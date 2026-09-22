<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Forestwise_Loan_report.aspx.cs" Inherits="ROFR.pages.Forestwise_Loan_report"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
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
    </script>s
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
               
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">FOREST WISE LOAN REPORT</h5></div>
              <div class="col-md-4 text-right">
                   <asp:LinkButton ID="btn_back_div" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_div">Back</asp:LinkButton>
                   <asp:LinkButton ID="btn_back_range" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_range">Back</asp:LinkButton>
                   <asp:LinkButton ID="btn_back_beat" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_beat">Back</asp:LinkButton>
                   <asp:LinkButton ID="btn_back_block" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_block">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_entered" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_entered">Back</asp:LinkButton>
                 <%-- <asp:LinkButton ID="btn_back_approved" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_approved">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_released" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_released">Back</asp:LinkButton>--%>
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
        <div class="col-md-8">  
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
                 <div id="lbl_dist" runat="server" visible="false">
                <div class="col-md-1 text-right" >
                   
                <asp:Label ID="Label1" runat="server" Text="District:" Font-Bold="true"></asp:Label>
               </div>
               <div class="col-md-2 "> 
                    <asp:Label ID="lbl_district" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
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
           <div class="col-md-8" id="div_dist" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" DISTRICT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("DISTRICT") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT")+","+ "fdivision"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("DISTRICT") %></asp:LinkButton>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="LOANS ENTERED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_ENTERED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LOANS APPROVED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_APPROVED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="LOANS RELEASED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_RELEASED") %>' runat="server" />
         
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
         <div class="col-md-8" id="div_division" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" FOREST DIVISION "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbld0" runat="server"  Font-Bold="True" Text='<%# Eval("FOREST_DIVISION") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkDButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_DIVISION")+","+ "frange"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("FOREST_DIVISION") %></asp:LinkButton>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="LOANS ENTERED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_ENTERED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LOANS APPROVED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_APPROVED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="LOANS RELEASED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_RELEASED") %>' runat="server" />
         
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


           <div class="col-md-8" id="div_range" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" FOREST RANGE "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("FOREST_RANGE") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_RANGE")+","+ "fbeat"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("FOREST_RANGE") %></asp:LinkButton>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="LOANS ENTERED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_ENTERED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LOANS APPROVED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_APPROVED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="LOANS RELEASED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_RELEASED") %>' runat="server" />
         
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

          <div class="col-md-8" id="div_beat" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" FOREST BEAT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("FOREST_BEAT") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_BEAT")+","+ "fblock"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("FOREST_BEAT") %></asp:LinkButton>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="LOANS ENTERED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_ENTERED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LOANS APPROVED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_APPROVED") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="LOANS RELEASED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_RELEASED") %>' runat="server" />
         
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

          <div class="col-md-8" id="div_block" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText=" FOREST BLOCK "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("FOREST_BLOCK") %>' ></asp:Label>
                    
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="LOANS ENTERED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_ENTERED") %>'  runat="server" Visible="false" />
   <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_BLOCK")+","+ "ENTERED"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("LOANS_ENTERED") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LOANS APPROVED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_APPROVED") %>' runat="server"  Visible="false"/>
  <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_BLOCK")+","+ "APPROVED"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("LOANS_APPROVED") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="LOANS RELEASED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOANS_RELEASED") %>' runat="server"  Visible="false"/>
         <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("FOREST_BLOCK")+","+ "RELEASED"%>' CausesValidation="false"  OnClick="Getlink_Click" ><%# Eval("LOANS_RELEASED") %></asp:LinkButton>
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
       
         <div class="col-md-8 table-responsive" id="div_entered" runat="server">
        
       <div class="headertable">
      <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText="LOAN ACCOUNT NO"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("LOAN_ACCOUNTNO") %>' ></asp:Label>
                   
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BORROWER NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER/HUSBAND NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("FATHER_HUSBAND_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="BORROWER AADHAAR NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_AADHAAR_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="COMPARTMENT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("COMPARTMENT_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="LOAN CREATED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_CREATED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                            <asp:TemplateField HeaderText="LOAN AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_AMOUNT") %>' runat="server" />
         
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
           
        
          <div class="col-md-8" id="div_approved" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText="LOAN ACCOUNT NO"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("LOAN_ACCOUNTNO") %>' ></asp:Label>
                   
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BORROWER NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER/HUSBAND NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("FATHER_HUSBAND_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="BORROWER AADHAAR NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_AADHAAR_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="COMPARTMENT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("COMPARTMENT_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="LOAN CREATED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_CREATED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                  <asp:TemplateField HeaderText="LOAN APPROVED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_APPROVED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="LOAN AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_AMOUNT") %>' runat="server" />
         
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
        
         <div class="col-md-10" id="div_released" runat="server">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                      

                          <asp:TemplateField HeaderText="LOAN ACCOUNT NO"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("LOAN_ACCOUNTNO") %>' ></asp:Label>
                   
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="BORROWER NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER/HUSBAND NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("FATHER_HUSBAND_NAME") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="BORROWER AADHAAR NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BORROWER_AADHAAR_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="COMPARTMENT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black" Font-Bold="True" Text='<%# Eval("COMPARTMENT_NO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="LOAN CREATED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_CREATED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                  <asp:TemplateField HeaderText="LOAN APPROVED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_APPROVED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="LOAN RELEASED ON" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_RELEASED_ON") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="LOAN AMOUNT" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Black" Font-Bold="True" Text='<%# Eval("LOAN_AMOUNT") %>' runat="server" />
         
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
