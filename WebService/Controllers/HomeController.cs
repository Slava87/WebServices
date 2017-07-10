using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.Models;
using WebService.ViewModel;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            List<Person> persons = db.Persons.ToList();
            return View();
        }



        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}