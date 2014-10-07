using System.Collections.Generic;
using System.IO;
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
            ViewBag.Title = "Employee Search";
            var searchParams = model.SearchParameters != null ? model.SearchParameters.ToLower() : string.Empty;
            var pageNumber = model.Page;
            Func<Employee, bool> searchCriteria = (employee) =>
                employee.Name.ToLower().Contains(searchParams)
                || employee.Email.ToLower().Contains(searchParams)
                || employee.Location.ToLower().Contains(searchParams)
                || employee.JobTitle.ToLower().Contains(searchParams);
            
            
            var resultData = !string.IsNullOrEmpty(searchParams) ? Procurer.Search(searchCriteria) : Procurer.GetData();
            
            //ToPagedList(page, 25),
            model = new EmployeeSearchViewModel
            {
                Page= pageNumber,
                ResultsCount = resultData.Count(),
                Results = resultData.Skip(model.Page -1 * model.ReturnCount).Take(model.ReturnCount).ToList(),
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