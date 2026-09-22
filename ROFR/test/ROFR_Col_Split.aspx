<%@ Page Title="BENIFICIARY DETAILS" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="ROFR_Col_Split.aspx.cs" Inherits="ROFR.test.ROFR_Col_Split" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
/*table {
border-collapse: collapse;
overflow-x: scroll;
display: block;
}
thead, tbody {
display: block;
}
tbody {
overflow-y: scroll;
overflow-x: hidden;
height: 500px;
width:4700px;
}
td, th {
min-width: 150px;
max-width: 300px;
font-size: 12px;
height: 25px; 
overflow:hidden;

}*/
 .table tr td {
       border:1px solid #eee !important;}

 
.headertable { overflow-y: auto; height:550px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 71px;}

</style>

    <script type="text/javascript">

            function PrintDiv() {
                var divToPrint = document.getElementById('printarea');
                var popupWin = window.open('', '_blank', 'width=300,height=400,location=no,left=200px');
                popupWin.document.open();
                popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
                popupWin.document.close();
            }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
     <div class="panel panel-body"> 

    <div class="row">
        <div class="col-md-4"></div>
       <div class="col-md-4">
           <h5 class="text-center text-success mb-4">BENEFICIARY DETAILS</h5>
           <div class="row  d-flex justify-content-center" id ="Select_Records" runat="server">
               <div class="col-md-4 text-center"><asp:Label ID="txt_records" runat="server" Text="Select Records: " ></asp:Label></div>

           <div class="col-md-4"><asp:DropDownList ID="ddl_records" style="width:70px"  runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList></div>
             </div> <div class="row  d-flex justify-content-center mt-3">  
              <div class="col-md-2" >
                  <asp:LinkButton ID="lbtn_part1" runat="server" OnClick="lbtn_part1_Click" Font-Underline="True" ForeColor="Green">Part1</asp:LinkButton></div>
                <div class="col-md-4"  > <asp:LinkButton ID="lbtn_part2" runat="server"  Font-Underline="True" ForeColor="Green" OnClick="lbtn_part2_Click">Part2</asp:LinkButton></div>

       
    </div>

        </div>
        

    
   

        
        <div class="col-md-4"></div>
      </div>
             <div id="printarea">
                 
                <div class="row mt-3 mb-3 text-center pt-2 pb-2" id="div_lbltxt" runat="server" style="border-bottom:1px solid #eee;border-top:1px solid #eee;">
                
                <div class="col-md-3"><asp:Label ID="txtFD" runat="server" Text="Forest Division:"></asp:Label>
     <asp:Label ID="txt_FD"  runat="server"  Font-Bold="True" ></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="txtFR" runat="server" Text="Forest Range:"></asp:Label>
       <asp:Label ID="txt_FR"  runat="server"  Font-Bold="True" ></asp:Label></div>
                   <div class="col-md-3"><asp:Label ID="txtFB" runat="server" Text="Forest Beat:"></asp:Label>
     <asp:Label ID="txt_FB"  runat="server" Font-Bold="True"  ></asp:Label></div>
            </div>
        
              




    <asp:Repeater ID="Repeater1" runat="server"  >

            <HeaderTemplate>
                <div class="headertable">
                    <h5 class="text-center text-success mb-4">Part1 Details</h5>
            <table class="table table-bordered" style="text-align: center">
                     
                         
      <thead>
                    
                    <tr class="text-white" style="background-color: #38a1d2 !important;">

                    <th >S.No<br />(1)</th> 

                        <th>Gram Panchayat <br />(2)</th>  
                    
                         <th>Habitation<br />(3)</th>    
                   
                         <th>Forest Block<br />(4)</th>  
                         <th>Compartment No.<br />(5)</th>  
                         <th>Plot No.<br />(6)</th>  
                         <th>Plot Area<br />(acres)<br />(7)</th>  
                         <th>Uncultivable Land(N.A)<br />(acres)<br />(8)</th>  
                         <th>Cultivable Land(Plot Area)<br />(acres)<br />(9)</th>  
                         <th>PATTA/INAM/GOVT.<br />(10)</th>  
                         <th>Water Tax(N.A)<br />(11)</th>  
                         <th>DRY/ID/ONE CROP/TWO CROP<br />(12)</th>  
                         <th>WATER SOURCE (WELL, IF AVALIABLE, OLD?NEW?)<br />(13)</th>  
                        <th>EXTENT IRRIGATED<br />(acres)<br />(14)</th>  
                        <th>ROFR PATTA NO.<br />(15)</th>  
                        <th>ROFR PATTADAAR<br />(16)</th>  
                        <th>CULTIVATOR NAME<br />(17)</th>  
                        
                      

                    </tr>
          </thead>
            </HeaderTemplate>

            <ItemTemplate>
                  <tbody>

                <tr style="background-color: White">
                   
                     <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>

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

                 
                </tr>
                        </tbody>
            </ItemTemplate>

            <AlternatingItemTemplate>
                  <tbody>
                <tr style="background-color:#AED6FF">

                    <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>


                    <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>


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

                </tr>
  </tbody>
            </AlternatingItemTemplate>

            <FooterTemplate>

                </table>
                 </div>
            </FooterTemplate>

        </asp:Repeater>
            
       
       
      

 
    <asp:Repeater ID="Repeater2" runat="server"  >

            <HeaderTemplate>
                  <div class="headertable">
                      <h5 class="text-center text-success mb-4">Part2 Details</h5>
               <table class="table table-bordered" style="text-align: center">
                     
                     
                         
      <thead>
                    
                     <tr class="text-white" style="background-color: #38a1d2 !important;">
                         <th>S.No<br />(1)</th> 
                          <th>Gram Panchayat <br />(2)</th>  
                    
                         <th>Habitation<br />(3)</th>    
                   
                         <th>Forest Block<br />(4)</th>  
                         <th>Compartment No.<br />(5)</th>  
                         <th>Plot No.<br />(6)</th> 
                        <th>ROFR PATTADAAR<br />(16)</th>  
                        <th>EXTENT UNDER CULTIVATOR<br />(acres)<br />(18)</th>  
                   
                        <th>HOLDING NATURE<br />(19)</th>  
                        <th>TYPE (CODE)<br />(20)</th>  
                        <th>EXTENT<br />(acres)<br />(21)</th>  
                        <th>NET SOWN AREA<br />(acres)<br />(22)</th>  
                        <th>KHARIF/RABI<br />(23)</th>  
                        <th>MONTH OF CULTIVATION<br />(24)</th>  
                        <th>CROP<br />(25)</th>  
                        <th>SINGLE<br />(acres)<br />(26)</th>  
                        <th>MIXED<br />(acres)<br />(27)</th>  
                        <th>TOTAL<br />(28)</th>  
                        <th>WATER SOURCE<br />(29)</th>  
                        <th>1st CROP<br />(30)</th>  
                        <th>2nd/3RD<br />(31)</th>  
                        <th>CROP YIELD<br />(32)</th>  
                        <th>VRO/RI REMARKS<br />(33)</th>  
                        <th>TAHSILDAR REMARKS<br />(34)</th>  
                        <th>REMARKS<br />(35)</th>  
           <%--              <th>AADHAR NO.<br />(36)</th> --%> 
                     

                    </tr>
          </thead>
            </HeaderTemplate>

            <ItemTemplate>

                 <tbody>
                <tr style="background-color: White">
              
                      <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>
                      <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.COMPARTMENT_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.PLOT_NO")%>  </td>
                     <td> <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTADAAR")%>  </td>
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

                   <%-- <td>  <%#DataBinder.Eval(Container, "DataItem.AADHAR_NO")%> </td>--%>

                  
                </tr>
 </tbody>
            </ItemTemplate>

            <AlternatingItemTemplate>
                 <tbody>
                  <tr style="background-color:#AED6FF">

                <td> <%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>
                <td>  <%#DataBinder.Eval(Container, "DataItem.GP_NAME")%>  </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.HABITATION")%> </td>


                    <td>  <%#DataBinder.Eval(Container, "DataItem.FOREST_BLOCK")%> </td>

                    <td>  <%#DataBinder.Eval(Container, "DataItem.COMPARTMENT_NO")%> </td>

                    <td> <%#DataBinder.Eval(Container, "DataItem.PLOT_NO")%>  </td>
                     <td> <%#DataBinder.Eval(Container, "DataItem.ROFR_PATTADAAR")%>  </td>
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

                <%--    <td>  <%#DataBinder.Eval(Container, "DataItem.AADHAR_NO")%> </td>--%>

              
                </tr>
 </tbody>
            </AlternatingItemTemplate>

            <FooterTemplate>

                </table>
                 </div>
            </FooterTemplate>

        </asp:Repeater>
            
        </div>
        
         </div>      
  
          <input id="btnprint" type="button" onclick="PrintDiv()" value="Print" />
        </div>
</asp:Content>
