using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Dynamic;
using System.Drawing;
using System.Management;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ROFR.Controllers;
using ROFR.NewHelper;
using System.Reflection;
using static ROFR.Models.crfclass;

namespace ROFR.helper
{
    public class GiribhumiSupport
    {

        Giribhumi_get userObj = new Giribhumi_get();

        HealthConnection hc = new HealthConnection();
        //newly adding  GetLandStatusReportBeneficiary
        public dynamic Get_LandStatus_Beneficiary_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.LandStatus_Beneficiaryreport_Sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        //newly adding  GetLandStatusReport
        public dynamic Get_LandStatus_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.LandStatus_report_Sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        //newly adding  RythubharosaPaymentStatus
        public dynamic Get_RythubharosaPaymentStatus_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetRythubharosaPaymentstatus_report_Sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        //newly adding  benificary report
        public dynamic Get_benificiary_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetBenificiary_report_Sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Get_Ecrop_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetAdangal_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Girivikasam_Rofr_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Girivikasam_Rofr_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Epassbook_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Epassbook_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic ViewEpassbook_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataSet dt = userObj.ViewEpassbook_sp(obj);
                string filename = string.Empty;
                string path = string.Empty;
                dt.Tables[0].Columns.Add("Base64Image", typeof(byte[]));
                if (dt != null && dt.Tables.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (dt.Tables[0].Rows.Count > 0)

                        {
                            if (dt.Tables[0].Rows[i]["Image1"].ToString() != "NA" && dt.Tables[0].Rows[i]["Imagepath"].ToString() != "NA")
                            {
                                filename = dt.Tables[0].Rows[i]["Image1"].ToString();
                                path = dt.Tables[0].Rows[i]["Imagepath"].ToString();
                                DisplayImages(dt.Tables[0].Rows[i], "Base64Image", (path + filename));

                            }
                            else
                            {
                                string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");
                                DisplayImages(dt.Tables[0].Rows[i], "Base64Image", (imgpath));


                            }
                        }
                    }
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rofr_Masters_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rofr_Masters_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Girivikasam_Masters_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Girivikasam_Masters_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rythubarosa_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubarosa_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rofr_Extent_data_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rofr_Extent_data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        private void DisplayImages(DataRow row, string img, string ImagePath)

        {

            FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

            byte[] ImgData = new byte[stream.Length];

            stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

            stream.Close();

            row[img] = ImgData;

        }


        public dynamic Multipart_Image_Valid(dynamic obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Multipart_Image_sp(obj);


                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "Success")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = "Updated Successfully";


                }
                else if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "101")
                {

                    obj_data.Status = "101";
                    obj_data.Message = "Failed";


                    obj_data.Reason = "Plot Id does not exists";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }



        public dynamic updateImage_Valid(dynamic obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.update_farmerimage_sp(obj);


                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "Success")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = "Updated Successfully";
                }

                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }





        public dynamic Rofr_Plot_Details_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string filename = string.Empty;
                string path = string.Empty;
                string apath = string.Empty;
                DataTable dt = userObj.Rofr_Plot_Details_sp(obj);
                dt.Columns.Add("LImage", typeof(byte[]));
                dt.Columns.Add("LImage1", typeof(byte[]));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count > 0)

                    {
                        if ((dt.Rows[i]["Land_Imagepath"].ToString() != "NA" && dt.Rows[i]["Land_Image"].ToString() != "NA"))
                        {
                            filename = dt.Rows[i]["Land_Image"].ToString();
                            path = dt.Rows[i]["Land_Imagepath"].ToString();



                            DisplayImages(dt.Rows[i], "LImage", (path + "/" + filename));


                        }

                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            DisplayImages(dt.Rows[i], "LImage", (imgpath));


                        }
                        if ((dt.Rows[i]["Land_Imagepath1"].ToString() != "NA" && dt.Rows[i]["Land_Image1"].ToString() != "NA"))
                        {
                            filename = dt.Rows[i]["Land_Image1"].ToString();
                            path = dt.Rows[i]["Land_Imagepath1"].ToString();



                            DisplayImages(dt.Rows[i], "LImage1", (path + "/" + filename));


                        }

                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            DisplayImages(dt.Rows[i], "LImage1", (imgpath));

                        }
                    }
                }
                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rofr_masters_data_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rofr_masters_data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.message = "Success";
                    obj_data.status = "1";
                    obj_data.villages_list = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.message = "Failure";

                    obj_data.status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rofr_mobile_version_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rofr_mobile_version_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.message = "Success";
                    obj_data.status = "1";
                    //obj_data.villages_list = dt;

                    // obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.message = "Failure";

                    obj_data.status = "0";
                    //  obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Farmer_Details_Card_valid()
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Farmer_Details_Card_sp();

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Farmer_Card_valid()
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Farmer_Card_sp();

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Farmer_Card_Compartment_valid()
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Farmer_Card_Compartment_sp();

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Land_Status_Report_valid()
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Land_Status_Report_sp();

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Land_Images_Report_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Land_Images_Report_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rofr_ben_Details_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rofr_ben_Details_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    //if (dt.Rows[0]["Dlcpath"].ToString() != null)
                    //{
                    //    if (dt.Rows[0]["Dlcpath"].ToString() != "")
                    //    {
                    //        string uriPath = dt.Rows[0]["Dlcpath"].ToString();
                    //        string localPath = new Uri(uriPath).LocalPath;
                    //        Byte[] bytes = File.ReadAllBytes(localPath);
                    //        String file = Convert.ToBase64String(bytes);
                    //        obj_data.pdfbyte = file;
                    //    }
                    //}
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Multipart_Dlc_Valid(dynamic obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Multipart_Dlc_sp(obj);


                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "SUCCESS")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = "Updated Successfully";


                }
                else if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "101")
                {

                    obj_data.Status = "101";
                    obj_data.Message = "Failed";
                    obj_data.Reason = "Plot Id does not exists";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic RB_STATUS_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = hc.RB_STATUS_SP(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    //DataTable dtn = dt.DefaultView.ToTable(true, "EXISTING_RC_NUMBER");
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic LAND_HOLDING_DYNAMIC_SERVICE()
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.LAND_HOLDING_DYNAMIC_SERVICE();

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Farmer_Images_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Farmer_Images_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Dlc_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Dlc_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Rythubharosa_2019_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubharosa_2019_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Rythubharosa_2020_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubharosa_2020_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Land_Invalid_Data_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Land_Invalid_Data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Beneficiary_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Beneficiary_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Missing_Data_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Missing_Data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Benificiarywise_Land_Status_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Benificiarywise_Land_Status_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public static DataTable Get_RTGS_INSERT_Valid(addbeneficiary_details obj)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Get_RTGS_INSERT_sp(obj);
        }
        public string VerifyToken(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            #region "Header Response"			
            string token = string.Empty;
            string pwd = string.Empty;
            string username = string.Empty;
            try
            {
                //if (headers.Contains("Session_Key"))
                //{
                //    token = headers.GetValues("Session_Key").First();
                //}
                if (headers.Contains("username"))
                {
                    username = headers.GetValues("username").First();
                }
                if (headers.Contains("password"))
                {
                    pwd = headers.GetValues("password").First();
                }

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd) /*|| string.IsNullOrEmpty(token)*/)
                {
                    return "Failure, Authentication Token Header is Missing";
                }
                else
                {
                    //string dbtoken = "969A687C0F273H0756A89347529CF5D377000995FC1B9GG97CD0TYU07A215TRIBAL";

                    if (/*token == dbtoken &&*/ username == "Tribal" && pwd == "Tribal@456")
                    {
                        return "success";
                    }
                    else
                    {
                        return "Failure, Authentication is Invalid";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            #endregion
        }
        public dynamic ROFR_RTGS_Valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_RTGS_INSERT_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";
                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic ROFR_RTGS_STATUSFLAG_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_RTGS_INSERT_sp(obj);

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")

                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    //obj_data.Data = dt;

                    obj_data.Reason = "Data Updated Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic ROFR_JALAKALA_RES_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ROFR_JALAKALA_RES_sp(obj);

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")

                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    //obj_data.Data = dt;
                    obj_data.Reason = "Data Updated Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic ROFR_YSR_JALAKALA_Valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ROFR_YSR_JALAKALA_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic ROFR_NREGA_Valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ROFR_NREGA_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Message = "Failure";

                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public object Log(dynamic strMsg, string mappath, string employeeid)
        {
            try
            {

                string strPath = mappath + "\\" + DateTime.Now.ToString("MMddyyyy") + "\\" + employeeid;
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                string path = strPath + "\\" + "Log" + DateTime.Now.ToString("yyyyMMddhhmmssmmm") + serNumber().ToString();
                StreamWriter swLog = new StreamWriter(path + ".txt", true);
                swLog.WriteLine(strMsg);
                swLog.Close();
                swLog.Dispose();
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public int serNumber()
        {
            Random r = new Random();
            int random_num = r.Next(0, 99999);
            return random_num;
        }

        public dynamic RYTHUBHAROSA_MAY_2021(dynamic root)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                var json = JsonConvert.SerializeObject(root);
                dynamic objre = JsonConvert.DeserializeObject<ExpandoObject>(json);
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                DataTable dt = userObj.GetRythuBharosaStatus_May21(objre.type, objre.itda, objre.dist, objre.mandal, objre.village, objre.username, objre.userprevileges);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic jalakalreport(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.jalakalareport_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        //public dynamic Benficiarywise_phasesdata_valid(addbeneficiary_details obj)
        //{
        //    dynamic obj_data = new ExpandoObject();
        //    try
        //    {

        //        DataTable dt = userObj.Land_Images_Report_sp(obj);

        //        if (dt != null && dt.Rows.Count > 0)
        //        {


        //            obj_data.Message = "Success";
        //            obj_data.Status = "1";
        //            obj_data.Data = dt;

        //            obj_data.Reason = "Data Loaded Successfully";


        //        }
        //        else
        //        {
        //            obj_data.Message = "Failure";

        //            obj_data.Status = "0";
        //            obj_data.Reason = " No Data Available";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        obj_data.Status = "Failure";
        //        obj_data.Reason = ex.Message.ToString();
        //    }
        //    finally
        //    {

        //    }
        //    return obj_data;
        //}

        public dynamic farUploadImage(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.update_farmerimage_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;

                    obj_data.Reason = "Data Updated Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "Updation Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }



        public dynamic GetUploadImage(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Getfarmerimge_details(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;

                    obj_data.Reason = "Data loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "Loading Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        //Newly Adding NewService
        public dynamic Get_Itdas(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Itdas_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        //15-09-2026 Add New Get_AllDropDowns Method//
        public dynamic Get_AllDropDowns(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_AllDropDowns_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic GetFarmerDetails(CropDetails cropDetails)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetFarmerDetails_SP(cropDetails);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic GetPlotdetalis(CropDetails cropDetails)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetPlotdetalis_SP(cropDetails);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic GetCropCategory(CropDetails cropDetails)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetCropCategory_SP(cropDetails);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic GetCropdetalis(CropDetails cropDetails)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.GetCropdetalis_SP(cropDetails);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Get_Districts(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Districts_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Get_Mandals(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Mandals_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Get_Villages(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Login_status_data_valid(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Login_status_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.message = "Success";
                    obj_data.status = "1";
                    obj_data.Details = dt;
                    obj_data.Reason = "Logout Successfully";
                }
                else
                {
                    obj_data.message = "Failure";
                    obj_data.Details = "";
                    obj_data.status = "0";
                    obj_data.Reason = "Logout Failed";
                }

            }
            catch (Exception ex)
            {
                obj_data.status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Get_healthdata(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                var result = new List<oiltypes>();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP1(obj);
                if (dt != null && dt.Rows.Count > 0)
                {

                    DataTable dt1 = hn.TWD_COMMENTS_REPORT_SP2(obj);
                    foreach (DataRow dr in dt.Rows)
                    {
                        oiltypes cm = new oiltypes();
                        var unitsList = new List<unittypes>();
                        cm.oilname = dr["CATEGORY_NAME"].ToString();
                        cm.oilid = Convert.ToInt32(dr["CATEGORY_ID"]);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            var oilid1 = Convert.ToInt32(dr1["CATEGORY_ID"].ToString());
                            if (oilid1 == cm.oilid)
                            {
                                unittypes rm = new unittypes();
                                rm.unitid = Convert.ToInt32(dr1["UNIT_ID"]);
                                rm.unitname = dr1["UNIT_NAME"].ToString();
                                rm.unitprice = Convert.ToInt32(dr1["PRICE"]);
                                unitsList.Add(rm);
                            }

                        }
                        cm.unitsList = unitsList;
                        result.Add(cm);
                    }
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = result;
                    obj_data.Reason = "Data Loaded Sucessfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }
        public dynamic Get_healthdata1(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP2(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);
                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Sucessfully";

                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Found";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Get_healthdata2(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP3(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt.Rows[0]["STATUS"];
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }


            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();

            }

            return obj_data;
        }



        public dynamic Get_healthdata3(addbeneficiary_details obj)
        {
            DataTable dt = new DataTable();
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                //if (obj.basestring != null || obj.basestring != "")
                //{
                //    string[] tokens = obj.basestring.Split(',');
                //    List<string> AuthorList = new List<string>();
                //    foreach (var token in tokens)
                //    {
                //        if (token == null || token == "" || token == "NULL")
                //        {
                //            AuthorList.Add(token);
                //        }
                //        else {
                //            string target1 = HttpContext.Current.Server.MapPath("DamagedImages") + "\\" + DateTime.Now.ToString("MMddyyyy");
                //            if (!Directory.Exists(target1))
                //            {
                //                Directory.CreateDirectory(target1);
                //            }
                //            string target = target1 + "\\" + obj.RbkId + "_" + obj.categoryid + "." + obj.extension;
                //            obj.imagepath = SavePdf(token, target);
                //            AuthorList.Add(obj.imagepath);
                //        }

                //    }
                //    obj.imagepaths = string.Join(",", AuthorList);
                //    dt = hn.TWD_COMMENTS_REPORT_SP4(obj);                
                //}

                //else
                //{
                //    dt = hn.TWD_COMMENTS_REPORT_SP4(obj);
                //}

                if (obj.basestring != null || obj.basestring != "")
                {

                    string target1 = HttpContext.Current.Server.MapPath("DamagedImages") + "\\" + DateTime.Now.ToString("MMddyyyy");
                    if (!Directory.Exists(target1))
                    {
                        Directory.CreateDirectory(target1);
                    }

                    string target = target1 + "\\" + obj.RbkId + "_" + obj.categoryid + "." + obj.extension;
                    obj.imagepath = SavePdf(obj.basestring, target);

                    dt = hn.TWD_COMMENTS_REPORT_SP4(obj);
                }
                else
                {
                    dt = hn.TWD_COMMENTS_REPORT_SP4(obj);
                }



                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic INSTSTOCKREC(addbeneficiary_details obj)
        {
            DataTable dt = new DataTable();
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();

                dt = hn.TWD_COMMENTS_REPORT_SP4(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("INSTSTOCKREC_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic versioncheck(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.check_version(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = "Version Checked Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "Version Checking Failed";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_healthdata4(addbeneficiary_details obj)
        {
            DataTable dt = new DataTable();
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                if (obj.basestring != null || obj.basestring != "")
                {

                    string target1 = HttpContext.Current.Server.MapPath("PaymentImages") + "\\" + DateTime.Now.ToString("MMddyyyy");
                    if (!Directory.Exists(target1))
                    {
                        Directory.CreateDirectory(target1);
                    }

                    string target = target1 + "\\" + obj.RbkId + "_" + obj.VoucharNo + "." + obj.extension;
                    obj.imagepath = SavePdf(obj.basestring, target);

                    dt = hn.TWD_COMMENTS_REPORT_SP5(obj);
                }
                else
                {
                    dt = hn.TWD_COMMENTS_REPORT_SP5(obj);
                }


                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("PAYMENT_DETAILS_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }
        public string SavePdf(string base644str, string path)
        {
            try
            {

                try
                {
                    byte[] bytes = Convert.FromBase64String(base644str);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        FileStream fs = new FileStream(path, FileMode.Create);
                        ms.WriteTo(fs);
                        ms.Close();
                        fs.Close();
                        fs.Dispose();
                    }

                    return path;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            catch (Exception ex)
            {
                return "101";
            }
        }

        public dynamic ProfilesUpdate(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.ProfileUpdate_SP(obj);


                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    //obj_data.Data = new DataTable();
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Profile_PasswordUpdate_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }
        public dynamic IndentRaise(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {




                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.Indent_Raise_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);


                //if (dt.Rows[0]["STATUS"].ToString() == "1")
                //{
                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("IndentRaise_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_healthdata5(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP6(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);
                //if (dt.Rows[0]["STATUS"].ToString() == "1")
                //{

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DAILY_STOCK_UPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_salesUpdated(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.Sales_SP6(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);
                //if (dt.Rows[0]["STATUS"].ToString() == "1")
                //{

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DAILY_SALES_UPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic Get_Login(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.Officer_Login_Sp(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Login Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Login_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }



        public dynamic Get_DoApprovals(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.DO_APPROVALS_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();



                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Edit_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic Get_Do_Dates(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.DO_APPROVALS_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";



                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DO_Edit_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_DOApprovals_Details(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();


                DataTable dt = hn.TWD_COMMENTS_REPORT_SP1(obj);



                DataTable dt1 = hn.DO_APPROVALS_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);
                var result = new List<oiltypes>();

                if (dt1 != null && dt1.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        oiltypes cm = new oiltypes();
                        var unitsList = new List<unittypes>();
                        cm.oilname = dr["CATEGORY_NAME"].ToString();
                        cm.oilid = Convert.ToInt32(dr["CATEGORY_ID"]);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            var oilid1 = Convert.ToInt32(dr1["CATEGORY_ID"].ToString());
                            if (oilid1 == cm.oilid)
                            {
                                unittypes rm = new unittypes();
                                rm.unitid = Convert.ToInt32(dr1["UNIT_ID"]);
                                rm.unitname = dr1["UNIT_NAME"].ToString();
                                rm.unitprice = Convert.ToInt32(dr1["UNIT_PRICE"]);
                                rm.Quantity = Convert.ToInt32(dr1["QUANTITY"]);
                                rm.Totlprice = (dr1["TOTAL_PRICE"].ToString());
                                unitsList.Add(rm);
                            }
                        }
                        cm.unitsList = unitsList;
                        result.Add(cm);
                    }
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = result;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";

                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DOApprovalDetails_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_reports(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();


                DataTable dt = hn.Reports_SP(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Report_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic Payment_Count(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();


                DataTable dt = hn.TWD_COMMENTS_REPORT_SP5(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic Payment_updation(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();


                DataTable dt = hn.payment_status(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic EOSTKACK(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();

                DataTable dt = hn.TWD_COMMENTS_REPORT_SP1(obj);
                DataTable dt1 = hn.EOstockack(obj);
                var result = new List<oiltypes>();
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        oiltypes cm = new oiltypes();
                        var unitsList = new List<unittypes>();
                        cm.oilname = dr["CATEGORY_NAME"].ToString();
                        cm.oilid = Convert.ToInt32(dr["CATEGORY_ID"]);

                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            var oilid1 = Convert.ToInt32(dr1["CATEGORY_ID"].ToString());
                            if (oilid1 == cm.oilid)
                            {
                                unittypes rm = new unittypes();
                                rm.unitid = Convert.ToInt32(dr1["UNIT_ID"]);
                                rm.unitname = dr1["UNIT_NAME"].ToString();
                                rm.unitprice = Convert.ToInt32(dr1["UNIT_PRICE"]);
                                rm.Quantity = Convert.ToInt32(dr1["QUANTITY"]);
                                rm.Totlprice = (dr1["TOTAL_PRICE"].ToString());
                                rm.stockid = dr1["STOCK_ID"].ToString();
                                unitsList.Add(rm);
                            }
                        }
                        cm.unitsList = unitsList;
                        result.Add(cm);
                    }
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = result;
                    obj_data.Reason = "Data Loaded Successfully";
                }

                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Paymentcount_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }



        public dynamic EOSTKACKDASHBOARD(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();


                DataTable dt = hn.EOSTOCKdboard(obj);

                if (dt != null && dt.Rows.Count > 0)
                {


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("StockDashBoard_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }
        public dynamic Get_SO_Approvals(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.SO_APPROVALS_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();



                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("SO_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic Get_Ceo_Approval(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.CEO_APPROVALS_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();



                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("CEO_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_SOApprovals_Details(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP1(obj);
                DataTable dt1 = hn.SO_APPROVALS_SP(obj);
                var result = new List<oiltypes>();
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        oiltypes cm = new oiltypes();
                        var unitsList = new List<unittypes>();
                        cm.oilname = dr["CATEGORY_NAME"].ToString();
                        cm.oilid = Convert.ToInt32(dr["CATEGORY_ID"]);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            var oilid1 = Convert.ToInt32(dr1["CATEGORY_ID"].ToString());
                            if (oilid1 == cm.oilid)
                            {
                                unittypes rm = new unittypes();
                                rm.unitid = Convert.ToInt32(dr1["UNIT_ID"]);
                                rm.unitname = dr1["UNIT_NAME"].ToString();
                                rm.unitprice = Convert.ToInt32(dr1["UNIT_PRICE"]);
                                rm.Quantity = Convert.ToInt32(dr1["QUANTITY"]);
                                rm.Totlprice = (dr1["TOTAL_PRICE"].ToString());
                                unitsList.Add(rm);
                            }
                        }
                        cm.unitsList = unitsList;
                        result.Add(cm);
                    }


                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = result;
                    obj_data.Reason = "Data Loaded Successfully";



                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DOApprovalDetails_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_CEO_Approvals(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP1(obj);
                DataTable dt1 = hn.CEO_APPROVALS_SP(obj);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    var result = new List<oiltypes>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        oiltypes cm = new oiltypes();
                        var unitsList = new List<unittypes>();
                        cm.oilname = dr["CATEGORY_NAME"].ToString();
                        cm.oilid = Convert.ToInt32(dr["CATEGORY_ID"]);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            var oilid1 = Convert.ToInt32(dr1["CATEGORY_ID"].ToString());
                            if (oilid1 == cm.oilid)
                            {
                                unittypes rm = new unittypes();
                                rm.unitid = Convert.ToInt32(dr1["UNIT_ID"]);
                                rm.unitname = dr1["UNIT_NAME"].ToString();
                                rm.unitprice = Convert.ToInt32(dr1["UNIT_PRICE"]);
                                rm.Quantity = Convert.ToInt32(dr1["QUANTITY"]);
                                rm.Totlprice = (dr1["TOTAL_PRICE"].ToString());
                                unitsList.Add(rm);
                            }
                        }
                        cm.unitsList = unitsList;
                        result.Add(cm);
                    }
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = result;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("CEO_Approvals_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";

                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }


        public dynamic INSERT_DatePayment(addbeneficiary_details obj)
        {

            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.datewise_REPORT_SP5(obj);

                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    //obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("DATE_WISE_PAYMENT_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }




        public dynamic INsertdamageinsert(addbeneficiary_details obj)
        {
            DataTable dt = new DataTable();
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();

                if (obj.basestring != null || obj.basestring != "")
                {

                    string target1 = HttpContext.Current.Server.MapPath("DamagedImages") + "\\" + DateTime.Now.ToString("MMddyyyy");
                    if (!Directory.Exists(target1))
                    {
                        Directory.CreateDirectory(target1);
                    }

                    string target = target1 + "\\" + obj.RbkId + "_" + obj.categoryid + "." + obj.extension;
                    obj.imagepath = SavePdf(obj.basestring, target);

                    dt = hn.EOstockack(obj);
                }
                else
                {
                    dt = hn.EOstockack(obj);
                }



                if (dt.Rows[0]["STATUS"].ToString() == "1")
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("STOCK_RECEIVED_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }
        public dynamic Get_FamilyCard(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.FamilyCard_SP(obj);

                //DataTable dt = userObj.Get_Villages_sp(obj);

                if (dt.Rows.Count > 0)
                {
                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("FamilyCard_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic GetData_Ap_Tourism(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.GetDataAp_Tourism_SP(obj);
                if (dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Ap_Tourism_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Insert_Ap_Tourism(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.InsertAp_Tourism_SP(obj);
                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = dt.Rows[0]["STATUS_TEXT"].ToString();
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("Insert_Ap_Tourism_Details_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }

            return obj_data;
        }

        public dynamic Get_DisReport(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Dist_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }



        public dynamic GetRtgsdata(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_RtgsData_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }



        public dynamic Getdata(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }

        public dynamic GetRofrdata(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {


                DataTable dt = userObj.Get_RofrData_sp(obj);


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }

        public dynamic ROFR_GetUpdate(ROFRData obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                AgriClass ag = new AgriClass();
                DataTable dt = userObj.ROFR_GetUpdate_sp(obj);

                Giribhumi_get gs = new Giribhumi_get();
                if (dt != null && dt.Rows.Count > 0)
                {
                    string UniqueID = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        UniqueID = ag.GenerateLandParcelId();
                        string uniquId = UniqueID?.ToString() ?? string.Empty;
                        string id = dr["ID"] != DBNull.Value ? dr["ID"].ToString() : string.Empty;
                        string Benificiaryid = dr["benficiary_id2"] != DBNull.Value ? dr["benficiary_id2"].ToString() : string.Empty;
                        string Aadhaarno = dr["AADHAAR_NO"] != DBNull.Value ? dr["AADHAAR_NO"].ToString() : string.Empty;
                        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(Benificiaryid) || string.IsNullOrEmpty(Aadhaarno))
                        {
                            Console.WriteLine("Warning: One or more values are empty.");
                        }
                        gs.ROFR_Updated_sp(uniquId, id, Benificiaryid, Aadhaarno);
                        //gs.ROFR_Updated_sp(uniquId, id);
                    }
                    // Success response
                    obj_data.Message = "Success";
                    obj_data.Status = "1";
                    obj_data.Reason = "Data Updated successfully.";
                }
                else
                {
                    obj_data.Message = "Failure";
                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public RofrResponse GetRofrdata1(addbeneficiary_details obj)
        {
            var response = new RofrResponse();

            try
            {
                DataTable dt = userObj.Get_RofrData_sp1(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    response.Status = "1";
                    response.Message = "Success";
                    response.Reason = "Data Loaded Successfully";
                    response.Data = dt.DataTableToList<RofrDataModelRes>(); //ConvertDataTableToList(dt);
                }
                else
                {
                    response.Status = "0";
                    response.Message = "Failure";
                    response.Reason = "No Data Available";
                    response.Data = new List<RofrDataModelRes>();
                }
            }
            catch (Exception ex)
            {
                response.Status = "Failure";
                response.Reason = ex.Message;
                response.Data = new List<RofrDataModelRes>();
            }

            return response;
        }

        public List<RofrDataModel> ConvertDataTableToList(DataTable dt)
        {
            List<RofrDataModel> list = new List<RofrDataModel>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RofrDataModel item = new RofrDataModel();
                    item.itdaname = row["ITDA_NAME"].ToStr();
                    item.districtname = row["District"].ToStr();
                    item.districtcode = row["District_Code"].ToStr();
                    item.mandalname = row["Mandal"].ToStr();
                    item.mandalcode = row["Mandal_Code"].ToStr();
                    item.Panchatname = row["Gram_Panchayat"].ToStr();
                    item.panchatcode = row["Grama_Panchayat_Code"].ToStr();
                    item.villagename = row["REV_Village"].ToStr();
                    item.villagecode = row["REVENUE_VILLAGECODE"].ToStr();
                    item.Hibitionname = row["Habitation"].ToStr();
                    item.Beneficaryid = row["benficiary_id"].ToStr();
                    item.Farmarname = row["ROFR_PATTADAAR"].ToStr();
                    item.Fathername = row["Father_Name"].ToStr();
                    item.Dob = row["DOB"].ToStr();
                    item.Gender = row["GENDER"].ToStr();
                    item.Cast = row["Caste"].ToStr();
                    item.SubCast = row["Sub_Caste"].ToStr();
                    item.ForestDivision = row["Forest_Division"].ToStr();
                    item.ForestRange = row["Forest_Range"].ToStr();
                    item.ForestBeat = row["Forest_Beat"].ToStr();
                    item.Forestblock = row["Forest_Block"].ToStr();
                    item.pattanumber = row["ROFR_PATTANO"].ToStr();
                    item.compartmentno = row["Compartment_No"].ToStr();
                    item.platid = row["Id"].ToStr();
                    item.extent = row["ExtentPlotArea"].ToStr();
                    list.Add(item);


                }
                // Map other columns accordingly

            }

            return list;
        }

        public dynamic GetRofrdataDynamic(addbeneficiary_details obj)
        {
            var response = new RofrResponse();

            try
            {
                DataTable dt = userObj.Get_RofrData_sp1(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    response.Status = "1";
                    response.Message = "Success";
                    response.Reason = "Data Loaded Successfully";
                    response.Data = dt.DataTableToList<RofrDataModelRes>(); //ConvertDataTableToList(dt);
                }
                else
                {
                    response.Status = "0";
                    response.Message = "Failure";
                    response.Reason = "No Data Available";
                    response.Data = new List<RofrDataModelRes>();
                }
            }
            catch (Exception ex)
            {
                response.Status = "Failure";
                response.Reason = ex.Message;
                response.Data = new List<RofrDataModelRes>();
            }

            return response;
        }

        //28-04-2025
        public dynamic GetRofrdataForAGri(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {


                DataTable dt = userObj.Get_RofrDataForAgri_sp(obj);


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }


        public dynamic GetRofrPushAGri(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {


                DataTable dt = userObj.Get_RofrPushToAgri_sp(obj);


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }

        public dynamic GetRofrPushAGri1(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {


                DataTable dt = userObj.Get_RofrPushToAgri_sp1(obj);


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "1";
                    obj_data.Message = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;


        }

        //17-02-2026 Forest Land Details For Agriculture
        public List<LandDetailsResponse> GetForestLandDetails(addbeneficiary_details request)
        {
            if (string.IsNullOrEmpty(request.village_lgd_code))
                throw new ApplicationException("101");

            DataTable dt = userObj.ForestlandDetailsSp(request);

            if (dt == null || dt.Rows.Count == 0)
                throw new ApplicationException("102");

            var groupedData = dt.AsEnumerable()
                .GroupBy(row => new
                {
                    Village = row["village_lgd_code"]?.ToString(),
                    Survey = row["survey_number"]?.ToString()
                });

            var result = new List<LandDetailsResponse>();

            foreach (var group in groupedData)
            {
                var firstRow = group.First();

                var landResponse = new LandDetailsResponse
                {
                    Code = "100",
                    village_lgd_code = group.Key.Village,

                    land_identifiers = new LandIdentifiers
                    {
                        survey_number = group.Key.Survey,
                        unique_land_code = firstRow["unique_land_code"]?.ToString()
                    },

                    total_plot_area = firstRow["total_plot_area"]?.ToString(),
                    total_plot_area_decimal_part = firstRow["total_plot_area_decimal_part"]?.ToString(),
                    area_unit = firstRow["area_unit"]?.ToString(),
                    Message = "Ok",
                    RequestedAt = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),


                    owner_details = group.Select(row => new OwnerDetails
                    {
                        khata_number = row["khata_number"]?.ToString(),
                        farm_id = row["farm_id"]?.ToString(),
                        owner_number = row["owner_number"]?.ToString(),
                        main_owner_number = row["main_owner_number"]?.ToString(),
                        owner_name_ror = row["owner_name_ror"]?.ToString(),
                        owner_name_english = row["owner_name_english"]?.ToString(),
                        owner_extent = row["owner_extent"]?.ToString(),
                        owner_extent_decimal_part = row["owner_extent_decimal_part"]?.ToString(),
                        owner_share = row["owner_share"]?.ToString(),
                        land_usage_type = row["land_usage_type"]?.ToString(),
                        owner_category = row["owner_category"]?.ToString(),
                        identifier_type = row["identifier_type"]?.ToString(),
                        identifier_name_ror = row["identifier_name_ror"]?.ToString(),
                        identifier_name_english = row["identifier_name_english"]?.ToString(),
                        government_liability = row["government_liability"]?.ToString(),
                        private_liability = row["private_liability"]?.ToString(),
                        Resurvey = row["Resurvey"]?.ToString()
                    }).ToList()
                };

                result.Add(landResponse);
            }


            return result;
        }

    }

    public class RofrResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }
        public List<RofrDataModelRes> Data { get; set; }
    }

    public class RofrDataModel
    {
        public string itdaname { get; set; }
        public string districtname { get; set; }
        public string districtcode { get; set; }
        public string mandalname { get; set; }
        public string mandalcode { get; set; }
        public string Panchatname { get; set; }
        public string panchatcode { get; set; }
        public string villagename { get; set; }
        public string villagecode { get; set; }
        public string Hibitionname { get; set; }
        public string Beneficaryid { get; set; }
        public string Farmarname { get; set; }
        public string Fathername { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Cast { get; set; }
        public string SubCast { get; set; }
        public string ForestDivision { get; set; }
        public string ForestRange { get; set; }
        public string ForestBeat { get; set; }
        public string Forestblock { get; set; }
        public string pattanumber { get; set; }
        public string compartmentno { get; set; }
        public string platid { get; set; }
        public string extent { get; set; }

    }
    public class RofrDataModelRes
    {
        public string ITDA_NAME { get; set; }
        public string District { get; set; }
        public string District_Code { get; set; }
        public string Mandal { get; set; }
        public string Mandal_Code { get; set; }
        public string Gram_Panchayat { get; set; }
        public string Grama_Panchayat_Code { get; set; }
        public string REV_Village { get; set; }
        public string REVENUE_VILLAGECODE { get; set; }
        public string Habitation { get; set; }
        public string benficiary_id { get; set; }
        public string ROFR_PATTADAAR { get; set; }
        public string Father_Name { get; set; }
        public string DOB { get; set; }
        public string GENDER { get; set; }
        public string Caste { get; set; }
        public string Sub_Caste { get; set; }
        public string Forest_Division { get; set; }
        public string Forest_Range { get; set; }
        public string Forest_Beat { get; set; }
        public string Forest_Block { get; set; }
        public string ROFR_PATTANO { get; set; }
        public string Compartment_No { get; set; }
        public string Id { get; set; }
        public string ExtentPlotArea { get; set; }

    }
    public static class Apputils
    {
        public static string ToStr(this object value)
        {
            if (value == DBNull.Value || value == null)
                return string.Empty;
            else
                return value.ToString().Trim();

        }
        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                T obj = new T();
                List<string> columnNames = table.Columns.Cast<DataColumn>()
                                .Select(x => x.ColumnName.ToLower())
                                .ToList();

                PropertyInfo[] lstPInfo = obj.GetType().GetProperties().Where(p => columnNames.Contains(p.Name.ToLower())).ToArray();
                foreach (var row in table.AsEnumerable())
                {
                    obj = new T();

                    foreach (var prop in lstPInfo)
                    {
                        try
                        {
                            if (!(row[prop.Name.ToLower()] is DBNull))
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name,
                                                                            BindingFlags.SetProperty | BindingFlags.IgnoreCase |
                                                                            BindingFlags.Public | BindingFlags.Instance);
                                propertyInfo.SetValue(obj, ChangeType(row[prop.Name.ToLower()], propertyInfo.PropertyType), null);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }





    }


}