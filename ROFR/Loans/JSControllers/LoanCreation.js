(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoanCreation", ["$scope", "network_service", LoanCrea_CTRL]);

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

    function LoanCrea_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loan Information Creation";
        scope.preloader = false;
        scope.CurrType = "1";
        scope.IsOngoing = true;
        scope.CurrBen = {};
        scope.TYPE_OF_CHARGE = "Crop Hypothecation";

        LoadAllData();

        scope.DistrictChange = function () {
            scope.DivisionDD = [];
            scope.RangeDD = [];
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.CompartmentDD = [];

            if (scope.SelDistrict)
                LoadCommonData("2"); // Load Forest Division Data
        }

        scope.DivisionChange = function () {
            scope.RangeDD = [];
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.CompartmentDD = [];

            if (scope.SelDistrict && scope.SelDivision)
                LoadCommonData("3"); // Load Forest Range Data
        }

        scope.RangeChange = function () {
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.CompartmentDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange)
                LoadCommonData("4"); // Load Forest Beet Data
        }

        scope.BeetChange = function () {
            scope.BlockDD = [];
            scope.CompartmentDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange && scope.SelBeet)
                LoadCommonData("5"); // Load Block Data
        }

        scope.BlockChange = function () {
            scope.CompartmentDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange && scope.SelBeet && scope.SelBlock)
                LoadCommonData("6"); // Load Compartment Data
        }

        scope.GetDetails = function () {
            if (GetDetValidations()) {
                scope.PattadarTable = [];
                scope.OnGoingTable = [];
                scope.HistoryTable = [];
                scope.CurrBen = [];
                LoadCommonData("7"); // Load Former Data
            }
        }

        scope.GetPattadarDetails = function (landid) {
            scope.OnGoingTable = [];
            scope.HistoryTable = [];

            if (landid && scope.SelDistrict) {
                scope.CurrBen = $(scope.PattadarTable).filter(function (i, n) { return n.ID === landid });
                if (scope.CurrBen.length > 0) {
                    LoadCommonData("8", landid); // Fill the Pattadar Data
                    LoadCommonData("9", landid); // Load Ongoing Loans Data
                    LoadCommonData("10", landid); // Load History Loans Data
                }
            }
        }

        scope.ChangeHistory = function () {
            //scope.OnGoingTable = [];
            //scope.HistoryTable = [];

            //if (scope.CurrBen.length > 0) {
            //    if (scope.CurrType == "1")
            //        LoadCommonData("9", scope.CurrBen[0].ID); // Load Ongoing Loans Data
            //    else
            //        LoadCommonData("10", scope.CurrBen[0].ID); // Load History Loans Data
            //}
        }

        scope.SaveData = function () {
            if (GetDetValidations()) {
                if (MainValidations() && scope.CurrBen.length > 0) {
                    scope.preloader = true;

                    scope.SANCTION_DATE = scope.SANCTION_DATE ? moment(scope.SANCTION_DATE).format('YYYY-MM-DD') : "";
                    scope.DATE_OF_DISBURSEMENT = scope.DATE_OF_DISBURSEMENT ? moment(scope.DATE_OF_DISBURSEMENT).format('YYYY-MM-DD') : "";
                    scope.DUE_DATE = scope.DUE_DATE ? moment(scope.DUE_DATE).format('YYYY-MM-DD') : "";

                    var req = { PTYPE: 12, BENFICIARY_ID: scope.CurrBen[0].BENFICIARY_ID, LAND_ID: scope.CurrBen[0].ID, TYPE_OF_CHARGE: scope.TYPE_OF_CHARGE, LOAN_ACCOUNTNO: scope.LOAN_ACCOUNTNO, SAVING_BANKACCOUNTNO: scope.SAVING_BANKACCOUNTNO, BORROWER_NAME: scope.BORROWER_NAME, FATHER_HUSBAND_NAME: scope.FATHER_HUSBAND_NAME, BORROWER_AADHAAR_NO: scope.BORROWER_AADHAAR_NO, CROP_SEASON: scope.CROP_SEASON, NAME_OF_THE_CROP: scope.NAME_OF_THE_CROP, SANCTION_DATE: scope.SANCTION_DATE, LOAN_AMOUNT: scope.LOAN_AMMOUNT, SUBSIDY_AMOUNT: scope.SUBSIDY_AMMOUNT, INTEREST_RATE: scope.INTEREST_RATE, TYPE_OF_FACILYTY: scope.TYPE_OF_FACILYTY, SUBSIDY_PROVIDING_AGENCY: scope.SUBSIDY_PROVIDING_AGENCY, DATE_OF_DISBURSEMENT: scope.DATE_OF_DISBURSEMENT, RATIONCARD_NO: scope.RATIONCARD_NO, DUE_DATE: scope.DUE_DATE, REPAYMENT_SCHEDULE: scope.REPAYMENT_SCHEDULE, NO_OF_INSTALLMENTS: scope.NO_OF_INSTALLMENTS, SUBSIDY_AGENCY_NAME: scope.SUBSIDY_AGENCY_NAME, TERM_LOAN_PURPOSE: scope.TERM_LOAN_PURPOSE, LOGIN_USER: scope.LOGIN_USER }
                    ns.post(baseurl + "SaveCreationData", req, function (value) {
                        scope.preloader = false;
                        if (value.data.Status == 100) {
                            swal("info", "Loan Information Creation Sucessfully", "info");
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
        }

        function LoadAllData() {
            LoadCommonData("1"); // Load Districts Data
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
            if (ftype == "1")
                req = { PTYPE: 1 }
            else if (ftype == "2")
                req = { PTYPE: 2, DISTRICT: scope.SelDistrict }
            else if (ftype == "3")
                req = { PTYPE: 3, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision }
            else if (ftype == "4")
                req = { PTYPE: 4, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange }
            else if (ftype == "5")
                req = { PTYPE: 5, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet }
            else if (ftype == "6")
                req = { PTYPE: 6, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock }
            else if (ftype == "7")
                req = { PTYPE: 7, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, COMPARTMENT_NO: scope.SelCompartment }
            else if (ftype == "8")
                req = { PTYPE: 8, LAND_ID: landid, DISTRICT: scope.SelDistrict }
            else if (ftype == "9")
                req = { PTYPE: 9, LAND_ID: landid, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "10")
                req = { PTYPE: 10, LAND_ID: landid, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "11")
                req = { PTYPE: 11, DROPDOWN_NAME: landid }

            ns.post(baseurl + "LoanChargeCommonData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {

                    if (ftype == "1") {
                        if (value.data.Data.length > 0)
                            scope.DistrictsDD = value.data.Data;
                        else
                            swal("Info", "No Districts Data Found", "info");
                    }

                    else if (ftype == "2") {
                        if (value.data.Data.length > 0)
                            scope.DivisionDD = value.data.Data;
                        else
                            swal("Info", "No Forest Divisions Data Found", "info");
                    }

                    else if (ftype == "3") {
                        if (value.data.Data.length > 0)
                            scope.RangeDD = value.data.Data;
                        else
                            swal("Info", "No Forest Range Data Found", "info");
                    }

                    else if (ftype == "4") {
                        if (value.data.Data.length > 0)
                            scope.BeetDD = value.data.Data;

                        else
                            swal("Info", "No Forest Beet Data Found", "info");
                    }

                    else if (ftype == "5") {
                        if (value.data.Data.length > 0)
                            scope.BlockDD = value.data.Data;
                        else
                            swal("Info", "No Block Data Found", "info");
                    }

                    else if (ftype == "6") {
                        if (value.data.Data.length > 0)
                            scope.CompartmentDD = value.data.Data;
                        else
                            swal("Info", "No Compartment Data Found", "info");
                    }

                    else if (ftype == "7") {
                        if (value.data.Data.length > 0)
                            scope.PattadarTable = value.data.Data;
                        else
                            swal("Info", "No Compartment Data Found", "info");
                    }

                    else if (ftype == "8") {
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
                        }
                        else
                            swal("Info", "No Pattadhar Data Found", "info");
                    }

                    else if (ftype == "9") {
                        scope.OnGoingTable = value.data.Data;
                    }

                    else if (ftype == "10") {
                        scope.HistoryTable = value.data.Data;
                    }


                    else if (ftype == "11") {
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
            if (!scope.SelDistrict) {
                swal("Info", "Please Select District ", "info");
                return false;
            }
            else if (!scope.SelDivision) {
                swal("Info", "Please Select Division ", "info");
                return false;
            }
            else if (!scope.SelRange) {
                swal("Info", "Please Select Forest Range ", "info");
                return false;
            }
            else if (!scope.SelBeet) {
                swal("Info", "Please Select Forest Beet ", "info");
                return false;
            }
            else if (!scope.SelBlock) {
                swal("Info", "Please Select Block ", "info");
                return false;
            }
            else if (!scope.SelCompartment) {
                swal("Info", "Please Select Compartment No ", "info");
                return false;
            }

            return true;
        }

        function MainValidations() {
            if (!scope.TYPE_OF_CHARGE) {
                swal("Info", "Please Select Type of Loan", "info");
                return false;
            }
            else if (!scope.LOAN_ACCOUNTNO) {
                swal("Info", "Please Enter Loan Account No ", "info");
                return false;
            }
            else if (!scope.BORROWER_NAME) {
                swal("Info", "Please Enter Borrowe Name ", "info");
                return false;
            }
            else if (!scope.FATHER_HUSBAND_NAME) {
                swal("Info", "Please Enter Father/Husband's Name ", "info");
                return false;
            }
            else if (!scope.CROP_SEASON) {
                swal("Info", "Please Select Crop Season ", "info");
                return false;
            }
            else if (!scope.NAME_OF_THE_CROP) {
                swal("Info", "Please Select Name Of Crop ", "info");
                return false;
            }
            else if (!scope.SANCTION_DATE) {
                swal("Info", "Please Select Sanction Date ", "info");
                return false;
            }
            else if (!scope.LOAN_AMMOUNT) {
                swal("Info", "Please Enter Loan Amount ", "info");
                return false;
            }
            else if (!scope.INTEREST_RATE) {
                swal("Info", "Please Enter Interest Rate ", "info");
                return false;
            }
            else if (!scope.TYPE_OF_FACILYTY) {
                swal("Info", "Please Select Type Of Facility ", "info");
                return false;
            }
            else if (!scope.DATE_OF_DISBURSEMENT) {
                swal("Info", "Please Select Date of Disbursement ", "info");
                return false;
            }
            else if (scope.DATE_OF_DISBURSEMENT < scope.SANCTION_DATE) {
                swal("Info", "Date of Disbursement Should be Greater than Sanction Date", "info");
                return false;
            }
            else if (scope.TYPE_OF_FACILYTY == "Term Loan" && !scope.TERM_LOAN_PURPOSE) {
                swal("Info", "Please Select Term Loan Purpose", "info");
                return false;
            }

            else if (scope.DUE_DATE && scope.DUE_DATE <= scope.DATE_OF_DISBURSEMENT) {
                swal("Info", "Due Date Should be Greater than Disbursement Date", "info");
                return false;
            }

            return true;
        }


    }
})();