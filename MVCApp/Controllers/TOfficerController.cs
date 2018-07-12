using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRepository;

namespace MVCApp.Controllers
{
    public class TOfficerController : Controller
    {
        // GET: TOfficer
        public ActionResult Home(TOfficer ho)
        {
            Session["TOfficer"] = ho;
            return RedirectToAction("Home1");
        }

        public ActionResult Home1()
        {
            return View(Session["TOfficer"]);
        }
    }
}