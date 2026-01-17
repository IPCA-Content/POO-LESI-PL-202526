using System;
using System.Windows.Input;
using WpfAppDemo.View.Interfaces;
using WpfAppDemo.ViewModels.Commands;
using WpfAppDemo.ViewModels.Interfaces;
using WpfAppDemo.ViewModels.Models;
using WpfAppDemo.ViewModels.Services;

namespace WpfAppDemo.ViewModels
{
    /// <summary>
    /// ViewModel for editing an <see cref="Employee"/>.
    /// </summary>
    public class EditEmployeeViewModel : BaseViewModel
    {
        #region Fields

        private readonly IWindowService _windowService;
        private readonly IEmployeeService _employeeService;

        // Backing fields for properties (important: avoid recursive getters/setters).
        private int _id;
        private string _name = string.Empty;
        private string _birthDay = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="EditEmployeeViewModel"/>.
        /// </summary>
        /// <param name="employeeService">Service used to save employees.</param>
        /// <param name="employee">Employee to edit (can be null for new employee).</param>
        public EditEmployeeViewModel(IEmployeeService employeeService, IWindowService windowService, Employee employee)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _windowService = windowService ?? throw new ArgumentNullException(nameof(windowService));
            Employee = employee ?? new Employee();

            // Initialize properties from the Employee model
            _id = Employee.Id;
            _name = Employee.Name ?? string.Empty;
            _birthDay = Employee.BirthDay ?? string.Empty;

            EditCommand = new RelayCommand<Employee>(EditEmployee, CanEditEmployee);
            CancelCommand = new RelayCommand(Cancel);

            // Default CloseWindowAction is null; view should set it (see wiring example).
            CloseWindowAction = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The employee model bound to the UI.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Action to request the view to close. The view should assign this, for example:
        /// vm.CloseWindowAction = () => this.Close();
        /// </summary>
        public Action? CloseWindowAction { get; set; }

        /// <summary>
        /// Employee identifier.
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        /// <summary>
        /// Employee name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Employee birthday as string (bind as needed or use DateTime for better modeling).
        /// </summary>
        public string BirthDay
        {
            get => _birthDay;
            set
            {
                if (_birthDay != value)
                {
                    _birthDay = value;
                    OnPropertyChanged(nameof(BirthDay));
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command that saves the employee and (optionally) closes the window.
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Command that cancels editing (does not save) and requests window close.
        /// </summary>
        public ICommand CancelCommand { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Whether the Edit command can execute. Add validation here as required.
        /// </summary>
        private bool CanEditEmployee(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            // Example simple validation: require a name. Adjust to your rules.
            return !string.IsNullOrWhiteSpace(employee.Name);
        }

        /// <summary>
        /// Save the employee data and request the view to close.
        /// </summary>
        private void EditEmployee(Employee employee)
        {
            _employeeService.Save(employee);

            // Safe close invocation: call if set, but guard against exceptions if view is already closed.
            TryInvokeCloseAction();
        }

        /// <summary>
        /// Cancel editing and request the view to close (no save).
        /// </summary>
        private void Cancel()
        {
            TryInvokeCloseAction();
        }

        /// <summary>
        /// Invokes <see cref="CloseWindowAction"/> safely. Catches exceptions that
        /// may happen if the window was already disposed/closed by another mechanism (e.g. user pressed X).
        /// </summary>
        private void TryInvokeCloseAction()
        {
            if (CloseWindowAction == null) return;

            try
            {
                _windowService.CloseWindow(this);
            }
            catch (ObjectDisposedException)
            {
                // Window or dispatcher already disposed — swallow or log as appropriate.
            }
            catch (InvalidOperationException)
            {
                // Window dispatcher/shutdown state — swallow or log as appropriate.
            }
            catch (Exception)
            {
                // If you have logging infrastructure, log unexpected exceptions here.
                // Don't rethrow; VM should not crash the UI thread.
            }
        }

        #endregion
    }
}