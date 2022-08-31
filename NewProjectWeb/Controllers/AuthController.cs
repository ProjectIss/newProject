using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProjectWeb.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uName,string pWord)
        {
            if (!string.IsNullOrEmpty(uName)&&!string.IsNullOrEmpty(pWord))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}