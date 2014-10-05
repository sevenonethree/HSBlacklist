using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PagedList;

namespace HSBlacklist.Models.DataHandlers
{
    public class FileDataProcurer<Employee> : IDataProcurer<Employee>
    {
        public FileDataProcurer()
        {
            Employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(GetEmployeesFromJsonFile(@"C:\Users\Tré\documents\visual studio 2013\Projects\HSBlacklist\HSBlacklist\App_Data\Employees.json"));
        }
        private IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Employee> GetData()
        {
            return Employees;
        }

        public Employee Find(Func<Employee,bool> predicate)
        {
            return Employees.Where(predicate).FirstOrDefault();
        }

        private string GetEmployeesFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            var employeesJson = string.Empty;
            try
            {
                employeesJson = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                throw;
                
            }

            return employeesJson;
        }
    }
}