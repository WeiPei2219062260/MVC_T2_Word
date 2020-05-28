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
            //很简单的传值方式，相当于有一个字典存储，控制器使用方法：
            ViewData["msg"] = "别害怕我是好人!";
            var user = new Models.User();
            user.UserID = 1;
            user.UserName = "覃大铁";
            ViewData["user"] = user;
            return View();
        }

        //使用TempData
        public ActionResult Result()
        {
            var user = new Models.User();
            user.UserID = 2;
            user.UserName = "覃灿";
            TempData["user"] = user;
            Session["UserID"] = user.UserID;
            return View();
        }

        //跨页面显示
        public ActionResult Show()
        {
            return View();
        }
    }
}