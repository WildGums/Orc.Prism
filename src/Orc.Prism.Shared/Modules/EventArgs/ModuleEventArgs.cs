// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleEventArgs.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism.Modules
{
    using System;
    using Catel;

#if PRISM6
    using global::Prism.Modularity;
#else
    using Microsoft.Practices.Prism.Modularity;
#endif

    /// <summary>
    /// Event args for moldue events.
    /// </summary>
    public class ModuleEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleEventArgs" /> class.
        /// </summary>
        /// <param name="moduleInfo">The module info.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="moduleInfo"/> is <c>null</c>.</exception>
        public ModuleEventArgs(ModuleInfo moduleInfo)
        {
            Argument.IsNotNull("moduleInfo", moduleInfo);

            ModuleName = moduleInfo.ModuleName;
        }

        /// <summary>
        /// Gets the module info.
        /// </summary>
        /// <value>The module info.</value>
        public string ModuleName { get; private set; }
    }
}