<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VillageGisDashboardReport.aspx.cs" Inherits="ROFR.VillageGisDashboardReport" %>

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
									<a class="nav-link" href="VillageGisDashboardReport.aspx">Home <span class="sr-only">(current)</span></a>
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
		<%--<div class="row mt-3">
			<div class="col-md-12">
				<nav aria-label="breadcrumb">
					<ol class="breadcrumb">
						<li class="breadcrumb-item"><a href="#">Home</a></li>
						<li class="breadcrumb-item active" aria-current="page">Reports</li>
					</ol>
				</nav>
			</div>
		</div>--%>
        	<div class="row mt-3 mb-3">
            <div class="col-md-12 d-flex justify-content-between">
                <div class="" id="back1">

                    <a href="VillageGisDashboardReport.aspx" class="btn btn-info btn-rounded"><i class="fa fa-arrow-circle-left mr-1"></i>Back</a>
                </div>
                 <div class="" id="back2" style="display:none" >

                    <a  name="lback2" href="VillageGisDashboardReport.aspx" class="btn btn-info btn-rounded"><i class="fa fa-arrow-circle-left mr-1"></i>Back</a>
                </div>
                 <div class="" id="back3" style="display:none">

                    <a name="lback3" href="VillageGisDashboardReport.aspx" class="btn btn-info btn-rounded"><i class="fa fa-arrow-circle-left mr-1"></i>Back</a>
                </div>
                <div class="text-center">
                    <div class="title">
                        <h5>Village Profile - Report</h5>
                    </div>
                </div>
                <div class="text-right">
                    <a href="VillageGisDashboardReport.aspx" class="btn btn-success btn-rounded"><i class="fa fa-home mr-1"></i>Home</a>
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
						<select class="form-control" id="District">
							<option value="">Select District</option>
							
						</select>
                            
                          
					</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">ITDA</label>
						<div class="col-md-8">
						<select class="form-control" id="Itda">
							<option value=" ">Select Itda</option>
							
						</select>
						</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Mandals</label>
						<div class="col-md-8">
						<select class="form-control" id="Mandal">
                           <option value=" ">Select Mandal</option>
						</select>
						</div>
					</div>
				</div>

                <div class="col-md-3">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Panchayat</label>
						<div class="col-md-8">
						<select class="form-control" id="GP">
							<option value=" ">Select GramPanchayat</option>
						</select>
						</div>
					</div>
				</div>
				<div class="col-md-2">
					<div class="form-group row">
						<label class="col-md-4 py-1" for="exampleFormControlInput1">Village</label>
						<div class="col-md-8">
						<select class="form-control" id="Village">
						<option value=" ">Select Village</option>
						</select>
						</div>
					</div>
				</div>
			</div>
		</section>

	
         <div class="row mt-4 mb-4" id="div1" >
            <div class="container-fluid justify-content-center">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <table class="table table-bordered table-striped " id="mytable1" border='1' bordercolor="#3366CC" style="display:none">
                                        <tr class="bg-primary text-white header-center">
                                        <th>S.No</th>
                                            <th>Department Name</th>
                                            <th>Assests</th>
                                            <th>Sub Assests</th>
                                            <th>Yes</th>
                                            <th>No</th>
                                           <%-- <tr><td>1</td><td><a  name='lnkViews' href="javascript:void(0);">dept</a></td><td>2</td><td>3</td><td>4</td><td>5</td></tr>--%>
<%--<tr><td>1</td><td><a  name='lnkViews' href="VillageGisDashboardReport.aspx?Dept=101">dept</a></td><td>2</td><td>3</td><td>4</td><td>5</td></tr>--%>
                                        </tr>
                                    </table> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

            <div class="row mt-4 mb-4" id="div2" >
            <div class="container-fluid justify-content-center">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <table class="table table-bordered table-striped" id="mytable2" border='1' style="display:none">
                                        <tr class="bg-primary text-white header-center">
                                        <th>S.No</th>
                                            <th>Assests Name</th>
                                            <th>Sub Assests</th>
                                            <th>Yes</th>
                                            <th>No</th>
                                        </tr>
                                    </table> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="row mt-4 mb-4" id="div3" >
            <div class="container-fluid justify-content-center">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <table class="table table-bordered table-striped" id="mytable3" border='1' style="display:none">
                                        <tr class="bg-primary text-white header-center ">
                                        <th>S.No</th>
                                            <th>SubAssest Name</th>
                                           <%-- <th>Sub Assest Status</th>--%>
                                            <th>Sub Asset Condition</th>
                                            <th>Sub Asset Image1</th>
                                            <th>Sub Asset Image2</th>
                                            <th>Sub Asset Image3</th>
                                            
                                        </tr>
                                    </table> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
         <div class="row mt-4 mb-4" id="div4" >
            <div class="container-fluid justify-content-center">
                <div class="card">
                    <div class="card-body">
                           <div class="row justify-content-center">
                        <div class="col-md-10 ">
                            <div class="table-responsive">
                                <div class="headertable">
                                    <table class="table table-bordered table-striped" id="mytable4" border='1' style="display:none">
                                        <tr class="bg-primary text-white header-center">
                                        <th>S.No</th>
                                            <th>Department</th>
                                            <th>No of Beneficiaries</th>
                                            <th>Road Name</th>
                                            <th>Road Category</th>
                                            <th>Road Start Image</th>
                                            <th>Road End Image</th>
                                            <th>Road Start Lat Long</th>
                                            <th>Road End Lat Long</th>
                                             <th>Road Legth (mts)</th>
                                             <th>Road Width (mts)</th>
                                             <th>Road Width Image</th>
                                             <th>Road Width Latlongs</th>
                                             <th>Road Connecting To</th>
                                             <th>Road Connection Name</th>
                                             <th>Road Condition</th>
                                             <th>Road Type</th>
                                             
                                             <th>Road Transport Type</th>
                                            
                                        </tr>
                                    </table> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>



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
  <%--   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script src="linksforcdns/Js/3.3.1.jquery.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
   
        	<%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
    <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
  <%--  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
    <script src="linksforcdns/Js/1.7.1.jquery.min.js"></script>
     <script type="text/javascript" src="../MapJsfloder/Report.js"></script>

    <script src="vendor-assets/popper.js/tooltip.min.js"></script>

	<!-- jQuery Knob -->
	<script src="js/jquery.knob.js"></script>
	<script src="js/widget-inline-charts.js"></script>
	<!-- jQuery Knob -->

   
   
<%--<script>

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

</script>--%>
</body>
</html>

