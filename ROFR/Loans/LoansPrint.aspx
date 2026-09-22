<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LoansPrint.aspx.cs" Inherits="ROFR.Loans.LoansPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loans Print</title>
    <script src="JSControllers/LoansPrint.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-controller="LoansExport">
        <div class="page-content">
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
                                        <h5 class="card-title text-center text-uppercase">Loans Print</h5>
                                    </div>
                                    <div class="card-body pb-5">

                                        <div class="form-group row text-center mb-3">
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

                                        <div class="form-group table-wrap">
                                            <table class="table table-bordered mb-3" style="max-height: 300px;" id="ExportLoans">
                                                <thead class="text-white" style="text-align: center; background: #004085">
                                                    <tr>
                                                        <th>Action</th>
                                                        <th>Account No</th>
                                                        <th>Khata No</th>
                                                        <th>Survey No</th>
                                                        <th>Pattadar Name</th>
                                                        <th>Pattadar Father Name</th>
                                                        <th>Occupant Name</th>
                                                        <th>Occupant FatherName</th>
                                                        <th>Pattadaar Aadhaar No</th>
                                                        <th>Total Extent</th>
                                                        <th>Crop Extent</th>
                                                        <th>Borrower Name</th>
                                                        <th>Father/Husband Name</th>
                                                        <th>Borrower Aadhaar No</th>
                                                        <th>Type of charge</th>
                                                        <th>Crop Season</th>
                                                        <th>Crop Name</th>
                                                        <th>Loan Amount</th>
                                                        <th>Subsidy Amount</th>
                                                        <th>Interest Rate</th>
                                                        <th>Sancation Date</th>
                                                        <th>Type of Facility</th>
                                                        <th>Due Date </th>
                                                        <th>ReyPayment Schedule</th>
                                                        <th>No Of Installments</th>
                                                        <th>Loan Purpose</th>
                                                        <th>Ration Card No</th>
                                                        <th>Subsidy Agency</th>
                                                        <th>Date Of Disbursement</th>
                                                        <th>Approved By</th>
                                                        <th>Approved On</th>
                                                        <th>Approved Remarks</th>
                                                    </tr>
                                                </thead>

                                                <tbody style="text-align: center">
                                                    <tr data-ng-repeat="par in PattadarTable">
                                                        <td><a style="text-decoration: underline; cursor: pointer;" ng-click="GetPattadarDetails(par.LAND_ID);">Select</a></td>
                                                        <td>{{par.LOAN_ACCOUNTNO}} </td>
                                                        <td>{{par.KHATA_NO}}</td>
                                                        <td>{{par.SURVEY_NO}}</td>
                                                        <td>{{par.ROFR_PATTADAAR}} </td>
                                                        <td>{{par.FATHER_NAME}} </td>
                                                        <td>{{par.OCCUPANT_NAME}} </td>
                                                        <td>{{par.OCCUPANT_FATHER_NAME}} </td>
                                                        <td>{{par.PATTADAR_AADHAAR_NO}}</td>
                                                        <td>{{par.TOTAL_EXTENT}}</td>
                                                        <td>{{par.CROP_EXTENT}}</td>
                                                        <td>{{par.BORROWER_NAME}} </td>
                                                        <td>{{par.FATHER_HUSBAND_NAME}} </td>
                                                        <td>{{par.BORROWER_AADHAAR_NO}} </td>
                                                        <td>{{par.TYPE_OF_CHARGE}} </td>
                                                        <td>{{par.CROP_SEASON}} </td>
                                                        <td>{{par.CROP_NAME}} </td>
                                                        <td>{{par.LOAN_AMOUNT}} </td>
                                                        <td>{{par.SUBSIDY_AMOUNT}} </td>
                                                        <td>{{par.INTEREST_RATE}} </td>
                                                        <td>{{par.SANCTION_DATE}} </td>
                                                        <td>{{par.TYPE_OF_FACILYTY}} </td>
                                                        <td>{{par.DUE_DATE}} </td>
                                                        <td>{{par.REPAYMENT_SCHEDULE}} </td>
                                                        <td>{{par.NO_OF_INSTALLMENTS}} </td>
                                                        <td>{{par.LOAN_PURPOSE}} </td>
                                                        <td>{{par.RATIONCARD_NO}} </td>
                                                        <td>{{par.SUBSIDY_AGENCY}} </td>
                                                        <td>{{par.DATE_OF_DISBURSEMENT}} </td>
                                                        <td>{{par.APPROVED_BY}} </td>
                                                        <td>{{par.APPROVED_ON}} </td>
                                                        <td>{{par.APPROVED_REMARKS}} </td>

                                                    </tr>
                                                </tbody>

                                            </table>
                                        </div>

                                        <div>
                                            <!--Step 1 Starting-->
                                            <div>
                                                <!--Main Fieldset-->
                                                <fieldset>
                                                    <legend class="w-auto">Pattadar Details
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
                                                    <legend class="w-auto">Borrower Details
                                                    </legend>
                                                    <div class="form-group row mb-3">
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Type Of Loan : <span style="color: red">* </span></label>
                                                            <div>
                                                                <input type="text" ng-disabled="true" class="form-control" ng-model="TYPE_OF_CHARGE">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Loan Account No : <span style="color: red">* </span></label>
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
                                                            <label class="col-form-label">Borrower Name : <span style="color: red">* </span></label>
                                                            <div>
                                                                <input type="text" ng-model="BORROWER_NAME" ng-disabled="true" class="form-control">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Father/Husband's Name : <span style="color: red">* </span></label>
                                                            <div>
                                                                <input type="text" ng-model="FATHER_HUSBAND_NAME" ng-disabled="true" class="form-control">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Borrower Aadhar Number :</label>
                                                            <input type="text" numbers-only maxlength="12" ng-disabled="true" ng-model="BORROWER_AADHAAR_NO" class="form-control">
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label class="col-lg-12 col-form-label">Crop Season : <span style="color: red">* </span></label>
                                                            <select class="form-control" ng-disabled="true" ng-model="CROP_SEASON">
                                                                <option selected="selected" value="">Choose Season</option>
                                                                <option data-ng-repeat="dis in SeasonsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                            </select>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-lg-12 col-form-label">Name Of The Crop : <span style="color: red">* </span></label>
                                                            <select class="form-control" ng-disabled="true" ng-model="NAME_OF_THE_CROP">
                                                                <option value="">Choose Name of the Crop</option>
                                                                <option data-ng-repeat="dis in CropsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                            </select>

                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-lg-12 col-form-label">Sanction Date : <span style="color: red">* </span></label>
                                                            <input type="date" ng-model="SANCTION_DATE" ng-disabled="true" class="form-control">
                                                        </div>


                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Loan Amount : <span style="color: red">* </span></label>
                                                            <div>
                                                                <input type="text" only-digits ng-model="LOAN_AMOUNT" ng-disabled="true" class="form-control">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Subsidy Amount :</label>
                                                            <div>
                                                                <input type="text" only-digits ng-model="SUBSIDY_AMOUNT" ng-disabled="true" class="form-control">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Interest Rate : <span style="color: red">* </span></label>
                                                            <input type="text" only-digits ng-model="INTEREST_RATE" ng-disabled="true" class="form-control">
                                                        </div>
                                                    </div>

                                                    <div class="form-group row mb-3">
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Type Of Facility : <span style="color: red">* </span></label>
                                                            <div>
                                                                <select class="form-control" ng-disabled="true" ng-model="TYPE_OF_FACILYTY">
                                                                    <option value="">Choose Type Of Facility</option>
                                                                    <option data-ng-repeat="dis in FacilityDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Demand Loan/Cash Credit'">
                                                            <label class="col-form-label">Due date :</label>
                                                            <input type="date" ng-disabled="true" class="form-control" ng-model="DUE_DATE">
                                                        </div>
                                                        <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
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
                                                                <input type="text" class="form-control" ng-disabled="true" maxlength="4" numbers-only ng-model="NO_OF_INSTALLMENTS" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Subsidy Providing Agency :</label>
                                                            <div>
                                                                <select class="form-control" ng-disabled="true" ng-model="SUBSIDY_PROVIDING_AGENCY">
                                                                    <option value="">Choose Subsidy Agency</option>
                                                                    <option data-ng-repeat="dis in AgencyDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>

                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3" ng-show="SUBSIDY_PROVIDING_AGENCY == 'Other'">
                                                            <label class="col-form-label">Subsidy Agency Name :</label>
                                                            <input type="text" class="form-control" ng-disabled="true" ng-model="SUBSIDY_AGENCY_NAME">
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Date of Disbursement : <span style="color: red">* </span></label>
                                                            <input type="date" class="form-control" ng-disabled="true" ng-model="DATE_OF_DISBURSEMENT">
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Ration Card Number :</label>
                                                            <input type="text" alpha-numbers maxlength="50" ng-disabled="true" class="form-control" ng-model="RATIONCARD_NO">
                                                        </div>
                                                        <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                            <label class="col-form-label">Term Loan Purpose :</label>
                                                            <select class="form-control" ng-disabled="true" ng-model="TERM_LOAN_PURPOSE">
                                                                <option selected="selected" value="">Select</option>
                                                                <option data-ng-repeat="dis in PurposeDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                            </select>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Approved By :</label>
                                                            <input type="text" maxlength="50" ng-disabled="true" class="form-control" ng-model="APPROVED_BY">
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Approved On :</label>
                                                            <input type="text" maxlength="50" ng-disabled="true" class="form-control" ng-model="APPROVED_ON">
                                                        </div>

                                                        <div class="col-md-3">
                                                            <label class="col-form-label">Approval Remarks : <span style="color: red">* </span></label>
                                                            <input type="text" maxlength="50" ng-disabled="true" class="form-control" ng-model="APPROVED_REMARKS">
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>
                                        <!--Step 2 Ending-->
                                        <div class="mt-3 text-center">
                                            <button type="button" class="btn btn-success" ng-click="Exportexcel();">Export To Excel</button>
                                            <button type="button" class="btn btn-success" ng-click="Print();">Print</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div id="printdiv" ng-show="isShowPrint">
            <div class="col-md-12">
                <fieldset style="border: 2px solid gray !important; border-radius: 3px; padding: 10px 15px!important;">
                    <legend class="w-auto" style="padding: 5px;">Pattadar Details</legend>
                    <div class="row" style="font-size: 16px;">
                        <div class="form-group col-md-3">
                            <label class="mb-0">Pattadar Name(Owner) :</label><br />
                            <span><b>{{PRINT_ROFR_PATTADAAR}}</b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Father/Husband's Name :</label><br />
                            <span><b>{{PRINT_FATHER_NAME}}</b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Pattadar Aadhar No :</label><br />
                            <span><b>{{PRINT_AADHAAR_NO}} </b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">ROFR Patta No :</label><br />
                            <span><b>{{PRINT_ROFR_PATTANO}} </b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Occupant Name :</label><br />
                            <span><b>{{PRINT_OCCUPANT_NAME}} </b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Father/Husband's Name :</label><br />
                            <span><b>{{PRINT_OCCUPANT_FATHER_NAME}} </b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Total Extent :</label><br />
                            <span><b>{{PRINT_EXTENTPLOTAREA}} </b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Crop Extent :</label><br />
                            <span><b>{{PRINT_CROP_EXTENT}} </b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">VILLAGE :</label><br />
                            <span><b>{{PRINT_VILLAGE}} </b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Branch :</label><br />
                            <span><b>{{PRINT_BRANCH}} </b></span>
                        </div>
                    </div>
                </fieldset>
                <br />


                <fieldset style="border: 2px solid gray !important; border-radius: 3px; padding: 10px 15px!important;">
                    <legend class="w-auto" style="padding: 5px;">Pattadar Details</legend>
                    <div class="row" style="font-size: 16px;">
                        <div class="form-group col-md-3">
                            <label class="mb-0">Type Of Loan :</label><br />
                            <span><b>{{PRINT_TYPE_OF_CHARGE}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Loan Account No :</label><br />
                            <span><b>{{PRINT_LOAN_ACCOUNTNO}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Saving Bank Account No :</label><br />
                            <span><b>{{PRINT_SAVING_BANKACCOUNTNO}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Borrower Name :</label><br />
                            <span><b>{{PRINT_BORROWER_NAME}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Father/Husband's Name :</label><br />
                            <span><b>{{PRINT_FATHER_HUSBAND_NAME}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Borrower Aadhar Number :</label><br />
                            <span><b>{{PRINT_BORROWER_AADHAAR_NO}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Crop Season :</label><br />
                            <span><b>{{PRINT_CROP_SEASON}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Name Of The Crop :</label><br />
                            <span><b>{{PRINT_NAME_OF_THE_CROP}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Sanction Date :</label><br />
                            <span><b>{{PRINT_SANCTION_DATE}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Loan Amount :</label><br />
                            <span><b>{{PRINT_LOAN_AMOUNT}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Subsidy Amount :</label><br />
                            <span><b>{{PRINT_SUBSIDY_AMOUNT}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Interest Rate :</label><br />
                            <span><b>{{PRINT_INTEREST_RATE}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Type Of Facility :</label><br />
                            <span><b>{{PRINT_TYPE_OF_FACILYTY}}</b></span>
                        </div>

                        <div class="form-group col-md-3" ng-show="TYPE_OF_FACILYTY == 'Demand Loan/Cash Credit'">
                            <label class="mb-0">Due Date :</label><br />
                            <span><b>{{PRINT_DUE_DATE}}</b></span>
                        </div>

                        <div class="form-group col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                            <label class="mb-0">Repament Schedule :</label><br />
                            <span><b>{{PRINT_REPAYMENT_SCHEDULE}}</b></span>
                        </div>

                        <div class="form-group col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                            <label class="mb-0">Number Of Installment :</label><br />
                            <span><b>{{PRINT_NO_OF_INSTALLMENTS}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Subsidy Providing Agency :</label><br />
                            <span><b>{{PRINT_SUBSIDY_PROVIDING_AGENCY}}</b></span>
                        </div>

                        <div class="form-group col-md-3" ng-show="SUBSIDY_PROVIDING_AGENCY == 'Other'">
                            <label class="mb-0">Subsidy Agency Name:</label><br />
                            <span><b>{{PRINT_SUBSIDY_AGENCY_NAME}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Ration Card Number :</label><br />
                            <span><b>{{PRINT_RATIONCARD_NO}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Date of Disbursement :</label><br />
                            <span><b>{{PRINT_DATE_OF_DISBURSEMENT}}</b></span>
                        </div>

                        <div class="form-group col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                            <label class="mb-0">Term Loan Purpose :</label><br />
                            <span><b>{{PRINT_TERM_LOAN_PURPOSE}}</b></span>
                        </div>

                        <div class="form-group col-md-3">
                            <label class="mb-0">Approved By :</label><br />
                            <span><b>{{PRINT_APPROVED_BY}}</b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Approved On :</label><br />
                            <span><b>{{PRINT_APPROVED_ON}}</b></span>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="mb-0">Approval Remarks :</label><br />
                            <span><b>{{PRINT_APPROVED_REMARKS}}</b></span>
                        </div>
                    </div>
                </fieldset>
            </div>

        </div>

    </div>
</asp:Content>
