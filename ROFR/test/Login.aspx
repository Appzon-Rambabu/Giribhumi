<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ROFR.test.Login"  EnableEventValidation="false"%>
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
    <script>
        <%--   function Validuser() {
        var uname = document.getElementById('<%=Txt_username.ClientID %>').value;
        var pwd = document.getElementById('<%=Txt_pwd.ClientID %>').value;
             var captcha = document.getElementById('txtInput').value;
        if (uname== "") {
            
            alert("Please Enter Username!");
            return false;
        }
        if (pwd == "") {

            alert("Please Enter Password");
            return false;
        }
        if (captcha == "") {

           alert("Please Enter Captcha!");
           return false;
             }
       
        ValidCaptcha();
    }--%>

     //function Captcha(){
     //    var alpha = new Array('0','1','2','3','4','5','6','7','8','9'
	 
 	 //   	);
     //var i;
     //for (i=0;i<6;i++){
     //    var a = alpha[Math.floor(Math.random() * alpha.length)];
     //    var b = alpha[Math.floor(Math.random() * alpha.length)];
     //    var c = alpha[Math.floor(Math.random() * alpha.length)];
     //    var d = alpha[Math.floor(Math.random() * alpha.length)];
     //    var e = alpha[Math.floor(Math.random() * alpha.length)];
        
     //                 }
     //    var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e ;
     //    document.getElementById("mainCaptcha").innerHTML = code
	 //    document.getElementById("mainCaptcha").value = code
     //  }
     function ValidCaptcha() {

        var uname = document.getElementById('<%=Txt_username.ClientID %>').value;
        var pwd = document.getElementById('<%=Txt_pwd.ClientID %>').value;
         var captcha = document.getElementById( '<%=txtInput.ClientID %>').value;
        
        if (uname== "") {
            
            alert("Please Enter Username!");
            return false;
        }
        if (pwd == "") {

            alert("Please Enter Password");
            return false;
        }
        if (captcha == "")
        {

            alert("Please Enter Captcha");
            return false;
        }
        if (captcha != "") {


            var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
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


//$(window).load(function () {
   
//    Captcha();
        //});
</script>

   <%--  <style>
        .capt{
	background-color:blue;
	width: 300px;
	height:100px;
	
}

#mainCaptcha{
	position: relative;
	left : 60px;
	top: 5px;
	
}

#refresh{
	position:relative;
	left:230px;
	width:30px;
	height:30px;
	bottom:45px;
	background-image: url(rpt.jpg);
}

#txtInput, #Button1{
	position: relative;
	left:40px;
	bottom: 40px;
}
  
      </style>--%>

<style>
.login-form-cst .border-box{
    border-radius:20px 0px 20px 0px !important;
    }
.login-form-cst .form-control{
    padding:0px 10px;
    border-color:#209d3c;
    }
    .login-form-cst .btn-light {
    color: #000;
    background-color: #c6c6c6;
    border-color: #8f8f8f;}
</style>

     <script type="text/javascript" language="javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row mt-2 mb-2 justify-content-center">


    <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 mb-4 mt-4 pt-4 login-form-cst">
        <div class="pl-5 pr-5 pt-2 pb-2 bg-white border-box" style="border: 2px solid #28a745;box-shadow: 0px 0px 35px -4px rgba(55, 184, 84, 1)">
            <h4 class="text-center text-success">User Login</h4><hr/>
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Username</strong></label>
               <%-- <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="username" autocomplete="off">--%>
                <asp:TextBox ID="Txt_username" runat="server" class="form-control h-auto" placeholder="Username" aria-label="Username" aria-describedby="username" autocomplete="off"> </asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Password</strong></label>
               <%-- <input type="password" class="form-control" placeholder="Password" aria-label="Password" aria-describedby="password" autocomplete="off">--%>
                 <asp:TextBox ID="Txt_pwd" runat="server" class="form-control h-auto" placeholder="Password" aria-label="Password" aria-describedby="password" autocomplete="off" TextMode="Password" MaxLength="40"> </asp:TextBox>
            </div>
            <body onload="Captcha();"  >
          
          <div class="row  pr-3 pl-3 justify-content-center">
          <div class="col-md-8 border bg-info" style="height: 40px;">
          <div class="capt"> 
              <h2 type="text" id="mainCaptcha" class="text-center text-white" "><span id="mcaptcha" runat="server"></span></h2>
              <%--   <asp:TextBox ID="txt_captcha" runat="server" class="form-control"  aria-label="Captcha" aria-describedby="Captcha" autocomplete="off"></asp:TextBox>--%>

          </div>

          </div>
          <div class="col-md-2"> <p><button type="button" class="btn btn-light" value="Refresh" id="refresh" onclick="Captcha();"><i class="fa fa-refresh"></i></button></p></div>
          </div>
          <div class="row">
              
              <div class="col-md-12"><label class="text-dark pt-1 pb-1">Enter Captcha</label><input type="text" id="txtInput" name="captcha" class="form-control h-auto" autocomplete="off" ></div> </div>
          </body>
            <div class="input-group mb-2 mt-2 justify-content-center">
             
          <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="btn_login_Click"  Text="Login" OnClientClick="return ValidCaptcha() "  />
            </div>
         <%--   <asp:Label ID="txt_lbl" runat="server" Text="Label"></asp:Label>--%>

          </div>
         
    </div>


   

    </div>

</asp:Content>
