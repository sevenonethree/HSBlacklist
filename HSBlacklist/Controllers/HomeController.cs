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
        public static IDataProcurer<Employee> Procurer { get; set; }

        static List<Employee> EmployeeList { get; set; }

        public HomeController(IDataProcurer<Employee> procurer)
        {
            Procurer = procurer;

        }

        public ActionResult Index(EmployeeSearchViewModel model)
        {
            ViewBag.Title = "Home Page";
            var page = model.Page == 0 ? 1 : model.Page ;
            IEnumerable<Employee> resultData = null;

            if (!string.IsNullOrEmpty(model.SearchParameters))
                resultData = Procurer.GetData().Where(x => x.Name.Contains(model.SearchParameters));
            else
                resultData = Procurer.GetData();

                model = new EmployeeSearchViewModel()
                {
                    Results = resultData.ToPagedList(page, 25),
                    SearchParameters = model.SearchParameters
                };

            return View(model);
        }

        public ActionResult Details(int employeeToEdit)
        {
            return View(Procurer.Find(x => x.Id == employeeToEdit));
        }
    }


}
