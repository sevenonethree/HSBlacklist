using HSBlacklist.Models.DataHandlers;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HSBlacklist.Models
{
    public class EmployeeSearchViewModel
    {
        public int Page { get; set; }
        public IPagedList<Employee> Results { get;set;}
        [Display(Name="Employee Name")]
        public string SearchParameters { get; set; }
    }
}