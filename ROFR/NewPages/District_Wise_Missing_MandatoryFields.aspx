<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="District_Wise_Missing_MandatoryFields.aspx.cs" Inherits="ROFR.NewPages.District_Wise_Missing_MandatoryFields" EnableEventValidation="false" %>


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
             
            <div class="col-md-3">
                <span style="color: red">NOTE: Click on Excel to download all records at once</span> 
            </div>
            <div class="col-md-6">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">DISTRICT WISE MISSING MANDATORY FIELDS BENEFICIARY DETAILS</h5>
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
                                    <select name="Count" id="districtId" class="form-control">
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
                       
                        <table id="dt_dist_benificiary_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                             
                                  <tr>
                                 <th  style="width: 10px!important;">S.NO</th>

                                   
                                    <th class="sorting_disabled text-center"> PLOT ID <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">ITDA NAME <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">DISTRICT <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">MANDAL <br /><span>(4)</span></th>

                                    <th class="sorting_disabled text-center">GRAM PANCHAYAT <br /><span>(5)</span></th>
                                    <th class="sorting_disabled text-center">REVENUE VILLAGE <br /><span>(6)</span></th>
                                     <th class="sorting_disabled text-center">VILLAGE <br /><span>(7)</span></th>
                                    <th class="sorting_disabled text-center">HABITATION <br /><span>(8)</span></th>
                                    <th class="sorting_disabled text-center">FOREST DIVISION <br /><span>(9)</span></th>

                                    <th class="sorting_disabled text-center">FOREST RANGE <br /><span>(10)</span></th>
                                    <th class="sorting_disabled text-center">FOREST BEAT <br /><span>(11)</span></th>
                                    <th class="sorting_disabled text-center">FOREST BLOCK <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">COMPARTMENT NO <br /><span>(13)</span></th>
                                     <th class="sorting_disabled text-center">PLOT NO <br /><span>(14)</span></th>

                                    <th class="sorting_disabled text-center">EXTENT PLOT AREA <br /><span>(15)</span></th>

                                    <th class="sorting_disabled text-center">ROFR PATTA NO <br /><span>(16)</span></th>
                                    <th class="sorting_disabled text-center">ROFR PATTADAAR <br /><span>(17)</span></th>
                                    <th class="sorting_disabled text-center">FATHER NAME <br /><span>(18)</span></th>
                                    <th class="sorting_disabled text-center">SUB CASTE <br /><span>(19)</span></th>
                                    <th class="sorting_disabled text-center">CULTIVATOR NAME <br /><span>(20)</span></th>
                                    <th class="sorting_disabled text-center">AADHAAR NO <br /><span>(21)</span></th>
                                    <th class="sorting_disabled text-center">BANK ACCOUNT NO <br /><span>(22)</span></th>
                                     <th class="sorting_disabled text-center">IFSC CODE <br /><span>(23)</span></th>
                                    <th class="sorting_disabled text-center">BANK NAME <br /><span>(24)</span></th>
                                    <th class="sorting_disabled text-center">UNCULTIVABLE LAND <br /><span>(25)</span></th>
                                    <th class="sorting_disabled text-center">CULTIVABLE LAND <br /><span>(26)</span></th>
                                    <th class="sorting_disabled text-center">PATTA INAM/GOVT <br /><span>(27)</span></th>
                                    <th class="sorting_disabled text-center">DRYID ONECROP/TWO CROP <br /><span>(28)</span></th>
                                    <th class="sorting_disabled text-center">WATER SOURCE <br /><span>(29)</span></th>
                                     <th class="sorting_disabled text-center">EXTENT IRRIGATED <br /><span>(30)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT UNDER CULTIVATOR <br /><span>(31)</span></th>


                                    <th class="sorting_disabled text-center">LAND CLASSIFICATION <br /><span>(32)</span></th>
                                    <th class="sorting_disabled text-center">HOLDING NATURE <br /><span>(33)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT <br /><span>(34)</span></th>
                                    <th class="sorting_disabled text-center">NET SOWN AREA <br /><span>(35)</span></th>
                                     <th class="sorting_disabled text-center">MONTH OF CULTIVATION <br /><span>(36)</span></th>
                                    <th class="sorting_disabled text-center">CROP <br /><span>(37)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT SINGLE <br /><span>(38)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT MIXED <br /><span>(39)</span></th>
                                    <th class="sorting_disabled text-center">EXTENT TOTAL <br /><span>(40)</span></th>
                                    <th class="sorting_disabled text-center">FIRST CROP <br /><span>(41)</span></th>
                                    <th class="sorting_disabled text-center">SECOND THIRD CROP <br /><span>(42)</span></th>
                                     <th class="sorting_disabled text-center">CROP YIELD <br /><span>(43)</span></th>
                                    <th class="sorting_disabled text-center">REMARKS <br /><span>(44)</span></th>
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
    <script src="../NewJsFiles/Districtwise_Missing_MandatoryFields.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>