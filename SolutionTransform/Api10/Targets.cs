using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionTransform.Model;
using SolutionTransform.ProjectFile;

namespace SolutionTransform.Api10 {
    static class Targets {
        static Dictionary<string, ITransform> targets = new Dictionary<string, ITransform>(StringComparer.InvariantCultureIgnoreCase) {
            { "", new NullTransform()},
            { "DotNet35", DotNet35Transform() },
            { "DotNet40", DotNet40Transform() },
            { "Silverlight30", Silverlight30Transform() }
        };

        public static ITransform Target(string target) {
            ITransform result;
            if (targets.TryGetValue(target ?? "", out result)) {
                return result;
            }
            throw new ArgumentException(string.Format("Unrecognized target '{0}'.  Valid targets are:  {1}", target,
                string.Join(", ", targets.Keys.ToArray())));
        }

        static ITransform Silverlight30Transform() {
            return new CompositeTransform(
                new MainSilverlight30Transform(),
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
						{ "adodb" },
                    },
                new LocalizeGACedReferences()  // NUnit won't work without this
                );
        }

        static ITransform DotNet40Transform() {
            return new CompositeTransform(
               RemoveFlavourTargetsAndDefines(),
               new AddDefineConstant("DOTNET40"),
               new AddTarget(CsharpTarget),
               new ChangeTo40Framework()
           );
        }

        static ITransform DotNet35Transform() {
            return new CompositeTransform(
               RemoveFlavourTargetsAndDefines(),
               new AddDefineConstant("DOTNET35"),
               new AddTarget(CsharpTarget),
               new ReferenceMapTransform { "Microsoft.CSharp" },  // Remove references to Microsoft.CSharp
               new ChangeFrameworkVersion("v3.5")
           );
        }

        internal static ITransform RemoveFlavourTargetsAndDefines() {
            return new CompositeTransform(
                new RemoveDefineConstant("DOTNET35"),
                new RemoveDefineConstant("SILVERLIGHT"),
                new RemoveDefineConstant("DOTNET40"),
                new RemoveTarget("Microsoft.Silverlight.CSharp.targets"),
                new RemoveTarget("Microsoft.CSharp.targets")
                );
        }

        public static string Silverlight30Target {
            get {
                return @"$(MSBuildExtensionsPath32)\Microsoft\Silverlight\v3.0\Microsoft.Silverlight.CSharp.targets";
            }
        }

        public static string CsharpTarget {
            get { return @"$(MSBuildToolsPath)\Microsoft.CSharp.targets"; }
        }
    }
}
