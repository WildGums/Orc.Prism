﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootstrapperBase.generic.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism
{
    using System.Windows;

    using Catel;
    using Catel.IoC;
    using Catel.Windows;

#if PRISM6
    using global::Prism.Modularity;
#else
    using Microsoft.Practices.Prism.Modularity;
#endif

    /// <summary>
    /// The service locator bootstrapper that allows simple instantiation of the shell.
    /// </summary>
    /// <typeparam name="TShell">
    /// The shell type
    /// </typeparam>
    public abstract class BootstrapperBase<TShell> : BootstrapperBase 
        where TShell : System.Windows.Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperBase{TShell}" /> class.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        protected BootstrapperBase(IServiceLocator serviceLocator = null)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        protected override DependencyObject CreateShell()
        {
            var shell = Container.ResolveType<TShell>();

            return shell;
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            var shell = Shell as System.Windows.Window;
            if (shell != null)
            {
                Application.Current.MainWindow = shell;

                shell.Owner = null;
                
                shell.Show();
                shell.BringWindowToTop();
            }
        }

        /// <summary>
        /// The configure container.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            if (!Container.IsTypeRegistered<TShell>() && !typeof(TShell).IsAbstract)
            {
                Container.RegisterType<TShell, TShell>();
            }
        }
    }

    /// <summary>
    /// The service locator bootstrapper that allows simple instantiation of the shell and the module catalog.
    /// </summary>
    /// <typeparam name="TShell">
    /// The shell type
    /// </typeparam>
    /// <typeparam name="TModuleCatalog">
    /// The module catalog type
    /// </typeparam>
    public abstract class BootstrapperBase<TShell, TModuleCatalog> : BootstrapperBase<TShell>
        where TShell : System.Windows.Window
        where TModuleCatalog : class, IModuleCatalog, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapperBase{TShell, TModuleCatalog}" /> class.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        protected BootstrapperBase(IServiceLocator serviceLocator = null)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog"/> used by Prism.
        /// </summary>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        /// <returns>
        /// The instance of <typeparamref name="TModuleCatalog"/> type.
        /// </returns>
        protected override sealed IModuleCatalog CreateModuleCatalog()
        {
            return new TModuleCatalog();
        }

        /// <summary>
        /// Gets the default <see cref="IModuleCatalog"/> for the application.
        /// </summary>
        /// <value>The default <see cref="IModuleCatalog"/> instance.</value>
        protected new TModuleCatalog ModuleCatalog
        {
            get
            {
                return base.ModuleCatalog as TModuleCatalog;
            }
        }
    }
}