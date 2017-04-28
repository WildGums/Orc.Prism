// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUICompositionServiceExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Prism.Services
{
    using System;
    using System.Linq;

    using Catel;
    using Catel.IoC;
    using Catel.MVVM;

    /// <summary>
    /// Extension methods for the UI composition service.
    /// </summary>
    public static class IUICompositionServiceExtensions
    {
        /// <summary>
        /// Tries to activate an existing view model in the specified region name. If there is no view model alive, it will create one
        /// and navigate to that view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="uiCompositionService">The UI composition service.</param>
        /// <param name="regionName">Name of the region.</param>
        public static void Activate<TViewModel>(this IUICompositionService uiCompositionService, string regionName)
            where TViewModel : IViewModel
        {
            uiCompositionService.Activate(typeof(TViewModel), regionName);
        }
    }
}