<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Rofr_LandPhasesReportN.aspx.cs" Inherits="ROFR.NewPages.Rofr_LandPhasesReportN" EnableEventValidation="false" %>
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
         /* .dt-button.buttons-copy {
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
          }*/
        /* column width size reduce here*/
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}
  
 
  </style>

    
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">ROFR STONE PLANTATION PHASE WISE REPORT</h5>
          </div>
              <div class="col-md-3 text-right">
                  <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                   <input type="button" value="Back" id="manbackid" class="btn btn-success btn-sm"/>
                   <input type="button" value="Back" id="vilbackid" class="btn btn-success btn-sm"/>
                      
              </div>
             
        </div>

          <div class="row justify-content-center mt-2">
             <div class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <select class="Benifciary" id="ddl_benificiary" name="dropdown" style="width:200px">  
                                 <option value="0" >ALL</option>  
                                    <option value="1"> PHASE-I </option>  
                                 <option value="2"> PHASE-II</option>  
                                      
                        </select>  
                    </div>
           </div>
        </div>
              </div>

          <div class="row justify-content-center">
                 <div class="col-md-10">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dit_All_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                               <%--<tr>
                                   <th colspan="8" style="text-align:center;color: white;">DISTRICT WISE ROFR STONE PLANTATION PHASE REPORT</th>
                               </tr>--%>
                                <tr>
                                 <th style=" text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS PLOTS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">UPTO YESTERDAY LAND IMAGES UPLOADED <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TODAY LAND IMAGES UPLOADED <br /><span>(5)</span></th>
                                     <th class="sorting_disabled text-center">CUMULATIVE LAND IMAGES UPLOADED <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGES NOT UPLOADED <br /><span>(7)</span></th>
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
                       
                        <table id="dt_mandal_ByAll_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="7" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="7" style="text-align:center;color: white;">MANDAL WISE ALL LAND DETAILS</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS PLOTS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">UPTO YESTERDAY LAND IMAGES UPLOADED <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TODAY LAND IMAGES UPLOADED <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">CUMULATIVE LAND IMAGES UPLOADED <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGES NOT UPLOADED <br /><span>(6)</span></th>
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
                       
                        <table id="dt_Vil_All_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="7" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="7" style="text-align:center;color: white;">VILLAGE WISE ALL LAND DETAILS</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS PLOTS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">UPTO YESTERDAY LAND IMAGES UPLOADED <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TODAY LAND IMAGES UPLOADED <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">CUMULATIVE LAND IMAGES UPLOADED <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGES NOT UPLOADED <br /><span>(6)</span></th>
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
                        <table id="dt_man_All_Notupload_tbl" class="table table-striped table-bordered dataTable" >
                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="10" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdavalANU"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distvalANU"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manvalANU"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="10" style="text-align:center;color: white;">MANDAL WISE ALL LAND IMAGES NOT UPLOADED</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">PLOT NO <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO<br /><span>(9)</span></th>
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
                        <table id="dt_VILL_ALL_Notupload_tbl" class="table table-striped table-bordered dataTable" >
                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="12" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdavalVA"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distvalVA"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manvalPVA"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="VILLvalPVA"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="12" style="text-align:center;color: white;">VILLAGE WISE ALL LAND IMAGES NOT UPLOADED</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">PLOT NO <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(9)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGE1 <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGE2 <br /><span>(11)</span></th>
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
                        <table id="dt_VILL_ALL_upload_tbl" class="table table-striped table-bordered dataTable" >
                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="12" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdavalu"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distvalu"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manvalu"></label>&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;<label id="vilvalu"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="12" style="text-align:center;color: white;">VILLAGE WISE ALL LAND IMAGES UPLOADED</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">PLOT NO <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(9)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGE1 <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">LAND IMAGE2 <br /><span>(11)</span></th>
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


    </div>
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
   <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="https://cdn.datatables.net/fixedcolumns/4.2.1/js/dataTables.fixedColumns.min.js"></script>
   <%-- <script src="../NewJsFiles/BenificiarywiseReport.js"></script>--%>
    <script src="../NewJsFiles/Rofr_Land_PhasesReportjs.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>

