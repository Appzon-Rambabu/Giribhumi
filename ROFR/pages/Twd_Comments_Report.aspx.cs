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

namespace ROFR.pages
{
    public partial class Twd_Comments_Report : System.Web.UI.Page
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
               
               
                    obj.Type = "1";
                    
                    dt = hc.TWD_COMMENTS_REPORT_SP(obj);
             

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
                        LinkButton Link_L1ACRE = (LinkButton)item.FindControl("Link_L1ACRE");
                        Label L_L1ACRE = (Label)item.FindControl("L_L1ACRE");
                        LinkButton Link_NOLAND = (LinkButton)item.FindControl("Link_NOLAND");
                        Label L_NOLAND = (Label)item.FindControl("L_NOLAND");
                        LinkButton Link_P_L1ACRE = (LinkButton)item.FindControl("Link_P_L1ACRE");
                        Label P_L1ACRE = (Label)item.FindControl("P_L1ACRE");
                        LinkButton Link_P_NOLAND = (LinkButton)item.FindControl("Link_P_NOLAND");
                        Label P_NOLAND = (Label)item.FindControl("P_NOLAND");
                        if (lblitda.Text == "Total")
                        {
                            lbl_sno.Text = "";
                            lblitda.Visible = false;
                            itda.Visible = true;
                            L_L1ACRE.Visible = true;
                            Link_L1ACRE.Visible = false;
                            L_NOLAND.Visible = true;
                            Link_NOLAND.Visible = false;
                            P_L1ACRE.Visible = true;
                            Link_P_L1ACRE.Visible = false;
                            P_NOLAND.Visible = true;
                            Link_P_NOLAND.Visible = false;
                        }
                        if(L_L1ACRE.Text=="0")
                        {
                            L_L1ACRE.Visible = true;
                            Link_L1ACRE.Visible = false;
                        }
                        if (L_NOLAND.Text == "0")
                        {
                            L_NOLAND.Visible = true;
                            Link_NOLAND.Visible = false;
                        }
                        if (P_L1ACRE.Text == "0")
                        {
                            P_L1ACRE.Visible = true;
                            Link_P_L1ACRE.Visible = false;
                        }
                        if (P_NOLAND.Text == "0")
                        {
                            P_NOLAND.Visible = true;
                            Link_P_NOLAND.Visible = false;
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
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itdaa = e.Item.FindControl("lbl_itdaa") as Label;
                Label status = e.Item.FindControl("status") as Label;
                lbl_itdaa.Text= "Itda: "+(string)Session["Itda"];
                status.Text =  (string)Session["end"];
            }
        }
        protected void rpt2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itdaa = e.Item.FindControl("lbl_itdaa") as Label;
                Label status = e.Item.FindControl("status") as Label;
                lbl_itdaa.Text = "Mandal: " + (string)Session["Mandal"];
                status.Text = (string)Session["mend"];
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

                btn_back_dist.Visible = true;
                btn_upload.Visible = false;
                btn_notupload.Visible = true;
                if(end== "u_lacre")
                {
                    Session["end"] = "Updated : Lessthan 1 Acre";
                    Session["Type"] = "LESSTHAN ACRE";
                }
                if (end == "u_noland")
                {
                    Session["end"] = "Updated : No Land";
                    Session["Type"] = "NO_LAND";
                }
                if (end == "p_lacre")
                {
                    Session["end"] = "Pending : Lessthan 1 Acre";
                    Session["Type"] = "PENDING_LESSTHAN ACRE";
                }
                if (end == "p_noland")
                {
                    Session["end"] = "Pending : No Land";
                    Session["Type"] = "PENDING_NO_LAND";
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
                    Session["mend"] = "NoLand : No land Available";
                    Session["mType"] = "NO_LAND_NO_LAND";
                }
                if (mend == "iden_noland")
                {
                    Session["mend"] = "NoLand : Land to be Identified";
                    Session["mType"] = "NO_LAND_LANDTOBE";
                }
                if (mend == "pol_noland")
                {
                    Session["mend"] = "NoLand : Polavaram Submerged";
                    Session["mType"] = "NO_LAND_POL";
                }
                if (mend == "death_noland")
                {
                    Session["mend"] = "NoLand : Death Cases";
                    Session["mType"] = "NO_LAND_DEATH";
                }
                if (mend == "ntribes_noland")
                {
                    Session["mend"] = "NoLand : Non-Tribes";
                    Session["mType"] = "NO_LAND_NONTRIBES";
                }

                if (mend == "govt_noland")
                {
                    Session["mend"] = "NoLand : Govt Employee";
                    Session["mType"] = "NO_LAND_GOVT";
                }

                if (mend == "web_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Not updated Webland";
                    Session["mType"] = "NO_LAND_NOTWEB";
                }
                if (mend == "giri_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Not updated Giribhumi";
                    Session["mType"] = "NO_LAND_NOTGIR";
                }
                if (mend == "muta_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Mutation to be done";
                    Session["mType"] = "NO_LAND_MUT";
                }
                if (mend == "notde_noland")
                {
                    Session["mend"] = "NoLand : Not dependent on cultivation";
                    Session["mType"] = "NO_LAND_CUL";
                }
                if (mend == "mig_noland")
                {
                    Session["mend"] = "NoLand : Migrated";
                    Session["mType"] = "NO_LAND_MIG";
                }



                if (mend == "noland_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : No land Available";
                    Session["mType"] = "LESS1_NO_LAND";
                }
                if (mend == "landiden_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Land to be Identified";
                    Session["mType"] = "LESS1_LANDTOBE";
                }
                if (mend == "pol_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Polavaram Submerged";
                    Session["mType"] = "LESS1_POL";
                }
                if (mend == "death_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Death Cases";
                    Session["mType"] = "LESS1_DEATH";
                }
                if (mend == "nontribes_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Non-Tribes";
                    Session["mType"] = "LESS1_NONTRIBES";
                }

                if (mend == "gov_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Govt Employee";
                    Session["mType"] = "LESS1_GOVT";
                }

                if (mend == "web_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Not updated Webland";
                    Session["mType"] = "LESS1_NOTWEB";
                }
                if (mend == "giri_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Not updated Giribhumi";
                    Session["mType"] = "LESS1_NOTGIR";
                }
                if (mend == "mut_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Mutation to be done";
                    Session["mType"] = "LESS1_MUT";
                }
                if (mend == "notdep_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Not dependent on cultivation";
                    Session["mType"] = "LESS1_CULT";
                }
                if (mend == "mig_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Migrated";
                    Session["mType"] = "LESS1_MIG";
                }





                if (mend == "noland_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : No land Available";
                    Session["mType"] = "GREAT1_NO_LAND";
                }
                if (mend == "landiden_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Land to be Identified";
                    Session["mType"] = "GREAT1_LANDTOBE";
                }
                if (mend == "pol_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre: Polavaram Submerged";
                    Session["mType"] = "GREAT1_POL";
                }
                if (mend == "death_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre: Death Cases";
                    Session["mType"] = "GREAT1_DEATH";
                }
                if (mend == "nontribe_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Non-Tribes";
                    Session["mType"] = "GREAT1_NONTRIBES";
                }

                if (mend == "gov_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Govt Employee";
                    Session["mType"] = "GREAT1_GOVT";
                }

                if (mend == "web_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Not updated Webland";
                    Session["mType"] = "GREAT1_NOTWEB";
                }
                if (mend == "giri_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Not updated Giribhumi";
                    Session["mType"] = "GREAT1_NOTGIR";
                }
                if (mend == "mut_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Mutation to be done";
                    Session["mType"] = "GREAT1_MUT";
                }
                if (mend == "notdep_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Not dependent on cultivation";
                    Session["mType"] = "GREAT1_CUL";
                }
                if (mend == "mig_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Migrated";
                    Session["mType"] = "GREAT1_MIG";
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
                    obj.Type = "2";
                    obj.Itda= (string)Session["Itda"];

                    dt = hc.TWD_COMMENTS_REPORT_SP(obj);
                    
                }

                if (dt.Rows.Count > 0)
                {

                    rpt1.DataSource = dt;

                    rpt1.DataBind();
                    foreach (RepeaterItem item in rpt1.Items)
                    {
                        Label lbl_msno = (Label)item.FindControl("lbl_msno");
                        Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                        Label m_noland = (Label)item.FindControl("m_noland");
                        LinkButton Link_m_noland = (LinkButton)item.FindControl("Link_m_noland");

                        Label iden_noland = (Label)item.FindControl("iden_noland");
                        LinkButton Link_iden_noland = (LinkButton)item.FindControl("Link_iden_noland");

                        Label Label8 = (Label)item.FindControl("Label8");
                        LinkButton Link_pol_noland = (LinkButton)item.FindControl("Link_pol_noland");
                        Label Label9 = (Label)item.FindControl("Label9");
                        LinkButton Link_death_noland = (LinkButton)item.FindControl("Link_death_noland");
                        Label Label1 = (Label)item.FindControl("Label1");
                        LinkButton Link_ntribes_noland = (LinkButton)item.FindControl("Link_ntribes_noland");
                        Label Label10 = (Label)item.FindControl("Label10");
                        LinkButton Link_govt_noland = (LinkButton)item.FindControl("Link_govt_noland");
                        Label Label11 = (Label)item.FindControl("Label11");
                        LinkButton Link_web_noland = (LinkButton)item.FindControl("Link_web_noland");
                        Label Label12 = (Label)item.FindControl("Label12");
                        LinkButton Link_giri_noland = (LinkButton)item.FindControl("Link_giri_noland");
                        Label Label13 = (Label)item.FindControl("Label13");
                        LinkButton Link_muta_noland = (LinkButton)item.FindControl("Link_muta_noland");
                        Label Label41 = (Label)item.FindControl("Label41");
                        LinkButton Link_notde_noland = (LinkButton)item.FindControl("Link_notde_noland");
                        Label Label47 = (Label)item.FindControl("Label47");
                        LinkButton Link_mig_noland = (LinkButton)item.FindControl("Link_mig_noland");


                        Label Label14 = (Label)item.FindControl("Label14");
                        LinkButton Link_noland_l1 = (LinkButton)item.FindControl("Link_noland_l1");

                        Label Label15 = (Label)item.FindControl("Label15");
                        LinkButton Link_landiden_l1 = (LinkButton)item.FindControl("Link_landiden_l1");

                        Label Label16 = (Label)item.FindControl("Label16");
                        LinkButton Link_pol_l1 = (LinkButton)item.FindControl("Link_pol_l1");
                        Label Label17 = (Label)item.FindControl("Label17");
                        LinkButton Link_death_l1 = (LinkButton)item.FindControl("Link_death_l1");
                        Label Label18 = (Label)item.FindControl("Label18");
                        LinkButton Link_nontribes_l1 = (LinkButton)item.FindControl("Link_nontribes_l1");
                        Label Label19 = (Label)item.FindControl("Label19");
                        LinkButton Link_gov_l1 = (LinkButton)item.FindControl("Link_gov_l1");
                        Label Label20 = (Label)item.FindControl("Label20");
                        LinkButton Link_web_l1 = (LinkButton)item.FindControl("Link_web_l1");
                        Label Label21 = (Label)item.FindControl("Label21");
                        LinkButton Link_giri_l1 = (LinkButton)item.FindControl("Link_giri_l1");
                        Label Label22 = (Label)item.FindControl("Label22");
                        LinkButton Link_mut_l1 = (LinkButton)item.FindControl("Link_mut_l1");
                        Label Label42 = (Label)item.FindControl("Label42");
                        LinkButton Link_notdep_l1 = (LinkButton)item.FindControl("Link_notdep_l1");
                        Label Label48 = (Label)item.FindControl("Label48");
                        LinkButton Link_mig_l1 = (LinkButton)item.FindControl("Link_mig_l1");


                        Label Label23 = (Label)item.FindControl("Label23");
                        LinkButton Link_noland_g1 = (LinkButton)item.FindControl("Link_noland_g1");

                        Label Label24 = (Label)item.FindControl("Label24");
                        LinkButton Link_landiden_g1 = (LinkButton)item.FindControl("Link_landiden_g1");

                        Label Label25 = (Label)item.FindControl("Label25");
                        LinkButton Link_pol_g1 = (LinkButton)item.FindControl("Link_pol_g1");
                        Label Label26 = (Label)item.FindControl("Label26");
                        LinkButton Link_death_g1 = (LinkButton)item.FindControl("Link_death_g1");
                        Label Label27 = (Label)item.FindControl("Label27");
                        LinkButton Link_nontribe_g1 = (LinkButton)item.FindControl("Link_nontribe_g1");
                        Label Label28 = (Label)item.FindControl("Label28");
                        LinkButton Link_gov_g1 = (LinkButton)item.FindControl("Link_gov_g1");
                        Label Label29 = (Label)item.FindControl("Label29");
                        LinkButton Link_web_g1 = (LinkButton)item.FindControl("Link_web_g1");
                        Label Label30 = (Label)item.FindControl("Label30");
                        LinkButton Link_giri_g1 = (LinkButton)item.FindControl("Link_giri_g1");
                        Label Label31 = (Label)item.FindControl("Label31");
                        LinkButton Link_mut_g1 = (LinkButton)item.FindControl("Link_mut_g1");
                        Label Label43 = (Label)item.FindControl("Label43");
                        LinkButton Link_notdep_g1 = (LinkButton)item.FindControl("Link_notdep_g1");
                        Label Label49 = (Label)item.FindControl("Label49");
                        LinkButton Link_mig_g1 = (LinkButton)item.FindControl("Link_mig_g1");
                        if (lbl_mandal.Text == "Total")
                        {
                            lbl_msno.Text = "";
                            m_noland.Visible = true;
                            Link_m_noland.Visible = false;
                            iden_noland.Visible = true;
                            Link_iden_noland.Visible = false;
                            Label8.Visible = true;
                            Link_pol_noland.Visible = false;
                            Label9.Visible = true;
                            Link_death_noland.Visible = false;
                            Label1.Visible = true;
                            Link_ntribes_noland.Visible = false;
                            Label10.Visible = true;
                            Link_govt_noland.Visible = false;
                            Label11.Visible = true;
                            Link_web_noland.Visible = false;
                            Label12.Visible = true;
                            Link_giri_noland.Visible = false;
                            Label13.Visible = true;
                            Link_muta_noland.Visible = false;
                            Label41.Visible = true;
                            Link_notde_noland.Visible = false;
                            Label47.Visible = true;
                            Link_mig_noland.Visible = false;

                         
                                Label14.Visible = true;
                                Link_noland_l1.Visible = false;
                           
                                Label15.Visible = true;
                                Link_landiden_l1.Visible = false;
                            
                                Label16.Visible = true;
                                Link_pol_l1.Visible = false;
                            Label17.Visible = true;
                                Link_death_l1.Visible = false;
                          
                                Label18.Visible = true;
                                Link_nontribes_l1.Visible = false;
                           
                                Label19.Visible = true;
                                Link_gov_l1.Visible = false;
                           
                                Label20.Visible = true;
                                Link_web_l1.Visible = false;
                           
                                Label21.Visible = true;
                                Link_giri_l1.Visible = false;
                           
                                Label22.Visible = true;
                                Link_mut_l1.Visible = false;
                           
                                Label42.Visible = true;
                                Link_notdep_l1.Visible = false;
                        
                                Label48.Visible = true;
                                Link_mig_l1.Visible = false;

                          
                                Label23.Visible = true;
                                Link_noland_g1.Visible = false;
                           
                                Label24.Visible = true;
                                Link_landiden_g1.Visible = false;
                          
                                Label25.Visible = true;
                                Link_pol_g1.Visible = false;
                           
                                Label26.Visible = true;
                                Link_death_g1.Visible = false;
                           
                                Label27.Visible = true;
                                Link_nontribe_g1.Visible = false;
                           
                                Label28.Visible = true;
                                Link_gov_g1.Visible = false;
                           
                                Label29.Visible = true;
                                Link_web_g1.Visible = false;
                           
                                Label30.Visible = true;
                                Link_giri_g1.Visible = false;
                            
                                Label31.Visible = true;
                                Link_mut_g1.Visible = false;
                          
                                Label43.Visible = true;
                                Link_notdep_g1.Visible = false;
                           
                                Label49.Visible = true;
                                Link_mig_g1.Visible = false;
                           

                        }
                        if (m_noland.Text == "0")
                        {
                            m_noland.Visible = true;
                            Link_m_noland.Visible = false;
                        }
                        if (iden_noland.Text == "0")
                        {
                            iden_noland.Visible = true;
                            Link_iden_noland.Visible = false;
                        }
                        if (Label8.Text == "0")
                        {
                            Label8.Visible = true;
                            Link_pol_noland.Visible = false;
                        }
                        if (Label9.Text == "0")
                        {
                            Label9.Visible = true;
                            Link_death_noland.Visible = false;
                        }
                        if (Label1.Text == "0")
                        {
                            Label1.Visible = true;
                            Link_ntribes_noland.Visible = false;
                        }
                        if (Label10.Text == "0")
                        {
                            Label10.Visible = true;
                            Link_govt_noland.Visible = false;
                        }
                        if (Label11.Text == "0")
                        {
                            Label11.Visible = true;
                            Link_web_noland.Visible = false;
                        }
                        if (Label12.Text == "0")
                        {
                            Label12.Visible = true;
                            Link_giri_noland.Visible = false;
                        }
                        if (Label13.Text == "0")
                        {
                            Label13.Visible = true;
                            Link_muta_noland.Visible = false;
                        }
                        if (Label41.Text == "0")
                        {
                            Label41.Visible = true;
                            Link_notde_noland.Visible = false;
                        }
                        if (Label47.Text == "0")
                        {
                            Label47.Visible = true;
                            Link_mig_noland.Visible = false;
                        }


                        if (Label14.Text == "0")
                        {
                            Label14.Visible = true;
                            Link_noland_l1.Visible = false;
                        }
                        if (Label15.Text == "0")
                        {
                            Label15.Visible = true;
                            Link_landiden_l1.Visible = false;
                        }
                        if (Label16.Text == "0")
                        {
                            Label16.Visible = true;
                            Link_pol_l1.Visible = false;
                        }
                        if (Label17.Text == "0")
                        {
                            Label17.Visible = true;
                            Link_death_l1.Visible = false;
                        }
                        if (Label18.Text == "0")
                        {
                            Label18.Visible = true;
                            Link_nontribes_l1.Visible = false;
                        }
                        if (Label19.Text == "0")
                        {
                            Label19.Visible = true;
                            Link_gov_l1.Visible = false;
                        }
                        if (Label20.Text == "0")
                        {
                            Label20.Visible = true;
                            Link_web_l1.Visible = false;
                        }
                        if (Label21.Text == "0")
                        {
                            Label21.Visible = true;
                            Link_giri_l1.Visible = false;
                        }
                        if (Label22.Text == "0")
                        {
                            Label22.Visible = true;
                            Link_mut_l1.Visible = false;
                        }
                        if (Label42.Text == "0")
                        {
                            Label42.Visible = true;
                            Link_notdep_l1.Visible = false;
                        }
                       
                        if (Label48.Text == "0")
                        {
                            Label48.Visible = true;
                            Link_mig_l1.Visible = false;
                        }

                        if (Label23.Text == "0")
                        {
                            Label23.Visible = true;
                            Link_noland_g1.Visible = false;
                        }
                        if (Label24.Text == "0")
                        {
                            Label24.Visible = true;
                            Link_landiden_g1.Visible = false;
                        }
                        if (Label25.Text == "0")
                        {
                            Label25.Visible = true;
                            Link_pol_g1.Visible = false;
                        }
                        if (Label26.Text == "0")
                        {
                            Label26.Visible = true;
                            Link_death_g1.Visible = false;
                        }
                        if (Label27.Text == "0")
                        {
                            Label27.Visible = true;
                            Link_nontribe_g1.Visible = false;
                        }
                        if (Label28.Text == "0")
                        {
                            Label28.Visible = true;
                            Link_gov_g1.Visible = false;
                        }
                        if (Label29.Text == "0")
                        {
                            Label29.Visible = true;
                            Link_web_g1.Visible = false;
                        }
                        if (Label30.Text == "0")
                        {
                            Label30.Visible = true;
                            Link_giri_g1.Visible = false;
                        }
                        if (Label31.Text == "0")
                        {
                            Label31.Visible = true;
                            Link_mut_g1.Visible = false;
                        }
                        if (Label43.Text == "0")
                        {
                            Label43.Visible = true;
                            Link_notdep_g1.Visible = false;
                        }
                        if (Label49.Text == "0")
                        {
                            Label49.Visible = true;
                            Link_mig_g1.Visible = false;
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
                    obj.Type = (string)Session["Type"];
                    obj.Itda = (string)Session["Itda"];

                    dt = hc.TWD_COMMENTS_REPORT_DETAIL_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    //foreach (RepeaterItem item in Repeater1.Items)
                    //{
                    //    Label lbl_msno = (Label)item.FindControl("lbl_msno");
                    //    Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                    //    if (lbl_mandal.Text == "Total")
                    //    {
                    //        lbl_msno.Text = "";
                    //    }
                    //}
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
                    obj.Type = (string)Session["mType"];
                    obj.Itda = (string)Session["Itda"];
                    obj.Mandal= (string)Session["Mandal"];
                    dt = hc.TWD_COMMENTS_REPORT_MANDALDETAIL_SP(obj);

                }

                if (dt.Rows.Count > 0)
                {

                    Repeater2.DataSource = dt;

                    Repeater2.DataBind();
                    //foreach (RepeaterItem item in Repeater1.Items)
                    //{
                    //    Label lbl_msno = (Label)item.FindControl("lbl_msno");
                    //    Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                    //    if (lbl_mandal.Text == "Total")
                    //    {
                    //        lbl_msno.Text = "";
                    //    }
                    //}
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
                string Filename = "TWD Comments Report" + DateTime.Now + ".xls";
               
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
                if ((string)Session["tend"] == "u_lacre")
                {
                    Session["end"] = "Updated : Lessthan 1 Acre";
                    Session["Type"] = "LESSTHAN ACRE";
                }
                if ((string)Session["tend"] == "u_noland")
                {
                    Session["end"] = "Updated : No Land";
                    Session["Type"] = "NO_LAND";
                }
                if ((string)Session["tend"] == "p_lacre")
                {
                    Session["end"] = "Pending : Lessthan 1 Acre";
                    Session["Type"] = "PENDING_LESSTHAN ACRE";
                }
                if ((string)Session["tend"] == "p_noland")
                {
                    Session["end"] = "Pending : No Land";
                    Session["Type"] = "PENDING_NO_LAND";
                }
                if ((string)Session["District"] == "Mandal")
                {
                    Repeater1.Visible = false;
                    rpt1.Visible = true;
                    BindMandal("");
                    Filename = "Mandalwise TWD Comments Report" + DateTime.Now + ".xls";
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
                   
                     Filename = (string)Session["end"]+"  Detail Level TWD Comments Report" + DateTime.Now + ".xls";
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
                    Session["mend"] = "NoLand : No land Available";
                    Session["mType"] = "NO_LAND_NO_LAND";
                }
                if ((string)Session["mtend"] == "iden_noland")
                {
                    Session["mend"] = "NoLand : Land to be Identified";
                    Session["mType"] = "NO_LAND_LANDTOBE";
                }
                if ((string)Session["mtend"] == "pol_noland")
                {
                    Session["mend"] = "NoLand : Polavaram Submerged";
                    Session["mType"] = "NO_LAND_POL";
                }
                if ((string)Session["mtend"] == "death_noland")
                {
                    Session["mend"] = "NoLand : Death Cases";
                    Session["mType"] = "NO_LAND_DEATH";
                }
                if ((string)Session["mtend"] == "ntribes_noland")
                {
                    Session["mend"] = "NoLand : Non-Tribes";
                    Session["mType"] = "NO_LAND_NONTRIBES";
                }

                if ((string)Session["mtend"] == "govt_noland")
                {
                    Session["mend"] = "NoLand : Govt Employee";
                    Session["mType"] = "NO_LAND_GOVT";
                }

                if ((string)Session["mtend"] == "web_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Not updated Webland";
                    Session["mType"] = "NO_LAND_NOTWEB";
                }
                if ((string)Session["mtend"] == "giri_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Not updated Giribhumi";
                    Session["mType"] = "NO_LAND_NOTGIR";
                }
                if ((string)Session["tend"] == "muta_noland")
                {
                    Session["mend"] = "NoLand : Having Land - Mutation to be done";
                    Session["mType"] = "NO_LAND_MUT";
                }
                if ((string)Session["mtend"] == "notde_noland")
                {
                    Session["mend"] = "NoLand : Not dependent on cultivation";
                    Session["mType"] = "NO_LAND_CUL";
                }
                if ((string)Session["mtend"] == "mig_noland")
                {
                    Session["mend"] = "NoLand : Migrated";
                    Session["mType"] = "NO_LAND_MIG";
                }


                if ((string)Session["mtend"] == "noland_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : No land Available";
                    Session["mType"] = "LESS1_NO_LAND";
                }
                if ((string)Session["mtend"] == "landiden_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Land to be Identified";
                    Session["mType"] = "LESS1_LANDTOBE";
                }
                if ((string)Session["mtend"] == "pol_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Polavaram Submerged";
                    Session["mType"] = "LESS1_POL";
                }
                if ((string)Session["mtend"] == "death_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Death Cases";
                    Session["mType"] = "LESS1_DEATH";
                }
                if ((string)Session["mtend"] == "nontribes_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Non-Tribes";
                    Session["mType"] = "LESS1_NONTRIBES";
                }

                if ((string)Session["mtend"] == "gov_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Govt Employee";
                    Session["mType"] = "LESS1_GOVT";
                }

                if ((string)Session["mtend"] == "web_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Not updated Webland";
                    Session["mType"] = "LESS1_NOTWEB";
                }
                if ((string)Session["mtend"] == "giri_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Not updated Giribhumi";
                    Session["mType"] = "LESS1_NOTGIR";
                }
                if ((string)Session["mtend"] == "mut_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Having Land - Mutation to be done";
                    Session["mType"] = "LESS1_MUT";
                }
                if ((string)Session["mtend"] == "notdep_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Not dependent on cultivation";
                    Session["mType"] = "LESS1_CULT";
                }
                if ((string)Session["mtend"] == "mig_l1")
                {
                    Session["mend"] = "Lessthan 1 Acre : Migrated";
                    Session["mType"] = "LESS1_MIG";
                }



                if ((string)Session["mtend"] == "noland_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : No land Available";
                    Session["mType"] = "GREAT1_NO_LAND";
                }
                if ((string)Session["mtend"] == "landiden_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Land to be Identified";
                    Session["mType"] = "GREAT1_LANDTOBE";
                }
                if ((string)Session["mtend"] == "pol_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre: Polavaram Submerged";
                    Session["mType"] = "GREAT1_POL";
                }
                if ((string)Session["mtend"] == "death_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre: Death Cases";
                    Session["mType"] = "GREAT1_DEATH";
                }
                if ((string)Session["mtend"] == "nontribe_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Non-Tribes";
                    Session["mType"] = "GREAT1_NONTRIBES";
                }

                if ((string)Session["mtend"] == "gov_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Govt Employee";
                    Session["mType"] = "GREAT1_GOVT";
                }

                if ((string)Session["mtend"] == "web_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Not updated Webland";
                    Session["mType"] = "GREAT1_NOTWEB";
                }
                if ((string)Session["mtend"] == "giri_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Not updated Giribhumi";
                    Session["mType"] = "GREAT1_NOTGIR";
                }
                if ((string)Session["mtend"] == "mut_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Having Land - Mutation to be done";
                    Session["mType"] = "GREAT1_MUT";
                }
                if ((string)Session["mtend"] == "notdep_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Not dependent on cultivation";
                    Session["mType"] = "GREAT1_CUL";
                }
                if ((string)Session["mtend"] == "mig_g1")
                {
                    Session["mend"] = "Greaterthan 1 Acre : Migrated";
                    Session["mType"] = "GREAT1_MIG";
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

                    Repeater2.RenderControl(htw);
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
    }
}