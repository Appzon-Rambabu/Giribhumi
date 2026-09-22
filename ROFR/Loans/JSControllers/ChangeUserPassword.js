(function () {
    var app = angular.module("GBLI", ["Network"]);

    app.controller("ChangeUserPassword", ["$scope", "network_service", CUP_CTRL]);

    function CUP_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Change User Password";
        scope.preloader = false;
        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");

        LoadACommonData("8"); // Load Users Data

        scope.UserChange = function () {
            scope.BANK_NAME = "";
            scope.BRANCH_NAME = "";

            if (scope.USER_ID) {
                LoadACommonData("11"); // Get User Details
            }
        }

        scope.SaveData = function () {
            if (Validations()) {
                LoadACommonData("12"); // Update User Password
            }
        }

        function LoadACommonData(type) {
            var ftype = type;
            var req = {};
            scope.preloader = true;
            if (ftype == "8")
                req = { PTYPE: 8, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "11")
                req = { PTYPE: 11, USER_ID: scope.USER_ID }
            else if (ftype == "12")
                req = { PTYPE: 12, NEW_PASSWORD: scope.NEW_PASSWORD, USER_ID: scope.USER_ID, LOGIN_USER: scope.LOGIN_USER }


            ns.post(baseurl + "AdminCommonData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {
                    if (ftype == "8") {
                        if (value.data.Data.length > 0)
                            scope.UsersDD = value.data.Data;
                        else
                            swal("Info", "No Users Data Found", "info");
                    }

                    else if (ftype == "11") {
                        if (value.data.Data.length > 0) {
                            scope.BANK_NAME = value.data.Data[0].BANKNAME;
                            scope.BRANCH_NAME = value.data.Data[0].BRANCH_NAME;
                        }
                        else
                            swal("Info", "No Users Data Found", "info");
                    }

                    else if (ftype == "12") {
                        swal("Info", "User Password Updated Successfully.", "info");
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
            if (!scope.USER_ID) {
                swal("Info", "Please Select User ID", "info");
                return false;
            }
            else if (!scope.NEW_PASSWORD) {
                swal("Info", "Please Enter New Password ", "info");
                return false;
            }
            else if (!scope.CONFIRM_PASSWORD) {
                swal("Info", "Please Enter Confirm Password ", "info");
                return false;
            }
            else if (scope.NEW_PASSWORD != scope.CONFIRM_PASSWORD) {
                swal("Info", "New Password &  Confirm Password Must be Equal", "info");
                return false;
            }

            return true;
        }
    }
})();