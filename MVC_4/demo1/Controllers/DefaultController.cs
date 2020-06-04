using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int Id, string Name)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;

            return View();
        }
    }
}