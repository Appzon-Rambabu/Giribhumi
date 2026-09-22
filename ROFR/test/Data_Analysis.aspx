<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Data_Analysis.aspx.cs" Inherits="ROFR.test.Data_Analysis" EnableEventValidation="false" %>
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
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText=" ITDA "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText=" DISTRICT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Total  Beneficiaries As Per Department(Static) " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_bneficiaries") %>' runat="server" />
  <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Green" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "1"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_bneficiaries") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Total  Beneficiaries Received(Giribhumi Database) By Department" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Giribhumi_beneficiaries") %>' runat="server" />
  <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Green" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "1"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_bneficiaries") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Total Plots " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("TOTAL_PLOTS") %>' runat="server" />
  <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Green" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "1"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_bneficiaries") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                         <%-- <asp:TemplateField HeaderText="No of Beneficiaries Records Having Compartment Number " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Compartment_No") %>' runat="server" />
     <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="#009900" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "2"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_Compartment_No") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Compartment Number " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("Compartment_No_Blank") %>' runat="server" />
  <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "3"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("Compartment_No_Blank") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Having Plot Number  " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Plot_No") %>' runat="server" />
          <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="#009900" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "4"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_Plot_No") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Plot Number" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Plot_No_Blank") %>' runat="server" />
          <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "5"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Plot_No_Blank") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> --%>
                     <asp:TemplateField HeaderText="No of Beneficiaries Records  Having  Pattadar Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_ROFR_PATTADAAR") %>' runat="server" />
          <asp:LinkButton ID="LinkButton4" runat="server"  Font-Bold="True" ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "6"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Total_ROFR_PATTADAAR") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Pattadar Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("ROFR_PATTDAAR_Blank") %>' runat="server" />
           <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "7"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("ROFR_PATTDAAR_Blank") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                  <%--    <asp:TemplateField HeaderText="No of Beneficiaries Records  Having Extent Plot Area " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Extent_Plot_Area") %>' runat="server" />
         <asp:LinkButton ID="LinkButton8" runat="server" Font-Bold="True"  ForeColor="#009900" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "8"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Extent_Plot_Area") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Extent Plot Area " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Extent_Plot_Area_Blank") %>' runat="server" />
          <asp:LinkButton ID="LinkButton9" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "9"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Extent_Plot_Area_Blank") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> --%>
                         <%--<asp:TemplateField HeaderText="No of Beneficiaries Records Having Fulldata " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Fulldata") %>' runat="server" />
          <asp:LinkButton ID="LinkButton10" runat="server" Font-Bold="True"  ForeColor="#009900" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "10"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Fulldata") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Fulldata " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Improperdata") %>' runat="server" />
          <asp:LinkButton ID="LinkButton11" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "11"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Improperdata") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> --%>
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Having Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Green" Font-Bold="True" Text='<%# Eval("total_received") %>' runat="server" />
          <asp:LinkButton ID="LinkButton6" runat="server" Font-Bold="True"  ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "10"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("total_received") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Having Valid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Adhharisvalid") %>' runat="server" />
          <asp:LinkButton ID="LinkButton7" runat="server" Font-Bold="True"  ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "11"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Adhharisvalid") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Having InValid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnoinvalid") %>' runat="server" />
          <asp:LinkButton ID="LinkButton8" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "12"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Adhharnoinvalid") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Having No Aadhar Numbers " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnotavaliable") %>' runat="server" />
          <asp:LinkButton ID="LinkButton9" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "13"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Adhharnotavaliable") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Beneficiaries Records  Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Bankavaliable") %>' runat="server" />
          <asp:LinkButton ID="LinkButton10" runat="server" Font-Bold="True"  ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "14"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Bankavaliable") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Banknotavaliable") %>' runat="server" />
          <asp:LinkButton ID="LinkButton11" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "15"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Banknotavaliable") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="No of Beneficiaries Records Having Inavlid Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Bankinvalid") %>' runat="server" />
          <asp:LinkButton ID="LinkButton11" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "15"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Banknotavaliable") %> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="No of Beneficiaries with full  details( Bank A/c + IFSC Code + Aadhar No)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl12" ForeColor="Green" Font-Bold="True" Text='<%# Eval("FullBankDetails") %>' runat="server" />
          <asp:LinkButton ID="LinkButton12" runat="server" Font-Bold="True"  ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "15"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Banknotavaliable") %> </asp:LinkButton>
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

           <div class="row mt-2 mb-3 justify-content-left"> <span style="color: red">NOTE: Invalid Aadhar Numbers includes Death, Migrated,No Aadhar </span></div>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
           </div>
</asp:Content>
