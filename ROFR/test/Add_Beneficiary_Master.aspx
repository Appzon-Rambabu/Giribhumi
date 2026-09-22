<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="Add_Beneficiary_Master.aspx.cs" Inherits="ROFR.test.Add_Beneficiary_Master"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
      <script type="text/javascript">
         
         function validation()
         {
             var Itda = document.getElementById('<%=ddl_ITda.ClientID %>').value;
             var district = document.getElementById('<%=ddl_district.ClientID %>').value;
             var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
             var village = document.getElementById('<%=ddl_village.ClientID %>').value;
            
         var habitation = document.getElementById('<%=ddl_Habitation.ClientID %>').value;
            
           var pattadhar = document.getElementById('<%=txt_pattadhar.ClientID %>').value;
             var aadhar = document.getElementById('<%=txt_Adhar.ClientID %>').value;
           <%--    var image = document.getElementById('<%=FileUpload.ClientID %>').value;
            --%>
                
        

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
             if (aadhar == "") {

                 alert("Please enter aadhar number!");
                 return false;
             }
             //if (image == "") {

             //    alert("Please choose image!");
             //    return false;
             //}

           
               
                
             
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
        var mask;
        function text()
        {
       mask = document.getElementById('<%=txt_Adhar.ClientID %>').value;
     document.getElementById('<%=HiddenField1.ClientID %>').value = mask;

        if (mask.length < 12 ||(mask.length>=13&& mask.length<16))
        {
            alert("Please enter either 12 or 16 digit aadhaar number");
            return false;
        }
        else if (mask.length == 12) {

            document.getElementById('<%=txt_Adhar.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxx');
                
            }
            else if (mask.length > 12 && mask.length==16) {
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
        /*.panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}*/

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="content-area">
     <div class="panel panel-body" style="margin-top:2px;">


        <h5 class="text-center text-success mb-4 mt-3">ADD FARMER</h5>

        <div class="row mb-2">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                      
                    <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                         </div>
                   
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="habiataion" runat="server">
                    <div class="col-md-5 text-center">
                        <asp:Label ID="txt_Habitation" runat="server" Text="Habitation:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-7">
                        <asp:DropDownList ID="ddl_Habitation" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitation_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>


  
            <br />
            <br />



              
       
       
       
        <br />
    </div> 
          <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                

        
        <div class="card row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                <div class="row giribhumi-custom-form">

                    <div class="col-md-4 col-12">
                        <div class="row mb-2">
                            <asp:Label ID="lbl_pattadhar" runat="server" CssClass="col-md-6 col-form-label" Text="Pattadhar Name:"><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_pattadhar" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_father" runat="server" Text="Father Name:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_father" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_Adhar" runat="server" Text="Aadhar Number:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                             <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:TextBox ID="txt_Adhar" runat="server" CssClass="col-md-6" autocomplete="off" onkeypress='codevalidate(event)'  MaxLength="16" onchange="return text()"></asp:TextBox>
                           <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Underline="true">Check</asp:LinkButton>--%>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_bankname" runat="server" Text="Bank Name:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_bankname" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_account" runat="server" Text="Bank Account Number:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_bankaccount" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_ifsc" runat="server" Text="IFSC Code:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_ifsc" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        

                    </div>


                    <div class="col-md-4 col-12">
                        
                        <div class="row mb-2">
                            <asp:Label ID="lbl_subcaste" runat="server" Text="Sub Caste:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_subcaste" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>
                        <div class="row mb-2">
                            <asp:Label ID="lbl_poname" runat="server" Text="Post Office Name:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_poname" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl_poaccount" runat="server" Text="Post Office Account Number:" CssClass="col-md-6 col-form-label" ></asp:Label>

                            <asp:TextBox ID="txt_poaccount" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                        <div class="row mb-2">
                            <asp:Label ID="lbl" runat="server" Text="Post Box Number:" CssClass="col-md-6 col-form-label"></asp:Label>

                            <asp:TextBox ID="txt_po_number" runat="server" CssClass="col-md-6" autocomplete="off"></asp:TextBox>
                        </div>

                       

                        <div class="row mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Upload Beneficiary Image:" CssClass="col-md-6 col-form-label"><%--<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>--%></asp:Label>
                            <asp:TextBox ID="txt_image" runat="server" autocomplete="off" ReadOnly="True" CssClass="col-md-4"></asp:TextBox>
                                    
                            <div class="custom-file col-md-2">
                                    <input id="FileUpload" type="file" name="file" onchange="show(this)" runat="server" />
                                    <%--<asp:Button ID="btn_image" runat="server" Text="Upload" OnClick="btn_image_Click"  AutoPostBack="true" />--%>
                            </div>
                           

                        </div>

                        
                    </div>
                    
                    <div class="col-md-4 col-12">
                         <div class="row mb-2">
                            
                            <div class="col-md-12"><img id="user_img" height="90" width="90" style="border: thick;" /></div>
                            
                        </div>
                    </div>

                </div>


                <div class="row mb-2 justify-content-center">
                            <asp:Button ID="btn_sumit" runat="server" Text="Submit"  OnClick="btn_submit_Click"  OnClientClick="return  validation()"/>&nbsp &nbsp
               <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" />
                     </div>
                


            </div>
        </div>

        


        <div>
             
             
              
                

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
</asp:Content>
