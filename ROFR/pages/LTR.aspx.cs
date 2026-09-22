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

namespace ROFR.pages
{
    public partial class LTR : System.Web.UI.Page
    {

        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {

                if (Session["event_controle"] != null)
                {
                    if (Session["event_controle"].ToString() == "pld")
                    {
                        ddl_itda.Focus();

                    }
                    if (Session["event_controle"].ToString() == "chk")
                    {
                        btn_submit.Focus();
                        //txt_cma_no.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "chk1")
                    {
                        txt_appeal_no.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "chk2")
                    {
                        txt_rpno.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "chk3")
                    {
                        //txt_gov_remarks.Focus();
                        //txt_cma_no.Focus();
                        txt_wpno.Focus();

                    }

                    else if (Session["event_controle"].ToString() == "chk4")
                    {
                        // txt_hc_remarks.Focus();
                        //txt_cma_no.Focus();
                        // txt_land_purpose.Focus();
                        btn_submit.Focus();

                    }




                    else if (Session["event_controle"].ToString() == "sdc")
                    {
                        // txt_land_purpose.Focus();
                        // btn_submit.Focus();
                        //txt_hc_gov_name.Focus();
                        txt_petitioner.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "addp")
                    {
                        // txt_land_purpose.Focus();
                        // btn_submit.Focus();
                        //txt_hc_gov_name.Focus();
                        txt_add_remarks.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "agentp")
                    {
                        // txt_land_purpose.Focus();
                        // btn_submit.Focus();
                        //txt_hc_gov_name.Focus();
                        txt_agent_remarks.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "govp")
                    {
                        // txt_land_purpose.Focus();
                        // btn_submit.Focus();
                        //txt_hc_gov_name.Focus();
                        txt_gov_remarks.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "hcp")
                    {
                        // txt_land_purpose.Focus();
                        // btn_submit.Focus();
                        //txt_hc_gov_name.Focus();
                        txt_hc_remarks.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "usdc")
                    {
                        ddl_sdc_status.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "uadd")
                    {
                        ddl_add_status.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "uagent")
                    {
                        ddl_agent_status.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "ugov")
                    {
                        ddl_gov_status.Focus();

                    }
                    else if (Session["event_controle"].ToString() == "uhc")
                    {
                        ddl_hc_status.Focus();

                    }

                }

            }
            catch (InvalidCastException ex)
            {
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //System.Threading.Thread.Sleep(5000);
                Session["event_controle"] = "pld";

                if (!IsPostBack)
                {

                    // Get values from POST data (Form collection)
                    if (Request.Form["ltId"] != null)
                    {
                        Session["ltId"] = Request.Form["ltId"];
                    }

                    if (Request.Form["CurrentPage"] != null)
                    {
                        Session["CurrentPage"] = Request.Form["CurrentPage"];
                    }


                    string ltId = Session["ltId"] != null ? Session["ltId"].ToString() : string.Empty;
                    
                    if ((string)(Session["CurrentPage"]) == "View_LTR.aspx")
                    {

                        if (!string.IsNullOrEmpty((string)(Session["ltId"])))
                        {
                            // btn_rdo_upload.Visible = false;
                            h_title.InnerText = "UPDATE LAND TRANSFER REGULATION";
                            div_add_partially.Visible = false;
                            div_agent_partially.Visible = false;
                            div_gov_partially.Visible = false;
                            div_high_court_partially.Visible = false;

                            //div_sdc_partially.Visible = false;
                            div_add_option.Visible = false;
                            div_agent_option.Visible = false;
                            div_gov_option.Visible = false;
                            div_hc_option.Visible = false;
                            Binddata((string)(Session["ltId"]));
                            Session["getltrid"] = (string)(Session["ltId"]);
                            Session["updateId"] = (string)(Session["ltId"]);
                            File_rdo_doc.Attributes.Add("onchange", "return file(this,'" + File_rdo_doc.ClientID + "');");
                            File_sdc.Attributes.Add("onchange", "return filesdc(this,'" + File_sdc.ClientID + "');");
                            file_collector.Attributes.Add("onchange", "return filecollector(this,'" + file_collector.ClientID + "');");
                            File_gov.Attributes.Add("onchange", "return filegov(this,'" + File_gov.ClientID + "');");
                            File_highcourt.Attributes.Add("onchange", "return filehighcourt(this,'" + File_highcourt.ClientID + "');");
                            gvFiles.Visible = true;
                            Bindrdo_docs();
                            btn_reset.Visible = false;

                            Session["sdcfile"] = null;
                            Session["rdofile"] = null;
                            Session["collectorfile"] = null;
                            Session["govfile"] = null;
                            Session["highcourtfile"] = null;
                        }
                    }
                    else
                    {
                        dtp_input2.Attributes.Add("readonly", "readonly");
                        Session["updateId"] = "0";
                        div_add_agent.Visible = false;
                        div_agent.Visible = false;
                        div_gov.Visible = false;
                        div_high_court.Visible = false;
                        div_add_partially.Visible = false;
                        div_agent_partially.Visible = false;
                        div_gov_partially.Visible = false;
                        div_high_court_partially.Visible = false;
                        div_sdc.Visible = false;
                        div_sdc_nt_name.Visible = false;
                        //div_sdc_gov_name.Visible = false;
                        div_sdc_tri_name.Visible = false;
                        div_sdc_nt_name.Visible = false;
                        //div_sdc_tri_orders_impl.Visible = false;
                        // div_sdc_gov_orders_impl.Visible = false;
                        div_sdc_partially.Visible = false;
                        div_add_option.Visible = false;
                        div_agent_option.Visible = false;
                        div_gov_option.Visible = false;
                        div_hc_option.Visible = false;
                        div_note.Visible = false;
                        File_rdo_doc.Attributes.Add("onchange", "return file(this,'" + File_rdo_doc.ClientID + "');");
                        File_sdc.Attributes.Add("onchange", "return filesdc(this,'" + File_sdc.ClientID + "');");
                        file_collector.Attributes.Add("onchange", "return filecollector(this,'" + file_collector.ClientID + "');");
                        File_gov.Attributes.Add("onchange", "return filegov(this,'" + File_gov.ClientID + "');");
                        File_highcourt.Attributes.Add("onchange", "return filehighcourt(this,'" + File_highcourt.ClientID + "');");
                        BindItda();
                        // FileUpload1.Attributes.Add(" ReadOnly", "return false;");


                        ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_hab.Items.Insert(0, new ListItem("Select", "0"));

                        btn_edit.Visible = false;
                        btnback.Visible = false;

                        this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
                        Session["sdcfile"] = null;
                        Session["rdofile"] = null;
                        Session["collectorfile"] = null;
                        Session["govfile"] = null;
                        Session["highcourtfile"] = null;

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void chk_add_agent_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "chk1";
                if (chk_add_agent.Checked == true || chk_add_agent.Checked == false)
                {
                    //div_high_court.Visible = true;

                    ddl_add.Items.Clear();
                    ddl_add.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_add.Items.Insert(1, new ListItem("ALLOWED", "ALLOWED"));
                    ddl_add.Items.Insert(2, new ListItem("DISALLOWED", "DISALLOWED"));
                    ddl_add.Items.Insert(3, new ListItem("REMANDED", "REMANDED"));
                    ddl_add_status.Items.Clear();
                    ddl_add_status.Items.Insert(0, new ListItem("SELECT", "0"));
                    ddl_add_status.Items.Insert(1, new ListItem("PENDING", "PENDING"));
                    ddl_add_status.Items.Insert(2, new ListItem("DISPOSED", "DISPOSED"));


                    div_add_option.Visible = false;
                    div_add_partially.Visible = false;
                }
                else
                {
                    ddl_add.ClearSelection();
                    txt_cma_no.Text = "";
                    txt_add_dt_orders.Text = "";
                    rbtn_add_orders_passed.ClearSelection();
                    rbtn_add_remanded.ClearSelection();
                    rbtn_add_nt.Checked = false;
                    rbtn_add_tri.Checked = false;
                    rbtn_add_gov.Checked = false;
                    txt_add_nt_name.Text = "";
                    txt_add_nt_extent.Text = "";
                    txt_add_tri_name.Text = "";
                    txt_add_tri_extent.Text = "";
                    txt_add_gov_name.Text = "";
                    txt_add_gov_extent.Text = "";
                    txt_rdo_sdc_doc.Text = "";
                    txt_add_remarks.Text = "";

                }

            }
            else
            {
                Session["event_controle"] = "chk";

                if (chk_add_agent.Checked == true)
                {

                    div_add_agent.Visible = true;
                    //chk_agent.Checked = false;

                    // chk_agent.Enabled = false;
                    // chk_government.Enabled = false;
                    // chk_high_court.Enabled = false;
                    rbtn_add_orders_passed.ClearSelection();
                    div_add_partially.Visible = false;
                    div_agent.Visible = false;
                    div_gov.Visible = false;
                    div_high_court.Visible = false;
                    chk_agent.Checked = false;
                    chk_government.Checked = false;
                    chk_high_court.Checked = false;
                    txt_wpno.Text = "";
                    txt_hc_dt_orders.Text = "";
                    rbtn_hc_orders_passed.ClearSelection();
                    rbtn_hc_remanded.ClearSelection();
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    rbtn_hc_tri_orders_impl.ClearSelection();
                    rbtn_hc_orders_impl.ClearSelection();
                    txt_hc_nt_name.Text = "";
                    txt_hc_nt_extent.Text = "";
                    txt_hc_tri_name.Text = "";
                    txt_hc_tri_extent.Text = "";
                    txt_hc_gov_name.Text = "";
                    txt_hc_gov_extent.Text = "";
                    txt_high_court_doc.Text = "";
                    txt_hc_remarks.Text = "";
                    // ClientScript.RegisterStartupScript(typeof(Page), "settingfocus", "<script language=javascript>document.getElementById( '<%=chk_add_agent.ClientID %>').focus();</script>");

                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "setFocus()", true);
                    txt_rpno.Text = "";
                    txt_gov_dt_orders.Text = "";
                    rbtn_gov_orders_passed.ClearSelection();
                    rbtn_gov_remanded.ClearSelection();
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;
                    rbtn_gov_impl.ClearSelection();
                    rbtn_gov_tri_impl.ClearSelection();
                    txt_gov_nt_name.Text = "";
                    txt_gov_nt_extent.Text = "";
                    txt_gov_tri_name.Text = "";
                    txt_gov_tri_extent.Text = "";
                    txt_gov_gov_name.Text = "";
                    txt_gov_gov_extent.Text = "";
                    txt_govt_doc.Text = "";
                    txt_gov_remarks.Text = "";
                    ddl_agent.ClearSelection();
                    txt_appeal_no.Text = "";
                    txt_agent_dt_orders.Text = "";
                    rbtn_agent.ClearSelection();
                    rbtn_agent_remanded.ClearSelection();
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;
                    rbtn_agent_gov_impl.ClearSelection();
                    rbtn_agent_tri_impl.ClearSelection();
                    txt_nt_name.Text = "";
                    txt_nt_extent.Text = "";
                    txt_tri_name.Text = "";
                    txt_tri_extent.Text = "";
                    txt_gov_name.Text = "";
                    txt_gov_extent.Text = "";
                    txt_collector_po_doc.Text = "";
                    txt_agent_remarks.Text = "";
                }
                else
                {
                    div_add_agent.Visible = false;
                    ddl_add.ClearSelection();
                    txt_cma_no.Text = "";
                    txt_add_dt_orders.Text = "";
                    rbtn_add_orders_passed.ClearSelection();
                    rbtn_add_remanded.ClearSelection();
                    rbtn_add_nt.Checked = false;
                    rbtn_add_tri.Checked = false;
                    rbtn_add_gov.Checked = false;
                    txt_add_nt_name.Text = "";
                    txt_add_nt_extent.Text = "";
                    txt_add_tri_name.Text = "";
                    txt_add_tri_extent.Text = "";
                    txt_add_gov_name.Text = "";
                    txt_add_gov_extent.Text = "";
                    txt_rdo_sdc_doc.Text = "";
                    txt_add_remarks.Text = "";


                }
            }

        }
        protected void chk_agent_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "chk2";
                if (chk_agent.Checked == true || chk_agent.Checked == false)
                {
                    //div_high_court.Visible = true;

                    ddl_agent.Items.Clear();
                    ddl_agent.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_agent.Items.Insert(1, new ListItem("ALLOWED", "ALLOWED"));
                    ddl_agent.Items.Insert(2, new ListItem("DISALLOWED", "DISALLOWED"));
                    ddl_agent.Items.Insert(3, new ListItem("REMANDED", "REMANDED"));
                    ddl_agent_status.Items.Clear();
                    ddl_agent_status.Items.Insert(0, new ListItem("SELECT", "0"));
                    ddl_agent_status.Items.Insert(1, new ListItem("PENDING", "PENDING"));
                    ddl_agent_status.Items.Insert(2, new ListItem("DISPOSED", "DISPOSED"));

                    div_agent_option.Visible = false;
                    div_agent_partially.Visible = false;
                }
                else
                {

                    ddl_agent.ClearSelection();
                    txt_appeal_no.Text = "";
                    txt_agent_dt_orders.Text = "";
                    rbtn_agent.ClearSelection();
                    rbtn_agent_remanded.ClearSelection();
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;
                    rbtn_agent_gov_impl.ClearSelection();
                    rbtn_agent_tri_impl.ClearSelection();
                    txt_nt_name.Text = "";
                    txt_nt_extent.Text = "";
                    txt_tri_name.Text = "";
                    txt_tri_extent.Text = "";
                    txt_gov_name.Text = "";
                    txt_gov_extent.Text = "";
                    txt_collector_po_doc.Text = "";
                    txt_agent_remarks.Text = "";
                }

            }
            else
            {
                Session["event_controle"] = "chk";

                if (chk_agent.Checked == true)
                {
                    div_agent.Visible = true;
                    div_add_agent.Visible = false;
                    div_gov.Visible = false;
                    div_high_court.Visible = false;
                    chk_add_agent.Checked = false;
                    chk_government.Checked = false;
                    chk_high_court.Checked = false;
                    txt_wpno.Text = "";
                    txt_hc_dt_orders.Text = "";
                    rbtn_hc_orders_passed.ClearSelection();
                    rbtn_hc_remanded.ClearSelection();
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    rbtn_hc_tri_orders_impl.ClearSelection();
                    rbtn_hc_orders_impl.ClearSelection();
                    txt_hc_nt_name.Text = "";
                    txt_hc_nt_extent.Text = "";
                    txt_hc_tri_name.Text = "";
                    txt_hc_tri_extent.Text = "";
                    txt_hc_gov_name.Text = "";
                    txt_hc_gov_extent.Text = "";
                    txt_high_court_doc.Text = "";
                    txt_hc_remarks.Text = "";
                    //ClientScript.RegisterStartupScript(typeof(Page), "settingfocus", "<script language=javascript>document.getElementById( '<%=.ClientID %>').focus();</script>");
                    txt_rpno.Text = "";
                    txt_gov_dt_orders.Text = "";
                    rbtn_gov_orders_passed.ClearSelection();
                    rbtn_gov_remanded.ClearSelection();
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;
                    rbtn_gov_impl.ClearSelection();
                    rbtn_gov_tri_impl.ClearSelection();
                    txt_gov_nt_name.Text = "";
                    txt_gov_nt_extent.Text = "";
                    txt_gov_tri_name.Text = "";
                    txt_gov_tri_extent.Text = "";
                    txt_gov_gov_name.Text = "";
                    txt_gov_gov_extent.Text = "";
                    txt_govt_doc.Text = "";
                    txt_gov_remarks.Text = "";

                    ddl_add.ClearSelection();
                    txt_cma_no.Text = "";
                    txt_add_dt_orders.Text = "";
                    rbtn_add_orders_passed.ClearSelection();
                    rbtn_add_remanded.ClearSelection();
                    rbtn_add_nt.Checked = false;
                    rbtn_add_tri.Checked = false;
                    rbtn_add_gov.Checked = false;
                    txt_add_nt_name.Text = "";
                    txt_add_nt_extent.Text = "";
                    txt_add_tri_name.Text = "";
                    txt_add_tri_extent.Text = "";
                    txt_add_gov_name.Text = "";
                    txt_add_gov_extent.Text = "";
                    txt_rdo_sdc_doc.Text = "";
                    txt_add_remarks.Text = "";
                }
                else
                {
                    div_agent.Visible = false;
                    ddl_agent.ClearSelection();
                    txt_appeal_no.Text = "";
                    txt_agent_dt_orders.Text = "";
                    rbtn_agent.ClearSelection();
                    rbtn_agent_remanded.ClearSelection();
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;
                    rbtn_agent_gov_impl.ClearSelection();
                    rbtn_agent_tri_impl.ClearSelection();
                    txt_nt_name.Text = "";
                    txt_nt_extent.Text = "";
                    txt_tri_name.Text = "";
                    txt_tri_extent.Text = "";
                    txt_gov_name.Text = "";
                    txt_gov_extent.Text = "";
                    txt_collector_po_doc.Text = "";
                    txt_agent_remarks.Text = "";
                }
            }

        }
        protected void chk_government_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "chk3";
                if (chk_government.Checked == true || chk_government.Checked == false)
                {
                    //div_high_court.Visible = true;

                    ddl_gov.Items.Clear();
                    ddl_gov.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_gov.Items.Insert(1, new ListItem("ALLOWED", "ALLOWED"));
                    ddl_gov.Items.Insert(2, new ListItem("DISALLOWED", "DISALLOWED"));
                    ddl_gov.Items.Insert(3, new ListItem("REMANDED", "REMANDED"));

                    ddl_gov_status.Items.Clear();
                    ddl_gov_status.Items.Insert(0, new ListItem("SELECT", "0"));
                    ddl_gov_status.Items.Insert(1, new ListItem("PENDING", "PENDING"));
                    ddl_gov_status.Items.Insert(2, new ListItem("DISPOSED", "DISPOSED"));

                    div_gov_option.Visible = false;
                    div_gov_partially.Visible = false;
                }
                else
                {

                    ddl_gov.ClearSelection();
                    txt_rpno.Text = "";
                    txt_gov_dt_orders.Text = "";
                    rbtn_gov_orders_passed.ClearSelection();
                    rbtn_gov_remanded.ClearSelection();
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;
                    rbtn_gov_impl.ClearSelection();
                    rbtn_gov_tri_impl.ClearSelection();
                    txt_gov_nt_name.Text = "";
                    txt_gov_nt_extent.Text = "";
                    txt_gov_tri_name.Text = "";
                    txt_gov_tri_extent.Text = "";
                    txt_gov_gov_name.Text = "";
                    txt_gov_gov_extent.Text = "";
                    txt_govt_doc.Text = "";
                    txt_gov_remarks.Text = "";
                }

            }
            else
            {
                Session["event_controle"] = "chk";

                if (chk_government.Checked == true)
                {
                    div_gov.Visible = true;

                    div_add_agent.Visible = false;
                    div_agent.Visible = false;
                    div_high_court.Visible = false;
                    chk_add_agent.Checked = false;
                    chk_agent.Checked = false;
                    chk_high_court.Checked = false;
                    txt_wpno.Text = "";
                    txt_hc_dt_orders.Text = "";
                    rbtn_hc_orders_passed.ClearSelection();
                    rbtn_hc_remanded.ClearSelection();
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    rbtn_hc_tri_orders_impl.ClearSelection();
                    rbtn_hc_orders_impl.ClearSelection();
                    txt_hc_nt_name.Text = "";
                    txt_hc_nt_extent.Text = "";
                    txt_hc_tri_name.Text = "";
                    txt_hc_tri_extent.Text = "";
                    txt_hc_gov_name.Text = "";
                    txt_hc_gov_extent.Text = "";
                    txt_high_court_doc.Text = "";
                    txt_hc_remarks.Text = "";

                    ddl_agent.ClearSelection();
                    txt_appeal_no.Text = "";
                    txt_agent_dt_orders.Text = "";
                    rbtn_agent.ClearSelection();
                    rbtn_agent_remanded.ClearSelection();
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;
                    rbtn_agent_gov_impl.ClearSelection();
                    rbtn_agent_tri_impl.ClearSelection();
                    txt_nt_name.Text = "";
                    txt_nt_extent.Text = "";
                    txt_tri_name.Text = "";
                    txt_tri_extent.Text = "";
                    txt_gov_name.Text = "";
                    txt_gov_extent.Text = "";
                    txt_collector_po_doc.Text = "";
                    txt_agent_remarks.Text = "";

                    ddl_add.ClearSelection();
                    txt_cma_no.Text = "";
                    txt_add_dt_orders.Text = "";
                    rbtn_add_orders_passed.ClearSelection();
                    rbtn_add_remanded.ClearSelection();
                    rbtn_add_nt.Checked = false;
                    rbtn_add_tri.Checked = false;
                    rbtn_add_gov.Checked = false;
                    txt_add_nt_name.Text = "";
                    txt_add_nt_extent.Text = "";
                    txt_add_tri_name.Text = "";
                    txt_add_tri_extent.Text = "";
                    txt_add_gov_name.Text = "";
                    txt_add_gov_extent.Text = "";
                    txt_rdo_sdc_doc.Text = "";
                    txt_add_remarks.Text = "";

                }
                else
                {
                    div_gov.Visible = false;
                    ddl_gov.ClearSelection();
                    txt_rpno.Text = "";
                    txt_gov_dt_orders.Text = "";
                    rbtn_gov_orders_passed.ClearSelection();
                    rbtn_gov_remanded.ClearSelection();
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;
                    rbtn_gov_impl.ClearSelection();
                    rbtn_gov_tri_impl.ClearSelection();
                    txt_gov_nt_name.Text = "";
                    txt_gov_nt_extent.Text = "";
                    txt_gov_tri_name.Text = "";
                    txt_gov_tri_extent.Text = "";
                    txt_gov_gov_name.Text = "";
                    txt_gov_gov_extent.Text = "";
                    txt_govt_doc.Text = "";
                    txt_gov_remarks.Text = "";
                }
            }


        }
        protected void chk_high_court_CheckedChanged(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "chk4";
                if (chk_high_court.Checked == true || chk_high_court.Checked == false)
                {
                    //div_high_court.Visible = true;

                    ddl_hc.Items.Clear();
                    ddl_hc.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_hc.Items.Insert(1, new ListItem("ALLOWED", "ALLOWED"));
                    ddl_hc.Items.Insert(2, new ListItem("DISALLOWED", "DISALLOWED"));
                    ddl_hc.Items.Insert(3, new ListItem("REMANDED", "REMANDED"));

                    ddl_hc_status.Items.Clear();
                    ddl_hc_status.Items.Insert(0, new ListItem("SELECT", "0"));
                    ddl_hc_status.Items.Insert(1, new ListItem("PENDING", "PENDING"));
                    ddl_hc_status.Items.Insert(2, new ListItem("DISPOSED", "DISPOSED"));
                    ddl_wpno_status.Items.Clear();
                    ddl_wpno_status.Items.Insert(0, new ListItem("SELECT", "0"));
                    ddl_wpno_status.Items.Insert(1, new ListItem("STAY", "STAY"));
                    ddl_wpno_status.Items.Insert(2, new ListItem("INTERM SUSPENSION", "INTERM SUSPENSION"));
                    ddl_wpno_status.Items.Insert(3, new ListItem("STATUSCO", "STATUSCO"));

                    div_hc_option.Visible = false;
                    div_high_court_partially.Visible = false;
                }
                else
                {

                    ddl_hc.ClearSelection();
                    txt_wpno.Text = "";
                    txt_hc_dt_orders.Text = "";
                    rbtn_hc_orders_passed.ClearSelection();
                    rbtn_hc_remanded.ClearSelection();
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    rbtn_hc_tri_orders_impl.ClearSelection();
                    rbtn_hc_orders_impl.ClearSelection();
                    txt_hc_nt_name.Text = "";
                    txt_hc_nt_extent.Text = "";
                    txt_hc_tri_name.Text = "";
                    txt_hc_tri_extent.Text = "";
                    txt_hc_gov_name.Text = "";
                    txt_hc_gov_extent.Text = "";
                    txt_high_court_doc.Text = "";
                    txt_hc_remarks.Text = "";
                }

            }
            else
            {
                Session["event_controle"] = "chk";
                if (chk_high_court.Checked == true)
                {
                    div_high_court.Visible = true;

                    div_add_agent.Visible = false;
                    div_agent.Visible = false;
                    div_gov.Visible = false;
                    chk_add_agent.Checked = false;
                    chk_agent.Checked = false;
                    chk_government.Checked = false;
                    txt_rpno.Text = "";
                    txt_gov_dt_orders.Text = "";
                    rbtn_gov_orders_passed.ClearSelection();
                    rbtn_gov_remanded.ClearSelection();
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;
                    rbtn_gov_impl.ClearSelection();
                    rbtn_gov_tri_impl.ClearSelection();
                    txt_gov_nt_name.Text = "";
                    txt_gov_nt_extent.Text = "";
                    txt_gov_tri_name.Text = "";
                    txt_gov_tri_extent.Text = "";
                    txt_gov_gov_name.Text = "";
                    txt_gov_gov_extent.Text = "";
                    txt_govt_doc.Text = "";
                    txt_gov_remarks.Text = "";
                    ddl_agent.ClearSelection();
                    txt_appeal_no.Text = "";
                    txt_agent_dt_orders.Text = "";
                    rbtn_agent.ClearSelection();
                    rbtn_agent_remanded.ClearSelection();
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;
                    rbtn_agent_gov_impl.ClearSelection();
                    rbtn_agent_tri_impl.ClearSelection();
                    txt_nt_name.Text = "";
                    txt_nt_extent.Text = "";
                    txt_tri_name.Text = "";
                    txt_tri_extent.Text = "";
                    txt_gov_name.Text = "";
                    txt_gov_extent.Text = "";
                    txt_collector_po_doc.Text = "";
                    txt_agent_remarks.Text = "";
                    ddl_add.ClearSelection();
                    txt_cma_no.Text = "";
                    txt_add_dt_orders.Text = "";
                    rbtn_add_orders_passed.ClearSelection();
                    rbtn_add_remanded.ClearSelection();
                    rbtn_add_nt.Checked = false;
                    rbtn_add_tri.Checked = false;
                    rbtn_add_gov.Checked = false;
                    txt_add_nt_name.Text = "";
                    txt_add_nt_extent.Text = "";
                    txt_add_tri_name.Text = "";
                    txt_add_tri_extent.Text = "";
                    txt_add_gov_name.Text = "";
                    txt_add_gov_extent.Text = "";
                    txt_rdo_sdc_doc.Text = "";
                    txt_add_remarks.Text = "";

                }
                else
                {
                    div_high_court.Visible = false;
                    ddl_hc.ClearSelection();
                    txt_wpno.Text = "";
                    txt_hc_dt_orders.Text = "";
                    rbtn_hc_orders_passed.ClearSelection();
                    rbtn_hc_remanded.ClearSelection();
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    rbtn_hc_tri_orders_impl.ClearSelection();
                    rbtn_hc_orders_impl.ClearSelection();
                    txt_hc_nt_name.Text = "";
                    txt_hc_nt_extent.Text = "";
                    txt_hc_tri_name.Text = "";
                    txt_hc_tri_extent.Text = "";
                    txt_hc_gov_name.Text = "";
                    txt_hc_gov_extent.Text = "";
                    txt_high_court_doc.Text = "";
                    txt_hc_remarks.Text = "";
                }
            }

        }

        protected void rbtn_add_orders_passed_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "addp";
                if (rbtn_add_orders_passed.SelectedValue == "A" || rbtn_add_orders_passed.SelectedValue == "B")

                {
                    div_add_partially.Visible = true;
                    rbtn_add_nt.Checked = false;
                    rbtn_add_gov.Checked = false;
                    rbtn_add_tri.Checked = false;

                    div_add_nt_txt.Visible = false;
                    div_add_tri_txt.Visible = false;
                    div_add_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_add_orders_passed.SelectedValue == "A" || rbtn_add_orders_passed.SelectedValue == "B")

                {
                    div_add_partially.Visible = true;
                    rbtn_add_nt.Checked = false;
                    rbtn_add_gov.Checked = false;
                    rbtn_add_tri.Checked = false;

                    div_add_nt_txt.Visible = false;
                    div_add_tri_txt.Visible = false;
                    div_add_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }

            }

        }

        protected void rbtn_add_nt_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "addp";

                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_nt.Checked == true)
                    {
                        div_add_nt_txt.Visible = true;
                        txt_add_nt_name.Text = "";
                        txt_add_nt_extent.Text = "";
                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_nt.Checked == true)
                    {
                        div_add_nt_txt.Visible = true;
                        rbtn_add_tri.Checked = false;
                        rbtn_add_gov.Checked = false;
                        div_add_tri_txt.Visible = false;
                        div_add_gov_txt.Visible = false;
                        txt_add_nt_name.Text = "";
                        txt_add_nt_extent.Text = "";
                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_nt.Checked == true)
                    {
                        div_add_nt_txt.Visible = true;
                        txt_add_nt_name.Text = "";
                        txt_add_nt_extent.Text = "";
                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_nt.Checked == true)
                    {
                        div_add_nt_txt.Visible = true;
                        rbtn_add_tri.Checked = false;
                        rbtn_add_gov.Checked = false;
                        div_add_tri_txt.Visible = false;
                        div_add_gov_txt.Visible = false;
                        txt_add_nt_name.Text = "";
                        txt_add_nt_extent.Text = "";
                    }
                }
            }
        }

        protected void rbtn_add_tri_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "addp";

                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_tri.Checked == true)
                    {

                        div_add_tri_txt.Visible = true;
                        txt_add_tri_name.Text = "";
                        txt_add_tri_extent.Text = "";

                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_tri.Checked == true)
                    {
                        div_add_tri_txt.Visible = true;


                        rbtn_add_nt.Checked = false;
                        rbtn_add_gov.Checked = false;
                        div_add_nt_txt.Visible = false;
                        div_add_gov_txt.Visible = false;
                        txt_add_tri_name.Text = "";
                        txt_add_tri_extent.Text = "";
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_tri.Checked == true)
                    {

                        div_add_tri_txt.Visible = true;
                        txt_add_tri_name.Text = "";
                        txt_add_tri_extent.Text = "";
                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_tri.Checked == true)
                    {
                        div_add_tri_txt.Visible = true;


                        rbtn_add_nt.Checked = false;
                        rbtn_add_gov.Checked = false;
                        div_add_nt_txt.Visible = false;
                        div_add_gov_txt.Visible = false;
                        txt_add_tri_name.Text = "";
                        txt_add_tri_extent.Text = "";
                    }

                }
            }
        }

        protected void rbtn_add_gov_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "addp";
                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_gov.Checked == true)
                    {
                        div_add_gov_txt.Visible = true;
                        txt_add_gov_name.Text = "";
                        txt_add_gov_extent.Text = "";

                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_gov.Checked == true)
                    {
                        div_add_gov_txt.Visible = true;

                        rbtn_add_nt.Checked = false;
                        rbtn_add_tri.Checked = false;
                        div_add_nt_txt.Visible = false;
                        div_add_tri_txt.Visible = false;
                        txt_add_gov_name.Text = "";
                        txt_add_gov_extent.Text = "";

                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_add_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_add_gov.Checked == true)
                    {
                        div_add_gov_txt.Visible = true;

                        txt_add_gov_name.Text = "";
                        txt_add_gov_extent.Text = "";

                    }

                }
                else if (rbtn_add_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_add_gov.Checked == true)
                    {
                        div_add_gov_txt.Visible = true;

                        rbtn_add_nt.Checked = false;
                        rbtn_add_tri.Checked = false;
                        div_add_nt_txt.Visible = false;
                        div_add_tri_txt.Visible = false;
                        txt_add_gov_name.Text = "";
                        txt_add_gov_extent.Text = "";

                    }

                }
            }
        }

        protected void rbtn_agent_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "agentp";
                if (rbtn_agent.SelectedValue == "A" || rbtn_agent.SelectedValue == "B")

                {
                    div_agent_partially.Visible = true;
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;

                    div_agent_nt_txt.Visible = false;
                    div_agent_tri_txt.Visible = false;
                    div_agent_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_agent.SelectedValue == "A" || rbtn_agent.SelectedValue == "B")

                {
                    div_agent_partially.Visible = true;
                    rbtn_nt.Checked = false;
                    rbtn_tribal.Checked = false;
                    rbtn_agent_gov.Checked = false;

                    div_agent_nt_txt.Visible = false;
                    div_agent_tri_txt.Visible = false;
                    div_agent_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
        }

        protected void rbtn_nt_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "agentp";

                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_nt.Checked == true)
                    {
                        div_agent_nt_txt.Visible = true;
                        txt_nt_name.Text = "";
                        txt_nt_extent.Text = "";

                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_nt.Checked == true)
                    {
                        div_agent_nt_txt.Visible = true;
                        rbtn_tribal.Checked = false;
                        rbtn_agent_gov.Checked = false;
                        div_agent_tri_txt.Visible = false;
                        div_agent_gov_txt.Visible = false;
                        txt_nt_name.Text = "";
                        txt_nt_extent.Text = "";


                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_nt.Checked == true)
                    {
                        div_agent_nt_txt.Visible = true;
                        txt_nt_name.Text = "";
                        txt_nt_extent.Text = "";


                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_nt.Checked == true)
                    {
                        div_agent_nt_txt.Visible = true;
                        rbtn_tribal.Checked = false;
                        rbtn_agent_gov.Checked = false;
                        div_agent_tri_txt.Visible = false;
                        div_agent_gov_txt.Visible = false;
                        txt_nt_name.Text = "";
                        txt_nt_extent.Text = "";


                    }
                }
            }
        }

        protected void rbtn_tribal_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "agentp";
                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_tribal.Checked == true)
                    {

                        div_agent_tri_txt.Visible = true;
                        txt_tri_name.Text = "";
                        txt_tri_extent.Text = "";
                        rbtn_agent_tri_impl.ClearSelection();

                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_tribal.Checked == true)
                    {
                        div_agent_tri_txt.Visible = true;


                        rbtn_nt.Checked = false;
                        rbtn_agent_gov.Checked = false;
                        div_agent_nt_txt.Visible = false;
                        div_agent_gov_txt.Visible = false;
                        txt_tri_name.Text = "";
                        txt_tri_extent.Text = "";
                        rbtn_agent_tri_impl.ClearSelection();
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_tribal.Checked == true)
                    {

                        div_agent_tri_txt.Visible = true;
                        txt_tri_name.Text = "";
                        txt_tri_extent.Text = "";

                        rbtn_agent_tri_impl.ClearSelection();
                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_tribal.Checked == true)
                    {
                        div_agent_tri_txt.Visible = true;


                        rbtn_nt.Checked = false;
                        rbtn_agent_gov.Checked = false;
                        div_agent_nt_txt.Visible = false;
                        div_agent_gov_txt.Visible = false;
                        txt_tri_name.Text = "";
                        txt_tri_extent.Text = "";
                        rbtn_agent_tri_impl.ClearSelection();
                    }

                }
            }
        }

        protected void rbtn_agent_gov_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "agentp";
                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_agent_gov.Checked == true)
                    {
                        div_agent_gov_txt.Visible = true;
                        txt_gov_name.Text = "";
                        txt_gov_extent.Text = "";
                        rbtn_agent_gov_impl.ClearSelection();

                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_agent_gov.Checked == true)
                    {
                        div_agent_gov_txt.Visible = true;

                        rbtn_nt.Checked = false;
                        rbtn_tribal.Checked = false;
                        div_agent_nt_txt.Visible = false;
                        div_agent_tri_txt.Visible = false;
                        txt_gov_name.Text = "";
                        txt_gov_extent.Text = "";
                        rbtn_agent_gov_impl.ClearSelection();
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_agent.SelectedValue == "A")
                {
                    if (rbtn_agent_gov.Checked == true)
                    {
                        div_agent_gov_txt.Visible = true;
                        txt_gov_name.Text = "";
                        txt_gov_extent.Text = "";
                        rbtn_agent_gov_impl.ClearSelection();

                    }

                }
                else if (rbtn_agent.SelectedValue == "B")
                {
                    if (rbtn_agent_gov.Checked == true)
                    {
                        div_agent_gov_txt.Visible = true;

                        rbtn_nt.Checked = false;
                        rbtn_tribal.Checked = false;
                        div_agent_nt_txt.Visible = false;
                        div_agent_tri_txt.Visible = false;
                        txt_gov_name.Text = "";
                        txt_gov_extent.Text = "";
                        rbtn_agent_gov_impl.ClearSelection();
                    }

                }
            }
        }

        protected void rbtn_gov_orders_passed_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "govp";
                if (rbtn_gov_orders_passed.SelectedValue == "A" || rbtn_gov_orders_passed.SelectedValue == "B")

                {
                    div_gov_partially.Visible = true;
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;

                    div_gov_nt_txt.Visible = false;
                    div_gov_tri_txt.Visible = false;
                    div_gov_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_gov_orders_passed.SelectedValue == "A" || rbtn_gov_orders_passed.SelectedValue == "B")

                {
                    div_gov_partially.Visible = true;
                    rbtn_gov_nt.Checked = false;
                    rbtn_gov_tri.Checked = false;
                    rbtn_gov_gov.Checked = false;

                    div_gov_nt_txt.Visible = false;
                    div_gov_tri_txt.Visible = false;
                    div_gov_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
        }

        protected void rbtn_gov_nt_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "govp";

                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_nt.Checked == true)
                    {
                        div_gov_nt_txt.Visible = true;
                        txt_gov_nt_name.Text = "";
                        txt_gov_nt_extent.Text = "";

                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_nt.Checked == true)
                    {
                        div_gov_nt_txt.Visible = true;
                        rbtn_gov_tri.Checked = false;
                        rbtn_gov_gov.Checked = false;
                        div_gov_tri_txt.Visible = false;
                        div_gov_gov_txt.Visible = false;
                        txt_gov_nt_name.Text = "";
                        txt_gov_nt_extent.Text = "";

                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_nt.Checked == true)
                    {
                        div_gov_nt_txt.Visible = true;
                        txt_gov_nt_name.Text = "";
                        txt_gov_nt_extent.Text = "";

                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_nt.Checked == true)
                    {
                        div_gov_nt_txt.Visible = true;
                        rbtn_gov_tri.Checked = false;
                        rbtn_gov_gov.Checked = false;
                        div_gov_tri_txt.Visible = false;
                        div_gov_gov_txt.Visible = false;
                        txt_gov_nt_name.Text = "";
                        txt_gov_nt_extent.Text = "";

                    }
                }
            }
        }

        protected void rbtn_gov_tri_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "govp";
                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_tri.Checked == true)
                    {

                        div_gov_tri_txt.Visible = true;
                        txt_gov_tri_name.Text = "";
                        txt_gov_tri_extent.Text = "";
                        rbtn_gov_tri_impl.ClearSelection();

                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_tri.Checked == true)
                    {
                        div_gov_tri_txt.Visible = true;


                        rbtn_gov_nt.Checked = false;
                        rbtn_gov_gov.Checked = false;
                        div_gov_nt_txt.Visible = false;
                        div_gov_gov_txt.Visible = false;
                        txt_gov_tri_name.Text = "";
                        txt_gov_tri_extent.Text = "";
                        rbtn_gov_tri_impl.ClearSelection();
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_tri.Checked == true)
                    {

                        div_gov_tri_txt.Visible = true;
                        txt_gov_tri_name.Text = "";
                        txt_gov_tri_extent.Text = "";
                        rbtn_gov_tri_impl.ClearSelection();

                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_tri.Checked == true)
                    {
                        div_gov_tri_txt.Visible = true;


                        rbtn_gov_nt.Checked = false;
                        rbtn_gov_gov.Checked = false;
                        div_gov_nt_txt.Visible = false;
                        div_gov_gov_txt.Visible = false;
                        txt_gov_tri_name.Text = "";
                        txt_gov_tri_extent.Text = "";
                        rbtn_gov_tri_impl.ClearSelection();
                    }

                }
            }
        }

        protected void rbtn_gov_gov_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "govp";
                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_gov.Checked == true)
                    {
                        div_gov_gov_txt.Visible = true;
                        txt_gov_gov_name.Text = "";
                        txt_gov_gov_extent.Text = "";
                        rbtn_gov_impl.ClearSelection();

                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_gov.Checked == true)
                    {
                        div_gov_gov_txt.Visible = true;

                        rbtn_gov_nt.Checked = false;
                        rbtn_gov_tri.Checked = false;
                        div_gov_nt_txt.Visible = false;
                        div_gov_tri_txt.Visible = false;
                        txt_gov_gov_name.Text = "";
                        txt_gov_gov_extent.Text = "";
                        rbtn_gov_impl.ClearSelection();
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_gov_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_gov_gov.Checked == true)
                    {
                        div_gov_gov_txt.Visible = true;

                        txt_gov_gov_name.Text = "";
                        txt_gov_gov_extent.Text = "";
                        rbtn_gov_impl.ClearSelection();
                    }

                }
                else if (rbtn_gov_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_gov_gov.Checked == true)
                    {
                        div_gov_gov_txt.Visible = true;

                        rbtn_gov_nt.Checked = false;
                        rbtn_gov_tri.Checked = false;
                        div_gov_nt_txt.Visible = false;
                        div_gov_tri_txt.Visible = false;
                        txt_gov_gov_name.Text = "";
                        txt_gov_gov_extent.Text = "";
                        rbtn_gov_impl.ClearSelection();
                    }

                }
            }

        }

        protected void rbtn_hc_orders_passed_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")

            {
                Session["event_controle"] = "hcp";
                if (rbtn_hc_orders_passed.SelectedValue == "A" || rbtn_hc_orders_passed.SelectedValue == "B")

                {
                    div_high_court_partially.Visible = true;
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;
                    div_hc_tri.Visible = true;
                    div_hc_nt_txt.Visible = false;
                    div_hc_tri_txt.Visible = false;
                    div_hc_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
            else
            {

                Session["event_controle"] = "chk";
                if (rbtn_hc_orders_passed.SelectedValue == "A" || rbtn_hc_orders_passed.SelectedValue == "B")

                {
                    div_high_court_partially.Visible = true;
                    rbtn_hc_nt.Checked = false;
                    rbtn_hc_tri.Checked = false;
                    rbtn_hc_gov.Checked = false;

                    div_hc_nt_txt.Visible = false;
                    div_hc_tri_txt.Visible = false;
                    div_hc_gov_txt.Visible = false;
                    // rbtn_add_orders_passed.Focus();


                }
            }
        }

        protected void rbtn_hc_nt_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "hcp";

                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_nt.Checked == true)
                    {
                        div_hc_nt_txt.Visible = true;
                        txt_hc_nt_name.Text = "";
                        txt_hc_nt_extent.Text = "";
                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_nt.Checked == true)
                    {
                        div_hc_nt_txt.Visible = true;
                        rbtn_hc_tri.Checked = false;
                        rbtn_hc_gov.Checked = false;
                        div_hc_tri_txt.Visible = false;
                        div_hc_gov_txt.Visible = false;
                        txt_hc_nt_name.Text = "";
                        txt_hc_nt_extent.Text = "";

                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_nt.Checked == true)
                    {
                        div_hc_nt_txt.Visible = true;
                        txt_hc_nt_name.Text = "";
                        txt_hc_nt_extent.Text = "";
                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_nt.Checked == true)
                    {
                        div_hc_nt_txt.Visible = true;
                        rbtn_hc_tri.Checked = false;
                        rbtn_hc_gov.Checked = false;
                        div_hc_tri_txt.Visible = false;
                        div_hc_gov_txt.Visible = false;
                        txt_hc_nt_name.Text = "";
                        txt_hc_nt_extent.Text = "";
                    }
                }
            }
        }

        protected void rbtn_hc_tri_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "hcp";
                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_tri.Checked == true)
                    {

                        div_hc_tri_txt.Visible = true;
                        txt_hc_tri_name.Text = "";
                        txt_hc_tri_extent.Text = "";
                        rbtn_hc_tri_orders_impl.ClearSelection();

                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_tri.Checked == true)
                    {
                        div_hc_tri_txt.Visible = true;


                        rbtn_hc_nt.Checked = false;
                        rbtn_hc_gov.Checked = false;
                        div_hc_nt_txt.Visible = false;
                        div_hc_gov_txt.Visible = false;
                        txt_hc_tri_name.Text = "";
                        txt_hc_tri_extent.Text = "";
                        rbtn_hc_tri_orders_impl.ClearSelection();

                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_tri.Checked == true)
                    {

                        div_hc_tri_txt.Visible = true;
                        txt_hc_tri_name.Text = "";
                        txt_hc_tri_extent.Text = "";
                        rbtn_hc_tri_orders_impl.ClearSelection();

                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_tri.Checked == true)
                    {
                        div_hc_tri_txt.Visible = true;


                        rbtn_hc_nt.Checked = false;
                        rbtn_hc_gov.Checked = false;
                        div_hc_nt_txt.Visible = false;
                        div_hc_gov_txt.Visible = false;
                        txt_hc_tri_name.Text = "";
                        txt_hc_tri_extent.Text = "";
                        rbtn_hc_tri_orders_impl.ClearSelection();

                    }
                }
            }
        }

        protected void rbtn_hc_gov_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "View_Ltr.aspx")
            {
                Session["event_controle"] = "hcp";

                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_gov.Checked == true)
                    {
                        div_hc_gov_txt.Visible = true;
                        txt_hc_gov_name.Text = "";
                        txt_hc_gov_extent.Text = "";
                        rbtn_hc_orders_impl.ClearSelection();

                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_gov.Checked == true)
                    {
                        div_hc_gov_txt.Visible = true;

                        rbtn_hc_nt.Checked = false;
                        rbtn_hc_tri.Checked = false;
                        div_hc_nt_txt.Visible = false;
                        div_hc_tri_txt.Visible = false;
                        txt_hc_gov_name.Text = "";
                        txt_hc_gov_extent.Text = "";
                        rbtn_hc_orders_impl.ClearSelection();
                    }

                }
            }
            else
            {
                Session["event_controle"] = "chk";

                if (rbtn_hc_orders_passed.SelectedValue == "A")
                {
                    if (rbtn_hc_gov.Checked == true)
                    {
                        div_hc_gov_txt.Visible = true;
                        txt_hc_gov_name.Text = "";
                        txt_hc_gov_extent.Text = "";
                        rbtn_hc_orders_impl.ClearSelection();

                    }

                }
                else if (rbtn_hc_orders_passed.SelectedValue == "B")
                {
                    if (rbtn_hc_gov.Checked == true)
                    {
                        div_hc_gov_txt.Visible = true;

                        rbtn_hc_nt.Checked = false;
                        rbtn_hc_tri.Checked = false;
                        div_hc_nt_txt.Visible = false;
                        div_hc_tri_txt.Visible = false;
                        txt_hc_gov_name.Text = "";
                        txt_hc_gov_extent.Text = "";
                        rbtn_hc_orders_impl.ClearSelection();
                    }

                }
            }
        }
        //dropdowns
        private void BindItda()
        {
            try

            {
                System.Threading.Thread.Sleep(5000);

                DataTable dtItda = Landsettlementpattas.GetMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_itda.DataSource = dtItda;
                    ddl_itda.DataTextField = "ITDA_NAME";
                    ddl_itda.DataValueField = "ITDA_NAME";
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

        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT";
                ddl_district.DataValueField = "DISTRICT";
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
                ddl_mandal.DataValueField = "MANDAL_NAME";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_village.DataValueField = "VILLAGE_NAME";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHab(DataTable dthab)
        {
            try
            {
                ddl_hab.DataSource = dthab;
                ddl_hab.DataTextField = "HABITATION";
                ddl_hab.DataValueField = "HABITATION";
                ddl_hab.DataBind();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_itda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                ddl_mandal.Items.Clear();
                ddl_village.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

               
                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    DataTable dtdistrict = Landsettlementpattas.GetMasters((string)(Session["username"]), "District", ddl_itda.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetMasters((string)(Session["username"]), "Mandal", ddl_itda.SelectedItem.Text, ddl_district.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
                           
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

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                System.Threading.Thread.Sleep(5000);
                ddl_mandal.Items.Clear();
                ddl_village.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_district.SelectedItem.Text != "Select")
                {

                    DataTable dtMandal = Landsettlementpattas.GetMasters((string)(Session["username"]), "Mandal", ddl_itda.SelectedItem.Text, ddl_district.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);


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

        protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Clear();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetMasters((string)(Session["username"]), "Village", ddl_itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);


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




                }
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

                //System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                string IPAddress = (string)(Session["IPAddress"]);
                land_transfer_regulation land_transfer_obj = new land_transfer_regulation();
                // int Id = int.Parse((string)(Session["updateId"]));
                //string Id = ((string)(Session["updateId"]));
                //Block1
                //int Id = 0;
                //land_transfer_obj.Id = Id;
                string ltrid = (string)(Session["updateId"]);
                land_transfer_obj.ltrid = ltrid;
                land_transfer_obj.Itda = ddl_itda.SelectedItem.Text;
                land_transfer_obj.District = ddl_district.SelectedItem.Text;
                land_transfer_obj.districtname = ddl_district.SelectedValue;
                land_transfer_obj.mandal = ddl_mandal.SelectedItem.Text;
                land_transfer_obj.village = ddl_village.SelectedItem.Text;
                land_transfer_obj.hab = ddl_hab.SelectedItem.Text;
                land_transfer_obj.rsno = txt_rsno.Text;
                land_transfer_obj.extent_ac_cts = txt_extent.Text;
                land_transfer_obj.ltrp_no = txt_ltrp.Text;
                land_transfer_obj.ltrp_date = dtp_input2.Text; ;
                land_transfer_obj.OLDltrp_date = txt_OldDateoforder.Text;
                if (ddl_sdc_status.SelectedItem.Text != "SELECT")
                {
                    land_transfer_obj.sdc_casestatus = ddl_sdc_status.SelectedItem.Text;
                }
                else
                {
                    land_transfer_obj.sdc_casestatus = "";
                }

                if (ddl_sdc.SelectedItem.Text != "Select")
                {
                    land_transfer_obj.sdc_level = ddl_sdc.SelectedItem.Text;
                }
                else
                {
                    land_transfer_obj.sdc_level = "";
                }

                if (ddl_sdc.SelectedValue == "ALLOWED" || ddl_sdc.SelectedItem.Text == "ALLOWED")
                {
                    if (rbtn_sdc_orders_passed.SelectedIndex != -1)
                    {
                        if (rbtn_sdc_orders_passed.SelectedItem.Text == "Partially" || rbtn_sdc_orders_passed.SelectedItem.Text == "Fully")
                        {
                            land_transfer_obj.sdc_orders_passed = rbtn_sdc_orders_passed.SelectedItem.Text;
                        }
                    }

                }
                else if (ddl_sdc.SelectedValue == "DISALLOWED" || ddl_sdc.SelectedItem.Text == "DISALLOWED")
                {
                    if (rbtn_sdc_disallowed.SelectedIndex != -1)
                    {
                        if (rbtn_sdc_disallowed.SelectedItem.Text == "On Full trial" || rbtn_sdc_disallowed.SelectedItem.Text == "Resjudicated/Dropped")
                        {
                            land_transfer_obj.sdc_orders_passed = rbtn_sdc_disallowed.SelectedItem.Text;
                        }
                    }
                }
                if (ddl_sdc.SelectedValue == "ALLOWED" || ddl_sdc.SelectedItem.Text == "ALLOWED")
                {
                    if (rbtn_sdc_orders_passed.SelectedIndex != -1)
                    {
                        if (rbtn_sdc_orders_passed.SelectedItem.Text == "Partially")
                        {

                            if (rbtn_sdc_nt.Checked == true)
                            {
                                land_transfer_obj.sdc_nt_name = txt_sdc_nt_name.Text;
                                //land_transfer_obj.sdc_nt_extent = (float)Convert.ToDouble(txt_sdc_nt_extent.Text);
                                land_transfer_obj.sdc_nt_extent = txt_sdc_nt_extent.Text;
                            }
                            if (rbtn_sdc_tri.Checked == true)
                            {
                                land_transfer_obj.sdc_tri_name = txt_sdc_tri_name.Text;
                                //land_transfer_obj.sdc_tri_extent = (float)Convert.ToDouble(txt_sdc_tri_extent.Text);
                                land_transfer_obj.sdc_tri_extent = txt_sdc_tri_extent.Text;
                                if (rbtn_sdc_tri_impl.SelectedIndex != -1)
                                {
                                    land_transfer_obj.sdc_tri_impl = rbtn_sdc_tri_impl.SelectedItem.Text;
                                }
                                land_transfer_obj.Details_T_Ac_cts = txt_t_ac_cts.Text;
                                // land_transfer_obj.Details_T_Hec_A = txt_t_hec.Text;
                            }
                            if (rbtn_sdc_gov.Checked == true)
                            {
                                land_transfer_obj.sdc_gov_name = txt_sdc_gov_name.Text;

                                //land_transfer_obj.sdc_gov_extent = (float)Convert.ToDouble(txt_gov_extent.Text);
                                land_transfer_obj.sdc_gov_extent = txt_gov_extent.Text;
                                if (rbtn_sdc_gov_impl.SelectedIndex != -1)
                                {
                                    land_transfer_obj.sdc_gov_impl = rbtn_sdc_gov_impl.SelectedItem.Text;
                                }
                                land_transfer_obj.Details_G_Ac_cts = txt_g_ac_cts.Text;
                                //land_transfer_obj.Details_G_Hec_A = txt_g_hec.Text;
                            }
                        }
                        else if (rbtn_sdc_orders_passed.SelectedItem.Text == "Fully")
                        {
                            //land_transfer_obj.sdc_orders_passed = rbtn_sdc_orders_passed.SelectedItem.Text;
                            if (rbtn_sdc_nt.Checked == true)
                            {
                                land_transfer_obj.sdc_nt_name = txt_sdc_nt_name.Text;
                                //land_transfer_obj.sdc_nt_extent = (float)Convert.ToDouble(txt_sdc_nt_extent.Text);
                                land_transfer_obj.sdc_nt_extent = txt_sdc_nt_extent.Text;

                            }
                            else if (rbtn_sdc_tri.Checked == true)
                            {
                                land_transfer_obj.sdc_tri_name = txt_sdc_tri_name.Text;
                                // land_transfer_obj.sdc_tri_extent = (float)Convert.ToDouble(txt_sdc_tri_extent.Text);
                                land_transfer_obj.sdc_tri_extent = txt_sdc_tri_extent.Text;
                                if (rbtn_sdc_tri_impl.SelectedIndex != -1)
                                {
                                    land_transfer_obj.sdc_tri_impl = rbtn_sdc_tri_impl.SelectedItem.Text;
                                }
                                land_transfer_obj.Details_T_Ac_cts = txt_t_ac_cts.Text;
                                //  land_transfer_obj.Details_T_Hec_A = txt_t_hec.Text;

                            }
                            else if (rbtn_sdc_gov.Checked == true)
                            {
                                land_transfer_obj.sdc_gov_name = txt_sdc_gov_name.Text;
                                //land_transfer_obj.sdc_gov_extent = (float)Convert.ToDouble(txt_sdc_gov_extent.Text);
                                land_transfer_obj.sdc_gov_extent = txt_sdc_gov_extent.Text;
                                if (rbtn_sdc_gov_impl.SelectedIndex != -1)
                                {
                                    land_transfer_obj.sdc_gov_impl = rbtn_sdc_gov_impl.SelectedItem.Text;
                                }
                                land_transfer_obj.Details_G_Ac_cts = txt_g_ac_cts.Text;
                                // land_transfer_obj.Details_G_Hec_A = txt_g_hec.Text;
                            }
                        }
                    }
                }

                land_transfer_obj.petitioner = txt_petitioner.Text;
                land_transfer_obj.respondent = txt_respondent.Text;

                //Block2 (at add)
                if (chk_add_agent.Checked == true)
                {
                    land_transfer_obj.cma_no = txt_cma_no.Text;
                    land_transfer_obj.cmadate = txt_add_dt_orders.Text;
                    land_transfer_obj.add_datedisposal = txt_add_disposal.Text;
                    if (ddl_add_status.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.add_casestatus = ddl_add_status.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.add_datedisposal = "";
                    }
                    if (ddl_add.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.add_level = ddl_add.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.add_level = "";
                    }
                    if (ddl_add.SelectedValue == "ALLOWED" || ddl_add.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_add_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_add_orders_passed.SelectedItem.Text == "Partially" || rbtn_add_orders_passed.SelectedItem.Text == "Fully")

                            {
                                land_transfer_obj.add_orders_passed = rbtn_add_orders_passed.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Additional agent orders passed in whose favour !')", true);
                            }
                        }
                    }
                    //else if (ddl_add.SelectedValue == "B")
                    //{
                    //    land_transfer_obj.add_orders_passed = rbtn_add_disallowed.SelectedItem.Text;
                    //}

                    else if (ddl_add.SelectedValue == "REMANDED" || ddl_add.SelectedItem.Text == "REMANDED")
                    {
                        if (rbtn_add_remanded.SelectedIndex != -1)
                        {
                            if (rbtn_add_remanded.SelectedItem.Text == "SDC")
                            {
                                land_transfer_obj.add_orders_passed = rbtn_add_remanded.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Remanded Court !')", true);
                            }
                        }
                    }
                    if (ddl_add.SelectedValue == "ALLOWED" || ddl_add.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_add_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_add_orders_passed.SelectedItem.Text == "Partially")
                            {

                                if (rbtn_add_nt.Checked == true)
                                {
                                    land_transfer_obj.add_nt_name = txt_add_nt_name.Text;
                                    // land_transfer_obj.add_nt_extent = (float)Convert.ToDouble(txt_add_nt_extent.Text);
                                    land_transfer_obj.add_nt_extent = txt_add_nt_extent.Text;
                                }
                                if (rbtn_add_tri.Checked == true)
                                {
                                    land_transfer_obj.add_tri_name = txt_add_tri_name.Text;
                                    // land_transfer_obj.add_tri_extent = (float)Convert.ToDouble(txt_add_tri_extent.Text);
                                    land_transfer_obj.add_tri_extent = txt_add_tri_extent.Text;
                                    if (rbtn_add_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.add_tri_impl = rbtn_add_tri_impl.SelectedItem.Text;
                                    }
                                }
                                if (rbtn_add_gov.Checked == true)
                                {
                                    land_transfer_obj.add_gov_name = txt_add_gov_name.Text;

                                    //land_transfer_obj.add_gov_extent = (float)Convert.ToDouble(txt_add_gov_extent.Text);
                                    land_transfer_obj.add_gov_extent = txt_add_gov_extent.Text;
                                    if (rbtn_add_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.add_gov_impl = rbtn_add_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                            else if (rbtn_add_orders_passed.SelectedItem.Text == "Fully")
                            {
                                //land_transfer_obj.add_orders_passed = rbtn_add_orders_passed.SelectedItem.Text;
                                if (rbtn_add_nt.Checked == true)
                                {
                                    land_transfer_obj.add_nt_name = txt_add_nt_name.Text;
                                    //land_transfer_obj.add_nt_extent = (float)Convert.ToDouble(txt_add_nt_extent.Text);
                                    land_transfer_obj.add_nt_extent = txt_add_nt_extent.Text;
                                }

                                else if (rbtn_add_tri.Checked == true)
                                {
                                    land_transfer_obj.add_tri_name = txt_add_tri_name.Text;
                                    // land_transfer_obj.add_tri_extent = (float)Convert.ToDouble(txt_add_tri_extent.Text);
                                    land_transfer_obj.add_tri_extent = txt_add_tri_extent.Text;
                                    if (rbtn_add_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.add_tri_impl = rbtn_add_tri_impl.SelectedItem.Text;
                                    }
                                }
                                else if (rbtn_add_gov.Checked == true)
                                {
                                    land_transfer_obj.add_gov_name = txt_add_gov_name.Text;
                                    //land_transfer_obj.add_gov_extent = (float)Convert.ToDouble(txt_add_gov_extent.Text);
                                    land_transfer_obj.add_gov_extent = txt_add_gov_extent.Text;
                                    if (rbtn_add_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.add_gov_impl = rbtn_add_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                        }
                    }
                    land_transfer_obj.add_remarks = txt_add_remarks.Text;
                }

                //agent
                if (chk_agent.Checked == true)
                {
                    land_transfer_obj.appeal_no = txt_appeal_no.Text;
                    land_transfer_obj.appealdate = txt_agent_dt_orders.Text;
                    land_transfer_obj.appeal_disposal = txt_agent_disposal.Text;

                    if (ddl_agent_status.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.appeal_casestatus = ddl_agent_status.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.appeal_casestatus = "";
                    }
                    if (ddl_agent.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.agent_level = ddl_agent.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.agent_level = "";
                    }
                    if (ddl_agent.SelectedValue == "ALLOWED" || ddl_agent.SelectedItem.Text == "ALLOWED")

                    {
                        if (rbtn_agent.SelectedIndex != -1)
                        {
                            if (rbtn_agent.SelectedItem.Text == "Partially" || rbtn_agent.SelectedItem.Text == "Fully")
                            {
                                land_transfer_obj.agent_orders_passed = rbtn_agent.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Agent to government orders passed in whose favour !')", true);
                            }
                        }
                    }
                    //else if (ddl_agent.SelectedValue == "B")
                    //{
                    //    land_transfer_obj.agent_orders_passed = rbtn_agent_disallowed.SelectedItem.Text;
                    //}
                    else if (ddl_agent.SelectedValue == "REMANDED" || ddl_agent.SelectedItem.Text == "REMANDED")
                    {
                        if (rbtn_agent_remanded.SelectedIndex != -1)
                        {
                            if (rbtn_agent_remanded.SelectedItem.Text == "SDC")
                            {
                                land_transfer_obj.agent_orders_passed = rbtn_agent_remanded.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Remanded Court!')", true);
                            }
                        }
                    }
                    if (ddl_agent.SelectedValue == "ALLOWED" || ddl_agent.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_agent.SelectedIndex != -1)
                        {
                            if (rbtn_agent.SelectedItem.Text == "Partially")
                            {
                                //land_transfer_obj.agent_orders_passed = rbtn_agent.SelectedItem.Text;
                                if (rbtn_nt.Checked == true)
                                {
                                    land_transfer_obj.agent_nt_name = txt_nt_name.Text;
                                    //land_transfer_obj.agent_nt_extent = (float)Convert.ToDouble(txt_nt_extent.Text);
                                    land_transfer_obj.agent_nt_extent = txt_nt_extent.Text;

                                }
                                if (rbtn_tribal.Checked == true)
                                {
                                    land_transfer_obj.agent_tri_name = txt_tri_name.Text;
                                    //land_transfer_obj.agent_tri_extent = (float)Convert.ToDouble(txt_tri_extent.Text);
                                    land_transfer_obj.agent_tri_extent = txt_tri_extent.Text;
                                    if (rbtn_agent_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.agent_tri_impl = rbtn_agent_tri_impl.SelectedItem.Text;
                                    }
                                }
                                if (rbtn_agent_gov.Checked == true)
                                {
                                    land_transfer_obj.agent_gov_name = txt_gov_name.Text;
                                    //land_transfer_obj.agent_gov_extent = (float)Convert.ToDouble(txt_gov_extent.Text);
                                    land_transfer_obj.agent_gov_extent = txt_gov_extent.Text;
                                    if (rbtn_agent_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.agent_gov_impl = rbtn_agent_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                            else if (rbtn_agent.SelectedItem.Text == "Fully")
                            {
                                // land_transfer_obj.agent_orders_passed = rbtn_agent.SelectedItem.Text;
                                if (rbtn_nt.Checked == true)
                                {
                                    land_transfer_obj.agent_nt_name = txt_nt_name.Text;
                                    // land_transfer_obj.agent_nt_extent = (float)Convert.ToDouble(txt_nt_extent.Text);
                                    land_transfer_obj.agent_nt_extent = txt_nt_extent.Text;
                                }

                                else if (rbtn_tribal.Checked == true)
                                {
                                    land_transfer_obj.agent_tri_name = txt_tri_name.Text;
                                    // land_transfer_obj.agent_tri_extent = (float)Convert.ToDouble(txt_tri_extent.Text);
                                    land_transfer_obj.agent_tri_extent = txt_tri_extent.Text;
                                    if (rbtn_agent_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.agent_tri_impl = rbtn_agent_tri_impl.SelectedItem.Text;
                                    }
                                }
                                else if (rbtn_agent_gov.Checked == true)
                                {
                                    land_transfer_obj.agent_gov_name = txt_gov_name.Text;
                                    // land_transfer_obj.agent_gov_extent = (float)Convert.ToDouble(txt_gov_extent.Text);
                                    land_transfer_obj.agent_gov_extent = txt_gov_extent.Text;
                                    if (rbtn_agent_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.agent_gov_impl = rbtn_agent_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                        }
                    }
                    land_transfer_obj.agent_remarks = txt_agent_remarks.Text;
                }
                if (chk_government.Checked == true)
                {
                    land_transfer_obj.rpno = txt_rpno.Text;
                    land_transfer_obj.rpdate = txt_gov_dt_orders.Text;
                    land_transfer_obj.gov_disposal = txt_gov_disposal.Text;
                    if (ddl_gov_status.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.gov_casestatus = ddl_gov_status.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.gov_casestatus = "";
                    }
                    if (ddl_gov.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.gov_level = ddl_gov.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.gov_level = "";
                    }
                    if (ddl_gov.SelectedValue == "ALLOWED" || ddl_gov.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_gov_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_gov_orders_passed.SelectedItem.Text == "Partially" || rbtn_gov_orders_passed.SelectedItem.Text == "Fully")
                            {
                                land_transfer_obj.govt_orders_passed = rbtn_gov_orders_passed.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Government orders passed in whose favour!')", true);
                            }
                        }
                    }
                    //else if (ddl_gov.SelectedValue == "B")
                    //{
                    //    land_transfer_obj.govt_orders_passed = rbtn_gov_disallowed.SelectedItem.Text;
                    //}
                    else if (ddl_gov.SelectedValue == "REMANDED" || ddl_gov.SelectedItem.Text == "REMANDED")
                    {
                        if (rbtn_gov_remanded.SelectedIndex != -1)
                        {
                            if (rbtn_gov_remanded.SelectedItem.Text == "Additional Agent" || rbtn_gov_remanded.SelectedItem.Text == "Agent to Government" || rbtn_gov_remanded.SelectedItem.Text == "SDC")
                            {
                                land_transfer_obj.govt_orders_passed = rbtn_gov_remanded.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Remanded Court !')", true);
                            }
                        }
                    }
                    if (ddl_gov.SelectedValue == "ALLOWED" || ddl_gov.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_gov_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_gov_orders_passed.SelectedItem.Text == "Partially")
                            {
                                // land_transfer_obj.govt_orders_passed = rbtn_gov_orders_passed.SelectedItem.Text;
                                if (rbtn_gov_nt.Checked == true)
                                {
                                    land_transfer_obj.gov_nt_name = txt_gov_nt_name.Text;
                                    //land_transfer_obj.gov_nt_extent = (float)Convert.ToDouble(txt_gov_nt_extent.Text);
                                    land_transfer_obj.gov_nt_extent = txt_gov_nt_extent.Text;
                                }
                                if (rbtn_gov_tri.Checked == true)
                                {
                                    land_transfer_obj.gov_tri_name = txt_gov_tri_name.Text;
                                    // land_transfer_obj.gov_tri_extent = (float)Convert.ToDouble(txt_gov_tri_extent.Text);
                                    land_transfer_obj.gov_tri_extent = txt_gov_tri_extent.Text;
                                    if (rbtn_gov_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.gov_tri_impl = rbtn_gov_tri_impl.SelectedItem.Text;
                                    }
                                }
                                if (rbtn_gov_gov.Checked == true)
                                {
                                    land_transfer_obj.gov_gov_name = txt_gov_gov_name.Text;
                                    //land_transfer_obj.gov_gov_extent = (float)Convert.ToDouble(txt_gov_gov_extent.Text);
                                    land_transfer_obj.gov_gov_extent = txt_gov_gov_extent.Text;
                                    if (rbtn_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.gov_gov_impl = rbtn_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                            else if (rbtn_gov_orders_passed.SelectedItem.Text == "Fully")
                            {
                                //land_transfer_obj.govt_orders_passed = rbtn_gov_orders_passed.SelectedItem.Text;
                                if (rbtn_gov_nt.Checked == true)
                                {
                                    land_transfer_obj.gov_nt_name = txt_gov_nt_name.Text;
                                    //land_transfer_obj.gov_nt_extent = (float)Convert.ToDouble(txt_gov_nt_extent.Text);
                                    land_transfer_obj.gov_nt_extent = txt_gov_nt_extent.Text;
                                }
                                else if (rbtn_gov_tri.Checked == true)
                                {
                                    land_transfer_obj.gov_tri_name = txt_gov_tri_name.Text;
                                    // land_transfer_obj.gov_tri_extent = (float)Convert.ToDouble(txt_gov_tri_extent.Text);
                                    land_transfer_obj.gov_tri_extent = txt_gov_tri_extent.Text;
                                    if (rbtn_gov_tri_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.gov_tri_impl = rbtn_gov_tri_impl.SelectedItem.Text;
                                    }
                                }
                                else if (rbtn_gov_gov.Checked == true)
                                {
                                    land_transfer_obj.gov_gov_name = txt_gov_gov_name.Text;
                                    //land_transfer_obj.gov_gov_extent = (float)Convert.ToDouble(txt_gov_gov_extent.Text);
                                    land_transfer_obj.gov_gov_extent = txt_gov_gov_extent.Text;
                                    if (rbtn_gov_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.gov_gov_impl = rbtn_gov_impl.SelectedItem.Text;
                                    }
                                }
                            }
                        }
                    }
                    land_transfer_obj.gov_remarks = txt_gov_remarks.Text;
                }
                if (chk_high_court.Checked == true)
                {
                    land_transfer_obj.wpno = txt_wpno.Text;
                    land_transfer_obj.wpdate = txt_hc_dt_orders.Text;
                    land_transfer_obj.hc_disposal = txt_hc_disposal.Text;
                    land_transfer_obj.hc_wpmpno = txt_wp_mpno.Text;
                    if (ddl_wpno_status.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.hc_wpmpno_status = ddl_wpno_status.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.hc_wpmpno_status = "";
                    }
                    if (ddl_hc_status.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.hc_casestatus = ddl_hc_status.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.hc_casestatus = "";
                    }
                    if (ddl_hc.SelectedItem.Text != "SELECT")
                    {
                        land_transfer_obj.hc_level = ddl_hc.SelectedItem.Text;
                    }
                    else
                    {
                        land_transfer_obj.hc_level = "";
                    }
                    if (ddl_hc.SelectedValue == "ALLOWED" || ddl_hc.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_hc_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_hc_orders_passed.SelectedItem.Text == "Partially" || rbtn_hc_orders_passed.SelectedItem.Text == "Fully")
                            {
                                land_transfer_obj.hc_orders_passed = rbtn_hc_orders_passed.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Highcourt orders passed in whose favour !')", true);
                            }
                        }
                    }
                    //else if (ddl_hc.SelectedValue == "B")
                    //{
                    //    land_transfer_obj.hc_orders_passed = rbtn_hc_disallowed.SelectedItem.Text;
                    //}
                    else if (ddl_hc.SelectedValue == "REMANDED" || ddl_hc.SelectedItem.Text == "REMANDED")
                    {
                        if (rbtn_hc_remanded.SelectedIndex != -1)
                        {
                            if (rbtn_hc_remanded.SelectedItem.Text == "Additional Agent" || rbtn_hc_remanded.SelectedItem.Text == "Agent to Government" || rbtn_hc_remanded.SelectedItem.Text == "Government" || rbtn_hc_remanded.SelectedItem.Text == "SDC")
                            {
                                land_transfer_obj.hc_orders_passed = rbtn_hc_remanded.SelectedItem.Text;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Remanded Court!')", true);
                            }
                        }
                    }
                    if (ddl_hc.SelectedValue == "ALLOWED" || ddl_hc.SelectedItem.Text == "ALLOWED")
                    {
                        if (rbtn_hc_orders_passed.SelectedIndex != -1)
                        {
                            if (rbtn_hc_orders_passed.SelectedItem.Text == "Partially")
                            {
                                //land_transfer_obj.hc_orders_passed= rbtn_hc_orders_passed.SelectedItem.Text;
                                if (rbtn_hc_nt.Checked == true)
                                {
                                    land_transfer_obj.hc_nt_name = txt_hc_nt_name.Text;
                                    //land_transfer_obj.hc_nt_extent = (float)Convert.ToDouble(txt_hc_nt_extent.Text);
                                    land_transfer_obj.hc_nt_extent = txt_hc_nt_extent.Text;
                                }
                                if (rbtn_hc_tri.Checked == true)
                                {
                                    land_transfer_obj.hc_tri_name = txt_hc_tri_name.Text;
                                    // land_transfer_obj.hc_tri_extent = (float)Convert.ToDouble(txt_hc_tri_extent.Text);
                                    land_transfer_obj.hc_tri_extent = txt_hc_tri_extent.Text;
                                    if (rbtn_hc_tri_orders_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.hc_tri_impl = rbtn_hc_tri_orders_impl.SelectedItem.Text;
                                    }
                                }
                                if (rbtn_hc_gov.Checked == true)
                                {
                                    land_transfer_obj.hc_gov_name = txt_hc_gov_name.Text;
                                    //land_transfer_obj.hc_gov_extent = (float)Convert.ToDouble(txt_hc_gov_extent.Text);
                                    land_transfer_obj.hc_gov_extent = txt_hc_gov_extent.Text;
                                    if (rbtn_hc_orders_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.hc_gov_impl = rbtn_hc_orders_impl.SelectedItem.Text;
                                    }
                                }
                            }
                            else if (rbtn_hc_orders_passed.SelectedItem.Text == "Fully")
                            {
                                // land_transfer_obj.hc_orders_passed = rbtn_hc_orders_passed.SelectedItem.Text;
                                if (rbtn_hc_nt.Checked == true)
                                {
                                    land_transfer_obj.hc_nt_name = txt_hc_nt_name.Text;
                                    // land_transfer_obj.hc_nt_extent = (float)Convert.ToDouble(txt_hc_nt_extent.Text);
                                    land_transfer_obj.hc_nt_extent = txt_hc_nt_extent.Text;
                                }
                                else if (rbtn_hc_tri.Checked == true)
                                {
                                    land_transfer_obj.hc_tri_name = txt_hc_tri_name.Text;
                                    // land_transfer_obj.hc_tri_extent = (float)Convert.ToDouble(txt_hc_tri_extent.Text);
                                    land_transfer_obj.hc_tri_extent = txt_hc_tri_extent.Text;
                                    if (rbtn_hc_tri_orders_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.hc_tri_impl = rbtn_hc_tri_orders_impl.SelectedItem.Text;
                                    }
                                }
                                else if (rbtn_hc_gov.Checked == true)
                                {
                                    land_transfer_obj.hc_gov_name = txt_hc_gov_name.Text;
                                    //land_transfer_obj.hc_gov_extent = (float)Convert.ToDouble(txt_hc_gov_extent.Text);
                                    land_transfer_obj.hc_gov_extent = txt_hc_gov_extent.Text;
                                    if (rbtn_hc_orders_impl.SelectedIndex != -1)
                                    {
                                        land_transfer_obj.hc_gov_impl = rbtn_hc_orders_impl.SelectedItem.Text;
                                    }
                                }
                            }
                        }
                    }
                    land_transfer_obj.hc_remarks = txt_hc_remarks.Text;
                }
                land_transfer_obj.land_already = txt_land_purpose.Text;
                land_transfer_obj.remarks = txt_remarks.Text;
                land_transfer_obj.Ipaddress = (string)(Session["IPAddress"]);
                land_transfer_obj.UserName = (string)(Session["username"]);

                if (chk_add_agent.Checked == true)
                {
                    if (string.IsNullOrEmpty(land_transfer_obj.cma_no))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter CMA NO/SRA !')", true);
                    }
                }

                if (chk_agent.Checked == true)
                {
                    if (string.IsNullOrEmpty(land_transfer_obj.appeal_no))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Appeal No. !')", true);
                    }
                }

                if (chk_government.Checked == true)
                {
                    if (string.IsNullOrEmpty(land_transfer_obj.rpno))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter R.P.No !')", true);
                    }
                }

                if (chk_high_court.Checked == true)
                {
                    if (string.IsNullOrEmpty(land_transfer_obj.wpno))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter W.P.No !')", true);
                    }
                }



                if (!string.IsNullOrEmpty(land_transfer_obj.UserName))
                {
                    try
                    {
                        DataTable DT = ProjectRofrBAL.GetMasterDetails.land_transfer_regulation1(land_transfer_obj);
                        if (chk_add_agent.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(land_transfer_obj.cma_no))
                            {
                                DataTable DTadd = ProjectRofrBAL.GetMasterDetails.LTR_Add(land_transfer_obj);
                            }
                        }
                        if (chk_agent.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(land_transfer_obj.appeal_no))
                            {
                                DataTable DTagent = ProjectRofrBAL.GetMasterDetails.LTR_Agent(land_transfer_obj);
                            }
                        }
                        if (chk_government.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(land_transfer_obj.rpno))
                            {
                                DataTable DTgov = ProjectRofrBAL.GetMasterDetails.LTR_Gov(land_transfer_obj);
                            }
                        }
                        if (chk_high_court.Checked == true)
                        {
                            if (!string.IsNullOrEmpty(land_transfer_obj.wpno))
                            {
                                DataTable DThc = ProjectRofrBAL.GetMasterDetails.LTR_Highcourt(land_transfer_obj);
                            }
                        }
                        if (land_transfer_obj.ltrid == "0")
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Land Transfer regulation registered successfully !Please save Beneficiary ID for future purpose and Beneficiary ID is:  " + DT.Rows[0]["LTRID"].ToString() + "')", true);
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Land Transfer regulation registered successfully')", true);
                            Session["updateId"] = DT.Rows[0]["LTRID"].ToString();
                            btn_submit.Visible = false;
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Land Transfer regulation updated successfully !')", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Land Transfer regulation updated successfully')", true);
                            Session["updateId"] = DT.Rows[0]["LTRID"].ToString();
                        }

                        if (DT.Rows.Count > 0)
                        {
                            BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
                            DataTable dtUploadFiles = new DataTable();

                            dtUploadFiles.Columns.Add("Option1");
                            dtUploadFiles.Columns.Add("Option2");
                            dtUploadFiles.Columns.Add("Option3");
                            dtUploadFiles.Columns.Add("Option4");
                            dtUploadFiles.Columns.Add("Option5");
                            dtUploadFiles.Columns.Add("Option6");
                            dtUploadFiles.Columns.Add("Option7");
                            DataTable sdc = new DataTable();
                            DataTable add = new DataTable();
                            DataTable agent = new DataTable();
                            DataTable gov = new DataTable();
                            DataTable highcourt = new DataTable();


                            if ((DataTable)Session["sdcfile"] != null)
                            {

                                sdc = (DataTable)Session["sdcfile"];

                                foreach (DataRow dr in sdc.Rows)
                                {
                                    if (sdc.Rows.Count > 0)
                                        dtUploadFiles.Rows.Add(dr.ItemArray);
                                }

                            }
                            if (chk_add_agent.Checked == true)
                            {
                                if ((DataTable)Session["rdofile"] != null)
                                {
                                    add = (DataTable)Session["rdofile"];
                                    foreach (DataRow dr in add.Rows)
                                    {
                                        if (add.Rows.Count > 0)
                                            dtUploadFiles.Rows.Add(dr.ItemArray);
                                    }
                                }
                            }
                            if (chk_agent.Checked == true)
                            {
                                if ((DataTable)Session["collectorfile"] != null)
                                {
                                    agent = (DataTable)Session["collectorfile"];
                                    foreach (DataRow dr in agent.Rows)
                                    {
                                        if (agent.Rows.Count > 0)
                                            dtUploadFiles.Rows.Add(dr.ItemArray);
                                    }

                                }
                            }
                            if (chk_government.Checked == true)
                            {
                                if ((DataTable)Session["govfile"] != null)
                                {
                                    gov = (DataTable)Session["govfile"];
                                    foreach (DataRow dr in gov.Rows)
                                    {
                                        if (gov.Rows.Count > 0)
                                            dtUploadFiles.Rows.Add(dr.ItemArray);
                                    }

                                }
                            }
                            if (chk_high_court.Checked == true)
                            {
                                if ((DataTable)Session["highcourtfile"] != null)
                                {

                                    highcourt = (DataTable)Session["highcourtfile"];
                                    foreach (DataRow dr in highcourt.Rows)
                                    {
                                        if (highcourt.Rows.Count > 0)
                                            dtUploadFiles.Rows.Add(dr.ItemArray);
                                    }


                                }

                            }
                            BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUploadFiles;
                            if (dtUploadFiles.Rows.Count > 0)
                            {
                                ProjectRofrBAL.GetMasterDetails.land_transfer_files(BeneficiaryDetailsobj);

                            }


                        }
                        Bindrdo_docs();
                        Session["sdcfile"] = null;
                        Session["rdofile"] = null;
                        Session["collectorfile"] = null;
                        Session["govfile"] = null;
                        Session["highcourtfile"] = null;
                        ddl_itda.Focus();
                    }


                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Registration failed !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Session Closed please Login Again !')", true);

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            System.Threading.Thread.Sleep(5000);
            AntiForgery.Validate();
            Response.Redirect("LTR.aspx");
        }

        protected void ddl_sdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Session["event_controle"] = "sdc";
            if (ddl_sdc.SelectedItem.Text != "Select")
            {

                if (ddl_sdc.SelectedValue == "ALLOWED")
                {
                    div_sdc.Visible = true;
                    Lbl_sdc.Visible = true;
                    div_sdc_disallowed.Visible = false;
                    div_sdc_passed.Visible = true;
                    div_sdc_partially.Visible = false;

                    rbtn_sdc_orders_passed.ClearSelection();


                }
                else if (ddl_sdc.SelectedValue == "DISALLOWED")
                {
                    div_sdc.Visible = true;
                    //Lbl_sdc.Visible = false;
                    Lbl_sdc.Text = "Select:";
                    div_sdc_passed.Visible = false;
                    div_sdc_disallowed.Visible = true;
                    div_sdc_partially.Visible = false;


                    div_sdc_tri_name.Visible = false;
                    div_sdc_nt_name.Visible = false;

                }
            }
            else
            {
                ddl_sdc.ClearSelection();
                div_sdc.Visible = false;
                div_sdc_partially.Visible = false;
            }
        }

        protected void rbtn_sdc_orders_passed_SelectedIndexChanged(object sender, EventArgs e)

        {

            System.Threading.Thread.Sleep(5000);

            Session["event_controle"] = "sdc";
            if (rbtn_sdc_orders_passed.SelectedValue == "A" || rbtn_sdc_orders_passed.SelectedValue == "B")
            {
                div_sdc_partially.Visible = true;

                div_sdc_gov.Visible = false;
                div_sdc_tri_name.Visible = false;
                div_sdc_nt_name.Visible = false;
                rbtn_sdc_nt.Checked = false;
                rbtn_sdc_tri.Checked = false;
                rbtn_sdc_gov.Checked = false;

            }


        }

        //  protected void rbtn_orders_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rbtn_sdc_orders_passed.SelectedValue == "A")
        //    {

        //        if (rbtn_orders.SelectedValue == "A")
        //        {
        //            // div_sdc_nt_name.Style.Add("display", "block");
        //            div_sdc_nt_name.Visible = true;
        //            div_sdc_tri_name.Visible = false;
        //            div_sdc_gov_name.Visible = false;
        //            div_sdc_tri_orders_impl.Visible = false;
        //            div_sdc_gov_orders_impl.Visible = false;




        //        }
        //        else if (rbtn_orders.SelectedValue == "B")
        //        {
        //            div_sdc_tri_name.Visible = true;
        //            div_sdc_nt_name.Visible = false;
        //            div_sdc_gov_name.Visible = false;
        //            div_sdc_tri_orders_impl.Visible = true;
        //            div_sdc_gov_orders_impl.Visible = false;


        //        }
        //        else if (rbtn_orders.SelectedValue == "C")
        //        {
        //            div_sdc_gov_name.Visible = true;
        //            div_sdc_tri_name.Visible = false;

        //            div_sdc_nt_name.Visible = false;
        //            div_sdc_gov_orders_impl.Visible = true;
        //            div_sdc_tri_orders_impl.Visible = false;


        //        }
        //    }
        //   else if (rbtn_sdc_orders_passed.SelectedValue == "B")
        //    {

        //        if (rbtn_orders.SelectedValue == "A")
        //        {
        //            // div_sdc_nt_name.Style.Add("display", "block");
        //            div_sdc_nt_name.Visible = true;
        //            div_sdc_tri_name.Visible = false;
        //            div_sdc_gov_name.Visible = false;
        //            div_sdc_tri_orders_impl.Visible = false;
        //            div_sdc_gov_orders_impl.Visible = false;
        //        }
        //        else if (rbtn_orders.SelectedValue == "B")
        //        {
        //            div_sdc_tri_name.Visible = true;
        //            div_sdc_nt_name.Visible = false;
        //            div_sdc_gov_name.Visible = false;
        //            div_sdc_tri_orders_impl.Visible = true;
        //            div_sdc_gov_orders_impl.Visible = false;
        //        }
        //        else if (rbtn_orders.SelectedValue == "C")
        //        {
        //            div_sdc_gov_name.Visible = true;
        //            div_sdc_tri_name.Visible = false;
        //            div_sdc_nt_name.Visible = false;
        //            div_sdc_gov_orders_impl.Visible = true;
        //            div_sdc_tri_orders_impl.Visible = false;
        //        }
        //    }
        //}


        protected void ddl_add_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (ddl_add.SelectedItem.Text != "SELECT")
            {
                if (ddl_add.SelectedItem.Text == "ALLOWED")
                {
                    div_add_option.Visible = true;
                    div_add_passed.Visible = true;
                    div_add_allowed.Visible = true;
                    rbtn_add_orders_passed.Visible = true;
                    div_add_disallowed.Visible = false;
                    div_add_remanded.Visible = false;
                    div_add_partially.Visible = false;
                    rbtn_add_orders_passed.ClearSelection();
                }
                else if (ddl_add.SelectedItem.Text == "DISALLOWED")
                {
                    div_add_option.Visible = false;
                    div_add_passed.Visible = false;
                    div_add_allowed.Visible = false;
                    div_add_disallowed.Visible = false;
                    div_add_remanded.Visible = false;
                    div_add_partially.Visible = false;
                    rbtn_add_disallowed.Visible = false;
                    div_add_partially.Visible = false;
                    rbtn_add_disallowed.ClearSelection();

                }
                else if (ddl_add.SelectedItem.Text == "REMANDED")
                {
                    div_add_option.Visible = true;
                    div_add_passed.Visible = true;
                    lbl_add_orders_passed.Visible = false;
                    div_add_allowed.Visible = false;
                    div_add_disallowed.Visible = false;
                    div_add_remanded.Visible = true;
                    div_add_partially.Visible = false;
                    rbtn_add_remanded.Visible = true;

                    rbtn_add_remanded.ClearSelection();

                }
            }
            else
            {
                ddl_add.ClearSelection();
                div_add_option.Visible = false;
                div_add_partially.Visible = false;
            }

        }
        protected void ddl_agent_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (ddl_agent.SelectedItem.Text != "SELECT")
            {
                if (ddl_agent.SelectedItem.Text == "ALLOWED")
                {
                    div_agent_option.Visible = true;
                    //div_agent_passed.Visible = true;
                    div_agent_allowed.Visible = true;
                    rbtn_agent.Visible = true;
                    div_agent_disallowed.Visible = false;
                    div_agent_remanded.Visible = false;
                    rbtn_agent.ClearSelection();
                }
                else if (ddl_agent.SelectedItem.Text == "DISALLOWED")
                {
                    div_agent_option.Visible = false;
                    //div_add_passed.Visible = true;
                    lbl_agent_orders_passed.Visible = false;
                    div_agent_allowed.Visible = false;
                    div_agent_disallowed.Visible = false;
                    div_agent_remanded.Visible = false;
                    div_agent_partially.Visible = false;
                    rbtn_agent_disallowed.Visible = false;
                    rbtn_agent_disallowed.ClearSelection();

                }
                else if (ddl_agent.SelectedItem.Text == "REMANDED")
                {
                    div_agent_option.Visible = true;
                    // div_add_passed.Visible = true;
                    lbl_agent_orders_passed.Visible = false;
                    div_agent_allowed.Visible = false;
                    div_agent_disallowed.Visible = false;
                    div_agent_remanded.Visible = true;
                    div_agent_partially.Visible = false;
                    rbtn_agent_remanded.Visible = true;
                    rbtn_agent_remanded.ClearSelection();
                }
            }
            else
            {
                ddl_agent.ClearSelection();
                div_agent_option.Visible = false;
                div_agent_partially.Visible = false;
            }
        }
        protected void ddl_gov_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (ddl_gov.SelectedItem.Text != "SELECT")
            {
                if (ddl_gov.SelectedItem.Text == "ALLOWED")
                {
                    div_gov_option.Visible = true;
                    //div_agent_passed.Visible = true;
                    div_gov_allowed.Visible = true;
                    div_gov_disallowed.Visible = false;
                    div_gov_remanded.Visible = false;
                    rbtn_gov_orders_passed.Visible = true;
                    rbtn_gov_orders_passed.ClearSelection();
                }
                else if (ddl_gov.SelectedItem.Text == "DISALLOWED")
                {
                    div_gov_option.Visible = false;
                    //div_add_passed.Visible = true;
                    lbl_gov_orders_passed.Visible = false;
                    div_gov_allowed.Visible = false;
                    div_gov_disallowed.Visible = false;
                    rbtn_gov_disallowed.Visible = false;
                    div_gov_remanded.Visible = false;
                    div_gov_partially.Visible = false;
                    rbtn_gov_disallowed.ClearSelection();

                }
                else if (ddl_gov.SelectedItem.Text == "REMANDED")
                {
                    div_gov_option.Visible = true;
                    // div_add_passed.Visible = true;
                    div_gov_allowed.Visible = false;
                    div_gov_disallowed.Visible = false;
                    div_gov_remanded.Visible = true;
                    rbtn_gov_remanded.Visible = true;
                    div_gov_partially.Visible = false;

                    rbtn_gov_remanded.ClearSelection();

                }
            }
            else
            {
                ddl_gov.ClearSelection();
                div_gov_option.Visible = false;
                div_gov_partially.Visible = false;
            }
        }
        protected void ddl_hc_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (ddl_hc.SelectedItem.Text != "SELECT")
            {
                if (ddl_hc.SelectedItem.Text == "ALLOWED")
                {
                    div_hc_option.Visible = true;

                    div_hc_allowed.Visible = true;

                    rbtn_hc_orders_passed.Visible = true;
                    div_hc_disallowed.Visible = false;
                    div_hc_remanded.Visible = false;
                    rbtn_hc_orders_passed.ClearSelection();
                }
                else if (ddl_hc.SelectedItem.Text == "DISALLOWED")
                {
                    div_hc_option.Visible = false;
                    Lbl_hc.Visible = false;
                    //div_add_passed.Visible = true;
                    div_hc_allowed.Visible = false;
                    div_hc_disallowed.Visible = false;
                    div_hc_remanded.Visible = false;
                    rbtn_hc_disallowed.Visible = false;
                    div_high_court_partially.Visible = false;
                    rbtn_hc_disallowed.ClearSelection();

                }
                else if (ddl_hc.SelectedItem.Text == "REMANDED")
                {
                    div_hc_option.Visible = true;
                    // div_add_passed.Visible = true;
                    div_hc_allowed.Visible = false;
                    div_hc_disallowed.Visible = false;
                    div_hc_remanded.Visible = true;
                    rbtn_hc_remanded.Visible = true;
                    div_high_court_partially.Visible = false;

                    rbtn_hc_remanded.ClearSelection();

                }
            }
            else
            {
                ddl_hc.ClearSelection();
                div_hc_option.Visible = false;
                div_high_court_partially.Visible = false;
            }
        }

        protected void rbtn_sdc_nt_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Session["event_controle"] = "sdc";

            if (rbtn_sdc_orders_passed.SelectedValue == "A")
            {
                if (rbtn_sdc_nt.Checked == true)
                {
                    div_sdc_nt_name.Visible = true;
                    txt_sdc_nt_name.Text = "";
                    txt_sdc_nt_extent.Text = "";

                }

            }
            else if (rbtn_sdc_orders_passed.SelectedValue == "B")
            {
                if (rbtn_sdc_nt.Checked == true)
                {
                    div_sdc_nt_name.Visible = true;
                    rbtn_sdc_tri.Checked = false;
                    rbtn_sdc_gov.Checked = false;
                    div_sdc_tri_name.Visible = false;
                    div_sdc_gov.Visible = false;
                    txt_sdc_nt_name.Text = "";
                    txt_sdc_nt_extent.Text = "";

                }
            }
        }

        protected void rbtn_sdc_tri_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Session["event_controle"] = "sdc";
            if (rbtn_sdc_orders_passed.SelectedValue == "A")
            {
                if (rbtn_sdc_tri.Checked == true)
                {

                    div_sdc_tri_name.Visible = true;
                    txt_sdc_tri_name.Text = "";
                    txt_sdc_tri_extent.Text = "";
                    rbtn_sdc_tri_impl.ClearSelection();
                    txt_t_ac_cts.Text = "";
                    //txt_t_hec.Text = "";

                }

            }
            else if (rbtn_sdc_orders_passed.SelectedValue == "B")
            {
                if (rbtn_sdc_tri.Checked == true)
                {
                    div_sdc_tri_name.Visible = true;


                    rbtn_sdc_nt.Checked = false;
                    rbtn_sdc_gov.Checked = false;
                    div_sdc_nt_name.Visible = false;
                    div_sdc_gov.Visible = false;
                    txt_sdc_tri_name.Text = "";
                    txt_sdc_tri_extent.Text = "";
                    rbtn_sdc_tri_impl.ClearSelection();
                    txt_t_ac_cts.Text = "";
                    //txt_t_hec.Text = "";
                }

            }

        }

        protected void rbtn_sdc_gov_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Session["event_controle"] = "sdc";
            if (rbtn_sdc_orders_passed.SelectedValue == "A")
            {
                if (rbtn_sdc_gov.Checked == true)
                {
                    div_sdc_gov.Visible = true;
                    txt_sdc_gov_name.Text = "";
                    txt_sdc_gov_extent.Text = "";
                    rbtn_sdc_gov_impl.ClearSelection();
                    txt_g_ac_cts.Text = "";
                    //txt_g_hec.Text = "";


                }

            }
            else if (rbtn_sdc_orders_passed.SelectedValue == "B")
            {
                if (rbtn_sdc_gov.Checked == true)
                {
                    div_sdc_gov.Visible = true;

                    rbtn_sdc_nt.Checked = false;
                    rbtn_sdc_tri.Checked = false;
                    div_sdc_nt_name.Visible = false;
                    div_sdc_tri_name.Visible = false;
                }

            }
        }

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                Response.Redirect("View_Ltr.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        public void Binddata(string id)
        {
            try
            {
                DataSet ds = Landsettlementpattas.GetLtrData(id);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];

                if (dt.Rows.Count > 0)
                {
                    ddl_itda.DataSource = dt.DefaultView.ToTable(true, "ITDA");
                    ddl_itda.DataTextField = "ITDA";
                    ddl_itda.DataValueField = "ITDA";
                    ddl_itda.DataBind();

                    ddl_district.DataSource = dt.DefaultView.ToTable(true, "DISTRICT");
                    ddl_district.DataTextField = "DISTRICT";
                    ddl_district.DataValueField = "DISTRICT";
                    ddl_district.DataBind();
                    ddl_mandal.DataSource = dt.DefaultView.ToTable(true, "MANDAL");
                    ddl_mandal.DataTextField = "MANDAL";
                    ddl_mandal.DataValueField = "MANDAL";
                    ddl_mandal.DataBind();
                    ddl_village.DataSource = dt.DefaultView.ToTable(true, "VILLAGE");
                    ddl_village.DataTextField = "VILLAGE";
                    ddl_village.DataValueField = "VILLAGE";
                    ddl_village.DataBind();
                    ddl_hab.DataSource = dt.DefaultView.ToTable(true, "HABITATION");
                    ddl_hab.DataTextField = "HABITATION";
                    ddl_hab.DataValueField = "HABITATION";
                    ddl_hab.DataBind();
                    txt_extent.Text = dt.Rows[0]["EXTENT"].ToString();
                    txt_rsno.Text = dt.Rows[0]["RS_NO"].ToString();
                    txt_ltrp.Text = dt.Rows[0]["LTRP_NO"].ToString();
                    txt_remarks.Text = dt.Rows[0]["REMARKS"].ToString();
                    txt_land_purpose.Text = dt.Rows[0]["LAND_ALREADY_ACQUIRED"].ToString();
                    dtp_input2.Text = dt.Rows[0]["DATE_OF_ORDERS"].ToString();
                    txt_OldDateoforder.Text = dt.Rows[0]["DISPOSAL_DATE"].ToString();

                    if ((dt.Rows[0]["case_status"].ToString()) == "PENDING")

                    {
                        ddl_sdc_status.DataSource = dt.DefaultView.ToTable(true, "case_status");
                        ddl_sdc_status.DataTextField = "case_status";
                        ddl_sdc_status.DataValueField = "case_status";
                        ddl_sdc_status.DataBind();
                    }
                    else if ((dt.Rows[0]["case_status"].ToString()) == "DISPOSED")
                    {
                        ddl_sdc_status.DataSource = dt.DefaultView.ToTable(true, "case_status");
                        ddl_sdc_status.DataTextField = "case_status";
                        ddl_sdc_status.DataValueField = "case_status";
                        ddl_sdc_status.DataBind();
                    }

                    if ((dt.Rows[0]["SDC_LEVEL"].ToString()) == "ALLOWED")

                    {

                        ddl_sdc.DataSource = dt.DefaultView.ToTable(true, "SDC_LEVEL");
                        ddl_sdc.DataTextField = "SDC_LEVEL";
                        ddl_sdc.DataValueField = "SDC_LEVEL";
                        ddl_sdc.DataBind();

                        if (ddl_sdc.SelectedItem.Text == "ALLOWED")
                        {
                            div_sdc.Visible = true;
                            div_sdc_passed.Visible = true;
                            rbtn_sdc_orders_passed.Visible = true;
                            //rbtn_sdc_disallowed.Visible = false;

                            div_sdc_disallowed.Visible = false;

                            if ((dt.Rows[0]["SDC_ORDERS_PASSED"].ToString()) == "Partially")
                            {


                                rbtn_sdc_orders_passed.Items.FindByValue("A").Selected = true;

                                //div_add_partially.Visible = true;



                            }
                            else if ((dt.Rows[0]["SDC_ORDERS_PASSED"].ToString()) == "Fully")
                            {


                                rbtn_sdc_orders_passed.Items.FindByValue("B").Selected = true;
                                // div_add_partially.Visible = true;



                            }
                        }
                    }
                    else if ((dt.Rows[0]["SDC_LEVEL"].ToString()) == "DISALLOWED")

                    {

                        ddl_sdc.DataSource = dt.DefaultView.ToTable(true, "SDC_LEVEL"); ;
                        ddl_sdc.DataTextField = "SDC_LEVEL";
                        ddl_sdc.DataValueField = "SDC_LEVEL";
                        ddl_sdc.DataBind();
                        if (ddl_sdc.SelectedItem.Text == "DISALLOWED")
                        {



                            div_sdc.Visible = true;
                            Lbl_sdc.Visible = false;
                            div_sdc_partially.Visible = false;
                            // div_sdc_tri.Visible = false;
                            div_sdc_disallowed.Visible = true;
                            div_sdc_passed.Visible = false;
                            rbtn_sdc_orders_passed.Visible = false;

                            if ((dt.Rows[0]["SDC_ORDERS_PASSED"].ToString()) == "On Full trial")
                            {
                                rbtn_sdc_disallowed.Items.FindByValue("A").Selected = true;
                            }
                            else if ((dt.Rows[0]["SDC_ORDERS_PASSED"].ToString()) == "Resjudicated/Dropped")
                            {
                                rbtn_sdc_disallowed.Items.FindByValue("B").Selected = true;
                            }
                        }
                    }
                    if (rbtn_sdc_orders_passed.SelectedValue == "A")
                    {
                        if ((dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString()) != "")
                        {

                            rbtn_sdc_nt.Checked = true;
                            if (rbtn_sdc_nt.Checked == true)
                            {
                                div_sdc_nt_name.Visible = true;
                                div_sdc_partially.Visible = true;
                                rbtn_sdc_nt.Visible = true;
                                txt_sdc_nt_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString();
                                txt_sdc_nt_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_NT_EXTENT"].ToString();
                            }
                        }
                        if (dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString() != "")
                        {

                            rbtn_sdc_tri.Checked = true;
                            if (rbtn_sdc_tri.Checked == true)
                            {
                                div_sdc_tri_name.Visible = true;
                                div_sdc_partially.Visible = true;
                                rbtn_sdc_tri.Visible = true;
                                // div_sdc_tri.Visible = true;
                                txt_sdc_tri_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString();
                                txt_sdc_tri_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_T_EXTENT"].ToString();
                                if ((dt.Rows[0]["O_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                {
                                    rbtn_sdc_tri_impl.Items.FindByValue("A").Selected = true;
                                    //rbtn_sdc_tri_impl.Visible = true;
                                }
                                else if ((dt.Rows[0]["O_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                {
                                    rbtn_sdc_tri_impl.Items.FindByValue("B").Selected = true;
                                    // rbtn_sdc_tri_impl.Visible = true;
                                }
                                txt_t_ac_cts.Text = dt.Rows[0]["DETAILS_OF_LAND_T_AC_CTS"].ToString();
                                //txt_t_hec.Text = dt.Rows[0]["DETAILS_OF_T_LAND_HEC_A"].ToString();

                            }

                        }
                        if (dt.Rows[0]["O_GOVT"].ToString() != "")
                        {

                            rbtn_sdc_gov.Checked = true;

                            if (rbtn_sdc_gov.Checked == true)
                            {
                                div_sdc_partially.Visible = true;

                                div_sdc_gov.Visible = true;
                                div_sdc_ogov.Visible = true;
                                rbtn_sdc_gov.Visible = true;
                                txt_sdc_gov_name.Text = dt.Rows[0]["O_GOVT"].ToString();
                                txt_sdc_gov_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_GOVT_EXTENT"].ToString();
                                if ((dt.Rows[0]["O_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                {
                                    rbtn_sdc_gov_impl.Items.FindByValue("A").Selected = true;

                                }
                                else if ((dt.Rows[0]["O_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                {
                                    rbtn_sdc_gov_impl.Items.FindByValue("B").Selected = true;
                                }
                                txt_g_ac_cts.Text = dt.Rows[0]["DETAILS_OF_LAND_G_AC_CTS"].ToString();
                                //txt_g_hec.Text = dt.Rows[0]["DETAILS_OF_G_LAND_HEC_A"].ToString();
                            }
                        }




                    }
                    else if (rbtn_sdc_orders_passed.SelectedValue == "B")
                    {

                        if (dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString() != "")
                        {

                            rbtn_sdc_nt.Checked = true;
                            if (rbtn_sdc_nt.Checked == true)
                            {
                                div_sdc_partially.Visible = true;

                                div_sdc_nt_name.Visible = true;
                                txt_sdc_nt_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString();
                                txt_sdc_nt_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_NT_EXTENT"].ToString();
                            }

                        }
                        else if (dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString() != "")
                        {

                            rbtn_sdc_tri.Checked = true;

                            if (rbtn_sdc_tri.Visible == true)
                            {
                                div_sdc_partially.Visible = true;

                                div_sdc_tri_name.Visible = true;
                                txt_sdc_tri_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString();
                                txt_sdc_tri_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_T_EXTENT"].ToString();
                                if ((dt.Rows[0]["O_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                {
                                    rbtn_sdc_tri_impl.Items.FindByValue("A").Selected = true;
                                }
                                else if ((dt.Rows[0]["O_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                {
                                    rbtn_sdc_tri_impl.Items.FindByValue("B").Selected = true;
                                }
                            }
                        }
                        else if (dt.Rows[0]["O_GOVT"].ToString() != "")
                        {

                            rbtn_sdc_gov.Checked = true;
                            if (rbtn_sdc_gov.Checked == true)
                            {
                                div_sdc_gov.Visible = true;
                                div_sdc_ogov.Visible = true;

                                div_sdc_partially.Visible = true;
                                rbtn_sdc_gov.Checked = true;
                                txt_sdc_gov_name.Text = dt.Rows[0]["O_GOVT"].ToString();
                                txt_sdc_gov_extent.Text = dt.Rows[0]["O_IN_FAVOUR_OF_GOVT_EXTENT"].ToString();
                                if ((dt.Rows[0]["O_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                {
                                    rbtn_sdc_gov_impl.Items.FindByValue("A").Selected = true;
                                }
                                else if ((dt.Rows[0]["O_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                {
                                    rbtn_sdc_gov_impl.Items.FindByValue("B").Selected = true;
                                }
                            }
                        }

                    }
                    txt_petitioner.Text = dt.Rows[0]["PETITIONER"].ToString();
                    txt_respondent.Text = dt.Rows[0]["RESPONDENT"].ToString();
                }
                //Additional Agent
                if (dt1.Rows.Count > 0)
                {
                    if ((dt1.Rows[0]["STATUS1"].ToString()) == "1")
                    {

                        txt_cma_no.Text = dt1.Rows[0]["AAG_CMA_NO"].ToString();
                        txt_add_dt_orders.Text = dt1.Rows[0]["CMADATE_OF_ORDERS"].ToString();
                        txt_add_remarks.Text = dt1.Rows[0]["AAG_REMARKS"].ToString();
                        txt_add_disposal.Text = dt1.Rows[0]["AAG_DATE_DISPOSAL"].ToString();
                        if ((dt1.Rows[0]["case_status"].ToString()) == "PENDING")

                        {
                            ddl_add_status.DataSource = dt1.DefaultView.ToTable(true, "case_status");
                            ddl_add_status.DataTextField = "case_status";
                            ddl_add_status.DataValueField = "case_status";
                            ddl_add_status.DataBind();
                        }
                        else if ((dt.Rows[0]["case_status"].ToString()) == "DISPOSED")
                        {
                            ddl_add_status.DataSource = dt1.DefaultView.ToTable(true, "case_status");
                            ddl_add_status.DataTextField = "case_status";
                            ddl_add_status.DataValueField = "case_status";
                            ddl_add_status.DataBind();
                        }
                        if ((dt1.Rows[0]["AAG_LEVEL"].ToString()) == "ALLOWED")

                        {

                            ddl_add.DataSource = dt1.DefaultView.ToTable(true, "AAG_LEVEL"); ;
                            ddl_add.DataTextField = "AAG_LEVEL";
                            ddl_add.DataValueField = "AAG_LEVEL";
                            ddl_add.DataBind();
                            if (ddl_add.SelectedItem.Text == "ALLOWED")
                            {
                                div_add_option.Visible = true;
                                div_add_passed.Visible = true;
                                div_add_disallowed.Visible = false;
                                div_add_remanded.Visible = false;
                                rbtn_add_disallowed.Visible = false;
                                rbtn_add_remanded.Visible = false;
                                rbtn_add_orders_passed.Visible = true;


                                if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Partially")
                                {


                                    rbtn_add_orders_passed.Items.FindByValue("A").Selected = true;


                                }
                                else if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Fully")
                                {


                                    rbtn_add_orders_passed.Items.FindByValue("B").Selected = true;


                                }
                            }
                        }
                        else if ((dt1.Rows[0]["AAG_LEVEL"].ToString()) == "DISALLOWED")

                        {
                            ddl_add.DataSource = dt1.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_add.DataTextField = "AAG_LEVEL";
                            ddl_add.DataValueField = "AAG_LEVEL";
                            ddl_add.DataBind();


                            //if (ddl_add.SelectedItem.Text == "DISALLOWED")
                            //{
                            //    div_add_option.Visible = true;
                            //    div_add_passed.Visible = true;
                            //    div_add_allowed.Visible = false;
                            //    rbtn_add_orders_passed.Visible = false;
                            //    div_add_partially.Visible = false;

                            //    div_add_disallowed.Visible = true;
                            //    div_add_remanded.Visible = false;
                            //    rbtn_add_disallowed.Visible = true;

                            //    if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "On Full trial")
                            //    {
                            //        rbtn_add_disallowed.Items.FindByValue("A").Selected = true;

                            //    }
                            //    else if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Resjudicated/Dropped")
                            //    {
                            //        rbtn_add_disallowed.Items.FindByValue("B").Selected = true;
                            //    }
                            //}
                        }

                        else if ((dt1.Rows[0]["AAG_LEVEL"].ToString()) == "REMANDED")

                        {
                            ddl_add.DataSource = dt1.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_add.DataTextField = "AAG_LEVEL";
                            ddl_add.DataValueField = "AAG_LEVEL";
                            ddl_add.DataBind();


                            if (ddl_add.SelectedItem.Text == "REMANDED")
                            {

                                div_add_option.Visible = true;
                                div_add_passed.Visible = false;

                                div_add_partially.Visible = false;

                                div_add_disallowed.Visible = false;
                                div_add_remanded.Visible = true;
                                div_add_allowed.Visible = false;


                                //if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Agent to Government")
                                //{
                                //    rbtn_add_remanded.Items.FindByValue("A").Selected = true;
                                //}
                                //else if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Government")
                                //{
                                //    rbtn_add_remanded.Items.FindByValue("B").Selected = true;
                                //}
                                //else if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "High Court")
                                //{
                                //    rbtn_add_remanded.Items.FindByValue("C").Selected = true;
                                //}
                                if ((dt1.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "SDC")
                                {
                                    rbtn_add_remanded.Items.FindByValue("D").Selected = true;
                                }
                            }


                        }
                        if (rbtn_add_orders_passed.SelectedValue == "A")
                        {
                            if ((dt1.Rows[0]["AAG_NT"].ToString()) != "")
                            {

                                rbtn_add_nt.Checked = true;
                                if (rbtn_add_nt.Checked == true)
                                {
                                    rbtn_add_nt.Visible = true;
                                    div_add_partially.Visible = true;
                                    div_add_nt_txt.Visible = true;

                                    txt_add_nt_name.Text = dt1.Rows[0]["AAG_NT"].ToString();
                                    txt_add_nt_extent.Text = dt1.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }
                            }
                            if (dt1.Rows[0]["AAG_T"].ToString() != "")
                            {

                                rbtn_add_tri.Checked = true;
                                if (rbtn_add_tri.Checked == true)
                                {
                                    div_add_partially.Visible = true;
                                    div_add_tri_txt.Visible = true;
                                    // div_sdc_tri.Visible = true;
                                    rbtn_add_tri.Visible = true;

                                    txt_add_tri_name.Text = dt1.Rows[0]["AAG_T"].ToString();
                                    txt_add_tri_extent.Text = dt1.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt1.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_add_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt1.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_add_tri_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }

                            }
                            if (dt1.Rows[0]["AAG_GOVT"].ToString() != "")
                            {

                                rbtn_add_gov.Checked = true;

                                if (rbtn_add_gov.Checked == true)
                                {
                                    div_add_partially.Visible = true;
                                    div_add_gov_txt.Visible = true;
                                    div_add_gov.Visible = true;
                                    rbtn_add_gov.Visible = true;
                                    txt_add_gov_name.Text = dt.Rows[0]["AAG_GOVT"].ToString();
                                    txt_add_gov_extent.Text = dt.Rows[0]["AAG_EXTENT_NT"].ToString();
                                    if ((dt1.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_add_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt1.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_add_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }




                        }
                        else if (rbtn_add_orders_passed.SelectedValue == "B")
                        {

                            if (dt1.Rows[0]["AAG_NT"].ToString() != "")
                            {

                                rbtn_add_nt.Checked = true;
                                if (rbtn_add_nt.Checked == true)
                                {

                                    div_add_partially.Visible = true;
                                    div_add_nt_txt.Visible = true;
                                    rbtn_add_nt.Visible = true;
                                    txt_add_nt_name.Text = dt1.Rows[0]["AAG_NT"].ToString();
                                    txt_add_nt_extent.Text = dt1.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }

                            }
                            else if (dt1.Rows[0]["AAG_T"].ToString() != "")
                            {
                                rbtn_add_tri.Checked = true;

                                if (rbtn_add_tri.Checked == true)
                                {
                                    div_add_partially.Visible = true;

                                    div_add_tri_txt.Visible = true;
                                    rbtn_add_tri.Visible = true;
                                    rbtn_add_tri_impl.Visible = true;
                                    txt_add_tri_name.Text = dt1.Rows[0]["AAG_T"].ToString();
                                    txt_add_tri_extent.Text = dt1.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt1.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {

                                        rbtn_add_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt1.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {

                                        rbtn_add_tri_impl.Items.FindByValue("B").Selected = true;

                                    }
                                }
                            }
                            else if (dt1.Rows[0]["AAG_GOVT"].ToString() != "")
                            {



                                rbtn_add_gov.Checked = true;
                                if (rbtn_add_gov.Checked == true)
                                {
                                    div_add_partially.Visible = true;
                                    div_add_gov.Visible = true;
                                    div_add_gov_txt.Visible = true;
                                    rbtn_add_gov.Visible = true;
                                    txt_add_gov_name.Text = dt1.Rows[0]["AAG_GOVT"].ToString();
                                    txt_add_gov_extent.Text = dt1.Rows[0]["AAG_EXTENT_GOVT"].ToString();
                                    if ((dt1.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_add_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt1.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_add_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }

                        }

                    }
                }
                //Agent To Government
                if (dt2.Rows.Count > 0)
                {
                    if ((dt2.Rows[0]["STATUS1"].ToString()) == "2")
                    {

                        txt_appeal_no.Text = dt2.Rows[0]["AAG_CMA_NO"].ToString();
                        txt_agent_dt_orders.Text = dt2.Rows[0]["CMADATE_OF_ORDERS"].ToString();
                        txt_agent_remarks.Text = dt2.Rows[0]["AAG_REMARKS"].ToString();
                        txt_agent_disposal.Text = dt2.Rows[0]["AG_DATE_DISPOSAL"].ToString();

                        if ((dt2.Rows[0]["case_status"].ToString()) == "PENDING")

                        {
                            ddl_agent_status.DataSource = dt2.DefaultView.ToTable(true, "case_status");
                            ddl_agent_status.DataTextField = "case_status";
                            ddl_agent_status.DataValueField = "case_status";
                            ddl_agent_status.DataBind();
                        }
                        else if ((dt2.Rows[0]["case_status"].ToString()) == "DISPOSED")
                        {
                            ddl_agent_status.DataSource = dt2.DefaultView.ToTable(true, "case_status");
                            ddl_agent_status.DataTextField = "case_status";
                            ddl_agent_status.DataValueField = "case_status";
                            ddl_agent_status.DataBind();
                        }
                        if ((dt2.Rows[0]["AAG_LEVEL"].ToString()) == "ALLOWED")

                        {

                            ddl_agent.DataSource = dt2.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_agent.DataTextField = "AAG_LEVEL";
                            ddl_agent.DataValueField = "AAG_LEVEL";
                            ddl_agent.DataBind();
                            if (ddl_agent.SelectedItem.Text == "ALLOWED")
                            {
                                div_agent_option.Visible = true;
                                div_agent_allowed.Visible = true;
                                rbtn_agent.Visible = true;
                                div_agent_disallowed.Visible = false;
                                rbtn_agent_disallowed.Visible = false;
                                div_agent_remanded.Visible = false;


                                if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Partially")
                                {


                                    rbtn_agent.Items.FindByValue("A").Selected = true;


                                }
                                else if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Fully")
                                {


                                    rbtn_agent.Items.FindByValue("B").Selected = true;


                                }
                            }
                        }
                        else if ((dt2.Rows[0]["AAG_LEVEL"].ToString()) == "DISALLOWED")

                        {

                            ddl_agent.DataSource = dt2.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_agent.DataTextField = "AAG_LEVEL";
                            ddl_agent.DataValueField = "AAG_LEVEL";
                            ddl_agent.DataBind();
                            //if (ddl_agent.SelectedItem.Text == "DISALLOWED")
                            //{
                            //    div_agent_disallowed.Visible = true;
                            //    div_agent_option.Visible = true;
                            //    div_agent_allowed.Visible = false;
                            //    div_agent_remanded.Visible = false;
                            //    div_agent_partially.Visible = false;



                            //    div_agent_tri_txt.Visible = false;


                            //    if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "On Full trial")
                            //    {
                            //        rbtn_agent_disallowed.Items.FindByValue("A").Selected = true;
                            //    }
                            //    else if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Resjudicated/Dropped")
                            //    {
                            //        rbtn_agent_disallowed.Items.FindByValue("B").Selected = true;
                            //    }
                            //}
                        }

                        else if ((dt2.Rows[0]["AAG_LEVEL"].ToString()) == "REMANDED")

                        {

                            ddl_agent.DataSource = dt2.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_agent.DataTextField = "AAG_LEVEL";
                            ddl_agent.DataValueField = "AAG_LEVEL";
                            ddl_agent.DataBind();
                            if (ddl_agent.SelectedItem.Text == "REMANDED")
                            {
                                div_agent_option.Visible = true;
                                div_agent_allowed.Visible = false;
                                div_agent_disallowed.Visible = false;
                                lbl_agent_orders_passed.Visible = false;
                                div_agent_remanded.Visible = true;

                                div_agent_partially.Visible = false;


                                //if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Additional Agent")
                                //{
                                //    rbtn_agent_remanded.Items.FindByValue("A").Selected = true;
                                //}
                                //else if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Government")
                                //{
                                //    rbtn_agent_remanded.Items.FindByValue("B").Selected = true;
                                //}
                                //else if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "High Court")
                                //{
                                //    rbtn_agent_remanded.Items.FindByValue("C").Selected = true;
                                //}
                                if ((dt2.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "SDC")
                                {
                                    rbtn_agent_remanded.Items.FindByValue("D").Selected = true;
                                }
                            }


                        }
                        if (rbtn_agent.SelectedValue == "A")
                        {
                            if ((dt2.Rows[0]["AAG_NT"].ToString()) != "")
                            {

                                rbtn_nt.Checked = true;
                                if (rbtn_nt.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_nt.Visible = true;

                                    div_agent_nt_txt.Visible = true;

                                    txt_nt_name.Text = dt2.Rows[0]["AAG_NT"].ToString();
                                    txt_nt_extent.Text = dt2.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }
                            }
                            if (dt2.Rows[0]["AAG_T"].ToString() != "")
                            {

                                rbtn_tribal.Checked = true;
                                if (rbtn_tribal.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_tribal.Visible = true;
                                    div_agent_tri_txt.Visible = true;
                                    // div_sdc_tri.Visible = true;
                                    txt_tri_name.Text = dt2.Rows[0]["AAG_T"].ToString();
                                    txt_tri_extent.Text = dt2.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt2.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_agent_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt2.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_agent_tri_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }

                            }
                            if (dt2.Rows[0]["AAG_GOVT"].ToString() != "")
                            {

                                rbtn_agent_gov.Checked = true;

                                if (rbtn_agent_gov.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_agent_gov.Visible = true;
                                    div_agent_gov_txt.Visible = true;
                                    txt_gov_name.Text = dt2.Rows[0]["AAG_GOVT"].ToString();
                                    txt_gov_extent.Text = dt2.Rows[0]["AAG_EXTENT_NT"].ToString();
                                    if ((dt2.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_agent_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt2.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_agent_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }




                        }
                        else if (rbtn_agent.SelectedValue == "B")
                        {

                            if (dt2.Rows[0]["AAG_NT"].ToString() != "")
                            {

                                rbtn_nt.Checked = true;
                                if (rbtn_nt.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_nt.Visible = true;
                                    div_agent_nt_txt.Visible = true;
                                    txt_nt_name.Text = dt2.Rows[0]["AAG_NT"].ToString();
                                    txt_nt_extent.Text = dt2.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }

                            }
                            else if (dt2.Rows[0]["AAG_T"].ToString() != "")
                            {
                                rbtn_tribal.Checked = true;

                                if (rbtn_tribal.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_tribal.Visible = true;
                                    div_agent_tri_txt.Visible = true;
                                    txt_tri_name.Text = dt2.Rows[0]["AAG_T"].ToString();
                                    txt_tri_extent.Text = dt2.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt2.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_agent_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt2.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_agent_tri_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }
                            else if (dt2.Rows[0]["AAG_GOVT"].ToString() != "")
                            {



                                rbtn_agent_gov.Checked = true;
                                if (rbtn_agent_gov.Checked == true)
                                {
                                    div_agent_partially.Visible = true;
                                    rbtn_agent_gov.Visible = true;
                                    div_agent_gov.Visible = true;
                                    txt_gov_name.Text = dt2.Rows[0]["AAG_GOVT"].ToString();
                                    txt_gov_extent.Text = dt2.Rows[0]["AAG_EXTENT_GOVT"].ToString();
                                    if ((dt2.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_agent_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt2.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_agent_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }

                        }

                    }
                }
                //Government
                if (dt3.Rows.Count > 0)
                {
                    if ((dt3.Rows[0]["STATUS1"].ToString()) == "3")
                    {

                        txt_rpno.Text = dt3.Rows[0]["AAG_CMA_NO"].ToString();
                        txt_gov_dt_orders.Text = dt3.Rows[0]["CMADATE_OF_ORDERS"].ToString();
                        txt_gov_remarks.Text = dt3.Rows[0]["AAG_REMARKS"].ToString();
                        txt_gov_disposal.Text = dt3.Rows[0]["G_DISPOSAL"].ToString();
                        if ((dt3.Rows[0]["case_status"].ToString()) == "PENDING")

                        {
                            ddl_gov_status.DataSource = dt3.DefaultView.ToTable(true, "case_status");
                            ddl_gov_status.DataTextField = "case_status";
                            ddl_gov_status.DataValueField = "case_status";
                            ddl_gov_status.DataBind();
                        }
                        else if ((dt3.Rows[0]["case_status"].ToString()) == "DISPOSED")
                        {
                            ddl_gov_status.DataSource = dt3.DefaultView.ToTable(true, "case_status");
                            ddl_gov_status.DataTextField = "case_status";
                            ddl_gov_status.DataValueField = "case_status";
                            ddl_gov_status.DataBind();
                        }
                        if ((dt3.Rows[0]["AAG_LEVEL"].ToString()) == "ALLOWED")

                        {

                            ddl_gov.DataSource = dt3.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_gov.DataTextField = "AAG_LEVEL";
                            ddl_gov.DataValueField = "AAG_LEVEL";
                            ddl_gov.DataBind();
                            if (ddl_gov.SelectedItem.Text == "ALLOWED")
                            {
                                div_gov_option.Visible = true;
                                rbtn_gov_disallowed.Visible = false;
                                div_gov_disallowed.Visible = false;
                                div_gov_remanded.Visible = false;
                                rbtn_gov_orders_passed.Visible = true;
                                div_gov_allowed.Visible = true;
                                if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Partially")
                                {


                                    rbtn_gov_orders_passed.Items.FindByValue("A").Selected = true;


                                }
                                else if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Fully")
                                {


                                    rbtn_gov_orders_passed.Items.FindByValue("B").Selected = true;


                                }
                            }
                        }
                        else if ((dt3.Rows[0]["AAG_LEVEL"].ToString()) == "DISALLOWED")

                        {
                            ddl_gov.DataSource = dt3.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_gov.DataTextField = "AAG_LEVEL";
                            ddl_gov.DataValueField = "AAG_LEVEL";
                            ddl_gov.DataBind();


                            //if (ddl_gov.SelectedItem.Text == "DISALLOWED")
                            //{

                            //    div_gov_option.Visible = true;
                            //    div_gov_allowed.Visible = false;
                            //    div_gov_disallowed.Visible = true;
                            //    div_gov_partially.Visible = false;

                            //    div_gov_remanded.Visible = false;


                            //    rbtn_gov_disallowed.Visible = true;

                            //    if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "On Full trial")
                            //    {
                            //        rbtn_gov_disallowed.Items.FindByValue("A").Selected = true;
                            //    }
                            //    else if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Resjudicated/Dropped")
                            //    {
                            //        rbtn_gov_disallowed.Items.FindByValue("B").Selected = true;
                            //    }
                            //}
                        }

                        else if ((dt3.Rows[0]["AAG_LEVEL"].ToString()) == "REMANDED")

                        {


                            ddl_gov.DataSource = dt3.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_gov.DataTextField = "AAG_LEVEL";
                            ddl_gov.DataValueField = "AAG_LEVEL";
                            ddl_gov.DataBind();
                            if (ddl_gov.SelectedItem.Text == "REMANDED")
                            {
                                div_gov_disallowed.Visible = false;
                                div_gov_option.Visible = true;
                                div_gov_allowed.Visible = false;
                                div_gov_remanded.Visible = true;

                                div_gov_partially.Visible = false;



                                if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Additional Agent")
                                {
                                    rbtn_gov_remanded.Items.FindByValue("A").Selected = true;
                                }
                                else if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Agent to Government")
                                {
                                    rbtn_gov_remanded.Items.FindByValue("B").Selected = true;
                                }
                                //else if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "High Court")
                                //{
                                //    rbtn_gov_remanded.Items.FindByValue("C").Selected = true;
                                //}
                                else if ((dt3.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "SDC")
                                {
                                    rbtn_gov_remanded.Items.FindByValue("D").Selected = true;
                                }
                            }


                        }
                        if (rbtn_gov_orders_passed.SelectedValue == "A")
                        {
                            if ((dt3.Rows[0]["AAG_NT"].ToString()) != "")
                            {
                                rbtn_gov_nt.Checked = true;
                                if (rbtn_gov_nt.Checked == true)
                                {
                                    div_gov_partially.Visible = true;
                                    rbtn_gov_nt.Visible = true;
                                    div_gov_nt_txt.Visible = true;

                                    txt_gov_nt_name.Text = dt3.Rows[0]["AAG_NT"].ToString();
                                    txt_gov_nt_extent.Text = dt3.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }
                            }
                            if (dt3.Rows[0]["AAG_T"].ToString() != "")
                            {

                                rbtn_gov_tri.Checked = true;
                                if (rbtn_gov_tri.Checked == true)
                                {
                                    div_gov_partially.Visible = true;
                                    rbtn_gov_tri.Visible = true;
                                    div_gov_tri_txt.Visible = true;
                                    // div_sdc_tri.Visible = true;
                                    txt_gov_tri_name.Text = dt3.Rows[0]["AAG_T"].ToString();
                                    txt_gov_tri_extent.Text = dt3.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt3.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_gov_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt3.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_gov_tri_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }

                            }
                            if (dt3.Rows[0]["AAG_GOVT"].ToString() != "")
                            {

                                rbtn_gov_gov.Checked = true;

                                if (rbtn_gov_gov.Checked == true)
                                {
                                    div_gov_partially.Visible = true;

                                    rbtn_gov_gov.Visible = true;
                                    div_gov_gov_txt.Visible = true;
                                    txt_gov_gov_name.Text = dt3.Rows[0]["AAG_GOVT"].ToString();
                                    txt_gov_gov_extent.Text = dt3.Rows[0]["AAG_EXTENT_NT"].ToString();
                                    if ((dt3.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt3.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }




                        }
                        else if (rbtn_gov_orders_passed.SelectedValue == "B")
                        {

                            if (dt3.Rows[0]["AAG_NT"].ToString() != "")
                            {

                                rbtn_gov_nt.Checked = true;
                                if (rbtn_gov_nt.Checked == true)
                                {
                                    div_gov_partially.Visible = true;
                                    rbtn_gov_nt.Visible = true; ;
                                    div_gov_nt_txt.Visible = true;
                                    txt_gov_nt_name.Text = dt3.Rows[0]["AAG_NT"].ToString();
                                    txt_gov_nt_extent.Text = dt3.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }

                            }
                            else if (dt.Rows[0]["AAG_T"].ToString() != "")
                            {

                                rbtn_gov_tri.Checked = true;

                                if (rbtn_gov_tri.Checked == true)
                                {
                                    div_gov_partially.Visible = true;
                                    div_gov_tri.Visible = true;
                                    rbtn_gov_tri.Visible = true;
                                    div_gov_tri_txt.Visible = true;
                                    txt_gov_tri_name.Text = dt3.Rows[0]["AAG_T"].ToString();
                                    txt_gov_tri_extent.Text = dt3.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt3.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_gov_tri_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt3.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_gov_tri_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }
                            else if (dt3.Rows[0]["AAG_GOVT"].ToString() != "")
                            {



                                rbtn_gov_gov.Checked = true;
                                if (rbtn_gov_gov.Checked == true)
                                {
                                    div_gov_partially.Visible = true;
                                    rbtn_gov_gov.Visible = true;
                                    div_gov_gov.Visible = true;
                                    txt_gov_gov_name.Text = dt3.Rows[0]["AAG_GOVT"].ToString();
                                    txt_gov_gov_extent.Text = dt3.Rows[0]["AAG_EXTENT_GOVT"].ToString();
                                    if ((dt3.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_gov_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt3.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_gov_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }

                        }


                    }
                }

                //highcourt
                if (dt4.Rows.Count > 0)
                {
                    if ((dt4.Rows[0]["STATUS1"].ToString()) == "4")
                    {

                        txt_wpno.Text = dt4.Rows[0]["AAG_CMA_NO"].ToString();
                        txt_hc_dt_orders.Text = dt4.Rows[0]["CMADATE_OF_ORDERS"].ToString();
                        txt_hc_remarks.Text = dt4.Rows[0]["AAG_REMARKS"].ToString();
                        txt_hc_disposal.Text = dt4.Rows[0]["HC_DATE_DISPOSAL"].ToString();
                        txt_wp_mpno.Text = dt4.Rows[0]["HC_WP_MP_NO"].ToString();
                        if ((dt4.Rows[0]["case_status"].ToString()) == "PENDING")

                        {
                            ddl_hc_status.DataSource = dt4.DefaultView.ToTable(true, "case_status");
                            ddl_hc_status.DataTextField = "case_status";
                            ddl_hc_status.DataValueField = "case_status";
                            ddl_hc_status.DataBind();
                        }
                        else if ((dt4.Rows[0]["case_status"].ToString()) == "DISPOSED")
                        {
                            ddl_hc_status.DataSource = dt4.DefaultView.ToTable(true, "case_status");
                            ddl_hc_status.DataTextField = "case_status";
                            ddl_hc_status.DataValueField = "case_status";
                            ddl_hc_status.DataBind();
                        }

                        if ((dt4.Rows[0]["HC_WPMP_STATUS"].ToString()) == "STAY")

                        {
                            ddl_wpno_status.DataSource = dt4.DefaultView.ToTable(true, "HC_WPMP_STATUS");
                            ddl_wpno_status.DataTextField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataValueField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataBind();
                        }
                        else if ((dt4.Rows[0]["HC_WPMP_STATUS"].ToString()) == "INTERM SUSPENSION")
                        {
                            ddl_wpno_status.DataSource = dt4.DefaultView.ToTable(true, "HC_WPMP_STATUS");
                            ddl_wpno_status.DataTextField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataValueField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataBind();
                        }
                        else if ((dt4.Rows[0]["HC_WPMP_STATUS"].ToString()) == "STATUSCO")
                        {
                            ddl_wpno_status.DataSource = dt4.DefaultView.ToTable(true, "HC_WPMP_STATUS");
                            ddl_wpno_status.DataTextField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataValueField = "HC_WPMP_STATUS";
                            ddl_wpno_status.DataBind();
                        }
                        if ((dt4.Rows[0]["AAG_LEVEL"].ToString()) == "ALLOWED")

                        {

                            ddl_hc.DataSource = dt4.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_hc.DataTextField = "AAG_LEVEL";
                            ddl_hc.DataValueField = "AAG_LEVEL";
                            ddl_hc.DataBind();
                            if (ddl_hc.SelectedItem.Text == "ALLOWED")
                            {
                                div_hc_option.Visible = true;
                                rbtn_hc_disallowed.Visible = false;
                                rbtn_hc_remanded.Visible = false;
                                rbtn_hc_orders_passed.Visible = true;
                                div_hc_allowed.Visible = true;
                                if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Partially")
                                {


                                    rbtn_hc_orders_passed.Items.FindByValue("A").Selected = true;


                                }
                                else if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Fully")
                                {


                                    rbtn_hc_orders_passed.Items.FindByValue("B").Selected = true;


                                }
                            }
                        }
                        else if ((dt4.Rows[0]["AAG_LEVEL"].ToString()) == "DISALLOWED")

                        {
                            ddl_hc.DataSource = dt4.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_hc.DataTextField = "AAG_LEVEL";
                            ddl_hc.DataValueField = "AAG_LEVEL";
                            ddl_hc.DataBind();

                            //if (ddl_hc.SelectedItem.Text == "DISALLOWED")
                            //{
                            //    div_hc_option.Visible = true;
                            //    div_hc_allowed.Visible = false;
                            //    div_hc_disallowed.Visible = true;
                            //    rbtn_hc_disallowed.Visible = true;
                            //    div_hc_remanded.Visible = false;
                            //    div_high_court_partially.Visible = false;






                            //    if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "On Full trial")
                            //    {
                            //        rbtn_hc_disallowed.Items.FindByValue("A").Selected = true;
                            //    }
                            //    else if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Resjudicated/Dropped")
                            //    {
                            //        rbtn_hc_disallowed.Items.FindByValue("B").Selected = true;
                            //    }
                            //}
                        }

                        else if ((dt4.Rows[0]["AAG_LEVEL"].ToString()) == "REMANDED")

                        {
                            ddl_hc.DataSource = dt4.DefaultView.ToTable(true, "AAG_LEVEL");
                            ddl_hc.DataTextField = "AAG_LEVEL";
                            ddl_hc.DataValueField = "AAG_LEVEL";
                            ddl_hc.DataBind();


                            if (ddl_hc.SelectedItem.Text == "REMANDED")
                            {
                                div_hc_option.Visible = true;

                                div_high_court_partially.Visible = false;

                                div_hc_disallowed.Visible = false;
                                div_hc_remanded.Visible = true;
                                div_hc_allowed.Visible = false;

                                if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Additional Agent")
                                {
                                    rbtn_hc_remanded.Items.FindByValue("A").Selected = true;
                                }
                                else if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Agent to Government")
                                {
                                    rbtn_hc_remanded.Items.FindByValue("B").Selected = true;
                                }
                                else if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "Government")
                                {
                                    rbtn_hc_remanded.Items.FindByValue("C").Selected = true;
                                }
                                else if ((dt4.Rows[0]["AAG_ORDERS_PASSED"].ToString()) == "SDC")
                                {
                                    rbtn_hc_remanded.Items.FindByValue("D").Selected = true;
                                }
                            }


                        }
                        if (rbtn_hc_orders_passed.SelectedValue == "A")
                        {
                            if ((dt4.Rows[0]["AAG_NT"].ToString()) != "")
                            {

                                rbtn_hc_nt.Checked = true;
                                if (rbtn_hc_nt.Checked == true)
                                {
                                    rbtn_hc_nt.Visible = true;
                                    div_high_court_partially.Visible = true;
                                    div_hc_nt_txt.Visible = true;

                                    txt_hc_nt_name.Text = dt4.Rows[0]["AAG_NT"].ToString();
                                    txt_hc_nt_extent.Text = dt4.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }
                            }
                            if (dt4.Rows[0]["AAG_T"].ToString() != "")
                            {
                                rbtn_hc_tri.Checked = true;
                                if (rbtn_hc_tri.Checked == true)
                                {
                                    div_hc_tri_txt.Visible = true;
                                    rbtn_hc_tri.Visible = true;
                                    // div_sdc_tri.Visible = true;
                                    txt_hc_tri_name.Text = dt4.Rows[0]["AAG_T"].ToString();
                                    txt_hc_tri_extent.Text = dt4.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt4.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_hc_tri_orders_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt4.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_hc_tri_orders_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }

                            }
                            if (dt4.Rows[0]["AAG_GOVT"].ToString() != "")
                            {

                                rbtn_hc_gov.Checked = true;

                                if (rbtn_hc_gov.Checked == true)
                                {
                                    div_hc_gov.Visible = true;
                                    rbtn_hc_gov.Visible = true;
                                    div_hc_gov_txt.Visible = true;
                                    txt_hc_gov_name.Text = dt4.Rows[0]["AAG_GOVT"].ToString();
                                    txt_hc_gov_extent.Text = dt4.Rows[0]["AAG_EXTENT_NT"].ToString();
                                    if ((dt4.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_hc_orders_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt4.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_hc_orders_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }




                        }
                        else if (rbtn_hc_orders_passed.SelectedValue == "B")
                        {

                            if (dt4.Rows[0]["AAG_NT"].ToString() != "")
                            {

                                rbtn_hc_nt.Checked = true;
                                if (rbtn_hc_nt.Checked == true)
                                {

                                    div_high_court_partially.Visible = true;
                                    div_hc_nt_txt.Visible = true;
                                    rbtn_hc_nt.Visible = true;
                                    txt_hc_nt_name.Text = dt4.Rows[0]["AAG_NT"].ToString();
                                    txt_hc_nt_extent.Text = dt4.Rows[0]["AAG_EXTENT_NT"].ToString();
                                }

                            }
                            else if (dt4.Rows[0]["AAG_T"].ToString() != "")
                            {
                                rbtn_hc_tri.Checked = true;

                                if (rbtn_hc_tri.Checked == true)
                                {
                                    div_high_court_partially.Visible = true;

                                    rbtn_hc_tri.Visible = true;
                                    div_hc_tri.Visible = true;
                                    div_hc_tri_txt.Visible = true;
                                    txt_hc_tri_name.Text = dt4.Rows[0]["AAG_T"].ToString();
                                    txt_hc_tri_extent.Text = dt4.Rows[0]["AAG_EXTENT_T"].ToString();
                                    if ((dt4.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_hc_tri_orders_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt4.Rows[0]["AAG_T_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_hc_tri_orders_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }
                            else if (dt4.Rows[0]["AAG_GOVT"].ToString() != "")
                            {


                                rbtn_hc_gov.Checked = true;
                                if (rbtn_hc_gov.Checked == true)
                                {
                                    div_high_court_partially.Visible = true;
                                    rbtn_hc_gov.Visible = true;
                                    div_hc_gov.Visible = true;
                                    txt_hc_gov_name.Text = dt4.Rows[0]["AAG_GOVT"].ToString();
                                    txt_hc_gov_extent.Text = dt4.Rows[0]["AAG_EXTENT_GOVT"].ToString();
                                    if ((dt4.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Orders Implemented")
                                    {
                                        rbtn_hc_orders_impl.Items.FindByValue("A").Selected = true;
                                    }
                                    else if ((dt4.Rows[0]["AAG_G_ORDERS_IMPLEMENT"].ToString()) == "Available for Implementation")
                                    {
                                        rbtn_hc_orders_impl.Items.FindByValue("B").Selected = true;
                                    }
                                }
                            }

                        }


                    }
                }




                //txt_ac_cts.Text = dt.Rows[0]["DETAILS_OF_LAND_AC_CTS"].ToString();
                //txt_hec.Text = dt.Rows[0]["DETAILS_OF_LAND_HEC_A"].ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Bindrdo_docs()
        {
            string ltrid = (string)Session["updateId"];


            DataTable dt = Landsettlementpattas.GetRdoDocuments(ltrid);
            if (dt.Rows.Count > 0)
            {
                gvFiles.Visible = true;
                gvFiles.DataSource = dt;
                gvFiles.DataBind();
            }
            else
            {
                gvFiles.Visible = false;
            }
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            gvFiles.EditIndex = -1;
            Bindrdo_docs();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            gvFiles.EditIndex = e.NewEditIndex;
            Bindrdo_docs();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string Id = btn.CommandArgument;
                Session["Id"] = Id;

                Label lblFile = (Label)btn.FindControl("lblFile");
                if (lblFile != null)
                    Session["fname"] = lblFile.Text;

                string url = "View_Land_Files.aspx";

                // Use ScriptManager to register the popup script correctly
                string script = "window.open('" + url + "', '_blank', 'width=1350,height=660,resizable=yes,scrollbars=yes');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('Error opening page!');", true);

                ProjectRofrBAL.GetMasterDetails.ErrorEntry(
                    ex,
                    this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Session["username"]?.ToString(),
                    HttpContext.Current.Request.UserHostAddress
                );
            }
        }

        //protected void Linkview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //System.Threading.Thread.Sleep(5000);


        //        LinkButton btn = (LinkButton)(sender);
        //        string Id = btn.CommandArgument;
        //        Session["Id"] = Id;
        //        string url = "View_Land_Files.aspx";
        //        Session["fname"] = (btn.FindControl("lblFile") as Label).Text;

        //        string s = "window.open('" + url + "', 'popup_window', 'width=1350,height=660,resizable=yes');";
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        protected void cal_date_orders_SelectionChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            dtp_input2.Text = cal_date_orders.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders1_SelectionChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            txt_add_dt_orders.Text = cal_date_orders1.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders2_SelectionChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            txt_agent_dt_orders.Text = cal_date_orders2.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders3_SelectionChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            txt_gov_dt_orders.Text = cal_date_orders3.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }

        protected void cal_date_orders4_SelectionChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            txt_hc_dt_orders.Text = cal_date_orders4.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }

        protected void rbtn_add_disallowed_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "VIEW_LTR.aspx")
            {
                Session["event_controle"] = "addp";
                if (ddl_add.SelectedValue == "B")
                {
                    if (rbtn_add_disallowed.SelectedValue == "A" || rbtn_add_disallowed.SelectedValue == "B")
                    {
                        div_add_partially.Visible = false;
                        // div_add_passed.Visible = false;
                        div_add_disallowed.Visible = false;
                        div_add_remanded.Visible = false;
                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (ddl_add.SelectedValue == "B")
                {
                    if (rbtn_add_disallowed.SelectedValue == "A" || rbtn_add_disallowed.SelectedValue == "B")
                    {
                        div_add_partially.Visible = false;
                        //div_add_passed.Visible = false;
                        div_add_disallowed.Visible = true;
                        div_add_remanded.Visible = false;
                    }
                }
            }
        }

        protected void rbtn_add_remanded_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "VIEW_LTR.aspx")
            {
                Session["event_controle"] = "addp";
                if (ddl_add.SelectedValue == "C")
                {
                    if (rbtn_add_remanded.SelectedValue == "A" || rbtn_add_remanded.SelectedValue == "B" || rbtn_add_remanded.SelectedValue == "C" || rbtn_add_remanded.SelectedValue == "D")
                    {
                        div_add_partially.Visible = false;
                        // div_add_passed.Visible = false;
                        div_add_disallowed.Visible = false;
                        div_add_remanded.Visible = true;
                    }
                }
            }
            else
            {
                Session["event_controle"] = "chk";
                if (ddl_add.SelectedValue == "C")
                {
                    if (rbtn_add_remanded.SelectedValue == "A" || rbtn_add_remanded.SelectedValue == "B" || rbtn_add_remanded.SelectedValue == "C" || rbtn_add_remanded.SelectedValue == "D")
                    {
                        div_add_partially.Visible = false;
                        // div_add_passed.Visible = false;
                        div_add_disallowed.Visible = false;
                        div_add_remanded.Visible = true;
                    }
                }
            }
        }

        protected void rbtn_sdc_disallowed_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            Session["event_controle"] = "sdc";
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            AntiForgery.Validate();
            if ((string)(Session["CurrentPage"]) == "VIEW_LTR.aspx")
            {
                Response.Redirect("VIEW_LTR.aspx");
            }
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if ((string)(Session["CurrentPage"]) == "VIEW_LTR.aspx")
            {
                Session["event_controle"] = "sdc";
                //div_high_court.Visible = true;

                ddl_sdc.Items.Clear();
                ddl_sdc.Items.Insert(0, new ListItem("Select", "0"));
                ddl_sdc.Items.Insert(1, new ListItem("ALLOWED", "ALLOWED"));
                ddl_sdc.Items.Insert(2, new ListItem("DISALLOWED", "DISALLOWED"));
                ddl_sdc_status.Items.Clear();
                ddl_sdc_status.Items.Insert(0, new ListItem("SELECT", "0"));
                ddl_sdc_status.Items.Insert(1, new ListItem("PENDING", "PENDING"));
                ddl_sdc_status.Items.Insert(2, new ListItem("DISPOSED", "DISPOSED"));
                div_sdc.Visible = false;
                div_sdc_partially.Visible = false;
                rbtn_sdc_disallowed.ClearSelection();
            }


        }


        protected void btn_sdc_upload_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = "usdc";

            string ltrid = Session["getltrid"] as string;
            if (string.IsNullOrEmpty(ltrid))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('LTR ID is missing!');", true);
                return;
            }

            DataTable dtUploadFiles = new DataTable();
            dtUploadFiles.Columns.Add("Option1");
            dtUploadFiles.Columns.Add("Option2");
            dtUploadFiles.Columns.Add("Option3");
            dtUploadFiles.Columns.Add("Option4");
            dtUploadFiles.Columns.Add("Option5");

            if (File_sdc.HasFiles)
            {
                try
                {
                    foreach (HttpPostedFile postfile in File_sdc.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfile.FileName).ToLower();

                        if (filetype == ".pdf" || filetype == ".jpg" || filetype == ".jpeg")
                        {
                            string serverfolder = Server.MapPath(
                                $"~/LandSettlementPattas/{DateTime.Now:dd-MM-yyyy}/SDC/{ltrid}/");

                            if (!Directory.Exists(serverfolder))
                                Directory.CreateDirectory(serverfolder);

                            string serverpath = Path.Combine(serverfolder, Path.GetFileName(postfile.FileName));

                            postfile.SaveAs(serverpath);

                            DataRow dr = dtUploadFiles.NewRow();
                            dr["Option1"] = ltrid;
                            dr["Option2"] = serverfolder;
                            dr["Option3"] = postfile.FileName;
                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr["Option5"] = "SDC";

                            dtUploadFiles.Rows.Add(dr);
                        }
                    }

                    // Save all uploaded file info in Session after loop
                    Session["sdcfile"] = dtUploadFiles;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        "alert('Files uploaded successfully!');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        $"alert('Error uploading files: {ex.Message}');", true);

                    // Optional: Log error
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex,
                        this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                        Session["username"]?.ToString(),
                        HttpContext.Current.Request.UserHostAddress);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('No files selected.');", true);
            }
        }

        //protected void btn_sdc_upload_Click(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(5000);
        //    //AntiForgery.Validate();
        //    //string ltrid = Session["getltrid"] as string;
        //    //if (string.IsNullOrEmpty(ltrid))
        //    //{
        //    //    // Log or alert
        //    //    return;
        //    //}
        //    Session["event_controle"] = "usdc";
        //    DataTable dtUploadFiles = new DataTable();
        //    dtUploadFiles.Columns.Add("Option1");
        //    dtUploadFiles.Columns.Add("Option2");
        //    dtUploadFiles.Columns.Add("Option3");
        //    dtUploadFiles.Columns.Add("Option4");
        //    dtUploadFiles.Columns.Add("Option5");
        //    dtUploadFiles.Columns.Add("Option6");
        //    dtUploadFiles.Columns.Add("Option7");
        //    if (File_sdc.HasFiles == true)
        //    {
        //        try
        //        {
        //            foreach (HttpPostedFile postfiles in File_sdc.PostedFiles)
        //            {
        //                //Get The File Extension  
        //                string filetype = Path.GetExtension(postfiles.FileName);
        //                if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
        //                {

        //                    double filesize = postfiles.ContentLength;

        //                    string serverfolder = string.Empty;
        //                    string serverpath = string.Empty;

        //                    switch (filetype)
        //                    {
        //                        case ".pdf":
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "SDC" + "/" + (string)Session["getltrid"] + "/");



        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                // create Folder  
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            //string[] files = Directory.GetFiles(serverfolder);
        //                            //foreach (string file in files)
        //                            //{
        //                            //    File.Delete(file);

        //                            //}

        //                            if (postfiles.ContentLength == filesize)
        //                            {

        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }

        //                            break;
        //                        case ".jpg":
        //                        case ".jpeg":
        //                            // serverfolder = Server.MapPath(@"uplaodfiles\document\");
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "SDC" + "/" + (string)Session["getltrid"] + "/");

        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {


        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }
        //                            //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
        //                            break;

        //                    }


        //                    DataRow dr = dtUploadFiles.NewRow();
        //                    dr["Option1"] = (string)Session["getltrid"];
        //                    dr["Option2"] = serverfolder;
        //                    dr["Option3"] = postfiles.FileName;
        //                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
        //                    dr["Option5"] = "SDC";
        //                    dtUploadFiles.Rows.Add(dr);
        //                    Session["sdcfile"] = dtUploadFiles;
        //                }



        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('SDC Documents Location Created Error !')", true);
        //            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

        //        }

        //    }
        //}

        protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (ddl_village.SelectedItem.Text != "Select")
                {
                    DataTable dtltrid = ProjectRofrBAL.GetMasterDetails.Getltrid(ddl_itda.SelectedItem.Text, ddl_district.SelectedValue);
                    if (dtltrid.Rows.Count > 0 && dtltrid != null)
                    {
                        Session["getltrid"] = dtltrid.Rows[0]["LTR_ID"].ToString();
                    }

                    DataTable dthab = Landsettlementpattas.GetMasters((string)(Session["username"]), "Habitation", ddl_itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);


                    if (dthab.Rows.Count > 0)
                    {
                        BindHab(dthab);
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


        protected void btn_rdo_upload_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = "uadd";

            string ltrid = Session["getltrid"] as string;
            if (string.IsNullOrEmpty(ltrid))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('LTR ID is missing!');", true);
                return;
            }

            DataTable dtUploadFiles = new DataTable();
            dtUploadFiles.Columns.Add("Option1");
            dtUploadFiles.Columns.Add("Option2");
            dtUploadFiles.Columns.Add("Option3");
            dtUploadFiles.Columns.Add("Option4");
            dtUploadFiles.Columns.Add("Option5");

            if (File_rdo_doc.HasFiles)
            {
                try
                {
                    foreach (HttpPostedFile postfile in File_rdo_doc.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfile.FileName).ToLower();

                        if (filetype == ".pdf" || filetype == ".jpg" || filetype == ".jpeg")
                        {
                            string serverfolder = Server.MapPath(
                                $"~/LandSettlementPattas/{DateTime.Now:dd-MM-yyyy}/RDO/{ltrid}/");

                            if (!Directory.Exists(serverfolder))
                                Directory.CreateDirectory(serverfolder);

                            string serverpath = Path.Combine(serverfolder, Path.GetFileName(postfile.FileName));

                            postfile.SaveAs(serverpath);

                            DataRow dr = dtUploadFiles.NewRow();
                            dr["Option1"] = ltrid;
                            dr["Option2"] = serverfolder;
                            dr["Option3"] = postfile.FileName;
                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr["Option5"] = "RDO";

                            dtUploadFiles.Rows.Add(dr);
                        }
                    }

                    // Save all uploaded file info in Session after loop
                    Session["rdofile"] = dtUploadFiles;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        "alert('Files uploaded successfully!');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        $"alert('Error uploading files: {ex.Message}');", true);

                    // Optional: Log error
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex,
                        this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                        Session["username"]?.ToString(),
                        HttpContext.Current.Request.UserHostAddress);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('No files selected.');", true);
            }
        }


        //protected void btn_rdo_upload_Click(object sender, EventArgs e)
        //{
        //    // System.Threading.Thread.Sleep(5000);
        //    // AntiForgery.Validate();

        //    string ltrid = Session["getltrid"] as string;
        //    if (string.IsNullOrEmpty(ltrid))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
        //            "alert('LTR ID is missing!');", true);
        //        return;
        //    }
        //    Session["event_controle"] = "uadd";

        //    DataTable dtUploadFiles = new DataTable();
        //    dtUploadFiles.Columns.Add("Option1");
        //    dtUploadFiles.Columns.Add("Option2");
        //    dtUploadFiles.Columns.Add("Option3");
        //    dtUploadFiles.Columns.Add("Option4");
        //    dtUploadFiles.Columns.Add("Option5");
        //    dtUploadFiles.Columns.Add("Option6");
        //    dtUploadFiles.Columns.Add("Option7");
        //    if (File_rdo_doc.HasFiles)
        //    {
        //        try
        //        {
        //            foreach (HttpPostedFile postfiles in File_rdo_doc.PostedFiles)
        //            {
        //                //Get The File Extension  
        //                string filetype = Path.GetExtension(postfiles.FileName);
        //                if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
        //                {

        //                    double filesize = postfiles.ContentLength;

        //                    string serverfolder = string.Empty;
        //                    string serverpath = string.Empty;

        //                    switch (filetype)
        //                    {
        //                        case ".pdf":
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "RDO" + "/" + (string)Session["getltrid"] + "/");



        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                // create Folder  
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {

        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }

        //                            break;
        //                        case ".jpg":
        //                        case ".jpeg":
        //                            // serverfolder = Server.MapPath(@"uplaodfiles\document\");
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "RDO" + "/" + (string)Session["getltrid"] + "/");

        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {


        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }
        //                            //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
        //                            break;

        //                    }
        //                    DataRow dr = dtUploadFiles.NewRow();
        //                    dr["Option1"] = (string)Session["getltrid"];
        //                    dr["Option2"] = serverfolder;
        //                    dr["Option3"] = postfiles.FileName;
        //                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
        //                    dr["Option5"] = "RDO";
        //                    dtUploadFiles.Rows.Add(dr);
        //                    Session["rdofile"] = dtUploadFiles;
        //                }




        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('RDO Documents Location Created Error !')", true);
        //            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

        //        }

        //    }
        //}

        //protected void btn_agent_upload_Click(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(5000);
        //    //AntiForgery.Validate();
        //    string ltrid = Session["getltrid"] as string;
        //    if (string.IsNullOrEmpty(ltrid))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
        //            "alert('LTR ID is missing!');", true);
        //        return;
        //    }

        //    Session["event_controle"] = "uagent";
        //    DataTable dtUploadFiles = new DataTable();
        //    dtUploadFiles.Columns.Add("Option1");
        //    dtUploadFiles.Columns.Add("Option2");
        //    dtUploadFiles.Columns.Add("Option3");
        //    dtUploadFiles.Columns.Add("Option4");
        //    dtUploadFiles.Columns.Add("Option5");
        //    dtUploadFiles.Columns.Add("Option6");
        //    dtUploadFiles.Columns.Add("Option7");
        //    if (file_collector.HasFiles == true)
        //    {
        //        try
        //        {
        //            foreach (HttpPostedFile postfiles in file_collector.PostedFiles)
        //            {
        //                //Get The File Extension  
        //                string filetype = Path.GetExtension(postfiles.FileName);
        //                if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
        //                {

        //                    double filesize = postfiles.ContentLength;

        //                    string serverfolder = string.Empty;
        //                    string serverpath = string.Empty;

        //                    switch (filetype)
        //                    {
        //                        case ".pdf":
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "POITDA" + "/" + (string)Session["getltrid"] + "/");



        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                // create Folder  
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {

        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }

        //                            break;
        //                        case ".jpg":
        //                        case ".jpeg":
        //                            // serverfolder = Server.MapPath(@"uplaodfiles\document\");
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "POITDA" + "/" + (string)Session["getltrid"] + "/");

        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {


        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }
        //                            //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
        //                            break;

        //                    }
        //                    DataRow dr = dtUploadFiles.NewRow();
        //                    dr["Option1"] = (string)Session["getltrid"];
        //                    dr["Option2"] = serverfolder;
        //                    dr["Option3"] = postfiles.FileName;
        //                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
        //                    dr["Option5"] = "POITDA";
        //                    dtUploadFiles.Rows.Add(dr);
        //                    Session["collectorfile"] = dtUploadFiles;
        //                }




        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Agent to Government Documents Location Created Error !')", true);
        //            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

        //        }

        //    }

        //}

        protected void btn_agent_upload_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = "uagent";

            string ltrid = Session["getltrid"] as string;
            if (string.IsNullOrEmpty(ltrid))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('LTR ID is missing!');", true);
                return;
            }

            DataTable dtUploadFiles = new DataTable();
            dtUploadFiles.Columns.Add("Option1");
            dtUploadFiles.Columns.Add("Option2");
            dtUploadFiles.Columns.Add("Option3");
            dtUploadFiles.Columns.Add("Option4");
            dtUploadFiles.Columns.Add("Option5");

            if (file_collector.HasFiles)
            {
                try
                {
                    foreach (HttpPostedFile postfile in file_collector.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfile.FileName).ToLower();

                        if (filetype == ".pdf" || filetype == ".jpg" || filetype == ".jpeg")
                        {
                            string serverfolder = Server.MapPath(
                                $"~/LandSettlementPattas/{DateTime.Now:dd-MM-yyyy}/POITDA/{ltrid}/");

                            if (!Directory.Exists(serverfolder))
                                Directory.CreateDirectory(serverfolder);

                            string serverpath = Path.Combine(serverfolder, Path.GetFileName(postfile.FileName));

                            postfile.SaveAs(serverpath);

                            DataRow dr = dtUploadFiles.NewRow();
                            dr["Option1"] = ltrid;
                            dr["Option2"] = serverfolder;
                            dr["Option3"] = postfile.FileName;
                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr["Option5"] = "POITDA";

                            dtUploadFiles.Rows.Add(dr);
                        }
                    }

                    // Save all uploaded file info in Session
                    Session["collectorfile"] = dtUploadFiles;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        "alert('Agent files uploaded successfully!');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        $"alert('Error uploading Agent files: {ex.Message}');", true);

                    // Optional: Log error
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex,
                        this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                        Session["username"]?.ToString(),
                        HttpContext.Current.Request.UserHostAddress);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('No files selected.');", true);
            }
        }


        //protected void btn_gov_upload_Click(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(5000);
        //    //AntiForgery.Validate();
        //    string ltrid = Session["getltrid"] as string;
        //    if (string.IsNullOrEmpty(ltrid))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
        //            "alert('LTR ID is missing!');", true);
        //        return;
        //    }
        //    Session["event_controle"] = "ugov";
        //    DataTable dtUploadFiles = new DataTable();
        //    dtUploadFiles.Columns.Add("Option1");
        //    dtUploadFiles.Columns.Add("Option2");
        //    dtUploadFiles.Columns.Add("Option3");
        //    dtUploadFiles.Columns.Add("Option4");
        //    dtUploadFiles.Columns.Add("Option5");
        //    dtUploadFiles.Columns.Add("Option6");
        //    dtUploadFiles.Columns.Add("Option7");
        //    if (File_gov.HasFiles == true)
        //    {
        //        try
        //        {
        //            foreach (HttpPostedFile postfiles in File_gov.PostedFiles)
        //            {
        //                //Get The File Extension  
        //                string filetype = Path.GetExtension(postfiles.FileName);
        //                if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
        //                {

        //                    double filesize = postfiles.ContentLength;

        //                    string serverfolder = string.Empty;
        //                    string serverpath = string.Empty;

        //                    switch (filetype)
        //                    {
        //                        case ".pdf":
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "Government" + "/" + (string)Session["getltrid"] + "/");



        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                // create Folder  
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {

        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }

        //                            break;
        //                        case ".jpg":
        //                        case ".jpeg":
        //                            // serverfolder = Server.MapPath(@"uplaodfiles\document\");
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "Government" + "/" + (string)Session["getltrid"] + "/");

        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {


        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }
        //                            //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
        //                            break;

        //                    }
        //                    DataRow dr = dtUploadFiles.NewRow();
        //                    dr["Option1"] = (string)Session["getltrid"];
        //                    dr["Option2"] = serverfolder;
        //                    dr["Option3"] = postfiles.FileName;
        //                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
        //                    dr["Option5"] = "Government";
        //                    dtUploadFiles.Rows.Add(dr);
        //                    Session["govfile"] = dtUploadFiles;
        //                }




        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Government Documents Location Created Error !')", true);
        //            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

        //        }

        //    }
        //}


        protected void btn_gov_upload_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = "ugov";

            string ltrid = Session["getltrid"] as string;
            if (string.IsNullOrEmpty(ltrid))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('LTR ID is missing!');", true);
                return;
            }

            DataTable dtUploadFiles = new DataTable();
            dtUploadFiles.Columns.Add("Option1");
            dtUploadFiles.Columns.Add("Option2");
            dtUploadFiles.Columns.Add("Option3");
            dtUploadFiles.Columns.Add("Option4");
            dtUploadFiles.Columns.Add("Option5");

            if (File_gov.HasFiles)
            {
                try
                {
                    foreach (HttpPostedFile postfile in File_gov.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfile.FileName).ToLower();

                        if (filetype == ".pdf" || filetype == ".jpg" || filetype == ".jpeg")
                        {
                            string serverfolder = Server.MapPath(
                                $"~/LandSettlementPattas/{DateTime.Now:dd-MM-yyyy}/Government/{ltrid}/");

                            if (!Directory.Exists(serverfolder))
                                Directory.CreateDirectory(serverfolder);

                            string serverpath = Path.Combine(serverfolder, Path.GetFileName(postfile.FileName));

                            postfile.SaveAs(serverpath);

                            DataRow dr = dtUploadFiles.NewRow();
                            dr["Option1"] = ltrid;
                            dr["Option2"] = serverfolder;
                            dr["Option3"] = postfile.FileName;
                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr["Option5"] = "Government";

                            dtUploadFiles.Rows.Add(dr);
                        }
                    }

                    // Save all uploaded file info in Session
                    Session["govfile"] = dtUploadFiles;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        "alert('Government files uploaded successfully!');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        $"alert('Error uploading Government files: {ex.Message}');", true);

                    // Optional: Log error
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex,
                        this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                        Session["username"]?.ToString(),
                        HttpContext.Current.Request.UserHostAddress);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('No files selected.');", true);
            }
        }


        //protected void btn_high_upload_Click(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(5000);
        //    //AntiForgery.Validate();
        //    string ltrid = Session["getltrid"] as string;
        //    if (string.IsNullOrEmpty(ltrid))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
        //            "alert('LTR ID is missing!');", true);
        //        return;
        //    }
        //    Session["event_controle"] = "uhc";
        //    DataTable dtUploadFiles = new DataTable();
        //    dtUploadFiles.Columns.Add("Option1");
        //    dtUploadFiles.Columns.Add("Option2");
        //    dtUploadFiles.Columns.Add("Option3");
        //    dtUploadFiles.Columns.Add("Option4");
        //    dtUploadFiles.Columns.Add("Option5");
        //    dtUploadFiles.Columns.Add("Option6");
        //    dtUploadFiles.Columns.Add("Option7");

        //    if (File_highcourt.HasFiles == true)
        //    {
        //        try
        //        {
        //            foreach (HttpPostedFile postfiles in File_highcourt.PostedFiles)
        //            {
        //                //Get The File Extension  
        //                string filetype = Path.GetExtension(postfiles.FileName);
        //                if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
        //                {

        //                    double filesize = postfiles.ContentLength;

        //                    string serverfolder = string.Empty;
        //                    string serverpath = string.Empty;

        //                    switch (filetype)
        //                    {
        //                        case ".pdf":
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "HIGHCOURT" + "/" + (string)Session["getltrid"] + "/");



        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                // create Folder  
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {

        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }

        //                            break;
        //                        case ".jpg":
        //                        case ".jpeg":
        //                            // serverfolder = Server.MapPath(@"uplaodfiles\document\");
        //                            serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "HIGHCOURT" + "/" + (string)Session["getltrid"] + "/");

        //                            if (!Directory.Exists(serverfolder))
        //                            {
        //                                Directory.CreateDirectory(serverfolder);
        //                            }
        //                            if (postfiles.ContentLength == filesize)
        //                            {


        //                                serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
        //                                postfiles.SaveAs(serverpath);
        //                            }
        //                            //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
        //                            break;

        //                    }
        //                    DataRow dr = dtUploadFiles.NewRow();
        //                    dr["Option1"] = (string)Session["getltrid"];
        //                    dr["Option2"] = serverfolder;
        //                    dr["Option3"] = postfiles.FileName;
        //                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
        //                    dr["Option5"] = "HIGHCOURT";
        //                    dtUploadFiles.Rows.Add(dr);
        //                    Session["highcourtfile"] = dtUploadFiles;
        //                }




        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Highcourt Documents Location Created Error !')", true);
        //            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

        //        }

        //    }


        //}

        protected void btn_high_upload_Click(object sender, EventArgs e)
        {
            Session["event_controle"] = "uhc";

            string ltrid = Session["getltrid"] as string;
            if (string.IsNullOrEmpty(ltrid))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('LTR ID is missing!');", true);
                return;
            }

            DataTable dtUploadFiles = new DataTable();
            dtUploadFiles.Columns.Add("Option1");
            dtUploadFiles.Columns.Add("Option2");
            dtUploadFiles.Columns.Add("Option3");
            dtUploadFiles.Columns.Add("Option4");
            dtUploadFiles.Columns.Add("Option5");

            if (File_highcourt.HasFiles)
            {
                try
                {
                    foreach (HttpPostedFile postfile in File_highcourt.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfile.FileName).ToLower();

                        if (filetype == ".pdf" || filetype == ".jpg" || filetype == ".jpeg")
                        {
                            string serverfolder = Server.MapPath(
                                $"~/LandSettlementPattas/{DateTime.Now:dd-MM-yyyy}/HIGHCOURT/{ltrid}/");

                            if (!Directory.Exists(serverfolder))
                                Directory.CreateDirectory(serverfolder);

                            string serverpath = Path.Combine(serverfolder, Path.GetFileName(postfile.FileName));

                            postfile.SaveAs(serverpath);

                            DataRow dr = dtUploadFiles.NewRow();
                            dr["Option1"] = ltrid;
                            dr["Option2"] = serverfolder;
                            dr["Option3"] = postfile.FileName;
                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr["Option5"] = "HIGHCOURT";

                            dtUploadFiles.Rows.Add(dr);
                        }
                    }

                    // Save all uploaded file info in Session
                    Session["highcourtfile"] = dtUploadFiles;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        "alert('High Court files uploaded successfully!');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                        $"alert('Error uploading High Court files: {ex.Message}');", true);

                    // Optional: Log error
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex,
                        this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name,
                        Session["username"]?.ToString(),
                        HttpContext.Current.Request.UserHostAddress);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage",
                    "alert('No files selected.');", true);
            }
        }



        protected void ddl_hab_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }

        public void MandatoryFields()
        {
            //    try

            //    {
            //        if (ddl_sdc.SelectedItem.Text == "ALLOWED")
            //        {
            //            if (rbtn_sdc_orders_passed.SelectedIndex == -1)
            //            {
            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please select an option at orders passed in whose favour in SDC Level !')", true);

            //            }
            //            if (rbtn_sdc_orders_passed.SelectedIndex != -1)
            //            {
            //                if ()
            //        }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Highcourt Documents Location Created Error !')", true);
            //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

            //    }

        }

    }
}