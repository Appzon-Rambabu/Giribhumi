<%@ Page Title="MEE GIRI BHOOMI BENIFICIARY DETAILS" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="Mee_Giri_Bhoomi.aspx.cs" Inherits="ROFR.pages.Mee_Giri_Bhoomi" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
    function Validate() {
        var Division = document.getElementById('<%=ddl_FD.ClientID %>').value;
        var Range = document.getElementById('<%=ddl_FR.ClientID %>').value;
        var Beat = document.getElementById('<%=ddl_FB.ClientID %>').value;
        var Option = document.getElementById('<%=txt_rbtn_list.ClientID %>').value;
       
       
        if (Division == "0") {

            alert("Please select Forest Division!");
            return false;
        }
        if (Range == "0") {

            alert("Please select Forest Range!");
            return false;
        }

        if (Beat == "0") {

            alert("Please select Forest Beat!");
            return false;
        }

        if (Option == " ") {

            alert("Please Enter Selected Option Value!");
            return false;
        }
       
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body"  style="margin-top:150px;"> 

    <div class="row">
        <div class="container">

            <div class="">

                
                <table width="60%" align="center" style="border-spacing: 5px; border-collapse: separate;">
                        <tbody><tr class="formtitle">
                            <td colspan="2" align="center" style="border-radius: 5px;">
                               <h5 class="text-center text-success">MEE GIRI BHOOMI BENEFICIARY DETAILS</h5>
                            </td>
                        </tr>
                        <tr>
                            <td class="lblunitel">
                                <asp:Label ID="txt_select" runat="server"  Text="Select Option"></asp:Label> : 
                            </td>
                            <td align="left" class="controlunitel">
                                <asp:RadioButtonList ID="rbtn_list"    runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtn_list_SelectedIndexChanged"  AutoPostBack="true">
          <asp:ListItem Selected="True">Compartment Number&nbsp&nbsp</asp:ListItem>
         <%-- <asp:ListItem>Plot No.&nbsp&nbsp</asp:ListItem>--%>
        <%--  <asp:ListItem>Aadhaar Number&nbsp&nbsp</asp:ListItem>--%>
          <asp:ListItem>Pattadar Number</asp:ListItem>
          </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="lblunitel">
                              <asp:Label ID="txtfd"  runat="server" Text="Forest Divison:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" class="controlunitel">
                                
	<asp:DropDownList ID="ddl_FD"    style="width:150px"  AutoPostBack="true" OnSelectedIndexChanged="ddlFD_OnSelectedIndexChanged" runat="server"></asp:DropDownList> 

                            </td>
                        </tr>
                        <tr>
                            <td class="lblunitel">
                               <asp:Label ID="txtfr" runat="server"  Text="Forest Range:"></asp:Label>&nbsp<asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" class="controlunitel">
                                <asp:DropDownList ID="ddl_FR"  style="width:150px"  runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlFR_OnSelectedIndexChanged"></asp:DropDownList>  
                            </td>
                        </tr>
                        <tr>
                            <td class="lblunitel">
                              <asp:Label ID="txtfb" runat="server"  Text="Forest Beat:"></asp:Label>&nbsp<asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" class="controlunitel">
                              <asp:DropDownList ID="ddl_FB"  style="width:150px" runat="server" AutoPostBack="true" ></asp:DropDownList>   
                            </td>
                        </tr>
                        <tr>
                            <td class="lblunitel">
                               <asp:Label ID="txt_rbtn" runat="server" Text="Label"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" class="controlunitel">
                               <asp:TextBox ID="txt_rbtn_list" style="width:150px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                              
                            </td>
                            <td align="left" class="controlunitel">
                              <asp:Button ID="Button1" OnClick="btnsend_Click" Text="Submit"   OnClientClick=" return Validate()" runat="server" />
                            </td>
                        </tr>
                       
                      
                     
                    </tbody></table>






          
      
        </div>
        </div>

       
            
        </div>
        

       

    


     </div>
</asp:Content>
