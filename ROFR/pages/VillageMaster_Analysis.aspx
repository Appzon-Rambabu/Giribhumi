<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="VillageMaster_Analysis.aspx.cs" Inherits="ROFR.pages.VillageMaster_Analysis" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #333 !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: #008500;}

.headertable .aftr th{position: sticky;top: 49px;}

     
    </style>
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
                   <h5 class="text-center text-success mb-1 mt-1 thick" id="Title_Header">VILLAGE MASTER</h5>
               </div>
              <div class="col-md-4 text-right ">
                  <div class="d-flex">
                      <div class="col-auto">
                          <div class="d-flex justify-content-end">
                         <input type="Button"  runat="server" id="Btn_Print_District"  class="btn btn-sm btn-success mr-2" value="Print" onclick="PrintGridData()" />&nbsp;&nbsp;
                               <asp:LinkButton ID="btn_back" runat="server"  Font-Underline="true"  OnClick="Get_Mandal">Back</asp:LinkButton>
                  </div>
                  </div>
                      <div class="col-md-9 col-auto ">
                     
                      </div>
                  </div>
                  </div>
        </div>

         <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
	
                   <div class="row  d-flex justify-content-center" id ="Select_Records" runat="server">
               <div class="col-md-4 text-center"><asp:Label ID="txt_records" runat="server" Text="Select Records: " ></asp:Label></div>

           <div class="col-md-2"><asp:DropDownList ID="ddl_records" style="width:70px"  runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="ddlrecords_OnSelectedIndexChanged"></asp:DropDownList></div>
             </div>

    <div class="row" style="text-align:right">
          <div class="table-responsive">

       <div class="headertable">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="grid" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>   
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "10" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("Sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>                                 
                         <asp:TemplateField HeaderText=" LGD DISTRICT CODE "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("LGD_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="REVENUE DISTRICT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:right">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("REV_DISTRICT_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="DISTRICT NAME " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:left">
              <asp:Label  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="LGD MANDAL CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:right">
              <asp:Label  ID="lbl4" runat="server"  Font-Bold="True" Text='<%# Eval("LGD_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="REVENUE MANDAL CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:right">
              <asp:Label  ID="lbl5" runat="server"  Font-Bold="True" Text='<%# Eval("REV_MANDAL_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="MANDAL NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:left">
              <asp:Label  ID="lbl6" runat="server"  Font-Bold="True" Text='<%# Eval("MANDAL_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="LGD VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:right">
              <asp:Label  ID="lbl7" runat="server"  Font-Bold="True" Text='<%# Eval("LGD_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="REVENUE VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:right">
              <asp:Label  ID="lbl8" runat="server"  Font-Bold="True" Text='<%# Eval("REV_VILLAGE_CODE") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="VILLAGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:left">
              <asp:Label  ID="lbl9" runat="server"  Font-Bold="True" Text='<%# Eval("VILLAGE_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="NO OF BEATS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl10" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NO_OF_BEATS") %>' runat="server" />
  <asp:LinkButton ID="LinkButton10" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("LGD_DISTRICT_CODE")+"-"+Eval("LGD_MANDAL_CODE")+"&"+Eval("LGD_VILLAGE_CODE")+","+ "10"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_BEATS") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NO OF HABITATIONS" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
                              <asp:Label ID="lbl11" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("NO_OF_HABITATIONS") %>' runat="server" />
  <asp:LinkButton ID="LinkButton11" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="True"  CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "11"%>' CausesValidation="false"  Visible ="false"  OnClick="link_onclick" ><%# Eval("NO_OF_HABITATIONS") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                            
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#008500" Font-Bold="True" ForeColor="#FFFFFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>
        </div>
           </div></div>
                 </ContentTemplate>
            </asp:UpdatePanel>
                </div>
</asp:Content>
