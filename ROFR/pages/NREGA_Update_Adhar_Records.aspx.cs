using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using ROFR.helper;
using System.Text;
using Newtonsoft.Json;
using ROFR.getEGSJobCardInfoByUIDser;

namespace ROFR.pages
{
    public partial class NREGA_Update_Adhar_Records : System.Web.UI.Page
    {

        DataTable dtupdaterec = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    dtupdaterec = null;
                    BindItda();
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
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("ITDA NAME", "0"));
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                dtupdaterec = null;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {

                    DataTable dtrecords = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecords(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtrecords.Rows.Count > 0)
                    {
                        dtupdaterec = dtrecords;
                        Label myLabel = this.FindControl("noofrec") as Label;
                        myLabel.Text = dtrecords.Rows.Count.ToString();
                        Label myLabel1 = this.FindControl("noofupdate") as Label;
                        myLabel1.Text = "0";
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

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {

                    if (dtupdaterec.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtupdaterec.Rows.Count; i++)
                        {
                            APHousingWS obj = new APHousingWS();
                            
                            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>("");
                            if (myDeserializedClass.Status[0].Message == "success" && myDeserializedClass.Status[0].Status == "200")
                            {
                                DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec.Rows[i]["Aadhaar_NO"].ToString(),
                                    myDeserializedClass.WageseekerInfo[0].JobCardID, myDeserializedClass.WageseekerInfo[0].JobCardName, myDeserializedClass.WageseekerInfo[0].JobCardStatus,
                                    myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", "N/A",
                                    myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                Label myLabel1 = this.FindControl("noofupdate") as Label;
                                myLabel1.Text = (j + 1).ToString();
                            }
                           else  if (myDeserializedClass.Status[0].Message == "Aadhar Details Not Found" && myDeserializedClass.Status[0].Status == "200")
                            {
                                DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec.Rows[i]["Aadhaar_NO"].ToString(),
                                    myDeserializedClass.WageseekerInfo[0].JobCardID, myDeserializedClass.WageseekerInfo[0].JobCardName, myDeserializedClass.WageseekerInfo[0].JobCardStatus,
                                    myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", "N/A",
                                    myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                Label myLabel1 = this.FindControl("noofupdate") as Label;
                                myLabel1.Text = (j + 1).ToString();
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

        public class Status1
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }

        public class WageseekerInfo
        {

            public string JobCardID { get; set; }
            public string JobCardName { get; set; }
            public string JobCardStatus { get; set; }
        }

        public class WorkInfo
        {

            public string WorkCode { get; set; }
            public string WorkName { get; set; }

            public double EstimtedCost { get; set; }
            public string CreatedDate { get; set; }
            public double LandExtent { get; set; }
            public string CompletionDate { get; set; }
        }

        public class PaymentDeatail
        {
            public string WorkCode { get; set; }
            public double Expenditure { get; set; }
        }

        public class Root
        {
            public List<Status1> Status { get; set; }
            public List<WageseekerInfo> WageseekerInfo { get; set; }
            public List<WorkInfo> WorkInfo { get; set; }
            public List<PaymentDeatail> PaymentDeatails { get; set; }
        }
    }
}