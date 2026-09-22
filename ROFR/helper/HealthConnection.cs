using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Dynamic;
using System.Drawing;
using System.Management;

using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web.UI;


namespace ROFR.helper
{
    public class HealthConnection
    {

        public DataTable result_tbl = null;
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["HEALTH"].ConnectionString);


        //string oradbnew = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=apexadata-scan1.apsdc.ap.gov.in)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=apsps16)));User Id=itda;Password=giripragati;";

        //OracleConnection con;
        OracleCommand objCmd;
        OracleDataAdapter dap;
        DataTable dt;

        string PName = "";

        private void Con_Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private void Con_Close_Exception()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (objCmd != null)
            {
                objCmd.Dispose();
                dap.Dispose();
                dt.Dispose();
            }
        }

      

        public DataTable Data(string dist, string facility, string hospital, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "rtgs_health";
                objCmd.Parameters.Add("p_dis", OracleDbType.Varchar2).Value = dist;
                objCmd.Parameters.Add("p_HEALTH_FACILITY", OracleDbType.Varchar2).Value = facility;
                objCmd.Parameters.Add("p_hsptl_name", OracleDbType.Varchar2).Value = hospital;
                objCmd.Parameters.Add("p_screen", OracleDbType.Varchar2).Value = screen;

                objCmd.Parameters.Add("p_cur ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable Data1(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.TW_CENTRIC_REPORT_PROC";
                objCmd.Parameters.Add("p_itda", OracleDbType.Varchar2).Value = itda;
                objCmd.Parameters.Add("p_dist", OracleDbType.Varchar2).Value = district;
                objCmd.Parameters.Add("p_mandal", OracleDbType.Varchar2).Value = mandal;
                objCmd.Parameters.Add("p_gp", OracleDbType.Varchar2).Value = gp;
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_screen", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }


        public DataTable Data2(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.TW_CENTRIC_per_REPORT_PROC";
                objCmd.Parameters.Add("P_DIS", OracleDbType.Varchar2).Value = district;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = itda;
                objCmd.Parameters.Add("P_MANDAL", OracleDbType.Varchar2).Value = mandal;
                objCmd.Parameters.Add("P_HAB", OracleDbType.Varchar2).Value = gp;
                objCmd.Parameters.Add("P_DEPT", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_screen", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("P_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }



        public DataTable Data3(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.TW_CENTRIC_per_REPORT_PROC";
                objCmd.Parameters.Add("P_DIS", OracleDbType.Varchar2).Value = district;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = itda;
                objCmd.Parameters.Add("P_MANDAL", OracleDbType.Varchar2).Value = mandal;
                objCmd.Parameters.Add("P_HAB", OracleDbType.Varchar2).Value = gp;
                objCmd.Parameters.Add("P_DEPT", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_screen", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("P_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable PssData(string adhar, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_ROFR_SPS";
                objCmd.Parameters.Add("P_aadhaar", OracleDbType.Varchar2).Value = adhar;
            

                objCmd.Parameters.Add("p_cur ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable Villageprofiledropdowns(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_master_dropdown";
                objCmd.Parameters.Add("p_itda", OracleDbType.Varchar2).Value = itda;
                objCmd.Parameters.Add("p_dis", OracleDbType.Varchar2).Value = district;
                objCmd.Parameters.Add("p_mandal", OracleDbType.Varchar2).Value = mandal;
                objCmd.Parameters.Add("p_gp", OracleDbType.Varchar2).Value = gp;
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_screen", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        
        public DataTable GisReport(string hab, string dept, string asset, string subasset, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_web_report";
                objCmd.Parameters.Add("P_HAB", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("P_DEPT", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("P_ASSET", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("P_SUB_ASSET", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
              
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }
        public DataTable Report(string hab, string dept, string asset, string subassest,  string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_web_report";
                objCmd.Parameters.Add("P_HAB", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("P_DEPT", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("P_ASSET", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("P_SUB_ASSET", OracleDbType.Varchar2).Value = subassest;
               
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
                 objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable Villagewiseallassetslatongs(string hab, string dept, string asset, string subasset, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_service_map";
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_dept", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("p_asset", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("p_sub_asset", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
                //objCmd.Parameters.Add("p_id", OracleDbType.Varchar2).Value = null;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }


        public DataTable AssetFacility(string hab, string dept, string asset, string subasset, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_service_map";
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_dept", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("p_asset", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("p_sub_asset", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }


        public DataTable Villagefencing(string hab, string dept, string asset, string subasset, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_HAB_BOUNDRIES";
                objCmd.Parameters.Add("P_HAB", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable deptassetcount( string hab)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.DEPT_COUNTS_PROC";
                objCmd.Parameters.Add("P_VILLAGE", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = "DEPT SUBASSETS COUNT";
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable RoadFencing(string hab, string dept, string asset, string subasset, string screen, string H)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.TW_ROAD_FENCING";
                objCmd.Parameters.Add("P_VILLAGE", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("P_ID", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SUBASSET", OracleDbType.Varchar2).Value = H;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = "FENCING";
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable Roadservice(string hab, string dept, string asset, string subasset, string screen, string H)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_service_map";
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_dept", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("p_asset", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("p_sub_asset", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = H;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public DataTable Subassetextradetails(string hab, string dept, string asset, string subasset, string screen)
        {
            try
            {
                //con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_CENTRIC_APP.tw_centric_service_map";
                objCmd.Parameters.Add("p_hab", OracleDbType.Varchar2).Value = hab;
                objCmd.Parameters.Add("p_dept", OracleDbType.Varchar2).Value = dept;
                objCmd.Parameters.Add("p_asset", OracleDbType.Varchar2).Value = asset;
                objCmd.Parameters.Add("p_sub_asset", OracleDbType.Varchar2).Value = subasset;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = screen;
                objCmd.Parameters.Add("p_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }


        // procedures for rbstatus

        public dynamic RB_STATUS_SP(addbeneficiary_details obj)
        {
            try
            {

               // dt.Reset(); dt.Clear();
                
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_RB_3LACS_PROC_REP";
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_DIS", OracleDbType.Varchar2).Value = obj.District;
                objCmd.Parameters.Add("P_MANDAL", OracleDbType.Varchar2).Value = obj.Mandal;
                objCmd.Parameters.Add("P_SECVILLA", OracleDbType.Varchar2).Value = obj.Village;
                objCmd.Parameters.Add("P_REMARKS", OracleDbType.Varchar2).Value = obj.REMARKS;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
       

        public dynamic RB_STATUS_INSERT_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_NEW_WEBLAND_LESSTHAN1_PROC";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_RATION_NUMBER", OracleDbType.Varchar2).Value = obj.id;


                objCmd.Parameters.Add("P_UID_NUM", OracleDbType.Varchar2).Value = obj.Aadhaar_NO;
                objCmd.Parameters.Add("P_LAND_TYPE", OracleDbType.Varchar2).Value = obj.TYPE_CODE;
                objCmd.Parameters.Add("P_SURVEY_COMPARTMENT_NO", OracleDbType.Varchar2).Value = obj.Compartment_No;
                objCmd.Parameters.Add("P_KHATHA_PATTA_NO", OracleDbType.Varchar2).Value = obj.ROFR_PATTANO;
                objCmd.Parameters.Add("P_EXTENT", OracleDbType.Varchar2).Value = obj.EXTENT;
                objCmd.Parameters.Add("p_LAND_HOLDING_REMARKS", OracleDbType.Varchar2).Value = obj.REMARKS;

                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        public dynamic TWD_COMMENTS_REPORT_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.WEBLAND_ROFR_DKT_TWD_COMM";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                //objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_DETAIL_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DTLS";
                //objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.WEBLAND_ROFR_DKT_DETAIL";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_MANDALDETAIL_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                //objCmd.CommandText = "WEBLAND_ROFR_DKT_DTLS";
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.WEBLAND_ROFR_DKT_DETAIL"; 
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_MANDAL", OracleDbType.Varchar2).Value = obj.Mandal;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic TWD_COMMENTS_REPORT_NEW_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_TWD_COMM_MOD";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_MANDAL", OracleDbType.Varchar2).Value = obj.Mandal;
                objCmd.Parameters.Add("P_LAND_TYPE", OracleDbType.Varchar2).Value = obj.TYPE_CODE;
                objCmd.Parameters.Add("P_LAND_HOLD_REMARKS", OracleDbType.Varchar2).Value = obj.REMARKS;
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic Land_holdings_Particulars(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_LAND_HOLD_PARTICULARS_REP";
                objCmd.Parameters.Add("P_TYPE", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic TWD_COMMENTS_REPORT_SP1(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.WEBLAND_ROFR_DKT_TWD_COMM";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = "3";
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = null;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic Reports_SP(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_REPORTS";
                objCmd.Parameters.Add("P_FLAG", OracleDbType.Varchar2).Value = obj.Pflag;
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_REPORT_DATE", OracleDbType.Varchar2).Value = obj.ReportDate;
                objCmd.Parameters.Add("P_DESIGNATION", OracleDbType.Varchar2).Value = obj.desiganation;

                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic TWD_COMMENTS_REPORT_SP2(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.WEBLAND_ROFR_DKT_TWD_COMM";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = "4";
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value =null;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_SP3(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_RBVO_RBK_INDENT";
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2).Value = obj.Quantity;
                objCmd.Parameters.Add("P_INDENT_RAISED_BY", OracleDbType.Varchar2).Value = obj.Indentraisedby;
                objCmd.Parameters.Add("P_INDENT_DATE", OracleDbType.Date).Value = obj.IndentDate;

                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2).Value = obj.unitprice;

                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_SP4(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_RBK_STOCK_RECEIVED";
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_QUANTITY ", OracleDbType.Varchar2).Value = obj.Quantity;
                objCmd.Parameters.Add("P_STOCK_RECEIVED_BY", OracleDbType.Varchar2).Value = obj.StockReceivedBy;
                objCmd.Parameters.Add("P_STOCK_RECEIVED_DATE", OracleDbType.Date).Value = obj.StockReceivedDate;
                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID ", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_DAMAGED", OracleDbType.Varchar2).Value = obj.Damage;
                objCmd.Parameters.Add("P_DAMAGED_IMAGE", OracleDbType.Varchar2).Value = obj.imagepath;
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_STOCK_ID", OracleDbType.Varchar2).Value = obj.stockid;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic EOstockack(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_RBK_STOCK_DAMAGE";
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_STOCK_RECEIVED_BY", OracleDbType.Varchar2).Value = obj.StockReceivedBy;
                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID ", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_DAMAGED_IMAGE", OracleDbType.Varchar2).Value = obj.imagepath;
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_STOCK_ID", OracleDbType.Varchar2).Value = obj.stockid;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        public dynamic check_version(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_MOBILE_VERSION_CHECK";
                objCmd.Parameters.Add("P_VERSION", OracleDbType.Varchar2).Value = obj.Version;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_SP5(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_STOCK_PAYMENT_DETAILS";
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_VOUCHER_NO", OracleDbType.Varchar2).Value = obj.VoucharNo;
                objCmd.Parameters.Add("P_AMOUNT", OracleDbType.Varchar2).Value = obj.Amount;
                objCmd.Parameters.Add("P_TOTAL_AMOUNT", OracleDbType.Varchar2).Value = obj.TotalAmount;
                objCmd.Parameters.Add("P_PAYMENT_DATE ", OracleDbType.Date).Value = obj.PaymentDate;
                objCmd.Parameters.Add("P_UPLOADED_BY", OracleDbType.Varchar2).Value = obj.UploadedBy;
                objCmd.Parameters.Add("P_UPLOADED_DATE", OracleDbType.Date).Value = obj.UploadedDate;
                objCmd.Parameters.Add("P_PAYMENT_RECEIPT", OracleDbType.Varchar2).Value = obj.imagepath;
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_STOCK_RECEIVED_DATE", OracleDbType.Date).Value = obj.StockReceivedDate;
                objCmd.Parameters.Add("P_REASON", OracleDbType.Varchar2).Value = obj.Reason;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic datewise_REPORT_SP5(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_DO_STOCK_RECEIVED";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_STOCK_RECEIVED_DATE", OracleDbType.Varchar2).Value = obj.vStockReceivedDate;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        public dynamic payment_status(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_PAYMENT_MODULE";
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_REPORT_DATE", OracleDbType.Varchar2).Value = obj.vStockReceivedDate;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic EOSTOCKdboard(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_DASHBOARD_REPORTS";
                objCmd.Parameters.Add("P_FLAG", OracleDbType.Varchar2).Value = obj.Pflag;
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic TWD_COMMENTS_REPORT_SP6(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_DAILY_STOCK_UPDATE";
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_QUANTITY ", OracleDbType.Varchar2).Value = obj.Quantity;

                objCmd.Parameters.Add("P_UPDATED_BY", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_UPDATED_DATE", OracleDbType.Date).Value = obj.UpdatedDate;

                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID ", OracleDbType.Varchar2).Value = obj.Unitid;


              
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        public dynamic Sales_SP6(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INS_DAILY_STOCK_UPDATE";
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_QUANTITY ", OracleDbType.Varchar2).Value = obj.Quantity;

                objCmd.Parameters.Add("P_UPDATED_BY", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_UPDATED_DATE", OracleDbType.Date).Value = obj.UpdatedDate;


                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        public dynamic Officer_Login_Sp(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_LOGIN_SERVICE";
                objCmd.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2).Value = obj.Password;
                objCmd.Parameters.Add("P_USER_NAME", OracleDbType.Varchar2).Value = obj.UserName;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic DO_APPROVALS_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_DO_STOCK_APPROVE";
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_INSERTED_BY", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_INSERTED_DATE", OracleDbType.Date).Value = obj.UpdatedDate;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_DESIGNATION", OracleDbType.Varchar2).Value = obj.desiganation;
                objCmd.Parameters.Add("P_APPROVAL_STATUS", OracleDbType.Varchar2).Value = obj.approvalstatus;
                objCmd.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2).Value = obj.Quantity;
                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2).Value = obj.unitprice;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;

                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


        public dynamic SO_APPROVALS_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_SO_STOCK_APPROVE";
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_INSERTED_BY", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_INSERTED_DATE", OracleDbType.Date).Value = obj.UpdatedDate;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_DESIGNATION", OracleDbType.Varchar2).Value = obj.desiganation;
                objCmd.Parameters.Add("P_APPROVAL_STATUS", OracleDbType.Varchar2).Value = obj.approvalstatus;
                objCmd.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2).Value = obj.Quantity;


                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2).Value = obj.unitprice;

                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic CEO_APPROVALS_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_CEO_STOCK_APPROVE";
                objCmd.Parameters.Add("P_EVENT", OracleDbType.Varchar2).Value = obj.pevent;
                objCmd.Parameters.Add("P_UNIT_OF_MEASUREMENT", OracleDbType.Varchar2).Value = obj.Unitofmeasurement;
                objCmd.Parameters.Add("P_DISTRICT_ID", OracleDbType.Varchar2).Value = obj.DistrictId;
                objCmd.Parameters.Add("P_DISTRICT_NAME", OracleDbType.Varchar2).Value = obj.DistrictName;
                objCmd.Parameters.Add("P_INSERTED_BY", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_INSERTED_DATE", OracleDbType.Date).Value = obj.UpdatedDate;
                objCmd.Parameters.Add("P_CATEGORY", OracleDbType.Varchar2).Value = obj.Category;
                objCmd.Parameters.Add("P_DESIGNATION", OracleDbType.Varchar2).Value = obj.desiganation;
                objCmd.Parameters.Add("P_APPROVAL_STATUS", OracleDbType.Varchar2).Value = obj.approvalstatus;
                objCmd.Parameters.Add("P_QUANTITY", OracleDbType.Varchar2).Value = obj.Quantity;



                objCmd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Varchar2).Value = obj.categoryid;
                objCmd.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2).Value = obj.Unitid;
                objCmd.Parameters.Add("P_UNIT_PRICE", OracleDbType.Varchar2).Value = obj.unitprice;

                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }



        public dynamic ProfileUpdate_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_PASSWORD_PROFILE";
                objCmd.Parameters.Add("TYPE_ID", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2).Value = obj.Password;
                objCmd.Parameters.Add("P_USER_NAME", OracleDbType.Varchar2).Value = obj.UserName;
                objCmd.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Varchar2).Value = obj.EmployeeId;
                objCmd.Parameters.Add("P_EMPLOYEE_NAME", OracleDbType.Varchar2).Value = obj.EmployeeName;
                objCmd.Parameters.Add("P_MOBILE_NUMBER", OracleDbType.Varchar2).Value = obj.Mobileno;
                objCmd.Parameters.Add("P_EMAIL_ID", OracleDbType.Varchar2).Value = obj.EmailId;
                objCmd.Parameters.Add("P_DEPARTMENT ", OracleDbType.Varchar2).Value = obj.Department;
                objCmd.Parameters.Add("P_ADDRESS", OracleDbType.Varchar2).Value = obj.Address;
                objCmd.Parameters.Add("P_DESIGNATION", OracleDbType.Varchar2).Value = obj.desiganation;
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic Indent_Raise_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "WEBLAND_ROFR_DKT_DYNAIMC_PKG.RBVO_INDENT_RAISED_VALIDATION";
                objCmd.Parameters.Add("P_RBK_ID", OracleDbType.Varchar2).Value = obj.RbkId;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }
        //E://Downloads/f.pdf
        public dynamic FamilyCard_SP(addbeneficiary_details obj)
        {
            try
            {

                // dt.Reset(); dt.Clear();

                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "TW_GB_ROFR_CARD";
                objCmd.Parameters.Add("P_SCREEN", OracleDbType.Varchar2).Value = obj.screen;
                objCmd.Parameters.Add("P_UID", OracleDbType.Varchar2).Value = obj.uid;
                objCmd.Parameters.Add("P_FIN_YEAR", OracleDbType.Varchar2).Value = obj.finyear;
                objCmd.Parameters.Add("P_ITDA", OracleDbType.Varchar2).Value = obj.Itda;
                objCmd.Parameters.Add("P_DID", OracleDbType.Varchar2).Value = obj.did;
                objCmd.Parameters.Add("P_MID", OracleDbType.Varchar2).Value = obj.mid;
                objCmd.Parameters.Add("P_VID", OracleDbType.Varchar2).Value = obj.vid;
                objCmd.Parameters.Add("P_RATION", OracleDbType.Varchar2).Value = obj.ration;
                objCmd.Parameters.Add("P_INPUT_01", OracleDbType.Varchar2).Value = obj.input1;
                objCmd.Parameters.Add("P_INPUT_02", OracleDbType.Varchar2).Value = obj.input2;
                objCmd.Parameters.Add("P_INPUT_03", OracleDbType.Varchar2).Value = obj.input3;
                objCmd.Parameters.Add("P_INPUT_04", OracleDbType.Varchar2).Value = obj.input4;
                objCmd.Parameters.Add("P_INPUT_05", OracleDbType.Varchar2).Value = obj.input5;
                objCmd.Parameters.Add("P_CUR OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        
        public dynamic GetDataAp_Tourism_SP(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "APTDC_TOURIST_PROC";
                objCmd.Parameters.Add("p_type", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("p_Survey_No ", OracleDbType.Varchar2).Value = obj.SurveyNo;
                objCmd.Parameters.Add("p_District", OracleDbType.Varchar2).Value = obj.District;
                objCmd.Parameters.Add("p_Mandal", OracleDbType.Varchar2).Value = obj.Mandal;
                objCmd.Parameters.Add("p_Village", OracleDbType.Varchar2).Value = obj.Village;
                objCmd.Parameters.Add("p_Property_Type", OracleDbType.Varchar2).Value = obj.Propertytype;
                objCmd.Parameters.Add("p_Land_Possession", OracleDbType.Varchar2).Value = obj.Landpossession;
                objCmd.Parameters.Add("p_Field_Type", OracleDbType.Varchar2).Value = obj.Fieldtype;
                objCmd.Parameters.Add("p_Land_Status", OracleDbType.Varchar2).Value = obj.Landstatus;
                objCmd.Parameters.Add("p_Mode_of_Operation", OracleDbType.Varchar2).Value = obj.Modeofoperation;
                objCmd.Parameters.Add("p_Thematic_Classification", OracleDbType.Varchar2).Value = obj.ThematicClassification;
                objCmd.Parameters.Add("p_Usage_Classification", OracleDbType.Varchar2).Value = obj.UsageClassification;
                objCmd.Parameters.Add("p_Functional_Jurisdiction", OracleDbType.Varchar2).Value = obj.FunctionalJurisdiction;
                objCmd.Parameters.Add("p_Distance_From_Nearest_City", OracleDbType.Varchar2).Value = obj.DistanceFromNearestCity;
                objCmd.Parameters.Add("p_Available_Amenities", OracleDbType.Varchar2).Value = obj.AvailableAmenities;
                objCmd.Parameters.Add("p_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.ExtentofLandAcrs;
                objCmd.Parameters.Add("p_Utlized_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.UtlizedExtentofLandAcrs;
                objCmd.Parameters.Add("p_Affected_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.AffectedExtentofLandAcrs;
                objCmd.Parameters.Add("p_Vacant_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.VacantExtentofLandAcrs;
                objCmd.Parameters.Add("p_Surveyor_Name", OracleDbType.Varchar2).Value = obj.SurveyorName;
                objCmd.Parameters.Add("p_Surveyor_Designation", OracleDbType.Varchar2).Value = obj.SurveyorDesignation;
                objCmd.Parameters.Add("p_Surveyor_Mobile_No", OracleDbType.Varchar2).Value = obj.SurveyorMobileNo;
                objCmd.Parameters.Add("p_image_1", OracleDbType.Varchar2).Value = obj.Image1;
                objCmd.Parameters.Add("p_image_2", OracleDbType.Varchar2).Value = obj.Image2;
                objCmd.Parameters.Add("p_image_3", OracleDbType.Varchar2).Value = obj.Image3;
                objCmd.Parameters.Add("p_image_4", OracleDbType.Varchar2).Value = obj.Image4;
                objCmd.Parameters.Add("p_Video_Upload", OracleDbType.Varchar2).Value = obj.VideoUpload;
                objCmd.Parameters.Add("p_Rural_Tourism ", OracleDbType.Varchar2).Value = obj.RuralTourism;
                objCmd.Parameters.Add("p_Heritage_Tourism ", OracleDbType.Varchar2).Value = obj.HeritageTourism;
                objCmd.Parameters.Add("p_Buddhist_Tourism ", OracleDbType.Varchar2).Value = obj.BuddhistTourism;
                objCmd.Parameters.Add("p_Eco_Tourism", OracleDbType.Varchar2).Value = obj.EcoTourism;
                objCmd.Parameters.Add("p_Beach_Water_Base_Tourism ", OracleDbType.Varchar2).Value = obj.BeachWaterBaseTourism;
                objCmd.Parameters.Add("p_Adven_Recreation_Tourism ", OracleDbType.Varchar2).Value = obj.AdvenRecreationTourism;
                objCmd.Parameters.Add("p_Religious_Tourism ", OracleDbType.Varchar2).Value = obj.ReligiousTourism;
                objCmd.Parameters.Add("p_Cuisine_Tourism", OracleDbType.Varchar2).Value = obj.CuisineTourism;
                objCmd.Parameters.Add("p_Wellness_Tourism ", OracleDbType.Varchar2).Value = obj.WellnessTourism;
                objCmd.Parameters.Add("p_MICE_Tourism ", OracleDbType.Varchar2).Value = obj.MICETourism;
                objCmd.Parameters.Add("p_Medical_Tourism ", OracleDbType.Varchar2).Value = obj.MedicalTourism;
                objCmd.Parameters.Add("p_National_Insti_Univesity ", OracleDbType.Varchar2).Value = obj.NationalInstiUnivesity;
                objCmd.Parameters.Add("p_Industry_Trade  ", OracleDbType.Varchar2).Value = obj.IndustryTrade;
                objCmd.Parameters.Add("p_inserted_by", OracleDbType.Varchar2).Value = obj.Insertby;
                objCmd.Parameters.Add("p_updated_by", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }

        public dynamic InsertAp_Tourism_SP(addbeneficiary_details obj)
        {
            try
            {
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "APTDC_TOURIST_PROC";
                objCmd.Parameters.Add("p_type", OracleDbType.Varchar2).Value = obj.Type;
                objCmd.Parameters.Add("p_Survey_No ", OracleDbType.Varchar2).Value = obj.SurveyNo;
                objCmd.Parameters.Add("p_District", OracleDbType.Varchar2).Value = obj.District;
                objCmd.Parameters.Add("p_Mandal", OracleDbType.Varchar2).Value = obj.Mandal;
                objCmd.Parameters.Add("p_Village", OracleDbType.Varchar2).Value = obj.Village;
                objCmd.Parameters.Add("p_Property_Type", OracleDbType.Varchar2).Value = obj.Propertytype;
                objCmd.Parameters.Add("p_Land_Possession", OracleDbType.Varchar2).Value = obj.Landpossession;
                objCmd.Parameters.Add("p_Field_Type", OracleDbType.Varchar2).Value = obj.Fieldtype;
                objCmd.Parameters.Add("p_Land_Status", OracleDbType.Varchar2).Value = obj.Landstatus;
                objCmd.Parameters.Add("p_Mode_of_Operation", OracleDbType.Varchar2).Value = obj.Modeofoperation;
                objCmd.Parameters.Add("p_Thematic_Classification", OracleDbType.Varchar2).Value = obj.ThematicClassification;
                objCmd.Parameters.Add("p_Usage_Classification", OracleDbType.Varchar2).Value = obj.UsageClassification;
                objCmd.Parameters.Add("p_Functional_Jurisdiction", OracleDbType.Varchar2).Value = obj.FunctionalJurisdiction;
                objCmd.Parameters.Add("p_Distance_From_Nearest_City", OracleDbType.Varchar2).Value = obj.DistanceFromNearestCity;
                objCmd.Parameters.Add("p_Available_Amenities", OracleDbType.Varchar2).Value = obj.AvailableAmenities;
                objCmd.Parameters.Add("p_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.ExtentofLandAcrs;
                objCmd.Parameters.Add("p_Utlized_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.UtlizedExtentofLandAcrs;
                objCmd.Parameters.Add("p_Affected_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.AffectedExtentofLandAcrs;
                objCmd.Parameters.Add("p_Vacant_Extent_of_Land_Acrs", OracleDbType.Varchar2).Value = obj.VacantExtentofLandAcrs;
                objCmd.Parameters.Add("p_Surveyor_Name", OracleDbType.Varchar2).Value = obj.SurveyorName;
                objCmd.Parameters.Add("p_Surveyor_Designation", OracleDbType.Varchar2).Value = obj.SurveyorDesignation;
                objCmd.Parameters.Add("p_Surveyor_Mobile_No", OracleDbType.Varchar2).Value = obj.SurveyorMobileNo;
                objCmd.Parameters.Add("p_image_1", OracleDbType.Varchar2).Value = obj.Image1;
                objCmd.Parameters.Add("p_image_2", OracleDbType.Varchar2).Value = obj.Image2;
                objCmd.Parameters.Add("p_image_3", OracleDbType.Varchar2).Value = obj.Image3;
                objCmd.Parameters.Add("p_image_4", OracleDbType.Varchar2).Value = obj.Image4;
                objCmd.Parameters.Add("p_Video_Upload", OracleDbType.Varchar2).Value = obj.VideoUpload;
                objCmd.Parameters.Add("p_Rural_Tourism ", OracleDbType.Varchar2).Value = obj.RuralTourism;
                objCmd.Parameters.Add("p_Heritage_Tourism ", OracleDbType.Varchar2).Value = obj.HeritageTourism;
                objCmd.Parameters.Add("p_Buddhist_Tourism ", OracleDbType.Varchar2).Value = obj.BuddhistTourism;
                objCmd.Parameters.Add("p_Eco_Tourism", OracleDbType.Varchar2).Value = obj.EcoTourism;
                objCmd.Parameters.Add("p_Beach_Water_Base_Tourism ", OracleDbType.Varchar2).Value = obj.BeachWaterBaseTourism;
                objCmd.Parameters.Add("p_Adven_Recreation_Tourism ", OracleDbType.Varchar2).Value = obj.AdvenRecreationTourism;
                objCmd.Parameters.Add("p_Religious_Tourism ", OracleDbType.Varchar2).Value = obj.ReligiousTourism;
                objCmd.Parameters.Add("p_Cuisine_Tourism", OracleDbType.Varchar2).Value = obj.CuisineTourism;
                objCmd.Parameters.Add("p_Wellness_Tourism ", OracleDbType.Varchar2).Value = obj.WellnessTourism;
                objCmd.Parameters.Add("p_MICE_Tourism ", OracleDbType.Varchar2).Value = obj.MICETourism;
                objCmd.Parameters.Add("p_Medical_Tourism ", OracleDbType.Varchar2).Value = obj.MedicalTourism;
                objCmd.Parameters.Add("p_National_Insti_Univesity ", OracleDbType.Varchar2).Value = obj.NationalInstiUnivesity;
                objCmd.Parameters.Add("p_Industry_Trade  ", OracleDbType.Varchar2).Value = obj.IndustryTrade;
                objCmd.Parameters.Add("p_inserted_by", OracleDbType.Varchar2).Value = obj.Insertby;
                objCmd.Parameters.Add("p_updated_by", OracleDbType.Varchar2).Value = obj.UpdatedBy;
                objCmd.Parameters.Add("P_CUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                objCmd.Dispose();
            }
        }


       
    }
}