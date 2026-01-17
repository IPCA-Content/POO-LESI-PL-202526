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
using WpfAppDemo.ViewModels;

namespace WpfAppDemo.Views
{
    /// <summary>
    /// Interaction logic for <c>LoginWindow.xaml</c>.
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="LoginWindow"/>.
        /// Sets up the <see cref="LoginViewModel"/>, authentication service, and view factory.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
