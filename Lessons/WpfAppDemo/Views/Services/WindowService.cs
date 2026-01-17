//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>04-12-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------


namespace WpfAppDemo.Views.Services
{
    using System.Windows;
    using WpfAppDemo.View.Interfaces;

    public class WindowService : IWindowService
    {
        public void CloseWindow(object viewModel)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == viewModel)
                {
                    window.Close();
                    return;
                }
            }
        }
    }
}
