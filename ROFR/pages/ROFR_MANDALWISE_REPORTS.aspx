<%@ Page Title="ROFR MANDAL WISE BENIFICIARIES REPORT" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="ROFR_MANDALWISE_REPORTS.aspx.cs" Inherits="ROFR.pages.ROFR_MANDALWISE_REPORTS" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function Validate() {
        var district = document.getElementById('<%=ddl_district.ClientID %>').value;
        var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
       
        if (district== "0") {
            
            alert("Please select District!");
            return false;
        }
        if (mandal == "0") {

            alert("Please select Mandal!");
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
      <h6 class="text-center text-success">ROFR MANDAL WISE BENEFICIARIES REPORT</h6>
    </tr>
  </thead>
  <tbody>
    <tr>
        
      <td><asp:Label ID="txt_district"  runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
      <td><asp:DropDownList ID="ddl_district" style="width:150px"  AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"  runat="server"></asp:DropDownList>
            </td>
    </tr>
       <tr>
      
      <td> <asp:Label ID="txt_mandal"  runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label></td>
      <td><asp:DropDownList ID="ddl_mandal"  style="width:150px" AutoPostBack="false"  runat="server"></asp:DropDownList>  </td>
    </tr>
    
    <tr>
        <td class="text-center">&nbsp;</td>
      <td ><asp:Button ID="btn_submit" OnClick="btnsend_Click"  runat="server" OnClientClick="return Validate()" Text="Submit"   /></td>
      
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
