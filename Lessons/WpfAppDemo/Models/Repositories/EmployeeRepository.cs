using System.IO;
using System.Text.Json;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.ViewModels.Models;

namespace WpfAppDemo.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Fields

        private readonly string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");
        private readonly string _employeesFile;

        #endregion

        public EmployeeRepository()
        {
            _employeesFile = Path.Combine(_basePath, "employees.json");

            // Ensure the file exists to avoid null or file not found issues
            if (!File.Exists(_employeesFile))
            {
                File.WriteAllText(_employeesFile, "[]"); // Initialize with empty JSON array
            }
        }

        private List<Employee> LoadEmployees()
        {
            try
            {
                string readJsonString = File.ReadAllText(_employeesFile);
                return JsonSerializer.Deserialize<List<Employee>>(readJsonString) ?? new List<Employee>();
            }
            catch (IOException)
            {
                // Log exception if needed
                return new List<Employee>();
            }
            catch (Exception)
            {
                // Log exception if needed
                return new List<Employee>();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return LoadEmployees();
        }

        public bool Save(Employee employee)
        {
            return UpdateEmployee(employee);
        }

        private bool UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            List<Employee> emps = RemoveEmployee(employee);

            if (emps != null)
            {
                emps.Add(employee);

                return SaveEmployee(emps);
            }
            return false;
        }

        private bool SaveEmployee(IEnumerable<Employee> emp)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(emp, options);
            File.WriteAllText(_employeesFile, jsonString);
            return true;
        }

        private Tuple<List<Employee>, Employee?> GetEmployeeById(int id)
        {
            if (id < 0)
            {
                return null;
            }

            List<Employee> empls = LoadEmployees();
            return new Tuple<List<Employee>, Employee?>(empls, empls.FirstOrDefault(x => x.Id == id));
        }

        private List<Employee> RemoveEmployee(Employee empl)
        {
            if (empl == null)
            {
                return null;
            }

            Tuple<List<Employee>, Employee?> emplTmp = GetEmployeeById(empl.Id);
            emplTmp.Item1.Remove(emplTmp.Item2);
            return emplTmp.Item1;
        }
    }
}
