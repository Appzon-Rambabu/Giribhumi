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

namespace ROFR.helper
{
    public class Landsettlementpattasd
    {
        public DataTable GetHealthMasters(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Data1(itda, district, mandal, gp, hab, screen);
        }

        public DataTable AsetsDashboardValues(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Data2(itda, district, mandal, gp, hab, screen);
        }

        public DataTable GetmandalMasterAnalysis()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable GetGirimandalMasterAnalysis()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable GetvillageMasterAnalysis(string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable GetData(string mandal, string village)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable GetData(string Id)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable ItdaWiseGetData()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable ForestDivisionWiseGetData()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestwiselandSummaryDetails", lstparams);
            return result;
        }

        public DataTable ItdaWiseGetData(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable ItdaWiseCompartmentsData(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",11));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable ItdaWiseCompartmentsInTwoMandals(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable MandalCompartmentsInTwoMandals(string Itda, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",13));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable ItdawiseTotals(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
          
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable ItdawiseTotals()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
           

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable ForestRangeGetData(string FD)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", FD));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestwiselandSummaryDetails", lstparams);
            return result;
        }

        public DataTable ItdaWiseGetData(string Itda, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable ForestBeatGetData(string fd, string fr)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", fd));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", fr));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestwiselandSummaryDetails", lstparams);
            return result;
        }

        public DataTable ItdaWiseGetData(string Itda, string Mandal,string Village)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", Village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable ForestCompartmentWiseGetData(string fd, string fr, string fb)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", fd));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", fr));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT_CODE", fb));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestwiselandSummaryDetails", lstparams);
            return result;
        }
        public DataTable GetRdoDocuments(string Id)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LTR_ID", Id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
            return result;
        }
        public DataTable DeleteRdoDocuments(int Id)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Id));
            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rdo_sdc_orders", rdofilename));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
            return result;
        }
        public DataTable UploadRdoDocuments(int Id,string filename)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id",Id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rdo_sdc_orders", filename));
            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rdo_sdc_path", path));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
            return result;
        }
        public DataTable Land_Transfer_file_retrieve(string Id)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@LTR_ID", Id));
            //lstparams.Add(new SqlParameter("@Rdo_sdc_orders", filename)); 
            lstparams.Add(new SqlParameter("@PTYPE", 6));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
            return result;
        }

        public DataTable PopulationGetData()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_itdawise_reports", lstparams);
            return result;
        }

        public DataTable GetPopulationData(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME",Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_itdawise_reports", lstparams);
            return result;
        }

        public DataSet PopulationGetDat()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_itdawise_reports", lstparams);
            return result;
        }
        public DataTable PopulationGetData(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_itdawise_reports", lstparams);
            return result;
        }
        public DataTable PopulationGetData(string Itda, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_NAME", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_itdawise_reports", lstparams);
            return result;
        }

        public DataTable GetAllComparementsLatlongs()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("COMPARTMENTNUMBERWISE_LATLONGS", lstparams);
            return result;
        }

        public DataTable ItdawiseComparementsLatlongs(string Itda, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MandalCode", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("COMPARTMENTNUMBERWISE_LATLONGS", lstparams);
            return result;
        }

        public DataTable Rejected_claims_login(string username, string password)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@username", username));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@password", password));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }

        public DataTable RejectedClaims()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }

        public DataTable RejectedClaimsItdawise(string Itdaname)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itdaname));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }
        public DataTable RejectedClaimMandals(string Itdaname)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itdaname));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }
        public DataTable RejectedClaimsClaimidwise(string Itdaname,string Mandal,string claimid)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itdaname));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@CLAIM_ID", claimid));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }
        public DataTable RejectedClaimsMandalwise(string Itdaname, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itdaname));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }
        public DataTable Updateclaims(rejected_claims rcobj)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@CLAIM_ID", rcobj.claimid));
            lstparams.Add(new SqlParameter("@NATURE_OF_EVIDENCE", rcobj.nature_of_evidence));

            //lstparams.Add(new SqlParameter("@REJECTION_REASON", rcobj.rejection_reason));
            lstparams.Add(new SqlParameter("@LAND_IMAGE", rcobj.filepath));
            lstparams.Add(new SqlParameter("@REJECTION_NOTICE_ISSUED_OR_NOT", rcobj.rejection_notice_issued));
            lstparams.Add(new SqlParameter("@PRESENT_LAND_STATUS",rcobj.present_land_status));
            lstparams.Add(new SqlParameter("@LATITUDE",rcobj.latitude));
            lstparams.Add(new SqlParameter("@LONGITUDE",rcobj.longitude));
            lstparams.Add(new SqlParameter("@REMARKS", rcobj.remarks));
            lstparams.Add(new SqlParameter("@LEVEL_OF_REJECTION", rcobj.LEVEL_OF_REJECTION));
            lstparams.Add(new SqlParameter("@MODIFIED_DATE",rcobj.modified_date));
            lstparams.Add(new SqlParameter("@MODIFIED_BY", rcobj.modified_by));
            lstparams.Add(new SqlParameter("@GEO_COORDINATES",rcobj.geo_coordinates));
            //lstparams.Add(new SqlParameter("",rcobj.IPaddress));

            lstparams.Add(new SqlParameter("@Q1", rcobj.Q1));
            lstparams.Add(new SqlParameter("@Q2", rcobj.Q2));
            lstparams.Add(new SqlParameter("@Q3", rcobj.Q3));
            lstparams.Add(new SqlParameter("@Q3_Y", rcobj.Q3_Y));
            lstparams.Add(new SqlParameter("@Q4", rcobj.evidencepath));
            lstparams.Add(new SqlParameter("@Q5", rcobj.Q5));
            lstparams.Add(new SqlParameter("@Q6", rcobj.Q6));
            lstparams.Add(new SqlParameter("@Q6_Y", rcobj.Q6_Y));

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
           

            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
                }

        public DataTable Insertclaims(rejected_claims rcobj)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@CLAIM_ID", rcobj.claimid));
            lstparams.Add(new SqlParameter("@NATURE_OF_EVIDENCE", rcobj.nature_of_evidence));
            lstparams.Add(new SqlParameter("@ITDA", rcobj.itdaname));
            lstparams.Add(new SqlParameter("@MANDAL", rcobj.Mandal));
            lstparams.Add(new SqlParameter("@REJECTION_REASON", rcobj.rejection_reason));
            lstparams.Add(new SqlParameter("@LAND_IMAGE", rcobj.filepath));
            lstparams.Add(new SqlParameter("@REJECTION_NOTICE_ISSUED_OR_NOT", rcobj.rejection_notice_issued));
            lstparams.Add(new SqlParameter("@PRESENT_LAND_STATUS", rcobj.present_land_status));
            lstparams.Add(new SqlParameter("@LATITUDE", rcobj.latitude));
            lstparams.Add(new SqlParameter("@LONGITUDE", rcobj.longitude));
            lstparams.Add(new SqlParameter("@REMARKS", rcobj.remarks));

            lstparams.Add(new SqlParameter("@MODIFIED_DATE", rcobj.modified_date));
            lstparams.Add(new SqlParameter("@MODIFIED_BY", rcobj.modified_by));
            lstparams.Add(new SqlParameter("@GEO_COORDINATES", rcobj.geo_coordinates));
            //lstparams.Add(new SqlParameter("",rcobj.IPaddress
            lstparams.Add(new SqlParameter("@LEVEL_OF_REJECTION", rcobj.LEVEL_OF_REJECTION));
            lstparams.Add(new SqlParameter("@DISTRICT", rcobj.DISTRICT));
            lstparams.Add(new SqlParameter("@GRAM_PANCHAYAT", rcobj.GRAM_PANCHAYAT));
            lstparams.Add(new SqlParameter("@VILLAGE_HABITATION", rcobj.VILLAGE_HABITATION));
            lstparams.Add(new SqlParameter("@BENEFICIARY_NAME", rcobj.BENEFICIARY_NAME));
            lstparams.Add(new SqlParameter("@FOREST_DIVISION", rcobj.FOREST_DIVISION));
            lstparams.Add(new SqlParameter("@FOREST_RANGE", rcobj.FOREST_RANGE));
            lstparams.Add(new SqlParameter("@FOREST_BEAT", rcobj.FOREST_BEAT));
            lstparams.Add(new SqlParameter("@COMPARTMENT_NO", rcobj.COMPARTMENT_NO));
            lstparams.Add(new SqlParameter("@EXTENT_PLOT_AREA", rcobj.EXTENT_PLOT_AREA));
            lstparams.Add(new SqlParameter("@Q1", rcobj.Q1));
            lstparams.Add(new SqlParameter("@Q2", rcobj.Q2));
            lstparams.Add(new SqlParameter("@Q3", rcobj.Q3));
            lstparams.Add(new SqlParameter("@Q3_Y", rcobj.Q3_Y));
            lstparams.Add(new SqlParameter("@Q4", rcobj.evidencepath));
            lstparams.Add(new SqlParameter("@Q5", rcobj.Q5));
            lstparams.Add(new SqlParameter("@Q6", rcobj.Q6));
            lstparams.Add(new SqlParameter("@Q6_Y", rcobj.Q6_Y));
           // lstparams.Add(new SqlParameter("@GEO_COORDINATES", rcobj.geo_coordinates));



            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));


            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }

        public DataTable GetClaimid(string itda,string district,string mandal)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
           
            lstparams.Add(new SqlParameter("@ITDA",itda));
            lstparams.Add(new SqlParameter("@DISTRICT",district ));
            lstparams.Add(new SqlParameter("@MANDAL", mandal));
           
            
          

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));


            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases", lstparams);
            return result;
        }

        public DataTable RejectedClaimsVillages(string Itdaname,string district,string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itdaname));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_gs_rofr_cases",lstparams);
            return result;
        }

        public DataTable LandSummaryTotals()
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
           
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }
        public DataTable LandSummaryTotals(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", Itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Surveyandsettlementpattas_Analysis", lstparams);
            return result;
        }

        public DataTable GetItdaMaster(string USERNAME, string filtertype)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (filtertype == "Itda")
            {
               
              
                    
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
               
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
            return result;
        }
        public DataTable GetDistrictMaster(string USERNAME,string itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }


            lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
            lstparams.Add(new SqlParameter("@PTYPE", 2));

           
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
            return result;
        }
        public DataTable GetCropLoanData(string district, string start, string end, string Itda, string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@DISTRICT", (district)));
            lstparams.Add(new SqlParameter("@MANDAL", mandal));

            lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
            lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
            lstparams.Add(new SqlParameter("@PTYPE", 1));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_CROP_LOAN", lstparams);
            return result;
        }
        public DataTable GetCropLoanDataCount(string district,  string Itda, string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@DISTRICT ", (district)));
            lstparams.Add(new SqlParameter("@MANDAL", mandal));

        
            lstparams.Add(new SqlParameter("@PTYPE", 2));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_CROP_LOAN", lstparams);
            return result;
        }
        public DataTable GetItdaBeneficiaryData(string Itda, string start, string end)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
            lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
            lstparams.Add(new SqlParameter("@PTYPE", 3));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }

        public DataTable GetItdaBenData(string Itda, string start, string end)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
            lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
            lstparams.Add(new SqlParameter("@PTYPE", 8));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataTable GetRtgs_FormatData(string Itda, string district, string mandal,string village,string status, string type)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            if(status=="Valid" && type=="Aadhar")
            {
                if(mandal!="NULL" && village!="NULL")
                {
                lstparams.Add(new SqlParameter("@STATUS", status));
                lstparams.Add(new SqlParameter("@type", type));
                lstparams.Add(new SqlParameter("@itda_name", (Itda)));

            lstparams.Add(new SqlParameter("@District_Code", district));
            lstparams.Add(new SqlParameter("@mandal", mandal));
            lstparams.Add(new SqlParameter("@village", village));
            lstparams.Add(new SqlParameter("@PTYPE", 3));
                }
               else if (mandal == "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 8));
                }
                else if (village == "NULL" && mandal!= "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 9));
                }
                else if (mandal=="NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 10));
                }
            }
           else if (status == "Valid" && type == "Bank")
            {
                  if (mandal != "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 4));
                }

               else if (mandal == "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 11));
                }

               else if (mandal != "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 12));
                }

               else if (mandal == "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 13));
                }
            }
            else if (status == "Invalid" && type == "Aadhar")
            {
                 if (mandal != "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 5));
                }
                if (mandal == "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 14));
                }
               else if (mandal != "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 15));
                }
               else if (mandal == "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 16));
                }
            }
            else if (status == "Invalid" && type == "Bank")
            {
                if (mandal != "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 6));
                }
               else if (mandal == "NULL" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 17));
                }
              else  if (mandal != "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 18));
                }
               else if (mandal == "NULL" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@STATUS", status));
                    lstparams.Add(new SqlParameter("@type", type));
                    lstparams.Add(new SqlParameter("@itda_name", (Itda)));

                    lstparams.Add(new SqlParameter("@District_Code", district));
                    lstparams.Add(new SqlParameter("@mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 19));
                }
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Rtgs_Data", lstparams);
            return result;
        }
        public DataTable ViewBeneficiaryPlots(string bid,string userprevileges,string username)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(username))
            {
                a = username;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;

            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
         
            lstparams.Add(new SqlParameter("@benficiary_id", (bid)));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataSet BeneficiaryePassbook(string bid, string userprevileges, string username)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(username))
            {
                a = username;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;

            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }


            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
            lstparams.Add(new SqlParameter("@benficiary_id", (bid)));


            lstparams.Add(new SqlParameter("@PTYPE", 7));

            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("[Beneficary_Master_Count]", lstparams);
            return result;
        }
        public DataSet EPassbook(string bid, string userprevileges, string username)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(username))
            {
                a = username;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;

            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }


            lstparams.Add(new SqlParameter("@benficiary_id", (bid)));
            lstparams.Add(new SqlParameter("@PTYPE", 3));

            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("[Proc_EPass_Book]", lstparams);
            return result;
        }

        public DataSet ViewPassbook(string bid, string userprevileges, string username)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(username))
            {
                a = username;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;

            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }


            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
            lstparams.Add(new SqlParameter("@benficiary_id", (bid)));


            lstparams.Add(new SqlParameter("@PTYPE", 4));

            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("[Proc_EPass_Book]", lstparams);
            return result;
        }
        public DataTable BeneficiaryPassbook(string bid, string userprevileges, string username)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(username))
            {
                a = username;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;

            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
          

                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
                    lstparams.Add(new SqlParameter("@benficiary_id", (bid)));


                    lstparams.Add(new SqlParameter("@PTYPE", 7));
              
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("[Beneficary_Master_Count]", lstparams);
            return result;
        }
        public DataTable GetItdabeneficiarycount(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@PTYPE", 2));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataTable GetItdabencount(string Itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@PTYPE", 7));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }

        public DataTable GetLtrDataCount(string Itda,string district, string mandal,string village,string hab)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@ITDA_NAME", (Itda)));
            lstparams.Add(new SqlParameter("@DISTRICT ", (district)));
            lstparams.Add(new SqlParameter("@MANDAL", mandal));


            lstparams.Add(new SqlParameter("@PTYPE", 2));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_CROP_LOAN", lstparams);
            return result;
        }
        public DataTable GetHealthMasters(string type, string district,string facility)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
           
            if (type == "district")
            {
                

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                
            }
            if (type == "facility")
            {
                    
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
               


            }
            if (type == "hospital")
            {
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@HEALTH_FACILITY", facility));
                lstparams.Add(new SqlParameter("@PTYPE", 3));



            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
            return result;
        }
        public DataTable GetRofrMasters(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {
                if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (type == "District")
            {

                if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "RtgsVillage")
            {
                if(mandal!="NULL")
                { 
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (mandal == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
              
            }
            else if (type == "status")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "type")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER", lstparams);
            return result;
        }

        public DataTable GetRofrMasters1(string USERNAME, string type, string itda, string district, string mandal, string panchayat, string revvillage, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {

               // lstparams.Add(new SqlParameter("@PTYPE", "0"));

                if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                {
                    userprevilages = "ALL";
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@District", ITDANAME));


                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (type == "District")
            {
                //lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                //lstparams.Add(new SqlParameter("@PTYPE", 2));


                if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }

            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat", panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@RevVillage", revvillage));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat", panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@RevVillage", revvillage));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "Division")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (type == "Range")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "Beat")
            {

               lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (type == "Gp")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "RV")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Panchayat", panchayat));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
            }
            else if (type == "RtgsVillage")
            {
                if (mandal != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (mandal == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }

            }
            else if (type == "status")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "type")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }

        public DataTable defaultcastefillmaster(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }
        public DataTable Getcastemaster(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }

        public DataTable GetSubcastemaster(string USERNAME, string type, string itda, string mandal, string district, string Caste, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if(Caste !="ST")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@CASTE", Caste));
            }
            else 
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@CASTE", Caste));
                
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }


        public DataTable GetadangalMasters1(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {


                lstparams.Add(new SqlParameter("@PTYPE", "20"));

                //if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                //{
                //    userprevilages = "ALL";
                //    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                //    lstparams.Add(new SqlParameter("@PTYPE", 1));
                //}
                //else if (start == "DTW")
                //{
                //    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                //    lstparams.Add(new SqlParameter("@District", ITDANAME));


                //    lstparams.Add(new SqlParameter("@PTYPE", 1));
                //}
                //else
                //{
                //    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                //    lstparams.Add(new SqlParameter("@PTYPE", 1));
                //}
            }
            if (type == "District")
            {
                lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new SqlParameter("@PTYPE", 22));


                //if (start == "DTW")
                //{
                //    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                //    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                //    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                //    lstparams.Add(new SqlParameter("@PTYPE", 2));
                //}
                //else
                //{
                //    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                //    lstparams.Add(new SqlParameter("@PTYPE", 2));
                //}


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "Division")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (type == "Range")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "Beat")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (type == "Gp")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "RV")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
            }
            else if (type == "RtgsVillage")
            {
                if (mandal != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (mandal == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }

            }
            else if (type == "status")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "type")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_MASTER1", lstparams);
            return result;
        }


        public DataTable Getbeneficiarytransaction(string USERNAME, string filtertype, string district, string mandal, string village, string adhar)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            string uprevilege = district;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }

            if (filtertype == "getdetails")
            {
                if (district == "ALL" || district == "" || district == null)
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", district));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (district == ITDANAME)
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }


        public DataTable UpdateFarmer(addbeneficiary_details obj, string Username)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@benficiary_id", obj.id));
            lstparams.Add(new SqlParameter("@Father_Name", obj.fathername));
            lstparams.Add(new SqlParameter("@Caste", obj.caste));
            lstparams.Add(new SqlParameter("@Sub_Caste", obj.sub_caste));
            lstparams.Add(new SqlParameter("@New_Aadhaar_no", obj.Aadhaar_NO));
            lstparams.Add(new SqlParameter("@BankAccountNo", obj.bankaccountno));
            lstparams.Add(new SqlParameter("@IfscCode", obj.ifsccode));
            lstparams.Add(new SqlParameter("@BankName", obj.bankname));
            lstparams.Add(new SqlParameter("@IPADDRESS", obj.Ipaddress));
            lstparams.Add(new SqlParameter("@UserName", Username));
            lstparams.Add(new SqlParameter("@DOB", obj.dob));
            lstparams.Add(new SqlParameter("@GENDER", obj.gender));
            lstparams.Add(new SqlParameter("@HOME_ADRESS", obj.Address));
            lstparams.Add(new SqlParameter("@MOBILE_NO",obj.Mobileno));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 9));
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Farmer_Validation", lstparams);
            return result;
        }
        public DataTable UpdateFarmerLandDetails(addbeneficiary_details obj, string Username)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@id", obj.id));
            lstparams.Add(new SqlParameter("@REV_Village", obj.rev_village));
            lstparams.Add(new SqlParameter("@Village_Revcode", obj.rev_village_code));
            lstparams.Add(new SqlParameter("@Gram_Panchayat", obj.Gram_Panchayat));
            lstparams.Add(new SqlParameter("@Grama_Panchayat_Code", obj.Grama_Panchayat_Code));

            lstparams.Add(new SqlParameter("@Forest_Division", obj.Forest_Division));
            lstparams.Add(new SqlParameter("@Forest_DivisionCode", obj.Forest_DivisionCode));
            lstparams.Add(new SqlParameter("@Forest_Range", obj.Forest_Range));
            lstparams.Add(new SqlParameter("@Forest_RangeCode", obj.Forest_RangeCode));
            lstparams.Add(new SqlParameter("@Forest_Beat", obj.Forest_Beat));
            lstparams.Add(new SqlParameter("@Forest_BeatCode", obj.Forest_BeatCode));
            lstparams.Add(new SqlParameter("@Forest_Block", obj.Forest_Block));

            lstparams.Add(new SqlParameter("@Compartment_No", obj.Compartment_No));
            lstparams.Add(new SqlParameter("@Plot_No", obj.Plot_No));
            lstparams.Add(new SqlParameter("@ROFR_PATTANO", obj.ROFR_PATTANO));
            lstparams.Add(new SqlParameter("@ExtentPlotArea", obj.ExtentPlotArea));
            lstparams.Add(new SqlParameter("@Cultivable_Land", obj.Cultivable_Land));
            lstparams.Add(new SqlParameter("@Uncultivable_Land", obj.Uncultivable_Land));
            lstparams.Add(new SqlParameter("@HOLDING_NATURE", obj.HOLDING_NATURE));
            lstparams.Add(new SqlParameter("@Water_Tax", obj.Water_Tax));
            lstparams.Add(new SqlParameter("@DRYID_ONECROP_TWO_CROP", obj.DRYID_ONECROP_TWO_CROP));
            lstparams.Add(new SqlParameter("@WATER_SOURCE", obj.WATER_SOURCE));
            lstparams.Add(new SqlParameter("@EXTENT_IRRIGATED", obj.EXTENT_IRRIGATED));
            lstparams.Add(new SqlParameter("@EXTENT_UNDER_CULTIVATOR", obj.EXTENT_UNDER_CULTIVATOR));
            lstparams.Add(new SqlParameter("@TYPE_CODE", obj.TYPE_CODE));
            lstparams.Add(new SqlParameter("@extent", obj.EXTENT));
            lstparams.Add(new SqlParameter("@NET_SOWN_AREA", obj.NET_SOWN_AREA));
            lstparams.Add(new SqlParameter("@KHARIFF_RABI", obj.KHARIFF_RABI));
            lstparams.Add(new SqlParameter("@MONTH_OF_CULTIVATION", obj.MONTH_OF_CULTIVATION));
            lstparams.Add(new SqlParameter("@crop", obj.CROP));
            lstparams.Add(new SqlParameter("@single", obj.SINGLE));
            lstparams.Add(new SqlParameter("@mixed", obj.MIXED));
            lstparams.Add(new SqlParameter("@total", obj.TOTAL));
            lstparams.Add(new SqlParameter("@WATER_SOURCE1", obj.WATER_SOURCE1));
            lstparams.Add(new SqlParameter("@FIRST_CROP", obj.FIRST_CROP));
            lstparams.Add(new SqlParameter("@SECOND_THIRD_CROP", obj.SECOND_THIRD_CROP));
            lstparams.Add(new SqlParameter("@CROP_YIELD", obj.CROP_YIELD));
            lstparams.Add(new SqlParameter("@VRO_RI_REMARKS", obj.VRO_RI_REMARKS));
            lstparams.Add(new SqlParameter("@TAHSILDAR_REMARKS", obj.TAHSILDAR_REMARKS));
            lstparams.Add(new SqlParameter("@REMARKS", obj.REMARKS));
        
            lstparams.Add(new SqlParameter("@IPADDRESS", obj.Ipaddress));
            lstparams.Add(new SqlParameter("@UserName", Username));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 12));
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Farmer_Validation", lstparams);
            return result;
        }
        public DataTable GetMastersUpdate(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {
                if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                {
                    userprevilages = "ALL";
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@ptype", 1));
                }
                else if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    //lstparams.Add(new SqlParameter("@District", ITDANAME));


                    lstparams.Add(new SqlParameter("@ptype", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                    lstparams.Add(new SqlParameter("@ptype", 1));
                }
            }
            if (type == "District")
            {

                if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@ptype", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@ptype", 2));
                }


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 3));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 5));
            }
            else if (type == "Division")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 13));
            }
            else if (type == "Range")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 14));
            }
            else if (type == "Beat")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 15));
            }
            else if (type == "Dryid")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 16));
            }
            else if (type == "Kharif")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 17));
            }
            else if (type == "Month")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 18));
            }
            else if (type == "Nature")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 19));
            }
            else if (type == "Details")
            {

                if (itda != "" && district != "" && mandal != "" && village != "" && village != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 7));
                }
                else if (itda != "" && district != "" && mandal != "" && village != "" && village == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 8));
                }
            }
            else if (type == "FDetails")
            {

                if (itda != "" && district != "" && mandal != "" && village != "" && village != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 10));
                }
                else if (itda != "" && district != "" && mandal != "" && village != "" && village == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ptype", 11));
                }
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Farmer_Validation", lstparams);
            return result;
        }
        public DataTable Beneficiary_Deletion_Form_Getdata(string USERNAME, string type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }



            if (itda == "9")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 1));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ""));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", ""));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", ""));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAAR_NO", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", ""));


            }
            else
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 2));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", ""));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", ""));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAAR_NO", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", ""));
            }





            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BENEFICIARY_DELETION", lstparams);
            return result;
        }

        public DataTable Beneficiary_Deletion(string USERNAME, string type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }



            if (type == "Mandal")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 13));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 14));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }


            if (type == "Benificiary")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 4));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 5));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Ben_del")
            {



            

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 6));

               

            }

            if (type == "Land")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 7));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 8));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Land_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id2", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 9));



            }

            if (type == "NoLand")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 10));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 11));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "NoLand_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 12));



            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BENEFICIARY_DELETION", lstparams);
            return result;
        }


        public DataTable Beneficiary_Deletion_rofrtest(string username, string type)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            
           
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", type));
            
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BEN_TESTLOGIN_DELETION", lstparams);
            return result;
        }
        public DataTable Beneficiary_Deletion_rofrtestsubmit(string username, string Reason, string Benid, string type,string id)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", type));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", Reason));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", Benid));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BEN_TESTLOGIN_DELETION", lstparams);
            return result;
        }

        public DataTable Beneficiary_Deletion_rofrdisplay(string username, string type, string Mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", Mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", type));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BEN_TESTLOGIN_DELETION", lstparams);
            return result;
        }

        public DataTable deletenolBeneficiary_Deletion(string USERNAME, string type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }



            if (type == "Mandal")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 15));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 16));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }


            if (type == "Benificiary")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 4));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 5));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Ben_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 6));



            }

            if (type == "Land")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 7));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 8));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Land_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id2", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 9));



            }

            if (type == "NoLand")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 10));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 11));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "NoLand_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 12));



            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BENEFICIARY_DELETION", lstparams);
            return result;
        }

        public DataTable DELETENOLANDBeneficiary_Deletion(string USERNAME, string type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string Itdastart = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                Itdastart = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }



            if (type == "Mandal")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 17));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 18));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }


            if (type == "Benificiary")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 4));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 5));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Ben_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 6));



            }

            if (type == "Land")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 7));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 8));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "Land_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id2", itdaname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 9));



            }

            if (type == "NoLand")
            {



                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 10));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", adharno));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 11));
                }
                //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                //{
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                //}

            }

            if (type == "NoLand_del")
            {





                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", USERNAME));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", adharno));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", itdaname));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 12));



            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BENEFICIARY_DELETION", lstparams);
            return result;
        }


        public DataTable Beneficiary_Deletion_Form_Deletedata(addbeneficiary_details obj, string Username, string reason)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@P_TYPE", 3));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ""));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ""));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", Username));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@benficiary_id", obj.id));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAAR_NO", obj.Aadhaar_NO));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DELETE_REASON", reason));

            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_BENEFICIARY_DELETION", lstparams);
            return result;
        }
        public DataTable GetAdharPhotoUpdate(string USERNAME, string type, string itda,string starts,string end)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "records")
            {
                lstparams.Add(new SqlParameter("@ITDA ", itda));
                lstparams.Add(new SqlParameter("@PTYPE", 10));
            }
           else if (type == "details")
            {
                lstparams.Add(new SqlParameter("@ITDA", itda));
                lstparams.Add(new SqlParameter("@Start_range", starts));
                lstparams.Add(new SqlParameter("@End_range",end));
                lstparams.Add(new SqlParameter("@PTYPE", 11));
            }
            else if (type == "update")
            {
                lstparams.Add(new SqlParameter("@Beneficiary_id", itda));
                lstparams.Add(new SqlParameter("@Start_range", starts));
                lstparams.Add(new SqlParameter("@End_range", end));
                lstparams.Add(new SqlParameter("@PTYPE", 11));
            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }
        public DataTable GetAdharUpdateImage(adhar_detials aobj)
        {
            SQLManager sqlmngr = new SQLManager();
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_IMAGE", aobj.Imagepath));
            //lstparams.Add(new SqlParameter("@Image1", aobj.Image1));
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_NAME", aobj.adharname));
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_CAREOF", aobj.careof));
            //lstparams.Add(new SqlParameter("@State_Code", aobj.statecode));
            //lstparams.Add(new SqlParameter("@District_Code", aobj.distcode));
            //lstparams.Add(new SqlParameter("@District", aobj.distname));
            //lstparams.Add(new SqlParameter("@Mandal_Code", aobj.mandalcode));
            //lstparams.Add(new SqlParameter("@Mandal", aobj.mandal));
            //lstparams.Add(new SqlParameter("@Village_Code", aobj.vcode));
            //lstparams.Add(new SqlParameter("@Village", aobj.vname));
            //lstparams.Add(new SqlParameter("@Street", aobj.street));
            //lstparams.Add(new SqlParameter("@Pincode", aobj.pincode));
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_DOB", aobj.dob));
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_GENDER", aobj.gender));
            lstparams.Add(new SqlParameter("@AADHAAR_SERVICE_PHONE_NO", aobj.phoneno));
            lstparams.Add(new SqlParameter("@Beneficiary_id", aobj.bid));

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;




        }
    public DataTable Get1bdetails(string USERNAME,string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            bool hasAadhaar = !string.IsNullOrWhiteSpace(adharno);
            bool hasPattadar = !string.IsNullOrWhiteSpace(pattadar);
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "pattadar")
            {
                
                    lstparams.Add(new SqlParameter("@Itda_name", itda));
                    lstparams.Add(new SqlParameter("@District", district));
                    lstparams.Add(new SqlParameter("@Mandal", mandal));
                    lstparams.Add(new SqlParameter("@village", village));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
               
            }
            else if (type == "pname")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Rofr_Pattadaar", pattadar));
                lstparams.Add(new SqlParameter("@PTYPE", 3));

            }
            else if (type == "adhar")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Aadhaar_No", adharno));
                lstparams.Add(new SqlParameter("@PTYPE", 4));

            }
            else if (type == "cno")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));
                lstparams.Add(new SqlParameter("@PTYPE", 5));

            }
            else if (type == "1bdetails")
            {
                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                if(hasAadhaar && hasPattadar)
                {
                    lstparams.Add(new SqlParameter("@Rofr_Pattadaar",pattadar));
                    lstparams.Add(new SqlParameter("@Aadhaar_No", adharno));
                    lstparams.Add(new SqlParameter("@PTYPE", 6));
                }
                else if(hasPattadar)
                {
                    lstparams.Add(new SqlParameter("@Rofr_Pattadaar",pattadar));
                    lstparams.Add(new SqlParameter("@Aadhaar_No",
                        hasAadhaar ? (object)adharno : DBNull.Value));

                    lstparams.Add(new SqlParameter("@PTYPE", 6));
                }
                
            }
            else if (type == "grama1b")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));
               
                lstparams.Add(new SqlParameter("@PTYPE", 1));

            }
            else if (type == "adangal")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));

                lstparams.Add(new SqlParameter("@PTYPE", 7));

            }
            else if (type == "adangalpname")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));

                lstparams.Add(new SqlParameter("@PTYPE", 7));

            }
            else if (type == "gramaAdangal")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                

                lstparams.Add(new SqlParameter("@PTYPE", 8));

            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_BenDetails_1B", lstparams);
            return result;
        }
        public DataTable Epassbook(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
           
          if (type == "pname")
            {

                lstparams.Add(new SqlParameter("@Itda_Name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@Village", village));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", pattadar));
                lstparams.Add(new SqlParameter("@PTYPE", 2));

            }
            else if (type == "adhar")
            {

                lstparams.Add(new SqlParameter("@Itda_Name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@Village", village));
                lstparams.Add(new SqlParameter("@Aadhaar_NO", adharno));
                lstparams.Add(new SqlParameter("@PTYPE", 1));

            }
           
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_EPass_Book", lstparams);
            return result;
        }

        public DataTable GetAdharwise_rofrdata(string USERNAME, string type, string bid,  string adharno, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }

            if (type == "master")
            {

                lstparams.Add(new SqlParameter("@AADHAAR_NO", adharno));
                lstparams.Add(new SqlParameter("@PTYPE", 13));

            }
            else if (type == "details")
            {

                lstparams.Add(new SqlParameter("@benficiary_id", bid));
                lstparams.Add(new SqlParameter("@AADHAAR_NO", adharno));
                lstparams.Add(new SqlParameter("@PTYPE", 14));

            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
            return result;
        }
        public DataTable UploadImage(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }

            if (type == "details")
            {

                lstparams.Add(new SqlParameter("@ITDA", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@Village", village));
               
                lstparams.Add(new SqlParameter("@PTYPE", 8));

            }
            else if (type == "upload")
            {
                string imagename = itda;
                string imagepath = district;
                string bid = mandal;
                lstparams.Add(new SqlParameter("@Image1", imagename));
                lstparams.Add(new SqlParameter("@Imagepath", imagepath));
                lstparams.Add(new SqlParameter("@Beneficiary_id",bid));
                lstparams.Add(new SqlParameter("@UserName", USERNAME));
                lstparams.Add(new SqlParameter("@PTYPE", 9));

            }

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
            return result;
        }
        public DataTable GetMasters(string USERNAME, string type,string itda, string district, string mandal, string village,string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {
                if(userprevilages=="ALL"|| userprevilages == ""|| userprevilages == null)
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                   
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (type == "District")
            {
                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@PTYPE", 2));

               
            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME",itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@revenue_village", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "5"));
            }


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LTR_MASTER", lstparams);
            return result;
        }

        public DataTable GetItdawiseBeneficiary(string  itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
           

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
            
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));
            


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataTable GetItdawiseBen(string itda)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "6"));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataTable GetDistrictMissingData(string itda,string district)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();


            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));

            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "4"));



            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SP_BENEFICIARY_DETAILS", lstparams);
            return result;
        }
        public DataSet GetLtrData(string ltrId)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LTR_ID", ltrId));
            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@RS_NO", rsno));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("MASTER_DATA_PROC", lstparams);
            return result;
        }
        public DataSet GetAdhar_Analysis(string itda,string district)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", itda));
          
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
            SQLManager sqlmngr = new SQLManager();
            DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_aadharwise_analysis", lstparams);
            return result;
        }

        public DataTable GetLtrData(string itda, string district, string mandal, string village,string habitation)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
           lstparams.Add(new System.Data.SqlClient.SqlParameter("@HABITATION", habitation));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",10));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
            return result;
        }

        public DataTable UpadteLtrstatus(string itda, string district, string mandal, string village,string hab)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@HABITATION",hab));
            // lstparams.Add(new System.Data.SqlClient.SqlParameter("@STATUS",status));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC1", lstparams);
            return result;
        }
        public DataTable UpdateCase(string ltrid, string refno, string casestatus, string caselevel)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LTR_ID ", ltrid));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@REFERENCE_NO", refno));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@case_status", casestatus));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@case_level", caselevel));
            // lstparams.Add(new System.Data.SqlClient.SqlParameter("@STATUS",status));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC1", lstparams);
            return result;
        }
        public DataTable Getlatlongsdata(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(obj.Ben_Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 20));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable Submit_key_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE","1"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL",obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //12-11-2024
        public DataTable Submit1_key_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //20-02-2025 Adding for key

        public DataTable FramIdSubmit_key_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "1"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable check_key_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //12-11-2024
        public DataTable check_key_data1(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //20-11-2025

        public DataTable FarmID_check_key_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataTable check_keynew_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "4"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Get_Plt_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "3"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Get_SPCrop_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "5"));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", obj.Districtcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandalcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REVENUE_VILLAGECODE", obj.RVCode));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Get_lnd_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "3"));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAAR_NO", obj.Adhno));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_RTGS", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetMasterslatlongsdata(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(obj.Ben_Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 21));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ITDAMANDALVILLAGEdropdowns(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", (obj.ITDA)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.MANDAL));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.VILLAGE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Category", obj.Category));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_GIS_LATLONGS", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetItdalatlongsdata(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", (obj.ITDA)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", obj.MANDAL));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", obj.VILLAGE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Category", obj.Category));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_GIS_LATLONGS", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable Villageprofiledropdowns(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Villageprofiledropdowns(itda, district, mandal, gp, hab, screen);
        }
        public DataTable Piechartdata(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
          
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_aadhar_status", lstparams);
            return result;
        }
        public DataTable GisReport(string hab, string dept, string asset, string subasset, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.GisReport(hab, dept, asset, subasset, screen);
        }

        public DataTable Report(string hab, string dept, string assest, string subassest, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Report(hab, dept, assest,subassest, screen);
        }

        public DataTable Villagewiseallassetslatongs(string hab, string dept, string asset, string subasset, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Villagewiseallassetslatongs(hab, dept, asset, subasset, screen);
        }

        public DataTable AssetFacility(string hab, string dept, string asset, string subasset, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.AssetFacility(hab, dept, asset, subasset, screen);
        }

        public DataTable Villagefencing(string hab, string dept, string asset, string subasset, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Villagefencing(hab, dept, asset, subasset, screen);
        }

        public DataTable Subassetextradetails(string hab, string dept, string asset, string subasset, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Subassetextradetails(hab, dept, asset, subasset, screen);
        }

        public DataTable GetRofrMasters11(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", (itda)));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_CODE", district));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Rofr_Complaints", lstparams);
            return result;
        }

        public DataTable SaveComplaint(string name, string mobile, string aadhar, string address, string complaint, string mail, string itda, string dist, string mandal, string village, string patta)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", dist));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Rofr_Pattano", patta));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint_Person_Name", name));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint_Person_Aadhaar_No", aadhar));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint_Person_Mobile", mobile));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint_Person_Address", address));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint_Person_EmailId", mail));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Complaint", complaint));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@Benficiary_Id", ""));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@id", ""));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@IPADDRESS", ""));
            lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Rofr_Complaints", lstparams);
            return result;
        }

        public DataTable DeptAssetcount(string hab)
        {
            HealthConnection con = new HealthConnection();
            return con.deptassetcount(hab);
        }

        public DataTable Road(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.RoadFencing(itda, district, mandal, gp, hab, screen);
        }

        public DataTable Roadservice(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Roadservice(itda, district, mandal, gp, hab, screen);
        }

        public DataTable ChartAsetsDashboardValues(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Data3(itda, district, mandal, gp, hab, screen);
        }


        public DataTable Get_Ecrop_sp(addbeneficiary_details obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", obj.Itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", obj.District));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL",obj.Mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", obj.Village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_ECrop", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable UpdateEcrop_sp(addbeneficiary_details obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DRYID_ONECROP_TWO_CROP", obj.DRYID_ONECROP_TWO_CROP));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE_CODE", obj.TYPE_CODE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@CROP", obj.CROP));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FIRST_CROP", obj.FIRST_CROP));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@SECOND_THIRD_CROP", obj.SECOND_THIRD_CROP));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@CROP_YIELD", obj.CROP_YIELD));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@CROP_IMAGE", obj.Imagepath));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@WATER_TAX", obj.Water_Tax));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@WATER_SOURCE", obj.WATER_SOURCE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@KHARIFF_RABI", obj.KHARIFF_RABI));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MONTH_OF_CULTIVATION", obj.MONTH_OF_CULTIVATION));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@SINGLE", obj.SINGLE));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MIXED", obj.MIXED));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@WATER_SOURCE1", obj.WATER_SOURCE1));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VRO_RI_REMARKS", obj.VRO_RI_REMARKS));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@TAHSILDAR_REMARKS", obj.TAHSILDAR_REMARKS));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@IPADDRESS", obj.Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MODIFIED_BY", obj.Modified_by));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ID", obj.id));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_ECrop", lstparams);


                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        public DataTable GetRofrMasters2(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {
                if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                {
                    userprevilages = "ALL";
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@District", ITDANAME));


                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 1));
                }
            }
            if (type == "District")
            {

                if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 2));
                }


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "Division")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (type == "Range")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "Beat")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (type == "Gp")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "RtgsVillage")
            {
                if (mandal != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (mandal == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }

            }
            else if (type == "status")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "type")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LATLONG_UP_DROPDOWNS", lstparams);
            return result;
        }

        public DataTable GetRofrMasters3(string USERNAME, string type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "Itda")
            {
                if (userprevilages == "ALL" || userprevilages == "" || userprevilages == null)
                {
                    userprevilages = "ALL";
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));
                    lstparams.Add(new SqlParameter("@PTYPE", 5));
                }
                else if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@District", ITDANAME));


                    lstparams.Add(new SqlParameter("@PTYPE", 5));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@userprevilages", userprevilages));

                    lstparams.Add(new SqlParameter("@PTYPE", 5));
                }
            }
            if (type == "District")
            {

                if (start == "DTW")
                {
                    lstparams.Add(new SqlParameter("@ITDA_NAME", start));
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", ITDANAME.Trim()));
                    lstparams.Add(new SqlParameter("@PTYPE", 6));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA_CODE", itda));
                    lstparams.Add(new SqlParameter("@PTYPE", 6));
                }


            }
            else if (type == "Mandal")
            {
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (type == "Village")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "Habitation")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "Division")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            else if (type == "Range")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
            }
            else if (type == "Beat")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Division", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Forest_Range", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
            }
            else if (type == "Gp")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
            }
            else if (type == "RV")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
            }
            else if (type == "RtgsVillage")
            {
                if (mandal != "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (mandal == "NULL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_CODE", itda));

                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    ////lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }

            }
            else if (type == "status")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
            }
            else if (type == "type")
            {

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_EPass_Book", lstparams);
            return result;
        }

        public DataTable Get1bdetails1(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            string a = string.Empty;
            if (!string.IsNullOrEmpty(USERNAME))
            {
                a = USERNAME;
            }
            else
            {
                a = "admin123";
            }

            var regexItem = new Regex("_");
            string start = string.Empty;
            string ITDANAME = string.Empty;
            if (regexItem.IsMatch(a))
            {
                var range = a.IndexOf('_');

                start = a.Substring(0, range);
                ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
            }
            if (type == "pattadar")
            {

                lstparams.Add(new SqlParameter("@Itda_Name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@Village", village));
                lstparams.Add(new SqlParameter("@PTYPE", 9));

            }
            else if (type == "pname")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Rofr_Pattadaar", pattadar));
                lstparams.Add(new SqlParameter("@PTYPE", 3));

            }
            else if (type == "adhar")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Aadhaar_No", adharno));
                lstparams.Add(new SqlParameter("@PTYPE", 4));

            }
            else if (type == "cno")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));
                lstparams.Add(new SqlParameter("@PTYPE", 5));

            }
            else if (type == "1bdetails")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));
                lstparams.Add(new SqlParameter("Rofr_Pattadaar", pattadar));
                lstparams.Add(new SqlParameter("@PTYPE", 6));

            }
            else if (type == "grama1b")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));

                lstparams.Add(new SqlParameter("@PTYPE", 1));

            }
            else if (type == "adangal")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));

                lstparams.Add(new SqlParameter("@PTYPE", 7));

            }
            else if (type == "adangalpname")
            {

                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@MANDAL", mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", village));
                lstparams.Add(new SqlParameter("@Compartment_No", cno));

                lstparams.Add(new SqlParameter("@PTYPE", 7));

            }
            else if (type == "gramaAdangal")
            {

                lstparams.Add(new SqlParameter("@Itda_name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                lstparams.Add(new SqlParameter("@Mandal", mandal));
                lstparams.Add(new SqlParameter("@village", village));


                lstparams.Add(new SqlParameter("@PTYPE", 8));

            }
            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_EPass_Book", lstparams);
            return result;
        }

        //12-11-2024 Newly adding data
        public DataTable Get_SPhouse_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "2"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DistrictCode", obj.Districtcode));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_CitizenService_HHData", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //20-02-2025 

        public DataTable Get_SPFarmID_data(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", obj.Type));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@DistrictCode", obj.Districtcode));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //21-02-2025
        public DataTable Get_Aadhar_data_sp(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "7"));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@URL", obj.url));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@API_KEY", obj.key));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@IP_ADDRESS", obj.Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Aadhaar_NO", obj.AadharNo));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //02-05-2025

        public DataTable Get_Adangal_Details_sp(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "8"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", obj.Districtcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandalcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", obj.Villagecode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PlotId", obj.Plotid));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable Get_PlotID_data_sp(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "9"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", obj.Districtcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandalcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", obj.Villagecode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@BeneficiaryId", obj.Ben_Id));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Get_Ror_data_sp(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "10"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District_Code", obj.Districtcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal_Code", obj.Mandalcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", obj.Villagecode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@BeneficiaryId", obj.Ben_Id));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //--------------------new method 20072026----------------
        public DataTable Get_RofrCropInsurance_sp(latlongsModel obj)
        {
            try
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", "11"));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VillageCode", obj.Villagecode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PlotId", obj.Plotid));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_PUSH_BENDATA_CCLA", lstparams);
                if (result != null && result.Rows.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //-------------------------------------------------------
    }

}