<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Benificiarywise_Reportw.aspx.cs" Inherits="ROFR.NewPages.Benificiarywise_Report" EnableEventValidation="false"%>

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
          /*.dt-button.buttons-copy {
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">BENEFICIARY  PHASESWISE LAND ABSTRACT REPORT</h5>
          </div>
              <div class="col-md-3 text-right">
                  <input type="button" value="Back" id="distbackidForAll" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="distbackidForPH1" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="distbackidForPH2" class="btn btn-success btn-sm"/>
                      <input type="button" value="Back" id="distbackidForBoth" class="btn btn-success btn-sm"/>
              </div>
             
        </div>

          <div class="row justify-content-center mt-2">
             <div class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
              <div class="col-md-3" style="display:none">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8 pl-0 pr-0">
                        <select class="Benifciary" id="ddl_benificiary" name="dropdown">  
                                 <option value="0" > Benficiarywise Phases Data </option>  
                                    <option value="1"> PHASE-I </option>  
                                 <option value="2"> PHASE-II</option>  
                                     <option value ="3"> Benificaries covered in PHASE-I & PHASE-II </option>  
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
                       
                        <table id="dt_dist_benificiary_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">Total Beneficiaries & Total Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style=" text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">NO OF PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
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
                       
                        <table id="dt_dist_Phase1_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase-I Beneficiaries & Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">NO OF PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_Phase2_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                              <%-- <tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase-II Beneficiaries & Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">NO OF FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">NO OF PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
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
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_dist_PHASESBOTH_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase - I Beneficiaries in Phase - II</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">PHASEI BEN IN PHASEII <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">PHASEI EXTENT <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">PHASEII EXTENT <br /><span>(5)</span></th>
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
                     
                    <div class="table-responsive">
                          <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_mandal_ben_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval1"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval1"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">Total Beneficiaries & Total Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <%--<th class="sorting_disabled text-center">DISTRICT <br /><span>(1)</span></th>--%>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL FARMERS <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(4)</span></th>
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
                       
                        <table id="dt_mandal_Ph1_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                 <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval2"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval2" class="Distid"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                               <%--<tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase-I Beneficiaries & Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
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
                       
                        <table id="dt_mandal_Ph2_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval3"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval3"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              <%-- <tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase-II Beneficiaries & Extent</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
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
                       
                        <table id="dt_mandal_both_tbl" class="table table-striped table-bordered dataTable">

                            <thead class="bg-info text-white">
                                <tr>
                                   <th colspan="9" style="text-align:center;color: white;">
                                       ITDA::&nbsp;<label id="itdaval4"></label>&nbsp;&nbsp;&nbsp;
                                       DISTRICT::&nbsp;<label id="distval4"></label>&nbsp;&nbsp;&nbsp;
                                   </th>
                               </tr>
                              <%-- <tr>
                                   <th colspan="6" style="text-align:center;color: white;">Phase - I Beneficiaries in Phase - II</th>
                               </tr>--%>
                                <tr>
                                 <th style="text-align:center">S.NO</th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL FARMERS <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL PLOTS <br /><span>(4)</span></th>
                                    <th class="sorting_disabled text-center">TOTAL EXTENT <br /><span>(5)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
        <%--panchayt table--%>
         <div class="row justify-content-center">
    <div class="col-md-10">
        <div class="table-responsive">
            <div class="maincard">
                <div class="maincard-bdy">
                    <table id="dt_panchayt_ben_tbl" class="table table-striped table-bordered dataTable">
                        <thead class="bg-info text-white">
                            <!-- Parent Info Row -->
                            <tr>
                                <th colspan="9" style="text-align:center; color:white;">
                                    ITDA:: <label id="itdaval5"></label> &nbsp;&nbsp;
                                    DISTRICT:: <label id="distval5"></label> &nbsp;&nbsp;
                                    MANDAL:: <label id="mandalval5"></label>
                                </th>
                            </tr>
                            <!-- Column Headers -->
                            <tr>
                                <th style="text-align:center">S.NO</th>
                                <%--<th class="text-center">DISTRICT<br /><span>(1)</span></th>
                                <th class="text-center">MANDAL<br /><span>(2)</span></th>--%>
                                <th class="text-center">PANCHAYAT<br /><span>(1)</span></th>
                                <th class="text-center">TOTAL FARMERS<br /><span>(2)</span></th>
                                <th class="text-center">TOTAL PLOTS<br /><span>(3)</span></th>
                                <th class="text-center">TOTAL EXTENT<br /><span>(4)</span></th>
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

         <%--revenuevillage Table --%>
        <div class="row justify-content-center">
    <div class="col-md-10">
        <div class="table-responsive">
            <div class="maincard">
                <div class="maincard-bdy">

                    <table id="dt_revenuevillage_ben_tbl"
                           class="table table-striped table-bordered dataTable"
                           style="width:100%;">

                        <thead class="bg-info text-white">

                            <!-- Parent Info -->
                            <tr>
                                <th colspan="8" style="text-align:center; color:white;">
                                    ITDA:: <label id="itdaval6"></label>
                                    &nbsp;&nbsp;
                                    DISTRICT:: <label id="distval6"></label>
                                    &nbsp;&nbsp;
                                    MANDAL:: <label id="mandalval6"></label>
                                    &nbsp;&nbsp;
                                    PANCHAYAT:: <label id="panchayatval6"></label>
                                </th>
                            </tr>

                            <!-- Column Headers -->
                            <tr>
                                <th style="text-align:center">
                                    S.NO
                                </th>

                               <%-- <th class="text-center">
                                    DISTRICT<br />
                                    <span>(1)</span>
                                </th>

                                <th class="text-center">
                                    MANDAL<br />
                                    <span>(2)</span>
                                </th>

                                <th class="text-center">
                                    PANCHAYAT<br />
                                    <span>(3)</span>
                                </th>--%>

                                <th class="text-center">
                                    REVENUE VILLAGE<br />
                                    <span>(1)</span>
                                </th>

                                <th class="text-center">
                                    TOTAL FARMERS<br />
                                    <span>(2)</span>
                                </th>

                                <th class="text-center">
                                    TOTAL PLOTS<br />
                                    <span>(3)</span>
                                </th>

                                <th class="text-center">
                                    TOTAL EXTENT<br />
                                    <span>(4)</span>
                                </th>
                            </tr>

                        </thead>

                        <tbody></tbody>

                    </table>

                </div>
            </div>
        </div>
    </div>
</div>

             <!-- =========================================================
     VILLAGE WISE TABLE
     ========================================================= -->

<div class="row justify-content-center">

    <div class="col-md-10">

        <div class="table-responsive">

            <div class="maincard">

                <div class="maincard-bdy">

                    <table id="dt_village_ben_tbl"
                           class="table table-striped table-bordered dataTable"
                           style="width:100%;">

                        <thead class="bg-info text-white">

                            <!-- Parent Heading -->
                            <tr>

                                <th colspan="9"
                                    style="text-align:center; color:white;">

                                    ITDA::
                                    <label id="itdaval7"></label>

                                    &nbsp;&nbsp;

                                    DISTRICT::
                                    <label id="distval7"></label>

                                    &nbsp;&nbsp;

                                    MANDAL::
                                    <label id="mandalval7"></label>

                                    &nbsp;&nbsp;

                                    PANCHAYAT::
                                    <label id="panchayatval7"></label>

                                    &nbsp;&nbsp;

                                    REVENUE VILLAGE::
                                    <label id="revenuevillageval7"></label>

                                </th>

                            </tr>


                            <!-- Column Heading -->
                            <tr>

                                <th style="text-align:center;">
                                    S.NO
                                </th>

                               <%-- <th style="text-align:center;">
                                    DISTRICT<br />
                                    <span>(1)</span>
                                </th>

                                <th style="text-align:center;">
                                    MANDAL<br />
                                    <span>(2)</span>
                                </th>

                                <th style="text-align:center;">
                                    PANCHAYAT<br />
                                    <span>(3)</span>
                                </th>

                                <th style="text-align:center;">
                                    REVENUE VILLAGE<br />
                                    <span>(4)</span>
                                </th>--%>

                               <th class="sorting_disabled text-center">VILLAGE <br /><span>(1)</span></th>
                                
                                <th style="text-align:center;">
                                    TOTAL FARMERS<br />
                                    <span>(2)</span>
                                </th>

                                <th style="text-align:center;">
                                    TOTAL PLOTS<br />
                                    <span>(3)</span>
                                </th>

                                <th style="text-align:center;">
                                    TOTAL EXTENT<br />
                                    <span>(4)</span>
                                </th>

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
                       <!-- =========================================================
     HABITATION WISE TABLE
     ========================================================= -->

<div class="row justify-content-center">

    <div class="col-md-10">

        <div class="table-responsive">

            <div class="maincard">

                <div class="maincard-bdy">

                    <table id="dt_habitation_ben_tbl"
                           class="table table-striped table-bordered dataTable"
                           style="width:100%;display:none;">

                        <thead class="bg-info text-white">

                            <!-- Parent Heading -->
                            <tr>

                                <th colspan="10"
                                    style="text-align:left; color:white;">

                                    ITDA::
                                    <label id="itdaval8"></label>

                                    &nbsp;&nbsp;

                                    DISTRICT::
                                    <label id="distval8"></label>

                                    &nbsp;&nbsp;

                                    MANDAL::
                                    <label id="mandalval8"></label>

                                    &nbsp;&nbsp;

                                    PANCHAYAT::
                                    <label id="panchayatval8"></label>

                                    &nbsp;&nbsp;
                                   
                                
                                    REVENUE VILLAGE::
                                    <label id="revenuevillageval8"></label>

                                    &nbsp;&nbsp;
                                    <br />
                                    VILLAGE::
                                    <label id="villageval8"></label>

                                </th>

                            </tr>


                            <!-- Column Heading -->
                            <tr>

                                <th style="text-align:center;">
                                    S.NO
                                </th>

                                <%--<th style="text-align:center;">
                                    DISTRICT<br />
                                    <span>(1)</span>
                                </th>

                                <th style="text-align:center;">
                                    MANDAL<br />
                                    <span>(2)</span>
                                </th>

                                <th style="text-align:center;">
                                    PANCHAYAT<br />
                                    <span>(3)</span>
                                </th>

                                <th style="text-align:center;">
                                    REVENUE VILLAGE<br />
                                    <span>(4)</span>
                                </th>

                                <th style="text-align:center;">
                                    VILLAGE<br />
                                    <span>(5)</span>
                                </th>--%>
                                <th class="sorting_disabled text-center">HABITATION <br /><span>(1)</span></th>
                                

                                <th style="text-align:center;">
                                    TOTAL FARMERS<br />
                                    <span>(2)</span>
                                </th>

                                <th style="text-align:center;">
                                    TOTAL PLOTS<br />
                                    <span>(3)</span>
                                </th>

                                <th style="text-align:center;">
                                    TOTAL EXTENT<br />
                                    <span>(4)</span>
                                </th>

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

                <div class="maincard-bdy">

                  <table id="dt_beneficiary_details_tbl"
       class="table table-striped table-bordered dataTable"
       style="width:100%;display:none;">

    <thead class="bg-info text-white">

        <tr>

            <th colspan="5"
                style="text-align:left; color:white;">

                ITDA::
                <label id="itdaval9"></label>

                &nbsp;&nbsp;

                DISTRICT::
                <label id="distval9"></label>

                &nbsp;&nbsp;

                MANDAL::
                <label id="mandalval9"></label>

                &nbsp;&nbsp;

                PANCHAYAT::
                <label id="panchayatval9"></label>

                &nbsp;&nbsp;
                
                REVENUE VILLAGE::
                <label id="revenuevillageval9"></label>

                &nbsp;&nbsp;
                <br />
                VILLAGE::
                <label id="villageval9"></label>

                &nbsp;&nbsp;

                HABITATION::
                <label id="habitationval9"></label>

            </th>

        </tr>

        <tr>

            <th style="text-align:center;">
                S.NO
            </th>
            <th class="sorting_disabled text-center">BenficiaryId <br /><span>(1)</span></th>
            <th class="sorting_disabled text-center">FarmerName <br /><span>(2)</span></th>
            <th class="sorting_disabled text-center">FatherName <br /><span>(3)</span></th>
            <th class="sorting_disabled text-center">AadhaarNo <br /><span>(4)</span></th>
            

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

                <div class="maincard-bdy">

                    <table id="dt_beneficiary_plots_tbl"
       class="table table-striped table-bordered dataTable"
       style="width:100%;display:none;">

    <thead class="bg-info text-white">

        <tr>

            <th colspan="9"
                style="text-align:left; color:white;">

                ITDA::
                <label id="itdaval10"></label>

                &nbsp;&nbsp;

                DISTRICT::
                <label id="distval10"></label>

                &nbsp;&nbsp;

                MANDAL::
                <label id="mandalval10"></label>

                &nbsp;&nbsp;

                PANCHAYAT::
                <label id="panchayatval10"></label>

                &nbsp;&nbsp;
                
                REVENUE VILLAGE::
                <label id="revenuevillageval10"></label>

                &nbsp;&nbsp;
                <br />

                VILLAGE::
                <label id="villageval10"></label>

                &nbsp;&nbsp;

                HABITATION::
                <label id="habitationval10"></label>

            </th>

        </tr>

        <tr>

            <th style="text-align:center;">
                S.NO
            </th>

               <th class="sorting_disabled text-center">BenficiaryId <br /><span>(1)</span></th>
            <th class="sorting_disabled text-center">PlotId <br /><span>(2)</span></th>
            <th class="sorting_disabled text-center">FarmerName <br /><span>(3)</span></th>
            <th class="sorting_disabled text-center">FatherName <br /><span>(4)</span></th>
            <th class="sorting_disabled text-center">AadhaarNo <br /><span>(5)</span></th>
            <th class="sorting_disabled text-center">CompartmentNo <br /><span>(6)</span></th>
            <th class="sorting_disabled text-center">RofrPattaNo <br /><span>(7)</span></th>
            <th class="sorting_disabled text-center">Extent <br /><span>(8)</span></th>

            

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
    <script src="https://cdn.datatables.net/fixedcolumns/4.2.1/js/dataTables.fixedColumns.min.js"></script>
    <script src="../NewJsFiles/BenificiarywiseReport.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>