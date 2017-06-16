// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISplashScreenServiceExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Prism.Services
{
    using System;
    using System.Threading.Tasks;

    using Catel;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;

    /// <summary>
    /// The splash screen service extensions.
    /// </summary>
    public static class ISplashScreenServiceExtensions
    {
        #region Methods
        /// <summary>
        /// The commit asyc.
        /// </summary>
        /// <typeparam name="TViewModel">The view model type.</typeparam>
        /// <param name="this">The splash screen service.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="regionName">The region name.</param>
        /// <param name="completedCallback">The completed callback.</param>
        public static async Task CommitAsync<TViewModel>(this ISplashScreenService @this, TViewModel viewModel, string regionName, Action completedCallback = null) 
            where TViewModel : IProgressNotifyableViewModel
        {
            var dependencyResolver = IoCConfiguration.DefaultDependencyResolver;
            var uiCompositionService = dependencyResolver.Resolve<IUICompositionService>();

            uiCompositionService.Activate(viewModel, regionName);

            // TODO: Replace with real async method once on Catel v5
            @this.CommitAsync(viewModel: viewModel, show: false, completedCallback: completedCallback);
        }

        /// <summary>
        /// The commit asyc.
        /// </summary>
        /// <typeparam name="TViewModel">The view model type.</typeparam>
        /// <param name="this">The splash screen service.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        /// <param name="regionName">The region name.</param>
        /// <param name="completedCallback">The completed callback.</param>
        public static async Task CommitAsync<TViewModel>(this ISplashScreenService @this, TViewModel viewModel, IViewModel parentViewModel, string regionName, Action completedCallback = null)
            where TViewModel : IProgressNotifyableViewModel
        {
            var dependencyResolver = IoCConfiguration.DefaultDependencyResolver;
            var uiCompositionService = dependencyResolver.Resolve<IUICompositionService>();

            uiCompositionService.Activate(viewModel, parentViewModel, regionName);

            // TODO: Replace with real async method once on Catel v5
            @this.CommitAsync(viewModel: viewModel, show: false, completedCallback: completedCallback);
        }
        #endregion
    }
}