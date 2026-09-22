<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Twd_Comments_Report.aspx.cs" Inherits="ROFR.pages.Twd_Comments_Report"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
         
          
          <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">TWD COMMENTS REPORT</h5></div>
              <div class="col-md-4 text-right ">
			  <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="EXCEL" />&nbsp;&nbsp;
			  <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="EXCEL" />
			   <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_upload_Click" runat="server" Text="EXCEL"  Visible="false"/>
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
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                  <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Noland</th>
                  <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Lessthan 1 Acre</th>
                    <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Greaterthan 1 Acre</th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ITDA</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
								<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>
          		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                          <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not Dependent on cultivation</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>

              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not Dependent on cultivation</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>

               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
                  <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>


              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not Dependent on cultivation</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
            
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
                <asp:Label ID="L_L1ACRE" runat="server" Text='<%# Eval("TOATL_L1ACRE") %>' Visible="false" ForeColor="Green"> </asp:Label>
                   <asp:LinkButton ID="Link_L1ACRE" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_lacre"+"-"+ "u_lacre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOATL_L1ACRE") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="L_NOLAND" runat="server" Text='<%# Eval("TOTAL_NOLAND") %>' Visible="false" ForeColor="Green"></asp:Label>
                   <asp:LinkButton ID="Link_NOLAND" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"u_noland"+"-"+ "u_noland"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("TOTAL_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="P_L1ACRE" runat="server" Text='<%# Eval("PENDING_L1ACRE") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_L1ACRE" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_lacre"+"-"+ "p_lacre"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_L1ACRE") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="P_NOLAND" runat="server" Text='<%# Eval("PENDING_NOLAND") %>' Visible="false" ForeColor="Red"></asp:Label>
                   <asp:LinkButton ID="Link_P_NOLAND" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+"p_noland"+"-"+ "p_noland"%>' CausesValidation="false"   OnClick="link_onclick"  Text='<%# Eval("PENDING_NOLAND") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NOLAND_NOLAND") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("LANDIDENTIFIED_NOLAND") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_NOLAND") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("DEATHCASES_NOLAND") %>'></asp:Label>
            </td>


            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NONTRIBES_NOLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("GOVT_EMP_NOLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("WEBLAND_NOLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text='<%# Eval("GIRIBHUMI_NOLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text='<%# Eval("MUTATION_NOLAND") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label38" runat="server" Text='<%# Eval("NOTDEPENDED_NOLAND") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label44" runat="server" Text='<%# Eval("Migrated_NOLAND") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text='<%# Eval("NOLAND_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" Text='<%# Eval("LANDIDENTIFIED_L1") %>'></asp:Label>
            </td>

            <td>
                <asp:Label ID="Label16" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text='<%# Eval("DEATHCASES_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text='<%# Eval("NONTRIBES_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text='<%# Eval("GOVT_EMP_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text='<%# Eval("WEBLAND_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Text='<%# Eval("GIRIBHUMI_L1") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Text='<%# Eval("MUTATION_L1") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label39" runat="server" Text='<%# Eval("NOTDEPENDED_L1") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label45" runat="server" Text='<%# Eval("Migrated_L1") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label23" runat="server" Text='<%# Eval("NOLAND_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label24" runat="server" Text='<%# Eval("LANDIDENTIFIED_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label25" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label26" runat="server" Text='<%# Eval("DEATHCASES_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label27" runat="server" Text='<%# Eval("NONTRIBES_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label28" runat="server" Text='<%# Eval("GOVT_EMP_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label29" runat="server" Text='<%# Eval("WEBLAND_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label30" runat="server" Text='<%# Eval("GIRIBHUMI_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("MUTATION_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label40" runat="server" Text='<%# Eval("NOTDEPENDED_REM") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label46" runat="server" Text='<%# Eval("Migrated_REM") %>'></asp:Label>
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
              <tr ><th align="center" colspan="39" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_itda" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;"></th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                  <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Noland</th>
                  <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Lessthan 1 Acre</th>
                    <th align="center" colspan="11" style="text-align:center;background-color: #008500;color: white;">Greaterthan 1 Acre</th>
              </tr>
          <tr class="aftr">
					<th style="text-align: center; vertical-align: middle;background-color: #008500;color: white;">S.No</th>
				
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">MANDAL</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land </th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Lessthan 1 Acre</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No Land</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
								<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>
          		<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                            <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not dependent on cultivation</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>

              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                                          <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not dependent on cultivation</th>
                    <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">No land Available</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land to be Identified</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Polavaram Submerged</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Death Cases</th>

               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Non-Tribes</th>
                  <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Govt Employee</th>


              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Webland</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Not updated Giribhumi</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Having Land - Mutation to be done</th>
                                        <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Not dependent on cultivation</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Migrated</th>
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
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
              <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TOATL_L1ACRE") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("TOTAL_NOLAND") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PENDING_L1ACRE") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("PENDING_NOLAND") %>'></asp:Label>
                   
            </td>
             <td>
                <asp:Label ID="m_noland" runat="server" Text='<%# Eval("NOLAND_NOLAND") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_m_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"m_noland"+"-"+ "m_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOLAND_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="iden_noland" runat="server" Text='<%# Eval("LANDIDENTIFIED_NOLAND") %>' Visible="false"></asp:Label>
                   <asp:LinkButton ID="Link_iden_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"iden_noland"+"-"+ "iden_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("LANDIDENTIFIED_NOLAND") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_NOLAND") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_pol_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"pol_noland"+"-"+ "pol_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("POLAVARAMSUBMERGED_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="Label9" runat="server" Text='<%# Eval("DEATHCASES_NOLAND") %>' Visible="false"></asp:Label>
                   <asp:LinkButton ID="Link_death_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"death_noland"+"-"+ "death_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("DEATHCASES_NOLAND") %>' ></asp:LinkButton>
            </td>


            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("NONTRIBES_NOLAND") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_ntribes_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"ntribes_noland"+"-"+ "ntribes_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NONTRIBES_NOLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text='<%# Eval("GOVT_EMP_NOLAND") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_govt_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"govt_noland"+"-"+ "govt_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GOVT_EMP_NOLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("WEBLAND_NOLAND") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_web_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"web_noland"+"-"+ "web_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("WEBLAND_NOLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text='<%# Eval("GIRIBHUMI_NOLAND") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_giri_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"giri_noland"+"-"+ "giri_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GIRIBHUMI_NOLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text='<%# Eval("MUTATION_NOLAND") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_muta_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"muta_noland"+"-"+ "muta_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("MUTATION_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="Label41" runat="server" Text='<%# Eval("NOTDEPENDED_NOLAND") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="Link_notde_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"notde_noland"+"-"+ "notde_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOTDEPENDED_NOLAND") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="Label47" runat="server" Text='<%# Eval("Migrated_NOLAND") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="Link_mig_noland" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"mig_noland"+"-"+ "mig_noland"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("Migrated_NOLAND") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text='<%# Eval("NOLAND_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_noland_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"noland_l1"+"-"+ "noland_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOLAND_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" Text='<%# Eval("LANDIDENTIFIED_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_landiden_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"landiden_l1"+"-"+ "landiden_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("LANDIDENTIFIED_L1") %>' ></asp:LinkButton>
            </td>

            <td>
                <asp:Label ID="Label16" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_pol_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"pol_l1"+"-"+ "pol_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("POLAVARAMSUBMERGED_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Text='<%# Eval("DEATHCASES_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_death_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"death_l1"+"-"+ "death_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("DEATHCASES_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text='<%# Eval("NONTRIBES_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_nontribes_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"nontribes_l1"+"-"+ "nontribes_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NONTRIBES_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text='<%# Eval("GOVT_EMP_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_gov_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"gov_l1"+"-"+ "gov_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GOVT_EMP_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text='<%# Eval("WEBLAND_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_web_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"web_l1"+"-"+ "web_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("WEBLAND_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Text='<%# Eval("GIRIBHUMI_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_giri_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"giri_l1"+"-"+ "giri_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GIRIBHUMI_L1") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Text='<%# Eval("MUTATION_L1") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_mut_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"mut_l1"+"-"+ "mut_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("MUTATION_L1") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="Label42" runat="server" Text='<%# Eval("NOTDEPENDED_L1") %>' Visible="false"></asp:Label>
                   <asp:LinkButton ID="Link_notdep_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"notdep_l1"+"-"+ "notdep_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOTDEPENDED_L1") %>' ></asp:LinkButton>
            </td>
              <td>
                <asp:Label ID="Label48" runat="server" Text='<%# Eval("Migrated_L1") %>' Visible="false"></asp:Label>
                   <asp:LinkButton ID="Link_mig_l1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"mig_l1"+"-"+ "mig_l1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("Migrated_L1") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label23" runat="server" Text='<%# Eval("NOLAND_REM") %>' Visible="false" ></asp:Label>
                  <asp:LinkButton ID="Link_noland_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"noland_g1"+"-"+ "noland_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOLAND_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label24" runat="server" Text='<%# Eval("LANDIDENTIFIED_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_landiden_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"landiden_g1"+"-"+ "landiden_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("LANDIDENTIFIED_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label25" runat="server" Text='<%# Eval("POLAVARAMSUBMERGED_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_pol_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"pol_g1"+"-"+ "pol_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("POLAVARAMSUBMERGED_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label26" runat="server" Text='<%# Eval("DEATHCASES_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_death_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"death_g1"+"-"+ "death_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("DEATHCASES_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label27" runat="server" Text='<%# Eval("NONTRIBES_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_nontribe_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"nontribe_g1"+"-"+ "nontribe_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NONTRIBES_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label28" runat="server" Text='<%# Eval("GOVT_EMP_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_gov_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"gov_g1"+"-"+ "gov_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GOVT_EMP_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label29" runat="server" Text='<%# Eval("WEBLAND_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_web_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"web_g1"+"-"+ "web_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("WEBLAND_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label30" runat="server" Text='<%# Eval("GIRIBHUMI_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_giri_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"giri_g1"+"-"+ "giri_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("GIRIBHUMI_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label31" runat="server" Text='<%# Eval("MUTATION_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_mut_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"mut_g1"+"-"+ "mut_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("MUTATION_REM") %>' ></asp:LinkButton>
            </td>
             <td>
                <asp:Label ID="Label43" runat="server" Text='<%# Eval("NOTDEPENDED_REM") %>' Visible="false"></asp:Label>
                  <asp:LinkButton ID="Link_notdep_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"notdep_g1"+"-"+ "notdep_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("NOTDEPENDED_REM") %>' ></asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Label49" runat="server" Text='<%# Eval("Migrated_REM") %>' Visible="false"></asp:Label>
                 <asp:LinkButton ID="Link_mig_g1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL_NAME")+","+"mig_g1"+"-"+ "mig_g1"%>' CausesValidation="false"   OnClick="mlink_onclick"  Text='<%# Eval("Migrated_REM") %>' ></asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
           </asp:Repeater>


            <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="rpt1_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:#2f3136" border="1">
              <tr ><th align="center" colspan="14" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_itdaa" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="14" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="status" runat="server" Text=""></asp:Label></th>
                 <%-- <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Noland</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Lessthan 1 Acre</th>
                    <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Greaterthan 1 Acre</th>--%>
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

					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land Holding Remarks</th>
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
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
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
             <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS") %>'></asp:Label>
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
        <table border="1" >
              <tr ><th align="center" colspan="16" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="lbl_itdaa" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr class="aftr" ><th align="center" colspan="16" style="text-align:center;background-color: #008500;color: white;"><asp:Label ID="status" runat="server" Text=""></asp:Label></th>
                 <%-- <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Updated</th>
                  <th align="center" colspan="2" style="text-align:center;background-color: #008500;color: white;">Pending</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Noland</th>
                  <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Lessthan 1 Acre</th>
                    <th align="center" colspan="9" style="text-align:center;background-color: #008500;color: white;">Greaterthan 1 Acre</th>--%>
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
				<%--	<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR</th>--%>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">ROFR Extent</th>
              <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">SURVEY/COMPARTMENT/NO.</th>
                            <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">KHATHA/PATTA/NO.</th>
               <th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">EXTENT</th>
					<th  style="text-align: center; vertical-align: middle;background-color: #008500;color: white;min-width: 90px;">Land Holding Remarks</th>
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
              <%--<td>
             
                     <div style="text-align:left">
                  
               <asp:Label ID="Label1" runat="server" Text='<%# Eval("DISTRICT") %>'></asp:Label>
                          </div>
                         </td>--%>
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
            <%-- <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("ROFR_EXTENT_DYNAMIC") %>'></asp:Label>
            </td>--%>
             <td>
                <asp:Label ID="Label50" runat="server" Text='<%# Eval("SURVEY_COMPARTMENT_NO") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label51" runat="server" Text='<%# Eval("KHATHA_PATTA_NO") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label52" runat="server" Text='<%# Eval("EXTENT") %>'></asp:Label>
            </td>
             <td>
                <asp:Label ID="Label7" runat="server" Text='<%# Eval("LAND_HOLDING_REMARKS") %>'></asp:Label>
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
      
</asp:Content>
