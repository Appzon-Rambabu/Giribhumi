<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LANDTRANSFER_MASTER.Master" AutoEventWireup="true" CodeBehind="UpdateLtrCases.aspx.cs" Inherits="ROFR.test.UpdateLtrCases" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .min-100 {
            min-width:100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-body" style="margin-top:150px;">
        <h5 class="text-center text-success mb-4">VIEW LTR CASES</h5>
        <div class="row mb-2" id="po" runat="server">
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="ITDA:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_Itda" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_Itda_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div2" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label2" runat="server" Text="DISTRICT:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_mandal" runat="server" Text="MANDAL:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_village" runat="server" Text="VILLAGE:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_hab" runat="server" Text="Habitation:"><asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_hab" Style="width: 100%" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_hab_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

         <br />
       
          <div class="row mb-2 justify-content-center">
                    <div class="col-md-8">
           <div id="dvScroll" class="headertable mt-1">

         <asp:GridView ID="gvCases" DataKeyNames="LTR_ID" runat="server" AutoGenerateColumns="false"
    OnRowEditing="EditCases" OnRowDataBound="RowDataBound" OnRowUpdating="UpdateCases"
    OnRowCancelingEdit="CancelEdit" OnSelectedIndexChanged="gvCases_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" Width="100%">
    <Columns>
         <asp:TemplateField HeaderText="S.no">
                                    <ItemTemplate>
                                        <asp:Label ID="Id" Text='<%#Container.DataItemIndex+1 %>' runat="server" />
                                    </ItemTemplate>
                                      </asp:TemplateField>
       
        <asp:TemplateField HeaderText="LTRP ID">
            <ItemTemplate>
                <asp:Label ID="lblltrpid" runat="server" Text='<%# Eval("LTR_ID")%>'></asp:Label>
            </ItemTemplate>
           
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LTRP NO.">
            <ItemTemplate>
                <asp:Label ID="lblltrp" runat="server" Text='<%# Eval("LTRP_NO")%>'></asp:Label>
            </ItemTemplate>
           <EditItemTemplate>
               <asp:Label ID="txtltrp" runat="server" Text='<%# Eval("LTRP_NO")%>'></asp:Label>
               <%--<asp:TextBox ID="txtltrp" runat="server" Text='<%# Eval("LTRP_NO")%>'></asp:TextBox>--%>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="R.S.NO">
            <ItemTemplate>
                <asp:Label ID="lblrsno" runat="server" Text='<%# Eval("RS_NO")%>'></asp:Label>
            </ItemTemplate>
           <EditItemTemplate>
               <asp:Label ID="txtrsno" runat="server" Text='<%# Eval("RS_NO")%>'></asp:Label>
              <%-- <asp:TextBox ID="txtrsno" runat="server" Text='<%# Eval("RS_NO")%>'></asp:TextBox>--%>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Extent">
            <ItemTemplate>
                <asp:Label ID="lblextent" runat="server" Text='<%# Eval("EXTENT")%>'></asp:Label>
            </ItemTemplate>
           <EditItemTemplate>
                <asp:Label ID="txtextent" runat="server" Text='<%# Eval("EXTENT")%>'></asp:Label>
              <%-- <asp:TextBox ID="txtextent" runat="server" Text='<%# Eval("EXTENT")%>'></asp:TextBox>--%>
            </EditItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="CASE LEVEL">
         <ItemTemplate>
                <asp:Label ID="lblclevel" runat="server" Text='<%# Eval("STATUS")%>'></asp:Label>
            </ItemTemplate>
         <EditItemTemplate>
              <asp:Label ID="txtclevel" runat="server" Text='<%# Eval("STATUS")%>'></asp:Label>
             <%--  <asp:TextBox ID="txtclevel" runat="server" Text='<%# Eval("STATUS")%>'></asp:TextBox>--%>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REFERENCE NUMBER">
         <ItemTemplate>
                <asp:Label ID="lblrefno" runat="server" Text='<%# Eval("REFERENCE_NO")%>'></asp:Label>
            </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtrefno" runat="server" Text='<%# Eval("REFERENCE_NO")%>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        
                 <asp:TemplateField HeaderText="CASE STATUS">
         <ItemTemplate>
                <asp:Label ID="ddlstatus" runat="server" Text='<%# Eval("case_status")%>'></asp:Label>
            </ItemTemplate>
           <EditItemTemplate>
                <asp:DropDownList ID="ddlstatus" runat="server">
                      <asp:ListItem Value="A">SELECT</asp:ListItem>
        <asp:ListItem Value="B">PENDING</asp:ListItem>
        <asp:ListItem Value="C">DISPOSED</asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
      <%--  <asp:CommandField ShowEditButton="True"  />--%>

       <%--  <asp:TemplateField ControlStyle-CssClass="min-100">  
                    <ItemTemplate>  
                        <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" Font-Underline="true">Edit</asp:LinkButton>
                    
                    </ItemTemplate>  
                    <EditItemTemplate>  
                      
                        <asp:LinkButton ID="btn_Update" runat="server" CommandName="Update" Font-Underline="true">Update</asp:LinkButton>
                        <asp:LinkButton ID="btn_Cancel" runat="server" CommandName="Cancel" Font-Underline="true">Cancel</asp:LinkButton> 
                    </EditItemTemplate>  
                </asp:TemplateField>--%>
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
</div></div>
</div>
   
</asp:Content>
