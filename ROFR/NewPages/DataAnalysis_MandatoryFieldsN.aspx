<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="DataAnalysis_MandatoryFieldsN.aspx.cs" Inherits="ROFR.NewPages.DataAnalysis_MandatoryFieldsN" EnableEventValidation="false" %>

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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">DATA ANALYSIS MANDATORY FIELDS</h5>
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
                       
  <table id="dt_dist_table" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                              
                                <tr>
                                 <th style="width: 10px!important;">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDANAME <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FARMERS AS PER GIRIBHUMI <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(4)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING MANDAL <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING MANDAL  <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING VILLAGE  <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING VILLAGE  <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING GRAM PANCHAYAT  <br /><span>(9)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING GRAM PANCHAYAT <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING HABITATION  <br /><span>(11)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING HABITATION  <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING FOREST DIVISION  <br /><span>(13)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING FOREST DIVISION <br /><span>(14)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING FOREST RANGE <br /><span>(15)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING FOREST RANGE <br /><span>(16)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING FOREST BEAT <br /><span>(17)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING FOREST BEAT <br /><span>(18)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING FOREST BLOCK <br /><span>(19)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING FOREST BLOCK <br /><span>(20)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING COMPARTMENT NO <br /><span>(21)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING COMPARTMENT NO <br /><span>(22)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING PLOT NO <br /><span>(23)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING PLOT NO <br /><span>(24)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING EXTENT PLOT AREA <br /><span>(25)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING EXTENT PLOT AREA <br /><span>(26)</span></th>
                                     <th class="sorting_disabled text-center">NO.OF PLOTS HAVING PATTA INAM/GOVT <br /><span>(27)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING PATTA INAM/GOVT <br /><span>(28)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING PATTA NO <br /><span>(29)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING PATTA NO <br /><span>(30)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING ROFR PATTADAR <br /><span>(31)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING ROFR PATTADAR <br /><span>(32)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING CULTIVATOR NAME <br /><span>(33)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING CULTIVATOR NAME <br /><span>(34)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING HOLDING NATURE <br /><span>(35)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING HOLDING NATURE <br /><span>(36)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING LAND CLASSIFICATION <br /><span>(37)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING LAND CLASSIFICATION <br /><span>(38)</span></th>
                                    <th class="sorting_disabled text-center">NO.OF PLOTS HAVING ALL MANDATORY FIELDS <br /><span>(39)</span></th>

                                    <th class="sorting_disabled text-center">NO.OF PLOTS NOT HAVING ANY ONE OF THE MANDATORY FIELDS <br /><span>(40)</span></th>
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
    
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="https://cdn.datatables.net/fixedcolumns/4.2.1/js/dataTables.fixedColumns.min.js"></script>
    <script src="../NewJsFiles/DataAnalysis_MandatoryFieldsN.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
    
    <%--<script src="../Newcdn/tabletoexcel.js"></script>--%>
    
</asp:Content>