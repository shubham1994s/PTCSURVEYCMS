using BLL.ViewModel;
using DAL.ChildDatabase;
using Ionic.Zip;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace PTCSURVEYCMS.Controllers
{
    public class ReportController : Controller
    {
        //   GET: Report

        public ActionResult Report()
        {
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(1))
            {
                var v = db.PropertyMasters.ToList();
                return View(v);
            }
        }

        public FileResult GenerateReport(string typeOfReport)
        {
            byte[] bytearray = null;
            string mimeType = "";
            byte[] renderedBytes = { 0 };
            List<byte[]> lstBytes = new List<byte[]>();
            List<string> lstFileNames = new List<string>();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("mr-IN");
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "Report1.rdlc");
            if (System.IO.File.Exists(path))
            {
                int AppId = SessionHandler.Current.AppId;
                var VM = new List<PropertyMasterVM>();
                List<PropertyMaster> cm = new List<PropertyMaster>();
                using (DEVPTCSURVEYMALEGAONEntities dc = new DEVPTCSURVEYMALEGAONEntities(AppId))
                {
                    cm = dc.PropertyMasters.ToList();

                }
                string deviceInfo;
                foreach (var vm in cm)
                {
                    DEVPTCSURVEYMALEGAONEntities dc = new DEVPTCSURVEYMALEGAONEntities(AppId);
                    cm = dc.PropertyMasters.Where(x => x.PropertyId == vm.PropertyId).ToList();
                    lr.ReportPath = path;
                    ReportDataSource rd = new ReportDataSource("DataSet1", cm);
                    lr.DataSources.Add(rd);
                    string reportType = typeOfReport;

                    string encoding;
                    string fileNameExtension;
                    deviceInfo =

                        "<DeviceInfo>" +

                        "<OutputFormat>" + typeOfReport + "</OutputFormat>" +

                        "</DeviceInfo>";


                    Microsoft.Reporting.WebForms.Warning[] warning;
                    string[] streams;


                    renderedBytes = lr.Render(
                        reportType,
                        deviceInfo,
                        out mimeType,
                        out encoding,
                        out fileNameExtension,
                        out streams,
                        out warning);
                    lstBytes.Add(renderedBytes);
                    lstFileNames.Add(vm.ToString());
                    lr.DataSources.Remove(rd);

                    Response.ContentType = mimeType;

                    Response.Buffer = true;
                    //   Response.WriteBinary(renderedBytes);


                }
                TempData["Data"] = lstBytes;
                TempData["File"] = lstFileNames;
                if (TempData["Data"] != null)
                {
                    List<byte[]> lstBytesArray = TempData["Data"] as List<byte[]>;
                    List<string> lstNamesArray = TempData["File"] as List<string>;

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                        int i = 1;
                        foreach (byte[] bytes in lstBytesArray)
                        {
                            zip.AddEntry("PropertyMaster" + i + ".pdf", bytes);
                            i++;
                        }
                        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MM-dd-HHmmss"));
                        using (MemoryStream stream = new MemoryStream())
                        {
                            zip.Save(stream);
                            return File(stream.ToArray(), "application/zip", zipName);
                        }
                    }
                }
                else
                {
                    // return new EmptyResult();
                }
            }
            return File(bytearray, "application/zip");
        }

        public ActionResult SurveyForm()
        {
            if (SessionHandler.Current.AppId != 0)
            {
                ViewBag.Appname_mar = SessionHandler.Current.AppName_mar;
            }
            return View();
        }
    }
}


