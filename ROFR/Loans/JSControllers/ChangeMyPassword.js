(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("ChangeMyPassword", ["$scope", "network_service", CMP_CTRL]);

    function CMP_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Change My Password";
        scope.preloader = false;
        //scope.USER_ID = "095201";
        scope.USER_ID = sessionStorage.getItem("USER_NAME");
        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");

        scope.SaveData = function () {
            if (Validations()) {
                scope.preloader = true;
                var req = { PTYPE: 10, NEW_PASSWORD: scope.NEW_PASSWORD, OLD_PASSWORD: scope.OLD_PASSWORD, USER_ID: scope.USER_ID, LOGIN_USER: scope.LOGIN_USER };
                ns.post(baseurl + "UpdateUserData", req, function (value) {
                    scope.preloader = false;
                    if (value.data.Status == 100) {
                        swal("Info", "Password Updated Successfully.", "info");
                        location.href = '../Loans/LandingPage.aspx';
                    }
                    else if (value.data.Status == "428") {
                        sessionStorage.clear();
                        swal("info", "Session Expired !!!", "info");
                        location.href = '../Loans/Login.aspx';
                        return;
                    }
                    else {
                        scope.OLD_PASSWORD = "";
                        swal("Info", value.data.Reason, "info");
                    }

                });
            }
        }

        function Validations() {
            if (!scope.USER_ID) {
                swal("Info", "Please Enter User ID", "info");
                return false;
            }
            else if (!scope.OLD_PASSWORD) {
                swal("Info", "Please Enter Old Password", "info");
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