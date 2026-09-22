<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ROFR.pages.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="logouttext" runat="server" ForeColor="Red" Visible="true" ></asp:Label>
          <ul><li><asp:LinkButton ID="Linklgn" runat="server" Font-Underline="true" ForeColor="Red" OnClick="Linklgn_Click">Click here to Login</asp:LinkButton></li></ul>
    </div>
    </form>
</body>
</html>
