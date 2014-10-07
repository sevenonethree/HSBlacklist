using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HSBlacklist.Models;
namespace HSBlacklist.Models.DataHandlers
{
    public class SqlDataProcurer: IDataProcurer<Employee>
    {
        private readonly SqlEntity _dbContext = new SqlEntity();
        public IEnumerable<Employee> GetData()
        {
            return _dbContext.Employees.OrderBy(x => x.Id);
        }

        public Employee Find(Func<Employee, bool> predicate)
        {
            return _dbContext.Employees.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<Employee> Search(Func<Employee, bool> predicate)
        {
            return _dbContext.Employees.Where(predicate);
        }
    }
}