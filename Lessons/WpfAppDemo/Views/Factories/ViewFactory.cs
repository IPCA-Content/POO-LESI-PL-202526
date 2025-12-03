using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppDemo.ViewModels;
using WpfAppDemo.Views.Enums;
using WpfAppDemo.Views.Interfaces;

namespace WpfAppDemo.Views.Factories
{
    /// <summary>
    /// Factory responsible for creating WPF Window instances based on the requested <see cref="ViewType"/>.
    /// This class centralizes the creation logic and ensures consistent initialization of windows.
    /// </summary>
    public class ViewFactory : IViewFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region Public Methods

        /// <summary>
        /// Creates and returns a WPF <see cref="Window"/> corresponding to the specified <see cref="ViewType"/>.
        /// Optionally accepts a parameter used for initializing windows that require input.
        /// </summary>
        /// <param name="type">The type of view to create.</param>
        /// <param name="parameter">
        /// Optional parameter used during window construction (e.g., passing data to MainWindow).
        /// </param>
        /// <returns>A fully constructed WPF <see cref="Window"/> instance.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown when the specified <see cref="ViewType"/> does not have a corresponding Window.
        /// </exception>
        public Window ShowDialog(ViewType type, object? parameter = null)
        {
            Window window = type switch
            {
                ViewType.Login => _serviceProvider.GetRequiredService<LoginWindow>(),
                ViewType.Main => _serviceProvider.GetRequiredService<MainWindow>(),
                ViewType.Registry => _serviceProvider.GetRequiredService<RegistryWindow>(),
                ViewType.EditEmployee => _serviceProvider.GetRequiredService<EditEmployeeWindow>(),
                _ => throw new NotImplementedException()
            };

            object viewModel = type switch
            {
                ViewType.Login => _serviceProvider.GetRequiredService<LoginViewModel>(),
                ViewType.Main => _serviceProvider.GetRequiredService<MainViewModel>(),
                ViewType.Registry => _serviceProvider.GetRequiredService<RegistryViewModel>(),
                ViewType.EditEmployee => ActivatorUtilities.CreateInstance<EditEmployeeViewModel>(_serviceProvider, parameter!),

                _ => throw new NotImplementedException()
            };

            window.DataContext = viewModel;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            return window;
        }

        #endregion
    }
}
