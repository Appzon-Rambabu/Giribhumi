<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="RythuBharosa_PaymentStatus_May21.aspx.cs" Inherits="ROFR.pages.RythuBharosa_PaymentStatus_May21" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #008500;}

.headertable .aftr th{position: sticky;top: 49px;}

 h5.thick {
  font-weight: bold;
}
   
 .grid td   /* this applies to the Gridviews Data fileds */
{
    padding: 10px;
    width: 3%;
  
}

 .grid th   /* this applies to the Gridviews Headers */
{
     padding: 10px 5px;
     height:5%;
     padding-top:3px
}


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
	
	<%--for print Button--%>
    <script type="text/javascript">
            function PrintGridData() {
              var prtGrid = document.getElementsByClassName('grid')[0];
              var title = document.getElementById('Title_Header').parentElement;
              prtGrid.border = 0;
             var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=100000 ,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
               prtwin.document.write('<div><div class="col-md-6"></div>' + title.outerHTML + "\r\n"+'</div>' + prtGrid.outerHTML);
               prtwin.document.close();
               prtwin.focus();
               prtwin.print();
               prtwin.close();
            }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdateProgress ID="UPDATED" runat="server">
                  <ProgressTemplate>
              <div class="preloader" style="background: rgba(255,255,255,0.5);">
                                     <div class="spinner"></div>
                                   <span id="loading-msg">
                                 <img src="../Rofrnewassets/images/aplogo.png" />
                             </span>
                              </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

     <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
        <div class="panel panel-body"> 
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> 
			   <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">RYTHU BHAROSA PAYMENT STATUS MAY - 2021</h5>
			   </div>
              <div class="col-md-4 text-right">
				  <div class="d-flex">
                      <div class="col-auto">
					      <div class="d-flex justify-content-end">
               <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />&nbsp;&nbsp;
			    <asp:Button ID="btn_excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Click" runat="server" Text="EXCEL"  />
			   
                           </div>
                   </div>
               <div class="col-md-9 col-auto">
                              <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
                        <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>    
                         
                    </div>
                </div>


            </div>
        </div>

           <div class="row  justify-content-center"  id="div_lbl" runat="server">
        <div class="col-md-8">  
            <div class="row">
                            <div class="col-md-3 " id="itda" runat="server" visible="false">
                
                   
                <asp:Label ID="lblitda" runat="server" Text="ITDA:" Font-Bold="true"></asp:Label>
              
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
              
                     </div>
                   <div class="col-md-3" id="district" runat="server" visible="false">
                            <asp:Label ID="lbldist" runat="server" Text="District:" Font-Bold="true"></asp:Label>
                                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                                       </div>
                   <div class="col-md-3" id="mandal" runat="server" visible="false">
             
                 <asp:Label ID="lblmandal" runat="server" Text="Mandal:" Font-Bold="true"></asp:Label>
                
                 <asp:Label ID="lbl_mandal" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                
                       </div>
                   <div class="col-md-3" id="village" runat="server" visible="false">
             
                 <asp:Label ID="lblvillage" runat="server" Text="Village:" Font-Bold="true"></asp:Label>
                
                 <asp:Label ID="lbl_village" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                   </div>
                 <div class="col-md-3" id="status" runat="server" visible="false">
             
                 <asp:Label ID="Label1" runat="server" Text="Status:" Font-Bold="true"></asp:Label>
                
                 <asp:Label ID="lbl_status" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                   </div>
                 </div>
                  
        </div>
          </div>

    <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  class="grid"  
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                         <asp:TemplateField HeaderText="S.NO"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText=" ITDA "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" District "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("District")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("District") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="No.of Beneficiaries" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("TOTAL") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Belong To Beneficiary Family" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Belong_to_Beneficiary_Family") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="Eligible" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Eligible") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="InEligible" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Ineligible") %>' runat="server" />
         
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
          <div class="row justify-content-center" style="text-align:right" id="div_mandal" runat="server">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  class="grid" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                       <asp:TemplateField HeaderText="S.NO."   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno1")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>           
                      

                          <asp:TemplateField HeaderText=" Mandal"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("Mandal") %> ' ForeColor="Red" ></asp:Label>
                     
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="No.of Beneficiaries" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Blue" Font-Bold="True" Text='<%# Eval("TOTAL") %>' runat="server"  />
 
            </ItemTemplate>
  
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Belong To Beneficiary Family" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Blue" Font-Bold="True" Text='<%# Eval("Belong_to_Beneficiary_Family") %>' runat="server" Visible="false" />
 <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Mandal")+","+ "BENEFICIARYFAMILY"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("Belong_to_Beneficiary_Family") %></asp:LinkButton>
            </ItemTemplate>
  
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="Eligible" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Eligible") %>' runat="server"  Visible="false"/>
   <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Mandal")+","+ "ELIGIBLE"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("Eligible") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="InEligible" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Ineligible") %>' runat="server"  Visible="false" />
         <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Mandal")+","+ "INELIGIBLE"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("Ineligible") %></asp:LinkButton>
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

             <div class="row justify-content-center" style="text-align:right" id="div_rejected" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" class="grid"  
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 

                    <Columns>   
                                
                       <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText=" Beneficiary ID"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"   Text='<%# Eval("BENFICIARY_ID") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" ITDA"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"   Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" District"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl3" runat="server"   Text='<%# Eval("DISTRICT") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Mandal"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl4" runat="server"   Text='<%# Eval("MANDAL") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Village"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl5" runat="server"   Text='<%# Eval("VILLAGE") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="ROFR Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl6"   Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl7"   Text='<%# Eval("FATHER_NAME") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Aadhaar Number" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl8"   Text='<%# Eval("AADHAAR_NO") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Survey Number" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl9"   Text='<%# Eval("SURVEY_NUMBER") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Khatha Number" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl10"   Text='<%# Eval("KHATHA_NUMBER") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Extent" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl11"   Text='<%# Eval("EXTENT") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Agr.Dept(RTGS) Comments" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl12"   Text='<%# Eval("Ag_deptRTGS_Comments") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="Field Comments" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl13" ForeColor="Black"  Text='<%# Eval("Field_Comment") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="Correct Aadhaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl14" ForeColor="Black"  Text='<%# Eval("Correct_Aadhar") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="HO Comment" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl15" ForeColor="Black"  Text='<%# Eval("HO_Comment") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                                <asp:TemplateField HeaderText="HO Remarks" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl16" ForeColor="Black"  Text='<%# Eval("HO_Remarks") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Status" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl17" ForeColor="Black"  Text='<%# Eval("STATUS") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Payment Status" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl18" ForeColor="Black"  Text='<%# Eval("PAYMENT_STATUS") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Amount" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl19" ForeColor="Black"  Text='<%# Eval("AMOUNT") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Credit Date" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl20" ForeColor="Black"  Text='<%# Eval("CREDIT_DATE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl21" ForeColor="Black"  Text='<%# Eval("REASON") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Belong To Beneficiary UID" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl22" ForeColor="Black"  Text='<%# Eval("BELONG_TO_BENF_UID") %>' runat="server" />
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
            

        </div>
 </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
