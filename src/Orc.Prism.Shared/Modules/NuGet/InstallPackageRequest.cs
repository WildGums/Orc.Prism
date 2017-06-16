// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallPackageRequest.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism.Modules
{
    using Catel;

    /// <summary>
    /// The install package request.
    /// </summary>
    public class InstallPackageRequest
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallPackageRequest" /> class.
        /// </summary>
        /// <param name="moduleAssemblyRef">The assembly file reference.</param>
        /// <exception cref="System.ArgumentException">The <paramref name="moduleAssemblyRef" /> is <c>null</c> or whitespace.</exception>
        public InstallPackageRequest(ModuleAssemblyRef moduleAssemblyRef)
        {
            Argument.IsNotNull(() => moduleAssemblyRef);

            this.ModuleAssemblyRef = moduleAssemblyRef;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the module assembly reference.
        /// </summary>
        /// <value>The assembly file reference.</value>
        public ModuleAssemblyRef ModuleAssemblyRef { get; private set; }

        #endregion

        /// <summary>
        /// Execute the package.
        /// </summary>
        public virtual void Execute()
        {
            // Do nothing
        }
    }
}