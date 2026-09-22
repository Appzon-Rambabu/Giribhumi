<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="View_Beneficiary_Plots.aspx.cs" Inherits="ROFR.test.View_Beneficiary_Plots"  EnableEventValidation="false"%>
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
     <div class="panel panel-body"  style="margin-top:150px;">


        <h5 class="text-center text-success mb-4 mt-3">VIEW BENEFICIARY PLOT DETAILS</h5>

        <div class="row mb-4 justify-content-center">
            <asp:Label ID="lbl_adhar" runat="server" Text="Enter Beneficiary ID:" CssClass="col-md-2 text-right" >
                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
           
            <asp:TextBox ID="txt_adhar" runat="server" CssClass="col-md-3" autocomplete="off"></asp:TextBox>
            <div class="col-md-2">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" OnClientClick="return valid()" />
            </div>
            <%-- <div class="col-md-2">
                <asp:Button ID="btn_pdf" runat="server" Text="PDF" OnClick="btn_pdf_Click"  />
            </div>
             <div class="col-md-2">
                <asp:Button ID="btn_pdf1" runat="server" Text="PDF1" OnClick="btn_pdf1_Click"  />
            </div>--%>
        </div>
            <div class="row justify-content-center">
         <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"  style="width:100%;">  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText="S.NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="ID"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Id") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                             <asp:TemplateField HeaderText="BENEFICIARY ID"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="ITDA NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' runat="server"  />
                      </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="DISTRICT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl3"  Font-Bold="True" Text='<%#Eval("District")%>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="MANDAL" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Mandal")%>' runat="server" />
           </div>
                      </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GRAM PANCHAYAT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl5"  Font-Bold="True" Text='<%# Eval("Gram_Panchayat")%>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="REVENUE VILLAGE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("REV_Village") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="VILLAGE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Village") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="HABITATION"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("Habitation") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="FOREST DIVISION" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Division") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST RANGE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Range") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST BEAT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Beat") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FOREST BLOCK"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Block") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="COMPARTMENT NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("Compartment_No") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PLOT NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Plot_No") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="EXTENT PLOT AREA"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ROFR PATTA NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ROFR PATTADAAR"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("FATHER_NAME") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SUB CASTE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("SUB_CASTE") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CULTIVATOR NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("CULTIVATOR_NAME") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                        
                         <asp:TemplateField HeaderText="AADHAR NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BANK ACCOUNT NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("BankAccountNo") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IFSC CODE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("IfscCode") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BANK NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("BankName") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="UNCULTIVABLE LAND"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Uncultivable_Land") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CULTIVABLE LAND"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Cultivable_Land") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PATTA INAM/GOVT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("PATTA_INAMGOVT") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="DRYID ONECROP/TWO CROP"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("DRYID_ONECROP_TWO_CROP") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="WATER SOURCE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("WATER_SOURCE") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT IRRIGATED"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("EXTENT_IRRIGATED") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT UNDER CULTIVATOR"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LAND CLASSIFICATION"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Land_Classification_Name") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="HOLDING NATURE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("HOLDING_NATURE") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("EXTENT") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="NET SOWN AREA"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("NET_SOWN_AREA") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MONTH OF CULTIVATION"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("MONTH_OF_CULTIVATION") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CROP"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("CROP") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="EXTENT SINGLE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("SINGLE") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="EXTENT MIXED"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("MIXED") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField HeaderText="EXTENT TOTAL"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("TOTAL") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FIRST CROP"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("FIRST_CROP") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SECOND THIRD CROP"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("SECOND_THIRD_CROP") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CROP YIELD" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("CROP_YIELD") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="REMARKS" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("REMARKS") %>' runat="server" />
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
