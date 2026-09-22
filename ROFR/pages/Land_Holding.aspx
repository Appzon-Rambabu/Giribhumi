<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Land_Holding.aspx.cs" Inherits="ROFR.pages.Land_Holding"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
    <script src="../linksforcdns/Js/jquery.min.js"></script>
     <script type="text/javascript">
         function RestrictComma(e) {
             var theEvent = e || window.event;
             var key = theEvent.keyCode || theEvent.which;
             key = String.fromCharCode(key);
             var regex = /[^,; ]+$/;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) {
                     theEvent.preventDefault();
                 }
             }
         }
         function validateFloatKeyPress(el, evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             var number = el.value.split('.');
             if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                 return false;
             }
             if (charCode >= 13 && charCode <= 27) {
                 return false;
             }
             //if (evt.which &&( charCode == 86|| charCode == 88 ||charCode == 67)) {
             //    return false;
             //}
             //just one dot
             if (number.length > 1 && charCode == 46) {
                 return false;
             }
             //get the carat position
             var caratPos = getSelectionStart(el);
             var dotPos = el.value.indexOf(".");
             if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
                 return false;
             }
             return true;
         }


         function getSelectionStart(o) {
             if (o.createTextRange) {
                 var r = document.selection.createRange().duplicate()
                 r.moveEnd('character', o.value.length)
                 if (r.text == '') return o.value.length
                 return o.value.lastIndexOf(r.text)
             } else return o.selectionStart
         }

         function fdecimal(event) {

             var str = event.value.indexOf(".");
             var reg = /^\d+(?:\.\d{1,2})?$/
             if (str != -1) {
                 if (reg.test(event.value)) {
                     return true;

                 }
                 else {
                     alert('Please enter valid extent.... Example:2.00, 23.45')
                     event.value = "";
                     return false;
                 }

             }

             else {
                 alert('Please enter valid extent.... Example:2.00, 23.45')
                 event.value = "";

             }

         }
        function openModal() {
            $('#exampleModal').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }

        function toggleModal() {
            $('#exampleModal').modal('toggle');
            //$('[id*=exampleModal]').modal('show');
        }
        function closeModal() {
            alert('Please click on Submit button to submit comments and then click close !');
            $('#exampleModal').modal('toggle');
            //$('[id*=exampleModal]').modal('show');
        }
        function HideModal() {
            
            $('#exampleModal').modal('hide');
            //$('[id*=exampleModal]').modal('show');
        }
    </script>
      <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
    

   
     .table th {
      text-align: center;
       background-color: #008500 !important;
    font-weight: 100 !important;
       }
  
  
      .table td, .table th {
        padding: .15rem !important;
        font-size: 12px;
      }
    .bg-nav{
      background-color: #008500 !important;
    }
   
  </style>
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: 0px; background-color: #008500;}

.headertable .aftr th{position: sticky;top: 36px;}
.headertable .aftr1 th{position: sticky;top: 72px;}
.headertable .aftr2 th{position: sticky;top: 108px;}

     
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="row" style="margin-top:-30px;">
      <span id="tk" style="display:none" runat="server"></span>
        <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">
            <div class="panel">
                <div class="panel-body">
                    <div class="row ">
                        <div class="col-md-3"></div>
                        <div class="col-md-6 text-center">
                            <h4 style="color:#00ad27;font-size:24px"><b>Family wise Land Holding Details</b></h4>
                        </div>
                        <div class="col-md-3">
                            <%--<a id="landexcel"><img src="../imagesnew/download1.jpg" width="28" height="28" style="float:right;margin:3px"
                                    onclick="land_excel()"/></a>--%>
                             <asp:Button ID="Button2" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="GridToExcel"  runat="server" Text="ABSTRACT EXCEL" />
                             <asp:Button ID="btn_excel" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="ExportToExcel"  runat="server" Text="DETAILS EXCEL" />
                         
                            <%--   <a id="Rythuexcel"><img src="../imagesnew/download1.jpg" width="28" height="28" style="float: right; margin: 3px"
                                    onclick="Rythu_excel()"/></a>--%>
                        </div>
                    </div>
                    



                                      <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-body bg-light p-2">
                                    <div class="row justify-content-center">
                                        <div class="showdetails1 col-md-6">
                                            
  
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table table-bordered text-center "  OnDataBound="OnDataBoundGrid"  >  
    
        
                                     <Columns>  
                                         <%-- <asp:TemplateField HeaderText="SNo." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"   Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>--%>
           <%--<asp:BoundField DataField='<%# Container.DataItemIndex + 1 %>' HeaderText="S.NO" ItemStyle-Width="150" />--%>
         <asp:BoundField DataField="itda" HeaderText="ITDA " ItemStyle-Width="150" />
         <asp:BoundField DataField="TOTAL" HeaderText="Total No.of Families" ItemStyle-Width="150" HeaderStyle-HorizontalAlign="Center" />
         <asp:BoundField DataField="SUBMERED" HeaderText="Sub-merged/Migrated/In-Eligible Families" ItemStyle-Width="150" />
         <asp:BoundField DataField="LANDALLOTMENT_FAMILIES" HeaderText="Families For Land Allotment" ItemStyle-Width="150" />
           <asp:BoundField DataField="LESSTHAN1_ACRE" HeaderText="Families with < 1Acres" ItemStyle-Width="150" />
         <asp:BoundField DataField="LESSTHAN" HeaderText="Families between 1 and 2Acres" ItemStyle-Width="150" />
         <asp:BoundField DataField="GRAEATERTHAN_FAMILIES" HeaderText="Families with > 2Acres" ItemStyle-Width="150" />
         <asp:BoundField DataField="NOLAND_FAMILIES" HeaderText="Families with No Land" ItemStyle-Width="150" />
          <%-- <asp:BoundField DataField="CUM_NO_OF_FARMERS" HeaderText="No of Beneficiries" ItemStyle-Width="150" />
         <asp:BoundField DataField="CUM_TOTAL_EXTENT" HeaderText="Extent (Acres)" ItemStyle-Width="150" /> --%>
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
                    
                                    <div class="row d-flex justify-content-center">
                                      
                                        <div class="col-md-2">
                                              <asp:RadioButtonList ID="rbtn_list"    runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
   
          <asp:ListItem Value="1" Selected="True">3.21 Lacs&nbsp</asp:ListItem>
        <%--  <asp:ListItem Value="2">2.7 Lacs</asp:ListItem>--%>
          </asp:RadioButtonList>
                                        </div>
                                    </div>
                    
                                    <div class="row d-flex justify-content-center">

                                        <div class="col-md-2 d-flex">
                                        <label>ITDA: </label>
                                          <%-- <select class="form-control" id="Itda">
							<option value="0">Select Itda</option>
                                              
						</select>--%>
                                            <asp:DropDownList ID="ddl_ITda"  CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
                                        </div>
                    
                                        <div class="col-md-2 d-flex">
                                        <label>District:</label>
                                           <%--  <select class="form-control" id="District">
							<option value="0">Select District</option>
							
						</select>--%>
                                               <asp:DropDownList ID="ddl_district" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Mandal:</label>
                                           <%--  <select class="form-control" id="Mandal">
							<option value="0">Select Mandal</option>
							
						</select>--%>
                                             <asp:DropDownList ID="ddl_mandal" CssClass="form-control" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Village Secratariate:</label>
                                             <%-- <select class="form-control" id="Village">
							<option value="0">Select Village</option>
							
						</select>--%>
                                              <asp:DropDownList ID="ddl_village" CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"></asp:DropDownList>
                                        </div>
                    
                                        
                                        <div class="col-md-2 d-flex">
                                        <label>Remarks:</label>
                                            <%-- <select class="form-control" id="Status">
							<option value="0">Select Status</option>
							
						</select>--%>
                                              <asp:DropDownList ID="ddl_status" CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlstatus_OnSelectedIndexChanged">

                                                    <asp:ListItem  Value="ALL">ALL</asp:ListItem>
                                                   <asp:ListItem  Value="NOLAND">No Land</asp:ListItem>
                                                   <asp:ListItem  Value="LESSTHAN">Between 1 and 2 acres</asp:ListItem>
                                                   <asp:ListItem  Value="LESSTHAN1 ACRE">Less than 1 acre</asp:ListItem>
                                                   <asp:ListItem  Value="GRAETERTHAN">Greater than 2 acres</asp:ListItem>
                                                   <asp:ListItem  Value="SUBMERGED">Submerged/Migrated/In-eligible</asp:ListItem>
                                              </asp:DropDownList>
                                      
                                              </div>
                                    </div>

                                    <div class="row justify-content-center mt-3">
                                        <div class="col-md-12">
                                          
                                         
                                            <div class="table-responsive">
                                                <div id="table-container">
                                                    <div class="headertable">
                                                        <div class="showdetails">
                                                    

                                                             <asp:Repeater ID="rpt1" runat="server">
    <HeaderTemplate>
        <table border="1" cellpadding="10" width="50%">
              <tr><th id="printHead" align="center" colspan="15" style="text-align:center;background-color: #008500;color: white;">Land Holding Details Report</th></tr>
          <tr class="aftr">
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Ration Card No</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Aadhaar Number</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Family Member Name</th>
					<th colspan="4" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 145px;">Land Details</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 95px;">DKT Land</th>

        <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Updated Survey/ Compartment No.</th>
             
                <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Updated Katha/ Patta No.</th>
                <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Updated Extent</th>
									 <%--    <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Updated Reason</th>
              <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">TWD Comments</th>--%>
               <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Updated Reason 2021</th>
              <th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">TWD Comments 2021</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Submit</th>
					
					</tr>
            <tr class="aftr1">
					<th colspan="2" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 185px;">WebLand</th>
					<th colspan="2" style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 95px;">RoFR</th>
					
			
				</tr>
            <tr class="aftr2">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;width:100px;">Survey No.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Extent.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Compartment No.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 100px;">Extent.</th>
				</tr>
         <%--   <tr>

                  <th>S No.</th>
                <th>Ration Card No</th>
                <th>Aadhaar Number</th>
                <th>Family Member Name</th>
                  <th>Survey No.</th>
                    <th>Extent.</th>
                <th>Compartment No.</th>
                  <th>Extent.</th>
                 <th>DKT Land</th>
                <th>TWD Comments</th>
                <th></th>
                <th></th>
            </tr>--%>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
             <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("RN") %>'></asp:Label>
            </td>
            <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="lblRelayName" runat="server" Text='<%# Eval("EXISTING_RC_NUMBER") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTimeFrom" runat="server" Text='<%# Eval("UID_NO") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("MEMBER_NAME_EN") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("WEBLAND_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("FINAL_WEBLAND_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ROFR_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("ROFR_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DKT_EXTENT") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label19" runat="server" Text='<%# Eval("UPDATED_SURVEY") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text='<%# Eval("UPDATED_PATTANO") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Text='<%# Eval("EXTENT_SURVEY") %>'></asp:Label>
            </td>
            <%-- <td>
                <asp:Label ID="Label24" runat="server" Text='<%# Eval("REASON_LANDHOLDINGREMARKS") %>'></asp:Label>
            </td>
              <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="Label25" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS") %>'></asp:Label>
            </td>--%>
            <td>
                <asp:Label ID="Label26" runat="server" Text='<%# Eval("REASON_LANDHOLDINGREMARKS_2021") %>'></asp:Label>
            </td>
              <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="lbl_cmts" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS_2021") %>'></asp:Label>
            </td>
               <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
              <%--  <asp:ImageButton ID="imgBtnStatus" runat="server"
                    ImageUrl="~/img/btnGet.jpg"
                    CommandName="Change" Style="width: 36px; border-width: 0px; margin-top: -4px; vertical-align: middle;" />--%>
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("EXISTING_RC_NUMBER")+","+ "1"%>' CausesValidation="false" OnClick="link_onclick" >Update</asp:LinkButton>
            </td>
            <%--  <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:CheckBox ID="chkStatus" runat="server" Checked="true" />
            </td>--%>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

    <asp:Repeater ID="rpt2" runat="server">
    <HeaderTemplate>
        <table border="1" cellpadding="10" width="50%">
              <tr><th id="printHead" align="center" colspan="10" style="text-align:center;background-color: #2e44df;color: white;">Land Holding Details Report</th></tr>
          <tr class="aftr">
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
				
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Ration Card No</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Aadhaar Number</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Family Member Name</th>
					<th colspan="4" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 145px;">Land Details</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">DKT Land</th>
					<th rowspan="3" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">TWD Comments</th>
		
					
					</tr>
            <tr class="aftr1">
					<th colspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 185px;">WebLand</th>
					<th colspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 95px;">RoFR</th>
					
			
				</tr>
            <tr class="aftr2">
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">Survey No.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Extent.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Compartment No.</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Extent.</th>
				</tr>
         <%--   <tr>

                  <th>S No.</th>
                <th>Ration Card No</th>
                <th>Aadhaar Number</th>
                <th>Family Member Name</th>
                  <th>Survey No.</th>
                    <th>Extent.</th>
                <th>Compartment No.</th>
                  <th>Extent.</th>
                 <th>DKT Land</th>
                <th>TWD Comments</th>
                <th></th>
                <th></th>
            </tr>--%>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
             <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("RN") %>'></asp:Label>
            </td>
            <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="lblRelayName" runat="server" Text='<%# Eval("EXISTING_RC_NUMBER") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTimeFrom" runat="server" Text='<%# Eval("UID_NO") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("MEMBER_NAME_EN") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("WEBLAND_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("FINAL_WEBLAND_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ROFR_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("ROFR_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DKT_EXTENT") %>'></asp:Label>
            </td>
              <td style='vertical-align: top; display: <%# ((bool) Eval("IsFirstRowWithThisItemName")) ? "" : "none" %>;' 
                rowspan="<%# Eval("CountOfProductsWithThisItemName") %>">
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS") %>'></asp:Label>
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
                                        </div>
                                    </div>

                    
                    
                                   
                                </div>
                            </div>
                    
                        </div>
                    </div>


                </div>
            </div>
        </main>
      </div>
    </div>  


         <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">UPDATE TWD COMMENTS</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                          <ContentTemplate>
               <div class="col-md-12">
                  <div class="row justify-content-center">

                      
                      <div class="col-md-6 col-12">
                          <div class="row mb-2">
                              <asp:Label ID="Label1" runat="server" Text="Ration Card No.:" CssClass="col-md-6 col-form-label">
                                  <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                              <div class="col-md-6">
                                  <asp:TextBox ID="Txt_ration_no" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                     

                       
                      
                      <div class="col-md-6 col-12">
                          <div class="row mb-2">
                              <asp:Label ID="Label2" runat="server" Text="Select Comments:" CssClass="col-md-6 col-form-label">
                                  <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                              <%--<input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly   />   --%>
                           
                                <div class="col-md-6">
                                      
                                  <asp:DropDownList ID="ddl_cmts" CssClass="form-control" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="ddl_cmts_OnSelectedIndexChanged" >

                                      <asp:ListItem Value="0">Select</asp:ListItem>
                                      <asp:ListItem Value="1">Land to be Identified (Pending claims)</asp:ListItem>
                                      <asp:ListItem Value="2">No Land Available for allotment</asp:ListItem>
                                      <asp:ListItem Value="3">GOVT Employee</asp:ListItem>
                                      <asp:ListItem Value="4">POLAVARAM_SUBMERGED AREA</asp:ListItem>
                                      <asp:ListItem Value="5">Having Land - Not Updated in Webland</asp:ListItem>
                                      <asp:ListItem Value="6">Having Land - Not Updated in Giribhumi</asp:ListItem>
                                      <asp:ListItem Value="7">Having Land more than 2 Acres - Mutation is pending</asp:ListItem>
                                       <asp:ListItem Value="8">Death Case</asp:ListItem>
                                        <asp:ListItem Value="9">Non-Tribes</asp:ListItem>
                                       <asp:ListItem Value="10">Not dependent on cultivation</asp:ListItem>
                                       <asp:ListItem Value="11">Migrated</asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                            <%--  </ContentTemplate>
                 </asp:UpdatePanel>--%>
                          </div>
                      </div>
                      
                              
              </div>
                      <div id="div_uid" runat="server">
                <div class="card">
                    <div class="card-body">
                  <div class="row">
                         <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Note: Add Survey or Compartment Details on clicking ADD Button. Multiple records can be added by entering all details in the fields using Add button</span></div>
                      </div>
                        <br />
                       <div class="row">
                       <div class="col-md-6">
 <div class="row mb-2">
                            <asp:Label ID="Label8" runat="server" Text="Select Aadhar:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         
                                  <%--<input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly   />   --%>
                             <div class="col-md-6">
                            <asp:DropDownList ID="ddl_uid" CssClass="form-control" AutoPostBack="true"  runat="server"  OnSelectedIndexChanged="ddl_uid_OnSelectedIndexChanged" >

                                                
                                              </asp:DropDownList>
                                      
                                 </div>
                        </div></div>
                       <div class="col-md-6">
                       <div class="row mb-2">
                            <asp:Label ID="Label10" runat="server" Text="Land Type:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         
                                  <%--<input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly   />   --%>
                             <div class="col-md-6">
                            <asp:DropDownList ID="ddl_land_type" CssClass="form-control" AutoPostBack="true"  runat="server"  OnSelectedIndexChanged="ddl_type_OnSelectedIndexChanged">

                                                  <asp:ListItem  Value="0">Select</asp:ListItem>
                                                   <asp:ListItem  Value="1">WebLand</asp:ListItem>
                                                   <asp:ListItem  Value="2">ROFR</asp:ListItem>
                                              </asp:DropDownList>
                                      
                                 </div>
                        </div>
                        </div>
                       </div>
                       <div class="row">
                       <div class="col-md-6">
                        <div class="row mb-2">
                            <asp:Label ID="Label13" runat="server" Text="Survey / Compartment No.:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         <div class="col-md-6">
                             <asp:TextBox ID="txt_cmpno" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return RestrictComma(event);"  oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                  <asp:TextBox ID="txt_cmp_hide" runat="server"  CssClass="form-control" Visible="false"></asp:TextBox>
                         </div></div>
    
                           </div>
                       
                       <div class="col-md-6">
                    <div class="row mb-2">
                            <asp:Label ID="Label15" runat="server" Text="Extent:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         <div class="col-md-6">
                            
                            <asp:TextBox ID="txt_extent" runat="server"  CssClass="form-control" onchange="return fdecimal(this);" autocomplete="off"  onkeypress="return validateFloatKeyPress(this,event);" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox></div></div>
                           </div>
                        </div>
                       <div class="row">
                       <div class="col-md-6">
                     <div class="row mb-2">
                            <asp:Label ID="Label17" runat="server" Text="Katha / Patta No.:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         <div class="col-md-6">
                             
                            <asp:TextBox ID="txt_pattano" runat="server"  CssClass="form-control" autocomplete="off" onkeypress="return RestrictComma(event);" oncopy="return false" onpaste="return false" oncut="return false" ></asp:TextBox></div></div>
                       </div>
                     <div class="col-md-6">
                     <%-- <div class="row mb-2">
                            <asp:Label ID="Label19" runat="server" Text="Remarks:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                        
                             <asp:TextBox ID="txt_remarks" runat="server"  CssClass="form-control" ></asp:TextBox></div></div>
                        </div>--%>
                       <div class="row">
                       <div class="col-md-12">
              <div class="row mb-2 text-center">
                             <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="add_click"  />
                    <asp:Label ID="add_status" runat="server"  CssClass="col-md-6 col-form-label" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                        </div>
                           </div>
                        </div>
                        </div>
                </div>
                  </div>
              </div>

                   <div id="div_rn" runat="server">
               <%-- <div class="card">
                    <div class="card-body">--%>
                 
                    
                       <div class="row">
                       <div class="col-md-6">
 <div class="row mb-2">
                            <asp:Label ID="Label22" runat="server" Text="Reason:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         
                                  <%--<input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly   />   --%>
                             <div class="col-md-6">
                            <asp:DropDownList ID="ddl_reason" CssClass="form-control" AutoPostBack="true"  runat="server"   >
                                   <asp:ListItem Value="0">Select</asp:ListItem>
                                      <asp:ListItem Value="1">Old age</asp:ListItem>
                                      <asp:ListItem Value="2">Own Business</asp:ListItem>
                                      <asp:ListItem Value="3">Widow</asp:ListItem>
                                                 <asp:ListItem Value="4">Minor</asp:ListItem>
                                              </asp:DropDownList>
                                      
                                 </div>
                        </div></div>
                   
                       </div>
                      
               <%-- </div>
                  </div>--%>
              </div>
                   <br />
                   <br />

                       <div class="row">
                         <div class="col-md-12 text-right" id="div1" runat="server">
                                <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click"   />
                             </div>
                      </div>
  </div>
                     </ContentTemplate>
                </asp:UpdatePanel>         
              </div>
          <div class="modal-footer">
           
            <%--  <asp:Button ID="mbtn_submit" runat="server" Text="Submit" OnClick="mbtn_click"  />--%>
           
          </div>
      
        </div>
          </div>
      </div>

</asp:Content>
