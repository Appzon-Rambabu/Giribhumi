using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.IO;
using System.Data;

namespace ROFR.test
{
    public partial class LandTransferRegulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                  
                    if ((string)(Session["CurrentPage"]) == "ViewLandTransferRegulation.aspx")
                    {
                        if ((string)(Session["ltId"]) != "")
                        {
                            btn_rdo_upload.Visible = false;
                            Binddata((string)(Session["ltId"]));
                            Session["updateId"] = (string)(Session["ltId"]);
                            File_rdo_doc.Attributes.Add("onchange", "return file(this,'" + File_rdo_doc.ClientID + "');");
                            Bindrdo_docs();
                        }
                    }
                    else
                    {
                        btn_rdo_upload.Visible = false;
                        Session["updateId"] = "0";
                        File_rdo_doc.Attributes.Add("onchange", "return file(this,'" + File_rdo_doc.ClientID + "');");
                    }
                }
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
                DataTable dt = Landsettlementpattas.GetData(id);
                if(dt.Rows.Count > 0)
                {
                    txt_mandal.Text= dt.Rows[0]["MANDAL"].ToString();
                    txt_village.Text = dt.Rows[0]["VILLAGE"].ToString();
                    txt_extent.Text= dt.Rows[0]["EXTENT"].ToString();
                    txt_rsno.Text= dt.Rows[0]["RS_NO"].ToString();
                    txt_ltrp.Text= dt.Rows[0]["LTRP_NO"].ToString();
                    txt_remarks.Text= dt.Rows[0]["REMARKS"].ToString();
                    txt_land_purpose.Text = dt.Rows[0]["LAND_ALREADY_ACQUIRED"].ToString();
                    txt_OldDateoforder.Text= dt.Rows[0]["DATE_OF_ORDERS"].ToString();
                    txt_ltrpdate.Text = dt.Rows[0]["NewDATE_OF_ORDERS"].ToString();
                    if ((dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString()) != "")
                    {
                        rbtn_orders.Items.FindByValue("A").Selected = true;
                        txt_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_NT"].ToString();
                    }
                    else if (dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString() !="")
                    {
                        rbtn_orders.Items.FindByValue("B").Selected = true;
                        txt_name.Text = dt.Rows[0]["O_IN_FAVOUR_OF_T"].ToString();
                    }
                    else if (dt.Rows[0]["O_GOVT"].ToString() !="")
                    {
                        rbtn_orders.Items.FindByValue("C").Selected = true;
                        txt_name.Text = dt.Rows[0]["O_GOVT"].ToString();
                    }
                    txt_wpno.Text = dt.Rows[0]["HC_WP_NO"].ToString();
                    txt_rpnm.Text= dt.Rows[0]["G_RP_NO"].ToString();
                    txt_appeal_no.Text= dt.Rows[0]["AG_APPEAL_NO"].ToString();
                    txt_cma_no.Text = dt.Rows[0]["AAG_CMA_NO"].ToString();
                    txt_ltrpdate1.Text = dt.Rows[0]["CMADATE_OF_ORDERS"].ToString();
                    txt_ltrpdate2.Text = dt.Rows[0]["AppealDATE_OF_ORDERS"].ToString();
                    txt_ltrpdated.Text = dt.Rows[0]["RPDATE_OF_ORDERS"].ToString();
                    txt_ltrpdate4.Text = dt.Rows[0]["WPNDATE_OF_ORDERS"].ToString();

                    if ((dt.Rows[0]["AAG_NT"].ToString()) == "Non-Tribal")
                    {
                        Radiobox_cma.Items.FindByValue("A").Selected = true;
                        Radiobox_cma.Items.FindByValue("B").Selected = false;
                        Radiobox_cma.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["AAG_T"].ToString() == "Tribal")
                    {
                        Radiobox_cma.Items.FindByValue("A").Selected = false;
                        Radiobox_cma.Items.FindByValue("B").Selected = true;
                        Radiobox_cma.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["AAG_GOVT"].ToString() == "Government")
                    {
                        Radiobox_cma.Items.FindByValue("A").Selected = false;
                        Radiobox_cma.Items.FindByValue("B").Selected = false;
                        Radiobox_cma.Items.FindByValue("C").Selected = true;
                    }

                    if ((dt.Rows[0]["AG_NT"].ToString()) == "Non-Tribal")
                    {
                        Radiobox_appeal.Items.FindByValue("A").Selected = true;
                        Radiobox_appeal.Items.FindByValue("B").Selected = false;
                        Radiobox_appeal.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["AG_T"].ToString() == "Tribal")
                    {
                        Radiobox_appeal.Items.FindByValue("A").Selected = false;
                        Radiobox_appeal.Items.FindByValue("B").Selected = true;
                        Radiobox_appeal.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["AG_GOVT"].ToString() == "Government")
                    {
                        Radiobox_appeal.Items.FindByValue("A").Selected = false;
                        Radiobox_appeal.Items.FindByValue("B").Selected = false;
                        Radiobox_appeal.Items.FindByValue("C").Selected = true;
                    }

                    if ((dt.Rows[0]["G_NT"].ToString()) == "Non-Tribal")
                    {
                        Radiobox_rpno.Items.FindByValue("A").Selected = true;
                        Radiobox_rpno.Items.FindByValue("B").Selected = false;
                        Radiobox_rpno.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["G_T"].ToString() == "Tribal")
                    {
                        Radiobox_rpno.Items.FindByValue("A").Selected = false;
                        Radiobox_rpno.Items.FindByValue("B").Selected = true;
                        Radiobox_rpno.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["G_GOVT"].ToString() == "Government")
                    {
                        Radiobox_rpno.Items.FindByValue("A").Selected = false;
                        Radiobox_rpno.Items.FindByValue("B").Selected = false;
                        Radiobox_rpno.Items.FindByValue("C").Selected = true;
                    }

                    if ((dt.Rows[0]["HC_NT"].ToString()) == "Non-Tribal")
                    {
                        Radiobox_wpno.Items.FindByValue("A").Selected = true;
                        Radiobox_wpno.Items.FindByValue("B").Selected = false;
                        Radiobox_wpno.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["HC_T"].ToString() == "Tribal")
                    {
                        Radiobox_wpno.Items.FindByValue("A").Selected = false;
                        Radiobox_wpno.Items.FindByValue("B").Selected = true;
                        Radiobox_wpno.Items.FindByValue("C").Selected = false;
                    }
                    else if (dt.Rows[0]["HC_GOVT"].ToString() == "Government")
                    {
                        Radiobox_wpno.Items.FindByValue("A").Selected = false;
                        Radiobox_wpno.Items.FindByValue("B").Selected = false;
                        Radiobox_wpno.Items.FindByValue("C").Selected = true;
                    }

                    txt_ac_cts.Text = dt.Rows[0]["DETAILS_OF_LAND_AC_CTS"].ToString();
                    txt_hec.Text = dt.Rows[0]["DETAILS_OF_LAND_HEC_A"].ToString();

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
                string IPAddress = (string)(Session["IPAddress"]);
                land_transfer_regulation land_transfer_obj = new land_transfer_regulation();
               
                    int Id = int.Parse((string)(Session["updateId"]));
                    //Block1
                    land_transfer_obj.Id = Id;
                     land_transfer_obj.mandal = txt_mandal.Text;
                    land_transfer_obj.village = txt_village.Text;
                    land_transfer_obj.rsno = txt_rsno.Text;
                    land_transfer_obj.extent_ac_cts = txt_extent.Text;
                    land_transfer_obj.ltrp_no = txt_ltrp.Text;
                    land_transfer_obj.ltrp_date = txt_ltrpdate.Text;
                    land_transfer_obj.OLDltrp_date= txt_OldDateoforder.Text;
                    //Block2
                    land_transfer_obj.cma_no = txt_cma_no.Text;
                    land_transfer_obj.cmadate = txt_ltrpdate1.Text;
                    if (Radiobox_cma.SelectedValue == "A")
                   {
                    land_transfer_obj.additional_nt = "Non-Tribal";
                    land_transfer_obj.additional_tri = "";
                    land_transfer_obj.additional_govt = "";
                   }
                   else if (Radiobox_cma.SelectedValue == "B")
                   {
                    land_transfer_obj.additional_nt = "";
                    land_transfer_obj.additional_tri = "Tribal";
                    land_transfer_obj.additional_govt = "";
                   }
                   else if (Radiobox_cma.SelectedValue == "C")
                   {
                    land_transfer_obj.additional_nt = "";
                    land_transfer_obj.additional_tri = "";
                    land_transfer_obj.additional_govt = "Government";
                   }

                land_transfer_obj.appeal_no = txt_appeal_no.Text;
                land_transfer_obj.appealdate = txt_ltrpdate2.Text;

                if (Radiobox_appeal.SelectedValue == "A")
                {
                    land_transfer_obj.agent_nt = "Non-Tribal";
                    land_transfer_obj.agent_tri = "";
                    land_transfer_obj.agent_govt = "";
                }
                else if (Radiobox_appeal.SelectedValue == "B")
                {
                    land_transfer_obj.agent_nt = "";
                    land_transfer_obj.agent_tri = "Tribal";
                    land_transfer_obj.agent_govt = "";
                }
                else if (Radiobox_appeal.SelectedValue == "C")
                {
                    land_transfer_obj.agent_nt = "";
                    land_transfer_obj.agent_tri = "";
                    land_transfer_obj.agent_govt = "Government";
                }

                land_transfer_obj.rpno = txt_rpnm.Text;
                    land_transfer_obj.rpdate = txt_ltrpdated.Text;

                if (Radiobox_rpno.SelectedValue == "A")
                {
                    land_transfer_obj.govt_nt = "Non-Tribal";
                    land_transfer_obj.govt_tri = "";
                    land_transfer_obj.govt_govt = "";
                }
                else if (Radiobox_rpno.SelectedValue == "B")
                {
                    land_transfer_obj.govt_nt = "";
                    land_transfer_obj.govt_tri = "Tribal";
                    land_transfer_obj.govt_govt = "";
                }
                else if (Radiobox_rpno.SelectedValue == "C")
                {
                    land_transfer_obj.govt_nt = "";
                    land_transfer_obj.govt_tri = "";
                    land_transfer_obj.govt_govt = "Government";
                }

                land_transfer_obj.wpno = txt_wpno.Text;
                land_transfer_obj.wpdate = txt_ltrpdate4.Text;
                if (Radiobox_wpno.SelectedValue == "A")
                {
                    land_transfer_obj.high_nt = "Non-Tribal";
                    land_transfer_obj.high_court_tri = "";
                    land_transfer_obj.high_court_govt = "";
                }
                else if (Radiobox_wpno.SelectedValue == "B")
                {
                    land_transfer_obj.high_nt = "";
                    land_transfer_obj.high_court_tri = "Tribal";
                    land_transfer_obj.high_court_govt = "";
                }
                else if (Radiobox_wpno.SelectedValue == "C")
                {
                    land_transfer_obj.high_nt = "";
                    land_transfer_obj.high_court_tri = "";
                    land_transfer_obj.high_court_govt = "Government";
                }
             
                    //Block3
                    land_transfer_obj.land_already = txt_land_purpose.Text;
                    land_transfer_obj.remarks = txt_remarks.Text;
                    //land_transfer_obj.Details_Ac_cts = txt_ac_cts.Text;
                    //land_transfer_obj.Details_Hec_A = txt_hec.Text;
                if (rbtn_orders.SelectedValue == "A")
                {
                    land_transfer_obj.orders_passed_nt = txt_name.Text;
                    land_transfer_obj.orders_passed_tri = string.Empty;
                    land_transfer_obj.orders_passed_govt = string.Empty;
                }
                else if (rbtn_orders.SelectedValue == "B")
                {
                    land_transfer_obj.orders_passed_nt = string.Empty;
                    land_transfer_obj.orders_passed_tri = txt_name.Text;
                    land_transfer_obj.orders_passed_govt = string.Empty;
                }
                else if (rbtn_orders.SelectedValue == "C")
                {
                    land_transfer_obj.orders_passed_nt = string.Empty;
                    land_transfer_obj.orders_passed_tri = string.Empty;
                    land_transfer_obj.orders_passed_govt = "Government";
                }
            
                    land_transfer_obj.Rdo_sdc_orders = lbl_rdo_doc.Text;

                    land_transfer_obj.collector_po = txt_collector_po_doc.Text;
                    land_transfer_obj.govt_doc = txt_govt_doc.Text;

                    land_transfer_obj.high_court_doc = txt_high_court_doc.Text;
                


                    land_transfer_obj.Ipaddress = (string)(Session["IPAddress"]);
                    land_transfer_obj.UserName = (string)(Session["username"]);

                    if (!string.IsNullOrEmpty(land_transfer_obj.UserName))
                    {
                    try
                    {
                        DataTable DT = ProjectRofrBAL.GetMasterDetails.land_transfer_regulation(land_transfer_obj);
                        if (land_transfer_obj.Id == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Land Transfer regulation registered successfully')", true);
                            Session["updateId"] = DT.Rows[0]["ID"].ToString();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Land Transfer regulation updated successfully')", true);
                            Session["updateId"] = DT.Rows[0]["ID"].ToString();
                        }
                      
                        //fileupload for RDO Documents
                        if (DT.Rows.Count > 0)
                        {
                            BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
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
                                    foreach (HttpPostedFile postfiles in File_rdo_doc.PostedFiles)
                                    {
                                        //Get The File Extension  
                                        string filetype = Path.GetExtension(postfiles.FileName);
                                        if ( filetype.ToLower() == ".pdf" ||  filetype.ToLower() == ".jpeg"|| filetype.ToLower() == ".jpg")
                                        {

                                            double filesize = postfiles.ContentLength;

                                            string serverfolder = string.Empty;
                                            string serverpath = string.Empty;

                                            switch (filetype)
                                            {
                                                case ".pdf":
                                                    serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "RDO" + "/" + DT.Rows[0]["ID"].ToString() + "/");



                                                    if (!Directory.Exists(serverfolder))
                                                    {
                                                        // create Folder  
                                                        Directory.CreateDirectory(serverfolder);
                                                    }
                                                    if (postfiles.ContentLength == filesize)
                                                    {

                                                        serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
                                                        postfiles.SaveAs(serverpath);
                                                    }

                                                    break;
                                                case ".jpg":
                                                case ".jpeg":
                                                    // serverfolder = Server.MapPath(@"uplaodfiles\document\");
                                                    serverfolder = Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "RDO" + "/" + DT.Rows[0]["ID"].ToString() + "/");

                                                    if (!Directory.Exists(serverfolder))
                                                    {
                                                        Directory.CreateDirectory(serverfolder);
                                                    }
                                                    if (postfiles.ContentLength == filesize)
                                                    {


                                                        serverpath = serverfolder + Path.GetFileName(postfiles.FileName);
                                                        postfiles.SaveAs(serverpath);
                                                    }
                                                    //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
                                                    break;

                                            }
                                            DataRow dr = dtUploadFiles.NewRow();
                                            dr["Option1"] = DT.Rows[0]["ID"].ToString();
                                            dr["Option2"] = serverfolder;
                                            dr["Option3"] = postfiles.FileName;
                                            dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                                            dr["Option5"] = "RDO";
                                            dtUploadFiles.Rows.Add(dr);
                                        }

                                        


                                    }
                                  
                                }

                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('RDO Documents Location Created Error !')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                            }

                            //fileupload for collector/POITDA

                            HttpPostedFile collector_po_doc = file_collector_po.PostedFile;
                            string collector_po_path = file_collector_po.PostedFile.FileName;
                            string collector_po_name = Path.GetFileName(collector_po_path);
                            string ext = Path.GetExtension(collector_po_name);
                            string jpgext = Path.GetExtension(collector_po_name);
                            string type = string.Empty;
                            string type1 = string.Empty;




                            if (collector_po_doc != null && collector_po_doc.ContentLength > 0)
                            {

                                try
                                {
                                    string location = HttpContext.Current.Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "POITDA/" + "/" + DT.Rows[0]["ID"].ToString() + "/");

                                    if (!Directory.Exists(location))
                                    {
                                        Directory.CreateDirectory(location);
                                    }

                                    string collectorpath = location + Path.GetFileName(collector_po_doc.FileName);
                                    file_collector_po.PostedFile.SaveAs(collectorpath);

                                    if (file_collector_po.PostedFile != null && collector_po_doc.ContentLength > 0)
                                    {
                                        txt_collector_po_doc.Text = file_collector_po.PostedFile.FileName;
                                    }
                                    DataRow dr = dtUploadFiles.NewRow();
                                    dr["Option1"] = DT.Rows[0]["ID"].ToString();
                                    dr["Option2"] = location;
                                    dr["Option3"] = collector_po_doc.FileName;
                                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                                    dr["Option5"] = "POITDA";
                                    dtUploadFiles.Rows.Add(dr);
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Documents Location Created Error !')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                                if (file_collector_po.PostedFile != null && collector_po_doc.ContentLength > 0)
                                {

                                    switch (ext)
                                    {
                                        case ".pdf":
                                            type = "pdf";

                                            break;
                                    }
                                    switch (jpgext)
                                    {
                                        case ".jpg":
                                            type1 = "jpg";
                                            break;
                                    }
                                    if (type != string.Empty)
                                    {
                                        Stream filestream = file_collector_po.PostedFile.InputStream;
                                        BinaryReader br = new BinaryReader(filestream);

                                    }
                                    if (type1 != string.Empty)
                                    {
                                        int length1 = file_collector_po.PostedFile.ContentLength;
                                        byte[] imgbyte1 = new byte[] { };
                                        imgbyte1 = new byte[length1];
                                        HttpPostedFile cimage1 = file_collector_po.PostedFile;
                                    }

                                }
                            }


                            //fileupload for govt doc

                            HttpPostedFile govt_doc = file_govt.PostedFile;
                            string govt_path = file_govt.PostedFile.FileName;
                            string govt_name = Path.GetFileName(govt_path);
                            string gext = Path.GetExtension(govt_name);
                            string jpggext = Path.GetExtension(govt_name);
                            string gtype = string.Empty;
                            string gtype1 = string.Empty;




                            if (govt_doc != null && govt_doc.ContentLength > 0)
                            {
                                try
                                {
                                    string location = HttpContext.Current.Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "Government/" + "/" + DT.Rows[0]["ID"].ToString() + "/");

                                    if (!Directory.Exists(location))
                                    {
                                        Directory.CreateDirectory(location);

                                    }

                                    string govpath = location + Path.GetFileName(govt_doc.FileName);
                                    file_govt.PostedFile.SaveAs(govpath);

                                    if (govt_doc != null && govt_doc.ContentLength > 0)
                                    {

                                        txt_govt_doc.Text = govt_doc.FileName;
                                    }

                                    DataRow dr = dtUploadFiles.NewRow();
                                    dr["Option1"] = DT.Rows[0]["ID"].ToString();
                                    dr["Option2"] = location;
                                    dr["Option3"] = govt_doc.FileName;
                                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                                    dr["Option5"] = "Government";
                                    dtUploadFiles.Rows.Add(dr);
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Government Documents Location Created Error !')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                                if (file_govt.PostedFile != null && govt_doc.ContentLength > 0)
                                {

                                    switch (gext)
                                    {
                                        case ".pdf":
                                            gtype = "pdf";

                                            break;            
                                    }
                                    switch (jpggext)
                                    {
                                        case ".jpg":
                                            gtype1 = "jpg";
                                            break;
                                    }
                                    if (gtype != string.Empty)
                                    {
                                        Stream filestream = govt_doc.InputStream;
                                        BinaryReader br = new BinaryReader(filestream);

                                    }
                                    if (gtype1 != string.Empty)
                                    {
                                        int length1 = govt_doc.ContentLength;
                                        byte[] imgbyte1 = new byte[] { };
                                        imgbyte1 = new byte[length1];

                                        HttpPostedFile gimage1 = govt_doc;
                                    }
                                }
                            }


                            //fileupload for highcourt doc

                            HttpPostedFile high_court_doc = file_high_court.PostedFile;
                            string high_court_path = file_high_court.PostedFile.FileName;
                            string high_court_name = Path.GetFileName(collector_po_path);
                            string hext = Path.GetExtension(high_court_name);
                            string jpghext = Path.GetExtension(high_court_name);
                            string htype = string.Empty;
                            string htype1 = string.Empty;




                            if (high_court_doc != null && high_court_doc.ContentLength > 0)
                            {

                                try
                                {
                                    string location = HttpContext.Current.Server.MapPath("~/LandSettlementPattas/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "HIGHCOURT/" + "/" + DT.Rows[0]["ID"].ToString() + "/");

                                    if (!Directory.Exists(location))
                                    {
                                        Directory.CreateDirectory(location);

                                    }

                                    string highcourtpath = location + Path.GetFileName(high_court_doc.FileName);
                                    high_court_doc.SaveAs(highcourtpath);

                                    if (high_court_doc != null && high_court_doc.ContentLength > 0)
                                    {

                                        txt_high_court_doc.Text = high_court_doc.FileName;
                                    }
                                    DataRow dr = dtUploadFiles.NewRow();
                                    dr["Option1"] = DT.Rows[0]["ID"].ToString();
                                    dr["Option2"] = location;
                                    dr["Option3"] = high_court_doc.FileName;
                                    dr["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                                    dr["Option5"] = "HIGHCOURT";
                                    dtUploadFiles.Rows.Add(dr);
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('High Court Documents Location Created Error !')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                                if (high_court_doc != null && high_court_doc.ContentLength > 0)
                                {

                                    switch (hext)
                                    {
                                        case ".pdf":
                                            type = "pdf";

                                            break;
                                    }
                                    switch (jpghext)
                                    {
                                        case ".jpg":
                                            type1 = "jpg";
                                            break;
                                    }
                                    if (htype != string.Empty)
                                    {
                                        Stream filestream = high_court_doc.InputStream;
                                        BinaryReader br = new BinaryReader(filestream);

                                    }
                                    if (htype1 != string.Empty)
                                    {
                                        int length1 = high_court_doc.ContentLength;
                                        byte[] imgbyte1 = new byte[] { };
                                        imgbyte1 = new byte[length1];

                                        HttpPostedFile himage1 = high_court_doc;

                                    }

                                }
                            }
                            BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUploadFiles;
                            if(dtUploadFiles.Rows.Count > 0)
                            {
                                 ProjectRofrBAL.GetMasterDetails.land_transfer_files(BeneficiaryDetailsobj);
                              
                            }
                           // gvFiles.Visible = true;
                           
                        }
                        Bindrdo_docs();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Registration failed !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                    }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        public Boolean validation()
        {
            bool mandatoryflag = false;

            if (txt_mandal.Text == "")
            {
                mandatoryflag = true;
            }

            if (txt_village.Text == "")
            {
                mandatoryflag = true;
            }
            if (txt_rsno.Text == "")
            {
                mandatoryflag = true;
            }
            if (txt_extent.Text == "")
            {
                mandatoryflag = true;
            }
            if (txt_ltrp.Text == "")
            {
                mandatoryflag = true;
            }
            if (txt_ltrpdate.Text == "")
            {
                mandatoryflag = true;
            }
            if (txt_OldDateoforder.Text == "")
            {
                mandatoryflag = true;
            }
            return mandatoryflag;


        }
        protected void rbtn_orders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_rdo_upload_Click(object sender, EventArgs e)
        {

            if (File_rdo_doc.HasFiles)
            {
                foreach (HttpPostedFile rdoFile in File_rdo_doc.PostedFiles)
                {
                    lbl_rdo_doc.Text += String.Format("{0}<br />", rdoFile.FileName);
                }
            }
            Label7.Text = file_high_court.PostedFile.FileName;
            Label4.Text= file_collector_po.PostedFile.FileName;
            Label6.Text = file_govt.PostedFile.FileName;

        }

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~//test//ViewLandTransferRegulation.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(cal_date_orders.Visible == true)
            {
                cal_date_orders.Visible = false;
            }
            else
            {
                cal_date_orders.Visible = true;
            }
        }

        protected void cal_date_orders_SelectionChanged(object sender, EventArgs e)
        {
            txt_ltrpdate.Text = cal_date_orders.SelectedDate.ToString("d");
          //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders1_SelectionChanged(object sender, EventArgs e)
        {
            txt_ltrpdate1.Text = cal_date_orders1.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders2_SelectionChanged(object sender, EventArgs e)
        {
            txt_ltrpdate2.Text = cal_date_orders2.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        protected void cal_date_orders3_SelectionChanged(object sender, EventArgs e)
        {
            txt_ltrpdated.Text = cal_date_orders3.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }

        protected void cal_date_orders4_SelectionChanged(object sender, EventArgs e)
        {
            txt_ltrpdate4.Text = cal_date_orders4.SelectedDate.ToString("d");
            //  cal_date_orders.Visible = false;
        }
        private void Reset()
        {
            Session["updateId"] = "0";
            txt_village.Text = "";
            txt_mandal.Text = "";
            txt_rsno.Text = "";
            txt_extent.Text = "";
            txt_ltrp.Text = "";
            txt_OldDateoforder.Text = "";
            txt_ltrpdate.Text = "";
            txt_cma_no.Text = "";
            txt_appeal_no.Text = "";
            txt_rpnm.Text = "";
            txt_wpno.Text = "";
            txt_ltrpdate1.Text = "";
            txt_ltrpdate2.Text = "";
            txt_ltrpdated.Text = "";
            txt_ltrpdate4.Text = "";
            Radiobox_cma.ClearSelection();
            Radiobox_appeal.ClearSelection();
            Radiobox_rpno.ClearSelection();
            Radiobox_wpno.ClearSelection();
            txt_land_purpose.Text = "";
            txt_remarks.Text = "";
            txt_ac_cts.Text = "";
            txt_hec.Text = "";
            rbtn_orders.ClearSelection();

            txt_name.Text = "";
            txt_rdo_sdc_doc.Text = "";
            txt_collector_po_doc.Text = "";
            txt_govt_doc.Text = "";
            txt_high_court_doc.Text = "";
            gvFiles.Visible = false;
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Bindrdo_docs()
        {
            //int Id = int.Parse((string)(Session["updateId"]));
            //DataTable dt = Landsettlementpattas.GetRdoDocuments(Id);
            //if (dt.Rows.Count > 0)
            //{
            //    gvFiles.Visible = true;
            //    gvFiles.DataSource = dt;
            //    gvFiles.DataBind();
            //}
            //else
            //{
            //    gvFiles.Visible = false;
            //}
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFiles.EditIndex = -1;
            Bindrdo_docs();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFiles.EditIndex = e.NewEditIndex;
            Bindrdo_docs();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
        }

        protected void gvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)(sender);
                string Id = btn.CommandArgument;
                Session["Id"] = Id;
                string url = "View_Land_Files.aspx";
                Session["fname"] = (btn.FindControl("lblFile") as Label).Text;

                string s = "window.open('" + url + "', 'popup_window', 'width=1350,height=660,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}