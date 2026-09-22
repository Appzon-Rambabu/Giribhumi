<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="TWD_Comments_New_Report.aspx.cs" Inherits="ROFR.pages.TWD_Comments_New_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
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
       background-color: #1F5C99 !important;
    font-weight: 100 !important;
       }
  
  
      .table td, .table th {
        padding: .15rem !important;
        font-size: 12px;
      }
    .bg-nav{
      background-color: #1F5C99 !important;
    }
   
  </style>
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: 0px; background-color: #1F5C99;}

.headertable .aftr th{position: sticky;top: 36px;}
.headertable .aftr1 th{position: sticky;top: 72px;}
.headertable .aftr2 th{position: sticky;top: 108px;}

     
    </style>
         <script type="text/javascript">
             function noBack() {
                 window.history.forward()
             }
             noBack();
             window.onload = noBack;
             window.onpageshow = function (evt) { if (evt.persisted) noBack() }
             window.onunload = function () { void (0) }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel panel-body"  style="margin-top:150px;">
         
          
          <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">TWD COMMENTS REPORT</h5></div>
               <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
                <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                   </div>
             
            <div class="col-md-4">

               <%-- <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_abstract" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="GridToExcel" runat="server" Text="ABSTRACT EXCEL" />&nbsp;&nbsp;
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_mabstract" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="ExportToExcel" runat="server" Text="ABSTRACT EXCEL" />
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_details" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="ExportToExcel" runat="server" Text="DETAILS EXCEL" />
                    </div>
                     
                </div>--%>


           </div>
        </div>

 
        <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
     

           <asp:Repeater ID="GridView" runat="server"  >
                <HeaderTemplate>
        <table border="1">
             <tr ><th align="center" colspan="2" style="text-align:center;background-color: #2e44df;color: white;"></th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #2e44df;color: white;">Updated</th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #2e44df;color: white;">Pending</th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">ITDA</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">InEligible</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">InEligible</th>
					
          </tr>
 
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_sno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
              <asp:Label ID="itda" runat="server" Text='<%# Eval("ITDA_NAME") %>' Visible="false" ForeColor="Red" Font-Bold="True" ></asp:Label>
                 <asp:LinkButton ID="lblitda" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"Mandal" +"-"+ "Mandal"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("ITDA_NAME") %>' ></asp:LinkButton>
                </div>
            </td>
             <td>
                <asp:Label ID="L_NOLAND" runat="server" Text='<%# Eval("TOTAL_NOLAND") %>' Visible="false" ForeColor="Green"></asp:Label>
                   <asp:LinkButton ID="Link_NOLAND" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_noland"+"-"+ "u_noland"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOTAL_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="L_L1ACRE" runat="server" Text='<%# Eval("TOTAL_L1ACRE") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_L1ACRE" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_lacre"+"-"+ "u_lacre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOTAL_L1ACRE") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="L_L2ACRE" runat="server" Text='<%# Eval("TOTAL_L2ACRE") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_L2ACRE" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_l2acre"+"-"+ "u_l2acre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOTAL_L2ACRE") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="L_INELIGIBLE" runat="server" Text='<%# Eval("TOTAL_INELIGBLE") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_INELIGIBLE" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_lineligible"+"-"+ "u_lineligible"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOTAL_INELIGBLE") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="P_NOLAND" runat="server" Text='<%# Eval("PENDING_NOLAND") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_NOLAND" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_noland"+"-"+ "p_noland"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_NOLAND") %>' ></asp:LinkButton>
            </td>

              <td>
                <asp:Label ID="P_L1ACRE" runat="server" Text='<%# Eval("PENDING_L1ACRE") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_L1ACRE" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_lacre"+"-"+ "p_lacre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_L1ACRE") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="P_L2ACRE" runat="server" Text='<%# Eval("PENDING_L2ACRE") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_L2ACRE" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_l2acre"+"-"+ "p_l2acre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_L2ACRE") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="P_INELIGIBLE" runat="server" Text='<%# Eval("PENDING_INELIGBLE") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_INELIGIBLE" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_lineligible"+"-"+ "p_lineligible"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_INELIGBLE") %>' ></asp:LinkButton>
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
           <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
      <asp:Repeater ID="rpt1" runat="server"  OnItemDataBound="rpt_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:brown" border="1">
              <tr ><th align="center" colspan="10" style="text-align:center;background-color: #2e44df;color: white;"><asp:Label ID="lbl_itda" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="2" style="text-align:center;background-color: #2e44df;color: white;"></th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #2e44df;color: white;">Updated</th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #2e44df;color: white;">Pending</th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">MANDAL</th>
                   <th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">No Land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">InEligible</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">No land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">InEligible</th>
          		
                </tr>

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_msno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("MANDAL_NAME") %>' ></asp:Label>
                </div>
            </td>
              <td>
                <asp:Label ID="lbl_tnoland" runat="server" Text='<%# Eval("TOTAL_NOLAND") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="lbl_tlacre" runat="server" Text='<%# Eval("TOTAL_L1ACRE") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="lbl_l2acre" runat="server" Text='<%# Eval("TOTAL_L2ACRE") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="lbl_ineligible" runat="server" Text='<%# Eval("TOTAL_INELIGBLE") %>'></asp:Label>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pnoland" runat="server" Text='<%# Eval("PENDING_NOLAND") %>'></asp:Label>
                   
            </td>
            <td>
                <asp:Label ID="lbl_placre" runat="server" Text='<%# Eval("PENDING_L1ACRE") %>'></asp:Label>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pl2acre" runat="server" Text='<%# Eval("PENDING_L2ACRE") %>'></asp:Label>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pineligible" runat="server" Text='<%# Eval("PENDING_INELIGBLE") %>'></asp:Label>
                   
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
           </asp:Repeater>

           <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="rpt1_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:brown" border="1">
              <tr ><th align="center" colspan="14" style="text-align:center;background-color: #2e44df;color: white;"><asp:Label ID="lbl_itdad" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="14" style="text-align:center;background-color: #2e44df;color: white;"><asp:Label ID="status" runat="server" Text=""></asp:Label></th>

              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Ration Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Aadhaar Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">ITDA</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">MANDAL</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">VILLAGE SECRETARIAT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Member Name</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">DKT Extent </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Webland Compartment No.</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">Webland Survey No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">ROFR</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">ROFR Extent</th>

          </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_dsno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Text='<%# Eval("EXISTING_RC_NUMBER") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label33" runat="server" Text='<%# Eval("UID_NO") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label34" runat="server" Text='<%# Eval("ITDA") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label35" runat="server" Text='<%# Eval("DIST_NAME_EN") %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("OFFICE_NAME_EN") %>' ></asp:Label>
                </div>
            </td>
             <td>   <div style="text-align:left">
                <asp:Label ID="Label36" runat="server" Text='<%# Eval("SECRETARIAT_NAME") %>' ></asp:Label>
                </div>
            </td>
               <td>   <div style="text-align:left">
                <asp:Label ID="Label37" runat="server" Text='<%# Eval("MEMBER_NAME_EN") %>' ></asp:Label>
                </div>
            </td>
              <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DKT_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("WEBLAND_COMP") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("WEBLAND_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("ROFR_DYNAMIC") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("ROFR_EXTENT_DYNAMIC") %>'></asp:Label>
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


              <div class="row d-flex justify-content-center">

                                                           
                                        <div class="col-md-2 d-flex">
                                        <label>Remarks:</label>

                                              <asp:DropDownList ID="ddl_status" CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlstatus_OnSelectedIndexChanged">

                                                   <asp:ListItem  Value="NO LAND">No Land</asp:ListItem>
                                                   <asp:ListItem  Value="LESS THAN 1">Less than 1 acre</asp:ListItem>
                                                   <asp:ListItem  Value="LESS THAN 2">Between 1 and 2 Acres</asp:ListItem>
                                                   <asp:ListItem  Value="SUB MERGED">In-eligible</asp:ListItem>
                                              </asp:DropDownList>
                                      
                                              </div>
                                    </div>

               <div class="row justify-content-center mt-3">
                                        <div class="col-md-12">

                                            <div class="table-responsive">
                                                <div id="table-container">
                                                    <div class="headertable">
                                                        <div class="showdetails">
                                                    

    <asp:Repeater ID="Repeater2" runat="server">
    <HeaderTemplate>
        <table border="1" cellpadding="10" width="50%">
              <tr><th id="printHead" align="center" colspan="15" style="text-align:center;background-color: #2e44df;color: white;">TWD Comments Details Report</th></tr>
          <tr class="aftr">
					<th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
				
					<th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">ITDA</th>
					<th colspan="11" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 145px;">No Land</th>

        			</tr>
            <tr class="aftr2">
                    <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">No Land Available</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Land To Be Identified</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Polavaram SubMerged</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Death Casese</th>
                     <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">Non Tribes</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Govt. Employees</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Not Updated in Web Land</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Not Updated in GiriBhumi</th>
                    <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Mutation To Be Done</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Dependent on Cultivation</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Migrated</th>
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
            <td>
                <asp:Label ID="lbl_dsno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ITDA") %>'></asp:Label>
                <asp:LinkButton ID="lblitdadt" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"Mandal" +"-"+ "Mandal"%>' CausesValidation="false"   OnClick="link_donclick"  Text='<%# Eval("ITDA_NAME") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("NO_LAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("LAND_TO_IDENTIFIED") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("POLAVARAM_SUBMERGED") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DEATH_CASES") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NON_TRIBES") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("GOVT_EMP") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("NOT_UPDATE_WEBLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("NOT_UPDATE_GIRIBHUMI") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("MUTATION_PENDING") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("NOT_DEPEND_CULTIVATION") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text='<%# Eval("MIGRATED") %>'></asp:Label>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

                                                             <asp:Repeater ID="Repeater3" runat="server">
    <HeaderTemplate>
        <table border="1" cellpadding="10" width="50%">
              <tr><th id="printHead" align="center" colspan="15" style="text-align:center;background-color: #2e44df;color: white;">TWD Comments Details Report</th></tr>
          <tr class="aftr">
					<th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">S.No</th>
				
					<th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 90px;">MANDAL NAME</th>
					<th colspan="11" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 145px;">No Land</th>

        			</tr>
            <tr class="aftr2">
                    <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">No Land Available</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Land To Be Identified</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Polavaram SubMerged</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Death Casese</th>
                     <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;width:100px;">Non Tribes</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Govt. Employees</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Not Updated in Web Land</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Not Updated in GiriBhumi</th>
                    <th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Having Land - Mutation To Be Done</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Dependent on Cultivation</th>
					<th style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;min-width: 100px;">Migrated</th>
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
             <td>
                <asp:Label ID="lbl_msno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("MANDAL_NAME") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("NO_LAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("LAND_TO_IDENTIFIED") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("POLAVARAM_SUBMERGED") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("DEATH_CASES") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NON_TRIBES") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("GOVT_EMP") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("NOT_UPDATE_WEBLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("NOT_UPDATE_GIRIBHUMI") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("MUTATION_PENDING") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("NOT_DEPEND_CULTIVATION") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text='<%# Eval("MIGRATED") %>'></asp:Label>
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
</asp:Content>
