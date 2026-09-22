<%@ Page Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master"  AutoEventWireup="true" CodeBehind="View_Ltr.aspx.cs" Inherits="ROFR.NewPages.View_Ltr" EnableEventValidation="false" %>
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
               <h5 class="text-center text-white rounded py-1 my-0 bg-nav">VIEW LTR</h5>
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


         <div class="row ">
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
      <div class="col-md-3">
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
      <label for="" class="col-sm-3 col-form-label" style=" margin-left: -20px;"><b>MANDAL:<span style="color:red;"><b>*</b></span></b></label>
      <div class="col-sm-9" style="margin-left: 12px;">
      <select name="itda" id="MandalID" class="form-control target">
      <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
      </select>
      </div>
      </div>
      </div>
      <div class="col-md-2">
      <div class="form-group row">
      <label for="" class="col-sm-3 col-form-label" style="margin-left: -20px;"><b>VILLAGE:<span style="color:red;"><b>*</b></span></b></label>
      <div class="col-sm-9" style="margin-left: 15px;">
      <select name="itda" id="VillageID" class="form-control">
      <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
      </select>
      </div>
      </div>
      </div>
      <div class="col-md-3">
      <div class="form-group row">
      <label for="" class="col-sm-4 col-form-label"><b>HABITATION:<span style="color:red;"><b>*</b></span></b></label>
      <div class="col-sm-8">
      <select name="itda" id="HabitationID" class="form-control">
      <option selected="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--Select--</option>
      </select>
      </div>
      </div>
      </div>
      </div>




      <br />
      <div class="row justify-content-center">
         <div class="col-md-12">
            <div class="table-responsive">
               <div class="maincard">
                  <div class="maincard-bdy" >
                     <table id="dt_bplot_tbl" class="table table-striped table-bordered dataTable ">
                        <thead>
                           <tr>
                              <td colspan="2" style="background-color:#008500;color:#fff;">&nbsp</td>
                              <td colspan="12" style="background-color: #008500;color:#fff;"></td>
                              <td colspan="1" style="background-color: #008500;color:#fff;">RESPONDENT</td>
                              <td colspan="2" style="background-color: #008500;color:#fff;">PETITIONER</td>
                              <td colspan="3" style="background-color: #008500;color:#fff;">ORDERS IN WHOSE FAVOUR</td>
                              <td colspan="2" style="background-color: #008500;color:#fff;">ORDERS IMPLEMENTED/AVAILABLE</td>
                              <td colspan="2" style="background-color: #008500;color:#fff;">DETAILS OF LAND FOR TRIBAL</td>
                              <td colspan="2" style="background-color: #008500;color:#fff;">DETAILS OF LAND FOR GOVERNMENT</td>
                              <td colspan="2" style="background-color: #008500;color:#fff;"></td>
                           </tr>
                           <tr style="background-color: #008500;color:#fff;">
                              <th scope="col" style="min-width:50px !important;">S.No<br />
                                 (1)
                              </th>
                              <th scope="col" style="min-width:50px !important;">VIEW
                                 <br />
                                 (2)
                              </th>
                              <th scope="col">ITDA
                                 <br />
                                 (3)
                              </th>
                              <th scope="col">DISTRICT
                                 <br />
                                 (4)
                              </th>
                              <th scope="col">MANDAL
                                 <br />
                                 (5)
                              </th>
                              <th scope="col">VILLAGE
                                 <br />
                                 (6)
                              </th>
                              <th   scope="col">STATUS
                                 <br />
                                 (7)
                              </th>
                              <th scope="col">R.S.No
                                 <br />
                                 (8)
                              </th>
                              <th  scope="col" style="min-width:140px;">EXTENT
                                 (Ac-Cts/Hec-a)<br />
                                 (9)
                              </th>
                              <th   scope="col">LTRP No.
                                 <br />
                                 (10)
                              </th>
                              <th   scope="col">DATE OF ORDERS
                                 <br />
                                 (11)
                              </th>
                              <th  scope="col">DATE OF DISPOSAL<br />  
                                 (12)
                              </th>
                              <th   scope="col">SDC LEVEL
                                 <br />
                                 (13)
                              </th>
                              <th   scope="col">SDC ORDERS PASSED
                                 <br />
                                 (14)
                              </th>
                              <th  scope="col">NON TRIBAL 
                                 <br />
                                 (15)
                              </th>
                              <th  scope="col">TRIBAL<br />
                                 (16)
                              </th>
                              <th  scope="col">GOVERNMENT<br />
                                 (17)
                              </th>
                              <th  scope="col">NON TRIBAL EXTENT
                                 <br />
                                 (18)
                              </th>
                              <th  scope="col">TRIBAL EXTENT<br />
                                 (19)
                              </th>
                              <th  scope="col" style="min-width:140px;">GOVERNMENT EXTENT<br />
                                 (20)
                              </th>
                              <th  scope="col">TRIBAL <br />
                                 (21)
                              </th>
                              <th scope="col">GOVT <br />
                                 (22)
                              </th>
                              <th  scope="col"> AC-CTS<br />  
                                 (23)
                              </th>
                              <th  scope="col">HEC-A<br />  
                                 (24)
                              </th>
                              <th scope="col">AC-CTS<br />  
                                 (25)
                              </th>
                              <th  scope="col"> HEC-A<br />  
                                 (26)
                              </th>
                              <th scope="col" style="min-width:220px;">Land Already Acquired for any Purpose<br />  
                                 (27)
                              </th>
                              <th scope="col">Remarks<br />
                                 (28)
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
   </div>
   <script src="../Newcdn/jquery-3.5.1.js"></script>
   <script src="../Newcdn/dataTables.buttons.min.js"></script>
   <script src="../Newcdn/dataTables.min.js"></script>
   <script src="../Newcdn/jszip.min.js"></script>
   <script src="../Newcdn/pdfmake0.1.18.min.js"></script>
   <script src="../Newcdn/vfs_fonts.js"></script>
   <script src="../Newcdn/html5.min.js"></script>
   <script src="../Newcdn/print.min.js"></script>
   <script src="../Newcdn/xlsx.full.min.js"></script>
   <script src="../NewJsFiles/View_Ltr.js"></script>
   <script src="../Newcdn/tabletoexcel.js"></script>
</asp:Content>