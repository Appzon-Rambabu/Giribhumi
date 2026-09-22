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
using System.Web.UI.HtmlControls;
using System.Web.Helpers;


namespace ROFR.pages
{
    public partial class TWD_Comments_New_Report : System.Web.UI.Page
    {



        HealthConnection hc = new HealthConnection();
        addbeneficiary_details obj = new addbeneficiary_details();
        DataSet rdt = new DataSet();
        DataTable rd = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ddl_status.Items.FindByValue("NO LAND").Selected = true;
                    BindData();
                    div_mandal.Visible = false;
                    Repeater2.Visible = false;
                    Repeater3.Visible = false;
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
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        protected void BindData()
        {
            try
            {
                DataTable dt = new DataTable();

                obj.Type = "COUNTS";

                dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                if (dt.Rows.Count > 0)
                {

                    //btn_details.Visible = false;

                    GridView.Visible = true;
                    GridView.DataSource = dt;
                    GridView.DataBind();
                    foreach (RepeaterItem item in GridView.Items)
                    {
                        Label lbl_sno = (Label)item.FindControl("lbl_sno");
                        LinkButton lblitda = (LinkButton)item.FindControl("lblitda");
                        Label itda = (Label)item.FindControl("itda");
                        LinkButton Link_NOLAND = (LinkButton)item.FindControl("Link_NOLAND");
                        Label L_NOLAND = (Label)item.FindControl("L_NOLAND");
                        LinkButton Link_L1ACRE = (LinkButton)item.FindControl("Link_L1ACRE");
                        Label L_L1ACRE = (Label)item.FindControl("L_L1ACRE");
                        LinkButton Link_L2ACRE = (LinkButton)item.FindControl("Link_L2ACRE");
                        Label L_L2ACRE = (Label)item.FindControl("L_21ACRE");
                        LinkButton Link_INELIGIBLE = (LinkButton)item.FindControl("Link_INELIGIBLE");
                        Label L_INELIGIBLE = (Label)item.FindControl("L_INELIGIBLE");
                        LinkButton Link_P_NOLAND = (LinkButton)item.FindControl("Link_P_NOLAND");
                        Label P_NOLAND = (Label)item.FindControl("P_NOLAND");
                        LinkButton Link_P_L1ACRE = (LinkButton)item.FindControl("Link_P_L1ACRE");
                        Label P_L1ACRE = (Label)item.FindControl("P_L1ACRE");
                        LinkButton Link_P_L2ACRE = (LinkButton)item.FindControl("Link_P_L2ACRE");
                        Label P_L2ACRE = (Label)item.FindControl("P_L2ACRE");
                        LinkButton Link_P_INELIGIBLE = (LinkButton)item.FindControl("Link_P_INELIGIBLE");
                        Label P_INELIGIBLE = (Label)item.FindControl("P_INELIGIBLE");
                        if (lblitda.Text == "Total")
                        {
                            lbl_sno.Text = "";
                            lblitda.Visible = false;
                            itda.Visible = true;
                            L_NOLAND.Visible = true;
                            Link_NOLAND.Visible = false;
                            L_L1ACRE.Visible = true;
                            Link_L1ACRE.Visible = false;
                            L_L2ACRE.Visible = true;
                            Link_L2ACRE.Visible = false;
                            L_INELIGIBLE.Visible = true;
                            Link_INELIGIBLE.Visible = false;
                            P_NOLAND.Visible = true;
                            Link_P_NOLAND.Visible = false;
                            P_L1ACRE.Visible = true;
                            Link_P_L1ACRE.Visible = false;
                            P_L2ACRE.Visible = true;
                            Link_P_L2ACRE.Visible = false;
                            P_INELIGIBLE.Visible = true;
                            Link_P_INELIGIBLE.Visible = false;

                        }
                        if (L_NOLAND.Text == "0")
                        {
                            L_NOLAND.Visible = true;
                            Link_NOLAND.Visible = false;
                        }
                        if (L_L1ACRE.Text == "0")
                        {
                            L_L1ACRE.Visible = true;
                            Link_L1ACRE.Visible = false;
                        }
                        if (L_L2ACRE.Text == "0")
                        {
                            L_L2ACRE.Visible = true;
                            Link_L2ACRE.Visible = false;
                        }
                        if (L_INELIGIBLE.Text == "0")
                        {
                            L_INELIGIBLE.Visible = true;
                            Link_INELIGIBLE.Visible = false;
                        }

                        if (P_NOLAND.Text == "0")
                        {
                            P_NOLAND.Visible = true;
                            Link_P_NOLAND.Visible = false;
                        }
                        if (P_L1ACRE.Text == "0")
                        {
                            P_L1ACRE.Visible = true;
                            Link_P_L1ACRE.Visible = false;
                        }
                        if (P_L2ACRE.Text == "0")
                        {
                            P_L2ACRE.Visible = true;
                            Link_P_L2ACRE.Visible = false;
                        }
                        if (P_INELIGIBLE.Text == "0")
                        {
                            P_INELIGIBLE.Visible = true;
                            Link_P_INELIGIBLE.Visible = false;
                        }

                    }
                    Session["districtexcel"] = dt;

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
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itda = e.Item.FindControl("lbl_itda") as Label;

                lbl_itda.Text = "ITDA: " + (string)Session["Itda"];
            }
        }
        protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itdad = e.Item.FindControl("lbl_itdad") as Label;
                Label status = e.Item.FindControl("status") as Label;
                lbl_itdad.Text = "Itda: " + (string)Session["Itda"];
                status.Text = (string)Session["end"];
            }
        }

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["tend"] = end.Trim();
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();
                div_dist.Visible = false;
                div_mandal.Visible = true;

                // btn_abstract.Visible = false;
                //btn_mabstract.Visible = true;
                if (end == "u_noland")
                {
                    Session["end"] = "Updated : No Land";
                    Session["Type"] = "NO_LAND";
                }
                if (end == "u_lacre")
                {
                    Session["end"] = "Updated : Lessthan 1 Acre";
                    Session["Type"] = "LESSTHAN ACRE";
                }

                if (end == "u_l2acre")
                {
                    Session["end"] = "Updated : Lessthan 2 Acres";
                    Session["Type"] = "LESSTHAN 2 ACRES";
                }
                if (end == "u_lineligible")
                {
                    Session["end"] = "Updated : InEligible";
                    Session["Type"] = "INELIGIBLE";
                }
                if (end == "p_noland")
                {
                    Session["end"] = "Pending : No Land";
                    Session["Type"] = "PENDING_NO_LAND";
                }
                if (end == "p_lacre")
                {
                    Session["end"] = "Pending : Lessthan 1 Acre";
                    Session["Type"] = "PENDING_LESSTHAN ACRE";
                }
                if (end == "p_l2acre")
                {
                    Session["end"] = "Pending : Lessthan 2 Acres";
                    Session["Type"] = "PENDING_LESSTHAN 2 ACRES";
                }
                if (end == "p_lineligible")
                {
                    Session["end"] = "Pending : InEligible";
                    Session["Type"] = "PENDING_IN_ELIGIBLE";
                }

                if (dist == "Mandal")
                {
                    Repeater1.Visible = false;
                    rpt1.Visible = true;
                    BindMandal("");

                }
                else
                {

                    Repeater1.Visible = true;
                    rpt1.Visible = false;
                    BindDetail("");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void BindMandal(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = "MANDAL COUNTS";
                    obj.Itda = (string)Session["Itda"];

                    dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    rpt1.DataSource = dt;
                    rpt1.DataBind();
                    foreach (RepeaterItem item in rpt1.Items)
                    {
                        Label lbl_msno = (Label)item.FindControl("lbl_msno");
                        Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                        Label lbl_tnoland = (Label)item.FindControl("lbl_tnoland");
                        Label lbl_tlacre = (Label)item.FindControl("lbl_tlacre");
                        Label lbl_l2acre = (Label)item.FindControl("lbl_l2acre");
                        Label lbl_ineligible = (Label)item.FindControl("lbl_ineligible");
                        Label lbl_pnoland = (Label)item.FindControl("lbl_pnoland");
                        Label lbl_placre = (Label)item.FindControl("lbl_placre");
                        Label lbl_pl2acre = (Label)item.FindControl("lbl_pl2acre");
                        Label lbl_pineligible = (Label)item.FindControl("lbl_pineligible");

                        if (lbl_mandal.Text == "Total")
                        {
                            lbl_msno.Text = "";
                        }

                    }

                    Session["mandaldexcel"] = dt;

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
        protected void BindDetail(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = (string)Session["Type"];
                    obj.Itda = (string)Session["Itda"];

                    dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                    Session["detailexcel"] = dt;

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

        protected void ddlstatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GridView.Visible = true;
                //btn_details.Visible = true;
                if (ddl_status.SelectedItem.Text != "Select")

                {

                    BindLandDetails();

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

        protected void BindLandDetails()
        {
            try
            {
                DataTable dt = new DataTable();

                obj.Type = "ITDA";
                obj.REMARKS = ddl_status.SelectedItem.Text;
                dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                if (dt.Rows.Count > 0)
                {

                    //btn_details.Visible = true;

                    Repeater2.Visible = true;
                    Repeater2.DataSource = dt;
                    Repeater2.DataBind();

                    Session["districtexcel"] = dt;

                }
                else
                {
                    Repeater2.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void link_donclick(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["tend"] = end.Trim();
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();
                div_dist.Visible = false;
                div_mandal.Visible = false;
                Repeater2.Visible = false;
                Repeater3.Visible = true;
                //btn_abstract.Visible = false;
                //btn_mabstract.Visible = true;

                if (dist == "Mandal")
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    Repeater2.Visible = true;
                    Repeater3.Visible = false;
                    BindMandalLand("");

                }
                else
                {

                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    Repeater2.Visible = false;
                    Repeater3.Visible = true;
                    //BindDetail("");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void BindMandalLand(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = "MANDAL";
                    obj.Itda = (string)Session["Itda"];

                    dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Repeater3.Visible = true;
                    Repeater3.DataSource = dt;
                    Repeater3.DataBind();


                    Session["mandaldexcel"] = dt;

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

        protected void Get_back_mandal(object sender, EventArgs e)
        {

            div_dist.Visible = false;
            div_mandal.Visible = true;
            Repeater3.Visible = true;
            Repeater2.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;

        }
        protected void Get_back_dist(object sender, EventArgs e)
        {

            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
            Repeater3.Visible = false;
            Repeater2.Visible = true;
        }

    }
}