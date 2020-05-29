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

        [HttpPost]
        public ActionResult Login(string userEmail, string userPwd)
        {
            if (userEmail.Equals("123@qq.com") && userPwd.Equals("123"))
            {
                ViewBag.userEmail = userEmail;
                ViewBag.userPwd = userPwd;
                return View();
            }
            else
            {
                ViewBag.Msg = "输入有误！";
                return View("Index");
            }
        }
    }
}