using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ROFR.Models
{
    public class FormHelper
    {
        public class Masters
        {
            public static DataTable HabAssetsData;
            public static DataTable RoadsData;
            public static DataTable AlldeptchartData;
        }


        public class ChartsEducation
        {
            public List<EducationCharts> Listgraph { get; set; }
            public string Title { get; set; }
            public string Status { get; set; }
            public string Reason { get; set; }
        }
        public class EducationCharts
        {
            public string y { get; set; }
            public string label { get; set; }

            public decimal d { get; set; }
        }
    }
}