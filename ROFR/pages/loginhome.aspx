<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ROFR_MASTER.Master" AutoEventWireup="true" CodeBehind="loginhome.aspx.cs" Inherits="ROFR.pages.loginhome"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
   <%-- <style>
          .total-count .card{
            border: 1px solid transparent;
            background-clip: border-box;
            border-radius: 5px;
            box-shadow: 4px 3px 17px 1px rgba(0, 0, 0, 0.2);
            min-height: 170px;
        }
       
        .total-count .bg-primary {
        background-color: #4c7cf3 !important;
        }

        .total-count .bg-secondary {
        background-color: #777b82 !important;
        }

        .total-count .bg-success {
        background-color: #2bcd72 !important;
        }

        .total-count .bg-danger {
        background-color: #ff4b5b !important;
        }

        .total-count .bg-info {
        background-color: #0dc8b7! important;
        }

        .total-count .bg-purple {
        background-color: #7266bb !important;
        }

        .total-count .bg-orange {
        background-color: #ed8040 !important;
        }
        .total-count p{
            border-bottom:1px dashed rgba(255, 255, 255, 0.2);
            margin-bottom: 0.2rem;
            padding-bottom: 0.5rem;
            font-size: 24px;
        }
        .total-count h3::after{
            content: "\f115";
            position: absolute;
            right: 0;
            bottom: 0;
            font-family:'FontAwesome';
        }
        .border-right.border-dashed{
            border-right-style:dashed !important;
            border-right-color:#ffffff33 !important;
        }
        [role="main"]{
            padding-bottom:0 !important;
            background: url(https://www.suretiimf.com/wp-content/uploads/2020/06/pattern-background-png-4-300x300.png);
            background-size: 10%;
        }
        .inner-card {
        padding: 15px;
      }
.inner-card {
      background: #f8fafc;
      border-radius: 14px;
      padding: 20px;
      margin-bottom: 20px;
      box-shadow: 0 4px 20px rgba(0,0,0,0.05);
    }
.card-container {
      max-width: 1400px;
      margin: 0 auto;
    }

    </style>--%>


<style>
body {
    background: #f4f7fb;
}

/* Main section container */
.section-box {
    background: #f5f5f5;
    border-radius: 20px;
    padding: 5px;
    margin-bottom: 20px;
	margin-Top: -10px;
    box-shadow: 0 8px 22px rgba(0,0,0,0.06);
}
.lineheight{
    line-height: 1;
}
/* Top gradient cards */
.gradient-red {
    
     background: linear-gradient(135deg, #e3f2fd, #90caf9);
}

.gradient-blue {
   background: linear-gradient(135deg, #e8f5e9, #81c784);
}

.gradient-green {
   background: linear-gradient(135deg, #fce4ec, #f48fb1);
}

.card-box {
    border-radius: 18px;
    padding: 28px;
    text-align: center;
    height: 100%;
}

.card-title {
    font-size: 18px;
    font-weight: 600;
}

.card-value {
    font-size:20px;
    font-weight: 700;
    margin-top: 5px;
}

/* White info cards */
.info-card {
    border-radius: 16px;
    padding: 15px;
    text-align: center;
    height: 100%;
    box-shadow: 0 5px 15px rgba(0,0,0,0.05);
}

.info-title {
    font-weight: 600;
    font-size: 18px;
}

.info-label {
    color: #555;
    margin-top: 10px;
}

.info-value {
    font-size: 20px;
    font-weight: 700;
}
.border-right {
    border-right: 1px dashed #ccc;
}

.info-card {
    border-radius: 16px;
    padding: 10px;
    box-shadow: 0 5px 15px rgba(0,0,0,0.05);
    height: 100%;
}

.info-title {
    font-size: 18px;
    font-weight: 600;
}

.info-label {
    font-size: 16px;
    font-weight: 600;
    margin-top: 10px;
}

.info-value {
    font-size: 20px;
    font-weight: 700;
    margin-top: 5px;
}
.size{
    font-size: 20px;
    font-weight: 700;
    margin-top: 5px;
}
.Dashboard{
    font-size: 20px;
    font-weight: 700;
    margin-top: -10px;
}


</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                         <%-- <div class="panel panel-body" >
                   <h3 class="text-center text-dark mt-3 mb-3"><i class="fa fa-home"></i>Dashboard</h3>
                           <div class="row total-count">
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Farmers </p></h2>
                                          
                                             <h2 class="text-white mt-4" id="totalbeneficiaries" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-primary">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Plots</p></h2>
                                            <h2 class="text-white mt-4" id="Ttlplots" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Extent</p></h2>
                                            <h2 class="text-white mt-4" id="TtlExtent" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Farmers not Having Land</p></h2>
                                           <h2 class="text-white mt-4" id="images_not_uploaded" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
								 <div class="col-md-3 mb-5">
                                    <div class="card bg-primary">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Farmer Images</p></h2>
                                           <div class="row">
                                                <div class="col-md-6 border-dashed border-right">
                                                    <h5 class="mb-1 text-dark">Uploaded</h5>
                                                    <h2 class="text-white" id="Frmrimgstat" runat="server"></h2>
                                                </div>
                                                <div class="col-md-6">
                                                    <h5 class="mb-1 text-dark">Yet to upload</h5>
                                                    <h2 class="text-white" id="Frmrimgnotstat" runat="server"></h2>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-purple">
                                        <div class="card-body text-center">
                                           <h2> <p class="text-white">DLC</p></h2>
                                            <div class="row">
                                                <div class="col-md-6 border-dashed border-right">
                                                    <h5 class="mb-1 text-dark">Uploaded</h5>
                                                    <h2 class="text-white" id="Hvngdlc" runat="server"></h2>
                                                </div>
                                                <div class="col-md-6">
                                                    <h5 class="mb-1 text-dark">Yet to upload</h5>
                                                    <h2 class="text-white" id="Nthvngdlc" runat="server"></h2>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-orange">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Stone Plantation</p></h2>
                                           <div class="row">
                                                <div class="col-md-6 border-dashed border-right">
                                                    <h5 class="mb-1 text-dark">Uploaded</h5>
                                                    <h2 class="text-white" id="STPShvng" runat="server"></h2>
                                                </div>
                                                <div class="col-md-6">
                                                    <h5 class="mb-1 text-dark">Yet to upload</h5>
                                                    <h2 class="text-white" id="STPSnothvng" runat="server"></h2>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-5">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Latitude Longitude</p></h2>
                                          <div class="row">
                                                <div class="col-md-6 border-dashed border-right">
                                                    <h5 class="mb-1 text-dark">Uploaded</h5>
                                                    <h2 class="text-white" id="latlnghvng" runat="server"></h2>
                                                </div>
                                                <div class="col-md-6">
                                                    <h5 class="mb-1 text-dark">Yet to upload</h5>
                                                    <h2 class="text-white" id="latlngnothvng" runat="server"></h2>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               
                                   
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Farmers </p></h2>
                                          
                                             <h2 class="text-white mt-4" id="H1" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-primary">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Plots</p></h2>
                                            <h2 class="text-white mt-4" id="H2" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Extent</p></h2>
                                            <h2 class="text-white mt-4" id="H3" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                   
                               
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Farmers not Having Land</p></h2>
                                           <h2 class="text-white mt-4" id="H4" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-info">
                                        <div class="card-body text-center">
                                            <h2><p class="text-white">Total Extent</p></h2>
                                            <h2 class="text-white mt-4" id="H5" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 mb-4">
                                    <div class="card bg-danger">
                                        <div class="card-body text-center">
                                          <h2>  <p class="text-white">Farmers not Having Land</p></h2>
                                           <h2 class="text-white mt-4" id="H6" runat="server"></h2>
                                        </div>
                                    </div>
                                </div>
                      
                            </div>
                         
        

       
        </div>--%>
   <%--<div class="container-fluid bg-dots mt-4">--%>

   <%-- <h3 class="text-center mb-2  Dashboard">
        <i class="fa fa-home"></i> Dashboard
    </h3>--%>

    <!-- ================= IFR SECTION ================= -->
    <div class="section-box gradient-gray">
        <h4 class="text-center mb-4 size">Individual Forest Rights (IFR)</h4>

        <!-- Top 4 Cards -->
        <div class="row" style="margin-top:-15px">
            <div class="col-md-3 mb-4">
                <div class="card-box gradient-red">
                    <div class="card-title">Total Farmers</div>
                    <div class="card-value" id="totalbeneficiaries" runat="server"></div>
                </div>
            </div>

            <div class="col-md-3 mb-4">
                <div class="card-box gradient-red">
                    <div class="card-title">Total Plots</div>
                    <div class="card-value" id="Ttlplots" runat="server"></div>
                </div>
            </div>

            <div class="col-md-3 mb-4">
                <div class="card-box gradient-red">
                    <div class="card-title">Total Extent (in Acres)</div>
                    <div class="card-value" id="TtlExtent" runat="server"></div>
                </div>
            </div>

            <div class="col-md-3 mb-4">
                <div class="card-box gradient-red">
                    <div class="card-title">Farmers not Having Land</div>
                    <div class="card-value" id="images_not_uploaded" runat="server"></div>
                </div>
            </div>
        </div>

        <!-- Bottom 4 Info Cards -->
        <div class="row" style="margin-top:-15px">

    <div class="col-md-3 mb-3">
        <div class="info-card gradient-red">
            <div class="info-title mb-3">DLC</div>

            <div class="row text-center">
                <div class="col-6 border-right">
                    <div class="info-label">Uploaded</div>
                    <div class="info-value" id="Hvngdlc" runat="server"></div>
                </div>
                <div class="col-6">
                    <div class="info-label">Yet to upload</div>
                    <div class="info-value" id="Nthvngdlc" runat="server"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-3 mb-3">
        <div class="info-card gradient-red">
            <div class="info-title mb-3">Stone Plantation</div>

            <div class="row text-center">
                <div class="col-6 border-right">
                    <div class="info-label">Uploaded</div>
                    <div class="info-value" id="STPShvng" runat="server"></div>
                </div>
                <div class="col-6">
                    <div class="info-label">Yet to upload</div>
                    <div class="info-value" id="STPSnothvng" runat="server"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-3 mb-3">
        <div class="info-card gradient-red">
            <div class="info-title mb-3">Latitude Longitude</div>

            <div class="row text-center">
                <div class="col-6 border-right">
                    <div class="info-label">Uploaded</div>
                    <div class="info-value" id="latlnghvng" runat="server"></div>
                </div>
                <div class="col-6">
                    <div class="info-label">Yet to upload</div>
                    <div class="info-value" id="latlngnothvng" runat="server"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-3 mb-3">
        <div class="info-card gradient-red">
            <div class="info-title mb-3">Farmer Images</div>

            <div class="row text-center">
                <div class="col-6 border-right">
                    <div class="info-label">Uploaded</div>
                    <div class="info-value" id="Frmrimgstat" runat="server"></div>
                </div>
                <div class="col-6">
                    <div class="info-label">Yet to upload</div>
                    <div class="info-value" id="Frmrimgnotstat" runat="server"></div>
                </div>
            </div>
        </div>
    </div>

</div>

    </div>

    <!-- ================= CFR + HOUSING ================= -->
    <div class="row lineheight">
        <!-- CFR -->
        <div class="col-md-6">
            <div class="section-box">
                <h4 class="text-center mb-4 size">Community Forest Rights (CFR)</h4>
                <div class="row" style="margin-top:-15px">
                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-blue">
                            <div class="card-title">Total Claims</div>
                            <div class="card-value" id="cfrtotalClaims" runat="server"></div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-blue">
                            <div class="card-title">Total Members</div>
                            <div class="card-value" id="cfrMembers" runat="server"></div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-blue">
                            <div class="card-title">Total Extent<h6>(in Acres)</h6></div>
                            <div class="card-value" id="CfrTotalExtent" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- HOUSING -->
        <div class="col-md-6">
            <div class="section-box">
                <h4 class="text-center mb-4 size">Housing</h4>
                <div class="row" style="margin-top:-10px">
                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-green">
                            <div class="card-title">Total Farmers</div>
                            <div class="card-value" id="HousingTF" runat="server"></div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-green">
                            <div class="card-title">Total Plots</div>
                            <div class="card-value" id="HousingTP" runat="server"></div>
                        </div>
                    </div>

                    <div class="col-md-4 mb-3">
                        <div class="card-box gradient-green">
                            <div class="card-title">Total Extent<h6>(in Acres)</h6></div>
                            <div class="card-value" id="HousingTE" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

<%--</div>--%>



</asp:Content>
