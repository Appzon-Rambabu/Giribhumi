<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LoanApprovedList.aspx.cs" Inherits="ROFR.Loans.LoanApprovedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loan Approved List</title>
    <script src="JSControllers/LoanApprovedList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="LoanApprovedList">
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
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header bg-indigo py-1">
                                <h5 class="card-title text-center text-uppercase">Loan Approved List</h5>
                            </div>
                            <div class="card-body pb-5">

                                <div class="form-group row text-center mb-3">
                                    <label class="col-lg-2 col-form-label">From Date : </label>
                                    <div class="col-lg-2">
                                        <input type="date" ng-model="FROM_DATE" class="form-control">
                                    </div>
                                    <label class="col-lg-2 col-form-label"> TO Date : </label>
                                    <div class="col-lg-2">
                                        <input type="date" ng-model="TO_DATE" class="form-control">
                                    </div>
                                    <div class="col-lg-2">
                                        <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Search</button>
                                    </div>

                                </div>

                                <div class="form-group" >
                                    <table class="table table-bordered mb-3" style="max-height:300px;table-layout:fixed;">
                                        <thead class="text-white" style="text-align:center;background: #004085;">
                                            <tr>
                                                <th>Branch Name</th>
                                                <th>Account No</th>
                                                <th>Account Name</th>
                                                <th>Account Father Name</th>
                                                <th>Village</th>
                                                <th>Khata No.</th>
                                                <th>Compartment No</th>
                                                <th>Pattadar Name</th>
                                                <th>Pattadar Father Name</th>

                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Extent Plot Areat</th>
                                                <th>Crop Season</th>
                                                <th>Name Of Crop</th>
                                                <th>Loan Amount</th>
                                                <th>Date Of Disbursement</th>
                                                <th>Due Date</th>
                                                <th>Loan Created On</th>
                                                <th>Loan Approved Date</th>
                                               
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in ReportsTable">
                                                <td>  {{par.BRANCH_NAME}} </td>
                                                <td>  {{par.LOAN_ACCOUNTNO}} </td>
                                                <td>  {{par.BORROWER_NAME}} </td>
                                                <td>  {{par.FATHER_HUSBAND_NAME}} </td>
                                                <td>  {{par.VILLAGE}} </td>
                                                <td>  {{par.ROFR_PATTANO}} </td>
                                                <td>  {{par.COMPARTMENT_NO}} </td>
                                                <td>  {{par.ROFR_PATTADAAR}} </td>
                                                <td>  {{par.FATHER_NAME}} </td>

                                                <td>  {{par.OCCUPANT_NAME}} </td>
                                                <td>  {{par.OCCUPANT_FATHER_NAME}} </td>
                                                <td>  {{par.EXTENTPLOTAREA}} </td>
                                                <td>  {{par.CROP_SEASON}} </td>
                                                <td>  {{par.NAME_OF_THE_CROP}} </td>
                                                <td>  {{par.LOAN_AMOUNT}} </td>
                                                <td>  {{par.DATE_OF_DISBURSEMENT}} </td>
                                                <td>  {{par.DUE_DATE}} </td>
                                                <td>  {{par.CHARGE_CREATED_ON}} </td>
                                                <td>  {{par.CHARGE_CREATION_APP_DATE}} </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
