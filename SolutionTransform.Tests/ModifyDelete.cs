using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SolutionTransform.Tests {
    class ModifyDelete {
        string castleCoreWithLogging = @"
Microsoft Visual Studio Solution File, Format Version 10.00
# Visual Studio 2008
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""Solution Items"", ""Solution Items"", ""{8C53C104-3557-4C1A-B653-C4E6C46DB48E}""
	ProjectSection(SolutionItems) = preProject
		Changes-logging.txt = Changes-logging.txt
		Changes.txt = Changes.txt
		License.txt = License.txt
		Settings.proj = Settings.proj
	EndProjectSection
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Core-vs2008"", ""src\Castle.Core\Castle.Core-vs2008.csproj"", ""{E4FA5B53-7D36-429E-8E5C-53D5479242BA}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Core.Tests-vs2008"", ""src\Castle.Core.Tests\Castle.Core.Tests-vs2008.csproj"", ""{087AD3BF-5E40-450D-8138-FBB5F57AC474}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Services.Logging.log4netIntegration-vs2008"", ""src\Castle.Services.Logging.log4netIntegration\Castle.Services.Logging.log4netIntegration-vs2008.csproj"", ""{FA79D6B4-30B1-444A-A627-ED283BF6406B}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Services.Logging.NLogIntegration-vs2008"", ""src\Castle.Services.Logging.NLogIntegration\Castle.Services.Logging.NLogIntegration-vs2008.csproj"", ""{D680B5DB-B943-4BB5-891A-1695DEF86A3A}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Release|Any CPU.Build.0 = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Release|Any CPU.Build.0 = Release|Any CPU
		{FA79D6B4-30B1-444A-A627-ED283BF6406B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{FA79D6B4-30B1-444A-A627-ED283BF6406B}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{FA79D6B4-30B1-444A-A627-ED283BF6406B}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{FA79D6B4-30B1-444A-A627-ED283BF6406B}.Release|Any CPU.Build.0 = Release|Any CPU
		{D680B5DB-B943-4BB5-891A-1695DEF86A3A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D680B5DB-B943-4BB5-891A-1695DEF86A3A}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D680B5DB-B943-4BB5-891A-1695DEF86A3A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D680B5DB-B943-4BB5-891A-1695DEF86A3A}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal";

    	

    	

		[Test]
		public void CanExplicitlyRemoveAReference()
		{
			var fileSystem = new CsprojDefaultingFileSystem(ExampleCsprojFiles.dynamicProxyTests);
			fileSystem.SetSolutionText(
                                @"D:\envision\CastleCore\Castle.Core\Castle.Core-Modified.sln",
								ExampleSolutionFiles.strippedCoreSolutionMar2010);
			Program.Main(fileSystem, new[] { 
                "ModifyProject",
                "--solution",
                @"D:\envision\CastleCore\Castle.Core\Castle.Core-Modified.sln",
				"--project",
                "Castle.DynamicProxy.Tests-Modified",
                "--removeAssembly",
                "Rhino.Mocks.CPP.Interfaces"
            });

			var touched =
				fileSystem.LoadAsDocument(
					@"D:\envision\CastleCore\Castle.Core\src\Castle.DynamicProxy.Tests\Castle.DynamicProxy.Tests-Modified.csproj");
					

			var untouched
				= fileSystem.LoadAsDocument(
					@"D:\envision\CastleCore\Castle.Core\src\Castle.Core.Tests\Castle.Core.Tests-Modified.csproj)");
			Assert.That(untouched.OuterXml, Contains.Substring("Rhino.Mocks.CPP.Interfaces"), "Core tests should still have Rhino Mocks reference.");
			Assert.IsFalse(touched.OuterXml.Contains("Rhino.Mocks.CPP.Interfaces"), "DynamicProxy tests should not have Rhino Mocks reference.");
		}


        [Test]
        public void SyncBackDoesntDuplicate() {
            var fileSystem = new CsprojDefaultingFileSystem();
			IEnumerable<string> originalLines = fileSystem.SetSolutionText(
				@"C:\dev\Castle\git\Core\Castle.Core-vs2008.sln", castleCoreWithLogging);
        	Program.Main(fileSystem, new[] { 
                "Modify",
                "--solution",
                @"C:\dev\Castle\git\Core\Castle.Core-vs2008.sln",
                "--rename",
                "-vs2008sl",
                "--remove",
                "Castle.Services.Logging.log4netIntegration-vs2008"
            });

            var silverlightSolutionPath = new FilePath(@"C:\dev\Castle\git\Core\Castle.Core-vs2008SL.sln", false);

            var silverlightLines = fileSystem.LoadAsLines(silverlightSolutionPath);


            var projectCount = silverlightLines.Count(x => x == "EndProject");
            Assert.That(projectCount, Is.EqualTo(originalLines.Count(x => x == "EndProject") - 1));


            Program.Main(fileSystem, new[] { 
                "Modify",
                "--solution",
                @"C:\dev\Castle\git\Core\Castle.Core-vs2008.sln",
                "--rename",
                "-vs2008sl",
                "--remove",
                "Castle.Services.Logging.log4netIntegration-vs2008",
                "Castle.Services.Logging.NLogIntegration-vs2008"
            });

            var silverlightLines2 = fileSystem.LoadAsLines(silverlightSolutionPath);
            var projectCount2 = silverlightLines2.Count(x => x == "EndProject");
            Assert.That(projectCount2, Is.EqualTo(originalLines.Count(x => x == "EndProject") - 2));
        }

    	
    }
}
