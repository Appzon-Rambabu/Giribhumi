<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nerga.aspx.cs" Inherits="ROFR.Nerga" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         
         function validation()
         {
             var Itda = document.getElementById('<%=ddl_ITda.ClientID %>').value;
             if (Itda == "0")
             {

                 alert("Please select Itda Name!");
                 return false;
             }
         } 
         
     </script>
</head>
<body>
    <form id="form1" runat="server">
     <div>
    <asp:TextBox ID="txtid" runat="server" ></asp:TextBox>  
    <asp:DropDownList class="form-control" ID="ddl_ITda" runat="server" AutoPostBack="true"></asp:DropDownList>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="Submit_Click"  OnClientClick="return validation()"/>
    <asp:Label ID="Label12" runat="server" Text="No of records" ForeColor="Black" ></asp:Label>
    <asp:Label ID="noofrec" runat="server" ForeColor="Red" ></asp:Label>

    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="Update_Click"  />
    

    </div>
    </form>
</body>
</html>
