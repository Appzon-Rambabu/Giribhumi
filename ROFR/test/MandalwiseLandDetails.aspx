<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Home.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MandalwiseLandDetails.aspx.cs" Inherits="ROFR.test.MandalwiseLandDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <style>
        .headertable table tr td{
            padding:0px 5px;

        }
    </style>--%>
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:420px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:  #007405;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
      <div class="panel panel-body" style="margin-top:1px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>

          <div class="row mb-2">
              <div class="col-md-10">
                  <h5 class="text-center text-success mb-2 mt-3 offset-2">MANDAL WISE LAND SUMMARY REPORT</h5>
              </div>
              <div class="col-md-2">
                  <asp:Button ID="btnExcel" class="btn btn-sm btn-success float-right" Style="height: 25px !important; padding: 1px 10px  !important;" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="BACK" />
              </div>
          </div>
            
          
           <div class="row mb-4">
                <div class="col-md-6">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:Label ID="txtItda" ForeColor="Black" Font-Bold="True"  runat="server" ></asp:Label>
                        
                    </div>
                </div>
            </div>

               <div class="col-md-5">
                   <div class="row d-flex justify-content-end">
                       <div class="col-md-4 text-center ml-0 mr-0">
                           <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Search..." autocomplete="off" AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox>
                       </div>

                       <div class="col-md-2 ml-0 mr-0">
                           <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                           <asp:Button ID="Button1" class="btn btn-sm btn-success" Style="height: 25px !important; padding: 1px 10px  !important;" AutoPostBack="true" Visible="false" runat="server" Text="Search" />
                       </div>
                   </div>
               </div>

               <div class="col-md-1 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success float-right" Style="height: 25px !important; padding: 1px 10px  !important;"  AutoPostBack="true" runat="server" Text="EXCEL" OnClick="btnsubmit_Click" />
                    </div>


               </div>
    <div class="row justify-content-center">
         <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" style="width:100%;">  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText="S.No"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Mandal"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                      <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"    CommandName="MyUpdate" CommandArgument='<%#Eval("Mandal")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("Mandal") %></asp:LinkButton>
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Mandal") %>' runat="server" Visible="false" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Compartments" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"    CommandName="MyUpdate" CommandArgument='<%#Eval("Total_Compartments")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick1" ><%# Eval("Total_Compartments") %></asp:LinkButton>
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_Compartments") %>' runat="server" Visible="false" />
                 </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Total Farmers"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl3" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Farmers Having Aadhar No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Beneficiaries_Having_Adhaar_no") %>' runat="server" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Total Available Land (In Acres)"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl5" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Land") %>' runat="server" />
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
        </div>
</asp:Content>
