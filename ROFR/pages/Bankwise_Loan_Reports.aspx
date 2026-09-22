<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Bankwise_Loan_Reports.aspx.cs" Inherits="ROFR.pages.Bankwise_Loan_Reports" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:500px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #1F5C99;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
               
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">BANK WISE LOAN REPORT</h5></div>
              <div class="col-md-4 text-right">
                   <asp:LinkButton ID="btn_back_entered" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_entered">Back</asp:LinkButton>
               
              </div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <%--<div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>


            </div>
        </div>
         
            
     
    <div class="row justify-content-center" style="text-align:right">
        <div class="col-md-10"> 
             <div class="row mb-2"> 
                                            <div class="col-md-4 text-right">Select: </div>
                                            <div class="col-md-8 text-left">
                                              
                                                <asp:RadioButtonList ID="rbtn_status" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtn_status_SelectedIndexChanged"  AutoPostBack="true" >
                                                    <asp:ListItem Selected="True">Entered</asp:ListItem>
                                                    <asp:ListItem>Approved</asp:ListItem>
                                                    <asp:ListItem>Released</asp:ListItem>
                                                    <asp:ListItem>Not Released</asp:ListItem>
                                                    <asp:ListItem>All</asp:ListItem>
                                                </asp:RadioButtonList>
                                             
                                            </div>
               
                                        </div>
             
            <div class="row mb-2">
                                            <div class="col-md-4 text-right">Bank Name: </div>
                                            <div class="col-md-4 text-left">
                                              
                                                     <asp:DropDownList ID="ddl_bank"   CssClass="form-control"   AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlbank_OnSelectedIndexChanged"></asp:DropDownList> 
                                             
                                            </div>
                 <div class="col-md-4 text-left">
                                              
                                                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="Getdata_Click" /> 
                                             
                                            </div>
                                        </div>
             <div class="row mb-1 mt-1 justify-content" id="div_lbl" runat="server">
                 <div id="lblbanch" runat="server" visible="false">
                <div class="col-md-1 text-right" >
                   
                <asp:Label ID="Label1" runat="server" Text="District:" Font-Bold="true"></asp:Label>
               </div>
               <div class="col-md-2 "> 
                    <asp:Label ID="lbl_branch" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
               </div>
                     </div>
                   <div id="lbl_divn" runat="server" visible="false">
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="Division:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_div" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                       </div>
                   <div id="lbl_rg" runat="server" visible="false">
               <div class="col-md-1 text-right">

                 <asp:Label ID="Label3" runat="server" Text="Range:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_range" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                       </div>
                   <div id="lbl_bt" runat="server" visible="false">
               <div class="col-md-1 text-right">

                 <asp:Label ID="Label4" runat="server" Text="Beat:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_beat" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                       </div>
                   <div id="lbl_bl" runat="server" visible="false">
               <div class="col-md-1 text-right">

                 <asp:Label ID="Label5" runat="server" Text="Block:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_block" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div> 
                       </div>
                 </div> 
        </div>
           <div class="col-md-10" id="div_entered" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" BANK NAME "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("BANKNAME") %>' ></asp:Label>
                    
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BRANCH NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BRANCH_NAME") %>' runat="server"  Visible="false"/>
   <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("BRANCH_NAME")%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("BRANCH_NAME") %></asp:LinkButton>
           </div>
                       </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="TOTAL LOANS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("TOTAL_LOANS") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="TOTAL SURVEY NUMBERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("TOTAL_SURVEY_NUMBERS") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                      
                        <asp:TemplateField HeaderText="TOTAL FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("TOTAL_FARMERS") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="TOTAL EXTENT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("TOTAL_EXTENT") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("AMOUNT") %>' runat="server" />
         
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
         <div class="col-md-12" id="div_branch_entered" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" BANKNAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbld0" runat="server"  Font-Bold="True" Text='<%# Eval("BANKNAME") %>' ></asp:Label>
                    
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BRANCH NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BRANCH_NAME") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="DIVISION RANGE BEAT BLOCK" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("DIVISION_RANGE_BEAT_BLOCK") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="SURVEY NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("SURVEY_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="ROFR PATTADAAR" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="FATHER_NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("FATHER_NAME") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                             <asp:TemplateField HeaderText="LOAN CREATED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_CREATED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="LOAN ACCOUNT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_ACCOUNTNO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Black" Font-Bold="True" Text='<%# Eval("AMOUNT") %>' runat="server" />
         
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


           
         <div class="col-md-12" id="div_all" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" BANKNAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbld0" runat="server"  Font-Bold="True" Text='<%# Eval("BANKNAME") %>' ></asp:Label>
                    
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BRANCH NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BRANCH_NAME") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ENTERED LOANS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ENTERED_LOANS") %>' runat="server" />

            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="APPROVED LOANS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("APPROVED_LOANS") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="ENTERED SURVEY NUMBERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ENTERED_SURVEY_NUMBERS") %>' runat="server" />

            </ItemTemplate>
        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="APPROVED SURVEY NUMBERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("APPROVED_SURVEY_NUMBERS") %>' runat="server" />
        
            </ItemTemplate>
        </asp:TemplateField> 
                             <asp:TemplateField HeaderText="ENTERED FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ENTERED_FARMERS") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="APPROVED FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Black" Font-Bold="True" Text='<%# Eval("APPROVED_FARMERS") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="ENTERED EXTENT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ENTERED_EXTENT") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                       <asp:TemplateField HeaderText="APPROVED EXTENT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Black" Font-Bold="True" Text='<%# Eval("APPROVED_EXTENT") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ENTERED AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Black" Font-Bold="True" Text='<%# Eval("ENTERED_AMOUNT") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="APPROVED AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Black" Font-Bold="True" Text='<%# Eval("APPROVED_AMOUNT") %>' runat="server" />
         
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
        </div>
</asp:Content>
