<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Aadharwise_Beneficiary_Details.aspx.cs" Inherits="ROFR.pages.Aadharwise_Beneficiary_Details"  EnableEventValidation="false"%>
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
   <style type="text/css">
       .spinner {
    border: 8px solid #f3f3f3;
    border-radius: 50%;
    border-top: 8px solid #3498db;
    width: 60px;
    height: 60px;
    animation: spin 2s linear infinite;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}
   </style>
    <script>
        function showLoader() {
            document.getElementById('loader').style.display = 'block';
        }

        function hideLoader() {
            document.getElementById('loader').style.display = 'none';
        }
</script>

     <script>
         var mask;
         function text() {
             mask = document.getElementById('<%=txt_adhar_no.ClientID %>').value;
            document.getElementById('<%=HiddenField1.ClientID %>').value = mask;

            if (mask.length < 12 || (mask.length >= 13 && mask.length < 16)) {
                alert("Please enter  12  digit aadhaar number");
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
       background-color:#008500!important;
       }
  
  
    .bg-nav{
      background-color: #008500 !important;
    }
   
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="loader" style="display:none;">
    <div class="spinner"></div>
    </div>
    
     <div class="container-fluid">
                <div class="row" style="margin-top:-30px;">
                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">
                      
                            <div class="panel panel-body">
                                
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Aadharwise Benificiary Details</h5>
                        <div>
                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">  <asp:Label ID="txt_rbtn" runat="server" Text="Aadhar No."></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                                  <asp:HiddenField ID="HiddenField1" runat="server" />
                                                  <asp:TextBox ID="txt_adhar_no" CssClass="form-control"  runat="server" autocomplete="off" onchange="return text()" onkeypress='codevalidate(event)' MaxLength="12" ></asp:TextBox>
                                                
                                            </div>
                                            <div class="col-md-4 text-left">
                                                <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Submit" OnClientClick="showLoader()"  OnClick="Button1_Click" />
                                            </div>
                                        </div>
                            </div>

                                    </div>
                                </div>


                                <div class="row justify-content-center">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            
                                       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table  table-bordered text-center  "  >  
                   
                               <Columns>   

							   
							   
											<asp:TemplateField HeaderText="S.NO"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
										<ItemTemplate>
							<div style="text-align:right">
						  <asp:Label Class="txt"  ID="lbl025" runat="server"   Font-Bold="True" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
						  </div>
						</ItemTemplate>
					</asp:TemplateField>
                                       <asp:TemplateField HeaderText=" BENIFICIARY ID" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
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
                                                                                     
                 <asp:TemplateField HeaderText="DISTRICT" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="MANDAL" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("Mandal") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                       <asp:TemplateField HeaderText="VILLAGE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl4" runat="server"  Font-Bold="True" Text='<%# Eval("Village") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="HABITATION" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl5" runat="server"  Font-Bold="True" Text='<%# Eval("Habitation") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="ROFR PATTADHAR" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="FATHER NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField>                               
                         <asp:TemplateField HeaderText="AADHAR NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl8" runat="server"  Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
               <asp:TemplateField HeaderText="BANK ACCOUNT NO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl9"  Font-Bold="True" Text='<%# Eval("BankAccountNo") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="IFSC CODE" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl10"  Font-Bold="True" Text='<%# Eval("IfscCode") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                           <asp:TemplateField HeaderText="BANK NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
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
    
   
    
</asp:Content>
