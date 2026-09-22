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

namespace ROFR.test
{
    public partial class GoogleCharts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPopulationData();
        }


        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetPopulationData()
        {

            List<GoogleChartData> data = new List<GoogleChartData>();
            dynamic objDetails = new ExpandoObject();
            DataTable dt = new DataTable();
            //objDetails.dt = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters("admin", "Season", district, mandal, village);
            
           for(int i=0;i<2;i++)
            {
                GoogleChartData GoogleChartData = new GoogleChartData();
                GoogleChartData.SLID = Convert.ToInt32(dt.Rows[i]["S_No"]);
                GoogleChartData.ProductCategory = dt.Rows[i]["A"].ToString();
                GoogleChartData.RevenueAmount = Convert.ToInt32(dt.Rows[i]["ST_POPULATION"]);
                data.Add(GoogleChartData);
            }

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