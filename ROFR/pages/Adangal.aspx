<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Adangal.master" AutoEventWireup="true" CodeBehind="Adangal.aspx.cs" Inherits="ROFR.pages.Adangal"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Rofrnewassets/css/bootstrap.css" rel="stylesheet" />
    <link href="../Rofrnewassets/css/style.css" rel="stylesheet" />
    <link href="../Rofrnewassets/css/all.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../datepicker/css/bootstrap-datetimepicker.min.css" />
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
    
     function ValidCaptcha() {

        var itda = document.getElementById('<%=ddl_itda.ClientID %>').value;
         var dist = document.getElementById('<%=ddl_dist.ClientID %>').value;
         var mandal = document.getElementById('<%=ddl_mandal.ClientID %>').value;
         var village = document.getElementById('<%=ddl_village.ClientID %>').value;
         var aadhar = document.getElementById('<%=txt_rbtn_list.ClientID%>').value;
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
         if (aadhar == "0") {

             alert("Please enter aadhar number!");
             return false;
         }
    }
     function removeSpaces(string){
     return string.split(' ').join('');
}

       </script>

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

     <script>
         var mask;
         function text() {
             mask = document.getElementById('<%=txt_rbtn_list.ClientID %>').value;
             document.getElementById('<%=HiddenField1.ClientID %>').value = mask;

          <%--  if (mask.length < 12 || (mask.length >= 13 && mask.length < 16)) {
                alert("Please enter either 12 or 16 digit aadhaar number");
                document.getElementById('<%=txt_rbtn_list.ClientID %>').value = "";
            return false;
        }--%>
             if (mask.length == 12) {
                 var enteredadhar = mask;
                 var status = validateVerhoeff(enteredadhar);
                 if (!status) {
                     if (status == "0") {
                         alert("Please enter a valid Aadhar Number");
                         document.getElementById('<%=txt_rbtn_list.ClientID %>').value = "";
                 }
                 return status;
             }
             document.getElementById('<%=txt_rbtn_list.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxx');
                
         }

         else if (mask.length > 12) {
             alert("Please enter a valid Aadhaar Number");
             document.getElementById('<%=txt_rbtn_list.ClientID %>').value = "";
             return;
         }
         else if (mask.length > 12 && mask.length == 16) {
             var enterdadhar = mask;
             var status = validateVerhoeff(enterdadhar);
             if (!status) {
                 if (status == "0") {
                     alert("Please enter a valid Aadhaar Number");
                     document.getElementById('<%=txt_rbtn_list.ClientID %>').value = "";
                 }
                 return status;
             }
             document.getElementById('<%=txt_rbtn_list.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxxxxxx');

             }
             return mask;
         }
     </script>

    <script>
        function validatesplkeyPress(el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;

            if (charCode >= 31 && charCode <= 37) {
                return false;
            }
            if (charCode >= 39 && charCode <= 43) {
                return false;
            }
            if (charCode == 46) {
                return false;
            }
            if (charCode >= 58 && charCode <= 64) {
                return false;
            }
            if (charCode >= 91 && charCode <= 96) {
                return false;
            }
            if (charCode >= 123 && charCode <= 255) {
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
       background-color:#008500 !important;
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
                        <body onload="Captcha();">
                            <div class="panel panel-body">

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <div class="row justify-content-center">
                                    <div class="col-md-5">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">MEE ADANGAL</h5>
                                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                                        <div class="row mb-1">
                                            <div class="col-md-4 text-right">Select Option : </div>
                                            <div class="col-md-8">
                                  <asp:RadioButtonList ID="rbtn_list"    runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtn_list_SelectedIndexChanged1">
          <asp:ListItem Selected="True" Value="A">Compartment No.&nbsp</asp:ListItem>
         <%-- <asp:ListItem Value="B">Patta No.&nbsp&nbsp</asp:ListItem>--%>
          <asp:ListItem Value="C">Aadhaar&nbsp</asp:ListItem>
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
                                            <div class="col-md-4 text-right">  
                                                <asp:Label ID="txt_rbtn" runat="server" Text="Compartment No.">
                                               </asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                               <asp:TextBox ID="txt_rbtn_list" CssClass="form-control"  runat="server"  onkeypress='codevalidate(event)' onchange="return text()"></asp:TextBox>
                                            <asp:DropDownList ID="ddl_pattadhar" CssClass="form-control"  runat="server" Visible="false"></asp:DropDownList>
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
                                                    <%--  <h2 type="text" id="mainCaptcha" class="text-center text-white" runat="server"> </h2>--%>
                                                         <asp:Image ID="Image2" runat="server" Height="40px"  Width="186px" />
                                                    </div>
                                               <%-- </div>--%>
                                            </div>
                                            <div class="col-md-2">
                                                <%--<button type="button" class="btn btn-success" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click">
                                                    <i class="fa fa-refresh"></i></button>--%>
                                               <p>
                                             <button type="button" class="btn btn-light" value="Refresh" id="refresh" runat="server" onserverclick="Submit_Click" ><i class="fa fa-sync"></i></button>
                                             </p>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">Enter Captcha <span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                <%--<div class="form-group">--%>
                                                 <input type="text" id="txtInput" name="captcha" maxlength="5" class="form-control" onkeypress="codevalidate(event)" autocomplete="off" runat="server" />
                                                <%--</div>--%>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right"></div>
                                            <div class="col-md-4 text-left">
                                                <div class="form-group">
                                                   <asp:Button ID="Button2" OnClientClick="return ValidCaptcha() " runat="server"  Text="Submit" OnClick="Button1_Click"  />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row mb-2">
                                            <div class="table-responsive">
                                              
                        
                                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table table-bordered text-center ">  
                    <Columns>   
                                       <asp:TemplateField HeaderText="S.No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"  ForeColor="Black" Text='<%# Container.DataItemIndex + 1 %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl10"  ForeColor="Black" Text='<%# Eval("Rofr_Pattano") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("Compartment_No")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("Compartment_No") %></asp:LinkButton>
              <asp:Label Class="txt"  ID="lbl0" runat="server" ForeColor="Black" Text='<%# Eval("Compartment_No") %>' Visible="false"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                             
          
                     <asp:TemplateField HeaderText="ROFR Pattadhar Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                     <%-- <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("Compartment_No")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick1" ><%# Eval("Rofr_Pattadaar") %></asp:LinkButton>--%>
                  <asp:Label ID="lbl2"  ForeColor="Black" Text='<%# Eval("Rofr_Pattadaar") %>' runat="server" Visible="true" />
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
    <script>

        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff(num) {
            //  alert("funcall" + num);
            if (num == "333333333333" || num == "777777777777") {
                return 0;
            }
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
                return true;

            }
            else {

                //alert("Invalid Aadhaar Number");
                return false;


            }
        }



        /*
         * Converts a string to a reversed integer array.
         */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
         * Reverses an int array
         */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }



    </script>
    <script>
        function pattadarnamevalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function Accountnovalidate(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[a-zA-Z0-9 ]|\a/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function onlynumbers(evt) {
            var theEvent = evt || window.event;

            //Handle paste
            if (theEvent.type === 'paste') {
                key = event.clipboardData.getData('text/plain');
            } else {
                // Handle key press
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
            }
            var regex = /[0-9 ]|\0/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

        function validtext(event) {

            var str = event.value;

            if (str == 'script' || str == 'alert') {
                alert('Enter valid format');
                event.value = "";
            }

            else {
                return false;
            }

        }
    </script>
</asp:Content>
