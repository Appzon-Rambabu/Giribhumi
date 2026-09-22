<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sqlquerywindow.aspx.cs" Inherits="ROFR.Sqlquerywindow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblsqlw" runat="server" Text="SQL Query Window" ForeColor="#003399"></asp:Label>
    </div>
    <div>
        <textarea id="txtquery" cols="400" rows="10" runat="server"></textarea>
    </div>
    <div>
        <asp:Button ID="btnExecuteQuery" runat="server" Text="Execute" OnClick="btnExecuteQuery_Click" />
    </div>
        <div>
        <asp:Label ID="lblreason" runat="server"  ForeColor="Red"></asp:Label>
    </div> 
     <div>
        <asp:Label ID="lblresult" runat="server" Text="Result :" ForeColor="#003399"></asp:Label>
    </div>
         <div>
        <asp:Button ID="btn_submit"  runat="server" CssClass="btn btn-success" AutoPostBack="true" OnClick="txtSearch_Click" Text="Data Export to Excel" />
 </div>
    <div>
       <asp:GridView ID="dgvresult" runat="server" AutoGenerateColumns="true" Visible="true"></asp:GridView>
    </div>
    </form>
</body>
</html>
