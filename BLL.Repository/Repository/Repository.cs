using BLL.ViewModel;
using DAL;
using DAL.ChildDatabase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BLL.Repository.Repository
{
    public class Repository : IRepository
    {

        public EmployeeVM Login(EmployeeVM _userinfo)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            using (DEVPTCSURVEYMAINEntities db = new DEVPTCSURVEYMAINEntities())
            {
                var appUser = (db.AD_USER_MST.Where(x => x.ADUM_LOGIN_ID == _userinfo.ADUM_LOGIN_ID && x.ADUM_PASSWORD == _userinfo.ADUM_PASSWORD).SingleOrDefault());
                if (appUser != null)
                {
                    _EmployeeVM.ADUM_LOGIN_ID = appUser.ADUM_LOGIN_ID;
                    _EmployeeVM.APP_ID = appUser.APP_ID;
                    _EmployeeVM.ADUM_USER_NAME = appUser.ADUM_USER_NAME;
                    _EmployeeVM.ADUM_USER_CODE = Convert.ToInt32(appUser.ADUM_USER_CODE);
                    _EmployeeVM.status = "Success";

                    return _EmployeeVM;
                }
                else
                {
                    _EmployeeVM.status = "Failure";
                    return _EmployeeVM;
                }
            }
        }

        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            using (DEVPTCSURVEYMAINEntities db = new DEVPTCSURVEYMAINEntities())
            {
                AppDetailsVM model = new AppDetailsVM();
                var appDetails = (db.AppDetails.Where(x => x.AppId == AppId).FirstOrDefault());
                if (appDetails != null)
                {
                    model.AppId = appDetails.AppId;
                    model.AppName = appDetails.AppName;
                    model.AppName_mar = appDetails.AppName_mar;
                    model.State = appDetails.State;
                    model.Tehsil = appDetails.Tehsil;
                    model.District = appDetails.District;
                    model.EmailId = appDetails.EmailId;
                    model.website = appDetails.website;
                    model.Android_GCM_pushNotification_Key = appDetails.Android_GCM_pushNotification_Key;
                    model.AppVersion = appDetails.AppVersion;
                    model.ForceUpdate = appDetails.ForceUpdate;
                    model.IsActive = appDetails.IsActive;
                    model.CreatedDate = DateTime.Now;
                    return model;
                }
                else
                {
                    return null;
                }
            }
        }

        public Result PropertySave(PropertyMasterVM _Property, int AppId)
        {
            Result Result = new Result();
            CultureInfo provider = CultureInfo.InvariantCulture;
            PropertyMaster Master = new PropertyMaster();
            try
            {
                using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
                {
                    var obj = db.PropertyMasters.Where(x => x.PropertyId == _Property.PropertyId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.PrabhagNo = _Property.PrabhagNo;
                        obj.WardNameNo = _Property.WardName_No;
                        obj.ElectionWard = _Property.ElectionWard;
                        obj.NewPropertyNo = _Property.NewPropertyNo;
                        obj.PropertyNo = _Property.PropertyNo;
                        obj.HouseNo = _Property.OldHouseNo1;
                        obj.oldHouseNo2 = _Property.OldHouseNo2;
                        obj.NoOfTrees = _Property.NoOfTrees;
                        obj.Personalwell = _Property.Personalwell;
                        obj.HeritageTree = _Property.HeritageTree;

                        obj.WaterConnection = _Property.WaterConnection;
                        obj.NoWaterConnection = _Property.NoWaterConnection;
                        obj.STP = _Property.STP;
                        obj.FST = _Property.FST;
                        obj.STS = _Property.STS;
                        obj.Other = _Property.Other;
                        obj.SGSK = _Property.SGSK;

                        obj.NOSGSK = _Property.NOSGSK;
                        obj.OtherGutter = _Property.OtherGutter;
                        obj.NaturalMethod = _Property.NaturalMethod;
                        obj.ArtifitialMethod = _Property.ArtifitialMethod;
                        obj.OtherMethod = _Property.OtherMethod;
                        obj.NoProject = _Property.NoProject;
                        obj.Safe = _Property.Safe;
                        obj.Danger = _Property.Danger;
                        obj.Safe2 = _Property.Safe2;
                        obj.Danger2 = _Property.Danger2;
                        obj.Safe3 = _Property.Safe3;

                        obj.NOSGSK = _Property.NOSGSK;
                        obj.OtherGutter = _Property.OtherGutter;
                        obj.NaturalMethod = _Property.NaturalMethod;
                        obj.ArtifitialMethod = _Property.ArtifitialMethod;
                        obj.OtherMethod = _Property.OtherMethod;
                        obj.NoProject = _Property.NoProject;
                        obj.Safe = _Property.Safe;
                        obj.Danger = _Property.Danger;
                        obj.Safe2 = _Property.Safe2;
                        obj.Danger2 = _Property.Danger2;
                        obj.Safe3 = _Property.Safe3;
                        obj.Danger3 = _Property.Danger3;

                        obj.TotalPropertyExpense = _Property.TotalPropertyExpense;
                        obj.CurrentPropertyTax = _Property.CurrentPropertyTax;
                        obj.CurrentProperyPrice = _Property.CurrentProperyPrice;
                        obj.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                        obj.ProperyTaxPrice = _Property.ProperyTaxPrice;
                        obj.TotalTaxPrice = _Property.TotalTaxPrice;
                        obj.OpenLandtaxprice = _Property.OpenLandtaxprice;
                        obj.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                        obj.Name1 = _Property.Name1;
                        obj.Name2 = _Property.Name2;
                        obj.Name3 = _Property.Name3;
                        obj.Name4 = _Property.Name4;

                        obj.Name5 = _Property.Name5;
                        obj.Name6 = _Property.Name6;
                        obj.Name7 = _Property.Name7;
                        obj.Name8 = _Property.Name8;

                        obj.Name9 = _Property.Name9;
                        obj.Name10 = _Property.Name10;
                        obj.Name11 = _Property.Name11;
                        obj.Name12 = _Property.Name12;

                        obj.Age1 = _Property.Age1;
                        obj.Age2 = _Property.Age2;
                        obj.Age3 = _Property.Age3;
                        obj.Age4 = _Property.Age4;

                        obj.Age5 = _Property.Age5;
                        obj.Age6 = _Property.Age6;
                        obj.Age7 = _Property.Age7;
                        obj.Age8 = _Property.Age8;

                        obj.Age9 = _Property.Age9;
                        obj.Age10 = _Property.Age10;
                        obj.Age11 = _Property.Age11;
                        obj.Age12 = _Property.Age12;

                        obj.link1 = _Property.link1;
                        obj.link2 = _Property.link2;
                        obj.link3 = _Property.link3;
                        obj.link4 = _Property.link4;
                        obj.link5 = _Property.link5;
                        obj.link6 = _Property.link6;
                        obj.link7 = _Property.link7;
                        obj.link8 = _Property.link8;
                        obj.link9 = _Property.link9;
                        obj.link10 = _Property.link10;
                        obj.link11 = _Property.link11;
                        obj.link12 = _Property.link12;

                        obj.ContactNo1 = _Property.ContactNo1;
                        obj.ContactNo2 = _Property.ContactNo2;
                        obj.ContactNo3 = _Property.ContactNo3;
                        obj.ContactNo4 = _Property.ContactNo4;
                        obj.ContactNo5 = _Property.ContactNo5;
                        obj.ContactNo6 = _Property.ContactNo6;
                        obj.ContactNo7 = _Property.ContactNo7;
                        obj.ContactNo8 = _Property.ContactNo8;
                        obj.ContactNo9 = _Property.ContactNo9;
                        obj.ContactNo10 = _Property.ContactNo10;
                        obj.ContactNo11 = _Property.ContactNo11;
                        obj.ContactNo12 = _Property.ContactNo12;

                        obj.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                        obj.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                        obj.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                        obj.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                        obj.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                        obj.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                        obj.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                        obj.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                        obj.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                        obj.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                        obj.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                        obj.VoterIdentityNo12 = _Property.VoterIdentityNo12;

                        obj.SurveyNo = _Property.SurveyNo;
                        obj.GatNo = _Property.GatNo;
                        obj.CitySurveyNo = _Property.CitySurveyNo;
                        obj.AnnualRateableValue = _Property.AnnualRateableValue;
                        obj.TotalPlotArea = _Property.TotalPlotArea;
                        obj.TotalBuildupArea = _Property.TotalBuildupArea;
                        obj.MarginSpace = _Property.MarginSpace;
                        obj.BuildingName = _Property.BuildingName;
                        obj.PlotNo = _Property.PlotNo;
                        obj.FlatNo = _Property.FlatNo;
                        obj.NoofFloors = _Property.NoofFloors;
                        obj.NoofFlats = _Property.NoofFlats;
                        obj.NoofShops = _Property.NoofShops;
                        obj.PropOwnerFirstName = _Property.PropOwnerFirstName;
                        obj.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                        obj.PropOwnerLastName = _Property.PropOwnerLastName;
                        obj.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                        obj.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                        obj.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                        obj.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                        obj.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                        obj.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                        obj.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                        obj.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                        obj.PropOwnerLastName4 = _Property.PropOwnerLastName4;

                        obj.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                        obj.PropOwnerMobileNo = _Property.PropOwnerElectionCardNo;
                        obj.PropOwnerEmailId = _Property.PropOwnerEmailId;
                        obj.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                        obj.OccupierFirstName = _Property.OccupierFirstName;
                        obj.OccupierMiddleName = _Property.OccupierMiddleName;
                        obj.OccupierLastName = _Property.OccupierLastName;
                        obj.OccupierMobileNo = _Property.OccupierMobileNo;
                        obj.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                        obj.TenantName = _Property.TenantName;
                        obj.Rent = _Property.Rent;
                        obj.TenantMobileNo = _Property.TenantMobileNo;
                        obj.TenantAdhaarNo = _Property.TenantAdhaarNo;
                        obj.Address = _Property.Address;
                        obj.Longitude = _Property.Longitude;
                        obj.Latitude = _Property.Latitude;
                        obj.ConstStartYear = _Property.ConstStartYear;
                        obj.CompletionYear = _Property.CompletionYear;
                        obj.Age = _Property.Age;
                        obj.Usage = _Property.Usage;
                        obj.TypeofBldg = _Property.TypeofBldg;
                        obj.ConstPermNo = _Property.ConstPermNo;
                        obj.PermUseNo = _Property.PermUseNo;
                        obj.Rainwaterharvest = _Property.Rainwaterharvest;
                        obj.SolarWaterheater = _Property.SolarWaterheater;
                        obj.VermicultureProject = _Property.VermicultureProject;
                        obj.SWHRemark = _Property.SWHRemark;
                        obj.WaterConnectionResidential = _Property.WaterConnectionResidential;
                        obj.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                        obj.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        obj.Borewell = _Property.Borewell;
                        obj.NonBorewellr = _Property.NonBorewellr;
                        obj.NoofToilets = _Property.NoofToilets;
                        obj.LocationofToiletResidential = _Property.LocationofToiletResidential;
                        obj.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                        obj.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                        obj.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                        obj.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                        obj.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                        obj.UnderGroundGutter = _Property.UnderGroundGutter;
                        obj.OpenGutter = _Property.OpenGutter;
                        obj.DoorLockIndustrial = _Property.DoorLockIndustrial;
                        obj.DoorLockResidential = _Property.DoorLockResidential;
                        obj.DoorLockSpecial = _Property.DoorLockSpecial;
                        obj.PermanentDoorLock = _Property.PermanentDoorLock;
                        obj.OuterMeasurement = _Property.OuterMeasurement;
                        obj.Lift = _Property.Lift;
                        obj.Remarks = _Property.Remarks;
                        obj.FloorNo1 = _Property.FloorNo1;
                        obj.OccupancyStatus1 = _Property.OccupancyStatus1;
                        obj.ConstType1 = _Property.ConstType1;
                        //if(_Property.DateofConstruction1=="--Select Date--")
                        //{
                        //    obj.DateofConstruction1 = null;
                        //}
                        //else
                        //{
                        //    obj.DateofConstruction1 = DateTime.ParseExact(_Property.DateofConstruction1, "dd-MM-yyyy", provider);
                        //}

                        //if (_Property.DateofConstruction2 == "--Select Date--")
                        //{
                        //    obj.DateofConstruction2 = null;
                        //}
                        //else
                        //{
                        //    obj.DateofConstruction2 = DateTime.ParseExact(_Property.DateofConstruction2, "dd-MM-yyyy", provider);
                        //}
                        //if (_Property.DateofConstruction3 == "--Select Date--")
                        //{
                        //    obj.DateofConstruction3 = null;
                        //}
                        //else
                        //{
                        //    obj.DateofConstruction3 = DateTime.ParseExact(_Property.DateofConstruction3, "dd-MM-yyyy", provider);
                        //}
                        //if (_Property.DateofConstruction4 == "--Select Date--")
                        //{
                        //    obj.DateofConstruction4 = null;
                        //}
                        //else
                        //{
                        //    obj.DateofConstruction4 = DateTime.ParseExact(_Property.DateofConstruction4, "dd-MM-yyyy", provider);
                        //}
                        //if (_Property.DateofConstruction5 == "--Select Date--")
                        //{
                        //    obj.DateofConstruction5 = null;
                        //}
                        //else
                        //{
                        //    obj.DateofConstruction5 = DateTime.ParseExact(_Property.DateofConstruction5, "dd-MM-yyyy", provider);
                        //}
                        obj.DateofConstruction1 = _Property.DateofConstruction1;
                        obj.DateofConstruction2 = _Property.DateofConstruction2;
                        obj.DateofConstruction3 = _Property.DateofConstruction3;
                        obj.DateofConstruction4 = _Property.DateofConstruction4;
                        obj.DateofConstruction5 = _Property.DateofConstruction5;
                        obj.UsageType1 = _Property.UsageType1;
                        obj.UsageTypeClass1 = _Property.UsageTypeClass1;
                        obj.Legal1 = _Property.Legal1;
                        obj.CarpetArea1 = _Property.CarpetArea1;
                        obj.BuildupArea1 = _Property.BuildupArea1;
                        obj.FloorNo2 = _Property.FloorNo2;
                        obj.OccupancyStatus2 = _Property.OccupancyStatus2;
                        obj.ConstType2 = _Property.ConstType2;

                        obj.UsageType2 = _Property.UsageType2;
                        obj.UsageTypeClass2 = _Property.UsageTypeClass2;
                        obj.Legal2 = _Property.Legal2;
                        obj.CarpetArea2 = _Property.CarpetArea2;
                        obj.BuildupArea2 = _Property.BuildupArea2;
                        obj.FloorNo3 = _Property.FloorNo3;
                        obj.OccupancyStatus3 = _Property.OccupancyStatus3;
                        obj.ConstType3 = _Property.ConstType3;

                        obj.UsageType3 = _Property.UsageType3;
                        obj.UsageTypeClass3 = _Property.UsageTypeClass3;
                        obj.Legal3 = _Property.Legal3;
                        obj.CarpetArea3 = _Property.CarpetArea3;
                        obj.BuildupArea3 = _Property.BuildupArea3;
                        obj.FloorNo4 = _Property.FloorNo4;
                        obj.OccupancyStatus4 = _Property.OccupancyStatus4;
                        obj.ConstType4 = _Property.ConstType4;

                        obj.UsageType4 = _Property.UsageType4;
                        obj.UsageTypeClass4 = _Property.UsageTypeClass4;
                        obj.Legal4 = _Property.Legal4;
                        obj.CarpetArea4 = _Property.CarpetArea4;
                        obj.BuildupArea4 = _Property.BuildupArea4;
                        obj.FloorNo5 = _Property.FloorNo5;
                        obj.OccupancyStatus5 = _Property.OccupancyStatus5;
                        obj.ConstType5 = _Property.ConstType5;

                        obj.UsageType5 = _Property.UsageType5;
                        obj.UsageTypeClass5 = _Property.UsageTypeClass5;
                        obj.Legal5 = _Property.Legal5;
                        obj.CarpetArea5 = _Property.CarpetArea5;
                        obj.BuildupArea5 = _Property.BuildupArea5;
                        obj.totalBuildupArea1 = _Property.totalBuildupArea1;
                        obj.totalCarpetArea = _Property.totalCarpetArea;
                        obj.totaltax = _Property.totaltax;
                        obj.OldUsageType = _Property.OldUsageType;
                        obj.OldConstructionType = _Property.OldConstructionType;
                        obj.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                        obj.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                        obj.NonRainwaterharvest = _Property.NonRainwaterharvest;
                        obj.NewUsageType = _Property.NewUsageType;
                        obj.NewConstructionType = _Property.NewConstructionType;
                        obj.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                        obj.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                        obj.ExtendUsageType = _Property.ExtendUsage_Type;
                        obj.ExtendConstructionType = _Property.ExtendConstructionType;
                        obj.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                        obj.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                        obj.PropertyType = _Property.PropertyType;
                        obj.SurveyorName = _Property.SurveyorName;
                        if (_Property.SurveyorSignature != null)
                        {
                            obj.SurveyorSignature = _Property.SurveyorSignature;
                        }
                        if (_Property.SurveyorDate == "--Select Date--")
                        {
                            obj.SurveyorDate = null;
                        }
                        else
                        {
                            obj.SurveyorDate = DateTime.ParseExact(_Property.SurveyorDate, "dd-MM-yyyy", provider);
                        }
                        if (_Property.DataEntryDate == "--Select Date--")
                        {
                            obj.DataEntryDate = null;
                        }
                        else
                        {
                            obj.DataEntryDate = DateTime.ParseExact(_Property.DataEntryDate, "dd-MM-yyyy", provider);
                        }

                        obj.DataEntryName = _Property.DataEntryName;
                        if (_Property.DataEntrySignature != null)
                        {
                            obj.DataEntrySignature = _Property.DataEntrySignature;
                        }
                        if (_Property.Sketchdiagram != null)
                        {
                            obj.Sketchdiagram = _Property.Sketchdiagram;
                        }
                        if (_Property.Sketchdiagram2 != null)
                        {
                            obj.Sketchdiagram2 = _Property.Sketchdiagram2;
                        }


                        obj.NonSolarWaterheater = _Property.NonSolarWaterheater;
                        obj.NonVermicultureProject = _Property.NonVermicultureProject;
                        obj.NoLift = _Property.NoLift;
                        obj.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        obj.AppId = AppId;
                        obj.ZoneNo = _Property.ZoneNo;
                        obj.VillageName = _Property.VillageName;
                        obj.HFSNo = _Property.HFSNo;
                        obj.Legal = _Property.Legal;
                        obj.HissaNo = _Property.HissaNo;
                        obj.OldRateableValue = _Property.OldRateableValue;
                        obj.OldTotalTax = _Property.OldTotalTax;
                        obj.FirstAssessmentYear = _Property.FirstAssessmentYear;
                        obj.ImageNo = _Property.ImageNo;
                        obj.WardNameNo2 = _Property.WardName_No2;
                        obj.ZoneNo2 = _Property.ZoneNo2;
                        obj.FHNo = _Property.FHNo;
                        obj.PropertyType2 = _Property.PropertyType2;
                        obj.NewPropertyNo2 = _Property.NewPropertyNo2;
                        obj.PropertyNo2 = _Property.PropertyNo2;
                        obj.GarbageType = _Property.GarbageType;
                        obj.NOGarbageType = _Property.NOGarbageType;
                        obj.PrabhagNo2 = _Property.PrabhagNo2;
                        obj.YConstPermNo = _Property.YConstPermNo;
                        obj.NConstPermNo = _Property.NConstPermNo;
                        obj.YPermUseNo = _Property.YPermUseNo;
                        obj.NPermUseNo = _Property.NPermUseNo;


                        obj.ZKMKG = _Property.ZKMKG;
                        obj.DVMKG = _Property.DVMKG;
                        obj.ThirdPT = _Property.ThirdPT;
                        obj.FourthPT = _Property.FourthPT;
                        obj.FifthPT = _Property.FifthPT;
                        obj.SixPT = _Property.SixPT;
                        obj.SevenPT = _Property.SevenPT;
                        obj.EightPT = _Property.EightPT;
                        obj.NinePT = _Property.NinePT;
                        obj.TenPT = _Property.TenPT;
                        obj.ElevenPT = _Property.ElevenPT;
                        obj.TwelvePT = _Property.TwelvePT;
                        obj.TherteenPT = _Property.TherteenPT;
                        obj.FourteenPT = _Property.FourteenPT;
                        obj.FifteenPT = _Property.FifteenPT;
                        obj.SixteenPT = _Property.SixteenPT;
                        obj.seventeenPT = _Property.seventeenPT;
                        obj.FirstRPC = _Property.FirstRPC;
                        obj.SecondRPC = _Property.SecondRPC;
                        obj.ThirdRPC = _Property.ThirdRPC;
                        obj.FourthRPC = _Property.FourthRPC;
                        obj.FifthRPC = _Property.FifthRPC;
                        obj.SixRPC = _Property.SixRPC;
                        obj.SevenRPC = _Property.SevenRPC;
                        obj.EightRPC = _Property.EightRPC;
                        obj.NineRPC = _Property.NineRPC;
                        obj.TenRPC = _Property.TenRPC;
                        obj.ElevenRPC = _Property.ElevenRPC;
                        obj.TwelveRPC = _Property.TwelveRPC;
                        obj.ThirteenRPC = _Property.ThirteenRPC;
                        obj.FirstCPC = _Property.FirstCPC;
                        obj.SecondCPC = _Property.SecondCPC;
                        obj.ThirdCPC = _Property.ThirdCPC;
                        obj.FourthCPC = _Property.FourthCPC;
                        obj.FifthCPC = _Property.FifthCPC;
                        obj.SixCPC = _Property.SixCPC;
                        obj.SevenCPC = _Property.SevenCPC;
                        obj.EightCPC = _Property.EightCPC;

                        obj.NineCPC = _Property.NineCPC;
                        obj.TenCPC = _Property.TenCPC;
                        obj.ElevenCPC = _Property.ElevenCPC;
                        obj.TwelveCPC = _Property.TwelveCPC;
                        obj.ThirteenCPC = _Property.ThirteenCPC;
                        obj.FourteenCPC = _Property.FourteenCPC;
                        obj.IsDelete = false;
                        db.SaveChanges();
                        Result.message = "Save Changes Successfully!";
                    }
                    else
                    {
                        Master.PrabhagNo = _Property.PrabhagNo;
                        Master.WardNameNo = _Property.WardName_No;
                        Master.ElectionWard = _Property.ElectionWard;
                        Master.NewPropertyNo = _Property.NewPropertyNo;
                        Master.PropertyNo = _Property.PropertyNo;
                        Master.HouseNo = _Property.OldHouseNo1;
                        Master.oldHouseNo2 = _Property.OldHouseNo2;
                        Master.NoOfTrees = _Property.NoOfTrees;
                        Master.Personalwell = _Property.Personalwell;
                        Master.HeritageTree = _Property.HeritageTree;

                        Master.WaterConnection = _Property.WaterConnection;
                        Master.NoWaterConnection = _Property.NoWaterConnection;
                        Master.STP = _Property.STP;
                        Master.FST = _Property.FST;
                        Master.STS = _Property.STS;
                        Master.Other = _Property.Other;
                        Master.SGSK = _Property.SGSK;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;
                        Master.Danger3 = _Property.Danger3;

                        Master.TotalPropertyExpense = _Property.TotalPropertyExpense;
                        Master.CurrentPropertyTax = _Property.CurrentPropertyTax;
                        Master.CurrentProperyPrice = _Property.CurrentProperyPrice;
                        Master.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                        Master.ProperyTaxPrice = _Property.ProperyTaxPrice;
                        Master.TotalTaxPrice = _Property.TotalTaxPrice;
                        Master.OpenLandtaxprice = _Property.OpenLandtaxprice;
                        Master.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                        Master.Name1 = _Property.Name1;
                        Master.Name2 = _Property.Name2;
                        Master.Name3 = _Property.Name3;
                        Master.Name4 = _Property.Name4;

                        Master.Name5 = _Property.Name5;
                        Master.Name6 = _Property.Name6;
                        Master.Name7 = _Property.Name7;
                        Master.Name8 = _Property.Name8;

                        Master.Name9 = _Property.Name9;
                        Master.Name10 = _Property.Name10;
                        Master.Name11 = _Property.Name11;
                        Master.Name12 = _Property.Name12;

                        Master.Age1 = _Property.Age1;
                        Master.Age2 = _Property.Age2;
                        Master.Age3 = _Property.Age3;
                        Master.Age4 = _Property.Age4;

                        Master.Age5 = _Property.Age5;
                        Master.Age6 = _Property.Age6;
                        Master.Age7 = _Property.Age7;
                        Master.Age8 = _Property.Age8;

                        Master.Age9 = _Property.Age9;
                        Master.Age10 = _Property.Age10;
                        Master.Age11 = _Property.Age11;
                        Master.Age12 = _Property.Age12;

                        Master.link1 = _Property.link1;
                        Master.link2 = _Property.link2;
                        Master.link3 = _Property.link3;
                        Master.link4 = _Property.link4;
                        Master.link5 = _Property.link5;
                        Master.link6 = _Property.link6;
                        Master.link7 = _Property.link7;
                        Master.link8 = _Property.link8;
                        Master.link9 = _Property.link9;
                        Master.link10 = _Property.link10;
                        Master.link11 = _Property.link11;
                        Master.link12 = _Property.link12;

                        Master.ContactNo1 = _Property.ContactNo1;
                        Master.ContactNo2 = _Property.ContactNo2;
                        Master.ContactNo3 = _Property.ContactNo3;
                        Master.ContactNo4 = _Property.ContactNo4;
                        Master.ContactNo5 = _Property.ContactNo5;
                        Master.ContactNo6 = _Property.ContactNo6;
                        Master.ContactNo7 = _Property.ContactNo7;
                        Master.ContactNo8 = _Property.ContactNo8;
                        Master.ContactNo9 = _Property.ContactNo9;
                        Master.ContactNo10 = _Property.ContactNo10;
                        Master.ContactNo11 = _Property.ContactNo11;
                        Master.ContactNo12 = _Property.ContactNo12;

                        Master.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                        Master.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                        Master.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                        Master.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                        Master.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                        Master.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                        Master.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                        Master.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                        Master.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                        Master.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                        Master.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                        Master.VoterIdentityNo12 = _Property.VoterIdentityNo12;
                        Master.SurveyNo = _Property.SurveyNo;
                        Master.GatNo = _Property.GatNo;
                        Master.CitySurveyNo = _Property.CitySurveyNo;
                        Master.AnnualRateableValue = _Property.AnnualRateableValue;
                        Master.TotalPlotArea = _Property.TotalPlotArea;
                        Master.TotalBuildupArea = _Property.TotalBuildupArea;
                        Master.MarginSpace = _Property.MarginSpace;
                        Master.BuildingName = _Property.BuildingName;
                        Master.PlotNo = _Property.PlotNo;
                        Master.FlatNo = _Property.FlatNo;
                        Master.NoofFloors = _Property.NoofFloors;
                        Master.NoofFlats = _Property.NoofFlats;
                        Master.NoofShops = _Property.NoofShops;
                        Master.PropOwnerFirstName = _Property.PropOwnerFirstName;
                        Master.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                        Master.PropOwnerLastName = _Property.PropOwnerLastName;
                        Master.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                        Master.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                        Master.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                        Master.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                        Master.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                        Master.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                        Master.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                        Master.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                        Master.PropOwnerLastName4 = _Property.PropOwnerLastName4;
                        Master.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                        Master.PropOwnerMobileNo = _Property.PropOwnerElectionCardNo;
                        Master.PropOwnerEmailId = _Property.PropOwnerEmailId;
                        Master.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                        Master.OccupierFirstName = _Property.OccupierFirstName;
                        Master.OccupierMiddleName = _Property.OccupierMiddleName;
                        Master.OccupierLastName = _Property.OccupierLastName;
                        Master.OccupierMobileNo = _Property.OccupierMobileNo;
                        Master.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                        Master.TenantName = _Property.TenantName;
                        Master.Rent = _Property.Rent;
                        Master.TenantMobileNo = _Property.TenantMobileNo;
                        Master.TenantAdhaarNo = _Property.TenantAdhaarNo;
                        Master.Address = _Property.Address;
                        Master.Longitude = _Property.Longitude;
                        Master.Latitude = _Property.Latitude;
                        Master.ConstStartYear = _Property.ConstStartYear;
                        Master.CompletionYear = _Property.CompletionYear;
                        Master.Age = _Property.Age;
                        Master.Usage = _Property.Usage;
                        Master.TypeofBldg = _Property.TypeofBldg;
                        Master.ConstPermNo = _Property.ConstPermNo;
                        Master.PermUseNo = _Property.PermUseNo;
                        Master.Rainwaterharvest = _Property.Rainwaterharvest;
                        Master.SolarWaterheater = _Property.SolarWaterheater;
                        Master.VermicultureProject = _Property.VermicultureProject;
                        Master.SWHRemark = _Property.SWHRemark;
                        Master.WaterConnectionResidential = _Property.WaterConnectionResidential;
                        Master.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Borewell = _Property.Borewell;
                        Master.NonBorewellr = _Property.NonBorewellr;
                        Master.NoofToilets = _Property.NoofToilets;
                        Master.LocationofToiletResidential = _Property.LocationofToiletResidential;
                        Master.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                        Master.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                        Master.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                        Master.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                        Master.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                        Master.UnderGroundGutter = _Property.UnderGroundGutter;
                        Master.OpenGutter = _Property.OpenGutter;
                        Master.DoorLockIndustrial = _Property.DoorLockIndustrial;
                        Master.DoorLockResidential = _Property.DoorLockResidential;
                        Master.DoorLockSpecial = _Property.DoorLockSpecial;
                        Master.PermanentDoorLock = _Property.PermanentDoorLock;
                        Master.OuterMeasurement = _Property.OuterMeasurement;
                        Master.Lift = _Property.Lift;
                        Master.Remarks = _Property.Remarks;
                        Master.FloorNo1 = _Property.FloorNo1;
                        Master.OccupancyStatus1 = _Property.OccupancyStatus1;
                        Master.ConstType1 = _Property.ConstType1;

                        Master.DateofConstruction1 = _Property.DateofConstruction1;

                        Master.UsageType1 = _Property.UsageType1;
                        Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                        Master.Legal1 = _Property.Legal1;
                        Master.CarpetArea1 = _Property.CarpetArea1;
                        Master.BuildupArea1 = _Property.BuildupArea1;
                        Master.FloorNo2 = _Property.FloorNo2;
                        Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                        Master.ConstType2 = _Property.ConstType2;
                        Master.DateofConstruction2 = _Property.DateofConstruction2;
                        Master.UsageType2 = _Property.UsageType2;
                        Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                        Master.Legal2 = _Property.Legal2;
                        Master.CarpetArea2 = _Property.CarpetArea2;
                        Master.BuildupArea2 = _Property.BuildupArea2;
                        Master.FloorNo3 = _Property.FloorNo3;
                        Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                        Master.ConstType3 = _Property.ConstType3;
                        Master.DateofConstruction3 = _Property.DateofConstruction3;


                        Master.UsageType3 = _Property.UsageType3;
                        Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                        Master.Legal3 = _Property.Legal3;
                        Master.CarpetArea3 = _Property.CarpetArea3;
                        Master.BuildupArea3 = _Property.BuildupArea3;
                        Master.FloorNo4 = _Property.FloorNo4;
                        Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                        Master.ConstType4 = _Property.ConstType4;

                        Master.DateofConstruction4 = _Property.DateofConstruction4;

                        Master.UsageType4 = _Property.UsageType4;
                        Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                        Master.Legal4 = _Property.Legal4;
                        Master.CarpetArea4 = _Property.CarpetArea4;
                        Master.BuildupArea4 = _Property.BuildupArea4;
                        Master.FloorNo5 = _Property.FloorNo5;
                        Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                        Master.ConstType5 = _Property.ConstType5;
                        //if (_Property.DateofConstruction5 != "--Select Date--")
                        //{
                        //    Master.DateofConstruction5 = DateTime.ParseExact(_Property.DateofConstruction5, "dd-MM-yyyy", provider);
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction5 = null;
                        //}
                        Master.DateofConstruction5 = _Property.DateofConstruction5;
                        Master.UsageType5 = _Property.UsageType5;
                        Master.UsageTypeClass5 = _Property.UsageTypeClass5;
                        Master.Legal5 = _Property.Legal5;
                        Master.CarpetArea5 = _Property.CarpetArea5;
                        Master.BuildupArea5 = _Property.BuildupArea5;
                        Master.totaltax = _Property.totaltax;
                        Master.totalBuildupArea1 = _Property.totalBuildupArea1;
                        Master.totalCarpetArea = _Property.totalCarpetArea;
                        Master.totaltax = _Property.totaltax;
                        Master.OldUsageType = _Property.OldUsageType;
                        Master.OldConstructionType = _Property.OldConstructionType;
                        Master.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                        Master.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                        Master.NewUsageType = _Property.NewUsageType;
                        Master.NewConstructionType = _Property.NewConstructionType;
                        Master.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                        Master.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                        Master.ExtendUsageType = _Property.ExtendUsage_Type;
                        Master.ExtendConstructionType = _Property.ExtendConstructionType;
                        Master.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                        Master.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                        Master.PropertyType = _Property.PropertyType;
                        Master.SurveyorName = _Property.SurveyorName;
                        if (_Property.SurveyorSignature != null)
                        {
                            Master.SurveyorSignature = _Property.SurveyorSignature;
                        }
                        Master.NonRainwaterharvest = _Property.NonRainwaterharvest;
                        if (_Property.SurveyorDate != "--Select Date--")
                        {
                            Master.SurveyorDate = DateTime.ParseExact(_Property.SurveyorDate, "dd-MM-yyyy", provider);
                        }
                        else
                        {
                            Master.SurveyorDate = null;
                        }
                        Master.DataEntryName = _Property.DataEntryName;
                        if (_Property.DataEntrySignature != null)
                        {
                            Master.DataEntrySignature = _Property.DataEntrySignature;
                        }
                        if (_Property.Sketchdiagram != null)
                        {
                            Master.Sketchdiagram = _Property.Sketchdiagram;
                        }
                        if (_Property.Sketchdiagram2 != null)
                        {
                            Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                        }

                        if (_Property.DataEntryDate != "--Select Date--")
                        {
                            Master.DataEntryDate = DateTime.ParseExact(_Property.DataEntryDate, "dd-MM-yyyy", provider);
                        }
                        else
                        {
                            Master.DataEntryDate = null;
                        }
                        Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                        Master.NonVermicultureProject = _Property.NonVermicultureProject;
                        Master.NoLift = _Property.NoLift;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.AppId = AppId;
                        Master.ZoneNo = _Property.ZoneNo;
                        Master.VillageName = _Property.VillageName;
                        Master.HFSNo = _Property.HFSNo;
                        Master.Legal = _Property.Legal;
                        Master.HissaNo = _Property.HissaNo;
                        Master.OldRateableValue = _Property.OldRateableValue;
                        Master.OldTotalTax = _Property.OldTotalTax;
                        Master.FirstAssessmentYear = _Property.FirstAssessmentYear;
                        Master.ImageNo = _Property.ImageNo;
                        Master.WardNameNo2 = _Property.WardName_No2;
                        Master.ZoneNo2 = _Property.ZoneNo2;
                        Master.FHNo = _Property.FHNo;
                        Master.PropertyType2 = _Property.PropertyType2;
                        Master.NewPropertyNo2 = _Property.NewPropertyNo2;
                        Master.PropertyNo2 = _Property.PropertyNo2;
                        Master.GarbageType = _Property.GarbageType;
                        Master.NOGarbageType = _Property.NOGarbageType;
                        Master.PrabhagNo2 = _Property.PrabhagNo2;
                        Master.YConstPermNo = _Property.YConstPermNo;
                        Master.NConstPermNo = _Property.NConstPermNo;
                        Master.YPermUseNo = _Property.YPermUseNo;
                        Master.NPermUseNo = _Property.NPermUseNo;

                        Master.ZKMKG = _Property.ZKMKG;
                        Master.DVMKG = _Property.DVMKG;
                        Master.ThirdPT = _Property.ThirdPT;
                        Master.FourthPT = _Property.FourthPT;
                        Master.FifthPT = _Property.FifthPT;
                        Master.SixPT = _Property.SixPT;
                        Master.SevenPT = _Property.SevenPT;
                        Master.EightPT = _Property.EightPT;
                        Master.NinePT = _Property.NinePT;
                        Master.TenPT = _Property.TenPT;
                        Master.ElevenPT = _Property.ElevenPT;
                        Master.TwelvePT = _Property.TwelvePT;
                        Master.TherteenPT = _Property.TherteenPT;
                        Master.FourteenPT = _Property.FourteenPT;
                        Master.FifteenPT = _Property.FifteenPT;
                        Master.SixteenPT = _Property.SixteenPT;
                        Master.seventeenPT = _Property.seventeenPT;
                        Master.FirstRPC = _Property.FirstRPC;
                        Master.SecondRPC = _Property.SecondRPC;
                        Master.ThirdRPC = _Property.ThirdRPC;
                        Master.FourthRPC = _Property.FourthRPC;
                        Master.FifthRPC = _Property.FifthRPC;
                        Master.SixRPC = _Property.SixRPC;
                        Master.SevenRPC = _Property.SevenRPC;
                        Master.EightRPC = _Property.EightRPC;
                        Master.NineRPC = _Property.NineRPC;
                        Master.TenRPC = _Property.TenRPC;
                        Master.ElevenRPC = _Property.ElevenRPC;
                        Master.TwelveRPC = _Property.TwelveRPC;
                        Master.ThirteenRPC = _Property.ThirteenRPC;
                        Master.FirstCPC = _Property.FirstCPC;
                        Master.SecondCPC = _Property.SecondCPC;
                        Master.ThirdCPC = _Property.ThirdCPC;
                        Master.FourthCPC = _Property.FourthCPC;
                        Master.FifthCPC = _Property.FifthCPC;
                        Master.SixCPC = _Property.SixCPC;
                        Master.SevenCPC = _Property.SevenCPC;
                        Master.EightCPC = _Property.EightCPC;

                        Master.NineCPC = _Property.NineCPC;
                        Master.TenCPC = _Property.TenCPC;
                        Master.ElevenCPC = _Property.ElevenCPC;
                        Master.TwelveCPC = _Property.TwelveCPC;
                        Master.ThirteenCPC = _Property.ThirteenCPC;
                        Master.FourteenCPC = _Property.FourteenCPC;
                        Master.IsDelete = false;

                        db.PropertyMasters.Add(Master);
                        db.SaveChanges();
                        Result.message = "Save Successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.message = "error";
            }

            return Result;
        }



        public Result NamunaSave(NamunaMasterVM _Namuna, int AppId)
        {
            Result Result = new Result();
            CultureInfo provider = CultureInfo.InvariantCulture;
            NamunaMaster Master = new NamunaMaster();
            try
            {
                using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
                {
                    var obj = db.NamunaMasters.Where(x => x.NamunaId == _Namuna.NamunaId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.NTK = _Namuna.NTK;
                        obj.NWord = _Namuna.NWord;
                        obj.LF = _Namuna.LF;
                        obj.RP2 = _Namuna.RP2;
                        obj.RP = _Namuna.RP;
                        obj.SurvivorName = _Namuna.SurvivorName;
                        obj.DataEntryName = _Namuna.DataEntryName;
                        if (_Namuna.SurvivorDate == "--Select Date--")
                        {
                            obj.SurvivorDate = null;
                        }
                        else
                        {
                            obj.SurvivorDate = DateTime.ParseExact(_Namuna.SurvivorDate, "dd-MM-yyyy", provider);
                        }

                        if (_Namuna.DataEntryDate == "--Select Date--")
                        {
                            obj.DataEntryDate = null;
                        }
                        else
                        {
                            obj.DataEntryDate = DateTime.ParseExact(_Namuna.DataEntryDate, "dd-MM-yyyy", provider); ;
                        }

                    
                        obj.AppilcantName = _Namuna.AppilcantName;

                        if (_Namuna.ApplicantDate == "--Select Date--")
                        {
                            obj.ApplicantDate = null;
                        }
                        else
                        {
                            obj.ApplicantDate = DateTime.ParseExact(_Namuna.ApplicantDate, "dd-MM-yyyy", provider);
                        }

                        if (_Namuna.TaxRegisterDate == "--Select Date--")
                        {
                            obj.TaxRegisterDate = null;
                        }
                        else
                        {
                            obj.TaxRegisterDate = DateTime.ParseExact(_Namuna.TaxRegisterDate, "dd-MM-yyyy", provider); ;
                        }


                        obj.TaxRegister = _Namuna.TaxRegister;
                       
                        obj.RMNAME = _Namuna.RMNAME;
                        obj.PropertyNo = _Namuna.PropertyNo;
                        obj.PropertyDescription = _Namuna.PropertyDescription;
                        obj.OwnerName = _Namuna.OwnerName;
                        obj.OccupantName = _Namuna.OccupantName;
                        obj.Used = _Namuna.Used;
                        obj.AVRent = _Namuna.AVRent;
                        obj.BDBVRent = _Namuna.BDBVRent;
                        obj.BNDBVRent = _Namuna.BNDBVRent;
                        obj.EKJYRent = _Namuna.EKJYRent;
                        obj.DEPercentV = _Namuna.DEPercentV;
                        obj.EKJKYPrice = _Namuna.EKJKYPrice;
                        obj.EMTax = _Namuna.EMTax;
                        obj.TreeTax = _Namuna.TreeTax;
                        obj.EducationTax = _Namuna.EducationTax;
                        obj.RSubTax = _Namuna.RSubTax;
                        obj.OtherTax = _Namuna.OtherTax;
                        obj.TotalTax = _Namuna.TotalTax;
                        obj.TaxBuldingLand = _Namuna.TaxBuldingLand;
                        obj.TaxA = _Namuna.TaxA;
                        obj.TaxB = _Namuna.TaxB;
                        obj.TaxC = _Namuna.TaxC;
                        obj.TaxD = _Namuna.TaxD;
                        obj.TaxABCD = _Namuna.TaxABCD;
                        obj.Signatures = _Namuna.Signatures;
                        obj.Stamp = _Namuna.Stamp;
                        obj.RMNAME2 = _Namuna.RMNAME2;
                        obj.PropertyNo2 = _Namuna.PropertyNo2;
                        obj.PropertyDescription2 = _Namuna.PropertyDescription2;
                        obj.OwnerName2 = _Namuna.OwnerName2;
                        obj.OccupantName2 = _Namuna.OccupantName2;
                        obj.Used2 = _Namuna.Used2;
                        obj.AVRent2 = _Namuna.AVRent2;
                        obj.BDBVRent2 = _Namuna.BDBVRent2;
                        obj.BNDBVRent2 = _Namuna.BNDBVRent2;
                        obj.EKJYRent2 = _Namuna.EKJYRent2;
                        obj.DEPercentV2 = _Namuna.DEPercentV2;
                        obj.EKJKYPrice2 = _Namuna.EKJKYPrice2;
                        obj.EMTax2 = _Namuna.EMTax2;
                        obj.TreeTax2 = _Namuna.TreeTax2;
                        obj.EducationTax2 = _Namuna.EducationTax2;
                        obj.RSubTax2= _Namuna.RSubTax2;
                        obj.OtherTax2 = _Namuna.OtherTax2;
                        obj.TotalTax2 = _Namuna.TotalTax2;
                        obj.TaxBuldingLand2 = _Namuna.TaxBuldingLand2;
                        obj.TaxA2 = _Namuna.TaxA2;
                        obj.TaxB2 = _Namuna.TaxB2;
                        obj.TaxC2 = _Namuna.TaxC2;
                        obj.TaxD2 = _Namuna.TaxD2;
                        obj.TaxABCD2 = _Namuna.TaxABCD2;
                        obj.Signatures2 = _Namuna.Signatures2;
                        obj.Stamp2 = _Namuna.Stamp2;
                        obj.RMNAME3 = _Namuna.RMNAME3;
                        obj.PropertyNo3 = _Namuna.PropertyNo3;
                        obj.PropertyDescription3 = _Namuna.PropertyDescription3;
                        obj.OwnerName3 = _Namuna.OwnerName3;
                        obj.OccupantName3 = _Namuna.OccupantName3;
                        obj.Used3 = _Namuna.Used3;
                        obj.AVRent3 = _Namuna.AVRent3;
                        obj.BDBVRent3 = _Namuna.BDBVRent3;
                        obj.BNDBVRent3 = _Namuna.BNDBVRent3;
                        obj.EKJYRent3 = _Namuna.EKJYRent3;
                        obj.DEPercentV3 = _Namuna.DEPercentV3;
                        obj.EKJKYPrice3 = _Namuna.EKJKYPrice3;
                        obj.EMTax3 = _Namuna.EMTax3;
                        obj.TreeTax3 = _Namuna.TreeTax3;
                        obj.EducationTax3 = _Namuna.EducationTax3;
                        obj.RSubTax3 = _Namuna.RSubTax3;
                        obj.OtherTax3 = _Namuna.OtherTax3;
                        obj.TotalTax3 = _Namuna.TotalTax3;
                        obj.TaxBuldingLand3 = _Namuna.TaxBuldingLand3;
                        obj.TaxA3 = _Namuna.TaxA3;
                        obj.TaxB3 = _Namuna.TaxB3;
                        obj.TaxC3 = _Namuna.TaxC3;
                        obj.TaxD3 = _Namuna.TaxD3;
                        obj.TaxABCD3 = _Namuna.TaxABCD3;
                        obj.Signatures3 = _Namuna.Signatures3;
                        obj.Stamp3 = _Namuna.Stamp3;
                        obj.RMNAME4 = _Namuna.RMNAME4;
                        obj.PropertyNo4 = _Namuna.PropertyNo4;
                        obj.PropertyDescription4 = _Namuna.PropertyDescription4;
                        obj.OwnerName4 = _Namuna.OwnerName4;
                        obj.OccupantName4 = _Namuna.OccupantName4;
                        obj.Used4 = _Namuna.Used4;
                        obj.AVRent4 = _Namuna.AVRent4;
                        obj.BDBVRent4 = _Namuna.BDBVRent4;
                        obj.BNDBVRent4 = _Namuna.BNDBVRent4;
                        obj.EKJYRent4 = _Namuna.EKJYRent4;
                        obj.DEPercentV4 = _Namuna.DEPercentV4;
                        obj.EKJKYPrice4 = _Namuna.EKJKYPrice4;
                        obj.EMTax4 = _Namuna.EMTax4;
                        obj.TreeTax4 = _Namuna.TreeTax4;
                        obj.EducationTax4 = _Namuna.EducationTax4;
                        obj.RSubTax4 = _Namuna.RSubTax4;
                        obj.OtherTax4 = _Namuna.OtherTax4;
                        obj.TotalTax4 = _Namuna.TotalTax4;
                        obj.TaxBuldingLand4 = _Namuna.TaxBuldingLand4;
                        obj.TaxA4 = _Namuna.TaxA4;
                        obj.TaxB4 = _Namuna.TaxB4;
                        obj.TaxC4 = _Namuna.TaxC4;
                        obj.TaxD4 = _Namuna.TaxD4;
                        obj.TaxABCD4 = _Namuna.TaxABCD4;
                        obj.Signatures4 = _Namuna.Signatures4;
                        obj.Stamp4 = _Namuna.Stamp4;
                        obj.RMNAME5 = _Namuna.RMNAME5;
                        obj.PropertyNo5 = _Namuna.PropertyNo5;
                        obj.PropertyDescription5 = _Namuna.PropertyDescription5;
                        obj.OwnerName5 = _Namuna.OwnerName5;
                        obj.OccupantName5 = _Namuna.OccupantName5;
                        obj.Used5 = _Namuna.Used5;
                        obj.AVRent5 = _Namuna.AVRent5;
                        obj.BDBVRent5 = _Namuna.BDBVRent5;
                        obj.BNDBVRent5 = _Namuna.BNDBVRent5;
                        obj.EKJYRent5 = _Namuna.EKJYRent5;
                        obj.DEPercentV5 = _Namuna.DEPercentV5;
                        obj.EKJKYPrice5 = _Namuna.EKJKYPrice5;
                        obj.EMTax5 = _Namuna.EMTax5;
                        obj.TreeTax5 = _Namuna.TreeTax5;
                        obj.EducationTax5 = _Namuna.EducationTax5;
                        obj.RSubTax5 = _Namuna.RSubTax5;
                        obj.OtherTax5 = _Namuna.OtherTax5;
                        obj.TotalTax5 = _Namuna.TotalTax5;
                        obj.TaxBuldingLand5 = _Namuna.TaxBuldingLand5;
                        obj.TaxA5 = _Namuna.TaxA5;
                        obj.TaxB5 = _Namuna.TaxB5;
                        obj.TaxC5 = _Namuna.TaxC5;
                        obj.TaxD5 = _Namuna.TaxD5;
                        obj.TaxABCD5 = _Namuna.TaxABCD5;
                        obj.Signatures5 = _Namuna.Signatures5;
                        obj.Stamp5 = _Namuna.Stamp5;
                        obj.IsDelete = false;
                        db.SaveChanges();
                        Result.message = "Save Changes Successfully!";
                    }
                    else
                    {
                       Master.NTK = _Namuna.NTK;
                       Master.NWord = _Namuna.NWord;
                       Master.LF = _Namuna.LF;
                       Master.RP2 = _Namuna.RP2;
                       Master.RP = _Namuna.RP;
                       Master.SurvivorName = _Namuna.SurvivorName;
                        if (_Namuna.SurvivorDate == "--Select Date--")
                        {
                            Master.SurvivorDate = null;
                        }
                        else
                        {
                            Master.SurvivorDate = DateTime.ParseExact(_Namuna.SurvivorDate, "dd-MM-yyyy", provider);
                        }

                        if (_Namuna.DataEntryDate == "--Select Date--")
                        {
                            Master.DataEntryDate = null;
                        }
                        else
                        {
                            Master.DataEntryDate = DateTime.ParseExact(_Namuna.DataEntryDate, "dd-MM-yyyy", provider); ;
                        }


                        Master.AppilcantName = _Namuna.AppilcantName;

                        if (_Namuna.ApplicantDate == "--Select Date--")
                        {
                            Master.ApplicantDate = null;
                        }
                        else
                        {
                            Master.ApplicantDate = DateTime.ParseExact(_Namuna.ApplicantDate, "dd-MM-yyyy", provider);
                        }

                        if (_Namuna.TaxRegisterDate == "--Select Date--")
                        {
                            Master.TaxRegisterDate = null;
                        }
                        else
                        {
                            Master.TaxRegisterDate = DateTime.ParseExact(_Namuna.TaxRegisterDate, "dd-MM-yyyy", provider); ;
                        }
                       Master.TaxRegister = _Namuna.TaxRegister;
                       Master.RMNAME = _Namuna.RMNAME;
                       Master.PropertyNo = _Namuna.PropertyNo;
                       Master.PropertyDescription = _Namuna.PropertyDescription;
                       Master.OwnerName = _Namuna.OwnerName;
                       Master.OccupantName = _Namuna.OccupantName;
                       Master.Used = _Namuna.Used;
                       Master.AVRent = _Namuna.AVRent;
                       Master.BDBVRent = _Namuna.BDBVRent;
                       Master.BNDBVRent = _Namuna.BNDBVRent;
                       Master.EKJYRent = _Namuna.EKJYRent;
                       Master.DEPercentV = _Namuna.DEPercentV;
                       Master.EKJKYPrice = _Namuna.EKJKYPrice;
                       Master.EMTax = _Namuna.EMTax;
                       Master.TreeTax = _Namuna.TreeTax;
                       Master.EducationTax = _Namuna.EducationTax;
                       Master.RSubTax = _Namuna.RSubTax;
                       Master.OtherTax = _Namuna.OtherTax;
                       Master.TotalTax = _Namuna.TotalTax;
                       Master.TaxBuldingLand = _Namuna.TaxBuldingLand;
                       Master.TaxA = _Namuna.TaxA;
                       Master.TaxB = _Namuna.TaxB;
                       Master.TaxC = _Namuna.TaxC;
                       Master.TaxD = _Namuna.TaxD;
                       Master.TaxABCD = _Namuna.TaxABCD;
                       Master.Signatures = _Namuna.Signatures;
                       Master.Stamp = _Namuna.Stamp;
                       Master.RMNAME2 = _Namuna.RMNAME2;
                       Master.PropertyNo2 = _Namuna.PropertyNo2;
                       Master.PropertyDescription2 = _Namuna.PropertyDescription2;
                       Master.OwnerName2 = _Namuna.OwnerName2;
                       Master.OccupantName2 = _Namuna.OccupantName2;
                       Master.Used2 = _Namuna.Used2;
                       Master.AVRent2 = _Namuna.AVRent2;
                       Master.BDBVRent2 = _Namuna.BDBVRent2;
                       Master.BNDBVRent2 = _Namuna.BNDBVRent2;
                       Master.EKJYRent2 = _Namuna.EKJYRent2;
                       Master.DEPercentV2 = _Namuna.DEPercentV2;
                       Master.EKJKYPrice2 = _Namuna.EKJKYPrice2;
                       Master.EMTax2 = _Namuna.EMTax2;
                       Master.TreeTax2 = _Namuna.TreeTax2;
                       Master.EducationTax2 = _Namuna.EducationTax2;
                       Master.RSubTax2 = _Namuna.RSubTax2;
                       Master.OtherTax2 = _Namuna.OtherTax2;
                       Master.TotalTax2 = _Namuna.TotalTax2;
                       Master.TaxBuldingLand2 = _Namuna.TaxBuldingLand2;
                       Master.TaxA2 = _Namuna.TaxA2;
                       Master.TaxB2 = _Namuna.TaxB2;
                       Master.TaxC2 = _Namuna.TaxC2;
                       Master.TaxD2 = _Namuna.TaxD2;
                       Master.TaxABCD2 = _Namuna.TaxABCD2;
                       Master.Signatures2 = _Namuna.Signatures2;
                       Master.Stamp2 = _Namuna.Stamp2;
                       Master.RMNAME3 = _Namuna.RMNAME3;
                       Master.PropertyNo3 = _Namuna.PropertyNo3;
                       Master.PropertyDescription3 = _Namuna.PropertyDescription3;
                       Master.OwnerName3 = _Namuna.OwnerName3;
                       Master.OccupantName3 = _Namuna.OccupantName3;
                       Master.Used3 = _Namuna.Used3;
                       Master.AVRent3 = _Namuna.AVRent3;
                       Master.BDBVRent3 = _Namuna.BDBVRent3;
                       Master.BNDBVRent3 = _Namuna.BNDBVRent3;
                       Master.EKJYRent3 = _Namuna.EKJYRent3;
                       Master.DEPercentV3 = _Namuna.DEPercentV3;
                       Master.EKJKYPrice3 = _Namuna.EKJKYPrice3;
                       Master.EMTax3 = _Namuna.EMTax3;
                       Master.TreeTax3 = _Namuna.TreeTax3;
                       Master.EducationTax3 = _Namuna.EducationTax3;
                       Master.RSubTax3 = _Namuna.RSubTax3;
                       Master.OtherTax3 = _Namuna.OtherTax3;
                       Master.TotalTax3 = _Namuna.TotalTax3;
                       Master.TaxBuldingLand3 = _Namuna.TaxBuldingLand3;
                       Master.TaxA3 = _Namuna.TaxA3;
                       Master.TaxB3 = _Namuna.TaxB3;
                       Master.TaxC3 = _Namuna.TaxC3;
                       Master.TaxD3 = _Namuna.TaxD3;
                       Master.TaxABCD3 = _Namuna.TaxABCD3;
                       Master.Signatures3 = _Namuna.Signatures3;
                       Master.Stamp3 = _Namuna.Stamp3;
                       Master.RMNAME4 = _Namuna.RMNAME4;
                       Master.PropertyNo4 = _Namuna.PropertyNo4;
                       Master.PropertyDescription4 = _Namuna.PropertyDescription4;
                       Master.OwnerName4 = _Namuna.OwnerName4;
                       Master.OccupantName4 = _Namuna.OccupantName4;
                       Master.Used4 = _Namuna.Used4;
                       Master.AVRent4 = _Namuna.AVRent4;
                       Master.BDBVRent4 = _Namuna.BDBVRent4;
                       Master.BNDBVRent4 = _Namuna.BNDBVRent4;
                       Master.EKJYRent4 = _Namuna.EKJYRent4;
                       Master.DEPercentV4 = _Namuna.DEPercentV4;
                       Master.EKJKYPrice4 = _Namuna.EKJKYPrice4;
                       Master.EMTax4 = _Namuna.EMTax4;
                       Master.TreeTax4 = _Namuna.TreeTax4;
                       Master.EducationTax4 = _Namuna.EducationTax4;
                       Master.RSubTax4 = _Namuna.RSubTax4;
                       Master.OtherTax4 = _Namuna.OtherTax4;
                       Master.TotalTax4 = _Namuna.TotalTax4;
                       Master.TaxBuldingLand4 = _Namuna.TaxBuldingLand4;
                       Master.TaxA4 = _Namuna.TaxA4;
                       Master.TaxB4 = _Namuna.TaxB4;
                       Master.TaxC4 = _Namuna.TaxC4;
                       Master.TaxD4 = _Namuna.TaxD4;
                       Master.TaxABCD4 = _Namuna.TaxABCD4;
                       Master.Signatures4 = _Namuna.Signatures4;
                       Master.Stamp4 = _Namuna.Stamp4;
                       Master.RMNAME5 = _Namuna.RMNAME5;
                       Master.PropertyNo5 = _Namuna.PropertyNo5;
                       Master.PropertyDescription5 = _Namuna.PropertyDescription5;
                       Master.OwnerName5 = _Namuna.OwnerName5;
                       Master.OccupantName5 = _Namuna.OccupantName5;
                       Master.Used5 = _Namuna.Used5;
                       Master.AVRent5 = _Namuna.AVRent5;
                       Master.BDBVRent5 = _Namuna.BDBVRent5;
                       Master.BNDBVRent5 = _Namuna.BNDBVRent5;
                       Master.EKJYRent5 = _Namuna.EKJYRent5;
                       Master.DEPercentV5 = _Namuna.DEPercentV5;
                       Master.EKJKYPrice5 = _Namuna.EKJKYPrice5;
                       Master.EMTax5 = _Namuna.EMTax5;
                       Master.TreeTax5 = _Namuna.TreeTax5;
                       Master.EducationTax5 = _Namuna.EducationTax5;
                       Master.RSubTax5 = _Namuna.RSubTax5;
                       Master.OtherTax5 = _Namuna.OtherTax5;
                       Master.TotalTax5 = _Namuna.TotalTax5;
                       Master.TaxBuldingLand5 = _Namuna.TaxBuldingLand5;
                       Master.TaxA5 = _Namuna.TaxA5;
                       Master.TaxB5 = _Namuna.TaxB5;
                       Master.TaxC5 = _Namuna.TaxC5;
                       Master.TaxD5 = _Namuna.TaxD5;
                       Master.TaxABCD5 = _Namuna.TaxABCD5;
                       Master.Signatures5 = _Namuna.Signatures5;
                       Master.Stamp5 = _Namuna.Stamp5;
                       Master.IsDelete = false;
                       db.NamunaMasters.Add(Master);
                       db.SaveChanges();
                       Result.message = "Save Successfully!";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Result.message = "error";
            }

            return Result;
        }


        public List<PropertyMasterVM> getPropertyDetails(int AppId)
        {
            List<PropertyMasterVM> result = new List<PropertyMasterVM>();

            using (var db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {
                result = db.PropertyMasters.Where(x => x.IsDelete == false).Select(x => new PropertyMasterVM
                {
                    PropertyId = x.PropertyId,
                    NewPropertyNo = x.NewPropertyNo,
                    PropertyNo = x.PropertyNo,
                    OldHouseNo1 = x.HouseNo,
                    PropOwnerFirstName = x.PropOwnerFirstName,
                    PropOwnerMiddleName = x.PropOwnerMiddleName,
                    PropOwnerLastName = x.PropOwnerLastName,
                    PropOwnerTelephoneNo = x.PropOwnerTelephoneNo,
                    Sketchdiagram2 = x.Sketchdiagram2,
                    PrabhagNo = x.PrabhagNo,
                    WardName_No = x.WardNameNo,
                    ConstStartYear = x.ConstStartYear,
                    CompletionYear = x.CompletionYear,
                    Safe=x.Safe,
                    Safe2 = x.Safe2,
                    Safe3 = x.Safe3,
                    Danger = x.Danger,
                    Danger2 = x.Danger2,
                    Danger3 = x.Danger3,
                    YPermUseNo=x.YPermUseNo,           
                    NPermUseNo=x.NPermUseNo,
                    YConstPermNo=x.YConstPermNo,
                    NConstPermNo=x.NConstPermNo,
                    ConstPermNo=x.ConstPermNo,
                    PermUseNo=x.PermUseNo,
                    Name1=x.Name1,
                    Name2 = x.Name2,
                    Name3 = x.Name3,
                    Name4 = x.Name4,
                    Name5 = x.Name5,
                    Name6 = x.Name6,
                    Name7 = x.Name7,
                    Name8 = x.Name8,
                    Name9 = x.Name9,
                    Name10 = x.Name10,
                    Name11 = x.Name11,
                    Name12 = x.Name12,
                    Rainwaterharvest=x.Rainwaterharvest,
                    NonRainwaterharvest=x.NonRainwaterharvest,
                    VermicultureProject=x.VermicultureProject,
                    NonVermicultureProject=x.NonVermicultureProject,
                    SolarWaterheater=x.SolarWaterheater,
                    NonSolarWaterheater=x.NonSolarWaterheater




                }).ToList();
            }


            return result;
        }


        public List<NamunaMasterVM> getNamunaDetails(int AppId)
        {
            List<NamunaMasterVM> result = new List<NamunaMasterVM>();

            using (var db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {
                result = db.NamunaMasters.Where(x => x.IsDelete == false).Select(x => new NamunaMasterVM
                {
                    NamunaId = x.NamunaId,
                    OwnerName = x.OwnerName,
                    OccupantName = x.OccupantName,
                    AppilcantName = x.AppilcantName,
                    PropertyNo = x.PropertyNo
                }).ToList();
            }


            return result;
        }


        public PropertyMasterVM getPropertyDetailsByID(int q, int AppId)
        {
            PropertyMasterVM Master = new PropertyMasterVM();
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {

                var _Property = db.PropertyMasters.Where(c => c.PropertyId == q).FirstOrDefault();
                if (_Property != null)
                {
                    Master.PropertyId = _Property.PropertyId;
                    Master.PrabhagNo = _Property.PrabhagNo;
                    Master.WardName_No = _Property.WardNameNo;
                    Master.ElectionWard = _Property.ElectionWard;
                    Master.NewPropertyNo = _Property.NewPropertyNo;
                    Master.PropertyNo = _Property.PropertyNo;
                    Master.OldHouseNo1 = _Property.HouseNo;
                    Master.OldHouseNo2 = _Property.oldHouseNo2;
                    Master.NoOfTrees = _Property.NoOfTrees;
                    Master.Personalwell = _Property.Personalwell;
                    Master.HeritageTree = _Property.HeritageTree;

                    Master.WaterConnection = _Property.WaterConnection;
                    Master.NoWaterConnection = _Property.NoWaterConnection;
                    Master.STP = _Property.STP;
                    Master.FST = _Property.FST;
                    Master.STS = _Property.STS;
                    Master.Other = _Property.Other;
                    Master.SGSK = _Property.SGSK;

                    Master.NOSGSK = _Property.NOSGSK;
                    Master.OtherGutter = _Property.OtherGutter;
                    Master.NaturalMethod = _Property.NaturalMethod;
                    Master.ArtifitialMethod = _Property.ArtifitialMethod;
                    Master.OtherMethod = _Property.OtherMethod;
                    Master.NoProject = _Property.NoProject;
                    Master.Safe = _Property.Safe;
                    Master.Danger = _Property.Danger;
                    Master.Safe2 = _Property.Safe2;
                    Master.Danger2 = _Property.Danger2;
                    Master.Safe3 = _Property.Safe3;

                    Master.NOSGSK = _Property.NOSGSK;
                    Master.OtherGutter = _Property.OtherGutter;
                    Master.NaturalMethod = _Property.NaturalMethod;
                    Master.ArtifitialMethod = _Property.ArtifitialMethod;
                    Master.OtherMethod = _Property.OtherMethod;
                    Master.NoProject = _Property.NoProject;
                    Master.Safe = _Property.Safe;
                    Master.Danger = _Property.Danger;
                    Master.Safe2 = _Property.Safe2;
                    Master.Danger2 = _Property.Danger2;
                    Master.Safe3 = _Property.Safe3;
                    Master.Danger3 = _Property.Danger3;

                    Master.TotalPropertyExpense = _Property.TotalPropertyExpense;
                    Master.CurrentPropertyTax = _Property.CurrentPropertyTax;
                    Master.CurrentProperyPrice = _Property.CurrentProperyPrice;
                    Master.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                    Master.ProperyTaxPrice = _Property.ProperyTaxPrice;
                    Master.TotalTaxPrice = _Property.TotalTaxPrice;
                    Master.OpenLandtaxprice = _Property.OpenLandtaxprice;
                    Master.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                    Master.Name1 = _Property.Name1;
                    Master.Name2 = _Property.Name2;
                    Master.Name3 = _Property.Name3;
                    Master.Name4 = _Property.Name4;

                    Master.Name5 = _Property.Name5;
                    Master.Name6 = _Property.Name6;
                    Master.Name7 = _Property.Name7;
                    Master.Name8 = _Property.Name8;

                    Master.Name9 = _Property.Name9;
                    Master.Name10 = _Property.Name10;
                    Master.Name11 = _Property.Name11;
                    Master.Name12 = _Property.Name12;

                    Master.Age1 = _Property.Age1;
                    Master.Age2 = _Property.Age2;
                    Master.Age3 = _Property.Age3;
                    Master.Age4 = _Property.Age4;

                    Master.Age5 = _Property.Age5;
                    Master.Age6 = _Property.Age6;
                    Master.Age7 = _Property.Age7;
                    Master.Age8 = _Property.Age8;

                    Master.Age9 = _Property.Age9;
                    Master.Age10 = _Property.Age10;
                    Master.Age11 = _Property.Age11;
                    Master.Age12 = _Property.Age12;

                    Master.link1 = _Property.link1;
                    Master.link2 = _Property.link2;
                    Master.link3 = _Property.link3;
                    Master.link4 = _Property.link4;
                    Master.link5 = _Property.link5;
                    Master.link6 = _Property.link6;
                    Master.link7 = _Property.link7;
                    Master.link8 = _Property.link8;
                    Master.link9 = _Property.link9;
                    Master.link10 = _Property.link10;
                    Master.link11 = _Property.link11;
                    Master.link12 = _Property.link12;

                    Master.ContactNo1 = _Property.ContactNo1;
                    Master.ContactNo2 = _Property.ContactNo2;
                    Master.ContactNo3 = _Property.ContactNo3;
                    Master.ContactNo4 = _Property.ContactNo4;
                    Master.ContactNo5 = _Property.ContactNo5;
                    Master.ContactNo6 = _Property.ContactNo6;
                    Master.ContactNo7 = _Property.ContactNo7;
                    Master.ContactNo8 = _Property.ContactNo8;
                    Master.ContactNo9 = _Property.ContactNo9;
                    Master.ContactNo10 = _Property.ContactNo10;
                    Master.ContactNo11 = _Property.ContactNo11;
                    Master.ContactNo12 = _Property.ContactNo12;

                    Master.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                    Master.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                    Master.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                    Master.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                    Master.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                    Master.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                    Master.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                    Master.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                    Master.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                    Master.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                    Master.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                    Master.VoterIdentityNo12 = _Property.VoterIdentityNo12;
                    Master.SurveyNo = _Property.SurveyNo;
                    Master.GatNo = _Property.GatNo;
                    Master.CitySurveyNo = _Property.CitySurveyNo;
                    Master.AnnualRateableValue = _Property.AnnualRateableValue;
                    Master.TotalPlotArea = _Property.TotalPlotArea;
                    Master.TotalBuildupArea = _Property.TotalBuildupArea;
                    Master.MarginSpace = _Property.MarginSpace;
                    Master.BuildingName = _Property.BuildingName;
                    Master.PlotNo = _Property.PlotNo;
                    Master.FlatNo = _Property.FlatNo;
                    Master.NoofFloors = _Property.NoofFloors;
                    Master.NoofFlats = _Property.NoofFlats;
                    Master.NoofShops = _Property.NoofShops;
                    Master.PropOwnerFirstName = _Property.PropOwnerFirstName;
                    Master.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                    Master.PropOwnerLastName = _Property.PropOwnerLastName;
                    Master.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                    Master.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                    Master.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                    Master.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                    Master.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                    Master.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                    Master.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                    Master.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                    Master.PropOwnerLastName4 = _Property.PropOwnerLastName4;
                    Master.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                    Master.PropOwnerElectionCardNo = _Property.PropOwnerMobileNo;
                    Master.PropOwnerEmailId = _Property.PropOwnerEmailId;
                    Master.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                    Master.OccupierFirstName = _Property.OccupierFirstName;
                    Master.OccupierMiddleName = _Property.OccupierMiddleName;
                    Master.OccupierLastName = _Property.OccupierLastName;
                    Master.OccupierMobileNo = _Property.OccupierMobileNo;
                    Master.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                    Master.TenantName = _Property.TenantName;
                    Master.Rent = _Property.Rent;
                    Master.TenantMobileNo = _Property.TenantMobileNo;
                    Master.TenantAdhaarNo = _Property.TenantAdhaarNo;
                    Master.Address = _Property.Address;
                    Master.Longitude = _Property.Longitude;
                    Master.Latitude = _Property.Latitude;
                    Master.ConstStartYear = _Property.ConstStartYear;
                    Master.CompletionYear = _Property.CompletionYear;
                    Master.Age = _Property.Age;
                    Master.Usage = _Property.Usage;
                    Master.TypeofBldg = _Property.TypeofBldg;
                    Master.ConstPermNo = _Property.ConstPermNo;
                    Master.PermUseNo = _Property.PermUseNo;
                    Master.Rainwaterharvest = _Property.Rainwaterharvest;
                    Master.NonRainwaterharvest = _Property.NonRainwaterharvest;
                    Master.SolarWaterheater = _Property.SolarWaterheater;
                    Master.VermicultureProject = _Property.VermicultureProject;
                    Master.SWHRemark = _Property.SWHRemark;
                    Master.WaterConnectionResidential = _Property.WaterConnectionResidential;
                    Master.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                    Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                    Master.Borewell = _Property.Borewell;
                    Master.NonBorewellr = _Property.NonBorewellr;
                    Master.NoofToilets = _Property.NoofToilets;
                    Master.LocationofToiletResidential = _Property.LocationofToiletResidential;
                    Master.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                    Master.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                    Master.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                    Master.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                    Master.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                    Master.UnderGroundGutter = _Property.UnderGroundGutter;
                    Master.OpenGutter = _Property.OpenGutter;
                    Master.DoorLockIndustrial = _Property.DoorLockIndustrial;
                    Master.DoorLockResidential = _Property.DoorLockResidential;
                    Master.DoorLockSpecial = _Property.DoorLockSpecial;
                    Master.PermanentDoorLock = _Property.PermanentDoorLock;
                    Master.OuterMeasurement = _Property.OuterMeasurement;
                    Master.Lift = _Property.Lift;
                    Master.Remarks = _Property.Remarks;
                    Master.FloorNo1 = _Property.FloorNo1;
                    Master.OccupancyStatus1 = _Property.OccupancyStatus1;
                    Master.ConstType1 = _Property.ConstType1;
                    Master.DateofConstruction1 = _Property.DateofConstruction1;
                    Master.DateofConstruction2 = _Property.DateofConstruction2;
                    Master.DateofConstruction3 = _Property.DateofConstruction3;
                    Master.DateofConstruction4 = _Property.DateofConstruction4;
                    Master.DateofConstruction5 = _Property.DateofConstruction5;

                    //if(_Property.DateofConstruction1 !=null)
                    //{ 
                    //Master.DateofConstruction1 = Convert.ToDateTime(_Property.DateofConstruction1).ToString("dd-MM-yyyy");
                    //}

                    //else
                    //{
                    //    Master.DateofConstruction1 = "--Select Date--";
                    //}

                    //if (_Property.DateofConstruction2 != null)
                    //{
                    //    Master.DateofConstruction2 = Convert.ToDateTime(_Property.DateofConstruction2).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //    Master.DateofConstruction2 = "--Select Date--";
                    //}


                    //if (_Property.DateofConstruction3 != null)
                    //{
                    //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //    Master.DateofConstruction3 = "--Select Date--";
                    //}


                    //if (_Property.DateofConstruction3 != null)
                    //{
                    //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //    Master.DateofConstruction3 = "--Select Date--";
                    //}


                    //if (_Property.DateofConstruction4 != null)
                    //{
                    //    Master.DateofConstruction4 = Convert.ToDateTime(_Property.DateofConstruction4).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //    Master.DateofConstruction4 = "--Select Date--";
                    //}


                    //if (_Property.DateofConstruction5 != null)
                    //{
                    //    Master.DateofConstruction5 = Convert.ToDateTime(_Property.DateofConstruction5).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //    Master.DateofConstruction5 = "--Select Date--";
                    //}
                    Master.UsageType1 = _Property.UsageType1;
                    Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                    Master.Legal1 = _Property.Legal1;
                    Master.CarpetArea1 = _Property.CarpetArea1;
                    Master.BuildupArea1 = _Property.BuildupArea1;
                    Master.FloorNo2 = _Property.FloorNo2;
                    Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                    Master.ConstType2 = _Property.ConstType2;

                    Master.UsageType2 = _Property.UsageType2;
                    Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                    Master.Legal2 = _Property.Legal2;
                    Master.CarpetArea2 = _Property.CarpetArea2;
                    Master.BuildupArea2 = _Property.BuildupArea2;
                    Master.FloorNo3 = _Property.FloorNo3;
                    Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                    Master.ConstType3 = _Property.ConstType3;

                    Master.UsageType3 = _Property.UsageType3;
                    Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                    Master.Legal3 = _Property.Legal3;
                    Master.CarpetArea3 = _Property.CarpetArea3;
                    Master.BuildupArea3 = _Property.BuildupArea3;
                    Master.FloorNo4 = _Property.FloorNo4;
                    Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                    Master.ConstType4 = _Property.ConstType4;

                    Master.UsageType4 = _Property.UsageType4;
                    Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                    Master.Legal4 = _Property.Legal4;
                    Master.CarpetArea4 = _Property.CarpetArea4;
                    Master.BuildupArea4 = _Property.BuildupArea4;
                    Master.FloorNo5 = _Property.FloorNo5;
                    Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                    Master.ConstType5 = _Property.ConstType5;

                    Master.UsageType5 = _Property.UsageType5;
                    Master.UsageTypeClass5 = _Property.UsageTypeClass5;
                    Master.Legal5 = _Property.Legal5;
                    Master.CarpetArea5 = _Property.CarpetArea5;
                    Master.BuildupArea5 = _Property.BuildupArea5;
                    Master.totaltax = _Property.totaltax;
                    Master.totalBuildupArea1 = _Property.totalBuildupArea1;
                    Master.totalCarpetArea = _Property.totalCarpetArea;
                    Master.totaltax = _Property.totaltax;
                    Master.OldUsageType = _Property.OldUsageType;
                    Master.OldConstructionType = _Property.OldConstructionType;
                    Master.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                    Master.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                    Master.NewUsageType = _Property.NewUsageType;
                    Master.NewConstructionType = _Property.NewConstructionType;
                    Master.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                    Master.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                    Master.ExtendUsage_Type = _Property.ExtendUsageType;
                    Master.ExtendConstructionType = _Property.ExtendConstructionType;
                    Master.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                    Master.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                    Master.PropertyType = _Property.PropertyType;
                    Master.SurveyorName = _Property.SurveyorName;
                    Master.SurveyorSignature = _Property.SurveyorSignature;

                    if (_Property.SurveyorDate != null)
                    {
                        Master.SurveyorDate = Convert.ToDateTime(_Property.SurveyorDate).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        Master.SurveyorDate = "--Select Date--";
                    }
                    if (_Property.DataEntryDate != null)
                    {
                        Master.DataEntryDate = Convert.ToDateTime(_Property.DataEntryDate).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        Master.DataEntryDate = "--Select Date--";
                    }
                    Master.DataEntryName = _Property.DataEntryName;
                    Master.DataEntrySignature = _Property.DataEntrySignature;

                    Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                    Master.NonVermicultureProject = _Property.NonVermicultureProject;
                    Master.NoLift = _Property.NoLift;
                    Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                    Master.Sketchdiagram = _Property.Sketchdiagram;
                    Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                    Master.ZoneNo = _Property.ZoneNo;
                    Master.VillageName = _Property.VillageName;
                    Master.HFSNo = _Property.HFSNo;
                    Master.Legal = _Property.Legal;
                    Master.HissaNo = _Property.HissaNo;
                    Master.OldRateableValue = _Property.OldRateableValue;
                    Master.OldTotalTax = _Property.OldTotalTax;
                    Master.FirstAssessmentYear = _Property.FirstAssessmentYear;
                    Master.ImageNo = _Property.ImageNo;
                    Master.WardName_No2 = _Property.WardNameNo2;
                    Master.ZoneNo2 = _Property.ZoneNo2;
                    Master.FHNo = _Property.FHNo;
                    Master.PropertyType2 = _Property.PropertyType2;
                    Master.NewPropertyNo2 = _Property.NewPropertyNo2;
                    Master.PropertyNo2 = _Property.PropertyNo2;
                    Master.GarbageType = _Property.GarbageType;
                    Master.NOGarbageType = _Property.NOGarbageType;
                    Master.PrabhagNo2 = _Property.PrabhagNo2;
                    Master.YConstPermNo = _Property.YConstPermNo;
                    Master.NConstPermNo = _Property.NConstPermNo;
                    Master.YPermUseNo = _Property.YPermUseNo;
                    Master.NPermUseNo = _Property.NPermUseNo;


                    Master.ZKMKG = _Property.ZKMKG;
                    Master.DVMKG = _Property.DVMKG;
                    Master.ThirdPT = _Property.ThirdPT;
                    Master.FourthPT = _Property.FourthPT;
                    Master.FifthPT = _Property.FifthPT;
                    Master.SixPT = _Property.SixPT;
                    Master.SevenPT = _Property.SevenPT;
                    Master.EightPT = _Property.EightPT;
                    Master.NinePT = _Property.NinePT;
                    Master.TenPT = _Property.TenPT;
                    Master.ElevenPT = _Property.ElevenPT;
                    Master.TwelvePT = _Property.TwelvePT;
                    Master.TherteenPT = _Property.TherteenPT;
                    Master.FourteenPT = _Property.FourteenPT;
                    Master.FifteenPT = _Property.FifteenPT;
                    Master.SixteenPT = _Property.SixteenPT;
                    Master.seventeenPT = _Property.seventeenPT;
                    Master.FirstRPC = _Property.FirstRPC;
                    Master.SecondRPC = _Property.SecondRPC;
                    Master.ThirdRPC = _Property.ThirdRPC;
                    Master.FourthRPC = _Property.FourthRPC;
                    Master.FifthRPC = _Property.FifthRPC;
                    Master.SixRPC = _Property.SixRPC;
                    Master.SevenRPC = _Property.SevenRPC;
                    Master.EightRPC = _Property.EightRPC;
                    Master.NineRPC = _Property.NineRPC;
                    Master.TenRPC = _Property.TenRPC;
                    Master.ElevenRPC = _Property.ElevenRPC;
                    Master.TwelveRPC = _Property.TwelveRPC;
                    Master.ThirteenRPC = _Property.ThirteenRPC;
                    Master.FirstCPC = _Property.FirstCPC;
                    Master.SecondCPC = _Property.SecondCPC;
                    Master.ThirdCPC = _Property.ThirdCPC;
                    Master.FourthCPC = _Property.FourthCPC;
                    Master.FifthCPC = _Property.FifthCPC;
                    Master.SixCPC = _Property.SixCPC;
                    Master.SevenCPC = _Property.SevenCPC;
                    Master.EightCPC = _Property.EightCPC;

                    Master.NineCPC = _Property.NineCPC;
                    Master.TenCPC = _Property.TenCPC;
                    Master.ElevenCPC = _Property.ElevenCPC;
                    Master.TwelveCPC = _Property.TwelveCPC;
                    Master.ThirteenCPC = _Property.ThirteenCPC;
                    Master.FourteenCPC = _Property.FourteenCPC;
                }
                else
                {

                }
            }
            return Master;
        }


        public NamunaMasterVM getNamunaDetailsByID(int q, int AppId)
        {
            NamunaMasterVM Master = new NamunaMasterVM();
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {

                var _Namuna = db.NamunaMasters.Where(c => c.NamunaId == q).FirstOrDefault();
                if (_Namuna != null)
                {
                    Master.NTK = _Namuna.NTK;
                    Master.NWord = _Namuna.NWord;
                    Master.LF = _Namuna.LF;
                    Master.RP2 = _Namuna.RP2;
                    Master.RP = _Namuna.RP;
                    Master.SurvivorName = _Namuna.SurvivorName;
                    Master.DataEntryName = _Namuna.DataEntryName;
                    Master.SurvivorDate = Convert.ToDateTime(_Namuna.SurvivorDate).ToString("dd-MM-yyyy");
                    Master.DataEntryDate = Convert.ToDateTime(_Namuna.DataEntryDate).ToString("dd-MM-yyyy");
                    Master.AppilcantName = _Namuna.AppilcantName;
                    Master.ApplicantDate = Convert.ToDateTime(_Namuna.ApplicantDate).ToString("dd-MM-yyyy");
                    Master.TaxRegister = _Namuna.TaxRegister;
                    Master.TaxRegisterDate = Convert.ToDateTime(_Namuna.SurvivorDate).ToString("dd-MM-yyyy");
                    Master.RMNAME = _Namuna.RMNAME;
                    Master.PropertyNo = _Namuna.PropertyNo;
                    Master.PropertyDescription = _Namuna.PropertyDescription;
                    Master.OwnerName = _Namuna.OwnerName;
                    Master.OccupantName = _Namuna.OccupantName;
                    Master.Used = _Namuna.Used;
                    Master.AVRent = _Namuna.AVRent;
                    Master.BDBVRent = _Namuna.BDBVRent;
                    Master.BNDBVRent = _Namuna.BNDBVRent;
                    Master.EKJYRent = _Namuna.EKJYRent;
                    Master.DEPercentV = _Namuna.DEPercentV;
                    Master.EKJKYPrice = _Namuna.EKJKYPrice;
                    Master.EMTax = _Namuna.EMTax;
                    Master.TreeTax = _Namuna.TreeTax;
                    Master.EducationTax = _Namuna.EducationTax;
                    Master.RSubTax = _Namuna.RSubTax;
                    Master.OtherTax = _Namuna.OtherTax;
                    Master.TotalTax = _Namuna.TotalTax;
                    Master.TaxBuldingLand = _Namuna.TaxBuldingLand;
                    Master.TaxA = _Namuna.TaxA;
                    Master.TaxB = _Namuna.TaxB;
                    Master.TaxC = _Namuna.TaxC;
                    Master.TaxD = _Namuna.TaxD;
                    Master.TaxABCD = _Namuna.TaxABCD;
                    Master.Signatures = _Namuna.Signatures;
                    Master.Stamp = _Namuna.Stamp;
                    Master.RMNAME2 = _Namuna.RMNAME2;
                    Master.PropertyNo2 = _Namuna.PropertyNo2;
                    Master.PropertyDescription2 = _Namuna.PropertyDescription2;
                    Master.OwnerName2 = _Namuna.OwnerName2;
                    Master.OccupantName2 = _Namuna.OccupantName2;
                    Master.Used2 = _Namuna.Used2;
                    Master.AVRent2 = _Namuna.AVRent2;
                    Master.BDBVRent2 = _Namuna.BDBVRent2;
                    Master.BNDBVRent2 = _Namuna.BNDBVRent2;
                    Master.EKJYRent2 = _Namuna.EKJYRent2;
                    Master.DEPercentV2 = _Namuna.DEPercentV2;
                    Master.EKJKYPrice2 = _Namuna.EKJKYPrice2;
                    Master.EMTax2 = _Namuna.EMTax2;
                    Master.TreeTax2 = _Namuna.TreeTax2;
                    Master.EducationTax2 = _Namuna.EducationTax2;
                    Master.RSubTax2 = _Namuna.RSubTax2;
                    Master.OtherTax2 = _Namuna.OtherTax2;
                    Master.TotalTax2 = _Namuna.TotalTax2;
                    Master.TaxBuldingLand2 = _Namuna.TaxBuldingLand2;
                    Master.TaxA2 = _Namuna.TaxA2;
                    Master.TaxB2 = _Namuna.TaxB2;
                    Master.TaxC2 = _Namuna.TaxC2;
                    Master.TaxD2 = _Namuna.TaxD2;
                    Master.TaxABCD2 = _Namuna.TaxABCD2;
                    Master.Signatures2 = _Namuna.Signatures2;
                    Master.Stamp2 = _Namuna.Stamp2;
                    Master.RMNAME3 = _Namuna.RMNAME3;
                    Master.PropertyNo3 = _Namuna.PropertyNo3;
                    Master.PropertyDescription3 = _Namuna.PropertyDescription3;
                    Master.OwnerName3 = _Namuna.OwnerName3;
                    Master.OccupantName3 = _Namuna.OccupantName3;
                    Master.Used3 = _Namuna.Used3;
                    Master.AVRent3 = _Namuna.AVRent3;
                    Master.BDBVRent3 = _Namuna.BDBVRent3;
                    Master.BNDBVRent3 = _Namuna.BNDBVRent3;
                    Master.EKJYRent3 = _Namuna.EKJYRent3;
                    Master.DEPercentV3 = _Namuna.DEPercentV3;
                    Master.EKJKYPrice3 = _Namuna.EKJKYPrice3;
                    Master.EMTax3 = _Namuna.EMTax3;
                    Master.TreeTax3 = _Namuna.TreeTax3;
                    Master.EducationTax3 = _Namuna.EducationTax3;
                    Master.RSubTax3 = _Namuna.RSubTax3;
                    Master.OtherTax3 = _Namuna.OtherTax3;
                    Master.TotalTax3 = _Namuna.TotalTax3;
                    Master.TaxBuldingLand3 = _Namuna.TaxBuldingLand3;
                    Master.TaxA3 = _Namuna.TaxA3;
                    Master.TaxB3 = _Namuna.TaxB3;
                    Master.TaxC3 = _Namuna.TaxC3;
                    Master.TaxD3 = _Namuna.TaxD3;
                    Master.TaxABCD3 = _Namuna.TaxABCD3;
                    Master.Signatures3 = _Namuna.Signatures3;
                    Master.Stamp3 = _Namuna.Stamp3;
                    Master.RMNAME4 = _Namuna.RMNAME4;
                    Master.PropertyNo4 = _Namuna.PropertyNo4;
                    Master.PropertyDescription4 = _Namuna.PropertyDescription4;
                    Master.OwnerName4 = _Namuna.OwnerName4;
                    Master.OccupantName4 = _Namuna.OccupantName4;
                    Master.Used4 = _Namuna.Used4;
                    Master.AVRent4 = _Namuna.AVRent4;
                    Master.BDBVRent4 = _Namuna.BDBVRent4;
                    Master.BNDBVRent4 = _Namuna.BNDBVRent4;
                    Master.EKJYRent4 = _Namuna.EKJYRent4;
                    Master.DEPercentV4 = _Namuna.DEPercentV4;
                    Master.EKJKYPrice4 = _Namuna.EKJKYPrice4;
                    Master.EMTax4 = _Namuna.EMTax4;
                    Master.TreeTax4 = _Namuna.TreeTax4;
                    Master.EducationTax4 = _Namuna.EducationTax4;
                    Master.RSubTax4 = _Namuna.RSubTax4;
                    Master.OtherTax4 = _Namuna.OtherTax4;
                    Master.TotalTax4 = _Namuna.TotalTax4;
                    Master.TaxBuldingLand4 = _Namuna.TaxBuldingLand4;
                    Master.TaxA4 = _Namuna.TaxA4;
                    Master.TaxB4 = _Namuna.TaxB4;
                    Master.TaxC4 = _Namuna.TaxC4;
                    Master.TaxD4 = _Namuna.TaxD4;
                    Master.TaxABCD4 = _Namuna.TaxABCD4;
                    Master.Signatures4 = _Namuna.Signatures4;
                    Master.Stamp4 = _Namuna.Stamp4;
                    Master.RMNAME5 = _Namuna.RMNAME5;
                    Master.PropertyNo5 = _Namuna.PropertyNo5;
                    Master.PropertyDescription5 = _Namuna.PropertyDescription5;
                    Master.OwnerName5 = _Namuna.OwnerName5;
                    Master.OccupantName5 = _Namuna.OccupantName5;
                    Master.Used5 = _Namuna.Used5;
                    Master.AVRent5 = _Namuna.AVRent5;
                    Master.BDBVRent5 = _Namuna.BDBVRent5;
                    Master.BNDBVRent5 = _Namuna.BNDBVRent5;
                    Master.EKJYRent5 = _Namuna.EKJYRent5;
                    Master.DEPercentV5 = _Namuna.DEPercentV5;
                    Master.EKJKYPrice5 = _Namuna.EKJKYPrice5;
                    Master.EMTax5 = _Namuna.EMTax5;
                    Master.TreeTax5 = _Namuna.TreeTax5;
                    Master.EducationTax5 = _Namuna.EducationTax5;
                    Master.RSubTax5 = _Namuna.RSubTax5;
                    Master.OtherTax5 = _Namuna.OtherTax5;
                    Master.TotalTax5 = _Namuna.TotalTax5;
                    Master.TaxBuldingLand5 = _Namuna.TaxBuldingLand5;
                    Master.TaxA5 = _Namuna.TaxA5;
                    Master.TaxB5 = _Namuna.TaxB5;
                    Master.TaxC5 = _Namuna.TaxC5;
                    Master.TaxD5 = _Namuna.TaxD5;
                    Master.TaxABCD5 = _Namuna.TaxABCD5;
                    Master.Signatures5 = _Namuna.Signatures5;
                    Master.Stamp5 = _Namuna.Stamp5;
                }
                else
                {
                    Master.NamunaId = -1;
                }
            }
            return Master;
        }

        public PropertyMasterVM getPropertyDetailsByFamily(string q,string n, int AppId)
        {
            PropertyMasterVM Master = new PropertyMasterVM();
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {
                string fname, mname, lname;
                string pname = n;
                string[] arr1 = pname.Split(' ');
             
                if (arr1.Length > 0)
                {
                    fname = arr1[0];

                    var _Property = db.PropertyMasters.Where(c => c.PropertyNo == q && (string.IsNullOrEmpty(c.PropOwnerFirstName) ? " " : c.PropOwnerFirstName.ToLower()) == fname.ToLower()).FirstOrDefault();
                    if (_Property != null)
                    {
                        Master.PropertyId = _Property.PropertyId;
                        Master.PrabhagNo = _Property.PrabhagNo;
                        Master.WardName_No = _Property.WardNameNo;
                        Master.ElectionWard = _Property.ElectionWard;
                        Master.NewPropertyNo = _Property.NewPropertyNo;
                        Master.PropertyNo = _Property.PropertyNo;
                        Master.OldHouseNo1 = _Property.HouseNo;
                        Master.OldHouseNo2 = _Property.oldHouseNo2;
                        Master.NoOfTrees = _Property.NoOfTrees;
                        Master.Personalwell = _Property.Personalwell;
                        Master.HeritageTree = _Property.HeritageTree;

                        Master.WaterConnection = _Property.WaterConnection;
                        Master.NoWaterConnection = _Property.NoWaterConnection;
                        Master.STP = _Property.STP;
                        Master.FST = _Property.FST;
                        Master.STS = _Property.STS;
                        Master.Other = _Property.Other;
                        Master.SGSK = _Property.SGSK;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;
                        Master.Danger3 = _Property.Danger3;

                        Master.TotalPropertyExpense = _Property.TotalPropertyExpense;
                        Master.CurrentPropertyTax = _Property.CurrentPropertyTax;
                        Master.CurrentProperyPrice = _Property.CurrentProperyPrice;
                        Master.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                        Master.ProperyTaxPrice = _Property.ProperyTaxPrice;
                        Master.TotalTaxPrice = _Property.TotalTaxPrice;
                        Master.OpenLandtaxprice = _Property.OpenLandtaxprice;
                        Master.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                        Master.Name1 = _Property.Name1;
                        Master.Name2 = _Property.Name2;
                        Master.Name3 = _Property.Name3;
                        Master.Name4 = _Property.Name4;

                        Master.Name5 = _Property.Name5;
                        Master.Name6 = _Property.Name6;
                        Master.Name7 = _Property.Name7;
                        Master.Name8 = _Property.Name8;

                        Master.Name9 = _Property.Name9;
                        Master.Name10 = _Property.Name10;
                        Master.Name11 = _Property.Name11;
                        Master.Name12 = _Property.Name12;

                        Master.Age1 = _Property.Age1;
                        Master.Age2 = _Property.Age2;
                        Master.Age3 = _Property.Age3;
                        Master.Age4 = _Property.Age4;

                        Master.Age5 = _Property.Age5;
                        Master.Age6 = _Property.Age6;
                        Master.Age7 = _Property.Age7;
                        Master.Age8 = _Property.Age8;

                        Master.Age9 = _Property.Age9;
                        Master.Age10 = _Property.Age10;
                        Master.Age11 = _Property.Age11;
                        Master.Age12 = _Property.Age12;

                        Master.link1 = _Property.link1;
                        Master.link2 = _Property.link2;
                        Master.link3 = _Property.link3;
                        Master.link4 = _Property.link4;
                        Master.link5 = _Property.link5;
                        Master.link6 = _Property.link6;
                        Master.link7 = _Property.link7;
                        Master.link8 = _Property.link8;
                        Master.link9 = _Property.link9;
                        Master.link10 = _Property.link10;
                        Master.link11 = _Property.link11;
                        Master.link12 = _Property.link12;

                        Master.ContactNo1 = _Property.ContactNo1;
                        Master.ContactNo2 = _Property.ContactNo2;
                        Master.ContactNo3 = _Property.ContactNo3;
                        Master.ContactNo4 = _Property.ContactNo4;
                        Master.ContactNo5 = _Property.ContactNo5;
                        Master.ContactNo6 = _Property.ContactNo6;
                        Master.ContactNo7 = _Property.ContactNo7;
                        Master.ContactNo8 = _Property.ContactNo8;
                        Master.ContactNo9 = _Property.ContactNo9;
                        Master.ContactNo10 = _Property.ContactNo10;
                        Master.ContactNo11 = _Property.ContactNo11;
                        Master.ContactNo12 = _Property.ContactNo12;

                        Master.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                        Master.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                        Master.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                        Master.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                        Master.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                        Master.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                        Master.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                        Master.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                        Master.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                        Master.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                        Master.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                        Master.VoterIdentityNo12 = _Property.VoterIdentityNo12;
                        Master.SurveyNo = _Property.SurveyNo;
                        Master.GatNo = _Property.GatNo;
                        Master.CitySurveyNo = _Property.CitySurveyNo;
                        Master.AnnualRateableValue = _Property.AnnualRateableValue;
                        Master.TotalPlotArea = _Property.TotalPlotArea;
                        Master.TotalBuildupArea = _Property.TotalBuildupArea;
                        Master.MarginSpace = _Property.MarginSpace;
                        Master.BuildingName = _Property.BuildingName;
                        Master.PlotNo = _Property.PlotNo;
                        Master.FlatNo = _Property.FlatNo;
                        Master.NoofFloors = _Property.NoofFloors;
                        Master.NoofFlats = _Property.NoofFlats;
                        Master.NoofShops = _Property.NoofShops;
                        Master.PropOwnerFirstName = _Property.PropOwnerFirstName;
                        Master.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                        Master.PropOwnerLastName = _Property.PropOwnerLastName;
                        Master.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                        Master.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                        Master.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                        Master.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                        Master.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                        Master.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                        Master.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                        Master.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                        Master.PropOwnerLastName4 = _Property.PropOwnerLastName4;
                        Master.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                        Master.PropOwnerElectionCardNo = _Property.PropOwnerMobileNo;
                        Master.PropOwnerEmailId = _Property.PropOwnerEmailId;
                        Master.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                        Master.OccupierFirstName = _Property.OccupierFirstName;
                        Master.OccupierMiddleName = _Property.OccupierMiddleName;
                        Master.OccupierLastName = _Property.OccupierLastName;
                        Master.OccupierMobileNo = _Property.OccupierMobileNo;
                        Master.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                        Master.TenantName = _Property.TenantName;
                        Master.Rent = _Property.Rent;
                        Master.TenantMobileNo = _Property.TenantMobileNo;
                        Master.TenantAdhaarNo = _Property.TenantAdhaarNo;
                        Master.Address = _Property.Address;
                        Master.Longitude = _Property.Longitude;
                        Master.Latitude = _Property.Latitude;
                        Master.ConstStartYear = _Property.ConstStartYear;
                        Master.CompletionYear = _Property.CompletionYear;
                        Master.Age = _Property.Age;
                        Master.Usage = _Property.Usage;
                        Master.TypeofBldg = _Property.TypeofBldg;
                        Master.ConstPermNo = _Property.ConstPermNo;
                        Master.PermUseNo = _Property.PermUseNo;
                        Master.Rainwaterharvest = _Property.Rainwaterharvest;
                        Master.NonRainwaterharvest = _Property.NonRainwaterharvest;
                        Master.SolarWaterheater = _Property.SolarWaterheater;
                        Master.VermicultureProject = _Property.VermicultureProject;
                        Master.SWHRemark = _Property.SWHRemark;
                        Master.WaterConnectionResidential = _Property.WaterConnectionResidential;
                        Master.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Borewell = _Property.Borewell;
                        Master.NonBorewellr = _Property.NonBorewellr;
                        Master.NoofToilets = _Property.NoofToilets;
                        Master.LocationofToiletResidential = _Property.LocationofToiletResidential;
                        Master.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                        Master.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                        Master.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                        Master.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                        Master.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                        Master.UnderGroundGutter = _Property.UnderGroundGutter;
                        Master.OpenGutter = _Property.OpenGutter;
                        Master.DoorLockIndustrial = _Property.DoorLockIndustrial;
                        Master.DoorLockResidential = _Property.DoorLockResidential;
                        Master.DoorLockSpecial = _Property.DoorLockSpecial;
                        Master.PermanentDoorLock = _Property.PermanentDoorLock;
                        Master.OuterMeasurement = _Property.OuterMeasurement;
                        Master.Lift = _Property.Lift;
                        Master.Remarks = _Property.Remarks;
                        Master.FloorNo1 = _Property.FloorNo1;
                        Master.OccupancyStatus1 = _Property.OccupancyStatus1;
                        Master.ConstType1 = _Property.ConstType1;
                        Master.DateofConstruction1 = _Property.DateofConstruction1;
                        Master.DateofConstruction2 = _Property.DateofConstruction2;
                        Master.DateofConstruction3 = _Property.DateofConstruction3;
                        Master.DateofConstruction4 = _Property.DateofConstruction4;
                        Master.DateofConstruction5 = _Property.DateofConstruction5;

                        //if(_Property.DateofConstruction1 !=null)
                        //{ 
                        //Master.DateofConstruction1 = Convert.ToDateTime(_Property.DateofConstruction1).ToString("dd-MM-yyyy");
                        //}

                        //else
                        //{
                        //    Master.DateofConstruction1 = "--Select Date--";
                        //}

                        //if (_Property.DateofConstruction2 != null)
                        //{
                        //    Master.DateofConstruction2 = Convert.ToDateTime(_Property.DateofConstruction2).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction2 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction4 != null)
                        //{
                        //    Master.DateofConstruction4 = Convert.ToDateTime(_Property.DateofConstruction4).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction4 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction5 != null)
                        //{
                        //    Master.DateofConstruction5 = Convert.ToDateTime(_Property.DateofConstruction5).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction5 = "--Select Date--";
                        //}
                        Master.UsageType1 = _Property.UsageType1;
                        Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                        Master.Legal1 = _Property.Legal1;
                        Master.CarpetArea1 = _Property.CarpetArea1;
                        Master.BuildupArea1 = _Property.BuildupArea1;
                        Master.FloorNo2 = _Property.FloorNo2;
                        Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                        Master.ConstType2 = _Property.ConstType2;

                        Master.UsageType2 = _Property.UsageType2;
                        Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                        Master.Legal2 = _Property.Legal2;
                        Master.CarpetArea2 = _Property.CarpetArea2;
                        Master.BuildupArea2 = _Property.BuildupArea2;
                        Master.FloorNo3 = _Property.FloorNo3;
                        Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                        Master.ConstType3 = _Property.ConstType3;

                        Master.UsageType3 = _Property.UsageType3;
                        Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                        Master.Legal3 = _Property.Legal3;
                        Master.CarpetArea3 = _Property.CarpetArea3;
                        Master.BuildupArea3 = _Property.BuildupArea3;
                        Master.FloorNo4 = _Property.FloorNo4;
                        Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                        Master.ConstType4 = _Property.ConstType4;

                        Master.UsageType4 = _Property.UsageType4;
                        Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                        Master.Legal4 = _Property.Legal4;
                        Master.CarpetArea4 = _Property.CarpetArea4;
                        Master.BuildupArea4 = _Property.BuildupArea4;
                        Master.FloorNo5 = _Property.FloorNo5;
                        Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                        Master.ConstType5 = _Property.ConstType5;

                        Master.UsageType5 = _Property.UsageType5;
                        Master.UsageTypeClass5 = _Property.UsageTypeClass5;
                        Master.Legal5 = _Property.Legal5;
                        Master.CarpetArea5 = _Property.CarpetArea5;
                        Master.BuildupArea5 = _Property.BuildupArea5;
                        Master.totaltax = _Property.totaltax;
                        Master.totalBuildupArea1 = _Property.totalBuildupArea1;
                        Master.totalCarpetArea = _Property.totalCarpetArea;
                        Master.totaltax = _Property.totaltax;
                        Master.OldUsageType = _Property.OldUsageType;
                        Master.OldConstructionType = _Property.OldConstructionType;
                        Master.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                        Master.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                        Master.NewUsageType = _Property.NewUsageType;
                        Master.NewConstructionType = _Property.NewConstructionType;
                        Master.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                        Master.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                        Master.ExtendUsage_Type = _Property.ExtendUsageType;
                        Master.ExtendConstructionType = _Property.ExtendConstructionType;
                        Master.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                        Master.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                        Master.PropertyType = _Property.PropertyType;
                        Master.SurveyorName = _Property.SurveyorName;
                        Master.SurveyorSignature = _Property.SurveyorSignature;

                        if (_Property.SurveyorDate != null)
                        {
                            Master.SurveyorDate = Convert.ToDateTime(_Property.SurveyorDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.SurveyorDate = "--Select Date--";
                        }
                        if (_Property.DataEntryDate != null)
                        {
                            Master.DataEntryDate = Convert.ToDateTime(_Property.DataEntryDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.DataEntryDate = "--Select Date--";
                        }
                        Master.DataEntryName = _Property.DataEntryName;
                        Master.DataEntrySignature = _Property.DataEntrySignature;

                        Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                        Master.NonVermicultureProject = _Property.NonVermicultureProject;
                        Master.NoLift = _Property.NoLift;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Sketchdiagram = _Property.Sketchdiagram;
                        Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                        Master.ZoneNo = _Property.ZoneNo;
                        Master.VillageName = _Property.VillageName;
                        Master.HFSNo = _Property.HFSNo;
                        Master.Legal = _Property.Legal;
                        Master.HissaNo = _Property.HissaNo;
                        Master.OldRateableValue = _Property.OldRateableValue;
                        Master.OldTotalTax = _Property.OldTotalTax;
                        Master.FirstAssessmentYear = _Property.FirstAssessmentYear;
                        Master.ImageNo = _Property.ImageNo;
                        Master.WardName_No2 = _Property.WardNameNo2;
                        Master.ZoneNo2 = _Property.ZoneNo2;
                        Master.FHNo = _Property.FHNo;
                        Master.PropertyType2 = _Property.PropertyType2;
                        Master.NewPropertyNo2 = _Property.NewPropertyNo2;
                        Master.PropertyNo2 = _Property.PropertyNo2;
                        Master.GarbageType = _Property.GarbageType;
                        Master.NOGarbageType = _Property.NOGarbageType;
                        Master.PrabhagNo2 = _Property.PrabhagNo2;
                        Master.YConstPermNo = _Property.YConstPermNo;
                        Master.NConstPermNo = _Property.NConstPermNo;
                        Master.YPermUseNo = _Property.YPermUseNo;
                        Master.NPermUseNo = _Property.NPermUseNo;


                        Master.ZKMKG = _Property.ZKMKG;
                        Master.DVMKG = _Property.DVMKG;
                        Master.ThirdPT = _Property.ThirdPT;
                        Master.FourthPT = _Property.FourthPT;
                        Master.FifthPT = _Property.FifthPT;
                        Master.SixPT = _Property.SixPT;
                        Master.SevenPT = _Property.SevenPT;
                        Master.EightPT = _Property.EightPT;
                        Master.NinePT = _Property.NinePT;
                        Master.TenPT = _Property.TenPT;
                        Master.ElevenPT = _Property.ElevenPT;
                        Master.TwelvePT = _Property.TwelvePT;
                        Master.TherteenPT = _Property.TherteenPT;
                        Master.FourteenPT = _Property.FourteenPT;
                        Master.FifteenPT = _Property.FifteenPT;
                        Master.SixteenPT = _Property.SixteenPT;
                        Master.seventeenPT = _Property.seventeenPT;
                        Master.FirstRPC = _Property.FirstRPC;
                        Master.SecondRPC = _Property.SecondRPC;
                        Master.ThirdRPC = _Property.ThirdRPC;
                        Master.FourthRPC = _Property.FourthRPC;
                        Master.FifthRPC = _Property.FifthRPC;
                        Master.SixRPC = _Property.SixRPC;
                        Master.SevenRPC = _Property.SevenRPC;
                        Master.EightRPC = _Property.EightRPC;
                        Master.NineRPC = _Property.NineRPC;
                        Master.TenRPC = _Property.TenRPC;
                        Master.ElevenRPC = _Property.ElevenRPC;
                        Master.TwelveRPC = _Property.TwelveRPC;
                        Master.ThirteenRPC = _Property.ThirteenRPC;
                        Master.FirstCPC = _Property.FirstCPC;
                        Master.SecondCPC = _Property.SecondCPC;
                        Master.ThirdCPC = _Property.ThirdCPC;
                        Master.FourthCPC = _Property.FourthCPC;
                        Master.FifthCPC = _Property.FifthCPC;
                        Master.SixCPC = _Property.SixCPC;
                        Master.SevenCPC = _Property.SevenCPC;
                        Master.EightCPC = _Property.EightCPC;

                        Master.NineCPC = _Property.NineCPC;
                        Master.TenCPC = _Property.TenCPC;
                        Master.ElevenCPC = _Property.ElevenCPC;
                        Master.TwelveCPC = _Property.TwelveCPC;
                        Master.ThirteenCPC = _Property.ThirteenCPC;
                        Master.FourteenCPC = _Property.FourteenCPC;
                    }
                }
                if (arr1.Length > 1)
                {
                    fname = arr1[0];
                    mname = arr1[1];
                    var _Property = db.PropertyMasters.Where(x => x.PropertyNo == q && (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower()  && (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName.ToLower()) == mname.ToLower()).FirstOrDefault();
                    if (_Property != null)
                    {
                        Master.PropertyId = _Property.PropertyId;
                        Master.PrabhagNo = _Property.PrabhagNo;
                        Master.WardName_No = _Property.WardNameNo;
                        Master.ElectionWard = _Property.ElectionWard;
                        Master.NewPropertyNo = _Property.NewPropertyNo;
                        Master.PropertyNo = _Property.PropertyNo;
                        Master.OldHouseNo1 = _Property.HouseNo;
                        Master.OldHouseNo2 = _Property.oldHouseNo2;
                        Master.NoOfTrees = _Property.NoOfTrees;
                        Master.Personalwell = _Property.Personalwell;
                        Master.HeritageTree = _Property.HeritageTree;

                        Master.WaterConnection = _Property.WaterConnection;
                        Master.NoWaterConnection = _Property.NoWaterConnection;
                        Master.STP = _Property.STP;
                        Master.FST = _Property.FST;
                        Master.STS = _Property.STS;
                        Master.Other = _Property.Other;
                        Master.SGSK = _Property.SGSK;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;
                        Master.Danger3 = _Property.Danger3;

                        Master.TotalPropertyExpense = _Property.TotalPropertyExpense;
                        Master.CurrentPropertyTax = _Property.CurrentPropertyTax;
                        Master.CurrentProperyPrice = _Property.CurrentProperyPrice;
                        Master.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                        Master.ProperyTaxPrice = _Property.ProperyTaxPrice;
                        Master.TotalTaxPrice = _Property.TotalTaxPrice;
                        Master.OpenLandtaxprice = _Property.OpenLandtaxprice;
                        Master.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                        Master.Name1 = _Property.Name1;
                        Master.Name2 = _Property.Name2;
                        Master.Name3 = _Property.Name3;
                        Master.Name4 = _Property.Name4;

                        Master.Name5 = _Property.Name5;
                        Master.Name6 = _Property.Name6;
                        Master.Name7 = _Property.Name7;
                        Master.Name8 = _Property.Name8;

                        Master.Name9 = _Property.Name9;
                        Master.Name10 = _Property.Name10;
                        Master.Name11 = _Property.Name11;
                        Master.Name12 = _Property.Name12;

                        Master.Age1 = _Property.Age1;
                        Master.Age2 = _Property.Age2;
                        Master.Age3 = _Property.Age3;
                        Master.Age4 = _Property.Age4;

                        Master.Age5 = _Property.Age5;
                        Master.Age6 = _Property.Age6;
                        Master.Age7 = _Property.Age7;
                        Master.Age8 = _Property.Age8;

                        Master.Age9 = _Property.Age9;
                        Master.Age10 = _Property.Age10;
                        Master.Age11 = _Property.Age11;
                        Master.Age12 = _Property.Age12;

                        Master.link1 = _Property.link1;
                        Master.link2 = _Property.link2;
                        Master.link3 = _Property.link3;
                        Master.link4 = _Property.link4;
                        Master.link5 = _Property.link5;
                        Master.link6 = _Property.link6;
                        Master.link7 = _Property.link7;
                        Master.link8 = _Property.link8;
                        Master.link9 = _Property.link9;
                        Master.link10 = _Property.link10;
                        Master.link11 = _Property.link11;
                        Master.link12 = _Property.link12;

                        Master.ContactNo1 = _Property.ContactNo1;
                        Master.ContactNo2 = _Property.ContactNo2;
                        Master.ContactNo3 = _Property.ContactNo3;
                        Master.ContactNo4 = _Property.ContactNo4;
                        Master.ContactNo5 = _Property.ContactNo5;
                        Master.ContactNo6 = _Property.ContactNo6;
                        Master.ContactNo7 = _Property.ContactNo7;
                        Master.ContactNo8 = _Property.ContactNo8;
                        Master.ContactNo9 = _Property.ContactNo9;
                        Master.ContactNo10 = _Property.ContactNo10;
                        Master.ContactNo11 = _Property.ContactNo11;
                        Master.ContactNo12 = _Property.ContactNo12;

                        Master.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                        Master.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                        Master.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                        Master.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                        Master.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                        Master.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                        Master.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                        Master.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                        Master.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                        Master.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                        Master.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                        Master.VoterIdentityNo12 = _Property.VoterIdentityNo12;
                        Master.SurveyNo = _Property.SurveyNo;
                        Master.GatNo = _Property.GatNo;
                        Master.CitySurveyNo = _Property.CitySurveyNo;
                        Master.AnnualRateableValue = _Property.AnnualRateableValue;
                        Master.TotalPlotArea = _Property.TotalPlotArea;
                        Master.TotalBuildupArea = _Property.TotalBuildupArea;
                        Master.MarginSpace = _Property.MarginSpace;
                        Master.BuildingName = _Property.BuildingName;
                        Master.PlotNo = _Property.PlotNo;
                        Master.FlatNo = _Property.FlatNo;
                        Master.NoofFloors = _Property.NoofFloors;
                        Master.NoofFlats = _Property.NoofFlats;
                        Master.NoofShops = _Property.NoofShops;
                        Master.PropOwnerFirstName = _Property.PropOwnerFirstName;
                        Master.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                        Master.PropOwnerLastName = _Property.PropOwnerLastName;
                        Master.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                        Master.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                        Master.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                        Master.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                        Master.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                        Master.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                        Master.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                        Master.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                        Master.PropOwnerLastName4 = _Property.PropOwnerLastName4;
                        Master.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                        Master.PropOwnerElectionCardNo = _Property.PropOwnerMobileNo;
                        Master.PropOwnerEmailId = _Property.PropOwnerEmailId;
                        Master.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                        Master.OccupierFirstName = _Property.OccupierFirstName;
                        Master.OccupierMiddleName = _Property.OccupierMiddleName;
                        Master.OccupierLastName = _Property.OccupierLastName;
                        Master.OccupierMobileNo = _Property.OccupierMobileNo;
                        Master.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                        Master.TenantName = _Property.TenantName;
                        Master.Rent = _Property.Rent;
                        Master.TenantMobileNo = _Property.TenantMobileNo;
                        Master.TenantAdhaarNo = _Property.TenantAdhaarNo;
                        Master.Address = _Property.Address;
                        Master.Longitude = _Property.Longitude;
                        Master.Latitude = _Property.Latitude;
                        Master.ConstStartYear = _Property.ConstStartYear;
                        Master.CompletionYear = _Property.CompletionYear;
                        Master.Age = _Property.Age;
                        Master.Usage = _Property.Usage;
                        Master.TypeofBldg = _Property.TypeofBldg;
                        Master.ConstPermNo = _Property.ConstPermNo;
                        Master.PermUseNo = _Property.PermUseNo;
                        Master.Rainwaterharvest = _Property.Rainwaterharvest;
                        Master.NonRainwaterharvest = _Property.NonRainwaterharvest;
                        Master.SolarWaterheater = _Property.SolarWaterheater;
                        Master.VermicultureProject = _Property.VermicultureProject;
                        Master.SWHRemark = _Property.SWHRemark;
                        Master.WaterConnectionResidential = _Property.WaterConnectionResidential;
                        Master.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Borewell = _Property.Borewell;
                        Master.NonBorewellr = _Property.NonBorewellr;
                        Master.NoofToilets = _Property.NoofToilets;
                        Master.LocationofToiletResidential = _Property.LocationofToiletResidential;
                        Master.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                        Master.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                        Master.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                        Master.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                        Master.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                        Master.UnderGroundGutter = _Property.UnderGroundGutter;
                        Master.OpenGutter = _Property.OpenGutter;
                        Master.DoorLockIndustrial = _Property.DoorLockIndustrial;
                        Master.DoorLockResidential = _Property.DoorLockResidential;
                        Master.DoorLockSpecial = _Property.DoorLockSpecial;
                        Master.PermanentDoorLock = _Property.PermanentDoorLock;
                        Master.OuterMeasurement = _Property.OuterMeasurement;
                        Master.Lift = _Property.Lift;
                        Master.Remarks = _Property.Remarks;
                        Master.FloorNo1 = _Property.FloorNo1;
                        Master.OccupancyStatus1 = _Property.OccupancyStatus1;
                        Master.ConstType1 = _Property.ConstType1;
                        Master.DateofConstruction1 = _Property.DateofConstruction1;
                        Master.DateofConstruction2 = _Property.DateofConstruction2;
                        Master.DateofConstruction3 = _Property.DateofConstruction3;
                        Master.DateofConstruction4 = _Property.DateofConstruction4;
                        Master.DateofConstruction5 = _Property.DateofConstruction5;

                        //if(_Property.DateofConstruction1 !=null)
                        //{ 
                        //Master.DateofConstruction1 = Convert.ToDateTime(_Property.DateofConstruction1).ToString("dd-MM-yyyy");
                        //}

                        //else
                        //{
                        //    Master.DateofConstruction1 = "--Select Date--";
                        //}

                        //if (_Property.DateofConstruction2 != null)
                        //{
                        //    Master.DateofConstruction2 = Convert.ToDateTime(_Property.DateofConstruction2).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction2 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction4 != null)
                        //{
                        //    Master.DateofConstruction4 = Convert.ToDateTime(_Property.DateofConstruction4).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction4 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction5 != null)
                        //{
                        //    Master.DateofConstruction5 = Convert.ToDateTime(_Property.DateofConstruction5).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction5 = "--Select Date--";
                        //}
                        Master.UsageType1 = _Property.UsageType1;
                        Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                        Master.Legal1 = _Property.Legal1;
                        Master.CarpetArea1 = _Property.CarpetArea1;
                        Master.BuildupArea1 = _Property.BuildupArea1;
                        Master.FloorNo2 = _Property.FloorNo2;
                        Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                        Master.ConstType2 = _Property.ConstType2;

                        Master.UsageType2 = _Property.UsageType2;
                        Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                        Master.Legal2 = _Property.Legal2;
                        Master.CarpetArea2 = _Property.CarpetArea2;
                        Master.BuildupArea2 = _Property.BuildupArea2;
                        Master.FloorNo3 = _Property.FloorNo3;
                        Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                        Master.ConstType3 = _Property.ConstType3;

                        Master.UsageType3 = _Property.UsageType3;
                        Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                        Master.Legal3 = _Property.Legal3;
                        Master.CarpetArea3 = _Property.CarpetArea3;
                        Master.BuildupArea3 = _Property.BuildupArea3;
                        Master.FloorNo4 = _Property.FloorNo4;
                        Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                        Master.ConstType4 = _Property.ConstType4;

                        Master.UsageType4 = _Property.UsageType4;
                        Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                        Master.Legal4 = _Property.Legal4;
                        Master.CarpetArea4 = _Property.CarpetArea4;
                        Master.BuildupArea4 = _Property.BuildupArea4;
                        Master.FloorNo5 = _Property.FloorNo5;
                        Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                        Master.ConstType5 = _Property.ConstType5;

                        Master.UsageType5 = _Property.UsageType5;
                        Master.UsageTypeClass5 = _Property.UsageTypeClass5;
                        Master.Legal5 = _Property.Legal5;
                        Master.CarpetArea5 = _Property.CarpetArea5;
                        Master.BuildupArea5 = _Property.BuildupArea5;
                        Master.totaltax = _Property.totaltax;
                        Master.totalBuildupArea1 = _Property.totalBuildupArea1;
                        Master.totalCarpetArea = _Property.totalCarpetArea;
                        Master.totaltax = _Property.totaltax;
                        Master.OldUsageType = _Property.OldUsageType;
                        Master.OldConstructionType = _Property.OldConstructionType;
                        Master.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                        Master.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                        Master.NewUsageType = _Property.NewUsageType;
                        Master.NewConstructionType = _Property.NewConstructionType;
                        Master.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                        Master.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                        Master.ExtendUsage_Type = _Property.ExtendUsageType;
                        Master.ExtendConstructionType = _Property.ExtendConstructionType;
                        Master.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                        Master.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                        Master.PropertyType = _Property.PropertyType;
                        Master.SurveyorName = _Property.SurveyorName;
                        Master.SurveyorSignature = _Property.SurveyorSignature;

                        if (_Property.SurveyorDate != null)
                        {
                            Master.SurveyorDate = Convert.ToDateTime(_Property.SurveyorDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.SurveyorDate = "--Select Date--";
                        }
                        if (_Property.DataEntryDate != null)
                        {
                            Master.DataEntryDate = Convert.ToDateTime(_Property.DataEntryDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.DataEntryDate = "--Select Date--";
                        }
                        Master.DataEntryName = _Property.DataEntryName;
                        Master.DataEntrySignature = _Property.DataEntrySignature;

                        Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                        Master.NonVermicultureProject = _Property.NonVermicultureProject;
                        Master.NoLift = _Property.NoLift;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Sketchdiagram = _Property.Sketchdiagram;
                        Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                        Master.ZoneNo = _Property.ZoneNo;
                        Master.VillageName = _Property.VillageName;
                        Master.HFSNo = _Property.HFSNo;
                        Master.Legal = _Property.Legal;
                        Master.HissaNo = _Property.HissaNo;
                        Master.OldRateableValue = _Property.OldRateableValue;
                        Master.OldTotalTax = _Property.OldTotalTax;
                        Master.FirstAssessmentYear = _Property.FirstAssessmentYear;
                        Master.ImageNo = _Property.ImageNo;
                        Master.WardName_No2 = _Property.WardNameNo2;
                        Master.ZoneNo2 = _Property.ZoneNo2;
                        Master.FHNo = _Property.FHNo;
                        Master.PropertyType2 = _Property.PropertyType2;
                        Master.NewPropertyNo2 = _Property.NewPropertyNo2;
                        Master.PropertyNo2 = _Property.PropertyNo2;
                        Master.GarbageType = _Property.GarbageType;
                        Master.NOGarbageType = _Property.NOGarbageType;
                        Master.PrabhagNo2 = _Property.PrabhagNo2;
                        Master.YConstPermNo = _Property.YConstPermNo;
                        Master.NConstPermNo = _Property.NConstPermNo;
                        Master.YPermUseNo = _Property.YPermUseNo;
                        Master.NPermUseNo = _Property.NPermUseNo;


                        Master.ZKMKG = _Property.ZKMKG;
                        Master.DVMKG = _Property.DVMKG;
                        Master.ThirdPT = _Property.ThirdPT;
                        Master.FourthPT = _Property.FourthPT;
                        Master.FifthPT = _Property.FifthPT;
                        Master.SixPT = _Property.SixPT;
                        Master.SevenPT = _Property.SevenPT;
                        Master.EightPT = _Property.EightPT;
                        Master.NinePT = _Property.NinePT;
                        Master.TenPT = _Property.TenPT;
                        Master.ElevenPT = _Property.ElevenPT;
                        Master.TwelvePT = _Property.TwelvePT;
                        Master.TherteenPT = _Property.TherteenPT;
                        Master.FourteenPT = _Property.FourteenPT;
                        Master.FifteenPT = _Property.FifteenPT;
                        Master.SixteenPT = _Property.SixteenPT;
                        Master.seventeenPT = _Property.seventeenPT;
                        Master.FirstRPC = _Property.FirstRPC;
                        Master.SecondRPC = _Property.SecondRPC;
                        Master.ThirdRPC = _Property.ThirdRPC;
                        Master.FourthRPC = _Property.FourthRPC;
                        Master.FifthRPC = _Property.FifthRPC;
                        Master.SixRPC = _Property.SixRPC;
                        Master.SevenRPC = _Property.SevenRPC;
                        Master.EightRPC = _Property.EightRPC;
                        Master.NineRPC = _Property.NineRPC;
                        Master.TenRPC = _Property.TenRPC;
                        Master.ElevenRPC = _Property.ElevenRPC;
                        Master.TwelveRPC = _Property.TwelveRPC;
                        Master.ThirteenRPC = _Property.ThirteenRPC;
                        Master.FirstCPC = _Property.FirstCPC;
                        Master.SecondCPC = _Property.SecondCPC;
                        Master.ThirdCPC = _Property.ThirdCPC;
                        Master.FourthCPC = _Property.FourthCPC;
                        Master.FifthCPC = _Property.FifthCPC;
                        Master.SixCPC = _Property.SixCPC;
                        Master.SevenCPC = _Property.SevenCPC;
                        Master.EightCPC = _Property.EightCPC;

                        Master.NineCPC = _Property.NineCPC;
                        Master.TenCPC = _Property.TenCPC;
                        Master.ElevenCPC = _Property.ElevenCPC;
                        Master.TwelveCPC = _Property.TwelveCPC;
                        Master.ThirteenCPC = _Property.ThirteenCPC;
                        Master.FourteenCPC = _Property.FourteenCPC;
                    }
                }
                if (arr1.Length > 2)
                {
                    fname = arr1[0];
                    lname = arr1[2];
                    var _Property = db.PropertyMasters.Where(x => x.PropertyNo == q && (string.IsNullOrEmpty(x.PropOwnerFirstName) ? " " : x.PropOwnerFirstName.ToLower()) == fname.ToLower() && (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName.ToLower()) == lname.ToLower()).FirstOrDefault();


                    if (_Property != null)
                    {
                        Master.PropertyId = _Property.PropertyId;
                        Master.PrabhagNo = _Property.PrabhagNo;
                        Master.WardName_No = _Property.WardNameNo;
                        Master.ElectionWard = _Property.ElectionWard;
                        Master.NewPropertyNo = _Property.NewPropertyNo;
                        Master.PropertyNo = _Property.PropertyNo;
                        Master.OldHouseNo1 = _Property.HouseNo;
                        Master.OldHouseNo2 = _Property.oldHouseNo2;
                        Master.NoOfTrees = _Property.NoOfTrees;
                        Master.Personalwell = _Property.Personalwell;
                        Master.HeritageTree = _Property.HeritageTree;

                        Master.WaterConnection = _Property.WaterConnection;
                        Master.NoWaterConnection = _Property.NoWaterConnection;
                        Master.STP = _Property.STP;
                        Master.FST = _Property.FST;
                        Master.STS = _Property.STS;
                        Master.Other = _Property.Other;
                        Master.SGSK = _Property.SGSK;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;

                        Master.NOSGSK = _Property.NOSGSK;
                        Master.OtherGutter = _Property.OtherGutter;
                        Master.NaturalMethod = _Property.NaturalMethod;
                        Master.ArtifitialMethod = _Property.ArtifitialMethod;
                        Master.OtherMethod = _Property.OtherMethod;
                        Master.NoProject = _Property.NoProject;
                        Master.Safe = _Property.Safe;
                        Master.Danger = _Property.Danger;
                        Master.Safe2 = _Property.Safe2;
                        Master.Danger2 = _Property.Danger2;
                        Master.Safe3 = _Property.Safe3;
                        Master.Danger3 = _Property.Danger3;

                        Master.TotalPropertyExpense = _Property.TotalPropertyExpense;
                        Master.CurrentPropertyTax = _Property.CurrentPropertyTax;
                        Master.CurrentProperyPrice = _Property.CurrentProperyPrice;
                        Master.OpenAroundLandtaxprice = _Property.OpenAroundLandtaxprice;
                        Master.ProperyTaxPrice = _Property.ProperyTaxPrice;
                        Master.TotalTaxPrice = _Property.TotalTaxPrice;
                        Master.OpenLandtaxprice = _Property.OpenLandtaxprice;
                        Master.ProperyTaxMarketPrice = _Property.ProperyTaxMarketPrice;
                        Master.Name1 = _Property.Name1;
                        Master.Name2 = _Property.Name2;
                        Master.Name3 = _Property.Name3;
                        Master.Name4 = _Property.Name4;

                        Master.Name5 = _Property.Name5;
                        Master.Name6 = _Property.Name6;
                        Master.Name7 = _Property.Name7;
                        Master.Name8 = _Property.Name8;

                        Master.Name9 = _Property.Name9;
                        Master.Name10 = _Property.Name10;
                        Master.Name11 = _Property.Name11;
                        Master.Name12 = _Property.Name12;

                        Master.Age1 = _Property.Age1;
                        Master.Age2 = _Property.Age2;
                        Master.Age3 = _Property.Age3;
                        Master.Age4 = _Property.Age4;

                        Master.Age5 = _Property.Age5;
                        Master.Age6 = _Property.Age6;
                        Master.Age7 = _Property.Age7;
                        Master.Age8 = _Property.Age8;

                        Master.Age9 = _Property.Age9;
                        Master.Age10 = _Property.Age10;
                        Master.Age11 = _Property.Age11;
                        Master.Age12 = _Property.Age12;

                        Master.link1 = _Property.link1;
                        Master.link2 = _Property.link2;
                        Master.link3 = _Property.link3;
                        Master.link4 = _Property.link4;
                        Master.link5 = _Property.link5;
                        Master.link6 = _Property.link6;
                        Master.link7 = _Property.link7;
                        Master.link8 = _Property.link8;
                        Master.link9 = _Property.link9;
                        Master.link10 = _Property.link10;
                        Master.link11 = _Property.link11;
                        Master.link12 = _Property.link12;

                        Master.ContactNo1 = _Property.ContactNo1;
                        Master.ContactNo2 = _Property.ContactNo2;
                        Master.ContactNo3 = _Property.ContactNo3;
                        Master.ContactNo4 = _Property.ContactNo4;
                        Master.ContactNo5 = _Property.ContactNo5;
                        Master.ContactNo6 = _Property.ContactNo6;
                        Master.ContactNo7 = _Property.ContactNo7;
                        Master.ContactNo8 = _Property.ContactNo8;
                        Master.ContactNo9 = _Property.ContactNo9;
                        Master.ContactNo10 = _Property.ContactNo10;
                        Master.ContactNo11 = _Property.ContactNo11;
                        Master.ContactNo12 = _Property.ContactNo12;

                        Master.VoterIdentityNo1 = _Property.VoterIdentityNo1;
                        Master.VoterIdentityNo2 = _Property.VoterIdentityNo2;
                        Master.VoterIdentityNo3 = _Property.VoterIdentityNo3;
                        Master.VoterIdentityNo4 = _Property.VoterIdentityNo4;
                        Master.VoterIdentityNo5 = _Property.VoterIdentityNo5;
                        Master.VoterIdentityNo6 = _Property.VoterIdentityNo6;
                        Master.VoterIdentityNo7 = _Property.VoterIdentityNo7;
                        Master.VoterIdentityNo8 = _Property.VoterIdentityNo8;
                        Master.VoterIdentityNo9 = _Property.VoterIdentityNo9;
                        Master.VoterIdentityNo10 = _Property.VoterIdentityNo10;
                        Master.VoterIdentityNo11 = _Property.VoterIdentityNo11;
                        Master.VoterIdentityNo12 = _Property.VoterIdentityNo12;
                        Master.SurveyNo = _Property.SurveyNo;
                        Master.GatNo = _Property.GatNo;
                        Master.CitySurveyNo = _Property.CitySurveyNo;
                        Master.AnnualRateableValue = _Property.AnnualRateableValue;
                        Master.TotalPlotArea = _Property.TotalPlotArea;
                        Master.TotalBuildupArea = _Property.TotalBuildupArea;
                        Master.MarginSpace = _Property.MarginSpace;
                        Master.BuildingName = _Property.BuildingName;
                        Master.PlotNo = _Property.PlotNo;
                        Master.FlatNo = _Property.FlatNo;
                        Master.NoofFloors = _Property.NoofFloors;
                        Master.NoofFlats = _Property.NoofFlats;
                        Master.NoofShops = _Property.NoofShops;
                        Master.PropOwnerFirstName = _Property.PropOwnerFirstName;
                        Master.PropOwnerMiddleName = _Property.PropOwnerMiddleName;
                        Master.PropOwnerLastName = _Property.PropOwnerLastName;
                        Master.PropOwnerFirstName2 = _Property.PropOwnerFirstName2;
                        Master.PropOwnerMiddleName2 = _Property.PropOwnerMiddleName2;
                        Master.PropOwnerLastName2 = _Property.PropOwnerLastName2;

                        Master.PropOwnerFirstName3 = _Property.PropOwnerFirstName3;
                        Master.PropOwnerMiddleName3 = _Property.PropOwnerMiddleName3;
                        Master.PropOwnerLastName3 = _Property.PropOwnerLastName3;

                        Master.PropOwnerFirstName4 = _Property.PropOwnerFirstName4;
                        Master.PropOwnerMiddleName4 = _Property.PropOwnerMiddleName4;
                        Master.PropOwnerLastName4 = _Property.PropOwnerLastName4;
                        Master.PropOwnerTelephoneNo = _Property.PropOwnerTelephoneNo;
                        Master.PropOwnerElectionCardNo = _Property.PropOwnerMobileNo;
                        Master.PropOwnerEmailId = _Property.PropOwnerEmailId;
                        Master.PropOwnerAdhaarNo = _Property.PropOwnerAdhaarNo;
                        Master.OccupierFirstName = _Property.OccupierFirstName;
                        Master.OccupierMiddleName = _Property.OccupierMiddleName;
                        Master.OccupierLastName = _Property.OccupierLastName;
                        Master.OccupierMobileNo = _Property.OccupierMobileNo;
                        Master.OccupierAdhaarNo = _Property.OccupierAdhaarNo;
                        Master.TenantName = _Property.TenantName;
                        Master.Rent = _Property.Rent;
                        Master.TenantMobileNo = _Property.TenantMobileNo;
                        Master.TenantAdhaarNo = _Property.TenantAdhaarNo;
                        Master.Address = _Property.Address;
                        Master.Longitude = _Property.Longitude;
                        Master.Latitude = _Property.Latitude;
                        Master.ConstStartYear = _Property.ConstStartYear;
                        Master.CompletionYear = _Property.CompletionYear;
                        Master.Age = _Property.Age;
                        Master.Usage = _Property.Usage;
                        Master.TypeofBldg = _Property.TypeofBldg;
                        Master.ConstPermNo = _Property.ConstPermNo;
                        Master.PermUseNo = _Property.PermUseNo;
                        Master.Rainwaterharvest = _Property.Rainwaterharvest;
                        Master.NonRainwaterharvest = _Property.NonRainwaterharvest;
                        Master.SolarWaterheater = _Property.SolarWaterheater;
                        Master.VermicultureProject = _Property.VermicultureProject;
                        Master.SWHRemark = _Property.SWHRemark;
                        Master.WaterConnectionResidential = _Property.WaterConnectionResidential;
                        Master.WaterConnectionIndustrial = _Property.WaterConnectionIndustrial;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Borewell = _Property.Borewell;
                        Master.NonBorewellr = _Property.NonBorewellr;
                        Master.NoofToilets = _Property.NoofToilets;
                        Master.LocationofToiletResidential = _Property.LocationofToiletResidential;
                        Master.LocationofToiletSpecial = _Property.LocationofToiletSpecial;
                        Master.LocationofToiletIndustrial = _Property.LocationofToiletIndustrial;
                        Master.ParkingFacilityIndustrial = _Property.ParkingFacilityIndustrial;
                        Master.ParkingFacilityResidential = _Property.ParkingFacilityResidential;
                        Master.ParkingFacilitySpecial = _Property.ParkingFacilitySpecial;
                        Master.UnderGroundGutter = _Property.UnderGroundGutter;
                        Master.OpenGutter = _Property.OpenGutter;
                        Master.DoorLockIndustrial = _Property.DoorLockIndustrial;
                        Master.DoorLockResidential = _Property.DoorLockResidential;
                        Master.DoorLockSpecial = _Property.DoorLockSpecial;
                        Master.PermanentDoorLock = _Property.PermanentDoorLock;
                        Master.OuterMeasurement = _Property.OuterMeasurement;
                        Master.Lift = _Property.Lift;
                        Master.Remarks = _Property.Remarks;
                        Master.FloorNo1 = _Property.FloorNo1;
                        Master.OccupancyStatus1 = _Property.OccupancyStatus1;
                        Master.ConstType1 = _Property.ConstType1;
                        Master.DateofConstruction1 = _Property.DateofConstruction1;
                        Master.DateofConstruction2 = _Property.DateofConstruction2;
                        Master.DateofConstruction3 = _Property.DateofConstruction3;
                        Master.DateofConstruction4 = _Property.DateofConstruction4;
                        Master.DateofConstruction5 = _Property.DateofConstruction5;

                        //if(_Property.DateofConstruction1 !=null)
                        //{ 
                        //Master.DateofConstruction1 = Convert.ToDateTime(_Property.DateofConstruction1).ToString("dd-MM-yyyy");
                        //}

                        //else
                        //{
                        //    Master.DateofConstruction1 = "--Select Date--";
                        //}

                        //if (_Property.DateofConstruction2 != null)
                        //{
                        //    Master.DateofConstruction2 = Convert.ToDateTime(_Property.DateofConstruction2).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction2 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction3 != null)
                        //{
                        //    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction3 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction4 != null)
                        //{
                        //    Master.DateofConstruction4 = Convert.ToDateTime(_Property.DateofConstruction4).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction4 = "--Select Date--";
                        //}


                        //if (_Property.DateofConstruction5 != null)
                        //{
                        //    Master.DateofConstruction5 = Convert.ToDateTime(_Property.DateofConstruction5).ToString("dd-MM-yyyy");
                        //}
                        //else
                        //{
                        //    Master.DateofConstruction5 = "--Select Date--";
                        //}
                        Master.UsageType1 = _Property.UsageType1;
                        Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                        Master.Legal1 = _Property.Legal1;
                        Master.CarpetArea1 = _Property.CarpetArea1;
                        Master.BuildupArea1 = _Property.BuildupArea1;
                        Master.FloorNo2 = _Property.FloorNo2;
                        Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                        Master.ConstType2 = _Property.ConstType2;

                        Master.UsageType2 = _Property.UsageType2;
                        Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                        Master.Legal2 = _Property.Legal2;
                        Master.CarpetArea2 = _Property.CarpetArea2;
                        Master.BuildupArea2 = _Property.BuildupArea2;
                        Master.FloorNo3 = _Property.FloorNo3;
                        Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                        Master.ConstType3 = _Property.ConstType3;

                        Master.UsageType3 = _Property.UsageType3;
                        Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                        Master.Legal3 = _Property.Legal3;
                        Master.CarpetArea3 = _Property.CarpetArea3;
                        Master.BuildupArea3 = _Property.BuildupArea3;
                        Master.FloorNo4 = _Property.FloorNo4;
                        Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                        Master.ConstType4 = _Property.ConstType4;

                        Master.UsageType4 = _Property.UsageType4;
                        Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                        Master.Legal4 = _Property.Legal4;
                        Master.CarpetArea4 = _Property.CarpetArea4;
                        Master.BuildupArea4 = _Property.BuildupArea4;
                        Master.FloorNo5 = _Property.FloorNo5;
                        Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                        Master.ConstType5 = _Property.ConstType5;

                        Master.UsageType5 = _Property.UsageType5;
                        Master.UsageTypeClass5 = _Property.UsageTypeClass5;
                        Master.Legal5 = _Property.Legal5;
                        Master.CarpetArea5 = _Property.CarpetArea5;
                        Master.BuildupArea5 = _Property.BuildupArea5;
                        Master.totaltax = _Property.totaltax;
                        Master.totalBuildupArea1 = _Property.totalBuildupArea1;
                        Master.totalCarpetArea = _Property.totalCarpetArea;
                        Master.totaltax = _Property.totaltax;
                        Master.OldUsageType = _Property.OldUsageType;
                        Master.OldConstructionType = _Property.OldConstructionType;
                        Master.OldCarpetAreaResident = _Property.OldCarpetAreaResident;
                        Master.OldCarpetAreaNonResident = _Property.OldCarpetAreaNonResident;
                        Master.NewUsageType = _Property.NewUsageType;
                        Master.NewConstructionType = _Property.NewConstructionType;
                        Master.NewCarpetAreaResident = _Property.NewCarpetAreaResident;
                        Master.NewCarpetAreaNonResident = _Property.NewCarpetAreaNonResident;
                        Master.ExtendUsage_Type = _Property.ExtendUsageType;
                        Master.ExtendConstructionType = _Property.ExtendConstructionType;
                        Master.ExtendCarpetAreaResident = _Property.ExtendCarpetAreaResident;
                        Master.ExtendCarpetAreaNonResident = _Property.ExtendCarpetAreaNonResident;
                        Master.PropertyType = _Property.PropertyType;
                        Master.SurveyorName = _Property.SurveyorName;
                        Master.SurveyorSignature = _Property.SurveyorSignature;

                        if (_Property.SurveyorDate != null)
                        {
                            Master.SurveyorDate = Convert.ToDateTime(_Property.SurveyorDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.SurveyorDate = "--Select Date--";
                        }
                        if (_Property.DataEntryDate != null)
                        {
                            Master.DataEntryDate = Convert.ToDateTime(_Property.DataEntryDate).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            Master.DataEntryDate = "--Select Date--";
                        }
                        Master.DataEntryName = _Property.DataEntryName;
                        Master.DataEntrySignature = _Property.DataEntrySignature;

                        Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                        Master.NonVermicultureProject = _Property.NonVermicultureProject;
                        Master.NoLift = _Property.NoLift;
                        Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                        Master.Sketchdiagram = _Property.Sketchdiagram;
                        Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                        Master.ZoneNo = _Property.ZoneNo;
                        Master.VillageName = _Property.VillageName;
                        Master.HFSNo = _Property.HFSNo;
                        Master.Legal = _Property.Legal;
                        Master.HissaNo = _Property.HissaNo;
                        Master.OldRateableValue = _Property.OldRateableValue;
                        Master.OldTotalTax = _Property.OldTotalTax;
                        Master.FirstAssessmentYear = _Property.FirstAssessmentYear;
                        Master.ImageNo = _Property.ImageNo;
                        Master.WardName_No2 = _Property.WardNameNo2;
                        Master.ZoneNo2 = _Property.ZoneNo2;
                        Master.FHNo = _Property.FHNo;
                        Master.PropertyType2 = _Property.PropertyType2;
                        Master.NewPropertyNo2 = _Property.NewPropertyNo2;
                        Master.PropertyNo2 = _Property.PropertyNo2;
                        Master.GarbageType = _Property.GarbageType;
                        Master.NOGarbageType = _Property.NOGarbageType;
                        Master.PrabhagNo2 = _Property.PrabhagNo2;
                        Master.YConstPermNo = _Property.YConstPermNo;
                        Master.NConstPermNo = _Property.NConstPermNo;
                        Master.YPermUseNo = _Property.YPermUseNo;
                        Master.NPermUseNo = _Property.NPermUseNo;


                        Master.ZKMKG = _Property.ZKMKG;
                        Master.DVMKG = _Property.DVMKG;
                        Master.ThirdPT = _Property.ThirdPT;
                        Master.FourthPT = _Property.FourthPT;
                        Master.FifthPT = _Property.FifthPT;
                        Master.SixPT = _Property.SixPT;
                        Master.SevenPT = _Property.SevenPT;
                        Master.EightPT = _Property.EightPT;
                        Master.NinePT = _Property.NinePT;
                        Master.TenPT = _Property.TenPT;
                        Master.ElevenPT = _Property.ElevenPT;
                        Master.TwelvePT = _Property.TwelvePT;
                        Master.TherteenPT = _Property.TherteenPT;
                        Master.FourteenPT = _Property.FourteenPT;
                        Master.FifteenPT = _Property.FifteenPT;
                        Master.SixteenPT = _Property.SixteenPT;
                        Master.seventeenPT = _Property.seventeenPT;
                        Master.FirstRPC = _Property.FirstRPC;
                        Master.SecondRPC = _Property.SecondRPC;
                        Master.ThirdRPC = _Property.ThirdRPC;
                        Master.FourthRPC = _Property.FourthRPC;
                        Master.FifthRPC = _Property.FifthRPC;
                        Master.SixRPC = _Property.SixRPC;
                        Master.SevenRPC = _Property.SevenRPC;
                        Master.EightRPC = _Property.EightRPC;
                        Master.NineRPC = _Property.NineRPC;
                        Master.TenRPC = _Property.TenRPC;
                        Master.ElevenRPC = _Property.ElevenRPC;
                        Master.TwelveRPC = _Property.TwelveRPC;
                        Master.ThirteenRPC = _Property.ThirteenRPC;
                        Master.FirstCPC = _Property.FirstCPC;
                        Master.SecondCPC = _Property.SecondCPC;
                        Master.ThirdCPC = _Property.ThirdCPC;
                        Master.FourthCPC = _Property.FourthCPC;
                        Master.FifthCPC = _Property.FifthCPC;
                        Master.SixCPC = _Property.SixCPC;
                        Master.SevenCPC = _Property.SevenCPC;
                        Master.EightCPC = _Property.EightCPC;

                        Master.NineCPC = _Property.NineCPC;
                        Master.TenCPC = _Property.TenCPC;
                        Master.ElevenCPC = _Property.ElevenCPC;
                        Master.TwelveCPC = _Property.TwelveCPC;
                        Master.ThirteenCPC = _Property.ThirteenCPC;
                        Master.FourteenCPC = _Property.FourteenCPC;
                    }
                }
                else
                {

                }
            }
            return Master;
        }

        public PropertyMasterVM getDeleteByID(int q, int AppId)
        {
            PropertyMasterVM Master = new PropertyMasterVM();
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {
                var _Property = db.PropertyMasters.Where(c => c.PropertyId == q).FirstOrDefault();
                if (_Property != null)
                {
                    _Property.IsDelete = true;
                    db.SaveChanges();
                }
            }
            return Master;
        }



        public NamunaMasterVM getDeleteByIDNamuna(int q, int AppId)
        {
            NamunaMasterVM Master = new NamunaMasterVM();
            using (DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId))
            {
                var _Property = db.NamunaMasters.Where(c => c.NamunaId == q).FirstOrDefault();
                if (_Property != null)
                {
                    _Property.IsDelete = true;
                    db.SaveChanges();
                }
            }
            return Master;
        }

        //public PropertyMasterVM GetPrabhagNo(int teamId)
        //{
        //    try
        //    {
        //        using (var db = new DEVPTCSURVEYMALEGAONEntities(AppID))
        //        {

        //            var atten = db.PropertyMasters;
        //            if (atten != null)
        //            {

        //                atten.UserList = ListUser();


        //                return loc;
        //            }
        //            else
        //            {
        //                return new SBALUserLocationMapView();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new SBALUserLocationMapView();
        //    }
        //}

        //public List<SelectListItem> ListUser()
        //{
        //    var user = new List<SelectListItem>();
        //    SelectListItem itemAdd = new SelectListItem() { Text = "--Select Employee--", Value = "0" };

        //    try
        //    {
        //        user = db.UserMasters.Where(c => c.isActive == true).ToList()
        //            .Select(x => new SelectListItem
        //            {
        //                Text = x.userName,
        //                Value = x.userId.ToString()
        //            }).OrderBy(t => t.Text).ToList();

        //    }
        //    catch (Exception ex) { throw ex; }

        //    return user;
        //}

        public void sendSMS(string sms, string MobilNumber)
        {
            try
            {
                //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.smsjust.com/sms/user/urlsms.php?username=ycagent&pass=yocc@5095&senderid=YOCCAG&dest_mobileno=" + MobilNumber + "&msgtype=UNI&message=" + sms + "&response=Y");
                //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.smsjust.com/sms/user/urlsms.php?username=ycagent&pass=yocc@5095&senderid=YOCCAG&dest_mobileno=" + MobilNumber + "&message=" + sms + "&response=Y");
                //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.smsjust.com/sms/user/urlsms.php?username=artiyocc&pass=123456&senderid=BIGVCL&dest_mobileno=" + MobilNumber + "&msgtype=UNI&message="+ sms + "%20&response=Y");

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.smsjust.com/sms/user/urlsms.php?username=artiyocc&pass=123456&senderid=BIGVCL&dest_mobileno=" + MobilNumber + "&message=" + sms + "%20&response=Y");

                //Get response from Ozeki NG SMS Gateway Server and read the answer
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
            }
            catch { }

        }

        public PropertyMasterVM SendPropertyDetails(int AppId, string SearchText, string SelectOption, string send, string Reminder,int q)
        {
            DEVPTCSURVEYMALEGAONEntities db = new DEVPTCSURVEYMALEGAONEntities(AppId);
            PropertyMasterVM result = new PropertyMasterVM();
            var model = from s in db.PropertyMasters select s;
            if(SelectOption== "Property Number")
            {
                SelectOption = "PropertyNumber";
            }
            if (SelectOption == "Prabhag Number")
            {
                SelectOption = "PrabhagNumber";
            }
            if (SelectOption == "Ward Number")
            {
                SelectOption = "WardNumber";
            }
            try
            {
                if (!String.IsNullOrEmpty(SearchText))
                {
                    switch (SelectOption)
                    {
                        case "PropertyNumber":
                            model = model.Where(a => a.PropertyNo== SearchText &&  a.IsDelete==false);
                            foreach (var item in model)
                            {
                                //  Console.WriteLine(item.PropOwnerMobileNo);
                                if (!string.IsNullOrEmpty(send) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " BIGVCL", item.PropOwnerTelephoneNo);
                                }
                                if (!string.IsNullOrEmpty(Reminder) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax Reminder - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " is due. BIGVCL", item.PropOwnerTelephoneNo);
                                }
                            }
                            break;

                        case "PrabhagNumber":
                            model = model.Where(a => a.PropertyNo == SearchText && a.IsDelete == false);

                            foreach (var item in model)
                            {
                                if (!string.IsNullOrEmpty(send) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " BIGVCL", item.PropOwnerTelephoneNo);
                                }
                                if (!string.IsNullOrEmpty(Reminder) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax Reminder - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " is due. BIGVCL", item.PropOwnerTelephoneNo);
                                }
                            }
                            break;

                        case "WardNumber":
                            model = model.Where(a => a.PropertyNo == SearchText && a.IsDelete == false);
                            foreach (var item in model)
                            {
                                if (!string.IsNullOrEmpty(send) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " BIGVCL", item.PropOwnerTelephoneNo);
                                }
                                if (!string.IsNullOrEmpty(Reminder) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax Reminder - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " is due. BIGVCL", item.PropOwnerTelephoneNo);
                                }
                            }
                            break;
                          

                    }
                    int cnt = model.Count();
                    if (cnt == 0)
                    {
                        result.ErrorMsg = "error";
                    }
                }
                
                else
                {
                    switch (SelectOption)
                    {
                        case "PropertyNumber":
                            model = model.Where(a => a.PropertyId == q && a.IsDelete==false);
                            foreach (var item in model)
                            {
                                //  Console.WriteLine(item.PropOwnerMobileNo);
                                if (!string.IsNullOrEmpty(send) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " BIGVCL", item.PropOwnerTelephoneNo);
                                }
                                if (!string.IsNullOrEmpty(Reminder) && !string.IsNullOrEmpty(item.PropOwnerTelephoneNo))
                                {
                                    sendSMS("Vengurla Property Tax Reminder - Your Property Tax Bill for Rs." + item.totaltax + " for Property Tax number " + item.PropertyNo + " is due. BIGVCL", item.PropOwnerTelephoneNo);
                                }
                            }
                            break;

                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMsg = "error";
            }
           
            //    result = model;
            return result;
        }

        public PropertyMasterVM GetPrabhagNo(int Appid,int q)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                   

                    var Details = db.PropertyMasters.ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM Prabhag = new PropertyMasterVM();

                        Prabhag.PrabhagNoList = ListPrabhag(Appid);
                     
                        return Prabhag;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public PropertyMasterVM GetPropertyNoList(int Appid, string pname)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    string fname, mname, lname;
                    string[] arr = pname.Split(' ');
                     fname = arr[0];
                     mname = arr[1];
                   //  lname = arr[2];
                    var Details = db.PropertyMasters.Where(x=>x.PropOwnerFirstName== fname && x.PropOwnerMiddleName == mname).ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM Property = new PropertyMasterVM();

                        Property.PropertyNoList = ListProperty(Appid, pname);

                        return Property;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public PropertyMasterVM GetOwnerNameList(int Appid, string pno)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    
                    var Details = db.PropertyMasters.Where(x => x.PropertyNo == pno).ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM Property = new PropertyMasterVM();

                        Property.PropertyOwnerList = ListOwnerName(Appid, pno);

                        return Property;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public PropertyMasterVM GetOwnerNameFocus(int Appid,string pname)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {

                    var Details = db.PropertyMasters.Where(x=>x.IsDelete==false).FirstOrDefault();
                    if (Details != null)
                    {
                        PropertyMasterVM Property = new PropertyMasterVM();

                        Property.PropertyOwnerList = ListOwnerNameFocus(Appid, pname);
                        return Property;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public List<SelectListItem> ListPrabhag(int Appid)
        {
            var user = new List<SelectListItem>();
           
            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                List<PropertyMaster> listObjects = (from obj in db.PropertyMasters

                                                    where obj.IsDelete == false
                                                    select obj).GroupBy(n => new { n.PrabhagNo }).Select(g => g.FirstOrDefault())
                                           .ToList();            
                try
                {
                    user = listObjects.Where(c =>  c.PrabhagNo!=null && c.PrabhagNo == c.PrabhagNo.Trim()).ToList()
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.PrabhagNo)) ? " " : x.PrabhagNo,

                            Value = (string.IsNullOrEmpty(x.PrabhagNo)) ? " " : x.PrabhagNo
                        }).Distinct().OrderBy(t => t.Text).ToList();                 
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public List<SelectListItem> ListOwnerName(int Appid, string pno)
        {
            var user = new List<SelectListItem>();
            List<PropertyMaster> listObjects = new List<PropertyMaster>();
            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                
                    listObjects = (from obj in db.PropertyMasters
                                   where obj.PropertyNo == pno && obj.IsDelete == false
                                   select obj).GroupBy(n => new { n.PropOwnerFirstName }).Select(g => g.FirstOrDefault())
                                              .ToList();
                   
                try
                {
                    user = listObjects
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.PropOwnerFirstName)) ? " " : x.PropOwnerFirstName + " " +
                                    //  (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName),
                            Value = (string.IsNullOrEmpty(x.PropOwnerFirstName)) ? " " : x.PropOwnerFirstName + " " +
                                 //     (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName)
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public List<SelectListItem> ListOwnerNameFocus(int Appid, string pname)
        {
            var user = new List<SelectListItem>();
            List<PropertyMaster> listObjects = new List<PropertyMaster>();
            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {

                listObjects = (from obj in db.PropertyMasters
                               where obj.IsDelete == false
                               select obj).GroupBy(n => new { n.PropOwnerFirstName }).Select(g => g.FirstOrDefault())
                                          .ToList();

                try
                {
                    user = listObjects.Where(c => ((string.IsNullOrEmpty(c.PropOwnerFirstName) ? " " : c.PropOwnerFirstName) + " " +
                                      //(string.IsNullOrEmpty(c.PropOwnerMiddleName) ? " " : c.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(c.PropOwnerLastName) ? " " : c.PropOwnerLastName) 
                                       ).ToUpper().Contains(pname.ToUpper()))
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.PropOwnerFirstName)) ? " " : x.PropOwnerFirstName + " " +
                                      //  (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName),
                            Value = (string.IsNullOrEmpty(x.PropOwnerFirstName)) ? " " : x.PropOwnerFirstName + " " +
                                      //     (string.IsNullOrEmpty(x.PropOwnerMiddleName) ? " " : x.PropOwnerMiddleName) + " " +
                                      (string.IsNullOrEmpty(x.PropOwnerLastName) ? " " : x.PropOwnerLastName)
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public List<SelectListItem> ListProperty(int Appid, string pname)
        {
            var user = new List<SelectListItem>();
            List<PropertyMaster> listObjects = new List<PropertyMaster>();
            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                string fname, mname, lname;
                string[] arr = pname.Split(' ');
                if (arr.Length > 0)
                {
                    fname = arr[0];
                 listObjects = (from obj in db.PropertyMasters where obj.PropOwnerFirstName==fname &&  obj.IsDelete == false
                                select obj).GroupBy(n => new { n.PropertyNo }).Select(g => g.FirstOrDefault())
                                           .ToList();
                }
                if (arr.Length > 1)
                {
                    mname = arr[1];
                    fname = arr[0];
                    listObjects = listObjects.Where(x => x.PropOwnerMiddleName == mname && x.PropOwnerFirstName == fname).ToList();
                    if(listObjects.Count==0)
                    {
                        listObjects = (from obj in db.PropertyMasters
                                       where obj.PropOwnerLastName == mname && obj.PropOwnerFirstName==fname
                                       select obj).GroupBy(n => new { n.PropertyNo }).Select(g => g.FirstOrDefault())
                                          .ToList();
                    }
                }
                if (arr.Length > 2)
                {
                    lname = arr[2];
                    listObjects = listObjects.Where(x => x.PropOwnerLastName == lname).ToList();
                }

                try
                {
                    user = listObjects
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.PropertyNo)) ? " " : x.PropertyNo,
                            Value = (string.IsNullOrEmpty(x.PropertyNo)) ? " " : x.PropertyNo
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public PropertyMasterVM GetWardNo(int Appid, int q)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {


                    var Details = db.PropertyMasters.ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM ward = new PropertyMasterVM();

                        ward.WardNoList = ListWard(Appid);

                        return ward;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public List<SelectListItem> ListWard(int Appid)
        {
            var user = new List<SelectListItem>();
         
            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                List<PropertyMaster> listObjects = (from obj in db.PropertyMasters
                                                    where obj.IsDelete == false
                                                    select obj).GroupBy(n => new { n.WardNameNo }).Select(g => g.FirstOrDefault())
                                           .ToList();
                try
                {
                    user = listObjects.Where(c =>  c.WardNameNo != null && c.WardNameNo == c.WardNameNo.Trim()).ToList()
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.WardNameNo)) ? " " : x.WardNameNo,
                            Value = (string.IsNullOrEmpty(x.WardNameNo)) ? " " : x.WardNameNo
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public PropertyMasterVM GetCSDate(int Appid, int q)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    var Details = db.PropertyMasters.ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM ward = new PropertyMasterVM();
                        ward.CSDateList = ListCSDate(Appid);

                        return ward;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public PropertyMasterVM GetCEDate(int Appid, int q)
        {
            try
            {
                using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
                {
                    var Details = db.PropertyMasters.ToList();
                    if (Details != null)
                    {
                        PropertyMasterVM ward = new PropertyMasterVM();
                        ward.CEDateList = ListCEDate(Appid);

                        return ward;
                    }
                    else
                    {
                        return new PropertyMasterVM();
                    }

                }
            }
            catch (Exception ex)
            {
                return new PropertyMasterVM();
            }
        }

        public List<SelectListItem> ListCSDate(int Appid)
        {
            var user = new List<SelectListItem>();

            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                List<PropertyMaster> listObjects = (from obj in db.PropertyMasters
                                                    where obj.IsDelete == false
                                                    select obj).GroupBy(n => new { n.ConstStartYear }).Select(g => g.FirstOrDefault())
                                           .ToList();
                try
                {
                    user = listObjects.Where(c => c.ConstStartYear != null && c.ConstStartYear == c.ConstStartYear.Trim()).ToList()
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.ConstStartYear)) ? " " : x.ConstStartYear,
                            Value = (string.IsNullOrEmpty(x.ConstStartYear)) ? " " : x.ConstStartYear
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }

        public List<SelectListItem> ListCEDate(int Appid)
        {
            var user = new List<SelectListItem>();

            using (var db = new DEVPTCSURVEYMALEGAONEntities(Appid))
            {
                List<PropertyMaster> listObjects = (from obj in db.PropertyMasters
                                                    where obj.IsDelete == false
                                                    select obj).GroupBy(n => new { n.CompletionYear }).Select(g => g.FirstOrDefault())
                                           .ToList();
                try
                {
                    user = listObjects.Where(c =>  c.CompletionYear != null ).ToList()
                        .Select(x => new SelectListItem
                        {
                            Text = (string.IsNullOrEmpty(x.CompletionYear)) ? " " : x.CompletionYear,
                            Value = (string.IsNullOrEmpty(x.CompletionYear)) ? " " : x.CompletionYear
                        }).Distinct().OrderBy(t => t.Text).ToList();
                }
                catch (Exception ex) { throw ex; }
            }
            return user;
        }
    }

}

