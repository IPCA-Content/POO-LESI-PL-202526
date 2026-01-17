using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppDemo.Models.Repositories;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.View.Interfaces;
using WpfAppDemo.ViewModels;
using WpfAppDemo.ViewModels.Interfaces;
using WpfAppDemo.ViewModels.Services;
using WpfAppDemo.Views;
using WpfAppDemo.Views.Factories;
using WpfAppDemo.Views.Interfaces;
using WpfAppDemo.Views.Services;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        private static void LoadServiceProvider()
        {
            ServiceProvider = new ServiceCollection()
                  .AddSingleton<MainWindow>()
                  .AddSingleton<MainViewModel>()
                  .AddSingleton<LoginViewModel>()
                  .AddSingleton<RegistryViewModel>()
                  .AddSingleton<EditEmployeeWindow>()
                  .AddSingleton<EditEmployeeViewModel>()
                  .AddSingleton<IViewFactory, ViewFactory>()
                  .AddSingleton<IWindowService, WindowService>()
                  .AddSingleton<IUserRepository, UserRepository>()
                  .AddSingleton<IEmployeeService, EmployeeService>()
                  .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                  .AddSingleton<IAuthenticationService, AuthenticationService>()
                  .BuildServiceProvider();
        }

        private void OpenStartWindow()
        {
#if DEBUG
            MainWindow mainWindow = new()
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>(),
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow?.Show();
#else
            LoginWindow loginWindow = new()
            {
                DataContext = ServiceProvider.GetRequiredService<LoginViewModel>(),
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            loginWindow?.Show();
#endif
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadServiceProvider();
            OpenStartWindow();
        }
    }
}
