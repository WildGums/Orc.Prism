// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageInfo.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism.Modules
{
    using Catel;
    using NuGet;

    /// <summary>
    /// NuGet package info.
    /// </summary>
    public class NuGetPackageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NuGetPackageInfo"/> class.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <param name="packageRepository">The package repository.</param>
        public NuGetPackageInfo(IPackage package, IPackageRepository packageRepository)
        {
            Argument.IsNotNull(() => package);
            Argument.IsNotNull(() => packageRepository);

            Package = package;
            PackageRepository = packageRepository;
        }

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <value>The package.</value>
        public IPackage Package { get; private set; }

        /// <summary>
        /// Gets or sets the package repository.
        /// </summary>
        /// <value>The package repository.</value>
        public IPackageRepository PackageRepository { get; set; }
    }
}
