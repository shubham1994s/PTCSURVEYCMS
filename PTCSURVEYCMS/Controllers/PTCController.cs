﻿
using BLL.Repository.Repository;
using BLL.ViewModel;
using DAL;
using DAL.ChildDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;



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
                DEVPTCSURVEYMAINEntities db = new DEVPTCSURVEYMAINEntities();
                var AppDetails = db.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault();
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
                       
                       var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.basePath));
                    //    var exists = System.IO.Directory.Exists(Server.MapPath("~/Images"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(AppDetails.basePath));
                        }
                        var path = Path.Combine(Server.MapPath(AppDetails.basePath), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.SurveyorSignature = myfile;
                        file.SaveAs(path);
                    }
                }
                if (file2 != null && file2.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg",".pdf" };

                    var fileName = Path.GetFileName(file2.FileName);
                    var ext = Path.GetExtension(file2.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.basePath));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(AppDetails.basePath));
                        }
                        var path = Path.Combine(Server.MapPath(AppDetails.basePath), myfile);
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
                        var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.basePath));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(AppDetails.basePath));
                        }
                        var path = Path.Combine(Server.MapPath(AppDetails.basePath), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.Sketchdiagram = myfile;
                        file3.SaveAs(path);
                    }
                }
                if (file4 != null && file4.ContentLength > 0)
                {
                    //int AppId = int.Parse(SessionHandler.Current.AppId.ToString());
                    //var AppDetails = mainRepository.GetApplicationDetails(AppId);
                    var _Extensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg",".pdf" };

                    var fileName = Path.GetFileName(file4.FileName);
                    var ext = Path.GetExtension(file4.FileName);
                    if (_Extensions.Contains(ext))
                    {
                        //Guid Random = Guid.NewGuid();
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = name + ext;

                        //var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"));
                        var exists = System.IO.Directory.Exists(Server.MapPath(AppDetails.basePath));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(AppDetails.basePath));
                        }
                        var path = Path.Combine(Server.MapPath(AppDetails.basePath), myfile);
                        //var path = Path.Combine(Server.MapPath(AppDetails.baseImageUrlCMS + "Images"), myfile);

                        Property.Sketchdiagram2 = myfile;
                        file4.SaveAs(path);
                    }
                }
                Result Result = new Result();
                Repository = new Repository();
                Result = Repository.PropertySave(Property, AppId);
                TempData["Success"] = Result.message;
                return Redirect("/PTC/SurveyList");

            }
            else
            {
                return Redirect("/Account/Login");
            }
        }
        [HttpGet]
        public ActionResult SurveyList(int q = -1, int clientId = 0)
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

        public ActionResult LoadData()
       {
            try
            {
                int AppId = SessionHandler.Current.AppId;
              
                    //Creating instance of DatabaseContext class  
                    using (DEVPTCSURVEYMALEGAONEntities _context = new DEVPTCSURVEYMALEGAONEntities(AppId))
                    {
                        var draw = Request.Form.GetValues("draw").FirstOrDefault();
                        var start = Request.Form.GetValues("start").FirstOrDefault();
                        var length = Request.Form.GetValues("length").FirstOrDefault();
                        var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                        var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                        var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                   // searchValue = "W1Z2000001";
                    Repository = new Repository();
                    //Paging Size (10,20,50,100)    
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                        int skip = start != null ? Convert.ToInt32(start) : 0;
                        int recordsTotal = 0;
                    var griddata = Repository.getPropertyDetails(AppId);
                    // Getting all Customer data
                    // 
                   // List<PropertyMaster> customerData = _context.PropertyMasters.Where(x=>x.IsDelete==false).ToList();
                   var customerData = (from tempcustomer in griddata select tempcustomer);

                        //Sorting    
                        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                        {
                     

                        customerData= customerData.OrderByDescending(x => x.PropertyId).ToList();
                    }         
                   
                    //Search    
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        var model = customerData.Where(c => ((string.IsNullOrEmpty(c.PropOwnerFirstName) ? " " : c.PropOwnerFirstName) + " " +
                                      (string.IsNullOrEmpty(c.PropOwnerMiddleName) ? " " : c.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(c.PropOwnerLastName) ? " " : c.PropOwnerLastName) + " " +
                                       (string.IsNullOrEmpty(c.PropOwnerTelephoneNo) ? " " : c.PropOwnerTelephoneNo) + " " +
                                      (string.IsNullOrEmpty(c.NewPropertyNo) ? " " : c.NewPropertyNo) + " " +
                                      (string.IsNullOrEmpty(c.PropertyNo) ? " " : c.PropertyNo) + " " +
                                      (string.IsNullOrEmpty(c.OldHouseNo1) ? " " : c.OldHouseNo1)
                                                           
                                       ).ToUpper().Contains(searchValue.ToUpper())).ToList();

                       customerData = model.ToList();
                    }

                    //total number of rows count     
                    recordsTotal = customerData.Count();
                    //Paging     
                    var data = customerData.Skip(skip).Take(pageSize).ToList();
                    
                 //   var data = customerData.Take(pageSize).ToList();
                    //Returning Json Data    
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                    }
                
            }
            
            catch (Exception ex)
            {
                throw;
            }

        }

 

public string SelectionNotExists(string SearchText, string selectoption)
        {
            int Appid = SessionHandler.Current.AppId;
            string msg = "";
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
              
                if (selectoption == "PropertyNumber")
                {
                    var isrecord = db.PropertyMasters.Where(x => x.PropertyNo == SearchText && x.IsDelete == false).FirstOrDefault();
                    if (isrecord == null)
                    {
                        msg = "This Property Number Is Not Exist!";
                    }
                    else
                    {
                        msg = "This Property Number Is  Exist!";
                    }
                }
                if (selectoption == "PrabhagNumber")
                {
                    var isrecord = db.PropertyMasters.Where(x => x.PrabhagNo == SearchText && x.IsDelete == false).FirstOrDefault();
                    if (isrecord == null)
                    {
                        msg = "This Prabhag Number Is Not Exist!";
                    }
                    else
                    {
                        msg = "This Prabhag Number Is  Exist!";
                    }
                }
                if (selectoption == "WardNumber")
                {
                    var isrecord = db.PropertyMasters.Where(x => x.WardNameNo == SearchText && x.IsDelete == false).FirstOrDefault();
                    if(isrecord==null)
                    { 
                    msg = "This Ward Number Is Not Exist!";
                    }
                    else
                    {
                        msg = "This Ward Number Is  Exist!";
                    }
                }

           
            }

            return msg;
        }
        [HttpPost]
        public ActionResult SurveyList(string send, string Reminder, string SearchText, string SelectOption,int q = -1, int clientId = 0 )
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

                DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid);
                
                    //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                    var EntryCount = db.PropertyMasters.Where(x => x.IsDelete == false).Count();
                    ViewBag.EntryCount = EntryCount;

                PropertyMasterVM model = new PropertyMasterVM();
              if (q == -1 && SearchText != null )
                 { 
                 model = Repository.SendPropertyDetails(Appid, SearchText, SelectOption,send,Reminder,q);
                    send = null;
                    Reminder = null;
                 }
              else if(q != -1)
                {
                    model = Repository.SendPropertyDetails(Appid, SearchText, SelectOption, send, Reminder, q);
                }

                if (model.ErrorMsg== "error" && q!=-1)
                {
                   
                    return Json(new { success = false, responseText = "Your message is not successfuly send!" }, JsonRequestBehavior.AllowGet);                 
                }
               else if(q != -1)
                {
                   
                    return Json(new { success = true, responseText = "Your message successfuly send!" }, JsonRequestBehavior.AllowGet);
                }

                if (model.ErrorMsg == "error")
                {
                    if (TempData["Success"] == null)
                    {
                        TempData["Success"] = "This Massage Is Not Send Successfully!";
                    }
                    else
                    {
                        TempData["Success"] = null;
                    }
                }
                else if(model.ErrorMsg != "error")
                {
                    if(TempData["Success"]==null)
                    { 
                    TempData["Success"] = "This Massage Is  Send Successfully!";
                    }
                    else
                    {
                        TempData["Success"] = null;
                    }
                }

                 if (q !=-1 && Reminder==null && send==null)
                {                
                        TempData["Success"] = null;               
                }

                return View(viewModel);

            }

            else
            {
                return Redirect("/Account/Login");
            }

        }


        public ActionResult PrabhagList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                PropertyMasterVM obj = new PropertyMasterVM();
                Repository = new Repository();
                int AppId = SessionHandler.Current.AppId;
                obj = Repository.GetPrabhagNo(AppId, -1);
                return Json(obj.PrabhagNoList, JsonRequestBehavior.AllowGet);

            }
            else
                return Redirect("/Account/Login");
        }

        public ActionResult WardList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                PropertyMasterVM obj = new PropertyMasterVM();
                Repository = new Repository();
                int AppId = SessionHandler.Current.AppId;
                obj = Repository.GetWardNo(AppId, -1);
                return Json(obj.WardNoList, JsonRequestBehavior.AllowGet);

            }
            else
                return Redirect("/Account/Login");
        }


        public ActionResult CSDateList()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                PropertyMasterVM obj = new PropertyMasterVM();
                Repository = new Repository();
                int AppId = SessionHandler.Current.AppId;
                obj = Repository.GetCSDate(AppId, -1);
                return Json(obj.CSDateList, JsonRequestBehavior.AllowGet);

            }
            else
                return Redirect("/Account/Login");
        }
        // done by shubham
        public FileResult Export(int q)
        {
            Repository = new Repository();
            int Appid = SessionHandler.Current.AppId;
            var viewModel = new PropertyMasterVM();
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
            //Build the File Path.
                string fileName= viewModel.Sketchdiagram2;
                string path = Server.MapPath("~/Images/") + fileName;
                //Read the File data into Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                //Send the File to Download.         
            return File(bytes, "application/octet-stream", fileName);
        }
       [HttpGet]
        public JsonResult getPropertyDetails()
        {
            Repository = new Repository();
            int AppId = SessionHandler.Current.AppId;
            var griddata = Repository.getPropertyDetails(AppId);
            //var dataJson = JsonConvert.SerializeObject(griddata);
            //  Response.Write(new ScriptingJsonSerializationSection().MaxJsonLength);
            //     var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100000 };
            return Json(new { data = griddata, MaxJsonLength = 86753090 },JsonRequestBehavior.AllowGet);

            //JsonSerializerSettings json = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            //var result = JsonConvert.SerializeObject(griddata, Formatting.Indented, json);
            //return new JsonResult { Data = result, MaxJsonLength = int.MaxValue };

         //   return new JsonResult() { Data = griddata, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            //    var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };

            //return new JsonResult()
            //{
            //    Content = serializer.Serialize(griddata),
            //    ContentType = "application/json",
            //};
            //var jsonResult = Json(griddata, JsonRequestBehavior.AllowGet);
            //jsonResult.MaxJsonLength = int.MaxValue;
            //return jsonResult;
            //  return new JsonResult ({ Data = griddata, MaxJsonLength = Int32.MaxValue, JsonRequestBehavior.AllowGet });

            //return new JsonResult()
            //{
            //   // ContentEncoding = Encoding.Default,
            //    ContentType = "application/json",
            //    Data = griddata,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            //    MaxJsonLength = 50000000
            //};

            //return new JsonResult()
            //{
            //    Data = griddata,
            //    MaxJsonLength = 86753090,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        }

        [HttpGet]
        public ActionResult SurveyForm(int q = -1)
        {
            if (q==-1)
            {
                ViewBag.btn = "Save";
                ViewBag.nadoc = "na";
            }
            else
            {
                ViewBag.btn = "Save Changes";
            }
            if (SessionHandler.Current.AppId != 0)
            {

                DEVPTCSURVEYMAINEntities db = new DEVPTCSURVEYMAINEntities();
               
                Repository = new Repository();
                int Appid = SessionHandler.Current.AppId;
                AppDetailsVM ApplicationDetails = Repository.GetApplicationDetails(Appid);
                ViewBag.Appname_mar = ApplicationDetails.AppName_mar;
                var viewModel = new PropertyMasterVM();
             
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
                if (viewModel.Sketchdiagram2 == null)
                {
                    ViewBag.nadoc = "na";
                }
                else
                {
                    int AppId = SessionHandler.Current.AppId;
                    var AppDetails = db.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault();
                    ViewBag.img = AppDetails.basePath;
                }
                return View(viewModel);
            }
            else
            {
                return Redirect("/Account/Login");
            }

        }
        public RedirectResult Delete(int q)
        {
            int AppId = SessionHandler.Current.AppId;
            var viewModel = new PropertyMasterVM();
            if (SessionHandler.Current.AppId != 0)
            {
                Repository = new Repository();
                viewModel = Repository.getDeleteByID(q, AppId);
            }
            return Redirect("/PTC/SurveyList");
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
                Repository = new Repository();
                AppDetailsVM ApplicationDetails = Repository.GetApplicationDetails(Appid);
                ViewBag.Appname_mar = ApplicationDetails.AppName_mar;
               
             
                var viewModel = new PropertyMasterVM();
          
                viewModel = Repository.getPropertyDetailsByID(q, Appid);
                if(viewModel.DateofConstruction1== "--Select Date--")
                {
                    viewModel.DateofConstruction1 = null;
                }
                if (viewModel.DateofConstruction2 == "--Select Date--")
                {
                    viewModel.DateofConstruction2 = null;
                }
                if (viewModel.DateofConstruction3 == "--Select Date--")
                {
                    viewModel.DateofConstruction3 = null;
                }
                if (viewModel.DateofConstruction4 == "--Select Date--")
                {
                    viewModel.DateofConstruction4 = null;
                }
                if (viewModel.DateofConstruction5 == "--Select Date--")
                {
                    viewModel.DateofConstruction5 = null;
                }
                if (viewModel.SurveyorDate == "--Select Date--")
                {
                    viewModel.SurveyorDate = null;
                }
                if (viewModel.DataEntryDate == "--Select Date--")
                {
                    viewModel.DataEntryDate = null;
                }
          
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

                var isrecord = db.PropertyMasters.Where(x => x.PropertyNo == PropertyNo && x.IsDelete==false).FirstOrDefault();
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

                var isrecord = db.PropertyMasters.Where(x => x.NewPropertyNo == NewPropertyNo && x.IsDelete == false).FirstOrDefault();
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

                var EntryCount = db.PropertyMasters.Where(x=>x.IsDelete==false).Count();
                return EntryCount;
            }
        }


    }
}