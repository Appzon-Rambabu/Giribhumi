<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ROFR.test.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Meta Tags -->
<meta name="viewport" content="width=device-width,initial-scale=1.0"/>
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<meta name="description" content="" />
<meta name="keywords" content="" />
<meta name="author" content="" />
       
<!-- Page Title -->
<title>Giribhumi - Home</title>

<!-- Favicon and Touch Icons -->
<link href="../assests/images/favicon.png" rel="shortcut icon" type="image/png"/>

<!-- Stylesheet -->
<link href="../assests/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/jquery-ui.min.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/animate.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/css-plugin-collections.css" rel="stylesheet"/>
<link  href="../assests/css/menuzord-megamenu.css" rel="stylesheet"/>
<link  href="../assests/css/menuzord-skins/menuzord-boxed.css" rel="stylesheet"/>
<link href="../assests/css/style-main.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/preloader.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/custom-bootstrap-margin-padding.css" rel="stylesheet" type="text/css"/>
<link href="../assests/css/responsive.css" rel="stylesheet" type="text/css"/>
<!-- <link href="css/style.css" rel="stylesheet" type="text/css"> -->

<!-- Revolution Slider 5.x CSS settings -->
<link  href="../assests/js/revolution-slider/css/settings.css" rel="stylesheet" type="text/css"/>
<link  href="../assests/js/revolution-slider/css/layers.css" rel="stylesheet" type="text/css"/>
<link  href="../assests/js/revolution-slider/css/navigation.css" rel="stylesheet" type="text/css"/>

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
                <li class="m-0 pl-10 pr-10"><%-- <a href="#" class="text-white"><i class="fa fa-phone text-white"></i> 123-456-789</a> --%></li>
                <li class="m-0 pl-10 pr-10"> 
                 <%-- <a href="#" class="text-white"><i class="fa fa-envelope-o text-white mr-5"></i> contact@yourdomain.com</a> --%>
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
              <li class="m-0 pl-10"> <%--<a href="" class="text-white ajaxload-popup"><i class="fa fa-user-o mr-5 text-white"></i> Login /</a>--%> </li>
              <li class="m-0 pl-0 pr-10"> 
              <%--  <a href="" class="text-white ajaxload-popup"><i class="fa fa-edit mr-5"></i>Register</a> --%>
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
                <img class="logo-default" src="../assests/images/cm.jpg" alt="">
                <img class="logo-scrolled-to-fixed" src="../assests/images/cm.jpg" alt="">
                <div class="text-center mt-5 minister-txt">శ్రీ.నారా చంద్రబాబు నాయుడు గారు<br>గౌ.ముఖ్యమంత్రివర్యులు<br>ఆంధ్రప్రదేశ్ ప్రభుత్వం</div>
            </a>
            <a class="menuzord-brand switchable-logo pull-left flip pt-10" href="">
              <img class="logo-default" src="../assests/images/logo-wide.png" alt="" style="max-height: 90px;">
              <img class="logo-scrolled-to-fixed" src="../assests/images/logo-wide.png" alt="" style="max-height: 90px;">
            </a>

            <a class="menuzord-brand switchable-logo pull-right flip pt-5 mr-0 minister2" href="">
                <img class="logo-default" src="../assests/images/minister.jpg" alt="">
                <img class="logo-scrolled-to-fixed" src="../assests/images/minister.jpg" alt="">
                <div class="text-center mt-5 minister-txt">శ్రీ.కిడారి శ్రావణ్ కుమార్ గారు<br>గౌ.మంత్రివర్యులు<br>గిరిజన సంక్షేమం &amp; సాధికారత</div>
            </a>

            <ul class="menuzord-menu">
              <li class="active"><a href="index.aspx">Home</a></li>
            
              
              <li><a href="#home">Giri Bhumi</a>
                <ul class="dropdown">
                  <li><a href="../pages/ROFR_BEATWISE_REPORT.aspx">BeatWise Giri Bhoomi</a></li>
                  <li><a href="../pages/Mee_Giri_Bhoomi.aspx">Mee Giri Bhoomi</a></li>
                </ul>
              </li>

              <li><a href="../pages/Login.aspx">Login</a></li>

             <%-- <li><a href="#">Nav 2</a></li>--%>
              
            </ul>

           
          </nav>
        </div>
      </div>
    </div>
  </header>
        
       


  
  <!-- Start main-content -->
  <div class="main-content">
    <!-- Section: home -->
    <section id="home">
      <div class="container-fluid p-0">
        
        <!-- START REVOLUTION SLIDER 5.0.7 -->
        <div id="rev_slider_home_wrapper" class="rev_slider_wrapper" data-alias="news-gallery34" style="margin:0px auto; background-color:#ffffff; padding:0px; margin-top:0px; margin-bottom:0px;">
          <!-- START REVOLUTION SLIDER 5.0.7 fullwidth mode -->
          <div id="rev_slider_home" class="rev_slider fullwidthabanner" style="display:none;" data-version="5.0.7">
            <ul>
              <!-- SLIDE 1 -->
              <li data-index="rs-1" data-transition="fade" data-slotamount="default" data-easein="default" data-easeout="default" data-masterspeed="default" data-thumb="../assests/images/bg/bg12.jpg" data-rotate="0"  data-fstransition="fade" data-saveperformance="off" data-title="Web Show" data-description="">
                <!-- MAIN IMAGE -->
                <img src="../assests/images/bg/bg12.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina/>
                <!-- LAYERS -->
                
              </li>

              <!-- SLIDE 2 -->
              <li data-index="rs-2" data-transition="fade" data-slotamount="default" data-easein="default" data-easeout="default" data-masterspeed="default" data-thumb="../assests/images/bg/bg2.jpg" data-rotate="0"  data-fstransition="fade" data-saveperformance="off" data-title="Web Show" data-description="">
                <!-- MAIN IMAGE -->
                <img src="../assests/images/bg/bg2.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina>
                <!-- LAYERS -->
                
              </li>

              
            </ul>
            <div class="tp-bannertimer tp-bottom" style="height: 5px; background-color: rgba(255, 255, 255, 0.2);"></div>
          </div>
        </div>

        <!-- END REVOLUTION SLIDER -->
        <script type="text/javascript">
          var tpj=jQuery;
          var revapi34;
          tpj(document).ready(function() {
            if(tpj("#rev_slider_home").revolution == undefined){
              revslider_showDoubleJqueryError("#rev_slider_home");
            }else{
              revapi34 = tpj("#rev_slider_home").show().revolution({
                sliderType:"standard",
                jsFileLocation:"js/revolution-slider/js/",
                sliderLayout:"fullwidth",
                dottedOverlay:"none",
                delay:2000,
                navigation: {
                  keyboardNavigation:"on",
                  keyboard_direction: "horizontal",
                  mouseScrollNavigation:"off",
                  onHoverStop:"on",
                  touch:{
                    touchenabled:"on",
                    swipe_threshold: 75,
                    swipe_min_touches: 1,
                    swipe_direction: "horizontal",
                    drag_block_vertical: false
                  }
                  ,
                  arrows: {
                    style: "hermes",
                    enable: true,
                    hide_onmobile: false,
                    hide_onleave: false,
                    tmp: '<div class="tp-arr-allwrapper"> <div class="tp-arr-imgholder"></div>  <div class="tp-arr-titleholder">{{title}}</div> </div>',
                    left: {
                        h_align: "left",
                        v_align: "center",
                        h_offset: 0,
                        v_offset: 0
                    },
                    right: {
                        h_align: "right",
                        v_align: "center",
                        h_offset: 0,
                        v_offset: 0
                    }
                  },
                  bullets: {
                    enable:false,
                    hide_onmobile:true,
                    hide_under:400,
                    style:"metis",
                    hide_onleave:true,
                    hide_delay:200,
                    hide_delay_mobile:1200,
                    direction:"horizontal",
                    h_align:"center",
                    v_align:"bottom",
                    h_offset:0,
                    v_offset:30,
                    space:5,
                    tmp:'<span class="tp-bullet-img-wrap"><span class="tp-bullet-image"></span></span>'
                  }
                },
                viewPort: {
                  enable:true,
                  outof:"pause",
                  visible_area:"80%"
                },
                responsiveLevels:[1240,1024,778,480],
                gridwidth:[1240,1024,778,480],
                gridheight:[400,350,300,300],
                lazyType:"none",
                parallax: {
                  type:"scroll",
                  origo:"enterpoint",
                  speed:400,
                  levels:[5,10,15,20,25,30,35,40,45,50],
                },
                shadow:0,
                spinner:"off",
                stopLoop:"off",
                stopAfterLoops:-1,
                stopAtSlide:-1,
                shuffle:"off",
                autoHeight:"off",
                hideThumbsOnMobile:"off",
                hideSliderAtLimit:0,
                hideCaptionAtLimit:0,
                hideAllCaptionAtLilmit:0,
                debugMode:false,
                fallbacks: {
                  simplifyAll:"off",
                  nextSlideOnWindowFocus:"off",
                  disableFocusListener:false,
                }
              });
            }
          }); /*ready*/
        </script>
      <!-- END REVOLUTION SLIDER -->

      </div>
    </section>

    <!--<section class="layer-overlay overlay-theme-colored2-9 border-bottom" data-bg-img="../assests/images/bg/bg-pattern.png">
      <div class="container pt-20 pb-20">
        <div class="row">

          <div class="col-md-3 col-xs-12 col-sm-6">
            <select class="form-control" name="" id="">
              <option>Select District</option>
            </select>
          </div>

          <div class="col-md-3 col-xs-12 col-sm-6">
              <select class="form-control" name="" id="">
                <option>Select Division</option>
              </select>
          </div>

          <div class="col-md-2 col-xs-12 col-sm-6">
              <select class="form-control" name="" id="">
                <option>Select Village</option>
              </select>
          </div>

          <div class="col-md-2 col-xs-12 col-sm-6">
              <select class="form-control" name="" id="">
                <option>1 - 90</option>
              </select>
          </div>

          <div class="col-md-2 col-xs-12 col-sm-6">
              <button type="submit" class="btn btn-theme-colored btn-lg form-control">Submit</button>
          </div>

        </div>
          
      </div>
    </section>-->

    <!-- Section: About -->
    <section id="about">
      <div class="container">
        <div class="section-content">
          <div class="row">
            <div class="col-md-12">
              
              <h3 class="font-weight-500 font-30 font- mt-10">MEE GIRI BHOOMI</h3>
              <div class="double-line-bottom-theme-colored-2"></div>
              <%--<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Labore atque officiis maxime suscipit expedita obcaecati nulla in ducimus iure quos quam recusandae dolor quas et perspiciatis voluptatum accusantium delectus nisi reprehenderit,Lorem ipsum dolor sit amet, consectetur adipisicing elit. Labore atque officiis maxime suscipit expedita obcaecati nulla in ducimus iure quos quam recusandae dolor quas et perspiciatis voluptatum accusantium delectus nisi reprehenderit,</p>--%>
              
            </div>
            
          </div>
        </div>
      </div>
    </section>


    <!--start Section-->
   
    <section class="parallax layer-overlay overlay-theme-colored-9" data-bg-img="../assests/images/bg/bg2.jpg" data-parallax-ratio="0.4">
      <div class="container pt-30 pb-30">
        <div class="section-content">
          <div class="row">


              <div class="owl-carousel-5col clients-logo transparent text-center">
                  <div class="item">
                      <div class="funfact text-center">
                          <div class="text-white font-weight-600 font-48"  id="districts" runat="server" data-theme="minimal"></div>
                         <%-- <label class="text-white font-weight-600 font-48"  id="districts" runat="server"></label>--%>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Districts</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="mandals" runat="server" data-theme="minimal"></div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Mandals</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="villages" runat="server" data-theme="minimal">0</div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Villages</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="divisions" runat="server" data-theme="minimal">0</div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Divisions</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="ranges" runat="server" data-theme="minimal">0</div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Ranges</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="beats" runat="server" data-theme="minimal">0</div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Beats</h5>
                      </div>
                  </div>
              </div>
            
          </div>
        </div>
      </div>
    </section>


    <!-- Section: Pricing -->
    <section id="pricing">
      <div class="container pt-70">
        
        <div class="section-content">
          <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-6 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Revenue Wise</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-4 font-16">Districts</label> <label class="col-md-6 font-40 digital-num" id="distcount" runat="server"></label> </li>
                  <li><label class="col-md-4 font-16">Mandals</label>  <label class="col-md-6 font-40 digital-num" id="Mandalcount" runat="server"></label> </li>
                  <li><label class="col-md-4 font-16">Villages</label>  <label class="col-md-6 font-40 digital-num" id="Villcount" runat="server"></label> </li>
                  
                </ul>
                <%--<a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>--%>
              </div>
            </div>


            <div class="col-xs-12 col-sm-6 col-md-6 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Forest Wise</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-4 font-16">Districts</label> <label class="col-md-6 font-40 digital-num"  id="Fdistcount" runat="server"></label>
                    
                      <%--<label class="col-md-4 font-16">Divisions</label> <label class="col-md-2 text-theme-colored2 font-16">12345</label>
                     --%>
                    </li>
                  <li><label class="col-md-4 font-16">Mandals</label> <label class="col-md-6 font-40 digital-num" id="FMandalcount" runat="server"></label>
                      <%--<label class="col-md-4 font-16">Ranges</label> <label class="col-md-2 text-theme-colored2 font-16">12345</label>
                     --%>
                    </li>
                  <li><label class="col-md-4 font-16">Villages</label> <label class="col-md-6 font-40 digital-num" id="Fvillcount" runat="server"></label>
                     <%-- <label class="col-md-4 font-16">Beats</label> <label class="col-md-2 text-theme-colored2 font-16">12345</label>--%>
                  </li>
                  
                </ul>
                <%--<a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>--%>
              </div>
            </div>

                <div class="col-xs-12 col-sm-6 col-md-6 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Forest Wise</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-4 font-16">Divisions</label> <label class="col-md-6 font-40 digital-num" id="Fdivcount" runat="server"></label></li>
                  <li><label class="col-md-4 font-16">Ranges</label> <label class="col-md-6 font-40 digital-num" id="Frangecount" runat="server"></label></li>
                  <li><label class="col-md-4 font-16">Beats</label> <label class="col-md-6 font-40 digital-num" id="Fbeatcount" runat="server"></label></li>
                  
                </ul>
               <%-- <a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>--%>
              </div>
            </div>

            

            <div class="col-xs-12 col-sm-6 col-md-6 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Beneficiaries</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-3 font-16">Total</label> <label class="col-md-3 font-40 digital-num" id="totalbenf" runat="server"></label></li>
                  <li><label class="col-md-3 font-16">Available</label> <label class="col-md-3 font-40 digital-num" id="Abencount" runat="server"></label>
                      <label class="col-md-3 font-16">Percentage</label> <label class="col-md-3 font-40 digital-num" id="Apercount" runat="server"></label>
                  </li>
                  <li><label class="col-md-3 font-16">YTE</label> <label class="col-md-3 font-40 digital-num" id="NAbencount" runat="server"></label>
                      <label class="col-md-3 font-16">Percentage</label> <label class="col-md-3 font-40 digital-num" id="NApercount" runat="server"></label>
                  </li>
                  
                </ul>
               <%-- <a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>--%>
              </div>
            </div>
             
              <%--  <div class="col-xs-12 col-sm-6 col-md-12 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Plot Wise</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-3 font-16">Beneficiaries</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label1" runat="server"></label></li>
                  <li><label class="col-md-3 font-16">Compartment</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label2" runat="server"></label>
                      <label class="col-md-3 font-16">Not entered</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label3" runat="server"></label>
                  </li>
                  <li><label class="col-md-3 font-16">Plo No </label> <label class="col-md-3 text-theme-colored2 font-16" id="Label4" runat="server"></label>
                      <label class="col-md-3 font-16">Not entered</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label5" runat="server"></label>
                  </li>
                     <li><label class="col-md-3 font-16">Habitations</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label6" runat="server"></label>
                      <label class="col-md-3 font-16">Not enetred</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label7" runat="server"> </label>
                  </li>
                     <li><label class="col-md-3 font-16">PlotArea</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label8" runat="server"></label>
                      <label class="col-md-3 font-16">Not entered</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label9" runat="server"></label>
                  </li>
                     <li><label class="col-md-3 font-16">Patta No</label> <label class="col-md-3  text-theme-colored2 font-16" id="Label10" runat="server"></label>
                      <label class="col-md-3 font-16">NA</label> <label class="col-md-3 text-theme-colored2 font-16" id="Label11" runat="server"></label>
                  </li>
                  
                </ul>
                <a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>
              </div>
            </div>--%>















            <div class="col-xs-12 col-sm-6 col-md-12 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Plot Wise</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                  <li><label class="col-md-2 font-16">Beneficiary Records</label> <label class="col-md-2 font-40 digital-num" id="beneficiary" runat="server"></label></li>

                    <li><label class="col-md-2 font-16">Beneficiary Names</label> <label class="col-md-2 font-40 digital-num" id="Ebeneficary" runat="server"></label>
                      <label class="col-md-2 font-40 digital-num" id="Ebenfpercent" runat="server" ></label>
                       
                                              <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEbeneficiary" runat="server"></label>
                 <label class="col-md-2 font-40 digital-num" id="NEbenfpercent" runat="server"></label></li>
                  <li><label class="col-md-2 font-16">Compartment</label> <label class="col-md-2 font-40 digital-num" id="Cmptcount" runat="server"></label>
                      <label class="col-md-2 font-40 digital-num" id="cmptpercent" runat="server" ></label>
                       
                                              <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEcmptcount" runat="server"></label>
                 <label class="col-md-2 font-40 digital-num" id="NEcmptpercent" runat="server"></label></li>
                  <li><label class="col-md-2 font-16">Plot No </label> <label class="col-md-2 font-40 digital-num" id="plotcount" runat="server"></label>
                     <label class="col-md-2 font-40 digital-num" id="plotpercent" runat="server"></label>
                    
                      <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEplotcount" runat="server"></label>
                   <label class="col-md-2 font-40 digital-num" id="NEplotpercent" runat="server"></label>
                    </li>
                     <li><label class="col-md-2 font-16">Habitations</label> <label class="col-md-2 font-40 digital-num" id="Habitations" runat="server"></label>
                     <label class="col-md-2 font-40 digital-num" id="Habpercent" runat="server"></label>
                
                         <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEhabcount" runat="server"> </label>
                  <label class="col-md-2 font-40 digital-num" id="NEhabpercent" runat="server"></label>
                    </li>
                     <li><label class="col-md-2 font-16">PlotArea</label> <label class="col-md-2 font-40 digital-num" id="plotarea" runat="server"></label>
                      <label class="col-md-2 font-40 digital-num" id="plotareapercent" runat="server"></label>
                   
                         <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEplotareacount" runat="server"></label>
                  <label class="col-md-2 font-40 digital-num" id="NEplotareapercent" runat="server"></label>
                    </li>
                     <li><label class="col-md-2 font-16">Patta No</label> <label class="col-md-2  font-40 digital-num" id="Pattano" runat="server"></label>
                     <label class="col-md-2 font-40 digital-num" id="pattapercent" runat="server"></label>
 
                        <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEpattacount" runat="server"></label>
                   <label class="col-md-2 font-40 digital-num" id="NEpattapercent" runat="server"></label>
                    </li>
                     <li><label class="col-md-2 font-16">Aadhaar No</label> <label class="col-md-2  font-40 digital-num" id="Eadhaar" runat="server"></label>
                     <label class="col-md-2 font-40 digital-num" id="Eadharpercent" runat="server"></label>
 
                        <label class="col-md-2 font-16">YTE</label> <label class="col-md-2 font-40 digital-num" id="NEadhaar" runat="server"></label>
                   <label class="col-md-2 font-40 digital-num" id="NEadharpercent" runat="server"></label>
                    </li>
                    
<li><label class="col-md-2 font-16">Invalid Aadhaar No</label> <label class="col-md-2  font-40 digital-num" id="Eadhaar1" runat="server">843</label>
                     <label class="col-md-2 font-40 digital-num" id="Eadharpercent1" runat="server">0.87 %</label>
    </li>

                  
                </ul>
                <%--<a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>--%>
              </div>
            </div>

           <%-- <div class="col-xs-12 col-sm-6 col-md-6 hvr-float-shadow mb-sm-30">
              <div class="pricing-table bg-silver-deep text-center maxwidth400 pt-10">
                <h2 class="package-type text-uppercase line-bottom-centered mb-30">Plot Wise Percentage</h2>
                <ul class="list price-list theme-colored text-left flip check-circle mt-0 mb-20">
                    <li>
                        <label class="col-md-3 font-16">Compartment</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="cmptpercent" runat="server" ></label>
                        <label class="col-md-3 font-16">Not entered</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="NEcmptpercent" runat="server"></label>
                    </li>
                    <li>
                        <label class="col-md-3 font-16">Plot No.</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="plotpercent" runat="server"></label>
                        <label class="col-md-3 font-16">Not entered</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="NEplotpercent" runat="server"></label>
                    </li>
                    <li>
                        <label class="col-md-3 font-16">Habitations</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="Habpercent" runat="server"></label>
                        <label class="col-md-3 font-16">Not entered</label>
                        <label class="col-md-3 text-theme-colored2 font-16" id="NEhabpercent" runat="server"></label>
                    </li>
                    <li>
                        <label class="col-md-3 font-16">PlotArea</label>
                        <label class="col-md-3 text-theme-colored2  font-16" id="plotareapercent" runat="server"></label>
                        <label class="col-md-3 font-16">Not entered</label>
                        <label class="col-md-3 text-theme-colored2 font-16">12345</label>
                    </li>
                    <li>
                        <label class="col-md-3 font-16">Patta No.</label>
                        <label class="col-md-3 text-theme-colored2 font-16"></label>
                        <label class="col-md-3 font-16">Not entered</label>
                        <label class="col-md-3 text-theme-colored2 font-16">12345</label>
                    </li>                
                </ul>
                <a class="btn btn-lg btn-theme-colored text-uppercase btn-block pt-10 pb-10 btn-flat" href="#">View More</a>
              </div>
            </div>
--%>

           

          </div>
        </div>
      </div>
    </section>
      <div style="text-align:center"><span style="color:red; font-size:large">Note: YTE - Yet to be entered</span></div>

    <!-- Section: Courses -->
    <section id="courses" class="bg-silver-deep">
      <div class="container pb-40">
        <div class="section-title">
          <div class="row">
            <div class="col-md-12">
              <h2 class="text-uppercase title">Our <span class="text-theme-colored2">ITDA's</span></h2>              
              <div class="double-line-bottom-theme-colored-2"></div>
						</div>
          </div>
        </div>
        <div class="row mtli-row-clearfix">
          <div class="owl-carousel-3col" data-nav="true">
            <div class="item">
              <div class="course-single-item bg-custom-1 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Chintur</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                     <%-- <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>


            <div class="item">
              <div class="course-single-item bg-custom-2 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Nellore</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                     <%-- <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>


            <div class="item">
              <div class="course-single-item bg-custom-3 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Paderu</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                    <%--  <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <div class="item">
              <div class="course-single-item bg-custom-4 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br/>Parvathipuram</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                      <%--<a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <div class="item">
              <div class="course-single-item bg-custom-5 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Plain Areas</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                     <%-- <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>

            <div class="item">
              <div class="course-single-item bg-custom-6 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Rampa Chodavaram</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                     <%-- <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>


            <div class="item">
              <div class="course-single-item bg-custom-7 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Seethampeta</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                    <li>
                      <%--<a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>


            <div class="item">
              <div class="course-single-item bg-custom-8 border-1px clearfix mb-30">
                <div class="course-details clearfix p-20 pt-15">
                  <div class="course-top-part mb-30">
                    <a href=""><h4 class="mt-0 mb-5 text-center text-white">ITDA<br>Srisailam</h4></a>
                    <h1 class=" text-white text-center mt-10 mb-10 font-30"></h1>
                  </div>
                  
                  <div class="clearfix"></div>
                  
                  <ul class="list-inline course-meta mt-15 text-center">
                   <li>
<%--                      <a href="" class="btn btn-default">View More</a>--%>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
            
          </div>
        </div>
      </div>
    </section>

    
    
    
  </div>
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

<!-- Footer Scripts -->

        <script src="../assests/js/custom.js"></script>

<!-- SLIDER REVOLUTION 5.0 EXTENSIONS (Load Extensions only on Local File Systems ! The following part can be removed on Server for On Demand Loading) -->

<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.actions.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.carousel.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.kenburn.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.layeranimation.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.migration.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.navigation.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.parallax.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.slideanims.min.js"></script>
<script type="text/javascript" src="../assests/js/revolution-slider/js/extensions/revolution.extension.video.min.js"></script>

    </div>
    </form>
</body>
</html>
