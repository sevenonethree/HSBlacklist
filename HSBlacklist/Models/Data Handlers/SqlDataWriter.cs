using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSBlacklist.Models.Data_Handlers
{
    public class SqlDataWriter : IDataWriter<Employee>
    {
        private SqlEntity DBContext { get; set; }

        public SqlDataWriter()
        {
            DBContext = new SqlEntity();
        }
        public Employee WriteData(Employee data)
        {
            var employee = DBContext.Employees.Where(x => x.Id == data.Id).FirstOrDefault();
            
            employee.Email = data.Email;
            employee.JobTitle = data.JobTitle;
            employee.Location = data.Location;
            employee.Name = data.Name;
            employee.Phone = data.Phone;
            
            try
            {
                DBContext.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }

            return employee;
        }
        
    }
}