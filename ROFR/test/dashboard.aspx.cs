using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR.test
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    DataSet dS = ProjectRofrBAL.GetMasterDetails.GetnewDashboard();
                    DataTable dt = dS.Tables[1];
                    DataTable dt1 = dS.Tables[0];
                    //dt1 = calculatetotals(dt);
                    //totalbenificiary.InnerText = dt1.Rows[dt.Rows.Count - 1]["Total_bneficiaries"].ToString();
                    totalbeneficiaries.InnerText = dt1.Rows[dt.Rows.Count - 1]["Giribhumi_beneficiaries"].ToString();
                    Accountsupdated.InnerText = dt1.Rows[dt.Rows.Count - 1]["Bankavaliable"].ToString();
                    Acntsnotupdated.InnerText = dt1.Rows[dt.Rows.Count - 1]["Banknotavaliable"].ToString();
                    Tavailaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["total_received"].ToString();
                    Tvalidaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharisvalid"].ToString();
                    Tinvalidaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharnoinvalid"].ToString();
                    Tunavailaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharnotavaliable"].ToString();
                   extent.InnerText = dS.Tables[2].Rows[0]["Total_Extent"].ToString();
                    //latlongsupdated.InnerText = dS.Tables[23].Rows[0]["LatlongsUpdated"].ToString();
                    //latlongsnotupdated.InnerText = dS.Tables[23].Rows[0]["LatlongsnotUpdated"].ToString();
                    //rbsuccess.InnerText = dt.Rows[0]["Payment_Success"].ToString();
                    //rbfail.InnerText = dt.Rows[0]["Payment_Rejected"].ToString();
                    //BindData();
                    BindDistrictcount();
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

                DataSet dS = ProjectRofrBAL.GetMasterDetails.GetnewDashboard();
                DataTable dt = dS.Tables[0];

                dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                   // Repeater1.DataSource = dt;

                   // Repeater1.DataBind();

                    //bindcount.DataBind();



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

        protected DataTable calculatetotals(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal = dt;
            try
            {
                var Totalbneficiaries = 0M;
                var giribhumibenificiaries = 0.00M;
                var TotalROFRPATTADAAR = 0.00M;
                var totalreceived = 0.00M;
                var ROFRPATTDAARBlank = 0.00M;
                var Adhharisvalid = 0.00M;
                var Adhharnoinvalid = 0.00M;
                var Adhharnotavaliable = 0.00M;
                var Bankavaliable = 0.00M;
                var Banknotavaliable = 0.00M;
                var FullBankDetails = 0.00M;

                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();

                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        //dr1["District"] = "Total:";
                        dr1["ITDA_NAME"] = "Total:";

                        Totalbneficiaries += (dr["Total_bneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Total_bneficiaries"].ToString());
                        dr1["Total_bneficiaries"] = Totalbneficiaries;

                        giribhumibenificiaries += (dr["Giribhumi_beneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Giribhumi_beneficiaries"].ToString());
                        dr1["Giribhumi_beneficiaries"] = giribhumibenificiaries;
                        TotalROFRPATTADAAR += (dr["Total_ROFR_PATTADAAR"].ToString() == "") ? 0 : int.Parse(dr["Total_ROFR_PATTADAAR"].ToString());
                        dr1["Total_ROFR_PATTADAAR"] = TotalROFRPATTADAAR;
                        ROFRPATTDAARBlank += (dr["ROFR_PATTDAAR_Blank"].ToString() == "") ? 0 : int.Parse(dr["ROFR_PATTDAAR_Blank"].ToString());
                        dr1["ROFR_PATTDAAR_Blank"] = ROFRPATTDAARBlank;
                        totalreceived += (dr["total_received"].ToString() == "") ? 0 : int.Parse(dr["total_received"].ToString());
                        dr1["total_received"] = totalreceived;
                        Adhharisvalid += (dr["Adhharisvalid"].ToString() == "") ? 0 : int.Parse(dr["Adhharisvalid"].ToString());
                        dr1["Adhharisvalid"] = Adhharisvalid;
                        Adhharnoinvalid += (dr["Adhharnoinvalid"].ToString() == "") ? 0 : int.Parse(dr["Adhharnoinvalid"].ToString());
                        dr1["Adhharnoinvalid"] = Adhharnoinvalid;
                        Adhharnotavaliable += (dr["Adhharnotavaliable"].ToString() == "") ? 0 : int.Parse(dr["Adhharnotavaliable"].ToString());
                        dr1["Adhharnotavaliable"] = Adhharnotavaliable;
                        Bankavaliable += (dr["Bankavaliable"].ToString() == "") ? 0 : int.Parse(dr["Bankavaliable"].ToString());
                        dr1["Bankavaliable"] = Bankavaliable;
                        Banknotavaliable += (dr["Banknotavaliable"].ToString() == "") ? 0 : int.Parse(dr["Banknotavaliable"].ToString());
                        dr1["Banknotavaliable"] = Banknotavaliable;


                        FullBankDetails += (dr["FullBankDetails"].ToString() == "") ? 0 : int.Parse(dr["FullBankDetails"].ToString());
                        dr1["FullBankDetails"] = FullBankDetails;

                    }
                    dtfinal.Rows.Add(dr1);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return dtfinal;

        }

        protected void BindDistrictcount()
        {
            try
            {

                DataSet dS = ProjectRofrBAL.GetMasterDetails.Getdashboard();
                DataTable dt = dS.Tables[0];
                if (dt.Rows.Count > 0)
                {




                    // districts.InnerText= dt.Rows[0]["revienue_dist_count"].ToString();
                    districts.InnerText = dt.Rows[0]["forest_dist_count"].ToString();
                    mandals.InnerText = dt.Rows[0]["forest_mandal_count"].ToString();
                    villages.InnerText = dt.Rows[0]["forest_village_count"].ToString();
                    divisions.InnerText = dt.Rows[0]["forest_division_count"].ToString();
                    ranges.InnerText = dt.Rows[0]["forest_ranges_count"].ToString();
                    beats.InnerText = dt.Rows[0]["forest_beats_count"].ToString();

                    habitations.InnerText = dt.Rows[0]["hab_count"].ToString();


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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("http://ysrrythubharosa.ap.gov.in/RBApp/index.html");
                Response.Write("<script>window.open ('http://ysrrythubharosa.ap.gov.in/RBApp/index.html','_blank');</script>");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}