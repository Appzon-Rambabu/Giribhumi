<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="ROFR.Loans.LandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Landing Page</title>

    <style type="text/css">
        .background-container {
            min-height: 550px;
            height: auto;
        }

        .gb-bg {
            background-size: cover;
            background-image: url(../Loans/assets/images/bg12.jpg);
            background-position: 50%;
            height: 100%;
            background-repeat: no-repeat;
            position: relative;
        }

            .gb-bg .overlay {
                position: absolute;
                width: 100%;
                height: 100%;
                background-color: rgba(0,0,0,0.5);
                left: 0;
                right: 0;
            }

            .gb-bg .main-title {
                font-size: 45px;
            }
    </style>
    <script src="JSControllers/DashBoardController.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content  p-0 background-container" ng-controller="DashBoardController">
        <div data-ng-show="preloader" class="loader"></div>
        <!-- Main content -->
        <div class="content-wrapper">
            <!-- Content area -->
            <div class="content m-0">
                <section class="gb-bg">
                    <div class="overlay"></div>
                    <div class="section-content h-100 d-flex align-items-center">
                        <div class="col-md-12 text-center">
                            <h1 class="font-weight-100 mt-10 text-white main-title">Welcome to <b style="color: #77f003">GIRI BHOOMI</b> </h1>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
