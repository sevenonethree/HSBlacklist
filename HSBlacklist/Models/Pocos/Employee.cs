using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSBlacklist.Models.Pocos
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}