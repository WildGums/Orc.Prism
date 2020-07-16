﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUIVisualizerServiceExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.Prism
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Catel;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.MVVM.Views;
    using Catel.Services;

#if PRISM6
    using global::Prism.Regions;
#else
    using Microsoft.Practices.Prism.Regions;
#endif

    /// <summary>
    /// Extension methods for the <see cref="IUIVisualizerService" />.
    /// </summary>
    public static class IUIVisualizerServiceExtensions
    {
        #region Methods
        private static T ResolveTypeFromContainer<T>()
        {
            var dependencyResolver = IoCConfiguration.DefaultDependencyResolver;
            return dependencyResolver.Resolve<T>();
        }

        /// <summary>
        /// Shows a window that is registered with the specified view model in a non-modal state.
        /// </summary>
        /// <param name="this">The <see cref="IUIVisualizerService" /> service self instance.</param>
        /// <param name="viewModel">The view model.</param>
        /// <param name="openedProc">The callback procedure that will be invoked when the window is opened (registered in the <see cref="IViewManager" />). This value can be <c>null</c>.</param>
        /// <param name="completedProc">The callback procedure that will be invoked as soon as the window is closed. This value can be <c>null</c>.</param>
        /// <param name="timeOutInMilliseconds">The time out in milliseconds.</param>
        /// <returns><c>true</c> if the popup window is successfully opened; otherwise <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="this" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="viewModel" /> is <c>null</c>.</exception>
        /// <exception cref="ViewModelNotRegisteredException">The <paramref name="viewModel" /> is not registered by the
        /// <see cref="IUIVisualizerService.Register(string,System.Type,bool)" />
        /// method first.</exception>
        /// <remarks>If the <see cref="IViewManager.GetViewsOfViewModel" /> method returns no active views for the <paramref name="viewModel" /> in the expected <paramref name="timeOutInMilliseconds" /> time
        /// then this method will assume that the view is actually opened and invokes <paramref name="openedProc" /> anyway.</remarks>
        public static Task<bool?> ShowAsync(this IUIVisualizerService @this, IViewModel viewModel, Action openedProc = null, EventHandler<UICompletedEventArgs> completedProc = null, uint timeOutInMilliseconds = 10000)
        {
            Argument.IsNotNull("@this", @this);

            return new Task<bool?>(() =>
            {
                var innerTask = @this.ShowAsync(viewModel, completedProc);
                return innerTask.ContinueWith(t =>
                {
                    if ((t.Result ?? false) && openedProc != null)
                    {
                        var startTime = DateTime.Now;
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            var viewManager = ResolveTypeFromContainer<IViewManager>();
                            while (viewManager.GetViewsOfViewModel(viewModel).Length == 0 && DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOutInMilliseconds)
                            {
                                ThreadHelper.Sleep(100);
                            }

                            var dispatcherService = ResolveTypeFromContainer<IDispatcherService>();
                            dispatcherService.Invoke(openedProc, true);
                        });
                    }

                    return t.Result;
                }).Result;
            });
        }

        #endregion
    }
}
