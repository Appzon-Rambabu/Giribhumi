<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Rythubarosa_PaymentStatus_May21.aspx.cs" Inherits="ROFR.NewPages.Rythubarosa_PaymentStatus_May21" EnableEventValidation="false" %>

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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">RYTHU BHAROSA PAYMENT STATUS MAY 2021</h5>
          </div>
              <div class="col-md-3 text-right">
                  <input type="button" value="Back" id="distbackid" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="mandalbackid" class="btn btn-success btn-sm"/>
                     
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
                       
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                              <%-- <tr>
                                   <th colspan="7" style="text-align:center;color: white;">DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS MAY-21</th>
                               </tr>--%>

                                
                                <tr>
                                <th>S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th style="text-align:center">NO OF BENEFICIARIES <br /><span>(3)</span></th>
                                    <th style="text-align:center">BELONG TO BENEFICIARY FAMILY <br /><span>(4)</span></th>
                                    <th style="text-align:center">ELIGIBLE <br /><span>(5)</span></th>
                                    <th style="text-align:center">INELIGIBLE <br /><span>(6)</span></th>
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
                       
                        <table id="dt_mandal_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="6" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                             
                                
                                <tr>
                                <th>S.NO</th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">NO OF BENEFICIARIES <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">BELONG TO BENEFICIARY FAMILY <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">ELIGIBLE <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">INELIGIBLE <br /><span>(5)</span></th>
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
                       
                        <table id="dt_BENEFICIARY_FAMILY_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                                  <tr>
                                   <th colspan="23" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="23" style="text-align:center;color: white;">BELONG TO BENEFICIARY FAMILY RYTHU BHAROSA PAYMENT STATUS MAY-21</th>
                               </tr>--%>
                                 
                                <tr>
                                <th>S.NO</th>
                                    <th style="text-align:center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDANAME <br /><span>(2)</span></th>
                                     <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR_PATTADAAR <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(7)</span></th>
                                    <th style="text-align:center">AADHAAR_NO <br /><span>(8)</span></th>
                                    <th style="text-align:center">SURVEY NUMBER <br /><span>(9)</span></th>
                                    <th style="text-align:center">KHATHA NUMBER <br /><span>(10)</span></th>
                                    <th style="text-align:center">EXTENT <br /><span>(11)</span></th>
                                    <th style="text-align:center">AGR.DEPT(RTGS) COMMENTS <br /><span>(12)</span></th>
                                    <th style="text-align:center">FIELD COMMENTS <br /><span>(13)</span></th>
                                    <th style="text-align:center">CORRECT AADHAAR <br /><span>(14)</span></th>
                                    <th style="text-align:center">HO COMMENT <br /><span>(15)</span></th>
                                    <th style="text-align:center">HO REMARKS <br /><span>(16)</span></th>
                                    <th style="text-align:center">STATUS <br /><span>(17)</span></th>
                                    <th style="text-align:center">PAYMENT STATUS <br /><span>(18)</span></th>
                                    <th style="text-align:center">AMOUNT <br /><span>(19)</span></th>
                                    <th style="text-align:center">CREDIT DATE <br /><span>(20)</span></th>
                                    <th style="text-align:center">REASON <br /><span>(21)</span></th>
                                    <th style="text-align:center">BELONG TO BENEFICIARY UID <br /><span>(22)</span></th>
                                    
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
                       
                        <table id="dt_Eligible_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                                  <tr>
                                   <th colspan="23" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval2"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval2"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="23" style="text-align:center;color: white;">ELIGIBLE RYTHU BHAROSA PAYMENT STATUS MAY-21</th>
                               </tr>--%>

                                 
                                <tr>
                                <th>S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDANAME <br /><span>(2)</span></th>
                                     <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR_PATTADAAR <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(7)</span></th>
                                    <th style="text-align:center">AADHAAR_NO <br /><span>(8)</span></th>
                                    <th style="text-align:center">SURVEY NUMBER <br /><span>(9)</span></th>
                                    <th style="text-align:center">KHATHA NUMBER <br /><span>(10)</span></th>
                                    <th style="text-align:center">EXTENT <br /><span>(11)</span></th>
                                    <th style="text-align:center">AGR.DEPT(RTGS) COMMENTS <br /><span>(12)</span></th>
                                    <th style="text-align:center">FIELD COMMENTS <br /><span>(13)</span></th>
                                    <th style="text-align:center">CORRECT AADHAAR <br /><span>(14)</span></th>
                                    <th style="text-align:center">HO COMMENT <br /><span>(15)</span></th>
                                    <th style="text-align:center">HO REMARKS <br /><span>(16)</span></th>
                                    <th style="text-align:center">STATUS <br /><span>(17)</span></th>
                                    <th style="text-align:center">PAYMENT STATUS <br /><span>(18)</span></th>
                                    <th style="text-align:center">AMOUNT <br /><span>(19)</span></th>
                                    <th style="text-align:center">CREDIT DATE <br /><span>(20)</span></th>
                                    <th style="text-align:center">REASON <br /><span>(21)</span></th>
                                    <th style="text-align:center">BELONG TO BENEFICIARY UID <br /><span>(22)</span></th>
                                    
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
                       
                        <table id="dt_INEligible_tbl" class="table table-striped table-bordered dataTable"  style="width:100%">

                            <thead class="bg-info text-white">
                                  <tr>
                                   <th colspan="23" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                       MANDAL::&nbsp;<label id="manval3"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              <%-- <tr>
                                   <th colspan="23" style="text-align:center;color: white;">INELIGIBLE RYTHU BHAROSA PAYMENT STATUS MAY-21</th>
                               </tr>--%>

                                 
                                <tr>
                                <th>S.NO</th>
                                    <th class="sorting_disabled text-center">BENEFICIARY ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDANAME <br /><span>(2)</span></th>
                                     <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">VILLAGE <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">ROFR_PATTADAAR <br /><span>(6)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR_NO <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">SURVEY NUMBER <br /><span>(9)</span></th>
                                    <th style="text-align:center">KHATHA NUMBER <br /><span>(10)</span></th>
                                    <th style="text-align:center">EXTENT <br /><span>(11)</span></th>
                                    <th style="text-align:center">AGR.DEPT(RTGS) COMMENTS <br /><span>(12)</span></th>
                                    <th style="text-align:center">FIELD COMMENTS <br /><span>(13)</span></th>
                                    <th style="text-align:center">CORRECT AADHAAR <br /><span>(14)</span></th>
                                    <th style="text-align:center">HO COMMENT <br /><span>(15)</span></th>
                                    <th style="text-align:center">HO REMARKS <br /><span>(16)</span></th>
                                    <th style="text-align:center">STATUS <br /><span>(17)</span></th>
                                    <th style="text-align:center">PAYMENT STATUS <br /><span>(18)</span></th>
                                    <th style="text-align:center">AMOUNT <br /><span>(19)</span></th>
                                    <th style="text-align:center">CREDIT DATE <br /><span>(20)</span></th>
                                    <th style="text-align:center">REASON <br /><span>(21)</span></th>
                                    <th style="text-align:center">BELONG TO BENEFICIARY UID <br /><span>(22)</span></th>
                                    
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
    <script src="../NewJsFiles/Rythubarosa_Payment_May21.js"></script>
     <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>
