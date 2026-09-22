<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="DistictData_Analysis.aspx.cs" Inherits="ROFR.test.DistictData_Analysis" EnableEventValidation="false" %>
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
     <div class="content-area">
     <div class="panel-heading" role="tab" id="headingOne" style="margin-top:2px;">
            <h4 class="panel-title">
								<a class="collapsed" role="button"  data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									DISTRICT MASTER
								</a>
							</h4>
        </div>
     <div class="panel panel-body"> 

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
              <asp:Label Class="txt"  ID="lbl0" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("Sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>   
                         <asp:TemplateField HeaderText=" LGD DISTRICT CODE "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("LGD_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="REVENUE DISTRICT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl2" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("REV_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="DISTRICT NAME " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl3" runat="server"  Font-Bold="True" ForeColor="Black" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="NO OF MANDALS"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NO_OF_MANDALS") %>' runat="server" />
  <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("LGD_DISTRICT_CODE")+","+ "3"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_MANDALS") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="NO OF DIVISIONS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("NO_OF_DIVISIONS") %>' runat="server" />
          <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("LGD_DISTRICT_CODE")+","+ "4"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_DIVISIONS") %></asp:LinkButton>
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
           </div></div></div>
         </div>
</asp:Content>
