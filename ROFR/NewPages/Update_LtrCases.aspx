<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Update_LtrCases.aspx.cs" Inherits="ROFR.NewPages.Update_LtrCases" EnableEventValidation="false" %>


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
            <h5 class="text-center text-white rounded py-1 my-0 bg-nav">VIEW LTR CASE STATUS</h5>
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

        <div class="row">
                        <div class="col-md-2">
                         <div class="form-group row">
                               <label for="" class="col-sm-2 col-form-label"><b>ITDA:<span style="color:red;"><b>*</b></span></b></label>
                                    <div class="col-sm-10">
                                            <select name="itda" id="ItdaID" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                            </select>
                                     </div>
                        </div>
                   </div>

                        <div class="col-md-2">
                 <div class="form-group row">
    <label for="" class="col-sm-3 col-form-label"><b>DISTRICT:<span style="color:red;"><b>*</b></span></b></label>
  <div class="col-sm-9">
     <select name="itda" id="DistrictID" class="form-control">
   <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
     </select>
      </div>

  </div>
            </div>

                        <div class="col-md-2">
                 <div class="form-group row">
    <label for="" class="col-sm-3 col-form-label"><b>MANDAL:<span style="color:red;"><b>*</b></span></b></label>
  <div class="col-sm-9">
     <select name="itda" id="MandalID" class="form-control target">
     <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>
      </div>

  </div>
            </div>

                        <div class="col-md-2">
                 <div class="form-group row">
    <label for="" class="col-sm-3 col-form-label"><b>VILLAGE:<span style="color:red;"><b>*</b></span></b></label>
  <div class="col-sm-9">
     <select name="itda" id="VillageID" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>
      </div>

  </div>
            </div>

                        <div class="col-md-3">
                 <div class="form-group row">
    <label for="" class="col-sm-3 col-form-label"><b>HABITATION:<span style="color:red;"><b>*</b></span></b></label>
  <div class="col-sm-6">
     <select name="itda" id="HabitationID" class="form-control">
                                               <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
                                    </select>
      </div>

  </div>
            </div>

        </div>
        <br />
                                  <div class="row justify-content-center">
                                       <div class="col-md-10  justify-content-center" >
                                                <table class="table table-bordered mb-0" id="Update_LtrCasesId">
                                                    <thead>
                                                        <tr>
                                                            <th style="text-align:center">S.NO</th>
                                                             <th style="text-align:center">LTRP ID</th>
                                                            <th style="text-align:center">LTRP NO </th>
                                                            <th style="text-align:center">R.S.NO</th>
                                                            <th style="text-align:center">Extent</th>
                                                            <th style="text-align:center">CASE LEVEL</th>
                                                            <th style="text-align:center">REFERENCE NUMBER</th>
                                                            <th style="text-align:center">CASE STATUS</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
															
                                                    </tbody>
                                                </table>

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
    <script src="../NewJsFiles/Update_LtrCases.js"></script>
    <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>

