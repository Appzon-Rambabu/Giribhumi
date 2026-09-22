<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Health.aspx.cs" Inherits="ROFR.pages.Health" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- CSS -->
    <link href="../reports1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../style.css" rel="stylesheet" />
    <link href="../reports1/css/font-awesome.css" rel="stylesheet" />
    <!-- CSS -->

</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
     <div class="panel panel-body"  style="margin-top:40px;">


        <h5 class="text-center text-success mb-4 mt-3">HEALTH ANALYSIS</h5>
          <div class="row mb-1 mt-1 justify-content-end">
            <div class="col-md-4">


                <div class="row d-flex justify-content-end">

                    <div class="col-md-3 ml-0 mr-0">
                          <asp:Button ID="btnsubmit" class="btn btn-sm btn-success" Visible="false" AutoPostBack="true" OnClick="txtSearch_Click" runat="server" Text="EXCEL" />
                    </div>
                </div>


            </div>
        </div>
                
          <div class="">
               <div class="row justify-content-center mb-2" id="po" runat="server">
              <div class="col-md-4">
                <div class="row  d-flex justify-content-center" id="Div3" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label4" runat="server" Text="DISTRICT:"></asp:Label>&nbsp<asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_district" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                </div>
            </div>
              <div class="col-md-4">
                <div class="row  d-flex justify-content-center" id="Div4" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label1" runat="server" Text="HEALTH FACILITY:"></asp:Label>&nbsp<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_facility" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_facility_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
                   <div class="col-md-4">
                <div class="row  d-flex justify-content-center" id="Div1" runat="server">
                    <div class="col-md-6 text-center pl-0 pr-0">
                        <asp:Label ID="Label2" runat="server" Text="HOSPITAL:"></asp:Label>&nbsp<asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-6 pl-0 pr-0">
                        <asp:DropDownList ID="ddl_hospital" Style="width: 100%" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_hospital_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                </div>
            </div>


      
        </div>
        <div class="col-md-8">
        <div class="table-responsive">

       <div class="headertable">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4"  style="width:100%;">  
                    <Columns>   
                            
                         <asp:TemplateField HeaderText="SNO" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl0" runat="server"  Font-Bold="True" Text='<%# Eval("sno") %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                             
                         <asp:TemplateField HeaderText="ITDA NAME" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:left">
                      
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Eval("itda_name") %>' Visible="false" runat="server" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Total Compartments" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                  <asp:Label ID="lbl2"  Font-Bold="True" Text='<%# Eval("Total_Compartments") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Total Beneficiaries" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="lbl3" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Beneficiaries") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Beneficiaries Having Aadhar No" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Beneficiaries_Having_Adhaar_no") %>' runat="server" />
            </div>
                      </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Total Available Land (In Acres)" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                  <div style="text-align:right">
                 <asp:Label ID="lbl5" ForeColor="#009900" Font-Bold="True" Text='<%# Eval("Total_Land") %>' runat="server" />
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
         </div>
    </div>
    </form>
</body>
</html>
