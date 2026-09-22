using ROFR.helper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ROFR.pages
{
    public partial class QuerySearch : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["ROFR"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvResult.DataSource = null;
            gvResult.DataBind();

            string query = txtQuery.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                ShowError("Please enter a query.");
                return;
            }

            // Allow only SELECT
            if (!Regex.IsMatch(query, @"^\s*SELECT\s+", RegexOptions.IgnoreCase))
            {
                ShowError("Only SELECT queries are allowed.");
                return;
            }

            string[] blockedWords =
            {
        "INSERT","UPDATE","DELETE","DROP","ALTER",
        "TRUNCATE","CREATE","EXEC","EXECUTE",
        "MERGE","GRANT","REVOKE"
    };

            foreach (string word in blockedWords)
            {
                if (Regex.IsMatch(query, @"\b" + word + @"\b",
                    RegexOptions.IgnoreCase))
                {
                    ShowError(word + " statements are not allowed.");
                    return;
                }
            }

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 120;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                // Store all records once
                Session["QueryResult"] = dt;

                gvResult.PageIndex = 0;
                gvResult.DataSource = dt;
                gvResult.DataBind();

                ShowSuccess("Records Found : " + dt.Rows.Count);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResult.PageIndex = e.NewPageIndex;

            DataTable dt = Session["QueryResult"] as DataTable;

            if (dt != null)
            {
                gvResult.DataSource = dt;
                gvResult.DataBind();
            }
        }
        private void ShowError(string message)
        {
            lblMessage.CssClass = "error";
            lblMessage.Text = message;
        }

        private void ShowSuccess(string message)
        {
            lblMessage.CssClass = "success";
            lblMessage.Text = message;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtQuery.Text = string.Empty;
            lblMessage.Text = string.Empty;

            Session.Remove("QueryResult");

            gvResult.PageIndex = 0;
            gvResult.DataSource = null;
            gvResult.DataBind();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
                "attachment;filename=QueryResult.xls");
            Response.ContentType = "application/vnd.ms-excel";

            Response.Write("<table border='1'>");

            // Header
            Response.Write("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                Response.Write("<th>" + col.ColumnName + "</th>");
            }
            Response.Write("</tr>");

            // Data
            foreach (DataRow row in dt.Rows)
            {
                Response.Write("<tr>");
                foreach (var item in row.ItemArray)
                {
                    Response.Write("<td>" + item.ToString() + "</td>");
                }
                Response.Write("</tr>");
            }

            Response.Write("</table>");
            Response.End();
        }
    }
}