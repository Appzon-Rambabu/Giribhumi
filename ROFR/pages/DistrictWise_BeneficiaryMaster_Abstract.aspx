<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="DistrictWise_BeneficiaryMaster_Abstract.aspx.cs" Inherits="ROFR.pages.DistrictWise_BeneficiaryMaster_Abstract"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:  #008500;}

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
         <div class="col-md-4">
               <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">DISTRICT WISE FARMER REPORT</h5>
			  </div>
         <div class="col-md-4  text-right ">
		 <input type="Button"  runat="server" id="Button1"  class="btn btn-sm btn-success" value="Print" onclick="PrintGridData()" />
          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
              </div>
            </div>
        </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="grid" 
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
                        
                         <asp:TemplateField HeaderText=" ITDA "   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("Itda_Name") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText=" District "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("District") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("Itda_Name")+","+Eval("District")+"-"+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("District") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Farmers as per record " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl31" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_bneficiaries_dept") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Farmers as per Giribhumi" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl3" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
  
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="No of Farmers Having Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Total_Received") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>  
                          <asp:TemplateField HeaderText="No of Farmers Not Having Aadhar Numbers " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl9" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnotavaliable") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No of Farmers Having Valid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl7" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Adhharisvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField HeaderText="No of Farmers Having Invalid Aadhar Numbers" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl8" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Adhharnoinvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                      
                        <asp:TemplateField HeaderText="No of Farmers Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl10" ForeColor="Green" Font-Bold="True" Text='<%# Eval("Bankavaliable") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No of Farmers Not Having Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl11" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Banknotavaliable") %>' runat="server" />
        
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="No of Farmers Having Invalid Bank Details (Bank A/c + IFSC Code)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl12" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Bankinvalid") %>' runat="server" />
         
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="No of Farmers with full  details( Bank A/c + IFSC Code + Aadhar No)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl13" ForeColor="Green" Font-Bold="True" Text='<%# Eval("FullBankDetails") %>' runat="server" />
          <asp:LinkButton ID="LinkButton12" runat="server" Font-Bold="True"  ForeColor="Green" Font-Underline="True" CommandName="MyUpdate" CommandArgument='<%#Eval("District")+","+ "15"%>' CausesValidation="false" Visible ="false"  OnClick="link_onclick" ><%# Eval("Banknotavaliable") %> </asp:LinkButton>
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
        
</asp:Content>
