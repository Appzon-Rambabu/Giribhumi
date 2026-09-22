(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoansExport", ["$scope", "network_service", LoansPrintRep]);

    function LoansPrintRep(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loans Print ";
        scope.preloader = false;
        scope.TYPE_OF_CHARGE = "Crop Hypothecation";

        scope.Isreleaseshow = true;
        scope.CurrBen = {};

        LoadAllData();

        scope.GetDetails = function () {
            if (GetDetValidations()) {
                scope.PattadarTable = [];

                if (scope.ROFR_PATTADAAR_ACCOUNT_NO)
                    LoadCommonData("18"); // Load Former Data
            }
        }

        scope.GetPattadarDetails = function (landid) {
            if (landid) {
                scope.CurrBen = $(scope.PattadarTable).filter(function (i, n) { return n.LAND_ID === landid });
                LoadCommonData("19", landid); // Fill the Pattadar Details
            }
        }



        function LoadAllData() {
            LoadCommonData("17"); // Load Accounts Data
            LoadCommonData("16", "TYPE OF CHARGE"); // Fill TYPE OF CHARGE Drop down
            LoadCommonData("16", "CROP SEASON"); // Fill CROP SEASON Drop down
            LoadCommonData("16", "NAME OF THE CROP"); // Fill NAME OF THE CROP Drop down
            LoadCommonData("16", "TYPE OF FACILITTY"); // Fill TYPE OF FACILITTY Drop down
            LoadCommonData("16", "REPAYMENT SCHEDULE"); // Fill REPAYMENT SCHEDULE Drop down
            LoadCommonData("16", "SUBSIDY PROVIDING AGENCY"); // Fill TYPE OF CHARGE Drop down
            LoadCommonData("16", "TERM LOAN PURPOSE"); // Fill TYPE OF CHARGE Drop down
        }

        function LoadCommonData(type, landid) {
            var req = {};
            var ftype = type;
            scope.preloader = true;
            if (ftype == "16")
                req = { PTYPE: 16, DROPDOWN_NAME: landid }
            else if (ftype == "17")
                req = { PTYPE: 17, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "18")
                req = { PTYPE: 18, LOAN_ACCOUNTNO: scope.ROFR_PATTADAAR_ACCOUNT_NO }

            else if (ftype == "19")
                req = { PTYPE: 19, LAND_ID: landid }

            ns.post(baseurl + "LoadReportsData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {
                    if (ftype == "16") {
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
                    if (ftype == "17") {
                        if (value.data.Data.length > 0)
                            scope.LoanAccountsDD = value.data.Data;
                    }
                    else if (ftype == "18") {
                        if (value.data.Data.length > 0)
                            scope.PattadarTable = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "19") {
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

                            scope.APPROVED_BY = currdata.APPROVED_BY;
                            scope.APPROVED_ON = currdata.APPROVED_ON;
                            scope.APPROVED_REMARKS = currdata.APPROVED_REMARKS;

                            
                            //Print Div Fill
                            scope.PRINT_ROFR_PATTADAAR = currdata.ROFR_PATTADAAR;
                            scope.PRINT_FATHER_NAME = currdata.FATHER_NAME;
                            scope.PRINT_AADHAAR_NO = currdata.AADHAAR_NO;
                            scope.PRINT_ROFR_PATTANO = currdata.ROFR_PATTANO;
                            scope.PRINT_OCCUPANT_NAME = currdata.OCCUPANT_NAME;
                            scope.PRINT_OCCUPANT_FATHER_NAME = currdata.OCCUPANT_FATHER_NAME;
                            scope.PRINT_EXTENTPLOTAREA = currdata.EXTENTPLOTAREA;
                            scope.PRINT_CROP_EXTENT = currdata.CROP_EXTENT;
                            scope.PRINT_VILLAGE = currdata.VILLAGE;
                            scope.PRINT_BRANCH = currdata.BRANCH;
                                 
                            scope.PRINT_TYPE_OF_CHARGE = currdata.TYPE_OF_CHARGE;
                            scope.PRINT_LOAN_ACCOUNTNO = currdata.LOAN_ACCOUNTNO;
                            scope.PRINT_SAVING_BANKACCOUNTNO = currdata.SAVING_BANKACCOUNTNO;
                            scope.PRINT_BORROWER_NAME = currdata.BORROWER_NAME;
                            scope.PRINT_FATHER_HUSBAND_NAME = currdata.FATHER_HUSBAND_NAME;
                            scope.PRINT_BORROWER_AADHAAR_NO = currdata.BORROWER_AADHAAR_NO;
                            scope.PRINT_CROP_SEASON = currdata.CROP_SEASON;
                            scope.PRINT_NAME_OF_THE_CROP = currdata.NAME_OF_THE_CROP;
                            scope.PRINT_SANCTION_DATE = currdata.SANCTION_DATE;
                            scope.PRINT_LOAN_AMOUNT = currdata.LOAN_AMOUNT;
                            scope.PRINT_SUBSIDY_AMOUNT = currdata.SUBSIDY_AMOUNT;
                            scope.PRINT_INTEREST_RATE = currdata.INTEREST_RATE;
                            scope.PRINT_TYPE_OF_FACILYTY = currdata.TYPE_OF_FACILYTY;
                            scope.PRINT_DUE_DATE = currdata.DUE_DATE;
                            scope.PRINT_SUBSIDY_PROVIDING_AGENCY = currdata.SUBSIDY_PROVIDING_AGENCY;
                            scope.PRINT_DATE_OF_DISBURSEMENT = currdata.DATE_OF_DISBURSEMENT
                            scope.PRINT_REPAYMENT_SCHEDULE = currdata.REPAYMENT_SCHEDULE;
                            scope.PRINT_NO_OF_INSTALLMENTS = currdata.NO_OF_INSTALLMENTS;
                            scope.PRINT_SUBSIDY_AGENCY_NAME = currdata.SUBSIDY_AGENCY_NAME;
                            scope.PRINT_TERM_LOAN_PURPOSE = currdata.TERM_LOAN_PURPOSE;
                            scope.PRINT_RATIONCARD_NO = currdata.RATIONCARD_NO;
                                  
                            scope.PRINT_APPROVED_BY = currdata.APPROVED_BY;
                            scope.PRINT_APPROVED_ON = currdata.APPROVED_ON;
                            scope.PRINT_APPROVED_REMARKS = currdata.APPROVED_REMARKS;
                        }
                        else
                            swal("Info", "No Pattadhar Details Found", "info");
                    }


                }
                else if (value.data.Status == "428") {
                    sessionStorage.clear();
                    swal("info", "Session Expired !!!", "info");
                    location.href = '../Home/LoginPage';;
                    return;
                }
                else
                    swal("Info", value.data.Reason, "info");

            });
        }

        function GetDetValidations() {
            if (!scope.ROFR_PATTADAAR_ACCOUNT_NO) {
                swal("Info", "Please Select Account Number ", "info");
                return false;
            }

            return true;
        }

        scope.Exportexcel = function () {
            $("#ExportLoans").table2excel({
                name: "Worksheet Name",
                exclude: ".image",
                filename: "Loan Aprovals"
            });
        }

        scope.Print = function () {
            var divprint = document.getElementById("printdiv").innerHTML;

            var popupWinindow = window.open('', 'Print-Window');
            popupWinindow.document.open();
            popupWinindow.document.write('<html><head><link href="/Loans/assets/css/bootstrap.css" rel="stylesheet" type="text/css"><link rel="stylesheet" type="text/css" href="assets/css/printcss.css" /></head><body onload="window.print()" style="background-color:#ffffff">' + divprint + '</html>');
            popupWinindow.document.close();
        }
    }
})();