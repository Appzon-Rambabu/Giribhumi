<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="ITDAWISE_BENICIARY_MASTERN.aspx.cs" Inherits="ROFR.NewPages.ITDAWISE_BENICIARY_MASTERN" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>
     <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.css" />
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
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
  .table thead tr:last-child th:nth-child(0) {
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
             
            <div class="col-md-3" >
                 <%--<span style="color: red">NOTE: Click on Excel to download all records at once</span> --%>
            </div>
            <div class="col-md-6">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav"> FARMER DETAILS REPORT</h5>

          </div>
              <div class="col-md-3 text-right">
                   <span style="color: red" id="NoteID">NOTE: Click on Excel to download all records at once</span>:: 
                  <button onclick="ExportToExcel()" name="ALL_DATA_ID" class="btn btn-success btn-sm">Excel</button>
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
         <div class="row">
                       <div class="col-auto"><b>ITDA:</b>

                       </div>
                        <div class="col-md-2">
                                    <select name="itda" id="itda" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                               
                                    </select>
                        </div>
                        <div class="col-auto"><b>DISTRICT:</b>
                       </div>
                           <div class="col-md-2">
                                    <select name="itda" id="Districtid" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>

                               
                        </div>
                         <div class="col-auto"><b>Select To View Records:</b>

                       </div>
                        <div class="col-md-2">
                                    <select name="Count" id="SelectRecordsid" class="form-control" style="width:200px;height:20px">
                                     <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>
                        </div>   

            </div>
        <br />
           <div class="row justify-content-center">
                 <div class="col-md-12">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                         
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable" >
                            <thead class="bg-info text-white">
                                <tr>
                                 <th  style="width: 10px!important;">S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDA NAME <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">SUB CASTE <br /><span>(9)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">BANK ACCOUNT NO <br /><span>(11)</span></th>
                                     <th class="sorting_disabled text-center">IFSC CODE <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">BANK NAME <br /><span>(13)</span></th>
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
                                                  <div class="col-md-10  justify-content-center" >
                                               
                                                <table class="table table-bordered mb-0" id="tbl_exporttable_to_xls">
                                                    <thead>
                                                       
                                                        <tr>
                                                           <th  style="width: 10px!important;">S.NO</th>
                                                                <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                                                <th class="sorting_disabled text-center">ITDA NAME <br /><span>(2)</span></th>
                                                                <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                                                <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                                                <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                                                <th class="sorting_disabled text-center">HABITATION <br /><span>(6)</span></th>
                                                                <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(7)</span></th>
                                                                <th class="sorting_disabled text-center">FATHER NAME <br /><span>(8)</span></th>
                                                                <th class="sorting_disabled text-center">SUB CASTE <br /><span>(9)</span></th>
                                                                <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(10)</span></th>
                                                                <th class="sorting_disabled text-center">BANK ACCOUNT NO <br /><span>(11)</span></th>
                                                                 <th class="sorting_disabled text-center">IFSC CODE <br /><span>(12)</span></th>
                                                                <th class="sorting_disabled text-center">BANK NAME <br /><span>(13)</span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
															<tr>
                                                            <td></td>
															<td></td>
															<td></td>
															<td></td>
															<td></td>
                                                            <td></td>
                                                            <td></td>
															<td></td>
															<td></td>
															<td></td>
															<td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
															</tr>
                                                    </tbody>
                                                </table>

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

    <script src="https://cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.js"></script>
    <script src="https://cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"></script>
   <script type="text/javascript" src="https://unpkg.com/xlsx@0.15.1/dist/xlsx.full.min.js"></script>

    <script src="../NewJsFiles/ITDAWISE_BENEFICIARY_MASTERJS.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>


   
    
</asp:Content>