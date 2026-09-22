<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Grievance.aspx.cs" Inherits="ROFR.pages.Grievance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }

   
    .table th {
      text-align: center;
       background-color:#1f5c99 !important;
       }
  
  
    .bg-nav{
      background-color: #1F5C99 !important;
    }
   
  </style>

  <%--   <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #38a1d2;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>--%>

      <script>
        
     function ValidCaptcha() {

        var itda = document.getElementById('<%=ddl_itda.ClientID %>').value;
         var dist = document.getElementById('<%=ddl_dist.ClientID %>').value;
         var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
         var village = document.getElementById('<%=ddl_village.ClientID %>').value;
         var patta = document.getElementById('<%=ddl_patta.ClientID %>').value;
         var name = document.getElementById('<%=txtname.ClientID %>').value;
         var mobile = document.getElementById('<%=txtmobileno.ClientID %>').value;
         var aadhar = document.getElementById('<%=txtaadharno.ClientID %>').value;
         var address = document.getElementById('<%=txtadd.ClientID %>').value;
         var complaint = document.getElementById('<%=txtcomplaint.ClientID %>').value;
        if (itda== "0") {
            
            alert("Please Select Itda!");
            return false;
        }
        if (dist == "0") {

            alert("Please Select district");
            return false;
        }
        if (mandal == "0") {

            alert("Please Select Mandal");
            return false;
        }
        if (village == "0") {

            alert("Please Select Village");
            return false;
        }
        if (patta == "0") {

            alert("Please Select Patta No");
            return false;
        }
        if (name == "") {

            alert("Please Enter Name");
            return false;
        }
        if (mobile == "") {

            alert("Please Enter Mobile No");
            return false;
        }

        if (aadhar == "") {

            alert("Please Enter Aadhar No");
            return false;
        }

        if (address == "") {

            alert("Please Enter Address");
            return false;
        }
        if (complaint == "") {

            alert("Please Enter Complaint");
            return false;
        }
}


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
      
     <div class="container-fluid">
                <div class="row" style="margin-top:0px;">

                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                        <body>
                            <div class="panel panel-body" style="margin-top:150px;">

                  

                                
                                <div class="container">

                                
                                <div class="row justify-content-center">
                                    
                                    <div class="col-md-12 text-center">
                                       
                                               <h5 class="text-center text-white rounded py-1 bg-nav">Farmer Epassbook</h5>
                                      
                                    </div>
                                    <div class="col-md-6">
                                     

                        <div>
                       

                                        <div class="row mb-2">
                                            <div class="col-md-6 text-right">Name <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                                 <asp:TextBox ID="txtname" CssClass="form-control"  runat="server"></asp:TextBox>
                                              
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-6 text-right">Mobile No: <span style="color:Red;">*</span> : <span style="color:black;">+91</span> </div>
                                            <div class="col-md-5 text-left">
                                                 <asp:TextBox ID="txtmobileno" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-6 text-right">Aadhar No <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                                  <asp:TextBox ID="txtaadharno" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-6 text-right">Address <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                             <asp:TextBox ID="txtadd" CssClass="form-control" TextMode="MultiLine"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-6 text-right">  <asp:Label ID="txt_rbtn" runat="server" Text="Email"></asp:Label> : </div>
                                            <div class="col-md-5 text-left">
                                               <asp:TextBox ID="txtemail" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                              <div class="row mb-2">
                                            <div class="col-md-6 text-right">  <asp:Label ID="Label2" runat="server" Text="Complaint Name"></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                               <asp:TextBox ID="txtcomplaint" CssClass="form-control" TextMode="MultiLine"   runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                            </div>


                              

                                    
                                    </div>
                                    <div class="col-md-6">
                                     

                        <div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">ITDA <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                                <%--<div class="form-group">--%>
                                                     <asp:DropDownList ID="ddl_itda"   CssClass="form-control"   AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" ></asp:DropDownList> 
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">District <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                               <%-- <div class="form-group">--%>
                                                    <asp:DropDownList ID="ddl_dist"   CssClass="form-control"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" ></asp:DropDownList> 
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Mandal <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                               <%-- <div class="form-group">--%>
                                                      <asp:DropDownList ID="ddl_mandal"   CssClass="form-control"   runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"  ></asp:DropDownList> 
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Village <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                              <%--  <div class="form-group">--%>
                                                    <asp:DropDownList ID="ddl_village"  CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"  ></asp:DropDownList> 
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">  <asp:Label ID="Label1" runat="server" Text="Patta No."></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-5 text-left">
                                               <%-- <div class="form-group">--%>
                                <asp:DropDownList ID="ddl_patta" CssClass="form-control" runat="server" ></asp:DropDownList>
                                                <%--</div>--%>
                                            </div>
                                        </div>
                            </div>

                                    </div>
                                      <div class="col-md-12 text-center">
                                       

                                                <div class="form-group">
                                                   <asp:Button ID="Button1"  OnClick="Button1_Click"   OnClientClick="return ValidCaptcha() "    runat="server" Text="Submit" ForeColor="White"  BackColor="#003366"/>
                                                </div>

                                      
                                    </div>
                                     </div>
                                    </div>
                                 
                            </div>

                        </body>



                    </main>
                </div>
            </div>
        </div>



       

</asp:Content>