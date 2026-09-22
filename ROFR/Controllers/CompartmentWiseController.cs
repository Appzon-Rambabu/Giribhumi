using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using ROFR.helper;
using System.Dynamic;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Cors;

namespace ROFR.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompartmentWiseController : ApiController
    {
        [HttpGet]
        [Route("CompartmentWiseController/ItdaWiseCompartmentsData")]
        public IHttpActionResult ItdaWiseCompartmentsData()
        {

            DataTable dt = new DataTable();
           
               dt = Landsettlementpattas.ItdaWiseGetData();
         
             return Ok(dt);
        }
        [HttpGet]
        [Route("CompartmentWiseController/ItdaWiseCompartmentsData/{Itda}")]
        public IHttpActionResult ItdaWiseCompartmentsData(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.ItdaWiseCompartmentsData(Itda);


            return Ok(dt);




        }


        [HttpGet]
        [Route("CompartmentWiseController/ItdaWiseCompartmentsInTwoMandals/{Itda}")]
        public IHttpActionResult ItdaWiseCompartmentsInTwoMandals(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.ItdaWiseCompartmentsInTwoMandals(Itda);


            return Ok(dt);




        }
        [HttpGet]
        [Route("CompartmentWiseController/MandalCompartmentsInTwoMandals/{Itda}/{Mandal}")]
        public IHttpActionResult MandalCompartmentsInTwoMandals(string Itda,string Mandal)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.MandalCompartmentsInTwoMandals(Itda,Mandal);


            return Ok(dt);




        }

        [HttpGet]
        [Route("CompartmentWiseController/ItdawiseTotals/{Itda}")]
        public IHttpActionResult ItdawiseTotals(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.ItdawiseTotals(Itda);


            return Ok(dt);




        }
        [HttpGet]
        [Route("CompartmentWiseController/ItdawiseTotals")]
        public IHttpActionResult ItdawiseTotals()
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.ItdawiseTotals();

            return Ok(dt);

        }



        [HttpGet]
        [Route("CompartmentWiseController/MandalWiseCompartmentsData/{Itda}")]
        public IHttpActionResult MandalWiseCompartmentsData(string Itda)
        {
            DataTable dtMandalWise = new DataTable();
            dtMandalWise = Landsettlementpattas.ItdaWiseGetData(Itda);
            return Ok(dtMandalWise);
            // dynamic objDetails = new ExpandoObject();
            // try
            // {
            // objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda);
            // }
            //catch (Exception ex)
            //{
            //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
            //  ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            // }
            // return Ok(JsonConvert.SerializeObject(objDetails));



        }


        [HttpGet]
        [Route("CompartmentWiseController/VillageWiseCompartmentsData/{Itda}/{Mandal}")]
        public IHttpActionResult VillageWiseCompartmentsData(string Itda, string Mandal)
        {
            DataTable dtVillageWise = new DataTable();
            dtVillageWise = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal);
            return Ok(dtVillageWise);
            //  dynamic objDetails = new ExpandoObject();
            //  try
            //  {
            // objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal);
            // }
            // catch (Exception ex)
            //// {
            //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
            //  ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //}
           // return Ok(JsonConvert.SerializeObject(objDetails));


        }

        [HttpGet]
        [Route("CompartmentWiseController/CompartmentWisesData/{Itda}/{Mandal}/{village}")]
        public IHttpActionResult CompartmentWisesData(string Itda, string Mandal, string village)
        {
            DataTable dtCompartmentWise = new DataTable();
            dtCompartmentWise = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal, village);
            return Ok(dtCompartmentWise);

           // dynamic objDetails = new ExpandoObject();
            //try
           // {
                //objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal, village);
            //}
           // catch (Exception ex)
           // {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
              //  ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            //}
            //return Ok(JsonConvert.SerializeObject(objDetails));


        }
        [HttpGet]
        [Route("GetAllComparementsLatlongs")]
        public IHttpActionResult GetAllComparementsLatlongs()
        {

            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.GetAllComparementsLatlongs();
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
             //   ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return Ok(JsonConvert.SerializeObject(objDetails));


        }
        [HttpGet]
        [Route("ItdaWiseComparementsLatlongs/{Itda}/{Mandal}")]
        public IHttpActionResult ItdaWiseComparementsLatlongs(string Itda, string Mandal)
        {

            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.ItdawiseComparementsLatlongs(Itda, Mandal);

            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
               // ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return Ok(JsonConvert.SerializeObject(objDetails));


        }

        [HttpGet]
        [Route("getitdalanddetails")]
        public IHttpActionResult getitdalanddetails()
        {

            DataTable dt = new DataTable();

            // dt = Landsettlementpattas.ItdaWiseGetData();
            string url = "http://www.giribhumi.ap.gov.in/CompartmentWiseController/ItdaWiseCompartmentsData";//"http://www.giribhumi.ap.gov.in/ItdaWiseCompartmentsData";
            GetData(url);
            return Ok(dt);
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


        [HttpGet]
        [Route("CompartmentWiseController/ItdaWisePopulationData")]
        public IHttpActionResult ItdaWisePopulationData()
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.PopulationGetData();


            return Ok(dt);

        }

        [HttpGet]
        [Route("CompartmentWiseController/ItdaWisePopulationData/{ITDA}")]
        public IHttpActionResult ItdaWisePopulationData(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.GetPopulationData(Itda);


            return Ok(dt);

        }
        [HttpGet]
        [Route("CompartmentWiseController/MandalPopulationData/{Itda}")]
        public IHttpActionResult MandalPopulationData(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.PopulationGetData(Itda);


            return Ok(dt);




        }
        [HttpGet]
        [Route("CompartmentWiseController/VillagePopulationData/{ITDA}/{Mandal}")]
        public IHttpActionResult VillagePopulationData(string Itda,string Mandal)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.PopulationGetData(Itda,Mandal);


            return Ok(dt);




        }

        [HttpGet]
        [Route("CompartmentWiseController/LandSummaryTotals")]
        public IHttpActionResult LandSummaryTotals()
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.LandSummaryTotals();


            return Ok(dt);

        }
        [HttpGet]
        [Route("CompartmentWiseController/LandSummaryTotals/{ITDA}")]
        public IHttpActionResult LandSummaryTotals(string Itda)
        {

            DataTable dt = new DataTable();

            dt = Landsettlementpattas.LandSummaryTotals(Itda);


            return Ok(dt);

        }


    }
}
