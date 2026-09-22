using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;
using System.Web.Helpers;
using System.Text.RegularExpressions;
using System.Threading;
namespace ROFR.pages
{
    public partial class Add_Beneficiary_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            try
            {

                if (!IsPostBack)
                {
                    if ((string)Session["username"] != null)
                    {
                       // System.Threading.Thread.Sleep(50000);//showing loader 5 seconds
                        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Cache.SetNoStore();
                        
                        BindItda();
                        
                       
                       // ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_panchayat.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_Rv.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else
                    {
                        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Cache.SetNoStore();
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
            ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void BindItda()
        {
            try
            {

                DataTable dtItda = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Itda", "","", "", "", "", "","", (string)Session["userprevilages"]);
               // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_CODE";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
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
        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "LGD_DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_mandal.DataTextField = "MANDAL_NAME";
                ddl_mandal.DataValueField = "LGD_MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        //Newly adding Panchayat
        private void BindPanchayat(DataTable dtpanchayat)
        {
            try
            {
                ddl_panchayat.DataSource = dtpanchayat;
                ddl_panchayat.DataTextField = "Gram_Panchayat";
                ddl_panchayat.DataValueField = "Grama_Panchayat_Code";
                ddl_panchayat.DataBind();
                ddl_panchayat.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        //Newly adding Revenue Village
        private void BindRevVillage(DataTable dtRevvillage)
        {
            try
            {
                ddl_Rv.DataSource = dtRevvillage;
                ddl_Rv.DataTextField = "REV_Village";
                ddl_Rv.DataValueField = "REV_VILLAGE_CODE";
                ddl_Rv.DataBind();
                ddl_Rv.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_village.DataTextField = "VILLAGE_NAME";
                ddl_village.DataValueField = "LGD_VILLAGE_CODE";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Bindhabitation(DataTable dthabitation)
        {
            try
            {
                ddl_Habitation.DataSource = dthabitation;
                ddl_Habitation.DataTextField = "HABITATION";
                ddl_Habitation.DataValueField = "HabitationCode";
                ddl_Habitation.DataBind();
                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
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
               // System.Threading.Thread.Sleep(50000);//showing loader 5 seconds

                ddl_mandal.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_district.Items.Clear();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                ddl_Habitation.Items.Clear();
                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    ddl_Habitation.ClearSelection();

                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "District", ddl_ITda.SelectedValue,"","", "", "","","", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
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
        protected void ddlHabitation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           // System.Threading.Thread.Sleep(50000);//showing loader 5 seconds
            BindCaste();
        }
        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // System.Threading.Thread.Sleep(50000);//showing Loader for 5 sec
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);

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
                    ddl_Habitation.ClearSelection();


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        private void BindCaste()
        {
            try
            {
               
                DataTable cs = Landsettlementpattas.GetCaste((string)(Session["username"]), "cs", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);

                if (cs.Rows.Count > 0)
                {
                    ddl_Caste.DataSource = cs;
                    ddl_Caste.DataTextField = "CASTE";
                    ddl_Caste.DataValueField = "CASTE";
                    ddl_Caste.DataBind();
                    ddl_Caste.Items.Insert(0, new ListItem("Select", "0"));
                    
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

            //try
            //{

            //    ddl_village.Items.Clear();

            //    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
            //    ddl_Habitation.Items.Clear();

            //    ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
            //    if (ddl_mandal.SelectedItem.Text != "Select")
            //    {
            //        ddl_village.ClearSelection();
            //        DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);



            //        if (dtVillages.Rows.Count > 0)
            //        {
            //            BindVillage(dtVillages);

            //        }
            //        else
            //        {
            //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
            //        }
            //    }
            //    else
            //    {
            //        ddl_village.ClearSelection();

            //        ddl_Habitation.ClearSelection();


            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
            //    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            //}


            try
            {

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));


                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    ddl_Rv.ClearSelection();
                    DataTable dtGramPanchayat = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Gp", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);



                    if (dtGramPanchayat.Rows.Count > 0)
                    {
                        //BindVillage(dtVillages);
                        BindPanchayat(dtGramPanchayat);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();

                    ddl_Habitation.ClearSelection();


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ddl_panchayatSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));


                if (ddl_panchayat.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    ddl_Rv.ClearSelection();
                    DataTable dtrv = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "RV", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_panchayat.SelectedItem.Text, "","", "", (string)Session["userprevilages"]);



                    if (dtrv.Rows.Count > 0)
                    {
                        //BindVillage(dtVillages);
                        BindRevVillage(dtrv);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();

                    ddl_Habitation.ClearSelection();


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddl_RvSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text,ddl_panchayat.SelectedItem.Text,ddl_Rv.SelectedItem.Text, "", "", (string)Session["userprevilages"]);



                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();

                    ddl_Habitation.ClearSelection();


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
               // System.Threading.Thread.Sleep(50000);

                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_village.SelectedItem.Text != "Select")


                {
                    DataTable dthab = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Habitation", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_panchayat.SelectedItem.Text, ddl_Rv.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);
                  //  DataTable dthab = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Rhabitation", ddl_district.SelectedValue, ddl_mandal.SelectedValue, ddl_village.SelectedValue);




                    if (dthab.Rows.Count > 0)
                    {
                        Bindhabitation(dthab);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {

                    ddl_Habitation.ClearSelection();


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void pgc_Click(object sender, EventArgs e)
        {
            try
            {
               // BindItda();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                
                string filepath = string.Empty;
                string location = string.Empty;
                string IPAddress = (string)(Session["IPAddress"]);
                string mask = Request.Form[HiddenField1.UniqueID];
                //string mask = "111111111111";
                //  txt_pattadhar.Text = "{script"; 
                bool ct = true;
                bool isValidnumber = aadharcard.validateVerhoeff(mask);
                if (isValidnumber)
                {
                    addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                    int length = FileUpload.PostedFile.ContentLength;
                    Byte[] bytes = new byte[] { };
                    byte[] imgbyte = new byte[] { };
                    imgbyte = new byte[length];

                    HttpPostedFile image = FileUpload.PostedFile;

                    image.InputStream.Read(imgbyte, 0, length);
                    string imagename = FileUpload.PostedFile.FileName;
                    string cl = FileUpload.PostedFile.ContentType;
                    int count = image.FileName.Split('.').Length - 1;
                    // FileUpload.PostedFile.SaveAs("~//Beneficiary Images" + "//" + imagename);
                    string imagefloder = ddl_ITda.SelectedItem.Text + ddl_district.SelectedValue;
                    string benid = txt_pattadhar.Text + mask;
                    //HttpPostedFile image1 = Request.Files["FileUpload"];

                    string extension = System.IO.Path.GetExtension(image.FileName);

                    if (ddl_ITda.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Itda = ddl_ITda.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.Itda = null;
                    }

                    if (!string.IsNullOrEmpty(ddl_ITda.SelectedValue) || (ddl_ITda.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.Itdacode = ddl_ITda.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.Itdacode = null;
                    }

                    if (ddl_district.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.District = ddl_district.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.District = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_district.SelectedValue) || (ddl_district.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.District_Code = ddl_district.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.District_Code = null;
                    }


                    if (ddl_mandal.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Mandal = ddl_mandal.SelectedItem.Text;
                    }
                    else
                    {

                        addbeneficiaryobj.Mandal = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_mandal.SelectedValue) || (ddl_mandal.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.Mandal_Code = ddl_mandal.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.Mandal_Code = null;
                    }
                    //newly adding panchayat and revvillage
                    if(ddl_panchayat.SelectedItem.Text!= "Select")
                    {
                        addbeneficiaryobj.panchayat = ddl_panchayat.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.panchayat = null;
                    }
                    if(!string.IsNullOrEmpty(ddl_panchayat.SelectedValue)||(ddl_panchayat.SelectedValue !="0"))
                    {
                        addbeneficiaryobj.panchayatcode = ddl_panchayat.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.panchayatcode = null;
                    }

                    //newly adding panchayat and revvillage
                    if (ddl_Rv.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.rev_village = ddl_Rv.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.rev_village = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_Rv.SelectedValue) || (ddl_Rv.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.rev_village_code = ddl_Rv.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.rev_village_code = null;
                    }







                    if (ddl_village.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Village = ddl_village.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.Village = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_village.SelectedValue) || (ddl_village.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.Village_Code = ddl_village.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.Village_Code = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_Habitation.SelectedValue) || (ddl_Habitation.SelectedValue != "0"))
                    {
                        addbeneficiaryobj.HabitationCode = ddl_Habitation.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.HabitationCode = null;
                    }
                    if (ddl_Habitation.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Habitation = ddl_Habitation.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.Habitation = null;
                    }
                    if (ddl_gender.SelectedItem.Text != "select")
                    {

                        addbeneficiaryobj.gender = ddl_gender.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.gender = null;
                    }

                    if (ddl_Caste.SelectedItem.Text != "select")
                    {

                        addbeneficiaryobj.caste = ddl_Caste.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.caste = null;
                    }

                    if (ddl_Subcaste.SelectedItem.Text != "select")
                    {

                        addbeneficiaryobj.sub_caste = ddl_Subcaste.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.sub_caste = null;
                    }
                    if (!string.IsNullOrEmpty(txt_pattadhar.Text))
                    {
                        // addbeneficiaryobj.ROFR_PATTADAAR = txt_pattadhar.Text;
                        //  ct = Check_values(txt_pattadhar.Text);
                        
                       ct = obj_IsAlphaNumericcheck(txt_pattadhar.Text);

                        if (ct == true)
                        {
                            ct = obj_IsAlphaNumericcheck(txt_bankname.Text);

                            if (ct == true)
                            {
                                ct = obj_IsAlphaNumericcheck(txt_bankaccount.Text);

                                if (ct == true)
                                {
                                    ct = obj_IsAlphaNumericcheck(txt_ifsc.Text);

                                    if (ct == true)
                                    {
                                        if (!string.IsNullOrEmpty(txt_father.Text))
                                        {

                                            ct = obj_IsAlphaNumericcheck(txt_father.Text);
                                            if (ct == true)
                                            {

                                                ct = obj_IsAlphaNumericcheck(txt_poaccount.Text);
                                                if (ct == true)
                                                {


                                                    ct = obj_IsAlphaNumericcheck(txt_po_number.Text);

                                                    if (ct == true)
                                                    {
                                                        ct = obj_IsAlphaNumericcheck(txt_poname.Text);

                                                        if (ct == true)
                                                        {

                                                            ct = obj_IsAlphaNumericcheck(ddl_Subcaste.Text);

                                                            if (ct == true)
                                                            {

                                                                ct = obj_IsAlphaNumericcheck(Apply.Text);

                                                                if (ct == true)
                                                                {

                                                                   ct = obj_IsAlphaNumericcheck(txt_mob.Text);


                                                                    if (ct == true)
                                                                    {

                                                                       ct = obj_IsAlphaNumericcheck(Txt_address.Text);

                                                                    if (ct == true)
                                                                    {
                                                                      ct = obj_IsAlphaNumericcheck(ddl_Caste.Text);
                                                                            if(ct==true)
                                                                            {

                                                                            }
                                                                            else
                                                                            {
                                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Select Caste')", true);

                                                                            }
                                                                        }
                                                                    else 
                                                                    {
                                                                        ScriptManager.RegisterStartupScript(this, this.GetType(),     "alertmessage", "javascript:alert('enter your address ')", true);
                                                                    }
                                                                    }

                                                                    else {
                                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('enter your mobile number')", true);
                                                                    }


                                                                }


                                                                else {

                                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('select Date of birth')", true);

                                                                }

                                                            }

                                                            else {

                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select SubCaste')", true);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid Po Name')", true);
                                                        }
                                                    }

                                                    else
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid PO number')", true);
                                                    }
                                                }

                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid PO account')", true);
                                                }
                                            }

                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid Father name')", true);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid IFSC')", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid Bank account')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid bankname')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Enter valid Pattadhar names')", true);
                        }

                    }


                    if (ct == true)
                    {
                        if (!string.IsNullOrEmpty(txt_pattadhar.Text))
                        {
                            addbeneficiaryobj.ROFR_PATTADAAR = txt_pattadhar.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.ROFR_PATTADAAR = null;
                        }
                        if (!string.IsNullOrEmpty(mask))
                        {
                            addbeneficiaryobj.Aadhaar_NO = mask;
                        }
                        else
                        {
                            addbeneficiaryobj.Aadhaar_NO = null;
                        }

                        if (!string.IsNullOrEmpty(txt_bankname.Text))
                        {
                            addbeneficiaryobj.bankname = txt_bankname.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.bankname = null;
                        }
                        if (!string.IsNullOrEmpty(txt_bankaccount.Text))
                        {
                            addbeneficiaryobj.bankaccountno = txt_bankaccount.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.bankaccountno = null;
                        }
                        if (!string.IsNullOrEmpty(txt_ifsc.Text))
                        {
                            addbeneficiaryobj.ifsccode = txt_ifsc.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.ifsccode = null;
                        }
                        if (!string.IsNullOrEmpty(txt_father.Text))
                        {
                            addbeneficiaryobj.fathername = txt_father.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.fathername = null;
                        }
                        if (!string.IsNullOrEmpty(txt_poaccount.Text))
                        {
                            addbeneficiaryobj.postofficeaccount = txt_poaccount.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.postofficeaccount = null;
                        }
                        if (!string.IsNullOrEmpty(txt_po_number.Text))
                        {
                            addbeneficiaryobj.ponumber = txt_po_number.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.ponumber = null;
                        }
                        if (!string.IsNullOrEmpty(txt_poname.Text))
                        {
                            addbeneficiaryobj.poname = txt_poname.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.poname = null;
                        }
                        //Newly adding for sub_cast
                        if (ddl_Subcaste.SelectedItem.Text != "Select")
                        {
                            addbeneficiaryobj.sub_caste = ddl_Subcaste.SelectedItem.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.sub_caste = null;
                        }
                        if (!string.IsNullOrEmpty(ddl_Subcaste.SelectedValue) || (ddl_Subcaste.SelectedValue != "0"))
                        {
                            addbeneficiaryobj.sub_caste = ddl_Subcaste.SelectedValue;
                        }
                        else
                        {
                            addbeneficiaryobj.sub_caste = null;
                        }
                        if (ddl_Caste.SelectedItem.Text != "Select")
                        {
                            addbeneficiaryobj.caste = ddl_Caste.SelectedItem.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.caste = null;
                        }
                        if (!string.IsNullOrEmpty(ddl_Caste.SelectedValue) || (ddl_Caste.SelectedValue != "0"))
                        {
                            addbeneficiaryobj.caste = ddl_Caste.SelectedValue;
                        }
                        else
                        {
                            addbeneficiaryobj.caste = null;
                        }
                        //if (!string.IsNullOrEmpty(txt_subcaste.Text))
                        //{
                        //    addbeneficiaryobj.sub_caste = txt_subcaste.Text;
                        //}
                        //else
                        //{
                        //    addbeneficiaryobj.sub_caste = null;
                        //}

                        //if (!string.IsNullOrEmpty(txt_cst.Text))
                        //{
                        //    addbeneficiaryobj.caste = txt_cst.Text;
                        //}
                        //else
                        //{
                        //    addbeneficiaryobj.caste = null;
                        //}

                        if (!string.IsNullOrEmpty(Apply.Text))
                        {
                            addbeneficiaryobj.dob = Apply.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.dob = null;
                        }

                        if (!string.IsNullOrEmpty(ddl_gender.SelectedValue))
                        {
                            addbeneficiaryobj.gender = ddl_gender.SelectedValue;
                        }
                        else
                        {
                            addbeneficiaryobj.gender = null;
                        }


                        if (!string.IsNullOrEmpty(txt_mob.Text))
                        {
                            addbeneficiaryobj.Mobileno = txt_mob.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.Mobileno = null;
                        }

                        if (!string.IsNullOrEmpty(Txt_address.Text))
                        {
                            addbeneficiaryobj.hAddress = Txt_address.Text;
                        }
                        else
                        {
                            addbeneficiaryobj.hAddress = null;
                        }


                        DataSet ds = ProjectRofrBAL.GetMasterDetails.Checkadhar((string)(Session["username"]), mask.Trim());
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            string adhar = mask;
                            string ad = dt.Rows[0]["Aadhaar_NO"].ToString();
                            if (adhar == ad)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Aadhar number already Exists')", true);
                            }
                            
                        }
                        else if (image != null && image.ContentLength > 0)
                        {
                            try
                            {
                                if (count > 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Valid Image!')", true);
                                }
                                else
                                {


                                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".JPG" || extension == ".JPEG" || extension == ".png" || extension == ".PNG")
                                    {
                                        if (cl == "image/png" || cl == "image/jpeg")
                                        {
                                            // location = HttpContext.Current.Server.MapPath("~/BeneficairyImages/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + imagefloder + "/" + benid + "/");

                                            string locpath = @"F:\tribal\BeneficairyImages\";
                                            string sc = @"\";
                                            location = (locpath + DateTime.Now.ToString("dd-MM-yyyy") + sc + imagefloder + sc + benid + sc);

                                            if (!Directory.Exists(location))
                                            {
                                                Directory.CreateDirectory(location);

                                            }
                                            string imagesavefilename = image.FileName;
                                            filepath = location + Path.GetFileName(image.FileName);
                                            image.SaveAs(filepath);
                                            if (image != null)
                                            {
                                                txt_image.Text = image.FileName;
                                            }
                                            if (image != null && image.ContentLength > 0)
                                            {
                                                addbeneficiaryobj.Image = image.FileName;
                                            }
                                            else
                                            {
                                                addbeneficiaryobj.Image = null;
                                            }
                                            if (image != null && image.ContentLength > 0)
                                            {
                                                addbeneficiaryobj.Imagepath = location;

                                            }
                                            else
                                            {
                                                addbeneficiaryobj.Imagepath = null;
                                            }

                                            addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                                            addbeneficiaryobj.UserName = (string)(Session["username"]);

                                            if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                                            {
                                                try
                                                {
                                                    DataTable id = ProjectRofrBAL.GetMasterDetails.AddBeneficiaryMaster(addbeneficiaryobj);
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary added successfully.Please save Beneficiary ID for future purpose and Beneficiary ID is:  " + id.Rows[0]["beneficiary_id"].ToString() + "')", true);
                                                    // DataSet ds= ProjectRofrBAL.GetMasterDetails.getbenificiaryid("","");

                                                    //GetBenficiaryID();
                                                    txt_Adhar.Text = "";
                                                    txt_image.Text = "";
                                                }

                                                catch (Exception ex)
                                                {
                                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Beneficiary insertion failed !')", true);
                                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Selected file is not a Image.. Please select Image')", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Only jpeg or png formats are allowed for images !')", true);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Image Location Created Error !')", true);
                                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                            }
                        }

                        else
                        {

                            // if (image != null && image.ContentLength > 0)
                            // {

                            if (image != null && image.ContentLength > 0)
                            {
                                addbeneficiaryobj.Image = image.FileName;
                            }
                            else
                            {
                                addbeneficiaryobj.Image = null;
                            }
                            if (image != null && image.ContentLength > 0)
                            {
                                addbeneficiaryobj.Imagepath = location;

                            }
                            else
                            {
                                addbeneficiaryobj.Imagepath = null;
                            }

                            addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                            addbeneficiaryobj.UserName = (string)(Session["username"]);

                            if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                            {
                                try
                                {
                                    DataTable id = ProjectRofrBAL.GetMasterDetails.AddBeneficiaryMaster(addbeneficiaryobj);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Beneficiary added successfully.Please save Beneficiary ID for future purpose and Beneficiary ID is:  " + id.Rows[0]["beneficiary_id"].ToString() + "')", true);
                                    // DataSet ds= ProjectRofrBAL.GetMasterDetails.getbenificiaryid("","");

                                    //GetBenficiaryID();
                                    txt_Adhar.Text = "";
                                }

                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Beneficiary insertion failed !')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);

                            }
                           
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter valid Aadhar Number!')", true);
                    HiddenField1.Value = "";
                    txt_Adhar.Text = "";
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message) ;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error ! " + ex.Message + "')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            Reset();


        }
        private void Reset()
        {
          //  System.Threading.Thread.Sleep(50000);//showing loader 5 seconds
            ddl_ITda.ClearSelection();
            ddl_district.ClearSelection();
            ddl_mandal.ClearSelection();
            ddl_Rv.ClearSelection();
            ddl_panchayat.ClearSelection();
            ddl_village.ClearSelection();

            ddl_Habitation.ClearSelection();
            ddl_gender.ClearSelection();
            //Newly adding sub_caste clear
            ddl_Subcaste.ClearSelection();
            ddl_Caste.ClearSelection();
            //txt_cst.Text = "";
            Txt_address.Text = "";
            txt_mob.Text = "";
            Apply.Text = "";
            txt_pattadhar.Text = "";
            //txt_subcaste.Text = "";
            txt_Adhar.Text = "";
            txt_image.Text = "";
            txt_father.Text = "";
            txt_bankaccount.Text = "";
            txt_bankname.Text = "";
            txt_ifsc.Text = "";
            txt_poaccount.Text = "";
            txt_poname.Text = "";
            txt_po_number.Text = "";


        }
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            try
            {
               // System.Threading.Thread.Sleep(50000);//showing loader 5 seconds
                DataSet ds = ProjectRofrBAL.GetMasterDetails.Checkadhar((string)(Session["username"]), txt_Adhar.Text.Trim());
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string adhar = txt_Adhar.Text;
                    string ad = dt.Rows[0]["Aadhaar_NO"].ToString();
                    if (adhar == ad)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Aadhar number is available')", true);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        //protected void txt_Adhar_TextChanged(object sender, EventArgs e)

        //{
        //    string str = txt_Adhar.Text.Trim();
        //    this.txt_Adhar.Text = string.Format("************{0}", this.txt_Adhar.Text.Trim().Substring((str.Length)-4, 4));
        //}

        public class aadharcard
        {
            static int[,] d = new int[,]

        {
  {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
  {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
  {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
  {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
  {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
  {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
  {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
  {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
  {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
  {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
        };
            static int[,] p = new int[,]
             {
       {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
       {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
       {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
       {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
       {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
       {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
       {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
       {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
             };

            static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

            public static bool validateVerhoeff(string num)
            {
                int c = 0; int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[(i % 8), myArray[i]]];
                }
                return c == 0;

            }
            private static int[] StringToReversedIntArray(string num)
            {
                int[] myArray = new int[num.Length];
                for (int i = 0; i < num.Length; i++)
                {
                    myArray[i] = int.Parse(num.Substring(i, 1));
                }
                Array.Reverse(myArray); return myArray;
            }
        }
        public bool Check_values(string val)
        {
            
                bool found = false;
                string[] Strval = new string[] { "alert", "script", "=", "+", "<", ">", "(", ")" };
                foreach (string vall1 in Strval)
                {
                    if (string.Equals(vall1, val))
                    {
                        found = true;
                        break;
                    }
                }
                return found;
            
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public bool obj_IsAlphaNumericcheck(dynamic obj)
        {
            try
            {
                var a = obj;
                string b = a.ToString();
                string c = b.Replace('{', ' ').Replace('}', ' ');

                var regexItem = new Regex("<");
                var regexItem1 = new Regex(">");

                if (regexItem.IsMatch(c))
                {
                    return false;
                }
                if (regexItem1.IsMatch(c))
                {
                    return false;
                }
                if (!regexItem.IsMatch(c))
                {
                    return true;
                }
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        protected void ddl_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = ddl_gender.SelectedValue;

            if (selectedGender == "M")
            {
                // Example: you can show/hide something based on selection
                // lblMessage.Text = "You selected Male";
            }
            else if (selectedGender == "F")
            {
                // lblMessage.Text = "You selected Female";
            }
        }

        protected void ddl_Caste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable scs = Landsettlementpattas.GetSUBCaste((string)(Session["username"]), ddl_Caste.Text, ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);

                if (scs.Rows.Count > 0)
                {

                    ddl_Subcaste.DataSource = scs;
                    ddl_Subcaste.DataTextField = "SUB_CASTE";
                    ddl_Subcaste.DataValueField = "SUB_CASTE";
                    ddl_Subcaste.DataBind();
                    ddl_Subcaste.Items.Insert(0, new ListItem("Select", "0"));
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

        
    }
}