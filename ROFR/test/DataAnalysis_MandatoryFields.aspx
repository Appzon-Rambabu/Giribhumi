<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="DataAnalysis_MandatoryFields.aspx.cs" Inherits="ROFR.test.DataAnalysis_MandatoryFields"  EnableEventValidation="false"%>
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
            <h5 class="text-center text-success mb-2 mt-3"> DATA ANALYSIS REPORT FOR MANDATORY FIELDS</h5>
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
                          <asp:TemplateField HeaderText="TOTAL FARMERS AS PER GIRIBHUMI"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
                        <%--  <asp:TemplateField HeaderText="NO. OF PLOTS HAVING AADHAR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("TOTAL_AADHARS") %>'></asp:Label>
                    </div>
            </ItemTemplate>

        </asp:TemplateField>--%>
                          <%--<asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING AADHAR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NEED_TO_UPDATE_AADHAARS") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING MANDAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_MANDAL") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING MANDAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_MANDAL") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING VILLAGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Blue" Font-Bold="True" Text='<%# Eval("HAVING_VILLAGE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING VILLAGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_VILLAGE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING GRAM PANCHAYAT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"   Font-Bold="True" Text='<%# Eval("GRAM_PANCHAYAT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING GRAM PANCHAYAT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_GRAM_PANCHAYAT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING HABITATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("Habitation") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING HABITATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_having_Habitation") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST DIVISION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_DIVISION") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST DIVISION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_DIVISION") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST RANGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_RANGE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST RANGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_RANGE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST BEAT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_BEAT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST BEAT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_BEAT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING FOREST BLOCK"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_FOREST_BLOCK") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING FOREST BLOCK"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("not_HAVING_FOREST_BLOCK") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING COMPARTMENT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_COMPARTMENT_NUMBER") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING COMPARTMENT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Red" Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_COMPARTMENT_NUMBER") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING PLOT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_PLOT_NO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING PLOT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("NOT_HAVING_PLOT_NO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING EXTENT PLOT AREA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_EXTENTPLOTAREA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING EXTENT PLOT AREA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_EXTENTPLOTAREA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING PATTA INAM/GOVT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("HAVING_PATTA_INAMGOVT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING PATTA INAM/GOVT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NOT_HAVING_PATTA_INAMGOVT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING PATTA NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_ROFR_PATTANO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING PATTA NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_ROFR_PATTANO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING ROFR PATTADAAR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_ROFR_PATTADAAR") %>'></asp:Label>
                    </div>
            </ItemTemplate>

        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING ROFR PATTADAAR"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_ROFR_PATTADAAR") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING CULTIVATOR NAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_CULTIVATOR_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING CULTIVATOR NAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red" Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_CULTIVATOR_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING HOLDING NATURE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_HOLDING_NATURE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING HOLDING NATURE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_HOLDING_NATURE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING LAND CLASSIFICATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_Land_Classification_Name") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING LAND CLASSIFICATION"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_Land_Classification_Name") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <%-- <asp:TemplateField HeaderText="NO. OF PLOTS HAVING BANK ACCOUNT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_BANKACCOUNTNO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
                         <%-- <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING BANK ACCOUNT NO."  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_BANKACCOUNTNO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
                        <%--  <asp:TemplateField HeaderText="NO. OF PLOTS HAVING IFSC CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("PLOTS_HAVING_IFSCCODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
                        <%--  <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING IFSC CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"   Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_IFSCCODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="NO. OF PLOTS HAVING ALL MANDATORY FIELDS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Blue"  Font-Bold="True" Text='<%# Eval("PLOTS_WITH_ALL_MANDATORY_FIELDS") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NO. OF PLOTS NOT HAVING ANY ONE OF THE MANDATORY FIELDS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS") %>'></asp:Label>
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

