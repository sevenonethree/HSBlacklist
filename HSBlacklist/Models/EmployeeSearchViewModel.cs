using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HSBlacklist.Models
{
    public class EmployeeSearchViewModel
    {
        public int Page { get; set; }

        public int ReturnCount { get; set; }

        public int ResultsCount { get; set; }

        public int NumberOfPages {get { return (ResultsCount/ReturnCount); }}
        public IList<Employee> Results { get;set;}

        [Display(Name="Search For", Prompt = "Search by Name, JobTitle, Email Address, or Location")]
        public string SearchParameters { get; set; }

        public EmployeeSearchViewModel()
        {
            ReturnCount = 25;
            Page = 1;
        }

    }
}