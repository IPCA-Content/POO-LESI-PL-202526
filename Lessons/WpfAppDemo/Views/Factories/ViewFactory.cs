using System.Windows;
using WpfAppDemo.Views.Interfaces;
using WpfAppDemo.Views.Enums;

namespace WpfAppDemo.Views.Factories
{
    /// <summary>
    /// Factory responsible for creating WPF Window instances based on the requested <see cref="ViewType"/>.
    /// This class centralizes the creation logic and ensures consistent initialization of windows.
    /// </summary>
    public class ViewFactory : IViewFactory
    {
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
        public Window CreateView(ViewType type, object? parameter = null)
        {
            Window window = type switch
            {
                ViewType.Login => new LoginWindow(),

                // If MainWindow requires parameters, they can be passed like:
                // ViewType.Main => new MainWindow(parameter as string)
                ViewType.Main => new MainWindow(),
                ViewType.Registry => new RegistryWindow(),

                _ => throw new NotImplementedException(
                    $"ViewFactory does not support view type: {type}")
            };

            // Ensures all windows open center on the screen by default
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            return window;
        }

        #endregion
    }
}
