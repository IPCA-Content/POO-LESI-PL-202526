using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDemo.ViewModels.Models;

namespace WpfAppDemo.ViewModels.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        bool Save(Employee employee);
    }
}
