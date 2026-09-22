using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;
using System.Text.RegularExpressions;
using ROFR.Models;
using System.IO;
using ROFR.NewHelper;

namespace ROFR.helper
{
    public class Giribhumi_get
    {

        //newly adding for LandStatusReport
        public DataTable LandStatus_Beneficiaryreport_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Status")
            {
                lstparams.Add(new SqlParameter("@PTYPE", 9));
            }
            if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;

        }

        //newly adding for LandStatusReport
        public DataTable LandStatus_report_Sp(addbeneficiary_details obj)
        {
            DataTable result = new DataTable();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Land")
            {
                lstparams.Add(new SqlParameter("@PTYPE", 1));
            }
            if (obj.type == "PMandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 27));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;

        }

        //newly adding RythubharosaPaymentstatus Sp
        public DataTable GetRythubharosaPaymentstatus_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "District")
            {
                if (obj.Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 3));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", obj.ITDANAME));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 4));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 2));

                }

            }
            else if (obj.type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 5));
            }
            else if (obj.type == "Village")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 6));
            }
            else if (obj.type == "Psuccess")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 7));
            }
            else if (obj.type == "Prejected")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@village", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 8));
            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments", lstparams);
            return result;

        }

        //newly adding for Benificiary_report
        public DataTable GetBenificiary_report_Sp(addbeneficiary_details obj)
        {

            DataTable result = new DataTable();
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if (obj.type == "Mandal")
            {


                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));


            }
            if (obj.type == "PMandal")
            {


                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 27));

            }
            if (obj.type == "Benificiary")
            {


                if (obj.Itdastart == "DTW")
                {

                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 19));
                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));

                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                }

            }
            if (obj.type == "PHASE1")
            {

                if (obj.Itdastart == "DTW")
                {

                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 20));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 16));

                }

            }
            if (obj.type == "PHASE2")
            {



                if (obj.Itdastart == "DTW")
                {

                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 21));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));

                }



            }

            if (obj.type == "PHASESBOTH")
            {



                if (obj.Itdastart == "DTW")
                {

                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 22));

                }
                else if (obj.Itdastart != "DTW" && obj.ITDANAME != "DIRECTOR" && obj.Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 26));
                }
                else if (obj.Itdastart == "" || obj.ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));

                }

            }

            if (obj.type == "Mandalben")
            {


                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 28));

            }

            if (obj.type == "Panchayatben")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 33));
            }
            if (obj.type == "RevenueVillageben")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PANCHAYAT", obj.Gram_Panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 34));
            }
            if (obj.type == "Villageben")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PANCHAYAT", obj.Gram_Panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REVENUE_VILLAGE", obj.REVENUE_VILLAGE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 35));
            }
            if (obj.type == "Habitationben")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new SqlParameter("@PANCHAYAT", obj.Gram_Panchayat));
                lstparams.Add(new SqlParameter("@REVENUE_VILLAGE", obj.REVENUE_VILLAGE));
                lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new SqlParameter("@PTYPE", 36));
            }
            if (obj.type == "BeneficiaryForAll")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new SqlParameter("@PANCHAYAT", obj.Gram_Panchayat));
                lstparams.Add(new SqlParameter("@REVENUE_VILLAGE", obj.REVENUE_VILLAGE));
                lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new SqlParameter("@HABITATION", obj.Habitation));
                lstparams.Add(new SqlParameter("@PTYPE", 37));
            }
            if (obj.type == "NoofFarmerPlots")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
                lstparams.Add(new SqlParameter("@PANCHAYAT", obj.Gram_Panchayat));
                lstparams.Add(new SqlParameter("@REVENUE_VILLAGE", obj.REVENUE_VILLAGE));
                lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new SqlParameter("@HABITATION", obj.Habitation));
                lstparams.Add(new SqlParameter("@PTYPE", 38));
            }

            if (obj.type == "Mandalphase1")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 29));

            }
            if (obj.type == "Mandalphase2")
            {




                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 30));

            }
            if (obj.type == "Mandalbothphase")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 31));

            }
            SQLManager sqlmngr = new SQLManager();
            result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;

        }
        public DataTable GetAdangal_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_name", obj.Itda));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@village", obj.Village));
            lstparams.Add(new SqlParameter("@Rofr_Pattadaar", obj.ROFR_PATTADAAR));
            lstparams.Add(new SqlParameter("@Compartment_No", obj.Compartment_No));
            lstparams.Add(new SqlParameter("@Aadhaar_No", obj.Aadhaar_NO));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_BenDetails_1B", lstparams);
            return result;
        }

        public DataTable Girivikasam_Rofr_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_name", obj.Itda));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@village", obj.Village));
            lstparams.Add(new SqlParameter("@Rofr_Pattadaar", obj.ROFR_PATTADAAR));
            lstparams.Add(new SqlParameter("@Compartment_No", obj.Compartment_No));
            lstparams.Add(new SqlParameter("@Aadhaar_No", obj.Aadhaar_NO));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_GIRIVIKASAM_ADANGAL", lstparams);
            return result;
        }
        public DataTable Epassbook_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_Name", obj.Itda));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@Village", obj.Village));
            lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", obj.ROFR_PATTADAAR));
            lstparams.Add(new SqlParameter("@Aadhaar_NO", obj.Aadhaar_NO));
            lstparams.Add(new SqlParameter("@benficiary_id", obj.Benificiary_id));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("[Proc_EPass_Book]", lstparams);
            return result;
        }

        public DataSet ViewEpassbook_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_Name", obj.Itda));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@Village", obj.Village));
            lstparams.Add(new SqlParameter("@benficiary_id", obj.Benificiary_id));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("[Proc_EPass_Book]", lstparams);
            return result;
        }

        public DataTable Rofr_Masters_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
            lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itdacode));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.District_Code));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
            lstparams.Add(new SqlParameter("@userprevilages ", obj.UserName));
            lstparams.Add(new SqlParameter("@Forest_Division", obj.Forest_Division));
            lstparams.Add(new SqlParameter("@Forest_Range", obj.Forest_Range));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }
        public DataTable Girivikasam_Masters_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
            lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itdacode));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.District_Code));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
            lstparams.Add(new SqlParameter("@userprevilages ", obj.UserName));
            lstparams.Add(new SqlParameter("@Forest_Division", obj.Forest_Division));
            lstparams.Add(new SqlParameter("@Forest_Range", obj.Forest_Range));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_GIRIVIKASAM_DROUPDOWNS", lstparams);
            return result;
        }

        public DataTable Rythubarosa_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("[Proc_GVikasam_RB_Counts]", lstparams);
            return result;
        }

        public DataTable Rofr_Extent_data_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_EXTENT_APP_DATA", lstparams);
            return result;
        }





        public DataTable Rofr_Plot_Details_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@ITDA", obj.Itda));

            lstparams.Add(new SqlParameter("@District", obj.District));

            lstparams.Add(new SqlParameter("@mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@village", obj.Village));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }

        public DataTable Rofr_masters_data_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }

        public DataTable Rofr_mobile_version_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@version", obj.Version));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }


        public DataTable Farmer_Details_Card_sp()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new SqlParameter("@P_TYPE", 1));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMAR_DETAILS_CARD", lstparams);
            return result;
        }
        public DataTable Farmer_Card_sp()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new SqlParameter("@P_TYPE", 2));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMAR_DETAILS_CARD", lstparams);
            return result;
        }

        public DataTable Farmer_Card_Compartment_sp()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new SqlParameter("@P_TYPE", 3));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMAR_DETAILS_CARD", lstparams);
            return result;
        }
        public DataTable Land_Status_Report_sp()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new SqlParameter("@PTYPE", 1));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;
        }

        public DataTable Land_Images_Report_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));

            lstparams.Add(new SqlParameter("@DISTRICT", obj.District));

            lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
            lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_IMAGE_REPORT", lstparams);
            return result;
        }

        public DataTable Rofr_ben_Details_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            //lstparams.Add(new SqlParameter("@ITDA", obj.Itda));

            //lstparams.Add(new SqlParameter("@District", obj.District));

            //lstparams.Add(new SqlParameter("@mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@benficiary_id2", obj.Benificiary_id));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_UPLOAD", lstparams);
            return result;
        }


        public DataTable Multipart_Dlc_sp(dynamic obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@DLCPATH", obj.DLCPATH));
            lstparams.Add(new SqlParameter("@Dlc_date", obj.Dlc_date));
            lstparams.Add(new SqlParameter("@ID", obj.ID));

            lstparams.Add(new SqlParameter("@PTYPE", obj.TYPE));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_UPLOAD", lstparams);
            return result;
        }
        public DataTable LAND_HOLDING_DYNAMIC_SERVICE()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new SqlParameter("@P_TYPE", 4));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_FARMAR_DETAILS_CARD", lstparams);
            return result;
        }

        public DataTable Get_RTGS_INSERT_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", obj.Benificiary_id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Aadhaar_NO", obj.Aadhaar_NO));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_RB_RTGS_PAYMENTS", lstparams);
            return result;
        }
        public DataTable ROFR_JALAKALA_RES_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", obj.id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MASTER_AADHAAR_NO", obj.Aadhaar_NO));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_YSR_JALAKALA", lstparams);
            return result;
        }
        public DataTable ROFR_YSR_JALAKALA_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", obj.District_Code));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MASTER_AADHAAR_NO", obj.Aadhaar_NO));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_YSR_JALAKALA", lstparams);
            return result;
        }

        public DataTable ROFR_NREGA_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();



            lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", obj.Benificiary_id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Aadhaar_NO", obj.Aadhaar_NO));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_NREGA_SERVICE", lstparams);
            return result;
        }
        public DataTable Farmer_Images_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_Name", obj.Itda));
            //lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itdacode));
            lstparams.Add(new SqlParameter("@District", obj.District));
            //lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.District_Code));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@Village", obj.Village));
            //lstparams.Add(new SqlParameter("@userprevilages ", obj.UserName));
            //lstparams.Add(new SqlParameter("@Forest_Division", obj.Forest_Division));
            //lstparams.Add(new SqlParameter("@Forest_Range", obj.Forest_Range));
            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Beneficary_Images_report", lstparams);
            return result;
        }

        public DataTable Dlc_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));

            lstparams.Add(new SqlParameter("@DISTRICT", obj.District));

            lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
            lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_UPLOAD", lstparams);
            return result;
        }
        public DataTable Rythubharosa_2019_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@itda_name", obj.Itda));

            lstparams.Add(new SqlParameter("@district", obj.District));

            lstparams.Add(new SqlParameter("@mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@village", obj.Village));

            lstparams.Add(new SqlParameter("@p_type", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments", lstparams);
            return result;
        }

        public DataTable Rythubharosa_2020_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@Itda_Name", obj.Itda));

            lstparams.Add(new SqlParameter("@District", obj.District));

            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@Village", obj.Village));

            lstparams.Add(new SqlParameter("@Ptype", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
            return result;
        }

        public DataTable Land_Invalid_Data_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));

            lstparams.Add(new SqlParameter("@DISTRICT", obj.District));


            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_INVALID_DATA_REPORT", lstparams);
            return result;
        }

        public DataTable Beneficiary_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));

            lstparams.Add(new SqlParameter("@District", obj.District));


            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }

        public DataTable Missing_Data_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA", obj.Itda));

            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", obj.District_Code));
            lstparams.Add(new SqlParameter("@SelectionOptionType", obj.REMARKS));

            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
            return result;
        }
        public DataTable Benificiarywise_Land_Status_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));

            lstparams.Add(new SqlParameter("@DISTRICT", obj.District));


            lstparams.Add(new SqlParameter("@PTYPE", obj.Type));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;
        }

        public DataTable jalakalareport_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@P_TYPE", obj.Type));
            lstparams.Add(new SqlParameter("@ITDA_NAME", obj.Itda));
            lstparams.Add(new SqlParameter("@DISTRICT", obj.District));
            lstparams.Add(new SqlParameter("@MANDAL", obj.Mandal));
            lstparams.Add(new SqlParameter("@VILLAGE", obj.Village));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_YSR_JALA_KALA_SCHEME", lstparams);
            return result;
        }

        public DataTable Getfarmerimge_details(addbeneficiary_details obj)
        {

            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@ITDA", obj.Itda));
            lstparams.Add(new SqlParameter("@District", obj.District));
            lstparams.Add(new SqlParameter("@Mandal", obj.Mandal));
            lstparams.Add(new SqlParameter("@Village", obj.Village));

            lstparams.Add(new SqlParameter("@PTYPE", "8"));




            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;

        }
        public DataTable update_farmerimage_sp(dynamic obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@Image1", obj.Land_Filename));
            lstparams.Add(new SqlParameter("@Imagepath", obj.Land_Image));
            lstparams.Add(new SqlParameter("@Img_updatedby", obj.username));
            lstparams.Add(new SqlParameter("@Beneficiary_id", obj.benid));  // obj.benid  
            lstparams.Add(new SqlParameter("@PTYPE", 22));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }
        public DataTable Multipart_Image_sp(dynamic obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@Land_Image", obj.Land_Filename));
            lstparams.Add(new SqlParameter("@Land_Imagepath", obj.Land_Image));
            lstparams.Add(new SqlParameter("@Land_Image1", obj.Land_Filename1));
            lstparams.Add(new SqlParameter("@Land_Imagepath1", obj.Land_Image1));
            lstparams.Add(new SqlParameter("@Id", obj.plotid));
            lstparams.Add(new SqlParameter("@benficiary_id2", obj.Benficiary_id));
            lstparams.Add(new SqlParameter("@UserName", obj.username));
            lstparams.Add(new SqlParameter("@Ipaddress", obj.ip));
            lstparams.Add(new SqlParameter("@LATITUDE", obj.latitude));
            lstparams.Add(new SqlParameter("@LONGITUDE", obj.longitude));
            lstparams.Add(new SqlParameter("@PTYPE", obj.TYPE));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }


        public DataTable Get_Itdas_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            //obj.userprevilages = "ALL";
            lstparams.Add(new SqlParameter("@userprevilages", obj.userprevilages));
            lstparams.Add(new SqlParameter("@PTYPE", 19));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }

        public DataTable Get_Districts_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_CODE", obj.Itda));
            lstparams.Add(new SqlParameter("@PTYPE", 2));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }

        public DataTable Get_Mandals_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;


        }

        public DataTable Get_Villages_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", obj.Itda));

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", obj.District));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", obj.Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }



        public DataTable Login_status_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            if (obj.Type == "19")
            {
                lstparams.Add(new SqlParameter("@PTYPE", obj.Type));

            }
            else if (obj.Type == "20")
            {
                lstparams.Add(new SqlParameter("@PTYPE", obj.Type));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
            }
            else if (obj.Type == "21")
            {
                lstparams.Add(new SqlParameter("@PTYPE", obj.Type));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@user_name", obj.UserName));
            }


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }


        //Newly adding 07-11-2024 
        public DataTable Get_Dist_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "1"));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_CitizenService_HHData", lstparams);
            return result;
        }

        public DataTable insertData_sp(Household obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "1"));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.DistrictCode));
            lstparams.Add(new SqlParameter("@DistrictName", obj.DistrictName));
            lstparams.Add(new SqlParameter("@CitizenAadharNo", obj.CitizenNumber));
            lstparams.Add(new SqlParameter("@CitizenName", obj.CitizenName));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_CitizenService_HHData", lstparams);
            return result;
        }


        //03-12-2024 

        public DataTable Get_RtgsData_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "4"));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_RTGS", lstparams);
            return result;
        }

        public DataTable Get_Data_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "5"));
            //lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_RTGS", lstparams);
            return result;
        }

        public DataTable Get_RofrData_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "6"));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_RTGS", lstparams);
            return result;
        }




        public DataTable Get_RofrData_sp1(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", "6"));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            return sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_RTGS", lstparams);
        }

        public DataTable ROFR_GetUpdate_sp(ROFRData obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_UNIQUE_FARMID", lstparams);
            return result;
        }

        public DataTable ROFR_Updated_sp(string uniquId, string id, string Benificiaryid, string Aadhaarno)
        {

            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", Benificiaryid));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Aadhaar_NO", Aadhaarno));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@UNIQUE_FARMID", uniquId));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_UNIQUE_FARMID", lstparams);
            return result;
        }

        //28-04-2025
        public DataTable Get_RofrDataForAgri_sp(addbeneficiary_details obj)
        {  //Type:2
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", obj.type));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_AGRIDEPT", lstparams);
            return result;
        }
        //08-09-2025
        public DataTable Get_RofrPushToAgri_sp(addbeneficiary_details obj)
        {  //type:3
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", obj.type));
            lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_AGRIDEPT", lstparams);
            return result;
        }

        //08-10-2025
        public DataTable Get_RofrPushToAgri_sp1(addbeneficiary_details obj)
        {  //type:4
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@PTYPE", obj.type));
            lstparams.Add(new SqlParameter("@INPUT_01", obj.StartDate));
            lstparams.Add(new SqlParameter("@INPUT_02", obj.EndDate));

            // lstparams.Add(new SqlParameter("@DistrictCode", obj.Districtcode));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_AGRIDEPT", lstparams);
            return result;
        }

        //17-02-2026 Forest Land Details For Agriculture
        public DataTable ForestlandDetailsSp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new SqlParameter("@village_lgd_code", obj.village_lgd_code));

            lstparams.Add(new SqlParameter("@survey_number",
                string.IsNullOrWhiteSpace(obj.survey_number)
                    ? (object)DBNull.Value
                    : obj.survey_number));

            lstparams.Add(new SqlParameter("@PTYPE", 5));

            SQLManager sqlmngr = new SQLManager();

            return sqlmngr.ExecuteProcedureReturnDataTable(
                "PROC_PUSH_BENDATA_AGRIDEPT", lstparams);
        }

        //15-09-2026 Add New Get_AllDropDowns Method//
        public DataTable Get_AllDropDowns_sp(addbeneficiary_details obj)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_IFR_Crop_Details", lstparams);
            return result;
        }
        public DataTable GetFarmerDetails_SP(CropDetails CropDetails)
        {
            DataTable result = new DataTable();
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@PTYPE", 2));
                lstparams.Add(new SqlParameter("@ITDA_Code", CropDetails.ITDA_Code));
                lstparams.Add(new SqlParameter("@District_Code", CropDetails.District_Code));
                lstparams.Add(new SqlParameter("@Mandal_Code", CropDetails.Mandal_Code));
                lstparams.Add(new SqlParameter("@Panchayat_Code", CropDetails.Panchayat_Code));
                lstparams.Add(new SqlParameter("@Rev_Village_code", CropDetails.Rev_Village_code));
                lstparams.Add(new SqlParameter("@Village", CropDetails.village));
                lstparams.Add(new SqlParameter("@Habitation", CropDetails.Habitation));
                SQLManager sqlmngr = new SQLManager();
                result = sqlmngr.ExecuteProcedureReturnDataTable("SP_IFR_Crop_Details", lstparams);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public DataTable GetPlotdetalis_SP(CropDetails CropDetails)
        {
            DataTable result = new DataTable();
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@PTYPE", 3));
                lstparams.Add(new SqlParameter("@benficiary_id2", CropDetails.Benificiaryid));
                SQLManager sqlmngr = new SQLManager();
                result = sqlmngr.ExecuteProcedureReturnDataTable("SP_IFR_Crop_Details", lstparams);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public DataTable GetCropCategory_SP(CropDetails CropDetails)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 4));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_IFR_Crop_Details", lstparams);
            return result;
        }
        public DataTable GetCropdetalis_SP(CropDetails CropDetails)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@PTYPE", 5));
            lstparams.Add(new SqlParameter("@Crop_Category_Code", CropDetails.Crop_Category_Code));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_IFR_Crop_Details", lstparams);
            return result;
        }
    }
}