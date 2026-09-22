<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="ForestDivision_Analysis.aspx.cs" Inherits="ROFR.NewPages.ForestDivision_Analysis" EnableEventValidation="false" %>

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


/*  sorting disable for S.No*/
 table.dataTable thead > tr > th.sorting_asc
 {
      cursor: pointer !important;
      position: initial !important;
    
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">FOREST DIVISION MASTER</h5>
          </div>
              <div class="col-md-3 text-right">
                      <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                  <input type="button" value="Back" id="F-rangebackid" class="btn btn-success btn-sm"/>
                   
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
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                              
                                <tr>
                                   <th class="sorting_asc">S.NO</th>
                                    <th>LGD DISTRICT CODE</th>
                                    <th>REVENUE DISTRICT CODE</th>
                                    <th>DISTRICT NAME</th>
                                    <th>FOREST DIVISION CODE</th>
                                    <th>FOREST DIVISION NAME</th>
                                    <th>NO OF RANGES</th>
                                    
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
                 <div class="col-md-12">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_fRange_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                              
                                <tr>
                                    <th>S.NO</th>
                                    <th>LGD DISTRICT CODE</th>
                                    <th>REVENUE DISTRICT CODE</th>
                                    <th>DISTRICT NAME</th>
                                    <th>LGD MANDAL CODE</th>
                                    <th>REVENUE MANDAL CODE</th>
                                    <th>MANDAL NAME</th>
                                    <th>FOREST DIVISION CODE</th>
                                    <th>FOREST DIVISION NAME</th>
                                    <th>FOREST RANGE CODE</th>
                                    <th>FOREST RANGE NAME</th>
                                    <th>NO OF BEATS</th>
                                    
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
                 <div class="col-md-12">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_FBeats_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                              
                                <tr>
                                    <th>S.NO</th>
                                    <th>LGD DISTRICT CODE</th>
                                    <th>REVENUE DISTRICT CODE</th>
                                    <th>DISTRICT NAME</th>
                                    <th>LGD MANDAL CODE</th>
                                    <th>REVENUE MANDAL CODE</th>
                                    <th>MANDAL NAME</th>
                                    <th>LGD VILLAGE CODE</th>
                                    <th>REVENUE VILLAGE CODE</th>
                                    <th>VILLAGE NAME</th>
                                    <th>FOREST DIVISION CODE</th>
                                    <th>FOREST DIVISION NAME</th>
                                    <th>FOREST RANGE CODE</th>
                                    <th>FOREST RANGE NAME</th>
                                    <th>FOREST BEAT CODE</th>
                                    <th>FOREST BEAT NAME</th>
                                    <th>HABITATION NAME</th>
                                    
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
    
   
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="../Newcdn/xlsx.full.min.js"></script>
    <script src="../NewJsFiles/ForestDivision_Analysis.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>

