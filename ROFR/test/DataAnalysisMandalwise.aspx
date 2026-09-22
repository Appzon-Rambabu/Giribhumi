<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="DataAnalysisMandalwise.aspx.cs" Inherits="ROFR.test.DataAnalysisMandalwise" EnableEventValidation="false" %>
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
            <h5 class="text-center text-success mb-2 mt-3">MANDAL WISE DATA ANALYSIS REPORT</h5>

                      <div class="row justify-content-center mt-3">
               <div class="col-md-2">
                   <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                       <div class="col-md-6 text-center pl-0 pr-0">
                           <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                       </div>

                       <div class="col-md-6 pl-0 pr-0">
                           <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                       </div>
                   </div>
               </div>
               <div class="col-md-2">
                   <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                       <div class="col-md-4 text-center">
                           <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                       </div>

                       <div class="col-md-8">
                           <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
                       </div>
                   </div>
               </div>

                
           </div>
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
                                
                         <asp:TemplateField HeaderText="ITDA Name"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left"
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="District "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left"
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mandal " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left"
              <asp:Label Class="txt"  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("Mandal") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                       
                     <asp:TemplateField HeaderText="Total  Beneficiaries Received(Giribhumi Database) by Department " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("TOTAL_BENEFICIARIES") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Total Plots" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>  
                     <asp:TemplateField HeaderText="No of Beneficiaries Records Having Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <asp:Label ID="lbl5" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("total_received") %>' runat="server" />
          
            </ItemTemplate>
        </asp:TemplateField> 
               
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Having Valid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Adhharisvalid") %>' runat="server" />
        
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Having Invalid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnoinvalid") %>' runat="server" />
 
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Having No Aadhar Numbers " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnotavaliable") %>' runat="server" />

            </ItemTemplate>
        </asp:TemplateField> 
                      
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Having Bank Details(Bank A/c + IFSC Code) " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Bankavaliable") %>' runat="server" />

            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Beneficiaries Records Not Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Banknotavaliable") %>' runat="server" />
      
            </ItemTemplate>
        </asp:TemplateField> 
                                <asp:TemplateField HeaderText="No of Beneficiaries Records Having Invalid Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Bankinvalid") %>' runat="server" />
      
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Beneficiaries Records Having Full Bank Details(Aadhar + Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("FullBankDetails") %>' runat="server" />
      
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
           </div>
</asp:Content>
