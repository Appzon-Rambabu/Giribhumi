<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ROFR.pages.Login"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../linksforcdns/Js/3.5.1.jquery.min.js"></script>

    <script src="../Loans/JS_Modules/angular.min.js"></script>
   
 

     <script>
         var app = angular.module('Myapp', []);
         app.controller('Mycontroller', function ($scope) {
             $scope.showpassword = false;

             $scope.toggleshowpassword = function () {
                 $scope.showpassword = !$scope.showpassword;
             }
         })
     </script>

    

    <script type="text/javascript">  
        $(document).ready(function () {
            $('#toggle_pwd').hover(function show() {
                //Change the attribute to text  
                $('#Txt_pwd').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Change the attribute back to password  
                    $('#Txt_pwd').attr('type', 'password');
                    $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });
            
        });
    </script>  

    <script>
     
   
    
     function ValidCaptcha() {

        var uname = document.getElementById('<%=Txt_username.ClientID %>').value;
        var pwd = document.getElementById('<%=Txt_pwd.ClientID %>').value;
            
        if (uname== "") {
            
            alert("Please Enter Username!");
            return false;
        }
        if (pwd == "") {

            alert("Please Enter Password");
            return false;
        }
        
        }




     </script>

  

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

    i{
  cursor:pointer;
}.form-group{position:relative;}
.form-group #toggle_pwd{
    position: absolute;
    right: 10px;
    bottom: 5px;
    margin: auto;
}
</style>

     <script type="text/javascript">
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
             
      <asp:Label ID="lab_text" runat="server"></asp:Label>                 

    <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 mb-4 mt-4 pt-4 login-form-cst">
        <div class="pl-5 pr-5 pt-2 pb-2 bg-white border-box" style="border: 2px solid #28a745;box-shadow: 0px 0px 35px -4px rgba(55, 184, 84, 1)">
            <h4 class="text-center text-success">User Login</h4><hr/>
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Username</strong></label>
               
                
                <asp:TextBox ID="Txt_username" runat="server" class="form-control h-auto" placeholder="Username" MaxLength="100" aria-label="Username" aria-describedby="username" autocomplete="off"> </asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Password</strong></label>
              <div ng-app="Myapp" ng-controller="Mycontroller">
                 <asp:TextBox ID="Txt_pwd" runat="server" class="form-control h-auto" ng-attr-type="{{showpassword ? 'text':'password'}}" placeholder="Password" aria-label="Password" aria-describedby="password" autocomplete="off" TextMode="Password" MaxLength="40"></asp:TextBox> 
                <i class="fa fa-eye-slash icon" id="toggle_pwd" ng-click="toggleshowpassword()"></i>
                  </div>
                <%--<i class="fas fa-eye-slash" id="toggle_pwd" ></i>--%>
                 
            </div>
      
          
          <div class="row  pr-3 pl-3 justify-content-center">
          <div style="height: 40px;">
          <div class="capt"> 
            <%--  <h2 type="text" id="mainCaptcha" class="text-center text-white" runat="server"></h2>--%>
                   <asp:Image ID="Image2" runat="server" Height="40px"  Width="186px" />

          </div>

          </div>
          <div class="col-md-2"> 
              <p>
              <button type="button" class="btn btn-light" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click" ><i class="fa fa-sync"></i></button>
              </p></div>
          </div>
          <div class="row">
              <asp:HiddenField ID = "HiddenField1" runat = "server" />
              
              <div class="col-md-12"><label class="text-dark pt-1 pb-1"><strong>Enter Captcha</strong></label>
                  <input type="text" id="txtInput" name="captcha" maxlength="5" class="form-control h-auto" autocomplete="off" runat="server" onkeypress='codevalidate(event)' ></div> </div>
         


                <div class="input-group mb-2 mt-2 justify-content-center">
             
          
       <a  href="Change_Password.aspx" style="text-decoration:underline" >Click here to Change Password</a>

          </div>
            <div class="input-group mb-2 mt-2 justify-content-center">

                <div class="mb-2 col-md-12 text-center">
             <asp:Label ID="loglbl" runat="server" CssClass="text-danger text-center font-weight-bold"></asp:Label>
                    </div>
          <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="btn_login_Click"  Text="Login" OnClientClick="return ValidCaptcha()"/>
       

          </div>
         
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
