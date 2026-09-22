using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Cors;
using ROFR.Models;
using ROFR.helper;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ROFR.Controllers
{
    
    public class ITDAController : ApiController
    {
        Landsettlementpattas latlonhelper = new Landsettlementpattas();



        [HttpPost]
        [Route("api/ITDA/GetApikey")]
        public IHttpActionResult Getkey()
        {
            latlongsModel objdata = new latlongsModel();

            try
            {
                string ipaddress =HttpContext.Current.Request.UserHostAddress;
                objdata.Ipaddress = ipaddress;
                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var Charsarr = new char[20];
                var random = new Random();

                for (int i = 0; i < Charsarr.Length; i++)
                {
                    Charsarr[i] = characters[random.Next(characters.Length)];
                }
                
                objdata.key = "ROFRGIRIBHUMI"+ new String(Charsarr);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objdata.url = url;
                string jsondata = JsonConvert.SerializeObject(objdata);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
               
                return Ok(latlonhelper.submit_key(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key+ objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/GetRofrPlotsData")]
        public IHttpActionResult GetplsData(string key)
        {
            latlongsModel objdata = new latlongsModel();
            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                objdata.Ipaddress = ipaddress;
                Random ran = new Random();
                objdata.key =key;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objdata.url = url;
                string jsondata = JsonConvert.SerializeObject(objdata);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_Plots_data(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key + objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));


               
            }
        }


        [HttpPost]
        [Route("api/ITDA/Agriculture")]
        public dynamic GetCropdata(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            //latlongsModel objdata = new latlongsModel();
            try
            { 
                string ipaddress = HttpContext.Current.Request.UserHostAddress;

                obj.Ipaddress = ipaddress;
                Random ran = new Random();
                obj.key = obj.key;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                obj.url = url;
                string jsondata = JsonConvert.SerializeObject(obj);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_Crop_data(objroot));
            }
            catch (Exception ex)
            {
              ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
               // throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/GetlandData")]
        public IHttpActionResult GetlandData(latlongsModel objdata)
        {
            
            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                objdata.Ipaddress = ipaddress;
                Random ran = new Random();
                objdata.key = objdata.key;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objdata.url = url;
                string jsondata = JsonConvert.SerializeObject(objdata);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_land_data(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key + objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/Latlongslist")]
        public IHttpActionResult Latlongslist(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_latlonglist(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/MastersLatlongslist")]
        public IHttpActionResult MastersLatlongslist(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_Masterslatlonglist(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        [HttpPost]
        [Route("api/ITDA/ITDAMANDALVILLAGEdropdowns")]
        public IHttpActionResult ITDAMANDALVILLAGEdropdowns(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.ITDAMANDALVILLAGEdropdowns(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/ItdaLatlongslist")]
        public IHttpActionResult ItdaLatlongslist(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_Itdalatlonglist(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/AsetsDashboardValues")]
        public IHttpActionResult AsetsDashboardValues(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.AsetsDashboardValues(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        [HttpPost]
        [Route("api/ITDA/DistrictDropdown")]
        public IHttpActionResult DistrictDropdown(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Villageprofiledropdowns(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

         [HttpPost]
        [Route("api/ITDA/Piechart")]
        public IHttpActionResult Piechartdata(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Piechartdata(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/Villagewiseallassetslatongs")]
        public IHttpActionResult Villagewiseallassetslatongs(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Villagewiseallassetslatongs(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/SubAssetsDetails")]
        public IHttpActionResult SubAssetsDetails(latlongsModel lmobj)
        {
            DataTable dt = new DataTable();


            string url = "http://giripragati.ap.gov.in/Tribalhabitation_centric/Tribalhabitation/TribalHabitation_Resource/getSubassetDetails";

            // GetData(url);
            var val = PostData(url, lmobj);
            var data = GetSerialzedData<dynamic>(val);
            return Ok(data);

        }

        [HttpPost]
        [Route("api/ITDA/SubAssets")]
        public IHttpActionResult SubAssets(latlongsModel lmobj)
        {
            DataTable dt = new DataTable();


            string url = "http://giripragati.ap.gov.in/Tribalhabitation_centric/Tribalhabitation/TribalHabitation_Resource/getAssetsDetails";

            // GetData(url);
            var val = PostData(url, lmobj);
            var data = GetSerialzedData<dynamic>(val);
            return Ok(data);

        }

        [HttpPost]
        [Route("api/ITDA/RoadSubAssets")]
        public IHttpActionResult RoadSubAssets(latlongsModel lmobj)
        {
            DataTable dt = new DataTable();


            string url = "http://giripragati.ap.gov.in/Tribalhabitation_centric/Tribalhabitation/TribalHabitation_Resource/getRoadDetails";

            // GetData(url);
            var val = PostData(url, lmobj);
            var data = GetSerialzedData<dynamic>(val);
            return Ok(data);

        }
        [HttpPost]
        [Route("api/ITDA/Sand")]
        public IHttpActionResult Sand(addbeneficiary_details lmobj)
        {
            DataTable dt = new DataTable();


           // string url = "http://mobilesand.ap.gov.in/RGLZCGF0Y2HNB2JPBGVDA";
            string url = "https://giribhumi.ap.gov.in/Giribhumi/Land_Images_Report";

            // GetData(url);
            var val = PostData(url, lmobj);
            var data = GetSerialzedData<dynamic>(val);
            return Ok(data);

        }



        

        

        public T GetSerialzedData<T>(string Input)
        {
            return JsonConvert.DeserializeObject<T>(Input);
        }


        public dynamic PostData(string url, dynamic jsonData)
        {
            var response = String.Empty;
            try
            {

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Headers.Add("username", "RGlzcGF0Y2g");
                req.Headers.Add("password", "RGlzcGF0Y2hANzUz");
                req.Headers.Add("Session_Key", "969A687C0F273H0852A75347529CF5D385974995FC1B9JJ97CD0RFV07A215RElTUEFUQ0G");
               
                //req.Credentials = CredentialCache.DefaultCredentials;
                WebProxy myProxy = new WebProxy();
                req.Proxy = myProxy;
                req.Method = "POST";
                var _jsonObject = JsonConvert.SerializeObject(jsonData);

                //If there is any json data
                if (!String.IsNullOrEmpty(_jsonObject))
                {
                    using (System.IO.Stream s = req.GetRequestStream())
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                            sw.Write(_jsonObject);


                    }
                }
                req.ContentType = "application/json; charset=utf-8";
                req.AllowAutoRedirect = false;
                var resp = (HttpWebResponse)req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());

                if ((resp.StatusCode == HttpStatusCode.Redirect) || (resp.StatusCode == HttpStatusCode.SeeOther) ||
                    (resp.StatusCode == HttpStatusCode.RedirectMethod))
                {
                }
                else
                {
                    response = sr.ReadToEnd().Trim();
                }
            }
            catch (WebException wex)
            {
                throw new Exception(wex.Message);
            }

            return response;
        }

        


        public dynamic PostData1(string url,string jsonData)
        {
            var response = String.Empty;
            try
            {

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Headers.Add("username", "RGlzcGF0Y2g");
                req.Headers.Add("password", "RGlzcGF0Y2hANzUz");
                req.Headers.Add("Session_Key", "969A687C0F273H0852A75347529CF5D385974995FC1B9JJ97CD0RFV07A215RElTUEFUQ0G");

                //req.Credentials = CredentialCache.DefaultCredentials;
                WebProxy myProxy = new WebProxy();
                req.Proxy = myProxy;
                req.Method = "POST";
                var _jsonObject = JsonConvert.SerializeObject(jsonData);

                //If there is any json data
                if (!String.IsNullOrEmpty(_jsonObject))
                {
                    using (System.IO.Stream s = req.GetRequestStream())
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                            sw.Write(_jsonObject);


                    }
                }
                req.ContentType = "application/json; charset=utf-8";
                req.AllowAutoRedirect = false;
                var resp = (HttpWebResponse)req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());

                if ((resp.StatusCode == HttpStatusCode.Redirect) || (resp.StatusCode == HttpStatusCode.SeeOther) ||
                    (resp.StatusCode == HttpStatusCode.RedirectMethod))
                {
                }
                else
                {
                    response = sr.ReadToEnd().Trim();
                }
            }
            catch (WebException wex)
            {
                throw new Exception(wex.Message);
            }

            return response;
        }

        public dynamic PostDataWithHeaders(string url)
        {
            var response = String.Empty;
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.Credentials = CredentialCache.DefaultCredentials;
                WebProxy myProxy = new WebProxy();
                req.Proxy = myProxy;
                req.Method = "POST";
                //var _jsonObject = JsonConvert.SerializeObject(jsonData);

                ////If there is any json data
                //if (!String.IsNullOrEmpty(_jsonObject))
                //{
                //    using (System.IO.Stream s = req.GetRequestStream())
                //    {
                //        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                //            sw.Write(_jsonObject);
                //    }
                //}
                req.ContentType = "application/json; charset=utf-8";

                req.AllowAutoRedirect = false;
                var resp = (HttpWebResponse)req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());

                if ((resp.StatusCode == HttpStatusCode.Redirect) || (resp.StatusCode == HttpStatusCode.SeeOther) ||
                    (resp.StatusCode == HttpStatusCode.RedirectMethod))
                {
                }
                else
                {
                    response = sr.ReadToEnd().Trim();
                }
            }
            catch (WebException wex)
            {
                throw new Exception(wex.Message);
            }

            return response;
        }

        public dynamic GetData(string url)
        {

            try
            {

                var req = (HttpWebRequest)WebRequest.Create(url);
                req.ContentType = "application/json; charset=utf-8";
                req.AllowAutoRedirect = false;
                var resp = req.GetResponse();
                var sr = new StreamReader(resp.GetResponseStream());
                var response = sr.ReadToEnd().Trim();

                var data = JsonConvert.DeserializeObject<dynamic>(response);
                // data = Json.DeserializeObject<dynamic>(response);

                return data;
            }
            catch (WebException wex)
            {
                throw new Exception(wex.Message);
            }
        }

        [HttpPost]
        [Route("api/ITDA/Report")]
        public IHttpActionResult Report(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Report(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        [HttpPost]
        [Route("api/ITDA/GisReport")]
        public IHttpActionResult GisReport(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.GisReport(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/Allassetslatongs")]
        public IHttpActionResult Allassetslatongs(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Allassetslatongs(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/Allassetslatongs1")]
        public IHttpActionResult Allassetslatongs1(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Allassetslatongs1(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/AssetFacility")]
        public IHttpActionResult AssetFacility(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.AssetFacility(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/Villagefencing")]
        public IHttpActionResult Villagefencing(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Villagefencing(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/Subassetextradetails")]
        public IHttpActionResult Subassetextradetails(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Subassetextradetails(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/DeptAssetcount")]
        public IHttpActionResult DeptAssetcount(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.DeptAssetcount(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/Road")]
        public IHttpActionResult Road(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Road(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/Roadservice")]
        public IHttpActionResult Roadservice(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Roadservice(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/imageRoad")]
        public IHttpActionResult imageRoad(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.imageRoad(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/EXCELVALUESFENCING")]
        public IHttpActionResult EXCELVALUESFENCING(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.EXCELVALUESFENCING(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/ChartAsetsDashboardValues")]
        public IHttpActionResult ChartAsetsDashboardValues(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.ChartAsetsDashboardValues(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpGet]
        [Route("api/ITDA/GetAllbeneficiaryrecords")]
        public IHttpActionResult GetAllbeneficiaryrecords()
        {
            MastersDataAnalysisBAL.MastersDataAnalysis obj1 = new MastersDataAnalysisBAL.MastersDataAnalysis();
            try
            {
               
                
                return Ok(obj1.Getbenallrecordsnerga());
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/chartAllassetslatongs1")]
        public IHttpActionResult chartAllassetslatongs1(latlongsModel objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            try
            {

                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.chartAllassetslatongs1(objroot));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/pdfimagedataconversion")]
        public IHttpActionResult pdfimagedataconversion(dynamic objdata)
        {
            string jsondata = JsonConvert.SerializeObject(objdata);
            dynamic obj_data1 = new ExpandoObject();
            try
            {
                var json = JsonConvert.SerializeObject(objdata);
                dynamic objre = JsonConvert.DeserializeObject<ExpandoObject>(json);
                ProjectRofrBAL.GetMasterDetails Obj = new ProjectRofrBAL.GetMasterDetails();
              //  return Ok(Obj.Get_Land_Images_Report(objre.type, objre.itda, objre.Dist, objre.Mandal, objre.Village, objre.user, objre.userpre));
                return Ok(Obj.Get_Land_Images_Report1(objdata));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        //12-11-2024 Newly adding service

        [HttpPost]
        [Route("api/ITDA/Apikey")]
        public IHttpActionResult Gethousekey()
        {
            latlongsModel objdata = new latlongsModel();

            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;

                objdata.Ipaddress = ipaddress;
                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var Charsarr = new char[20];
                var random = new Random();

                for (int i = 0; i < Charsarr.Length; i++)
                {
                    Charsarr[i] = characters[random.Next(characters.Length)];
                }

                objdata.key = "ROFRGIRIBHUMI" + new String(Charsarr);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objdata.url = url;
                string jsondata = JsonConvert.SerializeObject(objdata);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);

                return Ok(latlonhelper.submit1_key(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key + objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        //12-11-2024
        [HttpPost]
        [Route("api/ITDA/HouseStData")]
        public dynamic Gethousedata(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                obj.Ipaddress = ipaddress;
                Random ran = new Random();
                obj.key = obj.key;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                obj.url = url;
                string jsondata = JsonConvert.SerializeObject(obj);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_house_data(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                return obj_data;
                
            }
        }

        //20-02-2025 FarmIdKey
        [HttpPost]
        [Route("api/ITDA/GetFarmIdKey")]
        public IHttpActionResult FarmIdKey()
        {
            latlongsModel objdata = new latlongsModel();

            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;

                objdata.Ipaddress = ipaddress;
                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var Charsarr = new char[20];
                var random = new Random();

                for (int i = 0; i < Charsarr.Length; i++)
                {
                    Charsarr[i] = characters[random.Next(characters.Length)];
                }

                objdata.key = "ROFRGIRIBHUMI" + new String(Charsarr);
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objdata.url = url;
                string jsondata = JsonConvert.SerializeObject(objdata);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);

                return Ok(latlonhelper.FramIdsubmit_key(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key + objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        //20-02-2025 adding
        [HttpPost]
        [Route("api/ITDA/AgriStackData")]
        public dynamic GetUniqeFarmIddata(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                obj.Ipaddress = ipaddress;
                Random ran = new Random();
                obj.key = obj.key;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                obj.url = url;
                string jsondata = JsonConvert.SerializeObject(obj);
                latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_FarmID_data(objroot));
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                return obj_data;

            }
        }


        //21-02-2025 
        [HttpPost]
        [Route("api/ITDA/GetAadharwiseData")]
        public IHttpActionResult GetAadharData(latlongsModel objdata)
        {

            try
            {
                //string ipaddress = HttpContext.Current.Request.UserHostAddress;
                //objdata.Ipaddress = ipaddress;
                //Random ran = new Random();
                //objdata.key = objdata.key;
                //string url = HttpContext.Current.Request.Url.AbsoluteUri;
                //objdata.url = url;
                //string jsondata = JsonConvert.SerializeObject(objdata);
                //latlongsModel objroot = JsonConvert.DeserializeObject<latlongsModel>(jsondata);
                return Ok(latlonhelper.Get_Aadhar_data(objdata));
            }
            catch (Exception ex)
            {
               // ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, objdata.key + objdata.url + objdata.Ipaddress, HttpContext.Current.Request.UserHostAddress);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        //02-05-2025 For CCLA Data

        [HttpPost]
        [Route("api/ITDA/ToGetAdangalDetails")]
        public IHttpActionResult GetAdangalDetails(latlongsModel objdata)
        {

            try
            {
                
                return Ok(latlonhelper.Get_Adangal_Details(objdata));
            }
            catch (Exception ex)
            {
               
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/ToGetPlotIDData")]
        public IHttpActionResult GetPlotIDData(latlongsModel objdata)
        {

            try
            {

                return Ok(latlonhelper.Get_PlotIDData(objdata));
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        [HttpPost]
        [Route("api/ITDA/ToGetRorData")]
        public IHttpActionResult GetRorData3(latlongsModel objdata)
        {

            try
            {

                return Ok(latlonhelper.Get_Ror_data(objdata));
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/ITDA/RofrCropInsurance")]
        public IHttpActionResult Get_RofrCropInsurance(latlongsModel objdata)
        {

            try
            {

                return Ok(latlonhelper.Get_RofrCropInsurance(objdata));
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


    }
}
