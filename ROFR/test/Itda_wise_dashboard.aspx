<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Itda_wise_dashboard.aspx.cs" Inherits="ROFR.test.Itda_wise_dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <!-- Meta Tags -->
    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="" />

    <!-- Page Title -->
    <title>Giribhumi - Innerpage</title>
  <!-- Favicon and Touch Icons -->
    <link href="../assests/images/favicon.png" rel="shortcut icon" type="image/png"/>

    <!-- Stylesheet -->
    <link href="../assests/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/jquery-ui.min.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/animate.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/css-plugin-collections.css" rel="stylesheet" />
    <link href="../assests/css/menuzord-megamenu.css" rel="stylesheet" />
    <link  href="../assests/css/menuzord-skins/menuzord-boxed.css" rel="stylesheet" />
    <link href="../assests/css/style-main.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/preloader.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/custom-bootstrap-margin-padding.css" rel="stylesheet" type="text/css"/>
    <link href="../assests/css/responsive.css" rel="stylesheet" type="text/css"/>
    <!-- <link href="css/style.css" rel="stylesheet" type="text/css"> -->
    <!-- Revolution Slider 5.x CSS settings -->
    <link href="../assests/js/revolution-slider/css/settings.css" rel="stylesheet" type="text/css" />
    <link href="../assests/js/revolution-slider/css/layers.css" rel="stylesheet" type="text/css" />
    <link href="../assests/js/revolution-slider/css/navigation.css" rel="stylesheet" type="text/css" />

    <link href="../assests/css/colors/theme-skin-color-set2.css" rel="stylesheet" type="text/css"/>

    <script src="../assests/js/jquery-2.2.4.min.js"></script>
    <script src="../assests/js/jquery-ui.min.js"></script>
    <script src="../assests/js/bootstrap.min.js"></script>
    <script src="../assests/js/jquery-plugin-collection.js"></script>

    <script src="../assests/js/revolution-slider/js/jquery.themepunch.tools.min.js"></script>
    <script src="../assests/js/revolution-slider/js/jquery.themepunch.revolution.min.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div id="wrapper" class="clearfix">
        <!-- preloader -->
        <div id="preloader">
            <div id="spinner">
                <img alt="" src="../assests/images/preloaders/1.gif"/>
            </div>
            <div id="disable-preloader" class="btn btn-default btn-sm">Disable Preloader</div>
        </div>

        <!-- Header -->
        <header id="header" class="header">
            <div class="header-top bg-theme-colored2 sm-text-center">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="widget text-white">
                                <ul class="list-inline xs-text-center text-white">
                                    <li class="m-0 pl-10 pr-10"> <a href="#" class="text-white"><i class="fa fa-phone text-white"></i> 123-456-789</a> </li>
                                    <li class="m-0 pl-10 pr-10">
                                        <a href="#" class="text-white"><i class="fa fa-envelope-o text-white mr-5"></i> contact@yourdomain.com</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-4 pr-0">
                            <div class="widget">
                                <ul class="styled-icons icon-sm pull-right flip sm-pull-none sm-text-center mt-5">
                                    <li><a href="#"><i class="fa fa-facebook text-white"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter text-white"></i></a></li>
                                    <li><a href="#"><i class="fa fa-google-plus text-white"></i></a></li>
                                    <li><a href="#"><i class="fa fa-instagram text-white"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin text-white"></i></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <ul class="list-inline sm-pull-none sm-text-center text-right text-white mb-sm-20 mt-10">
                                <li class="m-0 pl-10"> <a href="" class="text-white ajaxload-popup"><i class="fa fa-user-o mr-5 text-white"></i> Login /</a> </li>
                                <li class="m-0 pl-0 pr-10">
                                    <a href="" class="text-white ajaxload-popup"><i class="fa fa-edit mr-5"></i>Register</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="header-nav">
                <div class="header-nav-wrapper navbar-scrolltofixed nav-lg">
                    <div class="container-fluid">

                        <nav id="menuzord-right" class="menuzord default no-bg">
                            <a class="menuzord-brand switchable-logo pull-left flip pt-5 minister1" href="">
                                <img class="logo-default" src="../assests/images/cm.jpg" alt=""/>
                                <img class="logo-scrolled-to-fixed" src="../assests/images/cm.jpg" alt=""/>
                                <div class="text-center mt-5 minister-txt">శ్రీ.నారా చంద్రబాబు నాయుడు గారు<br>గౌ.ముఖ్యమంత్రివర్యులు<br>ఆంధ్రప్రదేశ్ ప్రభుత్వం</div>
                            </a>
                            <a class="menuzord-brand switchable-logo pull-left flip pt-10" href="">
                                <img class="logo-default" src="../assests/images/logo-wide.png" alt="" style="max-height: 90px;"/>
                                <img class="logo-scrolled-to-fixed" src="../assests/images/logo-wide.png" alt="" style="max-height: 90px;"/>
                            </a>

                            <a class="menuzord-brand switchable-logo pull-right flip pt-5 mr-0 minister2" href="">
                                <img class="logo-default" src="../assests/images/minister.jpg" alt=""/>
                                <img class="logo-scrolled-to-fixed" src="../assests/images/minister.jpg" alt=""/>
                                <div class="text-center mt-5 minister-txt">శ్రీ.కిడారి శ్రావణ్ కుమార్ గారు<br>గౌ.మంత్రివర్యులు<br>గిరిజన సంక్షేమం &amp; సాధికారత</div>
                            </a>

                            <ul class="menuzord-menu">
                                <li class="active"><a href="#">Home</a></li>


                                <li>
                                    <a href="#home">Drop Down</a>
                                    <ul class="dropdown">
                                        <li><a href="">Dropdown 1</a></li>
                                        <li><a href="">Dropdown 2</a></li>
                                    </ul>
                                </li>

                                <li><a href="#">Nav 1</a></li>

                                <li><a href="#">Nav 2</a></li>

                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </header>

        <!-- Start main-content -->
        <div class="main-content">

            <!--start Section-->
            <section class="parallax layer-overlay overlay-theme-colored-9" data-bg-img="../assests/images/bg/bg2.jpg" data-parallax-ratio="0.4">
                <div class="container pt-30 pb-30">
                    <div class="section-content">
                        <div class="row">


                            <div class="owl-carousel-5col clients-logo transparent text-center">
                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="5100" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Districts</h5>
                                    </div>
                                </div>

                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="200" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Mandals</h5>
                                    </div>
                                </div>

                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="100" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Villages</h5>
                                    </div>
                                </div>

                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="600" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Divisions</h5>
                                    </div>
                                </div>

                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="600" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Ranges</h5>
                                    </div>
                                </div>

                                <div class="item">
                                    <div class="funfact text-center" data-toggle="modal" data-target="#myModal">
                                        <div class="odometer-animate-number text-white font-weight-600 font-48" data-value="600" data-theme="minimal">0</div>
                                        <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                                        <h5 class="text-white text-uppercase mb-0">Beats</h5>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>



            <section class="layer-overlay overlay-white-9" data-bg-img="../assests/images/bg/bg-pattern.png" style="background-image: url(&quot;images/bg/bg-pattern.png&quot;);">
                <div class="container pb-40">
                    <div class="section-content">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="icon-box hover-effect border-1px border-radius-10px text-center bg-white p-15 pt-40 pb-30">
                                    <a href="#" class="icon icon-circled icon-lg" data-bg-color="#FC9928" style="background: rgb(252, 153, 40) !important;">
                                        <i class="pe-7s-study text-white font-48"></i>
                                    </a>
                                    <h4 class="icon-box-title text-uppercase letter-space-1 font-20 mt-15"><a href="#">Category 1</a></h4>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="icon-box hover-effect border-1px border-radius-10px text-center bg-white p-15 pt-40 pb-30">
                                    <a href="#" class="icon icon-circled icon-lg" data-bg-color="#43B14B" style="background: rgb(67, 177, 75) !important;">
                                        <i class="pe-7s-notebook text-white font-48"></i>
                                    </a>
                                    <h4 class="icon-box-title text-uppercase letter-space-1 font-20 mt-15"><a href="#">Category 2</a></h4>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="icon-box hover-effect border-1px border-radius-10px text-center bg-white p-15 pt-40 pb-30">
                                    <a href="#" class="icon icon-circled icon-lg" data-bg-color="#00C3CB" style="background: rgb(0, 195, 203) !important;">
                                        <i class="pe-7s-diamond text-white font-48"></i>
                                    </a>
                                    <h4 class="icon-box-title text-uppercase letter-space-1 font-20 mt-15"><a href="#">Category 3</a></h4>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="icon-box hover-effect border-1px border-radius-10px text-center bg-white p-15 pt-40 pb-30">
                                    <a href="#" class="icon icon-circled icon-lg" data-bg-color="#EF5861" style="background: rgb(239, 88, 97) !important;">
                                        <i class="pe-7s-medal text-white font-48"></i>
                                    </a>
                                    <h4 class="icon-box-title text-uppercase letter-space-1 font-20 mt-15"><a href="#">Category 4</a></h4>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>


        </div>
        <!-- end main-content -->
        <!-- Footer -->
        <footer id="footer" class="footer divider layer-overlay overlay-dark-8">
            <!--<div class="container pt-70 pb-40">
              <div class="row">
                <div class="col-sm-6 col-md-3">
                  <div class="widget dark">
                    <img class="mt-5 mb-20" alt="" src="images/logo-white-footer.png">
                    <ul class="list-inline mt-5">
                      <li class="m-0 pl-10 pr-10"> <i class="fa fa-phone text-theme-colored2 mr-5"></i> <a class="text-gray" href="#">123-456-789</a> </li>
                      <li class="m-0 pl-10 pr-10"> <i class="fa fa-envelope-o text-theme-colored2 mr-5"></i> <a class="text-gray" href="#">support@giribhumi.ap.gov.in</a> </li>
                      <li class="m-0 pl-10 pr-10"> <i class="fa fa-globe text-theme-colored2 mr-5"></i> <a class="text-gray" href="#">www.giribhumi.ap.gov.in</a> </li>
                    </ul>
                    <ul class="styled-icons icon-sm icon-bordered icon-circled clearfix mt-10">
                      <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                      <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                      <li><a href="#"><i class="fa fa-vk"></i></a></li>
                      <li><a href="#"><i class="fa fa-instagram"></i></a></li>
                      <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                    </ul>
                  </div>
                </div>
                <div class="col-sm-6 col-md-3">
                  <div class="widget dark">
                    <h4 class="widget-title line-bottom-theme-colored-2">Useful Links</h4>
                    <ul class="angle-double-right list-border">
                      <li><a href="#">Home Page</a></li>
                      <li><a href="#">About Us</a></li>
                      <li><a href="#">Beatwise Giribhumi</a></li>
                      <li><a href="#">Support</a></li>
                      <li><a href="#">FAQ</a></li>
                    </ul>
                  </div>
                </div>
                <div class="col-sm-6 col-md-3">
                  <div class="widget dark">
                    <h4 class="widget-title line-bottom-theme-colored-2">Top News</h4>
                    <div class="latest-posts">
                      <article class="post media-post clearfix pb-0 mb-10">
                        <a class="post-thumb" href="#"><img src="https://placehold.it/80x55" alt=""></a>
                        <div class="post-right">
                          <h5 class="post-title mt-0 mb-5"><a href="#">News 1</a></h5>
                          <p class="post-date mb-0 font-12">Mar 08, 2015</p>
                        </div>
                      </article>
                      <article class="post media-post clearfix pb-0 mb-10">
                        <a class="post-thumb" href="#"><img src="https://placehold.it/80x55" alt=""></a>
                        <div class="post-right">
                          <h5 class="post-title mt-0 mb-5"><a href="#">News 2</a></h5>
                          <p class="post-date mb-0 font-12">Mar 08, 2015</p>
                        </div>
                      </article>
                      <article class="post media-post clearfix pb-0 mb-10">
                        <a class="post-thumb" href="#"><img src="https://placehold.it/80x55" alt=""></a>
                        <div class="post-right">
                          <h5 class="post-title mt-0 mb-5"><a href="#">News 3</a></h5>
                          <p class="post-date mb-0 font-12">Mar 08, 2015</p>
                        </div>
                      </article>
                    </div>
                  </div>
                </div>
                <div class="col-sm-6 col-md-3">
                  <div class="widget dark">
                    <h4 class="widget-title line-bottom-theme-colored-2">Opening Hours</h4>
                    <div class="opening-hours">
                      <ul class="list-border">
                        <li class="clearfix"> <span> Mon - Tues :  </span>
                          <div class="value pull-right"> 6.00 am - 10.00 pm </div>
                        </li>
                        <li class="clearfix"> <span> Wednes - Thurs :</span>
                          <div class="value pull-right"> 8.00 am - 6.00 pm </div>
                        </li>
                        <li class="clearfix"> <span> Fri : </span>
                          <div class="value pull-right"> 3.00 pm - 8.00 pm </div>
                        </li>
                        <li class="clearfix"> <span> Sun : </span>
                          <div class="value pull-right bg-theme-colored2 text-white closed"> Closed </div>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            -->
            <div class="footer-bottom" data-bg-color="#2b2d3b">
                <div class="container pt-20 pb-20">
                    <div class="row">
                        <div class="col-md-6">
                            <p class="font-12 text-black-777 m-0 sm-text-center">Copyright &copy;2019 Andhra Pradesh Giribhumi. All Rights Reserved</p>
                        </div>
                        <div class="col-md-6 text-right">
                            <div class="widget no-border m-0">
                                <ul class="list-inline sm-text-center mt-5 font-12">
                                    <li>
                                        Designed, Developed By<a href="#"> Codetree.in</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
        <a class="scrollToTop" href="#"><i class="fa fa-angle-up"></i></a>
    </div>
    <!-- end wrapper -->
    <!-- Districts Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">District</h4>
                </div>
                <div class="modal-body">
                    1.Name<br>
                    2.Name 2
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Districts Modal -->
    <!-- Footer Scripts -->
    <!-- JS | Custom script for all pages -->
    <script src="../assests/js/custom.js"></script>
    </div>
    </form>
</body>
</html>
