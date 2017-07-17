using Catel.IoC;
using Catel.Services;
using Orc.Prism.Services;
using Orc.Prism.Tasks;

#if PRISM6
using Prism.Regions;
#else
using Microsoft.Practices.Prism.Regions;
#endif

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;

        serviceLocator.RegisterTypeIfNotYetRegistered<IBootstrapperTaskFactory, BootstrapperTaskFactory>();

        serviceLocator.RegisterType<RegionAdapterMappings, RegionAdapterMappings>();
        serviceLocator.RegisterType<IUICompositionService, UICompositionService>();

        var languageService = serviceLocator.ResolveType<ILanguageService>();
        languageService.RegisterLanguageSource(new LanguageResourceSource("Orc.Prism", "Orc.Prism.Properties", "Resources"));
    }
}