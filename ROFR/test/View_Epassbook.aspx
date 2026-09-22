<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Giribhumi_Master.Master" AutoEventWireup="true" CodeBehind="View_Epassbook.aspx.cs" Inherits="ROFR.test.View_Epassbook" EnableEventValidation="false" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bg-nav{
            background-color: #007405 !important;
            color:#fff;
        }
         .table th {
      text-align: center;
       background-color:#007405 !important;
       }
  
  
        /* Field Set */
        .epassbook fieldset {
            min-width: 0;
            padding: 0px 20px;
            margin: 5px;
            border: 2px solid #d3d3d3;
            min-height: 460px;
        }
        .epassbook legend {
            display: block;
            width: auto;
            max-width: 100%;
            padding: 0px 10px;
            font-size: 1.2rem;
            line-height: inherit;
            color: inherit;
            white-space: normal;
            background: #007405;
            color: #fff;
            border-right: 5px solid #fff;
            border-left: 5px solid #fff;
            font-family: 'Oswald', sans-serif;
        }
        .epassbook .form-group {
            margin-bottom: 0.5rem;
            background: #fcfcfc;
            border-bottom: 1px solid #eee;
        }
        .epassbook .form-group .col-form-label:first-child::after{
            content: ':';
            right: 0;
            position: absolute;
        }
       .panel-body{
	background-color:#fff;
	padding:10px 20px;
	border:1px solid #28a745;
	margin-bottom:20px;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
    <div style="margin-top:1px;">
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-between">
                                        <h4 class="text-dark">View Farmer Details</h4>
                                     <%--   <input type="submit" class="btn btn-info" value="Download Epassbook" />--%>
                                         <asp:Button ID="btn_passbook" runat="server" Text="Download Epassbook" OnClick="Button1_Click"  CssClass="btn btn-info"/>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-body">
                                <div class="col-md-12">
                                    <div class="row epassbook">
                                        <div class="col-md-4 mb-3">
                                            <fieldset>
                                                <legend>Farmer Details</legend>
                                                 <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                      FARMER PHOTO
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Image ID="Image1" runat="server"  Width="70px" Height="70px" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                      FARMER ID
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_bid" runat="server" Text="" ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                    FARMER NAME
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_name" runat="server" Text=""  ForeColor="Red"   ></asp:Label>
                                                    </div>
                                                </div>
                                                  <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                       FATHER NAME
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_fname" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        SUB CASTE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_subcaste" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        AADHAR
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                         <asp:Label ID="txt_aadhar" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        BANK NAME
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_bankname" runat="server" Text="" ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        BANK ACCOUNT NO.
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_baccount" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        IFSC CODE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_ifsc" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <fieldset>
                                                <legend>Land Details</legend>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        DIVISION
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                         <asp:Label ID="txt_division" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        RANGE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_range" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        BEAT
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                      <asp:Label ID="txt_beat" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        BLOCK
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                         <asp:Label ID="txt_block" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        TOTAL EXTENT PLOT AREA
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
    <asp:Label ID="txt_extentarea" runat="server" Text=""  ForeColor="Red"  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        HOLDING NATURE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                          <asp:Label ID="txt_hnature" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        LAND CLASSIFICATION
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_lclass" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        PATTAINAM GOVT
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                      <asp:Label ID="txt_inam" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <fieldset>
                                                <legend>Address</legend>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        ITDA
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                          <asp:Label ID="txt_itda" runat="server" Text=""  ></asp:Label>

                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        DISTRICT
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_district" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        MANDAL
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_mandal" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                              
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        VILLAGE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                        <asp:Label ID="txt_village" runat="server" Text=""  ForeColor="Red"   ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        HABITATION
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_hab" runat="server" Text=""  ></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-6 col-form-label">
                                                        REVENUE VILLAGE
                                                    </div>
                                                    <div class="col-md-6 col-form-label">
                                                       <asp:Label ID="txt_rvillage" runat="server" Text=""   ></asp:Label>
                                                    </div>
                                                </div>
                                   
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="row justify-content-center">
                                        <div class="col-md-12">
                                            <div class="row epassbook">
                                                 <div class="col-md-10" >
                                            <div class="table-responsive">
                                                <div class="headertable">
                                                       
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-center "  >  
                    <Columns>   
                        
                                       <asp:TemplateField HeaderText="SNo." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl1"  Font-Bold="True" Text='<%# Container.DataItemIndex + 1 %>' runat="server" ForeColor="Black" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                                    
                         <asp:TemplateField HeaderText="Compartment No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
           
                              <ItemTemplate>
                <div style="text-align:center">
                  
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("Compartment_No") %>'  ForeColor="Black"  ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                                        <asp:TemplateField HeaderText="ROFR Patta No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("ROFR_PATTANO") %>'  runat="server"  ForeColor="Black" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField> 
               <asp:TemplateField HeaderText="Plot No." HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl4"  Font-Bold="True" Text='<%# Eval("Plot_No") %>'  runat="server"  ForeColor="Black"  />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
           
                        <asp:TemplateField HeaderText="EXTENT PLOT AREA" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl5"  Font-Bold="True" Text='<%# Eval("ExtentPlotArea") %>'  runat="server"  ForeColor="Black"  />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="CULTIVABLE LAND" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("Cultivable_Land") %>'  runat="server"  ForeColor="Black" />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="UNCULTIVABLE LAND" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
         
                               <ItemTemplate>
                <div style="text-align:center">
                      
                    <asp:Label ID="lbl7"  Font-Bold="True" Text='<%# Eval("Uncultivable_Land") %>'  runat="server"  ForeColor="Black" />
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
                                </div>
                            </div>
        </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
