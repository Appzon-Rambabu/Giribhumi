<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Add_Beneficiary_Master.aspx.cs" Inherits="ROFR.pages.Add_Beneficiary_Master"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .required{
           color:red;
       }
       .dateofbirth{
           width:260px;
       }
   </style>
      <script type="text/javascript">
         
         function validation()
         {
             var Itda = document.getElementById('<%=ddl_ITda.ClientID %>').value;
             var district = document.getElementById('<%=ddl_district.ClientID %>').value;
             var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
             var village = document.getElementById('<%=ddl_village.ClientID %>').value;
             var habitation = document.getElementById('<%=ddl_Habitation.ClientID %>').value;
             var pattadhar = document.getElementById('<%=txt_pattadhar.ClientID %>').value;
               var father = document.getElementById('<%=txt_father.ClientID %>').value;
             var aadhar = document.getElementById('<%=txt_Adhar.ClientID %>').value;
             var dob = document.getElementById('<%=Apply.ClientID %>').value;
             var gender = document.getElementById('<%=ddl_gender.ClientID %>').value;
             var mobilenm = document.getElementById('<%=txt_mob.ClientID %>').value;
             var subcaste = document.getElementById('<%=ddl_Subcaste.ClientID%>').value;
             var caste = document.getElementById('<%=ddl_Caste.ClientID%>').value;
           <%--    var image = document.getElementById('<%=FileUpload.ClientID %>').value;
            
             var bankname = document.getElementById('<%=txt_bankname.ClientID%>').value;
             var bankacno = document.getElementById('<%=txt_bankaccount.ClientID%>').value;
             var ifsc = document.getElementById('<%=txt_ifsc.ClientID%>').value;--%>
        

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
             if (village == "0") {

                 alert("Please select Village!");
                 return false;
             }
             if (habitation == "0") {

                 alert("Please select Habitation!");
                 return false;
             }
             if (pattadhar == "") {

                 alert("Please enter pattadhar name!");
                 return false;
             }
             if (father == "") {

                 alert("Please enter Father name!");
                 return false;
             }
             if (aadhar == "") {

                 alert("Please enter aadhar number!");
                 return false;
             }
            
             //if (bankname == "") {
             //    alert("please Enter Bank Name!");
             //    return false;
             //}
             //if (bankacno == "") {
             //    alert("Please Enter Bank Account Number!");
             //    return false;
             //}
             //if (ifsc == "") {
             //    alert("please Enter IFSC Code!");
             //    return false;
             //}

             if (dob == "") {

                 alert("please select date of birth!");
                 return false;
             }
             if (subcaste == "" || subcaste=="0") {
                 alert("Please select SubCaste");
                 return false;
             }
             if (caste == "" || subcaste=="0") {
                 alert("Please select Caste");
                 return false;
             }

             if (gender == 0 || gender == "0") {

                 alert("Please select Gender!");
                 return false;
             }

             if (mobilenm.length > 0)
             {
                 if (mobilenm.length != 10) {
                     alert("please enter valid mobile number!");
                     return false;
                 }
                 else {


                 }
             }

             
             //if (image == "") {

             //    alert("Please choose image!");
             //    return false;
             //}

           
               
                
             
             } 
         
      </script>
   <%-- //code block beacuse start audit--%>
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
            } else if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                $('#user_img').attr('src', null);
                $("#ContentPlaceHolder1_FileUpload").val("");
                 document.getElementById('<%=txt_image.ClientID %>').value = "";
                fileName = "";
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                    document.getElementById('<%=txt_image.ClientID %>').value = "Beneficairy Images/"+fileName;
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
           
        }
        </script>
    <%--  //code block beacuse close audit--%>
    <script>
        var mask;
        function text()
        {
       mask = document.getElementById('<%=txt_Adhar.ClientID %>').value;
     document.getElementById('<%=HiddenField1.ClientID %>').value = mask;

        if (mask.length < 12 ||(mask.length>=13&& mask.length<16))
        {
            alert("Please enter 12  digit aadhaar number");
             document.getElementById('<%=txt_Adhar.ClientID %>').value = "";
            return false;
        }
        else if (mask.length == 12) {
            var enteredadhar = mask;
            var status = validateVerhoeff(enteredadhar);
            if (!status)
            {
                if (status == "0") {
                    alert("Please enter a valid Aadhar Number");
                    document.getElementById('<%=txt_Adhar.ClientID %>').value = "";
                }
                return status;
            }
            document.getElementById('<%=txt_Adhar.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxx');
                
            }
        else if (mask.length > 12 && mask.length == 16) {
             var enterdadhar = mask;
            var status = validateVerhoeff(enterdadhar);
            if (!status)
            {
                if (status == "0") {
                    alert("Please enter a valid Aadhar Number");
                    document.getElementById('<%=txt_Adhar.ClientID %>').value = "";
                }
                return status;
            }
                document.getElementById('<%=txt_Adhar.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxxxxxx');
                
            }
            return mask;
        }
    </script>

    <style>
        .giribhumi-custom-form input{
            height:25px !important;
        }
        .giribhumi-custom-form .col-form-label{
            padding-top: 2px !important;
            padding-bottom: 2px !important;
        }
        .panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}

    </style>


     <%-- For Mobile Number--%>
    <script>
        function IsMobile(mobile) {
            var reg = /^[6-9][0-9]{9}$/;
            if (mobile == "1111111111" || mobile == "2222222222" || mobile == "3333333333" || mobile == "4444444444" || mobile == "5555555555" || mobile == "6666666666" || mobile == "7777777777" | mobile == "8888888888" || mobile == "9999999999") {

                return false;
            }
            if (reg.test(mobile)) {
                if (mobile.length == 10) {
                    return true;
                }

                else {

                    return false;
                }
            }
            else {

                return false;
            }
        }
    </script>

    <script>
        var mob;
        function Mobile() {
            mob = document.getElementById('<%=txt_mob.ClientID %>').value;
            document.getElementById('<%=HiddenField2.ClientID %>').value = mob;
            if (mob.length == "" || mob.length < 10) {
                alert("Please Enter Mobile Number and minimum or maximum 10 numbers");
                document.getElementById('<%=txt_mob.ClientID %>').value = "";
    return false;
}
else if(mob.length==10)
{
	var enterMobile=mob;
  var status = IsMobile(enterMobile);
	if(!status)
    {
       if(status == "0")
        {
          alert("Please enter a valid Mobile Number");
          document.getElementById('<%=txt_mob.ClientID %>').value = "";
        }
         return status;
        }
      
        }
   return mob;
   }
    </script>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                 
    <div class="container-fluid">
                <div class="row" style="margin-top:0px;">
                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">
                        <body>

                             

     <div class="panel panel-body">
          <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
									  <asp:UpdateProgress ID="UPDATED" runat="server">
                                <ProgressTemplate>
                                        <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner">
                                          
                                     </div>
                                   
                                   <span id="loading-msg">
                                       
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                 </ProgressTemplate>
         </asp:UpdateProgress>--%>
        <h5 class="text-center text-success mb-4 mt-3">ADD FARMER</h5>
         
         
         <div>
        <div class="row mb-2">
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 pl-0 pr-0">
                      
                    <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                         </div>
                   
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-3 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-3 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true"  OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                    <div class="col-md-3 text-center">
                        <asp:Label ID="Label22" runat="server" Text="Panchayat:"></asp:Label>&nbsp<asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddl_panchayat" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_panchayatSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            
          
            
            <br />
        <br />
    </div> 
<div class="row mb-2">
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-4 text-center pl-0 pr-0">
                        <asp:Label ID="Label24" runat="server" Text="Revenue Village:"></asp:Label>&nbsp<asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-5 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Rv" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_RvSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-3 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true"  OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged " runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="habiataion" runat="server">
                    <div class="col-md-3 text-center">
                        <asp:Label ID="txt_Habitation" runat="server" Text="Habitation:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <asp:DropDownList ID="ddl_Habitation" Style="width: 100%" AutoPostBack="true"  OnSelectedIndexChanged="ddlHabitation_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
         </div>
     </div>
                        
          <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                    
        <div class="card row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                <div class="row giribhumi-custom-form">

                    <div class="col-md-4 col-12">
                        <div class="row mb-2">
                            <asp:Label ID="lbl_pattadhar" runat="server" CssClass="col-md-6 col-form-label" Text="Pattadhar Name:"><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_pattadhar" runat="server" CssClass="col-md-6" autocomplete="off"  onkeypress='pattadarnamevalidate(event)'  onchange="return validtext(this)"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_father" runat="server" Text="Father Name:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_father" runat="server" CssClass="col-md-6" autocomplete="off"  onkeypress='pattadarnamevalidate(event)'  onchange="return validtext(this)"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_Adhar" runat="server" Text="Aadhar Number:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                             <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:TextBox ID="txt_Adhar" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'  MaxLength="12" onchange="return text()"></asp:TextBox>
                           <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Underline="true">Check</asp:LinkButton>--%>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_bankname" runat="server" Text="Bank Name:" CssClass="col-md-6 col-form-label" >
                                <%--<asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>

                            <asp:TextBox ID="txt_bankname" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_account" runat="server" Text="Bank Account Number:" CssClass="col-md-6 col-form-label" >
                                <%--<asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>

                            <asp:TextBox ID="txt_bankaccount" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_ifsc" runat="server" Text="IFSC Code:" CssClass="col-md-6 col-form-label" >
                                <%--<asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>

                            <asp:TextBox ID="txt_ifsc" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='Accountnovalidate(event)'></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                   
                            <asp:Label ID="Label12" runat="server" Text="Date of Birth:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="Apply" runat="server"  type="date" CssClass="dateofbirth" placeholder="MM/DD/YYYY"></asp:TextBox>
                              
                         <asp:RangeValidator id="rngDate" ControlToValidate="Apply"
                                             Type="Date" minimumvalue="01/01/1880"
                                             MaximumValue="01/01/1987" 
                                             ErrorMessage="Your Not Eligibil !You must be 18 years old or above "
                                             
                                             Display="Dynamic" runat="server" CssClass="required"></asp:RangeValidator>
                    
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="Label13" runat="server" Text="Gender:" CssClass="col-md-6 col-form-label"><asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>


                           <asp:DropDownList ID="ddl_gender" runat="server" CssClass="col-md-6" autocomplete="off" OnSelectedIndexChanged="ddl_gender_SelectedIndexChanged">
                                   <asp:ListItem Value=" ">--Select Gender--</asp:ListItem>
                                         <asp:ListItem Value="M">Male</asp:ListItem>
                                         <asp:ListItem Value="F">Female</asp:ListItem>
                                       
                           </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-4 col-12">
                          <div class="row mb-2">
						   <div class="col-md-6">
                            <asp:Label ID="Label16" runat="server" Text="Caste:" CssClass="col-form-label"></asp:Label>&nbsp<span class="text-danger">*</span>
							</div>
                              <asp:DropDownList ID="ddl_Caste" OnSelectedIndexChanged="ddl_Caste_SelectedIndexChanged" Style="width: 100%" AutoPostBack="true" CssClass="col-md-6" runat="server"></asp:DropDownList>
                            <%--<asp:TextBox ID="txt_cst" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>--%>
                        </div>
                        <div class="row mb-2">
						<div class="col-md-6">
                            <asp:Label ID="lbl_subcaste" runat="server" Text="Sub Caste:" CssClass="col-form-label" ></asp:Label>&nbsp<span class="text-danger">*</span>
							</div>
                            <asp:DropDownList ID="ddl_Subcaste" Style="width: 100%" AutoPostBack="true" CssClass="col-md-6" runat="server"></asp:DropDownList>
                            <%--<asp:TextBox ID="txt_subcaste" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox>--%>
                        </div>
                         
                        <div class="row mb-2">
                            <asp:Label ID="lbl_poname" runat="server" Text="Post Office Name:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_poname" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='pattadarnamevalidate(event)'></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_poaccount" runat="server" Text="Post Office Account Number:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_poaccount" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl" runat="server" Text="Post Box Number:" CssClass="col-md-6 col-form-label"></asp:Label>

                            <asp:TextBox ID="txt_po_number" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'></asp:TextBox>
                        </div>
                       


                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload Beneficiary Image:" CssClass="col-md-6 col-form-label"><%--<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>
                            <asp:TextBox ID="txt_image" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-2">
                                    <input id="FileUpload" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>


                        <div class="row mb-2">
                            <asp:Label ID="Label14" runat="server" Text="Mobile Number:" CssClass="col-md-6 col-form-label" ></asp:Label>
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:TextBox ID="txt_mob" runat="server" CssClass="col-md-6" MaxLength="10" autocomplete="off" onkeypress='onlynumbers(event)' onchange="return Mobile()"></asp:TextBox>
                        </div>

                          <div class="row mb-2">
                            <asp:Label ID="Label15" runat="server" Text="Home Address:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="Txt_address" runat="server" CssClass="col-md-6"  autocomplete="off"></asp:TextBox>
                        </div>

                        
                    </div>

                    <div class="col-md-4 col-12">
                         <div class="row mb-2">
                            
                            <div class="col-md-12"><img id="user_img" height="90" width="90" style="border: thick;"/></div>
                            
                        </div>
                    </div>

                    <div class="col-md-4 col-12">
                      
                    </div>
                    
                </div>

               
                <div class="row mb-2 justify-content-center">
                            <asp:Button ID="btn_sumit" runat="server" Text="Submit"  OnClick="btn_submit_Click"  OnClientClick="return  validation()"/>&nbsp &nbsp
               <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" />
                     </div>
            </div>
              
           
        </div>
         
        <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
          </div>
          </body>
                    </main>
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

            for (var i = 0; i < myArray.length ; i++) {
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
    
            if (str == 'script'||str == 'alert')
            {
        
          
                alert('Enter valid format');
                event.value = "";
            }
           
            else {
                return false;
            }
  
        }
    </script>

   
       
    
<%--    <script src="../linksforcdns/Js/3.3.1.jquery.min.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</asp:Content>
 