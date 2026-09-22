<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="SearchByCompartmentNo.aspx.cs" Inherits="ROFR.Loans.SearchByCompartmentNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loans Search By Compartment No</title>
    <script src="JSControllers/SearchByCompartmentNo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="SearchByCompartmentNo">
    <div data-ng-show="preloader" class="loader"></div>
    <!-- Main content -->
    <div class="content-wrapper">
        <!-- Content area -->
        <div class="content">
            <div class="container-fluid">
                <div class="row mb-2 justify-content-center">
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header bg-indigo py-1">
                                <h5 class="card-title text-center text-uppercase">Loans Search By Compartment No</h5>
                            </div>
                            <div class="card-body pb-5">

                                <div class="form-group row mb-3">
                                    <label class="col-lg-2 col-form-label">District : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelDistrict" ng-change="DistrictChange();">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in DistrictsDD" value="{{dis.DISTRICT}}">{{dis.DISTRICT}}</option>
                                        </select>
                                    </div>
                                    <label class="col-lg-2 col-form-label">Forest Division : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelDivision" ng-change="DivisionChange()">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in DivisionDD" value="{{dis.FOREST_DIVISION}}">{{dis.FOREST_DIVISION}}</option>
                                        </select>
                                    </div>
                                    <label class="col-lg-2 col-form-label">Forest Range : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelRange" ng-change="RangeChange()">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in RangeDD" value="{{dis.FOREST_RANGE}}">{{dis.FOREST_RANGE}}</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="form-group row mb-3">
                                    <label class="col-lg-2 col-form-label">Forest Beat : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelBeet" ng-change="BeetChange()">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in BeetDD" value="{{dis.FOREST_BEAT}}">{{dis.FOREST_BEAT}}</option>
                                        </select>
                                    </div>
                                    <label class="col-lg-2 col-form-label">Block : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelBlock" ng-change="BlockChange()">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in BlockDD" value="{{dis.FOREST_BLOCK}}">{{dis.FOREST_BLOCK}}</option>
                                        </select>
                                    </div>
                                    <label class="col-lg-2 col-form-label">Compartment No : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelCompartment">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in CompartmentDD" value="{{dis.COMPARTMENT_NO}}">{{dis.COMPARTMENT_NO}}</option>
                                        </select>
                                    </div>

                                    <div class="col-lg-12 text-center mt-2">
                                        <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Get Details</button>
                                    </div>
                                </div>

                                <div class="form-group table-wrap">
                                    <table class="table table-bordered mb-3" style="max-height:300px;">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Action</th>
                                                <th>Loan Status</th>
                                                <th>Branch</th>
                                                <th>Loan Account No</th>
                                                <th>Account Name</th>
                                                <th>Account Father Name</th>
                                                <th>Survey No</th>
                                                <th>Pattadar Name</th>
                                                <th>Pattadar Father Name</th>
                                                <th>Pattadar Aadhaar No</th>
                                                <th>Khata No.</th>
                                                <th>Plot No.</th>
                                                <th>Occupant Name</th>
                                                <th>Occupant FatherName</th>
                                                <th>Extent Plot Area</th>
                                                <th>Crop Name</th>
                                                <th>Loan Amount</th>
                                                <th>Date Of Disbursment</th>
                                                <th>Due Date</th>
                                                <th>Loan Created On</th>
                                                <th>Loan Approval On</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in PattadarTable">
                                                <td><a style="text-decoration: underline; cursor: pointer;" ng-click="GetPattadarDetails(par.LAND_ID);">Select</a></td>
                                                <td>  {{par.CHARGE_STATUS}} </td>
                                                <td>  {{par.BRANCH}} </td>
                                                <td>  {{par.LOAN_ACCOUNTNO}} </td>
                                                <td>  {{par.BORROWER_NAME}} </td>
                                                <td>  {{par.ACCOUNT_FATHER_NAME}} </td>
                                                <td>  {{par.SURVEY_NO}} </td>
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
                                                <td>  {{par.CHARGE_CREATED_ON}} </td>
                                                <td>  {{par.CHARGE_CREATION_APP_DATE}} </td>
                                            </tr>
                                        </tbody>

                                    </table>
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
                                                <label class="col-form-label">Katha No :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="KHATHA_NO">
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
                                                <label class="col-lg-12 col-form-label">Survey No :</label>
                                                <input type="text" class="form-control" ng-disabled="true" ng-model="SURVEY_NO">
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
                                                <label class="col-form-label">Type Of Loan : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" class="form-control" ng-model="TYPE_OF_CHARGE">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Account No : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" class="form-control" ng-model="LOAN_ACCOUNTNO">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Saving Bank Account No :</label>
                                                <div>
                                                    <input type="text" ng-disabled="true" class="form-control" ng-model="SAVING_BANKACCOUNTNO">
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Borrower Name : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" ng-model="BORROWER_NAME" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Father/Husband's Name : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" ng-model="FATHER_HUSBAND_NAME" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Borrower Aadhar Number :</label>
                                                <input type="text" ng-disabled="true" maxlength="12" ng-model="BORROWER_AADHAAR_NO" class="form-control">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Crop Season : </label>
                                                <select ng-disabled="true" class="form-control" ng-model="CROP_SEASON">
                                                    <option selected="selected" value="">Choose Season</option>
                                                    <option data-ng-repeat="dis in SeasonsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Name Of The Crop : </label>
                                                <select ng-disabled="true" class="form-control" ng-model="NAME_OF_THE_CROP">
                                                    <option value="">Choose Name of the Crop</option>
                                                    <option data-ng-repeat="dis in CropsDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>

                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-lg-12 col-form-label">Sanction Date : </label>
                                                <input type="date" ng-disabled="true" ng-model="SANCTION_DATE" class="form-control">
                                            </div>


                                            <div class="col-md-3">
                                                <label class="col-form-label">Loan Amount : </label>
                                                <div>
                                                    <input type="text" ng-disabled="true" ng-model="LOAN_AMOUNT" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Amount :</label>
                                                <div>
                                                    <input type="text" ng-disabled="true" ng-model="SUBSIDY_AMOUNT" class="form-control">
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Interest Rate : </label>
                                                <input type="text" ng-disabled="true" ng-model="INTEREST_RATE" class="form-control">
                                            </div>
                                        
                                            <div class="col-md-3">
                                                <label class="col-form-label">Type Of Facility : </label>
                                                <div>
                                                    <select ng-disabled="true" class="form-control" ng-model="TYPE_OF_FACILYTY">
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
                                                    <select ng-disabled="true" class="form-control" ng-model="REPAYMENT_SCHEDULE">
                                                        <option selected="selected" value="">Choose Type Of Facility</option>
                                                        <option data-ng-repeat="dis in SchedulesDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Number Of Installment :</label>
                                                <div>
                                                    <input type="text" class="form-control" ng-disabled="true" ng-model="NO_OF_INSTALLMENTS" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Subsidy Providing Agency :</label>
                                                <div>
                                                    <select ng-disabled="true" class="form-control" ng-model="SUBSIDY_PROVIDING_AGENCY">
                                                        <option value="">Choose Subsidy Agency</option>
                                                        <option data-ng-repeat="dis in AgencyDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-3" ng-show="SUBSIDY_PROVIDING_AGENCY == 'Other'">
                                                <label class="col-form-label">Subsidy Agency Name :</label>
                                                <input type="text" ng-disabled="true" class="form-control" ng-model="SUBSIDY_AGENCY_NAME">
                                            </div>

                                            <div class="col-md-3">
                                                <label class="col-form-label">Date of Disbursement : </label>
                                                <input type="date" ng-disabled="true" class="form-control" ng-model="DATE_OF_DISBURSEMENT">
                                            </div>
                                            <div class="col-md-3">
                                                <label class="col-form-label">Ration Card Number :</label>
                                                <input type="text" ng-disabled="true" maxlength="50" class="form-control" ng-model="RATIONCARD_NO">
                                            </div>
                                            <div class="col-md-3" ng-show="TYPE_OF_FACILYTY == 'Term Loan'">
                                                <label class="col-form-label">Term Loan Purpose : </label>
                                                <select ng-disabled="true" class="form-control" ng-model="TERM_LOAN_PURPOSE">
                                                    <option selected="selected" value="">Select</option>
                                                    <option data-ng-repeat="dis in PurposeDD" value="{{dis.DROPDOWN_VALUE}}">{{dis.DROPDOWN_VALUE}}</option>
                                                </select>
                                            </div>

                                        </div>
                                    </fieldset>
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
