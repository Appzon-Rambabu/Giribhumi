<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giripragathi.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GetOracleData.aspx.cs" Inherits="ROFR.test.GetOracleData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
            <h5 class="text-center text-success mb-2 mt-3">BENEFICIARIES DATA ANALYSIS REPORT</h5>
         <div class="row mb-1 mt-1 justify-content-end">
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>
                </div>


            </div>
        </div>
    <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>
             </div>
              </div>
        </div>
           </div>
</asp:Content>
