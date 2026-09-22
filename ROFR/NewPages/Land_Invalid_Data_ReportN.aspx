<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master"  AutoEventWireup="true" CodeBehind="Land_Invalid_Data_ReportN.aspx.cs" Inherits="ROFR.NewPages.Land_Invalid_Data_ReportN" EnableEventValidation="false" %>


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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">LAND INVALID DATA REPORT</h5>
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
                                   <th colspan="9" style="text-align:center;color: white;">DISTRICT WISE LAND INVALID DATA REPORT</th>
                               </tr>
                                <tr>
                                 <th  style="width: 10px!important;">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">DUPLICATE AADHAARS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">INVALID AADHAARS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME NULL <br /><span>(5)</span></th>
                                     <th class="sorting_disabled text-center">LOCATION DETAILS NULL(MANDAL/GP/VILLAGE) <br /><span>(6)</span></th>
                                     <th class="sorting_disabled text-center">LAND DETAILS-INVALID/NULL <br /><span>(7)</span></th>
                                     <th class="sorting_disabled text-center">EXTENT>10 ACRES <br /><span>(8)</span></th>
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

                 <div class="col-md-12">
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Duplicate_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="13" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">AADHAR NO <br /><span>(6)</span></th>
                                    
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Invaild_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="13" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval2"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">AADHAR NO <br /><span>(6)</span></th>
                                    
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Father_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="13" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">AADHAR NO <br /><span>(6)</span></th>
                                    
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Location_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="13" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">REVENUE VIILAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(9)</span></th>
                                    
                                    
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Land_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="14" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval5"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval5"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">REVENUE VIILAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE<br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION<br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(9)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(11)</span></th>
                                    <th class="sorting_disabled text-center">PLOT NO <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(13)</span></th>
                                    
                                    
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Extent_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="16" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval6"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval6"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME<br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(9)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTANO <br /><span>(11)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">BANK ACCOUNT NO <br /><span>(13)</span></th>
                                    <th class="sorting_disabled text-center">IFSC CODE <br /><span>(14)</span></th>
                                    <th class="sorting_disabled text-center">BANK NAME <br /><span>(15)</span></th>
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
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Newcdn/jquery-3.5.1.js"></script>
    <script src="../Newcdn/dataTables.min.js"></script>
    <script src="../Newcdn/dataTables.buttons.min.js"></script>
    <script src="../Newcdn/jszip.min.js"></script>
    <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
    <script src="../Newcdn/vfs_fonts.js"></script>
    <script src="../Newcdn/html5.min.js"></script>
    <script src="../Newcdn/print.min.js"></script>
    <script src="https://cdn.datatables.net/fixedcolumns/4.2.1/js/dataTables.fixedColumns.min.js"></script>
   <%-- <script src="../NewJsFiles/NotHavingLandDetailsN.js"></script>--%>
    <script src="../NewJsFiles/Land_Invalid_DataReportjs.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
    
</asp:Content>

