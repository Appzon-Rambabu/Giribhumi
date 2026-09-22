<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Benificiarywise_Report.aspx.cs" Inherits="ROFR.pages.Benificiarywise_Report" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#008500;}

.headertable .aftr th{position: sticky;top: 49px;}

     
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

  
      <div class="panel panel-body"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
           
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">BENEFICIARY  PHASESWISE LAND ABSTRACT REPORT</h5></div>
              <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
                  <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="EXCEL" />&nbsp;&nbsp;
                  <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="EXCEL" />
              <%-- <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>--%>
                   </div>
             
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                          
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          
                    </div>
                   
                </div>


           </div>
        </div>
          <br />
            <div class="row justify-content-center">
               
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged">
                         <asp:ListItem  Value="1">Benficiarywise Phases Data</asp:ListItem>
                                                   <asp:ListItem  Value="2">PHASE-I</asp:ListItem>
                                                   <asp:ListItem  Value="3">PHASE-II</asp:ListItem>
                                                   <asp:ListItem  Value="4">Benificaries covered in PHASE-I & PHASE-II</asp:ListItem>
                            </asp:DropDownList>
                    </div>
              
           </div>
              

      
        </div>
           
              </div>
            <br />
       
    <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
  

            <asp:Repeater ID="Grid1" runat="server"  OnItemDataBound="grid1_ItemDataBound">
                <HeaderTemplate>
                      <table style="border-color:brown" border="1">
                     <asp:TemplateField HeaderText="S.NO"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>       

                <tr  >
                 <th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_dlp" runat="server" Text=""></asp:Label></th>
                  
              </tr>
          <tr >
					
				
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">ITDA</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL FARMERS </th>
                    <th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL PLOTS </th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL EXTENT</th>
					
                </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
           
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                </div>
            </td>
                            <td> <div style="text-align:left">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DISTRICT") %>' ForeColor="Red" Visible="false"></asp:Label>
                                  <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("DISTRICT")+"-"+ "BEN"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("DISTRICT") %></asp:LinkButton>
                                 </div>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("NO_OF_FARMERS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NO_OF_PLOTS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TOTAL_EXTENT") %>'></asp:Label>
            </td>
            
            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td>Total</td>
            <td></td>
            <td><asp:Label ID="lblNOOFFARMERS" runat="server" /></td>
            <td><asp:Label ID="lblNOOFPLOTS" runat="server" /></td>
            <td><asp:Label ID="lblTOTALEXTENT" runat="server" /></td>
        </tr>
        </table>
    </FooterTemplate>
           </asp:Repeater>
             </div>
              </div>
               </div>
        </div>
          <div class="row justify-content-center" style="text-align:right" id="div_mandal" runat="server">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
    

            <asp:Repeater ID="Grid2" runat="server"  OnItemDataBound="grid2_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:brown" border="1">
              
             <tr ><th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_dlpp" runat="server" Text=""></asp:Label></th>
                  
              </tr>
          <tr >
					
				
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">ITDA</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">DISTRICT</th>
                    <th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">BENFICIARY ID COVERED IN PHASE-I & PHASE-II</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">PHASE-I EXTENT</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">PHASE-II EXTENT</th>
					
                </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <%--<td>
                <asp:Label ID="lbl_msno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>--%>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                </div>
            </td>
                            <td> <div style="text-align:left">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DISTRICT") %>' ForeColor="Red"  Visible="false"></asp:Label>
                                 <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("DISTRICT")+"-"+ "PBOTH"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("DISTRICT") %></asp:LinkButton>
                                 </div>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("PHASE_I_BEN_IN_PHASE_II") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PHASE_I_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PHASE_II_EXTENT") %>'></asp:Label>
            </td>
            
            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td>Total</td>
            <td></td>
            <td><asp:Label ID="lblPHASEIBENINPHASEII" runat="server" /></td>
            <td><asp:Label ID="lblPHASEIEXTENT" runat="server" /></td>
            <td><asp:Label ID="lblPHASEIIEXTENT" runat="server" /></td>
        </tr>
        </table>
    </FooterTemplate>
           </asp:Repeater>
             </div>
              </div>
               </div>
        </div>
              <div class="row justify-content-center" style="text-align:right" id="div_village" runat="server">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
  

            <asp:Repeater ID="GridV3" runat="server"  OnItemDataBound="rpt_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:brown" border="1">
              <tr ><th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_itda" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr  ><th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_mdlp" runat="server" Text=""></asp:Label></th>
                  
              </tr>
          <tr >
					
				
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">MANDAL</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL FARMERS </th>
              <th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL PLOTS </th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">TOTAL EXTENT</th>
					
                </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <%--<td>
                <asp:Label ID="lbl_msno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>--%>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("DISTRICT") %>' ></asp:Label>
                </div>
            </td>
                            <td> <div style="text-align:left">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("MANDAL") %>' ForeColor="Red"></asp:Label></div>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("NO_OF_FARMERS") %>'></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("NO_OF_PLOTS") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TOTAL_EXTENT") %>'></asp:Label>
            </td>
            
            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
       <tr>
            <td>Total</td>
            <td></td>
            <td><asp:Label ID="lblNOOFFARMERS_M" runat="server" /></td>
            <td><asp:Label ID="lblNOOFPLOTS_M" runat="server" /></td>
            <td><asp:Label ID="lblTOTALEXTENT_M" runat="server" /></td>
       </tr>
       

        </table>
    </FooterTemplate>
           </asp:Repeater>
             </div>
              </div>
               </div>
        </div>

           <div class="row justify-content-center" style="text-align:right" id="div_rejected" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
    
            <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="rpt1_ItemDataBound">
                <HeaderTemplate>
        <table style="border-color:brown" border="1">
              <tr ><th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_itdaa" runat="server" Text=""></asp:Label></th>
             
              </tr>
             <tr >
                 <th  colspan="5" style="text-align:center;color: white;"><asp:Label ID="lbl_mdlpp" runat="server" Text=""></asp:Label></th>
                  
              </tr>
          <tr >
					
				
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">DISTRICT</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">MANDAL</th>
              <th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">BENFICIARY ID COVERED IN PHASE-I & PHASE-II</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">PHASE-I EXTENT</th>
					<th  style="text-align: center; vertical-align: middle;color: white;min-width: 90px;">PHASE-II EXTENT</th>
					
                </tr>
          

    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            <%--<td>
                <asp:Label ID="lbl_msno" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
            </td>--%>
            <td>   <div style="text-align:left">
                <asp:Label ID="lbl_mandal" runat="server" Text='<%# Eval("DISTRICT") %>' ></asp:Label>
                </div>
            </td>
                            <td> <div style="text-align:left">
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("MANDAL") %>' ForeColor="Red"></asp:Label></div>
            </td>
              <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("PHASE_I_BEN_IN_PHASE_II") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PHASE_I_EXTENT") %>'></asp:Label>
            </td>
              <td>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PHASE_II_EXTENT") %>'></asp:Label>
            </td>
            
            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
         <tr>
            <td>Total</td>
            <td></td>
            <td><asp:Label ID="PHASEIBENINPHASEII_M" runat="server" /></td>
            <td><asp:Label ID="PHASEIEXTENT_M" runat="server" /></td>
            <td><asp:Label ID="PHASEIIEXTENT_M" runat="server" /></td>
       </tr>

        </table>
    </FooterTemplate>
           </asp:Repeater>
             </div>
              </div>
               </div>
        </div>
        </div>
    <script src="../newcss/js/jquery-3.5.1.min.js"></script>
</asp:Content>
