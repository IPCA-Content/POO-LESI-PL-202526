using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppDemo.Models.Repositories;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.ViewModels;
using WpfAppDemo.ViewModels.Interfaces;
using WpfAppDemo.ViewModels.Services;
using WpfAppDemo.Views.Factories;
using WpfAppDemo.Views.Interfaces;

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
                  .AddSingleton<LoginViewModel>()
                  .AddSingleton<IViewFactory, ViewFactory>()
                  .AddSingleton<IUserRepository, UserRepository>()
                  .AddSingleton<IAuthenticationService, AuthenticationService>()
                  .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadServiceProvider();    
        }
    }
}
