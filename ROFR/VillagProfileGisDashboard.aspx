<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VillagProfileGisDashboard.aspx.cs" Inherits="ROFR.VillagProfileGisDashboard" %>

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
		<!-- <div class="row mt-4 mb-4 ">
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-primary">1234</h4>
								<p class="mb-0 text-muted">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-primary-rgba">
									<i class="far fa-file-word font-30 text-primary"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-success">1234</h4>
								<p class="mb-0 text-muted">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-success-rgba">
									<i class="fas fa-rupee-sign font-30 text-success"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-warning">1234</h4>
								<p class="mb-0 text-muted">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-warning-rgba">
									<i class="fa fa-users font-30 text-warning"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-danger">1234</h4>
								<p class="mb-0 text-muted">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-danger-rgba">
									<i class="far fa-eye font-30 text-danger"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="row mt-4 mb-4">
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card bg-primary m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-white">1234</h4>
								<p class="mb-0 text-white">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-white">
									<i class="far fa-file-word font-30 text-primary"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card bg-success m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-white">1234</h4>
								<p class="mb-0 text-white">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-white">
									<i class="fa fa-rupee-sign font-30 text-success"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card bg-warning m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-white">1234</h4>
								<p class="mb-0 text-white">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-white">
									<i class="fas fa-users font-30 text-warning"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		
			<div class="col-md-6 col-lg-6 col-xl-3 mb-2">
				<div class="card bg-danger m-b-30">
					<div class="card-body">
						<div class="tw-widget-box">
							<div class="float-left">
								<h4 class="xp-counter text-white">1234</h4>
								<p class="mb-0 text-white">Title Here</p>
							</div>
							<div class="float-right">
								<div class="tw-widget-icon tw-widget-icon-bg bg-white">
									<i class="fas fa-eye font-30 text-danger"></i>
								</div>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
				</div>
			</div>
		</div> -->
		

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
		<div class="row mt-3">
			<div class="col-md-8">
				<div class="card m-b-30">
					<div class="card-body" style="padding: 0px !important;">
						   <div class="map-container">
             
                  <input runat="server" type="hidden" id="Hidden1">
                  <input runat="server" type="hidden" id="Hidden2">
                  <input runat="server" type="hidden" id="Hidden3">
                  <input runat="server" type="hidden" id="Hidden4">
                  <input runat="server" type="hidden" id="HABITATION">
                  <input runat="server" type="hidden" id="COMPARTMENT">
                  <div id="map"></div>
  
</div>
					</div>
				</div>
		
			</div>
			<div class="col-md-4">
				<div class="card m-b-30">
					<div class="card-header bg-white">
						<h5 class="card-title text-black mb-0">Village Profile</h5>
					</div>
					<div class="card-body p-0 village-bar">
							<div class="accordion" id="accordionExample">
								<div class="card">
									<div class="card-header" id="headingOne">
										<h2 class="mb-0">
											<button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne"
												aria-expanded="true" aria-controls="collapseOne">
												Roads <i class="fa fa-caret-square-down float-right"></i>
											</button>
										</h2>
									</div>
							
									<div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
										<div class="card-body assets-bar">
                                            <ul class="list-unstyled">

                                                <li>
                                                    <input class="form-check-input check_box" type="checkbox" id="Agriculturew" name="check_box" value="option1"/>
                                                    <a id="agriid"><label class="form-check-label"  for="Agriculture">Agriculture (5)</label></a>
                                                    <img src="img/agro.png">
                                                </li>
                                                <div class="sub-assets" id="assets">
                                                    <ul>
                                                        <li>
                                                            <input class="form-check-input" type="checkbox" id="Agriculture1" value="option1">
                                                            <label class="form-check-label" for="Agriculture1">Agriculture1 (1)</label>
                                                            <img src="img/agro.png">
                                                        </li>
                                                        <li>
                                                            <input class="form-check-input" type="checkbox" id="Agriculture2" value="option1">
                                                            <label class="form-check-label" for="Agriculture2">Agriculture2 (2)</label>
                                                            <img src="img/agro.png">
                                                        </li>
                                                    </ul>
                                                </div>
													<li>
														<input class="form-check-input" type="checkbox" id="APSRTC" value="option1">
														<label class="form-check-label" for="APSRTC">APSRTC (5)</label> <img src="img/bus.png">
													</li>
													<li>
														<input class="form-check-input" type="checkbox" id="Diary" value="option1">
														<label class="form-check-label" for="Diary">Diary (5)</label> <img src="img/milk.png">
													</li>
													<li>
														<input class="form-check-input" type="checkbox" id="Education" value="option1">
														<label class="form-check-label" for="Education">Education (5)</label> <img src="img/education.png">
													</li>
													<li>
														<input class="form-check-input" type="checkbox" id="Electricity" value="option1">
														<label class="form-check-label" for="Electricity">Electricity (5)</label> <img src="img/electric-pole.png">
													</li>
												</ul>
										</div>
									</div>
								</div>
							
							</div>


						<!-- <ul class="list-group list-group-flush">
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 1</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 2</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 3</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 4</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 5</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 6</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 7</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 8</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 9</a></li>
							<li class="list-group-item"><a href="" class="text-dark"><i
										class="fa fa-chevron-right text-success"></i> Village Profile 10</a></li>
						</ul> -->
					</div>
				</div>
			</div>
		</div>
		
		<div class="row mt-4 mb-4">
            <%--startcategory--%>
		<%--	<div class="col-md-12">
				<div class="card">
					<div class="card-body">
						<nav>
							<div class="nav nav-tabs" id="nav-tab" role="tablist">
								<a class="nav-item nav-link active text-danger" id="nav-home-tab" data-toggle="tab" href="#nav-home"
									role="tab" aria-controls="nav-home" aria-selected="true">Category 1</a>
								<a class="nav-item nav-link text-success" id="nav-profile-tab" data-toggle="tab" href="#nav-profile"
									role="tab" aria-controls="nav-profile" aria-selected="false">Category 2</a>
								<a class="nav-item nav-link text-info" id="nav-contact-tab" data-toggle="tab" href="#nav-contact"
									role="tab" aria-controls="nav-contact" aria-selected="false">Category 3</a>
							</div>
						</nav>
						<div class="tab-content" id="nav-tabContent">
							<div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
								<div class="row mt-3 mb-3 category">
									
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Education
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-danger float-right">
													<img src="img/education.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>

									
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Health
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-info float-right">
													<img src="img/hospital.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#38b3d6"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#38b3d6"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Rural Water Supply
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-success float-right">
													<img src="img/water.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Govt. Hostels
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-secondary float-right">
													<img src="img/hostel.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Women & Child Welfare
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-danger float-right">
													<img src="img/woman-and-child.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Food & Civil Supplies
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-success float-right">
													<img src="img/rice.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>

									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Agriculture
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-success float-right">
													<img src="img/agro.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
		
								</div>
							</div>
							<div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
								<div class="row mt-3 mb-3 category">
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												APSRTC
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-primary float-right">
													<img src="img/bus.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#3aa0dc"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#3aa0dc"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Diary
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-secondary float-right">
													<img src="img/milk.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Electricity
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-warning float-right">
													<img src="img/electric-pole.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Fibernet
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-info float-right">
													<img src="img/fibernet.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#17a2b8"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#17a2b8"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Finance
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-dark float-right">
													<img src="img/finance.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#343a40"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-dark"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#343a40"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-dark"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Forest
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-primary float-right">
													<img src="img/forest.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#007bff"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#007bff"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>

									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Irrigation
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-warning float-right">
													<img src="img/irrigation.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
		
								</div>
							</div>
							<div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
								<div class="row mt-3 mb-3 category">
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Panchayat Raj
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-primary float-right">
													<img src="img/panchayat.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#3281f2"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#3281f2"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-primary"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Revenue Dept
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-success float-right">
													<img src="img/revenue.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#28a745"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-success"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												SERP
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-info float-right">
													<img src="img/water.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#17a2b8"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#17a2b8"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-info"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Telecom
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-warning float-right">
													<img src="img/telecommunications.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#fb7605"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-warning"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Veterinary
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-secondary float-right">
													<img src="img/veterinary.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#6c757d"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-secondary"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Juvenile Welfare
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-dark float-right">
													<img src="img/agro.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#101214"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-dark"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#101214"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-dark"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
		
									<div class="col-md-6 col-lg-6 col-xl-3">
										<div class="card m-b-30">
											<div class="card-header bg-white">
												Miscellaneous
												<div class="tw-widget-icon tw-widget-icon-bg2 bg-danger float-right">
													<img src="img/agro.png" class="align-self-end ">
												</div>
											</div>
											<div class="card-body">
												<div class="xp-widget-box text-center">
													<div class="row">
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="90" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-up mx-1"></i>112.71%</p>
														</div>
		
														<div class="col-md-6 text-center">
															<input type="text" class="knob" value="40" data-thickness="0.2"
																data-width="100" data-height="100" data-fgColor="#f35956"
																data-readonly="true">
															<div class="knob-label">Title Here</div>
															<p class="mb-0 f-w-5 text-danger"><i
																	class="fa fa-arrow-down mx-1"></i>112.71%</p>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>

								</div>
							</div>
						</div>
					</div>
				</div>
			</div>--%>
            <%--endcategory--%>
		</div>


        <!-- <div class="row mt-4 mb-4 departments">
			<div class="col-md-12 text-center mb-2">
				<h3>Village Departments</h3>
			</div>
            <div class="col-md-3 mb-3">
                <div class="card success">
                    <div class="card-body"><img src="img/agro.png" class="align-self-end ">
                        <h5 class="card-title">Agriculture</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card primary">
                    <div class="card-body"><img src="img/bus.png" class="align-self-end ">
                        <h5 class="card-title">APSRTC</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card secondary">
                    <div class="card-body"><img src="img/milk.png" class="align-self-end ">
                        <h5 class="card-title">Diary</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card danger">
                    <div class="card-body"><img src="img/education.png" class="align-self-end ">
                        <h5 class="card-title">Education</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card warning">
                    <div class="card-body"><img src="img/electric-pole.png" class="align-self-end ">
                        <h5 class="card-title">Electricity</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card info">
                    <div class="card-body"><img src="img/fibernet.png" class="align-self-end ">
                        <h5 class="card-title">Fibernet</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card dark">
                    <div class="card-body"><img src="img/finance.png" class="align-self-end ">
                        <h5 class="card-title">Finance</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card success">
                    <div class="card-body"><img src="img/rice.png" class="align-self-end ">
                        <h5 class="card-title">Food & Civil Supplies</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card primary">
                    <div class="card-body"><img src="img/forest.png" class="align-self-end ">
                        <h5 class="card-title">Forest</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card secondary">
                    <div class="card-body"><img src="img/hostel.png" class="align-self-end ">
                        <h5 class="card-title">Govt. Hostels</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card info">
                    <div class="card-body"><img src="img/hospital.png" class="align-self-end ">
                        <h5 class="card-title">Health</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card warning">
                    <div class="card-body"><img src="img/irrigation.png" class="align-self-end ">
                        <h5 class="card-title">Irrigation</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            
            <div class="col-md-3 mb-3">
                <div class="card dark">
                    <div class="card-body"><img src="img/agro.png" class="align-self-end ">
                        <h5 class="card-title">Juvenile Welfare</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card danger">
                    <div class="card-body"><img src="img/agro.png" class="align-self-end ">
                        <h5 class="card-title">Miscellaneous</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card primary">
                    <div class="card-body"><img src="img/panchayat.png" class="align-self-end ">
                        <h5 class="card-title">Panchayat Raj</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card success">
                    <div class="card-body"><img src="img/revenue.png" class="align-self-end ">
                        <h5 class="card-title">Revenue Dept</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>

            
            <div class="col-md-3 mb-3">
                <div class="card success">
                    <div class="card-body"><img src="img/water.png" class="align-self-end ">
                        <h5 class="card-title">Rural Water Supply</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card info">
                    <div class="card-body"><img src="img/agro.png" class="align-self-end ">
                        <h5 class="card-title">SERP</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card dark">
                    <div class="card-body"><img src="img/telecommunications.png" class="align-self-end ">
                        <h5 class="card-title">Telecom</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card secondary">
                    <div class="card-body"><img src="img/veterinary.png" class="align-self-end ">
                        <h5 class="card-title">Veterinary</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card warning">
                    <div class="card-body"><img src="img/woman-and-child.png" class="align-self-end ">
                        <h5 class="card-title">Women & Child Welfare</h5>
                        <a href="report.html" class="btn btn-sm"><i class="fa fa-angle-double-right"></i> Read more</a>
                    </div>
                </div>
            </div>


        </div> -->
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
   <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script src="linksforcdns/Js/3.3.1.jquery.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
     <script type="text/javascript" src="../MapJsfloder/Dropdownjs.js"></script>
        	<%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
    <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
 <%--   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
    <script src="linksforcdns/Js/1.7.1.jquery.min.js"></script>


    <script src="vendor-assets/popper.js/tooltip.min.js"></script>

	<!-- jQuery Knob -->
	<script src="js/jquery.knob.js"></script>
	<script src="js/widget-inline-charts.js"></script>
	<!-- jQuery Knob -->

    <script type="text/javascript">
        $(document).ready(function () {
            $("#map").hide();s
            $("#map1").show();
            var value = false;
            $("#get_map").click(function () {
                if (value) {
                    $("#map").hide();
                    $("#map1").show();
                }
                else {
                    $("#map").show();
                    $("#map1").hide();
                }
                value = !value;
            });
        });
    </script>

   
    <script type="text/javascript">
        'use strict'
        $(document).ready(function () {
            var src = 'http://65.19.149.210/apkml2/9.kml';// state colour kml source
            mandal_details(src);
            function mandal_details(src) {
                var locations = [];
                var map = new google.maps.Map(document.getElementById('map1'), {
                    zoom: 12,
                    center: new google.maps.LatLng(17.585662, 81.540766),
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                });
                var infowindow = new google.maps.InfoWindow();
                var marker, i;
                for (i = 0; i < locations.length; i++) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                        map: map
                    });
                    google.maps.event.addListener(marker, 'click', (function (marker, i) {
                        return function () {
                            infowindow.setContent(locations[i][0]);
                            // infowindow.setContent(locations[i][0]+locations[i][1])
                            infowindow.open(map, marker);
                        }
                    })
                        (marker, i));
                }
                var kmlLayer = new google.maps.KmlLayer(src, { map: map });
                google.maps.event.addListener(this.kmlLayer, 'click', function (kmlEvent) {
                    self.props.someFunction({ value: kmlEvent.featureData })
                }) //to indicate state as blue colour
            }
        });
	</script>
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
</body>
</html>

