<%@ Page Title="" Language="C#" MasterPageFile="~/Bank/Master/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Aadharwise_Beneficiary_Details.aspx.cs" Inherits="ROFR.Bank.Pages.Aadharwise_Beneficiary_Details" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
                <div class="row" style="margin-top:0px;">

                    <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">




                      
                            <div class="panel panel-body" style="margin-top:150px;">

                       

                                
                                
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
                                        <h5 class="text-center text-white rounded py-1 bg-nav">Aadhaarwise Benificiary Details</h5>
                                          
                        <div>
                                        

                                        <div class="row mb-2">
                                            <div class="col-md-4 text-right">  <asp:Label ID="txt_rbtn" runat="server" Text="Aadhar No."></asp:Label><span style="color:Red;">*</span> : </div>
                                            <div class="col-md-4 text-left">
                                               <%-- <div class="form-group">--%>
                                                  <asp:TextBox ID="txt_adhar_no" CssClass="form-control"  runat="server" autocomplete="off" ></asp:TextBox>
                               
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


                                <div class="row justify-content-center">
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
</asp:Content>
