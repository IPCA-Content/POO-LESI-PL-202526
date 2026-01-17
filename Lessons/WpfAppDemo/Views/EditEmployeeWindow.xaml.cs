//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>04-12-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Windows;

namespace WpfAppDemo.Views
{
    /// <summary>
    /// Interaction logic for <c>EditEmployeeWindow.xaml</c>.
    /// This window handles user login and binds to <see cref="EditEmployeeWindow"/>.
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="EditEmployeeWindow"/>.
        /// Sets up the <see cref="EditEmployeeWindow"/>, edit employee view, and view factory.
        /// </summary>
        public EditEmployeeWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
