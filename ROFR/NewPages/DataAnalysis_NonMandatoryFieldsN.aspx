<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="DataAnalysis_NonMandatoryFieldsN.aspx.cs" Inherits="ROFR.NewPages.DataAnalysis_NonMandatoryFieldsN" EnableEventValidation="false" %>
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav" id="Title_Header">DATA ANALYSIS REPORT FOR NONMANDATORY FIELDS
</h5>
          </div>
              <div class="col-md-3 text-right">
                     
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
                 <div class="col-md-12">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                              
                                <tr>
                                  <th  style="width: 10px">S.NO</th>
                                    <th class="sorting_disabled text-center" colspan="1">ITDANAME <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">FARMERS AS PER GIRIBHUMI <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">TOTAL PLOTS <br /><span>(4)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING MANDAL CODE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING MANDAL CODE <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING VILLAGE CODE <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING VILLAGE CODE <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING GRAM PANCHAYAT CODE <br /><span>(9)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING GRAM PANCHAYAT CODE <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING HABITATION CODE <br /><span>(11)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING HABITATION CODE<br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING FOREST DIVISION CODE <br /><span>(13)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING FOREST DIVISION CODE <br /><span>(14)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING FOREST RANGE CODE <br /><span>(15)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING FOREST RANGE CODE <br /><span>(16)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING FOREST BEAT CODE <br /><span>(17)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING FOREST BEAT CODE <br /><span>(18)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING UNCULTIVABLE LAND <br /><span>(19)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING UNCULTIVABLE LAND <br /><span>(20)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING CULTIVABLE LAND <br /><span>(21)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING CULTIVABLE LAND<br /><span>(22)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING WATER TAX <br /><span>(23)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING WATER TAX <br /><span>(24)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING DRYID ONECROP TWOCROP <br /><span>(25)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING DRYID ONECROP TWOCROP <br /><span>(26)</span></th>
                                     <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING WATER SOURCE <br /><span>(27)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING WATER SOURCE <br /><span>(28)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING EXTENT IRRIGATED <br /><span>(29)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING EXTENT IRRIGATED <br /><span>(30)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING EXTENT UNDER CULTIVATO <br /><span>(31)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING EXTENT UNDER CULTIVATOR <br /><span>(32)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING TYPE CODE <br /><span>(33)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING TYPE CODE <br /><span>(34)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING NET SOWN AREA<br /><span>(35)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING NET SOWN AREA <br /><span>(36)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING KHARIFF/RABI <br /><span>(37)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING KHARIFF/RABI <br /><span>(38)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING MONTH OF CULTIVATION <br /><span>(39)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING MONTH OF CULTIVATION <br /><span>(40)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING CROP <br /><span>(41)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING CROP <br /><span>(42)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING EXTENT SINGLE <br /><span>(43)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING EXTENT SINGLE <br /><span>(44)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING EXTENT MIXED <br /><span>(45)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING EXTENT MIXED <br /><span>(46)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING EXTENT TOTAL <br /><span>(47)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING EXTENT TOTAL <br /><span>(48)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING FIRST CROP <br /><span>(49)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING FIRST CROP <br /><span>(50)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING SECOND THIRD CROP <br /><span>(51)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING SECOND THIRD CROP <br /><span>(52)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING CROP YIELD <br /><span>(53)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING CROP YIELD <br /><span>(54)</span></th>

                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS HAVING REMARKS <br /><span>(55)</span></th>
                                    <th class="sorting_disabled text-center" colspan="1">NO.OF PLOTS NOT HAVING REMARKS <br /><span>(56)</span></th>
                                   
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
       
         
    </div>
   <%-- <script>
        function PrintGridData() {
            var prtGrid = document.getElementById('#dt_dist_tbl')[0];
            var title = document.getElementById('Title_Header').parentNode;
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write('<div><div class="col-md-6"></div>' + title.outerHTML + "\r\n" + '</div>' + prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>--%>
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="https://cdn.datatables.net/fixedcolumns/4.2.1/js/dataTables.fixedColumns.min.js"></script>
    <script src="../NewJsFiles/DataAnalysis_NonMandatoryFieldsN.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    
</asp:Content>


