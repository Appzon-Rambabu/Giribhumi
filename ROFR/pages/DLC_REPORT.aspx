<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="DLC_REPORT.aspx.cs" Inherits="ROFR.pages.DLC_REPORT" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .header-center {
            text-align: center;
        }
        .headertable { overflow-y: auto; height:400px; } 
.headertable table { border-collapse: collapse; width: 100%; border:1px solid #3366CC !important;font-size:13px;}
.headertable th, .headertable td { padding: 8px 16px; } 
.headertable th { position: sticky; top: -10px; background-color: midnightblue;}

.headertable .aftr th{position: sticky;top: 49x;}

     
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="panel panel-body" style="margin-top:150px;">


        <h5 class="text-center text-success mb-4 mt-3">BENEFICIARY DLC REPORT</h5>

        <div class="row mb-2">
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="txt_Itda" runat="server" Text="ITDA Name:"></asp:Label>&nbsp<asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_ITda" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="row  d-flex justify-content-center" id="district_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="txt_district" runat="server" Text="District:"></asp:Label>&nbsp<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="mandal_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label6" runat="server" Text="Mandal:"></asp:Label>&nbsp<asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_mandal" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row  d-flex justify-content-center" id="village_Records" runat="server">
                    <div class="col-md-4 text-center">
                        <asp:Label ID="Label9" runat="server" Text="Village:"></asp:Label>&nbsp<asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-8">
                        <asp:DropDownList ID="ddl_village" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>


  
            <br />
            <br />



                 <div class="panel panel-body" id="panel1" runat="server"> 

    <div class="row justify-content-center" style="text-align:right">



              <div class="table-responsive">

       <div class="headertable">



     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>   
                             
                        <asp:TemplateField HeaderText=" SNO. "  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>   
                         <asp:TemplateField HeaderText=" DIVISION CODE"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_DivisionCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="DIVISION NAME " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
 <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_Division") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="RANGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl3" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_RangeCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="RANGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <asp:Label ID="lbl4"   Font-Bold="True" Text='<%# Eval("Forest_Range") %>' runat="server" />
 
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="BEAT CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl5" runat="server"  Font-Bold="True" Text='<%# Eval("Forest_BeatCode") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="BEAT NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Forest_Beat") %>' runat="server" />
        
            </ItemTemplate>

        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="VILLAGE CODE" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl7" runat="server"  Font-Bold="True" Text='<%# Eval("Village_Code") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="VILLAGE NAME" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl8" runat="server"  Font-Bold="True" Text='<%# Eval("Village") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="HABITATION" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl9" runat="server"  Font-Bold="True" Text='<%# Eval("Habitation") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="No Of DLC Uploaded" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
               <asp:Label ID="lbl10" ForeColor="Red"  Font-Bold="True" Text='<%# Eval("dlc_count") %>' runat="server" />
  <asp:LinkButton ID="LinkButton10" runat="server" Font-Bold="True" ForeColor="Red"   Font-Underline ="True"  CommandName="DLC" CommandArgument='<%#Eval("Forest_DivisionCode")+"-"+Eval("Habitation")+","+ "9"%>' CausesValidation="false"   Visible ="false" OnClick="link_onclick" ><%# Eval("dlc_count") %></asp:LinkButton>
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


       
       
       
        <br />
    </div> 
          </div></div></div>
</asp:Content>
