<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="Login_Statuspage.aspx.cs" Inherits="ROFR.pages.Login_Statuspage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:TextBox ID="Txt_username" runat="server" class="form-control h-auto" placeholder="Username" aria-label="Username" aria-describedby="username" autocomplete="off" OnTextChanged="Txt_username_TextChanged" AutoPostBack="True"></asp:TextBox>
            </div>
     </div>
          <div class="input-group mb-2 mt-2 justify-content-center">

                <div class="mb-2 col-md-12 text-center">
             <asp:Label ID="loglbl" runat="server" CssClass="text-danger text-center font-weight-bold"></asp:Label>
                    </div>
          <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="btn_login_Click"   Text="Logout" />
       

          </div>
         
    </div>
    </div>
</asp:Content>
