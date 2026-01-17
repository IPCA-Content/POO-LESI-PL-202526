//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.View.Interfaces;
using WpfAppDemo.ViewModels.Commands;
using WpfAppDemo.ViewModels.Models;
using WpfAppDemo.ViewModels.Services;
using WpfAppDemo.Views.Enums;
using WpfAppDemo.Views.Interfaces;

namespace WpfAppDemo.ViewModels
{
    /// <summary>
    /// ViewModel for login functionality. Handles authentication and navigation.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private readonly IViewFactory _viewFactory;
        private readonly IWindowService _windowService;
        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        #region Properties

        /// <summary>
        /// Action to hide the associated window. Typically set by the view.
        /// </summary>
        public Action? HideWindowAction { get; set; }

        /// <summary>
        /// Command for executing the login action.
        /// </summary>
        public ICommand CreateCommand { get; }

        /// <summary>
        /// Command for executing the edit employee action (open window).
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Command for executing the edit employee action (open window).
        /// </summary>

        public ObservableCollection<Employee> Employees { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="MainViewModel"/>.
        /// </summary>
        /// <param name="viewFactory">The factory to create views for navigation.</param>
        public MainViewModel(IViewFactory viewFactory, IWindowService windowService, IEmployeeRepository repository)
        {
            _employeeRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));
            
            IEnumerable<Employee> _employees = _employeeRepository.GetAll();

            Employees = new ObservableCollection<Employee>(_employees);

            EditCommand = new RelayCommand<Employee>(EditEmployee);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the create command.
        /// </summary>
        /// <param name="parameter">Optional command parameter (not used).</param>
        private void ExecuteCreateCommand(object parameter)
        {
            
        }

        private void EditEmployee(Employee employee)
        {
            // Handle edit logic (open window, show modal, etc.)
            // Debug.WriteLine($"Editing {employee.Name}");

            Window window = _viewFactory.ShowDialog(ViewType.EditEmployee, employee);
            //HideWindowAction?.Invoke();
            _windowService.CloseWindow(this);
            window?.Show();
        }

        #endregion
    }
}
