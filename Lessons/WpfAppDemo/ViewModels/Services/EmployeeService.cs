using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.ViewModels.Interfaces;
using WpfAppDemo.ViewModels.Models;

namespace WpfAppDemo.ViewModels.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;   
        }

        public IEnumerable<Employee> GetAll()
        {
            // Additional logic, if user has access???

            return _employeeRepository.GetAll();
        }

        public bool Save(Employee employee)
        {
            // Additional logic, if user has permissions to save???
            
            return _employeeRepository.Save(employee);
        }
    }
}
