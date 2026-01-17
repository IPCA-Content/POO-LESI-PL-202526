

using WpfAppDemo.ViewModels.Models;

namespace WpfAppDemo.Models.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        bool Save(Employee employee);
    }
}
