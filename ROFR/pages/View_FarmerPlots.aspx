<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="View_FarmerPlots.aspx.cs" Inherits="ROFR.pages.View_FarmerPlots"  EnableEventValidation="false"%>
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
      <%-- <style>
   
  
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
      <div style="margin-top:150px;">
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-between">
                                        <h4 class="text-dark">Farmer Plot Details</h4>
                                      <input id="btnprint" type="button" onclick="PrintDiv()" value="Print" class="btn btn-info"/>
                                    </div>
                                </div>
                            </div>


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
                    <asp:Label ID="lbl_itda" runat="server" Text="" ForeColor="Black" ></asp:Label>
               </div>
            <div class="col-md-1 text-right">

                 <asp:Label ID="Label2" runat="server" Text="District:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_dist" runat="server" Text="" ForeColor="Black"></asp:Label>
                

            </div>
                <div class="col-md-1 text-right">

                 <asp:Label ID="Label3" runat="server" Text="Mandal:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_mandal" runat="server" Text="" ForeColor="Black" ></asp:Label>
                

            </div>
                 <div class="col-md-1 text-right">

                 <asp:Label ID="Label4" runat="server" Text="Village:" ></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_village" runat="server" Text="" ForeColor="Black" ></asp:Label>
                

            </div>
        </div>

                  <div class="row justify-content-center">
                    <div class="col-md-12">
                      <div class="table-responsive">
                          <div class="headertable">
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" > 
                    <Columns>   
                                
                        
                                 <asp:TemplateField HeaderText="S.NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server" Text='<%# Eval("sno") %>' ForeColor="Black" ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="ID"   HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"   Text='<%# Eval("Id") %>'  runat="server" ForeColor="Black" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                             <asp:TemplateField HeaderText="BENEFICIARY ID"   HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1" Text='<%# Eval("benficiary_id") %>'  runat="server" ForeColor="Black" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="ITDA NAME"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                  <asp:Label ID="lbl2"   Text='<%# Eval("ITDA_NAME") %>' runat="server" ForeColor="Black"  />
                      </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="DISTRICT"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl3"   Text='<%#Eval("District")%>' runat="server" ForeColor="Black"  />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="MANDAL" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl4"   Text='<%# Eval("Mandal")%>' runat="server" ForeColor="Black" />
           </div>
                      </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GRAM PANCHAYAT"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl5"  Text='<%# Eval("Gram_Panchayat")%>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="REVENUE VILLAGE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("REV_Village") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="VILLAGE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("Village") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="HABITATION"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("Habitation") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="FOREST DIVISION" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Forest_Division") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST RANGE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Forest_Range") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="FOREST BEAT"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Forest_Beat") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FOREST BLOCK"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Forest_Block") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="COMPARTMENT NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Text='<%# Eval("Compartment_No") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PLOT NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Plot_No") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="EXTENT PLOT AREA"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("ExtentPlotArea") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ROFR PATTA NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("ROFR_PATTANO") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="ROFR PATTADAAR"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" ForeColor="Black"  />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER NAME"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("FATHER_NAME") %>' runat="server" ForeColor="Black"  />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SUB CASTE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("SUB_CASTE") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CULTIVATOR NAME" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("CULTIVATOR_NAME") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                        
                         <asp:TemplateField HeaderText="AADHAR NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("Aadhaar_NO") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BANK ACCOUNT NO."  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("BankAccountNo") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IFSC CODE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("IfscCode") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BANK NAME"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("BankName") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="UNCULTIVABLE LAND"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Uncultivable_Land") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CULTIVABLE LAND"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Cultivable_Land") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PATTA INAM/GOVT"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6" Text='<%# Eval("PATTA_INAMGOVT") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="DRYID ONECROP/TWO CROP"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("DRYID_ONECROP_TWO_CROP") %>' runat="server" ForeColor="Black"  />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="WATER SOURCE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("WATER_SOURCE") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT IRRIGATED"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("EXTENT_IRRIGATED") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT UNDER CULTIVATOR"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("EXTENT_UNDER_CULTIVATOR") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LAND CLASSIFICATION"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("Land_Classification_Name") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="HOLDING NATURE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("HOLDING_NATURE") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="EXTENT"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("EXTENT") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="NET SOWN AREA"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("NET_SOWN_AREA") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="MONTH OF CULTIVATION"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"   Text='<%# Eval("MONTH_OF_CULTIVATION") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CROP"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("CROP") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="EXTENT SINGLE"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("SINGLE") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="EXTENT MIXED"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Text='<%# Eval("MIXED") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField HeaderText="EXTENT TOTAL"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("TOTAL") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="FIRST CROP"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("FIRST_CROP") %>' runat="server" ForeColor="Black"  />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SECOND THIRD CROP"  HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Text='<%# Eval("SECOND_THIRD_CROP") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CROP YIELD" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"   Text='<%# Eval("CROP_YIELD") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="REMARKS" HeaderStyle-ForeColor="Black" HeaderStyle-CssClass="header-center" HeaderStyle-BackColor="White">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="Black"  Text='<%# Eval("REMARKS") %>' runat="server" />
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
