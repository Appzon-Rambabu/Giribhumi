<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Villageinfrastructure.aspx.cs" Inherits="ROFR.Villageinfrastructure" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Tribal Welfare</title>
    <link rel="stylesheet" href="GISNew/bower_components/bootstrap/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="GISNew/bower_components/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="GISNew/fonts/stylesheet.css"/>
    <link rel="stylesheet" href="GISNew/css/main.css"/>
    <link rel="stylesheet" href="GISNew/css/select2.css"/>
     <style type="text/css">
               .rotate90
        {
            transform: rotate(90deg);
            -webkit-transform: rotate(90deg);
            -ms-transform: rotate(90deg);
        }
        .rotate180
        {
            transform: rotate(180deg);
            -webkit-transform: rotate(180deg);
            -ms-transform: rotate(180deg);
        }
        .rotate270
        {
            transform: rotate(270deg);
            -webkit-transform: rotate(270deg);
            -ms-transform: rotate(270deg);
        }
        .rotate360
        {
            transform: rotate(360deg);
            -webkit-transform: rotate(360deg);
            -ms-transform: rotate(360deg);
        }
        .rotate-90
        {
            transform: rotate(270deg);
            -webkit-transform: rotate(270deg);
            -ms-transform: rotate(270deg);
        }
        .rotate-180
        {
            transform: rotate(-180deg);
            -webkit-transform: rotate(-180deg);
            -ms-transform: rotate(-180deg);
        }
        .rotate-270
        {
            transform: rotate(90deg);
            -webkit-transform: rotate(90deg);
            -ms-transform: rotate(90deg);
        }
        .rotate-360
        {
            transform: rotate(-360deg);
            -webkit-transform: rotate(-360deg);
            -ms-transform: rotate(-360deg);
        }
          </style>

</head>
<body  onload ="initMap();">

    <header class="main-header">
            <div class="row">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
<div class="col-md-4 text-left">
                            <img src="../Rofrnewassets/images/cm_babu.png" class="img-responsive">
                        </div>
                        <div class="col-md-3">
                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header" style="margin-top: 24px !important;margin-left: 115px !important;
}">
                           
                                <a class="navbar-brand">Village Profile</a>
                            </div>
                        </div>
   
                        <div class="col-md-5">
                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" style="margin-top: 20px !important;
                                                        margin-left: 26px !important;
                                                         font-size: 15px; !important;">
                                <ul class="nav navbar-nav">
                                    <li ><a href="https://giribhumi.ap.gov.in/(S(434ygid1sspwdctxdxkfmmrd))/Villageinfraprofiledashrepo.aspx">Home<span class="sr-only">(current)</span></a></li>
                                    <li class="active"><a href="https://giribhumi.ap.gov.in/(S(434ygid1sspwdctxdxkfmmrd))/Villageinfrastructure.aspx">Asset Gis View</a></li>
                                    <!--<li class="dropdown">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button"
                                            aria-haspopup="true" aria-expanded="false">Reports <span
                                                class="caret"></span></a>
                                        <ul class="dropdown-menu">
                                            <li><a href="https://giribhumi.ap.gov.in/(S(434ygid1sspwdctxdxkfmmrd))/Villageinfraprofiledashreport.aspx">Asset MIS Report</a></li>
                                            <li><a href="https://giribhumi.ap.gov.in/(S(434ygid1sspwdctxdxkfmmrd))/Villageinfraprofiledash.aspx">Asset Percentage Report</a></li>
                                        </ul>
                                    </li>-->
                                </ul>
                            </div> <!-- /.navbar-collapse -->
                        </div>

<div class="col-md-2 text-right">

                           <!-- <img src="../imagesnew/tribalministerpeedika.jpg" class="mx-auto d-block img-fluid" style="height: 65px;">-->
                        </div>
                    </div><!-- /.container-fluid -->
                </nav>
            </div>
    </header>

    <main>
        <div id="map"></div>

        <a  class="myworld hidden-xs">Village Profile</a>
        <!-- <a href="" class="welcome-note hidden-xs"><i class='fa fa-info-circle'></i>Tribal Welfare GIS Monitoring System
            <p id="welcometext">You Are at Location:Plain Areas</p>
        </a> -->

      
        <!-- mobile-header -->
        <header class="mobile-header visible-xs">
           
            <a  class="myworld">Village Profile</a>
        </header>
        <!-- /mobile-header -->
        <!-- sidebar -->
        <div class="sidebar container container--sidebar pull-right full-height" data-offset="0">
            <!-- overview -->
            <section class="overview sidebar__item" data-offset="0">
                <!-- overview-header -->
                <header class="overview__header overview-header overview-block ">
                    <div class="overview-header-wrapper">
                        <h1 class="overview-header__title"></h1>




                    </div>

                

                </header>
                <!-- /overview-header -->
                <!-- <section>
                    <div class="container-fluid">
                        <div class="row">
                            <label class="switch pull-right">
                                <input type="checkbox">
                                <span class="slider round"></span>
                            </label>
                        </div>


                        
                    </div>
               </section> -->
                <!-- grid -->



                <section class="grid">
                    <div class="overview-block overview-block--fluid grid-container">
                        <div class="container-fluid">
                            <form class="active" action="#">
                                <div class="container-fluid">

                                    <div class="row filter-row">
                                        <div class="col-md-3">
                                            <div class="filter">
                                                <select class="select select--gray select2-hidden-accessible"
                                                    tabindex="-1" aria-hidden="true">
                                                    <option value="Name" selected>State</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="filter">
                                                <select class="select select--gray select2-hidden-accessible"
                                                    tabindex="-1" aria-hidden="true">
                                                    <option value="Name" selected>District</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="filter">
                                                <select class="select select--gray select2-hidden-accessible"
                                                    tabindex="-1" aria-hidden="true">
                                                    <option value="Name" selected>ITDA</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="filter">
                                                <select class="select select--gray select2-hidden-accessible"
                                                    tabindex="-1" aria-hidden="true">
                                                    <option value="Name" selected>Mandal</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3" style="margin-top:10px;">
                                            <div class="filter">
                                                <select class="select select--gray select2-hidden-accessible"
                                                    tabindex="-1" aria-hidden="true">
                                                    <option value="Name" selected>Village</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                    <option value="Name">Name</option>
                                                </select>
                                            </div>
                                        </div>

                                    </div>


                                </div>

                            </form>
                            <div class="row">
                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                    <div class="panel panel-default">

                                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel"
                                            aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <div class="row"><a role="button" data-toggle="collapse"
                                                        data-parent="#accordion" href="#collapseTwo"
                                                        aria-expanded="false" aria-controls="collapseTwo"
                                                        class="btn btn-success pull-right">
                                                        Reports
                                                    </a></div>

                                                <div class="row" style="margin-top:10px;">
                                                    <div id="chartContainerNew" style="height: 370px; width: 100%;">
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">

                                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel"
                                            aria-labelledby="headingTwo">
                                            <div class="panel-body">
                                                <div class="row"><a role="button" data-toggle="collapse"
                                                        data-parent="#accordion" href="#collapseOne"
                                                        aria-expanded="true" aria-controls="collapseOne"
                                                        class="btn btn-success pull-right">
                                                        Chart
                                                    </a></div>
                                                <div class="row" style="margin-top:10px;">


                                                    <div class="col-md-12">
                                                        <!-- Nav tabs -->
                                                        <ul class="nav nav-tabs" role="tablist">
                                                            <li role="presentation" class="active"><a href="#home"
                                                                    aria-controls="home" role="tab"
                                                                    data-toggle="tab">ITDA</a></li>
                                                            <li role="presentation"><a href="#plainarea-tab"
                                                                    aria-controls="plainarea-tab" role="tab"
                                                                    data-toggle="tab">Plain Area</a></li>

                                                            <li role="presentation" id="myNav" style="display:none;"><a
                                                                    href="#chintur-tab" aria-controls="chintur-tab"
                                                                    role="tab" data-toggle="tab">Chintur <button
                                                                        id="hide" style="display:none"><i
                                                                            class="fa fa-close"></i></button></a>
                                                            </li>

                                                            <li role="presentation" id="myNav3" style="display:none;"><a
                                                                    href="#chintur-mandal-tab"
                                                                    aria-controls="chintur-mandal-tab" role="tab"
                                                                    data-toggle="tab">Chintur Mandal<button id="hide3"
                                                                        style="display:none"><i
                                                                            class="fa fa-close"></i></button></a>
                                                            </li>

                                                            <li role="presentation" id="myNav4" style="display:none;"><a
                                                                    href="#chintur-village-tab"
                                                                    aria-controls="chintur-village-tab" role="tab"
                                                                    data-toggle="tab">Chintur Vilage<button id="hide4"
                                                                        style="display:none"><i
                                                                            class="fa fa-close"></i></button></a>
                                                            </li>

                                                        </ul>

                                                        <!-- Tab panes -->
                                                        <div class="tab-content">
                                                            <div role="tabpanel" class="tab-pane active" id="home">
                                                                <div class="table-responsive pt-3">
                                                                    <table class="table text-left">
                                                                        <thead>
                                                                            <tr class="text-left">
                                                                                <th class="pt-0">S.No</th>
                                                                                <th class="pt-0">ITDA</th>
                                                                                <th class="pt-0">Mandals</th>
                                                                                <th class="pt-0">GPs</th>
                                                                                <th class="pt-0">Village/Habitation</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><a id="show">Chinturu <a
                                                                                            class="btn cont"
                                                                                            href="#">Continue</a></a>

                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">4
                                                                                    </label></td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">62</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">364</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>2</td>
                                                                                <td>KR Puram</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">9</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">115</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">560</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>3</td>
                                                                                <td>Nellore</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">46</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">838</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">2682</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>4</td>
                                                                                <td>Paderu</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">11</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">245</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">4213</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>5</td>
                                                                                <td>Parvathipuram</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">8</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">216</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">1491</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>6</td>
                                                                                <td>RC Varam</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">12</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">137</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">878</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>7</td>
                                                                                <td>Seethampeta</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">20</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">299</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">1403</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>8</td>
                                                                                <td>Srisailam</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">28</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">102</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">220</label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                            <div role="tabpanel" class="tab-pane" id="plainarea-tab">
                                                                <div class="table-responsive pt-3">
                                                                    <table class="table text-left">
                                                                        <thead>
                                                                            <tr class="text-left">
                                                                                <th class="pt-0">S.No</th>
                                                                                <th class="pt-0">ITDA</th>
                                                                                <th class="pt-0">Mandals</th>
                                                                                <th class="pt-0">GPs</th>
                                                                                <th class="pt-0">Village/Habitation</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><a id="show11">Plain Area</a></td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">40</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">204</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">1,400</label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                            <div role="tabpanel" class="tab-pane" id="chintur-tab">
                                                                <div class="table-responsive pt-3">
                                                                    ITDA
                                                                    <table class="table text-left">
                                                                        <thead>
                                                                            <tr class="text-left">
                                                                                <th class="pt-0">S.No</th>
                                                                                <th class="pt-0">Mandals</th>
                                                                                <th class="pt-0">GPs</th>
                                                                                <th class="pt-0">Village/Habitation</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><a id="show3">Chinturu</a></td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">15</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">117</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>2</td>
                                                                                <td>Kunavaram</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">16</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">72</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>3</td>
                                                                                <td>Nellipaka</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">21</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">107</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>4</td>
                                                                                <td>Vararamachandrapuram</td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">10</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">62</label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>


                                                            <div role="tabpanel" class="tab-pane"
                                                                id="chintur-mandal-tab">
                                                                <div class="table-responsive pt-3">
                                                                    Chintur Mandal
                                                                    <table class="table text-left">
                                                                        <thead>
                                                                            <tr class="text-left">
                                                                                <th class="pt-0">S.No</th>
                                                                                <th class="pt-0">ITDA</th>
                                                                                <th class="pt-0">Mandals</th>
                                                                                <th class="pt-0">GPs</th>
                                                                                <th class="pt-0">Village/Habitation</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><a id="show4">Plain Area</a></td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">40</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">204</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">1,400</label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>


                                                            <div role="tabpanel" class="tab-pane"
                                                                id="chintur-village-tab">
                                                                <div class="table-responsive pt-3">
                                                                    Chintur Village
                                                                    <table class="table text-left">
                                                                        <thead>
                                                                            <tr class="text-left">
                                                                                <th class="pt-0">S.No</th>
                                                                                <th class="pt-0">ITDA</th>
                                                                                <th class="pt-0">Mandals</th>
                                                                                <th class="pt-0">GPs</th>
                                                                                <th class="pt-0">Village/Habitation</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>1</td>
                                                                                <td><a>Plain Area</a></td>
                                                                                <td><label
                                                                                        class="badge badge-success mr-4 mr-xl-2">40</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-danger mr-4 mr-xl-2">204</label>
                                                                                </td>
                                                                                <td><label
                                                                                        class="badge badge-info mr-4 mr-xl-2">1,400</label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
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

                            </div>
                        </div>
                    </div>
                </section>
                <!-- /grid -->



            </section>
            <!-- /overview -->
            <!-- menu -->
        
            <!-- /menu -->
            <!-- places -->
            <section class="places sidebar__item" data-offset="0">
               <%--<i class="fa fa-street-view"></i>--%>
                <div class="places-toggle-wrapper visible-sm visible-md">
                    <button data-toggle-active="" class="places-toggle">
                        <span class="fa fa-bars fa-rotate-90"></span>
                    </button>
                </div>
                <div class="places-outer-wrapper">
                    <div class="places-wrapper">
                        <!-- places-header -->
                        <header class="places-header">
                            <span class="places-header__label">Village Profile</span>
                             <%-- <a class="menu-toggle visible-lg">
                              <span class="fa fa-bars"></span>
                            </a>--%>
                        </header>
                        <!-- /places-header -->
                        <section class="places-block">
                            <header>
                               <%-- <h4 class="places-block__title">Active Indicators:</h4>--%>
                            </header>

                            <h4 class="places-block__title active-status"><a href="#!" data-overview-toggle
                                    class="active"></a></h4>


                        </section>

                        <section class="places-block">
                            <form>
                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                       <select class="form-control" id="District">
							<option value="">Select District</option>
							
						</select>
                                    </div>

                                    <div class="col-md-12 mb-2">
                                      <select class="form-control" id="Itda">
							<option value=" ">Select Itda</option>
							
						</select>
                                    </div>

                                    <div class="col-md-12 mb-2">
                                      <select class="form-control" id="Mandal">
                           <option value=" ">Select Mandal</option>
						</select>
                                    </div>

                                    <div class="col-md-12 mb-2">
                                      <select class="form-control" id="GP">
							<option value=" ">Select GramPanchayat</option>
						</select>
                                    </div>

                                     <div class="col-md-12 mb-2">
                                    <select class="form-control" id="Village">
						<option value=" ">Select Village</option>
						</select>
                                    </div>
                                </div>
                            </form>
                        </section>

                        <section class="places-block">
                            <header>
                              <%--  <h4 class="places-block__title">Departments:</h4>--%>
                            </header>
                            <!-- striped-list -->


                         <%--   <ul class="my-list">
                                <li class="active"><i class="fa fa-building"></i> <a href="#!"
                                        class="menu-toggle">Education</a></li>

                                <li class=""><a href="#!" class="menu-toggle"><i class="fa fa-hospital-o"></i>
                                        Health</a></li>

                                <li class=""><a href="#!" class="menu-toggle"><i class="fa fa-tree"></i> Livelihoods</a>
                                </li>
                            </ul>--%>

                            <!-- /striped-list -->
                        </section>




                    </div>
                </div>
            </section>
            <!-- /places -->
        </div>
        <!-- /sidebar -->
        <!-- <a href="" target="_blank" class="copyright">
            &copy; Tribal Welfare
        </a> -->


        <div id="mySidepanel" class="sidepanel">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()"><i class="fa fa-angle-left"></i></a>
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne1">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne1"
                                aria-expanded="true" aria-controls="collapseOne1">
                                MENU <i class="fa fa-angle-down"></i>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne1" class="panel-collapse collapse in" role="tabpanel"
                        aria-labelledby="headingOne1">
                        <div class="panel-body">
                            <ul class="list-items">
                                <li>
                                   <input class="form-check-input check_box" type="checkbox" id="23" name="check_box" value="option1" onclick="Allassets(23);" checked="checked" />
														 <a id="agriid0" ><label class="form-check-label" for="AllAssets">All Assets</label> </a>
                                </li>
                                <li>
                                     <input class="form-check-input check_box" type="checkbox" id="901" name="check_box" value="option1" checked="checked"  onclick="check(901);">
                                                    <a id="agriid" ><label class="form-check-label"  for="Agriculture">Agriculture</label><label id="9011"></label></a>
                                                    <img src="img/D_Agriculture.png" >
                                </li>
                               
                       

                                <li>
                                    <input class="form-check-input check_box" type="checkbox" id="902" name="check_box" value="option1" checked="checked" onclick="check(902);">
                                                    <a id="agriidh" ><label class="form-check-label"  for="Agriculture">APSRTC</label> <label id="9021"></label></a>
                                                    <img src="img/D_APSRTC.png">
                               </li>
                                  <li>
														<input class="form-check-input check_box" type="checkbox"  id="922" name="check_box" value="option1" onclick="check(922);" checked="checked">
														<a id="agriidh1" ><label class="form-check-label" for="Skill Development">Roads</label><label id="9221"></label></a>
                                       <img src="img/Roadimg.png">
													</li>
                                                 
													<li>
														<input class="form-check-input check_box" type="checkbox" name="check_box" id="903" value="option1" onclick="check(903);" checked="checked">
														<a id="agriidh2" ><label class="form-check-label" for="Diary">Diary</label> <label id="9031"></label></a>
                                                         <img src="img/D_Diary.png">
													</li>
													<li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="904" value="option1" onclick="check(904);" checked="checked">
														<a id="agriidh3" ><label class="form-check-label" for="Education">Education</label><label id="9041"></label></a> <img src="img/D_Education.png">
													</li>
													<li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="905" value="option1" onclick="check(905);" checked="checked">
														<a id="agriidh4" ><label class="form-check-label" for="Electricity">Electricity</label><label id="9051"></label></a> <img src="img/D_Electricity.png">
													</li>
                                                     <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="906" value="option1" onclick="check(906);" checked="checked">
														<a id="agriidh5" ><label class="form-check-label" for="Fibernet">Fibernet</label><label id="9061"></label> </a><img src="img/D_Fibernet.png">
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="907" value="option1" onclick="check(907);" checked="checked">
														<a id="agriidh6" ><label class="form-check-label" for="Finance">Finance</label><label id="9071"></label></a> <img src="img/D_Finance.png">
													</li>
                                                  <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="908" value="option1" onclick="check(908);" checked="checked">
														<a id="agriidh7" ><label class="form-check-label" for="Food & Civil Supplies">Food & Civil Supplies</label> <label id="9081"></label></a><img src="img/D_Food & Civil Supplies.png">
													</li>
                                                  <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="909" value="option1" onclick="check(909);" checked="checked">
														<a id="agriidh8" ><label class="form-check-label" for="Forest">Forest</label><label id="9091"></label></a> <img src="img/D_Forest.png">
													</li>
                                                   <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="910" value="option1" onclick="check(910);" checked="checked">
														<a id="agriidh9" ><label class="form-check-label" for="Govt.Hostels">Govt.Hostels</label><label id="9101"></label></a> <img src="img/D_Govt.Hostels.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="911" value="option1" onclick="check(911);" checked="checked">
														<a id="agriidh10" ><label class="form-check-label" for="Health">Health</label><label id="9111"></label></a> <img src="img/D_Health.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="912" value="option1" onclick="check(912);" checked="checked">
														<a id="agriidh11" ><label class="form-check-label" for="Irrigation">Irrigation</label><label id="9121"></label> </a><img src="img/D_Irrigation.png">
													</li>
                                                  <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="913" value="option1" onclick="check(913);" checked="checked">
														<a id="agriidh12" ><label class="form-check-label" for="JuvenileWelfare">Juvenile Welfare</label><label id="9131"></label></a> <img src="img/D_Juvenile Welfare.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="914" value="option1" onclick="check(914);" checked="checked">
														<a id="agriidh13" ><label class="form-check-label" for="Miscellaneous">Miscellaneous</label><label id="9141"></label></a> <img src="img/D_Miscellaneous.png">
													</li>
                                                   <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="915" value="option1" onclick="check(915);" checked="checked">
														<a id="agriidh14" ><label class="form-check-label" for="PanchayatRaj">Panchayat Raj</label><label id="9151"></label></a> <img src="img/D_Panchayat Raj.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box"   type="checkbox" id="916" value="option1" onclick="check(916);" checked="checked">
														<a id="agriidh15" ><label class="form-check-label" for="Revenue">Revenue</label> <label id="9161"></label></a><img src="img/D_Revenue Dept.png">
													</li>
                                                <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="917" value="option1" onclick="check(917);" checked="checked">
														<a id="agriidh16" ><label class="form-check-label" for="RuralWaterSupply">Rural Water Supply</label><label id="9171"></label></a> <img src="img/D_Rural Water Supply.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="918" value="option1" onclick="check(918);" checked="checked">
														<a id="agriidh17" ><label class="form-check-label" for="SERP">SERP</label><label id="9181"></label></a> <img src="img/D_SERP.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="919" value="option1" onclick="check(919);" checked="checked">
														<a id="agriidh18" ><label class="form-check-label" for="Telecom">Telecom</label><label id="9191"></label></a> <img src="img/D_Telecom.png">
													</li>
                                                  <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="920" value="option1" onclick="check(920);" checked="checked">
														<a id="agriidh19" ><label class="form-check-label" for="Veterinary">Veterinary</label> <label id="9201"></label> </a><img src="img/D_Veterinary.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="921" value="option1" onclick="check(921);" checked="checked">
														<a id="agriidh20" ><label class="form-check-label" for="Women & Child welfare">Women & Child welfare</label><label id="9211"></label></a> <img src="img/D_Women & Child welfare.png">
													</li>
                                                 <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="923" value="option1" onclick="check(923);" checked="checked">
														<a id="agriidh21" ><label class="form-check-label" for="Skill Development">Skill Development</label><label id="9231"></label></a> <img src="img/D_Women & Child welfare.png">
													</li>
                                                <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="924" value="option1" onclick="check(924);" checked="checked">
														<a id="agriidh22" ><label class="form-check-label" for="Skill Development">GCC</label><label id="9241"></label></a> <img src="img/D_Women & Child welfare.png">
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="925" value="option1" onclick="check(925);" checked="checked">
														<a id="agriidh23" ><label class="form-check-label" for="Skill Development">Amusment</label><label id="9251"></label></a> <img src="img/D_Women & Child welfare.png">
                                                        </li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="926" value="option1" onclick="check(926);" checked="checked">
														<a id="agriidh24" ><label class="form-check-label" for="Skill Development">Gas and Petrol</label><label id="9261"></label> </a><img src="img/D_Women & Child welfare.png">
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="927" value="option1" onclick="check(927);" checked="checked">
														<a id="agriidh25" ><label class="form-check-label" for="Skill Development">RTA</label><label id="9271"></label></a> <img src="img/D_Women & Child welfare.png">
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="928" value="option1" onclick="check(928);" checked="checked"/>
														<a id="agriidh26" ><label class="form-check-label" for="Skill Development">ITDA</label><label id="9281"></label> </a><img src="img/D_Women & Child welfare.png"/>
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="929" value="option1" onclick="check(929);" checked="checked"/>
														<a id="agriidh27" ><label class="form-check-label" for="Skill Development">Self Help Group</label><label id="9291"></label> </a><img src="img/D_Women & Child welfare.png"/>
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="930" value="option1" onclick="check(930);" checked="checked"/>
														<a id="agriidh28" ><label class="form-check-label" for="Skill Development">Fire Station</label><label id="9301"></label> </a><img src="img/D_Women & Child welfare.png"/>
													</li>
                                                    <li>
														<input class="form-check-input check_box" name="check_box" type="checkbox" id="931" value="option1" onclick="check(931);" checked="checked"/>
														<a id="agriidh29" ><label class="form-check-label" for="Skill Development">Police Station</label><label id="9311"></label>
                                                            </a> <img src="img/D_Women & Child welfare.png"/>
													</li>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <button class="openbtn" onclick="openNav()"><i class="fa fa-angle-right"></i></button>

    </main>
    <!-- modals  -->
    <div class="modal fade" id="login" tabindex="-1" role="dialog">

        <div class="container-fluid full-height">


            <div class="row full-height">
                <div class="col-lg-4 full-height">
                    <div class="modal-dialog-wrapper full-height">
                        <div class="modal-dialog">

                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span
                                        aria-hidden="true">&times;</span></button>

                            </div>
                            1	Chinturu<br>
2	KR Puram<br>
3	Nellore<br>
4	Paderu<br>
5	Parvathipuram<br>
6	RC Varam<br>
7	Seethampeta<br>
8	Srisailam<br>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- /modals -->


    <div id="wrapper">
        <div class="overlay"></div>

        <!-- Sidebar -->
        <nav class="navbar navbar-inverse navbar-fixed-top" id="sidebar-wrapper" role="navigation">
            <div class="sidebar-body">
                <div class="legend">
                    <div class="row">
                        <h4 class="text-center">Legend</h4>
                        <p class="text-center">Litarate</p>
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#594627"></i> - 0 - 10%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#b26000"></i> - 10% - 20%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#ca8500"></i> - 20% - 30%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#ffae11"></i> - 30% - 40%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#F7B36C"></i> - 40% - 50%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#2bff7a"></i> - 50% - 60%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#18ff32"></i> - 60% - 70%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#7FFF00"></i> - 70% - 80%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#009111"></i> - 80% - 90%</span>
                    
                        <span class="col-md-12"><i class="fa fa-circle" style="color:#00660c"></i> - 90% - 100%</span>
                    </div>
                    </div>

                <a href="#" class="close"><i class="fa fa-close"></i></a>
            </div>
        </nav><!-- /#sidebar-wrapper -->

        <div id="page-content-wrapper">
          <%--  <button type="button" class="hamburger open-nav is-closed animated fadeInLeft">
                <i class="fa fa-dot-circle-o"></i>
            </button>--%>

        </div><!-- /#page-content-wrapper -->
    </div><!-- /#wrapper -->


    <!-- mobile menu -->
    <nav class="mobile-menu">
        <div class="mobile-menu-wrapper">
            <a href="#!" class="menu-item menu-item-active menu-item--mobile" data-overview-toggle>
                <i class="menu-item__icon fa fa-circle"></i> <span class="menu-item__title">Illitarate &gt; 6%</span>
            </a>
            <a href="" class="menu-item menu-item--mobile">
                <i class="menu-item__icon fa fa-circle"></i> <span class="menu-item__title">Litarate &gt; 3% to
                    6%</span>
            </a>
            <a href="" class="menu-item menu-item--mobile">
                <i class="menu-item__icon fa fa-circle"></i> <span class="menu-item__title">Illitarate &lt; 3%</span>
            </a>
        </div>
    </nav>
    <!--  -->
       <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModal">
        <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div id="loader">
                <div id="status2"></div>
<p>Loading...</p>
            </div>
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="exampleModal">Village Profile Images</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-8">
                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->

                        
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" role="listbox">
                                <div class="item active" id="imgh1">
                                
                                        <img id="img1" src="#" alt="" />
                                          
                                    
                                  
                                   <label class="card-title text-white mb-0 long-latitude" id="lblprofile"></label> 
                                    <div class="rotate-buttons">
                                       <img src="images/clockWiseDirection.png" id="imgClockWise" alt="Clock Wise Direction" title="Clock Wise Direction"  onclick="Rotate(0,'img1')" />
                                          <img src="images/counterclockWiseDirection.png" id="imgCounterClockWise" alt="Counter Clock Wise Direction" title="Counter Clock Wise Direction"  onclick="Rotate(1,'img1')" />
                                        </div>
                                </div>
                                <div class="item" id="imgh2">
                                   
                                        <img id="img2" src="#" alt="" />
                                        
                                   
                                    
                                    <label class="card-title text-white mb-0 long-latitude" id="lblprofile1"></label> 
                                    <div class="rotate-buttons">
                                        <img src="images/clockWiseDirection.png" id="imgClockWise1" alt="Clock Wise Direction" title="Clock Wise Direction"  onclick="Rotate(0,'img2')" />
                                          <img src="images/counterclockWiseDirection.png" id="imgCounterClockWise1" alt="Counter Clock Wise Direction" title="Counter Clock Wise Direction" onclick="Rotate(1,'img2')" />
                                        </div>
                                 
                                </div>
                                <div class="item" id="imgh3">
                                 
                                        <img id="img3" src="#" alt="" />
                                        
                               
                                    
                                    <label class="card-title text-white mb-0 long-latitude" id="lblprofile2"  ></label> 
                                    <div class="rotate-buttons">
                                      <img src="images/clockWiseDirection.png" id="imgClockWise2" alt="Clock Wise Direction" title="Clock Wise Direction"  onclick="Rotate(0,'img3')" />
                                          <img src="images/counterclockWiseDirection.png" id="imgCounterClockWise2" alt="Counter Clock Wise Direction" title="Counter Clock Wise Direction"  onclick="Rotate(1,'img3')" />
                                        </div>
                                     
                                </div>
                            </div>
                        
                            <!-- Controls -->
                            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                <span class="fa fa-chevron-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                <span class="fa fa-chevron-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card mb-3">
                           <div id="map1" class="gmaps" style="width:100%;height:220px;position:relative;overflow:hidden"></div>
                        </div>
                        <div class="card mb-3">
                            <div class="card-body">
                               <div id="AssetDetails">
                        <div class="col-md-12">
                                                
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> DEPARTMENT </label></div>
                                <div class="col-md-6"><label id="DEP" for="road-name" class="text-success"> </label></div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> ASSET NAME </label></div>
                                <div class="col-md-6"><label id="ASSET" for="road-name" class="text-success">  </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> SUBASSET NAME </label></div>
                                <div class="col-md-6"><label id="SUBASSET" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> CONDITION </label></div>
                                <div class="col-md-6"><label id="Con" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
 <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> Facilities </label></div>
                                <div class="col-md-6"><select class="form-control" id="facility">
						<option value="">Select</option>
						</select>
                                </div>

  
                            </div>
                              <div class="row mb-1">
                                  <div class="col-md-6"><label for="road-name">  </label></div>
                                  </div>
                             <div class="row mb-6">

                             <table id="mytable1" border='1' >
                                 <thead>
    <tr>
        <th bgcolor="#12be7e">Name</th>
         <th bgcolor="#12be7e">Value</th>
    </tr>
                                      </thead>
</table>

                                   </div>
                    
                        </div>
                            </div>
                               <div id="RoadDetails">
 <div class="col-md-12">
                                                
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> ROAD NAME </label></div>
                                <div class="col-md-6"><label id="RN" for="road-name" class="text-success"> </label></div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> ROAD CATEGORY </label></div>
                                <div class="col-md-6"><label id="RC" for="road-name" class="text-success">  </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> ROAD LENGTH </label></div>
                                 <div class="col-md-6"><label id="RL" for="road-name" class="text-success"> </label>
                                    
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6"><label for="road-name"> ROAD TYPE </label></div>
                                <div class="col-md-6"><label id="RT" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> ROAD CONNECTING FROM </label></div>
                                <div class="col-md-6"><label id="RCF" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> ROAD CONNECTING TO </label></div>
                                <div class="col-md-6"><label id="RCT" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> ROAD CONNECTION NAME </label></div>
                                <div class="col-md-6"><label id="RCN" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> ROAD CONDITION </label></div>
                                <div class="col-md-6"><label id="RCC" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> DEPARTMENT </label></div>
                                <div class="col-md-6"><label id="DEPA" for="road-name" class="text-success"> </label>
                                </div>
                            </div>
                            <div class="row mb-1">
                                   <div class="col-md-6"><label for="road-name"> ROAD TRANSPORT TYPE </label></div>
                                  <div class="col-md-6"><label id="RTT" for="road-name" class="text-success"></label>
                                </div>
                            </div>
                        </div>
					</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
            </div>
        </div>
        </div>
    </div>
    <script type="text/javascript" src="GISNew/js/bundle.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/build/myworld.js?0"></script>
    <script type="text/javascript" src="GISNew/js/myworld/dummy.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/map-init--index.js"></script>
     <script type="text/javascript" src="../MapJsfloder/Dropdownjs2.js"></script>
 <script type="text/javascript" src="../MapJsfloder/chartjs1.js"></script>
   
      <%--	<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVXFWjSgWqaHrZHdrjaWLUC2a9Z38f8">
    </script>--%>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVXFWjSgWqaHrZHdrjaWLUC2a9Z38f8"></script>
  
        	  <!-- <script type="text/javascript" src="../MapJsfloder/keymap.js"></script> -->
    <!--   zolotukhin!  -->
 
 
    <script>
        window.onload = function () {

            var chart = new CanvasJS.Chart("chartContainerNew", {
                theme: "light2", // "light1", "light2", "dark1", "dark2"
                exportEnabled: true,
                animationEnabled: true,
                title: {
                    text: "Desktop Browser Market Share in 2016"
                },
                data: [{
                    type: "pie",
                    startAngle: 25,
                    toolTipContent: "<b>{label}</b>: {y}%",
                    showInLegend: "true",
                    legendText: "{label}",
                    indexLabelFontSize: 16,
                    indexLabel: "{label} - {y}%",
                    dataPoints: [
                        { y: 51.08, label: "Chrome" },
                        { y: 27.34, label: "Internet Explorer" },
                        { y: 10.62, label: "Firefox" },
                        { y: 5.02, label: "Microsoft Edge" },
                        { y: 4.07, label: "Safari" },
                        { y: 1.22, label: "Opera" },
                        { y: 0.44, label: "Others" }
                    ]
                }]
            });
            chart.render();

        }
    </script>

    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
    <script>
        $(document).ready(function () {
            var open = $('.open-nav'),
                close = $('.close'),
                overlay = $('.overlay');

            open.click(function () {
                overlay.show();
                $('#wrapper').addClass('toggled');
            });

            close.click(function () {
                overlay.hide();
                $('#wrapper').removeClass('toggled');
            });
        });
    </script>
    <script>
        function openNav() {
            document.getElementById("mySidepanel").style.width = "250px";
        }

        function closeNav() {
            document.getElementById("mySidepanel").style.width = "0";
        }
    </script>
</body>
</html>