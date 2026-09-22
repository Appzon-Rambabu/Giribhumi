
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Adangal.master" AutoEventWireup="true" CodeBehind="GramaAdangal.aspx.cs" Inherits="ROFR.pages.GramaAdangal"  EnableEventValidation="false"%>

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
     <script>
     //     function Captcha(){
     //    var alpha = new Array('0','1','2','3','4','5','6','7','8','9'
 	 //   	);
     //var i;
     //for (i=0;i<6;i++){
     //    var a = alpha[Math.floor(Math.random() * alpha.length)];
     //    var b = alpha[Math.floor(Math.random() * alpha.length)];
     //    var c = alpha[Math.floor(Math.random() * alpha.length)];
     //    var d = alpha[Math.floor(Math.random() * alpha.length)];
     //    var e = alpha[Math.floor(Math.random() * alpha.length)];
        
     //                 }
     //    var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e ;
     //    document.getElementById("mainCaptcha").innerHTML = code
	 //    document.getElementById("mainCaptcha").value = code
     //  }
     function ValidCaptcha() {

        var itda = document.getElementById('<%=ddl_itda.ClientID %>').value;
         var dist = document.getElementById('<%=ddl_dist.ClientID %>').value;
         var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
         var village = document.getElementById('<%=ddl_village.ClientID %>').value;

             //var captcha = document.getElementById('txtInput').value;
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
        //if (captcha == "")
        //{

        //    alert("Please Enter Captcha");
        //    return false;
        //}
        //if (captcha != "") {


        //    var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
        //    var string2 = removeSpaces(document.getElementById('txtInput').value);
        //    if (string1 == string2) {
        //        return true;
        //    }


        //    else {

        //        alert("enter valid captcha");

        //        return false;
        //    }
        //}
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
       background-color:#00bcd4 !important;
       }
  
  
  
    .bg-nav{
      background-color: #008500 !important;
    }
   
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
                <div class="row" style="margin-top:0px;">

                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                        <body>
                            <div class="panel panel-body">

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                
                                
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
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
                                                    <div >
                                                     <%-- <h2 type="text" id="mainCaptcha" class="text-center text-white" runat="server"> </h2>--%>
                                                        <asp:Image ID="Image2" runat="server" Height="40px"  Width="186px" />
                                                    </div>
                                               <%-- </div>--%>
                                            </div>
                                            <div class="col-md-2">
                                                <%--<button type="button" class="btn btn-light" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click"><i class="fa fa-refresh"></i></button>--%>
                                                 <p>
                                             <button type="button" class="btn btn-light" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click" ><i class="fa fa-sync"></i></button>
                                             </p>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Enter Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                                 <input type="text" id="txtInput" name="captcha" maxlength="5" class="form-control" autocomplete="off" runat="server" onkeypress="codevalidate(event)" />
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right"></div>
                                            <div class="col-md-4 text-left">
                                                <div class="form-group">
                                                   <asp:Button ID="Button1" OnClientClick="return ValidCaptcha() " runat="server" Text="Submit" OnClick="Button1_Click"  />
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

     <script>
         function codevalidate(evt) {
             var theEvent = evt || window.event;

             // Handle paste
             if (theEvent.type === 'paste') {
                 key = event.clipboardData.getData('text/plain');
             } else {
                 // Handle key press
                 var key = theEvent.keyCode || theEvent.which;
                 key = String.fromCharCode(key);
             }
             var regex = /[0-9]|\0/;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) theEvent.preventDefault();

             }
         }
     </script>
</asp:Content>
