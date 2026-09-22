<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="HousingReport.aspx.cs" Inherits="ROFR.NewPages.HousingReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
      <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
     <style>
        .table-bordered td {
            border: 1px solid #808080;
        }
        .header{
            text-align:center
        }
        .container-center {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
}
    </style>
      <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }

   
     .table th {
     
       background-color:#008500 !important;
       }
  
  
  
    .bg-nav{
      background-color: #008500 !important;
    }
     #loading-wrapper {
            background: rgba(255, 255, 255, 0.40) !important;
        }
         
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}
/* Default sorting (when not sorted yet) */
/*table.dataTable thead .sorting:before,
table.dataTable thead .sorting:after {
    color: white !important;*/        /* White color */
    /*font-weight: 900 !important;*/    /* Extra bold */
    /*font-size: 18px !important;*/     /* Bigger size */
    /*text-shadow: 0 0 4px black;*/     /* Glow effect for visibility */
/*}*/
 
#dt_dist_tbl tfoot th,
#dt_man_tbl tfoot th,
#dt_Village_tbl tfoot th {
    text-align: left !important;
}
#dt_dist_tbl tfoot th:nth-child(3),
#dt_dist_tbl tfoot th:nth-child(4),
#dt_dist_tbl tfoot th:nth-child(5),
#dt_dist_tbl tfoot th:nth-child(6),

#dt_man_tbl tfoot th:nth-child(3),
#dt_man_tbl tfoot th:nth-child(4),
#dt_man_tbl tfoot th:nth-child(5),
#dt_Village_tbl tfoot th:nth-child(3),
#dt_Village_tbl tfoot th:nth-child(4),
#dt_Village_tbl tfoot th:nth-child(5) {
    text-align: right !important;
}
 
  </style>
    <script>

        function Getxlrpt() {
            var tblid = null;

            // Find first visible table
            $('table').each(function () {
                if ($(this).is(":visible")) {
                    tblid = $(this).attr('id');
                    return false; // stop after first visible table
                }
            });

            if (!tblid) {
                alert("No table is visible to export!");
                return;
            }

            var table = document.getElementById(tblid);

            // Clone table to avoid modifying original
            var cloneTable = table.cloneNode(true);

            // Determine level
            var levelName = "";
            if (tblid.includes("dist")) levelName = "District";
            else if (tblid.includes("man")) levelName = "Mandal";
            else if (tblid.includes("village")) levelName = "Village";
            else if (tblid.includes("VillageDetails")) levelName = "VillageDetails";
           
            else levelName = "Village";

            // Remove header rows based on level
            var thead = cloneTable.querySelector("thead");
            if (thead) {
                if (levelName === "District" && thead.rows.length >= 3) {
                    thead.deleteRow(2); 
                } else if ((levelName === "Mandal") && thead.rows.length >= 3) {
                    thead.deleteRow(0); 
                    thead.deleteRow(2); // Then remove 2nd row (index shifts after deleting 3rd)
                }
                else if ((levelName === "Village") && thead.rows.length >= 3) {
                    thead.deleteRow(0); 
                    thead.deleteRow(2); // Then remove 2nd row (index shifts after deleting 3rd)
                }
                else if ((levelName === "VillageDetails") && thead.rows.length >= 1) {
                    thead.deleteRow(0);
                    
                }
                
            }

            // Convert table to workbook
            var wb = XLSX.utils.table_to_book(cloneTable, { sheet: "Report" });
            var ws = wb.Sheets["Report"];

            // Center-align only header rows (remaining <thead> rows)
            if (thead) {
                for (let r = 0; r < thead.rows.length; r++) {
                    for (let c = 0; c < thead.rows[r].cells.length; c++) {
                        const cell_ref = XLSX.utils.encode_cell({ r: r, c: c });
                        if (!ws[cell_ref]) continue;
                        ws[cell_ref].s = ws[cell_ref].s || {};
                        ws[cell_ref].s.alignment = { horizontal: "center", vertical: "center" };
                    }
                }
            }

            var fileName = levelName + "_Housing_Report.xlsx";

            // Export Excel
            XLSX.writeFile(wb, fileName);
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <span id="userprevilages" style="display:none" runat="server"></span>
         <span id="username" style="display:none" runat="server"></span>
          <span id="ipadress" style="display:none" runat="server"></span>
          <span id="tk" style="display:none" runat="server"></span>
          <label type="text" id="cpt"  style="display:none" runat="server"/>
          <span id="ustart" style="display:none" runat="server"></span>
         <span id="end" style="display:none" runat="server"></span>


          <div class="row justify-content-center">
             
            <div class="col-md-3"></div>
            <div class="col-md-6">
            <h5 class="text-center text-black fw-bold rounded py-1 my-0">HOUSING REPORT</h5>
          </div>
              <div class="col-md-3 text-right">
                  <button type="button" class="btn btn-success btn-sm" onclick="Getxlrpt()">Excel</button>
                    <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                     <input type="button" value="Back" id="manbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="villbackid" class="btn btn-success btn-sm"/>
                     <!-- Your Export Button -->

              </div>
             
        </div>

          <div class="row justify-content-center mt-2">
             <div class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
       
              </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                          <div class="maincard justify-content-center">
                    <div class="maincard-bdy" >
<table id="dt_dist_tbl" class="table table-striped table-bordered dataTable">
  <thead class="bg-info text-white">
    <tr>
      <th>S.No<br /><span>(1)</span></th>
      <th>ITDA Name<br /><span>(2)</span></th>
      <th>District Name<br /><span>(3)</span></th>
      <th>Total Beneficiaries<br /><span>(4)</span></th>
      <th>Total Housing Plots<br /><span>(5)</span></th>
      <th>Total Extent<br /><span>(6)</span></th>
    </tr>
  </thead>
     <tbody></tbody>
  <tfoot class="bg-info text-white" id="dt_dist_tbl1">
    <tr>
      <th colspan="2"></th>
      <th>Total</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </tfoot>
</table>


                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
       
          <div class="row justify-content-center">

                 <div class="col-md-10">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_man_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="5" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
        <th style="width: 10px!important;">S.NO<br /><span>(1)</span></th>
        <th>Mandal Name <br /><span>(2)</span></th>
        <th>Total Beneficiaries<br /><span>(3)</span></th>
        <th>Total Housing plots<br /><span>(4)</span></th>
        <th>Total Extent<br /><span>(5)</span></th>
    </tr>
                               
                                
                            </thead>
                            <tbody></tbody>
                            <tfoot class="bg-info text-white">
    <tr>
       
       <th></th>
       <th>Total</th>
       <th></th>
       <th></th>
       <th></th>
      
      
    </tr>
  </tfoot>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                       
                        <table id="dt_Village_tbl" class="table table-striped table-bordered dataTable">
   <thead class="bg-info text-white">
       <tr>
                                   <th colspan="5" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdavill"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distvill"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="mandvill"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
      <tr>
         <th>S.No<br /><span>(1)</span></th>
         <th>Village Name<br /><span>(2)</span></th>
         <th>Total Beneficiaries<br /><span>(3)</span></th>
         <th>Total Housing Plots<br /><span>(4)</span></th>
         <th>Total Extent<br /><span>(5)</span></th>
      </tr>
   </thead>
   <tbody></tbody>
   <tfoot class="bg-info text-white">
      <tr>
         <th></th>
         <th>Total</th>
         <th></th>
         <th></th>
         <th></th>
      </tr>
   </tfoot>
</table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>

        <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                        <div class="container-center">
                          <div class="maincard justify-content-center" style="width:1500px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_villageDetails_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval3"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="village3"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              

                                <tr>
   <th>S.No<br /><span>(1)</span></th>                                   
   <th>Benficiaryid<br /><span>(2)</span></th>
   <th>Plot id<br /><span>(3)</span></th>
   <th>Rofr Pattadaar<br /><span>(4)</span></th>
   <th>Father Name<br /><span>(5)</span></th>
   <th>Aadhaar No<br /><span>(6)</span></th>
   <th>Rofr Pattano<br /><span>(7)</span></th>
  <th>Compartment No<br /><span>(8)</span></th>
   <th>Extent(acres)<br /><span>(9)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                            
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
        </div>


         <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                        <div class="container-center">
                          <div class="maincard justify-content-center" style="width:1500px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_DistrictDetails_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              

                                <tr>
   <th>S.No<br /><span>(1)</span></th>                                   
   <th>Benficiaryid<br /><span>(2)</span></th>
   <th>Plot id<br /><span>(3)</span></th>
   <th>Rofr Pattadaar<br /><span>(4)</span></th>
   <th>Father Name<br /><span>(5)</span></th>
   <th>Aadhaar No<br /><span>(6)</span></th>
   <th>Rofr Pattano<br /><span>(7)</span></th>
  <th>Compartment No<br /><span>(8)</span></th>
   <th>Extent(acres)<br /><span>(9)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                            
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
        </div>

        <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                        <div class="container-center">
                          <div class="maincard justify-content-center" style="width:1500px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_MandalDetails_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval5"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval5"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval5"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              

                                <tr>
    <th>S.No<br /><span>(1)</span></th>                                   
   <th>Benficiaryid<br /><span>(2)</span></th>
   <th>Plot id<br /><span>(3)</span></th>
   <th>Rofr Pattadaar<br /><span>(4)</span></th>
   <th>Father Name<br /><span>(5)</span></th>
   <th>Aadhaar No<br /><span>(6)</span></th>
   <th>Rofr Pattano<br /><span>(7)</span></th>
  <th>Compartment No<br /><span>(8)</span></th>
   <th>Extent(acres)<br /><span>(9)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                            
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
        </div>

       


         
        
         
    </div>
    
   
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    <script src="../NewJsFiles/HousingReport.js"></script>

    

</asp:Content>
