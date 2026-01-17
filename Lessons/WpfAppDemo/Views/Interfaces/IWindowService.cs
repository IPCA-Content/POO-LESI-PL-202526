//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace WpfAppDemo.View.Interfaces
{
    /// <summary>
    /// Defines a service for closing views/windows.
    /// </summary>
    public interface IWindowService
    {
        void CloseWindow(object viewModel);
    }

}
