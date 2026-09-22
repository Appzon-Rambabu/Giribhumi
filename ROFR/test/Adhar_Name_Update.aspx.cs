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
    public partial class Adhar_Name_Update : System.Web.UI.Page
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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Page Load Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        public void BindCount(bool FLAG, string VALUE)
        {
            try
            {
                string recordvalue = string.Empty;


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetNAdharcount();


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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Bind Count Error !')", true);
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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetNAdharData(start, end);
                Session["Ndata"] = dt;



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Bind Data Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void Update_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = (DataTable)Session["Ndata"];
                adhar_detials aobj = new adhar_detials();
                string adhar = string.Empty;
                string adharstatus = string.Empty;
                string aname = string.Empty;
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        adhar = string.Empty;
                        adharstatus = string.Empty;
                        aname = string.Empty;
                        AdharNameService.Services AOBJ = new AdharNameService.Services();
                        var result = AOBJ.DemoAuthenticationservice(dt.Rows[i]["AADHAAR_NO"].ToString(), dt.Rows[i]["ROFR_PATTADAAR"].ToString(), "CPK", "2/104", dt.Rows[i]["GENDER"].ToString());
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        string status = string.Empty;
                        string a = @"/java/object[@ class='com.beanclass.Authresult']";
                        XmlNodeList nodeList = doc.SelectNodes(a);
                        XmlNodeList elemList = doc.GetElementsByTagName("void");
                        foreach (XmlNode MemberObjN1 in nodeList)
                        {
                            foreach (XmlNode MemberObjN in MemberObjN1.ChildNodes)
                            {
                                string strPropvalue = MemberObjN.Attributes["property"].Value.ToString();
                                string strValue = MemberObjN.InnerText.ToString();

                                if (strPropvalue == "response_code")
                                {
                                    adhar = strValue;
                                    if (adhar == "100")
                                    {
                                        adharstatus = "Matched";
                                    }
                                    else if (adhar == "101")
                                    {
                                        adharstatus = "Notmatch";
                                    }
                                    else
                                    {
                                        adharstatus = null;
                                    }

                                }

                            }
                        }

                        if (adhar == "100" || adhar == "101")
                        {

                            if (dt.Rows[i]["Aadhaar_NO"].ToString() != null || dt.Rows[i]["Aadhaar_NO"].ToString() != "")
                            {
                                aobj.adharno = dt.Rows[i]["Aadhaar_NO"].ToString();
                                aobj.adharname = dt.Rows[i]["ROFR_PATTADAAR"].ToString();
                                aobj.adharstatus = adharstatus;
                                DataTable DT = ProjectRofrBAL.GetMasterDetails.GetNAdharUpdate(aobj);

                            }
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