<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="ROFR.pages.Change_Password" EnableEventValidation="false" %>
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
             $('#togglePassword').hover(function show() {
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
	/*border:1px solid #28a745;*/
margin-bottom:20px;
}

         i{
  cursor:pointer;
}
.form-group{position:relative;}
.form-group #togglePassword{
    position: absolute;
    right: 10px;
    bottom: 5px;
    margin: auto;
}


    i{
  cursor:pointer;
}
.form-group{position:relative;}
.form-group #togglePasswordnew{
    position: absolute;
    right: 10px;
    bottom: 5px;
    margin: auto;
}

    </style>
    <script>
        function pwdvalidation(event) {
            var keyCode = event.keyCode || event.which;



            //Regex for Valid Characters i.e. Alphabets and Numbers.
            var regex = /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])[a-zA-Z0-9!@#$%&*]+$/;

            //Validate TextBox value against the Regex.
            var isValid = regex.test(String.fromCharCode(keyCode));
            if (!isValid) {
                event.preventDefault();
                //alert("Only alpgabets and numbers allowed"); return;
                _n_plain_mes_1("<strong>Only alphabets and numbers allowed!</strong>", " ", "warning"); return;

            }

            return isValid;
        }
      
    </script>
    <script>  function checkPassword(event) {
      var reg = /^(?=.*\d)(?=.*[@#$&*_])(?=.*[a-z])(?=.*[A-Z]).{8,15}$/;
      //return re.test(str);
      if (reg.test(event.value)) {
          return true;

      }
      else {
          alert('Please enter valid Password. Password must contain alteast 8 and maximun 15 characters, one uppercase,one lowercase,one special character and one numeric ')
          event.value = "";
          return false;
      }
  }</script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:-10px;">
          <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">CHANGE PASSWORD</h5></div>
              <div class="col-md-4 text-right ">
                  
               <asp:LinkButton ID="btn_link" runat="server"  Font-Underline="true"  OnClick="link_click">Click here to Login</asp:LinkButton>
                   </div>
              </div>
       
        
          <div class="col-md-12 text-right" id="div_field" runat="server"><span style="color: red">Fields marked as * are mandatory</span></div>

                

        
        <div class="row mt-2 mb-2 border border-success bg-light">
            <div class="card-body">
                <div class="row giribhumi-custom-form justify-content-center">

                    <div class="col-md-4 col-12">
                          <div class="row mb-2">
                            <asp:Label ID="lbl_user" runat="server" CssClass="col-md-6 col-form-label" Text="Username:"><asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_username" runat="server" CssClass="col-md-6" autocomplete="off" ></asp:TextBox>
                        </div>

                        <div class=" form-group row mb-2">
                            <asp:Label ID="lbl_old" runat="server" CssClass="col-md-6 col-form-label" Text="Old Password:"><asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                            <div ng-app="Myapp" ng-controller="Mycontroller" class="col-md-6 px-0">
                            <asp:TextBox ID="txt_oldpwd" runat="server" CssClass="form-control" autocomplete="off"  TextMode="Password" ng-attr-type="{{showpassword ? 'text':'password'}}" ></asp:TextBox>
                                <i class="fa fa-eye-slash icon" id="togglePassword" ng-click="toggleshowpassword()"></i>
                             </div>
                        </div>

                        <div class="form-group row mb-2">
                            <asp:Label ID="lbl_new" runat="server" Text="New Password:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                             
                            <asp:TextBox ID="txt_newpwd" runat="server" CssClass="form-control col-md-6"  autocomplete="off" onchange="return checkPassword(this);" TextMode="Password"></asp:TextBox>
                                  
                        </div>
                       
                      

                        <div class="row mb-2">
                            <asp:Label ID="lbl_cnf" runat="server" Text="Confirm Password:" CssClass="col-md-6 col-form-label" ><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>

                            <asp:TextBox ID="txt_cnfpwd" runat="server" CssClass="col-md-6" autocomplete="off"  TextMode="Password"></asp:TextBox>
                        </div>

                      <div class="row mb-2 justify-content-center">
                         <span style="color: red">Note: Password should contain atleast<br /> 1) 8 characters<br /> 2) one special character<br /> (only these special characters @ # $ & * _ are allowed)<br />3) one Uppercase character<br /> 4) one Lowercase character<br /> 5) one Numeric</span>
                        </div>

                        

                    </div>


                   

                </div>
                <br />

                <div class="row mb-2 justify-content-center">
                           <asp:Button ID="btn_sumit" runat="server" Text="Submit" OnClick="btn_submit_Click"  />&nbsp &nbsp
               <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" />
                     </div>
                


            </div>
        </div>

        


        <div>
             
             
              
                

        </div>
          </div>
</asp:Content>
