<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Adangal.master" AutoEventWireup="true" CodeBehind="Aadharwise_Beneficiary_Details_BNK.aspx.cs" Inherits="ROFR.pages.Aadharwise_Beneficiary_Details_BNK" EnableEventValidation="false" %>
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

         function ValidCaptcha() {
         var aadhar = document.getElementById('<%=txt_adhar_no.ClientID%>').value;
             
             if (aadhar == "0") {

                 alert("Please enter aadhar number!");
                 return false;
             }
         }
         function removeSpaces(string) {
             return string.split(' ').join('');
         }

     </script>
     <script>
         var mask;
         function text() {
             mask = document.getElementById('<%=txt_adhar_no.ClientID %>').value;
             document.getElementById('<%=HiddenField1.ClientID %>').value = mask;

             if (mask.length < 12 || (mask.length >= 13 && mask.length < 16)) {
                 alert("Please enter either 12 or 16 digit aadhaar number");
                 document.getElementById('<%=txt_adhar_no.ClientID %>').value = "";
                return false;
            }
            else if (mask.length == 12) {
                var enteredadhar = mask;
                var status = validateVerhoeff(enteredadhar);
                if (!status) {
                    if (status == "0") {
                        alert("Please enter a valid Aadhar Number");
                        document.getElementById('<%=txt_adhar_no.ClientID %>').value = "";
                }
                return status;
            }
            document.getElementById('<%=txt_adhar_no.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxx');
                
            }
        else if (mask.length > 12 && mask.length == 16) {
             var enterdadhar = mask;
            var status = validateVerhoeff(enterdadhar);
            if (!status)
            {
                if (status == "0") {
                    alert("Please enter a valid Aadhar Number");
                    document.getElementById('<%=txt_adhar_no.ClientID %>').value = "";
                }
                return status;
            }
                document.getElementById('<%=txt_adhar_no.ClientID %>').value = mask.replace(mask.substring(0, mask.length - 4), 'xxxxxxxxxxxx');

             }
             return mask;
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

                            <div class="panel panel-body">
                                <div class="row justify-content-center">
                                    <div class="col-md-4">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Aadhaar wise Benificiary Details</h5>
                                       <div>
                                        <div class="row mb-3 mt-5">
                                            <div class="col-md-4 text-right">  <asp:Label ID="txt_rbtn" runat="server" Text="Aadhaar No."></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                  <asp:TextBox ID="txt_adhar_no" CssClass="form-control" MaxLength="12"  runat="server" autocomplete="off" onkeypress='codevalidate(event)' onchange="return text()" ></asp:TextBox>
                               
                                                <%--</div>--%>
                                            </div>
                                            <div class="col-md-4 text-left">
                                                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click"  />
                                            </div>
                                        </div>
                            </div>
                           

                                      
<%--                                        <div class="row mb-2">

                                            <div class="table-responsive">
                                               
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>


                                <div class="row justify-content-center mt-5">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            
                                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table  table-bordered text-center  "  >  
                   
                                                                                 <Columns>   

                                       <asp:TemplateField HeaderText="ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl0"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                                                                       <asp:TemplateField HeaderText="ITDA" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                     
                                                                                       <asp:TemplateField HeaderText="District" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="Mandal" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("Mandal") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                       <asp:TemplateField HeaderText="Village" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl4" runat="server"  Font-Bold="True" Text='<%# Eval("Village") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="Habitation" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl5" runat="server"  Font-Bold="True" Text='<%# Eval("Habitation") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="ROFR Pattadhar" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField>                               
                         <asp:TemplateField HeaderText="Aadhaar No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl8" runat="server"  Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="Bank Account No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl9"  Font-Bold="True" Text='<%# Eval("BankAccountNo") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Ifsc Code" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl10"  Font-Bold="True" Text='<%# Eval("IfscCode") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Bank Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl11"  Font-Bold="True" Text='<%# Eval("BankName") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                         
          
                    
                       
                          <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
<%--                      <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"   CommandName="MyUpdate" CommandArgument='<%#Eval("benficiary_id")+","+ "1"%>' CausesValidation="false"  OnClick="link_onclick" >View</asp:LinkButton> --%>
                   <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("benficiary_id")+","+Eval("Aadhaar_NO1")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" >View</asp:LinkButton>
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

