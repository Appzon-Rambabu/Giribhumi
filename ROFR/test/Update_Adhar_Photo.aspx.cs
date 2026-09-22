using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Xml;
using System.IO;

namespace ROFR.test
{
    public partial class Update_Adhar_Photo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindItda();
                  ddl_records.Items.Insert(0, new ListItem("Select", "0"));


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
                DataTable dtItda = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Itda", "", "", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_itda.DataSource = dtItda;
                    ddl_itda.DataTextField = "ITDA_NAME";
                    ddl_itda.DataValueField = "ITDA_CODE";
                    ddl_itda.DataBind();
                    ddl_itda.Items.Insert(0, new ListItem("Select", "0"));
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
                if (ddl_itda.SelectedItem.Text != "Select")
                {

               
                    BindCount( true, "", ddl_itda.SelectedItem.Text);
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
        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
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
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);
                adhar_detials aobj = new adhar_detials();
                DataTable dt = Landsettlementpattas.GetAdharPhotoUpdate((string)(Session["username"]), "details", itda, start, end);
                string adhar = string.Empty;
                string base64file = string.Empty;
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

                

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        WS_Aadhaar.Services obj = new WS_Aadhaar.Services();
                        //string str = obj.getAadhaarInfo(dt.Rows[i]["Aadhaar_NO"].ToString(), "");
                        var result = obj.getAadhaarInfo(dt.Rows[i]["Aadhaar_NO"].ToString(), "");
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        string status = string.Empty;
                        string asd = @"/java/object[@ class='com.ecentric.servicemodels.AadhaarProfile']";
                        XmlNodeList nodeList = doc.SelectNodes(asd);
                        XmlNodeList elemList = doc.GetElementsByTagName("void");
                        foreach (XmlNode MemberObjN1 in nodeList)
                        {
                            foreach (XmlNode MemberObjN in MemberObjN1.ChildNodes)
                            {
                                string strPropvalue = MemberObjN.Attributes["property"].Value.ToString();
                                string strValue = MemberObjN.InnerText.ToString();

                                if (strPropvalue == "uid")
                                {
                                    if (strValue == "101")
                                    {
                                        adhar = strValue + "NA";
                                    }
                                    else if (strValue == "111")
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
                              else  if (strPropvalue == "base64file")
                                {
                                  
                                        base64file = strValue;
                                    
                                }
                                else if (strPropvalue == "name")
                                {
                                    if (strValue == "101")
                                    {
                                        aname = strValue + "NA";
                                    }
                                    else if (strValue == "111")
                                    {
                                        aname = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        aname = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        aname = strValue;
                                    }
                                }
                                else if (strPropvalue == "careof")
                                {
                                    if (strValue == "101")
                                    {
                                        careof = strValue + "NA";
                                    }
                                    else if (strValue == "111")
                                    {
                                        careof = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        careof = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        careof = strValue;
                                    }
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
                                    distname = strValue;
                                }
                                else if (strPropvalue == "mandal")
                                {
                                    mandalcode = strValue;
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
                                    if (strValue == "101")
                                    {
                                        dob = strValue + "NA";
                                    }
                                    else if (strValue == "111")
                                    {
                                        dob = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        dob = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        dob = strValue;
                                    }
                                }
                                else if (strPropvalue == "gender")
                                {
                                    if (strValue == "101")
                                    {
                                        gender = strValue + "NA";
                                    }
                                    else if (strValue == "111")
                                    {
                                        gender = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        gender = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        gender = strValue;
                                    }
                                }
                                else if (strPropvalue == "phoneNo")
                                {
                                    if (strValue == "101")
                                    {
                                        phoneno = strValue + "NA";
                                    }
                                    else if (strValue == "111")
                                    {
                                        phoneno = strValue + "Network Error";
                                    }
                                    else if (strValue == "121")
                                    {
                                        phoneno = strValue + "Adhar Cancelled";
                                    }
                                    else
                                    {
                                        phoneno = strValue;
                                    }
                                }
                            }
                        }

                        if (base64file != "101" && base64file != "111" && base64file != "121")
                        {
                            string filepath = SaveImage(base64file, dt.Rows[i]["benficiary_id"].ToString(), ddl_itda.SelectedItem.Text, dt.Rows[i]["District_Code"].ToString());
                            //aobj.Image1 = Path.GetFileName(filepath);
                            aobj.Imagepath = filepath;
                        }
                        else
                        {
                           
                            aobj.Imagepath = null;
                        }
                        aobj.adharno = dt.Rows[i]["Aadhaar_NO"].ToString();
                        aobj.adharname = aname;
                        aobj.careof = careof;
                      
                        //aobj.statecode = statecode;
                        //aobj.distcode = distcode;
                        //aobj.distname = distname;
                        //aobj.mandalcode = mandalcode;
                        //aobj.mandal = mandal;
                        //aobj.vcode = villagecode;
                        //aobj.vname = vname;
                        //aobj.street = street;
                        //aobj.pincode = pincode;
                        aobj.dob = dob;
                        aobj.gender = gender;
                        aobj.phoneno = phoneno;
                        aobj.bid = dt.Rows[i]["benficiary_id"].ToString();
                        if (base64file != ("101") && base64file != ("111") && base64file != "121")
                        {
                            if (dt.Rows[i]["Aadhaar_NO"].ToString() != null || dt.Rows[i]["Aadhaar_NO"].ToString() != "")
                            {

                                DataTable dtu = Landsettlementpattas.GetAdharUpdateImage(aobj);

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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        public string SaveImage(string ImgStr, string benid, string itdaname,string distcode)
        {
            string imagefloder = itdaname + distcode;
           
            String path = HttpContext.Current.Server.MapPath("~/BeneficairyImages/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + imagefloder + "/" + benid + "/");
            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

           string imageName = benid + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path+imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return imgPath;
        }
        public void BindCount(bool FLAG, string VALUE, string Itda)
        {
            try
            {
                string recordvalue = string.Empty;
                DataTable dt = Landsettlementpattas.GetAdharPhotoUpdate((string)(Session["username"]), "records",Itda,"","");

               

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                       
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
                        string k = string.Empty;
                        for (int i = 1; i <= rowscount; i++)
                        {
                            if (rowscount <= 100)
                            {
                                int j = i + (rowscount - 1);
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                            }
                            else
                            {
                                int remainingrows = rowscount - i;
                                if (remainingrows > 100)
                                {
                                    int j = i + 99;
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


        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    if (ddl_records.SelectedValue != "0")
                    {
                        BindData(ddl_itda.SelectedItem.Text);
                    }
                    else
                    {
                       
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