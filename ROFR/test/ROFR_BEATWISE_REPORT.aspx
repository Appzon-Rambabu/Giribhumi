<%@ Page Title="FOREST BEAT WISE BENIFICIARY DETAILS" Language="C#" MasterPageFile="~/Masters/HOME.Master" AutoEventWireup="true" CodeBehind="ROFR_BEATWISE_REPORT.aspx.cs" Inherits="ROFR.test.ROFR_BEATWISE_REPORT"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
    function Validate() {
        var Division = document.getElementById('<%=ddl_FD.ClientID %>').value;
        var Range = document.getElementById('<%=ddl_FR.ClientID %>').value;
        var Beat = document.getElementById('<%=ddl_FB.ClientID %>').value;
       
       
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
       
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body" style="margin-top:150px;"> 

    <div class="row">
        <div class="col-md-4">
            
        </div><div class="col-md-4">

            <div class="table-responsive">


            <table class="table">
  <thead>
    <tr>
      <h5 class="text-center text-success">FOREST BEAT WISE BENEFICIARY DETAILS</h5>
    </tr>
  </thead>
  <tbody>

       <tr>
      
      <td> <asp:Label ID="txt_FOREST_Divison"  runat="server" Text="Forest Divison:"></asp:Label>&nbsp<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
      <td><asp:DropDownList ID="ddl_FD"  style="width:150px" AutoPostBack="true" OnSelectedIndexChanged="ddlFD_OnSelectedIndexChanged" runat="server"></asp:DropDownList>  </td>
    </tr>
    <tr>
      
      <td><asp:Label ID="txt_FOREST_Range" runat="server"  Text="Forest Range:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
      <td><asp:DropDownList ID="ddl_FR" runat="server" style="width:150px"  AutoPostBack="true" OnSelectedIndexChanged="ddlFR_OnSelectedIndexChanged"></asp:DropDownList>  
            </td>
    </tr>
    <tr>
      
      <td><asp:Label ID="txt_FOREST_Beat" runat="server"  Text="Forest Beat:"></asp:Label>&nbsp<asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
      <td><asp:DropDownList ID="ddl_FB" runat="server" style="width:150px" AutoPostBack="true" ></asp:DropDownList>  
            </td>
    </tr>
    <tr>
     <td class="text-center">&nbsp;</td>
      <td ><asp:Button ID="btn_submit" OnClick="btnsend_Click" OnClientClick=" return Validate()" runat="server" Text="Submit" /></td>
      
    </tr>
  </tbody>
</table>
      
        </div>
        </div>

        <div class="col-md-4">
            
        </div>
        

       

    </div>


     </div>
</asp:Content>
