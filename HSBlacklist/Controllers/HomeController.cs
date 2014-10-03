using HSBlacklist.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSBlacklist.Controllers
{
    public class HomeController : Controller
    {
        static List<Employee> EmployeeList { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            EmployeeList = GenerateFakeEmployees();
            return View(EmployeeList);
        }

        List<Employee> GenerateFakeEmployees()
        {
            var list = new List<Employee>();

            list.Add(new Employee
            {
                Id = 333,
                Email = "test@test.com",
                JobTitle = "User",
                Location = "Dallas, TX",
                Name = "Test User",
                Phone = "8005551234"
            });

            list.Add(new Employee
            {
                Id = 1,
                Email = "test2@test.com",
                JobTitle = "HR",
                Location = "Irving, TX",
                Name = "Application Test",
                Phone = "8005551234"
            });

            return list;
        }

        public ActionResult Details(int employeeToEdit)
        {
            return View(EmployeeList.Where(x => x.Id == employeeToEdit).FirstOrDefault());
        }
    }


}
