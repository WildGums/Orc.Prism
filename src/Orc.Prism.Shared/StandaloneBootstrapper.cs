// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandaloneBootstrapper.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Prism
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Catel.Logging;

    /// <summary>
    /// Standalone bootstrapper to make it possible to run Prism without initialization.
    /// </summary>
    public class StandaloneBootstrapper : BootstrapperBase
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns>DependencyObject.</returns>
        protected override DependencyObject CreateShell()
        {
            return new UserControl();
        }
    }
}