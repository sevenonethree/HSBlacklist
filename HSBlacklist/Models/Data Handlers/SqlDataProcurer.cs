using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HSBlacklist.Models;
namespace HSBlacklist.Models.DataHandlers
{
    public class SqlDataProcurer: IDataProcurer<Employee>
    {
        private SqlEntity dbContext = new SqlEntity();
        public IEnumerable<Employee> GetData()
        {
            return dbContext.Employees.OrderBy(x => x.Id);
        }

        public Employee Find(Func<Employee, bool> predicate)
        {
            return dbContext.Employees.Where(predicate).FirstOrDefault();
        }
    }
}