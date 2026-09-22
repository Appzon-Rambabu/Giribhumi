<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="MissingData.aspx.cs" Inherits="ROFR.NewPages.MissingData" EnableEventValidation="false" %>

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
          .dt-button.buttons-copy {
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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">MISSING AND INVALID DATA REPORT</h5>
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
          <br />   

         <div class="row justify-content-center">
                       <div class="col-md-1">
                          <label for="Itdaname">ITDANAME:</label>&nbsp<label style="color:red">*</label>
                       </div>
                       <div class="col-md-2">
                            <select name="itda" id="itda" class="form-control">
                             <option value="select" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                              </select>
                       </div>
                    <div class="col-md-1">
                   <label for="District">DISTRICT:</label>&nbsp<label style="color:red">*</label>
                     </div>
                    <div class="col-md-2">
                            <select name="district" id="DistrictId" class="form-control">
                             <option value="select" selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                              </select>
                       </div>

             </div>
             <br />   
        <div class="row justify-content-center">
            <label style="color:green"><b style="font-size:20px;">Based on select option Data Will be Export to Excel ?</b></label>
        </div>
        
        <div class="row justify-content-center">
            <formview>
            <div class="form-check">
              <input class="form-check-input" type="radio" value="A" name="ScreenRadio" id="Radio1" />
              <label class="form-check-label" for="flexRadioDisabled" style="color:black;font-size:15px;">
                ALL Details Not Available(AadhaarNo,BankAccount,IfscCode)
              </label>
            </div>

            <div class="form-check">
              <input class="form-check-input" type="radio" value="B" name="ScreenRadio" id="Radio2"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
                BankAccount Not Available For Valid Aadhaar Numbers
              </label>
            </div>

            <div class="form-check">
              <input class="form-check-input" type="radio" value="C" name="ScreenRadio" id="Radio3"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
                IfscCode Not Available For Valid BankAccount Numbers
              </label>
            </div>

<%--            <div class="form-check">
              <input class="form-check-input" type="radio" value="D" name="ScreenRadio" id="Radio4"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
               Total Invalid Aadhaars
              </label>
            </div>--%>

            <div class="form-check">
              <input class="form-check-input" type="radio" value="E" name="ScreenRadio" id="Radio5"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
               Total Invalid BankAccounts
              </label>
            </div>

            <div class="form-check">
              <input class="form-check-input" type="radio"  value="F" name="ScreenRadio" id="Radio6"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
                Total Invalid Ifsc Codes
              </label>
            </div>

            <%--<div class="form-check">
              <input class="form-check-input" type="radio" value="G" name="ScreenRadio" id="Radio7"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
                 Aadhaars Numbers Not Available
              </label>
            </div>--%>

            <div class="form-check">
              <input class="form-check-input" type="radio" value="H" name="ScreenRadio" id="Radio8"/>
              <label class="form-check-label" for="flexRadioCheckedDisabled" style="color:black;font-size:15px;">
               Either Bank Account or Ifsc Code Not Available
              </label>
            </div>
                </formview>
            
        </div>


         <div class="row justify-content-center">
                                                  <div class="col-md-10  justify-content-center" >
                                               
                                                <table class="table table-bordered mb-0" id="tbl_exporttable_to_xls">
                                                    <thead>
                                                       
                                                        <tr class="hidden">
                                                              <th  style="width: 10px!important;">S.NO</th>
                                                                <th style="text-align:center">BENEFICIARY ID</th>
                                                                <th style="text-align:center">ITDA NAME</th>
                                                                <th style="text-align:center">DISTRICT</th>
                                                                <th style="text-align:center">MANDAL</th>
                                                                <th style="text-align:center">GRAM PANCHAYAT</th>
                                                                <th style="text-align:center">VILLAGE</th>
                                                                <th style="text-align:center">HABITATION</th>
                                                                 <th style="text-align:center">COMPARTMENT NO</th>
                                                                <th style="text-align:center">ROFR PATTANO</th>
                                                                <th style="text-align:center">ROFR PATTADAAR</th>
                                                                <th style="text-align:center">FATHER NAME</th>
                                                                <th style="text-align:center">AADHAAR NO</th>
                                                                <th style="text-align:center">BANK ACCOUNT NO</th>
                                                                 <th style="text-align:center">IFSC CODE</th>
                                                                <th style="text-align:center">BANK NAME</th>
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
                                                            <td></td>
                                                            <td></td>
															</tr>
                                                    </tbody>
                                                </table>

                                            </div>
       </div>

           </div>

           <script>
               //function ExportToExcel(type, fn, dl) {
               //    var elt = document.getElementById('tbl_exporttable_to_xls');
               //    var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
               //    return dl ?
               //        XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
               //        XLSX.writeFile(wb, fn || ('MySheetName.' + (type || 'xls')));
               //}

           </script>
    
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
    <script src="../NewJsFiles/MissingData.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>