<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_Popup.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ROFR.pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="LATEST"></asp:Repeater>
<asp:SqlDataSource ID="LATEST" runat="server" ConnectionString="<%$ ConnectionStrings:LATESTNEWROFRConnectionString %>" SelectCommand="SELECT * FROM [BENEFICIARY_DETAILS]"></asp:SqlDataSource>
</asp:Content>

