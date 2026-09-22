<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Upload_Dlc.aspx.cs" Inherits="ROFR.pages.Upload_Dlc"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .ui-datepicker {
  display: none;
  width: 15rem;
  background: #ffffff;
  border-radius: 0.25rem;
  box-shadow: 0 0 5px 0 rgba(0, 0, 0, 0.2);
  margin-top: 1rem;
}
.ui-datepicker-header {
  text-align: center;
  padding: 0.5rem 0;
  text-transform: uppercase;
  letter-spacing: 0.1rem;
}
.ui-datepicker-header a span {
  display: none;
}
.ui-datepicker-header a.ui-corner-all {
  cursor: pointer;
  position: absolute;
  top: 0;
  width: 2rem;
  height: 2rem;
  margin: 0.5rem;
  border-radius: 0.5rem;
}
.ui-datepicker-header a.ui-datepicker-prev {
  left: 0;
}
.ui-datepicker-header a.ui-datepicker-prev::after {
  font-family: "FontAwesome";
  content: "\f104";
  font-size: 1.5rem;
  color: #444444;
}
.ui-datepicker-header a.ui-datepicker-next {
  right: 0;
}
.ui-datepicker-header a.ui-datepicker-next::after {
  font-family: "FontAwesome";
  content: "\f105";
  font-size: 1.5rem;
  color: #444444;
}
.ui-datepicker-calendar {
  width: 100%;
  text-align: center;
  padding: 1rem;
}
.ui-datepicker-calendar thead {
  color: #cccccc;
}
.ui-datepicker-calendar a {
  color: #444444;
  text-decoration: none;
  display: block;
  margin: 0 auto;
  width: 25px;
  height: 25px;
  line-height: 22px;
  border-radius: 50%;
  border: 1px solid transparent;
  cursor: pointer;
}
.ui-datepicker-calendar a:hover {
  border: 1px solid #cccccc;
}
.ui-datepicker-calendar .ui-state-highlight {
  border-color: #d33a47;
  color: #d33a47;
}
.ui-datepicker-calendar .ui-state-active {
  background: #d33a47;
  color: #ffffff;
}
    </style>
   <script>
        function show(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg', 'JPG', 'JPEG', 'PNG', 'pdf', 'PDF']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
            var FileSize = input.files[0].size / 1024 / 1024; // in MB
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                //$('#user_img').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--  document.getElementById('<%=txt_image.ClientID %>').value =  '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> '+"/"+fileName;--%>
                    <%--document.getElementById('<%=txt_image.ClientID %>').value = fileName;--%>
                    document.getElementById('txt_image').value = fileName;
                    var filerdr = new FileReader();
                    //filerdr.onload = function (e) {
                    //    $('#user_img').attr('src', e.target.result);
                    //}
                    filerdr.readAsDataURL(input.files[0]);
                }

            }
            //if (FileSize > 2) {
            //    alert('File size exceeds 2 MB');
            //    return false;
            //}
        }
    </script>
      <style>
   td {
  text-align: left; /* center checkbox horizontally */
  vertical-align: middle; /* center checkbox vertically */
}
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
     .table th {
      text-align:left;
       background-color:#008500!important;
       }
    .bg-nav{
      background-color:#008500 !important;
    }
     #loading-wrapper {
            background: rgba(255, 255, 255, 0.40) !important;
        }
     .table{
         
     }
  </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container-fluid">
           <%--<div id="loading-wrapper">
        <div>
            <div class="d-flex justify-content-center">
                <div class="spinner-border text-primary">
                    <span class="sr-only">Loading...</span>
                </div>
            </div>
        </div>
    </div>--%>
      <div id="preloader" style="background:rgba(255,255,255,0.5);text-align:center" >
                <div id="spinner" style="padding-top:10%;">
                  <img alt="" src="../newcss/images/preloaders/1.gif"/>
                </div>
              <div id="disable-preloader" class="btn btn-default btn-sm"></div>
              </div>

       <div class="row">
                        <span id="tk" style="display:none" runat="server"></span>
                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">
                        <span id="ben_id_multiple" style="display:none" ></span>
                                <div class="row justify-content-center">
                                    <div class="col-md-3">
                                     <h5 class="text-center text-white rounded py-1 bg-nav">Jalakala Scheme</h5>
                                <div>
                             </div>
                         </div>
                    </div>
     
      <div class="row justify-content-center">
              <div class="col-md-12">
                      <div class="table-responsive">
                               <div class="maincard">
                                       <div class="maincard-bdy" >
     <table id="dt_bplot_tbl" class="table table-striped table-bordered dataTable ">
                               <thead class="bg-info text-white">
                                   
                                <tr>
                                    <th rowspan="2">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">ITDA <br /><span>(1)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">Total Beneficiaries <br /><span>(2)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">VRO Status <br /><span>(3)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">Pending for APD Push to Contractor <br /><span>(4)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">Contractor Field Survey <br /><span>(5)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">Asst. Project Director (APD) Status <br /><span>(6)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">Bore Status <br /><span>(7)</span></th>
                                </tr>
                                <tr>
                                  
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Completed <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Success <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Failed <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">To be bored <br /><span>(3)</span></th>
                                </tr>
                                         <%-- <tr>

                                   <th>1</th>
                                    <th>1</th>
                                    <th>2</th>
                                    <th>3=2-4-5</th>
                                    <th>4</th>
                                    <th>5</th>
                                    <th>6</th>
                                    <th>7=3-6-8</th>
                                    <th>8</th>
                                    <th>9</th>
                                    <th>10</th>
                                    <th>11</th>
                                    <th>12</th>
                                    <th>13</th>
                                    <th>14=9-(12+13)</th>
                                </tr>--%>
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
                       <div class="col-md-12"> 
                           <input type="button" value="Back" id="itdaid"/></div>
                       <div class="table-responsive">
                 <div class="maincard">
                    <div class="maincard-bdy" >
                        <table id="dt_dist_tbl" class="table table-striped table-bordered dataTable" >
                            <thead class="bg-info text-white">
                                <tr>
                                     
                                    <th rowspan="2">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">District Name <br /><span>(1)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">Total Beneficiaries <br /><span>(2)</span></th>
                                     <th colspan="3" class="sorting_disabled text-center">VRO Status <br /><span>(3)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">Pending for APD Push to Contractor <br /><span>(4)</span></th>
                                    <th colspan="2" class="sorting_disabled text-center">Contractor Field Survey <br /><span>(5)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">Asst. Project Director (APD) Status <br /><span>(6)</span></th>
                                     <th colspan="3" class="sorting_disabled text-center">Bore Status <br /><span>(7)</span></th>
                                </tr>
                                <tr>
                                    
<th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Completed <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Success <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Failed <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">To be bored <br /><span>(3)</span></th>
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
                                    <div class="col-md-12"><div class="col-md-12">
                                        <input type="button" value="Back" id="distbackid"/></div>
                                        <div class="table-responsive">
                                             <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_Mandal_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                               
                                <tr>
                                     
                                    <th rowspan="2">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">Mandal Name <br /><span>(1)</span></th>
                                    <th rowspan="2"class="sorting_disabled text-center">Total Beneficiaries <br /><span>(2)</span></th>
                                 
                                     <th colspan="3" class="sorting_disabled text-center">VRO Status <br /><span>(3)</span></th>
                                    
                                    <th rowspan="2" class="sorting_disabled text-center">Pending for APD Push to Contractor <br /><span>(4)</span></th>
                                      
                                    <th colspan="2" class="sorting_disabled text-center">Contractor Field Survey <br /><span>(5)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">Asst. Project Director (APD) Status <br /><span>(6)</span></th>
                                     <th colspan="3" class="sorting_disabled text-center">Bore Status <br /><span>(7)</span></th>
                                       
                                     
                                    
                                </tr>
                                <tr>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Completed <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Success <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Failed <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">To be bored <br /><span>(3)</span></th>
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
                                    <div class="col-md-12"><div class="col-md-12"> <input type="button" value="Back" id="mandalbackid"/></div>
                                        <div class="table-responsive">
                                             <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_village_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                               
                                <tr>
                                     
                                 <th rowspan="2">S.NO</th>
                                    <th rowspan="2" class="sorting_disabled text-center">Village Name <br /><span>(1)</span></th>
                                    <th rowspan="2" class="sorting_disabled text-center">Total Beneficiaries <br /><span>(2)</span></th>
                                 
                                     <th colspan="3" class="sorting_disabled text-center">VRO Status <br /><span>(3)</span></th>
                                    
                                    <th rowspan="2" class="sorting_disabled text-center">Pending for APD Push to Contractor <br /><span>(4)</span></th>
                                      
                                    <th colspan="2" class="sorting_disabled text-center">Contractor Field Survey <br /><span>(5)</span></th>
                                    <th colspan="3" class="sorting_disabled text-center">Asst. Project Director (APD) Status <br /><span>(6)</span></th>
                                     <th colspan="3" class="sorting_disabled text-center">Bore Status <br /><span>(7)</span></th>
                                       
                                     
                                    
                                </tr>
                                <tr>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Completed <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Approved <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Rejected <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">Pending <br /><span>(3)</span></th>
                                    <th class="sorting_disabled text-center">Success <br /><span>(1)</span></th>
                                    <th class="sorting_disabled text-center">Failed <br /><span>(2)</span></th>
                                    <th class="sorting_disabled text-center">To be bored <br /><span>(3)</span></th>
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
                                    <div class="col-md-12"><div class="col-md-12"> <input type="button" value="Back" id="itdvillage"/></div>
                                        <div class="table-responsive">
                                             <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_detailed_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                                <tr>
                                   <th>S.NO</th>
                                   <th style="display: none" class="sorting_disabled text-center">Aadhaar Number <br /><span>(1)</span></th>
								   <th class="sorting_disabled text-center">Beneficiary Name <br /><span>(1)</span></th>
                                   <th class="sorting_disabled text-center">Father Name <br /><span>(2)</span></th> 
                                   <th class="sorting_disabled text-center">Caste <br /><span>(3)</span></th>
                                   <th class="sorting_disabled text-center">Sub Caste <br /><span>(4)</span></th>
                                   <th class="sorting_disabled text-center">Aadhaar Number <br /><span>(5)</span></th>
                                   <th class="sorting_disabled text-center">Mobile Number <br /><span>(6)</span></th>
                                   <th class="sorting_disabled text-center">Land Type <br /><span>(7)</span></th>
                                   <th class="sorting_disabled text-center">Survey No<br /><span>(8)</span></th>
                                   <th class="sorting_disabled text-center">Khata Number <br /><span>(9)</span></th>
                                   <th class="sorting_disabled text-center">Extent Acres <br /><span>(10)</span></th>
                                   <th class="sorting_disabled text-center">Application Number <br /><span>(11)</span></th>
                                   <th class="sorting_disabled text-center">Application Status <br /><span>(12)</span></th>
                                    <th class="sorting_disabled text-center">Bore Status Success Fail <br /><span>(13)</span></th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>
               </main>
          </div>
</div>
       <div class="modal fade" id="showupdate" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header ">
                    <h5 class="modal-title" id="changepwdLabel">Upload DLC</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" style="color:black">×</span>
                    </button>
                </div>
                <div class="modal-body">
                      <div class="row giribhumi-custom-form">
                    <div class="col-md-6 col-12">
                        <div class="row mb-2">
                           <asp:Label ID="Label1" runat="server" Text="DLC Issued date:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                           <input type="text" id="todate" title="Date" oncopy="return false" onpaste="return false" oncut="return false"  maxlength="10" autocomplete="off" placeholder="Date" class="col-md-6" readonly="" />
                        </div>
                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload DLC:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         
                               <input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly=""   />   
                            <div class="custom-file col-md-2">
                               <input id="FileUpload" type="file" name="file" onchange="show(this)" style="overflow: hidden; max-width: 270px;" />
                                   
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button"  id="Update_Image">Submit</button>

                </div>
            </div>
        </div>
    </div>

    
       <script src="js/custom.js"></script>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script src="../newcss/js/jquery-3.5.1.min.js"></script>
     <script src="../js/jquery-ui.js"></script>
  <%--<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" rel="stylesheet" />--%>
        	  <%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
   <%-- <script src="../newcss/js/date-picker.js"></script>--%>
    <script src="../MapJsfloder/Jalakalareport.js?v=34"></script>
    <%--<script src="vendor-assets/popper.js/tooltip.min.js"></script>--%>
     <link href="../js/datatable.css" rel="stylesheet" />
    <script src="../js/datatable.js"></script>
    <%-- <link href="../css/dataTables.checkboxes.css" rel="stylesheet" />
    <script src="../js/dataTables.checkboxes.min.js"></script>--%>
  <%-- <style>
  .hide_column {
    display : none;
    }
   </style>--%>
        
   
</asp:Content>
