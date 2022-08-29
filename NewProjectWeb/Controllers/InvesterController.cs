using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProjectWeb.Controllers
{
    public class InvesterController : Controller
    {
        // GET: Invester
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}