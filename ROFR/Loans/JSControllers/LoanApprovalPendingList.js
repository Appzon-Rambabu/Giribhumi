(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoanApprovalPendingList", ["$scope", "network_service", LoanAppPenList_CTRL]);

    function LoanAppPenList_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");
        scope.pagename = "Loan Approval Pending List";
        scope.preloader = false;

        scope.GetDetails = function () {
            if (Validations()) {
                scope.ReportsTable = [];

                scope.preloader = true;
                var req = { PTYPE: 3, FROM_DATE: moment(scope.FROM_DATE).format('YYYY/MM/DD'), TO_DATE: moment(scope.TO_DATE).format('YYYY/MM/DD'), LOGIN_USER: scope.LOGIN_USER }
                ns.post(baseurl + "LoadReportsData", req, function (value) {
                    scope.preloader = false;
                    if (value.data.Status == 100) {
                        if (value.data.Data.length > 0)
                            scope.ReportsTable = value.data.Data;
                        else
                            swal("Info", "No Data Found", "info");
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

        function Validations() {
            if (!scope.FROM_DATE) {
                swal("Info", "Please Select From Date ", "info");
                return false;
            }
            else if (!scope.TO_DATE) {
                swal("Info", "Please Select To Date ", "info");
                return false;
            }

            return true;
        }

    }
})();