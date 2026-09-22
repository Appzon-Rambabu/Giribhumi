<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="VillageWise_BeneficiaryMaster_Details.aspx.cs" Inherits="ROFR.pages.VillageWise_BeneficiaryMaster_Details"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
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
        function noBack()
         {
             window.history.forward()
         }
        noBack();
        window.onload = noBack;
        window.onpageshow = function(evt) { if (evt.persisted) noBack() }
        window.onunload = function() { void (0) }
    </script>
	
	<%--for print button--%>
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
          <%-- <asp:Button ID="btnexcel" runat="server" Text="Excel" />--%>
           
         <div class="row mb-1 mt-1 justify-content-end">
         <div class="col-md-4"> 
		 <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">VILLAGE WISE FARMER DETAILS</h5>
		 </div>
                <div class="col-md-4 text-right ">
				 <input type="Button"  runat="server" id="Button1"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />
				   <asp:Button ID="btnsubmit" class="btn btn-sm btn-success"  AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                   <asp:LinkButton ID="back_btn" runat="server"  Font-Bold="true"  Font-Underline="true"  OnClick="Back_Click">Back</asp:LinkButton>
                                 
           </div>
        </div>
            <div class="row mb-1 mt-1 justify-content-end">
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
                <div class="col-md-1 text-right">

                 <asp:Label ID="Label3" runat="server" Text="Mandal:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_mandal" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-1 text-right">

                 <asp:Label ID="Label4" runat="server" Text="Village:" Font-Bold="true"></asp:Label>
                

            </div>
                 <div class="col-md-2">

                 <asp:Label ID="lbl_village" runat="server" Text="" ForeColor="Black" Font-Bold="true"></asp:Label>
                

            </div>
        </div>
    <div class="row" style="text-align:right">
        <div class="table-responsive">

       <div class="headertable">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid"  
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="30px" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server" HorizontalAlign="left" Width="30px" ForeColor="Black"  Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>   
                       

                          <asp:TemplateField HeaderText="ROFR Farmer Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                <asp:Label ID="lbl3" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Rofr_Pattadaar") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Farmer Father Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl6" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Sub Caste" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl7" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Sub_Caste") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Aadhar Number" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:center">
                 <asp:Label ID="lbl8" ForeColor="Black" Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="BankAccount Number " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:center">
                 <asp:Label ID="lbl9" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BankAccountNo") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="IFSC Code" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:center">
                 <asp:Label ID="lbl10" ForeColor="Black" Font-Bold="True" Text='<%# Eval("IfscCode") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Bank Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="lbl11" ForeColor="Black" Font-Bold="True" Text='<%# Eval("BankName") %>' runat="server" />
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
</asp:Content>
