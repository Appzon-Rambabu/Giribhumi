(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("SearchByKathaNo", ["$scope", "network_service", SearchKatha_CTRL]);

    function SearchKatha_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loans Search By Katha No";
        scope.preloader = false;
        scope.CurrBen = {};

        LoadAllData();

        scope.DistrictChange = function () {
            scope.DivisionDD = [];
            scope.RangeDD = [];
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.KathasDD = [];

            if (scope.SelDistrict)
                LoadCommonData("6"); // Load Forest Division Data
        }

        scope.DivisionChange = function () {
            scope.RangeDD = [];
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.KathasDD = [];

            if (scope.SelDistrict && scope.SelDivision)
                LoadCommonData("7"); // Load Forest Range Data
        }

        scope.RangeChange = function () {
            scope.BeetDD = [];
            scope.BlockDD = [];
            scope.KathasDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange)
                LoadCommonData("8"); // Load Forest Beet Data
        }

        scope.BeetChange = function () {
            scope.BlockDD = [];
            scope.KathasDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange && scope.SelBeet)
                LoadCommonData("9"); // Load Block Data
        }

        scope.BlockChange = function () {
            scope.KathasDD = [];

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange && scope.SelBeet && scope.SelBlock)
                LoadCommonData("13"); // Load Katha Data
        }

        scope.GetDetails = function () {
            scope.CurrBen = [];
            if (GetDetValidations()) {
                scope.PattadarTable = [];
                LoadCommonData("14"); // Load Former Data
            }
        }

        scope.GetPattadarDetails = function (landid) {
            if (landid) {
                scope.CurrBen = $(scope.PattadarTable).filter(function (i, n) { return n.LAND_ID === landid });
                if (scope.CurrBen.length > 0) {
                    LoadCommonData("15", landid); // Fill the Pattadar Data
                }
            }
        }

        function LoadAllData() {
            LoadCommonData("5"); // Load Districts Data
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
            if (ftype == "5")
                req = { PTYPE: 5 }
            else if (ftype == "6")
                req = { PTYPE: 6, DISTRICT: scope.SelDistrict }
            else if (ftype == "7")
                req = { PTYPE: 7, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision }
            else if (ftype == "8")
                req = { PTYPE: 8, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange }
            else if (ftype == "9")
                req = { PTYPE: 9, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet }
            else if (ftype == "13")
                req = { PTYPE: 13, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock }
            else if (ftype == "14")
                req = { PTYPE: 14, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, KHATHA_NO: scope.SelKatha, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "15")
                req = { PTYPE: 15, LAND_ID: landid }
            else if (ftype == "16")
                req = { PTYPE: 16, DROPDOWN_NAME: landid }

            ns.post(baseurl + "LoadReportsData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {

                    if (ftype == "5") {
                        if (value.data.Data.length > 0)
                            scope.DistrictsDD = value.data.Data;
                        else
                            swal("Info", "No Districts Data Found", "info");
                    }

                    else if (ftype == "6") {
                        if (value.data.Data.length > 0)
                            scope.DivisionDD = value.data.Data;
                        else
                            swal("Info", "No Forest Divisions Data Found", "info");
                    }

                    else if (ftype == "7") {
                        if (value.data.Data.length > 0)
                            scope.RangeDD = value.data.Data;
                        else
                            swal("Info", "No Forest Range Data Found", "info");
                    }

                    else if (ftype == "8") {
                        if (value.data.Data.length > 0)
                            scope.BeetDD = value.data.Data;

                        else
                            swal("Info", "No Forest Beet Data Found", "info");
                    }

                    else if (ftype == "9") {
                        if (value.data.Data.length > 0)
                            scope.BlockDD = value.data.Data;
                        else
                            swal("Info", "No Block Data Found", "info");
                    }

                    else if (ftype == "13") {
                        if (value.data.Data.length > 0)
                            scope.KathasDD = value.data.Data;
                        else
                            swal("Info", "No Katha Data Found", "info");
                    }

                    else if (ftype == "14") {
                        if (value.data.Data.length > 0)
                            scope.PattadarTable = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "15") {
                        if (value.data.Data.length > 0) {
                            var currdata = value.data.Data[0];
                            scope.ROFR_PATTADAAR = currdata.ROFR_PATTADAAR;
                            scope.FATHER_NAME = currdata.FATHER_NAME;
                            scope.AADHAAR_NO = currdata.AADHAAR_NO;
                            scope.KHATHA_NO = currdata.KHATHA_NO;
                            scope.OCCUPANT_NAME = currdata.OCCUPANT_NAME;
                            scope.OCCUPANT_FATHER_NAME = currdata.OCCUPANT_FATHER_NAME;
                            scope.EXTENTPLOTAREA = currdata.EXTENTPLOTAREA;
                            scope.CROP_EXTENT = currdata.CROP_EXTENT;
                            scope.SURVEY_NO = currdata.SURVEY_NO;
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
                        }
                        else
                            swal("Info", "No Pattadhar Data Found", "info");
                    }

                    else if (ftype == "16") {
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
            else if (!scope.SelKatha) {
                swal("Info", "Please Select Katha No ", "info");
                return false;
            }

            return true;
        }

    }

})();