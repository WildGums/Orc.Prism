// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegionInfo.cs" company="WildGums">
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
    /// The region info interface.
    /// </summary>
    public interface IRegionInfo
    {
        #region Properties

        /// <summary>
        /// Gets RegionName.
        /// </summary>
        string RegionName { get; }

        /// <summary>
        /// Gets RegionManager.
        /// </summary>
        IRegionManager RegionManager { get; }
        #endregion
    }
}