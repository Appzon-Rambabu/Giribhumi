<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ForestBeatwiseLandDetails.aspx.cs" Inherits="ROFR.pages.ForestBeatwiseLandDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .headertable table tr td{
            padding:0px 5px;

        }
    </style>
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

          <div class="row mb-2">
              <div class="col-md-10">
                  <h5 class="text-center text-success mb-2 mt-3 offset-2">FOREST BEAT WISE LAND SUMMARY REPORT</h5>
              </div>
              <div class="col-md-2">
                  <asp:Button ID="btnExcel" class="btn btn-sm btn-success float-right" Style="height: 25px !important; padding: 1px 10px  !important;" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="BACK" />
              </div>
          </div>
            
          
           <div class="row mb-4">
               <div class="col-md-3">
                   <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                       <div class="col-md-6 text-center pl-0 pr-0">
                           <asp:Label ID="txt_Itda" runat="server" Text="DIVISION :"></asp:Label>
                       </div>

                       <div class="col-md-6 pl-0 pr-0">
                           <asp:Label ID="txtItda" ForeColor="Red" Font-Bold="True" runat="server"></asp:Label>

                       </div>
                   </div>
               </div>

               <div class="col-md-3">
                   <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                       <div class="col-md-6 text-center pl-0 pr-0">
                           <asp:Label ID="Label1" runat="server" Text="RANGE :"></asp:Label>
                       </div>

                       <div class="col-md-6 pl-0 pr-0">
                           <asp:Label ID="txtmandal" ForeColor="Red" Font-Bold="True" runat="server"></asp:Label>

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
    <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" style="width:100%;">  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText=" SNO "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText=" FOREST BEAT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Forest_Beat") %>' runat="server" />
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Compartments" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true"   CommandName="MyUpdate" CommandArgument= '<%#Eval("Forest_Beat") + "," +Eval("Total_Compartments")%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("Total_Compartments") %></asp:LinkButton>
             <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_Compartments") %>' runat="server"  Visible="false"/>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Total Beneficiaries" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Beneficiaries Having Aadhar No" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Beneficiaries_Having_Adhaar_no") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Total Available Land (In Acres)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Land") %>' runat="server" />
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
