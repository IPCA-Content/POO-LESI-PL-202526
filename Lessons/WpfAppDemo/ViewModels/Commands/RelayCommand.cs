using System.Windows.Input;

namespace WpfAppDemo.ViewModels.Commands
{
    /// <summary>
    /// A basic ICommand implementation supporting parameterless and parameterized execution.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => _execute();

        public event EventHandler? CanExecuteChanged;

        #endregion

        #region Public Methods

        /// <summary>
        /// Triggers a reevaluation of CanExecute.
        /// </summary>
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }

    /// <summary>
    /// A generic command that passes a parameter of type T.
    /// Use when your command must receive a value from the UI.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null) return true;

            // Handle null safely for reference types
            if (parameter == null && default(T) == null)
                return _canExecute(default!);

            // Avoid invalid cast crash
            if (parameter is T t)
                return _canExecute(t);

            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T value)
            {
                _execute(value);
                return;
            }

            // Allow null for reference types
            if (parameter == null && default(T) == null)
            {
                _execute(default!);
                return;
            }

            // Defensive: ignore bad casts instead of crashing UI
        }

        public event EventHandler? CanExecuteChanged;

        #endregion

        #region Public Methods

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}
