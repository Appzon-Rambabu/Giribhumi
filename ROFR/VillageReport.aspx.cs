using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Net.Http;

namespace ROFR
{
    public partial class VillageReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    BindDist();

                    ddl_itda.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_gp.Items.Insert(0, new ListItem("Select", "0"));

                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    div1.Visible = true;
                    div2.Visible = false;
                    div3.Visible = false;
                    div4.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindDist()
        {
            try
            {
                DataTable dtdist = Landsettlementpattas.Villageprofiledropdowns1("", "", "", "", "", "DISTRICT");
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtdist.Rows.Count > 0)
                {
                    ddl_dist.DataSource = dtdist;
                    ddl_dist.DataTextField = "DISTRICT";
                    ddl_dist.DataValueField = "SPS_DCODE";
                    ddl_dist.DataBind();
                    ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindItda(DataTable dt)
        {
            try
            {
                DataTable dtItda = dt;
                ddl_itda.DataSource = dtItda;
                ddl_itda.DataTextField = "ITDA";
                ddl_itda.DataValueField = "ITDA_CODE";
                ddl_itda.DataBind();
                ddl_itda.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindMandal(DataTable dtMandal)
        {
            try
            {
                ddl_mandal.DataSource = dtMandal;
                ddl_mandal.DataTextField = "MANDAL";
                ddl_mandal.DataValueField = "MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindGP(DataTable dtgp)
        {
            try
            {
                ddl_gp.DataSource = dtgp;
                ddl_gp.DataTextField = "GRAM_PANCHAYAT";
                ddl_gp.DataValueField = "ITDA_GP_CODE";
                ddl_gp.DataBind();
                ddl_gp.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindVillage(DataTable dtVillages)
        {
            try
            {
                ddl_village.DataSource = dtVillages;
                ddl_village.DataTextField = "VILLAGE_HABITATIONS";
                ddl_village.DataValueField = "HABITATION_CODE";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void ddldist_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_gp.Items.Clear();

                ddl_gp.Items.Insert(0, new ListItem("Select", "0"));

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                if (ddl_dist.SelectedItem.Text != "Select")
                {

                    DataTable Itda = Landsettlementpattas.Villageprofiledropdowns1("", ddl_dist.SelectedValue, "", "", "", "ITDA");
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (Itda.Rows.Count > 0)
                    {
                        BindItda(Itda);
                        if (Itda.Rows.Count <= 1)
                        {
                            ddl_itda.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.Villageprofiledropdowns1(ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", "MANDAL");
                            // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                            if (dtMandal.Rows.Count > 0)
                            {
                                BindMandal(dtMandal);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_gp.Items.Clear();

                ddl_gp.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.Villageprofiledropdowns1(ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", "MANDAL");

                    // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }


                }
                else
                {
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddlmandal_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                if (ddl_mandal.SelectedItem.Text != "Select")
                {

                    DataTable dtgp = Landsettlementpattas.Villageprofiledropdowns1(ddl_itda.SelectedValue, ddl_dist.SelectedValue, ddl_mandal.SelectedValue, "", "", "GP");
                    // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                    if (dtgp.Rows.Count > 0)
                    {
                        BindGP(dtgp);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();




                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddlgp_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                if (ddl_gp.SelectedItem.Text != "Select")


                {
                    DataTable dtvillage = Landsettlementpattas.Villageprofiledropdowns1(ddl_itda.SelectedValue, ddl_dist.SelectedValue, ddl_mandal.SelectedValue, ddl_gp.SelectedValue, "", "HAB");
                    //  DataTable dthab = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Rhabitation", ddl_district.SelectedValue, ddl_mandal.SelectedValue, ddl_village.SelectedValue);




                    if (dtvillage.Rows.Count > 0)
                    {
                        BindVillage(dtvillage);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlvillage_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                if (ddl_village.SelectedItem.Text != "Select")


                {
                    DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, "", "", "", "WEB-DEPT");
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                backbtn1.Visible = false;
                backbtn2.Visible = true;
                Session["HAB"] = ddl_village.SelectedValue;

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, start, "", "", "WEB-ASSET");
                Session["Dept"] = start;
                GridView1.Visible = false;
                GridView2.Visible = true;
                GridView3.Visible = false;
                GridView4.Visible = false;
                div1.Visible = false;
                div2.Visible = true;
                div3.Visible = false;
                div4.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void link1_onclick(object sender, EventArgs e)
        {
            try
            {



                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                string dept = (string)(Session["Dept"]);
                var range = s.IndexOf(',');

                string asset = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);

                Session["asset"] = asset;
                GridView1.Visible = false;
                GridView2.Visible = false;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                backbtn1.Visible = false;
                backbtn2.Visible = false;
                if (dept != "922" && asset != "92201")
                {
                    backbtn3.Visible = true;
                    //DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, dept, asset, "", "WEB-SUBASSET");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    string url = dt.Rows[0]["SUB_ASSET_IMG1"].ToString();

                    //    string path = Path.GetDirectoryName(url);
                    //    string imgname= Path.GetFileName(url);
                    //    //string subimg1 = SubassestsImage(url);
                    div3.Visible = true;
                    GridView3.Visible = true;
                    //    GridView4.Visible = false;
                    //    GridView3.DataSource = dt;
                    //    GridView3.DataBind();
                    //}
                    PopulateGridView();
                }
                else
                {
                    backbtn3.Visible = true;
                    div4.Visible = true;
                    GridView1.Visible = false;
                    GridView4.Visible = true;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    DataTable dt1 = Landsettlementpattas.Report(ddl_village.SelectedValue, dept, asset, "", "WEB-SUBASSET-ROAD");
                    if (dt1.Rows.Count > 0)
                    {
                        GridView4.DataSource = dt1;
                        GridView4.DataBind();
                    }
                }





            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void backbtn1_click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("VillageDashboardReport.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void backbtn2_click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, "", "", "", "WEB-DEPT");
                div1.Visible = true;
                GridView1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
                div4.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                backbtn1.Visible = true;
                backbtn2.Visible = false;
                backbtn3.Visible = false;
                backbtn4.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void backbtn3_click(object sender, EventArgs e)
        {
            try
            {
                div2.Visible = true;
                GridView2.Visible = true;
                div1.Visible = false;
                div3.Visible = false;
                div4.Visible = false; ;
                GridView1.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                backbtn1.Visible = false;
                backbtn2.Visible = true;
                backbtn3.Visible = false;
                backbtn4.Visible = false;
                DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, (string)(Session["Dept"]), "", "", "WEB-ASSET");


                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void backbtn4_click(object sender, EventArgs e)
        {
            try
            {
                div2.Visible = true;
                GridView2.Visible = true;
                div1.Visible = false;
                div3.Visible = false;
                div4.Visible = false; ;
                GridView1.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                backbtn1.Visible = false;
                backbtn2.Visible = true;
                backbtn3.Visible = false;
                backbtn4.Visible = false;
                DataTable dt = Landsettlementpattas.Report(ddl_village.SelectedValue, (string)(Session["Dept"]), "", "", "WEB-ASSET");


                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        //public string SubassestsImage(string ImgStr)
        //{


        //    //string imageName = claimid + ".jpg";

        //    //set the image path
        //   // string imgPath = Path.Combine(path, imageName);

        //    //byte[] imageBytes = Convert.ToBase64String(ImgStr);

        //    //File.WriteAllBytes(imageBytes);

        //    //return imgPath;

        //    byte[] imageBytes = System.IO.File.ReadAllBytes(ImgStr);
        //    string base64img = Convert.ToBase64String(imageBytes);
        //    return base64img;
        //}

        private void PopulateGridView()
        {
            string apiUrl = "http://www.giribhumi.ap.gov.in/api/ITDA";
            object input = new
            {
                HAB = ddl_village.SelectedValue,
                dept = (string)(Session["Dept"]),
                asset = (string)(Session["asset"]),
            };
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            //WebClient client = new WebClient();
            //client.Headers["Content-type"] = "application/json";
            //client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(apiUrl + "/SubAssetsDetails", inputJson);

            //GridView3.DataSource = (new JavaScriptSerializer()).Deserialize<List<Subassests>>(json);
            //GridView3.DataBind();


            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl + "/SubAssetsDetails", inputContent).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Subassests> assets= (new JavaScriptSerializer()).Deserialize<List<Subassests>>(response.Content.ReadAsStringAsync().Result);
                GridView3.DataSource = assets;
                GridView3.DataBind();
            }
        }

        public class Subassests
        {
            public string SUBASSET_NAME { get; set; }
            public string SUBASSET_STATUS { get; set; }
            public string SUBASSET_CONDITION { get; set; }
            public string SUB_ASSET_IMG1 { get; set; }
            public string SUB_ASSET_IMG2 { get; set; }
            public string SUB_ASSET_IMG3 { get; set; }
        }
    }
}