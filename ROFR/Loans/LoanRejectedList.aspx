<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LoanRejectedList.aspx.cs" Inherits="ROFR.Loans.LoanRejectedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loan Rejected List</title>
    <script src="JSControllers/LoanRejectedList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="LoanRejectedList">
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
                                <h5 class="card-title text-center text-uppercase">Loan Rejected List</h5>
                            </div>
                            <div class="card-body pb-5">

                                <div class="form-group row text-center mb-1">
                                    <label class="col-lg-2 col-form-label">Account Number : </label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="ROFR_PATTADAAR_ACCOUNT_NO">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in LoanAccountsDD" value="{{dis.LOAN_ACCOUNTNO}}">{{dis.LOAN_ACCOUNTNO}}</option>
                                        </select>
                                    </div>

                                    <div class="col-lg-1">
                                        <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Search</button>
                                    </div>

                                </div>

                                <div class="form-group" ng-show="Isreleaseshow">
                                    <table class="table table-bordered mb-1" style="max-height:300px;">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Action</th>
                                                <th>Land id</th>
                                                <th>Branch Name</th>
                                                <th>Loan AccoountNo</th>
                                                <th>Borrower Name</th>
                                                <th>Father/Husband Name</th>
                                                <th>Village</th>
                                                <th>Compartment No</th>
                                                <th>ROFR Pattadaar </th>
                                                <th>Father Name</th>
                                                <th>ROFR Aadhaar NO</th>
                                                <th>ROFR Patta NO</th>
                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Extent PlotArea</th>
                                                <th>Name Of The Crop</th>
                                                <th>Loan Amount</th>
                                                <th>Date Of Disbursement </th>
                                                <th>Due Date</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in PattadarTable">
                                                <td><a style="text-decoration: underline; cursor: pointer;" ng-click="GetPattadarDetails(par.LAND_ID);">Select</a></td>
                                                <td>{{par.LAND_ID}}</td>
                                                <td>  {{par.BRANCH_NAME}} </td>
                                                <td>  {{par.LOAN_ACCOUNTNO }} </td>
                                                <td>  {{par.BORROWER_NAME }} </td>
                                                <td>  {{par.FATHER_HUSBAND_NAME }} </td>
                                                <td>  {{par.VILLAGE}} </td>
                                                <td>  {{par.COMPARTMENT_NO }} </td>
                                                <td>  {{par.ROFR_PATTADAAR }} </td>
                                                <td>  {{par.FATHER_NAME }} </td>
                                                <td>  {{par.PATTADAR_AADHAR_NO }} </td>
                                                <td>  {{par.ROFR_PATTANO }} </td>
                                                <td>  {{par.OCCUPANT_NAME }} </td>
                                                <td>  {{par.OCCUPANT_FATHER_NAME }} </td>
                                                <td>  {{par.EXTENTPLOTAREA  }} </td>
                                                <td>  {{par.NAME_OF_THE_CROP  }} </td>
                                                <td>  {{par.LOAN_AMOUNT  }} </td>
                                                <td>  {{par.DATE_OF_DISBURSEMENT  }} </td>
                                                <td>  {{par.DUE_DATE }} </td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>

                                <!--Step 2 Starting-->
                                <div class="mt-2">
                                    <!--Main Fieldset-->
                                    <fieldset>
                                        <legend class="w-auto">
                                            Borrower Details
                                        </legend>
                                        <div class="form-group row mb-3">
                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Account No : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" alpha-numbers maxlength="50" ng-disabled="true" class="form-control" ng-model="LOAN_ACCOUNTNO">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Borrower Name : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" alpha-bets class="form-control" ng-model="BORROWER_NAME">

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Father/Husband's Name :<span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" alpha-bets maxlength="50" class="form-control" ng-model="FATHER_HUSBAND_NAME">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Survey No : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" ng-model="ROFR_PATTANO" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Village : </label>
                                                <div>
                                                    <input type="text" ng-model="VILLAGE" ng-disabled="true" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Branch :</label>
                                                <input type="text" ng-disabled="true" ng-model="BRANCH_NAME" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Type Of Charge : <span style="color:red"> * </span></label>
                                                <input type="text" ng-model="TYPE_OF_CHARGE" ng-disabled="true" class="form-control" />
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Pattadar Name(owner) :</label>
                                                <input type="text" ng-disabled="true" ng-model="ROFR_PATTADAAR" class="form-control">

                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Father/Husband's Name: </label>
                                                <input type="text" ng-disabled="true" ng-model="FATHER_NAME" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Khata No: </label>
                                                <input type="text" ng-disabled="true" ng-model="COMPARTMENT_NO" class="form-control">
                                            </div>


                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Occupant Name: </label>
                                                <input type="text" ng-disabled="true" ng-model="OCCUPANT_NAME" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Father/Husband's Name: </label>
                                                <input type="text" ng-disabled="true" ng-model="OCCUPANT_FATHER_NAME" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Total Extent: </label>
                                                <input type="text" ng-disabled="true" ng-model="EXTENTPLOTAREA" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Amount : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" only-digits ng-model="LOAN_AMOUNT" class="form-control">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Crop Season : </label>
                                                <div>
                                                    <select ng-model="CROP_SEASON" class="form-control">
                                                        <option value="">Select Crop Season</option>
                                                        <option data-ng-repeat="dis in SeasonsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Name Of The Crop : </label>
                                                <div>
                                                    <select ng-model="NAME_OF_THE_CROP" class="form-control">
                                                        <option select="selected" value="">Select Name of the Crop </option>
                                                        <option data-ng-repeat="dis in CropsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Sancation Date :</label>
                                                <div>
                                                    <input type="date" ng-model="SANCTION_DATE" class="form-control">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Interest Rate :<span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" ng-model="INTEREST_RATE" class="form-control">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Amount :</label>
                                                <div>
                                                    <input type="text" only-digits ng-model="SUBSIDY_AMOUNT" class="form-control">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Date of Disbursement : <span style="color:red"> * </span></label>
                                                <input type="date" class="form-control" ng-model="DATE_OF_DISBURSEMENT">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Pattadar Aadhar No : </label>
                                                <input type="text" ng-disabled="true" class="form-control" ng-model="PATTADAR_AADHAR_NO">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Occupant Aadhar No : </label>
                                                <input type="text" ng-disabled="true" class="form-control" ng-model="OCCUPANT_AADHAR_NO">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Type Of Facility : <span style="color:red"> * </span></label>
                                                <div>
                                                    <select class="form-control" ng-model="TYPE_OF_FACILYTY">
                                                        <option value="">Choose Type Of Facility</option>
                                                        <option data-ng-repeat="dis in FacilityDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-disabled="true" ng-show="TYPE_OF_FACILYTY == 'Demand Loan/Cash Credit'">
                                                <label class="col-form-label">Due date :</label>
                                                <input type="date" class="form-control" ng-model="DUE_DATE">
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Repayment Schedule :</label>
                                                <div>
                                                    <select class="form-control" ng-model="REPAYMENT_SCHEDULE">
                                                        <option selected="selected" value="">Choose Type Of Facility</option>
                                                        <option data-ng-repeat="dis in SchedulesDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Number Of Installment :</label>
                                                <div>
                                                    <input type="text" class="form-control" maxlength="4" numbers-only ng-model="NO_OF_INSTALLMENTS" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Providing Agency :</label>
                                                <div>
                                                    <select class="form-control" ng-model="SUBSIDY_PROVIDING_AGENCY">
                                                        <option value="">Choose Subsidy Agency</option>
                                                        <option data-ng-repeat="dis in AgencyDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="SUBSIDY_PROVIDING_AGENCY == 'Other'">
                                                <label class="col-form-label">Subsidy Agency Name :</label>
                                                <input type="text" class="form-control" ng-model="SUBSIDY_AGENCY_NAME">
                                            </div>


                                            <div class="col-md-3">
                                                <label class="col-form-label">Ration Card Number :</label>
                                                <input type="text" alpha-numbers maxlength="50" class="form-control" ng-model="RATIONCARD_NO">
                                            </div>


                                            <div class="col-md-3">
                                                <label class="col-form-label">Term Loan Purpose :</label>
                                                <select class="form-control" ng-model="TERM_LOAN_PURPOSE">
                                                    <option selected="selected" value="">Select</option>
                                                    <option data-ng-repeat="dis in PurposeDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Reject Remarks : <span style="color:red"> * </span></label>
                                                <input type="text" maxlength="50" class="form-control" ng-model="CHARGE_CREATION_APP_REJ_REMARKS">
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <!--Step 2 Ending-->
                                <div class="mt-3 text-center">
                                    <button type="button" class="btn btn-success" ng-click="Modify();">Modify</button>

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
