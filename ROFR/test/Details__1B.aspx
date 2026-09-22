<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Home.Master" AutoEventWireup="true" CodeBehind="Details__1B.aspx.cs" Inherits="ROFR.test.Details__1B" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
        <div class="container-fluid">
            <div class="row" style="margin-top: 0px;">

                <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                    <body onload="Captcha();">
                        <div class="panel panel-body" style="margin-top: 2px;">

                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



                            <div class="row justify-content-center">
                                <div class="col-md-8">
                                    <h5 class="text-center text-white rounded py-1 bg-nav">MEE 1B NAMUNA</h5>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <div class="row mb-1">
                                                    <div class="col-md-4 text-right">Select Option : </div>
                                                    <div class="col-md-8">
                                                        <asp:RadioButtonList ID="rbtn_list" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtn_list_SelectedIndexChanged1">
                                                            <asp:ListItem Selected="True" Value="A">Compartment No.&nbsp</asp:ListItem>
                                                            <%-- <asp:ListItem Value="B">Patta No.&nbsp&nbsp</asp:ListItem>--%>
                                                            <asp:ListItem Value="C">Aadhar&nbsp</asp:ListItem>
                                                            <asp:ListItem Value="D">Pattadar Name</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>

                                                <div class="row mb-2">
                                                    <div class="col-md-4 text-right">ITDA <span style="color: Red;">*</span> : </div>
                                                    <div class="col-md-4 text-left">
                                                        <%--<div class="form-group">--%>
                                                        <asp:DropDownList ID="ddl_itda" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
                                                        <%-- </div>--%>
                                                    </div>
                                                </div>

                                                <div class="row mb-2">
                                                    <div class="col-md-4 text-right">District <span style="color: Red;">*</span> : </div>
                                                    <div class="col-md-4 text-left">
                                                        <%-- <div class="form-group">--%>
                                                        <asp:DropDownList ID="ddl_dist" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged"></asp:DropDownList>
                                                        <%-- </div>--%>
                                                    </div>
                                                </div>

                                                <div class="row mb-2">
                                                    <div class="col-md-4 text-right">Mandal <span style="color: Red;">*</span> : </div>
                                                    <div class="col-md-4 text-left">
                                                        <%-- <div class="form-group">--%>
                                                        <asp:DropDownList ID="ddl_mandal" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
                                                        <%--</div>--%>
                                                    </div>
                                                </div>

                                                <div class="row mb-2">
                                                    <div class="col-md-4 text-right">Village <span style="color: Red;">*</span> : </div>
                                                    <div class="col-md-4 text-left">
                                                        <%--  <div class="form-group">--%>
                                                        <asp:DropDownList ID="ddl_village" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"></asp:DropDownList>
                                                        <%-- </div>--%>
                                                    </div>
                                                </div>

                                                <div class="row mb-2">
                                                    <div class="col-md-4 text-right">
                                                        <asp:Label ID="txt_rbtn" runat="server" Text="Compartment No."></asp:Label><span style="color: Red;">*</span> : </div>
                                                    <div class="col-md-4 text-left">
                                                        <%-- <div class="form-group">--%>
                                                        <asp:TextBox ID="txt_rbtn_list" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:DropDownList ID="ddl_pattadhar" CssClass="form-control" runat="server" Visible="false"></asp:DropDownList>
                                                        <%--</div>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                    <div class="row mb-2">
                                        <div class="col-md-4 text-right">Captcha <span style="color: Red;">*</span> : </div>
                                        <div class="col-md-4 text-left">
                                            <%--  <div class="form-group">--%>
                                            <div class=" bg-secondary text-white text-center" style="letter-spacing: normal; font-size: 1rem;">
                                                <h2 type="text" id="mainCaptcha" class="text-center text-white"></h2>
                                            </div>
                                            <%-- </div>--%>
                                        </div>
                                        <div class="col-md-1 text-left">
                                            <button type="button" class="btn btn-light" value="Refresh" id="refresh" onclick="Captcha();"><i class="fa fa-sync"></i></button>
                                        </div>
                                    </div>

                                    <div class="row mb-2">
                                        <div class="col-md-4 text-right">Enter Captcha <span style="color: Red;">*</span> : </div>
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
                                                <asp:Button ID="Button1" OnClientClick="return ValidCaptcha() " runat="server" Text="Submit" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row mb-2">
                                        <div class="table-responsive">


                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-center ">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">

                                                        <ItemTemplate>
                                                            <div style="text-align: center">
                                                                <asp:Label Class="txt" ID="lbl0" runat="server" ForeColor="Black" Text='<%# Eval("Compartment_No") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">

                                                        <ItemTemplate>
                                                            <div style="text-align: center">

                                                                <asp:Label ID="lbl1" ForeColor="Black" Text='<%# Eval("Rofr_Pattano") %>' runat="server" />
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ROFR Pattadhar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
                                                        <ItemTemplate>
                                                            <div style="text-align: left">
                                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Rofr_Pattadaar")+","+ "1"%>' CausesValidation="false" OnClick="link_onclick"><%# Eval("Rofr_Pattadaar") %></asp:LinkButton>
                                                                <asp:Label ID="lbl2" ForeColor="Black" Text='<%# Eval("Rofr_Pattadaar") %>' runat="server" Visible="false" />
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
                                                        <ItemTemplate>
                                                            <div style="text-align: left">
                                                                <asp:Label ID="lbl3" ForeColor="Black" Text='<%# Eval("Father_Name") %>' runat="server" />
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
</asp:Content>
