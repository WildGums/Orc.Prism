// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegionManagerExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism
{
    using System;
    using System.Windows.Controls;
    using Catel;

#if PRISM6
    using global::Prism.Regions;
#else
    using Microsoft.Practices.Prism.Regions;
#endif

    /// <summary>
    /// The <see cref="IRegionManager"/> extensions methods.
    /// </summary>
    public static class IRegionManagerExtensions
    {
        #region Methods
        /// <summary>
        /// Registers the view with region.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="regionName">Name of the region.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="regionManager"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="regionName"/> is <c>null</c>.</exception>
        public static void RegisterViewWithRegion<TView>(this IRegionManager regionManager, string regionName) 
            where TView : UserControl
        {
            Argument.IsNotNull("regionManager", regionManager);
            Argument.IsNotNullOrWhitespace("regionName", regionName);

            regionManager.RegisterViewWithRegion(regionName, typeof (TView));
        }
        #endregion
    }
}