<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Latlongs_Abstract_ReportN.aspx.cs" Inherits="ROFR.NewPages.Latlongs_Abstract_ReportN" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>

      <script type="text/javascript">
          function noBack() {
              window.history.forward()
          }
          noBack();
          window.onload = noBack;
          window.onpageshow = function (evt) { if (evt.persisted) noBack() }
          window.onunload = function () { void (0) }
      </script>

    <script type="text/javascript" >

        window.onload = function () {

            var table = document.getElementById("dt_man_tbl");
            var rows = table.getElementsByTagName("tr");
            for (i = 0; i < rows.length; i++) {
                rows[i].childNodes[5].onclick = function () { event.cancelBubble = true; }
            }
        }
    </script>
     <style>
        .table-bordered td {
            border: 1px solid #808080;
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
          /*.dt-button.buttons-copy {
              color: #fff !important;
              background-color: #007bff !important;
              border-color: #007bff !important;
          }

          .dt-button.buttons-excel {
              color: #fff !important;
              background-color: #28a745 !important;
              border-color: #28a745 !important;
          }


          .dt-button.buttons-csv {
              color: #fff;
              background-color: #17a2b8 !important;
              border-color: #17a2b8 !important;
          }

          .dt-button.buttons-pdf {
              color: #fff;
              background-color: #dc3545 !important;
              border-color: #dc3545 !important;
          }
          .dt-button.buttons-print {
              color: #fff;
              background-color: #ffc107 !important;
              border-color: #ffc107 !important;
          }
          */
        /* column width size reduce here*/
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}
  
 
  </style>


    <script>
        
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">LATLONGS REPORT</h5>
          </div>
              <div class="col-md-3 text-right">
                  <a id="dld_NotUploadDataID" href='#' onclick='return Download_NotUploadData();' style="color:red;">NotUploadData</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <a id="dld_Lessthan4ID" href='#' onclick='return Download_Lessthan4();' style="color:green;">Download_Lessthan4</a>
                  <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                     <input type="button" value="Back" id="manbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="villbackid" class="btn btn-success btn-sm"/>
                     
              </div>
             
        </div>

          <div class="row justify-content-center mt-2">
             <div class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
             <img src="../Rofrnewassets/images/aplogo.png" alt="Loading"/>
        </span>
      </div>
       
              </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                              <%-- <tr>
                                   <th colspan="8" style="text-align:center;color: white;">DISTRICT WISE LATLONGS REPORT</th>
                               </tr>--%>
                                <tr>
                                 <th  style="width: 10px!important;">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS UPLOADED <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS NOT UPLOADED <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS LESSTHAN 4 <br /><span>(7)</span></th>
                                </tr>
                            </thead>
                            <tbody>

                            </tbody>
                            <tfoot>
	    	
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
                                   <th colspan="7" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="7" style="text-align:center;color: white;">MANDAL WISE LATLONGS REPORT </th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS UPLOADED <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS NOT UPLOADED <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS LESSTHAN 4 <br /><span>(6)</span></th>
                                </tr>
                               
                            </thead>
                            <tbody>
                               
                            </tbody>
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
                                   <th colspan="7" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval2"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">VILLAGE WISE LATLONGS REPORT</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS UPLOADED <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">LATLONGS NOT UPLOADED <br /><span>(5)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
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
                       
                        <table id="dt_vil_rej_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="8" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval3"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="villval"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="8" style="text-align:center;color: white;">VILLAGE WISE NOT HAVING LATLONGS </th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENIFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">PLOT NO <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOTAREA <br /><span>(7)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
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
                       
                        <table id="dt_mandal_rej_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="12" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval4"></label>&nbsp;&nbsp;&nbsp;
                                      
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="12" style="text-align:center;color: white;">MANDAL WISE NOT HAVING LATLONGS</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENIFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDA NAME <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">PATTADAAR NAME  <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">
                                       ROFR PATTADAAR <br /><span>(9)</span>
                                    </th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(11)</span></th>
                                    
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                     <div class="col-md-12">
                           

                     </div>
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_mandal_les_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">

                                 <tr>
                                   <th colspan="12" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval5"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval5"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval5"></label>&nbsp;&nbsp;&nbsp;
                                      
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="12" style="text-align:center;color: white;">MANDAL WISE LATLONGS LESSTHAN 4</th>
                               </tr>--%>
                                <tr>
                                 <th>S.NO</th>
                                    <th class="sorting_disabled text-center">BENIFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDA NAME <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">PATTADAAR NAME <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">
                                       ROFR PATTADAAR <br /><span>(9)</span>
                                    </th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(11)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                      <div class="col-md-12">
                            

                     </div>
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_vill_hav_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                 <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval6"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval6"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval6"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="villval6"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                                    </tr>
                               <%--<tr>
                                   <th colspan="9" style="text-align:center;color: white;">VILLAGE WISE HAVING LATLONGS</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENIFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">PATTADAAR NAME <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(3)</span></th>
                                     <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR NO <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOTAREA <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">LATITUDE <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">LONGITUDE<br /><span>(8)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
     
          <div class="row justify-content-center">
                 <div class="col-md-12">
                      <div class="col-md-12">
                           

                     </div>
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_download_latlongs_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                
                               <%--<tr>
                                   <th colspan="14" style="text-align:center;color: white;">LESSTHAN4 LATLONGS DATA</th>
                               </tr>--%>
                                <tr class="NoExcel">
                                    <th class="sorting_disabled text-center">S.NO</th>
                                   <th class="sorting_disabled text-center">ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">ITDA_NAME <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">District <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">Mandal <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">Gram_Panchayat <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">Village <br /><span>(7)</span>
                                           </th>
                                    <th class="sorting_disabled text-center">Habitation <br /><span>(8)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">ROFR_PATTADAAR <br /><span>(9)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">Father_Name <br /><span>(10)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">ROFR_PATTANO <br /><span>(11)</span>

                                     </th>
                                    <th class="sorting_disabled text-center">Plot_No <br /><span>(12)</span>

                                     </th>
                                    <th class="sorting_disabled text-center">ExtentPlotArea <br /><span>(13)</span>

                                     </th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>

         <div class="row justify-content-center">
                 <div class="col-md-12">
                      <div class="col-md-12">
                     </div>
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Not_Upload_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                
                               <tr>
                                   <th colspan="14" style="text-align:center;color: white;">Not Upload Data Details</th>
                               </tr>
                                <tr>
								<th style="text-align:center">S.NO</th>
                                   <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">ITDA_NAME <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">District <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">Mandal <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">Gram_Panchayat <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">Village <br /><span>(7)</span>
                                           </th>
                                    <th class="sorting_disabled text-center">Habitation <br /><span>(8)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">ROFR_PATTADAAR <br /><span>(9)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">Father_Name <br /><span>(10)</span>
                                     </th>
                                    <th class="sorting_disabled text-center">ROFR_PATTANO <br /><span>(11)</span>

                                     </th>
                                    <th class="sorting_disabled text-center">Plot_No <br /><span>(12)</span>

                                     </th>
                                    <th class="sorting_disabled text-center">ExtentPlotArea <br /><span>(13)</span>

                                     </th>
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
    
    
   


    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/xlsx.full.min.js"></script>
   <script src="../NewJsFiles/Latlongs_Abstract_Reportjs.js"></script>
     <script src="../Newcdn/tabletoexcel.js"></script>
    
</asp:Content>
