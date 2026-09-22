<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="LandStatusReport.aspx.cs" Inherits="ROFR.pages.LandStatusReport" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #333 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: 1px; background-color:#008500;}
.headertable .aftr th{position: sticky; top: 37px;}
h5.thick {
  font-weight: bold;
}   
     

    </style>
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
     <script type="text/javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
 
  <%--for print Repeater--%>
   <script type="text/javascript">
function PrintDivData(crtlid)
{
    var ctrlcontent = document.getElementById(crtlid);
    var title = document.getElementById('Title_Header').parentElement;
    var printscreen = window.open('', '', 'left=100,top=100,width=10000,height=1000,toolbar=0,scrollbars=0,status=0');
    //printscreen.document.write(ctrlcontent.innerHTML);
    printscreen.document.write('<div><div class="col-md-6"></div>' + title.outerHTML + "\r\n" + '</div>' + ctrlcontent.outerHTML);
    printscreen.document.close();
    printscreen.focus();
    printscreen.print();
    printscreen.close();
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                 <asp:UpdateProgress ID="UPDATED" runat="server">
                                    <ProgressTemplate>
                                        <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner"></div>
                                   <span id="loading-msg">
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

     <asp:UpdatePanel runat="server">
        <ContentTemplate>
      <div class="panel panel-body"> 
           
         <div class="row mb-1 mt-1 justify-content-end">
              <div class="col-md-7 text-left"> 
			   <h5 class="text-left text-success mb-1 mt-1 thick" id="Title_Header">Phase-II Plot Wise Land Status Report</h5>
			   </div>
              <div class="col-md-10 text-right justify-content-end ">
			  <input id="btnPrintITDALevel" name="Print" runat="server" class="btn btn-success mr-2" type="button" value="Print" onclick="javascript: PrintDivData('Rep_Print');" />
              <%--<input id="btnPrintMandalLevel" name="Print" runat="server" class="btn btn-success mr-2" type="button" value="Print" onclick="javascript: PrintDivData('Rep1_Print');" />--%>
			  <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="EXCEL" />
			   <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="EXCEL" />&nbsp;&nbsp;
                   <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
              
                   </div>
             
            <div class="col-md-4">
             </div>
        </div>


       
          <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-12" id="Rep_Print">
        <div class="table-responsive">

       <div class="headertable" >
     

           <asp:Repeater ID="GridView" runat="server" OnItemDataBound="rpt_ItemDataBound" >
                <HeaderTemplate>
        <table border="1" cellpadding="10" width="50%">
              <tr ><th align="center" colspan="3" style="text-align:center;background-color: #008500;color: white;"></th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"> <asp:Label ID="lbl_approved" runat="server" Text="Already Approved"></asp:Label></th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_yes" runat="server" Text=""></asp:Label></th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_today" runat="server" Text=""></asp:Label></th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_cum" runat="server" Text=""></asp:Label></th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">District</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No of Beneficiries </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Extent (Acres)s</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No of Beneficiaries</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Extent (Acres)</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No of Beneficiaries</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Extent (Acres)</th>
								<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No of Beneficiaries</th>
          		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Extent (Acres)</th>
          </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lblTimeFrom" runat="server" Text='<%# Eval("Sno") %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                </div>
            </td>
              <td>
              <%--  <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>--%>
                     <div style="text-align:left">
                      <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("DISTRICT")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("DISTRICT") %></asp:LinkButton>
            </div>
                         </td>
              <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("NO_OF_BENEFICIARIES") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("UPTOYES_NO_OF_FARMERS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("UPTOYES_TOTAL_EXTENT") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("TODAY_NO_OF_FARMERS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("TODAY_TOTAL_EXTENT") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("CUM_NO_OF_FARMERS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("CUM_TOTAL_EXTENT") %>'></asp:Label>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
           </asp:Repeater>
             </div>
              </div>
               
               </div>
        </div>

          <div class="row justify-content-center" style="text-align:right" id="div_mandal" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView2" HeaderStyle-BackColor="#9AD6ED" HeaderStyle-ForeColor="#FFFFFF"
    runat="server" AutoGenerateColumns="false" OnDataBound="OnDataBoundMandal"> 
                  <Columns>
       
                        <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="District"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Eval("DISTRICT") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mandal"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Eval("MANDAL") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
        
           <asp:BoundField DataField="UPTOYES_NO_OF_FARMERS" HeaderText="No of Beneficiries" ItemStyle-Width="150" />
         <asp:BoundField DataField="UPTOYES_TOTAL_EXTENT" HeaderText="Extent (Acres)" ItemStyle-Width="150" />
         <asp:BoundField DataField="TODAY_NO_OF_FARMERS" HeaderText="No of Beneficiries" ItemStyle-Width="150" />
         <asp:BoundField DataField="TODAY_TOTAL_EXTENT" HeaderText="Extent (Acres)" ItemStyle-Width="150" />
           <asp:BoundField DataField="CUM_NO_OF_FARMERS" HeaderText="No of Beneficiries" ItemStyle-Width="150" />
         <asp:BoundField DataField="CUM_TOTAL_EXTENT" HeaderText="Extent (Acres)" ItemStyle-Width="150" />
    </Columns>  
                  
                </asp:GridView>
             </div>
              </div>
               </div>
        </div>
           
          
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
