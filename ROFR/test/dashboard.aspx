<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ROFR.test.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         
<!-- Meta Tags -->
<meta name="viewport" content="width=device-width,initial-scale=1.0"/>
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<meta name="description" content="" />
<meta name="Subject" content="Giribhumi"/>
<meta name="Subject" content="Tribal Welfare Department Giribhumi AP" />
<meta name="Subject" content="TWD Giribhumi AP" />
<meta name="keywords" content="ROFR lands AP,ROFR Lands Andhra Pradesh,Giribhumi,Giribhumi Rofr Lands, Tribal welfare department ROFR Lands Andhra pradesh,
    Tribal welfare department ROFR Lands AP,Giribhumi Tribal welfare AP,Giribhumi Tribal welfare Andhra Pradesh,ROFR AP,ROFR Andhra Pradesh,Rofr Lands Giribhumi,
    Tribal welfare Department Giribhumi Andhra Pradesh,Tribal welfare department giribhumi AP,TWD giribhumo Andhra Pradesh" />
<meta name="author" content="" />

    
<!-- Page Title -->
<title>Giribhumi - Home</title>

<!-- Favicon and Touch Icons -->
<link href="../newcss/images/favicon.png" rel="shortcut icon" type="image/png"/>

<!-- Stylesheet -->
<link href="../newcss/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/jquery-ui.min.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/animate.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/css-plugin-collections.css" rel="stylesheet"/>
<link href="../newcss/css/menuzord-megamenu.css" rel="stylesheet"/>
<link href="../newcss/css/menuzord-skins/menuzord-boxed.css" rel="stylesheet"/>
<link href="../newcss/css/style-main.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/preloader.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/custom-bootstrap-margin-padding.css" rel="stylesheet" type="text/css"/>
<link href="../newcss/css/responsive.css" rel="stylesheet" type="text/css"/>
<!-- <link href="css/style.css" rel="stylesheet" type="text/css"> -->

<!-- Revolution Slider 5.x CSS settings -->
<link  href="../newcss/js/revolution-slider/css/settings.css" rel="stylesheet" type="text/css"/>
<link  href="../newcss/js/revolution-slider/css/layers.css" rel="stylesheet" type="text/css"/>
<link  href="../newcss/js/revolution-slider/css/navigation.css" rel="stylesheet" type="text/css"/>

<link href="../newcss/css/colors/theme-skin-color-set2.css" rel="stylesheet" type="text/css"/>

<%--<script src="../newcss/js/jquery-2.2.4.min.js"></script>--%>
       <script src="../newcss/js/jquery-3.4.1.min.js"></script>
<script src="../newcss/js/jquery-ui.min.js"></script>
<script src="../newcss/js/bootstrap.min.js"></script>
<script src="../newcss/js/jquery-plugin-collection.js"></script>

<script src="../newcss/js/revolution-slider/js/jquery.themepunch.tools.min.js"></script>
<script src="../newcss/js/revolution-slider/js/jquery.themepunch.revolution.min.js"></script>

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
      <img alt="" src="../newcss/images/preloaders/1.gif"/>
    </div>
    <div id="disable-preloader" class="btn btn-default btn-sm">Disable Preloader</div>
  </div>
  
  <!-- Header -->
  <header id="header" class="header">
    <div class="header-nav">
      <div class="header-nav-wrapper navbar-scrolltofixed nav-lg">
        <div class="container-fluid">

          <nav id="menuzord-right" class="menuzord default no-bg justify-content-center">
           <a class="menuzord-brand switchable-logo pull-left flip pt-5 minister1" href="">
                 <img class="logo-default" src="../imagesnew/jcm.jpeg" alt=""/>
              <img class="logo-scrolled-to-fixed" src="../imagesnew/newcmimg.jpeg" alt=""/>
         <div class="text-center text-white" style="font-size:10px;">శ్రీ.వై.ఎస్.జగన్ మోహన్ రెడ్డి గారు<br />గౌ.ముఖ్యమంత్రివర్యులు<br />ఆంధ్రప్రదేశ్ ప్రభుత్వం</div>
            </a>
            <a class="menuzord-brand switchable-logo flip pt-20 ml-50" href="">
              <img class="logo-default" src="../newcss/images/logo-wide.png" alt="" style="max-height: 90px;"/>
              <img class="logo-scrolled-to-fixed" src="../newcss/images/logo-wide.png" alt="" style="max-height: 90px;"/>
            </a>

            <a class="menuzord-brand switchable-logo pull-right flip pt-5 mr-0 minister2" href="">
             <img class="logo-default" src="../imagesnew/Tribal-Minister.jpg" alt="">
             <img class="logo-scrolled-to-fixed" src="../imagesnew/minister.jpeg" alt="">
         <div class="text-center text-white" style="font-size:10px;">శ్రీమతి.పి.పుష్ప శ్రీవాణి గారు<br />గౌ.ఉప ముఖ్యమంత్రివర్యులు<br />గిరిజన సంక్షేమ శాఖ</div>
            </a>

            <ul class="menuzord-menu pt-10">
              <li class="active"><a href="../pages/dashboard.aspx">Home</a></li>
            
              
              <li><a href="#home">Reports</a>
                <ul class="dropdown">
                  <%--  <li><a href="../pages/ROFR_BEATWISE_REPORT.aspx">BeatWise Giri Bhoomi</a></li>
                  <li><a href="../pages/Mee_Giri_Bhoomi.aspx">Mee Giri Bhoomi</a></li>--%>
                     <%--<li><a href="../pages/Epassbook.aspx">EPASSBOOK</a></li>--%>
                 <li><a href="../pages/ItdawiseLandDetails.aspx">LAND SUMMARY REPORT</a></li>
                  <li><a href="../pages/ITDAWISE_POPULATION_REPORT.aspx">POPULATION REPORT</a></li>
                 
                </ul>
              </li>

              <li><a href="../pages/Login.aspx">Login</a></li>

              
            </ul>

           
          </nav>
        </div>
      </div>
    </div>
  </header>
  
  <!-- Start main-content -->
  <div class="main-content">
    

    


    <!--start Section-->
      <section class="parallax layer-overlay overlay-theme-colored-9" data-bg-img="../newcss/images/bg/bg12.jpg" data-parallax-ratio="0.4" style="background-size:cover;">
          <div class="container pt-30 pb-30">
              <div class="section-content">
                  <div class="row">
                      
                      <div class="col-md-12">
                        <strong style="color: #f1ff1e;">
                            <marquee direction="left" width="100%" onmouseover="this.stop();" onmouseout="this.start();">
                                <i class="fa fa-arrow-circle-o-right text-white"></i> 

                                <asp:LinkButton ID="LinkButton1" runat="server"  ForeColor="#f1ff1e" OnClick="LinkButton1_Click"><u> Click Here For Rythu Bharosa Dashboard</u></asp:LinkButton>
                            </marquee>

                        </strong>
                      </div>
                      <div class="col-md-12 text-center">

                          <h3 class="font-weight-500 font-30 mt-10 text-white">MEE GIRI BHOOMI</h3>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-15"></div>

                      </div>

                  </div>

                  <%--          <div class="col-md-12 bg-alpha mb-10">
            <div class="row">
          
              <div class="col-md-3 col-sm-6 col-xs-12 text-center cus-count">
                <h4>HH's Identified for Payment</h4>
                <h2 class="numb-count">123456</h2>
              </div>
          
              <div class="col-md-3 col-sm-6 col-xs-12 text-center cus-count">
                <h4>Payment Initiated</h4>
                <h2 class="numb-count">123456</h2>
              </div>
          
              <div class="col-md-3 col-sm-6 col-xs-12 text-center cus-count">
                <h4>Payment Success</h4>
                <h2 class="numb-count">123456</h2>
              </div>
          
              <div class="col-md-3 col-sm-6 col-xs-12 text-center cus-count">
                <h4>Payment Under Process</h4>
                <h2 class="numb-count">123456</h2>
              </div>
          
            </div>
          </div>--%>

                  <div class="row mt-20">
                     <%-- <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Total Farmers As Per Department</h4>
                              <h2 class="numb-count" id="totalbenificiary" runat="server"></h2>
                          </div>
                      </div>--%>


                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Total Farmers </h4>
                              <h2 class="numb-count" id="totalbeneficiaries" runat="server"></h2>
                          </div>
                      </div>


                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Bank Accounts Updated</h4>
                              <h2 class="numb-count" id="Accountsupdated" runat="server">123456</h2>
                          </div>
                      </div>


                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Bank Accounts Need to be Updated</h4>
                              <h2 class="numb-count" id="Acntsnotupdated" runat="server"></h2>
                          </div>
                      </div>
                        
                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Aadhars Updated</h4>
                              <h2 class="numb-count" id="Tavailaadhar" runat="server"></h2>
                          </div>
                      </div>
                       <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Aadhars Need to be Updated</h4>
                              <h2 class="numb-count" id="Tunavailaadhar" runat="server"></h2>
                          </div>
                      </div>


                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4> Valid Aadhars</h4>
                              <h2 class="numb-count" id="Tvalidaadhar" runat="server"></h2>
                          </div>
                      </div>

                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4> Invalid Aadhars</h4>
                              <h2 class="numb-count" id="Tinvalidaadhar" runat="server"></h2>
                          </div>
                      </div>

                        <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4> Extent(Acres)</h4>
                              <h2 class="numb-count" id="extent" runat="server"></h2>
                          </div>
                      </div>

                   

                      
                   <%--   <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Total Geographic CoordinatesUpdated</h4>
                              <h2 class="numb-count" id="latlongsupdated" runat="server"></h2>
                          </div>
                      </div>


                      <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Total Geographic Coordinates Need To be Updated</h4>
                              <h2 class="numb-count" id="latlongsnotupdated" runat="server"></h2>
                          </div>
                      </div>--%>
                        <%-- <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Rythu Bharosa Payment Success</h4>
                              <h2 class="numb-count" id="rbsuccess" runat="server"></h2>
                          </div>
                      </div>--%>


                     <%-- <div class="col-xs-12 col-sm-6 col-md-6 mb-sm-30 mb-10">
                          <div class="bg-alpha cus-count">
                              <h4>Rythu Bharosa Payment Failed</h4>
                              <h2 class="numb-count" id="rbfail" runat="server"></h2>
                          </div>
                      </div>--%>

                  </div>


                      <div class="row mt-20 bg-alpha">
                        
              <div class="owl-carousel-5col clients-logo transparent text-center">
                  <div class="item">
                      <div class="funfact text-center">
                          <div class="text-white font-weight-600 font-48"  id="districts" runat="server" data-theme="minimal">0</div>
                         <%-- <label class="text-white font-weight-600 font-48"  id="districts" runat="server"></label>--%>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Districts</h5>
                      </div>
                  </div>

                  <div class="item">
                      <div class="funfact text-center">
                          <div class=" text-white font-weight-600 font-48" id="mandals" runat="server" data-theme="minimal">0</div>
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
                          <div class=" text-white font-weight-600 font-48" id="habitations" runat="server" data-theme="minimal">0</div>
                          <div class="double-line-bottom-centered-theme-colored-2 mt-0 mb-25"></div>
                          <h5 class="text-white text-uppercase mb-0">Habitations</h5>
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


         <%--   <div class="row mt-20">

            <div class="col-md-12 mt-10 mb-10">
              <div class="table-responsive bg-white cus-table">
              <table class="table table-hover table-striped table-bordered" >
                <thead>
                  <tr>
                    <th scope="col">S.No</th>
                    <th scope="col">District Name</th>
                    <th scope="col">Total Beneficiaries</th>
                    <th scope="col">Total Unavailable Accounts</th>
                    <th scope="col">Accounts Updated</th>
                    <th scope="col">Accounts Need to be Updated</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>1</td>
                    <td>Anantapur</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                  </tr>
                  <tr>
                    <td>2</td>
                    <td>Chittoor</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                  </tr>
                  <tr>
                    <td>3</td>
                    <td>EastGodavari</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                    <td>123456</td>
                  </tr>
                  
                </tbody>
              </table>
            </div>

          </div>

          </div>--%>
              <%-- Repeater    --%>
                  
      <%--   <div class="row mt-20">

             <div class="col-md-12 mt-10 mb-10">
                 <asp:Repeater ID="Repeater1" runat="server">

                     <HeaderTemplate>


                         <div class="table-responsive bg-white cus-table">
                             <table class="table table-hover table-striped table-bordered">
                                 <thead>
                                     <tr>
                                         <th>S.No</th>

                                         <th>ITDA</th>
                                         <th>District</th>
                                         <th>Total  Beneficiaries</th>
                                         <th>Total Available Aadhars</th>
                                         <th>Total Available Valid Aadhars</th>
                                         <th>Total Available Invalid Aadhars </th>
                                         <th> Aadhars Need to be Updated</th>
                                       
                                         <th>Accounts Updated</th>
                                         <th>Accounts Need to be Updated</th>
                                           <th>Beneficiaries with Full Bank Details</th>
                                     </tr>
                                 </thead>
                     </HeaderTemplate>

                     <ItemTemplate>
                         <tbody>

                             <tr>

                           
                                  <td><%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.ITDA_NAME")%>  </td>
                                 <td><%#DataBinder.Eval(Container, "DataItem.District")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Total_bneficiaries")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.total_received")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharisvalid")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharnoinvalid")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharnotavaliable")%> </td>



                                 <td><%#DataBinder.Eval(Container, "DataItem.Bankavaliable")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Banknotavaliable")%> </td>
                                 <td><%#DataBinder.Eval(Container, "DataItem.FullBankDetails")%> </td>

                             </tr>
                         </tbody>
                     </ItemTemplate>
                     <AlternatingItemTemplate>
                  <tbody>
                    

 <tr style="background-color:white">

                               
      <td><%#DataBinder.Eval(Container, "DataItem.sno")%>  </td>
     
                                 <td><%#DataBinder.Eval(Container, "DataItem.ITDA_NAME")%>  </td>
                                
                                 <td><%#DataBinder.Eval(Container, "DataItem.District")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Total_bneficiaries")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.total_received")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharisvalid")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharnoinvalid")%>  </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Adhharnotavaliable")%> </td>

                          

                                 <td><%#DataBinder.Eval(Container, "DataItem.Bankavaliable")%> </td>

                                 <td><%#DataBinder.Eval(Container, "DataItem.Banknotavaliable")%> </td>
     <td><%#DataBinder.Eval(Container, "DataItem.FullBankDetails")%> </td>

                             </tr>
                         </tbody>
                          </AlternatingItemTemplate>
                     <FooterTemplate>
                         </table>
                 </div>
                     </FooterTemplate>

                 </asp:Repeater>


             </div>

         </div>--%>

     </div>
    </div>
  </section>



    

    

    
    
    
  </div>
  <!-- Footer -->
  <footer id="footer" class="footer divider layer-overlay overlay-dark-8">
    
    <div class="footer-bottom" data-bg-color="#2b2d3b">
      <div class="container pt-10 pb-10">
        <div class="row">
          <div class="col-md-12">
            <p class="font-14 text-black-777 m-0 text-center text-white">Copyright &copy;2019 Andhra Pradesh Giribhumi. All Rights Reserved Tribal Welfare Department</p>
          </div>
        </div>
      </div>
    </div>
  </footer>
  <a class="scrollToTop" href="#"><i class="fa fa-angle-up"></i></a>
</div>
<!-- end wrapper -->

<!-- Footer Scripts -->
<script src="../newcss/js/custom.js"></script>

<!-- SLIDER REVOLUTION 5.0 EXTENSIONS (Load Extensions only on Local File Systems ! The following part can be removed on Server for On Demand Loading) -->

<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.actions.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.carousel.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.kenburn.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.layeranimation.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.migration.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.navigation.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.parallax.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.slideanims.min.js"></script>
<script type="text/javascript" src="../newcss/js/revolution-slider/js/extensions/revolution.extension.video.min.js"></script>

    </div>
    </form>
</body>
</html>
