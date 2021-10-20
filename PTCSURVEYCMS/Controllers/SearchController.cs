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

        [HttpGet]
        public ActionResult SurveyListSearch(string q = "-1" ,string n="-1", string x = "-1", string y = "-1", int clientId=0)
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
              
              


                if (x != "-1")
                {
                    q = x;
                    n = y;
                    viewModel = Repository.getPropertyDetailsByFamily(q, n, Appid);
                    return PartialView("_SearchFamily", viewModel);
                }
                if (q != "-1")
                {
                    viewModel = Repository.getPropertyDetailsByFamily(q, n, Appid);
                    return PartialView("_SearchFamily", viewModel);
                }
                using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

                    var EntryCount = db.PropertyMasters.Where(c => c.IsDelete == false).Count();
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

        [HttpPost]
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
                    if (Convert.ToInt32(length) >= 5)
                    {

                        string[] a = searchValue.Split(',');
                        if ((searchValue == null || searchValue == "") && (Convert.ToInt32(length) >= 5))
                        {
                            if (a.Length >= 5 && a[5].ToString() == "1")
                            {
                                searchValue = Session["Search"].ToString();
                            }
                            else
                            {
                                if ((searchValue == null || searchValue == "") && (Convert.ToInt32(length) >= 5 && draw != "1"))
                                { searchValue = Session["Search"].ToString(); }
                                else
                                {
                                    searchValue = "";
                                    Session["Search"] = null;
                                    Session["rn"] = null;
                                }
                            }
                        }
                    }


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


                        customerData = customerData.OrderByDescending(x => x.PropertyId).ToList();
                    }

                    //Search
                    var searchString = searchValue;
                    Session["Search"] = searchString;
                    string[] arr = searchString.Split(',');
                    if (arr[0] == "f")
                    {
                        if (arr[1] != "All")
                        {
                            customerData = customerData.Where(x => x.PrabhagNo == arr[1]).ToList();
                        }
                        if (arr[2] != "All")
                        {
                            customerData = customerData.Where(x => x.WardName_No == arr[2]).ToList();
                        }
                        if (arr[3] != "All")
                        {
                            customerData = customerData.Where(x => x.CompletionYear == arr[3]).ToList();
                        }

                        if (arr[4] != "All")
                        {
                            customerData = customerData.Where(x => x.ConstStartYear == arr[4]).ToList();
                        }
                        if (arr[5] != "")
                        {
                            if (arr[5] == "Safe")
                            {
                                customerData = customerData.Where(x => x.Safe == true).ToList();
                            }
                            if (arr[5] == "Safe2")
                            {
                                customerData = customerData.Where(x => x.Safe2 == true).ToList();
                            }
                            if (arr[5] == "Safe3")
                            {
                                customerData = customerData.Where(x => x.Safe3 == true).ToList();
                            }
                            if (arr[5] == "Danger")
                            {
                                customerData = customerData.Where(x => x.Danger == true).ToList();
                            }
                            if (arr[5] == "Danger2")
                            {
                                customerData = customerData.Where(x => x.Danger2 == true).ToList();
                            }
                            if (arr[5] == "Danger3")
                            {
                                customerData = customerData.Where(x => x.Danger3 == true).ToList();
                            }
                        }

                        if (arr[6] != "")
                        {
                            customerData = customerData.Where(x => x.PropertyNo == arr[6]).ToList();
                        }
                        if (arr[7] != "")
                        {
                            string fname, mname, lname;
                            string pname = arr[7];
                            string[] arr1 = pname.Split(' ');
                            if (arr1.Length > 0)
                            {
                                fname = arr1[0];

                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower()).ToList();

                            }
                            if (arr1.Length > 1)
                            {
                                fname = arr1[0];
                                mname = arr1[1];
                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName.ToLower()) == mname.ToLower()).ToList();

                                if (customerData.Count() == 0)
                                {
                                    customerData = (from tempcustomer in griddata select tempcustomer);

                                    //Sorting    
                                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                                    {


                                        customerData = customerData.OrderByDescending(x => x.PropertyId).ToList();
                                    }

                                    if (arr[6] != "")
                                    {
                                        customerData = customerData.Where(x => x.PropertyNo == arr[6]).ToList();
                                    }
                                    customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName.ToLower()) == mname.ToLower() && (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower()).ToList();
                                }

                            }
                            if (arr1.Length > 2)
                            {
                                lname = arr1[2];
                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName.ToLower()) == lname.ToLower()).ToList();
                            }
                        }

                        if (arr[8] != "")
                        {
                            customerData = customerData.Where(x => x.PropertyNo == arr[8]).ToList();
                        }
                        string name = arr[9];
                        if (name != "null")
                        {
                            string fname, mname, lname;
                            string pname = arr[9];
                            string[] arr1 = pname.Split(' ');
                            if (arr1.Length > 0)
                            {
                                fname = arr1[0];

                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower()).ToList();

                            }
                            if (arr1.Length > 1)
                            {
                                fname = arr1[0];
                                mname = arr1[1];
                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName.ToLower()) == mname.ToLower()).ToList();

                                if (customerData.Count() == 0)
                                {
                                    customerData = (from tempcustomer in griddata select tempcustomer);

                                    //Sorting    
                                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                                    {


                                        customerData = customerData.OrderByDescending(x => x.PropertyId).ToList();
                                    }

                                    if (arr[6] != "")
                                    {
                                        customerData = customerData.Where(x => x.PropertyNo == arr[6]).ToList();
                                    }
                                    customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName.ToLower()) == mname.ToLower() && (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower()).ToList();
                                }

                            }
                            if (arr1.Length > 2)
                            {
                                lname = arr1[2];
                                customerData = customerData.Where(x => (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName.ToLower()) == lname.ToLower()).ToList();
                            }
                            ViewBag.Name1 = customerData.Select(x => x.Name1).FirstOrDefault();
                            TempData.Keep("Name1");
                            TempData["Name2"] = customerData.Select(x => x.Name2).FirstOrDefault();
                            TempData.Keep("Name2");
                            TempData["Name3"] = customerData.Select(x => x.Name3).FirstOrDefault();
                            TempData.Keep("Name3");
                            TempData["Name4"] = customerData.Select(x => x.Name4).FirstOrDefault();
                            TempData.Keep("Name4");
                            TempData["Name5"] = customerData.Select(x => x.Name5).FirstOrDefault();
                            TempData.Keep("Name5");
                            TempData["Name6"] = customerData.Select(x => x.Name6).FirstOrDefault();
                            TempData.Keep("Name6");
                            TempData["Name7"] = customerData.Select(x => x.Name7).FirstOrDefault();
                            TempData.Keep("Name7");
                            TempData["Name8"] = customerData.Select(x => x.Name8).FirstOrDefault();
                            TempData.Keep("Name8");
                            TempData["Name9"] = customerData.Select(x => x.Name9).FirstOrDefault();
                            TempData.Keep("Name9");
                            TempData["Name10"] = customerData.Select(x => x.Name10).FirstOrDefault();
                            TempData.Keep("Name10");
                            TempData["Name11"] = customerData.Select(x => x.Name11).FirstOrDefault();
                            TempData.Keep("Name11");
                            TempData["Name12"] = customerData.Select(x => x.Name12).FirstOrDefault();
                            TempData.Keep("Name12");

                            TempData["Age1"] = customerData.Select(x => x.Age1).FirstOrDefault();
                            TempData.Keep("Age1");
                            TempData["Age2"] = customerData.Select(x => x.Age2).FirstOrDefault();
                            TempData.Keep("Age2");
                            TempData["Age3"] = customerData.Select(x => x.Age3).FirstOrDefault();
                            TempData.Keep("Age3");
                            TempData["Age4"] = customerData.Select(x => x.Age4).FirstOrDefault();
                            TempData.Keep("Age4");
                            TempData["Age5"] = customerData.Select(x => x.Age5).FirstOrDefault();
                            TempData.Keep("Age5");
                            TempData["Age6"] = customerData.Select(x => x.Age6).FirstOrDefault();
                            TempData.Keep("Age6");
                            TempData["Age7"] = customerData.Select(x => x.Age7).FirstOrDefault();
                            TempData.Keep("Age7");
                            TempData["Age8"] = customerData.Select(x => x.Age8).FirstOrDefault();
                            TempData.Keep("Age8");
                            TempData["Age9"] = customerData.Select(x => x.Age9).FirstOrDefault();
                            TempData.Keep("Age9");
                            TempData["Age10"] = customerData.Select(x => x.Age10).FirstOrDefault();
                            TempData.Keep("Age10");
                            TempData["Age11"] = customerData.Select(x => x.Age11).FirstOrDefault();
                            TempData.Keep("Age11");
                            TempData["Age12"] = customerData.Select(x => x.Age12).FirstOrDefault();
                            TempData.Keep("Age12");

                            TempData["link1"] = customerData.Select(x => x.link1).FirstOrDefault();
                            TempData.Keep("link1");
                            TempData["link2"] = customerData.Select(x => x.link2).FirstOrDefault();
                            TempData.Keep("link2");
                            TempData["link3"] = customerData.Select(x => x.link3).FirstOrDefault();
                            TempData.Keep("link3");
                            TempData["link4"] = customerData.Select(x => x.link4).FirstOrDefault();
                            TempData.Keep("link4");
                            TempData["link5"] = customerData.Select(x => x.link5).FirstOrDefault();
                            TempData.Keep("link5");
                            TempData["link6"] = customerData.Select(x => x.link6).FirstOrDefault();
                            TempData.Keep("link6");
                            TempData["link7"] = customerData.Select(x => x.link7).FirstOrDefault();
                            TempData.Keep("link7");
                            TempData["link8"] = customerData.Select(x => x.link8).FirstOrDefault();
                            TempData.Keep("link8");
                            TempData["link9"] = customerData.Select(x => x.link9).FirstOrDefault();
                            TempData.Keep("link9");
                            TempData["link10"] = customerData.Select(x => x.link10).FirstOrDefault();
                            TempData.Keep("link10");
                            TempData["link11"] = customerData.Select(x => x.link11).FirstOrDefault();
                            TempData.Keep("link11");
                            TempData["link12"] = customerData.Select(x => x.link12).FirstOrDefault();
                            TempData.Keep("link12");

                            TempData["ContactNo1"] = customerData.Select(x => x.ContactNo1).FirstOrDefault();
                            TempData.Keep("ContactNo1");
                            TempData["ContactNo2"] = customerData.Select(x => x.ContactNo2).FirstOrDefault();
                            TempData.Keep("ContactNo2");
                            TempData["ContactNo3"] = customerData.Select(x => x.ContactNo3).FirstOrDefault();
                            TempData.Keep("ContactNo3");
                            TempData["ContactNo4"] = customerData.Select(x => x.ContactNo4).FirstOrDefault();
                            TempData.Keep("ContactNo4");
                            TempData["ContactNo5"] = customerData.Select(x => x.ContactNo5).FirstOrDefault();
                            TempData.Keep("ContactNo5");
                            TempData["ContactNo6"] = customerData.Select(x => x.ContactNo6).FirstOrDefault();
                            TempData.Keep("ContactNo6");
                            TempData["ContactNo7"] = customerData.Select(x => x.ContactNo7).FirstOrDefault();
                            TempData.Keep("ContactNo7");
                            TempData["Name8"] = customerData.Select(x => x.ContactNo8).FirstOrDefault();
                            TempData.Keep("Name8");
                            TempData["ContactNo9"] = customerData.Select(x => x.ContactNo9).FirstOrDefault();
                            TempData.Keep("ContactNo9");
                            TempData["ContactNo10"] = customerData.Select(x => x.ContactNo10).FirstOrDefault();
                            TempData.Keep("ContactNo10");
                            TempData["ContactNo11"] = customerData.Select(x => x.ContactNo11).FirstOrDefault();
                            TempData.Keep("ContactNo11");
                            TempData["ContactNo12"] = customerData.Select(x => x.ContactNo12).FirstOrDefault();
                            TempData.Keep("ContactNo12");

                            TempData["VoterIdentityNo1"] = customerData.Select(x => x.VoterIdentityNo1).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo1");
                            TempData["VoterIdentityNo2"] = customerData.Select(x => x.VoterIdentityNo2).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo2");
                            TempData["VoterIdentityNo3"] = customerData.Select(x => x.VoterIdentityNo3).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo3");
                            TempData["VoterIdentityNo4"] = customerData.Select(x => x.VoterIdentityNo4).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo4");
                            TempData["VoterIdentityNo5"] = customerData.Select(x => x.VoterIdentityNo5).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo5");
                            TempData["VoterIdentityNo6"] = customerData.Select(x => x.VoterIdentityNo6).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo6");
                            TempData["Name7"] = customerData.Select(x => x.VoterIdentityNo7).FirstOrDefault();
                            TempData.Keep("Name7");
                            TempData["VoterIdentityNo8"] = customerData.Select(x => x.VoterIdentityNo8).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo8");
                            TempData["VoterIdentityNo9"] = customerData.Select(x => x.VoterIdentityNo9).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo9");
                            TempData["VoterIdentityNo10"] = customerData.Select(x => x.VoterIdentityNo10).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo10");
                            TempData["VoterIdentityNo11"] = customerData.Select(x => x.VoterIdentityNo11).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo11");
                            TempData["VoterIdentityNo12"] = customerData.Select(x => x.VoterIdentityNo12).FirstOrDefault();
                            TempData.Keep("VoterIdentityNo12");

                        }

                        if (arr[10] != "")
                        {
                            if (arr[10] == "Y")
                            {
                                customerData = customerData.Where(x => x.YConstPermNo == true).ToList();
                            }
                            if (arr[10] == "N")
                            {
                                customerData = customerData.Where(x => x.NConstPermNo == true).ToList();
                            }
                            if (arr[10] == "NA")
                            {
                                customerData = customerData.Where(x => x.YConstPermNo == false && x.NConstPermNo == false).ToList();
                            }
                        }

                        if (arr[11] != "")
                        {
                            if (arr[11] == "Y")
                            {
                                customerData = customerData.Where(x => x.YPermUseNo == true).ToList();
                            }
                            if (arr[11] == "N")
                            {
                                customerData = customerData.Where(x => x.NPermUseNo == true).ToList();
                            }
                            if (arr[11] == "NA")
                            {
                                customerData = customerData.Where(x => x.YPermUseNo == false && x.NPermUseNo == false).ToList();
                            }
                        }



                    }
                    else if (!string.IsNullOrEmpty(searchValue))
                    {
                        var model = customerData.Where(c => ((string.IsNullOrEmpty(c.PropOwnerFirstName) ? " " : c.PropOwnerFirstName) + " " +
                                      (string.IsNullOrEmpty(c.PropOwnerMiddleName) ? " " : c.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(c.PropOwnerLastName) ? " " : c.PropOwnerLastName) + " " +
                                       (string.IsNullOrEmpty(c.PropOwnerTelephoneNo) ? " " : c.PropOwnerTelephoneNo) + " " +
                                      (string.IsNullOrEmpty(c.NewPropertyNo) ? " " : c.NewPropertyNo) + " " +
                                      (string.IsNullOrEmpty(c.PropertyNo) ? " " : c.PropertyNo) + " " +
                                      (string.IsNullOrEmpty(c.OldHouseNo1) ? " " : c.OldHouseNo1) + "" +
                                      (string.IsNullOrEmpty(c.PrabhagNo) ? " " : c.PrabhagNo) + "" +
                                      (string.IsNullOrEmpty(c.WardName_No) ? " " : c.WardName_No) + "" +
                                      (string.IsNullOrEmpty(c.ConstStartYear) ? " " : c.ConstStartYear) + "" +
                                      (string.IsNullOrEmpty(c.CompletionYear) ? " " : c.CompletionYear)

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

        public ActionResult SurveyChildTable(int q = -1, int clientId = 0)
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