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
using WpfAppDemo.Models.Repositories;
using WpfAppDemo.ViewModels;
using WpfAppDemo.ViewModels.Services;
using WpfAppDemo.Views.Factories;

namespace WpfAppDemo.Views
{
    /// <summary>
    /// Interaction logic for <c>LoginWindow.xaml</c>.
    /// This window handles user login and binds to <see cref="LoginViewModel"/>.
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region Fields

        private readonly LoginViewModel _viewModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="LoginWindow"/>.
        /// Sets up the <see cref="LoginViewModel"/>, authentication service, and view factory.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();

            // Create dependencies
            ViewFactory viewFactory = new ViewFactory();
            UserRepository userRepository = new UserRepository();
            AuthenticationService authService = new AuthenticationService(userRepository);

            // Initialize ViewModel
            _viewModel = new LoginViewModel(authService, viewFactory)
            {
                HideWindowAction = Hide
            };

            // Set DataContext for data binding
            DataContext = _viewModel;
        }

        #endregion
    }
}
