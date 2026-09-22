<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Latlongs_Abstract_Report.aspx.cs" Inherits="ROFR.pages.Latlongs_Abstract_Report"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <style type="text/css">
        .header-center {
            text-align: center;
        }
        
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
        //function noBack()
        // {
        //     window.history.forward()
        // }
        //noBack();
        //window.onload = noBack;
        //window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        //window.onunload = function() { void (0) }
    </script>
	
	 <%--for print Button--%>
    <script type="text/javascript">
            function PrintGridData() {
              var prtGrid = document.getElementsByClassName('grid')[0];
              var title = document.getElementById('Title_Header').parentElement;
              prtGrid.border = 0;
             var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
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
     <div class="panel panel-body"> 
    <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">LATLONGS REPORT</h5></div>
              <div class="col-md-4 text-right ">
                  <div class="d-flex">
                      <div class="col-auto">
                          <div class="d-flex justify-content-end">
                          <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />
                          <asp:Button ID="btn_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btnupload_Click" runat="server" Text="Uploaded" Visible="false" />
                     <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="Not Uploaded Data" Visible="true" />
                    <asp:Button ID="btn_img_upload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_upload_Click" runat="server" Text="Excel"  Visible="false"/>
                     <asp:Button ID="btn_img_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_notupload_Click" runat="server" Text="Excel" Visible="false"/>
                     <asp:Button ID="Button1" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Button1_Click1" runat="server" Text="Excel" Visible="false"/>
                     <asp:Button ID="Button2" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Button2_Click" runat="server" Text="Excel" Visible="false"/>
                   
                </div>

                      </div>
                      <div class="col-auto">
                          <asp:Button ID="dwnld_latlongs" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Button1_Click" runat="server" Text="Download Latlongs Lessthan 4" />
                          <%--<asp:LinkButton ID="dwnld_latlongs" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="dwnldlatlongs_Click">Download Latlongs Lessthan 4</asp:LinkButton>--%>
               </div>
                      <div class="col-auto">
                    <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
                    <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                   <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>
                   <asp:LinkButton ID="latlongback" runat="server"  Font-Underline="true" Visible="false" OnClick="latlongback_Click">Back</asp:LinkButton>
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
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" class="grid" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
           <asp:TemplateField HeaderText="S.NO."   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>        
                        
                         <asp:TemplateField HeaderText=" ITDA "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("itda_name") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" DISTRICT "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("district") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("itda_name")+","+Eval("district")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("district") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("total_benficiaries") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                               <asp:TemplateField HeaderText="LATLONGS LESSTHAN 4" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Red" Font-Bold="True" Text='<%# Eval("LATLONGS_LESSTHAN_4") %>' runat="server" />
         
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
      <asp:GridView ID="GridView2" runat="server" class="grid" AutoGenerateColumns="False"   
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

                          <asp:TemplateField HeaderText=" MANDAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("mandal") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")%>' CausesValidation="false"   OnClick="Mandal_onclick" ><%# Eval("mandal") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("total_benficiaries") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" Visible="false" />
              <asp:LinkButton ID="lbl4Buttonmand" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")+","+ "Plots not having latlongs"%> ' CausesValidation="false"   OnClick="mandclick_plots_not_having_latlongs_click" ><%# Eval("plots_not_having_latlongs") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="LATLONGS LESSTHAN 4" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("LATLONGS_LESSTHAN_4") %>' runat="server" Visible="false"/>
            <asp:LinkButton ID="lbl5LinkButton" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")+","+ "LATLONGS LESSTHAN4"%> ' CausesValidation="false" OnClick="lbl5LinkButton_Click"><%# Eval("LATLONGS_LESSTHAN_4") %></asp:LinkButton>

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
      <asp:GridView ID="GridView3" runat="server" class="grid" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                       <asp:TemplateField HeaderText="S.NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_Vill")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>       

                          <asp:TemplateField HeaderText=" VILLAGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("village") %>' ForeColor="Red" ></asp:Label>
                     
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="FARMERS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("total_benficiaries") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" Visible="false" />
  <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("village")+","+ "HAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("plots_having_latlongs") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" Visible="false" />
         <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("village")+","+ "NOTHAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("plots_not_having_latlongs") %></asp:LinkButton>
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
    
         
    <div class="row justify-content-center" style="text-align:right" id="div_success" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView4" runat="server" class="grid" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"> 
                    <Columns>   
                                
                       <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black"  Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"   Text='<%# Eval("benficiary_id") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl2"   Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl3" ForeColor="Black"  Text='<%# Eval("Father_Name") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="Compartment No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black"  Text='<%# Eval("Compartment_No") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Extent PlotArea" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="Black"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Latitude" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl7" ForeColor="Black"  Text='<%# Eval("LATITUDE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Longitude" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl7" ForeColor="Black"  Text='<%# Eval("LONGITUDE") %>' runat="server" />
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

    <div class="row justify-content-center" style="text-align:right" id="div_rejected" runat="server">
           <div class="col-md-10">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView5" runat="server" class="grid" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                       <asp:TemplateField HeaderText="S.No" ItemStyle-Width="15px" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"   Text='<%# Eval("benficiary_id") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl2"   Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
 <asp:TemplateField HeaderText="Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl3" ForeColor="Black"  Text='<%# Eval("Father_Name") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                         <asp:TemplateField HeaderText="Compartment No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Black"  Text='<%# Eval("Compartment_No") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl5" ForeColor="Black"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Plot No." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="Black"  Text='<%# Eval("Plot_No") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Extent PlotArea" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
                 <asp:Label ID="lbl7" ForeColor="Black"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
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

    <div class="row justify-content-center" style="text-align:right" id="div_madalDetailswise" runat="server">
         <div class="col-md-12">
     <div class="table-responsive">
     <div class="headertable">
     <asp:GridView ID="GridView6" runat="server" class="grid" AutoGenerateColumns="False"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" > 
      <Columns>
    <asp:TemplateField HeaderText="S.No" HeaderStyle-ForeColor="White" ItemStyle-Width="15px" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
        <div style="text-align:right">
            <asp:Label Class="txt" ID="label0" runat="server" ForeColor="Black" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
            </div>
    </ItemTemplate>
   </asp:TemplateField>

   <asp:TemplateField HeaderText=" Benficiary Id" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label1" runat="server" Text='<%# Eval("benficiary_id") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
  <asp:TemplateField HeaderText=" ITDA Name" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label2" runat="server" Text='<%# Eval("ITDA_NAME") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText="District" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label3" runat="server" Text='<%# Eval("District") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Mandal" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label4" runat="server" Text='<%# Eval("Mandal") %>'></asp:Label>
       
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Gram Panchayat" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label5" runat="server" Text='<%# Eval("Gram_Panchayat") %>'></asp:Label>
       
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Village" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label6" runat="server" Text='<%# Eval("Village") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="Habitation" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label7" runat="server" Text='<%# Eval("Habitation") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label8" runat="server" Text='<%# Eval("Rofr_Pattadaar") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
           <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label9" runat="server" Text='<%# Eval("ROFR_PATTANO") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
   <%-- <asp:TemplateField HeaderText="Aadhaar NO" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
     <ItemTemplate>
            <asp:Label Class="txt" ID="label10" runat="server" Text='<%# Eval("AADHAAR_NO") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>--%>
<asp:TemplateField HeaderText="Father Name" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label ID="label11" ForeColor="Black" Text='<%# Eval("Father_Name") %>' runat="server" />
       
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Compartment No" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
        <asp:Label ID="label12" ForeColor="Black" Text='<%# Eval("Compartment_No") %>' runat="server" />
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

    <div class="row justify-content-center" style="text-align:right" id="divlatlongmandal" runat="server">
         <div class="col-md-12">
     <div class="table-responsive">
     <div class="headertable">
     <asp:GridView ID="GridView7" runat="server" class="grid" AutoGenerateColumns="False"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" > 
      <Columns>
    <asp:TemplateField HeaderText="S.No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label0" runat="server" ForeColor="Black" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>

   <asp:TemplateField HeaderText=" Benficiary Id" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label1" runat="server" Text='<%# Eval("benficiary_id") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
  <asp:TemplateField HeaderText=" ITDA Name" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label2" runat="server" Text='<%# Eval("ITDA_NAME") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText="District" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label3" runat="server" Text='<%# Eval("District") %>'></asp:Label>
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Mandal" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label4" runat="server" Text='<%# Eval("Mandal") %>'></asp:Label>
       
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Gram Panchayat" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label5" runat="server" Text='<%# Eval("Gram_Panchayat") %>'></asp:Label>
       
    </ItemTemplate>
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Village" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label Class="txt" ID="label6" runat="server" Text='<%# Eval("Village") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
   <asp:TemplateField HeaderText="Habitation" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label7" runat="server" Text='<%# Eval("Habitation") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label8" runat="server" Text='<%# Eval("Rofr_Pattadaar") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
           <asp:TemplateField HeaderText="Rofr Pattadaar" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
       
            <asp:Label Class="txt" ID="label9" runat="server" Text='<%# Eval("ROFR_PATTANO") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>
   <%-- <asp:TemplateField HeaderText="Aadhaar NO" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
     <ItemTemplate>
            <asp:Label Class="txt" ID="label10" runat="server" Text='<%# Eval("AADHAAR_NO") %>'></asp:Label>
       
    </ItemTemplate>
    </asp:TemplateField>--%>
<asp:TemplateField HeaderText="Father Name" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
            <asp:Label ID="label11" ForeColor="Black" Text='<%# Eval("Father_Name") %>' runat="server" />
       
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Compartment No" ItemStyle-Width="150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
    <ItemTemplate>
        <asp:Label ID="label12" ForeColor="Black" Text='<%# Eval("Compartment_No") %>' runat="server" />
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
