using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Xml;


namespace ROFR.pages
{
    public partial class Adhar_Details_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {

                    BindCount(true, "");
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
     
        public void BindCount(bool FLAG, string VALUE)
        {
            try
            {
                string recordvalue = string.Empty;


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetAdharcount();
              

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                       
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
                        string k = string.Empty;
                        for (int i = 1; i <= rowscount; i++)
                        {
                            if (rowscount <= 500)
                            {
                                int j = i + (rowscount - 1);
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                            }
                            else
                            {
                                int remainingrows = rowscount - i;
                                if (remainingrows > 500)
                                {
                                    int j = i + 499;
                                    k = i + "-" + j;
                                    if (FLAG == false)
                                    {
                                        if (VALUE == k)
                                        {
                                            recordvalue = k;
                                        }
                                    }
                                    list.Add(new ListItem(k));
                                    i = j;
                                }
                                else
                                {
                                    int j = (i) + remainingrows;
                                    k = i + "-" + j;
                                    list.Add(new ListItem(k));
                                    i = j;
                                    break;
                                }
                            }
                        }
                        ddl_records.DataSource = list;
                        ddl_records.DataBind();
                        if (FLAG == true)
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                        }
                        else
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                            if (recordvalue != string.Empty)
                            {
                                ddl_records.SelectedValue = recordvalue;
                            }
                            else
                            {
                                ddl_records.SelectedValue = k;
                            }

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('No Data Found')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddl_records.SelectedValue != "0")
                {
                    BindData();


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
        protected void BindData()
        {
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);
               

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetAdharData(start, end);
                Session["data"] = dt;


               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void Update_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = (DataTable)Session["data"];
                adhar_detials aobj = new adhar_detials();
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
                string adharstatus = string.Empty;
                string phoneno = string.Empty;
                if (dt.Rows.Count > 0)
                {

                    //DataTable dt1 = new DataTable();
                    //dt1.Columns.Add("Aadharno");
                    //dt1.Columns.Add("AadharName");
                    //dt1.Columns.Add("CareOf");
                    //dt1.Columns.Add("StateCode");
                    //dt1.Columns.Add("DistrictCode");
                    //dt1.Columns.Add("District");
                    //dt1.Columns.Add("MandalCode");
                    //dt1.Columns.Add("Mandal");
                    //dt1.Columns.Add("VillageCode");
                    //dt1.Columns.Add("Village");
                    //dt1.Columns.Add("Street");
                    //dt1.Columns.Add("Pincode");
                    //dt1.Columns.Add("DateofBirth");
                    //dt1.Columns.Add("Gender");
                    //dt1.Columns.Add("Phoneno");
                    //dt1.Columns.Add("adharstatus");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        WS_Aadhaar.Services obj = new WS_Aadhaar.Services();
                       // string str = obj.getAadhaarInfo(dt.Rows[i]["Aadhaar_NO"].ToString(), "");
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
                                    if (strValue == "101" )
                                    {
                                        adhar = strValue +"NA";
                                    }
                                    else if(strValue == "111")
                                    {
                                        adhar = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        adhar = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        adhar = strValue;
                                    }
                                    
                                  
                                    
                                }

                                else if (strPropvalue == "name")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        aname = null;
                                    }
                                    else
                                    {
                                        aname = strValue;
                                    }
                                   
                                }
                                else if (strPropvalue == "careof")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        careof = null;
                                    }
                                    else
                                    {
                                        careof = strValue;

                                    }
                                }
                                else if (strPropvalue == "statecode")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        statecode = null;
                                    }
                                    else
                                    {
                                        statecode = strValue;

                                    }
                                }
                                else if (strPropvalue == "district")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        distcode = null;
                                    }
                                    else
                                    {
                                        distcode = strValue;

                                    }
                                }
                                else if (strPropvalue == "district_name")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        distname = null;
                                    }
                                    else
                                    {

                                        distname = strValue;

                                    }
                                }
                                else if (strPropvalue == "mandal")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        mandalcode = null;
                                    }
                                    else
                                    {
                                        mandalcode = strValue;

                                    }
                                }
                                else if (strPropvalue == "mandal_name")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        mandal = null;
                                    }
                                    else
                                    {
                                        mandal = strValue;
                                    }
                                }
                                else if (strPropvalue == "village")
                                {

                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        villagecode = null;
                                    }
                                    else
                                    {
                                        villagecode = strValue;
                                    }
                                }
                                else if (strPropvalue == "village_name")
                                {

                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        vname = null;
                                    }
                                    else
                                    {
                                        vname = strValue;
                                    }
                                }
                                else if (strPropvalue == "street")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        street = null;
                                    }
                                    else
                                    {
                                        street = strValue;
                                    }
                                }
                                else if (strPropvalue == "pincode")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        pincode = null;
                                    }
                                    else
                                    {
                                        pincode = strValue;
                                    }
                                }

                                else if (strPropvalue == "dob")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        dob = null;
                                    }
                                    else
                                    {
                                        dob = strValue;
                                    }
                                }
                                else if (strPropvalue == "gender")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        gender = null;
                                    }
                                    else
                                    {
                                        gender = strValue;
                                    }
                                }
                                else if (strPropvalue == "phoneNo")
                                {
                                    if (strValue == "101" || strValue == "111" || strValue == "121")
                                    {
                                        phoneno = null;
                                    }
                                    else
                                    {
                                        phoneno = strValue;
                                    }
                                }
                            }
                        }

                        if(adhar=="101"||adhar=="111"||adhar=="121")
                        {
                            adharstatus = "N";
                            adhar = null;
                            aname = null;
                            careof = null;
                            statecode = null;
                            distcode = null;
                            distname = null;
                            mandalcode = null;
                            mandal = null;
                            villagecode = null;
                            vname = null;
                            street = null;
                            pincode = null;
                            dob = null;
                            gender = null;
                            phoneno = null;
                        }
                        else
                        {
                            adharstatus = "Y";
                        }
                        //DataRow dr1 = dt1.NewRow();
                        //dr1["Aadharno"] = adhar;
                        //dr1["AadharName"] = aname;
                        //dr1["CareOf"] = careof;
                        //dr1["StateCode"] = statecode;
                        //dr1["DistrictCode"] = distcode;
                        //dr1["District"] = distname;
                        //dr1["MandalCode"] = mandalcode;
                        //dr1["Mandal"] = mandal;
                        //dr1["VillageCode"] = villagecode;
                        //dr1["Village"] = vname;
                        //dr1["Street"] = street;
                        //dr1["Pincode"] = pincode;
                        //dr1["DateofBirth"] = dob;
                        //dr1["Gender"] = gender;
                        //dr1["Phoneno"] = phoneno;
                        //dr1["adharstatus"] = adharstatus;
                        //dt1.Rows.Add(dr1);
                      aobj.adharno = dt.Rows[i]["Aadhaar_NO"].ToString();
                        aobj.adharname = aname;
                        aobj.careof = careof;
                        aobj.statecode = statecode;
                        aobj.distcode = distcode;
                        aobj.distname = distname;
                        aobj.mandalcode = mandalcode;
                        aobj.mandal = mandal;
                        aobj.vcode = villagecode;
                        aobj.vname = vname;
                        aobj.street = street;
                        aobj.pincode = pincode;
                        aobj.dob = dob;
                        aobj.gender = gender;
                        aobj.phoneno = phoneno;
                        aobj.adharstatus = adharstatus;

                        if (dt.Rows[i]["Aadhaar_NO"].ToString() != null || dt.Rows[i]["Aadhaar_NO"].ToString() != "")
                        {

                            DataTable DT = ProjectRofrBAL.GetMasterDetails.GetAdharUpdate(aobj);

                        }

                    }
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Updated Successfully')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
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