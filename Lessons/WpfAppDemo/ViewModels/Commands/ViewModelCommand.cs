//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Windows.Input;

namespace WpfAppDemo.ViewModels.Commands
{
    /// <summary>
    /// A command implementation that wraps execute and can-execute delegates for MVVM binding.
    /// </summary>
    public class ViewModelCommand : ICommand
    {
        #region Delegates

        /// <summary>
        /// Delegate for the command's execute action.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public delegate void ICommandOnExecute(object? parameter);

        /// <summary>
        /// Delegate for the command's can-execute function.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns>True if the command can execute, otherwise false.</returns>
        public delegate bool ICommandOnCanExecute(object? parameter);

        #endregion

        #region Fields

        private readonly ICommandOnExecute _execute;
        private readonly ICommandOnCanExecute? _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="ViewModelCommand"/> with an execute delegate.
        /// </summary>
        /// <param name="onExecuteMethod">The execute delegate.</param>
        public ViewModelCommand(ICommandOnExecute onExecuteMethod)
        {
            _execute = onExecuteMethod ?? throw new ArgumentNullException(nameof(onExecuteMethod));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ViewModelCommand"/> with execute and can-execute delegates.
        /// </summary>
        /// <param name="onExecuteMethod">The execute delegate.</param>
        /// <param name="onCanExecuteMethod">The can-execute delegate.</param>
        public ViewModelCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod ?? throw new ArgumentNullException(nameof(onExecuteMethod));
            _canExecute = onCanExecuteMethod ?? throw new ArgumentNullException(nameof(onCanExecuteMethod));
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns>True if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }

        #endregion
    }
}
