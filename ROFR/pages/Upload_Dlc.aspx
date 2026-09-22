<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Upload_Dlc.aspx.cs" Inherits="ROFR.pages.Upload_Dlc"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            var validExtensions = ['jpg', 'png', 'jpeg','JPG','JPEG','PNG','pdf','PDF']; //array of valid extensions
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
  text-align: center; /* center checkbox horizontally */
  vertical-align: middle; /* center checkbox vertically */
}
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }

   
     .table th {
      text-align: center;
       background-color:#008500!important;
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
    
       <div class="container-fluid"><%--<div id="loading-wrapper">
        <div>
            <div class="d-flex justify-content-center">
                <div class="spinner-border text-primary">
                    <span class="sr-only">Loading...</span>
                </div>
            </div>
        </div>
    </div>--%>
           <div id="preloader" class="preloader" style="background: rgba(255,255,255,0.5);">
        <div class="spinner"></div>
        <span id="loading-msg">
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
       <%--    <div  style="background:rgba(255,255,255,0.5);text-align:center" >
                <div id="spinner" style="padding-top:10%;">
                  <img alt="" src="../newcss/images/preloaders/1.gif"/>
                </div>
                <div id="disable-preloader" class="btn btn-default btn-sm"></div>
              </div>--%>
                <div class="row" style="margin-top:-30px;">
                        <span id="tk" style="display:none" runat="server"></span>
                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">

                        <span id="ben_id_multiple" style="display:none" ></span>
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Upload DLC</h5>
                <div>
                    <div class="col-lg-12" >
                                <div class="row" id="maindiv">

                                     <div class="col-md-4">

                                        <label class="Radio Radio--large" for="rbgst">
                                            Select:
                                        </label>
                                    </div>
                                    <div class="col-md-4">

                                        <label class="Radio Radio--large" for="rbgst">
                                            <input type="radio" checked="checked" class="Radio-Input" id="rbbid" name="in" value="1"/>Benificiary Id wise
                                        </label>
                                    </div>
                                    <div class="col-md-4">

                                        <label class="Radio Radio--large" for="rbgst">
                                     <input type="radio" class="Radio-Input" id="rbid" name="in" value="2"/>Plot Id wise
                                        </label>
                                    </div>
                                  
                                   
                                </div>
                                <div class="row">

                                       <div class="col-md-10">
                                    <div class="form-group ">
                                        <div class="row">
                                            <label class="col-md-5" id="lblsou">Enter Id's: </label>
                                            <div class="col-md-7">
                                                <input type="text" id="Ben_multi" class="form-control" autocomplete="off" placeholder="Benificiary Id's" style="width:400px"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                <div class="row"> <div class="col-md-10 text-center">
                                        <a href="javascript:void(0);" title="click here get" id="Ben_data" class="btn  btn-success">Submit</a>
                                     <a href="javascript:void(0);" title="click here get" id="upload_dlc" class="btn  btn-success">Upload DLC</a>
                                    
                                    </div></div>
                     

                          

                            <!--<div class="col-md-2">
                                <a href="javascript:void(0);" title="click here get" id="Revenue_data" class="btn  btn-primary">Submit</a>

                            </div>-->
                        </div>
                      
                  
                         </div>

                    </div>
 <div class="row justify-content-center">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                             <div class="maincard">
                    <div class="maincard-bdy" >
                       
                        <table id="dt_bplot_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                               
                                <tr>
                                     <th><input type="checkbox" id="checkAll"/></th>
                                 <th>S.NO</th>
                                    <th>BENEFICIARY ID</th>
                                    <th>PLOT ID</th>
                                 <%--  <th>ITDA</th>
                                    <th>DISTRICT</th>--%>
                                     <th>MANDAL</th>
                                    
                                    <th>VILLAGE</th>
                                      
                                    <th>ROFR PATTADAR NAME</th>
                                    <th>FATHER NAME</th>
                                     <th>AADHAR NO.</th>
                                       <th>COMPARTMENT NO.</th>
                                    <th>ROFR PATTANO.</th>
                                    <th>EXTENT</th>
                                     <th>VIEW DLC</th>
                                     
                                    
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

                           <input type="text" id="todate" title="Date" oncopy="return false" onpaste="return false" oncut="return false"  maxlength="10" autocomplete="off" placeholder="Date" class="col-md-6" readonly />
                        </div>

                       

                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload DLC:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                         
                                  <input id="txt_image" type="text" name="filename"  class="col-md-4" autocomplete="off" readonly   />   
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

     <script src="../MapJsfloder/Upload_Dlc.js"></script>

    <%--<script src="vendor-assets/popper.js/tooltip.min.js"></script>--%>
   

    


     <link href="../js/datatable.css" rel="stylesheet" />
    <script src="../js/datatable.js"></script>
    <%-- <link href="../css/dataTables.checkboxes.css" rel="stylesheet" />
  
    <script src="../js/dataTables.checkboxes.min.js"></script>--%>
  
</asp:Content>
