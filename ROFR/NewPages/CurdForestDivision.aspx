<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="CurdForestDivision.aspx.cs" Inherits="ROFR.NewPages.CurdForestDivision" EnableEventValidation="false" %>

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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">UPDATE FOREST DIVISION</h5>
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

          <div class="row justify-content-center">
                 <div class="col-auto">
                     <b>DISTRICT:</b>
                   </div>
                    <div class="col-md-2">
                    <select name="district" id="ddl_district" class="form-control">
                  <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                  </select>
                                </div>
          </div>


   <div class="modal" id="EditModal">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                 <h5 class="modal-title" id="exampleModalLabel">UPDATE FOREST DIVISION</h5>
               <button type="button" class="btn btn-secondary" id="btnClose" data-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                     <label class="modal_note">FOREST DIVISION CODE</label>
                         </div>
                 <div class="col-md-5">
                        <input type="text" id="DIVISIONID" class="form-control" placeholder="FOREST DIVISION CODE"/>
                     </div>
                     
                </div>
                <br />
                <div class="row g-4 align-items-center">
                   <div class="col-md-4">
                     <label class="modal_note">FOREST DIVISION NAME</label>
                         </div>
                 <div class="col-md-5">
                        
                     <input type="text" id="DIVISIONNAMEID" class="form-control" placeholder="FOREST DIVISION NAME"/>
                     
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


        <div class="modal" id="DeleteModal">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
            </div>
            <div class="modal-body">
                <p style="color:red"><b>ARE YOU SURE WANT DELETE THIS RECORD!PLEASE CLICK ON DELETE</b></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal" id="btnClosePopup">Cancel</button>
                <button type="button" class="btn btn-success" id="deleteid">Delete</button>
            </div>
        </div>
    </div>
</div>
        
     <br />

         <div class=" row justify-content-center">
         <div class="col-md-5">
              <table class="table table-bordered" id="CurdforestDivsionId_tbl">
         <thead>
              <tr>
           <th>FOREST DIVISION CODE</th>
          <th>FOREST DIVISION NAME</th>
            <th>UPDATE</th>
           <th>DELETE</th>
             </tr>
             </thead>
           <tbody>
		    <tr>	
             <td style="text-align:right"></td>
			<td style="text-align:left"></td>
			<td></td>
			<td></td>
				</tr>										
               </tbody>
               </table>
         </div>
            </div>
        <div>
       

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
    <script src="../NewJsFiles/CurdForestDivision.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>

       
</asp:Content>


