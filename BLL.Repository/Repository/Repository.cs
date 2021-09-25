using BLL.ViewModel;
using DAL;
using DAL.ChildDatabase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                        obj.ContactNo11= _Property.ContactNo11;
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
                        Result.message = "success";
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
                       
                        Master.DateofConstruction1 =_Property.DateofConstruction1;
                     
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
                 
                            Master.DateofConstruction4 =_Property.DateofConstruction4;
                      
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
                        Result.message = "success";
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
                result = db.PropertyMasters.Where(x=>x.IsDelete==false).Select(x => new PropertyMasterVM
                {
                    PropertyId = x.PropertyId,
                    NewPropertyNo = x.NewPropertyNo,
                    PropertyNo = x.PropertyNo,
                    OldHouseNo1 = x.HouseNo,
                    PropOwnerFirstName = x.PropOwnerFirstName,
                    PropOwnerLastName = x.PropOwnerLastName,
                    PropOwnerTelephoneNo = x.PropOwnerTelephoneNo,
                    Sketchdiagram2=x.Sketchdiagram2

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
        }
}


