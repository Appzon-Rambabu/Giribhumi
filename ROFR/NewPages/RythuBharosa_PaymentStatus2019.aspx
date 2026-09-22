<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="RythuBharosa_PaymentStatus2019.aspx.cs" Inherits="ROFR.NewPages.RythuBharosa_PaymentStatus2019"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.datatables.net/v/dt/dt-1.13.4/datatables.min.css" rel="stylesheet"/>
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
  .table thead tr:last-child th:nth-child(1) {
    width: 10px!important;
    text-align:right
}
  
  @media print {
  .header-print {
    display: table-header-group;
  }
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">RYTHU BHAROSA PAYMENT STATUS 2019</h5>
          </div>
              <div class="col-md-3 text-right">
                  <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="mandalbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="villagebackid" class="btn btn-success btn-sm"/>
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
                    <div class="maincard-bdy header-print" >
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                            
                                <tr>
                                   <th>S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th style="text-align:center">PAYMENT SUCCESS <br /><span>(3)</span></th>
                                    <th style="text-align:center">PAYMENT REJECTED <br /><span>(4)</span></th>
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
                       
                        <table id="dt_mandal_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="6" style="text-align:center;color: white;">
                                       ITDA::&nbsp;&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              
                                <tr>
                                 <th>S.NO</th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(1)</span></th>
                                     <th style="text-align:center">PAYMENT SUCCESS <br /><span>(2)</span></th>
                                    <th style="text-align:center">PAYMENT REJECTED <br /><span>(3)</span></th>
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
                       
                        <table id="dt_Village_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="6" style="text-align:center;color: white;">
                                       ITDA::&nbsp;&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;&nbsp;<label id="distval2"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;&nbsp;<label id="manval2"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                   </th>
                               </tr>
                               
                                <tr>
                                 <th>S.NO</th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">PAYMENT SUCCESS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">PAYMENT REJECTED <br /><span>(3)</span></th>
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
                       
                        <table id="dt_RPayment_Success_tbl" class="table table-striped table-bordered dataTable" >
                            
                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="8" style="text-align:center;color: white;">
                                       ITDA::&nbsp;&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;&nbsp;<label id="manval3"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       VILLAGE::&nbsp;&nbsp;<label id="villageval"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               
                                <tr>
                                    <th colspan="1" class="sorting_disabled text-center">S.NO</th>
                                    <th colspan="1" style="text-align:center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th colspan="1" class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(2)</span></th>
                                    <th colspan="1" class="sorting_disabled text-center">FATHER NAME <br /><span>(3)</span></th>
                                    <th colspan="1" style="text-align:center">AADHAAR NO <br /><span>(4)</span></th>
                                    <th colspan="1" style="text-align:center">BANK ACCOUNT NO <br /><span>(5)</span></th>
                                     <th colspan="1" style="text-align:center">IFSC CODE <br /><span>(6)</span></th>
                                    <th colspan="1" class="sorting_disabled text-center">BANK NAME <br /><span>(7)</span></th>
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
                       
                        <table id="dt_RPayment_Rejected_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;&nbsp;<label id="manval4"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        VILLAGE::&nbsp;&nbsp;<label id="villageval4"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   </th>
                                    </tr>
                               
                                <tr>
                                 <th>S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(3)</span></th>
                                    <th style="text-align:center">AADHAAR NO <br /><span>(4)</span></th>
                                    <th style="text-align:center">BANK ACCOUNT NO <br /><span>(5)</span></th>
                                     <th style="text-align:center">IFSC CODE <br /><span>(6)</span></th>
                                    <th style="text-align:center">BANK NAME <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">REJECTED REASON <br /><span>(8)</span></th>
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
    <script src="https://cdn.datatables.net/v/dt/dt-1.13.4/datatables.min.js"></script>
   <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/xlsx.full.min.js"></script>
    <script src="../NewJsFiles/RythubarosaPaymentStatus2019.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>
