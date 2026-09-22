<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="LandPhasesReport.aspx.cs" Inherits="ROFR.pages.LandPhasesReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #1F5C99;}

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
    
      <div class="panel panel-body" style="margin-top:160px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
           
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">BENEFICIARY  PHASESWISE LAND ABSTRACT REPORT</h5></div>
              <div class="col-md-4 text-right ">
                 
              <%-- <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>--%>
                   </div>
             
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                  
                    <%--<div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_village_excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_village_excel_Click" runat="server" Text="EXCEL"  Visible="false"/>
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_upload_Click" runat="server" Text="EXCEL"  Visible="false"/>
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_img_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_notupload_Click" runat="server" Text="EXCEL" Visible="false"/>
                    </div>--%>
                </div>


           </div>
        </div>
          <br />
            <div class="row justify-content-center">
               
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server">
                         <asp:ListItem  Value="1">Benficiarywise Phases Data</asp:ListItem>
                                                   <asp:ListItem  Value="2">PHASE-I</asp:ListItem>
                                                   <asp:ListItem  Value="3">PHASE-II</asp:ListItem>
                                                   <asp:ListItem  Value="4">Benificaries covered in PHASE-I & PHASE-II</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div>
                       <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true">linkbutton</asp:LinkButton>
                                 
                    </div>
              
           </div>
              

      
        </div>
           </div>
              </div>
</asp:Content>
