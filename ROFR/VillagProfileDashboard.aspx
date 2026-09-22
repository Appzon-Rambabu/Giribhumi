<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VillagProfileDashboard.aspx.cs" Inherits="ROFR.VillagProfileDashboard" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Tribal Village Profile GEO</title>


    <link rel="stylesheet" href="vendor-assets/bootstrap-4.3.1/css/bootstrap.min.css">

   <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.7.0/css/all.css" rel="stylesheet">--%>
    <link href="linksforcdns/Css/all.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/main.css">

    <link rel="stylesheet" href="css/map.css">
    <style>
        #map {
            height: 100%;
        }
.map-container {
    width:  100%;
    height: 480px;
    margin:0;;
}

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

</head>

<body onload ="initMap();">


    <div id="navbar">
        <nav id="mainnavbar" class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="">
                <img src="images/aplogo.png" height="50" class="d-inline-block align-top"alt="">
                <!-- <img src="images/logo.png" height="50" class="d-inline-block align-top" alt=""> -->
            </a>
            &nbsp; &nbsp;
            <span class="navbar-text"
                style="margin-bottom:0px; margin-top:0px; padding: 2px 2px; font-size: 24px; color:#00a651;">
                <b>
                   Tribal Welfare Village Profile
                </b>
            </span>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href=""><i class="fas fa-home"></i> Home</a>
                    </li>
                    <!-- <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            Importank Links
                        </a>
                        <div class="dropdown-menu dropdown-menu-right text-right" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="#">Another action</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#"></a>
                        </div>
                    </li> -->
                
                    <li class="nav-item">
                        <a class="nav-link" href="" id="login">Login&nbsp;<i class="fas fa-sign-in-alt"></i></a>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="vertical-line"></div>
    </div>

    <div id="app-main" class="container-fluid">

        <!-- page-wrapper -->
        <div class="page-wrapper chiller-theme toggled" style="color: #bababa;">

            <div>
                <a id="show-sidebar" class="btn btn-sm btn-dark" href="#">
                    <i class="fas fa-bars"></i>
                </a>
            </div>

            <!-- sidebar-wrapper  -->
            <nav id="sidebar" class="sidebar-wrapper">
                <div class="sidebar-content">
                    <div class="sidebar-brand">
                        <a href="#">MENU</a>
                        <div id="close-sidebar">
                            <i class="fas fa-angle-double-left"></i>
                        </div>
                    </div>
                    <!-- sidebar-search  -->
                    <div class="sidebar-menu">
                        <ul>
                            <li class="sidebar-dropdown active">
                                <a href="#">
                                    <i class="fa fa-bars"></i>
                                    <span>Navigation</span>
                                </a>
                                <div class="sidebar-submenu light">
                                    <br />
                                    <div id="navigation-list">
                                        <div class="form-group row">
                                            <div class="col-md-12 mb-2">
                                               <label><b>Select Itda :</b></label>
                         
                               <select class="form-control" id="selecteddistrict">
											<option value="s">Select Itda</option>
										
										</select>
                                            </div>
                                            <div class="col-md-12 mb-2">
                                                <label><b>Select Mandal :</b></label>
                          
                                  <select class="form-control" id="selectedMandal" >
											<option value="s">Select Mandal</option>
											
										</select>
                                            </div>
                                    
                                            <div class="col-md-12 mb-2">
                                               <label><b>Select Village :</b></label>
                                            <select class="form-control" id="selectedVillage">
											<option value="s">Select Village</option>		
										</select>
                                            </div>
                                            <div class="col-md-12 mb-2">
                              <label><b>Select Category :</b></label>
                              <select class="form-control" id="selectedparameter">
											<option value="s">Select Category</option>									
										</select>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </li>
                            <!--<li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="fa fa-chart-pie"></i>
                                    <span>Option</span>
                                    <span class="badge badge-pill badge-danger">3</span>
                                </a>
                                <div class="sidebar-submenu light">
                                    <div id="downloads-content">
                                       
                                    </div>
                                </div>
                            </li>-->

                        </ul>
                    </div>
                    <!-- sidebar-menu  -->
                </div>
                <!-- sidebar-content  -->
                <div class="sidebar-footer dark">
                    <!--
            <a href="#">
            <i class="fa fa-bell"></i>
            <span class="badge badge-pill badge-warning notification">3</span>
            </a>
            <a href="#">
            <i class="fa fa-envelope"></i>
            <span class="badge badge-pill badge-success notification">7</span>
            </a>
            <a href="#">
            <i class="fa fa-cog"></i>
            <span class="badge-sonar"></span>
            </a>
            -->
                    <a href="#">
                        <i class="fa fa-power-off"></i>
                    </a>
                </div>
            </nav>
            <main class="page-content">
                <div class="map-wrapper">
                        <div class="map-container">
             
                  <input runat="server" type="hidden" id="ITDA">
                  <input runat="server" type="hidden" id="DISTRICT">
                  <input runat="server" type="hidden" id="MANDAL">
                  <input runat="server" type="hidden" id="VILLAGE">
                  <input runat="server" type="hidden" id="HABITATION">
                  <input runat="server" type="hidden" id="COMPARTMENT">
                  <div id="map" style="height: 600px; width: auto;"></div>
  
</div>
                </div>
            </main>

        </div>
        <!-- page-wrapper -->
    </div>
    <div id="snackbar">Some text some message..</div>
    

    <script src="vendor-assets/jquery/jquery-3.3.1.min.js"></script>
    <script src="vendor-assets/popper.js/popper.min.js"></script>
    <script src="vendor-assets/popper.js/tooltip.min.js"></script>
    <script src="vendor-assets/bootstrap-4.3.1/js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
    <script src="js/map.js"></script>
	 <%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
    <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
     <script type="text/javascript" src="../MapJsfloder/villageprofilejs.js"></script>
    <script src="linksforcdns/Js/1.7.1.jquery.min.js"></script>
<%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
    
</body>

</html>