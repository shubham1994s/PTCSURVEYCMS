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
                var appUser = (db.AD_USER_MST.Where(x => x.ADUM_LOGIN_ID == _userinfo.ADUM_LOGIN_ID && x.ADUM_PASSWORD == _userinfo.ADUM_PASSWORD).FirstOrDefault());
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
                        obj.HouseNo = _Property.HouseNo;
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
                        obj.PropOwnerMobileNo = _Property.PropOwnerMobileNo;
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
                        obj.DateofConstruction1 = DateTime.ParseExact(_Property.DateofConstruction1, "dd-MM-yyyy", provider);
                        obj.UsageType1 = _Property.UsageType1;
                        obj.UsageTypeClass1 = _Property.UsageTypeClass1;
                        obj.Legal1 = _Property.Legal1;
                        obj.CarpetArea1 = _Property.CarpetArea1;
                        obj.BuildupArea1 = _Property.BuildupArea1;
                        obj.FloorNo2 = _Property.FloorNo2;
                        obj.OccupancyStatus2 = _Property.OccupancyStatus2;
                        obj.ConstType2 = _Property.ConstType2;
                        obj.DateofConstruction2 = DateTime.ParseExact(_Property.DateofConstruction2, "dd-MM-yyyy", provider);
                        obj.UsageType2 = _Property.UsageType2;
                        obj.UsageTypeClass2 = _Property.UsageTypeClass2;
                        obj.Legal2 = _Property.Legal2;
                        obj.CarpetArea2 = _Property.CarpetArea2;
                        obj.BuildupArea2 = _Property.BuildupArea2;
                        obj.FloorNo3 = _Property.FloorNo3;
                        obj.OccupancyStatus3 = _Property.OccupancyStatus3;
                        obj.ConstType3 = _Property.ConstType3;
                        obj.DateofConstruction3 = DateTime.ParseExact(_Property.DateofConstruction3, "dd-MM-yyyy", provider);
                        obj.UsageType3 = _Property.UsageType3;
                        obj.UsageTypeClass3 = _Property.UsageTypeClass3;
                        obj.Legal3 = _Property.Legal3;
                        obj.CarpetArea3 = _Property.CarpetArea3;
                        obj.BuildupArea3 = _Property.BuildupArea3;
                        obj.FloorNo4 = _Property.FloorNo4;
                        obj.OccupancyStatus4 = _Property.OccupancyStatus4;
                        obj.ConstType4 = _Property.ConstType4;
                        obj.DateofConstruction4 = DateTime.ParseExact(_Property.DateofConstruction4, "dd-MM-yyyy", provider);
                        obj.UsageType4 = _Property.UsageType4;
                        obj.UsageTypeClass4 = _Property.UsageTypeClass4;
                        obj.Legal4 = _Property.Legal4;
                        obj.CarpetArea4 = _Property.CarpetArea4;
                        obj.BuildupArea4 = _Property.BuildupArea4;
                        obj.FloorNo5 = _Property.FloorNo5;
                        obj.OccupancyStatus5 = _Property.OccupancyStatus5;
                        obj.ConstType5 = _Property.ConstType5;
                        obj.DateofConstruction5 = DateTime.ParseExact(_Property.DateofConstruction5, "dd-MM-yyyy", provider);
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
                        obj.SurveyorDate = DateTime.ParseExact(_Property.SurveyorDate, "dd-MM-yyyy", provider);
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

                        obj.DataEntryDate = DateTime.ParseExact(_Property.DataEntryDate, "dd-MM-yyyy", provider);
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
                        Master.HouseNo = _Property.HouseNo;
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
                        Master.PropOwnerMobileNo = _Property.PropOwnerMobileNo;
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
                        Master.DateofConstruction1 = DateTime.ParseExact(_Property.DateofConstruction1, "dd-MM-yyyy", provider);
                        Master.UsageType1 = _Property.UsageType1;
                        Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                        Master.Legal1 = _Property.Legal1;
                        Master.CarpetArea1 = _Property.CarpetArea1;
                        Master.BuildupArea1 = _Property.BuildupArea1;
                        Master.FloorNo2 = _Property.FloorNo2;
                        Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                        Master.ConstType2 = _Property.ConstType2;
                        Master.DateofConstruction2 = DateTime.ParseExact(_Property.DateofConstruction2, "dd-MM-yyyy", provider);
                        Master.UsageType2 = _Property.UsageType2;
                        Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                        Master.Legal2 = _Property.Legal2;
                        Master.CarpetArea2 = _Property.CarpetArea2;
                        Master.BuildupArea2 = _Property.BuildupArea2;
                        Master.FloorNo3 = _Property.FloorNo3;
                        Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                        Master.ConstType3 = _Property.ConstType3;
                        Master.DateofConstruction3 = DateTime.ParseExact(_Property.DateofConstruction3, "dd-MM-yyyy", provider);
                        Master.UsageType3 = _Property.UsageType3;
                        Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                        Master.Legal3 = _Property.Legal3;
                        Master.CarpetArea3 = _Property.CarpetArea3;
                        Master.BuildupArea3 = _Property.BuildupArea3;
                        Master.FloorNo4 = _Property.FloorNo4;
                        Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                        Master.ConstType4 = _Property.ConstType4;
                        Master.DateofConstruction4 = DateTime.ParseExact(_Property.DateofConstruction4, "dd-MM-yyyy", provider);
                        Master.UsageType4 = _Property.UsageType4;
                        Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                        Master.Legal4 = _Property.Legal4;
                        Master.CarpetArea4 = _Property.CarpetArea4;
                        Master.BuildupArea4 = _Property.BuildupArea4;
                        Master.FloorNo5 = _Property.FloorNo5;
                        Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                        Master.ConstType5 = _Property.ConstType5;
                        Master.DateofConstruction5 = DateTime.ParseExact(_Property.DateofConstruction5, "dd-MM-yyyy", provider);
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
                        Master.SurveyorDate = DateTime.ParseExact(_Property.SurveyorDate, "dd-MM-yyyy", provider);
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
                        Master.DataEntryDate = DateTime.ParseExact(_Property.DataEntryDate, "dd-MM-yyyy", provider);
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
                result = db.PropertyMasters.Select(x => new PropertyMasterVM
                {
                    PropertyId = x.PropertyId,
                    NewPropertyNo = x.NewPropertyNo,
                    PropertyNo = x.PropertyNo,
                    HouseNo = x.HouseNo,
                    PropOwnerFirstName = x.PropOwnerFirstName,
                    PropOwnerLastName = x.PropOwnerLastName,
                    PropOwnerMobileNo = x.PropOwnerMobileNo,

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
                    Master.HouseNo = _Property.HouseNo;
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
                    Master.PropOwnerMobileNo = _Property.PropOwnerMobileNo;
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
                    Master.DateofConstruction1 = Convert.ToDateTime(_Property.DateofConstruction1).ToString("dd-MM-yyyy");
                    Master.UsageType1 = _Property.UsageType1;
                    Master.UsageTypeClass1 = _Property.UsageTypeClass1;
                    Master.Legal1 = _Property.Legal1;
                    Master.CarpetArea1 = _Property.CarpetArea1;
                    Master.BuildupArea1 = _Property.BuildupArea1;
                    Master.FloorNo2 = _Property.FloorNo2;
                    Master.OccupancyStatus2 = _Property.OccupancyStatus2;
                    Master.ConstType2 = _Property.ConstType2;
                    Master.DateofConstruction2 = Convert.ToDateTime(_Property.DateofConstruction2).ToString("dd-MM-yyyy");
                    Master.UsageType2 = _Property.UsageType2;
                    Master.UsageTypeClass2 = _Property.UsageTypeClass2;
                    Master.Legal2 = _Property.Legal2;
                    Master.CarpetArea2 = _Property.CarpetArea2;
                    Master.BuildupArea2 = _Property.BuildupArea2;
                    Master.FloorNo3 = _Property.FloorNo3;
                    Master.OccupancyStatus3 = _Property.OccupancyStatus3;
                    Master.ConstType3 = _Property.ConstType3;
                    Master.DateofConstruction3 = Convert.ToDateTime(_Property.DateofConstruction3).ToString("dd-MM-yyyy");
                    Master.UsageType3 = _Property.UsageType3;
                    Master.UsageTypeClass3 = _Property.UsageTypeClass3;
                    Master.Legal3 = _Property.Legal3;
                    Master.CarpetArea3 = _Property.CarpetArea3;
                    Master.BuildupArea3 = _Property.BuildupArea3;
                    Master.FloorNo4 = _Property.FloorNo4;
                    Master.OccupancyStatus4 = _Property.OccupancyStatus4;
                    Master.ConstType4 = _Property.ConstType4;
                    Master.DateofConstruction4 = Convert.ToDateTime(_Property.DateofConstruction4).ToString("dd-MM-yyyy");
                    Master.UsageType4 = _Property.UsageType4;
                    Master.UsageTypeClass4 = _Property.UsageTypeClass4;
                    Master.Legal4 = _Property.Legal4;
                    Master.CarpetArea4 = _Property.CarpetArea4;
                    Master.BuildupArea4 = _Property.BuildupArea4;
                    Master.FloorNo5 = _Property.FloorNo5;
                    Master.OccupancyStatus5 = _Property.OccupancyStatus5;
                    Master.ConstType5 = _Property.ConstType5;
                    Master.DateofConstruction5 = Convert.ToDateTime(_Property.DateofConstruction5).ToString("dd-MM-yyyy");
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
                    Master.SurveyorDate = Convert.ToDateTime(_Property.SurveyorDate).ToString("dd-MM-yyyy");
                    Master.DataEntryName = _Property.DataEntryName;
                    Master.DataEntrySignature = _Property.DataEntrySignature;

                    Master.DataEntryDate = Convert.ToDateTime(_Property.DataEntryDate).ToString("dd-MM-yyyy");
                    Master.NonSolarWaterheater = _Property.NonSolarWaterheater;
                    Master.NonVermicultureProject = _Property.NonVermicultureProject;
                    Master.NoLift = _Property.NoLift;
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
                    Master.WaterConnectionSpecialCategory = _Property.WaterConnectionSpecialCategory;
                    Master.Sketchdiagram = _Property.Sketchdiagram;
                    Master.Sketchdiagram2 = _Property.Sketchdiagram2;
                }
            }
            return Master;
        }
    }
}


