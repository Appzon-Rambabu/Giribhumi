using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Xml;

namespace ROFR.test
{
    public partial class Adhar_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindItda();
                    //  BindData();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindItda()
        {
            try

            {


                DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_Itda.DataSource = dtItda;
                    ddl_Itda.DataTextField = "ITDA_NAME";
                    ddl_Itda.DataValueField = "ITDA_CODE";
                    ddl_Itda.DataBind();
                    ddl_Itda.Items.Insert(0, new ListItem("Select", "0"));
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
        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
               

                if (ddl_Itda.SelectedItem.Text != "Select")
                {
                    BindData(ddl_Itda.SelectedItem.Text);
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
        protected void BindData(string itda)
        {
            try
            {

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetAdharDetails(ddl_Itda.SelectedItem.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));

                string adhar = string.Empty;
                string aname = string.Empty;
                string careof = string.Empty;
                string statecode = string.Empty;
                string distcode = string.Empty;
                string distname = string.Empty;
                string mandalcode = string.Empty;
                string mandal = string.Empty;
                string villagecode = string.Empty;
                string vname = string.Empty;
                string street = string.Empty;
                string pincode = string.Empty;
                string dob = string.Empty;
                string gender = string.Empty;

                string phoneno = string.Empty;
                if (dt.Rows.Count > 0)
                {

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Aadharno");
                    dt1.Columns.Add("AadharName");
                    dt1.Columns.Add("CareOf");
                    dt1.Columns.Add("StateCode");
                    dt1.Columns.Add("DistrictCode");
                    dt1.Columns.Add("District");
                    dt1.Columns.Add("MandalCode");
                    dt1.Columns.Add("Mandal");
                    dt1.Columns.Add("VillageCode");
                    dt1.Columns.Add("Village");
                    dt1.Columns.Add("Street");
                    dt1.Columns.Add("Pincode");
                    dt1.Columns.Add("DateofBirth");
                    dt1.Columns.Add("Gender");
                    dt1.Columns.Add("Phoneno");
                  
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        WS_Aadhaar.Services obj = new WS_Aadhaar.Services();
                       // string str = obj.getAadhaarInfo("699614742138", "");
                        var result = obj.getAadhaarInfo(dt.Rows[i]["Aadhaar_NO"].ToString(), "");
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        string status = string.Empty;
                        string a = @"/java/object[@ class='com.ecentric.servicemodels.AadhaarProfile']";
                        XmlNodeList nodeList = doc.SelectNodes(a);
                        XmlNodeList elemList = doc.GetElementsByTagName("void");
                        foreach (XmlNode MemberObjN1 in nodeList)
                        {
                            foreach (XmlNode MemberObjN in MemberObjN1.ChildNodes)
                            {
                                string strPropvalue = MemberObjN.Attributes["property"].Value.ToString();
                                string strValue = MemberObjN.InnerText.ToString();

                                if (strPropvalue == "uid")
                                {
                                 adhar = strValue;
                                }

                              else if (strPropvalue == "name")
                                {
                                     aname = strValue;
                                }
                                else if (strPropvalue == "careof")
                                {
                                    careof = strValue;
                                }
                                else if (strPropvalue == "statecode")
                                {
                                     statecode = strValue;
                                }
                                else if (strPropvalue == "district")
                                {
                                  distcode = strValue;
                                }
                                else if (strPropvalue == "district_name")
                                {
                                    distname  = strValue;
                                }
                                else if (strPropvalue == "mandal")
                                {
                                    mandalcode= strValue;
                                }
                                else if (strPropvalue == "mandal_name")
                                {
                                     mandal = strValue;
                                }
                                else if (strPropvalue == "village")
                                {
                                     villagecode = strValue;
                                }
                                else if (strPropvalue == "village_name")
                                {
                                vname = strValue;
                                }
                                else if (strPropvalue == "street")
                                {
                                     street = strValue;
                                }
                                else if (strPropvalue == "pincode")
                                {
                                    pincode = strValue;
                                }
                               
                                else if (strPropvalue == "dob")
                                {
                                    dob = strValue;
                                }
                                else if (strPropvalue == "gender")
                                {
                                    gender = strValue;
                                }
                                else if (strPropvalue == "phoneNo")
                                {
                                    phoneno = strValue;
                                }
                            }
                        }
                        DataRow dr1 = dt1.NewRow();
                        dr1["Aadharno"] = adhar;
                        dr1["AadharName"] = aname;
                        dr1["CareOf"] = careof;
                        dr1["StateCode"] = statecode;
                        dr1["DistrictCode"] = distcode;
                        dr1["District"] = distname;
                        dr1["MandalCode"] = mandalcode;
                        dr1["Mandal"] = mandal;
                        dr1["VillageCode"] = villagecode;
                        dr1["Village"] = vname;
                        dr1["Street"] = street;
                        dr1["Pincode"] = pincode;
                        dr1["DateofBirth"] = dob;
                        dr1["Gender"] = gender;
                        dr1["Phoneno"] = phoneno;
                        dt1.Rows.Add(dr1);
                        Session["DATA"] = dt1;
                    }

                   
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

        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                //BindData();
                DataTable dt = (DataTable)(Session["DATA"]);

               
             
                if (dt.Rows.Count > 0)
                {
                    string filename = "Adhar_Details.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();

                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();





                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;

                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
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