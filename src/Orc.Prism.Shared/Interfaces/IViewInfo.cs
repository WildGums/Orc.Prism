// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IViewRegionItem.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism
{
    using System.Windows;

#if PRISM6
    using global::Prism.Regions;
#else
    using Microsoft.Practices.Prism.Regions;
#endif

    /// <summary>
    /// The view region item interface.
    /// </summary>
    public interface IViewInfo
    {
        /// <summary>
        /// Gets View.
        /// </summary>
        FrameworkElement View { get; }

        /// <summary>
        /// Gets Region.
        /// </summary>
        IRegion Region { get; }
    }
}