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
using System.Windows.Input;
using WpfAppDemo.ViewModels.Interfaces;
using WpfAppDemo.Views.Enums;
using WpfAppDemo.Views.Interfaces;

namespace WpfAppDemo.ViewModels
{
    /// <summary>
    /// ViewModel for login functionality. Handles authentication and navigation.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IViewFactory _viewFactory;
        private string _username = string.Empty;
        private string _password = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Action to hide the associated window. Typically set by the view.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command for executing the login action.
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Gets or sets the username entered by the user.
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        /// <summary>
        /// Gets or sets the password entered by the user.
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="LoginViewModel"/>.
        /// </summary>
        /// <param name="authenticationService">The authentication service to validate users.</param>
        /// <param name="viewFactory">The factory to create views for navigation.</param>
        public LoginViewModel(IAuthenticationService authenticationService, IViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the login command, validating credentials and navigating to the main view if successful.
        /// </summary>
        /// <param name="parameter">Optional command parameter (not used).</param>
        private void ExecuteLoginCommand(object parameter)
        {
            if (_authenticationService.UserExists(Username, Password))
            {
                Window window = _viewFactory.CreateView(ViewType.Main);
                HideWindowAction?.Invoke();
                window.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion
    }
}
