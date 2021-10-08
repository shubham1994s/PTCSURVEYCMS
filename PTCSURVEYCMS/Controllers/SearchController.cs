using BLL.Repository.Repository;
using BLL.ViewModel;
using DAL.ChildDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCSURVEYCMS.Controllers
{
    public class SearchController : Controller
    {

        IRepository Repository;
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SurveyListSearch(int q = -1, int clientId = 0)
        {
            Repository = new Repository();
            if (clientId != 0)
            {
                SessionHandler.Current.AppId = clientId;
                int AppId = SessionHandler.Current.AppId;
                AppDetailsVM ApplicationDetails = Repository.GetApplicationDetails(AppId);
                ViewBag.Appname = ApplicationDetails.AppName;
            }
            else
            {
                ViewBag.Appname = SessionHandler.Current.AppName;
            }
            if (SessionHandler.Current.AppId != 0)
            {
                int Appid = SessionHandler.Current.AppId;
                if (Appid == 1)
                {
                    ViewBag.Clogo = "property_tax_logo.png";

                }
                if (Appid == 2)
                {
                    ViewBag.Clogo = "vengurla logo.jpeg";
                }


                var viewModel = new PropertyMasterVM();
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
                using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                    var EntryCount = db.PropertyMasters.Where(x => x.IsDelete == false).Count();
                    ViewBag.EntryCount = EntryCount;
                }

                var jsonResult = Json("10000000", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;


                //   return Json(viewModel);
                return View(viewModel);

            }

            else
            {
                return Redirect("/Account/Login");
            }

        }
    }
}