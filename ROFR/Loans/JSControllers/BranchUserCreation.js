(function () {
    var status = false;
    var app = angular.module("GBLI", ["Network"]);

    app.controller("BranchUserCreation", ["$scope", "network_service", BUC_CTRL]);

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

    function BUC_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Branch User Creation";
        scope.preloader = false;
        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");

        LoadACommonData("3"); // Load Current Bank Name
        LoadACommonData("5"); // Load Branches Data
        LoadACommonData("6"); // Load Roles Data

        scope.SaveData = function () {
            if (Validations()) {
                var req = { PTYPE: 3, LOGIN_USER: scope.USER_ID };
                ns.post(baseurl + "AdminCommonData", req, function (value) {
                    if (value.data.Data.length > 0) {
                        swal("Info", "User ID Already Exists ", "info");
                        return false;
                    }
                    else {
                        var req = { PTYPE: 20, USER_NAME: scope.USER_NAME };
                        ns.post(baseurl + "AdminCommonData", req, function (value) {
                            if (value.data.Data.length > 0) {
                                swal("Info", "User Name Already Exists ", "info");
                                return false;
                            }
                            else {
                                LoadACommonData("7"); // Save Branch User Creation Data
                            }
                        });
                    }
                });
            }
        }

        function LoadACommonData(type) {
            var ftype = type;
            var req = {};
            scope.preloader = true;
            if (ftype == "3")
                req = { PTYPE: 3, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "5")
                req = { PTYPE: 5, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "6")
                req = { PTYPE: 6 }
            else if (ftype == "7")
                req = { PTYPE: 7, BANKNAME: scope.CurrBankName, USER_ID: scope.USER_ID, USER_NAME: scope.USER_NAME, DESIGNATION: scope.DESIGNATION, MOBILE_NO: scope.MOBILE_NO, BRANCH_NAME: scope.BRANCH_NAME, ROLE: scope.ROLE, TOKEN_NUMBER: scope.TOKEN_NUMBER, EXPIRY_DATE: moment(scope.EXPIRY_DATE).format('YYYY/MM/DD'), LOGIN_USER: scope.LOGIN_USER }

            ns.post(baseurl + "AdminCommonData", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {
                    if (ftype == "3") {
                        if (value.data.Data.length > 0) {
                            scope.BANKNAME = value.data.Data[0].BANKNAME;
                            scope.CurrBankName = scope.BANKNAME;
                        }
                    }
                    else if (ftype == "5") {
                        if (value.data.Data.length > 0)
                            scope.BranchesDD = value.data.Data;
                        else
                            swal("Info", "No Branches Data Found", "info");
                    }
                    else if (ftype == "6") {
                        if (value.data.Data.length > 0)
                            scope.RolesDD = value.data.Data;
                        else
                            swal("Info", "No Roles Data Found", "info");
                    }

                    else if (ftype == "7") {
                        swal("Info", "Branch User Created Successfully.", "info");
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
            else if (!scope.USER_ID) {
                swal("Info", "Please Enter User Id ", "info");
                return false;
            }
            else if (!scope.USER_NAME) {
                swal("Info", "Please Enter User Name ", "info");
                return false;
            }
            else if (!scope.DESIGNATION) {
                swal("Info", "Please Enter Designation ", "info");
                return false;
            }
            else if (!scope.MOBILE_NO) {
                swal("Info", "Please Enter Mobile Number ", "info");
                return false;
            }
            else if (!scope.BRANCH_NAME) {
                swal("Info", "Please Select Branch ", "info");
                return false;
            }
            else if (!scope.ROLE) {
                swal("Info", "Please Select Role ", "info");
                return false;
            }
            else if (!scope.TOKEN_NUMBER) {
                swal("Info", "Please Enter Token Number ", "info");
                return false;
            }
            else if (!scope.EXPIRY_DATE) {
                swal("Info", "Please Select Expire Date ", "info");
                return false;
            }
            else if (scope.EXPIRY_DATE < new Date()) {
                swal("Info", "Expire Date Should be Greater than To Day", "info");
                return false;
            }
            return true;
        }


    }
})();