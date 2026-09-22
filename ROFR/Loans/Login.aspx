<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ROFR.Loans.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="shortcut icon" href="../Loans/assets/images/favicon.png" type="image/vnd.microsoft.icon">

    <title>Loans Login</title>

    <style type="text/css">
        @media (min-width: 1200px) {
            .page-header-content {
                padding-left: 1rem;
                padding-right: 1rem;
            }
        }

        .card {
            box-shadow: 0 3px 15px 0 #E0E0E0;
            border-radius: 11px;
        }

        .card-header .card-title {
            font-weight: 800;
            font-family: "Roboto";
            font-size: 16px;
        }

        .card-body fieldset {
        }

        .card-body .bg-primary-800 {
            background-color: #174d8b;
        }

        .card-body legend {
            margin-bottom: 0.50rem;
            font-family: "Roboto", Arial, sans-serif !important;
            font-weight: 600;
            font-size: 13px;
            padding: 5px 10px !important;
        }

        .card-body .form-group {
            margin: 0.5rem 0.5rem;
        }

            .card-body .form-group .required {
                color: red;
            }

            .card-body .form-group .form-control, .card-body .form-group button {
                padding: 0.2rem 1rem !important;
                height: 28.4px;
            }

            .card-body .form-group select.form-control:not([size]):not([multiple]) {
                height: 28.4px;
            }

            .card-body .form-group .btn-primary {
                background-color: #174d8b;
            }

        .font-telugu h2 {
            font-size: 30px;
            font-family: 'Ramabhadra', sans-serif;
            text-shadow: 2px 2px rgba(0,0,0,0.3);
            line-height: 1.2;
        }

        .custom-bg {
            background: url(../Loans/assets/images/header-bg.jpg);
            background-repeat: no-repeat;
            background-position: center right;
            background-size: cover;
        }

        /*Loader*/
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('../Loans/assets/images/loader.gif') 50% 50% no-repeat #ffffffb8;
        }

        .table th, .table td {
            padding: 0.25rem 0.25rem !important;
        }

        legend {
            background: #004085;
            padding: 4px 22px;
            border-radius: 3px;
            color: white;
            font-size: 16px;
        }

        fieldset {
            border: 2px solid gray !important;
            border-radius: 3px;
            padding: 20px !important;
        }

        .w-72 {
            width: 72% !important;
        }

        .card {
            box-shadow: 0px 5px 10px rgba(0,0,0,0.3);
        }
    </style>

    <link href="../Loans/assets/css/icons/icomoon/styles.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/icons/material/icons.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/bootstrap_limitless.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/layout.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/components.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/colors.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/slick.css" rel="stylesheet" />
    <link href="../Loans/assets/css/slick-theme.css" rel="stylesheet" />

    <link href="../Loans/assets/flaticon/flaticon.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/hover.css" rel="stylesheet" type="text/css">
    <link href="../Loans/assets/css/style.css" rel="stylesheet" type="text/css">

    <script src="../Loans/assets/js/jquery.min.js"></script>
    <script src="../Loans/assets/js/bootstrap.bundle.min.js"></script>

    <script src="../Loans/assets/plugins/uniform.min.js"></script>
    <script src="../Loans/assets/plugins/switch.min.js"></script>
    <script src="../Loans/assets/plugins/spin.min.js"></script>
    <script src="../Loans/assets/plugins/ladda.min.js"></script>
    <script src="../Loans/assets/plugins/components_buttons.js"></script>
    <script src="../Loans/JS_Modules/moment.js"></script>
     <script src="../Loans/JS_Modules/angular.min.js"></script>
    <script src="../Loans/JS_Modules/network.js"></script>
   <script src="../Loans/JS_Modules/SweetAlert2.js"></script>
    <script src="../Loans/JSControllers/Loginjs.js"></script>
</head>
<body>
    <div>
        <div class="page-header page-header-dark cust-page-header ng-scope custom-bg">

            <div class="container-fluid">
                <div class="row my-1">
                    <div class="col-md-2">
                        <img src="../Loans/assets/images/newcmimg.jpg" class="mx-auto d-block img-fluid" style="height: 70px;">
                        <div class="text-center" style="font-size: 10px;">
                            శ్రీ.వై.ఎస్.జగన్ మోహన్ రెడ్డి గారు<br>
                            గౌ.ముఖ్యమంత్రివర్యులు<br>
                            ఆంధ్రప్రదేశ్ ప్రభుత్వం
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="mt-3 d-flex font-telugu justify-content-center">
                            <h2 class="text-center mx-2">ఆంధ్రప్రదేశ్ ప్రభుత్వం<br>
                                గిరిజన సంక్షేమ శాఖ</h2>
                            <img src="../Loans/assets/images/ap-logo.png" height="70px">
                            <h2 class="text-center mx-2 mt-2" style="line-height: 1; font-size: 50px;">గిరి భూమి<br>
                                <p style="font-size: 13px; margin-top: -10px;">భూమి రికార్డుల వివరములు - ప్రజా పోర్టల్</p>
                            </h2>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <img src="../Loans/assets/images/minister.jpg" class="mx-auto d-block img-fluid" style="height: 70px;">
                        <div class="text-center" style="font-size: 10px;">
                            శ్రీమతి.పి.పుష్ప శ్రీవాణి గారు<br>
                            గౌ.ఉప
                    ముఖ్యమంత్రివర్యులు<br>
                            గిరిజన సంక్షేమ శాఖ
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="page-content pt-0" data-ng-app="GBLI" ng-controller="LoginController">
            <div class="content-wrapper">
                <div class="content">
                    <div class="page-content">

                        <!-- Main content -->
                        <div class="content-wrapper">
                            <!-- Content area -->
                            <div class="content">
                                <div class="container-fluid">
                                    <div class="row mb-2 justify-content-center">

                                        <div class="col-sm-6">
                                            <div class="card">
                                                <div class="card-header bg-indigo py-1">
                                                    <h5 class="card-title text-center text-uppercase">Login</h5>
                                                </div>
                                                <div class="card-body pb-5">

                                                    <div class="form-group row mb-3">
                                                        <label class="col-lg-6 col-form-label">User ID : <span style="color: red;">* </span></label>
                                                        <div class="col-lg-6">
                                                            <input type="text" ng-model="USER_ID" class="form-control">
                                                        </div>
                                                    </div>
                                                    <div class="form-group row mb-3">
                                                        <label class="col-lg-6 col-form-label">Password : <span style="color: red;">* </span></label>
                                                        <div class="col-lg-6">
                                                            <input type="password" ng-model="PASSWORD" class="form-control">
                                                        </div>
                                                    </div>
                                                    <div class="form-group form-row ">
                                                        <label class="col-lg-6 col-form-label">Captcha : </label>
                                                        <div class="col-lg-6 d-flex">

                                                            <a href="javascript:void(0);" title="click here to get new confirmation code" class="btn bg-primary-800 btn-round" ng-click="GetRefresh();"><i class="icon-reload-alt" aria-hidden="true"></i></a>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <table id="captchdis">
                                                        <tbody></tbody>
                                                    </table>

                                                        </div>

                                                    </div>
                                                    <div class="form-group row mb-3">
                                                        <label class="col-lg-6 col-form-label">Enter Above Captcha : <span style="color: red;">* </span></label>
                                                        <div class="col-lg-6">
                                                            <input type="text" alpha-numbers maxlength="6" ng-model="EnterCaptcha" class="form-control">
                                                        </div>

                                                    </div>

                                                    <div class="mt-3 text-center">
                                                        <button type="button" class="btn btn-success" ng-click="GetLogin();">Login</button>
                                                        <button type="button" class="btn btn-secondary" ng-click="Reset();">Clear</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="navbar navbar-expand-lg navbar-light">
            <div class="text-center d-lg-none w-100">
                <span class="navbar-text">© Copyright Govt of AP. All Rights Reserved
                </span>
            </div>
        </div>

    </div>

</body>
</html>
