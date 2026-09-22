<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Villagewise_Farmer_Images_NDetails.aspx.cs" Inherits="ROFR.pages.Villagewise_Farmer_Images_NDetails"  EnableEventValidation="false"%>
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
              
               <div class="col-md-4"> <h5 class="text-center text-success mb-1 mt-1">FARMER IMAGES UPLOADED DETAILS</h5></div>
              <div class="col-md-4 text-right ">
                   <asp:LinkButton ID="back_btn" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="Back_Click">Back</asp:LinkButton>
               
                   </div>s
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                   <%-- <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>


            </div>
        </div>
            <div class="row mb-1 mt-1 justify-content">
               <div class="col-md-1 text-right">
                   
                <asp:Label ID="Label1" runat="server" Text="ITDA:" Font-Bold="true"></asp:Label>
               </div>
               <div class="col-md-2"> 
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
               </div>
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="District:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                <div class="col-md-1 text-right" >

                 <asp:Label ID="Label3" runat="server" Text="Mandal:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_mandal" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                  <div class="col-md-1 text-right" >

                 <asp:Label ID="Label4" runat="server" Text="Village:" Font-Bold="true"></asp:Label>
                

            </div>
                <div class="col-md-2">

                 <asp:Label ID="lbl_village" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
        </div>
  <div class="row justify-content-center" style="text-align:center">
           <div class="col-md-10">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   > 
                    <Columns>   
                                
                        
                       

                          <asp:TemplateField HeaderText="Beneficiary Id "   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>' ForeColor="Black"></asp:Label>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                   
                          <asp:TemplateField HeaderText="Farmer Name"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Rofr_Pattadaar") %>' runat="server" />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Father Name" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
          </div>

            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Sub Caste" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:left">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Sub_Caste") %>' runat="server"  />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Aadhaar No."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                   <div style="text-align:center">
                 <asp:Label ID="lbl2" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server"  />
          </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Farmer Image" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 
                    <asp:Image ID="Image1" runat="server"  ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' Width="50px" Height="50px"/>
                    
                 
          
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
</asp:Content>
