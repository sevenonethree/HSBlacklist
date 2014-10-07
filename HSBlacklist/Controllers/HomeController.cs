using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HSBlacklist.Models;
using HSBlacklist.Models.DataHandlers;
using PagedList;
using System;

namespace HSBlacklist.Controllers
{
    public class HomeController : Controller
    {
        public static IDataProcurer<Employee> Procurer { get; set; }
        public static IDataWriter<Employee> EmployeeWriter { get; set; }

        public HomeController(IDataProcurer<Employee> procurer, IDataWriter<Employee> writer)
        {
            Procurer = procurer;
            EmployeeWriter = writer;
        }

        public ActionResult Index(EmployeeSearchViewModel model)
        {
            ViewBag.Title = "Home Page";
            var page = model.Page == 0 ? 1 : model.Page;
            var searchParams = model.SearchParameters != null ? model.SearchParameters.ToLower() : null;
            IEnumerable<Employee> resultData;

            Func<Employee, bool> searchCriteria = (employee) =>
                employee.Name.ToLower().Contains(searchParams)
                || employee.Email.ToLower().Contains(searchParams)
                || employee.Location.ToLower().Contains(searchParams)
                || employee.JobTitle.ToLower().Contains(searchParams);
            
            
            if (!string.IsNullOrEmpty(searchParams))
                resultData = Procurer.Search(searchCriteria);
            else
                resultData = Procurer.GetData();

            model = new EmployeeSearchViewModel
            {
                Results = resultData.ToPagedList(page, 25),
                SearchParameters = model.SearchParameters
            };

            return View(model);
        }

        public ActionResult Details(int employeeToView)
        {
            return View(Procurer.Find(x => x.Id == employeeToView));
        }

        public ActionResult Edit(int employeeToEdit)
        {
            return View(Procurer.Find(x => x.Id == employeeToEdit));
        }

        public ActionResult SaveEmployee(Employee emp)
        {
            var updatedEmployee = EmployeeWriter.WriteData(emp);
            if (updatedEmployee.Equals(emp))
                return new RedirectResult(Request.UrlReferrer.OriginalString);

            return (new JsonResult { Data = new { Text = "Unable to update" } });
        }
    }
}