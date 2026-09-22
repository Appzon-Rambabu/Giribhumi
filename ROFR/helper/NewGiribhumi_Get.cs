using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ROFR.NewHelper;
namespace ROFR.helper
{
    public class NewGiribhumi_Get
    {

        //newly adding For GetNOtHavingLandDetails
        public DataTable NOtHavingLandDetails_report_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "LandDetails")
            {
                lstparams.Add(new SqlParameter("@PTYPE", 8));
            }
           if(obj.type== "NeedTo")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new SqlParameter("@PTYPE", 10));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;

        }

        //newly adding for LatlongsAbstractReport
        public DataTable LatlongsAbstractReport_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "FDistrict")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }

            }
            else if (obj.type == "FMandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "FVillage")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (obj.type == "Having")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (obj.type == "Nothaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            //all login excel download
            else if (obj.type == "IDistrict")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));

                }

            }
            else if (obj.type == "INDistrict")
            {
                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 13));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

                }

            }
            else if (obj.type == "Download")
            {
                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 16));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));

                }


            }
            else if (obj.type == "Plots not having latlongs")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));
            }
            else if (obj.type == "LATLONGS LESSTHAN4")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Latlongs_Report_Excel", lstparams);
            return result;



        }

        //newly adding for Land_Invalid_Data
        public DataTable Land_Invalid_Data_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT",obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }

            }
            else if (obj.type == "Duplicate")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Invalid")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (obj.type == "Father")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (obj.type == "Location")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (obj.type == "Land")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (obj.type == ">10")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }

           

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_INVALID_DATA_REPORT", lstparams);
            return result;



        }

        //newly adding for DCL_Abstract
        public DataTable DCL_Abstract_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (obj.type == "Having")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
            }
            else if (obj.type == "IHaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (obj.type == "Nothaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            }
            else if (obj.type == "Not Having Dlc")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));
            }



            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_UPLOAD", lstparams);
            return result;



        }

        //newly adding for Farmer_Images
        public DataTable Farmer_Images_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
             if(obj.type == "FDistrict")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));

                }

            }
            else if (obj.type == "FMandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));
            }
            else if (obj.type == "FVillage")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
            }
            else if (obj.type == "Having")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));
            }
            else if (obj.type == "Nothaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 16));
            }
            //all login excel download
            else if (obj.type == "IDistrict")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 21));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 19));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));

                }

            }
            else if (obj.type == "INDistrict")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 22));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 20));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));

                }

            }
            else if (obj.type == "FARMERS")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));
            }
            else if (obj.type == "IMAGES UPLOADED")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
            }
            else if (obj.type == "IMAGES NOT UPLOADED")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
            }
            else if (obj.type == "Plots not having latlongs")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Beneficary_Images_report", lstparams);
            return result;



        }

        //newly adding for Get_ItdawiseFarmer_Details
        public DataTable ItdaWise_Farmer_Details_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            //string Itdastart = string.Empty;
            //string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Itda")
            {
                if (obj.userprevilages == "ALL" || obj.userprevilages == "" || obj.userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages",obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }

            if (obj.type == "District")
            {

                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itdacode));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itdacode));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER", lstparams);
            return result;
        }

        //newly adding for GetItda_ben_count
        public DataTable Itda_ben_count_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(obj.type=="Count")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", (obj.Itda)));
                lstparams.Add(new SqlParameter("@District", (obj.DistrictName)));
                lstparams.Add(new SqlParameter("@PTYPE", 7));
            }
            else if(obj.type=="DataDisplay")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", (obj.Itda)));
                lstparams.Add(new SqlParameter("@District", (obj.DistrictName)));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(obj.start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(obj.end)));
                lstparams.Add(new SqlParameter("@PTYPE", 8));
            }
            else if(obj.type=="BeneficiaryCount")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", (obj.Itda)));
                lstparams.Add(new SqlParameter("@District", (obj.DistrictName)));
                lstparams.Add(new SqlParameter("@PTYPE", 2));
            }
            else if(obj.type=="BeneficiaryData")
            {
                if(obj.screen == "MandalData")
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", (obj.itdacode)));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (obj.Districtcode)));
                    lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", (obj.mancode)));
                    lstparams.Add(new SqlParameter("@PTYPE", 3));

                }
                else if(obj.screen == "Rvdata")
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", (obj.itdacode)));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (obj.Districtcode)));
                    lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", (obj.mancode)));
                    lstparams.Add(new SqlParameter("@REVENUE_VILLAGE", (obj.Rvillage)));
                    lstparams.Add(new SqlParameter("@PTYPE", 3));

                }
                else if(obj.screen=="villdata")
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", (obj.itdacode)));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (obj.Districtcode)));
                    lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", (obj.mancode)));
                    lstparams.Add(new SqlParameter("@REVENUE_VILLAGE", (obj.Rvillage)));
                    lstparams.Add(new SqlParameter("@VILLAGE_NAME", (obj.village)));
                    //lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(obj.start)));
                    //lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(obj.end)));
                    lstparams.Add(new SqlParameter("@PTYPE", 3));
                }
                
            }
            else if(obj.type=="MissingData")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "4"));
            }
            else if(obj.type=="ExcelDownload")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", (obj.Itda)));
                lstparams.Add(new SqlParameter("@District", (obj.DistrictName)));
                lstparams.Add(new SqlParameter("@PTYPE", 6));

            }
            else if(obj.type=="Itda_Ben_details_down")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", (obj.Itda)));
                lstparams.Add(new SqlParameter("@District", (obj.DistrictName)));
                lstparams.Add(new SqlParameter("@PTYPE", 1));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;

        }


        //newly adding for RofrLandPhasesReport
        public DataTable RofrLandPhasesReport_SP(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "ALL")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }

            }
            
            
            if (obj.type == "PHASE-I")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
            }
            if (obj.type == "PHASE-II")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.type));

                }
            }

            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));

            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));

            }
            else if (obj.type == "Having")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));

            }
            else if (obj.type == "IHaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));

            }
            else if (obj.type == "Nothaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));

            }
            else if (obj.type == "pdfIHaving")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

            }
            else if (obj.type == "pdfIHavingupdate")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            }

            else if (obj.type == "NothavingMandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", obj.phasetype));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_IMAGES_PHASES_REPORT", lstparams);
            return result;



        }

        //newly adding For DataAnalysis_MandatoryFields
        public DataTable DataAnalysis_MandatoryFields_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.Itdastart != "DTW")
            {
                if (obj.userprevilages == "ALL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", obj.userprevilages));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", obj.userprevilages));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }
            }
            else if (obj.Itdastart == "DTW")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", "Plain Areas"));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", "Plain Areas"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("ABSTRACT_REPORTS", lstparams);
            return result;

        }
        //newly adding For DataAnalysis_NonMandatoryFields
        public DataTable DataAnalysis_NonMandatoryFields_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.Itdastart != "DTW")
            {
                if (obj.userprevilages == "ALL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", obj.userprevilages));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", obj.userprevilages));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
            }
            else if (obj.Itdastart == "DTW")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", "Plain Areas"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("ABSTRACT_REPORTS", lstparams);
            return result;

        }

        //newly adding for ItdaWise_Beneficiary_Details_Sp
        public DataTable ItdaWise_Beneficiary_Details_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Itda")
            {
                if (obj.userprevilages == "ALL" || obj.userprevilages == "" || obj.userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (obj.type == "District")
            {

                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE",obj.Itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 16));
            }
            else if (obj.type == "Rv")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 17));
            }
            else if (obj.type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REVENUE_VILLAGE", obj.Rvillage));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 18));
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER", lstparams);
            return result;



        }

        //newly adding for District_wise_BeneficiaryMaster_Abstract
        public DataTable District_wise_BeneficiaryMaster_Abstract_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District == "" ? "" : obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District == "" ? "" : obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District == "" ? "" : obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (obj.type == "VDetails")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficary_Master_Count", lstparams);
            return result;



        }

        //newly adding For FarmerUpdate_Sp
        public DataTable FarmerUpdate_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type =="FarmerUpdate")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id",obj.Benificiary_id));
            }
            
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMER_UPDATE", lstparams);
            return result;

        }
        //newly adding For //newly adding For FarmerUpdate_Sp
        public DataTable Get_Farmer_DataUpdate_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(obj.type =="FDataUpdate")
            {
                
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", obj.Benificiary_id));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAR_NO", obj.Aadhaar_NO));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ROFR_PATTADAAR", obj.ROFR_PATTADAAR));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Father_Name", obj.fathername));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",obj.Type));
            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMER_UPDATE", lstparams);
            return result;
        }

        public DataTable Get_websiteVisitors_DataUpdate_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
            return result;
        }


        //newly adding For MissingData_Sp
        public DataTable MissingData_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "Itda")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", "Plain Areas"));
                    lstparams.Add(new SqlParameter("@Ptype", obj.Type));
                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME",obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", obj.Type));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@Ptype",obj.Type));
                }
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
            return result;

        }

        //newly adding For MissingData_District_Sp
        public DataTable MissingData_Dis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(obj.type=="LoadDistrict")
            {
                if (obj.Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype",obj.Type));
                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype",obj.Type));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@itda", (obj.District)));
                    lstparams.Add(new SqlParameter("@Ptype", obj.Type));
                }
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For MissingData_Download_Sp
        public DataTable MissingData_Download_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "MissingDataDownload")
            {
                lstparams.Add(new SqlParameter("@ITDA", obj.Itda));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", Convert.ToInt32(obj.District_Code)));
                lstparams.Add(new SqlParameter("@SelectionOptionType",obj.screen));
                lstparams.Add(new SqlParameter("@Ptype",obj.Type));
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For Rythubarosa_May20_Sp
        public DataTable Rythubarosa_May20_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", obj.Type));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 4));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 5));
            }
            else if (obj.type == "Psuccess")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 6));
            }
            else if (obj.type == "Pending")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 7));
            }
            else if (obj.type == "Prejected")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 9));
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
            return result;

        }

        //newly adding For Rythubarosa_May21_Sp
        public DataTable Rythubarosa_May21_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "DISTRICT")
            {
                if (obj.Itdastart == "DTW")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 17));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 18));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 16));

                }

            }
            else if (obj.type == "MANDAL")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 19));
            }
            else if (obj.type == "Belong to Beneficiary Family")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 20));
            }
            else if (obj.type == "Eligible")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 21));
            }
            else if (obj.type == "Ineligible")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 22));
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
            return result;

        }

        //newly adding For Rythubarosa_May21_Sp
        public DataTable Rythubarosa_Oct20_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 10));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 13));
            }
            
            else if (obj.type == "Eligible")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
               
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 14));
            }
            else if (obj.type == "NotEligible")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 15));
            }
            

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
            return result;

        }

        //newly adding For DistictData_Analysis_Sp
        public DataTable DistictData_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.District != "")
            {

                if (obj.Mandal == "4")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 2));
                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 2));
                    }
                }
                else if (obj.Division == "5")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                }
                else if (obj.Village == "7")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 3));
                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 3));
                    }
                }
                else if (obj.Range == "8")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 6));
                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                }
                else if(obj.NoofBeats=="10")
                {
                    if(obj.Type=="")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", obj.Village));
                        lstparams.Add(new SqlParameter("@Ptype", 9));
                    }
                }
                else if(obj.rangebeats=="11")
                {
                    if(obj.Type=="")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", obj.Division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", obj.Range));
                        lstparams.Add(new SqlParameter("@Ptype", 10));
                    }
                }
               else if (obj.divirange == "6")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", obj.Division));
                        lstparams.Add(new SqlParameter("@Ptype", 7));
                    }
                }
            }
            
            else
            {
                lstparams.Add(new SqlParameter("@Ptype", 1));
            }
            
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;

        }


        //newly adding For BenificiaryMaster_sp
        public DataTable BenificiaryMaster_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
           
                if (obj.Benificiary == "4")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", obj.Itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                    lstparams.Add(new SqlParameter("@PTYPE", 7));

                }
                else
                {

                    lstparams.Add(new SqlParameter("@PTYPE", 6));


                }

           

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;

        }

        //newly adding For AllForestBeatMaster_sp
        public DataTable AllForestBeatMaster_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "ALL")
            {

                lstparams.Add(new SqlParameter("@Ptype", 11));

            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For ForestRangeMaster_Analysis_Sp
        public DataTable ForestRangeMaster_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.forestrange == "6")
            {
                if (obj.Type == "")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }
            }

            if (obj.allForestbeat == "11")
            {
                if (obj.Type == "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", obj.Division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", obj.Range));
                    lstparams.Add(new SqlParameter("@Ptype", 10));

                }
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For ForestDivisionMaster_Analysis_Sp
        public DataTable ForestDivisionMaster_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            
            
                if (obj.Division == "5")
                {
                    if (obj.Type == "")
                    {
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                    //lstparams.Add(new SqlParameter("@Ptype", 4));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }
                else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", obj.Type));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                }
            if (obj.District != "")
            {
                if (obj.forestrange == "6")
                {
                    if (obj.Type == "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", obj.Division));
                        lstparams.Add(new SqlParameter("@Ptype", 7));
                    }
                }
                else if(obj.Frangebeats=="11")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE",obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE",obj.Mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", obj.Division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", obj.Range));
                    lstparams.Add(new SqlParameter("@Ptype", 10));
                }
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For ForestDivisionMaster_Analysis_Sp
        public DataTable CurdForestDivision_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "Division")
            {
                if (obj.start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else if (obj.start != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", obj.ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else if (obj.start == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
            return result;

        }

        //newly adding For ForestDivisionMaster_Analysis_Sp
        public DataTable CurdForestDivisionDetails_Analysis_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(obj.type=="FDDetails")
            lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE",obj.District));
            lstparams.Add(new SqlParameter("@Ptype", 7));


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
            return result;

        }

        //newly adding For //newly adding For FarmerUpdate_Sp
        public DataTable Get_ForestDivision_Update_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "FDivisionUpdate")
            {
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", obj.District));
                lstparams.Add(new SqlParameter("@Id", obj.id == "" ? 0 : Convert.ToInt32(obj.id)));
                lstparams.Add(new SqlParameter("@Ptype", 10));
            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
            return result;
        }



        //newly adding for UpdateLtrCases_Sp
        public DataTable UpdateLtrCases_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Itda")
            {
                if (obj.userprevilages == "ALL" || obj.userprevilages == "" || obj.userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (obj.type == "District")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@PTYPE", 2));


            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }
            else if (obj.type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@revenue_village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "5"));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LTR_MASTER", lstparams);
            return result;

        }

        //newly adding for UpdateLtrCases_Sp
        public DataTable UpdateLtrCasesDetails_Sp(addbeneficiary_details obj)
        {

            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(obj.type=="updateLtrStatus")
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@HABITATION", obj.Habitation));
            // lstparams.Add(new System.Data.SqlClient.SqlParameter("@STATUS",status));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC1", lstparams);
            return result;
        }


        //newly adding forLtrs_Sp
        public DataTable ViewLtr_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();

            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Itda")
            {
                if (obj.userprevilages == "ALL" || obj.userprevilages == "" || obj.userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (obj.type == "District")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@PTYPE", 2));


            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }
            else if (obj.type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@revenue_village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "5"));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LTR_MASTER", lstparams);
            return result;

        }

        //newly adding forLtrdata_Sp
        public DataTable ViewLtrData_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@HABITATION", obj.Habitation));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
            return result;

        }

        //newly adding for ItdaWise_Beneficiary_Details_Sp
        public DataTable FarmerLand_Details_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Itda")
            {
                if (obj.userprevilages == "ALL" || obj.userprevilages == "" || obj.userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (obj.type == "District")
            {

                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@DISTRICT_NAME", obj.ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 3));
            }
            else if (obj.type == "Rv")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 4));
            }
            else if (obj.type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REVENUE_VILLAGE", obj.Rvillage));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 5));
            }
            else if (obj.type == "Farmerlanddetails")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REVENUE_VILLAGE", obj.Rvillage));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE_NAME", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 6));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_LandDetails_Report", lstparams);
            return result;



        }

        public DataTable Get_Data_sp1(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@TYPE",obj.type));
            if (obj.PTYPE=="1")
            {

                if(obj.type== "District")
                {

                    lstparams.Add(new SqlParameter("@PTYPE",obj.PTYPE));
                }
                else if(obj.type== "Mandal")
                {
                    lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
                    lstparams.Add(new SqlParameter("@Input1",obj.Districtcode));
                }
                else if(obj.type=="Panchayat")
                {

                    lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
                    lstparams.Add(new SqlParameter("@Input1", obj.Districtcode));
                    lstparams.Add(new SqlParameter("@Input2",obj.mancode));
                }
                else if (obj.type == "Village")
                {
                    lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
                    lstparams.Add(new SqlParameter("@Input1", obj.Districtcode));
                    lstparams.Add(new SqlParameter("@Input2", obj.mancode));
                    lstparams.Add(new SqlParameter("@Input3", obj.GramaPanchayatCode));
                }
                else if (obj.type == "Village_Category")
                {
                    lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
                }


            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_MOTA_VILLAGES_VALIDATION", lstparams);
            return result;
        }

        public DataTable Get_VillageData_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            
                lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
                lstparams.Add(new SqlParameter("@Input1", obj.Districtcode));
                lstparams.Add(new SqlParameter("@Input2", obj.mancode));
                lstparams.Add(new SqlParameter("@Input3", obj.GramaPanchayatCode));
                lstparams.Add(new SqlParameter("@Input4", obj.VillageCode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_MOTA_VILLAGES_VALIDATION", lstparams);
            return result;
        }

        public DataTable VillageValiUpdated_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            // here type 5

            lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new SqlParameter("@Input1", obj.Districtcode));
            lstparams.Add(new SqlParameter("@Input2", obj.mancode));
            lstparams.Add(new SqlParameter("@Input3", obj.GramaPanchayatCode));
            lstparams.Add(new SqlParameter("@Input4", obj.VillageCode));
            lstparams.Add(new SqlParameter("@Input5", obj.Recordid)); 
            lstparams.Add(new SqlParameter("@Input6", obj.GgeographicalArea));
            lstparams.Add(new SqlParameter("@Input7", obj.TotalHH));
            lstparams.Add(new SqlParameter("@Input8", obj.TotalPopulation));
            lstparams.Add(new SqlParameter("@Input9", obj.TotalMale));
            lstparams.Add(new SqlParameter("@Input10", obj.TotalFemale));
            lstparams.Add(new SqlParameter("@Input11", obj.TotalSC));
            lstparams.Add(new SqlParameter("@Input12", obj.SCMale));
            lstparams.Add(new SqlParameter("@Input13", obj.SCFemale));
            lstparams.Add(new SqlParameter("@Input14", obj.TotalST));
            lstparams.Add(new SqlParameter("@Input15", obj.STMale));
            lstparams.Add(new SqlParameter("@Input16", obj.STFemale));
            lstparams.Add(new SqlParameter("@Input17", obj.ForestHectares));
            lstparams.Add(new SqlParameter("@Input18", obj.VillageCategory));
            lstparams.Add(new SqlParameter("@Input19", obj.VillageStatus));
            

            SQLManager sqlmngr = new SQLManager();
            return sqlmngr.ExecuteProcedureReturnDataTable("PROC_MOTA_VILLAGES_VALIDATION", lstparams);
        }



        public DataTable Get_DropdownData_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "Itda")
            {
                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (obj.userprevilages == "ALL" || string.IsNullOrEmpty(obj.userprevilages))
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }

            if (obj.type == "District")
            {

                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@DISTRICT_CODE", obj.District));
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                    
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }

            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }

            else if (obj.type == "Panchayat")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }

            else if (obj.type == "RevVillage")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat_Code", obj.panchayatcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (obj.type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat_Code", obj.panchayatcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rev_Villagecode", obj.rev_village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (obj.type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat_Code", obj.panchayatcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rev_Villagecode", obj.rev_village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village_Code", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (obj.type == "Division")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (obj.type == "Range")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", obj.Forest_Division));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (obj.type == "Beat")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", obj.Forest_Division));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", obj.Range));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            }
            else if (obj.type == "cfr")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
            }

            else if (obj.type == "cfrLatLongs")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));
            }

            else if (obj.type == "cfrmfp")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
            }

            else if(obj.type =="Cfrnatureddl")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
            }

            else if (obj.type == "CfrProductNameddl")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 19));
            }

            if (obj.type == "crfdistrict")
            {
                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@DISTRICT_CODE", obj.District));
                    lstparams.Add(new SqlParameter("@PTYPE", 12));
                }
                else if (obj.userprevilages == "ALL" || string.IsNullOrEmpty(obj.userprevilages))
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 12));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 12));
                }
            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DROPDOWNS", lstparams);
            return result;
        }


        //03-09-2025 Crf insertion
        public DataTable Crfinsertion_sp(addbeneficiary_details obj, string fileName, string filePath)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new SqlParameter("@Input_01", obj.ItdaCodecrf));
            lstparams.Add(new SqlParameter("@Input_02", obj.ItdaNamecrf));
            lstparams.Add(new SqlParameter("@Input_03", obj.DistrictCodecrf));
            lstparams.Add(new SqlParameter("@Input_04", obj.Districtcrf));
            lstparams.Add(new SqlParameter("@Input_05", obj.Mandal_Code));
            lstparams.Add(new SqlParameter("@Input_06", obj.Mandalcrf));
            lstparams.Add(new SqlParameter("@Input_07", obj.PanchayatCodecrf));
            lstparams.Add(new SqlParameter("@Input_08", obj.Panchayatcrf));
            lstparams.Add(new SqlParameter("@Input_09", obj.RevVillagecodecrf));
            lstparams.Add(new SqlParameter("@Input_10", obj.RevVillagecrf));
            lstparams.Add(new SqlParameter("@Input_11", obj.Village_Code));
            lstparams.Add(new SqlParameter("@Input_12", obj.Village));

            string hab = obj.HabitationCode;
            if (string.IsNullOrWhiteSpace(hab) ||
                hab.Trim().ToLower() == "null" ||
                hab.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_13", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_13", hab));
            }

            //lstparams.Add(new SqlParameter("@Input_13", obj.HabitationCode ?? (object)DBNull.Value));

            lstparams.Add(new SqlParameter("@Input_14", obj.Habitation));
           // lstparams.Add(new SqlParameter("@Input_15", obj.Forest_DivisionCode));

            string fdc = obj.Forest_DivisionCode;
            if (string.IsNullOrWhiteSpace(fdc) ||
                fdc.Trim().ToLower() == "null" ||
                fdc.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_15", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_15", fdc));
            }

            lstparams.Add(new SqlParameter("@Input_16", obj.Forest_Division));
           // lstparams.Add(new SqlParameter("@Input_17", obj.Forest_RangeCode));

            string frc = obj.Forest_RangeCode;
            if (string.IsNullOrWhiteSpace(frc) ||
                frc.Trim().ToLower() == "null" ||
                frc.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_17", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_17", frc));
            }

            lstparams.Add(new SqlParameter("@Input_18", obj.Forest_Range));
           // lstparams.Add(new SqlParameter("@Input_19", obj.Forest_BeatCode));


            string fbc = obj.Forest_BeatCode;
            if (string.IsNullOrWhiteSpace(fbc) ||
                fbc.Trim().ToLower() == "null" ||
                fbc.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_19", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_19", fbc));
            }


            lstparams.Add(new SqlParameter("@Input_20", obj.Forest_Beat));
            lstparams.Add(new SqlParameter("@Input_21", obj.Forest_Block));
            lstparams.Add(new SqlParameter("@Input_22", obj.Compartment_No));
            lstparams.Add(new SqlParameter("@Input_23", obj.KhasraNo));

            

          //  lstparams.Add(new SqlParameter("@Input_24", obj.ROFR_PATTANO));

            string rpn = obj.ROFR_PATTANO;
            if (string.IsNullOrWhiteSpace(rpn) ||
                rpn.Trim().ToLower() == "null" ||
                rpn.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_24", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_24", rpn));
            }
            //lstparams.Add(new SqlParameter("@Input_25", obj.Boundaries_Description));
            string bdn = obj.Boundaries_Description;
            if (string.IsNullOrWhiteSpace(bdn) ||
                bdn.Trim().ToLower() == "null" ||
                bdn.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_25", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_25", bdn));
            }

            lstparams.Add(new SqlParameter("@Input_26", obj.Total_CFR_Members));
            lstparams.Add(new SqlParameter("@Input_27", obj.Total_Extent));
            lstparams.Add(new SqlParameter("@Input_28", obj.CFR_Nature));


            string us = obj.Utilization_Status;
            if (string.IsNullOrWhiteSpace(us) ||
                us.Trim().ToLower() == "null" ||
                us.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_29", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_29", us));
            }
            //lstparams.Add(new SqlParameter("@Input_29", obj.Utilization_Status ?? (object)DBNull.Value));

            //lstparams.Add(new SqlParameter("@Input_30", obj.Support_Required));

            string sr = obj.Support_Required;
            if (string.IsNullOrWhiteSpace(sr) ||
                sr.Trim().ToLower() == "null" ||
                sr.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_30", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_30", sr));
            }



            //lstparams.Add(new SqlParameter("@Input_31", obj.Remarks));

            string rem = obj.Remarks;
            if (string.IsNullOrWhiteSpace(rem) ||
                rem.Trim().ToLower() == "null" ||
                rem.Trim() == "0")
            {
                lstparams.Add(new SqlParameter("@Input_31", DBNull.Value));
            }
            else
            {
                lstparams.Add(new SqlParameter("@Input_31", rem));
            }

            lstparams.Add(new SqlParameter("@Input_32", fileName ?? (object)DBNull.Value)); // file name
            lstparams.Add(new SqlParameter("@Input_33", obj.user_name));
            lstparams.Add(new SqlParameter("@Input_34", obj.IPADDRESS));
            lstparams.Add(new SqlParameter("@Input_35", obj.Gramsabha));
            lstparams.Add(new SqlParameter("@Input_36", obj.Naturecode));
            lstparams.Add(new SqlParameter("@Input_37", obj.NatureName));



            // Optional: include filePath if SP supports it
            // lstparams.Add(new SqlParameter("@Input_35", filePath ?? (object)DBNull.Value));

            SQLManager sqlmngr = new SQLManager();
            return sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
        }


        public DataTable Get_cfrData_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            //CFR_GET_DATA for type
            lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new SqlParameter("@Input_01", obj.itdacode));
            lstparams.Add(new SqlParameter("@Input_02", obj.Districtcode));
            lstparams.Add(new SqlParameter("@Input_03", obj.mancode));
            lstparams.Add(new SqlParameter("@Input_04", obj.CFRID));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }

        public DataTable Get_cfrData_sp1(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            //CFR_GET_DATA for type
            lstparams.Add(new SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new SqlParameter("@Input_01", obj.itdacode));
            lstparams.Add(new SqlParameter("@Input_02", obj.Districtcode));
            lstparams.Add(new SqlParameter("@Input_03", obj.mancode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }


        public DataTable cfr_Farmerinsertion_sp(addbeneficiary_details obj)
        {
            // type = CFR_FARMER_INSERT

            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",obj.PTYPE));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_01", obj.CFRID));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_02", obj.FarmerUniqueID));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_03", obj.RepreseName));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_04", obj.FatherName));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_05", obj.Aadhaarno));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_06", obj.user_name));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_07", obj.IPADDRESS));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }

        public DataTable Check_AadhaarExists(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "AADHAAR_CHECK"));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_01", obj.Aadhaarno));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }

        public DataTable cfr_Lotlongsave_sp(addbeneficiary_details obj)
        {
            // type = CFR_LATLONGS_INSERT


            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_01", obj.CFRID));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_02", obj.LATITUDE));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_03", obj.LONGITUDE));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_04", obj.user_name));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_05", obj.IPADDRESS));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }


        public DataTable cfr_mfpsave_sp(addbeneficiary_details obj)
        {
            // type = CFR_LATLONGS_INSERT


            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.PTYPE));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_01", obj.CFRID));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_02", obj.ProductCode));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_03", obj.ProductName));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_04", obj.TotalAcres));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_05", obj.IncomePerAnnum));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_06", obj.PointOfSale));
            lstparams.Add(new SqlParameter("@INPUT_07", obj.ProductQuantity));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_08", obj.IPADDRESS));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@INPUT_09", obj.user_name));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DETAILS", lstparams);
            return result;
        }


        public DataTable CFR_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }

            else if (obj.type == "CFRIDYTS")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (obj.type == "CFRIDYTSL")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (obj.type == "CFRIDMEMSUB")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (obj.type == "CFRIDMEMSUBDET")
            {
                
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }


            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_REPORT", lstparams);
            return result;



        }


        public DataTable Housing_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }
                

            }
            else if (obj.type == "HousingDistrictDetails")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }

            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }

            else if (obj.type == "HousingMandalDetails")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }

            else if (obj.type == "HousingVillageDetails")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }

            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Housing_Reports", lstparams);
            return result;



        }

        public DataTable viewcfrDataSp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.type == "Itda")
            {
                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@PTYPE", 15));
                }
                else if (obj.userprevilages == "ALL" || string.IsNullOrEmpty(obj.userprevilages))
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 15));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 15));
                }
            }

            if (obj.type == "District")
            {

                if (obj.start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@DISTRICT_CODE", obj.District));
                    lstparams.Add(new SqlParameter("@ITDA_NAME", obj.start));
                    lstparams.Add(new SqlParameter("@PTYPE",16));

                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
                    lstparams.Add(new SqlParameter("@PTYPE",16));
                }


            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",17));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_DROPDOWNS", lstparams);
            return result;
        }


        public DataTable viewcfrDataDetailsSp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

             if(obj.type == "viewcfrData")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_CFR_REPORT", lstparams);
            return result;
        }

        public DataTable viewagricultureHorticulture()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();

            return sqlmngr.ExecuteProcedureReturnDataTable(
                "SP_IFR_Lands_Cropping_Pattern",
                lstparams);
        }
        public DataTable viewagetCultivationReport()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();

            return sqlmngr.ExecuteProcedureReturnDataTable(
                "SP_IFR_Lands_Cropping_Pattern",
                lstparams);
        }
        public DataTable viewagetPMKisanReport()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();

            return sqlmngr.ExecuteProcedureReturnDataTable(
                "SP_ADSB_Payment_Report",
                lstparams);
        }


    }



}