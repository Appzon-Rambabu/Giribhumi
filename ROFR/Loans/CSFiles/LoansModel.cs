using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ROFR.Loans.CSFiles
{
    public class LoansModel
    {

    }

    public class ResponseModel
    {
        public int Status { get; set; }
        public string Reason { get; set; }
        public DataTable DataList { get; set; }
    }

    public class UserLoginCls
    {
        public string PTYPE { get; set; }
        public string LOGIN_USER { get; set; }
        public string DISTRICT_CODE { get; set; }
        public string DISTRICT { get; set; }
        public string MANDAL { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_ADDRESS { get; set; }
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string DESIGNATION { get; set; }
        public string MOBILE_NO { get; set; }
        public string ROLE { get; set; }
        public string TOKEN_NUMBER { get; set; }
        public string EXPIRY_DATE { get; set; }
        public string OLD_PASSWORD { get; set; }
        public string NEW_PASSWORD { get; set; }
        public string ACTIVE_STATUS { get; set; }
        public string REFER_ID { get; set; }
        public string CAPTHA_VALUE { get; set; }
        public string IP { get; set; }
    }

    public class captchgens
    {
        public string idval { get; set; }
        public string imgurl { get; set; }
        public string code { get; set; }
        public string Reason { get; set; }

    }

    public class AdangalCls
    {
        public string PTYPE { get; set; }
        public string DISTRICT { get; set; }
        public string FOREST_DIVISION { get; set; }
        public string FOREST_RANGE { get; set; }
        public string FOREST_BEAT { get; set; }
        public string FOREST_BLOCK { get; set; }
        public string COMPARTMENT_NO { get; set; }
        public string ROFR_PATTADAAR { get; set; }
        public string AADHAAR_NO { get; set; }
        public string ITDA_CODE { get; set; }
        public string DISTRICT_CODE { get; set; }
        public string MANDAL_CODE { get; set; }
        public string VILLAGE_NAME { get; set; }
    }

    public class CommonCls
    {
        public string PTYPE { get; set; }
        public string LOGIN_USER { get; set; }
        public string DISTRICT { get; set; }
        public string FOREST_DIVISION { get; set; }
        public string FOREST_RANGE { get; set; }
        public string FOREST_BEAT { get; set; }
        public string FOREST_BLOCK { get; set; }
        public string COMPARTMENT_NO { get; set; }
        public string BENFICIARY_ID { get; set; }
        public string LAND_ID { get; set; }
        public string TYPE_OF_CHARGE { get; set; }
        public string LOAN_ACCOUNTNO { get; set; }
        public string SAVING_BANKACCOUNTNO { get; set; }
        public string BORROWER_NAME { get; set; }
        public string FATHER_HUSBAND_NAME { get; set; }
        public string BORROWER_AADHAAR_NO { get; set; }
        public string CROP_SEASON { get; set; }
        public string NAME_OF_THE_CROP { get; set; }
        public string SANCTION_DATE { get; set; }
        public string LOAN_AMOUNT { get; set; }
        public string SUBSIDY_AMOUNT { get; set; }
        public string INTEREST_RATE { get; set; }
        public string TYPE_OF_FACILYTY { get; set; }
        public string SUBSIDY_PROVIDING_AGENCY { get; set; }
        public string DATE_OF_DISBURSEMENT { get; set; }
        public string RATIONCARD_NO { get; set; }
        public string DUE_DATE { get; set; }
        public string REPAYMENT_SCHEDULE { get; set; }
        public string NO_OF_INSTALLMENTS { get; set; }
        public string SUBSIDY_AGENCY_NAME { get; set; }
        public string CHARGE_CREATED_BY { get; set; }
        public string CHARGE_CREATION_APP_REJ_REMARKS { get; set; }
        public string CHARGE_CREATION_APP_STATUS { get; set; }
        public string CHARGE_CREATION_APP_ENTRYBY { get; set; }
        public string CHARGE_RELEASE_REMARKS { get; set; }
        public string CHARGE_RELEASE_BY { get; set; }
        public string TERM_LOAN_PURPOSE { get; set; }
        public string CHARGE_RELEASED_STATUS { get; set; }
        public string CHARGE_RELEASED_APP_APP_REMARKS { get; set; }
        public string CHARGE_RELEASE_APPROVED_BY { get; set; }
        public string DROPDOWN_NAME { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }

    }

    public class ReportsCls
    {
        public string PTYPE { get; set; }
        public string LOGIN_USER { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
        public string DISTRICT { get; set; }
        public string FOREST_DIVISION { get; set; }
        public string FOREST_RANGE { get; set; }
        public string FOREST_BEAT { get; set; }
        public string FOREST_BLOCK { get; set; }
        public string COMPARTMENT_NO { get; set; }
        public string LAND_ID { get; set; }
        public string KHATHA_NO { get; set; }
        public string DROPDOWN_NAME { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCH_NAME { get; set; }
        public String LOAN_ACCOUNTNO { get; set; }
    }
}