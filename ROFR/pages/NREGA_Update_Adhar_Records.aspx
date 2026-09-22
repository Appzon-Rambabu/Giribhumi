<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="NREGA_Update_Adhar_Records.aspx.cs" Inherits="ROFR.pages.NREGA_Update_Adhar_Records" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList class="form-control" ID="ddl_ITda" runat="server" AutoPostBack="true"></asp:DropDownList>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="Submit_Click"  OnClientClick="return validation()"/>
    <asp:Label ID="Label12" runat="server" Text="No of records" ForeColor="Black" ></asp:Label>
    <asp:Label ID="noofrec" runat="server" ForeColor="Red" ></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="No of records update" ForeColor="Black" ></asp:Label>
    <asp:Label ID="noofupdate" runat="server" ForeColor="Red" ></asp:Label>
    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="Update_Click"  />
    

</asp:Content>