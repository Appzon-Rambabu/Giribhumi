<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="Beneficiary_Analysis.aspx.cs" Inherits="ROFR.test.Beneficiary_Analysis"  EnableEventValidation="false"%>
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
      <div class="panel-heading" role="tab" id="headingOne"  style="margin-top:2px;">
            <h4 class="panel-title">
								<a class="collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									BENEFICIARY MASTER DETAILS
								</a>
							</h4>
        </div>
       <div class="col-md-12 text-right" id="div_field" runat="server">
           <asp:LinkButton ID="btnback" runat="server" OnClick="btnback_Click" Font-Underline="true">Back</asp:LinkButton></div>
       <div class="row d-flex justify-content-end">

                  <%--  <div class="col-md-3 ml-0 mr-0">
                       <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>
                                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>
     <div class="panel panel-body"> 
          <div class="row mt-3 mb-3 text-center pt-2 pb-2 justify-content-center" style="border-bottom:1px solid #eee;border-top:1px solid #eee;">
                <div class="col-md-3"><asp:Label ID="txtitda" runat="server" Text="ITDA :"></asp:Label>
     <asp:Label ID="txt_itda"  runat="server"  Font-Bold="True" ></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="txtdistrict" runat="server" Text="DISTRICT:"></asp:Label>
     <asp:Label ID="txt_district"  runat="server"  Font-Bold="True" ></asp:Label></div>
              
            </div>
    <div class="row justify-content-center" style="text-align:right">
           <div class="">

       <div class="headertable">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>  
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>                                  
                         <asp:TemplateField HeaderText=" BENEFICIARY ID "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl01" runat="server"  ForeColor="Black" Font-Bold="True" Text='<%# Eval("benficiary_id") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="BENEFICIARY NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl2" runat="server" ForeColor="Black"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR ") %>'></asp:Label>
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
           </div></div></div></div>
</asp:Content>

