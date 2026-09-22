<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="DistrictWise_BeneficiaryMaster_Abstract.aspx.cs" Inherits="ROFR.test.DistrictWise_BeneficiaryMaster_Abstract"  EnableEventValidation="false"%>
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
      <div class="panel panel-body" style="margin-top:3px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
           
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">DISTRICT WISE FARMER REPORT</h5></div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>
                </div>


            </div>
        </div>
    <div class="row " style="text-align:right">
           <div class="col-md-14">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    > 
                    <Columns>   
                                
                        
                         <asp:TemplateField HeaderText=" ITDA "   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("Itda_Name") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" District "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Itda_Name")+","+Eval("District")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("District") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Farmers as per record " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl31" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_bneficiaries_dept") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Farmers as per Giribhumi" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="No of Farmers Having Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_Received") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>  
                          <asp:TemplateField HeaderText="No of Farmers Not Having Aadhar Numbers " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnotavaliable") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Farmers Having Valid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Adhharisvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField HeaderText="No of Farmers Having Invalid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnoinvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                      
                        <asp:TemplateField HeaderText="No of Farmers Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Bankavaliable") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Farmers Not Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Banknotavaliable") %>' runat="server" />
        
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="No of Farmers Having Invalid Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl12" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Bankinvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="No of Farmers with full  details( Bank A/c + IFSC Code + Aadhar No)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl13" ForeColor="Green" Font-Bold="True" Text='<%# Eval("FullBankDetails") %>' runat="server" />
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
        </div>
        </div>
        </div>
         
        
</asp:Content>
