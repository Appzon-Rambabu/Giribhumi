using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ROFR.helper;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ROFR.pages
{
    public partial class loginhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dt1 = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr1((string)(Session["username"]));
                DataTable dtCategories = dt1.Tables[0];
                DataTable dtSuppliers = dt1.Tables[1];

                DataTable dtMerged = MergeTables(dtCategories, dtSuppliers);
                if (dtMerged.Rows.Count > 0)
                {
                    totalbeneficiaries.InnerText = dtMerged.Rows[0]["Giribhumi_beneficiaries"].ToString();
                    Ttlplots.InnerText = dtMerged.Rows[0]["Total_Plots"].ToString();
                    TtlExtent.InnerText = dtMerged.Rows[0]["Total_Extent"].ToString();
                    Hvngdlc.InnerText = dtMerged.Rows[0]["Having_Dlc"].ToString();
                    Nthvngdlc.InnerText = dtMerged.Rows[0]["Not_Having_Dlc"].ToString();

                    STPShvng.InnerText = dtMerged.Rows[0]["Having_Land_Image"].ToString();
                    STPSnothvng.InnerText = dtMerged.Rows[0]["Not_having_Land_Image"].ToString();

                    latlnghvng.InnerText = dtMerged.Rows[0]["Plots_having_latlongs"].ToString();
                    latlngnothvng.InnerText = dtMerged.Rows[0]["Plots_not_having_latlongs"].ToString();

                    Frmrimgstat.InnerText = dtMerged.Rows[0]["Images_Uploaded"].ToString();
                    Frmrimgnotstat.InnerText = dtMerged.Rows[0]["Images_Not_Uploaded"].ToString();

                    images_not_uploaded.InnerText = dtMerged.Rows[0]["Noland_Farmers"].ToString();

                    cfrtotalClaims.InnerText = dtMerged.Rows[0]["TOTAL_CFR_Claims"].ToString();
                    cfrMembers.InnerText = dtMerged.Rows[0]["Mem_Sub_Claims"].ToString();
                    CfrTotalExtent.InnerText = dtMerged.Rows[0]["Total_CFR_Extent"].ToString();

                    HousingTF.InnerText = dtMerged.Rows[0]["Total_Beneficiaries"].ToString();
                    HousingTP.InnerText = dtMerged.Rows[0]["Total_Housing_Plots"].ToString();
                    HousingTE.InnerText = dtMerged.Rows[0]["Total_Housing_Extent"].ToString();
                }
                //dtCategories.Columns.Add("Noland_Farmer", typeof(string));

                //string s2 = "";

                //foreach (DataRow dr2 in dtSuppliers.Rows)
                //{

                //    s2 = dr2["Noland_Farmers"].ToString();

                //}
                //dtCategories.Rows[0]["Noland_Farmer"] = s2.ToString();


                //DataTable dt = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr((string)(Session["username"]));


                //if (dt.Rows.Count > 0)
                //{
                //    //totalbenificiary.InnerText = dt.Rows[0]["Total_bneficiaries_dept"].ToString();
                //    totalbeneficiaries.InnerText = dt.Rows[0]["Total_Beneficiaries"].ToString();
                //    aadharavaliable.InnerText = dt.Rows[0]["Total_Received"].ToString();
                //    aadharnotavaliable.InnerText = dt.Rows[0]["Adhharnotavaliable"].ToString();
                //    vaildaadhar.InnerText = dt.Rows[0]["Adhharisvalid"].ToString();
                //    invaildaadhar.InnerText = dt.Rows[0]["Adhharnoinvalid"].ToString();
                //    images_uploaded.InnerText = dt.Rows[0]["Images_Uploaded"].ToString();
                //    images_not_uploaded.InnerText = dt.Rows[0]["Images_Not_Uploaded"].ToString();
                //    //images_adhar_updated.InnerText = dt.Rows[0]["Aadhaar_Service_Image_Uploaded"].ToString();
                //    //images_adhar_notupdated.InnerText = dt.Rows[0]["Aadhaar_Service_Image_not_Uploaded"].ToString();
                //    //if ((string)(Session["username"]) == "admin")
                //    //{
                //    //    extent.InnerText = (string)(Session["sessionextent"]);
                //    //}
                //    //else
                //    //{
                //        extent.InnerText = dt.Rows[0]["Total_Extent"].ToString();
                //    //}

                //}
                //foreach (DataRow dr23 in dtCategories.Rows) {
                //    dr23["Noland_Farmer"] = s2;
                //}

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        public static DataTable MergeTables(DataTable baseTable, params DataTable[] additionalTables)
        {
            // Build combined table columns
            DataTable merged = baseTable;
            foreach (DataTable dt in additionalTables)
            {
                merged = AddTable(merged, dt);
            }
            return merged;
        }
        public static DataTable AddTable(DataTable baseTable, DataTable additionalTable)
        {
            // Build combined table columns
            DataTable merged = baseTable.Clone();                  // Include all columns from base table in result.
            foreach (DataColumn col in additionalTable.Columns)
            {
                string newColumnName = col.ColumnName;
                merged.Columns.Add(newColumnName, col.DataType);
            }
            // Add all rows from both tables
            var bt = baseTable.AsEnumerable();
            var at = additionalTable.AsEnumerable();
            var mergedRows = bt.Zip(at, (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
            foreach (object[] rowFields in mergedRows)
            {
                merged.Rows.Add(rowFields);
            }
            return merged;
        }

    }
}