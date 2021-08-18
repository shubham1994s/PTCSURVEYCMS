
using BLL.Repository.Repository;
using BLL.ViewModel;
using DAL.ChildDatabase;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCSURVEYCMS.Controllers
{
    public class PTCController : Controller
    {
        IRepository Repository;
        // GET: PTC

        public ActionResult SurveyForm()
        {
         
            if (SessionHandler.Current.AppId != 0)
            {

                ViewBag.Appname = SessionHandler.Current.AppName;
            
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddSurveyForm(PropertyMasterVM Property, HttpPostedFileBase file, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {

            int AppId = SessionHandler.Current.AppId;
            if (SessionHandler.Current.AppId != 0)
            {

                if (file != null && file.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file.FileName);
                    var ext = Path.GetExtension(file.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.SurveyorSignature = myfile;
                        file.SaveAs(path);
                    }
                }
                if (file2 != null && file2.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file2.FileName);
                    var ext = Path.GetExtension(file2.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.DataEntrySignature = myfile;
                        file2.SaveAs(path);
                    }
                }

                if (file3 != null && file3.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file3.FileName);
                    var ext = Path.GetExtension(file3.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.Sketchdiagram = myfile;
                        file3.SaveAs(path);
                    }
                }
                if (file4 != null && file4.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                    var fileName = Path.GetFileName(file4.FileName);
                    var ext = Path.GetExtension(file4.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        var path = Path.Combine(Server.MapPath("~/Images"), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.Sketchdiagram2 = myfile;
                        file4.SaveAs(path);
                    }
                }
                Result Result = new Result();
                Repository = new Repository();
                Result = Repository.PropertySave(Property, AppId);
                ViewBag.Message = Result.message;
                return Redirect("/PTC/SurveyList");

            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        public ActionResult SurveyList(int q = -1,int clientId=0)
        {
            Repository = new Repository();
            if (clientId!=0)
            {
                SessionHandler.Current.AppId = clientId;
                int AppId = SessionHandler.Current.AppId;     
                AppDetailsVM  ApplicationDetails = Repository.GetApplicationDetails(AppId);
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

                    var EntryCount = db.PropertyMasters.Count();
                    ViewBag.EntryCount = EntryCount;
                }
                return View(viewModel);
             
            }

            else
            {
                return Redirect("/Account/Login");
            }
         
        }


        [HttpGet]
        public JsonResult getPropertyDetails()
        {
            Repository = new Repository();
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getPropertyDetails(AppId);
            //var dataJson = JsonConvert.SerializeObject(griddata);
            return Json(new { data = griddata }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SurveyForm(int q = -1)
        {
            if(q==-1)
            {
                ViewBag.btn = "Save";
            }
            else
            {
                ViewBag.btn = "Save Changes";
            }
            if (SessionHandler.Current.AppId != 0)
            {

                int Appid = SessionHandler.Current.AppId;
                ViewBag.Appname_mar = SessionHandler.Current.AppName_mar;
                Repository = new Repository();
                var viewModel = new PropertyMasterVM();
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }


        [HttpGet]
        public ActionResult ViewSurveyForm(int q = -1)
        {
            if (SessionHandler.Current.AppId != 0)
            {
                int Appid = SessionHandler.Current.AppId;
                if (Appid==1)
                {
                    ViewBag.logo = "property_tax_logo.png";
                    ViewBag.RLogo = "mkmj.jpeg";
                }
                if (Appid == 2)
                {
                    ViewBag.logo = "vengurla logo.jpeg";
                    ViewBag.RLogo = "Logo_150x48.png";
                }
                ViewBag.Appname_mar = SessionHandler.Current.AppName_mar;
                Repository = new Repository();
                var viewModel = new PropertyMasterVM();
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }

        [HttpPost]
        public string IsPropertyNoExists(string PropertyNo)
        {
            int Appid = SessionHandler.Current.AppId;
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                var isrecord = db.PropertyMasters.Where(x => x.PropertyNo == PropertyNo).FirstOrDefault();
                if (isrecord != null)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }

            }
        }
        [HttpPost]
        public string IsNewPropertyNoExists(string NewPropertyNo)
        {
            int Appid = SessionHandler.Current.AppId;
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                var isrecord = db.PropertyMasters.Where(x => x.NewPropertyNo == NewPropertyNo).FirstOrDefault();
                if (isrecord != null)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }

            }
        }

        [HttpPost]
        public int EntryCount(string PropertyNo)
        {
            int Appid = SessionHandler.Current.AppId;
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                var EntryCount = db.PropertyMasters.Count();
                return EntryCount;
            }
        }


    }
}