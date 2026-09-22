<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="LotLogs_Phases_Report.aspx.cs" Inherits="ROFR.pages.LotLogs_Phases_Report" EnableEventValidation ="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #1F5C99;}

.headertable .aftr th{position: sticky;top: 49px;}

     
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
    <div class="panel panel-body">
        <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">LOTLONGS PHASES REPORT</h5></div>
                  <div class="col-md-4 text-right ">
               <asp:LinkButton ID="btn_back_dist" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_dist">Back</asp:LinkButton>
               <asp:LinkButton ID="btn_back_mandal" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_mandal">Back</asp:LinkButton>
                  <asp:LinkButton ID="btn_back_village" runat="server"  Font-Underline="true" Visible="false" OnClick="Get_back_village">Back</asp:LinkButton>
                  <asp:LinkButton ID="latlongback" runat="server"  Font-Underline="true" Visible="false" OnClick="latlongback_Click">Back</asp:LinkButton>
                      </div>
            <div >
                     <asp:Button ID="btn_uploadDISTRICTWISE" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Excel_uploadDist__Click" runat="server" Text="Excel" />&nbsp;&nbsp;

                     <asp:Button ID="btn_notupload" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_notupload_Click" runat="server" Text="Not Uploaded Data" Visible="true" />
            </div>
              <div class="col-auto">

              <asp:Button ID="dwnld_latlongs" class="btn btn-sm btn-success"  AutoPostBack="true"  OnClick="Down_LessThan_4" runat="server" Text="Download Latlongs Lessthan 4" />
              <asp:Button ID="btn_Mand_Excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Mandalwise_Not_DownLoad" runat="server" Text="Excel" Visible="false"/>
              <asp:Button ID="btn_Village_Excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Village_LotLongs_Download" runat="server" Text="Excel"  Visible="false"/>
              <asp:Button ID="btn_Not_Village_Excel" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="Village_LotLongs_Not_Download" runat="server" Text="Excel" Visible="false"/>
              <div class="col-md-3 ml-0 mr-0">
                   <asp:Button ID="btn_img_pdf" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_img_pdf_Click" runat="server" Text="PDF"  Visible="false"/>
                    </div>
                      <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_uploadMandalWise" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Excel_uploadMand_Click"  runat="server" Text="EXCEL" Visible="false"/>
                    </div>
                    <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btn_UploadvillageWise" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="btn_Excel_uploadVill_Click"  runat="server" Text="EXCEL" Visible="false"/>
                    </div>
              </div>
             <div class="col-auto">

                   
                   
                      </div>

        </div>
        <br />
         
         <div class="row justify-content-center">
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="Select:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged">
                         <asp:ListItem  Value="ALL">ALL</asp:ListItem>
                                                   <asp:ListItem  Value="PHASE-I">PHASE-I</asp:ListItem>
                                                   <asp:ListItem  Value="PHASE-II">PHASE-II</asp:ListItem>
                                                  
                          </asp:DropDownList>
                    </div>
              
           </div>
        </div>
   </div>
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

         <div class="row justify-content-center" style="text-align:right" id="div_dist" runat="server">
           <div class="col-md-9">
        <div class="table-responsive">
       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
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
              <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("itda_name")+","+Eval("district")+"-"+ "1"%>' CausesValidation="false" OnClick="LinkDistrict_OnClick"><%# Eval("district") %></asp:LinkButton>
               </div>
            </ItemTemplate>
        </asp:TemplateField>
          
       <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl2" class="txt" Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
       <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

       <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

       <asp:TemplateField HeaderText="LATLONGS LESSTHAN 4" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl5" ForeColor="Red" Font-Bold="True" Text='<%# Eval("LATLONGS_LESSTHAN_4") %>' runat="server" />
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

         <div class="row justify-content-center" style="text-align:right" id="div_mandal" runat="server">
           <div class="col-md-9">
        <div class="table-responsive">
       <div class="headertable">
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
      <asp:TemplateField HeaderText=" MANDAL"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
            <div style="text-align:left">
            <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("mandal") %>' Visible="false"></asp:Label>
             <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")%>' CausesValidation="false" OnClick="LinkMandal_OnClick" ><%# Eval("mandal") %></asp:LinkButton>
            </div>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl1" Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
      <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

      <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" Visible="false" />
              <asp:LinkButton ID="lbl3Buttonmand" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")+","+ "Plots not having latlongs"%> ' CausesValidation="false" OnClick="MandalLevel_NotHaving_OnClick"><%# Eval("plots_not_having_latlongs") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="LATLONGS LESSTHAN 4" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("LATLONGS_LESSTHAN_4") %>' runat="server" Visible="false"/>
           <asp:LinkButton ID="lbl4LinkButton" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("mandal")+","+ "LATLONGS LESSTHAN4"%> ' CausesValidation="false"><%# Eval("LATLONGS_LESSTHAN_4") %></asp:LinkButton>
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
           <div class="col-md-9">
        <div class="table-responsive">
       <div class="headertable">
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
     <asp:TemplateField HeaderText=" VILLAGE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("village") %>' ForeColor="Red" ></asp:Label>
               </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
     <asp:TemplateField HeaderText="TOTAL PLOTS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("total_plots") %>' runat="server"  />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

     <asp:TemplateField HeaderText="LATLONGS UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("plots_having_latlongs") %>' runat="server" Visible="false" />
                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Green"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("village")+","+ "HAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("plots_having_latlongs") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 

     <asp:TemplateField HeaderText="LATLONGS NOT UPLOADED" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl3" ForeColor="Red" Font-Bold="True" Text='<%# Eval("plots_not_having_latlongs") %>' runat="server" Visible="false" />
         <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("village")+","+ "NOTHAVING"%> ' CausesValidation="false"   OnClick="Rejected_onclick" ><%# Eval("plots_not_having_latlongs") %></asp:LinkButton>
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
      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"> 
                    <Columns> 
                        
       <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black"  Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

       <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
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
                <div style="text-align:left">
                 <asp:Label ID="lbl5" ForeColor="Black"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
                </div>
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
           <div class="col-md-9">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"> 
                    <Columns>   
                                
    <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" ItemStyle-Width = "100"  HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black"  Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

    <asp:TemplateField HeaderText=" Benficiary Id"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
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
                <div style="text-align:left">
                 <asp:Label ID="lbl4" ForeColor="Black"  Text='<%# Eval("Compartment_No") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

   <asp:TemplateField HeaderText="ROFR Pattano." ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl5" ForeColor="Black"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField> 

   <asp:TemplateField HeaderText="Extent PlotArea" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="Black"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>

  <%-- <asp:TemplateField HeaderText="Latitude" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
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
        </asp:TemplateField>--%>
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
         <div class="col-md-10">
     <div class="table-responsive">
     <div class="headertable">
     <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" > 
      <Columns>
    <asp:TemplateField HeaderText="S.No" HeaderStyle-ForeColor="White" ItemStyle-Width="150" HeaderStyle-CssClass="header-center">
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
</asp:Content>
