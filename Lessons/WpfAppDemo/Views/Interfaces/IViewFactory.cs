//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Windows;
using WpfAppDemo.Views.Enums;

namespace WpfAppDemo.Views.Interfaces
{
    /// <summary>
    /// Defines a factory for creating views/windows.
    /// </summary>
    public interface IViewFactory
    {
        #region Methods

        /// <summary>
        /// Creates a <see cref="Window"/> instance of the specified <see cref="ViewType"/>.
        /// </summary>
        /// <param name="type">The type of view to create.</param>
        /// <param name="parameter">Optional parameter to pass to the view.</param>
        /// <returns>A new instance of a <see cref="Window"/> corresponding to the specified view type.</returns>
        Window CreateView(ViewType type, object? parameter = null);

        #endregion
    }
}
