<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Dlc_Abstract_Report.aspx.cs" Inherits="ROFR.pages.Dlc_Abstract_Report" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        <%-- .headertable { overflow-y: auto; height:400px; } --%>
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #dee2e6 !important;font-size:13px;}
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

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
     <div class="panel panel-body" style="margin-top:-10px;"> 
          
           
         <div class="row mb-1 mt-1 justify-content-end">
               
               <div class="col-md-4"> 
			   <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">FARMER PLOT WISE DLC REPORT</h5>
			   </div>
              <div class="col-md-4 text-right ">
			  <div class="d-flex">
			  <div class="col-auto">
			  <div class="d-flex justify-content-end">
			  <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />
			   <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="EXCEL" />&nbsp;&nbsp;
			   <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="EXCEL" />
			    <asp:Button ID="btn_village_excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_village_excel_Click" runat="server" Text="EXCEL"  Visible="false"/>
				 <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_upload_Click" runat="server" Text="EXCEL"  Visible="false"/>
				  <asp:Button ID="btn_img_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_notupload_Click" runat="server" Text="EXCEL" Visible="false"/>
			   <asp:Button ID="Farmer_image_not_excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Farmer_image_not_excel_Click" runat="server" Text="EXCEL" Visible="false"/>
			  </div>
			  </div>
			  <div class="col-md-9 col-auto ">
			   <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
               <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>
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
                 <div class="col-md-4" id="status" runat="server" visible="false">
             
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
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   class="grid" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
               <asp:TemplateField HeaderText="S.NO"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME")+","+Eval("DISTRICT")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("DISTRICT") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_farmer_Plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="DLC UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Having_Dlc") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="DLC NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_Having_Dlc") %>' runat="server" />
         
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
                             <asp:TemplateField HeaderText="S.NO"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")%>' CausesValidation="false"   OnClick="Mandal_onclick" ><%# Eval("MANDAL") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("Total_Farmer_Plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="DLC UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Having_Dlc") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="DLC NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <%--<asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_Having_Dlc") %>' runat="server" />--%>
               <asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_Having_Dlc") %>' runat="server" Visible="false" />
              <asp:LinkButton ID="lbl3Buttonmand" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")+","+ "Not Having Dlc"%> ' CausesValidation="false"   OnClick="mandclick_Farmer_image_not_Click" ><%# Eval("Not_Having_Dlc") %></asp:LinkButton>
           
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

         
            <div class="row justify-content-center" style="text-align:right" id="div_madalDetailswise" runat="server">
           <div class="col-md-11">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" class="grid"   
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
                         <asp:TemplateField HeaderText= "ID"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lble26" runat="server"  Font-Bold="True" Text='<%# Eval("ID") %>' ></asp:Label>
                   </div>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField HeaderText="BENFICIARY ID"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lble0" runat="server"  Font-Bold="True" Text='<%# Eval("benficiary_id2") %>' ></asp:Label>
                   </div>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="ITDA NAME"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lble1" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' ></asp:Label>
                   </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
       <asp:TemplateField HeaderText="DISTRICT"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lblel0" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' ></asp:Label>
                   </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="MANDAL" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lblel1"  Font-Bold="True" Text='<%# Eval("Mandal") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
   

        <asp:TemplateField HeaderText="VILLAGE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel3"  Font-Bold="True" Text='<%# Eval("Village") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FATHER NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel3"  Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField>
     
         <asp:TemplateField HeaderText="PLOT NO" ItemStyle-Width = "200" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
			<div style="text-align:right">
                 <asp:Label ID="lblel5"  Font-Bold="True" width="150" Text='<%# Eval("Plot_No") %>' runat="server"  />
				 </div>
             </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="EXTENT PLOT AREA" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel6"  Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>' runat="server"  />
             </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="AADHAAR NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
			<div style="text-align:right">
                 <asp:Label ID="lblel61"  Font-Bold="True" Text='<%# Eval("AADHAAR_NO") %>' runat="server"  />
				 </div>
             </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="COMPARTMENT NO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel7"  Font-Bold="True" Text='<%# Eval("Compartment_No") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="ROFR PATTANO" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel8" Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dlc date" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel9"  Font-Bold="True" Text='<%# Eval("Dlc_date") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Dlcpath" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel9"  Font-Bold="True" Text='<%# Eval("Dlcpath") %>' runat="server" />
             </ItemTemplate>
        </asp:TemplateField>   
                        <asp:TemplateField HeaderText="dlc" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lblel9"  Font-Bold="True" Text='<%# Eval("dlc") %>' runat="server" />
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
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  class="grid"  
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                             <asp:TemplateField HeaderText="S.NO"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
 <asp:TemplateField HeaderText="DLC UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Having_Dlc") %>' runat="server" Visible="false" />
  <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "HAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("Having_Dlc") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="DLC NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Not_Having_Dlc") %>' runat="server" Visible="false" />
         <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "NOTHAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("Not_Having_Dlc") %></asp:LinkButton>
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
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False"   class="grid" 
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
                        <asp:TemplateField HeaderText="DLC Issued Date" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
               
                     <asp:Label ID="lbl9" ForeColor="Black"  Text='<%# Eval("Dlc_date") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Dlc" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                      <%--<asp:Label Text= '<%# If(Eval("Dlcpath").ToString() != null,  Eval("Dlcpath"), "") %>' runat="server" />--%>
                <a href='<%# Eval("Dlcpath") %>' target="_blank" >
                   
              <asp:Label ID="lbl10" ForeColor="Red"  Text='<%# Eval("dlc") %>' runat="server" />
                   
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
                
        </div>
                  </ContentTemplate>
             </asp:UpdatePanel>
</asp:Content>
