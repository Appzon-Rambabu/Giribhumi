<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Phase1_Data.aspx.cs" Inherits="ROFR.pages.Phase1_Data"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="panel panel-body"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
               
         <div class="row mb-1 mt-1 justify-content-end">
              
               <div class="col-md-4 "> <asp:LinkButton ID="LinkButton1" runat="server"  ForeColor="Red"  Font-Underline="true"  OnClick="Phase1_Download">Download Phase1 Data</asp:LinkButton><br /><br />

                    <asp:LinkButton ID="btn_back_entered" runat="server"  Font-Underline="true" ForeColor="Red" OnClick="Phase2_Download">Download Phase2 Data</asp:LinkButton>
               </div>
              <div class="col-md-4"> </div>
             <div class="col-md-4"> </div>
             
        </div>
         
            
     
    
        </div>
</asp:Content>
