using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;
using System.Drawing;
using System.IO;
using System.Web.Helpers;


namespace ROFR.pages
{
    public partial class Twd_Comments_July2021_Report : System.Web.UI.Page
    {
        HealthConnection hc = new HealthConnection();
        addbeneficiary_details obj = new addbeneficiary_details();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (!this.IsPostBack)
                {
                    BindData();
                    div_mandal.Visible = false;
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
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();


                obj.Type = "COUNTS";

                dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);


                if (dt.Rows.Count > 0)
                {

                    btn_notupload.Visible = false;

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
                        Label L_L2ACRE = (Label)item.FindControl("L_L2ACRE");
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


        protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try { 
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itdaa = e.Item.FindControl("lbl_itdad") as Label;
                Label status = e.Item.FindControl("status") as Label;
                lbl_itdaa.Text = "Itda: " + (string)Session["Itda"];
                status.Text = (string)Session["end"];
            }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void rpt2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itdaa = e.Item.FindControl("lbl_mitdad") as Label;
                Label status = e.Item.FindControl("mstatus") as Label;
                lbl_itdaa.Text = "Mandal: " + (string)Session["Mandal"];
                status.Text = (string)Session["mend"];
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
            try { 
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itda = e.Item.FindControl("lbl_itda") as Label;

                lbl_itda.Text = "ITDA: " + (string)Session["Itda"];
            }
        } catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
}

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

                System.Threading.Thread.Sleep(5000);
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
                // btn_details.Visible = false;
                // btn_abstract.Visible = false;
                // btn_mabstract.Visible = true;
                // btn_mdetails.Visible = true;
             
                btn_back_dist.Visible = true;
                btn_upload.Visible = false;
                btn_notupload.Visible = true;
                if (end == "u_noland")

            {
                Session["end"] = "Updated : No Land";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "NO LAND";
            }
            if (end == "u_lacre")
            {
                Session["end"] = "Updated : Lessthan 1 Acre";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "LESS THAN 1";
            }

            if (end == "u_l2acre")
            {
                Session["end"] = "Updated :  Between 1 and 2 Acres";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "LESS THAN 2";
            }
            if (end == "u_lineligible")
            {
                Session["end"] = "Updated : InEligible";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "SUB MERGED";
            }
            if (end == "p_noland")
            {
                Session["end"] = "Pending : No Land";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "NO LAND";
            }
            if (end == "p_lacre")
            {
                Session["end"] = "Pending : Lessthan 1 Acre";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "LESS THAN 1";
            }
            if (end == "p_l2acre")
            {
                Session["end"] = "Pending : Between 1 and 2 Acres";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "LESS THAN 2";
            }
            if (end == "p_lineligible")
            {
                Session["end"] = "Pending : InEligible";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "SUB MERGED";
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
        protected void mlink_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string mend = s.Substring(s.LastIndexOf('-') + 1);
                Session["mtend"] = mend.Trim();
                Session["Mandal"] = start.Trim();
                Session["mDistrict"] = dist.Trim();
                div_dist.Visible = false;
                div_mandal.Visible = false;
                div_village.Visible = true;
                btn_back_mandal.Visible = true;
                btn_back_dist.Visible = false;
                btn_upload.Visible = false;
                btn_notupload.Visible = false;
                btn_img_upload.Visible = true;
                if (mend == "m_noland")

                {
                    Session["mend"] = "Updated : No Land";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "NO LAND";
                }
                if (mend == "m_l1acre")
                {
                    Session["mend"] = "Updated : Lessthan 1 Acre";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "LESS THAN 1";
                }

                if (mend == "m_l2acre")
                {
                    Session["mend"] = "Updated :  Between 1 and 2 Acres";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "LESS THAN 2";
                }
                if (mend == "m_ineligible")
                {
                    Session["mend"] = "Updated : InEligible";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "SUB MERGED";
                }
                if (mend == "m_pnoland")
                {
                    Session["mend"] = "Pending : No Land";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "NO LAND";
                }
                if (mend == "m_placre")
                {
                    Session["mend"] = "Pending : Lessthan 1 Acre";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "LESS THAN 1";
                }
                if (mend == "m_pl2acre")
                {
                    Session["mend"] = "Pending : Between 1 and 2 Acres";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "LESS THAN 2";
                }
                if (mend == "m_pineligible")
                {
                    Session["mend"] = "Pending : InEligible";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "SUB MERGED";
                }
                 Repeater2.Visible = true;

                BindMandalDetail("");


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
                System.Threading.Thread.Sleep(5000);
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
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = (string)Session["Screen"];
                    obj.TYPE_CODE = (string)Session["Type"];
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

        protected void BindMandalDetail(string form)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = (string)Session["mScreen"];
                    obj.TYPE_CODE = (string)Session["mType"];
                    obj.Itda = (string)Session["Itda"];
                    obj.Mandal = (string)Session["Mandal"];
                    dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Repeater2.DataSource = dt;

                    Repeater2.DataBind();
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label lbl_msno = (Label)item.FindControl("lbl_msno");
                        Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                        if (lbl_mandal.Text == "Total")
                        {
                            lbl_msno.Text = "";
                        }
                    }
                    Session["detailmandalexcel"] = dt;




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
            div_village.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;
            btn_upload.Visible = false;
            btn_notupload.Visible = true;
            btn_img_upload.Visible = false;

        }
        protected void Get_back_dist(object sender, EventArgs e)
        {

            div_dist.Visible = true;
            div_mandal.Visible = false;
            div_village.Visible = false;
            btn_back_dist.Visible = false;

            btn_upload.Visible = true;
            btn_notupload.Visible = false;
            btn_img_upload.Visible = false;
        }



        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                this.BindData();
                string Filename = "TWD Comments July 2021 Report" + DateTime.Now + ".xls";

                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //GridView.AllowPaging = false;
                //GridView.GridLines = GridLines.Both;
                //GridView.HeaderStyle.Font.Bold = true;
                GridView.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_notupload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                //this.BindMandal("");
                string Filename = string.Empty;
                if ((string)Session["tend"] == "u_noland")

                {
                    Session["end"] = "Updated : No Land";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "NO LAND";
                }
                if ((string)Session["tend"] == "u_lacre")
                {
                    Session["end"] = "Updated : Lessthan 1 Acre";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "LESS THAN 1";
                }

                if ((string)Session["tend"] == "u_l2acre")
                {
                    Session["end"] = "Updated : Lessthan 2 Acres";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "LESS THAN 2";
                }
                if ((string)Session["tend"] == "u_lineligible")
                {
                    Session["end"] = "Updated : InEligible";
                    Session["Screen"] = "UPDATED";
                    Session["Type"] = "SUB MERGED";
                }
                if ((string)Session["tend"] == "p_noland")
                {
                    Session["end"] = "Pending : No Land";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "NO LAND";
                }
                if ((string)Session["tend"] == "p_lacre")
                {
                    Session["end"] = "Pending : Lessthan 1 Acre";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "LESS THAN 1";
                }
                if ((string)Session["tend"] == "p_l2acre")
                {
                    Session["end"] = "Pending : Lessthan 2 Acres";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "LESS THAN 2";
                }
                if ((string)Session["tend"] == "p_lineligible")
                {
                    Session["end"] = "Pending : InEligible";
                    Session["Screen"] = "PENDING";
                    Session["Type"] = "SUB MERGED";
                }
              
                if ((string)Session["District"] == "Mandal")
                {
                    Repeater1.Visible = false;
                    rpt1.Visible = true;
                    BindMandal("");
                    Filename = "Mandalwise TWD Comments July 2021 Report" + DateTime.Now + ".xls";
                    Response.ClearContent();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearHeaders();
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                    StringWriter str = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(str);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    rpt1.RenderControl(htw);
                    Response.Write(str.ToString());
                    Response.Flush();
                    Response.Close();
                    Response.End();
                }
                else
                {

                    Repeater1.Visible = true;
                    rpt1.Visible = false;
                    BindDetail("");

                    Filename = (string)Session["end"] + "  Detail Level TWD Comments July 2021 Report" + DateTime.Now + ".xls";
                    Response.ClearContent();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearHeaders();
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                    StringWriter str = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(str);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    Repeater1.RenderControl(htw);
                    Response.Write(str.ToString());
                    Response.Flush();
                    Response.Close();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_img_upload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                //this.BindMandal("");
                string Filename = string.Empty;

                if ((string)Session["mtend"] == "m_noland")

                {
                    Session["mend"] = "Updated : No Land";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "NO LAND";
                }
                if ((string)Session["mtend"] == "m_l1acre")
                {
                    Session["mend"] = "Updated : Lessthan 1 Acre";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "LESS THAN 1";
                }

                if ((string)Session["mtend"] == "m_l2acre")
                {
                    Session["mend"] = "Updated :  Between 1 and 2 Acres";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "LESS THAN 2";
                }
                if ((string)Session["mtend"] == "m_ineligible")
                {
                    Session["mend"] = "Updated : InEligible";
                    Session["mScreen"] = "UPDATED";
                    Session["mType"] = "SUB MERGED";
                }
                if ((string)Session["mtend"] == "m_pnoland")
                {
                    Session["mend"] = "Pending : No Land";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "NO LAND";
                }
                if ((string)Session["mtend"] == "m_placre")
                {
                    Session["mend"] = "Pending : Lessthan 1 Acre";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "LESS THAN 1";
                }
                if ((string)Session["mtend"] == "m_pl2acre")
                {
                    Session["mend"] = "Pending : Between 1 and 2 Acres";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "LESS THAN 2";
                }
                if ((string)Session["mtend"] == "m_pineligible")
                {
                    Session["mend"] = "Pending : InEligible";
                    Session["mScreen"] = "PENDING";
                    Session["mType"] = "SUB MERGED";
                }
                Repeater2.Visible = true;

                BindMandalDetail("");

                Filename = (string)Session["mend"] + "  Detail Level TWD Comments Report" + DateTime.Now + ".xls";
                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

               // Repeater2.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void cmnts_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                LinkButton btn = (LinkButton)sender;

                // LinkButton btn = (LinkButton)item.FindControl("LinkButton2");

                ddl_cmts_status.Items.FindByValue("NO LAND").Selected = true;
                BindItdawiseCmts();
                div_cmts_detaails.Visible = false;
                string script = "window.onload = function() { openModal(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);
                // }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void rpt_itda_cmts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_remarks = e.Item.FindControl("lbl_remarks") as Label;


                lbl_remarks.Text = ddl_cmts_status.SelectedItem.Text;
            }
        }
        protected void BindItdawiseCmts()
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();


                obj.Type = "ITDA";

                obj.TYPE_CODE = ddl_cmts_status.SelectedValue;
                dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);


                if (dt.Rows.Count > 0)
                {

                    btn_cmts_notuploaded.Visible = false;

                    rpt_itda_cmts.Visible = true;
                    rpt_itda_cmts.DataSource = dt;

                    rpt_itda_cmts.DataBind();
                    //foreach (RepeaterItem item in GridView.Items)
                    //{
                    //    Label lbl_sno = (Label)item.FindControl("lbl_sno");
                    //    LinkButton lblitda = (LinkButton)item.FindControl("lblitda");
                    //    Label itda = (Label)item.FindControl("itda");
                    //    LinkButton Link_NOLAND = (LinkButton)item.FindControl("Link_NOLAND");
                    //    Label L_NOLAND = (Label)item.FindControl("L_NOLAND");
                    //    LinkButton Link_L1ACRE = (LinkButton)item.FindControl("Link_L1ACRE");
                    //    Label L_L1ACRE = (Label)item.FindControl("L_L1ACRE");
                    //    LinkButton Link_L2ACRE = (LinkButton)item.FindControl("Link_L2ACRE");
                    //    Label L_L2ACRE = (Label)item.FindControl("L_L2ACRE");
                    //    LinkButton Link_INELIGIBLE = (LinkButton)item.FindControl("Link_INELIGIBLE");
                    //    Label L_INELIGIBLE = (Label)item.FindControl("L_INELIGIBLE");
                    //    LinkButton Link_P_NOLAND = (LinkButton)item.FindControl("Link_P_NOLAND");
                    //    Label P_NOLAND = (Label)item.FindControl("P_NOLAND");
                    //    LinkButton Link_P_L1ACRE = (LinkButton)item.FindControl("Link_P_L1ACRE");
                    //    Label P_L1ACRE = (Label)item.FindControl("P_L1ACRE");
                    //    LinkButton Link_P_L2ACRE = (LinkButton)item.FindControl("Link_P_L2ACRE");
                    //    Label P_L2ACRE = (Label)item.FindControl("P_L2ACRE");
                    //    LinkButton Link_P_INELIGIBLE = (LinkButton)item.FindControl("Link_P_INELIGIBLE");
                    //    Label P_INELIGIBLE = (Label)item.FindControl("P_INELIGIBLE");
                    //    if (lblitda.Text == "Total")
                    //    {
                    //        lbl_sno.Text = "";
                    //        lblitda.Visible = false;
                    //        itda.Visible = true;
                    //        L_NOLAND.Visible = true;
                    //        Link_NOLAND.Visible = false;
                    //        L_L1ACRE.Visible = true;
                    //        Link_L1ACRE.Visible = false;
                    //        L_L2ACRE.Visible = true;
                    //        Link_L2ACRE.Visible = false;
                    //        L_INELIGIBLE.Visible = true;
                    //        Link_INELIGIBLE.Visible = false;
                    //        P_NOLAND.Visible = true;
                    //        Link_P_NOLAND.Visible = false;
                    //        P_L1ACRE.Visible = true;
                    //        Link_P_L1ACRE.Visible = false;
                    //        P_L2ACRE.Visible = true;
                    //        Link_P_L2ACRE.Visible = false;
                    //        P_INELIGIBLE.Visible = true;
                    //        Link_P_INELIGIBLE.Visible = false;

                    //    }
                    //    if (L_NOLAND.Text == "0")
                    //    {
                    //        L_NOLAND.Visible = true;
                    //        Link_NOLAND.Visible = false;
                    //    }
                    //    if (L_L1ACRE.Text == "0")
                    //    {
                    //        L_L1ACRE.Visible = true;
                    //        Link_L1ACRE.Visible = false;
                    //    }
                    //    if (L_L2ACRE.Text == "0")
                    //    {
                    //        L_L2ACRE.Visible = true;
                    //        Link_L2ACRE.Visible = false;
                    //    }
                    //    if (L_INELIGIBLE.Text == "0")
                    //    {
                    //        L_INELIGIBLE.Visible = true;
                    //        Link_INELIGIBLE.Visible = false;
                    //    }

                    //    if (P_NOLAND.Text == "0")
                    //    {
                    //        P_NOLAND.Visible = true;
                    //        Link_P_NOLAND.Visible = false;
                    //    }
                    //    if (P_L1ACRE.Text == "0")
                    //    {
                    //        P_L1ACRE.Visible = true;
                    //        Link_P_L1ACRE.Visible = false;
                    //    }
                    //    if (P_L2ACRE.Text == "0")
                    //    {
                    //        P_L2ACRE.Visible = true;
                    //        Link_P_L2ACRE.Visible = false;
                    //    }
                    //    if (P_INELIGIBLE.Text == "0")
                    //    {
                    //        P_INELIGIBLE.Visible = true;
                    //        Link_P_INELIGIBLE.Visible = false;
                    //    }

                    //}
                    Session["Itdawisecmts"] = dt;



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
        public void btncmtsupload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                this.BindItdawiseCmts();
                string Filename = "TWD Commentswise July 2021 Abstract Report" + DateTime.Now + ".xls";

                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //GridView.AllowPaging = false;
                //GridView.GridLines = GridLines.Both;
                //GridView.HeaderStyle.Font.Bold = true;
                rpt_itda_cmts.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void cmnts_onclick1(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                this.BindItdawiseCmts();
                string Filename = "TWD Commentswise July 2021 Abstract Report" + DateTime.Now + ".xls";

                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //GridView.AllowPaging = false;
                //GridView.GridLines = GridLines.Both;
                //GridView.HeaderStyle.Font.Bold = true;
                rpt_itda_cmts.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void Get_back_cmtsdist(object sender, EventArgs e)
        {

            div_itda_cmts.Visible = true;
            div_cmts_detaails.Visible = false;
            // div_village.Visible = false;
            itda_cmts_back.Visible = false;

            btn_cmts_upload.Visible = true;
            btn_cmts_notuploaded.Visible = false;
            // btn_img_upload.Visible = false;
        }

        protected void Rpt_cmts_detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_cmtsitdaa = e.Item.FindControl("lbl_cmtsitdaa") as Label;
                Label cmtsstatus = e.Item.FindControl("cmtsstatus") as Label;

                Label cmtsremarks = e.Item.FindControl("cmtsremarks") as Label;
                lbl_cmtsitdaa.Text = "ITDA: " + (string)Session["cmtsItda"];
                cmtsstatus.Text = "REMARKS: " + ddl_cmts_status.SelectedValue;
                cmtsremarks.Text = "COMMENTS: " + (string)Session["Cend"];
            }
        }
        protected void Close_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void cmtslink_onclick(object sender, EventArgs e)
        {
            try
            {

                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["cmtstend"] = end.Trim();
                Session["cmtsItda"] = start.Trim();
                Session["cmtsDistrict"] = dist.Trim();
                div_dist.Visible = false;
                div_mandal.Visible = true;
                // btn_details.Visible = false;
                // btn_abstract.Visible = false;
                // btn_mabstract.Visible = true;
                // btn_mdetails.Visible = true;

                btn_back_dist.Visible = true;
                btn_upload.Visible = false;
                btn_notupload.Visible = true;
                if (end == "i_noland")

                {
                    Session["Cend"] = " Updated : NO LAND";
                    Session["CScreen"] = "NO LAND";
                    Session["CType"] = "NO LAND";
                }
                if (end == "i_land_ident")
                {
                    Session["Cend"] = "Updated : LAND TO IDENTIFIED";
                    Session["CScreen"] = "LAND TO BE IDENTIFIED";
                    Session["CType"] = "LAND TO BE IDENTIFIED";
                }

                if (end == "i_polavaram")
                {
                    Session["Cend"] = "Updated : POLAVARAM SUBMERGED";
                    Session["CScreen"] = "POLAVARAM SUBMERGED";
                    Session["CType"] = "POLAVARAM SUBMERGED";
                }
                if (end == "i_death")
                {
                    Session["Cend"] = "Updated : DEATH CASES";
                    Session["CScreen"] = "DEATH CASE";
                    Session["CType"] = "DEATH CASE";
                }
                if (end == "i_ntribes")
                {
                    Session["Cend"] = "Updated : NON TRIBES";
                    Session["CScreen"] = "NON TRIBES";
                    Session["CType"] = "NON TRIBES";
                }
                if (end == "i_govt")
                {
                    Session["Cend"] = "Updated : GOVT EMPLOYEE";
                    Session["CScreen"] = "GOVT EMP";
                    Session["CType"] = "GOVT EMP";
                }
                if (end == "i_web")
                {
                    Session["Cend"] = "Updated : HAVING LAND -NOT UPDATE WEBLAND";
                    Session["CScreen"] = "NOT IN WEBLAND";
                    Session["CType"] = "NOT IN WEBLAND";
                }
                if (end == "i_giri")
                {
                    Session["Cend"] = "Updated : HAVING LAND -NOT UPDATE GIRIBHUMI";
                    Session["CScreen"] = "NOT IN GIRIBHUMI";
                    Session["CType"] = "NOT IN GIRIBHUMI";
                }
                if (end == "i_mut")
                {
                    Session["Cend"] = "Updated :HAVING LAND - MUTATION TO BE DONE";
                    Session["CScreen"] = "MUTATION PENDING";
                    Session["CType"] = "MUTATION PENDING";
                }
                if (end == "i_cult")
                {
                    Session["Cend"] = "Updated : NOT DEPEND CULTIVATION";
                    Session["CScreen"] = "NOT DEPEND CULT";
                    Session["CType"] = "NOT DEPEND CULT";
                }
                if (end == "i_mig")
                {
                    Session["Cend"] = "Updated: MIGRATED";
                    Session["CScreen"] = "MIGRATED";
                    Session["CType"] = "MIGRATED";
                }
                //if (dist == "Mandal")
                //{
                //    Repeater1.Visible = false;
                //    rpt1.Visible = true;
                //    BindMandal("");

                //}
                //else
                //{

                Rpt_cmts_detail.Visible = true;
                //rpt1.Visible = false;
                BindcmtsDetail("");
                //}

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void BindcmtsDetail(string form)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                if (form == "")
                {
                    obj.Type = (string)Session["CScreen"];
                    obj.REMARKS = (string)Session["CType"];
                    obj.Itda = (string)Session["cmtsItda"];

                    dt = hc.TWD_COMMENTS_REPORT_NEW_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Rpt_cmts_detail.DataSource = dt;
                    Rpt_cmts_detail.DataBind();
                    Session["detailcmtsexcel"] = dt;

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
        protected void ddlcmts_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
               // LinkButton btn = (LinkButton)sender;

               // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert("+ ddl_cmts_status.SelectedValue + ")", true);
                BindItdawiseCmts();
                div_cmts_detaails.Visible = false;
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_cmtsnotupload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                //this.BindMandal("");
                string Filename = string.Empty;

                if ((string)Session["cmtstend"] == "i_noland")

                {
                    Session["Cend"] = " Updated : NO LAND";
                    Session["CScreen"] = "NO LAND";
                    Session["CType"] = "NO LAND";
                }
                if ((string)Session["cmtstend"] == "i_land_ident")
                {
                    Session["Cend"] = "Updated : LAND TO IDENTIFIED";
                    Session["CScreen"] = "LAND TO BE IDENTIFIED";
                    Session["CType"] = "LAND TO BE IDENTIFIED";
                }

                if ((string)Session["cmtstend"] == "i_polavaram")
                {
                    Session["Cend"] = "Updated : POLAVARAM SUBMERGED";
                    Session["CScreen"] = "POLAVARAM SUBMERGED";
                    Session["CType"] = "POLAVARAM SUBMERGED";
                }
                if ((string)Session["cmtstend"] == "i_death")
                {
                    Session["Cend"] = "Updated : DEATH CASES";
                    Session["CScreen"] = "DEATH CASE";
                    Session["CType"] = "DEATH CASE";
                }
                if ((string)Session["cmtstend"] == "i_ntribes")
                {
                    Session["Cend"] = "Updated : NON TRIBES";
                    Session["CScreen"] = "NON TRIBES";
                    Session["CType"] = "NON TRIBES";
                }
                if ((string)Session["cmtstend"] == "i_govt")
                {
                    Session["Cend"] = "Updated : GOVT EMPLOYEE";
                    Session["CScreen"] = "GOVT EMP";
                    Session["CType"] = "GOVT EMP";
                }
                if ((string)Session["cmtstend"] == "i_web")
                {
                    Session["Cend"] = "Updated : HAVING LAND -NOT UPDATE WEBLAND";
                    Session["CScreen"] = "NOT IN WEBLAND";
                    Session["CType"] = "NOT IN WEBLAND";
                }
                if ((string)Session["cmtstend"] == "i_giri")
                {
                    Session["Cend"] = "Updated : HAVING LAND -NOT UPDATE GIRIBHUMI";
                    Session["CScreen"] = "NOT IN GIRIBHUMI";
                    Session["CType"] = "NOT IN GIRIBHUMI";
                }
                if ((string)Session["cmtstend"] == "i_mut")
                {
                    Session["Cend"] = "Updated :HAVING LAND - MUTATION TO BE DONE";
                    Session["CScreen"] = "MUTATION PENDING";
                    Session["CType"] = "MUTATION PENDING";
                }
                if ((string)Session["cmtstend"] == "i_cult")
                {
                    Session["Cend"] = "Updated : NOT DEPEND CULTIVATION";
                    Session["CScreen"] = "NOT DEPEND CULT";
                    Session["CType"] = "NOT DEPEND CULT";
                }
                if ((string)Session["cmtstend"] == "i_mig")
                {
                    Session["Cend"] = "Updated: MIGRATED";
                    Session["CScreen"] = "MIGRATED";
                    Session["CType"] = "MIGRATED";
                }
                if ((string)Session["cmtsDistrict"] == "Mandal")
                {
                    //Repeater1.Visible = false;
                    //rpt1.Visible = true;
                    //BindMandal("");
                    //Filename = "Mandalwise TWD Comments July 2021 Report" + DateTime.Now + ".xls";
                    //Response.ClearContent();
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.ClearHeaders();
                    //Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";
                    //Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                    //StringWriter str = new StringWriter();
                    //HtmlTextWriter htw = new HtmlTextWriter(str);
                    //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    //rpt1.RenderControl(htw);
                    //Response.Write(str.ToString());
                    //Response.Flush();
                    //Response.Close();
                    //Response.End();
                }
                else
                {

                    Rpt_cmts_detail.Visible = true;
                    // rpt1.Visible = false;
                    BindcmtsDetail("");

                    Filename = (string)Session["Cend"] + "  Detail Level TWD Comments wise July 2021 Report" + DateTime.Now + ".xls";
                    Response.ClearContent();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearHeaders();
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                    StringWriter str = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(str);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    Rpt_cmts_detail.RenderControl(htw);
                    Response.Write(str.ToString());
                    Response.Flush();
                    Response.Close();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
    }
}