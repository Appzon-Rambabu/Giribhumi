<%@ Page Title="APPROVE BENIFICIARY DETAILS" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="ROFR_BeneficiariesDetailsApproval.aspx.cs" Inherits="ROFR.test.ROFR_BeneficiariesDetailsApproval"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/web1.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>

    <script type="text/javascript">
        var gridViewScroll = null;
        window.onload = function () {
            gridViewScroll = new GridViewScroll({
                elementID: "gvMain",

                height: 400,
                freezeColumn: true,
                freezeFooter: false,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                freezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount: 2,
                freezeColumnCount: 5,
                onscroll: function (scrollTop, scrollLeft) {
                    console.log(scrollTop + " - " + scrollLeft);
                }
            });
            gridViewScroll.enhance();

        }
    </script>
    <style type="text/css">
        .myClass {
            border: 2px solid green;
        }

            .myClass tr {
            }

                .myClass tr:hover {
                    background-color: limegreen;
                    cursor: pointer;
                }
                       .panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}
    </style>
    <style>
        #gvMain_Content_Fixed {
            width: 100% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
   <div class="panel panel-body" style="margin-top:3px;">
        <h5 class="text-center text-success mb-4">APPROVE FARMER DETAILS</h5>
         <div class="row mb-2" id="po" runat="server">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="col-md-2">
                <div class="row d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-7 text-center ml-0 mr-0">
                        <asp:Label ID="txt_records" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 ml-0 mr-0">
                        <asp:DropDownList ID="ddl_records" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-2" id="Director" runat="server">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div12" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                         <asp:Label ID="txt_district1" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_district1" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict1_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="district_Records1" runat="server">
                    <div class="col-md-6 text-center">
                      <asp:Label ID="txt_records1" runat="server" Text="Select Records: "></asp:Label>&nbsp<asp:Label ID="Label141" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                         <asp:DropDownList ID="ddl_records1" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords1_OnSelectedIndexChanged"></asp:DropDownList>
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
                                    <td colspan="5" style="background-color: #007405;">&nbsp</td>
                                    <td colspan="2" style="background-color: #007405;">&nbsp</td>

                                  
                                    <th rowspan="2" scope="col">Gram Panchayat
                                        <br />
                                        (8)</th>
                                    <th rowspan="2" scope="col">Habitation Code
                                        <br />
                                        (9)</th>
                                    <th rowspan="2" scope="col">Habitation<br />
                                        (10)</th>
                                    <th rowspan="2" scope="col">Forest Block<br />
                                        (11)</th>
                                    <th rowspan="2" scope="col">Compartment No.<br />
                                        (12)</th>
                                    <th rowspan="2" scope="col">Plot No.<br />
                                        (13)</th>
                                    <th rowspan="2" scope="col">Extent Plot Area<br />
                                        (acres)<br />
                                        (14)</th>
                                    <th rowspan="2" scope="col">Extent Uncultivable Land(N.A)<br />
                                        (acres)<br />
                                        (15)</th>
                                    <th rowspan="2" scope="col">Extent Cultivable Land(Plot Area)<br />
                                        (acres)<br />
                                        (16)</th>
                                     <th rowspan="2" scope="col">LAND CLASSIFICATION<br />
                                        (17)</th>
                                    <th rowspan="2" scope="col">PATTA/INAM/GOVT.<br />
                                        (18)</th>
                                    <th rowspan="2" scope="col">Water Tax(N.A)<br />
                                        (19)</th>
                                   
                                    <th rowspan="2" scope="col">WATER SOURCE (WELL, IF AVALIABLE, OLD?NEW?)<br />
                                        (20)</th>
                                    <th rowspan="2" scope="col">EXTENT IRRIGATED<br />
                                        (acres)<br />
                                        (21)</th>
                                    <th rowspan="2" scope="col">ROFR PATTA NO.<br />
                                        (22)</th>
                                    <th rowspan="2" scope="col">ROFR PATTADAAR<br />
                                        (23)</th>
                                    <th rowspan="2" scope="col">FATHER NAME<br />
                                        (24)</th>
                                    <th rowspan="2" scope="col">CULTIVATOR NAME<br />
                                        (25)</th>
                                    <th rowspan="2" scope="col">EXTENT UNDER CULTIVATOR<br />
                                        (26)</th>

                                    <th rowspan="2" scope="col">HOLDING NATURE<br />
                                        (27)</th>
                                     <th rowspan="2" scope="col">DRY/ID/ONE CROP/TWO CROP<br />
                                        (28)</th>
                                    <th rowspan="2" scope="col">TYPE (CODE)<br />
                                        (29)</th>
                                    <th rowspan="2" scope="col">EXTENT<br />
                                        (acres)<br />
                                        (30)</th>
                                    <th rowspan="2" scope="col">NET SOWN AREA<br />
                                        (acres)<br />
                                        (31)</th>
                                    <th rowspan="2" scope="col">KHARIF/RABI<br />
                                        (32)</th>
                                    <th rowspan="2" scope="col">MONTH OF CULTIVATION<br />
                                        (33)</th>
                                    <th rowspan="2" scope="col">CROP<br />
                                        (34)</th>
                                    <th rowspan="2" scope="col">EXTENT SINGLE<br />
                                        (acres)<br />
                                        (35)</th>
                                    <th rowspan="2" scope="col">EXTENT MIXED<br />
                                        (acres)<br />
                                        (36)</th>
                                    <th rowspan="2" scope="col">EXTENT TOTAL<br />(acres)<br />
                                        (37)</th>
                                    <th rowspan="2" scope="col">EXTENT CULTIVATED UNDER WATER SOURCE<br />(acres)<br />
                                        (38)</th>
                                    <th rowspan="2" scope="col">EXTENT OF LAND IRRIGATED 1ST CROP<br />(acres)<br />
                                        (39)</th>
                                    <th rowspan="2" scope="col">EXTENT OF LAND IRRIGATED 2ND/3RD<br />(acres)<br />
                                        (40)</th>
                                    <th rowspan="2" scope="col">CROP YIELD<br />
                                        (41)</th>
                                    <th rowspan="2" scope="col">VRO/RI REMARKS<br />
                                        (42)</th>
                                    <th rowspan="2" scope="col">TAHSILDAR REMARKS<br />
                                        (43)</th>
                                    <th rowspan="2" scope="col">REMARKS<br />
                                        (44)</th>
                                    <th rowspan="2" scope="col">AADHAR NO<br />
                                        (45)</th>
                                     <th rowspan="2" scope="col">BANK NAME<br />
                                        (46)</th>
                                    <th rowspan="2" scope="col">BANK ACCOUNT NO<br />
                                        (47)</th>
                                     <th rowspan="2" scope="col">IFSC CODE<br />
                                        (48)</th>
                                    <th rowspan="2" scope="col">DLC DATE<br />
                                        (49)</th>
                                    <th rowspan="2" scope="col">Image<br />
                                        (50)</th>
                                    <th rowspan="2" scope="col">Dlc<br />
                                        (51)</th>
                                    <th rowspan="2" scope="col">
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                    </th>
                                    <th rowspan="2" scope="col" style="width: 0px">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr class="GridViewScrollHeader">

                                    <th scope="col">S.No<br />
                                        (1)</th>
                                    <th scope="col">District
                                        <br />
                                        (2)</th>
                                    <th scope="col">MANDAL
                                        <br />
                                        (3)</th>
                                    <th scope="col">VILLAGE
                                        <br />
                                        (4)</th>
                                      <th  scope="col">Forest Division
                                        <br />
                                        (5)</th>
                                    <th  scope="col">Forest Range
                                        <br />
                                        (6)</th>
                                    <th  scope="col">Forest Beat
                                        <br />
                                        (7)</th>






                                </tr>
                            </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tbody>

                        <tr class="GridViewScrollItem">

                            <td>
                                <asp:Label ID="lbl_Id" runat="server" Text='<%# Eval("sno") %>'></asp:Label>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>  

                            </td>

                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>--%>
                                <%--        <asp:TextBox ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="txt_MN" runat="server" Text='<%# Eval("MANDAL_NAME") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_VN" runat="server" Text='<%# Eval("VILLAGE_NAME") %>' ></asp:Label>

                            </td>


                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>--%>
                                <%-- <asp:TextBox ID="txt_FDN" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                 <asp:Label ID="txt_FDN" runat="server" Text='<%# Eval("FOREST_DIVISION_NAME") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FRN" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                <asp:Label ID="txt_FRN" runat="server" Text='<%# Eval("FOREST_RANGE_NAME") %>' ></asp:Label>
                            </td>


                            <td>
                               <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>--%>
                                <%--  <asp:TextBox ID="txt_FBN" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' onkeypress='mastervalidatenumerics(event)' ></asp:TextBox>--%>
                                <asp:Label ID="txt_FBN" runat="server" Text='<%# Eval("FOREST_BEAT_NAME") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>--%>

                                <%--<asp:TextBox ID="txt_GPN" runat="server" Text='<%# Eval("GP_NAME") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_GPN" runat="server" Text='<%# Eval("GP_NAME") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HabitationCode")%> --%>
                              <%--  <asp:TextBox ID="txt_HABC" runat="server" Text='<%# Eval("HabitationCode") %>' onkeypress='codevalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HABC" runat="server" Text='<%# Eval("HabitationCode") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<%#DataBinder.Eval(Container, "DataItem.HABITATION")%>--%>
                               <%-- <asp:TextBox ID="txt_HAB" runat="server" Text='<%# Eval("HABITATION") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HAB" runat="server" Text='<%# Eval("HABITATION") %>' ></asp:Label>
                            </td>

                            <td>
                                <%-- <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%>--%>

                              <%--  <asp:TextBox ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_FBL" runat="server" Text='<%# Eval("FOREST_BLOCK") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_CNO" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' onkeypress='compartnovalidate(event)'></asp:TextBox>
                                   <br />--%>
                                <asp:Label ID="txt_CNO" runat="server" Text='<%# Eval("COMPARTMENT_NO") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_PN" runat="server" Text='<%# Eval("PLOT_NO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_PN" runat="server" Text='<%# Eval("PLOT_NO") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_EPA" runat="server" Text='<%# Eval("EXTENT_PLOT_AREA") %>' ></asp:Label>
                            </td>


                            <td>
                            <%--<asp:TextBox ID="txt_EUL" runat="server" Text='<%# Eval("EXTENT_UNCULTIVABLE_LAND") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_EUL" runat="server" Text='<%# Eval("EXTENT_UNCULTIVABLE_LAND") %>' ></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txt_ECL" runat="server" Text='<%# Eval("EXTENT_CULTIVABLE_LAND") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_ECL" runat="server" Text='<%# Eval("EXTENT_CULTIVABLE_LAND") %>' ></asp:Label>
                            </td>
                              <td>
                               <%-- <asp:DropDownList ID="landclassfication" runat="server"></asp:DropDownList>--%>
                                  <asp:Label ID="txtland" runat="server" Text='<%# Eval("Landclassification") %>' ></asp:Label>
                              <%--    <asp:TextBox ID="txtland" runat="server" Text='<%# Eval("Landclassification") %>' ></asp:TextBox>--%>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="txt_PIG" runat="server" Text='<%# Eval("PATTA_INAM_GOVT") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_PIG" runat="server" Text='<%# Eval("PATTA_INAM_GOVT") %>' ></asp:Label>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txt_WT" runat="server" Text='<%# Eval("WATER_TAX") %>'> </asp:TextBox>--%>
                                 <asp:Label ID="txt_WT" runat="server" Text='<%# Eval("WATER_TAX") %>' ></asp:Label>
                            </td>

                           

                            <td>
                               <%-- <asp:TextBox ID="txt_WS" runat="server" Text='<%# Eval("WATER_SOURCE") %>'></asp:TextBox>--%>
                                 <asp:Label ID="txt_WS" runat="server" Text='<%# Eval("WATER_SOURCE") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EI" runat="server" Text='<%# Eval("EXTENT_IRRIGATED") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_EI" runat="server" Text='<%# Eval("EXTENT_IRRIGATED") %>' ></asp:Label>
                            </td>

                            <td>
                              <%--  <asp:TextBox ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>' onkeypress='plotnovalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_RPN" runat="server" Text='<%# Eval("ROFR_PATTA_NO") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_RPD" runat="server" Text='<%# Eval("ROFR_PATTADAAR") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_Fathername" runat="server" Text='<%# Eval("Father_Name") %>' ></asp:Label>
                            </td>

                            <td>
                            <%--    <asp:TextBox ID="txt_CNA" runat="server" Text='<%# Eval("CULTIVATOR_NAME_") %>' onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_CNA" runat="server" Text='<%# Eval("CULTIVATOR_NAME_") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_EUC" runat="server" Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_EUC" runat="server" Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_HN" runat="server" Text='<%# Eval("HOLDING_NATURE") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_HN" runat="server" Text='<%# Eval("HOLDING_NATURE") %>' ></asp:Label>
                            </td>
                             <td>
                              <%--  <asp:TextBox ID="txt_DI" runat="server" Text='<%# Eval("DRY_ID_ONE_CROP_TWO_CROP") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_DI" runat="server" Text='<%# Eval("DRY_ID_ONE_CROP_TWO_CROP") %>' ></asp:Label>
                            </td>
                            <td>
                              <%--  <asp:TextBox ID="txt_LUTC" runat="server" Text='<%# Eval("LAND_UTILIZATION_TYPE_CODE") %>' onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>--%>
                                <asp:Label ID="txt_LUTC" runat="server" Text='<%# Eval("LAND_UTILIZATION_TYPE_CODE") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_LUE" runat="server" Text='<%# Eval("LAND_UTILAZATION_EXTENT") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_LUE" runat="server" Text='<%# Eval("LAND_UTILAZATION_EXTENT") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_LUNSA" runat="server" Text='<%# Eval("LAND_UTILIZATION_NET_SOWN_AREA") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_LUNSA" runat="server" Text='<%# Eval("LAND_UTILIZATION_NET_SOWN_AREA") %>' ></asp:Label>
                            </td>

                            <td>
                             <%--   <asp:TextBox ID="txt_KR" runat="server" Text='<%# Eval("KHARIFF_RABI") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_KR" runat="server" Text='<%# Eval("KHARIFF_RABI") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_MOC" runat="server" Text='<%# Eval("MONTH_OF_CULTIVATION") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_MOC" runat="server" Text='<%# Eval("MONTH_OF_CULTIVATION") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_Crop" runat="server" Text='<%# Eval("CROP") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_Crop" runat="server" Text='<%# Eval("CROP") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_ES" runat="server" Text='<%# Eval("EXTENT_SINGLE") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_ES" runat="server" Text='<%# Eval("EXTENT_SINGLE") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_EM" runat="server" Text='<%# Eval("EXTENT_MIXED") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_EM" runat="server" Text='<%# Eval("EXTENT_MIXED") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_ET" runat="server" Text='<%# Eval("EXTENT_TOTAL") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_ET" runat="server" Text='<%# Eval("EXTENT_TOTAL") %>' ></asp:Label>
                            </td>

                            <td>
                              <%--  <asp:TextBox ID="txt_ELWS" runat="server" Text='<%# Eval("EXTENT_LAND_WATER_SOURCE") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_ELWS" runat="server" Text='<%# Eval("EXTENT_LAND_WATER_SOURCE") %>' ></asp:Label>
                            </td>

                            <td>
                               <%-- <asp:TextBox ID="txt_ELCO" runat="server" Text='<%# Eval("EXTENT_LAND_CROP_1") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                <asp:Label ID="txt_ELCO" runat="server" Text='<%# Eval("EXTENT_LAND_CROP_1") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_ELCTH" runat="server" Text='<%# Eval("EXTENT_LAND_CROP_2_3") %>' onkeypress='validate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_ELCTH" runat="server" Text='<%# Eval("EXTENT_LAND_CROP_2_3") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_CY" runat="server" Text='<%# Eval("CROP_YIELD") %>'></asp:TextBox>--%>
                                <asp:Label ID="txt_CY" runat="server" Text='<%# Eval("CROP_YIELD") %>' ></asp:Label>
                            </td>

                            <td>
                              <%--  <asp:TextBox ID="txt_VRE" runat="server" Text='<%# Eval("VRO_RI_REMARKS") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_VRE" runat="server" Text='<%# Eval("VRO_RI_REMARKS") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_TRE" runat="server" Text='<%# Eval("TAHSILDAR_REMARKS") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_TRE" runat="server" Text='<%# Eval("TAHSILDAR_REMARKS") %>' ></asp:Label>
                            </td>

                            <td>
                                <%--<asp:TextBox ID="txt_RE" runat="server" Text='<%# Eval("REMARKS") %>' onkeypress='mastervalidatenumerics(event)'></asp:TextBox>--%>
                                 <asp:Label ID="txt_RE" runat="server" Text='<%# Eval("REMARKS") %>' ></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:TextBox ID="AADHAR_NO" runat="server" Text='<%# Eval("AADHAR_NO") %>' onkeypress='codevalidate(event)'></asp:TextBox>--%>
                                 <asp:Label ID="AADHAR_NO" runat="server" Text='<%# Eval("AADHAR_NO") %>' ></asp:Label>
                            </td>
                             <td>
                                 <asp:Label ID="txt_Bank" runat="server" Text='<%# Eval("BankName") %>' ></asp:Label>
                              <%--  <asp:TextBox ID="txt_Bank" runat="server" Text='<%# Eval("BankName") %>'></asp:TextBox>--%>
                            </td>
                             <td>
                                <%--<asp:TextBox ID="txt_Bankac" runat="server" Text='<%# Eval("BankAccountNo") %>'></asp:TextBox>--%>
                                  <asp:Label ID="txt_Bankac" runat="server" Text='<%# Eval("BankAccountNo") %>' ></asp:Label>
                            </td>
                             <td>
                               <%-- <asp:TextBox ID="txt_ifsc" runat="server" Text='<%# Eval("IfscCode") %>'></asp:TextBox>--%>
                                  <asp:Label ID="txt_ifsc" runat="server" Text='<%# Eval("IfscCode") %>' ></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="txt_dlcdate" runat="server" Text='<%# Eval("Dlc_date") %>' ></asp:Label>
                              <%--  <asp:TextBox ID="txt_dlcdate" runat="server" Text='<%# Eval("Dlc_date") %>' onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox>--%>
                            </td>
                           

                            <td>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImageId="+ Eval("Id") %>' Height="25px" Width="25px" />

                            </td>
                            <td>

                                <asp:LinkButton ID="view_file" CommandArgument='<%#Eval("Id") %>' runat="server" Font-Underline="true" OnClick="Linkview_Click">View DLC</asp:LinkButton>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="false" /></td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                <asp:Label ID="lbl_MNC" runat="server" Text='<%# Eval("MANDAL_CODE") %>'></asp:Label>
                                <asp:Label ID="lbl_VNC" runat="server" Text='<%# Eval("VILLAGE_CODE") %>'></asp:Label>
                                <asp:Label ID="lbl_FDC" runat="server" Text='<%# Eval("FOREST_DIVISION_CODE") %>'></asp:Label>
                                <asp:Label ID="lbl_FRC" runat="server" Text='<%# Eval("FOREST_RANGE_CODE") %>'></asp:Label>
                                <asp:Label ID="lbl_FBC" runat="server" Text='<%# Eval("FOREST_BEATCODE") %>'></asp:Label>
                                <asp:Label ID="txtDlc" runat="server" Text='<%# Eval("Dlc") %>'></asp:Label>
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
        <div class="row justify-content-center mt-1">
            <asp:CheckBox ID="chkAll" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged"  runat="server" Text="Select All"  />

        </div>
        <br />
        <div class="row justify-content-center mt-1">
            <asp:Button ID="btn_submit" OnClick="btnsend_Click"  OnClientClick=" return Validate()" runat="server" Text="APPROVE" />&nbsp&nbsp&nbsp&nbsp
               <asp:Button ID="btn_Reject" OnClick="btnReject_Click"  runat="server" Text="Reject"  />

        </div>
        <br />
        <div class="row justify-content-center mt-1">
            <asp:Label ID="lbl_msg" runat="server" Text="NO DATA FOUND" Visible="false" Width="100px" ForeColor="Red"></asp:Label>
        </div>

    </div>
        </div>



    <%--        </div>
     </div>--%>
    <script>
        function validate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function compartnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9&]|\,/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function plotnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9/]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function codevalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\0/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function mastervalidatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z]|\A/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function pattadarnamevalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z0-9/]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function validatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z/]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        //function SelectAllCheckboxes(chk) {
        //    if (chk.Checked == true)
        //    {
        //        alert("CheckBox checked.");
        //    }
        //    else if (chk.Checked == false) {
        //        alert("CheckBox checked.");
        //    }


        //}
    </script>
</asp:Content>
