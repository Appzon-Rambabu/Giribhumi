using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace ROFR.pages
{
    public partial class Villagewise_Farmer_Images_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "Villagewise_Farmer_Images_Details.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        string mandal = (string)(Session["Mandal"]);
                        string village = (string)(Session["Village"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (dist != "" & Itda != "" && mandal != "" && village != "")
                        {
                            BindData(Itda, dist, mandal, village);
                        }
                    }
                    else
                    {
                        if ((string)(Session["District"]) != "" && (string)(Session["Itda"]) != "" && (string)(Session["mandal"]) != "" && (string)(Session["village"]) != "")
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                            string mandal = (string)(Session["Mandal"]);
                            string village = (string)(Session["Village"]);
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                            lbl_village.Text = village;
                            if (dist != "" & Itda != "" && mandal != "" && village != "")
                            {
                                BindData(Itda, dist, mandal, village);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }



        protected void BindData(string Itda, string dist, string mandal, string village)
        {
            try
            {
                string filename = string.Empty;
                string path = string.Empty;
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFarmerImagesReport("VDetails", Itda, dist, mandal, village, (string)(Session["username"]), (string)Session["userprevilages"]);
                dt.Columns.Add("Image", typeof(byte[]));
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count > 0)

                    {
                        if (dt.Rows[i]["Image1"].ToString() != null && dt.Rows[i]["Imagepath"].ToString() !=null)
                        {
                            filename = dt.Rows[i]["Image1"].ToString();
                            path = dt.Rows[i]["Imagepath"].ToString();



                            DisplayImages(dt.Rows[i], "Image", (path + filename));


                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            DisplayImages(dt.Rows[i], "Image", (imgpath));

                        }
                      
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;


                    GridView1.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void DisplayImages(DataRow row, string img, string ImagePath)

        {

            FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

            byte[] ImgData = new byte[stream.Length];

            stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

            stream.Close();

            row[img] = ImgData;

        }


        protected void Back_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Villagewise_Farmer_Images_Report.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}