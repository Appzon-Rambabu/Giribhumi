<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Update_Land_Image.aspx.cs" Inherits="ROFR.pages.Update_Land_Image" EnableEventValidation="false" %>
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
<%--   
<script src="//cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
<link href="//cdn.datatables.net/1.10.4/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../js/S_Common.js"></script>--%>
    <style>
        .table-bordered td {
            border: 1px solid #808080;
        }
    </style>
     <script>
        function show(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg','JPG','JPEG','PNG']; //array of valid extensions
            var fileName = input.files[0].name;
            var str = input.files[0].name.split('.').length-1;
            //imageupload.FileName.Split('.').Length - 1;
           
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                $('#user_img').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            } else if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                $('#user_img').attr('src', null);
                $("#ContentPlaceHolder1_FileUpload").val("");
                document.getElementById('txt_image').value = "";
                fileName = "";
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--  document.getElementById('<%=txt_image.ClientID %>').value =  '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> '+"/"+fileName;--%>
                    <%--document.getElementById('<%=txt_image.ClientID %>').value = fileName;--%>
                    document.getElementById('txt_image').value = fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
           
        }
        </script>

     <script>
        function showimage(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg','JPG','JPEG','PNG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                $('#user_imgnew').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            } else if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                $('#user_imgnew').attr('src', null);
                $("#ContentPlaceHolder1_FileUpload1").val("");
                 document.getElementById('txt_imagenew').value = "";
                fileName = "";
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--  document.getElementById('<%=txt_image.ClientID %>').value =  '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> '+"/"+fileName;--%>
                    <%--document.getElementById('<%=txt_image.ClientID %>').value = fileName;--%>
                    document.getElementById('txt_imagenew').value = fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_imgnew').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
            //if (FileSize > 2) {
            //    alert('File size exceeds 2 MB');
            //    return false;
            //}
        }
        </script>
     <script>
          function Captcha(){
         var alpha = new Array('0','1','2','3','4','5','6','7','8','9'
 	    	);
     var i;
     for (i=0;i<6;i++){
         var a = alpha[Math.floor(Math.random() * alpha.length)];
         var b = alpha[Math.floor(Math.random() * alpha.length)];
         var c = alpha[Math.floor(Math.random() * alpha.length)];
         var d = alpha[Math.floor(Math.random() * alpha.length)];
         var e = alpha[Math.floor(Math.random() * alpha.length)];
        
                      }
         var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e ;
        // document.getElementById("mainCaptcha").innerHTML = code
		// document.getElementById("mainCaptcha").value = code
       }
     function ValidCaptcha() {

        var itda = document.getElementById("Itda").value;
         var dist = document.getElementById("District").value;
         var mandal = document.getElementById("Mandal").value;
         var village = document.getElementById("Village").value;

             var captcha = document.getElementById('txtInput').value;
        if (itda== "0") {
            
            alert("Please Select Itda!");
            return false;
        }
        if (dist == "0") {

            alert("Please Select district");
            return false;
        }
        if (mandal == "0") {

            alert("Please Select Mandal");
            return false;
        }
        if (village == "0") {

            alert("Please Select Village");
            return false;
        }
        if (captcha == "")
        {

            alert("Please Enter Captcha");
            return false;
        }
        if (captcha != "") {

            var string1;
        //    var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
            var string2 = removeSpaces(document.getElementById('txtInput').value);
            if (string1 == string2) {
                return true;
            }


            else {

                alert("enter valid captcha");

                return false;
            }
        }
}
function removeSpaces(string){
     return string.split(' ').join('');
}

    </script>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <div class="container-fluid">
                                  <div class="panel panel-body">

                                        <asp:UpdateProgress ID="UPDATED" runat="server">
                                    <ProgressTemplate>
                                        <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner"></div>
                                   <span id="loading-msg">
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                

                                <span id="user" style="display:none" runat="server"></span>
                                <span id="username" style="display:none" runat="server"></span>
                                <span id="ipadress" style="display:none" runat="server"></span>
                                  <span id="tk" style="display:none" runat="server"></span>
                               <%-- <span id="cpt" style="display:none" runat="server"></span>--%>
                                 <label type="text" id="cpt"  style="display:none" runat="server"/>
                                                
                       <span id="ustart" style="display:none" runat="server"></span>
                         <span id="end" style="display:none" runat="server"></span>

                                     
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Upload Stone Plantation Images</h5>
                        <div>
                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">ITDA <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                                <select class="form-control" id="Itda">
							<option value="0">Select Itda</option>
							
						</select>
                                                   <%--  <asp:DropDownList ID="ddl_itda"   CssClass="form-control"   AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList> --%>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">District <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                <select class="form-control" id="District">
							<option value="0">Select District</option>
							
						</select>
                                                   <%-- <asp:DropDownList ID="ddl_dist"   CssClass="form-control"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"></asp:DropDownList> --%>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Mandal <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                <select class="form-control" id="Mandal">
							<option value="0">Select Mandal</option>
							
						</select>
                                                     <%-- <asp:DropDownList ID="ddl_mandal"   CssClass="form-control"   runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" ></asp:DropDownList> --%>
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Village <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                              <%--  <div class="form-group">--%>
                                                <select class="form-control" id="Village">
							<option value="0">Select Village</option>
							
						</select>
                                                   <%-- <asp:DropDownList ID="ddl_village"  CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" ></asp:DropDownList> --%>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                       
                            </div>
                                             <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                            
                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                              <%--  <div class="form-group">--%>
                                             <%--<div >
                                                     <h2 type="text" id="mainCaptcha" class="text-center text-white"> </h2>
                                                         <asp:Image ID="Image2" runat="server" Height="40px"  Width="186px" />
                                                    </div>
                                               <%-- </div>--%>
                                             <%-- </div>
                                            <div class="col-md-1 text-left">
                                                <button type="button" class="btn btn-light" value="Refresh" id="refresh"  runat="server" onserverclick="Submit_Click"><i class="fa fa-refresh"></i></button>
                                            </div>
                                        </div>
                           </ContentTemplate>
                         </asp:UpdatePanel>--%>
                                             <%--   <div class="row mb-2">
                                            <div class="col-md-4 text-right">Enter Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                             <%--<input type="text" id="txtInput" name="captcha" class="form-control" autocomplete="off"  />
                                               </div>
                                            </div>
                                        </div>--%>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right"></div>
                                            <div class="col-md-4 text-left">
                                                <div class="form-group">
                                                     <a href="javascript:void(0);" title="Submit" id="btn_submit" class="btn  btn-success ">Submit</a>
                                                 <%--  <asp:Button ID="Button1"     OnClientClick="return ValidCaptcha() " runat="server" Text="Submit" OnClick="Button1_Click"  />--%>
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
                       
                        <table id="dt_plot_tbl" class="table table-striped table-bordered dataTable" >

                            <thead class="bg-info text-white">
                               
                                <tr>
                                 <th>S.NO</th>
                                    <th>BENEFICIARY ID</th>
                                    <th>ID</th>
                                 <%--  <th>ITDA</th>
                                    <th>DISTRICT</th>
                                     <th>MANDAL</th>
                                    
                                    <th>VILLAGE</th>--%>
                                      
                                    <th>ROFR PATTADAR NAME</th>
                                    <th>FATHER NAME</th>
                                     <th>AADHAR NO.</th>
                                       <th>COMPARTMENT NO.</th>
                                    <th>ROFR PATTANO.</th>
                                    <th>EXTENT</th>
                                     <th>VIEW IMAGE1</th>
                                      <th>VIEW IMAGE2</th>
                                      <th>UPDATE</th>
                                    
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>

                      
                    </div>
                </div>
                                        </div>
                                    </div>
                                </div>



                            </div>

                       



                    </main>
                </div>
           

    <div class="modal fade" id="showupdate" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header ">
                    <h5 class="modal-title" id="changepwdLabel">Upload Land Images</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" style="color:black">×</span>
                    </button>
                </div>
                <div class="modal-body">
                      <div class="row giribhumi-custom-form">

                 


                    <div class="col-md-6 col-12">
                        
                        <div class="row mb-2">
                            <asp:Label ID="lbl_subcaste" runat="server" Text="Beneficiary Id:" CssClass="col-md-6 col-form-label" ></asp:Label>

                               <label id="ben_id" class="col-md-6" style="color:#1f1f75;"></label>
                        </div>
                        <div class="row mb-2">
                            <asp:Label ID="lbl_poname" runat="server" Text="Id:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <label id="plot_id" class="col-md-6" style="color:#1f1f75;"></label>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_poaccount" runat="server" Text="ROFR Pattadhaar Name:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <label id="farmer_name" class="col-md-6" style="color:#1f1f75;"></label>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl" runat="server" Text="Extent:" CssClass="col-md-6 col-form-label"></asp:Label>

                           <label id="p_extent" class="col-md-6" style="color:#1f1f75;"></label>
                        </div>

                       

                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload Land Image1:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                          <%--  <asp:TextBox ID="txt_image" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>--%>
                                  <input id="txt_image" type="text" name="filename"  class="col-md-4"autocomplete="off" readonly   />   
                            <div class="custom-file col-md-2">
                                    <input id="FileUpload" type="file" name="file" onchange="show(this)"  />
                                    <%--<asp:Button ID="btn_image" runat="silenameerver" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>

                           <div class="row mb-2">
                            <asp:Label ID="Label1" runat="server" Text="Upload Land Image2:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                          <%--  <asp:TextBox ID="txt_image" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>--%>
                                  <input id="txt_imagenew" type="text" name="filename"  class="col-md-4"autocomplete="off" readonly   />   
                            <div class="custom-file col-md-2">
                                    <input id="FileUpload1" type="file" name="file" onchange="showimage(this)"  />
                                    <%--<asp:Button ID="btn_image" runat="silenameerver" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>
                    </div>
                    
                    <div class="col-md-3 col-12  justify-content-end">
                         <div class="row mb-2">
                            
                            <div class="col-md-12"><img id="user_img" height="90" width="90" style="border: thick;" /></div>
                            
                        </div>
                    </div>
                           <div class="col-md-3 col-12  justify-content-end">
                         <div class="row mb-2">
                            
                            <div class="col-md-12"><img id="user_imgnew" height="90" width="90" style="border: thick;" /></div>
                            
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
        	
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>

     <script src="../MapJsfloder/Update_LandImage.js"></script>

   
      <%--  <script src="../js/jquery.min.js"></script>--%>
<%--  <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>--%>
   <%-- <script src="../js/bootstrap.bundle.min.js"></script>--%>
     <link href="../js/datatable.css" rel="stylesheet" />
    <script src="../js/datatable.js"></script>
  <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
  
    <script src="../js/datatables.min.js"></script>--%>
    

</asp:Content>
