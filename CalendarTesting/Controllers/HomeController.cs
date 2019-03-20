using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CalendarTesting.Models;
using System.Text.RegularExpressions;

namespace FreeTrial.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            
            //return View();
            //return View("../ChoosePhoneNumber/Index");
            //return View("../Payment/Index");
            
            //return View("../Profile/Index");
            return View();
        }

        public ActionResult ScreenSizes(HomeModel.ScreenSettings ScreenSettings) 
        {
            if (TempData["FirstLoad"] == null)
            {
                TempData["FirstLoad"] = true;
                TempData.Keep("FirstLoad");
            }
            else
            {
                TempData["FirstLoad"] = false;
            }
            TempData["globalWidth"] = ScreenSettings.Width;
            TempData["globalHeight"] = ScreenSettings.Height;
            TempData.Keep("globalWidth");
            TempData.Keep("globalHeight");


            return Json(new { success = TempData["FirstLoad"]});
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult CheckValidCC(string txtCardNumber)
        {
            var ccType = "unknown";
            var ccLength = "unknown";
            if (string.IsNullOrEmpty(txtCardNumber) == false)
            {
                
                var regMC= new Regex("^5[1-5]");
                var regVS = new Regex("^4");
                var regAE = new Regex("^3[47]");
                
                if (regMC.IsMatch(txtCardNumber))
                {
                    ccType = "mastercard";
                }
                
                else if (regVS.IsMatch(txtCardNumber)) {
                    ccType = "visa";
                }
                    
                else if (regAE.IsMatch(txtCardNumber)) {
                    ccType = "amex";
                }
                
            }
            var result = (ccType != "unknown");

            if (ccType == "mastercard")
            {
                ccLength = "13";
            }
            else if (ccType == "visa")
            {
                ccLength = "13";
            }
            else if(ccType == "amex")
            {
                ccLength = "19";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

public enum HeaderViewRenderMode { Full, Title }
public enum StepsWizard { Profile, Business, Options, GetStarted, LetsGetStarted, SetUpSpecialist, Done }
public enum BusinessHours { MondayFrom, MondayTo, ThuesdayFrom,ThuesdayTo  }