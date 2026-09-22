<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Dup_ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Dup_Login.aspx.cs" Inherits="ROFR.pages.Dup_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</style>

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2 mb-2 justify-content-center">
             
      <asp:Label ID="lab_text" runat="server"></asp:Label>                 

    <div class="col-md-4 col-lg-4 col-xl-4 col-sm-12 mb-4 mt-4 pt-4 login-form-cst">
        <div class="pl-5 pr-5 pt-2 pb-2 bg-white border-box" style="border: 2px solid #28a745;box-shadow: 0px 0px 35px -4px rgba(55, 184, 84, 1)">
            <h4 class="text-center text-success">User Login</h4><hr/>
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Username</strong></label>
               
                
                <asp:TextBox ID="Txt_username" runat="server" class="form-control h-auto" placeholder="Username" aria-label="Username" aria-describedby="username" autocomplete="off"> </asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="basic-url"><strong> Password</strong></label>
              
                 <asp:TextBox ID="Txt_pwd" runat="server" class="form-control h-auto" placeholder="Password" aria-label="Password" aria-describedby="password" autocomplete="off" TextMode="Password" MaxLength="40"> </asp:TextBox>
            </div>
      
          
          <div class="row  pr-3 pl-3 justify-content-center">
          <div style="height: 40px;">
          <div class="capt"> 
                   <asp:Image ID="Image2" runat="server" Height="40px"  Width="186px" />

          </div>

          </div>
          <div class="col-md-2"> <p><button type="button" class="btn btn-light" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click" ><i class="fa fa-refresh"></i></button></p></div>
          </div>
          <div class="row">
              
              <div class="col-md-12"><label class="text-dark pt-1 pb-1"><strong>Enter Captcha</strong></label><input type="text" id="txtInput" name="captcha" class="form-control h-auto" autocomplete="off" runat="server"/></div> </div>
         
                <div class="input-group mb-2 mt-2 justify-content-center">
          
       <a  href="Change_Password.aspx" style="text-decoration:underline" >Click here to Change Password</a>

          </div>
            <div class="input-group mb-2 mt-2 justify-content-center">

                <div class="mb-2 col-md-12 text-center">
             <asp:Label ID="loglbl" runat="server" CssClass="text-danger text-center font-weight-bold"></asp:Label>
                    </div>
          <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="btn_login_Click"  Text="Login" /><%--OnClientClick="return ValidCaptcha()"--%>
       

          </div>
         
    </div>
    </div>
    </div>
</asp:Content>
