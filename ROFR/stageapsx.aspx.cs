using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ROFR
{
    public partial class stageapsx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try

            {
              
                //string uriPath = "http://localhost:60061//DLC//01-10-2020//27-10-2020_sahasra.pdf";
                //if (uriPath.StartsWith("http:/r"))
                   // uriPath = uriPath.Replace("http:/r", "http://r");
                //string ImagePath = "http://localhost:60061//DLC//01-10-2020//27-10-2020_sahasra.pdf";
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImagePath);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream receiveStream = response.GetResponseStream();
                string uriPath = "C:\\Users\\CODETREE\\Desktop\\12072021\\ROFR\\ROFR\\DLC\\01-10-2020\\06-05-2021_1685 DLC dt 22.02.2009.pdf";
                string localPath = uriPath;
                Byte[] bytes = File.ReadAllBytes(localPath);
                String file = Convert.ToBase64String(bytes);
                Stagemgnergs.APHousingWS obj = new Stagemgnergs.APHousingWS();
               
                var a = obj.WorkDetailsCapturingByUID("732593694873");
                Label myLabel = this.FindControl("noofrec") as Label;
                myLabel.Text = a.ToString();
                string logdata = a;
                string mappath = HttpContext.Current.Server.MapPath("MgnergasResponselogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));

            }
            catch (Exception ex)
            {
                Label myLabel = this.FindControl("noofrec") as Label;
                myLabel.Text = ex.ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}