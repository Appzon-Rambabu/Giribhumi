<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="LoansByBranch.aspx.cs" Inherits="ROFR.Loans.LoansByBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Loans By Branch Wise Summary</title>
    <script src="JSControllers/LoansByBranch.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" ng-controller="LoansByBranch">
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
                                <h5 class="card-title text-center text-uppercase">Loans By Branch Wise Summary</h5>
                            </div>
                            <div class="card-body pb-5">
                                <div class="col-lg-12 text-center mt">
                                    <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="1" checked />
                                    <label>Entered</label>
                                    <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="2" />
                                    <label>Approved</label>
                                    <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="3" />
                                    <label>Released</label>
                                    <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="4" />
                                    <label>Not Released</label>
                                    <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="5" />
                                    <label>All</label>
                                </div>

                                <div class="form-group row mb-3">
                                    <label class="col-lg-2 col-form-label">Bank Name : <span style="color:red"> * </span></label>
                                    <div class="col-lg-2">
                                        <select class="form-control" ng-model="SelBank">
                                            <option selected="selected" value="">-Select-</option>
                                            <option data-ng-repeat="dis in BankDD" value="{{dis.BANKNAME}}">{{dis.BANKNAME}}</option>
                                        </select>
                                    </div>
                                    <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Get Details</button>

                                </div>

                                <div class="form-group col-lg-16">
                                    <table class="table table-bordered mb-3" style="max-height:300px;" ng-show="Bank_TableData">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                               
                                                <th>Bank Name</th>
                                                <th>Branch Name</th>
                                                <th>Total Loans</th>
                                                <th>Total Survey Numbers</th>
                                                <th>Total Farmers</th>
                                                <th>Total Extent</th>
                                                <th>Amount</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in UserTable">
                                                
                                                <td>{{par.BANKNAME}}</td>
                                                <td><a style="text-decoration: underline; cursor: pointer;color:red;" ng-click="GetBranchDetails(par.BRANCH_NAME);">{{par.BRANCH_NAME}}</a></td>
                                                <td>{{par.TOTAL_LOANS}}</td>
                                                <td>{{par.TOTAL_SURVEY_NUMBERS}}</td>
                                                <td>{{par.TOTAL_FARMERS}}</td>
                                                <td>{{par.TOTAL_EXTENT}}</td>
                                                <td>{{par.AMOUNT}}</td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>

                                <div class="form-group col-lg-16">
                                    <table class="table table-bordered mb-3" style="max-height:300px;" ng-show="Branch_TableData">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Bank Name</th>
                                                <th>Branch Name</th>
                                                <th>Division range beat block</th>
                                                <th> Survey Number</th>
                                                <th>ROFR Pattadaar</th>
                                                <th>Father Name</th>
                                                <th>Loan Created On</th>
                                                <th>Loan Account No</th>
                                                <th>Amount</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in UserBranchWise">
                                                <td>{{par.BANKNAME}}</td>
                                                <td>{{par.BRANCH_NAME}}</td>
                                                <td>{{par.DIVISION_RANGE_BEAT_BLOCK}}</td>
                                                <td>{{par.SURVEY_NO}}</td>
                                                <td>{{par.ROFR_PATTADAAR}}</td>
                                                <td>{{par.FATHER_NAME}}</td>
                                                <td>{{par.LOAN_CREATED_ON}}</td>
                                                <td>{{par.LOAN_ACCOUNTNO}}</td>
                                                <td>{{par.AMOUNT}}</td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>

                                <!-- All Data Table Start -->

                                <div class="form-group col-lg-16">
                                    <table class="table table-bordered mb-3" style="max-height:300px;" ng-show="AllLoans">
                                        <thead class="text-white" style="text-align:center;background: #004085">
                                            <tr>
                                                <th>Bank Name</th>
                                                <th>Branch Name</th>
                                                <th>Entered Loans</th>
                                                <th>Approved Loans</th>
                                                <th>Entered Survey Numbers</th>
                                                <th>Approved Survey Numbers</th>
                                                <th>Entere Farmers</th>
                                                <th>Approved Farmers</th>
                                                <th>Entered Extent</th>
                                                <th>Approved Extent</th>
                                                <th>Entered Amount</th>
                                                <th>Approved Amount</th>
                                            </tr>
                                        </thead>

                                        <tbody style="text-align:center">
                                            <tr data-ng-repeat="par in AllBankWiseData">
                                                <td>{{par.BANKNAME}}</td>
                                                <td>{{par.BRANCH_NAME}}</td>
                                                <td>{{par.ENTERED_LOANS}}</td>
                                                <td>{{par.APPROVED_LOANS}}</td>
                                                <td>{{par.ENTERED_SURVEY_NUMBERS}}</td>
                                                <td>{{par.APPROVED_SURVEY_NUMBERS}}</td>
                                                <td>{{par.ENTERED_FARMERS}}</td>
                                                <td>{{par.APPROVED_FARMERS}}</td>
                                                <td>{{par.ENTERED_EXTENT}}</td>
                                                <td>{{par.APPROVED_EXTENT}}</td>
                                                <td>{{par.ENTERED_AMOUNT}}</td>
                                                <td>{{par.APPROVED_AMOUNT}}</td>
                                            </tr>
                                        </tbody>

                                    </table>
                                </div>

                                <!-- All Data Table Start -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
