<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="RPayment_Success.aspx.cs" Inherits="ROFR.test.RPayment_Success" EnableEventValidation="false" %>
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
           
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">RYTHU BHAROSA PAYMENT SUCCESS DETAILS</h5></div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                   <%-- <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>


            </div>
        </div>
            <div class="row mb-1 mt-1 justify-content">
               <div class="col-md-1 text-right">
                   
                <asp:Label ID="Label1" runat="server" Text="ITDA:" Font-Bold="true"></asp:Label>
               </div>
               <div class="col-md-2"> 
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
               </div>
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="District:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                <div class="col-md-1 text-right" >

                 <asp:Label ID="Label3" runat="server" Text="Mandal:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_mandal" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                  <div class="col-md-1 text-right" >

                 <asp:Label ID="Label4" runat="server" Text="Village:" Font-Bold="true"></asp:Label>
                

            </div>
                <div class="col-md-2">

                 <asp:Label ID="lbl_village" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
        </div>
  <div class="row justify-content-center" style="text-align:right">
           <div class="col-md-12">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                       

                          <asp:TemplateField HeaderText="Beneficiary Id "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>' ForeColor="Black"></asp:Label>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                        <%--  <asp:TemplateField HeaderText="Compartment No" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">

                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Compartment_No") %>' runat="server" />
  </div>

            </ItemTemplate>
        </asp:TemplateField> 
                           --%>
                       <%--    
                         <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:center">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>' runat="server"  />
          </div>
            </ItemTemplate>
        </asp:TemplateField> --%>
                               
                       <%--  <asp:TemplateField HeaderText="Plot No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Plot_No") %>' runat="server" />
       
            </ItemTemplate>
        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="ROFR Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
          </div>

            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Aadhaar No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:center">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server"  />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="BankAccountNo." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:center">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BankAccountNo") %>' runat="server" />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                           <asp:TemplateField HeaderText="IfscCode" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:center">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("IfscCode") %>' runat="server"  />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="BankName" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BankName") %>' runat="server" />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Payment Status" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("RB_Payment_Status") %>' runat="server"/>
          
            </ItemTemplate>
        </asp:TemplateField>--%>
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

