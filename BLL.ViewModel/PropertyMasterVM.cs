﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModel
{
    public class PropertyMasterVM
    {

        public int PropertyId { get; set; }
        public string PrabhagNo { get; set; }
        public string WardName_No { get; set; }

        public string WardName_No2 { get; set; }

        public string ZoneNo2 { get; set; }

        public string FHNo { get; set; }

        public string PropertyType2 { get; set; }



        public string ZoneNo { get; set; }
        public string ElectionWard { get; set; }
        public string NewPropertyNo { get; set; }

        public string NewPropertyNo2 { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Can Not Be Blank")]
        public string PropertyNo { get; set; }
        public string HouseNo { get; set; }
        public string SurveyNo { get; set; }
        public string GatNo { get; set; }
        public string CitySurveyNo { get; set; }
        public string AnnualRateableValue { get; set; }
        public string TotalPlotArea { get; set; }
        public string TotalBuildupArea { get; set; }
        public string MarginSpace { get; set; }
        public string BuildingName { get; set; }
        public string PlotNo { get; set; }
        public string FlatNo { get; set; }
        public string NoofFloors { get; set; }
        public string NoofFlats { get; set; }
        public string NoofShops { get; set; }
        public string PropOwnerFirstName { get; set; }
        public string PropOwnerMiddleName { get; set; }
        public string PropOwnerLastName { get; set; }
        public string PropOwnerTelephoneNo { get; set; }
        public string PropOwnerMobileNo { get; set; }
        public string PropOwnerEmailId { get; set; }
        public string PropOwnerAdhaarNo { get; set; }
        public string OccupierFirstName { get; set; }
        public string OccupierMiddleName { get; set; }
        public string OccupierLastName { get; set; }
        public string OccupierMobileNo { get; set; }
        public string OccupierAdhaarNo { get; set; }
        public string TenantName { get; set; }
        public string Rent { get; set; }
        public string TenantMobileNo { get; set; }
        public string TenantAdhaarNo { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ConstStartYear { get; set; }
        public string CompletionYear { get; set; }
        public string Age { get; set; }
        public string Usage { get; set; }
        public string TypeofBldg { get; set; }
        public string ConstPermNo { get; set; }
        public string PermUseNo { get; set; }
        public Nullable<bool> Rainwaterharvest { get; set; }
        public Nullable<bool> SolarWaterheater { get; set; }
        public Nullable<bool> VermicultureProject { get; set; }
        public string SWHRemark { get; set; }
        public Nullable<bool> Borewell { get; set; }

        public Nullable<bool> NonBorewellr { get; set; }
        public Nullable<int> NoofToilets { get; set; }
        public Nullable<bool> PermanentDoorLock { get; set; }
        public Nullable<bool> OuterMeasurement { get; set; }
        public Nullable<bool> Lift { get; set; }
        public string Remarks { get; set; }
        public string FloorNo1 { get; set; }
        public string OccupancyStatus1 { get; set; }
        public string ConstType1 { get; set; }

        [Display(Name = "Enter DateofConstruction1")]
        public string DateofConstruction1 { get; set; }
        public string UsageType1 { get; set; }
        public string UsageTypeClass1 { get; set; }
        public string Legal1 { get; set; }
        public string CarpetArea1 { get; set; }
        public string BuildupArea1 { get; set; }
        public string FloorNo2 { get; set; }
        public string OccupancyStatus2 { get; set; }
        public string ConstType2 { get; set; }

        [Display(Name = "Enter DateofConstruction2")]
        public string DateofConstruction2 { get; set; }
        public string UsageType2 { get; set; }
        public string UsageTypeClass2 { get; set; }
        public string Legal2 { get; set; }
        public string CarpetArea2 { get; set; }
        public string BuildupArea2 { get; set; }
        public string FloorNo3 { get; set; }
        public string OccupancyStatus3 { get; set; }
        public string ConstType3 { get; set; }

        [Display(Name = "Enter DateofConstruction3")]
        public string DateofConstruction3 { get; set; }
        public string UsageType3 { get; set; }
        public string UsageTypeClass3 { get; set; }
        public string Legal3 { get; set; }
        public string CarpetArea3 { get; set; }
        public string BuildupArea3 { get; set; }
        public string FloorNo4 { get; set; }
        public string OccupancyStatus4 { get; set; }
        public string ConstType4 { get; set; }
        [Display(Name = "Enter DateofConstruction4")]
        public string DateofConstruction4 { get; set; }
        public string UsageType4 { get; set; }
        public string UsageTypeClass4 { get; set; }
        public string Legal4 { get; set; }
        public string CarpetArea4 { get; set; }
        public string BuildupArea4 { get; set; }
        public string FloorNo5 { get; set; }
        public string ConstType5 { get; set; }

        [Display(Name = "Enter DateofConstruction5")]

        public string DateofConstruction5 { get; set; }
        public string UsageType5 { get; set; }
        public string UsageTypeClass5 { get; set; }
        public string Legal5 { get; set; }

        public string Legal { get; set; }

        public string HissaNo { get; set; }

        public string OldRateableValue { get; set; }

        public string OldTotalTax { get; set; }

        public string FirstAssessmentYear { get; set; }

        public string ImageNo { get; set; }
        public string CarpetArea5 { get; set; }
        public string BuildupArea5 { get; set; }
        public string OldUsageType { get; set; }
        public string OldConstructionType { get; set; }
        public string NewUsageType { get; set; }
        public string NewConstructionType { get; set; }
        public string ExtendUsage_Type { get; set; }
        public string ExtendConstructionType { get; set; }
        public string PropertyType { get; set; }

        public string VillageName { get; set; }

        public string HFSNo { get; set; }

        public string SurveyorName { get; set; }
        public string SurveyorSignature { get; set; }

        [Display(Name = "Enter SurveyorDate")]
        public string SurveyorDate { get; set; }
        public string DataEntryName { get; set; }
        public string DataEntrySignature { get; set; }

        [Display(Name = "Enter DataEntryDate")]
        public string DataEntryDate { get; set; }
        public Nullable<bool> NonRainwaterharvest { get; set; }
        public Nullable<bool> NonSolarWaterheater { get; set; }
        public Nullable<bool> NonVermicultureProject { get; set; }

        public Nullable<bool> NoLift { get; set; }
        public string WaterConnectionResidential { get; set; }
        public string WaterConnectionSpecialCategory { get; set; }
        public string WaterConnectionIndustrial { get; set; }
        public string LocationofToiletResidential { get; set; }
        public string LocationofToiletSpecial { get; set; }
        public string LocationofToiletIndustrial { get; set; }
        public string ParkingFacilityResidential { get; set; }
        public string ParkingFacilitySpecial { get; set; }
        public string ParkingFacilityIndustrial { get; set; }
        public string DoorLockResidential { get; set; }
        public string DoorLockSpecial { get; set; }
        public string DoorLockIndustrial { get; set; }
        public string UnderGroundGutter { get; set; }
        public string OpenGutter { get; set; }
        public string totalCarpetArea { get; set; }
        public string totalBuildupArea1 { get; set; }
        public string totaltax { get; set; }
        public string OldCarpetAreaResident { get; set; }
        public string OldCarpetAreaNonResident { get; set; }
        public string NewCarpetAreaResident { get; set; }
        public string NewCarpetAreaNonResident { get; set; }
        public string ExtendCarpetAreaResident { get; set; }
        public string ExtendCarpetAreaNonResident { get; set; }
        public string OccupancyStatus5 { get; set; }

        public string Sketchdiagram { get; set; }

        public string Sketchdiagram2 { get; set; }
    }
}
