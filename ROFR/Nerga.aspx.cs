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
using System.Net;
using System.Threading.Tasks;

namespace ROFR
{
    public partial class Nerga : System.Web.UI.Page
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
                   // third();



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

    
        protected void Update_Click1(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    DataTable dtupdaterec1 = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecords(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtupdaterec1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= (dtupdaterec1.Rows.Count - 1); i++)
                        {
                           
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            APHousingWS obj = new APHousingWS();

                            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(obj.WorkDetailsCapturingByUID(dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString()));
                            var a = obj.WorkDetailsCapturingByUID(dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString());
                            string logdata = a;
                            string mappath = HttpContext.Current.Server.MapPath("MgnergasResponselogs");
                            Log sqlmngr = new Log();
                            Task WriteTask = Task.Factory.StartNew(() => sqlmngr.Logcreate(logdata+i, mappath, DateTime.Now.ToString("yyyyMMddhhmmssmmm")));

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
        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                first();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        public void first()
        {
            try
            {
                int j = 0;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    DataTable dtupdaterec1 = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecords(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                   //re ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(" + dtupdaterec1.Rows.Count + ")", true);
                    if (dtupdaterec1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= (dtupdaterec1.Rows.Count - 1); i++)
                        {
                            if (i <= 100)
                            {
                                //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(" + dtupdaterec1.Rows[0]["Aadhaar_NO"].ToString() + ")", true);

                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                APHousingWS obj = new APHousingWS();

                                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(obj.WorkDetailsCapturingByUID(dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString()));
                                if (myDeserializedClass.Status[0].Message == "success" && myDeserializedClass.Status[0].Status == "200")
                                {
                                    string JobCardID = "NA";
                                    string JobCardName = "NA";
                                    string JobCardStatus = "NA";
                                    if (myDeserializedClass.WageseekerInfo.Count != 0)
                                    {
                                        JobCardID = myDeserializedClass.WageseekerInfo[0].JobCardID;
                                        JobCardName = myDeserializedClass.WageseekerInfo[0].JobCardName;
                                        JobCardStatus = myDeserializedClass.WageseekerInfo[0].JobCardStatus;
                                    }
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                       JobCardID, JobCardName, JobCardStatus,
                                        myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", myDeserializedClass.Status[0].Message,
                                        myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                    // Label myLabel1 = this.FindControl("noofupdate") as Label;
                                    // j = j + 1;
                                    // myLabel1.Text = (j ).ToString();
                                }
                                else if (myDeserializedClass.Status[0].Message == "Aadhar Details Not Found" && myDeserializedClass.Status[0].Status == "200")
                                {
                                    string JobCardID = "NA";
                                    string JobCardName = "NA";
                                    string JobCardStatus = "NA";
                                    if (myDeserializedClass.WageseekerInfo.Count != 0)
                                    {
                                        JobCardID = myDeserializedClass.WageseekerInfo[0].JobCardID;
                                        JobCardName = myDeserializedClass.WageseekerInfo[0].JobCardName;
                                        JobCardStatus = myDeserializedClass.WageseekerInfo[0].JobCardStatus;
                                    }
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                     JobCardID, JobCardName, JobCardStatus,
                                      myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", myDeserializedClass.Status[0].Message,
                                      myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                    //  Label myLabel1 = this.FindControl("noofupdate") as Label;
                                    // j = j + 1;
                                    //  myLabel1.Text = (j).ToString();
                                }
                                else
                                {
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                    "N/A", "N/A", "N/A",
                                    "N/A", "N/A", "N/A", myDeserializedClass.Status[0].Message,
                                     "0.0", "N/A", "N/A", "N/A", "N/A");
                                }
                            }
                            else
                            {
                                second();
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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(' first Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        public void second()
        {
            try
            {
                int j = 0;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    DataTable dtupdaterec1 = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecords(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtupdaterec1.Rows.Count > 0)
                    {

                        for (int i = 0; i <= (dtupdaterec1.Rows.Count - 1); i++)
                        {
                            if (i <= 100)
                            {
                                //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(" + dtupdaterec1.Rows[0]["Aadhaar_NO"].ToString() + ")", true);

                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                APHousingWS obj = new APHousingWS();

                                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(obj.WorkDetailsCapturingByUID(dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString()));
                                if (myDeserializedClass.Status[0].Message == "success" && myDeserializedClass.Status[0].Status == "200")
                                {
                                    string JobCardID = "NA";
                                    string JobCardName = "NA";
                                    string JobCardStatus = "NA";
                                    if (myDeserializedClass.WageseekerInfo.Count != 0)
                                    {
                                        JobCardID = myDeserializedClass.WageseekerInfo[0].JobCardID;
                                        JobCardName = myDeserializedClass.WageseekerInfo[0].JobCardName;
                                        JobCardStatus = myDeserializedClass.WageseekerInfo[0].JobCardStatus;
                                    }
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                        JobCardID, JobCardName, JobCardStatus,
                                        myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", myDeserializedClass.Status[0].Message,
                                        myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                    // Label myLabel1 = this.FindControl("noofupdate") as Label;
                                    // j = j + 1;
                                    // myLabel1.Text = (j ).ToString();
                                }
                                else if (myDeserializedClass.Status[0].Message == "Aadhar Details Not Found" && myDeserializedClass.Status[0].Status == "200")
                                {
                                    string JobCardID = "NA";
                                    string JobCardName = "NA";
                                    string JobCardStatus = "NA";
                                    if (myDeserializedClass.WageseekerInfo.Count != 0)
                                    {
                                        JobCardID = myDeserializedClass.WageseekerInfo[0].JobCardID;
                                        JobCardName = myDeserializedClass.WageseekerInfo[0].JobCardName;
                                        JobCardStatus = myDeserializedClass.WageseekerInfo[0].JobCardStatus;
                                    }
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                     JobCardID, JobCardName, JobCardStatus,
                                      myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", myDeserializedClass.Status[0].Message,
                                      myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                                    //  Label myLabel1 = this.FindControl("noofupdate") as Label;
                                    // j = j + 1;
                                    //  myLabel1.Text = (j).ToString();
                                }
                                else
                                {
                                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert(ddl_ITda.SelectedItem.Text, dtupdaterec1.Rows[i]["Aadhaar_NO"].ToString(),
                                    "N/A", "N/A", "N/A",
                                    "N/A", "N/A", "N/A", myDeserializedClass.Status[0].Message,
                                     "0.0", "N/A", "N/A", "N/A", "N/A");
                                }
                            }
                            else
                            {
                                first();
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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(' second Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        public void third()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                APHousingWS obj = new APHousingWS();

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(obj.WorkDetailsCapturingByUID("687472535361"));
                if (myDeserializedClass.Status[0].Message == "success" && myDeserializedClass.Status[0].Status == "200")
                {
                    string JobCardID = "NA";
                    string JobCardName = "NA";
                    string JobCardStatus = "NA";
                    if (myDeserializedClass.WageseekerInfo.Count !=0)
                    {
                        JobCardID = myDeserializedClass.WageseekerInfo[0].JobCardID;
                        JobCardName = myDeserializedClass.WageseekerInfo[0].JobCardName;
                        JobCardStatus = myDeserializedClass.WageseekerInfo[0].JobCardStatus;
                    }
                   
                    DataTable dr = MastersDataAnalysisBAL.MastersDataAnalysis.Getnregaadharrecordsinsert("paderu", "687472535361",
                        JobCardID, JobCardName, JobCardStatus,
                        myDeserializedClass.WorkInfo[0].WorkCode, myDeserializedClass.WorkInfo[0].WorkName, "N/A", myDeserializedClass.Status[0].Message,
                        myDeserializedClass.WorkInfo[0].EstimtedCost.ToString(), myDeserializedClass.PaymentDeatails[0].Expenditure.ToString(), myDeserializedClass.WorkInfo[0].CreatedDate, myDeserializedClass.WorkInfo[0].CompletionDate, myDeserializedClass.WorkInfo[0].LandExtent.ToString());
                    // Label myLabel1 = this.FindControl("noofupdate") as Label;
                    // j = j + 1;
                    // myLabel1.Text = (j ).ToString();
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