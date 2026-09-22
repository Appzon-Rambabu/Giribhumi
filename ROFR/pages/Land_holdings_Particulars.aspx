<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Land_holdings_Particulars.aspx.cs" Inherits="ROFR.pages.Land_holdings_Particulars"EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:  #1F5C99;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
            <h5 class="text-center text-success mb-2 mt-3">LAND HOLDINGS PARTICULARS</h5>
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
                        
                          <asp:TemplateField HeaderText="DISTRICT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("DIST_NAME_EN") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="ITDA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Green" Font-Bold="True" Text='<%# Eval("ITDA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Total families in Scheduled area (as per Rice cards) (a)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("TOTAL_FAMILIES_ST_RC") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                          <asp:TemplateField HeaderText="Total In-eligible (b)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("TOTAL_IN_ELIGIBLE_FAM") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Total eligible families for suvey(a-b)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("TOTAL_ELIGIBLE_FAMILIES") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Land holding >2 acres (c)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  ForeColor="Green" Font-Bold="True" Text='<%# Eval("GREATER_THAN_2_ACRES") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Land holding <2 acres (d)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("LESS_THAN_2_ACRES") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Land holding Total (c+d)"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"   Font-Bold="True" Text='<%# Eval("TOTAL_G2_AND_L2") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Claims pending for approval"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("CLAIMS_PEND_APPROVAL") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="No Land Available for Allotment"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Green"  Font-Bold="True" Text='<%# Eval("NOLAND_AVAILABLE_FOR_ALLOT") %>'></asp:Label>
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
</asp:Content>
