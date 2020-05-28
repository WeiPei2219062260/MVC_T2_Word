using demo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            StudentEntities entities = new StudentEntities();
            List<demo2.Models.Student_Data> studentList = entities.Student_Data.ToList();
            ViewBag.studentList = studentList;
            return View();
        }
    }
}