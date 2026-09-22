<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LANDTRANSFER_MASTER.Master" AutoEventWireup="true" CodeBehind="ViewLandTransferRegulation.aspx.cs" Inherits="ROFR.pages.ViewLandTransferRegulation" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;">
        <h5 class="text-center text-success mb-4">LAND TRANSFER REGULATIONS</h5>
         <div class="row mb-2" id="po" runat="server">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_mandal" runat="server" Text="MANDAL:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_mandalname" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_village" runat="server" Text="VILLAGE:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_villagename" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

       
        <div id="dvScroll" class="headertable mt-1">
            <asp:Repeater ID="Repeater1" runat="server">

                <HeaderTemplate>
                    <div class="">
                        <%--<h5 class="text-center text-success mb-4">Beneficiary Details</h5>--%>


                        <table id="gvMain" style="border-collapse: collapse;">


                            <thead>



                                <tr class="GridViewScrollHeader">
                                    <td colspan="2" style="background-color: midnightblue;">&nbsp</td>
                                    <td colspan="2" style="background-color: midnightblue;">&nbsp</td>
                                      <th  rowspan="2" scope="col">LTRP No.
                                        <br />
                                        (5)</th>
                                    <th  rowspan="2" scope="col">Date of Orders.
                                        <br />
                                        (6)</th>
                                    <th  rowspan="2" scope="col">R.S.No
                                        <br />
                                        (7)</th>

                                      <th rowspan="2" scope="col">Extent<br />
                                        (Ac-Cts/Hec-a)<br />
                                        (8)</th>
                                  
                                    <th rowspan="2" scope="col">Non Tribal Name
                                        <br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">Tribal Name<br />
                                        (10)</th>
                                    <th rowspan="2" scope="col">Government<br />
                                        (11)</th>
                                    <th rowspan="2" scope="col">CMA No.<br />& Date of Orders<br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">Po/Additional Agent to Government.<br />Non Tribal Name<br />
                                        (13)</th>
                                    <th rowspan="2" scope="col">Po/Additional Agent to Government.<br />Tribal Name<br />
                                        (14)</th>
                                    <th rowspan="2" scope="col">Po/Additional Agent to Government.<br />Government<br />                                      
                                        (15)</th>
                                    <th rowspan="2" scope="col">Appeal No.<br />& Date of Orders<br />
                                        (16)</th>
                                  <th rowspan="2" scope="col">Agent to Government.<br />Non Tribal Name<br />
                                        (17)</th>
                                    <th rowspan="2" scope="col">Agent to Government.<br />Tribal Name<br />
                                        (18)</th>
                                    <th rowspan="2" scope="col">Agent to Government.<br />Government<br />                                      
                                        (19)</th>
                                   
                                    <th rowspan="2" scope="col">R.P.No.<br />& Date of Orders<br />
                                        (20)</th>
                                    <th rowspan="2" scope="col">Government.(Revision)<br />Non Tribal Name<br />
                                        (21)</th>
                                    <th rowspan="2" scope="col">Government.(Revision)<br />Tribal Name<br />
                                        (22)</th>
                                    <th rowspan="2" scope="col">Government.(Revision)<br />Government<br />                                      
                                        (23)</th>
                                    <th rowspan="2" scope="col">W.P.No.<br />& Date of Orders<br />
                                        (24)</th>
                                   <th rowspan="2" scope="col">High Court<br />Non Tribal Name<br />
                                        (25)</th>
                                    <th rowspan="2" scope="col">High Court<br />Tribal Name<br />
                                        (26)</th>
                                    <th rowspan="2" scope="col">High Court<br />Government<br />                                      
                                        (27)</th>
                                     <th rowspan="2" scope="col">Land Already Acquired<br />for any Projectt<br />  
                                        (28)</th>
                                    <th rowspan="2" scope="col">Remarks<br />
                                        (29)</th>
                                    <th rowspan="2" scope="col">Year<br />
                                        (30)</th>
                           
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">S.No<br />
                                        (1)</th>
                                    <th scope="col">MANDAL
                                        <br />
                                        (2)</th>
                                    <th scope="col">VIEW
                                        <br />
                                        (3)</th>
                                    <th scope="col">VILLAGE
                                        <br />
                                        (4)</th>
                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem">

                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("SeNO") %>'></asp:Label>
                            </td>

                             <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_VN" runat="server" Text='<%# Eval("MANDAL") %>' ></asp:Label>

                            </td>
                            <td>
                                <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Id") %>' runat="server" ForeColor="#33cc33" Font-Underline="true" OnClick="Linkview_Click">View</asp:LinkButton>
                            </td>
                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--        <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="txt_MN" runat="server" Text='<%# Eval("VILLAGE") %>' ></asp:Label>
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
                                <%--<asp:TextBox ID="txt_CNO" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' onkeypress='compartnovalidate(event)'></asp:TextBox>
                                   <br />--%>
                                <asp:Label ID="txt_CNO" runat="server" Text='<%# Eval("AAG_CMA_NO") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_PN" runat="server" Text='<%# Eval("PLOT_NO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_PN" runat="server" Text='<%# Eval("AAG_NT") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_EPA" runat="server" Text='<%# Eval("AAG_T") %>' ></asp:Label>
                            </td>


                            <td>
                            <%--<asp:TextBox ID="txt_EUL" runat="server" Text='<%# Eval("EXTENT_UNCULTIVABLE_LAND") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_EUL" runat="server" Text='<%# Eval("AAG_GOVT") %>' ></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txt_ECL" runat="server" Text='<%# Eval("EXTENT_CULTIVABLE_LAND") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_ECL" runat="server" Text='<%# Eval("AG_APPEAL_NO") %>' ></asp:Label>
                            </td>
                              <td>
                               <%-- <asp:DropDownList ID="landclassfication" runat="server"></asp:DropDownList>--%>
                                  <asp:Label ID="txtland" runat="server" Text='<%# Eval("AG_NT") %>' ></asp:Label>
                              <%--    <asp:TextBox ID="txtland" runat="server" Text='<%# Eval("Landclassification") %>' ></asp:TextBox>--%>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txt_PIG" runat="server" Text='<%# Eval("PATTA_INAM_GOVT") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_PIG" runat="server" Text='<%# Eval("AG_T") %>' ></asp:Label>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_WT" runat="server" Text='<%# Eval("WATER_TAX") %>'> </asp:TextBox>--%>
                                 <asp:Label ID="txt_WT" runat="server" Text='<%# Eval("AG_GOVT") %>' ></asp:Label>
                            </td>

                           

                            <td>
                               <%-- <asp:TextBox ID="txt_WS" runat="server" Text='<%# Eval("WATER_SOURCE") %>'></asp:TextBox>--%>
                                 <asp:Label ID="txt_WS" runat="server" Text='<%# Eval("G_RP_NO") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EI" runat="server" Text='<%# Eval("EXTENT_IRRIGATED") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_EI" runat="server" Text='<%# Eval("G_NT") %>' ></asp:Label>
                            </td>

                            <td>
                              <%--  <asp:TextBox ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_RPN" runat="server" Text='<%# Eval("G_T") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_RPD" runat="server" Text='<%# Eval("G_GOVT") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_Fathername" runat="server" Text='<%# Eval("HC_WP_NO") %>' ></asp:Label>
                            </td>

                            <td>
                            <%--    <asp:TextBox ID="txt_CNA" runat="server" Text='<%# Eval("CULTIVATOR_NAME_") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_CNA" runat="server" Text='<%# Eval("HC_NT") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EUC" runat="server" Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_EUC" runat="server" Text='<%# Eval("HC_T") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_HN" runat="server" Text='<%# Eval("HOLDING_NATURE") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HN" runat="server" Text='<%# Eval("HC_GOVT") %>' ></asp:Label>
                            </td>
                             <td>
                              <%--  <asp:TextBox ID="txt_DI" runat="server" Text='<%# Eval("DRY_ID_ONE_CROP_TWO_CROP") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_DI" runat="server" Text='<%# Eval("LAND_ALREADY_ACQUIRED") %>' ></asp:Label>
                            </td>
                            <td>
                              <%--  <asp:TextBox ID="txt_LUTC" runat="server" Text='<%# Eval("LAND_UTILIZATION_TYPE_CODE") %>' onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>--%>
                                <asp:Label ID="txt_LUTC" runat="server" Text='<%# Eval("REMARKS") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_LUE" runat="server" Text='<%# Eval("LAND_UTILAZATION_EXTENT") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_LUE" runat="server" Text='<%# Eval("YEAR") %>' ></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                
                 </div>
                </FooterTemplate>

            </asp:Repeater>
            <input type="hidden" id="div_position" name="div_position" />
            <%--  <tr>
     <td class="text-center">&nbsp;</td>--%>


            <%--  </tr>--%>
        </div>
    </div>
</asp:Content>
