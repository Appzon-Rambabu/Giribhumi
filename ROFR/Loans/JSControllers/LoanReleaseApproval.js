(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoanReleaseApproval", ["$scope", "network_service", LoanRelAppr_CTRL]);

    function LoanRelAppr_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loan Release Approval";
        scope.preloader = false;

        scope.Isreleaseshow = true;
        scope.CurrBen = {};
        scope.TYPE_OF_CHARGE = "Crop Hypothecation";

        LoadAllData();

        scope.GetDetails = function () {
            if (GetDetValidations()) {
                scope.PattadarTable = [];

                if (scope.ROFR_PATTADAAR_ACCOUNT_NO)
                    LoadCommonData("19"); // Load Former Data
                else if (scope.SEL_FROM_DATE && scope.SEL_TO_DATE)
                    LoadCommonData("26"); // Load Former Data
            }
        }

        scope.GetPattadarDetails = function (landid) {
            if (landid) {
                scope.CurrBen = $(scope.PattadarTable).filter(function (i, n) { return n.LAND_ID === landid });
                LoadCommonData("20", landid); // Fill the Pattadar Details
            }
        }

        scope.SaveData = function () {
            if (MainValidations()) {
                scope.preloader = true;
                var req = { PTYPE: 21, LAND_ID: scope.CurrBen[0].LAND_ID, CHARGE_RELEASED_STATUS: "RELEASED", CHARGE_RELEASED_APP_APP_REMARKS: scope.CHARGE_RELEASED_APP_APP_REMARKS, LOGIN_USER: scope.LOGIN_USER }
                ns.post(baseurl + "SaveCreationData", req, function (value) {
                    scope.preloader = false;
                    if (value.data.Status == 100) {
                        swal("info", "Loan Release Approval Saved Sucessfully", "info");
                        window.location.reload();
                    }
                    else if (value.data.Status == "428") {
                        sessionStorage.clear();
                        swal("info", "Session Expired !!!", "info");
                        location.href = '../Loans/Login.aspx';;
                        return;
                    }
                    else
                        swal("Info", value.data.Reason, "info");
                });
            }
        }

        function LoadAllData() {
            LoadCommonData("25"); // Load Releae Approval Accounts Data
            LoadCommonData("11", "TYPE OF CHARGE"); // Fill TYPE OF CHARGE Drop down
            LoadCommonData("11", "CROP SEASON"); // Fill CROP SEASON Drop down
            LoadCommonData("11", "NAME OF THE CROP"); // Fill NAME OF THE CROP Drop down
            LoadCommonData("11", "TYPE OF FACILITTY"); // Fill TYPE OF FACILITTY Drop down
            LoadCommonData("11", "REPAYMENT SCHEDULE"); // Fill REPAYMENT SCHEDULE Drop down
            LoadCommonData("11", "SUBSIDY PROVIDING AGENCY"); // Fill TYPE OF CHARGE Drop down
            LoadCommonData("11", "TERM LOAN PURPOSE"); // Fill TYPE OF CHARGE Drop down
        }

        function LoadCommonData(type, landid) {
            var req = {};
            var ftype = type;
            scope.preloader = true;
            if (ftype == "11")
                req = { PTYPE: 11, DROPDOWN_NAME: landid }
            else if (ftype == "19")
                req = { PTYPE: 19, LOAN_ACCOUNTNO: scope.ROFR_PATTADAAR_ACCOUNT_NO }
            else if (ftype == "20")
                req = { PTYPE: 20, LAND_ID: landid }
            else if (ftype == "25")
                req = { PTYPE: 25, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "26")
                req = { PTYPE: 26, FROM_DATE: moment(scope.SEL_FROM_DATE).format('YYYY/MM/DD'), TO_DATE: moment(scope.SEL_TO_DATE).format('YYYY/MM/DD'), LOGIN_USER: scope.LOGIN_USER }

            ns.post(baseurl + "LoanChargeCommonData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {

                    if (ftype == "11") {
                        if (value.data.Data.length > 0) {
                            if (landid == "TYPE OF CHARGE")
                                scope.LoansDD = value.data.Data;
                            else if (landid == "CROP SEASON")
                                scope.SeasonsDD = value.data.Data;
                            else if (landid == "NAME OF THE CROP")
                                scope.CropsDD = value.data.Data;
                            else if (landid == "TYPE OF FACILITTY")
                                scope.FacilityDD = value.data.Data;
                            else if (landid == "REPAYMENT SCHEDULE")
                                scope.SchedulesDD = value.data.Data;
                            else if (landid == "SUBSIDY PROVIDING AGENCY")
                                scope.AgencyDD = value.data.Data;
                            else if (landid == "TERM LOAN PURPOSE")
                                scope.PurposeDD = value.data.Data;
                        }

                    }

                    else if (ftype == "19" || ftype == "26") {
                        if (value.data.Data.length > 0)
                            scope.PattadarTable = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "25") {
                        if (value.data.Data.length > 0)
                            scope.LoanAccountsDD = value.data.Data;
                    }

                    else if (ftype == "20") {
                        if (value.data.Data.length > 0) {
                            var currdata = value.data.Data[0];
                            scope.ROFR_PATTADAAR = currdata.ROFR_PATTADAAR;
                            scope.FATHER_NAME = currdata.FATHER_NAME;
                            scope.AADHAAR_NO = currdata.AADHAAR_NO;
                            scope.ROFR_PATTANO = currdata.ROFR_PATTANO;
                            scope.OCCUPANT_NAME = currdata.OCCUPANT_NAME;
                            scope.OCCUPANT_FATHER_NAME = currdata.OCCUPANT_FATHER_NAME;
                            scope.EXTENTPLOTAREA = currdata.EXTENTPLOTAREA;
                            scope.CROP_EXTENT = currdata.CROP_EXTENT;
                            scope.VILLAGE = currdata.VILLAGE;
                            scope.BRANCH = currdata.BRANCH;

                            scope.TYPE_OF_CHARGE = currdata.TYPE_OF_CHARGE;
                            scope.LOAN_ACCOUNTNO = currdata.LOAN_ACCOUNTNO;
                            scope.SAVING_BANKACCOUNTNO = currdata.SAVING_BANKACCOUNTNO;
                            scope.BORROWER_NAME = currdata.BORROWER_NAME;
                            scope.FATHER_HUSBAND_NAME = currdata.FATHER_HUSBAND_NAME;
                            scope.BORROWER_AADHAAR_NO = currdata.BORROWER_AADHAAR_NO;
                            scope.CROP_SEASON = currdata.CROP_SEASON;
                            scope.NAME_OF_THE_CROP = currdata.NAME_OF_THE_CROP;
                            if (currdata.SANCTION_DATE)
                                scope.SANCTION_DATE = new Date(currdata.SANCTION_DATE);
                            scope.LOAN_AMOUNT = currdata.LOAN_AMOUNT;
                            scope.SUBSIDY_AMOUNT = currdata.SUBSIDY_AMOUNT;
                            scope.INTEREST_RATE = currdata.INTEREST_RATE;
                            scope.TYPE_OF_FACILYTY = currdata.TYPE_OF_FACILYTY;
                            if (currdata.DUE_DATE)
                                scope.DUE_DATE = new Date(currdata.DUE_DATE);
                            scope.SUBSIDY_PROVIDING_AGENCY = currdata.SUBSIDY_PROVIDING_AGENCY;
                            if (currdata.DATE_OF_DISBURSEMENT)
                                scope.DATE_OF_DISBURSEMENT = new Date(currdata.DATE_OF_DISBURSEMENT);
                            scope.REPAYMENT_SCHEDULE = currdata.REPAYMENT_SCHEDULE;
                            scope.NO_OF_INSTALLMENTS = currdata.NO_OF_INSTALLMENTS;
                            scope.SUBSIDY_AGENCY_NAME = currdata.SUBSIDY_AGENCY_NAME;
                            scope.TERM_LOAN_PURPOSE = currdata.TERM_LOAN_PURPOSE;
                            scope.RATIONCARD_NO = currdata.RATIONCARD_NO;

                            scope.CHARGE_RELEASE_BY = currdata.CHARGE_RELEASE_BY;
                            scope.CHARGE_RELEASE_ON = currdata.CHARGE_RELEASE_ON;
                            scope.CHARGE_RELEASE_REMARKS = currdata.CHARGE_RELEASE_REMARKS;

                        }
                        else
                            swal("Info", "No Pattadhar Details Found", "info");
                    }


                }
                else if (value.data.Status == "428") {
                    sessionStorage.clear();
                    swal("info", "Session Expired !!!", "info");
                    location.href = '../Loans/Login.aspx';;
                    return;
                }
                else
                    swal("Info", value.data.Reason, "info");

            });
        }

        function GetDetValidations() {
            if (scope.SEL_FROM_DATE && !scope.SEL_TO_DATE) {
                swal("Info", "Please Select TO Date ", "info");
                return false;
            }
            else if (scope.SEL_FROM_DATE && scope.SEL_TO_DATE) {
                return true;
            }
            else if (!scope.ROFR_PATTADAAR_ACCOUNT_NO) {
                swal("Info", "Please Select Account Number ", "info");
                return false;
            }

            return true;
        }

        function MainValidations() {
            if (!scope.CurrBen.length) {
                swal("Info", "Please Select Pattadar", "info");
                return false;
            }
            else if (!scope.CHARGE_RELEASE_REMARKS) {
                swal("Info", "Please Enter Release Remarks ", "info");
                return false;
            }
            return true;
        }

    }
})();