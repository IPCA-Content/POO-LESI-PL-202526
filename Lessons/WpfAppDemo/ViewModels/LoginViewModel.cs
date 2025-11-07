using System.Windows.Input;

namespace WpfAppDemo.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        private string _username;

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


        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand);
        }

        private void ExecuteLoginCommand(object parameter)
        {
            Console.WriteLine("login done");
        }

    }
}
