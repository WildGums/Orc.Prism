[assembly: System.Resources.NeutralResourcesLanguage("en-US")]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v3.1", FrameworkDisplayName="")]
public static class ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.Prism
{
    public abstract class BootstrapperBase : Prism.Bootstrapper
    {
        protected BootstrapperBase(Catel.IoC.IServiceLocator serviceLocator = null) { }
        protected Catel.IoC.IServiceLocator Container { get; }
        public event System.EventHandler<System.EventArgs> BootstrapperCompleted;
        public event System.EventHandler<System.EventArgs> ConfiguredDefaultRegionBehaviors;
        public event System.EventHandler<System.EventArgs> ConfiguredModuleCatalog;
        public event System.EventHandler<System.EventArgs> ConfiguredRegionAdapters;
        public event System.EventHandler<System.EventArgs> ConfiguredServiceLocator;
        public event System.EventHandler<System.EventArgs> ConfiguredServiceLocatorContainer;
        public event System.EventHandler<System.EventArgs> CreatedLogger;
        public event System.EventHandler<System.EventArgs> CreatedModuleCatalog;
        public event System.EventHandler<System.EventArgs> CreatedServiceLocatorContainer;
        public event System.EventHandler<System.EventArgs> CreatedShell;
        public event System.EventHandler<System.EventArgs> InitializedModules;
        public event System.EventHandler<System.EventArgs> InitializedShell;
        public event System.EventHandler<System.EventArgs> RegisteredFrameworkExceptionTypes;
        protected virtual void ConfigureContainer() { }
        protected override sealed void ConfigureServiceLocator() { }
        protected virtual Catel.MVVM.Tasks.ITask[] CreateInitializationTasks(bool runWithDefaultConfiguration) { }
        protected override sealed Prism.Logging.ILoggerFacade CreateLogger() { }
        protected virtual void InitializeBootTasks(System.Collections.Generic.IList<Catel.MVVM.Tasks.ITask> bootTasks) { }
        protected override void InitializeModules() { }
        public override void Run(bool runWithDefaultConfiguration) { }
        public class LoggerFacadeAdapter : Catel.Logging.LogListenerBase, Prism.Logging.ILoggerFacade
        {
            public LoggerFacadeAdapter(Catel.Logging.ILog log, bool relayCatelMessageToLoggerFacade = false) { }
            protected override void Debug(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
            protected override void Error(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
            protected override void Info(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
            protected override void Warning(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        }
    }
    public abstract class BootstrapperBase<TShell> : Orc.Prism.BootstrapperBase
        where TShell : System.Windows.Window
    {
        protected BootstrapperBase(Catel.IoC.IServiceLocator serviceLocator = null) { }
        protected override void ConfigureContainer() { }
        protected override System.Windows.DependencyObject CreateShell() { }
        protected override void InitializeShell() { }
    }
    public abstract class BootstrapperBase<TShell, TModuleCatalog> : Orc.Prism.BootstrapperBase<TShell>
        where TShell : System.Windows.Window
        where TModuleCatalog :  class, Prism.Modularity.IModuleCatalog, new ()
    {
        protected BootstrapperBase(Catel.IoC.IServiceLocator serviceLocator = null) { }
        protected TModuleCatalog ModuleCatalog { get; }
        protected override sealed Prism.Modularity.IModuleCatalog CreateModuleCatalog() { }
    }
    public static class DependencyObjectExtensions
    {
        public static Prism.Regions.IRegionManager FindFirstParentRegionManager(this System.Windows.DependencyObject @this) { }
        public static Orc.Prism.IRegionInfo GetRegionInfo(this System.Windows.DependencyObject @this, string regionName, Catel.IoC.IServiceLocator serviceLocator = null, Prism.Regions.IRegionManager defaultRegionManager = null) { }
        public static Prism.Regions.IRegionManager GetRegionManager(this System.Windows.DependencyObject @this) { }
        public static string GetRegionName(this System.Windows.DependencyObject @this) { }
        public static void SetRegionManager(this System.Windows.DependencyObject @this, Prism.Regions.IRegionManager regionManager) { }
    }
    public static class ILogExtensions
    {
        public static void Debug(this Catel.Logging.ILog @this, Prism.Logging.Priority priority, string messageFormat, params object[] args) { }
        public static void Debug(this Catel.Logging.ILog @this, System.Exception exception, Prism.Logging.Priority priority = 0, string messageFormat = "", params object[] args) { }
        public static void Error(this Catel.Logging.ILog @this, Prism.Logging.Priority priority, string messageFormat, params object[] args) { }
        public static void Error(this Catel.Logging.ILog @this, System.Exception exception, Prism.Logging.Priority priority = 0, string messageFormat = "", params object[] args) { }
        public static void Info(this Catel.Logging.ILog @this, Prism.Logging.Priority priority, string messageFormat, params object[] args) { }
        public static void Info(this Catel.Logging.ILog @this, System.Exception exception, Prism.Logging.Priority priority = 0, string messageFormat = "", params object[] args) { }
        public static void Warning(this Catel.Logging.ILog @this, Prism.Logging.Priority priority, string messageFormat, params object[] args) { }
        public static void Warning(this Catel.Logging.ILog @this, System.Exception exception, Prism.Logging.Priority priority = 0, string messageFormat = "", params object[] args) { }
    }
    public interface IModuleTracker
    {
        void RecordModuleConstructed(string moduleName);
        void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive);
        void RecordModuleInitialized(string moduleName);
        void RecordModuleLoaded(string moduleName);
    }
    public interface IRegionInfo
    {
        Prism.Regions.IRegionManager RegionManager { get; }
        string RegionName { get; }
    }
    public static class IRegionManagerExtensions
    {
        public static void RegisterViewWithRegion<TView>(this Prism.Regions.IRegionManager regionManager, string regionName)
            where TView : System.Windows.Controls.UserControl { }
    }
    public interface IUICompositionService
    {
        void Activate(Catel.MVVM.IViewModel viewModel, string regionName = null);
        void Activate(System.Type viewModelType, string regionName);
        void Activate(Catel.MVVM.IViewModel viewModel, Catel.MVVM.IViewModel parentViewModel, string regionName);
        void Deactivate(Catel.MVVM.IViewModel viewModel);
    }
    public static class IUICompositionServiceExtensions
    {
        public static void Activate<TViewModel>(this Orc.Prism.IUICompositionService uiCompositionService, string regionName)
            where TViewModel : Catel.MVVM.IViewModel { }
    }
    public static class IUIVisualizerServiceExtensions
    {
        public static System.Threading.Tasks.Task<bool?> ShowAsync(this Catel.Services.IUIVisualizerService @this, Catel.MVVM.IViewModel viewModel, System.Action openedProc = null, System.EventHandler<Catel.Services.UICompletedEventArgs> completedProc = null, uint timeOutInMilliseconds = 10000) { }
    }
    public interface IViewInfo
    {
        Prism.Regions.IRegion Region { get; }
        System.Windows.FrameworkElement View { get; }
    }
    public static class PrismHelper
    {
        public static void InitializeMainWindow() { }
        public static void PrepareWithoutBootstrapper() { }
    }
    public class ServiceLocatorAdapter : Microsoft.Practices.ServiceLocation.ServiceLocatorImplBase
    {
        public ServiceLocatorAdapter() { }
        public ServiceLocatorAdapter(Catel.IoC.IServiceLocator serviceLocator) { }
        public static Orc.Prism.ServiceLocatorAdapter Default { get; }
        protected override System.Collections.Generic.IEnumerable<object> DoGetAllInstances(System.Type serviceType) { }
        protected override object DoGetInstance(System.Type serviceType, string key) { }
    }
    public class StandaloneBootstrapper : Orc.Prism.BootstrapperBase
    {
        public StandaloneBootstrapper() { }
        protected override System.Windows.DependencyObject CreateShell() { }
    }
    public sealed class UICompositionService : Catel.Services.ViewModelServiceBase, Orc.Prism.IUICompositionService
    {
        public UICompositionService(Prism.Regions.IRegionManager regionManager, Catel.MVVM.Views.IViewManager viewManager, Catel.MVVM.IViewLocator viewLocator, Catel.Services.IDispatcherService dispatcherService, Catel.MVVM.IViewModelManager viewModelManager, Catel.MVVM.IViewModelFactory viewModelFactory) { }
        public void Activate(Catel.MVVM.IViewModel viewModel, string regionName = null) { }
        public void Activate(System.Type viewModelType, string regionName) { }
        public void Activate(Catel.MVVM.IViewModel viewModel, Catel.MVVM.IViewModel parentViewModel, string regionName) { }
        public void Deactivate(Catel.MVVM.IViewModel viewModel) { }
    }
}
namespace Orc.Prism.Modules
{
    public sealed class CompositeModuleCatalog : Orc.Prism.Modules.CompositeModuleCatalog<Prism.Modularity.IModuleCatalog>
    {
        public CompositeModuleCatalog() { }
    }
    public class CompositeModuleCatalog<TModuleCatalog> : Orc.Prism.Modules.ModuleCatalog
        where TModuleCatalog : Prism.Modularity.IModuleCatalog
    {
        public CompositeModuleCatalog() { }
        public System.Collections.Generic.IEnumerable<Prism.Modularity.IModuleCatalog> LeafCatalogs { get; }
        protected System.Collections.ObjectModel.ReadOnlyCollection<TModuleCatalog> ModuleCatalogs { get; }
        public override System.Collections.Generic.IEnumerable<Prism.Modularity.IModuleCatalogItem> QueryItems { get; }
        public void Add(TModuleCatalog moduleCatalog) { }
        public override void Initialize() { }
    }
    public class CompositeNuGetBasedModuleCatalog : Orc.Prism.Modules.CompositeModuleCatalog<Orc.Prism.Modules.INuGetBasedModuleCatalog>, Orc.Prism.Modules.INuGetBasedModuleCatalog, Prism.Modularity.IModuleCatalog
    {
        public CompositeNuGetBasedModuleCatalog() { }
        public bool AllowPrereleaseVersions { get; set; }
        public bool IgnoreDependencies { get; set; }
        public override System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> Modules { get; }
        public string OutputDirectory { get; set; }
        public string OutputDirectoryFullPath { get; }
        public string PackagedModuleIdFilterExpression { get; set; }
        public Orc.Prism.Modules.INuGetBasedModuleCatalog Parent { get; set; }
        public System.Collections.Generic.IEnumerable<NuGet.IPackageRepository> GetPackageRepositories() { }
        public bool TryCreateInstallPackageRequest(Prism.Modularity.ModuleInfo moduleInfo, out Orc.Prism.Modules.InstallPackageRequest installPackageRequest) { }
    }
    public interface IDownloadingModuleCatalog : Prism.Modularity.IModuleCatalog
    {
        event System.EventHandler<Orc.Prism.Modules.ModuleEventArgs> ModuleDownloaded;
        event System.EventHandler<Orc.Prism.Modules.ModuleEventArgs> ModuleDownloading;
        void LoadModule(string moduleName, System.Action completedCallback);
    }
    public interface INuGetBasedModuleCatalog : Prism.Modularity.IModuleCatalog
    {
        bool AllowPrereleaseVersions { get; set; }
        bool IgnoreDependencies { get; set; }
        string OutputDirectory { get; set; }
        string OutputDirectoryFullPath { get; }
        string PackagedModuleIdFilterExpression { get; set; }
        Orc.Prism.Modules.INuGetBasedModuleCatalog Parent { get; set; }
        System.Collections.Generic.IEnumerable<NuGet.IPackageRepository> GetPackageRepositories();
        bool TryCreateInstallPackageRequest(Prism.Modularity.ModuleInfo moduleInfo, out Orc.Prism.Modules.InstallPackageRequest installPackageRequest);
    }
    public static class INuGetBasedModuleCatalogExtensions
    {
        public static System.Collections.Generic.IEnumerable<NuGet.IPackageRepository> GetAllPackageRepositories(this Orc.Prism.Modules.INuGetBasedModuleCatalog moduleCatalog, bool allowParentPackageSources) { }
    }
    public class InstallPackageRequest
    {
        public InstallPackageRequest(Orc.Prism.Modules.ModuleAssemblyRef moduleAssemblyRef) { }
        public Orc.Prism.Modules.ModuleAssemblyRef ModuleAssemblyRef { get; }
        public virtual void Execute() { }
    }
    public class ModuleAssemblyRef
    {
        public ModuleAssemblyRef(string baseUri, string directoryName, string assemblyName) { }
        public bool IsInstalled { get; }
        public string Ref { get; }
    }
    public abstract class ModuleBase : Orc.Prism.Modules.ModuleBase<Catel.IoC.IServiceLocator>
    {
        protected ModuleBase(string moduleName, Orc.Prism.IModuleTracker moduleTracker = null, Catel.IoC.IServiceLocator container = null) { }
        protected override T GetService<T>() { }
    }
    [Prism.Modularity.Module]
    public abstract class ModuleBase<TContainer> : Prism.Modularity.IModule
        where TContainer :  class
    {
        protected ModuleBase(string moduleName, Orc.Prism.IModuleTracker moduleTracker = null, TContainer container = null) { }
        protected TContainer Container { get; }
        protected string ModuleName { get; }
        protected Orc.Prism.IModuleTracker ModuleTracker { get; }
        protected Prism.Regions.IRegionManager RegionManager { get; }
        protected abstract T GetService<T>();
        public void Initialize() { }
        protected virtual void OnInitialized() { }
        protected virtual void OnInitializing() { }
        protected virtual void OnRegisterViewsAndTypes() { }
    }
    [System.Windows.Markup.ContentProperty("Items")]
    public class ModuleCatalog : Prism.Modularity.IModuleCatalog
    {
        protected readonly Catel.Threading.SynchronizationContext _synchronizationContext;
        public ModuleCatalog() { }
        public ModuleCatalog(System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> modules) { }
        protected System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> GrouplessModules { get; }
        public System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfoGroup> Groups { get; }
        public System.Collections.ObjectModel.Collection<Prism.Modularity.IModuleCatalogItem> Items { get; }
        public virtual System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> Modules { get; }
        public virtual System.Collections.Generic.IEnumerable<Prism.Modularity.IModuleCatalogItem> QueryItems { get; }
        protected bool Validated { get; set; }
        public virtual Orc.Prism.Modules.ModuleCatalog AddGroup(Prism.Modularity.InitializationMode initializationMode, string refValue, params Prism.Modularity.ModuleInfo[] moduleInfos) { }
        public virtual void AddModule(Prism.Modularity.ModuleInfo moduleInfo) { }
        public Orc.Prism.Modules.ModuleCatalog AddModule(System.Type moduleType, params string[] dependsOn) { }
        public Orc.Prism.Modules.ModuleCatalog AddModule(string moduleName, string moduleType, params string[] dependsOn) { }
        public Orc.Prism.Modules.ModuleCatalog AddModule(System.Type moduleType, Prism.Modularity.InitializationMode initializationMode, params string[] dependsOn) { }
        public Orc.Prism.Modules.ModuleCatalog AddModule(string moduleName, string moduleType, Prism.Modularity.InitializationMode initializationMode, params string[] dependsOn) { }
        public Orc.Prism.Modules.ModuleCatalog AddModule(string moduleName, string moduleType, string refValue, Prism.Modularity.InitializationMode initializationMode, params string[] dependsOn) { }
        public virtual System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> CompleteListWithDependencies(System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> modules) { }
        protected virtual void EnsureCatalogValidated() { }
        public virtual System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> GetDependentModules(Prism.Modularity.ModuleInfo moduleInfo) { }
        protected virtual System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> GetDependentModulesInner(Prism.Modularity.ModuleInfo moduleInfo) { }
        protected Prism.Modularity.ModuleInfo GetModuleInfoByName(string moduleName) { }
        public virtual void Initialize() { }
        protected virtual void InnerLoad() { }
        public void Load() { }
        protected virtual System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> Sort(System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> modules) { }
        public virtual void Validate() { }
        protected virtual void ValidateCrossGroupDependencies() { }
        protected virtual void ValidateDependenciesInitializationMode() { }
        protected virtual void ValidateDependencyGraph() { }
        protected virtual void ValidateUniqueModules() { }
        public static Orc.Prism.Modules.ModuleCatalog CreateFromXaml(System.IO.Stream xamlStream) { }
        public static Orc.Prism.Modules.ModuleCatalog CreateFromXaml(System.Uri builderResourceUri) { }
        protected static string[] SolveDependencies(System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> modules) { }
        protected static void ValidateDependencies(System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> modules) { }
    }
    public static class ModuleCatalogExtensions
    {
        public static bool IsCatalogType(this Prism.Modularity.IModuleCatalog moduleCatalog, System.Type typeToCheck) { }
        public static bool IsCatalogType<T>(this Prism.Modularity.IModuleCatalog moduleCatalog) { }
    }
    public class ModuleEventArgs : System.EventArgs
    {
        public ModuleEventArgs(Prism.Modularity.ModuleInfo moduleInfo) { }
        public string ModuleName { get; }
    }
    public static class ModuleInfoExtensions
    {
        public static string GetAssemblyName(this Prism.Modularity.ModuleInfo moduleInfo) { }
        public static Orc.Prism.Modules.ModuleAssemblyRef GetModuleAssemblyRef(this Prism.Modularity.ModuleInfo moduleInfo, string outputDirectoryAbsoluteUri) { }
        public static NuGet.PackageName GetPackageName(this Prism.Modularity.ModuleInfo moduleInfo) { }
    }
    public class NuGetBasedModuleCatalog : Orc.Prism.Modules.ModuleCatalog, Orc.Prism.Modules.INuGetBasedModuleCatalog, Prism.Modularity.IModuleCatalog
    {
        public NuGetBasedModuleCatalog() { }
        public bool AllowPrereleaseVersions { get; set; }
        public Prism.Modularity.InitializationMode DefaultInitializationMode { get; set; }
        public bool IgnoreDependencies { get; set; }
        public override System.Collections.Generic.IEnumerable<Prism.Modularity.ModuleInfo> Modules { get; }
        public string OutputDirectory { get; set; }
        public string OutputDirectoryFullPath { get; }
        public string PackageSource { get; set; }
        public string PackagedModuleIdFilterExpression { get; set; }
        public Orc.Prism.Modules.INuGetBasedModuleCatalog Parent { get; set; }
        protected virtual Prism.Modularity.ModuleInfo CreatePackageModule(NuGet.IPackage package) { }
        protected virtual System.Collections.Generic.IEnumerable<NuGet.IPackage> GetFilteredPackagedModules(System.Linq.IQueryable<NuGet.IPackage> queryablePackages) { }
        protected virtual Prism.Modularity.InitializationMode GetPackageInitializationMode(NuGet.IPackage package) { }
        public System.Collections.Generic.IEnumerable<NuGet.IPackageRepository> GetPackageRepositories() { }
        public bool TryCreateInstallPackageRequest(Prism.Modularity.ModuleInfo moduleInfo, out Orc.Prism.Modules.InstallPackageRequest installPackageRequest) { }
    }
    public class NuGetBasedModuleCatalogParentChildBehavior
    {
        public NuGetBasedModuleCatalogParentChildBehavior(Orc.Prism.Modules.INuGetBasedModuleCatalog moduleCatalog) { }
        public bool AllowPrereleaseVersions { get; set; }
        public bool IgnoreDependencies { get; set; }
        public string OutputDirectory { get; set; }
        public string PackagedModuleIdFilterExpression { get; set; }
    }
    public sealed class NuGetModuleTypeLoader : Prism.Modularity.IModuleTypeLoader
    {
        public NuGetModuleTypeLoader(Prism.Modularity.IModuleCatalog moduleCatalog) { }
        public event System.EventHandler<Prism.Modularity.LoadModuleCompletedEventArgs> LoadModuleCompleted;
        public event System.EventHandler<Prism.Modularity.ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;
        public bool CanLoadModuleType(Prism.Modularity.ModuleInfo moduleInfo) { }
        public void LoadModuleType(Prism.Modularity.ModuleInfo moduleInfo) { }
    }
    public class NuGetPackageInfo
    {
        public NuGetPackageInfo(NuGet.IPackage package, NuGet.IPackageRepository packageRepository) { }
        public NuGet.IPackage Package { get; }
        public NuGet.IPackageRepository PackageRepository { get; set; }
    }
    public class SafeDirectoryModuleCatalog : Orc.Prism.Modules.ModuleCatalog
    {
        public SafeDirectoryModuleCatalog() { }
        public string ModulePath { get; set; }
        protected virtual System.AppDomain BuildChildDomain(System.AppDomain parentDomain) { }
        protected override void InnerLoad() { }
    }
}
namespace Orc.Prism.Tasks
{
    public class BootstrapperTaskFactory : Orc.Prism.Tasks.IBootstrapperTaskFactory
    {
        public BootstrapperTaskFactory() { }
        public virtual Catel.MVVM.Tasks.ITask CreateConfigureDefaultRegionBehaviorsTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateConfigureDefaultRegionBehaviorsTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateConfigureModuleCatalogTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateConfigureModuleCatalogTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateConfigureRegionAdaptersTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateConfigureRegionAdaptersTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorContainerTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorContainerTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateCreateLoggerTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateCreateLoggerTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateCreateModuleCatalogTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateCreateModuleCatalogTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateCreateServiceLocatorContainerTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateCreateServiceLocatorContainerTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateCreateShellTask(System.Action action, bool dispatch = true) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateCreateShellTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateInitializeModulesTask(System.Action action, bool dispatch = true) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateInitializeModulesTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateInitializingShellTask(System.Action action, bool dispatch = true) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateInitializingShellTask(System.Action action, string description, bool dispatch) { }
        public virtual Catel.MVVM.Tasks.ITask CreateRegisterFrameworkExceptionTypesTask(System.Action action, bool dispatch = false) { }
        protected virtual Catel.MVVM.Tasks.ITask CreateRegisterFrameworkExceptionTypesTask(System.Action action, string description, bool dispatch) { }
    }
    public interface IBootstrapperTaskFactory
    {
        Catel.MVVM.Tasks.ITask CreateConfigureDefaultRegionBehaviorsTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateConfigureModuleCatalogTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateConfigureRegionAdaptersTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorContainerTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateConfigureServiceLocatorTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateCreateLoggerTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateCreateModuleCatalogTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateCreateServiceLocatorContainerTask(System.Action action, bool dispatch = false);
        Catel.MVVM.Tasks.ITask CreateCreateShellTask(System.Action action, bool dispatch = true);
        Catel.MVVM.Tasks.ITask CreateInitializeModulesTask(System.Action action, bool dispatch = true);
        Catel.MVVM.Tasks.ITask CreateInitializingShellTask(System.Action action, bool dispatch = true);
        Catel.MVVM.Tasks.ITask CreateRegisterFrameworkExceptionTypesTask(System.Action action, bool dispatch = false);
    }
}