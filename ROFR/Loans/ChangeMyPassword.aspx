<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="ChangeMyPassword.aspx.cs" Inherits="ROFR.Loans.ChangeMyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Change My Password</title>
    <script src="JSControllers/ChangeMyPassword.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="ChangeMyPassword">
    <div data-ng-show="preloader" class="loader"></div>
    <!-- Main content -->
    <div class="content-wrapper">
        <!-- Content area -->
        <div class="content">
            <div class="container-fluid">
                <div class="row mb-2 justify-content-center">
                    <!--<div class="col-sm-12 text-center mb-2">
                        <h1 style="text-align: center;">Loan Information Creation </h1>
                    </div>-->
                    <div class="col-sm-6">
                        <div class="card">
                            <div class="card-header bg-indigo py-1">
                                <h5 class="card-title text-center text-uppercase">Change My Password</h5>
                            </div>
                            <div class="card-body pb-5">

                                <div class="form-group row mb-3">
                                    <label class="col-lg-6 col-form-label"> User Name : <span style="color:red;"> * </span></label>
                                    <div class="col-lg-6">
                                        <input type="text" ng-model="USER_ID" ng-disabled="true" class="form-control">
                                    </div>

                                    <label class="col-lg-6 col-form-label"> Old Password : <span style="color:red;"> * </span></label>
                                    <div class="col-lg-6">
                                        <input type="password" ng-model="OLD_PASSWORD" class="form-control">
                                    </div>

                                    <label class="col-lg-6 col-form-label"> New Password : <span style="color:red;"> * </span></label>
                                    <div class="col-lg-6">
                                        <input type="password" ng-model="NEW_PASSWORD" class="form-control">
                                    </div>

                                    <label class="col-lg-6 col-form-label"> Confirm Password : <span style="color:red;"> * </span></label>
                                    <div class="col-lg-6">
                                        <input type="password" ng-model="CONFIRM_PASSWORD" class="form-control">
                                    </div>

                                </div>

                                <div class="mt-3 text-center">
                                    <button type="button" class="btn btn-success" ng-click="SaveData();">Save</button>
                                    <!--<button type="button" class="btn btn-secondary" ng-click="Reset();">Reset</button>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
