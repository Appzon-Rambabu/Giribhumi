(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("BranchMasterEntry", ["$scope", "network_service", BME_CTRL]);

    function BME_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Branch Master Entry";
        scope.preloader = false;
        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");

        LoadACommonData("1"); // Load Districts
        LoadACommonData("3"); // Load Bank Name

        scope.DistrictChange = function () {
            scope.MandalsDD = [];

            if (scope.SELDISTRICT)
                LoadACommonData("2"); // Load Mandals Data
        }

        scope.SaveData = function () {
            if (Validations()) {
                LoadACommonData("4"); // Save Branch Master Entry Data
            }
        }

        function LoadACommonData(type) {
            var ftype = type;
            var req = {};
            scope.preloader = true;
            if (ftype == "1")
                req = { PTYPE: 1 }
            else if (ftype == "2")
                req = { PTYPE: 2, DISTRICT_CODE: scope.SELDISTRICT }
            else if (ftype == "3")
                req = { PTYPE: 3, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "4")
                req = { PTYPE: 4, BANKNAME: scope.CurrBankName, BRANCH_CODE: scope.BRANCH_CODE, BRANCH_NAME: scope.BRANCH_NAME, BRANCH_ADDRESS: scope.BRANCH_ADDRESS, DISTRICT: scope.SELDISTRICT, MANDAL: scope.SELMANDAL, LOGIN_USER: scope.LOGIN_USER }

            ns.post(baseurl + "AdminCommonData", req, function (value) {
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
                            scope.MandalsDD = value.data.Data;
                        else
                            swal("Info", "No Mandals Data Found", "info");
                    }
                    if (ftype == "3") {
                        if (value.data.Data.length > 0) {
                            scope.BANKNAME = value.data.Data[0].BANKNAME;
                            scope.CurrBankName = scope.BANKNAME;
                        }
                    }
                    else if (ftype == "4") {
                        swal("Info", "Branch Master Data Saving Successfully.", "info");
                        window.location.reload();
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

        function Validations() {
            if (!scope.BANKNAME) {
                swal("Info", "Please Enter Bank Name", "info");
                return false;
            }
            else if (!scope.BRANCH_CODE) {
                swal("Info", "Please Enter Branch Code ", "info");
                return false;
            }
            else if (!scope.BRANCH_NAME) {
                swal("Info", "Please Enter Branch Name ", "info");
                return false;
            }
            else if (!scope.BRANCH_ADDRESS) {
                swal("Info", "Please Enter Branch Address ", "info");
                return false;
            }
            else if (!scope.SELDISTRICT) {
                swal("Info", "Please Select District ", "info");
                return false;
            }
            else if (!scope.SELMANDAL) {
                swal("Info", "Please Select Mandal ", "info");
                return false;
            }

            return true;
        }
    }
})();