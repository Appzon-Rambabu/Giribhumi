<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="VIEW_LTR.aspx.cs" Inherits="ROFR.pages.VIEW_LTR"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../date/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen"/>
	 <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
   <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

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
     <link href="../css/web.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>
    <script type="text/javascript">
        var gridViewScroll = null;
        window.onload = function () {
            gridViewScroll = new GridViewScroll({
                elementID: "gvMain",
                height: 320,
                freezeColumn: true,
                freezeFooter: false,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                freezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount: 2,
                freezeColumnCount: 2,
                onscroll: function (scrollTop, scrollLeft) {
                    console.log(scrollTop + " - " + scrollLeft);
                }
            });
            gridViewScroll.enhance();

        }
    </script>

    <style>
	@font-face {
  font-family: 'Poppins';
  src: url('/Rofrnewassets/webfonts/Poppins-Regular.ttf') format('truetype');
  font-display: swap; /* 👈 Allows fallback font until Poppins is ready */
}
	
	
	
        #gvMain_Content_Fixed {
            width: 100% !important;
        }
        [role="main"] {
            padding-top: 10px !important;
            background-color: #eee;
            padding-bottom: 20px;
        }
         /*.headertable input, select, textarea { 
            border-color: #a9a9a9 !important;
            border-width: 1px !important;
        }*/
        .table-bordered thead td, .table-bordered thead th {
            border-bottom-width: 1px;
            min-width: 120px;
        }
        .headertable { overflow-y: auto; max-height:400px; } 
        .headertable table { border-collapse: collapse; width: 100%; border:1px solid #111111 !important;}
        .headertable th, .headertable td {} 
        .headertable th { position: sticky; top: -10px; background-color:#008500;}
        .headertable .aftr th{position: sticky;top: 49px;}
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="panel panel-body">
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

        <h5 class="text-center text-success mb-4">VIEW LAND TRANSFER REGULATIONS</h5>
         <asp:UpdatePanel runat="server" ID="updatepanel1">
             <ContentTemplate>
         <div class="row mb-2" id="po" runat="server">
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="ITDA:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label2" runat="server" Text="DISTRICT:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_mandal" runat="server" Text="MANDAL:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_village" runat="server" Text="VILLAGE:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_hab" runat="server" Text="Habitation:"></asp:Label>&nbsp<asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_hab" Style="width: 100%" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_hab_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
             <%--  <div class="col-md-2">
                <div class="row d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-7 text-center ml-0 mr-0">
                        <asp:Label ID="txt_records" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 ml-0 mr-0">
                        <asp:DropDownList ID="ddl_records" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>--%>
        </div>
           
       
        <div id="dvScroll" class="headertable mt-1">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">

                <HeaderTemplate>
                    <div class="">
                        <%--<h5 class="text-center text-success mb-4">Beneficiary Details</h5>--%>

                        <div class="table-responsive">
                        <table class="table-bordered text-center" style="border-collapse:collapse;">


                            <thead>
                                <tr>
                                    <td colspan="2" style="background-color:#008500;color:#fff;">&nbsp</td>
                                    <td colspan="12" style="background-color: #008500;color:#fff;"></td>
                                    <td colspan="1" style="background-color: #008500;color:#fff;">RESPONDENT</td>
                                      <td colspan="2" style="background-color: #008500;color:#fff;">PETITIONER</td>
                                    <td colspan="3" style="background-color: #008500;color:#fff;">ORDERS IN WHOSE FAVOUR</td>
                                   

                                    <td colspan="2" style="background-color: #008500;color:#fff;">ORDERS IMPLEMENTED/AVAILABLE</td>

                                     
                                     
                                      <td colspan="2" style="background-color: #008500;color:#fff;">DETAILS OF LAND FOR TRIBAL</td>
                                     
                                  
                                     <td colspan="2" style="background-color: #008500;color:#fff;">DETAILS OF LAND FOR GOVERNMENT</td>
                                     

                               
                                     <td colspan="2" style="background-color: #008500;color:#fff;"></td>
                                     
                                   
                           
                                </tr>
                                <tr style="background-color: #008500;color:#fff;">

                                    <th scope="col" style="min-width:50px !important;">S.No<br />
                                        (1)</th>
                                     <th scope="col" style="min-width:50px !important;">VIEW
                                        <br />
                                        (2)</th>
                                     <th scope="col">ITDA
                                        <br />
                                        (3)</th>
                                     <th scope="col">DISTRICT
                                        <br />
                                        (4)</th>
                                    <th scope="col">MANDAL
                                        <br />
                                        (5)</th>
                                   
                                    <th scope="col">VILLAGE
                                        <br />
                                        (6)</th>
                                    
                                    <th   scope="col">STATUS
                                        <br />
                                        (7)</th>
                                    <th scope="col">R.S.No
                                        <br />
                                        (8)</th>
                                     <th  scope="col" style="min-width:140px;">EXTENT
                                        (Ac-Cts/Hec-a)<br />
                                        (9)</th>
                                        <th   scope="col">LTRP No.
                                        <br />
                                        (10)</th>
                                    <th   scope="col">DATE OF ORDERS
                                        <br />
                                        (11)</th>
                                    <th  scope="col">DATE OF DISPOSAL<br />  
                                        (12)</th>
                                     <th   scope="col">SDC LEVEL
                                        <br />
                                        (13)</th>
                                    <th   scope="col">SDC ORDERS PASSED
                                        <br />
                                        (14)</th>
                                    
                                    <th  scope="col">NON TRIBAL 
                                        <br />
                                        (15)</th>
                                    <th  scope="col">TRIBAL<br />
                                        (16)</th>
                                    <th  scope="col">GOVERNMENT<br />
                                        (17)</th>
                                       <th  scope="col">NON TRIBAL EXTENT
                                        <br />
                                        (18)</th>
                                    <th  scope="col">TRIBAL EXTENT<br />
                                        (19)</th>
                                    <th  scope="col" style="min-width:140px;">GOVERNMENT EXTENT<br />
                                        (20)</th>
                                    <th  scope="col">TRIBAL <br />
                                        (21)</th>
                                      <th scope="col">GOVT <br />
                                        (22)</th>
                                    
                                  
                                   
                                      <th  scope="col"> AC-CTS<br />  
                                        (23)</th>
                                     <th  scope="col">HEC-A<br />  
                                        (24)</th>
                                         <th scope="col">AC-CTS<br />  
                                        (25)</th>
                                     <th  scope="col"> HEC-A<br />  
                                        (26)</th>
                                     <th scope="col" style="min-width:220px;">Land Already Acquired for any Purpose<br />  
                                        (27)</th>
                                    <th scope="col">Remarks<br />
                                        (28)</th>
                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem">

                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                            </td>
                              <td>
                                <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("LTR_ID")%>' runat="server" ForeColor="#33cc33" Font-Underline="true" OnClick="Linkview_Click">View</asp:LinkButton>
                            </td>
                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="lbl_itda" runat="server" Text='<%# Eval("ITDA") %>' ></asp:Label>

                            </td>
                             <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="lbl_district" runat="server" Text='<%# Eval("DISTRICT") %>' ></asp:Label>

                            </td>
                             <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_VN" runat="server" Text='<%# Eval("MANDAL") %>' ></asp:Label>

                            </td>
                          
                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--        <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="txt_MN" runat="server" Text='<%# Eval("VILLAGE") %>' ></asp:Label>
                            </td>
                               <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--        <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="Label19" runat="server" Text='<%# Eval("STTA") %>' ></asp:Label>
                            </td>
                           
                             <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FBN" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                <asp:Label ID="txt_FBN" runat="server" Text='<%# Eval("RS_NO") %>' ></asp:Label>
                            </td>

                             <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>--%>

                                <%--<asp:TextBox ID="txt_GPN" runat="server" Text='<%# Eval("GP_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_GPN" runat="server" Text='<%# Eval("EXTENT") %>' ></asp:Label>
                            </td>
                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>--%>
                                <%-- <asp:TextBox ID="txt_FDN" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="txt_FDN" runat="server" Text='<%# Eval("LTRP_NO") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FRN" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                <asp:Label ID="txt_FRN" runat="server" Text='<%# Eval("DATE_OF_ORDERS") %>' ></asp:Label>
                            </td>
                              <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("DISPOSAL_DATE") %>' ></asp:Label>
                            </td>

                            
                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HabitationCode")%> --%>
                              <%--  <asp:TextBox ID="txt_HABC" runat="server" Text='<%# Eval("HabitationCode") %>' onkeypress='codevalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_sdclevel" runat="server" Text='<%# Eval("SDC_LEVEL") %>' ></asp:Label>
                            </td>
                                 <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HabitationCode")%> --%>
                              <%--  <asp:TextBox ID="txt_HABC" runat="server" Text='<%# Eval("HabitationCode") %>' onkeypress='codevalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("SDC_ORDERS_PASSED") %>' ></asp:Label>
                            </td>
                          

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HabitationCode")%> --%>
                              <%--  <asp:TextBox ID="txt_HABC" runat="server" Text='<%# Eval("HabitationCode") %>' onkeypress='codevalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HABC" runat="server" Text='<%# Eval("O_IN_FAVOUR_OF_NT") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HABITATION")%>--%>
                               <%-- <asp:TextBox ID="txt_HAB" runat="server" Text='<%# Eval("HABITATION") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HAB" runat="server" Text='<%# Eval("O_IN_FAVOUR_OF_T") %>' ></asp:Label>
                            </td>

                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_FBL" runat="server" Text='<%# Eval("O_GOVT") %>' ></asp:Label>
                            </td>
                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("O_IN_FAVOUR_OF_NT_EXTENT") %>' ></asp:Label>
                            </td>
                          

                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("O_IN_FAVOUR_OF_T_EXTENT") %>' ></asp:Label>
                            </td>
                              <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("O_IN_FAVOUR_OF_GOVT_EXTENT") %>' ></asp:Label>
                            </td>
                          
                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("O_T_ORDERS_IMPLEMENT") %>' ></asp:Label>
                            </td>
                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("O_G_ORDERS_IMPLEMENT") %>' ></asp:Label>
                            </td>
                           

                          
                            

                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("DETAILS_OF_LAND_T_AC_CTS") %>' ></asp:Label>
                            </td>
                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("DETAILS_OF_T_LAND_HEC_A") %>' ></asp:Label>
                            </td>
                           
                         
                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("DETAILS_OF_LAND_G_AC_CTS") %>' ></asp:Label>
                            </td>
                             <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("DETAILS_OF_G_LAND_HEC_A") %>' ></asp:Label>
                            </td>
                               <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("LAND_ALREADY_ACQUIRED") %>' ></asp:Label>
                            </td>

                            <td>
                              <%--  <asp:TextBox ID="txt_LUTC" runat="server" Text='<%# Eval("LAND_UTILIZATION_TYPE_CODE") %>' onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>--%>
                                <asp:Label ID="txt_LUTC" runat="server" Text='<%# Eval("REMARKS") %>' ></asp:Label>
                            </td>

                           
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    </div>
                
                 </div>
                </FooterTemplate>

            </asp:Repeater>
            <input type="hidden" id="div_position" name="div_position" />
            <%--  <tr>
     <td class="text-center">&nbsp;</td>--%>


            <%--  </tr>--%>
        </div>
                  </ContentTemplate>
         </asp:UpdatePanel>
    </div>
	
	  <script src="../Newcdn/jquery-3.5.1.js"></script>
  
</asp:Content>
