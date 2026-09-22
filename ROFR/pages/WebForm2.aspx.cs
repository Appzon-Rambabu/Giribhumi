using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ROFR.pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string dt = "04-11-2020 15:06:46";
            string dt1 = "04-11-2020 14:06:46";
            TimeSpan ts = Convert.ToDateTime(dt) - Convert.ToDateTime(dt1);
            
            Console.Write(ts.TotalHours);
            if(ts.TotalHours>=1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('date') ", true);
            }
        }
    }
}