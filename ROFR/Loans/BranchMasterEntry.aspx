<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="BranchMasterEntry.aspx.cs" Inherits="ROFR.Loans.BranchMasterEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Branch Master Entry</title>
    <script src="JSControllers/BranchMasterEntry.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="BranchMasterEntry">
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
                                    <h5 class="card-title text-center text-uppercase">Branch Master Entry</h5>
                                </div>
                                <div class="card-body pb-5">

                                    <div class="form-group row mb-3">
                                        <label class="col-lg-6 col-form-label">Bank Name : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-disabled="true" ng-model="BANKNAME" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Branch Code : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="BRANCH_CODE" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Branch Name : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="BRANCH_NAME" class="form-control">
                                        </div>
                                        <label class="col-lg-6 col-form-label">Branch Address : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <input type="text" ng-model="BRANCH_ADDRESS" class="form-control">
                                        </div>

                                        <label class="col-lg-6 col-form-label">District : <span style="color: red;"> * </span></label>
                                        <div class="col-lg-6">
                                            <select class="form-control" ng-model="SELDISTRICT" ng-change="DistrictChange();">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in DistrictsDD" value="{{dis.DISTRICT_CODE}}">{{dis.DISTRICT}}</option>
                                            </select>
                                        </div>

                                        <label class="col-lg-6 col-form-label">Mandal : <span style="color: red;"></span></label>
                                        <div class="col-lg-6">
                                            <select class="form-control" ng-model="SELMANDAL">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in MandalsDD" value="{{dis.MANDAL_CODE}}">{{dis.MANDAL}}</option>
                                            </select>
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
