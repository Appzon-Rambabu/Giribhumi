<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER_BNK.Master" AutoEventWireup="true" CodeBehind="ViewAdharwiseDetails_Bnk.aspx.cs" Inherits="ROFR.pages.ViewAdharwiseDetails_Bnk" %>
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
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#1F5C99;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="margin-top:150px;">
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-between">
                                        <h4 class="text-dark">View Aadharwise Benificiary Plot Details</h4>
                                      <%--<input id="btnprint" type="button" onclick="PrintDiv()" value="Print" class="btn btn-info"/>--%>
                                    </div>
                                </div>
                            </div>


     <div class="container-fluid">
          <div class="row" style="margin-top:0px;">
              
            <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">

                   

                <div id="printarea">

             
                <div class="panel panel-body" style="margin-top:0px;">

             
                <div class="row mb-1 mt-1 justify-content-left">
               <div class="col-md-1 text-left">
                   
                <asp:Label ID="Label1" runat="server" Text="Benficiary ID:" ></asp:Label>
               </div>
               <div class="col-md-2"> 
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" ></asp:Label>
               </div>
           <%-- <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text=":" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black"></asp:Label>
                

            </div>--%>
               
        </div>

                  <div class="row justify-content-center">
                    <div class="col-md-12">
                      <div class="table-responsive">
                          <div class="headertable">
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table  table-bordered text-center  "  >  
                   
                                                                                 <Columns>   

                                                                                       <asp:TemplateField HeaderText="Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl0"  Font-Bold="True" Text='<%# Eval("ID") %>'  runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Benificiary Id" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
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
                                                                                           <asp:TemplateField HeaderText="GramPanchayat" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl4" runat="server"  Font-Bold="True" Text='<%# Eval("Gram_Panchayat") %>' ></asp:Label>
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
                                                                                        <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Compartment_No") %>' runat="server"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                                                                     
                                                                                        <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                      
                  <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>' runat="server"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                                                                                      <asp:TemplateField HeaderText="Extent Plot Area" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>' runat="server" />
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
                                                        
                         <asp:TemplateField HeaderText="Aadhaar No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl8" runat="server"  Font-Bold="True" Text='<%# Eval("AADHAAR_NO") %>' ></asp:Label>
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

          

                    </div>

            </main>
          </div>
        </div>
</asp:Content>

