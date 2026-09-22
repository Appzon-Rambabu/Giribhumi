<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="ITDAWISE_BENICIARY_MASTER.aspx.cs" Inherits="ROFR.pages.ITDAWISE_BENICIARY_MASTER" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #000000 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color:#008500;}

.headertable .aftr th{position: sticky;top: 49px;}
h5.thick {
  font-weight: bold;
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
                <div class="col-md-4">
               <span style="color: red">NOTE: Click on Excel to download all records at once</span> 
                 </div>
              <div class="col-md-4">
                  <h5 class="text-center text-success mb-2 mt-3 thick" id="Title_Header">ITDA WISE FARMER DETAILS</h5>
                  </div>
               
            <div class="col-md-4">
                <div class="row d-flex justify-content-end">
                    <div class="col-md-5  ml-0 mr-0">
                      <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />&nbsp;&nbsp
					   <asp:Button ID="Button1" class="btn btn-sm btn-success" AutoPostBack="true" OnClick="Excel_Click" runat="server" Text="EXCEL" />&nbsp;&nbsp
                      
                        
                    </div>
					

                    <div class="col-md-4 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                          <asp:TextBox ID="txtSearch" runat="server"  class="form-control"  placeholder="PATTADAAR..." autocomplete="off"  ></asp:TextBox>
                    </div>
					
                     <div class="col-md-3 ml-0 mr-0">
                       <%--  <button type="button" class="btn btn-sm btn-success"><i class="fa fa-search"></i> Search</button>--%>
                       <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" style="height: 25px !important;padding: 1px 10px  !important;" OnClick="txtSearch_Click" AutoPostBack="true"  runat="server" Text="Search" />
                    </div>
                
                </div>


            </div>

        </div>

       <asp:UpdatePanel runat="server">
        <ContentTemplate>
         
       <div class="row justify-content-left">
               
              <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-3 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="ITDA:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
              
           </div>
              

      
        </div>
            <div class="col-md-3">
                <div class="row d-flex justify-content-center" id="select_records" runat="server">
                    <div class="col-md-7 text-center ml-0 mr-0">
                        <asp:Label ID="txt_records" runat="server" Text="Select To View Records: "></asp:Label>&nbsp<%--<asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    </div>

                    <div class="col-md-5 ml-0 mr-0">
                        <asp:DropDownList ID="ddl_records" Style="width: 100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
              </div>
        
         <br />
          <div class="row justify-content-center">
         <div class="col-md-12">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid"  
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"  style="width:100%;">  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText="S.NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>' ForeColor="Black"></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="BENEFICIARY ID"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl101"  Font-Bold="True" Text='<%# Eval("benficiary_id") %>'  runat="server" ForeColor="Black"/>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                            <asp:TemplateField HeaderText="ITDA NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("ITDA_NAME") %>' runat="server" ForeColor="Black"  />
                      </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="DISTRICT"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl3"  Font-Bold="True" Text='<%#Eval("District")%>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="MANDAL" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Mandal")%>' runat="server" ForeColor="Black" />
           </div>
                      </ItemTemplate>
        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="VILLAGE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Village") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="HABITATION"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6" Font-Bold="True" Text='<%# Eval("Habitation") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>  
                     
                      
                   
                      
                         <asp:TemplateField HeaderText="ROFR PATTADAAR"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROFR_PATTADAAR") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="FATHER NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Father_Name") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SUB CASTE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("SUB_CASTE") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                       
                       
                        
                         <asp:TemplateField HeaderText="AADHAR NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Aadhaar_NO") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BANK ACCOUNT NO."  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("BankAccountNo") %>' runat="server" ForeColor="Black"/>
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IFSC CODE"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:right">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("IfscCode") %>' runat="server" ForeColor="Black" />
                     </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BANK NAME"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:left">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("BankName") %>' runat="server" ForeColor="Black"/>
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

            </ContentTemplate>
        </asp:UpdatePanel>
         </div>
            
</asp:Content>
