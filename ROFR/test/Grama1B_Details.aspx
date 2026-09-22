<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="Grama1B_Details.aspx.cs" Inherits="ROFR.test.Grama1B_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#007405;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>
   <%--  <style>
   
  
    .font-telugu {
      font-family: 'Ramabhadra', sans-serif;
      text-shadow: 2px 2px rgba(0, 0, 0, 0.3);
      font-size: 30px;
    }
     .table  {
   border:1px solid #000000 !important;
       }
  
   
    .table th {
      text-align: center;
       background-color:none !important;
  
       }
  
   .table tr {
     
     color:black;
       }
  
  
    .bg-nav{
      background-color: #1F5C99 !important;
    }
   
  </style>--%>
      <script type="text/javascript">

            function PrintDiv() {
                var divToPrint = document.getElementById('printarea');
                var popupWin = window.open('', '_blank', 'width=300,height=400,location=no,left=200px');
                popupWin.document.open();
                popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
                popupWin.document.close();
            }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="margin-top:1px;">
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-between">
                                        <h4 class="text-dark">Details Of Land Records Grama 1B Namuna</h4>
                                      <input id="btnprint" type="button" onclick="PrintDiv()" value="Print" class="btn btn-info"/>
                                    </div>
                                </div>
                            </div>

    <div class="content-area">
     <div class="container-fluid">
          <div class="row" style="margin-top:0px;">
              
            <main role="main" class="col-md-12 ml-sm-auto col-lg-12 px-4">

                   

                <div id="printarea">

             
                <div class="panel panel-body" style="margin-top:0px;">

             
                <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-1 text-right">
                   
                <asp:Label ID="Label1" runat="server" Text="ITDA:" ></asp:Label>
               </div>
               <div class="col-md-2"> 
                    <asp:Label ID="lbl_itda" runat="server" Text=""  ></asp:Label>
               </div>
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="District:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ></asp:Label>
                

            </div>
                <div class="col-md-1 text-right">

                 <asp:Label ID="Label3" runat="server" Text="Mandal:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_mandal" runat="server" Text="" ></asp:Label>
                

            </div>
                 <div class="col-md-1 text-right">

                 <asp:Label ID="Label4" runat="server" Text="Village:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_village" runat="server" Text=""  ></asp:Label>
                

            </div>
        </div>

                  <div class="row justify-content-center">
                    <div class="col-md-12">
                      <div class="table-responsive">
                            <div class="headertable">
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   > 
                    <Columns>   
                                
                        
                       

                          <asp:TemplateField HeaderText="S.No"   HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:center">
                <asp:Label ID="lbl3" Text='<%# Eval("Sno") %>' runat="server"  ForeColor="Black" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="ROFR Pattadar Name"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Rofr_Pattadaar") %>' runat="server" ForeColor="Black"  />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Father/Husband Name"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl7" Text='<%# Eval("Father_Name") %>' runat="server" ForeColor="Black"  />
         </div>
            </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField HeaderText="ROFR Patta No."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl8"   Text='<%# Eval("Rofr_Pattano") %>' runat="server" ForeColor="Black"  />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Compartment No."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl9"   Text='<%# Eval("Compartment_No") %>' runat="server" ForeColor="Black"  />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Landn Classification Name"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl10"   Text='<%# Eval("Land_Classification_Name") %>' runat="server" ForeColor="Black"  />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Extent PlotArea (Acres/Cents)"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl11"   Text='<%# Eval("ExtentPlotArea") %>' runat="server" ForeColor="Black" />
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
        </div>
</asp:Content>
