<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Beneficiary_Analysis.aspx.cs" Inherits="ROFR.pages.Beneficiary_Analysis"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #333 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#008500;}

.headertable .aftr th{position: sticky;top: 49px;}

     h5.thick {
  font-weight: bold;
}
.grid td   /* this applies to the Gridviews Data fileds */
{
    padding: 10px;
    width: 3%;
  
}

 .grid th   /* this applies to the Gridviews Headers */
{
     padding: 10px 5px;
     height:5%;
     padding-top:3px
}
    </style>

     <script type="text/javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
 <%--for print Button--%>
    <script type="text/javascript">
            function PrintGridData() {
              var prtGrid = document.getElementsByClassName('grid')[0];
              var title = document.getElementById('Title_Header').parentElement;
              prtGrid.border = 0;
             var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=100000 ,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
               prtwin.document.write('<div><div class="col-md-6"></div>' + title.outerHTML + "\r\n"+'</div>' + prtGrid.outerHTML);
               prtwin.document.close();
               prtwin.focus();
               prtwin.print();
               prtwin.close();
            }
    </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%--<div class="panel-heading" role="tab" id="headingOne" >
            <h4 class="panel-title">
								<a class="collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
									BENEFICIARY MASTER DETAILS
								</a>
							</h4>
        </div>--%>
		
        <%--<div class="col-md-12 text-right" id="div_field" runat="server">--%>
           
       <%--<div class="row d-flex justify-content-end">

                  <%--<div class="col-md-3 ml-0 mr-0">
                       <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>
                                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                <%--</div>--%>
     <div class="panel panel-body"> 
						
	  <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> 
                   <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">BENEFICIARY MASTER DETAILS</h5>
               </div>
              <div class="col-md-4 text-right ">
                  <div class="d-flex">
                      <div class="col-auto">
                          <div class="d-flex justify-content-end">
                         <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />&nbsp;&nbsp;
                  </div>
                  </div>
                      <div class="col-md-9 col-auto ">
					  <asp:LinkButton ID="btnback" runat="server" OnClick="btnback_Click" Font-Underline="true">Back</asp:LinkButton>
                     
                     
                      </div>
                  </div>
                  </div>
	 </div>
	 
	 
	 
	 
          <div class="row mt-3 mb-3 text-center pt-2 pb-2 justify-content-center" style="border-bottom:1px solid #eee;border-top:1px solid #eee;">
                <div class="col-md-3"><asp:Label ID="txtitda" runat="server" Text="ITDA :"></asp:Label>
     <asp:Label ID="txt_itda"  runat="server"  Font-Bold="True" ></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="txtdistrict" runat="server" Text="DISTRICT:"></asp:Label>
     <asp:Label ID="txt_district"  runat="server"  Font-Bold="True" ></asp:Label></div>
              
            </div>
    <div class="row justify-content-center" style="text-align:right">
           <div class="">

       <div class="headertable">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="grid" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>  
                        <asp:TemplateField HeaderText=" S.NO"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>                                  
                         <asp:TemplateField HeaderText=" BENEFICIARY ID "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl01" runat="server"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="BENEFICIARY NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR ") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     
                      
                 
                         
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#008500" Font-Bold="True" ForeColor="#FFFFFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>
        </div>
           </div></div>
		    <%--</div>--%>
</asp:Content>
