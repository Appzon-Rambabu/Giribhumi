<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="GramaAdangal.aspx.cs" Inherits="ROFR.test.GramaAdangal"  EnableEventValidation="false"%>
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
                <div class="row" style="margin-top:0px;">

                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                        <body onload="Captcha();">
                            <div class="panel panel-body" style="margin-top:1px;">

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                
                                
                                <div class="row justify-content-center">
                                    <div class="col-md-8">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">GRAMA ADANGAL</h5>
                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                                       

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

                                     
                            </div>
                             </ContentTemplate>

                         </asp:UpdatePanel>
                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                              <%--  <div class="form-group">--%>
                                                    <div class=" bg-secondary text-white py-1 text-center" style="letter-spacing:normal;font-size: 1rem; ">
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
