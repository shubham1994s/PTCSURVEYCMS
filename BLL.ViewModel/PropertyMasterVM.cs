using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BLL.ViewModel
{
    public class PropertyMasterVM : FilterDropdownVM
    {
       

        public int PropertyId { get; set; }
        public string PrabhagNo { get; set; }

        public string PrabhagNo2 { get; set; }
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

        public string PropertyNo2 { get; set; }

        public string OldHouseNo1 { get; set; }
        public string OldHouseNo2 { get; set; }

        public string NoOfTrees { get; set; }

        public string TotalPropertyExpense { get; set; }

        public string CurrentPropertyTax { get; set; }
        public string CurrentProperyPrice { get; set; }

        public string OpenAroundLandtaxprice { get; set; }

        public string ProperyTaxPrice { get; set; }

        public string TotalTaxPrice { get; set; }
        public string OpenLandtaxprice { get; set; }

        public string ProperyTaxMarketPrice { get; set; }

        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }
        public string Name6 { get; set; }
        public string Name7 { get; set; }
        public string Name8 { get; set; }
        public string Name9 { get; set; }
        public string Name10 { get; set; }
        public string Name11 { get; set; }
        public string Name12 { get; set; }

        public string Age1 { get; set; }
        public string Age2 { get; set; }
        public string Age3 { get; set; }
        public string Age4 { get; set; }
        public string Age5 { get; set; }
        public string Age6 { get; set; }
        public string Age7 { get; set; }
        public string Age8 { get; set; }
        public string Age9 { get; set; }
        public string Age10 { get; set; }
        public string Age11 { get; set; }
        public string Age12 { get; set; }

        public string link1 { get; set; }
        public string link2 { get; set; }
        public string link3 { get; set; }
        public string link4 { get; set; }
        public string link5 { get; set; }
        public string link6 { get; set; }
        public string link7 { get; set; }
        public string link8 { get; set; }
        public string link9 { get; set; }
        public string link10 { get; set; }
        public string link11 { get; set; }
        public string link12 { get; set; }

        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string ContactNo3 { get; set; }
        public string ContactNo4 { get; set; }
        public string ContactNo5 { get; set; }
        public string ContactNo6 { get; set; }
        public string ContactNo7 { get; set; }
        public string ContactNo8 { get; set; }
        public string ContactNo9 { get; set; }
        public string ContactNo10 { get; set; }
        public string ContactNo11 { get; set; }
        public string ContactNo12 { get; set; }

        public string VoterIdentityNo1 { get; set; }
        public string VoterIdentityNo2 { get; set; }
        public string VoterIdentityNo3 { get; set; }
        public string VoterIdentityNo4 { get; set; }
        public string VoterIdentityNo5 { get; set; }
        public string VoterIdentityNo6 { get; set; }
        public string VoterIdentityNo7 { get; set; }
        public string VoterIdentityNo8 { get; set; }
        public string VoterIdentityNo9 { get; set; }
        public string VoterIdentityNo10 { get; set; }
        public string VoterIdentityNo11 { get; set; }
        public string VoterIdentityNo12 { get; set; }

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

        public string PropOwnerFirstName2 { get; set; }
        public string PropOwnerMiddleName2 { get; set; }
        public string PropOwnerLastName2 { get; set; }

        public string PropOwnerFirstName3 { get; set; }
        public string PropOwnerMiddleName3 { get; set; }
        public string PropOwnerLastName3 { get; set; }

        public string PropOwnerFirstName4 { get; set; }
        public string PropOwnerMiddleName4 { get; set; }
        public string PropOwnerLastName4 { get; set; }
        public string PropOwnerTelephoneNo { get; set; }
        public string PropOwnerElectionCardNo { get; set; }
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


      //  public Usage UsageList { get; set; }
        public string Usage { get; set; }
        public string TypeofBldg { get; set; }
        public string ConstPermNo { get; set; }
        public string PermUseNo { get; set; }

        public Nullable<bool> Personalwell { get; set; }

        public Nullable<bool> Publicwell { get; set; }

        public string HeritageTree { get; set; }

        public Nullable<bool> WaterConnection { get; set; }
        public Nullable<bool> NoWaterConnection { get; set; }
        public Nullable<bool> STP { get; set; }
        public Nullable<bool> FST { get; set; }
        public Nullable<bool> STS { get; set; }
        public Nullable<bool> Other { get; set; }
        public Nullable<bool> SGSK { get; set; }

        public Nullable<bool> NOSGSK { get; set; }
        public Nullable<bool> OtherGutter { get; set; }
        public Nullable<bool> NaturalMethod { get; set; }
        public Nullable<bool> ArtifitialMethod { get; set; }
        public Nullable<bool> OtherMethod { get; set; }


        public Nullable<bool> NoProject { get; set; }

        public Nullable<bool> Safe { get; set; }
        public Nullable<bool> Danger { get; set; }
        public Nullable<bool> Safe2 { get; set; }
        public Nullable<bool> Danger2 { get; set; }
        public Nullable<bool> Safe3 { get; set; }

        public Nullable<bool> Danger3 { get; set; }
        public Nullable<bool> Rainwaterharvest { get; set; }
        public Nullable<bool> SolarWaterheater { get; set; }
        public Nullable<bool> VermicultureProject { get; set; }
        public string SWHRemark { get; set; }
        public Nullable<bool> Borewell { get; set; }

        public Nullable<bool> NonBorewellr { get; set; }
        public Nullable<int> NoofToilets { get; set; }

        public Nullable<bool> GarbageType { get; set; }
        public Nullable<bool> NOGarbageType { get; set; }
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

        public Nullable<bool> YConstPermNo { get; set; }
        public Nullable<bool> NConstPermNo { get; set; }

        public Nullable<bool> YPermUseNo { get; set; }
        public Nullable<bool> NPermUseNo { get; set; }
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

        public string ErrorMsg { get; set; }

        public Nullable<bool> ZKMKG { get; set; }

        public Nullable<bool> DVMKG { get; set; }


        public Nullable<bool> ThirdPT { get; set; }
        public Nullable<bool> FourthPT { get; set; }
        public Nullable<bool> FifthPT { get; set; }
        public Nullable<bool> SixPT { get; set; }
        public Nullable<bool> SevenPT { get; set; }
        public Nullable<bool> EightPT { get; set; }
        public Nullable<bool> NinePT { get; set; }
        public Nullable<bool> TenPT { get; set; }
        public Nullable<bool> ElevenPT { get; set; }
        public Nullable<bool> TwelvePT { get; set; }
        public Nullable<bool> TherteenPT { get; set; }
        public Nullable<bool> FourteenPT { get; set; }
        public Nullable<bool> FifteenPT { get; set; }
        public Nullable<bool> SixteenPT { get; set; }
        public Nullable<bool> seventeenPT { get; set; }


        public Nullable<bool> FirstRPC { get; set; }
        public Nullable<bool> SecondRPC { get; set; }
        public Nullable<bool> ThirdRPC { get; set; }
        public Nullable<bool> FourthRPC { get; set; }
        public Nullable<bool> FifthRPC { get; set; }
        public Nullable<bool> SixRPC { get; set; }
        public Nullable<bool> SevenRPC { get; set; }
        public Nullable<bool> EightRPC { get; set; }
        public Nullable<bool> NineRPC { get; set; }
        public Nullable<bool> TenRPC { get; set; }
        public Nullable<bool> ElevenRPC { get; set; }
        public Nullable<bool> TwelveRPC { get; set; }

        public Nullable<bool> ThirteenRPC { get; set; }
        public Nullable<bool> FirstCPC { get; set; }
        public Nullable<bool> SecondCPC { get; set; }
        public Nullable<bool> ThirdCPC { get; set; }


        public Nullable<bool> FourthCPC { get; set; }
        public Nullable<bool> FifthCPC { get; set; }
        public Nullable<bool> SixCPC { get; set; }
        public Nullable<bool> SevenCPC { get; set; }
        public Nullable<bool> EightCPC { get; set; }
        public Nullable<bool> NineCPC { get; set; }
        public Nullable<bool> TenCPC { get; set; }
        public Nullable<bool> ElevenCPC { get; set; }
        public Nullable<bool> TwelveCPC { get; set; }
        public Nullable<bool> ThirteenCPC { get; set; }
        public Nullable<bool> FourteenCPC { get; set; }

        public Nullable<bool> IsDelete { get; set; }
        
    }
  
}
