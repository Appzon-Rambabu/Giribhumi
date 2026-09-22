using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
using ROFR.NewHelper;
using static ROFR.Models.crfclass;

namespace ROFR.helper
{
    public class NewGiribhumiSupport
    {
        //Giribhumi_get userObj = new Giribhumi_get();
        NewGiribhumi_Get userObj = new NewGiribhumi_Get();
        HealthConnection hc = new HealthConnection();

        //newly adding  Get_NotHaving_LandDetais
        public dynamic Get_NotHaving_LandDetais_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.NOtHavingLandDetails_report_Sp(obj);

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

        //newly adding  GetLatlongsAbstractReport
        public dynamic Get_LatlongsAbstract_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.LatlongsAbstractReport_report_Sp(obj);

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
        
        //newly adding  GetLand_Invalid_Data
        public dynamic Get_Land_Invalid_Data_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Land_Invalid_Data_report_Sp(obj);

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

        //newly adding  GetDCL_Abstract
        public dynamic Get_DCL_Abstract_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.DCL_Abstract_report_Sp(obj);

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

        //newly adding  GetFarmer_Images
        public dynamic Get_Farmer_Images_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Farmer_Images_report_Sp(obj);

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
        //newly adding  Get_ItdawiseFarmer_Details
        public dynamic Get_ItdawiseFarmer_Details(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ItdaWise_Farmer_Details_Sp(obj);

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

        //newly adding  GetItdabencountDetails
        public dynamic GetItdabencountDetails(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Itda_ben_count_Sp(obj);

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

        //newly adding  RofrLandPhasesReport
        public dynamic Get_RofrLandPhasesReport(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.RofrLandPhasesReport_SP(obj);

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

        //newly adding  DataAnalysis_MandatoryFields
        public dynamic Get_DataAnalysis_MandatoryFields_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.DataAnalysis_MandatoryFields_Sp(obj);

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
        //newly adding  DataAnalysis_NonMandatoryFields
        public dynamic Get_DataAnalysis_NonMandatoryFields_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.DataAnalysis_NonMandatoryFields_Sp(obj);

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

        //newly adding  Get_Itdawise_Beneficiary_Details
        public dynamic Get_Itdawise_Beneficiary_Details(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ItdaWise_Beneficiary_Details_Sp(obj);

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

        //newly adding  GetDistrict_wise_BeneficiaryMaster_Abstract
        public dynamic District_wise_BeneficiaryMaster_Abstract(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.District_wise_BeneficiaryMaster_Abstract_Sp(obj);

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


        //newly adding  Get_FarmerUpdate_report
        public dynamic Get_FarmerUpdate_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.FarmerUpdate_Sp(obj);

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

        public dynamic GetFarmerDataUpdate(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Farmer_DataUpdate_sp(obj);

                
                if(dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["STATUS"].ToString() == "Success")
                    {
                        obj_data.Status = "Success";
                        obj_data.Message = "Success";
                        obj_data.Reason = "Data Updated Successfully";
                    }
                    else if(dt.Rows[0]["STATUS"].ToString() == "101")
                    {
                        obj_data.Status = "101";
                        obj_data.Message = "Already Aadhar Exists";
                        obj_data.Reason = "Already Aadhar Exists";
                    }
                    else if(dt.Rows[0]["STATUS"].ToString() == "Fail")
                    {
                        obj_data.Status = "Fail";
                        obj_data.Message = "Failure";
                        obj_data.Reason = "Updation Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("FarmerUPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();
                
            }

            return obj_data;
        }

        public dynamic GetwebSiteVisiDataUpdate(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_websiteVisitors_DataUpdate_sp(obj);


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
                string mappath = HttpContext.Current.Server.MapPath("FarmerUPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();

            }

            return obj_data;
        }




        //newly adding  Get_MissingData_report
        public dynamic Get_MissingData_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.MissingData_Sp(obj);

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


        //newly adding  Get_MissingDataDis_report
        public dynamic Get_MissingData_Dis_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.MissingData_Dis_Sp(obj);

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


        //newly adding  Get_MissingDataDownload_report
        public dynamic Get_MissingData_Download_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.MissingData_Download_Sp(obj);

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

        //newly adding  Get_rythubarosa_may20
        public dynamic Get_rythubarosa_may20(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubarosa_May20_Sp(obj);

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

        //newly adding  Get_rythubarosa_may21
        public dynamic Get_rythubarosa_may21(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubarosa_May21_Sp(obj);

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

        //newly adding  Get_rythubarosa_oct20
        public dynamic Get_rythubarosa_oct20(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Rythubarosa_Oct20_Sp(obj);

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

        //newly adding  Get_DistictData_Analysis
        public dynamic Get_DistictData_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.DistictData_Analysis_Sp(obj);

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

        //newly adding  Get_Beni_Master_Analysis
        public dynamic Get_Beni_Master_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.BenificiaryMaster_Analysis_Sp(obj);

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


        //newly adding  Get_AllForestBeat_Master_Analysis
        public dynamic Get_AllForestBeat_Master_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.AllForestBeatMaster_Analysis_Sp(obj);

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


        //newly adding  Get_ForestRange_Master_Analysis
        public dynamic Get_ForestRange_Master_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ForestRangeMaster_Analysis_Sp(obj);

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

        //newly adding  Get_ForestDivision_Master_Analysis
        public dynamic Get_ForestDivision_Master_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ForestDivisionMaster_Analysis_Sp(obj);

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

        //newly adding  Get_CurdForestDivision_Analysis
        public dynamic Get_CurdForestDivision_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.CurdForestDivision_Analysis_Sp(obj);

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

        //newly adding  GetForestMasterDetails_Analysis
        public dynamic GetForestMasterDetails_Analysis(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.CurdForestDivisionDetails_Analysis_Sp(obj);

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

        public dynamic Get_ForestDivisionUpdate(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_ForestDivision_Update_sp(obj);


                if (dt.Rows[0]["status"].ToString() == "1")
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
                string mappath = HttpContext.Current.Server.MapPath("FarmerUPDATE_ExceptionLogs");
                Log sqlmngr = new Log();
                Task WriteTask = Task.Factory.StartNew(() => sqlmngr.exceptionLog(ex.ToString(), mappath, DateTime.Now.Ticks.ToString()));
                obj_data.Status = "0";
                obj_data.Message = "Failed";
                obj_data.Reason = ex.Message.ToString();

            }

            return obj_data;
        }

        public dynamic Get_TwdComments(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.TWD_COMMENTS_REPORT_SP(obj);

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

        //newly adding  GetUpdateLtrCases
        public dynamic GetUpdateLtrCases(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.UpdateLtrCases_Sp(obj);

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

        //newly adding  GetUpdateLtrCases
        public dynamic GetUpdateLtrCasesDetails(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.UpdateLtrCasesDetails_Sp(obj);

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

        public dynamic Get_LandHolding(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                HealthConnection hn = new HealthConnection();
                DataTable dt = hn.RB_STATUS_SP(obj);

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


        //newly adding  GetLtrs
        public dynamic GetViewLtrs(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ViewLtr_Sp(obj);

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

        //newly adding  GetLtrdata
        public dynamic GetViewLtrsData(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.ViewLtrData_Sp(obj);

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


        //newly adding  Get_Itdawise_Beneficiary_Details
        public dynamic FarmerLand_Details(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.FarmerLand_Details_Sp(obj);

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

        public dynamic Getdata1(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_Data_sp1(obj);

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
        public dynamic Getdata2(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_VillageData_sp(obj);

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

        public dynamic VillageValiUpdated(addbeneficiary_details obj)
        {

            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.VillageValiUpdated_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string status = dt.Rows[0]["STATUS"]?.ToString()?.Trim();
                    string message = dt.Rows[0]["STATUS_TEXT"]?.ToString();
                    if (status == "1")
                    {
                        obj_data.Message = message;
                       
                        obj_data.Status = "1";
                    }
                    else if (status == "0")
                    {
                        obj_data.Message = message;
                        
                        obj_data.Status = "0";
                    }
                    else
                    {
                        obj_data.Message = "Unknown Status";
                        obj_data.Reason = "Unexpected STATUS value: " + status;
                        obj_data.Status = "-1";
                    }
                }
                else
                {
                    obj_data.Status = "0";
                    obj_data.Message = "No data returned";
                    obj_data.Reason = "DataTable is null or empty";
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


        public dynamic GetDropdowns(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_DropdownData_sp(obj);

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
        
        public dynamic Getcfrdata(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_cfrData_sp(obj);

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

        public dynamic Getcfrdata1(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Get_cfrData_sp1(obj);

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




        public dynamic CFR_FARMERINSERTION(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                
                string ipaddress = HttpContext.Current.Request.UserHostAddress;
                obj.IPADDRESS = ipaddress;

                AgriClass ag = new AgriClass();
                //string UniqueID = string.Empty;
                obj.FarmerUniqueID = obj.FarmerUniqueID?.ToString() ?? string.Empty;
                obj.FarmerUniqueID = ag.GenerateLandParcelIdCF();
                

                DataTable dt = userObj.cfr_Farmerinsertion_sp(obj);
                if (dt != null && dt.Rows.Count > 0)
                {

                    string status = dt.Rows[0]["STATUS"]?.ToString();
                    string message = dt.Rows[0]["STATUS_TEXT"]?.ToString();
                    obj_data.Status = status;
                    obj_data.Message = message;
                    
                    
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


        public dynamic CFR_FARMERsaveLotlang(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipaddress))
                {
                    ipaddress = HttpContext.Current.Request.UserHostAddress;
                }
                obj.IPADDRESS = ipaddress;

                DataTable dt = userObj.cfr_Lotlongsave_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    string status = dt.Rows[0]["STATUS"]?.ToString();
                    string message = dt.Rows[0]["STATUS_TEXT"]?.ToString();
                    obj_data.Status = status;
                    obj_data.Message = message;
                    obj_data.CFRID = obj.CFRID;

                }
                else
                {
                    obj_data.Message = "Failure";
                    obj_data.CFRID = obj.CFRID;
                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.CFRID = obj.CFRID;
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic CFR_mfpsave(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipaddress))
                {
                    ipaddress = HttpContext.Current.Request.UserHostAddress;
                }
                obj.IPADDRESS = ipaddress;

                DataTable dt = userObj.cfr_mfpsave_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    string status = dt.Rows[0]["STATUS"]?.ToString();
                    string message = dt.Rows[0]["STATUS_TEXT"]?.ToString();
                    obj_data.Status = status;
                    obj_data.Message = message;
                    obj_data.CFRID = obj.CFRID;

                }
                else
                {
                    obj_data.Message = "Failure";
                    obj_data.CFRID = obj.CFRID;
                    obj_data.Status = "0";
                    obj_data.Reason = " No Data Available";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.CFRID = obj.CFRID;
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic AadharCheckexist(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                DataTable dtCheck = userObj.Check_AadhaarExists(obj);

                if (dtCheck != null && dtCheck.Rows.Count > 0)
                {
                    // Duplicate Aadhaar
                    obj_data.Status = "0";
                   // obj_data.Message = "Aadhaar number already exists";
                }
                else
                {
                    // Aadhaar not found → valid
                    obj_data.Status = "1";
                    //obj_data.Message = "Aadhaar number is available";
                }
            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message;
            }
            return obj_data;
        }

        public dynamic Get_CFR_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.CFR_report_Sp(obj);

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


        public dynamic Get_Housing_report(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.Housing_report_Sp(obj);

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


        public dynamic viewcfrdatadet(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.viewcfrDataSp(obj);

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

        public dynamic viewcfrdatadetDetails(addbeneficiary_details obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                DataTable dt = userObj.viewcfrDataDetailsSp(obj);

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
         public dynamic viewagricultureHorticulture()
        {
            dynamic result = new ExpandoObject();

            try
            {
                DataTable dt = userObj.viewagricultureHorticulture();

                if (dt.Rows.Count > 0)
                {
                    result.Status = "1";
                    result.Message = "Success";
                    result.Data = dt;
                }
                else
                {
                    result.Status = "0";
                    result.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                result.Status = "0";
                result.Message = ex.Message;
            }

            return result;
        }

        public dynamic viewagetCultivationReport()
        {
            dynamic result = new ExpandoObject();

            try
            {
                DataTable dt = userObj.viewagetCultivationReport();

                if (dt.Rows.Count > 0)
                {
                    result.Status = "1";
                    result.Message = "Success";
                    result.Data = dt;
                }
                else
                {
                    result.Status = "0";
                    result.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                result.Status = "0";
                result.Message = ex.Message;
            }

            return result;
        }
        public dynamic viewagetPMKisanReport()
        {
            dynamic result = new ExpandoObject();

            try
            {
                DataTable dt = userObj.viewagetPMKisanReport();

                if (dt.Rows.Count > 0)
                {
                    result.Status = "1";
                    result.Message = "Success";
                    result.Data = dt;
                }
                else
                {
                    result.Status = "0";
                    result.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                result.Status = "0";
                result.Message = ex.Message;
            }

            return result;
        }

       


    }
}