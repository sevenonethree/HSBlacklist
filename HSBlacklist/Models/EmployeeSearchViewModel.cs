using HSBlacklist.Models.Pocos;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSBlacklist.Models
{
    public class EmployeeSearchViewModel
    {
        public int Page { get; set; }
        public IPagedList<Employee> Results { get;set;}
        public string SearchParameters { get; set; }
    }
}