<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Rofrlandphasesreport.aspx.cs" Inherits="ROFR.pages.Rofrlandphasesreport" EnableEventValidation ="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .header-center {
            text-align: center;
        }
        
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #008500;}

.headertable .aftr th{position: sticky;top: 49px;}
 h5.thick 
 {
  font-weight: bold;
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
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="margin-top:-10px">
    <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1 thick">ROFR STONE PLANTATION PHASES REPORT</h5></div>
                  <div class="col-md-4 text-right ">
				   <asp:Button ID="btn_uploadDISTRICTWISE" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_upload_Click" runat="server" Text="Excel" />&nbsp;&nbsp;
                    <asp:Button ID="btn_uploadMandalWise" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_uploadMandalWise_Click"  runat="server" Text="EXCEL" Visible="false"/>&nbsp;&nbsp;
				   <asp:Button ID="btn_UploadvillageWise" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_UploadvillageWise_Click"  runat="server" Text="EXCEL" Visible="false"/>&nbsp;&nbsp;
				   <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true"  runat="server" Text="EXCEL" OnClick="btn_img_upload_Click"  Visible="false"/>
				    <asp:Button ID="btn_img_pdf" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_pdf_Click"   runat="server" Text="PDF"  Visible="false"/>
				   <asp:Button ID="btnmandnothaving" class="btn btn-sm btn-success"  AutoPostBack="true"  runat="server" Text="EXCEL" OnClick="btnmandnothaving_Click" Visible="false"/>
				  <asp:Button ID="btn_Phase1_Excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Phase1_Excel_Click" runat="server" Text="Excel" />&nbsp;&nbsp;
                   <asp:Button ID="btn_Phase2_Excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Phase2_Excel_Click" runat="server" Text="Excel" />&nbsp;&nbsp;
               <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
               <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
               <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>
               <asp:LinkButton ID="btn_mand_nothaving" runat="server"  Font-Underline="true" Visible="false" OnClick="btn_mand_nothaving_Click">Back</asp:LinkButton>
              </div>
                   
              <div class="col-md-4">
                <div class="row d-flex justify-content-end">
                    <div class="col-md-3 ml-0 mr-0">
                        
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                         
                    </div>
                    <div class="col-md-3 ml-0 mr-0">
                          
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                         
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                          
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_img_notupload" class="btn btn-sm btn-success"  AutoPostBack="true"  runat="server" Text="EXCEL" OnClick="btn_img_notupload_Click" Visible="false"/>
                    </div>
                         <div class="col-md-3 ml-0 mr-0">
                         
                    </div>
                     <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_img_pdf_down" class="btn btn-sm btn-success"  AutoPostBack="true"  runat="server" Text="PDF"  Visible="false"/>
                    </div>

                </div>


           </div>
            
        </div>
    <div class="row justify-content-center">
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged">
                                    <asp:ListItem  Value="PHASE-II">PHASE-II</asp:ListItem>               
                                     <asp:ListItem  Value="ALL">ALL</asp:ListItem>
                                     <asp:ListItem  Value="PHASE-I">PHASE-I</asp:ListItem>
                                                  
                                                  
                            </asp:DropDownList>
                    </div>
              
           </div>
              

      
        </div>
           
              </div>
        <br />
        <br />
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
                 <div class="col-md-4" id="status" runat="server" visible="false">
                 <asp:Label ID="Label1" runat="server" Text="Status:" Font-Bold="true"></asp:Label>
                 <asp:Label ID="lbl_status" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                   </div>
                 </div>
        </div>
    </div>

    <div class="row justify-content-center" style="text-align:right;" id="div_dist" runat="server">
           <div class="col-md-10">
                  <div class="table-responsive">
                        <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <rowstyle Height="20px" />
                  <alternatingrowstyle  Height="20px"/>
                    <Columns>   
               <asp:TemplateField HeaderText="S.NO."  ItemStyle-Width = "50" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
         <asp:TemplateField HeaderText=" DISTRICT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("DISTRICT") %>' Visible="false"></asp:Label>
              <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("DISTRICT")+"-"+ "1"%>' CausesValidation="false" OnClick="LinkButton1_Click1"><%# Eval("DISTRICT") %></asp:LinkButton>

              </div>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="FARMERS PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("total_farmer_Plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="UPTO YESTERDAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl5" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Till_yesterday_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="TODAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl6" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Today_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="CUMULATIVE LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Cumulative_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="LAND IMAGES NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_having_Land_Image") %>' runat="server" />
         
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
             <div class="col-md-10">
                     <div class="table-responsive">
                                    <div class="headertable">
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>
                        <asp:TemplateField HeaderText="S.NO."  ItemStyle-Width = "50" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno1")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>    
                          <asp:TemplateField HeaderText=" MANDAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("MANDAL") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")%>' CausesValidation="false" OnClick="OnMandal_Click" ><%# Eval("MANDAL") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Total_Farmer_Plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="UPTO YESTERDAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Till_yesterday_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText=" TODAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl5" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Today_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText=" CUMULATIVE LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Cumulative_Having_Land_Image") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                     <%--    <asp:TemplateField HeaderText="LAND IMAGES NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_having_Land_Image") %>' runat="server" Visible="false"/>
           <asp:LinkButton ID="mandclick" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")+","+ "NOTHAVING"%> ' CausesValidation="false" OnClick="mandclick_Click"><%# Eval("Not_having_Land_Image") %></asp:LinkButton>
       
            </ItemTemplate>
        </asp:TemplateField> --%>
                      
               <asp:TemplateField HeaderText="LAND IMAGES NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblmand" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_having_Land_Image") %>' runat="server" Visible="false" />
         <asp:LinkButton ID="LinkButtonmand" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")+","+ "NOTHAVING"%> ' CausesValidation="false" OnClick="MandalLevel_Click" ><%# Eval("Not_having_Land_Image") %></asp:LinkButton>
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

    <div class="row justify-content-center" style="text-align:right" id="div_village" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">
       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                        <asp:TemplateField HeaderText="S.NO."  ItemStyle-Width = "20" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno2")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>    
             <asp:TemplateField HeaderText=" VILLAGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("VILLAGE") %>' ForeColor="Red" ></asp:Label>
                     
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Total_Farmer_Plots") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="UPTO YESTERDAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Till_yesterday_Having_Land_Image") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="TODAY LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("Today_Having_Land_Image") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText=" CUMULATIVE LAND IMAGES UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Cumulative_Having_Land_Image") %>' runat="server" Visible="false" />
     <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "HAVING"%> ' CausesValidation="false" OnClick="Rejected_onclick" ><%# Eval("Cumulative_Having_Land_Image") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="LAND IMAGES NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_having_Land_Image") %>' runat="server" Visible="false" />
         <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "NOTHAVING"%> ' CausesValidation="false" OnClick="Rejected_onclick"><%# Eval("Not_having_Land_Image") %></asp:LinkButton>
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
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False"  
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
                          <asp:TemplateField HeaderText="  Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"   Text='<%# Eval("ID") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"   Text='<%# Eval("benficiary_id2") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl3"   Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl4" ForeColor="Black"  Text='<%# Eval("Father_Name") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="Compartment No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black"  Text='<%# Eval("Compartment_No") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Plot No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl7" ForeColor="Black"  Text='<%# Eval("Plot_No") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Extent Plot Area" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl8" ForeColor="Black"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aadhaar No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl9" ForeColor="Black"  Text='<%# Eval("Aadhaar_NO") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Land Image1" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <a href='<%# Eval("Land_Img_path1") %>' target="_blank">
                    <img src='<%# Eval("Land_Img_path1") %>' width:"50px"  height="50px"/>
                </a>
  
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Land Image2" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                    
                  <a href='<%# Eval("Land_Img_path2") %>' target="_blank">
                    <img src='<%# Eval("Land_Img_path2") %>' width="50px"  height="50px" />
                </a>
  
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

    <div class="row justify-content-center" style="text-align:right" id="divMandcount" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
            <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl025" runat="server"   Font-Bold="True" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Id"  ItemStyle-Width = "50" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lb" runat="server"   Font-Bold="True"  Text='<%# Eval("ID") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl25" runat="server"  Font-Bold="True"  Text='<%# Eval("benficiary_id2") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl35" Font-Bold="True"  Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
            <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl45" Font-Bold="True"  Text='<%# Eval("Father_Name") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
            <asp:TemplateField HeaderText="Compartment No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl55" Font-Bold="True"  Text='<%# Eval("Compartment_No") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
            <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl65" Font-Bold="True"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
            <asp:TemplateField HeaderText="Plot No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl75" Font-Bold="True" Text='<%# Eval("Plot_No") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Extent Plot Area" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl85" Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Aadhaar No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl95" Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server" />
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
</asp:Content>
