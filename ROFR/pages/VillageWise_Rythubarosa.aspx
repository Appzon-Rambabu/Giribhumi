<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="VillageWise_Rythubarosa.aspx.cs" Inherits="ROFR.pages.VillageWise_Rythubarosa" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
/*.headertable th, .headertable td { padding: 8px 16px; } */
.headertable th { position: sticky; top: -10px; background-color: #008500;}

.headertable .aftr th{position: sticky;top: 49px;}
h5.thick {
  font-weight: bold;
}
     
.grid td  
{
    padding: 10px;
    width: 3%;
  
}

 .grid th  
{
     padding: 10px 5px;
     height:5%;
     padding-top:3px
}

    </style>
	
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

     <div class="panel panel-body"> 
          
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
         <div class="row mb-1 mt-1 justify-content-end">
               <div class="col-md-4"></div>
               <div class="col-md-4"> 
			   <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">VILLAGE WISE RYTHU BHAROSA PAYMENT STATUS 2019</h5>
			   </div>
                <div class="col-md-4 text-left">
                         <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />&nbsp;&nbsp;
				
                   <asp:LinkButton ID="btn_back" runat="server"  Font-Underline="true"  OnClick="Get_back">Back</asp:LinkButton>
               
                
                   </div>
              <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                   <%-- <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>--%>
                </div>


            </div>
        </div>
             <div class="row  justify-content-center"  id="div_lbl" runat="server">
        <div class="col-md-8">  
            <div class="row">
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
        </div>
            </div></div>

          <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>

  <div class="row justify-content-center" style="text-align:right">
           <div class="col-md-8">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="grid"  
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
                       

                          <asp:TemplateField HeaderText=" Village "  ItemStyle-Width = "150"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("VILLAGE") %>' ForeColor="Black"></asp:Label>
                   
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Payment Success" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Payment_Success") %>' runat="server"  Visible="false"/>
   <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Green" Font-Underline="true"    CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("Payment_Success") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Payment Rejected" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl2" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Payment_Rejected") %>' runat="server" Visible="false" />
          <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="true"    CommandName="MyUpdate" CommandArgument='<%#Eval("VILLAGE")+","+ "1"%>' CausesValidation="false"   OnClick="link1_onclick" ><%# Eval("Payment_Rejected") %></asp:LinkButton>
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

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
