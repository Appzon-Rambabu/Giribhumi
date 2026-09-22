using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.IO;
using System.Reflection;

namespace ROFR.pages
{
    public partial class View_Land_Files : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Id = (string)(Session["Id"]);
                string fname = (string)(Session["fname"]);
                if (Id != null)
                {
                    bool jpgfile = false;
                    DataTable dtfile = Landsettlementpattas.Land_Transfer_file_retrieve(Id);
                    string filename = dtfile.Rows[0]["RDO_FILENAME"].ToString();
                    string date=dtfile.Rows[0]["FILE_DATE"].ToString();
                    string id= dtfile.Rows[0]["Id"].ToString();
                    string folder = dtfile.Rows[0]["FILE_FOLDER"].ToString();
                    //string itdaname = dtfile.Rows[0]["ITDA_NAME"].ToString();
                    //string districtcode = dtfile.Rows[0]["District_Code"].ToString();
                    //string floder = itdaname.Replace(" ", string.Empty) + districtcode;
                    string type = dtfile.Rows[0]["RDO_FILENAME"].ToString();
                    // string path = dtfile.Rows[0]["Dlcpath"].ToString();
                    string path = dtfile.Rows[0]["RDO_PATH"].ToString();
                  
                    if (type.Contains(".jpg") == true)
                    {
                        jpgfile = true;
                        LandRegulationImage.Visible = true;
                        Session["typefile"] = "jpg";
                        LandRegulationImage.ImageUrl = "~/Land_image_file.ashx ?ImageId=" + Id;
                        
                    }
                   else if (type.Contains(".jpeg") == true)
                    {
                        jpgfile = true;
                        LandRegulationImage.Visible = true;
                        Session["typefile"] = "jpeg";
                        LandRegulationImage.ImageUrl = "~/Land_image_file.ashx ?ImageId=" + Id;

                    }
                    else
                    {
                        LandRegulationImage.Visible = false;
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-dispostion", "attachment;filename=" + filename);
                        // Response.TransmitFile(Server.MapPath("~/DLC/" + floder + "/" + filename));
                         //Response.TransmitFile(Server.MapPath(path+"/"+ filename));
                        Response.TransmitFile(Server.MapPath("~/LandSettlementPattas/" + date + "/" + folder + "/" +id+ "/"+filename));
                        Response.End();
                    }


                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}