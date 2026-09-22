<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="loginhome.aspx.cs" Inherits="ROFR.test.loginhome"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
          .total-count .card{
            border: 1px solid transparent;
            background-clip: border-box;
            border-radius: 5px;
            box-shadow: 4px 3px 17px 1px rgba(0, 0, 0, 0.2)
        }
       
        .total-count .bg-primary {
        background-color: #4c7cf3 !important;
        }

        .total-count .bg-secondary {
        background-color: #777b82 !important;
        }

        .total-count .bg-success {
        background-color: #2bcd72 !important;
        }

        .total-count .bg-danger {
        background-color: #ff4b5b !important;
        }

        .total-count .bg-info {
        background-color: #0dc8b7! important;
        }

        .total-count .bg-purple {
        background-color: #7266bb !important;
        }

        .total-count .bg-orange {
        background-color: #ed8040 !important;
        }
        .total-count p{
            border-bottom:1px dashed rgba(255, 255, 255, 0.2);
            margin-bottom: 0.2rem;
            padding-bottom: 0.3rem;
        }
        .total-count h3::after{
            content: "\f115";
            position: absolute;
            right: 0;
            bottom: 0;
            font-family:'FontAwesome';
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
    <div class="panel panel-body"  style="margin-top:0px;">
  <h3 class="text-center text-dark mt-3 mb-3"><i class="fa fa-home"></i>Dashboard</h3>
                            <div class="row total-count">
                              <%--  <div class="col-md-3 mb-3">
                                    <div class="card bg-success">
                                        <div class="card-body text-center">
                                           <h2> <p class="text-white">Farmers As Per Record</p></h2>
                                             <h2 class="text-white" id="totalbenificiary" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-3 mb-3">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Farmers </p></h2>
                                          
                                             <h2 class="text-white" id="totalbeneficiaries" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                      <%--<div class="col-md-3 mb-3">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Rythu Bharosa Payment Success</p></h2>
                                            <h2 class="text-white" id="rbps" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>--%>
                               <%-- <div class="col-md-3 mb-3">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                           <h2> <p class="text-white">Rythu Bharosa Payment Failed</p></h2>
                                             <h2 class="text-white" id="rbpf" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-3 mb-3">
                                    <div class="card bg-primary">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Aadhars Updated</p></h2>
                                            <h2 class="text-white" id="aadharavaliable" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Aadhars to be Updated</p></h2>
                                            <h2 class="text-white" id="aadharnotavaliable" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="card bg-purple">
                                        <div class="card-body text-center">
                                           <h2> <p class="text-white">Valid Aadhars</p></h2>
                                            <h2 class="text-white" id="vaildaadhar" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <div class="card bg-orange">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Invalid Aadhars</p></h2>
                                           <h2 class="text-white" id="invaildaadhar" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                           <div class="col-md-3 mb-3">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Total Extent(Acres)</p></h2>
                                           <h2 class="text-white" id="extent" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                          
                            </div>
        </div>
        </div>
</asp:Content>
