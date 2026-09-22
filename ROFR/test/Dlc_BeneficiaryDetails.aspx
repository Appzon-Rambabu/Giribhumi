<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Dlc_BeneficiaryDetails.aspx.cs" Inherits="ROFR.test.Dlc_BeneficiaryDetails" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #3366CC !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: midnightblue;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
                   <div class="panel panel-body" style="margin-top:150px;"> 
                        <h5 class="text-center text-success mb-4 mt-3">BENEFICIARY DLC DETAILS</h5>
    <div class="row justify-content-center" style="text-align:right">
              <div class="table-responsive">

       <div class="headertable">




     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>   
                             
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>   
                         <asp:TemplateField HeaderText=" DIVISION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_DivisionCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                      
                     <asp:TemplateField HeaderText="DIVISION NAME " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_Division") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="RANGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_RangeCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="RANGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4"   Font-Bold="True" Text='<%# Eval("Forest_Range") %>' runat="server" />
 
            </ItemTemplate>
        </asp:TemplateField>
                      <asp:TemplateField HeaderText="BEAT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl5" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_BeatCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="BEAT NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Beat") %>' runat="server" />
        
            </ItemTemplate>

        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl7" runat="server"  Font-Bold="True" Text='<%# Eval("Village_Code") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GRAMPANCHAYAT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl11" runat="server"  Font-Bold="True" Text='<%# Eval("Gram_Panchayat") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="VILLAGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl12" runat="server"  Font-Bold="True" Text='<%# Eval("Village") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 

         <asp:TemplateField HeaderText="HABITATION" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl13" runat="server"  Font-Bold="True" Text='<%# Eval("Habitation") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="FOREST BLOCK" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl14" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_Block") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="COMPARTMENT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl15" runat="server"  Font-Bold="True" Text='<%# Eval("Compartment_No") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PLOT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl16" runat="server"  Font-Bold="True" Text='<%# Eval("Plot_No") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="EXTENT PLOT AREA" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl17" runat="server"  Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="PATTA INAM GOVT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl18" runat="server"  Font-Bold="True" Text='<%# Eval("PATTA_INAMGOVT") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="ROFR PATTA NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl19" runat="server"  Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="ROFR PATTADAAR" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl20" runat="server"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="HOLDING NATURE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl21" runat="server"  Font-Bold="True" Text='<%# Eval("HOLDING_NATURE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 

                         <asp:TemplateField HeaderText="Dlc Date" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl22" runat="server" Width="100"  Font-Bold="True" Text='<%# Eval("Dlc_date") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="DLC" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                         <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Id") %>' runat="server" Font-Underline="true"  Width="75" OnClick="Linkview_Click">View DLC</asp:LinkButton>
               
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
    </div></div>

</asp:Content>
