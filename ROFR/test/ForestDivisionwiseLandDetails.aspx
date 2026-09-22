<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ForestDivisionwiseLandDetails.aspx.cs" Inherits="ROFR.test.ForestDivisionwiseLandDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .headertable table tr td{
            padding:0px 5px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
              <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
            <h5 class="text-center text-success mb-2 mt-3">FOREST DIVISION WISE LAND SUMMARY REPORT</h5>
         <div class="row mb-1 mt-1 justify-content-end">
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" Visible="false" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>
                </div>


            </div>
        </div>
    <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"  style="width:100%;">  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText=" SNO "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText=" FOREST DIVISION "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                      <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("Forest_Division")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("Forest_Division") %></asp:LinkButton>
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Forest_Division") %>' Visible="false" runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Compartments" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_Compartments") %>' runat="server" />
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
        </div>
</asp:Content>
