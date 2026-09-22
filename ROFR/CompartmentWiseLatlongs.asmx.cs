using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ROFR.helper;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.ComponentModel;
using System.Dynamic;
using Newtonsoft.Json;

namespace ROFR
{
    /// <summary>
    /// Summary description for CompartmentWiseLatlongs
    /// </summary>
    [WebService(Namespace = "http://giribhumi.ap.gov.in/Latlongsservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CompartmentWiseLatlongs : System.Web.Services.WebService
    {
        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ItdaWiseCompartmentsData()
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.ItdaWiseGetData();
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string MandalWiseCompartmentsData(string Itda)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda);
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }


        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string VillageWiseCompartmentsData(string Itda, string Mandal)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal);
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }


        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CompartmentWisesData(string Itda, string Mandal,string village)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.ItdaWiseGetData(Itda, Mandal, village);
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAllComparementsLatlongs()
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.GetAllComparementsLatlongs();
            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetItdaWiseComparementsLatlongs(string Itda, string Mandal)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
               // objDetails.dt = Landsettlementpattas.GetItdawiseComparementsLatlongs(Itda,Mandal);

            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ItdaWiseCompartmentsInTwoMandals(string Itda)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                 objDetails.dt = Landsettlementpattas.ItdaWiseCompartmentsInTwoMandals(Itda);
                

            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string MandalCompartmentsInTwoMandals(string Itda, string Mandal)
        {
            dynamic objDetails = new ExpandoObject();
            try
            {
                objDetails.dt = Landsettlementpattas.MandalCompartmentsInTwoMandals(Itda,Mandal);


            }
            catch (Exception ex)
            {
                //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return JsonConvert.SerializeObject(objDetails);
        }
    }
}
