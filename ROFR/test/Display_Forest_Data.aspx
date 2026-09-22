<%@ Page Title="ROFR FOREST WISE BENIFICIARY DETAILS" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Display_Forest_Data.aspx.cs" Inherits="ROFR.test.Display_Forest_Data"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
/*table {
border-collapse: collapse;
overflow-x: scroll;
display: block;
}*/
/*thead, tbody {
display: block;
}
tbody {
overflow-y: scroll;
overflow-x: hidden;
height: 500px;
width:5700px;
}
td, th {
min-width: 150px;
font-size: 12px;*/
/* height: 25px; */
/*overflow:hidden;
max-width: 300px;

}
 .table tr td {
       border:1px solid #eaeaea !important;}*/

.table tr td {
       border:1px solid #eee !important;}

 
.headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top:  px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;"> 

    <div class="row">
        <div class="col-md-4"></div>
       <div class="col-md-4">
           <h6 class="text-center text-success mb-4">ROFR FOREST WISE BENEFICIARY DETAILS</h6>
           <div class="row"><div class="col-md-2"></div>
               <div class="col-md-4 text-center pt-2"><asp:Label ID="txt_records" runat="server" Text="Select Records: " ></asp:Label></div>

           <div class="col-md-4"><asp:DropDownList ID="ddl_records" style="width:75px" runat="server" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList></div>
      
    </div>
    

            
            
            
             
       
        </div>
        
        <div class="col-md-4"></div>
      </div>
           <div class="row mt-3 mb-3 text-center pt-2 pb-2" style="border-bottom:1px solid #eee;border-top:1px solid #eee;">
                <div class="col-md-3"><asp:Label ID="txtdistrict" runat="server" Text="District:"></asp:Label>
     <asp:Label ID="txt_district"  runat="server"  Font-Bold="True" ></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="txtFD" runat="server" Text="Forest Division:"></asp:Label>
     <asp:Label ID="txt_FD"  runat="server"  Font-Bold="True" ></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="txtFR" runat="server" Text="Forest Range:"></asp:Label>
       <asp:Label ID="txt_FR"  runat="server"  Font-Bold="True" ></asp:Label></div>
                   <div class="col-md-3"><asp:Label ID="txtFB" runat="server" Text="Forest Beat:"></asp:Label>
     <asp:Label ID="txt_FB"  runat="server" Font-Bold="True"  ></asp:Label></div>
            </div>

        <div class="table-responsive">




            



               
      
       
 
    <asp:Repeater ID="Repeater1" runat="server" >

            <HeaderTemplate>
                   <div class="headertable">
            <table class="table table-bordered" style="text-align: center">
                     
      <thead>
                    <tr  class ="header1 text-white text-center" style="background-color: #333 !important;">  
                 <%--    <th style="width:0px"></th>  --%>
                    <th colspan="8" > </th>  
                    <th colspan="3">EXTENT</th>  
                        <th colspan="10"></th> 
                        <th colspan="3">LAND UTILIZATION/ EXTENT LEFT FALLOW</th>  
                         <th colspan="3"></th>
                         <th colspan="3">EXTENT</th>
                       
                         <th colspan="3">EXTENT LAND IRRIGATED</th>
                         <th colspan="6"></th>
                       <%--  <th colspan="2">Datum: WGS84,Indian Bangladesh etc</th>
                   <th colspan="1"></th>--%>
                    </tr>  
                    <tr class="text-white" style="background-color: #38a1d2 !important;">

                    <th>S.No<br />(1)</th> 
                        <%--<th>District</th> --%> 
                        <th>Mandal<br />(2)</th>  
                        <th >Gram Panchayat <br />(3)</th>  
                         <th>Village<br />(4)</th> 
                         <th>Habitation<br />(5)</th>    
                      <%--  <th>Forest Division<br />(4)</th>  --%>
                       <%--  <th>Forest Range<br />(5) </th> --%> 
                        <%-- <th>Forest Beat<br />(6)</th>  --%>
                         <th>Forest Block<br />(6)</th>  
                         <th>Compartment No.<br />(7)</th>  
                         <th>Plot No.<br />(8)</th>  
                         <th>Plot Area<br />(acres)<br />(9)</th>  
                         <th>Uncultivable Land(N.A)<br />(acres)<br />(10)</th>  
                         <th>Cultivable Land(Plot Area)<br />(acres)<br />(11)</th>  
                         <th>PATTA/INAM/GOVT.<br />(12)</th>  
                         <th>Water Tax(N.A)<br />(13)</th>  
                         <th>DRY/ID/ONE CROP/TWO CROP<br />(14)</th>  
                         <th>WATER SOURCE (WELL, IF AVALIABLE, OLD?NEW?)<br />(15)</th>  
                        <th>EXTENT IRRIGATED<br />(acres)<br />(16)</th>  
                    <th>ROFR PATTA NO.<br />(17)</th>  
                        <th>ROFR PATTADAAR<br />(18)</th>  
                        <th>CULTIVATOR NAME<br />(19)</th>  
                        <th>EXTENT UNDER CULTIVATOR<br />(20)</th>  
                        <th>HOLDING NATURE<br />(21)</th>  
                        <th>TYPE (CODE)<br />(22)</th>  
                        <th>EXTENT<br />(acres)<br />(23)</th>  
                        <th>NET SOWN AREA<br />(acres)<br />(24)</th>  
                        <th>KHARIF/RABI<br />(25)</th>  
                        <th>MONTH OF CULTIVATION<br />(26)</th>  
                        <th>CROP<br />(27)</th>  
                        <th>SINGLE<br />(acres)<br />(28)</th>  
                        <th> MIXED<br />(acres)<br />(29)</th>  
                        <th>TOTAL<br />(30)</th>  
                        <th>WATER SOURCE<br />(31)</th>  
                        <th>1st CROP<br />(32)</th>  
                        <th>2nd/3RD<br />(33)</th>  
                        <th>CROP YIELD<br />(34)</th>  
                        <th>VRO/RI REMARKS<br />(35)</th>  
                        <th>TAHSILDAR REMARKS<br />(36)</th>  
                        <th>REMARKS<br />(37)</th>  
                        <%-- <th>AADHAR NO.<br />(38)</th> --%> 
                       <%--  <th>LATITUDE<br />(39)</th>  
                         <th>LONGITUDE<br />(40)</th>  
                       
                       <th >Scan Copy of DLC proceedings YES/NO<br />(41)</th>  --%>

                    </tr>
          </thead>
            </HeaderTemplate>

            <ItemTemplate>

                
                <tr style="background-color: White">
                   
                     <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>

              <%--       <td> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>  </td>--%>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>

           <%--         <td> <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>--%>

          <%--          <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%> </td>--%>

                    <%--<td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>  </td>--%>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.COMPARTMENT_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.PLOT_NO")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_PLOT_AREA")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_UNCULTIVABLE_LAND")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_CULTIVABLE_LAND")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.PATTA_INAM_GOVT")%> </td>
                     <td>  <%#DataBinder.Eval(Container, "DataItem.WATER_TAX")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.DRY_ID_ONE_CROP_TWO_CROP")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.WATER_SOURCE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_IRRIGATED")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTA_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTADAAR")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.CULTIVATOR_NAME_")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_UNDER_CULTIVATOR")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HOLDING_NATURE")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILIZATION_TYPE_CODE")%> </td>




                     <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILAZATION_EXTENT")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILIZATION_NET_SOWN_AREA")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.KHARIFF_RABI")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.MONTH_OF_CULTIVATION")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.CROP")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_SINGLE")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.EXTENT_MIXED")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_TOTAL")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_WATER_SOURCE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_CROP_1")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_CROP_2_3")%> </td>



                    
                     <td>  <%#DataBinder.Eval(Container, "DataItem.CROP_YIELD")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.VRO_RI_REMARKS")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.TAHSILDAR_REMARKS")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.REMARKS")%>  </td>

                 <%--   <td>  <%#DataBinder.Eval(Container, "DataItem.AADHAR_NO")%> </td>--%>

                 <%--   <td>  <%#DataBinder.Eval(Container, "DataItem.DATUM_LATITUDE")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.DATUM_LONGITUDE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.SCAN_COPY_DLC_YES_NO")%> </td>--%>

                  
                </tr>

            </ItemTemplate>

            <AlternatingItemTemplate>

                <tr style="background-color:#AED6FF">

                    <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>

               <%--      <td> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>  </td>--%>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>

<%--                    <td> <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>--%>

              <%--      <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%> </td>--%>

           <%--         <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>  </td>--%>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.COMPARTMENT_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.PLOT_NO")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_PLOT_AREA")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_UNCULTIVABLE_LAND")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_CULTIVABLE_LAND")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.PATTA_INAM_GOVT")%> </td>
                     <td>  <%#DataBinder.Eval(Container, "DataItem.WATER_TAX")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.DRY_ID_ONE_CROP_TWO_CROP")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.WATER_SOURCE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_IRRIGATED")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTA_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTADAAR")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.CULTIVATOR_NAME_")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_UNDER_CULTIVATOR")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HOLDING_NATURE")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILIZATION_TYPE_CODE")%> </td>




                     <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILAZATION_EXTENT")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.LAND_UTILIZATION_NET_SOWN_AREA")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.KHARIFF_RABI")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.MONTH_OF_CULTIVATION")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.CROP")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_SINGLE")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.EXTENT_MIXED")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_TOTAL")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_WATER_SOURCE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_CROP_1")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.EXTENT_LAND_CROP_2_3")%> </td>



                    
                     <td>  <%#DataBinder.Eval(Container, "DataItem.CROP_YIELD")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.VRO_RI_REMARKS")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.TAHSILDAR_REMARKS")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.REMARKS")%>  </td>

<%--                    <td>  <%#DataBinder.Eval(Container, "DataItem.AADHAR_NO")%> </td>--%>

                 <%--   <td>  <%#DataBinder.Eval(Container, "DataItem.DATUM_LATITUDE")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.DATUM_LONGITUDE")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.SCAN_COPY_DLC_YES_NO")%> </td>--%>

                </tr>

            </AlternatingItemTemplate>

            <FooterTemplate>

                  </table>
                </tbody>

            </FooterTemplate>

        </asp:Repeater>
            
        </div>
         </div>
</asp:Content>
