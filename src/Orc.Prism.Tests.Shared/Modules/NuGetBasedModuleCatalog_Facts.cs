// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NuGetBasedModuleCatalogExtensions_Facts.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism.Tests.Modules
{
    using System.Linq;
    using NUnit.Framework;
    using Prism.Modules;

    [TestFixture]
    public class NuGetBasedModuleCatalog_Facts
    {
        #region Nested type: The_GetPackageRepository_Method
        [TestFixture]
        public class The_GetPackageRepository_Method
        {
            [TestCase]
            public void Returns_Null_If_The_PackageSource_Is_Empty()
            {
                var nuGetBasedModuleCatalog = new NuGetBasedModuleCatalog { PackageSource = string.Empty };
                var packageRepository = nuGetBasedModuleCatalog.GetPackageRepositories().First();

                Assert.IsNull(packageRepository);
            }

            [TestCase]
            public void Returns_Null_If_The_PackageSource_Has_Incorrect_Format()
            {
                var nuGetBasedModuleCatalog = new NuGetBasedModuleCatalog { PackageSource = "2344:2345982345:" };
                var packageRepository = nuGetBasedModuleCatalog.GetPackageRepositories().First();
                Assert.IsNull(packageRepository);
            }
        }
        #endregion
    }
}