<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="ROFR.pages.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"    CssClass="table table-bordered text-center "   >  
                 
<Columns>   
                        
    <asp:TemplateField><HeaderTemplate> <tr>
                                                        <th rowspan="2"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Total No.of Families</th>
                                                            <th rowspan="2" style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                          Sub-Merged/Migrated/In-Eligible Families</th>
                                                        <th colspan="3"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Land Holding Details</th>
                                                        <th colspan="3"
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Rythu Bharosa Status</th>
                                                    </tr>
                                                    <tr class="aftr">
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with &lt; 2Acres</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with &gt; 2Acres</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families with No Land</th>
                 
                                                        <th

                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Eligible Families</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Rejected Families</th>
                                                        <th
                                                            style="text-align: center; vertical-align: middle;background-color: #2e44df;color: white;">
                                                            Families Not Covered</th>
                                                    </tr></HeaderTemplate></asp:TemplateField>
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='1' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='2' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
   <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='3' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='4' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='5' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>

        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='6' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='7' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='8' runat="server" ForeColor="Black"/>
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
     <asp:TemplateField >
            <ItemTemplate>
                  <div style="text-align:left">
                 <asp:Label ID="hab"   Text='9' runat="server" ForeColor="Black"/>
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
</asp:Content>
