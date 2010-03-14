using System.Xml;

namespace SolutionTransform.Tests
{
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


		internal static string iocTests = @"
<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"" ToolsVersion=""3.5"">
  <PropertyGroup>
    <ProjectType>Local</ProjectType>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{CB3A30A6-56D4-4F4F-9AEF-DA55E1FF6D74}</ProjectGuid>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ApplicationIcon>
    </ApplicationIcon>
    <AssemblyKeyContainerName>
    </AssemblyKeyContainerName>
    <AssemblyName>Castle.Windsor.Tests</AssemblyName>
    <AssemblyOriginatorKeyFile>
    </AssemblyOriginatorKeyFile>
    <DefaultClientScript>JScript</DefaultClientScript>
    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>
    <DefaultTargetSchema>IE50</DefaultTargetSchema>
    <DelaySign>false</DelaySign>
    <OutputType>Library</OutputType>
    <RootNamespace>Castle.Windsor.Tests</RootNamespace>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
    <StartupObject>
    </StartupObject>
    <FileUpgradeFlags>
    </FileUpgradeFlags>
    <UpgradeBackupLocation>
    </UpgradeBackupLocation>
    <OldToolsVersion>2.0</OldToolsVersion>
    <PublishUrl>http://localhost/Castle.Windsor.Tests/</PublishUrl>
    <Install>true</Install>
    <InstallFrom>Web</InstallFrom>
    <UpdateEnabled>true</UpdateEnabled>
    <UpdateMode>Foreground</UpdateMode>
    <UpdateInterval>7</UpdateInterval>
    <UpdateIntervalUnits>Days</UpdateIntervalUnits>
    <UpdatePeriodically>false</UpdatePeriodically>
    <UpdateRequired>false</UpdateRequired>
    <MapFileExtensions>true</MapFileExtensions>
    <ApplicationRevision>0</ApplicationRevision>
    <ApplicationVersion>1.0.0.%2a</ApplicationVersion>
    <IsWebBootstrapper>true</IsWebBootstrapper>
    <UseApplicationTrust>false</UseApplicationTrust>
    <BootstrapperEnabled>true</BootstrapperEnabled>
    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <OutputPath>..\bin\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE;DEBUG</DefineConstants>
    <DocumentationFile>
    </DocumentationFile>
    <DebugSymbols>true</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>
    </NoWarn>
    <Optimize>false</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>full</DebugType>
    <ErrorReport>prompt</ErrorReport>
    <UseVSHostingProcess>false</UseVSHostingProcess>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <OutputPath>bin\Release\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE</DefineConstants>
    <DocumentationFile>
    </DocumentationFile>
    <DebugSymbols>false</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>
    </NoWarn>
    <Optimize>true</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>none</DebugType>
    <ErrorReport>prompt</ErrorReport>
    <UseVSHostingProcess>true</UseVSHostingProcess>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""Castle.Core, Version=1.2.0.0, Culture=neutral, PublicKeyToken=407dd0808d44fbdc, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\net-3.5\Castle.Core.dll</HintPath>
    </Reference>
    <Reference Include=""Castle.DynamicProxy2, Version=2.2.0.0, Culture=neutral, PublicKeyToken=407dd0808d44fbdc, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\net-3.5\Castle.DynamicProxy2.dll</HintPath>
    </Reference>
    <Reference Include=""nunit.framework, Version=2.5.0.9122, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\nunit.framework.dll</HintPath>
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
    <Reference Include=""System.Xml"">
      <Name>System.XML</Name>
    </Reference>
    <ProjectReference Include=""..\Castle.MicroKernel.Tests\Castle.MicroKernel.Tests-vs2008.csproj"">
      <Project>{EF9313A4-C6E0-40F7-9E3F-530D547D3AEF}</Project>
      <Name>Castle.MicroKernel.Tests-vs2008</Name>
    </ProjectReference>
    <ProjectReference Include=""..\Castle.MicroKernel\Castle.MicroKernel-vs2008.csproj"">
      <Name>Castle.MicroKernel-vs2008</Name>
      <Project>{8C6AADEB-D099-4D2A-8F5B-4EBC12AC9159}</Project>
      <Package>{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</Package>
    </ProjectReference>
    <ProjectReference Include=""..\Castle.Windsor\Castle.Windsor-vs2008.csproj"">
      <Name>Castle.Windsor-vs2008</Name>
      <Project>{60EFCB9B-E3FF-46A5-A2D2-D9F0EF75D5FE}</Project>
      <Package>{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</Package>
      <Private>True</Private>
    </ProjectReference>
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""Adapters\ComponentModel\ContainerAdapterTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Adapters\ComponentModel\TestComponent.cs"">
      <SubType>Component</SubType>
    </Compile>
    <Compile Include=""Bugs\FACILITIES-ISSUE-111\Components\A_Facilities_Issue_111.cs"" />
    <Compile Include=""Bugs\FACILITIES-ISSUE-111\Components\B_Facilities_Issue_111.cs"" />
    <Compile Include=""Bugs\FACILITIES-ISSUE-111\Components\IA_Facilities_Issue_111.cs"" />
    <Compile Include=""Bugs\FACILITIES-ISSUE-111\Components\IB_Facilities_Issue_111.cs"" />
    <Compile Include=""Bugs\FACILITIES-ISSUE-111\FACILITIES_ISSUE_111.cs"" />
    <Compile Include=""Bugs\IoC-102.cs"" />
    <Compile Include=""Bugs\IoC-115.cs"" />
    <Compile Include=""Bugs\IoC-127.cs"" />
    <Compile Include=""Bugs\IoC-138.cs"" />
    <Compile Include=""Bugs\IoC-73\ClassUser.cs"" />
    <Compile Include=""Bugs\IoC-73\IMyClass.cs"" />
    <Compile Include=""Bugs\IoC-73\MyClass.cs"" />
    <Compile Include=""Bugs\IoC-73\IoC73.cs"" />
    <Compile Include=""Bugs\IoC-73\Proxy.cs"" />
    <Compile Include=""Bugs\IoC-78\IoC-78.cs"" />
    <Compile Include=""Bugs\IoC_103\IoC_103.cs"" />
    <Compile Include=""Bugs\IoC_120.cs"" />
    <Compile Include=""Bugs\IoC_142.cs"" />
    <Compile Include=""Bugs\IoC_147.cs"" />
    <Compile Include=""Bugs\IoC_155.cs"" />
    <Compile Include=""Bugs\IoC_169\IoC_169.cs"" />
    <Compile Include=""Bugs\IoC_92.cs"" />
    <Compile Include=""ChildContainerSupportTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""CircularDependencyTests.cs"" />
    <Compile Include=""Components\CalculatorService.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\CalculatorServiceWithAttributes.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\CalculatorServiceWithInternalInterface.cs"" />
    <Compile Include=""Components\CalculatorServiceWithLifecycle.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\Camera.cs"" />
    <Compile Include=""Components\CircularDependencyComponents.cs"" />
    <Compile Include=""Components\ComponentWithConfigs.cs"" />
    <Compile Include=""Components\ComponentWithProperties.cs"" />
    <Compile Include=""Components\ComponentWithStringProperty.cs"" />
    <Compile Include=""Components\CalculatorServiceWithProxyBehavior.cs"" />
    <Compile Include=""Components\DotNet2Components.cs"" />
    <Compile Include=""Components\Employee.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\ICalcService.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\IEmployee.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\IReviewableEmployee.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\IReviewer.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\MailServer.cs"" />
    <Compile Include=""Components\MarshalCalculatorService.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\ReviewableEmployee.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\Reviewer.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\Robot.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Components\SimpleMixIn.cs"" />
    <Compile Include=""ConfigHelper.cs"" />
    <Compile Include=""Configuration2\ConfigurationEnvTestCase.cs"" />
    <Compile Include=""Configuration2\ConfigurationForwardedTypesTestCase.cs"" />
    <Compile Include=""Configuration2\ConfigWithStatementsTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Configuration2\EvalSupportTestCase.cs"" />
    <Compile Include=""Configuration2\IncludesTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Configuration2\Properties\PropertiesTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Configuration2\SynchronizationProblemTestCase.cs"" />
    <Compile Include=""Configuration\AppDomainConfigurationStoreTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""Configuration\ConfigXmlInterpreterTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ConfigureDecoratorsTestCase.cs"" />
    <Compile Include=""ContainerProblem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""ContainerProblem2.cs"" />
    <Compile Include=""Facilities\EventWiring\InvalidConfigTestCase.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\GenericService.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\Handlers.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\MultiListener.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\MultiPublisher.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\MyInterceptor.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\PublisherListener.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\SimpleListener.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\SimplePublisher.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\SimpleService.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\SubscriberWithDependency.cs"" />
    <Compile Include=""Facilities\EventWiring\Model\SubscriberWithGenericDependency.cs"" />
    <Compile Include=""Facilities\EventWiring\ProxiedSubscriberTestCase.cs"" />
    <Compile Include=""Facilities\EventWiring\SingletonComponentsTestCase.cs"" />
    <Compile Include=""Facilities\EventWiring\SingletonStartableTestCase.cs"" />
    <Compile Include=""Facilities\EventWiring\SubscriberWithDependenciesTestCase.cs"" />
    <Compile Include=""Facilities\EventWiring\WiringTestBase.cs"" />
    <Compile Include=""Facilities\Remoting\AbstractRemoteTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\AppDomainFactory.cs"" />
    <Compile Include=""Facilities\Remoting\CalcServiceImpl.cs"" />
    <Compile Include=""Facilities\Remoting\ChangeResultInterceptor.cs"" />
    <Compile Include=""Facilities\Remoting\ConfigurableRegistrationTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\ConsumerComp.cs"" />
    <Compile Include=""Facilities\Remoting\CustomToStringService.cs"" />
    <Compile Include=""Facilities\Remoting\FacilityLifeCycleTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\GenericToStringServiceImpl.cs"" />
    <Compile Include=""Facilities\Remoting\ICalcService.cs"" />
    <Compile Include=""Facilities\Remoting\IGenericHashService.cs"" />
    <Compile Include=""Facilities\Remoting\InterceptableCalcService.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteClientActivatedTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteComponentTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteComponentWithInterceptorTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteGenericComponentTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteRecoverableCpntTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\RemoteSingletonTestCase.cs"" />
    <Compile Include=""Facilities\Remoting\ServerClientContainerTestCase.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\Component1.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\Component2.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\IDummyComponent.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\IProtocolHandler.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\MessengerProtocolHandler.cs"" />
    <Compile Include=""Facilities\TypedFactory\Components\MirandaProtocolHandler.cs"" />
    <Compile Include=""Facilities\TypedFactory\ExternalConfigurationTestCase.cs"" />
    <Compile Include=""Facilities\TypedFactory\Factories\IComponentFactory.cs"" />
    <Compile Include=""Facilities\TypedFactory\Factories\IProtocolHandlerFactory.cs"" />
    <Compile Include=""Facilities\TypedFactory\TypedFactoryTestCase.cs"" />
    <Compile Include=""InterceptorSelectorTestCase.cs"" />
    <Compile Include=""OpenGenericsTestCase.cs"" />
    <Compile Include=""RegisteringTwoServicesForSameType.cs"" />
    <Compile Include=""SubResolversShouldNotBeTrustedToBeCorrect.cs"" />
    <Compile Include=""ModelInterceptorsSelectorTestCase.cs"" />
    <Compile Include=""DependencyProblem.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Content Include=""ignoreprop.xml"" />
    <Content Include=""DotNet2Config\ComplexGenericConfig.xml"" />
    <Content Include=""DotNet2Config\GenericDecoratorConfig.xml"" />
    <Content Include=""DotNet2Config\MissingDecoratorConfig.xml"" />
    <Content Include=""DotNet2Config\RecursiveDecoratorConfig.xml"" />
    <Content Include=""DotNet2Config\DecoratorConfig.xml"">
      <SubType>
      </SubType>
    </Content>
    <Compile Include=""Facilities\SlowlyInitFacility.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""HandlerSelectorsTestCase.cs"" />
    <Compile Include=""IgnoreWireTestCase.cs"" />
    <Compile Include=""Installer\ConfigurationInstallerTestCase.cs"" />
    <Compile Include=""Installer\InstallerTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""InterceptorsTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""MultiResolveTests.cs"" />
    <Compile Include=""PropertiesInspectionBehaviorTestCase.cs"" />
    <Compile Include=""Proxy\MixInTestCase.cs"" />
    <Compile Include=""Proxy\FactorySupportTestCase.cs"" />
    <Compile Include=""Proxy\TypedFactoryFacilityTestCase.cs"" />
    <Compile Include=""Proxy\ProxyBehaviorInvalidTestCase.cs"" />
    <Compile Include=""Proxy\ProxyBehaviorTestCase.cs"" />
    <Compile Include=""ReportedProblemTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""RobotWireTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""SmartProxyTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""WindsorDotNet2Tests.cs"" />
    <Compile Include=""XmlProcessor\XmlProcessorTestCase.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Content Include=""Configuration2\Properties\config_with_missing_properties.xml"" />
    <Content Include=""Configuration2\Properties\config_with_properties.xml"" />
    <Content Include=""Configuration2\Properties\config_with_properties_and_defines.xml"" />
    <Content Include=""Configuration2\Properties\config_with_properties_and_defines2.xml"" />
    <Content Include=""Configuration2\Properties\config_with_properties_and_includes.xml"" />
    <Content Include=""Configuration2\Properties\config_with_silent_properties.xml"" />
    <Content Include=""Configuration2\Properties\properties.xml"" />
    <Content Include=""Configuration2\Properties\properties_using_properties.xml"" />
    <Content Include=""DotNet2Config\GenericsConfig.xml"" />
    <Content Include=""installerconfig.xml"" />
    <Content Include=""propertyInspectionBehavior.xml"" />
    <Content Include=""propertyInspectionBehaviorInvalid.xml"" />
    <Content Include=""robotwireconfig.xml"" />
    <Content Include=""sample_config.xml"" />
    <Content Include=""XmlProcessor\TestFiles\AssemblyIncludeTestDisabled.xml"" />
    <Content Include=""XmlProcessor\TestFiles\AssemblyIncludeTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ChooseStatement2Test.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ChooseStatement2TestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ChooseStatementTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ChooseStatementTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ComplexPropertiesTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\ComplexPropertiesTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\DefineDebugTestDisabled.xml"" />
    <Content Include=""XmlProcessor\TestFiles\DefineDebugTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\DefineDefaultTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\DefineDefaultTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\IfStatementTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\IfStatementTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidElseWithFlag.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidElsifWithNoFlag.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidFlag.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidIfWithNoFlag.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidPropertiesMissing.xml"" />
    <Content Include=""XmlProcessor\TestFiles\InvalidUnbalancedIfStatement.xml"" />
    <Content Include=""XmlProcessor\TestFiles\MultiInclude2Test.xml"" />
    <Content Include=""XmlProcessor\TestFiles\MultiInclude2TestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\MultiIncludeTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\MultiIncludeTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ChooseStatement2Test.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ChooseStatement2TestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ChooseStatementTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ChooseStatementTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ComplexChooseStatementTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ComplexChooseStatementTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ComplexDefineDefaultTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-ComplexDefineDefaultTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-DefineDebugTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-DefineDebugTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-DefineDefaultTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\Pi-DefineDefaultTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PI-IfStatementTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PI-IfStatementTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PropertiesMissingSilentTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PropertiesMissingSilentTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PropertiesWithAttributesTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\PropertiesWithAttributesTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\RelativeTest\Include1.xml"" />
    <Content Include=""XmlProcessor\TestFiles\RelativeTest\Include2.xml"" />
    <Content Include=""XmlProcessor\TestFiles\SimpleInclude.xml"" />
    <Content Include=""XmlProcessor\TestFiles\SimplePropertiesTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\SimplePropertiesTestResult.xml"" />
    <Content Include=""XmlProcessor\TestFiles\SimpleTest.xml"" />
    <Content Include=""XmlProcessor\TestFiles\SimpleTestResult.xml"" />
    <EmbeddedResource Include=""Adapters\ComponentModel\TestComponent.resx"">
      <DependentUpon>TestComponent.cs</DependentUpon>
      <SubType>Designer</SubType>
    </EmbeddedResource>
    <EmbeddedResource Include=""Configuration2\config_with_choose_stmt.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_define_debug.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_define_default.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_define_prod.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_define_qa.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_if_stmt.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_include.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_include_relative.xml"" />
    <EmbeddedResource Include=""Configuration2\config_with_include_relative2.xml"" />
    <EmbeddedResource Include=""Configuration2\include1.xml"" />
    <EmbeddedResource Include=""Configuration2\include2.xml"" />
    <EmbeddedResource Include=""Configuration2\RelativeTest\rel_include1.xml"" />
    <EmbeddedResource Include=""Configuration2\RelativeTest\rel_include2.xml"" />
    <EmbeddedResource Include=""Configuration2\resource_config_with_include.xml"" />
    <EmbeddedResource Include=""XmlProcessor\TestFiles\AssemblyInclude1.xml"" />
    <EmbeddedResource Include=""XmlProcessor\TestFiles\AssemblyInclude2.xml"" />
    <EmbeddedResource Include=""XmlProcessor\TestFiles\include1.xml"" />
    <EmbeddedResource Include=""XmlProcessor\TestFiles\include2.xml"" />
  </ItemGroup>
  <ItemGroup>
    <None Include=""App.config"" />
    <None Include=""DotNet2Config\chainOfRespnsability.config"" />
    <None Include=""DotNet2Config\chainOfRespnsability_smart.config"" />
    <None Include=""Facilities\EventWiring\App.config"" />
    <Content Include=""RemotingTcpConfig2.config"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include=""RemotingTcpConfigClient.config"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include=""RemotingTcpConfig.config"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <EmbeddedResource Include=""Facilities\EventWiring\Config\dependencies.config"" />
    <EmbeddedResource Include=""Facilities\EventWiring\Config\invalid.config"" />
    <EmbeddedResource Include=""Facilities\EventWiring\Config\singleton.config"" />
    <EmbeddedResource Include=""Facilities\EventWiring\Config\startable.config"" />
    <EmbeddedResource Include=""Configuration2\env_config.xml"" />
    <EmbeddedResource Include=""Configuration2\eval_config.xml"" />
    <Content Include=""Configuration2\config_with_forwarded_types.xml"" />
    <Content Include=""Configuration2\synchtest_config.xml"" />
    <EmbeddedResource Include=""sample_config_with_spaces.xml"" />
    <EmbeddedResource Include=""Configuration\sample_config.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_12134_kernelcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_clientactivated.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_confreg_clientactivated.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_kernelcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_kernelcomponent_recover.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_kernelgenericcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\client_simple_scenario.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_clientactivated.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_client_kernelcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_confreg_clientactivated.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_kernelcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_kernelcomponent_inter1.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_kernelcomponent_recover.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_kernelgenericcomponent.xml"" />
    <EmbeddedResource Include=""Facilities\Remoting\Configs\server_simple_scenario.xml"" />
    <EmbeddedResource Include=""Facilities\TypedFactory\typedFactory_castle_config.xml"" />
    <Content Include=""IOC-51.xml"" />
    <Content Include=""Proxy\typedFactory.xml"" />
    <Content Include=""Proxy\proxyBehaviorInvalidConfig.xml"" />
    <Content Include=""Proxy\proxyBehavior.xml"" />
    <Content Include=""Proxy\typedFactoryCreateWithoutId.xml"" />
  </ItemGroup>
  <ItemGroup>
    <Service Include=""{B4F97281-0DBD-4835-9ED8-7DFB966E87FF}"" />
  </ItemGroup>
  <ItemGroup>
    <BootstrapperPackage Include=""Microsoft.Net.Framework.2.0"">
      <Visible>False</Visible>
      <ProductName>.NET Framework 2.0 %28x86%29</ProductName>
      <Install>true</Install>
    </BootstrapperPackage>
    <BootstrapperPackage Include=""Microsoft.Net.Framework.3.0"">
      <Visible>False</Visible>
      <ProductName>.NET Framework 3.0 %28x86%29</ProductName>
      <Install>false</Install>
    </BootstrapperPackage>
    <BootstrapperPackage Include=""Microsoft.Net.Framework.3.5"">
      <Visible>False</Visible>
      <ProductName>.NET Framework 3.5</ProductName>
      <Install>false</Install>
    </BootstrapperPackage>
  </ItemGroup>
  <ItemGroup>
    <Folder Include=""Bugs\UnregisteringWithFactorySupport\"" />
  </ItemGroup>
  <Import Project=""$(MSBuildBinPath)\Microsoft.CSharp.targets"" />
  <PropertyGroup>
    <PreBuildEvent>
    </PreBuildEvent>
    <PostBuildEvent>
    </PostBuildEvent>
  </PropertyGroup>
</Project>";

		internal static string dynamicProxyTests =
		@"
<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"" ToolsVersion=""3.5"">
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{FE432670-73A1-499D-A353-28FC902A43C8}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>Castle.DynamicProxy.Tests</RootNamespace>
    <AssemblyName>Castle.DynamicProxy.Tests</AssemblyName>
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>..\..\buildscripts\CastleKey.snk</AssemblyOriginatorKeyFile>
    <FileUpgradeFlags>
    </FileUpgradeFlags>
    <OldToolsVersion>2.0</OldToolsVersion>
    <UpgradeBackupLocation>
    </UpgradeBackupLocation>
    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>TRACE;DEBUG;DOTNET35</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <NoWarn>
    </NoWarn>
    <UseVSHostingProcess>true</UseVSHostingProcess>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""adodb, Version=7.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\net-3.5\adodb.dll</HintPath>
    </Reference>
    <Reference Include=""nunit.framework, Version=2.5.0.9122, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\nunit.framework.dll</HintPath>
    </Reference>
    <Reference Include=""Rhino.Mocks.CPP.Interfaces, Version=1.0.3078.4206, Culture=neutral, PublicKeyToken=0b3305902db7183f, processorArchitecture=MSIL"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\..\lib\net-3.5\Rhino.Mocks.CPP.Interfaces.dll</HintPath>
    </Reference>
    <Reference Include=""System"" />
    <Reference Include=""System.configuration"" />
    <Reference Include=""System.Core"">
      <RequiredTargetFramework>3.5</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Data"" />
    <Reference Include=""System.Runtime.Serialization"">
      <RequiredTargetFramework>3.0</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.ServiceModel"">
      <RequiredTargetFramework>3.0</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Xml"" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""AccessLevelTestCase.cs"" />
    <Compile Include=""BasePEVerifyTestCase.cs"" />
    <Compile Include=""BasicClassProxyTestCase.cs"" />
    <Compile Include=""BasicInterfaceProxyTestCase.cs"" />
    <Compile Include=""Classes\AttributedClass.cs"" />
    <Compile Include=""Classes\ClassToSerialize.cs"" />
    <Compile Include=""Classes\ClassWithIndexer.cs"" />
    <Compile Include=""Classes\DiffAccessLevelOnProperties.cs"" />
    <Compile Include=""Classes\NonPublicConstructorClass.cs"" />
    <Compile Include=""Classes\NonPublicMethodsClass.cs"" />
    <Compile Include=""Classes\ServiceClass.cs"" />
    <Compile Include=""ClassWithAttributesTestCase.cs"" />
    <Compile Include=""GenClasses\ClassWithGenArgs.cs"" />
    <Compile Include=""GenClasses\ClassWithIndexer.cs"" />
    <Compile Include=""GenClasses\GenClassNameClash.cs"" />
    <Compile Include=""GenClasses\GenClassWithConstraints.cs"" />
    <Compile Include=""GenClasses\GenClassWithGenMethods.cs"" />
    <Compile Include=""GenClasses\GenClassWithGenMethodsConstrained.cs"" />
    <Compile Include=""GenClasses\GenClassWithGenReturn.cs"" />
    <Compile Include=""GenClasses\OnlyGenMethodsClass.cs"" />
    <Compile Include=""GenerationHookTestCase.cs"" />
    <Compile Include=""GenericClassProxyTestCase.cs"" />
    <Compile Include=""GenericInterfaceProxyTestCase.cs"" />
    <Compile Include=""GenInterfaces\GenInterface.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithGenericTypes.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithGenMethods.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithGenMethodsAndGenReturn.cs"" />
    <Compile Include=""Interceptors\LogInvocationInterceptor.cs"" />
    <Compile Include=""InterClasses\IExtendedService.cs"" />
    <Compile Include=""InterClasses\IService.cs"" />
    <Compile Include=""InterClasses\ServiceImpl.cs"" />
    <Compile Include=""MethodsWithAttributesOnParametersTestCase.cs"" />
    <Compile Include=""MixinTestCase.cs"" />
    <Compile Include=""XmlSerializationTestCase.cs"" />
  </ItemGroup>
  <ItemGroup>
    <None Include=""..\..\buildscripts\CastleKey.snk"">
      <Link>CastleKey.snk</Link>
    </None>
    <None Include=""App.config"" />
    <None Include=""Properties\Settings.settings"">
      <Generator>SettingsSingleFileGenerator</Generator>
      <LastGenOutput>Settings.Designer.cs</LastGenOutput>
    </None>
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""ChangeProxyTargetInterceptor.cs"" />
    <Compile Include=""Classes\ClassWithExplicitInterface.cs"" />
    <Compile Include=""Classes\ClassWith_Smart_Attribute.cs"" />
    <Compile Include=""Classes\VirtuallyImplementsInterfaceWithEvent.cs"" />
    <Compile Include=""ComInterfacesTests.cs"" />
    <Compile Include=""ExplicitInterfaceTestCase.cs"" />
    <Compile Include=""CustomAttributesTestCase.cs"" />
    <Compile Include=""GenClasses\GenClassWithExplicitImpl.cs"">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include=""GenInterfaces\GenInterfaceWithMethodWithNestedGenericParameter.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithMethodWithNestedGenericParameterByRef.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithMethodWithNestedGenericReturn.cs"" />
    <Compile Include=""Interceptors\AssertCanChangeTargetInterceptor.cs"" />
    <Compile Include=""Interceptors\AssertCannotChangeTargetInterceptor.cs"" />
    <Compile Include=""Interceptors\CallCountingInterceptor.cs"" />
    <Compile Include=""Interceptors\AddTwoInterceptor.cs"" />
    <Compile Include=""BaseTestCaseTestCase.cs"" />
    <Compile Include=""BasicInterfaceProxyWithoutTargetTestCase.cs"" />
    <Compile Include=""BugsReportedTestCase.cs"" />
    <Compile Include=""BugsReported\Camera.cs"" />
    <Compile Include=""BugsReported\ConstraintViolationInDebuggerTestCase.cs"" />
    <Compile Include=""BugsReported\DynProxy46.cs"" />
    <Compile Include=""BugsReported\DynProxy88.cs"" />
    <Compile Include=""CacheKeyTestCase.cs"" />
    <Compile Include=""CanDefineAdditionalCustomAttributes.cs"" />
    <Compile Include=""ClassEmitterTestCase.cs"" />
    <Compile Include=""Classes\ClassCallingVirtualMethodFromCtor.cs"" />
    <Compile Include=""Classes\ClassWithCharRetType.cs"" />
    <Compile Include=""Classes\ClassWithConstructors.cs"" />
    <Compile Include=""Classes\ClassWithVariousConstructors.cs"" />
    <Compile Include=""Classes\ClassWithInternalDefaultConstructor.cs"" />
    <Compile Include=""Classes\ClassWithProtectedDefaultConstructor.cs"" />
    <Compile Include=""Classes\MySerializableClass.cs"" />
    <Compile Include=""Classes\ProtectedInternalConstructorClass.cs"" />
    <Compile Include=""Classes\SimpleClass.cs"" />
    <Compile Include=""Classes\ClassOverridingEqualsAndGetHashCode.cs"" />
    <Compile Include=""Classes\ClassWithDefaultConstructor.cs"" />
    <Compile Include=""ClassProxyConstructorsTestCase.cs"" />
    <Compile Include=""Interceptors\DoNothingInterceptor.cs"" />
    <Compile Include=""GenClasses\ClassWithMethodWithArrayOfListOfT.cs"" />
    <Compile Include=""GenClasses\ClassWithMethodWithGenericOfGenericOfT.cs"" />
    <Compile Include=""GenClasses\ClassWithMethodWithReturnArrayOfListOfT.cs"" />
    <Compile Include=""GenClasses\MethodWithArgumentBeingArrayOfGenericTypeOfT.cs"" />
    <Compile Include=""GenericMethodsProxyTestCase.cs"" />
    <Compile Include=""DictionarySerializationTestCase.cs"" />
    <Compile Include=""GenInterfaces\GenericMethodWhereOneGenParamInheritsTheOther.cs"" />
    <Compile Include=""InterClasses\IInterfaceWithGenericMethodWithDependentConstraint.cs"" />
    <Compile Include=""InheritedInterfacesTestCase.cs"" />
    <Compile Include=""InterceptorSelectorTestCase.cs"" />
    <Compile Include=""InterfaceProxyBaseTypeTestCase.cs"" />
    <Compile Include=""InterfaceProxyWithTargetInterfaceTestCase.cs"" />
    <Compile Include=""Interfaces\IDecimalOutParam.cs"" />
    <Compile Include=""Interfaces\IdenticalInterfaces.cs"" />
    <Compile Include=""Interfaces\IEmpty.cs"" />
    <Compile Include=""Interfaces\IFooWithIntPtr.cs"" />
    <Compile Include=""Interfaces\IFooWithOutIntPtr.cs"" />
    <Compile Include=""Interfaces\IGenericWithRefOut.cs"" />
    <Compile Include=""Interfaces\INullable.cs"" />
    <Compile Include=""Interfaces\IOne.cs"" />
    <Compile Include=""Interfaces\ITwo.cs"" />
    <Compile Include=""Interfaces\IWithRefOut.cs"" />
    <Compile Include=""Interfaces\One.cs"" />
    <Compile Include=""Interfaces\OneTwo.cs"" />
    <Compile Include=""Interfaces\Two.cs"" />
    <Compile Include=""InvocationMethodInvocationTargetTestCase.cs"" />
    <Compile Include=""InvocationTypesCachingTestCase.cs"" />
    <Compile Include=""LoggingTestCase.cs"" />
    <Compile Include=""MethodEquivalenceTestCase.cs"" />
    <Compile Include=""MixinDataTestCase.cs"" />
    <Compile Include=""CrossAppDomainCaller.cs"" />
    <Compile Include=""MethodComparerTestCase.cs"" />
    <Compile Include=""GenericTestUtility.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceHierarchy.cs"" />
    <Compile Include=""GenInterfaces\GenExplicitImplementation.cs"" />
    <Compile Include=""GenInterfaces\GenInterfaceWithGenArray.cs"" />
    <Compile Include=""GenInterfaces\OnlyGenMethodsInterface.cs"" />
    <Compile Include=""Interceptors\ChangeTargetInterceptor.cs"" />
    <Compile Include=""Interceptors\KeepDataInterceptor.cs"" />
    <Compile Include=""InterClasses\AlwaysThrowsServiceImpl.cs"" />
    <Compile Include=""InterClasses\ClassWithIndexer.cs"" />
    <Compile Include=""InterClasses\ClassWithMarkerInterface.cs"" />
    <Compile Include=""InterClasses\ClassWithMultiDimentionalArray.cs"" />
    <Compile Include=""InterClasses\IClassWithMultiDimentionalArray.cs"" />
    <Compile Include=""InterClasses\IMyInterface2.cs"" />
    <Compile Include=""InterClasses\InterfaceWithIndexer.cs"" />
    <Compile Include=""InterClasses\IService2.cs"" />
    <Compile Include=""InvocationTestCase.cs"" />
    <Compile Include=""MethodFinderTestCase.cs"" />
    <Compile Include=""Mixins\ClassImplementingIDerivedSImpleMixin.cs"" />
    <Compile Include=""Mixins\ClassImplementingISimpleMixin.cs"" />
    <Compile Include=""Mixins\ComplexMixin.cs"" />
    <Compile Include=""Mixins\IDerivedSimpleMixin.cs"" />
    <Compile Include=""Mixins\OtherMixin.cs"" />
    <Compile Include=""Mixins\OtherMixinImplementingISimpleMixin.cs"" />
    <Compile Include=""Mixins\SimpleMixin.cs"" />
    <Compile Include=""ModuleScopeTestCase.cs"" />
    <Compile Include=""NonProxiedMethodsNoTargetTestCase.cs"" />
    <Compile Include=""NonProxiedMixinMethodsTestCase.cs"" />
    <Compile Include=""NonProxiedTargetMethodsTestCase.cs"" />
    <Compile Include=""OrderOfInterfacePrecedenceTestCase.cs"" />
    <Compile Include=""OutRefParams.cs"" />
    <Compile Include=""PersistentProxyBuilderTestCase.cs"" />
    <Compile Include=""Interceptors\ProceedOnTypeInterceptor.cs"" />
    <Compile Include=""Properties\Settings.Designer.cs"">
      <AutoGen>True</AutoGen>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
      <DependentUpon>Settings.settings</DependentUpon>
    </Compile>
    <Compile Include=""ProxyGenerationOptionsTestCase.cs"" />
    <Compile Include=""Interceptors\RequiredParamInterceptor.cs"" />
    <Compile Include=""ProxyKind.cs"" />
    <Compile Include=""ProxyNothingHook.cs"" />
    <Compile Include=""ProxyTargetAccessorHandlingTestCase.cs"" />
    <Compile Include=""RhinoMocksTestCase.cs"" />
    <Compile Include=""SerializableClassTestCase.cs"" />
    <Compile Include=""InternalsVisibleTo.cs"" />
    <Compile Include=""Interceptors\SetReturnValueInterceptor.cs"" />
    <Compile Include=""Interceptors\WithCallbackInterceptor.cs"" />
    <Compile Include=""Classes\VirtuallyImplementsInterfaceWithProperty.cs"" />
  </ItemGroup>
  <ItemGroup>
    <Service Include=""{B4F97281-0DBD-4835-9ED8-7DFB966E87FF}"" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include=""..\Castle.Core\Castle.Core-vs2008.csproj"">
      <Project>{E4FA5B53-7D36-429E-8E5C-53D5479242BA}</Project>
      <Name>Castle.Core-vs2008</Name>
    </ProjectReference>
    <ProjectReference Include=""..\Castle.DynamicProxy\Castle.DynamicProxy-vs2008.csproj"">
      <Project>{2DE7CC8C-6F06-43BC-A7B6-9466BEDEAC28}</Project>
      <Name>Castle.DynamicProxy-vs2008</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project=""$(MSBuildBinPath)\Microsoft.CSharp.targets"" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name=""BeforeBuild"">
  </Target>
  <Target Name=""AfterBuild"">
  </Target>
  -->
</Project>";

	}


}