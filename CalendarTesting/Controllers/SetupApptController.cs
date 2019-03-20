using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarTesting.Controllers
{
    public class SetupApptController : Controller
    {
        //
        // GET: /service_details/
        public ActionResult Index()
        {
            TempData["globalWidth"] = 1090;
            TempData.Keep("globalWidth");
            TempData.Keep("globalHeight");
            return View();
        }

        public ActionResult SaveSetUpApptgData()
        {
            TempData.Keep("globalWidth");
            TempData.Keep("globalHeight");
            return Json(new { success = true, url = Url.Action("Index", "thank_you") });
        }
	}
}