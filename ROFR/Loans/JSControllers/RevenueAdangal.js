(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("RevenueAdangal", ["$scope", "network_service", REV_CTRL]);

    function REV_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Revenue Adangal";
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

            scope.SelITDA = "";
            scope.ITDAChange();
        }

        scope.ITDAChange = function () {
            scope.DistrictsDD = [];
            scope.MandalsDD = [];
            scope.VillageDD = [];
            scope.CompartmentDD = [];
            scope.PattadarNameDD = [];

            if (scope.SelITDA)
                LoadCommonData("12"); // Load ITDA District Data
        }

        scope.DistrictChange = function () {
            scope.MandalsDD = [];
            scope.VillageDD = [];
            scope.CompartmentDD = [];
            scope.PattadarNameDD = [];

            if (scope.SelITDA && scope.SelDistrict)
                LoadCommonData("13"); // Load Madal Data
        }

        scope.MandalChange = function () {
            scope.VillageDD = [];
            scope.CompartmentDD = [];
            scope.PattadarNameDD = [];

            if (scope.SelITDA && scope.SelDistrict && scope.SelMandal)
                LoadCommonData("14"); // Load Village Data
        }

        scope.VillageChange = function () {
            scope.CompartmentDD = [];

            if (scope.SelITDA && scope.SelDistrict && scope.SelMandal && scope.SelVillage) {
                if (scope.Radio_sel == "1")
                    LoadCommonData("16"); // Load Compartment Data
                else if (scope.Radio_sel == "3")
                    LoadCommonData("15"); // Load Pattadar Name Data
            }
        }

        scope.GetDetails = function () {
            if (GetDetValidations()) {
                scope.IsComShow = false;
                scope.AdnagalShow = false;

                scope.UserTable = [];
                scope.AdandalTable = [];

                if (scope.Radio_sel == "1")
                    LoadCommonData("19");// Load Adangal Data
                else if (scope.Radio_sel == "2")
                    LoadCommonData("18");// Load User Data Data
                else if (scope.Radio_sel == "3")
                    LoadCommonData("17");// Load User Data Data
            }
        }

        scope.GetAdangalDetails = function (comaprtment) {
            scope.CurrCompartment = comaprtment;
            LoadCommonData("20");// Load Adangal Data
        }

        function LoadAllData() {
            LoadCommonData("11"); // Load ITDA Data
        }

        function LoadCommonData(type) {

            scope.preloader = true;
            scope.IsComShow = false;
            scope.AdnagalShow = false;
            scope.UserTable = [];
            scope.AdandalTable = [];

            var req = {};
            var ftype = type;
            if (ftype == "11")
                req = { PTYPE: 11 }
            else if (ftype == "12")
                req = { PTYPE: 12, ITDA_CODE: scope.SelITDA }
            else if (ftype == "13")
                req = { PTYPE: 13, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict }
            else if (ftype == "14")
                req = { PTYPE: 14, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal }
            else if (ftype == "15")
                req = { PTYPE: 15, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage }
            else if (ftype == "16")
                req = { PTYPE: 16, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage }
            else if (ftype == "17")
                req = { PTYPE: 17, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage, ROFR_PATTADAAR: scope.Pattadar_Name }
            else if (ftype == "18")
                req = { PTYPE: 9, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage, AADHAAR_NO: scope.Aadhar_No }
            else if (ftype == "19")
                req = { PTYPE: 19, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage, COMPARTMENT_NO: scope.SelCompartment }
            else if (ftype == "20")
                req = { PTYPE: 19, ITDA_CODE: scope.SelITDA, DISTRICT_CODE: scope.SelDistrict, MANDAL_CODE: scope.SelMandal, VILLAGE_NAME: scope.SelVillage, COMPARTMENT_NO: scope.CurrCompartment }

            ns.post(baseurl + "LoanAdangalData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {

                    if (ftype == "11") {
                        if (value.data.Data.length > 0)
                            scope.ITDADD = value.data.Data;
                        else
                            swal("Info", "No ITDA Data Found", "info");
                    }

                    else if (ftype == "12") {
                        if (value.data.Data.length > 0)
                            scope.DistrictsDD = value.data.Data;
                        else
                            swal("Info", "No Districts Data Found", "info");
                    }

                    else if (ftype == "13") {
                        if (value.data.Data.length > 0)
                            scope.MandalsDD = value.data.Data;
                        else
                            swal("Info", "No Mandals Data Found", "info");
                    }

                    else if (ftype == "14") {
                        if (value.data.Data.length > 0)
                            scope.VillageDD = value.data.Data;

                        else
                            swal("Info", "No Villages Data Found", "info");
                    }

                    else if (ftype == "16") {
                        if (value.data.Data.length > 0)
                            scope.CompartmentDD = value.data.Data;
                        else
                            swal("Info", "No Compartment Data Found", "info");
                    }

                    else if (ftype == "15") {
                        if (value.data.Data.length > 0)
                            scope.PattadarNameDD = value.data.Data;
                        else
                            swal("Info", "No Pattadar Data Found", "info");
                    }

                    else if (ftype == "17" || ftype == "18") {
                        if (value.data.Data.length > 0) {
                            scope.IsComShow = true;
                            scope.UserTable = value.data.Data;
                        }
                        else
                            swal("Info", "No User Data Found", "info");
                    }

                    else if (ftype == "19" || ftype == "20") {
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
            if (!scope.SelITDA) {
                swal("Info", "Please Select ITDA Name ", "info");
                return false;
            }
            else if (!scope.SelDistrict) {
                swal("Info", "Please Select District ", "info");
                return false;
            }
            else if (!scope.SelMandal) {
                swal("Info", "Please Select Mandal ", "info");
                return false;
            }
            else if (!scope.SelVillage) {
                swal("Info", "Please Select Village ", "info");
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