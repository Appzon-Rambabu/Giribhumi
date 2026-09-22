
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using ROFR.helper;

using System.Dynamic;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

using ROFR.Models;
using System.Configuration;
using ROFR.NewHelper;

namespace ROFR.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("Giribhumi")]
    public class NewGiribhumiController : ApiController
    {
        NewGiribhumiSupport gs = new NewGiribhumiSupport();
        //GiribhumiSupport gs = new GiribhumiSupport();
        Profile.Security ps = new Profile.Security();
        dynamic obj_data = new ExpandoObject();
        SQLManager sm = new SQLManager();


        // For Get_Not_HavingLand_Details 
        [HttpPost]
        [Route("Get_Not_HavingLand_Details")]
        public dynamic Get_Not_HavingLand_Details_Report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Landstatus_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_NotHaving_LandDetais_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Landstatus_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // for  LatlongsAbstractReport 
        [HttpPost]
        [Route("GetLatlongsAbstract_report")]
        public dynamic GetLatlongsAbstract_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("LatlongsAbstract_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_LatlongsAbstract_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("LatlongsAbstract_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For  Land_Invalid_Data 
        [HttpPost]
        [Route("GetLand_Invalid_Data_report")]
        public dynamic GetLand_Invalid_Data_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Land_Invalid_Data_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_Land_Invalid_Data_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Land_Invalid_Data_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For  DCL_Abstract 
        [HttpPost]
        [Route("GetDCL_Abstract_report")]
        public dynamic GetDCL_Abstract_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("DCL_Abstract_report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_DCL_Abstract_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DCL_Abstract_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For  Farmer_Images Report 
        [HttpPost]
        [Route("GetFarmer_Images_report")]
        public dynamic GetFarmer_Images_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Images Report_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_Farmer_Images_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Images Report_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For  Itda_wise_Farmer_Details GetItdabencount
        [HttpPost]
        [Route("GetItda_wise_Farmer_Details")]
        public dynamic GetItda_wise_Farmer_Details(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_ItdawiseFarmer_Details(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For   GetItdabencount
        [HttpPost]
        [Route("GetItda_ben_count")]
        public dynamic GetItdabencount(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetItdabencountDetails(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For  RofrLandPhasesReport
        [HttpPost]
        [Route("GetRofr_Land_Phases_Report")]
        public dynamic GetRofrLandPhasesReport(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("RofrLandPhasesReport_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_RofrLandPhasesReport(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("RofrLandPhasesReport_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For DataAnalysis_MandatoryFields
        [HttpPost]
        [Route("DataAnalysis_MandatoryFields")]
        public dynamic GetDataAnalysis_MandatoryFields_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("DataAnalysis_MandatoryFields_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_DataAnalysis_MandatoryFields_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DataAnalysis_MandatoryFields_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        // For DataAnalysis_NonMandatoryFields
        [HttpPost]
        [Route("DataAnalysis_NonMandatoryFields")]
        public dynamic GetDataAnalysis_NonMandatoryFields_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("DataAnalysis_NonMandatoryFields_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_DataAnalysis_NonMandatoryFields_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DataAnalysis_NonMandatoryFields_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }



        [HttpPost]
        [Route("GetItda_wise_Beneficiary_Details")]
        public dynamic GetItda_wise_Beneficiary_Details(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_Itdawise_Beneficiary_Details(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Itda_wise_Farmer_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("GetDistrict_wise_BeneficiaryMaster_Abstract")]
        public dynamic GetDistrict_wise_BeneficiaryMaster_Abstract(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("District_wise_BeneficiaryMaster_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.District_wise_BeneficiaryMaster_Abstract(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("District_wise_BeneficiaryMaster_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For FarmerUpdate
        [HttpPost]
        [Route("Farmer_Update")]
        public dynamic GetFarmer_Update(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Update_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_FarmerUpdate_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Update_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("Farmer_Data_Update")]
        public dynamic Farmer_DataUpdate(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Update_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetFarmerDataUpdate(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Farmer_Update_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        // For Missing Data Load Itda
        [HttpPost]
        [Route("Missing_Data_Load_Itda")]
        public dynamic GetMissingDataLoad_Itda(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("MissingDataLoad_Itda_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_MissingData_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("MissingDataLoad_Itda_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Missing Data Load District
        [HttpPost]
        [Route("Missing_Data_Load_District")]
        public dynamic GetMissingDataLoad_District(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("MissingDataLoad_District_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_MissingData_Dis_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("MissingDataLoad_District_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Missing Data DownLoad 
        [HttpPost]
        [Route("Missing_Data_DownLoad")]
        public dynamic GetMissingDataDownLoad(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Missing_Data_DownLoad_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_MissingData_Download_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Missing_Data_DownLoad_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For Get_rythubarosa_may20
        [HttpPost]
        [Route("Rythubarosa_May20")]
        public dynamic GetRythubarosaPaymentStatusMay20(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_may20_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_rythubarosa_may20(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_may20_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For Get_rythubarosa_may20
        [HttpPost]
        [Route("Rythubarosa_May21")]
        public dynamic GetRythubarosaPaymentStatusMay21(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_may20_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_rythubarosa_may21(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_may20_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For Get_rythubarosa_oct20
        [HttpPost]
        [Route("Rythubarosa_Oct20")]
        public dynamic GetRythubarosaPaymentStatusOct20(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_OCT20_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_rythubarosa_oct20(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_rythubarosa_OCT20_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }



        // For Get_DistictData_Analysis
        [HttpPost]
        [Route("DistictData_Analysis")]
        public dynamic GetDistictData_Analysis(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_DistictData_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_DistictData_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_DistictData_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Get_BenificiaryMaster
        [HttpPost]
        [Route("BenificiaryMaster_Analysis")]
        public dynamic GetBenificiaryMaster_Analysis(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_BenificiaryMaster_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_Beni_Master_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_BenificiaryMaster_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Get_ALLForestBeats
        [HttpPost]
        [Route("ALLForestBeats_Analysis")]
        public dynamic GetALLForestBeat_Master_Analysis(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ALLForestBeats_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_AllForestBeat_Master_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ALLForestBeats_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Get_ALLForestBeats
        [HttpPost]
        [Route("ForestRange_Analysis")]
        public dynamic GetForestRange_Master_Analysis(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestRange_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_ForestRange_Master_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestRange_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For Get_ForestDivision
        [HttpPost]
        [Route("ForestDivision_Analysis")]
        public dynamic GetForestDivision_Master_Analysis(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestDivision_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_ForestDivision_Master_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestDivision_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // For Get_CurdForestDivision GetForestMasterDetails
        [HttpPost]
        [Route("CurdForestDivision_Analysis")]
        public dynamic GetCurdForestDivision_Analysis(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestDivision_Analysis_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_CurdForestDivision_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ForestDivision_Analysis_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For GetForestMasterDetails GetForestMasterDetails
        [HttpPost]
        [Route("GetForestDivisionDetails")]
        public dynamic GetForestMasterDetails(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("GetForestMasterDetails_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetForestMasterDetails_Analysis(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("GetForestMasterDetails_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("ForestDivision_Update")]
        public dynamic ForestDivision_Update(addbeneficiary_details obj)
        {
            try
            {
               
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                obj.Ipaddress = ipaddress;
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("ForestDivision_Update_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_ForestDivisionUpdate(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("ForestDivision_Update_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }



        [HttpPost]
        [Route("TwdCommentsReport")]
        public dynamic Twd_Comments_Report(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_TwdComments(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For   Get_Update_LtrCases
        [HttpPost]
        [Route("Get_Update_LtrCases")]
        public dynamic GetUpdateLtrCases(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_Update_LtrCases_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetUpdateLtrCases(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_Update_LtrCases_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        // For   Get_Update_LtrCases
        [HttpPost]
        [Route("Get_Update_LtrCases_Details")]
        public dynamic GetUpdateLtrCasesDetails(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_Update_LtrCases_Details_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetUpdateLtrCasesDetails(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_Update_LtrCases_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("LandHolding")]
        public dynamic LandHolding(addbeneficiary_details obj)
        {

            try
            {
                return gs.Get_LandHolding(obj);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("websitevisitor")]
        public dynamic WebsiteVisitors(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("websiteVisi_Update_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetwebSiteVisiDataUpdate(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("websiteVisi_Update_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }



        // For   Get_GetViewLtr
        [HttpPost]
        [Route("GetViewLtr")]
        public dynamic GetViewLtr(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ViewLtr_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetViewLtrs(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ViewLtr_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // Get_viewLtrData
        [HttpPost]
        [Route("GetLtrData")]
        public dynamic GetLtrData(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("Get_ViewLtrData_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.GetViewLtrsData(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Get_ViewLtrData_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("getmulti")]
        public dynamic GetMulti(string v1,string v2,string v3)
        {
            string x = v1 + " " + v2;
            return x;
        }

        [HttpPost]
        [Route("FarmerLand_Detailsreport")]
        public dynamic FarmerLand_Detailsreport(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("FarmerLand_Details_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.FarmerLand_Details(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("FarmerLand_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        
        [HttpPost]
        [Route("DropdownsLoad")]
        public dynamic VGetdata(addbeneficiary_details obj)
        {

            try
            {
                return gs.Getdata1(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetVillageData")]
        public dynamic Villagedata(addbeneficiary_details obj)
        {

            try
            {
                return gs.Getdata2(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("VillageValiUpdate")]
        public dynamic VillageVali_Update(addbeneficiary_details obj)
        {

            try
            {
                return gs.VillageValiUpdated(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("GetDropdownsDataCfr")]
        public dynamic DropdownSData(addbeneficiary_details obj)
        {

            try
            {
                return gs.GetDropdowns(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

       
        NewGiribhumi_Get userObj = new NewGiribhumi_Get();
        [HttpPost]
        [Route("CRfInsertion")]
        public async Task<IHttpActionResult> Insertioncfrdata()
        {
            dynamic obj_data = new ExpandoObject();

            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return BadRequest("Unsupported media type");
                }

                string uploadsFolder = ConfigurationManager.AppSettings["pdfcrf"].ToString();
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var provider = new MultipartFormDataStreamProvider(uploadsFolder);
                await Request.Content.ReadAsMultipartAsync(provider);

                string filePath = null;
                string fileName = null;

                // File upload
                if (provider.FileData.Count > 0)
                {
                    var fileData = provider.FileData[0];
                    string originalFileName = fileData.Headers.ContentDisposition.FileName.Trim('"');

                    // ✅ Keep original file name instead of renaming
                    fileName = Path.GetFileName(originalFileName);

                    string tempFilePath = fileData.LocalFileName;
                    filePath = Path.Combine(uploadsFolder, fileName);

                    // If file already exists, you may want to add timestamp to avoid overwrite
                    if (File.Exists(filePath))
                    {
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                        string ext = Path.GetExtension(fileName);
                        fileName = $"{nameWithoutExt}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                        filePath = Path.Combine(uploadsFolder, fileName);
                    }

                    File.Move(tempFilePath, filePath);
                }

                // JSON model
                var jsonModel = provider.FormData["model"];
                var obj = JsonConvert.DeserializeObject<addbeneficiary_details>(jsonModel);

                // Stored procedure call

                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                obj.IPADDRESS = ipaddress;
                DataTable dt = userObj.Crfinsertion_sp(obj, fileName, filePath);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = dt.Rows[0]["STATUS"]?.ToString();
                    obj_data.Message = dt.Rows[0]["STATUS_TEXT"]?.ToString();
                    obj_data.retId = dt.Rows[0]["CFR_ID"]?.ToString();
                    obj_data.FileName = fileName;
                    obj_data.FilePath = filePath;
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "No data returned";
                }
            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message;
            }

            return Ok(obj_data); // ✅ Correct IHttpActionResult return
        }


        [HttpPost]
        [Route("GetCfrData")]
        public dynamic Cfrdata(addbeneficiary_details obj)
        {

            try
            {
                return gs.Getcfrdata(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [HttpPost]
        [Route("GetCfrData1")]
        public dynamic Cfrdata1(addbeneficiary_details obj)
        {

            try
            {
                return gs.Getcfrdata1(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("FarmerInsertionofcfr")]
        public IHttpActionResult GetFarmerdata(List<addbeneficiary_details> objList)
        {
            try
            {
                foreach (var obj in objList)
                {
                    gs.CFR_FARMERINSERTION(obj);
                }
                return Ok(new { Status = "1", Message = "Farmers Submitted Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("cfrmfrSavedata")]
        public IHttpActionResult GetcfrSaveData([FromBody] List<addbeneficiary_details> objList)
        {
            try
            {
                if (objList == null || objList.Count == 0)
                {
                    return BadRequest("Invalid request. Farmer list is empty.");
                }
                var results = new List<dynamic>();
                foreach (var obj in objList)
                {
                    var result = gs.CFR_mfpsave(obj);
                    results.Add(result);
                }
                if (results.All(r => r.Status == "1"))
                {
                    return Ok(new { Status = "1", Message = "Data Inserted successfully", Details = results });
                }
                else
                {
                    return Ok(new { Status = "0", Message = "Some records failed", Details = results });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("AadharChecking")]
        public dynamic AadhaarCheck(addbeneficiary_details obj)
        {

            try
            {
                return gs.AadharCheckexist(obj);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }



        [HttpPost]
        [Route("GetCFR_report")]
        public dynamic GetCFR_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("cfr_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_CFR_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("cfr_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        //06-11-2025 Housing Report
        [HttpPost]
        [Route("GetHousing_report")]
        public dynamic GetHousing_report(addbeneficiary_details obj)
        {

            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("housing_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.Get_Housing_report(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("housing_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("viewcfrData")]
        public dynamic viewcfrData(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("viewdata_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.viewcfrdatadet(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("viewdata_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }


        [HttpPost]
        [Route("viewcfrDatadetails")]
        public dynamic viewcfrDatadetails(addbeneficiary_details obj)
        {
            try
            {
                string logdata = JsonConvert.SerializeObject(obj);
                addbeneficiary_details dlogdata = JsonConvert.DeserializeObject<addbeneficiary_details>(logdata);
                string mappath = HttpContext.Current.Server.MapPath("viewdata_SuccessLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));
                return gs.viewcfrdatadetDetails(obj);
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("viewdata_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
        [HttpPost]
        [Route("agricultureHorticulture")]
        public dynamic agricultureHorticulture()
        {

            try
            {
                return gs.viewagricultureHorticulture();
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("viewdata_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        [HttpPost]
        [Route("getCultivationReport")]
        public dynamic getCultivationReport()
        {
            try
            {
                return gs.viewagetCultivationReport();
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("viewdata_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        [HttpPost]
        [Route("getPMKisanReport")]
        public dynamic getPMKisanReport()
        {
            try
            {
                return gs.viewagetPMKisanReport();
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("viewdata_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

    }


}
