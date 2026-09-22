<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="MissingData.aspx.cs" Inherits="ROFR.pages.MissingData"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 49px;}

     
    </style>

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
          
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
									  <asp:UpdateProgress ID="UPDATED" runat="server">
                                    <ProgressTemplate>
                                        <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner"></div>
                                   <span id="loading-msg">
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                
            <h5 class="text-center text-success mb-2 mt-3">Missing And Invalid Data Export to Excel</h5>
         <asp:UpdatePanel runat="server">
        <ContentTemplate>
           <div class="row justify-content-center">
               <div class="col-md-2">
                   <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                       <div class="col-md-6 text-center pl-0 pr-0">
                           <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                       </div>

                       <div class="col-md-6 pl-0 pr-0">
                           <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                       </div>
                   </div>
               </div>
               <div class="col-md-2">
                   <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                       <div class="col-md-4 text-center">
                           <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                       </div>

                       <div class="col-md-8">
                           <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"  OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" runat="server"></asp:DropDownList>
                       </div>
                   </div>
               </div>

                
           </div>

            <div class="row justify-content-center mt-3">
               <div class="col-md-12">
                   <div class="row d-flex justify-content-center mb-2">
                       <asp:Label ID="Label2"   runat="server" Text="Based on select option Data Will be Export to Excel ?" CssClass="col-md-4 text-success" />
                           </div>
                   <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                       
                       <asp:RadioButtonList ID="radioid" runat="server">
                             
                          <asp:ListItem Text="ALL Details Not Available(AadharNo,BankAccount,IfscCode)" Value="A" Selected="True" class="col-md-3"></asp:ListItem>
                               <asp:ListItem Text="BankAccount Not Available For Valid Aadhar Numbers " Value="B" class="col-md-3"></asp:ListItem>
                               <asp:ListItem Text="IfscCode Not Available For Valid BankAccount Numbers" Value="C" class="col-md-3"></asp:ListItem>
                               <asp:ListItem Text="Total Invalid Aadhars" Value="D" class="col-md-3"></asp:ListItem>
                               <asp:ListItem Text="Total Invalid BankAccounts" Value="E" class="col-md-3"></asp:ListItem>
                              <asp:ListItem Text="Total Invalid Ifsc Codes" Value="F" class="col-md-3"></asp:ListItem>
                           <asp:ListItem Text="Aadhars Numbers Not Available" Value="G" class="col-md-3"></asp:ListItem>
                           <asp:ListItem Text="Either Bank Account or Ifsc Code Not Available" Value="H" class="col-md-3"></asp:ListItem>
                           </asp:RadioButtonList>

                      
                   </div>
            </div>
        </div>
             </ContentTemplate>
        </asp:UpdatePanel>
            <div class="row justify-content-center mt-3">
                <asp:Button ID="btn_submit"  runat="server" CssClass="btn btn-success" AutoPostBack="true" OnClick="txtSearch_Click" Text="Data Export to Excel" />
            </div>
  </div>
           
</asp:Content>
