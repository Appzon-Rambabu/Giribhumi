using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.NetworkInformation;
using ROFR.helper;
using System.IO;

namespace ROFR.test
{
    public partial class VIEWDLC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Id = (string)(Session["Id"]);
                if (Id != null)
                {
                    bool jpgfile = false;
                    DataTable dtfile = ProjectRofrBAL.GetMasterDetails.pdfFile_retrieve(Id);
                    string filename = dtfile.Rows[0]["Dlc"].ToString();
                    string itdaname = dtfile.Rows[0]["ITDA_NAME"].ToString();
                    string districtcode = dtfile.Rows[0]["District_Code"].ToString();
                    string floder = itdaname.Replace(" ", string.Empty) + districtcode;
                    string type = dtfile.Rows[0]["Dlc"].ToString();
                    string path = dtfile.Rows[0]["Dlcpath"].ToString();

                    if (type.Contains(".jpg") == true)
                    {
                        jpgfile = true;
                        DlcImage.Visible = true;
                        Session["typefile"] = "jpg";
                        DlcImage.ImageUrl = "~/DlcImage.ashx?ImageId=" + Id;
                      
                    }
                    else
                    {
                        DlcImage.Visible = false;
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-dispostion", "attachment;filename=" + filename);
                     Response.TransmitFile(Server.MapPath("~/DLC/" + floder + "/" + filename));
                      // Response.TransmitFile(Server.MapPath("~/DLC/" + floder + "/" + path));
                        Response.End();
                    }

                    //    jpgfile = true;
                    //    Image1.Visible = true;
                    //    Session["typefile"] = "jpg";
                    //    Image1.ImageUrl = "ImageHandler - Copy.ashx?ImageId=" + Id;
                    //}
                    //else
                    //{
                    //    if (Id != null)
                    //    {
                    //        Image1.Visible = false;
                    //        Response.Clear();
                    //        if (dtfile.Rows[0]["Dlc"].ToString() == "System.Byte[]")
                    //        {
                    //            Response.Buffer = true;
                    //            //  Response.ContentType = dr["type"].ToString();
                    //            //Response.AddHeader("content-disposition", "attachment;filename=" + dtfile.Rows[0]["Dlc"].ToString()); // to open file prompt Box open or Save file  
                    //            Response.Charset = "";
                    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //            Response.ContentType = "application/pdf";


                    //            Response.BinaryWrite((byte[])dtfile.Rows[0]["Dlc"]);
                    //            Response.End();
                    //        }
                    //    }
                    //}
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