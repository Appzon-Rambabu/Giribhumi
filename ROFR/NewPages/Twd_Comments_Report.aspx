<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Twd_Comments_Report.aspx.cs" Inherits="ROFR.NewPages.Twd_Comments_Report" %>

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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">TWD COMMENTS REPORT</h5>
          </div>
              <div class="col-md-3 text-right">
                  <%--<input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="mandalbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="villagebackid" class="btn btn-success btn-sm"/>--%>
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
                                          <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable ">
                               <thead class="bg-info text-white">
                                   
                                <tr>
                                    <th rowspan="2">S.NO</th>
                                    <th rowspan="2" style="text-align:center">ITDA</th>
                                    <th colspan="2" style="text-align:center">UPDATED</th>
                                    <th colspan="2" style="text-align:center">Pending</th>
                                    <th colspan="11" style="text-align:center">Noland</th>
                                    <th colspan="11" style="text-align:center">Lessthan 1 Acre</th>
                                    <th colspan="11" style="text-align:center">Greaterthan 1 Acre</th>
                                </tr>
                                <tr>
                                  
                                    <th>Lessthan 1 Acre</th>
                                    <th>No Land</th>
                                    <th>Lessthan 1 Acre</th>
                                    <th>No Land</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged	</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
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
                                          <table id="dt_Man_tbl" class="table table-striped table-bordered dataTable ">
                               <thead class="bg-info text-white">
                                   
                                <tr>
                                    <th rowspan="2">S.NO</th>
                                    <th rowspan="2" style="text-align:center">MANDAL</th>
                                    <th colspan="2" style="text-align:center">UPDATED</th>
                                    <th colspan="2" style="text-align:center">Pending</th>
                                    <th colspan="11" style="text-align:center">Noland</th>
                                    <th colspan="11" style="text-align:center">Lessthan 1 Acre</th>
                                    <th colspan="11" style="text-align:center">Greaterthan 1 Acre</th>
                                </tr>
                                <tr>
                                  
                                    <th>Lessthan 1 Acre</th>
                                    <th>No Land</th>
                                    <th>Lessthan 1 Acre</th>
                                    <th>No Land</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged	</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
                                    <th>No land Available</th>
                                    <th>Land to be Identified</th>
                                    <th>Polavaram Submerged</th>
                                    <th>Death Cases</th>
                                    <th>Non-Tribes</th>
                                    <th>Govt Employee</th>
                                    <th>Having Land - Not updated Webland</th>
                                    <th>Having Land - Not updated Giribhumi</th>
                                    <th>Having Land - Mutation to be done</th>
                                    <th>Not Dependent on cultivation</th>
                                    <th>Migrated</th>
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
    <script src="../NewJsFiles/Twd_Comments_Report_JAN2021.js"></script>
   <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>
