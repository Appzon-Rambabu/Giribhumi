<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LoanApproval.aspx.cs" Inherits="ROFR.Loans.LoanApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loan Information Approval</title>
    <script src="JSControllers/LoanApproval.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content"  ng-controller="LoanApproval">
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
                                <h5 class="card-title text-center text-uppercase">Loan Information Approval</h5>
                            </div>
                            <div class="card-body pb-5">

                                <div class="form-group row mb-1">
                                    <label class="col-lg-2 col-form-label">Account Number : </label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="ROFR_PATTADAAR_ACCOUNT_NO">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in LoanAccountsDD" value="{{dis.LOAN_ACCOUNTNO}}">{{dis.LOAN_ACCOUNTNO}}</option>
                                        </select>
                                    </div>
                                    <label class="col-lg-1 col-form-label"><span style="color:red;font-weight:bold;"> OR </span> From Date : </label>
                                    <div class="col-lg-2">
                                        <input type="date" ng-model="SEL_FROM_DATE" class="form-control">
                                    </div>
                                    <label class="col-lg-1 col-form-label"> TO Date : </label>
                                    <div class="col-lg-2">
                                        <input type="date" ng-model="SEL_TO_DATE" class="form-control">
                                    </div>
                                    <div class="col-lg-1">
                                        <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Search</button>
                                    </div>

                                </div>

                                <div class="form-group table-wrap">
                                    <table class="table table-bordered mb-3" style="max-height:300px;">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Action</th>
                                                <th>Account No</th>
                                                <th>Account Name</th>
                                                <th>Account Father Name</th>
                                                <th>Village</th>
                                                <th>Compartment No</th>
                                                <th>Pattadar Name</th>
                                                <th>Pattadar Father Name</th>
                                                <th>Pattadar Aadhaar No</th>
                                                <th>Khata No.</th>
                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Extent Plot Areat</th>
                                                <th>Crop Season</th>
                                                <th>Name Of Crop</th>
                                                <th>Loan Amount</th>
                                                <th>Date Of Disbursement</th>
                                                <th>Due Date</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in PattadarTable">
                                                <td><a style="text-decoration: underline; cursor: pointer;" ng-click="GetPattadarDetails(par.LAND_ID);">Select</a></td>
                                                <td>  {{par.LOAN_ACCOUNTNO}} </td>
                                                <td>  {{par.BORROWER_NAME}} </td>
                                                <td>  {{par.FATHER_HUSBAND_NAME}} </td>
                                                <td>  {{par.VILLAGE}} </td>
                                                <td>  {{par.COMPARTMENT_NO}} </td>
                                                <td>  {{par.ROFR_PATTADAAR}} </td>
                                                <td>  {{par.FATHER_NAME}} </td>
                                                <td>  {{par.PATTADAR_AADHAR_NO}} </td>
                                                <td>  {{par.ROFR_PATTANO}} </td>
                                                <td>  {{par.OCCUPANT_NAME}} </td>
                                                <td>  {{par.OCCUPANT_FATHER_NAME}} </td>
                                                <td>  {{par.EXTENTPLOTAREA}} </td>
                                                <td>  {{par.CROP_SEASON}} </td>
                                                <td>  {{par.NAME_OF_THE_CROP}} </td>
                                                <td>  {{par.LOAN_AMOUNT}} </td>
                                                <td>  {{par.DATE_OF_DISBURSEMENT}} </td>
                                                <td>  {{par.DUE_DATE}} </td>


                                            </tr>
                                        </tbody>

                                    </table>
                                </div>

                                <div>
                                    <input type="radio" ng-model="CurrType" ng-change="ChangeHistory();" value="1" name="radio_btn" />
                                    <label style="font-weight:bold;">On Going Loans</label>
                                    <input type="radio" ng-model="CurrType" ng-change="ChangeHistory();" value="2" name="radio_btn" />
                                    <label style="font-weight:bold;">Loans History</label>
                                </div>

                                <!-- On Going Loans Table-->
                                <div class="form-group" ng-show="CurrType == '1'">
                                    <table class="table table-bordered mb-1" style="table-layout:fixed;">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Status</th>
                                                <th>Branch Name</th>
                                                <th>A/C NO.</th>
                                                <th>Borrower Name</th>
                                                <th>Account Father Name</th>
                                                <th>Pattadar Name</th>
                                                <th>Pattadar Father Name</th>
                                                <th>Aadhaar Name</th>
                                                <th>Khata No.</th>
                                                <th>Plot No.</th>
                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Total Extent</th>
                                                <th>Name of The Crop</th>
                                                <th>Loan Amount</th>
                                                <th>Date of Disbursement</th>
                                                <th>Due Date</th>
                                            </tr>
                                        </thead>
                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in OnGoingTable">
                                                <td>{{par.CHARGE_CREATION_APP_STATUS}}</td>
                                                <td>  {{par.BRANCH}} </td>
                                                <td>  {{par.LOAN_ACCOUNTNO}} </td>
                                                <td>  {{par.BORROWER_NAME}} </td>
                                                <td>  {{par.ACCOUNT_FATHER_NAME}} </td>
                                                <td>  {{par.ROFR_PATTADAAR}} </td>
                                                <td>  {{par.PATTADAR_FATHER_NAME}} </td>
                                                <td>  {{par.PATTADAR_AADHAR_NO}} </td>
                                                <td>  {{par.KHATHA_NO}} </td>
                                                <td>  {{par.PLOT_NO}} </td>
                                                <td>  {{par.OCCUPANT_NAME}} </td>
                                                <td>  {{par.OCCUPANT_FATHER_NAME}} </td>
                                                <td>  {{par.EXTENTPLOTAREA}} </td>
                                                <td>  {{par.CROP_NAME}} </td>
                                                <td>  {{par.LOAN_AMOUNT}} </td>
                                                <td>  {{par.DATE_OF_DISBURSEMENT}} </td>
                                                <td>  {{par.DUE_DATE}} </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <!-- <p style="font-size:12px;color:red">All the Fields are Mandatory</p>-->
                                </div>

                                <!-- Loans History-->
                                <div class="form-group" ng-show="CurrType == '2'">
                                    <table class="table table-bordered mb-1" style="table-layout:fixed;padding: 0.25rem 0.25rem">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Branch Name</th>
                                                <th>A/C NO.</th>
                                                <th>Borrower Name</th>
                                                <th>Account Father Name.</th>
                                                <th>Village</th>
                                                <th>Survey No.</th>
                                                <th>Pattadar Name</th>
                                                <th>Pattadar Father Name</th>
                                                <th>Aadhaar Name</th>
                                                <th>Khata No.</th>
                                                <th>Plot No.</th>
                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Total Extent</th>
                                                <th>Crop Season</th>
                                                <th>Name of The Crop</th>
                                                <th>Loan Amount</th>
                                                <th>Date of Disbursement</th>
                                                <th>Due Date</th>
                                            </tr>
                                        </thead>
                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in HistoryTable">
                                                <td>  {{par.BRANCH}} </td>
                                                <td>  {{par.LOAN_ACCOUNTNO}} </td>
                                                <td>  {{par.BORROWER_NAME}} </td>
                                                <td>  {{par.ACCOUNT_FATHER_NAME}} </td>
                                                <td>  {{par.VILLAGE}} </td>
                                                <td>  {{par.SURVEY_NO}} </td>
                                                <td>  {{par.ROFR_PATTADAAR}} </td>
                                                <td>  {{par.PATTADAR_FATHER_NAME}} </td>
                                                <td>  {{par.PATTADAR_AADHAR_NO}} </td>
                                                <td>  {{par.KHATHA_NO}} </td>
                                                <td>  {{par.PLOT_NO}} </td>
                                                <td>  {{par.OCCUPANT_NAME}} </td>
                                                <td>  {{par.OCCUPANT_FATHER_NAME}} </td>
                                                <td>  {{par.EXTENTPLOTAREA}} </td>
                                                <td>  {{par.CROP_SEASON}} </td>
                                                <td>  {{par.CROP_NAME}} </td>
                                                <td>  {{par.LOAN_AMOUNT}} </td>
                                                <td>  {{par.DATE_OF_DISBURSEMENT}} </td>
                                                <td>  {{par.DUE_DATE}} </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <!-- <p style="font-size:12px;color:red">All the Fields are Mandatory</p>-->
                                </div>

                                <!--Step 1 Starting-->
                                <div>
                                    <!--Main Fieldset-->
                                    <fieldset>
                                        <legend class="w-auto">
                                            Pattadar Details
                                        </legend>
                                        <div class="form-group row mb-3">
                                            <div class="col-md-3">
                                                <label class="col-form-label">Pattadar Name(Owner) :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="ROFR_PATTADAAR" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Father/Husband's Name :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="FATHER_NAME">

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Pattadar Aadhar No :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="AADHAAR_NO">

                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">ROFR Patta No :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="ROFR_PATTANO">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Occupant Name :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="OCCUPANT_NAME">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Father/Husband's Name :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="OCCUPANT_FATHER_NAME">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Total Extent :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="EXTENTPLOTAREA">
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Crop Extent :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="CROP_EXTENT">
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">VILLAGE :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="VILLAGE">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Branch :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="BRANCH">
                                            </div>

                                        </div>

                                    </fieldset>

                                </div>
                                <!--Step 1 Ending-->
                                <!--Step 2 Starting-->
                                <div class="mt-2">
                                    <!--Main Fieldset-->
                                    <fieldset>
                                        <legend class="w-auto">
                                            Borrower Details
                                        </legend>
                                        <div class="form-group row mb-3">
                                            <div class="col-md-3">
                                                <label class="col-form-label">Type Of Loan : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" ng-disabled="true" class="form-control" ng-model="TYPE_OF_CHARGE">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Account No : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" alpha-numbers maxlength="50" ng-disabled="true" class="form-control" ng-model="LOAN_ACCOUNTNO">

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Saving Bank Account No :</label>
                                                <div>
                                                    <input type="text" alpha-numbers maxlength="50" ng-disabled="true" class="form-control" ng-model="SAVING_BANKACCOUNTNO">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Borrower Name : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" ng-model="BORROWER_NAME" ng-disabled="true" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Father/Husband's Name : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" ng-model="FATHER_HUSBAND_NAME" ng-disabled="true" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Borrower Aadhar Number :</label>
                                                <input type="text" numbers-only maxlength="12" ng-disabled="true" ng-model="BORROWER_AADHAAR_NO" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Crop Season : <span style="color:red"> * </span></label>
                                                <select class="form-control" ng-disabled="true" ng-model="CROP_SEASON">
                                                    <option selected="selected" value="">Choose Season</option>
                                                    <!--<option value="ఖరీఫ్">ఖరీఫ్</option>
                        <option value="రబీ">రబీ</option>-->
                                                    <option data-ng-repeat="dis in SeasonsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Name Of The Crop : <span style="color:red"> * </span></label>
                                                <select class="form-control" ng-disabled="true" ng-model="NAME_OF_THE_CROP">
                                                    <option value="">Choose Name of the Crop</option>
                                                    <option data-ng-repeat="dis in CropsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>

                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Sanction Date : <span style="color:red"> * </span></label>
                                                <input type="date" ng-disabled="true" ng-model="SANCTION_DATE" class="form-control">
                                            </div>


                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Amount : <span style="color:red"> * </span></label>
                                                <div>
                                                    <input type="text" ng-disabled="true" only-digits ng-model="LOAN_AMOUNT" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Amount :</label>
                                                <div>
                                                    <input type="text" ng-disabled="true" only-digits ng-model="SUBSIDY_AMOUNT" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Interest Rate : <span style="color:red"> * </span></label>
                                                <input type="text" only-digits ng-model="INTEREST_RATE" ng-disabled="true" class="form-control">
                                            </div>
                                        
                                            <div class="col-md-3">
                                                <label class="col-form-label">Type Of Facility : <span style="color:red"> * </span></label>
                                                <div>
                                                    <select class="form-control" ng-disabled="true" ng-model="TYPE_OF_FACILYTY">
                                                        <option value="">Choose Type Of Facility</option>
                                                        <option data-ng-repeat="dis in FacilityDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                        <!--<option value="1">Demand Loan/Cash Credit</option>
                            <option value="2">Term Loan</option>-->
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-disabled="true" ng-show="TYPE_OF_FACILYTY == 'Demand Loan/Cash Credit'">
                                                <label class="col-form-label">Due date :</label>
                                                <input type="date" class="form-control" ng-model="DUE_DATE">
                                            </div>
                                            <div class="col-md-3" ng-disabled="true" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Repayment Schedule :</label>
                                                <div>
                                                    <select class="form-control" ng-disabled="true" ng-model="REPAYMENT_SCHEDULE">
                                                        <option selected="selected" value="">Choose Type Of Facility</option>
                                                        <option data-ng-repeat="dis in SchedulesDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Number Of Installment :</label>
                                                <div>
                                                    <input type="text" ng-disabled="true" class="form-control" maxlength="4" numbers-only ng-model="NO_OF_INSTALLMENTS" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Providing Agency :</label>
                                                <div>
                                                    <select class="form-control" ng-disabled="true" ng-model="SUBSIDY_PROVIDING_AGENCY">
                                                        <option value="">Choose Subsidy Agency</option>
                                                        <option data-ng-repeat="dis in AgencyDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                        <!--<option value="1">Government of Andhra Pradesh</option>
                            <option value="2">Governement of India</option>
                            <option value="3">NABARD</option>SUBSIDY_PROVIDING_AGENCY
                            <option value="4">Other</option>-->
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="SUBSIDY_PROVIDING_AGENCY == 'Other'">
                                                <label class="col-form-label">Subsidy Agency Name :</label>
                                                <input type="text" ng-disabled="true" class="form-control" ng-model="SUBSIDY_AGENCY_NAME">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Date of Disbursement : <span style="color:red"> * </span></label>
                                                <input type="date" ng-disabled="true" class="form-control" ng-model="DATE_OF_DISBURSEMENT">
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Ration Card Number :</label>
                                                <input type="text" ng-disabled="true" alpha-numbers maxlength="50" class="form-control" ng-model="RATIONCARD_NO">
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Term Loan Purpose :</label>
                                                <select class="form-control" ng-disabled="true" ng-model="TERM_LOAN_PURPOSE">
                                                    <option selected="selected" value="">Select</option>
                                                    <option data-ng-repeat="dis in PurposeDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Entered By :</label>
                                                <input type="text" maxlength="50" ng-disabled="true" class="form-control" ng-model="CHARGE_CREATED_BY">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Entered On :</label>
                                                <input type="date" maxlength="50" ng-disabled="true" class="form-control" ng-model="CHARGE_CREATED_ON">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Approval/Reject Remarks : <span style="color:red"> * </span></label>
                                                <input type="text" maxlength="50" class="form-control" ng-model="CHARGE_CREATION_APP_REJ_REMARKS">
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <!--Step 2 Ending-->
                                <div class="mt-3 text-center">
                                    <button type="button" class="btn btn-success" ng-click="SaveData('APPROVED');">Approval</button>
                                    <button type="button" class="btn btn-secondary" ng-click="SaveData('REJECTED');">Reject</button>
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
