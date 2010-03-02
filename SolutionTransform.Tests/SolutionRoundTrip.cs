using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SolutionTransform.Solutions;
using NUnit.Framework;

namespace SolutionTransform.Tests {
    [TestFixture]
    public class SolutionRoundTrip {
        string iocSolutionJan2010 = @"
Microsoft Visual Studio Solution File, Format Version 10.00
# Visual Studio 2008
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""Solution Items"", ""Solution Items"", ""{F9A88F20-64E5-442C-8C20-10C69A39EF4C}""
	ProjectSection(SolutionItems) = preProject
		Changes.txt = Changes.txt
		License.txt = License.txt
		Readme.txt = Readme.txt
	EndProjectSection
	ProjectSection(FolderStartupServices) = postProject
		{B4F97281-0DBD-4835-9ED8-7DFB966E87FF} = {B4F97281-0DBD-4835-9ED8-7DFB966E87FF}
	EndProjectSection
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.MicroKernel-vs2008"", ""Castle.MicroKernel\Castle.MicroKernel-vs2008.csproj"", ""{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Windsor-vs2008"", ""Castle.Windsor\Castle.Windsor-vs2008.csproj"", ""{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.MicroKernel.Tests-vs2008"", ""Castle.MicroKernel.Tests\Castle.MicroKernel.Tests-vs2008.csproj"", ""{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}""
EndProject
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""Castle.Windsor.Tests-vs2008"", ""Castle.Windsor.Tests\Castle.Windsor.Tests-vs2008.csproj"", ""{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}.Release|Any CPU.Build.0 = Release|Any CPU
		{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}.Release|Any CPU.Build.0 = Release|Any CPU
		{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}.Release|Any CPU.Build.0 = Release|Any CPU
		{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(TextTemplating) = postSolution
		TextTemplating = 1
	EndGlobalSection
EndGlobal
";

        [Test]
        public void CanRoundTripSolutionFile()
        {
            var parser = new SolutionFileParser(new FakeFileSystem());
            var solutionFile = parser.Parse(new FilePath ("c:\\x.sln", false), iocSolutionJan2010.AsLines());
            var roundTripped = ToSolutionString(solutionFile.Lines());
            Assert.That(roundTripped, Is.EqualTo(iocSolutionJan2010), "Roundtripping loading the solution should not have changed it at all.");
        }

        string ToSolutionString(IEnumerable<string> lines)
        {
            return string.Join(Environment.NewLine, lines.ToArray()) + Environment.NewLine;
        }

        [Test]
        public void CanFindProjectConfigurationSections() {
            var parser = new SolutionFileParser(new FakeFileSystem());
            var solution = parser.Parse(new FilePath("c:\\x.sln", false), iocSolutionJan2010.AsLines());
            Assert.IsNotNull(solution.Globals);
            Assert.IsNotNull(solution.Globals.ProjectConfigurationPlatforms);
            Assert.IsNotNull(solution.Globals.SolutionConfigurationPlatforms);
        }

        [Test]
        public void SyncBackDoesntDuplicate()
        {
            var fileSystem = new CsprojDefaultingFileSystem();
            string solutionFileName = @"C:\Projects\MicroKernel.sln";
            var filePath = new FilePath(solutionFileName, false);
            var originalLines = iocSolutionJan2010.AsLines();
            fileSystem.Save(filePath, originalLines);
            Program.Main(fileSystem, new[] { 
                "Modify",     
                "--solution", 
                solutionFileName,
                "--add", 
                @"C:\TestAssembly.csproj"
            });
            Program.Main(fileSystem, new[] { 
                "Sync",
                "--fromSolution", 
                @"C:\Projects\MicroKernel-Modified.sln", 
                "--toSolution", 
                solutionFileName,
                "--rename",
                "",
                "--assemblyPaths",
                "lib" });
            var roundTripped = fileSystem.LoadAsLines(filePath);
            var roundTrippedString = ToSolutionString(roundTripped);
            // Assert.That(roundTrippedString, Is.EqualTo(iocSolutionJan2010));

            Assert.That(roundTripped.Last(), Is.EqualTo("EndGlobal"));  // Should end with the global section
            var projectCount = roundTripped.Count(x => x == "EndProject");
            Assert.That(projectCount, Is.EqualTo(originalLines.Count(x => x == "EndProject")));
            // var parser = new SolutionFileParser(fileSystem);
            // var solution = parser.Parse(filePath, roundTripped);
            
        }
    }

    public class ExampleCsprojFiles
    {
        internal static XmlDocument ToDocument(string lines)
        {
            var result = new XmlDocument();
            result.LoadXml(lines);
            return result;
        }

        internal static string microKernel = @"
<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"" ToolsVersion=""3.5"">
  <PropertyGroup>
    <ProjectType>Local</ProjectType>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}</ProjectGuid>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ApplicationIcon>
    </ApplicationIcon>
    <AssemblyKeyContainerName>
    </AssemblyKeyContainerName>
    <AssemblyName>Castle.MicroKernel</AssemblyName>
    <AssemblyOriginatorKeyFile>..\..\CastleKey.snk</AssemblyOriginatorKeyFile>
    <DefaultClientScript>JScript</DefaultClientScript>
    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>
    <DefaultTargetSchema>IE50</DefaultTargetSchema>
    <DelaySign>false</DelaySign>
    <OutputType>Library</OutputType>
    <RootNamespace>Castle.MicroKernel</RootNamespace>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
    <StartupObject>
    </StartupObject>
    <FileUpgradeFlags>
    </FileUpgradeFlags>
    <UpgradeBackupLocation>
    </UpgradeBackupLocation>
    <SignAssembly>false</SignAssembly>
    <OldToolsVersion>2.0</OldToolsVersion>
    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <OutputPath>..\bin\temp\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE;DEBUG</DefineConstants>
    <DocumentationFile>..\bin\temp\Castle.MicroKernel.XML</DocumentationFile>
    <DebugSymbols>true</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>1591</NoWarn>
    <Optimize>false</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>full</DebugType>
    <ErrorReport>prompt</ErrorReport>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <OutputPath>..\bin\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE</DefineConstants>
    <DocumentationFile>..\bin\Castle.MicroKernel.XML</DocumentationFile>
    <DebugSymbols>false</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>1591</NoWarn>
    <Optimize>true</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>none</DebugType>
    <ErrorReport>prompt</ErrorReport>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""Castle.Core, Version=1.2.0.0, Culture=neutral, PublicKeyToken=407dd0808d44fbdc, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\net-3.5\Castle.Core.dll</HintPath>
    </Reference>
    <Reference Include=""System"">
      <Name>System</Name>
    </Reference>
    <Reference Include=""System.configuration"" />
    <Reference Include=""System.Core"">
      <RequiredTargetFramework>3.5</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Data"">
      <Name>System.Data</Name>
    </Reference>
    <Reference Include=""System.Runtime.Remoting"" />
    <Reference Include=""System.Web"" />
    <Reference Include=""System.Xml"">
      <Name>System.XML</Name>
    </Reference>
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""ComponentActivator\AbstractComponentActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ComponentActivator\ComponentActivatorException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ComponentActivator\DefaultComponentActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ComponentActivator\FactoryMethodActivator.cs"" />
    <Compile Include=""ComponentActivator\WebUserControlComponentActivator.cs"" />
    <Compile Include=""Context\Burden.cs"" />
    <Compile Include=""Context\Arguments.cs"" />
    <Compile Include=""Context\ComponentArgumentsEnumerator.cs"" />
    <Compile Include=""Context\NamedArgumentsStore.cs"" />
    <Compile Include=""Context\DependencyTrackingScope.cs"" />
    <Compile Include=""ComponentActivator\ExternalInstanceActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ComponentActivator\IComponentActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Context\CreationContext.cs"" />
    <Compile Include=""Context\IArgumentsStore.cs"" />
    <Compile Include=""Context\TypedArgumentsStore.cs"" />
    <Compile Include=""DefaultKernel.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""DefaultKernel_AddComponent.cs"" />
    <Compile Include=""DefaultKernel_Events.cs"" />
    <Compile Include=""DefaultKernel_Resolve.cs"" />
    <Compile Include=""Exceptions\CircularDependencyException.cs"" />
    <Compile Include=""Exceptions\ComponentNotFoundException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Exceptions\ComponentRegistrationException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Exceptions\KernelException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\AbstractFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\EventWiring\EventWiringException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\EventWiring\EventWiringFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\FacilityException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\FactorySupport\AccessorActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\FactorySupport\FactoryActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\FactorySupport\FactorySupportFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\IFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\CustomActivators\RemoteActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\CustomActivators\RemoteActivatorThroughConnector.cs"" />
    <Compile Include=""Facilities\Remoting\CustomActivators\RemoteActivatorThroughRegistry.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\CustomActivators\RemoteClientActivatedActivator.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\CustomActivators\RemoteMarshallerActivator.cs"" />
    <Compile Include=""Facilities\Remoting\RemotingFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\RemotingInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Remoting\RemotingRegistry.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Startable\StartableFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Startable\StartableFacilityRegistrationExtensions.cs"" />
    <Compile Include=""Facilities\Startable\StartConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\Startable\StopConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\TypedFactory\DefaultTypedFactoryComponentSelector.cs"" />
    <Compile Include=""Facilities\TypedFactory\Dispose.cs"" />
    <Compile Include=""Facilities\TypedFactory\Empty.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\TypedFactory\FactoryEntry.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\TypedFactory\FactoryInterceptor.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\TypedFactory\ITypedFactoryComponentSelector.cs"" />
    <Compile Include=""Facilities\TypedFactory\ITypedFactoryMethod.cs"" />
    <Compile Include=""Facilities\TypedFactory\Release.cs"" />
    <Compile Include=""Facilities\TypedFactory\Resolve.cs"" />
    <Compile Include=""Facilities\TypedFactory\TypedFactoryComponent.cs"" />
    <Compile Include=""Facilities\TypedFactory\TypedFactoryFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Facilities\TypedFactory\TypedFactoryInterceptor.cs"" />
    <Compile Include=""Facilities\TypedFactory\TypedFactoryRegistrationExtensions.cs"" />
    <Compile Include=""Handlers\AbstractHandler.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\ForwardingHandler.cs"" />
    <Compile Include=""Handlers\ParentHandlerWithChildResolver.cs"" />
    <Compile Include=""Handlers\DefaultGenericHandler.cs"" />
    <Compile Include=""Handlers\DefaultHandler.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\DefaultHandlerFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\HandlerException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\IExposeDependencyInfo.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\IHandler.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Handlers\IHandlerFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""IKernel.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""IKernelEvents.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""IKernel_AddComponent.cs"" />
    <Compile Include=""IKernel_Resolve.cs"" />
    <Compile Include=""LifecycleConcerns\DisposalConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""LifecycleConcerns\ILifecycleConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""LifecycleConcerns\InitializationConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""LifecycleConcerns\OnCreateActionDelegate.cs"" />
    <Compile Include=""LifecycleConcerns\OnCreatedStep.cs"" />
    <Compile Include=""LifecycleConcerns\SupportInitializeConcern.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\AbstractLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\ILifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\PerThreadLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\PerThreadThreadStaticLifestyleManager.cs"" />
    <Compile Include=""Lifestyle\PerWebRequestLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\PoolableLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\Pool\DefaultPool.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\Pool\DefaultPoolFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\Pool\IPool.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\Pool\IPoolFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\Pool\PoolException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\SingletonLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Lifestyle\TransientLifestyleManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\DefaultComponentModelBuilder.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\IComponentModelBuilder.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\IContributeComponentModelConstruction.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\AdditionalInterfacesInspector.cs"" />
    <Compile Include=""ModelBuilder\Inspectors\ComponentActivatorInspector.cs"" />
    <Compile Include=""ModelBuilder\Inspectors\ComponentProxyInspector.cs"" />
    <Compile Include=""ModelBuilder\Inspectors\ConfigurationModelInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\ConfigurationParametersInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\ConstructorDependenciesModelInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\ExtendedPropertiesConstants.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\GenericInspector.cs"" />
    <Compile Include=""ModelBuilder\Inspectors\InterceptorInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\LifecycleModelInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\LifestyleModelInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\MethodMetaInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ModelBuilder\Inspectors\MixinInspector.cs"" />
    <Compile Include=""ModelBuilder\Inspectors\PropertiesDependenciesModelInspector.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Proxy\ComponentReference.cs"" />
    <Compile Include=""Proxy\IModelInterceptorsSelector.cs"" />
    <Compile Include=""Proxy\InstanceReference.cs"" />
    <Compile Include=""Proxy\IProxyFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Proxy\IProxyHook.cs"" />
    <Compile Include=""Proxy\IReference.cs"" />
    <Compile Include=""Proxy\NotSupportedProxyFactory.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Proxy\ProxyConstants.cs"" />
    <Compile Include=""Proxy\ProxyOptions.cs"" />
    <Compile Include=""Proxy\ProxyUtil.cs"" />
    <Compile Include=""Registration\AbstractPropertyDescriptor.cs"" />
    <Compile Include=""Registration\AttributeDescriptor.cs"" />
    <Compile Include=""Registration\Component.cs"" />
    <Compile Include=""Registration\ComponentDependencyRegistrationExtensions.cs"" />
    <Compile Include=""Registration\ComponentDescriptor.cs"" />
    <Compile Include=""Registration\ComponentInstanceDescriptor.cs"" />
    <Compile Include=""Registration\ComponentRegistration.cs"" />
    <Compile Include=""Registration\ComponentRegistration.nonGeneric.cs"" />
    <Compile Include=""Registration\Configuration.cs"" />
    <Compile Include=""Registration\ConfigurationDescriptor.cs"" />
    <Compile Include=""Registration\CustomDependencyDescriptor.cs"" />
    <Compile Include=""Registration\ExtendedPropertiesDescriptor.cs"" />
    <Compile Include=""Registration\FactoryDescriptor.cs"" />
    <Compile Include=""Registration\OnCreateComponentDescriptor.cs"" />
    <Compile Include=""Registration\DynamicParametersDescriptor.cs"" />
    <Compile Include=""Registration\Interceptor\InterceptorSelectorDescriptor.cs"" />
    <Compile Include=""Registration\Interceptor\InterceptorDescriptor.cs"" />
    <Compile Include=""Registration\Interceptor\InterceptorGroup.cs"" />
    <Compile Include=""Registration\IRegistration.cs"" />
    <Compile Include=""Registration\Lifestyle\Custom.cs"" />
    <Compile Include=""Registration\Lifestyle\LifestyleDescriptor.cs"" />
    <Compile Include=""Registration\Lifestyle\LifestyleGroup.cs"" />
    <Compile Include=""Registration\Lifestyle\PerThread.cs"" />
    <Compile Include=""Registration\Lifestyle\PerWebRequest.cs"" />
    <Compile Include=""Registration\Lifestyle\Pooled.cs"" />
    <Compile Include=""Registration\Lifestyle\Singleton.cs"" />
    <Compile Include=""Registration\Lifestyle\Transient.cs"" />
    <Compile Include=""Registration\Parameter.cs"" />
    <Compile Include=""Registration\ParametersDescriptor.cs"" />
    <Compile Include=""Registration\Property.cs"" />
    <Compile Include=""Registration\Proxy\ProxyMixIns.cs"" />
    <Compile Include=""Registration\Proxy\ProxyGroup.cs"" />
    <Compile Include=""Registration\Proxy\ProxyInterfaces.cs"" />
    <Compile Include=""Registration\RegistrationGroup.cs"" />
    <Compile Include=""Registration\ServiceOverride.cs"" />
    <Compile Include=""Registration\ServiceOverrideDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\AllTypes.cs"" />
    <Compile Include=""Registration\Strategies\AllTypesOf.cs"" />
    <Compile Include=""Registration\Strategies\ConfigureDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\FromAssemblyDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\FromTypesDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\FromDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\ServiceDescriptor.cs"" />
    <Compile Include=""Registration\Strategies\BasedOnDescriptor.cs"" />
    <Compile Include=""Releasers\AllComponentsReleasePolicy.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Releasers\IReleasePolicy.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Releasers\LifecycledComponentsReleasePolicy.cs"" />
    <Compile Include=""Releasers\NoTrackingReleasePolicy.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Resolvers\DefaultDependencyResolver.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Resolvers\DependencyResolverException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Resolvers\IDependencyResolver.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Resolvers\ISubDependencyResolver.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Resolvers\SpecializedResolvers\ArrayResolver.cs"" />
    <Compile Include=""Resolvers\SpecializedResolvers\ListResolver.cs"" />
    <Compile Include=""SubSystems\AbstractSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Configuration\DefaultConfigurationStore.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Configuration\IConfigurationStore.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\AbstractTypeConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\ConverterException.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\ArrayConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\AttributeAwareConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\ComponentConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\ComponentModelConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\DefaultComplexConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\DictionaryConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\EnumConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\Generics\GenericDictionaryConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\Generics\IGenericCollectionConverterHelper.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\Generics\GenericListConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\ListConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\NullableConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\PrimitiveConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\Converters\TimeSpanConverter.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\TypeDescriptor.cs"" />
    <Compile Include=""SubSystems\Conversion\Converters\TypeNameConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\ConvertibleAttribute.cs"" />
    <Compile Include=""SubSystems\Conversion\DefaultConversionManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\IConversionManager.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\IKernelDependentConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\ITypeConverter.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Conversion\ITypeConverterContext.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\ISubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Naming\BinaryTreeComponentName.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Naming\ComponentName.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Naming\DefaultNamingSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Naming\IHandlerSelector.cs"" />
    <Compile Include=""Resolvers\ILazyComponentLoader.cs"" />
    <Compile Include=""SubSystems\Naming\KeySearchNamingSubSystem.cs"" />
    <Compile Include=""SubSystems\Naming\INamingSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Naming\NamingPartsSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Resource\DefaultResourceSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\Resource\IResourceSubSystem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SubSystems\SubSystemConstants.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Util\GenericTypeNameProvider.cs"" />
    <Compile Include=""Util\ReferenceComparer.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Util\ReferenceExpressionUtil.cs"">
      <SubType>Code</SubType>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <Service Include=""{B4F97281-0DBD-4835-9ED8-7DFB966E87FF}"" />
  </ItemGroup>
  <Import Project=""$(MSBuildBinPath)\Microsoft.CSharp.targets"" />
  <PropertyGroup>
    <PreBuildEvent>
    </PreBuildEvent>
    <PostBuildEvent>
    </PostBuildEvent>
  </PropertyGroup>
</Project>";
    }
}
