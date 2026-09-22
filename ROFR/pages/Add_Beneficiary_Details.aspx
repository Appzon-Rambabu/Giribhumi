<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Add_Beneficiary_Details.aspx.cs" Inherits="ROFR.pages.Add_Beneficiary_Details"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript" language="javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
         
     <script type="text/javascript">
         
         function validation()
         {
             var Itda = document.getElementById('<%=ddl_ITda.ClientID %>').value;
             var district = document.getElementById('<%=ddl_district.ClientID %>').value;
             var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
             var division = document.getElementById('<%=ddl_division.ClientID %>').value;
             var range = document.getElementById('<%=ddl_range.ClientID %>').value;
             var beat = document.getElementById('<%=ddl_beat.ClientID %>').value;
             var gp = document.getElementById('<%=txt_gp.ClientID %>').value;
             var gpcode= document.getElementById('<%=txt_gpcode.ClientID %>').value;
             var village = document.getElementById('<%=ddl_village.ClientID %>').value;
       <%-- var villagecode = document.getElementById('<%=txt_villagecode.ClientID %>').value;--%>
             <%--  var habitation = document.getElementById('<%=txt_Habitation.ClientID %>').value;--%>
             var fblock = document.getElementById('<%=txt_fblock.ClientID %>').value;
             var compartment = document.getElementById('<%=txt_compartment.ClientID %>').value;
             <%--var plot = document.getElementById('<%=txt_plot.ClientID %>').value;--%>
             var plotarea= document.getElementById('<%=txt_plotarea.ClientID %>').value;
             <%-- var ucland = document.getElementById('<%=txt_uc_land.ClientID %>').value;
        var cland = document.getElementById('<%=txt_c_land.ClientID %>').value;--%>
             var pattainam = document.getElementById('<%=ddl_patta_inam.ClientID %>').value;
             <%--  var wtax = document.getElementById('<%=txt_wtax.ClientID %>').value;--%>
             <%--var dryid = document.getElementById('<%=ddl_dry_id.ClientID %>').value;--%>
             <%--  var wsource = document.getElementById('<%=txt_wsource.ClientID %>').value;--%>
             var pattano = document.getElementById('<%=txt_patta_no.ClientID %>').value;
             <%--var eirrigated = document.getElementById('<%=txt_Eirrigated.ClientID %>').value;--%>
             var pattadar = document.getElementById('<%=txt_pattadar.ClientID %>').value;

            <%-- var fathername= document.getElementById('<%=txt_father_name.ClientID %>').value;--%>

             var cname= document.getElementById('<%=txt_cname.ClientID %>').value;
             <%--var eucultivator = document.getElementById('<%=txt_eu_cultivator.ClientID %>').value;--%>

             var holding = document.getElementById('<%=txt_holding.ClientID %>').value;
             <%--var typecode = document.getElementById('<%=txt_typecode.ClientID %>').value;

         var extent = document.getElementById('<%=txt_extent.ClientID %>').value;
         var netarea = document.getElementById('<%=txt_net_area.ClientID %>').value;--%>
             <%-- var kharif = document.getElementById('<%=txt_kharif.ClientID %>').value;
        var month = document.getElementById('<%=txt_month.ClientID %>').value;--%>
             <%--   var crop = document.getElementById('<%=txt_crop.ClientID %>').value;
         var single = document.getElementById('<%=txt_single.ClientID %>').value;
         var mixed = document.getElementById('<%=txt_mixed.ClientID %>').value;
         var total = document.getElementById('<%=txt_total.ClientID %>').value;
         var water = document.getElementById('<%=txt_water.ClientID %>').value;
         var firstcrop = document.getElementById('<%=txt_firstcrop.ClientID %>').value;
         var secondcrop = document.getElementById('<%=txt_secondcrop.ClientID %>').value;--%>
             var landclassification = document.getElementById('<%=ddl_land_class.ClientID %>').value;
              var dlcdate = document.getElementById('<%=txt_dlc_date.ClientID %>').value;
             var aadhar = document.getElementById('<%=txt_aadhar.ClientID %>').value;
             var bankname = document.getElementById('<%=txt_bank_name.ClientID %>').value;
             var bankacnt = document.getElementById('<%=txt_bank_acnt.ClientID %>').value;
        
             var ifsc=  document.getElementById('<%=txt_ifsc_code.ClientID %>').value;
             <%--var cropyeild = document.getElementById('<%=txt_crop_yield.ClientID %>').value;
         var vro = document.getElementById('<%=txt_vro.ClientID %>').value;
         var thasildar= document.getElementById('<%=txt_Thasildar.ClientID %>').value;
        var remarks = document.getElementById('<%=txt_remarks.ClientID %>').value;--%>
             var img = document.getElementById('<%=FileUpload.ClientID %>').value;
             var imgpath=document.getElementById('<%=txt_image.ClientID %>').value;
             var dlc = document.getElementById('<%=file_dlc.ClientID %>').value;
             var dlcpath = document.getElementById('<%=txt_dlc.ClientID %>').value;
             
            
            
             
            
            

             if (Itda == "0") {

                 alert("Please select Itda Name!");
                 return false;
             }
             if (district== "0") {
            
                 alert("Please select District!");
                 return false;
             }
             if (mandal == "0") {

                 alert("Please select Mandal!");
                 return false;
             }
             if (division == "0") {

                 alert("Please select Division!");
                 return false;
             }
             if (range == "0") {

                 alert("Please select Range!");
                 return false;
             }
             if (beat == "0") {

                 alert("Please select Beat!");
                 return false;
             }
             if (gp == "") {

                 alert("Please Enter Grampanchayat!");
                 return false;
             }
             if (gpcode == "") {

                 alert("Please Enter Grampanchayat code!");
                 return false;
             }
             if (village == "0") {

                 alert("Please Select Village!");
                 return false;
             }
             //if (villagecode == "") {

             //    alert("Please Enter Village Code!");
             //    return false;
             //}
         
             if (fblock == "") {

                 alert("Please Enter Forest Block!");
                 return false;
             }
             if (compartment == "") {

                 alert("Please Enter Compartment Number!");
                 return false;
             }
                
             if (plotarea == "") {

                 alert("Please Enter Plot Area!");
                 return false;
             }
             //if (ucland == "") {

             //    alert("Please Enter Uncultivable Land!");
             //    return false;
             //}
             //if (cland == "") {

             //    alert("Please Enter Cultivable Land!");
             //    return false;
             //}
             //if (cland == "") {

             //    alert("Please Enter Cultivable Land!");
             //    return false;
             //}
             if (pattainam == "0") {

                 alert("Please Enter Patta Inam Govt!");
                 return false;
             }
             if (pattano == "") {

                 alert("Please Enter ROFR Patta Number!");
                 return false;
             }
             if (pattadar == "") {

                 alert("Please Enter Pattadaar Name!");
                 return false;
             }
             if (cname == "") {

                 alert("Please Enter Cultivator Name!");
                 return false;
             }
             if (holding == "") {

                 alert("Please Enter Holding Nature!");
                 return false;
             }
             //if (typecode == "") {

                 //    alert("Please Enter Typecode!");
                 //    return false;
                 //}
                 //if (extent == "") {

                 //    alert("Please Enter Extent!");
                 //    return false;
                 //}
                 //if (netarea == "") {

                 //    alert("Please Enter Net Sown Area!");
                 //    return false;
                 //}
                 //if (kharif == "") {

                 //    alert("Please Enter Kharif/Rabi!");
                 //    return false;
                 //}
                 //if (month== "") {

                 //    alert("Please Enter Month of Cultivation!");
                 //    return false;
                 //}
                 //if (crop == "") {

                 //    alert("Please Enter Crop!");
                 //    return false;
                 //}
                 //if (single == "") {

                 //    alert("Please Enter Single!");
                 //    return false;
                 //}
                 //if (mixed == "") {

                 //    alert("Please Enter Mixed!");
                 //    return false;
                 //}
                 //if (total == "") {

                 //    alert("Please Enter Total!");
                 //    return false;
                 //}
                 //if (water == "") {

                 //    alert("Please Enter Water Source1 !");
                 //    return false;
                 //}
                 //if (firstcrop == "") {

                 //    alert("Please Enter First Crop!");
                 //    return false;
                 //}
                 //if (secondcrop == "") {

                 //    alert("Please Enter Second-Third Crop!");
                 //    return false;
                 //}
             if (landclassification == "0") {
                 alert("Select Land Classification!");
                 return false;
             }

             if (dlcdate == "") {
                 alert("Enter Dlc Date!");
                 return false;
             }
                 if (aadhar== "") {

                     alert("Please Enter Aadhaar Number!");
                     return false;
                 }
               
                 //if (cropyeild == "") {

                 //    alert("Please Enter Crop Yeild!");
                 //    return false;
                 //}
                 //if (vro== "") {

                 //    alert("Please Enter VRO Remarks!");
                 //    return false;
                 //}
                 //if (thasildar == "") {

                 //    alert("Please Enter Tahsildar Remarks!");
                 //    return false;
                 //}
                 //if (remarks== "") {

                 //    alert("Please Enter  Remarks!");
                 //    return false;
             //}

                 //if (fathername == "") {
                 //    alert("Enter Father name!");
                 //    return false;
                 //}

                 if (bankname == "") {
                     alert("Enter Bank name!");
                     return false;
                 }
                 if (bankacnt == "") {
                     alert("Enter Bank account number!");
                     return false;
                 }
                 if (ifsc == "") {
                     alert("Enter IFSC code!");
                     return false;
                 }

                 if(img=="")
                 {
                     alert("Please Select Image!");
                     return false;
                 }
                 if (imgpath == "") {
                     alert("Select Image!");
                     return false;
                 }
                 if (dlc == "") {
                     alert("Please Select Dlc!");
                     return false;
                 }

                 if (dlcpath == "")
                 {
                     alert("Select Dlc!");
                     return false;
                 }
                
             
             } 
         
     </script>

    <script>
        function show(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg','JPG','JPEG','PNG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                $('#user_img').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--  document.getElementById('<%=txt_image.ClientID %>').value =  '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> '+"/"+fileName;--%>
                    document.getElementById('<%=txt_image.ClientID %>').value = "Beneficairy Images/"+fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
            if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                return false;
            }
        }
        </script>
    <script>
        function file(input,obj) {
            debugger;
            var validExtensions = ['pdf', 'PDF', 'jpg', 'JPG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);

            var FileSize = input.files[0].size / 1024 / 1024; // in MB


            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
               // $('#user_img').attr('src', "");
                alert("Only these pdf and jpg  files are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--   document.getElementById('<%=txt_dlc.ClientID %>').value = input.value;--%>

                      document.getElementById('<%=txt_dlc.ClientID %>').value= "DLC/"+fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                       // $('#user_img').attr('src', e.target.result);
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
   

<%--    <script>
    function checkFileDetails() {
        var fi = document.getElementById('file');
        if (fi.files.length > 0) {      // FIRST CHECK IF ANY FILE IS SELECTED.
           
         

            // GET THE IMAGE WIDTH AND HEIGHT USING fileReader() API.
            function readImageFile(file) {
                var reader = new FileReader(); // CREATE AN NEW INSTANCE.

                reader.onload = function (e) {
                    var img = new Image();      
                    img.src = e.target.result;

                    img.onload = function () {
                        var w = this.width;
                        var h = this.height;

                        document.getElementById('fileInfo').innerHTML =
                            document.getElementById('fileInfo').innerHTML + '<br /> ' +
                                'Name: <b>' + file.name + '</b> <br />' +
                                'File Extension: <b>' + fileExtension + '</b> <br />' +
                                'Size: <b>' + Math.round((file.size / 1024)) + '</b> KB <br />' +
                                'Width: <b>' + w + '</b> <br />' +
                                'Height: <b>' + h + '</b> <br />' +
                                'Type: <b>' + file.type + '</b> <br />' +
                                'Last Modified: <b>' + file.lastModifiedDate + '</b> <br />';
                    }
                };
                reader.readAsDataURL(file);
            }
        }
    }
</script>--%>

    <style>
    .panel-body {
    padding: 0px 5px;
    margin-bottom: 10px;
    }
        .card-header {
            padding: .10rem 1.25rem;
        }
  /*.form-control {
      border-radius:0px;
      border-color:#888;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container"></div>

         <div class="row mt-2 mb-3 justify-content-left"> <span style="color: red">Fields marked as * are mandatory</span></div>
         <div class="panel panel-body">
             <div class="row mt-2 mb-2 justify-content-center">
                  
                 <div class="col-md-3 input-group">
                     <span style="color: red">*</span>
                    
                     <asp:DropDownList class="form-control" ID="ddl_ITda" AppendDataBoundItems="false" runat="server" AutoPostBack="true"></asp:DropDownList>
                 </div>

                 <div class="col-md-3 input-group">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_district" AppendDataBoundItems="false" runat="server" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>


                 <div class="col-md-3 input-group ">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_mandal" runat="server" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>

                 <div class="col-md-3 input-group ">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_village" runat="server" OnSelectedIndexChanged="ddl_village_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>
             </div>
         </div>


         <div class="panel panel-body">
             <div class="row mt-2 mb-2 justify-content-left">

                 <div class="col-md-3 input-group ">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_division" runat="server" OnSelectedIndexChanged="ddl_division_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>

                 <div class="col-md-3 input-group ">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_range" runat="server" OnSelectedIndexChanged="ddl_range_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>

                 <div class="col-md-3 input-group ">
                     <span style="color: red">*</span>
                     <asp:DropDownList class="form-control" ID="ddl_beat" runat="server" OnSelectedIndexChanged="ddl_beat_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                 </div>

             </div>
         </div>

     <div class="card mb-3 mt-3">
          <div class="card-header bg-info">
            <strong class="text-white">Forest Details</strong>
          </div>
          <div class="card-body">
            
            <div class="row form-group">
            <div class="col-md-3 input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_gp" runat="server"  class="form-control" placeholder="Grampanchayat"  autocomplete="off"  onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
              <div class="col-md-3 input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_gpcode" runat="server"  class="form-control" placeholder="Grampanchayat Code" autocomplete="off" onkeypress='codevalidate(event)'></asp:TextBox></div>
           <%-- <div class="col-md-3"><asp:TextBox ID="txt_village" runat="server"  class="form-control" placeholder="Village" autocomplete="off" onkeypress="validate(event)"></asp:TextBox></div>--%>
                 
                <div class="col-md-3"><span style="color:red"></span><asp:TextBox ID="txt_habitation_code" runat="server"  class="form-control" placeholder="Habitation Code" autocomplete="off"   onkeypress='codevalidate(event)'></asp:TextBox></div>
                 <%--<div class="col-md-3"><asp:TextBox ID="txt_villagecode" runat="server"  class="form-control" placeholder="Village Code" autocomplete="off" onkeypress="validatenumerics(event)"></asp:TextBox></div>--%>
             <div class="col-md-3"><span style="color:red"></span><asp:TextBox ID="txt_Habitation" runat="server"  class="form-control" placeholder="Habitation" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
           
            </div>
            
            <div class="row form-group">
                <%-- <div class="col-md-3"><asp:TextBox ID="txt_Habitation" runat="server"  class="form-control" placeholder="Habitation" autocomplete="off" onkeypress="validate(event)"></asp:TextBox></div>--%>
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_fblock" runat="server"  class="form-control" placeholder="Forest Block" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_compartment" runat="server"  class="form-control" placeholder="Compartment Number" autocomplete="off"  onkeypress='compartnovalidate(event)'></asp:TextBox></div>
            
            <div class="col-md-3 input-group"><span style="color:red"></span><asp:TextBox ID="txt_plot" runat="server"  class="form-control" placeholder="Plot Number" autocomplete="off" onkeypress='plotnovalidate(event)'></asp:TextBox ></div>

            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_plotarea" runat="server"  class="form-control" placeholder="Extent Plot Area" autocomplete="off" onkeypress="return isDecimalNumber(event,this);"  MaxLength="5"></asp:TextBox></div>
            
            </div>
            
            <div class="row form-group">
                
            
            <div class="col-md-3 input-group"><span style="color:red"></span><asp:TextBox ID="txt_uc_land" runat="server"  class="form-control" placeholder="Uncultivable Land" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            <div class="col-md-3 input-group"><span style="color:red"></span><asp:TextBox ID="txt_c_land" runat="server"  class="form-control" placeholder="Cultivable Land" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            
            <div class="col-md-3  input-group">
                 <span style="color:red">*</span> <asp:DropDownList ID="ddl_patta_inam" runat="server"  class="form-control"></asp:DropDownList>
                <%--<asp:TextBox ID="txt_patta_inam" runat="server"  class="form-control" placeholder="Patta Inam Govt" autocomplete="off" onkeypress="validate(event)"></asp:TextBox>--%></div>
            
           <div class="col-md-3 input-group"><asp:TextBox ID="txt_wtax" runat="server"  class="form-control" placeholder="Water Tax" autocomplete="off" ></asp:TextBox></div>
            
            
            </div>
            
            <div class="row form-group">
                 
            <div class="col-md-3 input-group"><span style="color:red"></span>
                <asp:DropDownList ID="ddl_dry_id" runat="server"  class="form-control"></asp:DropDownList>
                
                <%--<asp:TextBox ID="txt_dry_id" runat="server"  class="form-control" placeholder="Dry Id one crop two crop" autocomplete="off" onkeypress="validate(event)"></asp:TextBox>--%></div>
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_wsource" runat="server"  class="form-control" placeholder="Water Source" autocomplete="off" ></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_Eirrigated" runat="server"  class="form-control" placeholder="Extent Irrigated" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
        
          <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_patta_no" runat="server"  class="form-control" placeholder="ROFR Patta Number " autocomplete="off"  onkeypress='plotnovalidate(event)'></asp:TextBox></div>
                </div>
            
          <%--  <div class="row form-group">
                 <%-- <div class="col-md-3"><asp:TextBox ID="txt_patta_no" runat="server"  class="form-control" placeholder="ROFR Patta Number "></asp:TextBox></div>--%>
                <%-- <div class="col-md-3"><asp:TextBox ID="TextBox7" runat="server"  class="form-control" placeholder="" autocomplete="off"></asp:TextBox></div>
            <div class="col-md-3"><asp:TextBox ID="TextBox5" runat="server"  class="form-control" placeholder="" autocomplete="off"></asp:TextBox></div>
            <div class="col-md-3"><asp:TextBox ID="TextBox1" runat="server"  class="form-control" placeholder="" autocomplete="off"></asp:TextBox></div>
            
            <div class="col-md-3"><asp:TextBox ID="TextBox2" runat="server"  class="form-control" placeholder="" autocomplete="off"></asp:TextBox></div>
            
            
            
            </div>
        
          </div>
        </div>--%>
      <div class="card mb-3 mt-3">
          <div class="card-header bg-info">
            <strong class="text-white">Beneficiary Details</strong>
          </div>
          <div class="card-body">
            
            <div class="row form-group">
           <%-- <div class="col-md-3"><asp:TextBox ID="txt_patta_no" runat="server"  class="form-control" placeholder="ROFR Patta Number"></asp:TextBox></div>--%>
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_pattadar" runat="server"  class="form-control" placeholder="ROFR Pattadar" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox></div>
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_cname" runat="server"  class="form-control" placeholder="Cultivator Name" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_eu_cultivator" runat="server"  class="form-control" placeholder="Extent Under Cultivator" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_holding" runat="server"  class="form-control" placeholder="Holding Nature" autocomplete="off" onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
            
            </div>
            
            <div class="row form-group">
           
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_typecode" runat="server"  class="form-control" placeholder="Type Code" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_extent" runat="server"  class="form-control" placeholder="Extent" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_net_area" runat="server"  class="form-control" placeholder="Net Sown Area" autocomplete="off"  onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
              <div class="col-md-3  input-group"><span style="color:red"></span>
                   <asp:DropDownList ID="ddl_kharif" runat="server"  class="form-control"></asp:DropDownList>
                  
                  <%--<asp:TextBox ID="txt_kharif" runat="server"  class="form-control" placeholder="Kharif-Rabi" autocomplete="off" onkeypress="validate(event)">--%></asp:TextBox></div>
            </div>
            
            <div class="row form-group">
          
            
            <div class="col-md-3  input-group"><span style="color:red"></span>
                <asp:DropDownList ID="ddl_month" runat="server"  class="form-control"></asp:DropDownList>
                <%--<asp:TextBox ID="txt_month" runat="server"  class="form-control" placeholder="Month of Cultivation" autocomplete="off" onkeypress="validate(event)"></asp:TextBox>--%></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_crop" runat="server"  class="form-control" placeholder="Crop" autocomplete="off" ></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_single" runat="server"  class="form-control" placeholder="Single" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
             <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_mixed" runat="server"  class="form-control" placeholder="Mixed" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            </div>
            
            <div class="row form-group">
           
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_total" runat="server"  class="form-control" placeholder="Total" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_water" runat="server"  class="form-control" placeholder="Water Source1" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_firstcrop" runat="server"  class="form-control" placeholder="First Crop" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
              <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_secondcrop" runat="server"  class="form-control" placeholder="Second Third Crop" autocomplete="off" onkeypress="return isDecimalNumber(event,this);" MaxLength="5"></asp:TextBox></div>
            </div>
            
            <div class="row form-group">
            <%--<div class="col-md-3"><asp:TextBox ID="txt_patta_no" runat="server"  class="form-control" placeholder="ROFR Patta Number " autocomplete="off" onkeypress="validate(event)"></asp:TextBox></div>--%>
            
          <%-- <div class="col-md-3"><asp:TextBox ID="txt_aadhar" runat="server"  class="form-control" placeholder="Aadhaar Number" autocomplete="off" onkeypress="validate(event)"></asp:TextBox></div>--%>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_crop_yield" runat="server"  class="form-control" placeholder="Crop Yield" autocomplete="off" ></asp:TextBox></div>
            
            <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_vro" runat="server"  class="form-control" placeholder="VRO-RI Remarks" autocomplete="off"  onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
            
                
             <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_Thasildar" runat="server"  class="form-control" placeholder="Thasildar Remarks" autocomplete="off"  onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
             <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_remarks" runat="server"  class="form-control" placeholder="Remarks" autocomplete="off"  onkeypress='mastervalidatenumerics(event)'></asp:TextBox></div>
          
                  
            </div>
               <div class="row form-group">
            
            
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:DropDownList ID="ddl_land_class" runat="server"  class="form-control"></asp:DropDownList></div>
                   
                   <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_dlc_date" runat="server"  class="form-control" placeholder="Dlc Date" autocomplete="off" onkeypress='datevalidate(event)' MaxLength="10"></asp:TextBox></div>
                   <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_aadhar" runat="server"  class="form-control" placeholder="Aadhaar Number" autocomplete="off" onkeypress='codevalidate(event)' MaxLength="12"></asp:TextBox></div>
          
            </div>
                 <div class="row form-group">
                 
             
             <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_bank_name" runat="server"  class="form-control" placeholder="BankName" autocomplete="off" ></asp:TextBox></div>
          
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_bank_acnt" runat="server"  class="form-control" placeholder="Bank Account Number" autocomplete="off" ></asp:TextBox></div>
            
            <div class="col-md-3  input-group"> <span style="color:red">*</span><asp:TextBox ID="txt_ifsc_code" runat="server"  class="form-control" placeholder="Ifsc Code" autocomplete="off" ></asp:TextBox></div>
           <div class="col-md-3  input-group"><span style="color:red"></span><asp:TextBox ID="txt_father_name" runat="server"  class="form-control" placeholder="Father Name" autocomplete="off" ></asp:TextBox></div>
          
            </div>
            
          </div>
        </div>
       <div id="panlimage" runat="server" class="card mb-1 mt-1">
            <div class="card-header bg-info">
                <strong class="text-white">Upload Beneficiary Image & DLC</strong>
            </div>
            <div class="card-body">








                <div class="row">
                    <div class="col-md-1 text-right align-bottom"><strong class="text-info">Image :</strong></div>
                    <div class="col-md-1">
                        <div class="input-group-append">
                            <%--   <asp:Image ID="ImgUpload" ToolTip="Upload Employee Photo Here" runat="server" Height="200px"  Width="200px" />--%>
                            <div>
                                <img id="user_img" height="50px" width="50px" style="border: thick" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group mb-1">
                            <div class="custom-file">

                                <asp:TextBox ID="txt_image" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                                &nbsp&nbsp
    <input id="FileUpload" type="file" name="file" onchange="show(this)" runat="server" /><%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                            <div class="input-group-append">
                            </div>
                        </div>
                    </div>
                    &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp




                    <div class="col-md-1 pt-1 align-bottom"><strong class="text-info"> DLC :</strong></div>
                    <div class="col-md-1">
                        <div class="input-group mb-1">
                            <div class="custom-file">

                                <asp:TextBox ID="txt_dlc" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                                &nbsp&nbsp
    <%--  <input id="file_dlc" type="file" name="file" onchange="file(this)"  runat="server" />--%>
                                <asp:FileUpload ID="file_dlc" runat="server" /><%--<asp:Button ID="btn_dlc" runat="server" Text="Upload" OnClick="btn_dlc_Click"  OnClientClick="return validfile()"/>--%>
                            </div>
                            <div class="input-group-append">
                            </div>
                        </div>
                    </div>

                 <%--   <div class="col-md-1">
                        <asp:Button ID="btn_Image" OnClick="btn_Image_Click" CssClass="btn btn-success" runat="server" Text="UPLOAD FILES" ForeColor="White" />
                    </div>--%>






                </div>







            </div>
        </div>
              

     
    
              <br />
 <div class="row justify-content-center">
    
     <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="Submit_Click"  OnClientClick="return validation()"/>

  </div>
      </div>

      <%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>--%>
         <script src="../linksforcdns/Js/1.jquery.min.js"></script>

    <script>
        function validate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9]|\./;
            //var regex = /^[-+]?[0-9]+\.[0-9]+$/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function compartnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9&]|\,/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function plotnovalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9/]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

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

        function datevalidate(evt) {
            var theEvent = evt || window.event;

            // Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9/]|\-/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        function mastervalidatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z]|\A/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

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
            var regex = /[a-zA-Z0-9/]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function validatenumerics(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z/]|\./;
            if (test.indexOf('.') >= 0) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
           
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

    
    </script>
     <script>

  var count = 0;
  function isDecimalNumber(evt, c) {
      count = count + 1;
      var charCode = (evt.which) ? evt.which : event.keyCode;
      var dot1 = c.value.indexOf('.');
      var dot2 = c.value.lastIndexOf('.');
      if (count > 2 && dot1 == -1) {
          c.value = "";
          count = 0;
      }
      if (dot1 > 2) {
          c.value = "";
      }
      if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
          return false;
      else if (charCode == 46 && (dot1 == dot2) && dot1 != -1 && dot2 != -1)
          return false;

      return true;
  }
</script>
</asp:Content>
