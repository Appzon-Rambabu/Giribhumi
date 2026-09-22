using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace ROFR.Loans.CSFiles
{
    [RoutePrefix("API/LoansAPI")]
    public class LoansAPIController : ApiController
    {
        ResponseModel _response = new ResponseModel();
        LoansHelper _Lhel = new LoansHelper();
        dynamic CatchData = new ExpandoObject();

        #region Login Module
        [HttpPost]
        [Route("GetCaptcha")]
        public dynamic GetCaptcha(dynamic data)
        {
            string jsondata = JsonConvert.SerializeObject(data);

            try
            {
                UserLoginCls val = JsonConvert.DeserializeObject<UserLoginCls>(jsondata);
                return Ok(_Lhel.check_s_captch(val));
            }
            catch (Exception ex)
            {
                _response.Status = 102;
                _response.Reason = "Error Occured While Load Captch";
                return Ok(_response);
            }
        }

        [HttpPost]
        [Route("GBLIUserLogin")]
        public dynamic GBLIUserLogin(dynamic data)
        {

            string jsondata = JsonConvert.SerializeObject(data); //token_gen.Authorize_aesdecrpty(data);
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;

                string mappath = HttpContext.Current.Server.MapPath("LoginLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_Log(mappath, jsondata));

                UserLoginCls root = JsonConvert.DeserializeObject<UserLoginCls>(jsondata);
                return Ok(_Lhel.GBLIUserLogin(root));

            }
            catch (Exception ex)
            {
                _response.Status = 102;
                _response.Reason = "Error Occured While Login";
                return Ok(_response);
            }
        }

        #endregion

        #region Admin Module

        [HttpPost]
        [Route("AdminCommonData")]
        public IHttpActionResult AdminCommonData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                UserLoginCls rootobj = JsonConvert.DeserializeObject<UserLoginCls>(value);
                return Ok(_Lhel.LoadCommonData_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        [HttpPost]
        [Route("UpdateUserData")]
        public IHttpActionResult UpdateUserData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                UserLoginCls rootobj = JsonConvert.DeserializeObject<UserLoginCls>(value);
                return Ok(_Lhel.UpdateUser_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        #endregion

        #region Adangal Module

        [HttpPost]
        [Route("LoanAdangalData")]
        public IHttpActionResult LoanAdangalData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                AdangalCls rootobj = JsonConvert.DeserializeObject<AdangalCls>(value);
                return Ok(_Lhel.LoanAdangalData_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        #endregion

        #region Loans Module

        [HttpPost]
        [Route("LoanChargeCommonData")]
        public IHttpActionResult LoanChargeCommonData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                CommonCls rootobj = JsonConvert.DeserializeObject<CommonCls>(value);
                return Ok(_Lhel.LoadLoansCommonData_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        [HttpPost]
        [Route("SaveCreationData")]
        public IHttpActionResult SaveCreationData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                CommonCls rootobj = JsonConvert.DeserializeObject<CommonCls>(value);
                return Ok(_Lhel.LoadLoansCommonData_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Saving Data";
                return Ok(CatchData);
            }

        }

        #endregion

        #region Reports Module

        [HttpPost]
        [Route("LoadReportsData")]
        public IHttpActionResult LoadReportsData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                ReportsCls rootobj = JsonConvert.DeserializeObject<ReportsCls>(value);
                return Ok(_Lhel.LoadReportsCommonData_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        [HttpPost]
        [Route("LoadReportsDataBranchWise")]
        public IHttpActionResult LoadBranchWiseData(dynamic data)
        {
            //string value = token_gen.Authorize_aesdecrpty(data);
            try
            {

                string value = JsonConvert.SerializeObject(data);
                ReportsCls rootobj = JsonConvert.DeserializeObject<ReportsCls>(value);
                return Ok(_Lhel.LoadBranchWise_Helper(rootobj));
            }
            catch (Exception ex)
            {
                CatchData.Status = 102;
                CatchData.Reason = "Error Occured While Load Data";
                return Ok(CatchData);
            }

        }

        #endregion
    }
}