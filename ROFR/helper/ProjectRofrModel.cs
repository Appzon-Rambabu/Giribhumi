using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace ROFR.helper
{
    public class ProjectRofrModel
    {
    }
    public class captch
    {
        public string id { get; set; }
        public string Capchid { get; set; }
        public string REQUESTIP { get; set; }
        public string browser { get; set; }
        public string SOURCE { get; set; }
        public string flat { get; set; }
        public string flong { get; set; }
        public string fgeoaddres { get; set; }
    }


    public class UserLoginCls
    {
        public string PTYPE { get; set; }
        public string LOGIN_USER { get; set; }
        public string DISTRICT_CODE { get; set; }
        public string DISTRICT { get; set; }
        public string MANDAL { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_ADDRESS { get; set; }
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string DESIGNATION { get; set; }
        public string MOBILE_NO { get; set; }
        public string ROLE { get; set; }
        public string TOKEN_NUMBER { get; set; }
        public string EXPIRY_DATE { get; set; }
        public string OLD_PASSWORD { get; set; }
        public string NEW_PASSWORD { get; set; }
        public string ACTIVE_STATUS { get; set; }
        public string REFER_ID { get; set; }
        public string CAPTHA_VALUE { get; set; }
        public string IP { get; set; }
    }

    public class captchgens
    {
        public string idval { get; set; }
        public string imgurl { get; set; }
        public string code { get; set; }
        public string Reason { get; set; }

    }
    public class BeneficiaryDetails
    {
        public DataTable UpdateForestMasterDetails
        {
            get;
            set;
        }

    }

    public class oiltypes
    {
        public string oilname { get; set; }
        public int oilid { get; set; }
        public List<unittypes> unitsList { get; set; }
    }

    public class oilResultModel
    {
        public int S_NO { get; set; }
        public int CATEGORY_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_NAME { get; set; }
        public int ONE_LTR_PRICE { get; set; }
        public int ONE_LtR_PET_BOTTLE_PRICE { get; set; }
        public int ONE_LTR_SACHET_PRICE { get; set; }
    }



    public class unittypes
    {
        public int unitid { get; set; }
        public string unitname { get; set; }
        public int Quantity { get; set; }
        public string Totlprice { get; set; }
        public string stockid { get; set; }
        public int unitprice { get; set; }
    }

    public class HouseholdData
    {
        public int DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string CitizenNumber { get; set; }
        public string CitizenName { get; set; }
    }
    public class ROFRData
    {

        public string id { get; set; }
        public string Benificiaryid { get; set; }
        public string Aadhaarno { get; set; }
        public string uniquId { get; set; }
    }

    public class addbeneficiary_details
    {
        //mfr model
        public string ProductQuantity { get; set; }
        public string ProductCode { get; set; }
        public string IncomePerAnnum { get; set; }
        public string TotalAcres { get; set; }
        public string ProductName { get; set; }
        public string PointOfSale { get; set; }
        //crfmodel Representative_Name

        public string survey_number { get; set; }
        public string village_lgd_code { get; set; }
        public string NatureName { get; set; }
        public string Naturecode { get; set; }
        public string panchayat { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Gramsabha { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string FarmerUniqueID { get; set; }
        public string RepreseName { get; set; }
        public string FatherName { get; set; }
        public HttpPostedFileBase DocumentFile { get; set; }
        public string CFRID { get; set; }
        public string ItdaCodecrf { get; set; }
        public string ItdaNamecrf { get; set; }
        public string DistrictCodecrf { get; set; }
        public string Districtcrf { get; set; }
        public string MandalCodecrf { get; set; }
        public string Mandalcrf { get; set; }
        public string PanchayatCodecrf { get; set; }
        public string Panchayatcrf { get; set; }
        public string RevVillagecodecrf { get; set; }
        public string RevVillagecrf { get; set; }
        public string REVENUE_VILLAGE { get; set; }
        public string VillageCodecrf { get; set; }
        public string Villagecrf { get; set; }
        public string HabitationCodecrf { get; set; }
        public string Habitationcrf { get; set; }
        public string Forest_DivisionCodecrf { get; set; }
        public string ForestDivisioncrf { get; set; }
        public string ForestRangeCode { get; set; }
        public string ForestRange { get; set; }
        public string ForestBeatCode { get; set; }
        public string ForestBeat { get; set; }
        public string ForestBlock { get; set; }
        public string CompartmentNo { get; set; }
        public string KhasraNo { get; set; }
        public string ROFRPATTANO { get; set; }
        public string Boundaries_Description { get; set; }
        public string Total_CFR_Members { get; set; }
        public string Total_Extent { get; set; }
        public string CFR_Nature { get; set; }
        public string Utilization_Status { get; set; }
        public string Support_Required { get; set; }
        public string Remarkscrf { get; set; }
        public string CFR_Document { get; set; }
        public string user_name { get; set; }
        public string IPADDRESS { get; set; }

        //end crfmodel
        public string Recordid { get; set; }
        public string GramaPanchayatCode { get; set; }
        public string GgeographicalArea { get; set; }
        public string TotalHH { get; set; }
        public string TotalPopulation { get; set; }

        public string TotalMale { get; set; }
        public string TotalFemale { get; set; }
        public string TotalSC { get; set; }
        public string SCMale { get; set; }
        public string SCFemale { get; set; }
        public string TotalST { get; set; }
        public string STMale { get; set; }
        public string STFemale { get; set; }
        public string VillageStatus { get; set; }
        public string VillageCategory { get; set; }

        public string ForestHectares { get; set; }
        public string PTYPE { get; set; }
        public string ApUniqueID { get; set; }
        public string Aadhaarno { get; set; }
        public string Benificiaryid { get; set; }
        public string uniquId { get; set; }
        //newly adding 10-02-2025
        public string VoID { get; set; }
        public string VillageCode { get; set; }
        public string VoName { get; set; }
        public string VoAName { get; set; }
        public string VoAMobile { get; set; }
        public string Shgid { get; set; }
        public string ShgName { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemMobileNo { get; set; }
        public string MemberUId { get; set; }
        public string HavingKitchenGarden { get; set; }
        public string KitchenGardenSize { get; set; }
        public string KitchenGardenLoc { get; set; }
        public string WillingKitGarden { get; set; }
        public string WillingKitchenGardenSize { get; set; }
        public string WillingKitchenGardenLoc { get; set; }
        public string HavingIndvhhCompit { get; set; }
        public string CompoundpitSize { get; set; }
        public string IndvhhcompitLength { get; set; }
        public string Indvhhcompitwidth { get; set; }
        public string IndvhhcompitDepth { get; set; }
        public string IsSiteAvilable { get; set; }
        public string SiteLength { get; set; }


        public string panchayatcode { get; set; }

        public string SiteSize { get; set; }
        public string FamilySize { get; set; }
        public string SiteLen { get; set; }
        public string SiteWidth { get; set; }
        public string SiteDepth { get; set; }
        public string SHGGroupID { get; set; }

        //10-02-2025 End







        public string Status { get; set; }
        public string Message { get; set; }
        public HouseholdData[] HHData { get; set; }
        //end here
        public string itdacode { get; set; }
        public string Districtcode { get; set; }
        public string mancode { get; set; }
        public string Rvillage { get; set; }
        public string village { get; set; }
        public string year { get; set; }
        public string Section { get; set; }
        public string Ups { get; set; }
        public string typename { get; set; }
        public string Internetavailable { get; set; }
        public string Providername { get; set; }
        public string Internetspeed { get; set; }
        public string Routeravailable { get; set; }
        public string Internetallclassrooms { get; set; }

        //newly adding for ankaiah

        public string Complaintid { get; set; }
        public string ComplaintStatus { get; set; }
        public string Remarks { get; set; }
        public string InsertedBy { get; set; }

        public string devicename { get; set; }
        public string SoftwareInstall { get; set; }
        public string ComplaintTitle { get; set; }
        public string ComplaintDesc { get; set; }
        public string ComplaintLatitude { get; set; }
        public string ComplaintLongitude { get; set; }

        public string TechLatitude { get; set; }
        public string TechLongitude { get; set; }

        public string Technicianid { get; set; }
        public string DiseCode { get; set; }
        public string Classname { get; set; }
        public string Classtype { get; set; }
        public string Camera { get; set; }
        public string Projector { get; set; }
        public string Speakers { get; set; }
        public string Cpu { get; set; }
        public string DeviceLatitude { get; set; }
        public string DeviceLongitude { get; set; }

        public string Id { get; set; }
        public string Frangebeats { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string allForestbeat { get; set; }
        public string forestrange { get; set; }
        public string Benificiary { get; set; }
        public string divirange { get; set; }
        public string rangebeats { get; set; }
        public string NoofBeats { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        public string end { get; set; }
        public string ITDANAME { get; set; }
        public string phasetype { get; set; }
        public string Itdastart { get; set; }
        public string type { get; set; }
        public string Insertby { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string VideoUpload { get; set; }
        public string RuralTourism { get; set; }
        public string HeritageTourism { get; set; }
        public string BuddhistTourism { get; set; }
        public string EcoTourism { get; set; }
        public string BeachWaterBaseTourism { get; set; }
        public string AdvenRecreationTourism { get; set; }
        public string ReligiousTourism { get; set; }
        public string CuisineTourism { get; set; }
        public string WellnessTourism { get; set; }
        public string MICETourism { get; set; }
        public string MedicalTourism { get; set; }
        public string NationalInstiUnivesity { get; set; }
        public string IndustryTrade { get; set; }
        public string Nameoftourdestination { get; set; }
        public string Tourattraindestination { get; set; }
        public string Howtoreach { get; set; }
        public string Nearestrailbusairport { get; set; }
        public string SurveyorMobileNo { get; set; }
        public string SurveyorDesignation { get; set; }
        public string SurveyorName { get; set; }
        public string VacantExtentofLandAcrs { get; set; }
        public string AffectedExtentofLandAcrs { get; set; }
        public string UtlizedExtentofLandAcrs { get; set; }
        public string ExtentofLandAcrs { get; set; }
        public string AvailableAmenities { get; set; }
        public string DistanceFromNearestCity { get; set; }
        public string FunctionalJurisdiction { get; set; }
        public string UsageClassification { get; set; }
        public string ThematicClassification { get; set; }
        public string Modeofoperation { get; set; }
        public string Landstatus { get; set; }
        public string Fieldtype { get; set; }
        public string Landpossession { get; set; }
        public string Propertytype { get; set; }
        public string SurveyNo { get; set; }
        public string caste { get; set; }
        public string gender { get; set; }
        public string dob
        {
            get; set;

        }
        public string hAddress
        {
            get; set;
        }

        public string input1 { get; set; }
        public string input2 { get; set; }
        public string input3 { get; set; }
        public string input4 { get; set; }
        public string input5 { get; set; }

        public string ration { get; set; }

        public string vid { get; set; }

        public string mid { get; set; }
        public string did { get; set; }
        public string finyear { get; set; }
        public string uid { get; set; }
        public string screen { get; set; }
        public string basestring { get; set; }

        public string imagepaths { get; set; }
        public string extension { get; set; }

        public string Password { get; set; }
        public string Mobileno { get; set; }
        public string imagepath { get; set; }


        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

        public string pevent { get; set; }

        public string stockid { get; set; }
        public string approvalstatus { get; set; }
        public string desiganation { get; set; }

        public string Pflag { get; set; }
        public string ReportDate { get; set; }




        public string userprevilages { get; set; }

        public string benid { get; set; }
        public string imagename { get; set; }
        public string rev_village { get; set; }

        public string privilages { get; set; }

        public string id { get; set; }
        public string start { get; set; }

        public string Phase_Name { get; set; }
        public string rev_village_code { get; set; }
        public string Benificiary_id { get; set; }
        public string Itda { get; set; }
        public string Type { get; set; }
        public string dlcid { get; set; }
        public string District_Code { get; set; }
        public string District { get; set; }
        public string Mandal_Code { get; set; }
        public string Mandal { get; set; }
        public string Grama_Panchayat_Code { get; set; }
        public string Gram_Panchayat { get; set; }
        public string Village_Code { get; set; }
        public string Village { get; set; }
        public string Habitation { get; set; }
        public string Forest_DivisionCode { get; set; }
        public string Forest_Division { get; set; }
        public string Forest_RangeCode { get; set; }
        public string Forest_Range { get; set; }
        public string Forest_BeatCode { get; set; }
        public string Forest_Beat { get; set; }
        public string Forest_Block { get; set; }
        public string Compartment_No { get; set; }
        public string Plot_No { get; set; }
        public string ExtentPlotArea { get; set; }
        public string Uncultivable_Land { get; set; }
        public string Cultivable_Land { get; set; }
        public string PATTA_INAMGOVT { get; set; }
        public string Water_Tax { get; set; }
        public string DRYID_ONECROP_TWO_CROP { get; set; }
        public string WATER_SOURCE { get; set; }
        public string EXTENT_IRRIGATED { get; set; }
        public string ROFR_PATTANO { get; set; }
        public string ROFR_PATTADAAR { get; set; }
        public string CULTIVATOR_NAME { get; set; }
        public string EXTENT_UNDER_CULTIVATOR { get; set; }
        public string HOLDING_NATURE { get; set; }
        public string TYPE_CODE { get; set; }
        public string EXTENT { get; set; }
        public string NET_SOWN_AREA { get; set; }
        public string KHARIFF_RABI { get; set; }
        public string MONTH_OF_CULTIVATION { get; set; }
        public string CROP { get; set; }
        public string SINGLE { get; set; }
        public string MIXED { get; set; }
        public string TOTAL { get; set; }
        public string WATER_SOURCE1 { get; set; }
        public string FIRST_CROP { get; set; }
        public string SECOND_THIRD_CROP { get; set; }
        public string CROP_YIELD { get; set; }
        public string VRO_RI_REMARKS { get; set; }
        public string TAHSILDAR_REMARKS { get; set; }
        public string REMARKS { get; set; }
        public string Aadhaar_NO { get; set; }

        public string Dlc { get; set; }
        public string Image { get; set; }

        public string Imagepath { get; set; }
        public string Dlcpath { get; set; }
        public string Ipaddress { get; set; }

        public string UserName { get; set; }
        public string HabitationCode { get; set; }
        public string landclassifcation { get; set; }

        public string dlcdate { get; set; }
        public string bankname { get; set; }
        public string bankaccountno { get; set; }
        public string ifsccode { get; set; }
        public string fathername { get; set; }
        public string aadhaarstatus { get; set; }

        public string postofficeaccount { get; set; }
        public string ponumber { get; set; }
        public string poname { get; set; }
        public string sub_caste { get; set; }
        public string Itdacode { get; set; }
        public string Modified_by { get; set; }
        public string Land_Filename { get; set; }
        public string Land_Image { get; set; }
        public string Version { get; set; }

        //New Properties for checking

        public string DistrictName { get; set; }
        public string DistrictId { get; set; }
        public string RbkId { get; set; }
        public string Category { get; set; }
        public string Unitofmeasurement { get; set; }
        public string Quantity { get; set; }
        public string Indentraisedby { get; set; }


        public string Unitid { get; set; }
        public string unitprice { get; set; }
        public string categoryid { get; set; }

        public string Damage { get; set; }


        public DateTime IndentDate { get; set; }

        public string StockReceivedBy { get; set; }
        public DateTime StockReceivedDate { get; set; }

        public string vStockReceivedDate { get; set; }
        public string VoucharNo { get; set; }
        public string Amount { get; set; }
        public string TotalAmount { get; set; }


        public string Reason { get; set; }

        public DateTime PaymentDate { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

    public class land_transfer_regulation
    {
        public int Id { get; set; }
        public string hab { get; set; }
        public string ltrid { get; set; }
        public string Itda { get; set; }
        public string District { get; set; }
        public string village { get; set; }
        public string mandal { get; set; }
        public string ltrp_no { get; set; }
        public string ltrp_date { get; set; }
        public string OLDltrp_date { get; set; }
        public string sdc_casestatus { get; set; }
        public string sdc_level { get; set; }
        public string rsno { get; set; }
        public string extent_ac_cts { get; set; }
        public string cma_no { get; set; }
        public string cma_date { get; set; }
        public string add_datedisposal { get; set; }
        public string add_casestatus { get; set; }

        public string additional_nt { get; set; }
        public string additional_tri { get; set; }
        public string additional_govt { get; set; }
        public string appeal_no { get; set; }
        public string appeal_date { get; set; }
        public string appeal_disposal { get; set; }
        public string appeal_casestatus { get; set; }
        public string agent_nt { get; set; }
        public string agent_tri { get; set; }
        public string agent_govt { get; set; }
        public string rpno { get; set; }
        public string rpno_date { get; set; }
        public string gov_disposal { get; set; }
        public string gov_casestatus { get; set; }
        public string govt_nt { get; set; }
        public string govt_tri { get; set; }
        public string govt_govt { get; set; }
        public string wpno { get; set; }
        public string wpno_date { get; set; }
        public string hc_disposal { get; set; }
        public string hc_wpmpno { get; set; }
        public string hc_wpmpno_status { get; set; }
        public string hc_casestatus { get; set; }

        public string high_nt { get; set; }
        public string high_court_tri { get; set; }
        public string high_court_govt { get; set; }
        public string land_already { get; set; }
        public string remarks { get; set; }
        public string Details_T_Ac_cts { get; set; }
        public string Details_T_Hec_A { get; set; }
        public string Details_G_Ac_cts { get; set; }
        public string Details_G_Hec_A { get; set; }
        public string orders_passed_nt { get; set; }
        public string orders_passed_tri { get; set; }
        public string orders_passed_govt { get; set; }
        public string Rdo_sdc_orders { get; set; }
        public string collector_po { get; set; }
        public string govt_doc { get; set; }
        public string high_court_doc { get; set; }
        public string cmadate { get; set; }
        public string appealdate { get; set; }
        public string rpdate { get; set; }
        public string wpdate { get; set; }

        public string Ipaddress { get; set; }

        public string UserName { get; set; }
        public string petitioner { get; set; }
        public string respondent { get; set; }
        public string add_nt_name { get; set; }
        public string add_nt_extent { get; set; }
        public string add_tri_name { get; set; }
        public string add_tri_extent { get; set; }
        public string add_gov_name { get; set; }
        public string add_gov_extent { get; set; }
        public string agent_nt_name { get; set; }
        public string agent_nt_extent { get; set; }
        public string agent_tri_name { get; set; }

        public string agent_tri_extent { get; set; }
        public string agent_gov_name { get; set; }
        public string agent_gov_extent { get; set; }
        public string gov_tri_name { get; set; }
        public string gov_tri_extent { get; set; }
        public string gov_nt_name { get; set; }
        public string gov_nt_extent { get; set; }
        public string gov_gov_name { get; set; }
        public string gov_gov_extent { get; set; }
        public string hc_tri_name { get; set; }
        public string hc_tri_extent { get; set; }
        public string hc_nt_name { get; set; }
        public string hc_nt_extent { get; set; }
        public string hc_gov_name { get; set; }
        public string hc_gov_extent { get; set; }
        public string add_remarks { get; set; }
        public string agent_remarks { get; set; }
        public string gov_remarks { get; set; }
        public string hc_remarks { get; set; }
        public string add_orders_passed { get; set; }
        public string agent_orders_passed { get; set; }
        public string govt_orders_passed { get; set; }
        public string hc_orders_passed { get; set; }
        public string sdc_orders_passed { get; set; }
        public string sdc_nt_name { get; set; }
        public string sdc_nt_extent { get; set; }
        public string sdc_tri_name { get; set; }
        public string sdc_tri_extent { get; set; }
        public string sdc_gov_name { get; set; }
        public string sdc_gov_extent { get; set; }
        public string sdc_tri_impl { get; set; }
        public string sdc_gov_impl { get; set; }
        public string add_tri_impl { get; set; }
        public string add_gov_impl { get; set; }
        public string agent_tri_impl { get; set; }
        public string agent_gov_impl { get; set; }
        public string gov_tri_impl { get; set; }
        public string gov_gov_impl { get; set; }
        public string hc_tri_impl { get; set; }
        public string hc_gov_impl { get; set; }
        public string agent_level { get; set; }
        public string add_level { get; set; }
        public string gov_level { get; set; }
        public string hc_level { get; set; }
        public string districtname { get; set; }








    }
    public class rejected_claims
    {
        public string itdaname { get; set; }
        public string claimid { get; set; }
        public string nature_of_evidence { get; set; }
        public string rejection_reason { get; set; }
        public string rejection_notice_issued { get; set; }
        public string present_land_status { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string remarks { get; set; }
        public string modified_date { get; set; }
        public string modified_by { get; set; }
        public string IPaddress { get; set; }
        public string imgbase64 { get; set; }
        public string filepath { get; set; }
        public string geo_coordinates { get; set; }

        public string LEVEL_OF_REJECTION { get; set; }
        public string DISTRICT { get; set; }
        public string GRAM_PANCHAYAT { get; set; }
        public string VILLAGE_HABITATION { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string FOREST_DIVISION { get; set; }
        public string FOREST_RANGE { get; set; }
        public string FOREST_BEAT { get; set; }
        public string COMPARTMENT_NO { get; set; }
        public string EXTENT_PLOT_AREA { get; set; }
        public string evidence { get; set; }
        public string evidencepath { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q3_Y { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }
        public string Q6 { get; set; }
        public string Q6_Y { get; set; }
        public string Mandal { get; set; }

    }
    public class adhar_detials
    {
        public string bid { get; set; }
        public string adharstatus { get; set; }
        public string adharno { get; set; }
        public string adharname { get; set; }
        public string careof { get; set; }

        public string statecode { get; set; }
        public string distcode { get; set; }
        public string distname { get; set; }
        public string mandalcode { get; set; }
        public string mandal { get; set; }
        public string vcode { get; set; }
        public string vname { get; set; }
        public string street { get; set; }
        public string pincode { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string phoneno { get; set; }
        public string Image1 { get; set; }
        public string Imagepath { get; set; }

    }
    public class Loan_details
    {
        public string login_user { get; set; }
        public string bank_name { get; set; }
        public string branch_name { get; set; }
        public string itda { get; set; }
        public string dist { get; set; }

        public string mandal { get; set; }
        public string village { get; set; }
        public string division { get; set; }
        public string range { get; set; }
        public string beat { get; set; }
        public string block { get; set; }
        public string type { get; set; }
        public string username { get; set; }
        public string userprev { get; set; }
    }

    public class Rtgs
    {


        public string beficiaryId { get; set; }
        public string itdaName { get; set; }
        public string districtName { get; set; }
        public string districtId { get; set; }
        public string mandalName { get; set; }
        public string mandalId { get; set; }
        public string revVillageId { get; set; }
        public string revVillageName { get; set; }
        public string villageName { get; set; }
        public string villageId { get; set; }
        public string pattadharName { get; set; }
        public string fatherName { get; set; }
        public string uidNum { get; set; }
        public string caste { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string mobileNumber { get; set; }
        public string surveyNo { get; set; }
        public string khathaNo { get; set; }
        public string extent { get; set; }

    }
    public class Agriculture
    {
        public string Districtcode { get; set; }
        public string Mandalcode { get; set; }
        public string Villagecode { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string key { get; set; }
    }

    public class CropDetails
    {
        public int ITDA_Code { get; set; }
        public string Itda { get; set; }

        public int District_Code { get; set; }
        public string district { get; set; }

        public int Mandal_Code { get; set; }
        public string mandal { get; set; }

        public int Panchayat_Code { get; set; }
        public string panchayat { get; set; }
        public string Rev_Village_code { get; set; }
        public string village { get; set; }
        public string Habitation { get; set; }
        public string Benificiaryid { get; set; }
        public string Crop_Code { get; set; }
        public string Crop_Name { get; set; }
        public string Crop_Category_Code { get; set; }
        public string Crop_Category_Name { get; set; }

    }

}