<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="MandalMaster_Analysis.aspx.cs" Inherits="ROFR.test.MandalMaster_Analysis"  EnableEventValidation="false"%>
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
								<a class="collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									MANDAL MASTER
								</a>
							</h4>
        </div>
     <div class="panel panel-body"> 

    <div class="row" style="text-align:right">
          <div class="table-responsive">

       <div class="headertable">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>  
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black"  Font-Bold="True" Text='<%# Eval("Sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>                                  
                         <asp:TemplateField HeaderText=" LGD DISTRICT CODE "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl01" runat="server" ForeColor="Black"   Font-Bold="True" Text='<%# Eval("LGD_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="REVENUE DISTRICT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  ForeColor="Black" Font-Bold="True" Text='<%# Eval("REV_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="DISTRICT NAME " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl3" runat="server"  ForeColor="Black" Font-Bold="True" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="LGD MANDAL CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl4" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("LGD_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="REVENUE MANDAL CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl5" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("REV_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="MANDAL NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl6" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("MANDAL_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="NO OF VILLAGES" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl7" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NO_OF_VILLAGES") %>' runat="server" />
  <asp:LinkButton ID="LinkButton7" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("LGD_DISTRICT_CODE") + "-"+Eval("LGD_MANDAL_CODE")+","+ "7"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_VILLAGES") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NO OF RANGES" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl8" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NO_OF_RANGES") %>' runat="server" />
  <asp:LinkButton ID="LinkButton8" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("LGD_DISTRICT_CODE")+"-"+Eval("LGD_MANDAL_CODE")+","+ "8"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_RANGES") %></asp:LinkButton>
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
