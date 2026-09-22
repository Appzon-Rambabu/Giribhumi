using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.Dynamic;
using System.Xml;

namespace ROFR.pages
{
    public partial class Adhar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div_display.Visible = false;
        }

        protected void btn_submit_click(object sender, EventArgs e)
        {
            try
            {
               // dynamic objDetails = new ExpandoObject();

                WS_Aadhaar.Services obj = new WS_Aadhaar.Services();
          string str = obj.getAadhaarInfo(txt_adhar.Text, "");
                var result = obj.getAadhaarInfo(txt_adhar.Text, "");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                string status = string.Empty;
                string a = @"/java/object[@ class='com.ecentric.servicemodels.AadhaarProfile']";
                XmlNodeList nodeList = doc.SelectNodes(a);
                XmlNodeList elemList = doc.GetElementsByTagName("void");

                //if (elemList[2].ChildNodes[0].InnerText == "100")
                //{
                    foreach (XmlNode MemberObjN1 in nodeList)
                    {
                        foreach (XmlNode MemberObjN in MemberObjN1.ChildNodes)
                        {
                            string strPropvalue = MemberObjN.Attributes["property"].Value.ToString();
                            string strValue = MemberObjN.InnerText.ToString();

                            if (strPropvalue == "careof")
                            {
                                lbl_test.Text = strValue;
                            }
                        //else if (strPropvalue == "district")
                        //{
                        //    obj.DISTRICTNAME = strValue;
                        //}
                        //else if (strPropvalue == "dob")
                        //{
                        //    obj.DATEOFBIRTH = strValue;
                        //}
                        //else if (strPropvalue == "name")
                        //{
                        //    obj.NAME = strValue;
                        //}
                        //else if (strPropvalue == "lc")
                        //{
                        //    obj.MANDALNAME = strValue;
                        //}
                        //else if (strPropvalue == "village")
                        //{
                        //    obj.VILLAGENAME = strValue;
                        //}
                        //else if (strPropvalue == "pincode")
                        //{
                        //    obj.PINCODE = strValue;
                        //}
                        //else if (strPropvalue == "gender")
                        //{
                        //    obj.GENDER = strValue;
                        //}
                    }
                }
               // }

                    div_display.Visible = true;
                lbl_display.Text = str;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        }
}