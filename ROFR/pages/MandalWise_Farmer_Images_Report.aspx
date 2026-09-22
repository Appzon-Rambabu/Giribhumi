<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="MandalWise_Farmer_Images_Report.aspx.cs" Inherits="ROFR.pages.MandalWise_Farmer_Images_Report"  EnableEventValidation="false"%>
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;"> 
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
           
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
            
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">MANDAL WISE FARMER IMAGES REPORT</h5></div>
               <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="back_btn" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="Back_Click">Back</asp:LinkButton>
               
                   </div>
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                   <%-- <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>


            </div>
        </div>
            <div class="row mb-1 mt-1 justify-content">
               <div class="col-md-1 text-right" >
                   
                <asp:Label ID="Label1" runat="server" Text="ITDA:" Font-Bold="true"></asp:Label>
               </div>
               <div class="col-md-2 "> 
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
               </div>
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="District:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
        </div>
  <div class="row justify-content-center" style="text-align:right">
           <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                       

                          <asp:TemplateField HeaderText=" Mandal "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("Mandal") %>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="LinkButton0" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"    CommandName="MyUpdate" CommandArgument='<%#Eval("MANDAL")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("MANDAL") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Total Farmers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Images Uploaded" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Images_Uploaded") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Images Not Uploaded" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Images_Not_Uploaded") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Images Uploaded From Aadhar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Aadhaar_Service_Image_Uploaded") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Images Not Uploaded from Aadhar" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Aadhaar_Service_Image_not_Uploaded") %>' runat="server" />
         
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
