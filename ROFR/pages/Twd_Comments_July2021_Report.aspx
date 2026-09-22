<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Twd_Comments_July2021_Report.aspx.cs" Inherits="ROFR.pages.Twd_Comments_July2021_Report"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script src="../linksforcdns/Js/3.5.1.jquery.min.js"></script>
     <script type="text/javascript">

        function openModal() {
            $('#exampleModall').modal('show');
            //$('[id*=exampleModal]').modal('show');
        }
      
    </script>
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:250px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #2f3136 !important;font-size:13px;}
/*.headertable th, .headertable td { padding: 8px 16px; }*/ 
.headertable th { position: sticky; top: -10px; background-color:#008500;}

.headertable .aftr th{position: sticky;top: 49x;}
  .headertable td, .table th {
        padding: .15rem !important;
        font-size: 12px;
      }

        .table td, .table th {
        padding: .15rem !important;
        font-size: 12px;
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
     <div class="panel panel-body">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> </div>
              <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="report_cmnts" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="cmnts_onclick">Click here for Comments wise Details</asp:LinkButton>
               
                   </div>
          
        </div>
          
          <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">TWD COMMENTS JULY 2021 REPORT</h5></div>
              <div class="col-md-4 text-right ">
			  <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="EXCEL1" />&nbsp;&nbsp;
			   <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="EXCEL2" />
			    <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_upload_Click" runat="server" Text="EXCEL3"  Visible="false"/>
                   <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
                <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                   </div>
             
            
        </div>

 
        <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
     

           <asp:Repeater ID="GridView" runat="server"  >
                <HeaderTemplate>
        <table border="1">
             <tr ><th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"></th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                 
              </tr>
          <tr class="aftr">
					
				
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">InEligible</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">InEligible</th>
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
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
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
        <table style="border-color:#2f3136" border="1">
              <tr ><th align="center" colspan="10" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_itda" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"></th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="4" style="text-align:center;background-color: #008500;color: white;">Pending</th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MANDAL</th>
                   <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">InEligible</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Between 1 and 2 Acres</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">InEligible</th>
          		
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
                <asp:Label ID="lbl_tnoland" runat="server" Text='<%# Eval("TOTAL_NOLAND") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_tnoland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_noland"+"-"+ "m_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("TOTAL_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="lbl_tlacre" runat="server" Text='<%# Eval("TOTAL_L1ACRE") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_tlacre" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_l1acre"+"-"+ "m_l1acre"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("TOTAL_L1ACRE") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="lbl_l2acre" runat="server" Text='<%# Eval("TOTAL_L2ACRE") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_l2acre" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_l2acre"+"-"+ "m_l2acre"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("TOTAL_L2ACRE") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="lbl_ineligible" runat="server" Text='<%# Eval("TOTAL_INELIGBLE") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_ineligible" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_ineligible"+"-"+ "m_ineligible"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("TOTAL_INELIGBLE") %>' ></asp:LinkButton>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pnoland" runat="server" Text='<%# Eval("PENDING_NOLAND") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="Link_pnoland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_pnoland"+"-"+ "m_pnoland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("PENDING_NOLAND") %>' ></asp:LinkButton>
                   
            </td>
            <td>
                <asp:Label ID="lbl_placre" runat="server" Text='<%# Eval("PENDING_L1ACRE") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="Link_placre" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_placre"+"-"+ "m_placre"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("PENDING_L1ACRE") %>' ></asp:LinkButton>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pl2acre" runat="server" Text='<%# Eval("PENDING_L2ACRE") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="Link_pl2acre" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_pl2acre"+"-"+ "m_pl2acre"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("PENDING_L2ACRE") %>' ></asp:LinkButton>
                   
            </td>
            <td>
                <asp:Label ID="lbl_pineligible" runat="server" Text='<%# Eval("PENDING_INELIGBLE") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="Link_pineligible" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_pineligible"+"-"+ "m_pineligible"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("PENDING_INELIGBLE") %>' ></asp:LinkButton>
                   
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
              <tr ><th align="center" colspan="13" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_itdad" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="13" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="status" runat="server" Text=""></asp:Label></th>

              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Ration Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Aadhaar Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MANDAL</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">VILLAGE SECRETARIAT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Member Name</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DKT Extent </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Compartment No.</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Survey No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR Extent</th>

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


           <div class="row justify-content-center" style="text-align:right" id="div_village" runat="server">
           <div class="col-md-12">
        <div class="table-responsive">
             <asp:Repeater ID="Repeater2" runat="server"  OnItemDataBound="rpt2_ItemDataBound">
              <HeaderTemplate>
        <table style="border-color:#2f3136" border="1">
              <tr ><th align="center" colspan="13" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_mitdad" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="13" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="mstatus" runat="server" Text=""></asp:Label></th>

              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Ration Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Aadhaar Number</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MANDAL</th>
              		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">VILLAGE SECRETARIAT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Member Name</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DKT Extent </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Compartment No.</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Survey No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR Extent</th>

          </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_mdsno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
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
                <asp:Label ID="lbl_mandalm" runat="server" Text='<%# Eval("OFFICE_NAME_EN") %>' ></asp:Label>
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
      <!-- Modal -->
    <div class="modal fade" id="exampleModall" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
      <div class="modal-dialog modal-xl" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">TWD COMMENTS WISE DETAILS REPORT</h5>
           <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return close();">
               --%>
                <asp:ImageButton ID="btn_close" runat="server" ImageUrl="~/imagesnew/close-button-png-26.png" Height="20px" Width="20px" OnClick="Close_Click" />
             
           <%-- </button>--%>
          </div>
          <div class="modal-body" style="max-height:500px;overflow:auto;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                          <ContentTemplate>
               <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1"></h5></div>
              <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="itda_cmts_back" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_cmtsdist">Back</asp:LinkButton>
               <%-- <asp:LinkButton ID="detail_cmts_back" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>--%>
                   </div>
             
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                         <asp:LinkButton ID="btn_cmts_upload1" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="cmnts_onclick1">EXCEL4(1)</asp:LinkButton>
                          <asp:Button ID="btn_cmts_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btncmtsupload_Click" runat="server" Text="EXCEL4"  />&nbsp;&nbsp;
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_cmts_notuploaded" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_cmtsnotupload_Click" runat="server" Text="EXCEL5" />
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="Button3" class="btn btn-sm btn-success"  AutoPostBack="true"  runat="server" Text="EXCEL6"  Visible="false"/>
                    </div>
                </div>


           </div>
        </div>

  <div class="row d-flex justify-content-center">

                                                           
                                        <div class="col-md-2 d-flex">
                                        <label>Remarks:</label>

                                              <asp:DropDownList ID="ddl_cmts_status" CssClass="form-control" AutoPostBack="true"  Width="150px" runat="server"  OnSelectedIndexChanged="ddlcmts_OnSelectedIndexChanged">

                                                   <asp:ListItem  Value="NO LAND">No Land</asp:ListItem>
                                                   <asp:ListItem  Value="LESS THAN 1">Less than 1 acre</asp:ListItem>
                                                   <asp:ListItem  Value="LESS THAN 2">Between 1 and 2 Acres</asp:ListItem>
                                                   <asp:ListItem  Value="SUB MERGED">In-eligible</asp:ListItem>
                                              </asp:DropDownList>
                                      
                                              </div>
                                    </div>
        <div class="row justify-content-center" style="text-align:right" id="div_itda_cmts" runat="server">
           <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
     

           <asp:Repeater ID="rpt_itda_cmts" runat="server" OnItemDataBound="rpt_itda_cmts_ItemDataBound" >
                <HeaderTemplate>
        <table border="1">
             <tr >
                  <th align="center" colspan="13" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_remarks" runat="server" Text=""></asp:Label>/th>
                 
                 
              </tr>
          <tr class="aftr">
					
				
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">NO LAND </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">LAND TO IDENTIFIED</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">POLAVARAM SUBMERGED</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DEATH CASES</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">NON TRIBES </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">GOVT EMPLOYEE</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">HAVING LAND -NOT UPDATE WEBLAND</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">HAVING LAND -NOT UPDATE GIRIBHUMI</th>

              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">HAVING LAND - MUTATION TO BE DONE</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">NOT DEPEND CULTIVATION</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MIGRATED</th>
          </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_ssno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
              <asp:Label ID="citda" runat="server" Text='<%# Eval("ITDA") %>'  ForeColor="Red" Font-Bold="True" ></asp:Label>
               <%--  <asp:LinkButton ID="lblitda" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"Mandal" +"-"+ "Mandal"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("ITDA_NAME") %>' ></asp:LinkButton>--%>
                </div>
            </td>
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
           <td>
                <asp:Label ID="I_NOLAND" runat="server" Text='<%# Eval("NO_LAND") %>' Visible="false" ForeColor="Green"></asp:Label>
                   <asp:LinkButton ID="Link_INOLAND" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_noland"+"-"+ "i_noland"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("NO_LAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="I_LAND_IDENT" runat="server" Text='<%# Eval("LAND_TO_IDENTIFIED") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_I_LAND_IDENT" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_land_ident"+"-"+ "i_land_ident"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("LAND_TO_IDENTIFIED") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_POLAVARAM" runat="server" Text='<%# Eval("POLAVARAM_SUBMERGED") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_I_POLAVARAM" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_polavaram"+"-"+ "i_polavaram"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("POLAVARAM_SUBMERGED") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_DEATH" runat="server" Text='<%# Eval("DEATH_CASES") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_I_DEATH" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_death"+"-"+ "i_death"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("DEATH_CASES") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_NTRIBES" runat="server" Text='<%# Eval("NON_TRIBES") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_NTRIBES" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_ntribes"+"-"+ "i_ntribes"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("NON_TRIBES") %>' ></asp:LinkButton>
            </td>

              <td>
                <asp:Label ID="I_GOVT" runat="server" Text='<%# Eval("GOVT_EMP") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_GOVT" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_govt"+"-"+ "i_govt"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("GOVT_EMP") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_WEB" runat="server" Text='<%# Eval("NOT_UPDATE_WEBLAND") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_WEB" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_web"+"-"+ "i_web"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("NOT_UPDATE_WEBLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_GIRI" runat="server" Text='<%# Eval("NOT_UPDATE_GIRIBHUMI") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_GIRI" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_giri"+"-"+ "i_giri"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("NOT_UPDATE_GIRIBHUMI") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="I_MUT" runat="server" Text='<%# Eval("MUTATION_PENDING") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_MUT" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_mut"+"-"+ "i_mut"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("MUTATION_PENDING") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="I_CULT" runat="server" Text='<%# Eval("NOT_DEPEND_CULTIVATION") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_CULT" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_cult"+"-"+ "i_cult"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("NOT_DEPEND_CULTIVATION") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="I_MIG" runat="server" Text='<%# Eval("MIGRATED") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_I_MIG" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA")+","+"i_mig"+"-"+ "i_mig"%>' CausesValidation="false"   OnClick="cmtslink_onclick"  Text='<%# Eval("MIGRATED") %>' ></asp:LinkButton>
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
      

           <div class="row justify-content-center" style="text-align:right" id="div_cmts_detaails" runat="server">
           <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
      <asp:Repeater ID="Rpt_cmts_detail" runat="server"  OnItemDataBound="Rpt_cmts_detail_ItemDataBound">
                 <HeaderTemplate>
        <table border="1" >
              <tr ><th align="center" colspan="18" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_cmtsitdaa" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="18" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="cmtsstatus" runat="server" Text=""></asp:Label></th>
                 <%-- <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Noland</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Lessthan 1 Acre</th>
                    <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Greaterthan 1 Acre</th>--%>
              </tr>
             <tr class="aftr" ><th align="center" colspan="18" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="cmtsremarks" runat="server" Text=""></asp:Label></th>
                
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
									<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Ration Number</th>
              									<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Aadhaar Number</th>
              					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
              					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MANDAL</th>
              					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">VILLAGE SECRETARIAT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Member Name</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">DKT Extent </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Compartment No.</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Webland Survey No</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR Dynamic</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR Extent</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">SURVEY/COMPARTMENT/NO.</th>
                            <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">KHATHA/PATTA/NO.</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">EXTENT</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">RN</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land Holding Remarks</th>
          </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lbl_ddsno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label321" runat="server" Text='<%# Eval("EXISTING_RC_NUMBER") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label331" runat="server" Text='<%# Eval("UID_NO") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label341" runat="server" Text='<%# Eval("ITDA") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label351" runat="server" Text='<%# Eval("DIST_NAME_EN") %>'></asp:Label>
            </td>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("OFFICE_NAME_EN") %>' ></asp:Label>
                </div>
            </td>
             <td>   <div style="text-align:left">
                <asp:Label ID="Label361" runat="server" Text='<%# Eval("SECRETARIAT_NAME") %>' ></asp:Label>
                </div>
            </td>
               <td>   <div style="text-align:left">
                <asp:Label ID="Label371" runat="server" Text='<%# Eval("MEMBER_NAME_EN") %>' ></asp:Label>
                </div>
            </td>
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
              <td>
                <asp:Label ID="Label21" runat="server" Text='<%# Eval("DKT_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("WEBLAND_COMP") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label41" runat="server" Text='<%# Eval("WEBLAND_SURVEYNO_DYNAMIC") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label511" runat="server" Text='<%# Eval("ROFR_DYNAMIC") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label61" runat="server" Text='<%# Eval("ROFR_EXTENT_DYNAMIC") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label501" runat="server" Text='<%# Eval("SURVEY_COMPARTMENT_NO") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label5111" runat="server" Text='<%# Eval("KHATHA_PATTA_NO") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label521" runat="server" Text='<%# Eval("EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("RN") %>'></asp:Label>
            </td>
            
             <td>
                <asp:Label ID="Label71" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS") %>'></asp:Label>
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
