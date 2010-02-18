// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Interpreter;
using SolutionTransform.CodingStandards;
using SolutionTransform.Model;
using SolutionTransform.ProjectFile;

using SolutionTransform.Solutions;
using SCIEnumerable = System.Collections.IEnumerable;

namespace SolutionTransform.Api10
{
    public class Api 
    {
        private readonly BooCommandLineParser commandLineParser;
        private readonly IFileSystem fileSystem;



        class ApiOption<TResult> : Option<IDictionary<string, object>>
        {
            public ApiOption(string name, bool isRequired, string description, OptionType optionType, Func<string, TResult> evaluate) : base(name, isRequired, optionType, description, ToParse(name, optionType == Api10.OptionType.MultipleValues, evaluate))
            {
                
            }

            static Action<IDictionary<string, object>, IEnumerable<string>> ToParse(string key, bool isList, Func<string, TResult> evaluate)
            {
                return (store, values) => {
                                          foreach (var v in values)
                                          {
                                              var value = evaluate(v);
                                              if (isList) {
                                                  var list = store.ContainsKey(key)
                                                                 ? (List<TResult>)store[key]
                                                                 : (List<TResult>)(store[key] = new List<TResult>());
                                                  list.Add(value);
                                              } else {
                                                  store[key] = value;
                                              }
                                          }
                };
                
                
            }
        }

        public Api(BooCommandLineParser commandLineParser, IFileSystem fileSystem)
        {
            this.commandLineParser = commandLineParser;
            this.fileSystem = fileSystem;
        }

        public void Parameters(params IOption[] options)
        {
            var rename = new Option<IDictionary<string, object>>("rename", false, OptionType.OneValue, "The rename rule for the projects and solution.  Use blank to overwrite the target solution.",
                (c, v) => standardRename = new StandardRename(v.FirstOrDefault()));
            var paths = new Option<IDictionary<string, object>>("assemblyPaths", false, OptionType.MultipleValues, "The location of reference assemblies.",
                (c, v) => assemblyPaths.AddRange(v));
            var modified = options.ToList();
            modified.Add(rename);
            modified.Add(paths);
            commandLineParser.Parameters(modified);
        }

        public IOption String(string name, string description)
        {
            return new ApiOption<string>(name, false, description, OptionType.OneValue, v => v);
        }

        public IOption StringList(string name, string description) {
            return new ApiOption<string>(name, false, description, OptionType.MultipleValues, v => v);
        }

        public IOption Solution(string name, string description) {
            return new ApiOption<SolutionTransformer>(name, true, description, OptionType.OneValue, GetSolutionFile);
        }

        public IOption SolutionList(string name, string description) {
            return new ApiOption<SolutionTransformer>(name, true, description, OptionType.MultipleValues, GetSolutionFile);
        }

        private static SolutionTransformer GetSolutionFile(string path) {
            var parser = new SolutionFileParser(new FileSystem());
            var filePath = new FilePath(path, false);
            return new SolutionTransformer(parser.Parse(filePath, filePath.FileContent().AsLines()));
        }

        public IRename StandardRename()
        {
            return standardRename;
        }
        public IRename StandardRename(string replacement)
        {
            return new StandardRename(replacement);
        }

        public IProjectFilter DontFilter()
        {
            return new DontFilter();
        }

        public ITransform RebaseAssemblies(SolutionTransformer transformer, params string[] relativePaths)
        {
            if (relativePaths.Length == 0)
            {
                if (assemblyPaths.Count == 0)
                {
                    // No reference assembly paths specified.  Do nothing
                    return new NullTransform();
                }
                relativePaths = assemblyPaths.ToArray();
            }
            return new RebaseAssemblies(transformer.BasePath, relativePaths);
        }


        public ITransform ChangeOutputPaths(string relativeOutputPath)
        {
            return new ChangeOutputPaths(new FilePath(relativeOutputPath, true, false));
        }

        public ITransform Silverlight30Transform()
        {
            return new CompositeTransform(
                new MainSolutionTransform(),
                RemoveFlavourTargetsAndDefines(),
                new AddDefineConstant("SILVERLIGHT"),
                new AddTarget(Silverlight30Target),
                new ReferenceMapTransform
                    {
                        { "System", "mscorlib", "system" },
                        { "System.Data" },
                        { "System.Data.DataSetExtensions" },
                        { "System.Web" },
                        { "System.Configuration" },
                        { "System.Runtime.Remoting" },
                    },
                new LocalizeGACedReferences()
                );
        }

        static readonly string Silverlight30Target = @"$(MSBuildExtensionsPath32)\Microsoft\Silverlight\v3.0\Microsoft.Silverlight.CSharp.targets";
        static readonly string CsharpTarget = @"(MSBuildToolsPath)\Microsoft.CSharp.targets";
        private IRename standardRename = new StandardRename("-Modified");
        private List<string> assemblyPaths = new List<string>();

        public ITransform RemoveFlavourTargetsAndDefines()
        {
            return new CompositeTransform(
                new RemoveDefineConstant("DOTNET35"),
                new RemoveDefineConstant("SILVERLIGHT"),
                new RemoveTarget("Microsoft.Silverlight.CSharp.targets"),
                new RemoveTarget("Microsoft.CSharp.targets")
                );
        }

        public ITransform CastleStandardsTransform()
        {
            return new StandardizeTransform(new CastleStandardizer());
        }

        public ISolutionCommand Modify(List<string> toAdd, List<string> toRemove)
        {
            toAdd = toAdd ?? new List<string>();
            toRemove = toRemove ?? new List<string>();

            var commands = toAdd.Select(a => (ISolutionCommand)new AddProjectCommand(a, fileSystem))
                .Union(
                    toRemove.Select(r => (ISolutionCommand) new RemoveProjectCommand(r))
                );
            return new CompositeCommand(commands.ToList());
        }

        public ISolutionCommand SyncFrom(SolutionTransformer solutionFrom)
        {
            return new SyncFromCommand(solutionFrom.Solution);
        }

        public ISolutionCommand MergeFrom(IEnumerable<SolutionTransformer> solutionsFrom) {
            return new MergeFromCommand(solutionsFrom.Select(s => s.Solution));
        }
    }
}