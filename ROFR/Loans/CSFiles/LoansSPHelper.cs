using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace ROFR.Loans.CSFiles
{
    public class LoansSPHelper : CommonSPHel
    {
        SqlCommand cmd;

        #region Login Module & Admin Module
        public DataTable GetCommonData_SP(UserLoginCls ObjLogin)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_LOAN_BANK_LOGINS";
                cmd.Parameters.Add("@PTYPE", SqlDbType.Int).Value = ObjLogin.PTYPE;
                cmd.Parameters.Add("@LOGIN_USER ", SqlDbType.NVarChar).Value = ObjLogin.LOGIN_USER;
                cmd.Parameters.Add("@DISTRICT_CODE", SqlDbType.NVarChar).Value = ObjLogin.DISTRICT_CODE;
                cmd.Parameters.Add("@DISTRICT ", SqlDbType.NVarChar).Value = ObjLogin.DISTRICT;
                cmd.Parameters.Add("@MANDAL", SqlDbType.NVarChar).Value = ObjLogin.MANDAL;
                cmd.Parameters.Add("@BANKNAME", SqlDbType.NVarChar).Value = ObjLogin.BANKNAME;
                cmd.Parameters.Add("@BRANCH_CODE", SqlDbType.NVarChar).Value = ObjLogin.BRANCH_CODE;
                cmd.Parameters.Add("@BRANCH_NAME", SqlDbType.NVarChar).Value = ObjLogin.BRANCH_NAME;
                cmd.Parameters.Add("@BRANCH_ADDRESS", SqlDbType.NVarChar).Value = ObjLogin.BRANCH_ADDRESS;
                cmd.Parameters.Add("@USER_ID", SqlDbType.NVarChar).Value = ObjLogin.USER_ID;
                cmd.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = ObjLogin.USER_NAME;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = ObjLogin.DESIGNATION;
                cmd.Parameters.Add("@MOBILE_NO", SqlDbType.NVarChar).Value = ObjLogin.MOBILE_NO;
                cmd.Parameters.Add("@ROLE", SqlDbType.NVarChar).Value = ObjLogin.ROLE;
                cmd.Parameters.Add("@TOKEN_NUMBER", SqlDbType.NVarChar).Value = ObjLogin.TOKEN_NUMBER;
                cmd.Parameters.Add("@EXPIRY_DATE", SqlDbType.NVarChar).Value = ObjLogin.EXPIRY_DATE;
                cmd.Parameters.Add("@OLD_PASSWORD", SqlDbType.NVarChar).Value = ObjLogin.OLD_PASSWORD;
                cmd.Parameters.Add("@NEW_PASSWORD", SqlDbType.NVarChar).Value = ObjLogin.NEW_PASSWORD;
                cmd.Parameters.Add("@ACTIVE_STATUS", SqlDbType.NVarChar).Value = ObjLogin.ACTIVE_STATUS;
                cmd.Parameters.Add("@REFER_ID", SqlDbType.NVarChar).Value = ObjLogin.REFER_ID;
                cmd.Parameters.Add("@CAPTHA_VALUE", SqlDbType.NVarChar).Value = ObjLogin.CAPTHA_VALUE;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = ObjLogin.IP;

                DataTable dtLogin = GetDataAdapter(cmd);
                if (dtLogin != null)
                {
                    return dtLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("LoginExceptionLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, " Login Errors :" + ex.Message.ToString()));
                throw ex;
            }
        }

        #endregion

        #region Adangal Module

        public DataTable LoanAdangalData_Helper_SP(AdangalCls Obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_LOAN_ADANGAL";
                cmd.Parameters.Add("@PTYPE", SqlDbType.Int).Value = Obj.PTYPE;
                cmd.Parameters.Add("@DISTRICT", SqlDbType.NVarChar).Value = Obj.DISTRICT;
                cmd.Parameters.Add("@FOREST_DIVISION ", SqlDbType.NVarChar).Value = Obj.FOREST_DIVISION;
                cmd.Parameters.Add("@FOREST_RANGE ", SqlDbType.NVarChar).Value = Obj.FOREST_RANGE;
                cmd.Parameters.Add("@FOREST_BEAT ", SqlDbType.NVarChar).Value = Obj.FOREST_BEAT;
                cmd.Parameters.Add("@FOREST_BLOCK ", SqlDbType.NVarChar).Value = Obj.FOREST_BLOCK;
                cmd.Parameters.Add("@COMPARTMENT_NO ", SqlDbType.NVarChar).Value = Obj.COMPARTMENT_NO;
                cmd.Parameters.Add("@ROFR_PATTADAAR ", SqlDbType.NVarChar).Value = Obj.ROFR_PATTADAAR;
                cmd.Parameters.Add("@AADHAAR_NO ", SqlDbType.NVarChar).Value = Obj.AADHAAR_NO;
                cmd.Parameters.Add("@ITDA_CODE ", SqlDbType.NVarChar).Value = Obj.ITDA_CODE;
                cmd.Parameters.Add("@DISTRICT_CODE ", SqlDbType.NVarChar).Value = Obj.DISTRICT_CODE;
                cmd.Parameters.Add("@MANDAL_CODE ", SqlDbType.NVarChar).Value = Obj.MANDAL_CODE;
                cmd.Parameters.Add("@VILLAGE_NAME ", SqlDbType.NVarChar).Value = Obj.VILLAGE_NAME;

                DataTable dtLogin = GetDataAdapter(cmd);
                if (dtLogin != null)
                {
                    return dtLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("AdnaglaException");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, "Adnagal Exceptions :" + ex.Message.ToString()));
                throw ex;
            }
        }

        #endregion

        #region Loans Module

        public DataTable GetLoansCommonData_SP(CommonCls ObjLogin)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Proc_Loan_Borrower_Details";
                cmd.Parameters.Add("@PTYPE", SqlDbType.Int).Value = ObjLogin.PTYPE;
                cmd.Parameters.Add("@LOGIN_USER ", SqlDbType.NVarChar).Value = ObjLogin.LOGIN_USER;
                cmd.Parameters.Add("@DISTRICT ", SqlDbType.NVarChar).Value = ObjLogin.DISTRICT;
                cmd.Parameters.Add("@FOREST_DIVISION", SqlDbType.NVarChar).Value = ObjLogin.FOREST_DIVISION;
                cmd.Parameters.Add("@FOREST_RANGE", SqlDbType.NVarChar).Value = ObjLogin.FOREST_RANGE;
                cmd.Parameters.Add("@FOREST_BEAT", SqlDbType.NVarChar).Value = ObjLogin.FOREST_BEAT;
                cmd.Parameters.Add("@FOREST_BLOCK", SqlDbType.NVarChar).Value = ObjLogin.FOREST_BLOCK;
                cmd.Parameters.Add("@COMPARTMENT_NO", SqlDbType.NVarChar).Value = ObjLogin.COMPARTMENT_NO;
                cmd.Parameters.Add("@BENFICIARY_ID", SqlDbType.NVarChar).Value = ObjLogin.BENFICIARY_ID;
                cmd.Parameters.Add("@LAND_ID", SqlDbType.NVarChar).Value = ObjLogin.LAND_ID;
                cmd.Parameters.Add("@TYPE_OF_CHARGE", SqlDbType.NVarChar).Value = ObjLogin.TYPE_OF_CHARGE;
                cmd.Parameters.Add("@LOAN_ACCOUNTNO", SqlDbType.NVarChar).Value = ObjLogin.LOAN_ACCOUNTNO;
                cmd.Parameters.Add("@SAVING_BANKACCOUNTNO", SqlDbType.NVarChar).Value = ObjLogin.SAVING_BANKACCOUNTNO;
                cmd.Parameters.Add("@BORROWER_NAME", SqlDbType.NVarChar).Value = ObjLogin.BORROWER_NAME;
                cmd.Parameters.Add("@FATHER_HUSBAND_NAME", SqlDbType.NVarChar).Value = ObjLogin.FATHER_HUSBAND_NAME;
                cmd.Parameters.Add("@BORROWER_AADHAAR_NO", SqlDbType.NVarChar).Value = ObjLogin.BORROWER_AADHAAR_NO;
                cmd.Parameters.Add("@CROP_SEASON", SqlDbType.NVarChar).Value = ObjLogin.CROP_SEASON;
                cmd.Parameters.Add("@NAME_OF_THE_CROP", SqlDbType.NVarChar).Value = ObjLogin.NAME_OF_THE_CROP;
                cmd.Parameters.Add("@SANCTION_DATE", SqlDbType.NVarChar).Value = ObjLogin.SANCTION_DATE;
                cmd.Parameters.Add("@LOAN_AMOUNT", SqlDbType.NVarChar).Value = ObjLogin.LOAN_AMOUNT;
                cmd.Parameters.Add("@SUBSIDY_AMOUNT", SqlDbType.NVarChar).Value = ObjLogin.SUBSIDY_AMOUNT;
                cmd.Parameters.Add("@INTEREST_RATE", SqlDbType.NVarChar).Value = ObjLogin.INTEREST_RATE;
                cmd.Parameters.Add("@TYPE_OF_FACILYTY", SqlDbType.NVarChar).Value = ObjLogin.TYPE_OF_FACILYTY;
                cmd.Parameters.Add("@SUBSIDY_PROVIDING_AGENCY", SqlDbType.NVarChar).Value = ObjLogin.SUBSIDY_PROVIDING_AGENCY;
                cmd.Parameters.Add("@DATE_OF_DISBURSEMENT", SqlDbType.NVarChar).Value = ObjLogin.DATE_OF_DISBURSEMENT;
                cmd.Parameters.Add("@RATIONCARD_NO", SqlDbType.NVarChar).Value = ObjLogin.RATIONCARD_NO;
                cmd.Parameters.Add("@DUE_DATE", SqlDbType.NVarChar).Value = ObjLogin.DUE_DATE;
                cmd.Parameters.Add("@REPAYMENT_SCHEDULE", SqlDbType.NVarChar).Value = ObjLogin.REPAYMENT_SCHEDULE;
                cmd.Parameters.Add("@NO_OF_INSTALLMENTS", SqlDbType.NVarChar).Value = ObjLogin.NO_OF_INSTALLMENTS;
                cmd.Parameters.Add("@SUBSIDY_AGENCY_NAME", SqlDbType.NVarChar).Value = ObjLogin.SUBSIDY_AGENCY_NAME;
                cmd.Parameters.Add("@CHARGE_CREATION_APP_REJ_REMARKS", SqlDbType.NVarChar).Value = ObjLogin.CHARGE_CREATION_APP_REJ_REMARKS;
                cmd.Parameters.Add("@CHARGE_CREATION_APP_STATUS", SqlDbType.NVarChar).Value = ObjLogin.CHARGE_CREATION_APP_STATUS;
                cmd.Parameters.Add("@CHARGE_RELEASE_REMARKS", SqlDbType.NVarChar).Value = ObjLogin.CHARGE_RELEASE_REMARKS;
                cmd.Parameters.Add("@TERM_LOAN_PURPOSE", SqlDbType.NVarChar).Value = ObjLogin.TERM_LOAN_PURPOSE;
                cmd.Parameters.Add("@CHARGE_RELEASED_STATUS", SqlDbType.NVarChar).Value = ObjLogin.CHARGE_RELEASED_STATUS;
                cmd.Parameters.Add("@CHARGE_RELEASED_APP_APP_REMARKS", SqlDbType.NVarChar).Value = ObjLogin.CHARGE_RELEASED_APP_APP_REMARKS;
                cmd.Parameters.Add("@DROPDOWN_NAME", SqlDbType.NVarChar).Value = ObjLogin.DROPDOWN_NAME;
                cmd.Parameters.Add("@FROM_DATE", SqlDbType.NVarChar).Value = ObjLogin.FROM_DATE;
                cmd.Parameters.Add("@TO_DATE", SqlDbType.NVarChar).Value = ObjLogin.TO_DATE;

                DataTable dtLogin = GetDataAdapter(cmd);
                if (dtLogin != null)
                {
                    return dtLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("LoadDataExceptionLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, "Error From Load Data:" + ex.Message.ToString()));
                throw ex;
            }
        }

        #endregion

        #region Reports Module

        public DataTable GetReportsCommonData_SP(ReportsCls ObjLogin)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_LOAN_REPORTS";
                cmd.Parameters.Add("@PTYPE", SqlDbType.Int).Value = ObjLogin.PTYPE;
                cmd.Parameters.Add("@LOGIN_USER ", SqlDbType.NVarChar).Value = ObjLogin.LOGIN_USER;
                cmd.Parameters.Add("@FROM_DATE", SqlDbType.NVarChar).Value = ObjLogin.FROM_DATE;
                cmd.Parameters.Add("@TO_DATE", SqlDbType.NVarChar).Value = ObjLogin.TO_DATE;
                cmd.Parameters.Add("@DISTRICT ", SqlDbType.NVarChar).Value = ObjLogin.DISTRICT;
                cmd.Parameters.Add("@FOREST_DIVISION ", SqlDbType.NVarChar).Value = ObjLogin.FOREST_DIVISION;
                cmd.Parameters.Add("@FOREST_RANGE ", SqlDbType.NVarChar).Value = ObjLogin.FOREST_RANGE;
                cmd.Parameters.Add("@FOREST_BEAT ", SqlDbType.NVarChar).Value = ObjLogin.FOREST_BEAT;
                cmd.Parameters.Add("@FOREST_BLOCK ", SqlDbType.NVarChar).Value = ObjLogin.FOREST_BLOCK;
                cmd.Parameters.Add("@COMPARTMENT_NO ", SqlDbType.NVarChar).Value = ObjLogin.COMPARTMENT_NO;
                cmd.Parameters.Add("@LAND_ID ", SqlDbType.NVarChar).Value = ObjLogin.LAND_ID;
                cmd.Parameters.Add("@KHATHA_NO ", SqlDbType.NVarChar).Value = ObjLogin.KHATHA_NO;
                cmd.Parameters.Add("@DROPDOWN_NAME ", SqlDbType.NVarChar).Value = ObjLogin.DROPDOWN_NAME;
                cmd.Parameters.Add("@LOAN_ACCOUNTNO ", SqlDbType.NVarChar).Value = ObjLogin.LOAN_ACCOUNTNO;

                DataTable dtLogin = GetDataAdapter(cmd);
                if (dtLogin != null)
                {
                    return dtLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("ReportsDataExceptionLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, "Error From Load Data:" + ex.Message.ToString()));
                throw ex;
            }
        }

        public DataTable GetBranchData_SP(ReportsCls ObjLogin)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_LOAN_REPORTS1";
                cmd.Parameters.Add("@PTYPE", SqlDbType.Int).Value = ObjLogin.PTYPE;
                cmd.Parameters.Add("@BANKNAME ", SqlDbType.NVarChar).Value = ObjLogin.BANKNAME;
                cmd.Parameters.Add("@BRANCH_NAME", SqlDbType.NVarChar).Value = ObjLogin.BRANCH_NAME;
                DataTable dtLogin = GetDataAdapter(cmd);
                if (dtLogin != null)
                {
                    return dtLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string mappath = HttpContext.Current.Server.MapPath("ReportsDataExceptionLogs");
                Task WriteTask = Task.Factory.StartNew(() => new Logdatafile().Write_ReportLog_Exception(mappath, "Error From Load Data:" + ex.Message.ToString()));
                throw ex;
            }
        }

        #endregion

    }
}