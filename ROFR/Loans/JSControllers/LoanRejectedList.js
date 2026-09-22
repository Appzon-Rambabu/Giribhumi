(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoanRejectedList", ["$scope", "network_service", LoanReJEntry_CTRL]);

    app.directive('numbersOnly', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^0-9]/g, '');
                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return digits;//ParseInt(digits,10);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    });

    app.directive('alphaNumbers', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^a-zA-Z0-9]/g, '');
                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return digits;//ParseInt(digits,10);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    });

    app.directive('alphaBets', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^a-zA-Z ]/g, '');
                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return digits;//ParseInt(digits,10);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    });

    app.directive('onlyDigits', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function (scope, element, attr, ctrl) {
                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^0-9.-]/g, '');
                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }
                        return digits;//ParseInt(digits,10);
                    }
                    return undefined;
                }
                ctrl.$parsers.push(inputValue);
            }
        };
    });

    function LoanReJEntry_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loan Reject List";
        scope.preloader = false;
        scope.TYPE_OF_CHARGE = "Crop Hypothecation";

        scope.Isreleaseshow = true;
        scope.CurrBen = {};

        LoadAllData();

        scope.GetDetails = function () {
            scope.CurrBen = {};
            if (GetDetValidations()) {
                scope.PattadarTable = [];

                if (scope.ROFR_PATTADAAR_ACCOUNT_NO)
                    LoadCommonData("30"); // Load Former Data
            }
        }

        scope.GetPattadarDetails = function (landid) {
            if (landid) {
                scope.CurrBen = $(scope.PattadarTable).filter(function (i, n) { return n.LAND_ID === landid });
                LoadCommonData("31", landid); // Fill the Pattadar Details
            }
        }

        scope.Modify = function () {
            if (MainValidations()) {
                scope.preloader = true;
                var req = { PTYPE: "32", LAND_ID: scope.CurrBen[0].LAND_ID, BORROWER_NAME: scope.BORROWER_NAME, FATHER_HUSBAND_NAME: scope.FATHER_HUSBAND_NAME, TYPE_OF_CHARGE: scope.TYPE_OF_CHARGE, LOAN_AMOUNT: scope.LOAN_AMOUNT, CROP_SEASON: scope.CROP_SEASON, NAME_OF_THE_CROP: scope.NAME_OF_THE_CROP, SANCTION_DATE: scope.SANCTION_DATE, INTEREST_RATE: scope.INTEREST_RATE, SUBSIDY_AMOUNT: scope.SUBSIDY_AMOUNT, DATE_OF_DISBURSEMENT: scope.DATE_OF_DISBURSEMENT, TYPE_OF_FACILYTY: scope.TYPE_OF_FACILYTY, DUE_DATE: scope.DUE_DATE, REPAYMENT_SCHEDULE: scope.REPAYMENT_SCHEDULE, NO_OF_INSTALLMENTS: scope.NO_OF_INSTALLMENTS, SUBSIDY_PROVIDING_AGENCY: scope.SUBSIDY_PROVIDING_AGENCY, SUBSIDY_AGENCY_NAME: scope.SUBSIDY_AGENCY_NAME, RATIONCARD_NO: scope.RATIONCARD_NO, TERM_LOAN_PURPOSE: scope.TERM_LOAN_PURPOSE, CHARGE_CREATION_APP_REJ_REMARKS: scope.CHARGE_CREATION_APP_REJ_REMARKS, LOGIN_USER: scope.LOGIN_USER };

                ns.post(baseurl + "SaveCreationData", req, function (value) {
                    scope.preloader = false;
                    if (value.data.Status == 100) {
                        swal("info", "Loan Rejected Data Modified Sucessfully", "info");
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
            LoadCommonData("29"); // Load Rejected Accounts Data
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
            else if (ftype == "29")
                req = { PTYPE: 29, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "30")
                req = { PTYPE: 30, LOAN_ACCOUNTNO: scope.ROFR_PATTADAAR_ACCOUNT_NO, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "31")
                req = { PTYPE: 31, LAND_ID: landid, LOGIN_USER: scope.LOGIN_USER }

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

                    else if (ftype == "30") {
                        if (value.data.Data.length > 0)
                            scope.PattadarTable = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "29") {
                            scope.LoanAccountsDD = value.data.Data;
                    }

                    else if (ftype == "31") {
                        if (value.data.Data.length > 0) {
                            var currdata = value.data.Data[0];
                            scope.LOAN_ACCOUNTNO = currdata.LOAN_ACCOUNTNO;
                            scope.BORROWER_NAME = currdata.BORROWER_NAME;
                            scope.FATHER_HUSBAND_NAME = currdata.FATHER_HUSBAND_NAME;
                            scope.ROFR_PATTANO = currdata.ROFR_PATTANO;
                            scope.VILLAGE = currdata.VILLAGE;
                            scope.BRANCH_NAME = currdata.BRANCH_NAME;
                            scope.TYPE_OF_CHARGE = currdata.TYPE_OF_CHARGE;
                            scope.ROFR_PATTADAAR = currdata.ROFR_PATTADAAR;
                            scope.FATHER_NAME = currdata.FATHER_NAME;
                            scope.COMPARTMENT_NO = currdata.COMPARTMENT_NO;
                            scope.OCCUPANT_NAME = currdata.OCCUPANT_NAME;
                            scope.OCCUPANT_FATHER_NAME = currdata.OCCUPANT_FATHER_NAME;
                            scope.EXTENTPLOTAREA = currdata.EXTENTPLOTAREA; 
                            scope.LOAN_AMOUNT = currdata.LOAN_AMOUNT;
                            scope.CROP_SEASON = currdata.CROP_SEASON;
                            scope.NAME_OF_THE_CROP = currdata.NAME_OF_THE_CROP;
                            if (currdata.SANCTION_DATE)
                                scope.SANCTION_DATE = new Date(currdata.SANCTION_DATE);
                            scope.INTEREST_RATE = currdata.INTEREST_RATE;
                            scope.SUBSIDY_AMOUNT = currdata.SUBSIDY_AMOUNT;
                            if (currdata.DATE_OF_DISBURSEMENT)
                                scope.DATE_OF_DISBURSEMENT = new Date(currdata.DATE_OF_DISBURSEMENT);
                            scope.PATTADAR_AADHAR_NO = currdata.PATTADAR_AADHAR_NO;
                            scope.OCCUPANT_AADHAR_NO = currdata.OCCUPANT_AADHAR_NO;
                            scope.TYPE_OF_FACILYTY = currdata.TYPE_OF_FACILYTY;
                            scope.REPAYMENT_SCHEDULE = currdata.REPAYMENT_SCHEDULE;
                            scope.NO_OF_INSTALLMENTS = currdata.NO_OF_INSTALLMENTS;
                            scope.SUBSIDY_PROVIDING_AGENCY = currdata.SUBSIDY_PROVIDING_AGENCY;
                            scope.RATIONCARD_NO = currdata.RATIONCARD_NO;
                            scope.TERM_LOAN_PURPOSE = currdata.TERM_LOAN_PURPOSE;
                            scope.CHARGE_CREATION_APP_REJ_REMARKS = currdata.CHARGE_CREATION_APP_REJ_REMARKS;
                            if (currdata.DUE_DATE)
                                scope.DUE_DATE = new Date(currdata.DUE_DATE);

                            scope.SUBSIDY_AGENCY_NAME = currdata.SUBSIDY_AGENCY_NAME;

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
            if (!scope.ROFR_PATTADAAR_ACCOUNT_NO) {
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
            else if (!scope.BORROWER_NAME) {
                swal("info", "Please Enter Borrower Name", "info")
                return false;
            }
            else if (!scope.FATHER_HUSBAND_NAME) {
                swal("info", "Please Enter Borrower Father/husband Name", "info")
                return false;
            }
            else if (!scope.TYPE_OF_CHARGE) {
                swal("info", "Please Enter Type of Loan", "info")
                return false;
            }
            else if (!scope.LOAN_AMOUNT) {
                swal("info", "Please Enter Loan Amount", "info")
                return false;
            }
            else if (!scope.CROP_SEASON) {
                swal("info", "Please select crop season", "info")
                return false;
            }
            else if (!scope.NAME_OF_THE_CROP) {
                swal("info", "Please select name of the crop ", "info")
                return false;
            }
            else if (!scope.SANCTION_DATE) {
                swal("info", "Please enter sanction date", "info")
                return false;
            }
            else if (!scope.INTEREST_RATE) {
                swal("info", "Please enter interest rate", "info")
                return false;
            }
            //else if (!scope.SUBSIDY_AMOUNT) {
            //    swal("info", "Please enter subsidy amount", "info")
            //    return false;
            //}
            else if (!scope.DATE_OF_DISBURSEMENT) {
                swal("info", "Please enter date of disbursement", "info")
                return false;
            }
            else if (!scope.TYPE_OF_FACILYTY) {
                swal("info", "Please select type of facility", "info")
                return false;
            }
            else if (scope.TYPE_OF_FACILYTY == "Demand Loan/Cash Credit" && !scope.DUE_DATE) {
                swal("info", "Please enter due date", "info")
                return false;
            }
            else if (scope.TYPE_OF_FACILYTY == "Term Loan" && !scope.REPAYMENT_SCHEDULE) {
                swal("info", "Please enter repayment schedule", "info")
                return false;
            }
            else if (scope.TYPE_OF_FACILYTY == "Term Loan" && !scope.NO_OF_INSTALLMENTS) {
                swal("info", "Please enter number of installments", "info")
                return false;
            }
            else if (!scope.SUBSIDY_PROVIDING_AGENCY) {
                swal("info", "Please select subsidy providing agency", "info")
                return false;
            }
            else if (scope.SUBSIDY_PROVIDING_AGENCY == "Other" && !scope.SUBSIDY_AGENCY_NAME) {
                swal("info", "Please select subsidy providing agency name", "info")
                return false;
            }
            else if (!scope.RATIONCARD_NO) {
                swal("info", "Please enter ration card number", "info")
                return false;
            }
            else if (scope.TYPE_OF_FACILYTY == "Term Loan" && !scope.TERM_LOAN_PURPOSE) {
                swal("info", "Please select term loan purpose", "info")
                return false;
            }
            else if (!scope.CHARGE_CREATION_APP_REJ_REMARKS) {
                swal("info", "Please enter Remarks", "info")
                return false;
            }
            return true;
        }

    }
})();