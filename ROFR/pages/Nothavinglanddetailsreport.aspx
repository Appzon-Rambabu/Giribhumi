<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Nothavinglanddetailsreport.aspx.cs" Inherits="ROFR.pages.Nothavinglanddetailsreport" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#008500;}

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
     <script type="text/javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function() { void (0) }
 </script>
 
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
           <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
    
    <div class="panel panel-body" style="margin-top:-10px;">
          

        
          <div class="row mb-1 mt-1 justify-content-end">
       
              <div class="col-md-4">
                  <h5 class="text-center text-success mb-2 mt-3 thick" id="Title_Header">Beneficiarywise Not Having Land Details Report</h5>
                  </div>
                 
            <div class="col-md-4">
                <div class="row d-flex justify-content-end">
                      <div class="col-md-5 text-center ml-0 mr-0">
                   <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />
                      <asp:Button ID="Button1" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="ExportToExcel"  runat="server" Text="EXCEL" />
                         <asp:Button ID="Button3" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="ExportToExcelDetails"  runat="server" Text="EXCEL" Visible="false" />
                          <asp:Button ID="Button2"  AutoPostBack="true"  OnClick="Backtonohavingcounts"  runat="server" Text="Back" Visible="false" />
                    </div>

                     <div class="col-md-2 ml-0 mr-0">
                        
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                          
                    </div>
                
                </div>
            </div>

        </div>
       

       
       <div class="row mt-2 mb-3 justify-content-left"> <span style="color: red"></span></div>
         <br />
          <div class="row justify-content-center">
         <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
         
   <asp:GridView ID="GridView1" HeaderStyle-BackColor="#008500" HeaderStyle-ForeColor="#FFFFFF" class="grid"
    runat="server" AutoGenerateColumns="false" >
    <Columns>
         <asp:TemplateField HeaderText="S.NO"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                     <asp:Label ID="lblSRNO" runat="server" Text='<%#Eval("itda_srno")  %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>         

        <asp:TemplateField HeaderText="ITDA Name"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label   ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>'  ></asp:Label>
                     
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="District" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("DISTRICT") %>' runat="server"  />
 
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField HeaderText="Total Beneficiaries not having land" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_Beneficiaries_not_having_land") %>' runat="server"  />
                 </div>
            </ItemTemplate>
        </asp:TemplateField> 
      <asp:TemplateField HeaderText="Today Updated" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right"> 
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("Today_Updated") %>' runat="server"  />
 </div>
            </ItemTemplate>
        </asp:TemplateField> 
          <asp:TemplateField HeaderText="Need To Update" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right"> 
                <asp:Label ID="lbl4" ForeColor="Red" Font-Bold="True" Text='<%# Eval("Need_To_Update") %>' runat="server" Visible="false" />
  <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ITDA_NAME") + "," +Eval("DISTRICT")%>' CausesValidation="false" OnClick="Rejected_onclick"><%# Eval("Need_To_Update") %></asp:LinkButton>
                    </div>
          
            </ItemTemplate>
        </asp:TemplateField> 
       
    </Columns>
</asp:GridView>
           <asp:GridView ID="GridView2" HeaderStyle-BackColor="#9AD6ED" HeaderStyle-ForeColor="#FFFFFF" class="grid"
    runat="server" AutoGenerateColumns="false" >
    <Columns>
         <asp:TemplateField HeaderText="S.No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  ForeColor="Black" Text='<%# Container.DataItemIndex + 1 %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="benficiary_id" HeaderText="Benficiary Id" ItemStyle-Width="150" />
         <asp:BoundField DataField="ITDA_NAME" HeaderText="Itda Name" ItemStyle-Width="150" HeaderStyle-HorizontalAlign="Center" />
         <asp:BoundField DataField="DISTRICT" HeaderText="District" ItemStyle-Width="150" />
         <asp:BoundField DataField="Mandal" HeaderText="Mandal" ItemStyle-Width="150" />
         <asp:BoundField DataField="Village" HeaderText="Village" ItemStyle-Width="150" />
         <asp:BoundField DataField="Habitation" HeaderText="Habitation" ItemStyle-Width="150" />
         <asp:BoundField DataField="ROFR_PATTADAAR" HeaderText="Rofr Pattadaar" ItemStyle-Width="150" />
         <asp:BoundField DataField="Father_Name" HeaderText="Father Name" ItemStyle-Width="150" />
         <asp:BoundField DataField="AADHAAR_NO" HeaderText="Aadhaar No" ItemStyle-Width="150" />
         <asp:BoundField DataField="BankAccountNo" HeaderText="Bank AccountNo" ItemStyle-Width="150" />
         <asp:BoundField DataField="IfscCode" HeaderText="Ifsc Code" ItemStyle-Width="150" />
         <asp:BoundField DataField="BankName" HeaderText="Bank Name" ItemStyle-Width="150" />
    </Columns>
</asp:GridView>
             </div>
              </div>
        </div>
        </div>
                
         </div>
              </ContentTemplate>
        </asp:UpdatePanel>  
</asp:Content>
