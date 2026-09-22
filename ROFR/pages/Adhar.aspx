<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Adhar.aspx.cs" Inherits="ROFR.pages.Adhar" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body"  style="margin-top:150px;">

    <asp:Label ID="Label1" runat="server" Text="Enter Aadhar"></asp:Label>
    <asp:TextBox ID="txt_adhar" runat="server"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="Button"  OnClick="btn_submit_click"/>
    <div id="div_display" runat="server">
    <asp:Label ID="lbl_display" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lbl_test" runat="server" Text="Label"></asp:Label>
        </div>
          </div>
</asp:Content>
