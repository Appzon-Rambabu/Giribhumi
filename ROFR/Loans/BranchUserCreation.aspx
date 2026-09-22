<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="BranchUserCreation.aspx.cs" Inherits="ROFR.Loans.BranchUserCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Branch User Creation</title>
    <script src="JSControllers/BranchUserCreation.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="BranchUserCreation">
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
                                    <h5 class="card-title text-center text-uppercase">Branch User Creation</h5>
                                </div>
                                <div class="card-body pb-5">

                                    <div class="form-group row mb-3">
                                        <label class="col-lg-6 col-form-label">Bank Name : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="BANKNAME" ng-disabled="true" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">User Id : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" alpha-numbers ng-model="USER_ID" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">User Name : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="USER_NAME" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Designation : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="DESIGNATION" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Mobile No : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" numbers-only maxlength="10" ng-model="MOBILE_NO" class="form-control">
                                        </div>

                                        <label class="col-lg-6 col-form-label">Branch : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <select class="form-control" ng-model="BRANCH_NAME">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in BranchesDD" value="{{dis.BRANCH_NAME}}">{{dis.BRANCH_NAME}}</option>
                                            </select>
                                        </div>

                                        <label class="col-lg-6 col-form-label">Role : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <select class="form-control" ng-model="ROLE">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in RolesDD" value="{{dis.ROLES}}">{{dis.ROLES}}</option>
                                            </select>
                                        </div>

                                        <label class="col-lg-6 col-form-label">Token No : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="TOKEN_NUMBER" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Expiry Date : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="date" ng-model="EXPIRY_DATE" class="form-control">
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
