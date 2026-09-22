<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="CFRREPORT.aspx.cs" Inherits="ROFR.NewPages.CFRREPORT" EnableEventValidation="false" %>

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
      text-align: center;
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
table.dataTable thead .sorting:before,
table.dataTable thead .sorting:after {
    color: white !important;        /* White color */
    font-weight: 900 !important;    /* Extra bold */
    font-size: 18px !important;     /* Bigger size */
    text-shadow: 0 0 4px black;     /* Glow effect for visibility */
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
            else if (tblid.includes("YTSC")) levelName = "YTSC";
            else if (tblid.includes("YTSL")) levelName = "YTSL";
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
                else if ((levelName === "YTSC") && thead.rows.length >= 1) {
                    thead.deleteRow(0);
                    
                }
                else if ((levelName === "YTSL") && thead.rows.length >= 1) {
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

            var fileName = levelName + "_CFR_Report.xlsx";

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
            <h5 class="text-center text-black fw-bold rounded py-1 my-0">CFR REPORT</h5>
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
                          <div class="maincard justify-content-center" style="width:1200px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                             									
	
                                <tr>
                                 <th rowspan="2"  style="width: 10px!important;"  class="text-center align-middle">S.NO</th>
                                    <th rowspan="2" class="text-center  align-middle">ITDA Name<br /></th>
                                    <th rowspan="2" class="text-center  align-middle">District Name <br /></th>
                                    <th colspan="4" class="text-center">CFR Claims Entry Status<br /></th>
                                    <th colspan="3" class="text-center">Members Details Entry Status<br /></th>
                                    <th colspan="2" class="text-center">Lat&longs Entry Status<br /></th>
                                </tr>

                                 <tr>
                                     <th class="text-center">Total Claims<br /></th>
                                    <th class="text-center" style="width: 75px!important;">Members Details Uploaded<br/></th>
                                    <th class="text-center" style="width: 50px!important;">Yet to Submit<br /></th>
                                    <th class="text-center" style="width: 60px!important;">Total Extent <br /></th>
                                    <th class="text-center">Total<br /></th>
                                    <th class="text-center"> Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                    <th class="text-center">Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                </tr>
                                <tr>
                                    <th class="text-center"><span>(1)</span></th>
                                    <th class="text-center"><span>(2)</span></th>
                                    <th class="text-center"><span>(3)</span></th>
                                    <th class="text-center"><span>(4)</span></th>
                                    <th class="text-center"><span>(5)</span></th>
                                    <th class="text-center"><span>(6)</span></th>
                                    <th class="text-center"><span>(7)</span></th>
                                    <th class="text-center"><span>(8)</span></th>
                                    <th class="text-center"><span>(9)</span></th>
                                    <th class="text-center"><span>(10)</span></th>
                                    <th class="text-center"><span>(11)</span></th>
                                    <th class="text-center"><span>(12)</span></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                            </tbody>
                            
                            <tfoot>
    <tr>
        <th class="text-right text-white"></th>
        <th class="text-right text-white"></th>
      <th class="text-center text-white">Total</th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      
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
                                   <th colspan="11" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              
                                <tr>
                                 <th rowspan="2" style="text-align:center" class="text-center align-middle">S.NO</th>
                                    <th rowspan="2" class="text-center align-middle">Mandal Name <br /></th>
                                     <th colspan="4" class="text-center">CFR Claims Entry Status<br /></th>
                                    <th colspan="3" class="text-center">Members Details Entry Status<br /></th>
                                    <th colspan="2" class="text-center">Lat&longs Entry Status<br /></th>
                                </tr>
                               <tr>
                                     <th class="text-center">Total Claims<br /></th>
                                    <th class="text-center" style="width:75px">Members Details Uploaded<br /></th>
                                    <th class="text-center">Yet to Submit<br /></th>
                                    <th class="text-center">Total Extent <br /></th>
                                    <th class="text-center">Total<br /></th>
                                    <th class="text-center"> Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                    <th class="text-center">Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                </tr>
                                <tr>
                                    <th class="text-center"><span>(1)</span></th>
                                    <th class="text-center"><span>(2)</span></th>
                                    <th class="text-center"><span>(3)</span></th>
                                    <th class="text-center"><span>(4)</span></th>
                                    <th class="text-center"><span>(5)</span></th>
                                    <th class="text-center"><span>(6)</span></th>
                                    <th class="text-center"><span>(7)</span></th>
                                    <th class="text-center"><span>(8)</span></th>
                                    <th class="text-center"><span>(9)</span></th>
                                    <th class="text-center"><span>(10)</span></th>
                                    <th class="text-center"><span>(11)</span></th>
                                    
                                </tr>
                            </thead>
                            <tbody>
                               
                            </tbody>
                            <tfoot>
    <tr>
       
        <th class="text-right text-white"></th>
      <th class="text-right text-white">Total</th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      
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
                       
                        <table id="dt_Village_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="11" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval2"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
                                 <th rowspan="2" style="text-align:center" class="text-center align-middle">S.NO</th>
                                    <th rowspan="2" class="text-center align-middle">Village Name<br /></th>
                                      <th colspan="4" class="text-center">CFR Claims Entry Status<br /></th>
                                    <th colspan="3" class="text-center">Members Details Entry Status<br /></th>
                                    <th colspan="2" class="text-center">Lat&longs Entry Status<br /></th>
                                </tr>
                                <tr>
                                     <th class="text-center">Total Claims<br /></th>
                                    <th class="text-center" style="width:75px">Members Details Uploaded<br /></th>
                                    <th class="text-center">Yet to Submit<br /></th>
                                    <th class="text-center">Total Extent <br /></th>
                                    <th class="text-center">Total<br /></th>
                                    <th class="text-center"> Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                    <th class="text-center">Submitted<br /></th>
                                    <th class="text-center">Yet to Submit <br /></th>
                                </tr>
                                <tr>
                                    <th class="text-center"><span>(1)</span></th>
                                    <th class="text-center"><span>(2)</span></th>
                                    <th class="text-center"><span>(3)</span></th>
                                    <th class="text-center"><span>(4)</span></th>
                                    <th class="text-center"><span>(5)</span></th>
                                    <th class="text-center"><span>(6)</span></th>
                                    <th class="text-center"><span>(7)</span></th>
                                    <th class="text-center"><span>(8)</span></th>
                                    <th class="text-center"><span>(9)</span></th>
                                    <th class="text-center"><span>(10)</span></th>
                                    <th class="text-center"><span>(11)</span></th>
                                    
                                </tr>
                            </thead>
                            <tbody></tbody>
                            <tfoot>
    <tr>
       
        <th class="text-right text-white"></th>
      <th class="text-right text-white">Total</th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
         <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
      
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
                          <div class="maincard justify-content-center" style="width:800px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_cfridyts_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="4" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval3"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="village3"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
   <th class="text-center">S.NO<br /><span>(1)</span></th>
   <th class="text-center">CFRID<br /><span>(2)</span></th>
   <th class="text-center">Total Members<br /><span>(3)</span></th>
   <th class="text-center">Total Extent<br /><span>(4)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                             <tfoot>
    <tr>
        <th class="text-right text-white"></th>
      <th class="text-right text-white">Total</th>
      
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
    </tr>
  </tfoot>
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
                          <div class="maincard" style="width:800px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_cfridytsLot_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="4" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval4"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="village5"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
   <th class="text-center">S.NO<br /><span>(1)</span></th>
   <th class="text-center">CFRID<br /><span>(2)</span></th>
   <th class="text-center">Total Members<br /><span>(3)</span></th>
   <th class="text-center">Total Extent<br /><span>(4)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                            <tfoot>
    <tr>
        <th class="text-right text-white"></th>
      <th class="text-right text-white">Total</th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
    </tr>
  </tfoot>
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
                          <div class="maincard" style="width:800px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_cfridmemsub_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="4" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdamem"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distmem"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manmem"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="villmem"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
   <th class="text-center">S.NO<br /><span>(1)</span></th>
   <th class="text-center">CFRID<br /><span>(2)</span></th>
   <th class="text-center">Total Members<br /><span>(3)</span></th>
   <th class="text-center">Submitted Members<br /><span>(4)</span></th>
</tr>
                                
                            </thead>
                            <tbody></tbody>
                            <tfoot>
    <tr>
        <th class="text-right text-white"></th>
      <th class="text-right text-white">Total</th>
      <th class="text-right text-white"></th>
      <th class="text-right text-white"></th>
    </tr>
  </tfoot>
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
                          <div class="maincard" style="width:1200px">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_cfridmemdet_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="6" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdamemdet"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distmemdet"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manmemdet"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="villmemdet"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
   <th class="text-center">S.NO<br /><span>(1)</span></th>
   <th class="text-center">CFRID<br /><span>(2)</span></th>
   <th class="text-center">FarmerID<br /><span>(3)</span></th>
   <th class="text-center">Representative Name<br /><span>(4)</span></th>
   <th class="text-center">Father Name<br /><span>(5)</span></th>
   <th class="text-center">Aadhaar NO<br /><span>(6)</span></th>
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
    <script src="../NewJsFiles/Cfrreport.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    
</asp:Content>