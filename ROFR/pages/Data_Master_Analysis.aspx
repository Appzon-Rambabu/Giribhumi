<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="Data_Master_Analysis.aspx.cs" Inherits="ROFR.pages.Data_Master_Analysis" EnableEventValidation="false" %>
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

    <div class="row" style="text-align:right">
    
         <div class="table-responsive">

       <div class="headertable">

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" >  
                    <Columns>   
                                
                         <asp:TemplateField HeaderText=" DISTRICT"  ItemStyle-Width = "150"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("DISTRICT_NAME") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                     
                         <asp:TemplateField HeaderText=" Mandal With Codes" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
            <asp:LinkButton ID="LinkButton8" runat="server" Font-Bold="True" ForeColor="#009900" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "1"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_MANDAL_CODE") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Mandal With Out Codes" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
            <asp:LinkButton ID="LinkButton7" runat="server" Font-Bold="True" ForeColor="Red" Font-Underline="false"  CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "2"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("MANDAL_CODE_NULL") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText=" Village With Code " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton6" runat="server" Font-Bold="True" ForeColor="#009900" Font-Underline="false"  CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "3"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_VILLAGE_CODE") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText=" Village With Out Codes" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "4"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("VILLAGE_CODE_NULL") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Forest Division With Code" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton4" runat="server"  Font-Bold="True" ForeColor="#009900" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "5"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_FOREST_DIVISION_CODE") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Forest Division With Out Codes" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "6"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("FOREST_DIVISION_CODE_NULL") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText=" Forest Range With Code" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True"  ForeColor="#009900" Font-Underline="false"  CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "7"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_FOREST_RANGE_CODE") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     <asp:TemplateField HeaderText="Forest Range With Out Code " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "8"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("FOREST_RANGE_CODE_NULL") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                     
                     <asp:TemplateField HeaderText="Forest Beat With Code" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton11" runat="server" Font-Bold="True"  ForeColor="#009900" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "9"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_FOREST_BEAT_CODE") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                    
                     <asp:TemplateField HeaderText=" Forest Beat With Out Code " ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton12" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "10"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("FOREST_BEAT_CODE_NULL") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                    
                       <asp:TemplateField HeaderText="Habitation Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton13" runat="server" Font-Bold="True"  ForeColor="#009900" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "11"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("TOTAL_HAB_NAME") %></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField> 
                       <asp:TemplateField HeaderText="Habitation Name Empty" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
             <asp:LinkButton ID="LinkButton14" runat="server" Font-Bold="True"  ForeColor="Red" Font-Underline="false" CommandName="MyUpdate" CommandArgument='<%#Eval("DISTRICT_NAME")+","+ "12"%>' CausesValidation="false" OnClick="link_onclick" ><%# Eval("HAB_NAME_NULL") %></asp:LinkButton>
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
    <div class="row">
        <%-- <asp:Repeater ID="Repeater1" runat="server"  >

            <HeaderTemplate>
                <div class="headertable">
                   
           <table class="table table-bordered table-striped" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <thead class="text-white" style="background-color:#38a1d2; ">
                        <tr>
                                 
                         
     
                         <th style="text-align: center" >District<br /></th> 
                    <th style="text-align: center"> District Code<br /></th> 

                        <th style="text-align: center">Mandal <br /></th>  
                    
                         <th style="text-align: center">Mandal Code<br /></th>    
                   
                        
                        <th style="text-align: center">Village<br /></th>   
                         <th style="text-align: center">Village Code<br /></th>     
                             <th style="text-align: center">Forest Division<br /></th>   
                         <th style="text-align: center">Forest Division Code<br /></th>    
                             <th style="text-align: center">Forest Range<br /></th>   
                         <th style="text-align: center">Forest Range Code<br /></th>   
                             <th style="text-align: center">Forest Beat<br /></th>   
                         <th style="text-align: center">Forest Beat Code<br /></th>     
       
      
     
     
      
                    </tr>
          </thead>
            </HeaderTemplate>

            <ItemTemplate>
                  <tbody>

                <tr style="background-color: White">
                    <td style="text-align: center"> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>  </td>
                     <td style="text-align: center"> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_CODE")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.MANDAL_CODE")%> </td>

                  <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_CODE")%> </td>

                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_CODE")%> </td>
                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_CODE")%> </td>

                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_CODE")%> </td>



                 
                </tr>
                        </tbody>
            </ItemTemplate>

            <AlternatingItemTemplate>
                  <tbody>
                <tr style="background-color:#AED6FF">
                  <td style="text-align: center"> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_NAME")%>  </td>
                     <td style="text-align: center"> <%#DataBinder.Eval(Container, "DataItem.DISTRICT_CODE")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.MANDAL_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.MANDAL_CODE")%> </td>

                  <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.VILLAGE_CODE")%> </td>

                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_DIVISION_CODE")%> </td>
                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_RANGE_CODE")%> </td>

                       <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_NAME")%>  </td>

                    <td style="text-align: center">  <%#DataBinder.Eval(Container, "DataItem.FOREST_BEAT_CODE")%> </td>


                  

                </tr>
  </tbody>
            </AlternatingItemTemplate>

            <FooterTemplate>

                </table>
                 </div>
            </FooterTemplate>

        </asp:Repeater>--%>

        </div>
           </div></div></div>
</asp:Content>
