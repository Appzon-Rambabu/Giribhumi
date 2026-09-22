(function () {
    var status = false;
    var app = angular.module("GBLI", ["Network"]);

    app.controller("BranchUserUpdation", ["$scope", "network_service", BUU_CTRL]);

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

    function BUU_CTRL(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "Branch User Updation";
        scope.preloader = false;
        scope.isactive = false;
        scope.LOGIN_USER = sessionStorage.getItem("USER_ID");

        LoadACommonData("3"); // Load Current Bank Name
        LoadACommonData("5"); // Load Branches Data
        LoadACommonData("6"); // Load Roles Data
        LoadACommonData("8"); // Load Users Data

        scope.UserChange = function () {
            if (scope.USER_ID) {
                LoadACommonData("13"); // Load User Details
            }
        }

        scope.SaveData = function () {
            if (Validations()) {
                LoadACommonData("9"); // Update User Data
            }
        }

        scope.UserUpdate = function (activestatus) {
            if (ActiveValidations()) {
                LoadACommonData("14", activestatus); // Active or Inactive User
            }
        }

        function LoadACommonData(type, userstatus) {
            var ftype = type;
            var req = {};
            scope.preloader = true;
            if (ftype == "3")
                req = { PTYPE: 3, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "5")
                req = { PTYPE: 5, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "6")
                req = { PTYPE: 6 }
            else if (ftype == "8")
                req = { PTYPE: 8, LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "9")
                req = { PTYPE: 9, BANKNAME: scope.CurrBankName, USER_ID: scope.USER_ID, USER_NAME: scope.USER_NAME, DESIGNATION: scope.DESIGNATION, MOBILE_NO: scope.MOBILE_NO, BRANCH_NAME: scope.BRANCH_NAME, ROLE: scope.ROLE, TOKEN_NUMBER: scope.TOKEN_NUMBER, EXPIRY_DATE: moment(scope.EXPIRY_DATE).format('YYYY/MM/DD'), LOGIN_USER: scope.LOGIN_USER }
            else if (ftype == "13")
                req = { PTYPE: 13, USER_ID: scope.USER_ID }
            else if (ftype == "14")
                req = { PTYPE: 14, USER_ID: scope.USER_ID, ACTIVE_STATUS: userstatus, LOGIN_USER: scope.LOGIN_USER }

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

                    else if (ftype == "8") {
                        if (value.data.Data.length > 0)
                            scope.UsersDD = value.data.Data;
                        else
                            swal("Info", "No Users Data Found", "info");
                    }

                    else if (ftype == "9") {
                        swal("Info", "User Profile Updated Successfully.", "info");
                        window.location.reload();
                    }

                    else if (ftype == "13") {
                        if (value.data.Data.length > 0) {
                            var userdata = value.data.Data[0];
                            scope.USER_NAME = userdata.USER_NAME;
                            scope.DESIGNATION = userdata.DESIGNATION;
                            scope.MOBILE_NO = userdata.MOBILE_NO;
                            scope.BRANCH_NAME = userdata.BRANCH_NAME;
                            scope.ROLE = userdata.ROLE;
                            scope.TOKEN_NUMBER = userdata.TOKEN_NUMBER;
                            scope.EXPIRY_DATE = new Date(userdata.EXPIRY_DATE);
                            if (userdata.ACTIVE_STATUS == "Active")
                                scope.isactive = true;
                            else
                                scope.isactive = false;

                        }
                        else
                            swal("Info", "User Details Not Found", "info");
                    }

                    else if (ftype == "14") {
                        if (userstatus == "Active")
                            swal("Info", "User Activated Successfully.", "info");
                        else
                            swal("Info", "User Inactivated Successfully.", "info");

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
                swal("Info", "Please Select User Id ", "info");
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
                swal("Info", "Expire Date Should be Grater than To Day", "info");
                return false;
            }

            return true;
        }

        function ActiveValidations() {
            if (!scope.USER_ID) {
                swal("Info", "Please Select User Id ", "info");
                return false;
            }

            return true;
        }
    }
})();