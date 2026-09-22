<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="LandStatusReportBeneficiaryReportN.aspx.cs" Inherits="ROFR.NewPages.LandStatusReportBeneficiaryReportN" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Newcdn/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Newcdn/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/4.2.1/css/fixedColumns.dataTables.min.css" rel="stylesheet"/>

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
             
            <div class="col-md-3"></div>
            <div class="col-md-6">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">Phase-II Beneficiarywise Land Status Report</h5>
          </div>
              <div class="col-md-3 text-right">
                  <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
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
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                
                              <tr>
                                    <th rowspan="2" class="sorting_disabled text-center">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">ITDANAME <br /><span>(1)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">ALREADY APPROVED <br /><span>(3)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">UPTO YESTERDAY &nbsp&nbsp<label id="asonYD"></label> <br /><span>(4)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">AS ON TODAY &nbsp&nbsp<label id="asontodayId"></label> <br /><span>(5)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">CUMULATIVE AS ON &nbsp&nbsp<label id="asontodayId1"></label> <br /><span>(6)</span></th>
                                    
                                </tr>
                                <tr>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
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
                       
                        <table id="dt_Mandal_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              <tr>
                                     
                                    <th rowspan="2" class="sorting_disabled text-center">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">DISTRICT <br /><span>(1)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">UPTO YESTERDAY &nbsp&nbsp<label id="asonYDM"></label> <br /><span>(3)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">AS ON TODAY &nbsp&nbsp<label id="asontodayId2"></label> <br /><span>(4)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">CUMULATIVE AS ON &nbsp&nbsp<label id="asontodayId3"></label> <br /><span>(5)</span></th>
                                    
                                </tr>
                                <tr>
                                    
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT (ACRES) <br /><span>(2)</span></th>
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
    <script src="../Newcdn/xlsx.full.min.js"></script>
   <script src="../NewJsFiles/LandStatusReportBeneficiary.js"></script>
     <script src="../Newcdn/tabletoexcel.js"></script>
    
</asp:Content>
