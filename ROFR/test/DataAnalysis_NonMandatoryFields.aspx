<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="DataAnalysis_NonMandatoryFields.aspx.cs" Inherits="ROFR.test.DataAnalysis_NonMandatoryFields" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #007405;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-area">
     <div class="panel panel-body" style="margin-top:2px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
            <h5 class="text-center text-success mb-2 mt-3"> DATA ANALYSIS REPORT FOR NONMANDATORY FIELDS</h5>
         <div class="row mb-1 mt-1 justify-content-end">
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="Excel_Click" runat="server" Text="EXCEL" />
                    </div>
                </div>


            </div>
        </div>

          <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns> 
                         <asp:TemplateField HeaderText="ITDANAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="DISTRICT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="FARMERS AS PER GIRIBHUMI"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Blue" Font-Bold="True" Text='<%# Eval("TOTAL_BENEFICIARIES") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="TOTAL PLOTS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("TOTAL_PLOTS") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING MANDAL CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>

        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING MANDAL CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING VILLAGE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING VILLAGE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING GRAM PANCHAYAT CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Blue" Font-Bold="True" Text='<%# Eval("GRAM_PANCHAYAT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING GRAM PANCHAYAT CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_GRAM_PANCHAYAT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING HABITATION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("Habitation_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING HABITATION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_having_Habitation_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST DIVISION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_DIVISION_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST DIVISION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_DIVISION_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST RANGE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_RANGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST RANGE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_RANGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST BEAT CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_BEAT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST BEAT CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_BEAT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING UNCULTIVABLE LAND"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"   Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_Uncultivable_Land") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING UNCULTIVABLE LAND"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_Uncultivable_Land") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING CULTIVABLE LAND"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_Cultivable_Land") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING CULTIVABLE LAND"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NOT_HAVING_Cultivable_Land") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING WATER TAX"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_Water_Tax") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING WATER TAX"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Red" Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_Water_Tax") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING DRYID ONECROP TWOCROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_DRYID_ONECROP_TWO_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING DRYID ONECROP TWOCROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("NOT_HAVING_DRYID_ONECROP_TWO_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING WATER SOURCE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_WATER_SOURCE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING WATER SOURCE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_WATER_SOURCE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT IRRIGATED"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENT_IRRIGATED") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT IRRIGATED"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENT_IRRIGATED") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT UNDER CULTIVATOR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENT_UNDER_CULTIVATOR") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT UNDER CULTIVATOR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENT_UNDER_CULTIVATOR") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING TYPE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_TYPE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>

        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING TYPE CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_TYPE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING NET SOWN AREA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_NET_SOWN_AREA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING NET SOWN AREA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red" Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_NET_SOWN_AREA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING KHARIFF/RABI"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_KHARIFF_RABI") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING KHARIFF/RABI"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_KHARIFF_RABI") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING MONTH OF CULTIVATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_MONTH_OF_CULTIVATION") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING MONTH OF CULTIVATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_MONTH_OF_CULTIVATION") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT SINGLE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENT_SINGLE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT SINGLE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENT_SINGLE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT MIXED"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENT_MIXED") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT MIXED"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENT_MIXED") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT TOTAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue" Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENT_TOTAL") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT TOTAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENT_TOTAL") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FIRST CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_FIRST_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FIRST CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_FIRST_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                              <asp:TemplateField HeaderText="NO. OF PLOTS HAVING SECOND THIRD CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_SECOND_THIRD_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING SECOND THIRD CROP"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_SECOND_THIRD_CROP") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING CROP YIELD"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_CROP_YIELD") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING CROP YIELD"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_CROP_YIELD") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING REMARKS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_REMARKS") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING REMARKS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_REMARKS") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          
                          
                          </Columns>  
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
         </div>
</asp:Content>

