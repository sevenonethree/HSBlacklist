using HSBlacklist.Models;
using HSBlacklist.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace HSBlacklist.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
            : this(new FileDataProcurer<Employee>())
        { }

        public HomeController(IDataProcurer<Employee> procurer)
        {
            Procurer = procurer;

        }
        public static IDataProcurer<Employee> Procurer { get; set; }
        static List<Employee> EmployeeList { get; set; }
        public ActionResult Index(EmployeeSearchViewModel model)
        {
            ViewBag.Title = "Home Page";
            var page = model.Page == 0 ? 1 : model.Page ;
            EmployeeList = Procurer.GetData().ToList();

            if (model.Results == null)
            {
                model = new EmployeeSearchViewModel()
                {
                    Results = Procurer.GetData().ToPagedList(page, 25)
                    //Results = new PagedList.PagedList<Employee>(Procurer.GetData(), 1, 50)
                };
            }
            //var model = new EmployeeSearchViewModel()
            //{ 
            //    Results = new PagedList.PagedList<Employee>(Procurer.GetData(),1,50)
            //};

            return View(model);
        }

        public ActionResult Details(int employeeToEdit)
        {
            return View(EmployeeList.Where(x => x.Id == employeeToEdit).FirstOrDefault());
        }
    }


}
