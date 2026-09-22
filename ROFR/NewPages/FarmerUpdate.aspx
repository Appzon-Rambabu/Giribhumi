<%@ Page Language="C#"  MasterPageFile="~/Masters/Adangal.master"  AutoEventWireup="true" CodeBehind="FarmerUpdate.aspx.cs" Inherits="ROFR.NewPages.FarmerUpdate" EnableEventValidation="false" %>

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
   .dt-checkboxes {
float :left;
}
  
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
  
  .box1 {
    
    padding: 10px;
    
}

.box2 {
   
    padding: 10px;
    
    
}
 
  </style>

     <script>
         var mask;
         function AadharValidation() {
             mask = document.getElementById('aadharID').value;
             document.getElementById('hiddenElement').value = mask;

             if (mask.length < 12 || (mask.length >= 13 && mask.length < 16)) {
                 alert("Please enter 12  digit aadhaar number");
                 document.getElementById('aadharID').value = "";
                 return false;
             }
             else if (mask.length == 12) {
                 var enteredadhar = mask;
                 var status = validateVerhoeff(enteredadhar);
                 if (!status) {
                     if (status == "0") {
                         alert("Please enter a valid Aadhar Number");
                         document.getElementById('aadharID').value = "";
                     }
                     return status;
                 }
                 /*document.getElementById('aadharID').value = mask.replace(mask.substring(0, mask.length - 4), '');*/

             }
             else if (mask.length > 12 && mask.length == 16) {
                 var enterdadhar = mask;
                 var status = validateVerhoeff(enterdadhar);
                 if (!status) {
                     if (status == "0") {
                         alert("Please enter a valid Aadhar Number");
                         document.getElementById('aadharID').value = "";
                     }
                     return status;
                 }
                 document.getElementById('aadharID').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxxxxxx');

             }
             return mask;
         }
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

         <div class="modal" id="myModal" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                 <h5 class="modal-title" id="exampleModalLabel">FARMER UPDATE</h5>
               <button type="button" class="btn btn-secondary" id="btnClose" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                     <label class="modal_note">BENEFICIARY ID</label>
                         </div>
                 <div class="col-md-5">
                        <input type="text" id="BenID" class="form-control" placeholder="BeneficiaryID"  onkeypress="codevalidate(evt)" disabled="disabled"/>
                     </div>
                     
                </div>
                <br />
                <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                     <label class="modal_note">   AADHAR NO</label>
                         </div>
                 <div class="col-md-5">
                        <input type="hidden" id="hiddenElement" />
                     <input type="text" id="aadharID" class="form-control" placeholder="AadharNumber"  onkeypress="codevalidate(evt)" maxlength="12" onchange="return AadharValidation()"/>
                     <input type="hidden" id="hiddenId"/>
                     </div>
                </div>
                <br />
                <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                      <label class="modal_note">FARMER NAME</label>
                         </div>
                 <div class="col-md-5">
                       <input class="myInput form-control form-control-md" type="text" id="farmerID" placeholder="Farmer Name" required=""/>
                     </div>
                     
                </div>
               <br />
               <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                       <label class="modal_note">FATHER NAME</label>
                         </div>
                 <div class="col-md-5">
                      <input class="myInput form-control form-control-md" type="text" id="fatherID" placeholder="Father Name" required=""/>
                     </div>
                     
                </div>
              
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnClosePopup">Close</button>
                <button type="button" class="btn btn-success" id="updateId">Save changes</button>
            </div>
        </div>
    </div>
</div>

          <div class="row justify-content-center" style="margin-top:10px">
             
            <div class="col-md-3"></div>
            <div class="col-md-6">
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">FARMER UPDATE</h5>
          </div>
              <div class="col-md-3 text-right">
                  
              </div>
             
        </div>
         <br />
              <div class="Updateform"> 
                  <div class="row justify-content-center">
                      <div class="box1">
                          <label><b>BENEFICIARY ID:</b></label>
                          <input type="text" name="beneficiary" id="txtbenid" onkeypress="codevalidate(evt)"/>
                      </div>
                      
                      <div class="box2">
                          <p> 
                    <button type="button" id="submitBtn" class="btn btn-success btn-sm" onclick="GetDetails()">Submit</button>
                      </p> 
                      </div>
                  </div>
            
            </div>  
         <br />
        <div class="row justify-content-center">
          <div class="col-md-10  justify-content-center" >
                                               
                                                <table class="table table-bordered mb-0" id="FarmerUpdateId">
                                                    <thead>
                                                       
                                                        <tr>
                                                            <th style="text-align:center">S.NO</th>
                                                             <th style="text-align:center">SELECT</th>
                                                            <th style="text-align:center">BENEFICIARY ID</th>
                                                            <th style="text-align:center">AADHAR NO</th>
                                                            <th style="text-align:center">FARMER NAME</th>
                                                            <th style="text-align:center">FATHER NAME</th>
                                                            <th style="text-align:center">TotalExtent</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
															<tr>
                                                            <td></td>
															<td><input type="checkbox" id="checkid"/></td>
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
         function codevalidate(evt) {
             var theEvent = evt || window.event;

             // Handle paste
             if (theEvent.type === 'paste') {
                 key = event.clipboardData.getData('text/plain');
             } else {
                 // Handle key press
                 var key = theEvent.keyCode || theEvent.which;
                 key = String.fromCharCode(key);
             }
             var regex = /[0-9]|\0/;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) theEvent.preventDefault();

             }
         }
     </script>
    
   
    <script>

        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff(num) {
            //  alert("funcall" + num);
            if (num == "333333333333" || num == "777777777777") {
                return 0;
            }
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
                return true;

            }
            else {

                //alert("Invalid Aadhaar Number");
                return false;


            }
        }



        /*
         * Converts a string to a reversed integer array.
         */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
         * Reverses an int array
         */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }



    </script>


    <script>
        function pattadarnamevalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function Accountnovalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z0-9 ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function onlynumbers(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9 ]|\0/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function validtext(event) {

            var str = event.value;

            if (str == 'script' || str == 'alert') {


                alert('Enter valid format');
                event.value = "";
            }

            else {
                return false;
            }

        }
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
    <script src="../NewJsFiles/FarmerUpdateN.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
   
     
</asp:Content>
