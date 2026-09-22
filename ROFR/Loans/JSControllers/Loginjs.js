(function () {
    var app = angular.module("GBLI", ["Network"]);

    app.controller("LoginController", ["$scope", "network_service", "$interval", Login_CTRL]);

    function Login_CTRL(scope, ns, int) {

        var baseurl = "/API/LoansAPI/";

        scope.divloader = false;
        CaptchLoad();

        scope.GetRefresh = function () {
            CaptchLoad();
        }

        scope.Reset = function () {
            scope.USER_ID = "";
            scope.PASSWORD = "";
            scope.EnterCaptcha = "";
            scope.capId = "";
            CaptchLoad();
        }

        scope.GetLogin = function () {

            if (!scope.USER_ID) {

                swal('info', 'Please Enter User ID', 'info')
                return;
            }
            if (!scope.PASSWORD) {

                swal('info', 'Please Enter Password', 'info')
                return;
            }
            if (!scope.EnterCaptcha) {
                swal('info', 'Please Enter Captcha', 'info')
                return;
            }
            else {
                LOADlOGIN();
            }
        }

        function CaptchLoad() {
            scope.apploader = true;
            sessionStorage.setItem("hskey", "admin");
            var obj = { ftype: "1" }
            ns.post(baseurl + "GetCaptcha", obj, function (data) {
                scope.apploader = false;
                scope.EnterCaptcha = "";
                var res = data.data;
                if (res.code == "100") {
                    scope.capatchval = "";
                    $("#capid").html(res.idval);
                    scope.capId = res.idval;
                    $("#captchdis tr").remove();
                    var img = $("<img>", { "id": res.idval, "src": "data:image/Gif;base64," + res.imgurl, "width": "120px", "height": "40px" });
                    var rowget = $('<tr></tr>').append('<td></td>').html(img);
                    $("#captchdis tbody").append(rowget);
                }

                //else {

                //    CaptchLoad();
                //}

            });
        }

        function LOADlOGIN() {

            scope.isdisabled = true;
            scope.divloader = true;

            var input = { USER_NAME: scope.USER_ID, NEW_PASSWORD: scope.PASSWORD, REFER_ID: scope.EnterCaptcha, CAPTHA_VALUE: scope.capId }

            ns.post(baseurl + "GBLIUserLogin", input, function (value) {

                var res = value.data;
                scope.divloader = false;
                scope.isdisabled = false;

                if (res.Status == '100') {

                    sessionStorage.setItem("USER_ID", res.DataList[0].USER_ID);
                    sessionStorage.setItem("USER_NAME", res.DataList[0].USER_NAME);
                    sessionStorage.setItem("BANKNAME", res.DataList[0].BANKNAME);
                    sessionStorage.setItem("DESIGNATION", res.DataList[0].DESIGNATION);
                    sessionStorage.setItem("BRANCH_NAME", res.DataList[0].BRANCH_NAME);
                    sessionStorage.setItem("ROLE", res.DataList[0].ROLE);

                    if (res.DataList[0].IS_UPDATE_PASSWORD != true)
                        location.href = '../Loans/ChangeMyPassword.aspx';
                    else
                        location.href = '../Loans/LandingPage.aspx';
                    //state.go("ui.MainDashBoard");
                }
                else if (res.Status == "428") {
                    sessionStorage.clear();
                    location.href = '../Loans/Login.aspx';
                    return;
                }
                else {
                    scope.EnterCaptcha = "";
                    CaptchLoad();
                    swal('info', res.Reason, 'info');
                }
            });
        }
    }
})();