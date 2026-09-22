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
    public partial class MandalWise_Rythubarosa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "MandalWise_Rythubarosa.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        if (dist != "" & Itda != "")
                        {
                            BindData(Itda, dist);
                        }
                    }
                    else
                    {
                        if ((string)(Session["District"]) != "" && (string)(Session["Itda"]) != "")
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);

                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            if (dist != "" & Itda != "")
                            {
                                BindData(Itda, dist);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData(string Itda, string dist)
        {
            try
            {

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus("Mandal", Itda, dist, "", "", (string)(Session["username"]), (string)Session["userprevilages"]);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;


                    GridView1.DataBind();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }

                            }

                        }
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

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);

                Session["CurrentPage"] = "VillageWise_Rythubarosa.aspx";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Mandal"] = start.Trim();
                            Response.Redirect("~//test//VillageWise_Rythubarosa.aspx");
                        }

                    }
                }




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

    }
}