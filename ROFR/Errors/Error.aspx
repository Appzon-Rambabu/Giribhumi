<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ROFR.Errors.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script type="text/javascript" language="javascript">
        function disableBackButton() {
            window.history.forward()
        }
        disableBackButton(); dis();
        window.onload = disableBackButton();
        window.onpageshow = function (evt) {
            if (evt.persisted) disableBackButton()
        }
        window.onunload = function () {
            void (0)
        }
        function dis() {
            window.history.pushState(null, "", window.location.href);
            window.onpopstate = function () {
                window.history.pushState(null, "", window.location.href);
            };
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>An Error has occured</h2>
        <p>An unexpected error occured in website.Please contact admin or login again</p>
        <ul><li><asp:LinkButton ID="Linklgn" runat="server" Font-Underline="true" ForeColor="Red" OnClick="Linklgn_Click">Click here to Login</asp:LinkButton></li></ul>
    </div>
    </form>
    
</body>
</html>
