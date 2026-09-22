using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using ROFR.helper;
using Newtonsoft.Json;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Dynamic;




namespace ROFR
{
    /// <summary>
    /// Summary description for RofrService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RofrService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetPopulationData()
        {

            List<GoogleChartData> data = new List<GoogleChartData>();
            dynamic objDetails = new ExpandoObject();

                //objDetails.dt = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters("admin", "Season", district, mandal, village);
                objDetails.dt = Landsettlementpattas.PopulationGetData();

                data = JsonConvert.SerializeObject(objDetails);


                var chartData = new object[data.Count + 1];
                chartData[0] = new object[]{
                "Product Category",
                "Revenue Amount"
            };
                int j = 0;
                foreach (var i in data)
                {
                    j++;
                    chartData[j] = new object[] { i.ProductCategory, i.RevenueAmount };
                }

       
            return chartData;
        }







    }
}
