using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProjectWeb.Controllers
{
    public class InvestmentController : Controller
    {
        issNewBAL.topupBAL objTopupBAL = new issNewBAL.topupBAL();

        // GET: Investment
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            ds = objTopupBAL.GetTopup();
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DateTime TDate, int TopupID, int TAmount)
        {
            int uID = 1;
            int resp = objTopupBAL.InsertUpdate(TopupID,TDate,1,uID,TAmount,"Create");
            if (resp==1)
            {
               return RedirectToAction("Index");
            }
            return View();
        }
    

    [HttpPost]
        public ActionResult Delete(int TopupID,int InvID)
        {
            int uID = 1;
            int resp = objTopupBAL.Delete(TopupID, InvID,uID, "Delete");
            if (resp==1)
            {
               return RedirectToAction("Index");
            }
            return View();
        }
    }
}