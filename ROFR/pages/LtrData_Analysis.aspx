<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Land_reg_TranMaster.master" AutoEventWireup="true" CodeBehind="LtrData_Analysis.aspx.cs" Inherits="ROFR.pages.LtrData_Analysis"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <style type="text/css">
        .header-center {
            text-align: center;
        }
         html, body {
    overflow: hidden; /* disables both vertical and horizontal scrolling */
}
        .headertable { overflow-y: auto; height:350px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #3366CC !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #008000;}

.headertable .aftr th{position: sticky;top: 49px;}

     
    </style>


     <script type="text/javascript" language="javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel-heading" role="tab" id="headingOne" style="margin-top:10px;">
            <h4 class="panel-title text-center">
								<a class="collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									LTR DATA ANALYSIS REPORT
								</a>
							</h4>
        </div>

    <div class="col-md-11">
      <div class="text-left" id="div_field" runat="server">
           <asp:LinkButton ID="btnback" runat="server" ForeColor="#008000" OnClick="btnback_Click" Font-Underline="true">Back</asp:LinkButton></div>
     <div class="text-right" id="div1" runat="server">
         <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/imagesnew/download.jpg"  OnClick="btnexcel_Click" />
     </div>

     <div class="panel panel-body"> 

    <div class="row">

    <div class="table-responsive">

       <div class="headertable">

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="2" OnRowCreated="GridView1_RowCreated" CellSpacing="2" >  
                    <Columns>   
                             
                     <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>   
                     <asp:TemplateField HeaderText=" ITDA "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText=" DISTRICT " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                     <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT")+","+ Eval("ITDA")%>' CausesValidation="false"   Visible ="false"  OnClick="dislink_onclick" ><%# Eval("DISTRICT") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText=" MANDAL " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("MANDAL") %>'></asp:Label>
                     <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")+","+ Eval("DISTRICT") +"-" +Eval("ITDA")%>' CausesValidation="false"  Visible ="false"  OnClick="manlink_onclick" ><%# Eval("MANDAL") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="VILLAGE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4"   Font-Bold="True" Text='<%# Eval("VILLAGE") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="TOTAL CASES" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5"  Font-Bold="True" Text='<%# Eval("TOTAL_CASES") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PENDING" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("SDC_PENDING") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DISPOSED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7"  Font-Bold="True" Text='<%# Eval("SDC_DISPOSED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PENDING" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9"  Font-Bold="True" Text='<%# Eval(" ADDITIONAL_AGENT_PENDING") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="DISPOSED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10"  Font-Bold="True" Text='<%# Eval("ADDITIONAL_AGENT_DISPOSED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PENDING" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11"  Font-Bold="True" Text='<%# Eval("AGENT_GOVT_PENDING") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="DISPOSED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl12"  Font-Bold="True" Text='<%# Eval("AAGENT_GOVT_DISPOSED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PENDING" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl13"  Font-Bold="True" Text='<%# Eval("GOVT_PENDING") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="DISPOSED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl14"  Font-Bold="True" Text='<%# Eval("GOVT_DISPOSED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PENDING" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl15"  Font-Bold="True" Text='<%# Eval("HIGHCOURT_PENDING") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DISPOSED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl16"  Font-Bold="True" Text='<%# Eval(" HIGHCOURT_DISPOSED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CASE STATUS TO BE UPDATED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl17"  Font-Bold="True" Text='<%# Eval("CASE_STATUS_TO_BE_UPDATED") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />  
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
