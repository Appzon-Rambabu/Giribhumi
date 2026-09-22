<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Home.Master" AutoEventWireup="true" CodeBehind="Epass_book.aspx.cs" Inherits="ROFR.test.Epass_book"  EnableEventValidation="false" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }

   
    .table th {
      text-align: center;
       background-color:#007405 !important;
       }
  
  
    .bg-nav{
      background-color: #007405 !important;
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
          function Captcha(){
         var alpha = new Array('0','1','2','3','4','5','6','7','8','9'
	 	
 	    	);
     var i;
     for (i=0;i<6;i++){
         var a = alpha[Math.floor(Math.random() * alpha.length)];
         var b = alpha[Math.floor(Math.random() * alpha.length)];
         var c = alpha[Math.floor(Math.random() * alpha.length)];
         var d = alpha[Math.floor(Math.random() * alpha.length)];
         var e = alpha[Math.floor(Math.random() * alpha.length)];
        
                      }
         var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e ;
         document.getElementById("mainCaptcha").innerHTML = code
		 document.getElementById("mainCaptcha").value = code
       }
     function ValidCaptcha() {

        var itda = document.getElementById('<%=ddl_itda.ClientID %>').value;
         var dist = document.getElementById('<%=ddl_dist.ClientID %>').value;
         var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
         var village = document.getElementById('<%=ddl_village.ClientID %>').value;

             var captcha = document.getElementById('txtInput').value;
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
        if (captcha == "")
        {

            alert("Please Enter Captcha");
            return false;
        }
        if (captcha != "") {


            var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
            var string2 = removeSpaces(document.getElementById('txtInput').value);
            if (string1 == string2) {
                return true;
            }


            else {

                alert("enter valid captcha");

                return false;
            }
        }
}
function removeSpaces(string){
     return string.split(' ').join('');
}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-area">
    <div class="container-fluid">
                <div class="row" style="margin-top:0px;">

                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                        <body onload="Captcha();">
                            <div class="panel panel-body" style="margin-top:1px;">

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                               
                               
                                <div class="row justify-content-center">
                                    <div class="col-md-8">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Farmer Epassbook</h5>
                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                                        <div class="row mb-1">
                                            <div class="col-md-4 text-right">Select Option : </div>
                                            <div class="col-md-8">
                                               <asp:RadioButtonList ID="rbtn_list"    runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtn_list_SelectedIndexChanged1">
     <%--     <asp:ListItem Selected="True" Value="A">Compartment No.&nbsp</asp:ListItem>--%>
         <%-- <asp:ListItem Value="B">Patta No.&nbsp&nbsp</asp:ListItem>--%>
          <asp:ListItem Value="C" Selected="True">Aadhar&nbsp</asp:ListItem>
          <asp:ListItem Value="D">Pattadar Name</asp:ListItem>
          </asp:RadioButtonList>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">ITDA <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                                     <asp:DropDownList ID="ddl_itda"   CssClass="form-control"   AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">District <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                    <asp:DropDownList ID="ddl_dist"   CssClass="form-control"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"></asp:DropDownList>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Mandal <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                      <asp:DropDownList ID="ddl_mandal"   CssClass="form-control"   runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" ></asp:DropDownList>
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Village <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                              <%--  <div class="form-group">--%>
                                                    <asp:DropDownList ID="ddl_village"  CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" ></asp:DropDownList>
                                               <%-- </div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">  <asp:Label ID="txt_rbtn" runat="server" Text="Aadhar"></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                  <asp:TextBox ID="txt_rbtn_list" CssClass="form-control"  runat="server"></asp:TextBox>
                                <asp:DropDownList ID="ddl_pattadhar" CssClass="form-control" runat="server" Visible="false"></asp:DropDownList>
                                                <%--</div>--%>
                                            </div>
                                        </div>
                            </div>
                             </ContentTemplate>

                         </asp:UpdatePanel>
                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                              <%--  <div class="form-group">--%>
                                                    <div class=" bg-secondary text-white text-center" style="letter-spacing:normal;font-size: 1rem; ">
                                                      <h2 type="text" id="mainCaptcha" class="text-center text-white"> </h2>
                                                    </div>
                                               <%-- </div>--%>
                                            </div>
                                            <div class="col-md-1 text-left">
                                                <button type="button" class="btn btn-light" value="Refresh" id="refresh" onclick="Captcha();"><i class="fa fa-sync"></i></button>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Enter Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                                 <input type="text" id="txtInput" name="captcha" class="form-control" autocomplete="off" />
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right"></div>
                                            <div class="col-md-4 text-left">
                                                <div class="form-group">
                                                   <asp:Button ID="Button1"     OnClientClick="return ValidCaptcha() " runat="server" Text="Submit" OnClick="Button1_Click"  />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="table-responsive">
                                                <%--<table class="table table-bordered">--%>
                       
                                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table  table-bordered text-center  "  >  
                   
                                                                                 <Columns>  

                                       <asp:TemplateField HeaderText="ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                     
                    <asp:Label ID="lbl1" ForeColor="Black" Text='<%# Eval("benficiary_id") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                 
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Eval("Compartment_No") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                           
               <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                     
                    <asp:Label ID="lbl10" ForeColor="Black" Text='<%# Eval("ROFR_PATTANO") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         
         
                     <asp:TemplateField HeaderText="ROFR Pattadhar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                     
                  <asp:Label ID="lbl2"  ForeColor="Black" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl3" ForeColor="Black" Text='<%# Eval("Father_Name") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("benficiary_id")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" >View</asp:LinkButton>
                 
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                       
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>
                                                <%--</table>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row justify-content-center">
                                    <div class="col-md-12">
                                        <div class="table-responsive">

                                        </div>
                                    </div>
                                </div>


                            </div>

                        </body>



                    </main>
                </div>
            </div>
            </div>
    <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
   
    <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>





       

</asp:Content>
