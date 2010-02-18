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

using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using SolutionTransform.Api10;
using SolutionTransform.Solutions;

[assembly:InternalsVisibleTo("SolutionTransform.Tests")]

namespace SolutionTransform {
	using System;

	public class Program {
        

        public static FilePath FullPath(string file)
        {
            if (file.Contains("\\"))
            {
                if (file.Contains(":"))
                {
                    return new FilePath(file, false);
                }
                return GetCurrentPath().File(file);
            }
            return FindScript(GetCurrentPath(), file);
        }

	    private static FilePath FindScript(FilePath path, string file)
	    {
            var searchPath = path.File(file);
	        if (File.Exists(searchPath.Path))
	        {
                return searchPath;
	        }
            searchPath = path.Directory("Scripts").File(file);
            if (File.Exists(searchPath.Path)) {
                return searchPath;
            }
            var parent = path.Parent;
            if (parent == null)
            {
                return null;
            }
            return FindScript(parent, file);
	    }

	    public static FilePath GetCurrentPath()
        {
            var executablePath = Assembly.GetExecutingAssembly().CodeBase;
            return ToLocal(Path.GetDirectoryName(executablePath));
        }

        static FilePath ToLocal(string uriStyle)
        {
            string result = uriStyle.Replace("/", "\\");
            return new FilePath(result.Substring(6), true);
        }

        
		public static int Main(string[] args)
		{
		    if (args.Length == 0) {
				Console.WriteLine("Usage:\tSolutionTransform <Script Name or Path> <Other Arguments>");
                Console.WriteLine("\t\tSolutionTransform <Script Name or Path> --help");
                Console.WriteLine("\t\t\tfor script argument help");
                Console.WriteLine("\t\t\tNote that paths nearly always have to be absolute.");
                return 0;
			}
		    return ExecuteScript(args);
		}

	    private static int ExecuteScript(string[] args)
	    {
	        try
	        {
	            var interpreter = new Boo.Lang.Interpreter.InteractiveInterpreter2();
                
                var parser = new BooCommandLineParser(interpreter, args);
                var api10 = new Api(parser, new FileSystem());
	            // api10.Parameters();
                    
	            interpreter.SetValue("api10", api10);
                    
	            string script = GetScriptContents(args[0]);
	            CompilerContext context;
	            try
	            {
	                context = interpreter.Eval(script);
	            } catch(TargetInvocationException ex)
	            {
	                throw ex.InnerException;
	            }
	            foreach (var e in context.Errors)
	            {
	                Console.WriteLine(e.ToString());
	            }
	            if (context.Errors.Count != 0)
	            {
	                return 2;
	            }
	        } catch (NonErrorTerminationException)
	        {
	            return 0;
	        }
	        catch (Exception ex) {
	            WriteException(Console.Out, ex);
	            return 1;
	        }
	        return 0;
	    }

	    private static string GetScriptContents(string scriptFile)
	    {
	        if (!scriptFile.Contains("."))
	        {
	            scriptFile += ".boo";
	        }
	        return FullPath(scriptFile).FileContent();
	    }

	    static void WriteException(TextWriter writer, Exception ex)
        {
            writer.WriteLine(ex.Message);
            writer.WriteLine();
            writer.WriteLine(ex.StackTrace);
            var inner = ex.InnerException;
            if (inner != null)
            {
                writer.WriteLine("======");
                WriteException(writer, inner);
            }
            
        }
	}
}
