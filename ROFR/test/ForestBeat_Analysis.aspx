<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="ForestBeat_Analysis.aspx.cs" Inherits="ROFR.test.ForestBeat_Analysis" EnableEventValidation="false" %>
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
									FOREST BEAT MASTER
								</a>
							</h4>
        </div>
     <div class="panel panel-body"> 

    <div class="row" style="text-align:right">

        <div class="table-responsive">

       <div class="headertable"
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>  
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Sno") %>'></asp:Label>
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
              <asp:Label  ID="lbl3" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
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

                         <asp:TemplateField HeaderText="LGD VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl7" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("LGD_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="REVENUE VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl8" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("REV_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="VILLAGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl9" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("VILLAGE_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FOREST DIVISION CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl10" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_DIVISION_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="FOREST DIVISION NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl11" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_DIVISION_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="FOREST RANGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl12" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_RANGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST RANGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl13" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_RANGE_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FOREST BEAT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl14" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_BEAT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST BEAT NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl15" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("FOREST_BEAT_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="HABITATION NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl16" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("HAB_NAME") %>'></asp:Label>
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
           </div></div>
       </div>
</asp:Content>

