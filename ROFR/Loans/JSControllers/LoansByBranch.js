(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoansByBranch", ["$scope", "network_service", Loans_BranchWise]);

    function Loans_BranchWise(scope, ns) {
        var baseurl = "/API/LoansAPI/";

        scope.pagename = "BranchWise Loans Summary";
        scope.preloader = false;
        scope.Radio_sel = "1";
        scope.Bank_TableData = false;
        scope.Branch_TableData = false;
        scope.AllLoans = false;
        LoadAllData();


        function LoadAllData() {
            LoadCommonData("1"); // Load Districts Data
        }

        scope.ChangeOption = function () {
            scope.UserTable = [];
            scope.UserBranchWise = [];
            scope.AllBankWiseData = [];

            scope.SelBank = "";
            scope.Bank_TableData = false;
            scope.Branch_TableData = false;
            scope.AllLoans = false;
            if (scope.Radio_sel == "1")
                LoadCommonData("1");// Loan Entered
            else if (scope.Radio_sel == "2") {
                scope.BankDD = [];
                LoadCommonData("1");  // Loan Approved
            }
            else if (scope.Radio_sel == "3") {
                scope.BankDD = []
                LoadCommonData("1");//  Loan Released
            }
            else if (scope.Radio_sel == "4") {
                scope.BankDD = []
                LoadCommonData("1");// Loan Not Released
            }
            else
                scope.BankDD = [];
            LoadCommonData("1");// All Loans
        }

        scope.GetDetails = function () {

            scope.Bank_TableData = false;
            scope.Branch_TableData = false;
            scope.AllLoans = false;

            if (!scope.SelBank) {

                swal("info", "Please select bank", "info");
            }

            else if (scope.Radio_sel == "1")
                LoadCommonData("2");// Loan Entered

            else if (scope.Radio_sel == "2")
                LoadCommonData("4");  // Loan Approved

            else if (scope.Radio_sel == "3")
                LoadCommonData("6");//  Loan Released

            else if (scope.Radio_sel == "4")
                LoadCommonData("8");// Loan Not Released

            else if (scope.Radio_sel == "5")
                LoadCommonData("10");// All Loans

        }

        scope.GetBranchDetails = function (branch) {
            scope.UserBranchWise = [];
            scope.Branch_TableData = false;
            scope.AllLoans = false;
            if (scope.Radio_sel == "1") {
                LoadCommonData("3", branch);
            }
            else if (scope.Radio_sel == "2") {
                LoadCommonData("5", branch);
            }
            else if (scope.Radio_sel == "3") {
                LoadCommonData("7", branch);
            }
            else if (scope.Radio_sel == "4") {
                LoadCommonData("9", branch);
            }
            else {
                LoadCommonData("10", branch);
            }
        }

        function LoadCommonData(type, branch) {

            scope.preloader = true;

            var req = {};
            var ftype = type;
            if (ftype == "1")
                req = { PTYPE: 1 }
            else if (ftype == "2")
                req = { PTYPE: 2, BANKNAME: scope.SelBank }
            else if (ftype == "3")
                req = { PTYPE: 3, BANKNAME: scope.SelBank, BRANCH_NAME: branch }
            else if (ftype == "4")
                req = { PTYPE: 4, BANKNAME: scope.SelBank }
            else if (ftype == "5")
                req = { PTYPE: 5, BANKNAME: scope.SelBank, BRANCH_NAME: branch }
            else if (ftype == "6")
                req = { PTYPE: 6, BANKNAME: scope.SelBank }
            else if (ftype == "7")
                req = { PTYPE: 7, BANKNAME: scope.SelBank, BRANCH_NAME: branch }
            else if (ftype == "8")
                req = { PTYPE: 8, BANKNAME: scope.SelBank }
            else if (ftype == "9")
                req = { PTYPE: 9, BANKNAME: scope.SelBank, BRANCH_NAME: branch }
            else if (ftype == "10")
                req = { PTYPE: 10, BANKNAME: scope.SelBank }
            ns.post(baseurl + "LoadReportsDataBranchWise", req, function (value) {
                scope.preloader = false;
                if (value.data.Status == 100) {
                    if (ftype == "1") {

                        if (value.data.Data.length > 0)
                            scope.BankDD = value.data.Data;
                        else
                            swal("Info", "No Data Found", "info");
                    }
                    else if (ftype == "2") {
                        scope.Bank_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserTable = value.data.Data;
                        else
                            swal("Info", "No Bank Data Found In Entered List", "info");
                    }
                    else if (ftype == "3") {
                        scope.Branch_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserBranchWise = value.data.Data;
                        else
                            swal("Info", "No Branch Data Found In Entered List", "info");
                    }
                    else if (ftype == "4") {
                        scope.Bank_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserTable = value.data.Data;
                        else
                            swal("Info", "No Bank Data Found In Approved List", "info");
                    }
                    else if (ftype == "5") {
                        scope.Branch_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserBranchWise = value.data.Data;
                        else
                            swal("Info", "No Branch Data Found In Approved List", "info");
                    }
                    else if (ftype == "6") {
                        scope.Bank_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserTable = value.data.Data;
                        else
                            swal("Info", "No Bank Data Found In Released List", "info");
                    }
                    else if (ftype == "7") {
                        scope.Branch_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserBranchWise = value.data.Data;
                        else
                            swal("Info", "No Branch Data Found In  Released List", "info");
                    }
                    else if (ftype == "8") {
                        scope.Bank_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserTable = value.data.Data;
                        else
                            swal("Info", "No Bank Data Found In Not Released List ", "info");
                    }
                    else if (ftype == "9") {
                        scope.Branch_TableData = true;
                        if (value.data.Data.length > 0)
                            scope.UserBranchWise = value.data.Data;
                        else
                            swal("Info", "No Branch Data Found In Not Released List", "info");
                    }
                    else if (ftype == "10") {
                        scope.AllLoans = true;
                        if (value.data.Data.length > 0)
                            scope.AllBankWiseData = value.data.Data;
                        else
                            swal("Info", "No  Data Found", "info");
                    }
                    else
                        swal("Info", "No  Data Found", "info");
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
})();