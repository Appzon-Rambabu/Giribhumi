<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VillageDashboardReport.aspx.cs" Inherits="ROFR.VillageDashboardReport"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<link rel="shortcut icon" href="img/favicon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/all.css">
    <title>Tribal Village Profile - Home</title>
      <style type="text/css">
        .header-center {
            text-align: center;
        }
        </style>
      <style>
        #map {
            height: 520px;
        }
        .map-container {
            width:  100%;
            height: 520px;
            margin:0;;
        }

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>
</head>

<body class="bg-light" onload ="initMap();">
    <form runat="server">
	<!-- Preloader -->
	<div class="bgoverlay">
		<div class="spinner2"></div>
	</div>
	<!-- Preloader -->
    <header>
		<nav class="navbar navbar-expand-lg navbar-light bg-custom">
			<div class="col-md-12">
				<div class="row">
					<div class="col-md-3">
						<a class="navbar-brand font-weight-bold" href="#"><img src="img/logo.png" style="height: 50px;" /></a>
						<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
							aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
							<span class="navbar-toggler-icon"></span>
						</button>
					</div>
					<div class="col-md-7">
						<div class="collapse navbar-collapse mt-2" id="navbarSupportedContent">
							<ul class="navbar-nav mr-auto">
								<li class="nav-item active">
									<a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
								</li>
								<li class="nav-item">
									<a class="nav-link" href="department-inner.html">Department Input</a>
								</li>
								<li class="nav-item dropdown">
									<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button"
										data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
										Dropdown
									</a>
									<div class="dropdown-menu" aria-labelledby="navbarDropdown">
										<a class="dropdown-item" href="#">Action</a>
										<a class="dropdown-item" href="#">Another action</a>
									</div>
								</li>
							</ul>
						</div>
					</div>
					<div class="col-md-2 text-right">
						<div class="dropdown mt-3">
							<a href="#!" class="dropdown-toggle text-white" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
								Welcome admin <i class="fa fa-1x fa-user-circle">
								</i></a>
							</button>
							<div class="dropdown-menu" aria-labelledby="dropdownMenu2">
							  <button class="dropdown-item" type="button">Logout</button>
							  <button class="dropdown-item" type="button">Forgot Password</button>
							  <button class="dropdown-item" type="button">Something else here</button>
							</div>
						  </div>
					</div>
				</div>
			</div>
		</nav>
    </header>

    <div class="container-fluid">
		
			<div class="row mt-3 mb-3">
            <div class="col-md-12 d-flex justify-content-between">
                <div class="">
                   <%-- <a href="index.html" class="btn btn-info btn-rounded"><i class="fa fa-arrow-circle-left mr-1"></i>Back</a>--%>
                    <asp:LinkButton ID="backbtn1" runat="server" class="btn btn-info btn-rounded fa fa-arrow-circle-left mr-1" OnClick="backbtn1_click" >Back</asp:LinkButton>
                     <asp:LinkButton ID="backbtn2" runat="server" class="btn btn-info btn-rounded fa fa-arrow-circle-left mr-1" Visible="false" OnClick="backbtn2_click">Back</asp:LinkButton>
                     <asp:LinkButton ID="backbtn3" runat="server" class="btn btn-info btn-rounded fa fa-arrow-circle-left mr-1" Visible="false" OnClick="backbtn3_click">Back</asp:LinkButton>
                     <asp:LinkButton ID="backbtn4" runat="server" class="btn btn-info btn-rounded fa fa-arrow-circle-left mr-1" Visible="false" OnClick="backbtn4_click">Back</asp:LinkButton>

                </div>
                <div class="text-center">
                    <div class="title">
                        <h5>Village Profile - Report</h5>
                    </div>
                </div>
                <div class="text-right">
                    <a href="VillageDashboardReport.aspx" class="btn btn-success btn-rounded"><i class="fa fa-home mr-1"></i>Home</a>
                    <a href="#!" class="btn btn-primary btn-rounded"><i class="fa fa-print mr-1"></i>Print</a>
                </div>
            </div>
		</div>

		<section class="col-md-12 selection-bar mt-4 mb-4">
			<div class="row">
				<div class="col-md-3">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">District</label>
						<div class="col-md-8">
						<%--<select class="form-control" id="District">
							<option value="">Select District</option>
							
						</select>
                            --%>
                            <asp:DropDownList ID="ddl_dist" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddldist_OnSelectedIndexChanged"></asp:DropDownList>
					</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">ITDA</label>
						<div class="col-md-8">
						<%--<select class="form-control" id="Itda">
							<option value=" ">Select Itda</option>
							
						</select>--%>
                             <asp:DropDownList ID="ddl_itda" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlitda_OnSelectedIndexChanged"></asp:DropDownList>
						</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Mandals</label>
						<div class="col-md-8">
					<%--	<select class="form-control" id="Mandal">
                           <option value=" ">Select Mandal</option>
						</select>--%>
                            <asp:DropDownList ID="ddl_mandal" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlmandal_OnSelectedIndexChanged"></asp:DropDownList>
						</div>
					</div>
				</div>

                <div class="col-md-3">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Panchayat</label>
						<div class="col-md-8">
						<%--<select class="form-control" id="GP">
							<option value=" ">Select GramPanchayat</option>
						</select>--%>
                            <asp:DropDownList ID="ddl_gp" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlgp_OnSelectedIndexChanged"></asp:DropDownList>
						</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Village</label>
						<div class="col-md-8">
					<%--	<select class="form-control" id="Village">
						<option value=" ">Select Village</option>
						</select>--%>

                             <asp:DropDownList ID="ddl_village" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlvillage_OnSelectedIndexChanged"></asp:DropDownList>
						</div>
					</div>
				</div>
			</div>
		</section>

        
	
        <div class="row mt-4 mb-4 " id="div1" runat="server">
            <div class="container-fluid ">
                <div class="card">
                    <div class="card-body ">
                        <div class="row justify-content-center">
                        <div class="col-md-10">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                         <asp:TemplateField HeaderText="S.No "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Department Name"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("DEPARTMENT_NAME") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("DEPT_CODE")+","+ "1"%>' CausesValidation="false"   OnClick="link_onclick" ><%# Eval("DEPARTMENT_NAME") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Assets"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                 <div style="text-align:center">
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("ASSETS_CNT") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Sub Assets"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("SUBASSET_CNT") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Yes" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("YES_CNT") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="No"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center" ControlStyle-CssClass="text-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl8"  Font-Bold="True" Text='<%# Eval("NO_CNT") %>' runat="server" />
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
	  <div class="row mt-4 mb-4" id="div2" runat="server">
            <div class="container-fluid ">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                         <asp:TemplateField HeaderText="S.No "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Assest Name"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("ASSET_NAME") %>' Visible="false"></asp:Label>
                     <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Red"  Font-Underline="true" CommandName="MyUpdate" CommandArgument='<%#Eval("ASSET_CODE")+","+ "1"%>' CausesValidation="false"   OnClick="link1_onclick" ><%# Eval("ASSET_NAME") %></asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Sub Assets" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("SUBASSET_CNT") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Yes" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("YES_CNT") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="No" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("NO_CNT") %>' runat="server" />
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
          <div class="row mt-4 mb-4" id="div3" runat="server">
            <div class="container-fluid">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                         <asp:TemplateField HeaderText="S.No "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:center">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Sub Assest Name"  ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("SUBASSET_NAME") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Sub Asset Status" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("SUBASSET_STATUS") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Sub Asset Condition" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("SUBASSET_CONDITION") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Sub Asset Image1" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("SUB_ASSET_IMG1") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Sub Asset Image2" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("SUB_ASSET_IMG2") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Asset Image3" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("SUB_ASSET_IMG3") %>' runat="server" />
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
         <div class="row mt-4 mb-4" id="div4" runat="server">
            <div class="container-fluid justify-content-center">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"   
                    CellPadding="4" > 
                    <Columns>   
                                
                        
                         <asp:TemplateField HeaderText="S.No "  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl1" runat="server"  Font-Bold="True" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Road Name"   HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                <div style="text-align:left">
              <asp:Label Class="txt"  ID="lbl2" runat="server"  Font-Bold="True" Text='<%# Eval("ROAD_NAME") %>' ></asp:Label>
                    
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Road Category"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                <asp:Label ID="lbl3"  Font-Bold="True" Text='<%# Eval("ROAD_CATEGORY") %>' runat="server" />
  </div>
            </ItemTemplate>
        </asp:TemplateField> 
                           
                           
                         <asp:TemplateField HeaderText="Road Start Image"  HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl6"  Font-Bold="True" Text='<%# Eval("ROAD_START_IMAGE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Road End Image" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_END_IMAGE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Road Start Lat Long" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_START_LAT_LONG") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Road End Lat Long" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_END_LAT_LONG") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Legth (mts)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_LENGTH_MTS") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Road Width (mts)" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_WIDTH_MTS") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Width Image" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_WIDTH_IMAGE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Width Latlongs" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_WIDTH_LATLONGS") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Connecting To" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_CONNECTING_TO") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Connection Name" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_CONNECTION_NAME") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Condition" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_CONDITION") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Type" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_TYPE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Department" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("DEPARTMENT") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Road Transport Type" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("ROAD_TRANSPORT_TYPE") %>' runat="server" />
         </div>
            </ItemTemplate>
        </asp:TemplateField>
                          <asp:TemplateField HeaderText="No of Beneficiaries" ItemStyle-Width = "150" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="header-center">
            <ItemTemplate>
                 <div style="text-align:center">
                 <asp:Label ID="lbl7" Font-Bold="True" Text='<%# Eval("NO_OF_BENFICIARIES") %>' runat="server" />
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





      <%-- <div class="panel panel-body" style="margin-top:150px;">

               
               <div class="row" style="margin-top:50px;margin-left:50px;margin-right:50px;">
                    <div class="col-md-12">
                  
               <table id="mytable1" border='1'  >
    <tr>
        <%--<th>S.No</th>
         <th>Department Name</th>
         <th>Assests</th>
         <th>Sub Assests</th>
        <th>Yes</th>
        <th>No</th>
    </tr>
</table>
               </div>
                    </div>  
    </div>--%>
    <footer>
        <div class="container-fluid">
        <div class="row">
            <duv class="col-md-12 text-center py-2">
                <p class="mb-0 text-white">&copy; Tribal Welfare</p>
            </duv>
        </div>
    </div>
    </footer>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="js/custom.js"></script>
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
        <script src="linksforcdns/Js/3.3.1.jquery.min.js"></script>
        <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
        <script src="linksforcdns/Js/1.7.1.jquery.min.js"></script>
        	<%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>

    <%-- <script type="text/javascript" src="../MapJsfloder/Report.js"></script>--%>

    <script src="vendor-assets/popper.js/tooltip.min.js"></script>

	<!-- jQuery Knob -->
	<script src="js/jquery.knob.js"></script>
	<script src="js/widget-inline-charts.js"></script>
	<!-- jQuery Knob -->

   
   
<script>

$("#assets").hide();
$("#agriid").click(function () {
    if (($('#assets').is(':visible') == true))
    {
        $("#assets").hide();
    }
    else if (($('#assets').is(':hidden') == true))
    {
        $("#assets").show();
    } 
});

</script>
        </form>
</body>
</html>