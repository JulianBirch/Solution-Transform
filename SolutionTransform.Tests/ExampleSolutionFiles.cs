using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionTransform.Tests {
	static class ExampleSolutionFiles {
		internal static string strippedCoreSolutionMar2010 =
			@"

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
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Core-Modified"", ""src\Castle.Core\Castle.Core-Modified.csproj"", ""{E4FA5B53-7D36-429E-8E5C-53D5479242BA}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Core.Tests-Modified"", ""src\Castle.Core.Tests\Castle.Core.Tests-Modified.csproj"", ""{087AD3BF-5E40-450D-8138-FBB5F57AC474}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.DynamicProxy-Modified"", ""src\Castle.DynamicProxy\Castle.DynamicProxy-Modified.csproj"", ""{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.DynamicProxy.Tests-Modified"", ""src\Castle.DynamicProxy.Tests\Castle.DynamicProxy.Tests-Modified.csproj"", ""{FE432670-73A1-499D-A353-28FC902A43C8}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
		ReleaseSL3|Any CPU = ReleaseSL3|Any CPU
		ReleaseSL4|Any CPU = ReleaseSL4|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.Release|Any CPU.Build.0 = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.ReleaseSL3|Any CPU.ActiveCfg = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.ReleaseSL3|Any CPU.Build.0 = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.ReleaseSL4|Any CPU.ActiveCfg = Release|Any CPU
		{E4FA5B53-7D36-429E-8E5C-53D5479242BA}.ReleaseSL4|Any CPU.Build.0 = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.Release|Any CPU.Build.0 = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.ReleaseSL3|Any CPU.ActiveCfg = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.ReleaseSL3|Any CPU.Build.0 = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.ReleaseSL4|Any CPU.ActiveCfg = Release|Any CPU
		{087AD3BF-5E40-450D-8138-FBB5F57AC474}.ReleaseSL4|Any CPU.Build.0 = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.Release|Any CPU.Build.0 = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.ReleaseSL3|Any CPU.ActiveCfg = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.ReleaseSL3|Any CPU.Build.0 = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.ReleaseSL4|Any CPU.ActiveCfg = Release|Any CPU
		{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}.ReleaseSL4|Any CPU.Build.0 = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.Release|Any CPU.Build.0 = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.ReleaseSL3|Any CPU.ActiveCfg = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.ReleaseSL3|Any CPU.Build.0 = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.ReleaseSL4|Any CPU.ActiveCfg = Release|Any CPU
		{FE432670-73A1-499D-A353-28FC902A43C8}.ReleaseSL4|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";
	}
}
