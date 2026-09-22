<%@ Page Title="" Language="C#" MasterPageFile="~/Loans/Loans.Master" AutoEventWireup="true" CodeBehind="ForestAdangal.aspx.cs" Inherits="ROFR.Loans.ForestAdangal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Forest Adangal</title>
    <script src="JSControllers/ForestAdangal.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content" ng-controller="ForestAdangal">
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
                                    <h5 class="card-title text-center text-uppercase">Forest Adangal</h5>
                                </div>
                                <div class="card-body pb-5">
                                    <div class="col-lg-12 text-center mt">
                                        <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="1" checked />
                                        <label>Compartment No</label>
                                        <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="2" />
                                        <label>Aadhar No</label>
                                        <input type="radio" name="radio_btn" ng-change="ChangeOption();" ng-model="Radio_sel" value="3" />
                                        <label>Pattadar Name</label>
                                    </div>

                                    <div class="form-group row mb-1">
                                        <label class="col-lg-2 col-form-label">District : <span style="color: red">* </span></label>
                                        <div class="col-lg-2">
                                            <select class="form-control" ng-model="SelDistrict" ng-change="DistrictChange();">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in DistrictsDD" value="{{dis.DISTRICT}}">{{dis.DISTRICT}}</option>
                                            </select>
                                        </div>
                                        <label class="col-lg-2 col-form-label">Forest Division : <span style="color: red">* </span></label>
                                        <div class="col-lg-2">
                                            <select class="form-control" ng-model="SelDivision" ng-change="DivisionChange()">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in DivisionDD" value="{{dis.FOREST_DIVISION}}">{{dis.FOREST_DIVISION}}</option>
                                            </select>
                                        </div>
                                        <label class="col-lg-2 col-form-label">Forest Range : <span style="color: red">* </span></label>
                                        <div class="col-lg-2">
                                            <select class="form-control" ng-model="SelRange" ng-change="RangeChange()">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in RangeDD" value="{{dis.FOREST_RANGE}}">{{dis.FOREST_RANGE}}</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="form-group row mb-1">
                                        <label class="col-lg-2 col-form-label">Forest Beat : <span style="color: red">* </span></label>
                                        <div class="col-lg-2">
                                            <select class="form-control" ng-model="SelBeet" ng-change="BeetChange()">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in BeetDD" value="{{dis.FOREST_BEAT}}">{{dis.FOREST_BEAT}}</option>
                                            </select>
                                        </div>
                                        <label class="col-lg-2 col-form-label">Block : <span style="color: red">* </span></label>
                                        <div class="col-lg-2">
                                            <select class="form-control" ng-model="SelBlock" ng-change="BlockChange()">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in BlockDD" value="{{dis.FOREST_BLOCK}}">{{dis.FOREST_BLOCK}}</option>
                                            </select>
                                        </div>
                                        <label class="col-lg-2 col-form-label" ng-show="Radio_sel =='1'">Compartment No : <span style="color: red">* </span></label>
                                        <div class="col-lg-2" ng-show="Radio_sel =='1'">
                                            <select class="form-control" ng-model="SelCompartment">
                                                <option selected="selected" value="">-Select-</option>
                                                <option data-ng-repeat="dis in CompartmentDD" value="{{dis.COMPARTMENT_NO}}">{{dis.COMPARTMENT_NO}}</option>
                                            </select>
                                        </div>

                                        <label class="col-lg-2 col-form-label" ng-show="Radio_sel =='2'">Aadhar No :</label>
                                        <div class="col-lg-2" ng-show="Radio_sel =='2'">
                                            <input type="text" class="form-control" numbers-only maxlength="12" ng-model="Aadhar_No" />
                                        </div>

                                        <label class="col-lg-2 col-form-label" ng-show="Radio_sel =='3'">Pattadar Name :</label>
                                        <div class="col-lg-2" ng-show="Radio_sel =='3'">
                                            <select class="form-control" ng-model="Pattadar_Name">
                                                <option selected="selected" value="">-Select Pattadar Name -</option>
                                                <option ng-repeat="obj in PattadarNameDD" value="{{obj.ROFR_PATTADAAR}}">{{obj.ROFR_PATTADAAR}}</option>
                                            </select>
                                        </div>

                                        <div class="col-lg-12 text-center mt-2">
                                            <button type="button" data-ng-click="GetDetails();" class="btn btn-primary">Get Details</button>
                                        </div>
                                    </div>

                                    <div class="form-group col-lg-16" ng-show="IsComShow">
                                        <table class="table table-bordered mb-3" style="max-height: 300px;">
                                            <thead class="text-white" style="text-align: center; background: #004085">
                                                <tr>
                                                    <th>Compartment No</th>
                                                    <th>ROFR Patta No</th>
                                                    <th>Pattadar Name</th>
                                                    <th>Pattadar Father Name</th>
                                                </tr>
                                            </thead>

                                            <tbody style="text-align: center">
                                                <tr data-ng-repeat="par in UserTable">
                                                    <td><a style="text-decoration: underline; cursor: pointer; color: red;" ng-click="GetAdangalDetails(par.COMPARTMENT_NO);">{{par.COMPARTMENT_NO}}</a></td>
                                                    <td>{{par.ROFR_PATTANO}}</td>
                                                    <td>{{par.ROFR_PATTADAAR}}</td>
                                                    <td>{{par.FATHER_NAME}}</td>
                                                </tr>
                                            </tbody>

                                        </table>
                                    </div>

                                    <div class="form-group" ng-show="AdnagalShow">
                                        <table class="table table-bordered mb-3" style="table-layout: fixed;">
                                            <thead class="text-white" style="text-align: center; background: #004085">
                                                <tr>
                                                    <th>SNO</th>
                                                    <th>Compartment No</th>
                                                    <th>Total Extent</th>
                                                    <th>Uncultivable Land</th>
                                                    <th>Cultivable Land</th>
                                                    <th>Holding Nature </th>
                                                    <th>Land Classification Name </th>
                                                    <th>Patta No </th>
                                                    <th>Pattadaar Name</th>
                                                    <th>Father Name </th>
                                                    <th>Extent </th>
                                                    <th>Remarks </th>
                                                </tr>
                                            </thead>
                                            <tbody style="text-align: center">
                                                <tr data-ng-repeat="par in AdandalTable">
                                                    <td>{{par.SNO}}</td>
                                                    <td>{{par.COMPARTMENT_NO}}</td>
                                                    <td>{{par.TOTAL_EXTENT.toFixed(2)}}</td>
                                                    <td>{{par.UNCULTIVABLE_LAND.toFixed(2)}}</td>
                                                    <td>{{par.CULTIVABLE_LAND.toFixed(2)}}</td>
                                                    <td>{{par.HOLDING_NATURE}}</td>
                                                    <td>{{par.LAND_CLASSIFICATION_NAME}}</td>
                                                    <td>{{par.ROFR_PATTANO}}</td>
                                                    <td>{{par.ROFR_PATTADAAR}}</td>
                                                    <td>{{par.FATHER_NAME}}</td>
                                                    <td>{{par.EXTENT.toFixed(2)}}</td>
                                                    <td>{{par.REMARKS}}</td>
                                                </tr>
                                            </tbody>
                                        </table>

                                        <!-- <p style="font-size:12px;color:red">All the Fields are Mandatory</p>-->
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
