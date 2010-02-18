using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionTransform.Tests {
    public class QuickTests {

        public void MergeIocAndCore()
        {
            Program.Main(new [] { 
                "Merge", 
                "--toSolution",
                @"C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln",
                "--fromSolutions",
                @"C:\OSS3\Castle Core\src\Core-vs2008.sln",
                @"C:\OSS3\Castle DP\DynamicProxy\src\Castle.DynamicProxy2-vs2008.sln"
            });
        }

        public void RemoveJiliomLib()
        {
            Program.Main(new [] { 
                "Sync",
                "--fromSolution", 
                @"C:\Projects\Interfaces\Connectivity\FixJunction-Modified.sln", 
                "--toSolution", 
                @"C:\Projects\Interfaces\Connectivity\FixJunction.sln",
                "--rename",
                "",
                "--assemblyPaths",
                "lib"
            });
        }

        public void AddJiliomLib()
        {
            Program.Main(new [] { 
                "Modify",     
                "--solution", 
                @"C:\Projects\Interfaces\Connectivity\FixJunction.sln", 
                "--add", 
                @"C:\Projects\IOM\JILIOM\JILIOMLib\JILiomLIB.csproj"
            });
        }

        public void CastleSilverlight()
        {
            Program.Main(new [] { 
                "Modify",     
                "--solution", 
                @":\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln", 
            });
        }
    }
}
