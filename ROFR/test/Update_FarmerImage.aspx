<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="Update_FarmerImage.aspx.cs" Inherits="ROFR.test.Update_FarmerImage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
        function show(input) {
            debugger;
            var validExtensions = ['jpg', 'png', 'jpeg','JPG','JPEG','PNG']; //array of valid extensions
            var fileName = input.files[0].name;
            var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
                  
                        var FileSize = input.files[0].size / 1024 / 1024; // in MB
           
         
            if ($.inArray(fileNameExt, validExtensions) == -1) {
                input.type = ''
                input.type = 'file'
                $('#user_img').attr('src', "");
                alert("Only these image types are accepted : " + validExtensions.join(', '));
                return false;
            }
            else {
                if (input.files && input.files[0]) {
                 <%--  document.getElementById('<%=txt_image.ClientID %>').value =  '<%= Server.MapPath("~/Beneficairy Images/" +"/"+ DateTime.Now.ToString("dd-MM-yyy") )%> '+"/"+fileName;--%>
                    <%--document.getElementById('<%=txt_image.ClientID %>').value = "Beneficairy Images/"+fileName;--%>
                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {
                        $('#user_img').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
               
            }
            if (FileSize > 2) {
                alert('File size exceeds 2 MB');
                return false;
            }
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
     <%-- <style type="text/css">
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
                            <div class="panel panel-body" style="margin-top:3px;">

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                
                                
                                <div class="row justify-content-center">
                                    <div class="col-md-8">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Upload Farmer Image</h5>
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
                                                <button type="button" class="btn btn-light" value="Refresh" id="refresh" onclick="Captcha();"><i class="fa fa-refresh"></i></button>
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

                                 <div class="row mb-10">
                                            <div class="table-responsive">
                                              
                        
                                                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table table-bordered text-center ">  
                 
<Columns>   
                        
                                       <asp:TemplateField HeaderText="SNo." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"  Font-Bold="True" Text='<%# Container.DataItemIndex + 1 %>' runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>'  runat="server"  ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("Compartment_No") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl102"  Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         
          
                     <asp:TemplateField HeaderText="ROFR Pattadhar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Choose Image" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                     
                       
                 <div class="custom-file col-md-2">
                      <%--  <input id="FileUpload" type="file" name="file" onchange="show(this)" runat="server" />--%>
                     <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black" />
                           </div>
                       
                 
            </div>
                      </ItemTemplate>
        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Update" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                     
                  
                       <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("benficiary_id")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" >Update</asp:LinkButton>
                 
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Updated Image" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                    <asp:Image ID="Image1" runat="server"  ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' Width="50px" Height="50px"/>
                     <%--  <asp:Image ID="Image2" runat="server"  ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])(Eval("Image") == DBNull.Value ?"na": Eval("Image"))) %>' Width="30px" Height="30px"/>--%>
                     
                  
                      <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Black"></asp:Label>
                 
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="Image as in Aadhar" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                    <asp:Image ID="Image2" runat="server"  ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("AImage")) %>' Width="50px" Height="50px"/>
                     <%--  <asp:Image ID="Image2" runat="server"  ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])(Eval("Image") == DBNull.Value ?"na": Eval("Image"))) %>' Width="30px" Height="30px"/>--%>
                     
                  
                      <asp:Label ID="Label2" runat="server" Text="Label" Visible="false" ForeColor="Black"></asp:Label>
                 
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
