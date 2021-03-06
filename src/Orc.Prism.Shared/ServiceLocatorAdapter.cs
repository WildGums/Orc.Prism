﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceLocatorAdapter.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism
{
    using System;
    using System.Collections.Generic;

    using Catel;
    using Catel.IoC;

    using Microsoft.Practices.ServiceLocation;
    using IServiceLocator = Catel.IoC.IServiceLocator;

    /// <summary>
    /// The catel service locator adapter.
    /// </summary>
    public class ServiceLocatorAdapter : ServiceLocatorImplBase
    {
        #region Fields

        /// <summary>
        /// The service locator.
        /// </summary>
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="ServiceLocatorAdapter"/> class.
        /// </summary>
        static ServiceLocatorAdapter()
        {
            Default = new ServiceLocatorAdapter(Catel.IoC.ServiceLocator.Default);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorAdapter"/> class.
        /// </summary>
        /// <remarks>
        /// Do not remove this method, the <see cref="Catel.IoC.ServiceLocator"/> cannot instantiate classes with arguments.
        /// </remarks>
        public ServiceLocatorAdapter()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorAdapter"/> class. 
        /// </summary>
        /// <param name="serviceLocator">
        /// The service Locator. If <c>null</c>, <see cref="Catel.IoC.ServiceLocator.Default"/> will be used.
        /// </param>
        public ServiceLocatorAdapter(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator ?? Catel.IoC.ServiceLocator.Default;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the default service locator adapter.
        /// </summary>
        /// <value>The default.</value>
        public static ServiceLocatorAdapter Default { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// The do get instance.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="key">The key.</param>
        /// <returns>An instance of the type registered on the interface.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceType" /> is <c>null</c>.</exception>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            Argument.IsNotNull("serviceType", serviceType);

            object instance = null;
            if (_serviceLocator.IsTypeRegistered(serviceType, key))
            {
                instance = _serviceLocator.ResolveType(serviceType, key);
            }
            else if (serviceType.IsClass && !serviceType.IsAbstract)
            {
                if (_serviceLocator.CanResolveNonAbstractTypesWithoutRegistration)
                {
                    instance = _serviceLocator.ResolveType(serviceType, key);
                }
                else
                {
                    var typeFactory = _serviceLocator.ResolveType<ITypeFactory>();
                    instance = typeFactory.CreateInstance(serviceType);
                }
            }

            return instance;
        }

        /// <summary>
        /// The do get all instances.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>An instance of the type registered on the interface.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceType" /> is <c>null</c>.</exception>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            object instance = DoGetInstance(serviceType, null);
            return instance == null ? new object[] { } : new[] { instance };
        }
        #endregion
    }
}