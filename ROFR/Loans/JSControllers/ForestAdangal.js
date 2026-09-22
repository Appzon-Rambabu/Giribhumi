(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("ForestAdangal", ["$scope", "network_service", FOREST_CTRL]);

    function FOREST_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Branch Master Entry";
        scope.preloader = false;
        scope.Radio_sel = "1";
        scope.IsComShow = false;
        scope.AdnagalShow = false;

        LoadAllData();

        scope.ChangeOption = function () {
            scope.IsComShow = false;
            scope.AdnagalShow = false;
            scope.UserTable = [];
            scope.AdandalTable = [];

            scope.SelDistrict = "";
            scope.DistrictChange();
        }

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

            if (scope.SelDistrict && scope.SelDivision && scope.SelRange && scope.SelBeet && scope.SelBlock) {
                if (scope.Radio_sel == "1")
                    LoadCommonData("6"); // Load Compartment Data
                else if (scope.Radio_sel == "3")
                    LoadCommonData("7"); // Load Pattadar Name Data
            }

        }

        scope.GetDetails = function () {
            if (GetDetValidations()) {
                scope.IsComShow = false;
                scope.AdnagalShow = false;

                scope.UserTable = [];
                scope.AdandalTable = [];

                if (scope.Radio_sel == "1")
                    LoadCommonData("10");// Load Adangal Data
                else if (scope.Radio_sel == "2")
                    LoadCommonData("9");// Load User Data Data
                else if (scope.Radio_sel == "3")
                    LoadCommonData("8");// Load User Data Data
            }
        }

        scope.GetAdangalDetails = function (comaprtment) {
            scope.CurrCompartment = comaprtment;
            LoadCommonData("11");// Load Adangal Data
        }

        function LoadAllData() {
            LoadCommonData("1"); // Load Districts Data
        }

        function LoadCommonData(type) {

            scope.preloader = true;
            scope.IsComShow = false;
            scope.AdnagalShow = false;
            scope.UserTable = [];
            scope.AdandalTable = [];

            var req = {};
            var ftype = type;
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
                req = { PTYPE: 7, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock }
            else if (ftype == "8")
                req = { PTYPE: 8, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, ROFR_PATTADAAR: scope.Pattadar_Name }
            else if (ftype == "9")
                req = { PTYPE: 9, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, AADHAAR_NO: scope.Aadhar_No }
            else if (ftype == "10")
                req = { PTYPE: 10, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, COMPARTMENT_NO: scope.SelCompartment }
            else if (ftype == "11")
                req = { PTYPE: 10, DISTRICT: scope.SelDistrict, FOREST_DIVISION: scope.SelDivision, FOREST_RANGE: scope.SelRange, FOREST_BEAT: scope.SelBeet, FOREST_BLOCK: scope.SelBlock, COMPARTMENT_NO: scope.CurrCompartment }

            ns.post(baseurl + "LoanAdangalData", req, function (value) {
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
                            scope.PattadarNameDD = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "8" || ftype == "9") {
                        if (value.data.Data.length > 0) {
                            scope.IsComShow = true;
                            scope.UserTable = value.data.Data;
                        }
                        else
                            swal("Info", "No User Data Found", "info");
                    }

                    else if (ftype == "10" || ftype == "11") {
                        if (value.data.Data.length > 0) {
                            scope.AdnagalShow = true;
                            scope.AdandalTable = value.data.Data;
                        }
                        else
                            swal("Info", "No Adangal Data Found", "info");
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
            else if (scope.Radio_sel == "1" && !scope.SelCompartment) {
                swal("Info", "Please Select Compartment No ", "info");
                return false;
            }
            else if (scope.Radio_sel == "2" && !scope.Aadhar_No) {
                swal("Info", "Please Enter Aadhaar No ", "info");
                return false;
            }
            else if (scope.Radio_sel == "3" && !scope.Pattadar_Name) {
                swal("Info", "Please Select Pattadar Name ", "info");
                return false;
            }

            return true;
        }
    }
})();