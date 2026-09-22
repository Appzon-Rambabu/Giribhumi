<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ROFR.pages.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
	<meta name="Subject" content="Giribhumi"/>
 <meta name="Subject" content="Tribal Welfare Department Giribhumi AP" />
<meta name="Subject" content="TWD Giribhumi AP" />
<meta name="keywords" content="ROFR lands AP,ROFR Lands Andhra Pradesh,Giribhumi,Giribhumi Rofr Lands, Tribal welfare department ROFR Lands Andhra pradesh,
    Tribal welfare department ROFR Lands AP,Giribhumi Tribal welfare AP,Giribhumi Tribal welfare Andhra Pradesh,ROFR AP,ROFR Andhra Pradesh,Rofr Lands Giribhumi,
    Tribal welfare Department Giribhumi Andhra Pradesh,Tribal welfare department giribhumi AP,TWD giribhumo Andhra Pradesh" />
<meta name="author" content="" />

    <!-- CSS -->
   <%-- <link rel="stylesheet" href="css/bootstrap.css">--%>
      <link href="../Rofrnewassets/css/bootstrap.css" rel="stylesheet" />
      <link href="../Rofrnewassets/css/style.css" rel="stylesheet" />
   <%-- <link rel="stylesheet" href="css/style.css">--%>
      <link href="../Rofrnewassets/css/all.min.css" rel="stylesheet" />
  <%--  <link rel="stylesheet" href="css/all.min.css">--%>
     

    <link rel="shortcut icon" href="images/aplogo.png"/>
         <script src="../newcss/js/translate.js"></script>
    <title>Home - గిరి భూమి</title>

       <script type="text/javascript">
           function googleTranslateElementInit()
           {
			new google.translate.TranslateElement({
				pageLanguage : 'en',
				includedLanguages : 'en,te',
				layout : google.translate.TranslateElement.InlineLayout.SIMPLE
			}, 'google_translate_element');
		}
		
		
	</script>
	
	<style>
	
	ul.top-matter
	{
	position:relative !important;
	}
	
	

/* Marquee itself */
.marq {
    white-space: nowrap;        /* ensures a single long horizontal line */
}

.demo3 {
    height: 26px!important;
    overflow: hidden;
    
}

.demo3 button {
   z-index:999;
   background:#007405;
   color:#ffffff;
   font-weight:800;
   margin-left:-76px!important;
    
}

.demo3 button:hover {
   z-index:999;
   background:#007405;
   color:#ffffff;
   font-weight:800;
   margin-left:-76px!important;
    
}


.news-ticker {
    list-style: none;
    padding: 0;
    margin: 0;
    position: absolute;
    animation: ticker 10s linear infinite;
}

.news-ticker li {
    height: 37px;
    line-height: 30px;
    white-space: nowrap;
}
    
@keyframes ticker {
    0% { top: 0; }
    20% { top: 0; }

    25% { top: -34px; }
    45% { top: -34px; }

    50% { top: -68px; }
    70% { top: -68px; }

    75% { top: -102px; }
    100% { top: -102px; }
}

	</style>
  </head>
  <body onload="disableBackButton();" class="">
      
    <div class="preloader">
        <div class="spinner"></div>
        <span id="loading-msg">
           <%-- <img src="../Rofrnewassets/aplogo.png">--%>
             <img src="../Rofrnewassets/images/aplogo.png" />
        </span>
      </div>
    <header class="bg-white">
        <div class="container-fluid">
        <div class="row top-bar">
            <div class="col-md-10">
                    <!-- Outer container for scrolling banner -->
<div class="demo3">
    <button class="btn btn-sm">Latest News</button>
    <!-- Single marquee for smooth left-side scrolling -->
    <marquee direction="left" scrollamount="5" class="marq mt-1">
        
        <!-- First scrolling message -->
        <span class="badge badge-danger">!New</span>
        <a href="https://youtube.com/live/r2ZHZFsa02g?feature=share" target="_blank">
            Click Here Janjatiya Gaurav Diwas / Pakhwada
        </a>

        <!-- Separator between messages -->
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; | &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <!-- Second scrolling message -->
        <span class="badge badge-danger">New !</span>
        <a href="https://swarnandhra.ap.gov.in/Suggestions" target="_blank">
            Click Here For Submiting Your Suggestions/inputs on Swarna Andhra@2047 vision Plan
        </a>

    </marquee>

</div>

            </div>
            <div class="col-md-2 text-right d-flex justify-content-end right-side">
                <a href="#!" class="btn btn-info font-weight-bold">+ A</a>
                <a href="#!" class="btn btn-info font-weight-bold">AA</a>
                <a href="#!" class="btn btn-info font-weight-bold">- A</a>
                 <div id="google_translate_element" class="float-lg-right"></div>
                <%--<div class="dropdown ml-2">
                    <button class="btn btn btn-outline-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        Language <i class="fa fa-caret-down"></i>
                    </button>
                  <%--  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item" href="#">English</a>
                        <a class="dropdown-item" href="#">Telugu</a>
                    </div>
                </div>--%>
            </div>
        </div>
         <div class="row d-flex justify-content-center main-header">
            <div class="col-md-4 text-left">
                <div class="logo">
                    <img src="../Rofrnewassets/images/ap-logo-left.png"/>
                </div></div>
            <div class="col-md-4 text-center">
                <div class="logo">
                    <img src="../Rofrnewassets/images/giri-bhumi-logo.png"/>
                </div>
            </div>
			 <div class="col-md-1">
                 </div>
            <%-- Newly adding--%>
             <div class="col-md-3 ">
               <div class="d-flex justify-content-end">
                  <div class="logo">
                     <img src="../Rofrnewassets/images/indian_emblem.png"/>
                     <img src="../Rofrnewassets/images/g20-logo.png"/>
                  </div>
               </div>
            </div>
        </div>
        </div>
        <nav class="navbar navbar-expand-lg navbar-light">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
          
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item"><a class="nav-link" href="#!"><i class="fa fa-home"></i> Home</a></li>


                 <li class="nav-item dropdown">
                                    <div id="masters" runat="server"><a class="nav-link dropdown-toggle" href="#" id="navbarDropdown3" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Adangal </a>
                                          <ul class="dropdown-menu">
                                         <li><a class="dropdown-item" href="../pages/Adangal.aspx">Mee Adangal</a></li>
                                    <li><a class="dropdown-item" href="../pages/GramaAdangal.aspx">Grama Adangal</a></li>
                                        </ul>
                                    </div>
                                </li>


                  <li class="nav-item dropdown">
                  <div id="Div1" runat="server"><a class="nav-link dropdown-toggle" href="#" id="navbarDropdown3" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">1-B </a><ul class="dropdown-menu">
                   <li><a class="dropdown-item" href="../pages/Details_1B.aspx">Mee 1B</a></li>
                    <li><a class="dropdown-item" href="../pages/Grama1B.aspx">Grama 1B</a></li>
                    </ul>
                   </div>
                    </li>
                <li class="nav-item"><a class="nav-link" href="../pages/Login.aspx">Dashboard</a></li>
               <li class="nav-item"><a class="nav-link" href="../Rofrnewassets/about.html">About</a></li>
                
               <li class="nav-item"><a class="nav-link" href="../Rofrnewassets/forestact.html">Act & Rule</a></li>
                 <li class="nav-item"><a class="nav-link" href="../pages/Aadharwise_Beneficiary_Details_BNK.aspx">Bankers</a></li>

            </ul>

              <a  href="../pages/Login.aspx" class="float-right text-white btn btn-outline-success login-btn"><i class="fa fa-unlock-alt"></i> Login</a>
            </div>
          </nav>
    </header>
    <section class="main-slider">
        <div class="container-fluid">
            
        <div class="row">
            <div class="col-md-3 text-center cm">
                <img src="../Rofrnewassets/images/CM_2.png" style="height: 300px;" class="img-fluid"/>
               <%-- <img src="../Rofrnewassets/ysr-png.png" style="height: 300px;" class="img-fluid">--%>
                 <h4>Sri Nara Chandrababu Naidu <br></h4>
                   <h5>Hon’ble Chief Minister of Andhra Pradesh</h5>
            </div>
            <div class="col-md-9">
                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                     <li data-target="#carouselExampleIndicators" data-slide-to="1"  class="active"></li>
					 <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="3" ></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="6"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="7"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="8"></li>
					<li data-target="#carouselExampleIndicators" data-slide-to="9"></li>
                </ol>
                <div class="carousel-inner">
                   
				   <div class="carousel-item active">
                        <img src="../Rofrnewassets/images/screenpic1.jpeg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/Slide1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
					<div class="carousel-item">
                        <img src="../Rofrnewassets/images/slider_image.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/Slide1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
					 <div class="carousel-item">
                        <img src="../Rofrnewassets/images/SSlide1.jpeg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/Slide1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
					<div class="carousel-item ">
                        <img src="../Rofrnewassets/images/SSlide2.jpeg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/slider-1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
					<div class="carousel-item ">
                        <img src="../Rofrnewassets/images/Sslide3.jpeg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/slider-1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
                    <div class="carousel-item ">
                        <img src="../Rofrnewassets/images/slider-1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/slider-1.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
                    <div class="carousel-item">
                        <img src="../Rofrnewassets/images/slider-2.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                      <%--  <img src="../Rofrnewassets/slider-2.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
                    <div class="carousel-item">
                        <img src="../Rofrnewassets/images/slider-4.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                       <%-- <img src="../Rofrnewassets/slider-4.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
                    <div class="carousel-item">
                        <img src="../Rofrnewassets/images/commi.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;"/>
                      <%--  <img src="../Rofrnewassets/slider-5.jpg" class="d-block w-100" alt="Giribhumi" style="height: 380px;">--%>
                    </div>
                      
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div></div>
        </div>
        
    </div>
    </section>

    <section class="telugu-section">
        <div class="container-fluid">
            <div class="row mt-4 mb-2">
                <div class="col-md-7 mb-4 main">
                    <h3 class="text-success welcome-text">Welcome to Giribhumi Tribal Welfare Department</h3>
                    <p class="text-justify">
                        Scheduled Tribes And Other Traditional Forest Dwellers (Recognition Of Forest Rights) Act, 2006
The Forest Rights Act (FRA), 2006 recognizes the rights of the forest dwelling tribal communities and other traditional forest dwellers to forest resources, on which these communities were dependent for a variety of needs, including livelihood, habitation and other socio-cultural needs. The forest management policies, including the Acts, Rules and Forest Policies of Participatory Forest Management policies in both colonial and post-colonial India, did not, till the enactment of this Act, recognize the symbiotic relationship of the STs with the forests, reflected in their dependence on the forest as well as in their traditional wisdom regarding conservation of the forests.
                    </p>
                    
                </div>
                <div class="col-md-5 mb-4 main">
                    <div class="member d-flex justify-content-between">
                        
                    <div class="member-box text-center mx-2">
                       <img src="../Rofrnewassets/images/Gsr.jpeg" class="img-fluid mt-2"/>
					   <p class="text-info">Smt. Gummidi Sandhya Rani Garu<br>
                            <span>Hon'ble Minister For Women & Child Welfare and Tribal Welfare Department</span></p>
                    </div>

                    <div class="member-box text-center mx-2">
                          <img src="../Rofrnewassets/images/Nayak.jpeg" class="img-fluid mt-2"/>
                              
                        <p class="text-info">Sri M.Mallikarjuna Nayak,<br> IAS<br>
                            <span>Secretary, Tribal Welfare.</span></p>
                    </div>

                    <div class="member-box text-center mx-2">
                        <img src="../Rofrnewassets/images/Sada-bhargavi_Tribal.jpg" class="img-fluid mt-2" />
                        <p class="text-info">Smt. S. Bhargavi,<br>IAS<br>
                            <span>Director, Tribal Welfare.</span></p>
                    </div>
					
                    </div>
                    
                </div>
                   
                </div>
                
            </div>

            
            

            <div class="container-fluid">
          
            
        </div>
       
    </section>


    <section class="links-section">
        <div class="col-md-12">
        <div class="container">
        <div id="divmarquee" class="marquee">
            <div class="d-flex mt-4 mb-4 marquee2">
                    <div class="item px-5">
                        <a href="http://www.india.gov.in/" title="India.gov.in" target="_blank">
                            <img src="../Rofrnewassets/images/links/ind_gov.jpg" class="img-fluid">
                            <span>India.gov.in</span>
                        </a>
                    </div>
                    <div class="item px-5">
                        <a href="http://ap.meeseva.gov.in/DeptPortal/UserInterface/LoginForm.aspx" title="India.gov.in" target="_blank">
                            <img src="../Rofrnewassets/images/links/meeseva.jpg" class="img-fluid">
                            <span>AP-Meeseva</span>
                        </a>
                    </div>
                    <div class="item px-5">
                        <a href="http://www.ap.gov.in" title="AP Govt. Portal" target="_blank">
                            <img src="../Rofrnewassets/images/links/apportal.jpg" class="img-fluid">
                            <span>AP Govt. Portal</span>
                        </a>
                    </div>
                   <%-- <div class="item px-5">
                        <a href="http://www.smart.ap.gov.in/myvillage/" title="AP Smart Gov" target="_blank">
                            <img src="../Rofrnewassets/images/links/smartgov.jpg" class="img-fluid">
                            <span>AP Smart Gov</span>
                        </a>
                    </div>--%>
                
                    <div class="item px-5">
                        <a href="https://aptribes.ap.gov.in/" title="AP Tribes" target="_blank">
                            <img src="../Rofrnewassets/images/links/aptribes-logo.png" class="img-fluid">
                            <span>Aptribes</span>
                        </a>
                    </div>
                    <div class="item px-5">
                        <a href="https://meekosam.ap.gov.in/" title="Spandana" target="_blank">
                            <img src="../Rofrnewassets/images/links/meekosam_logo.jpg" class="img-fluid">
                            <%--<span>Spandana</span>--%>
							 <span>Meekosam</span>
                        </a>
                    </div>
            </div>
            </div>
        </div>
    </div>
    </section>



      <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable" role="document">
        <div class="modal-content">
            <div class="modal-header py-0">
            <h5 class="modal-title mt-0 text-success" id="exampleModalCenterTitle">Family Benifit Card</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            </div>
            <div class="modal-body">
               
                <img src="../Rofrnewassets/images/Rofr-Land-Details.jpg" class="img-fluid"/>
            </div>
        </div>
        </div>
    </div>


    <!-- Footer -->
    <footer class="page-footer font-small">
      <div class="footer-copyright text-center py-3 text-white">
        <div class="row justify-content-end">
            <div class="col-md-6">Copyright © 2022 Andhra Pradesh Giribhumi. All Rights Reserved Tribal Welfare Department</div>

       <div class="col-md-3">
      <%--   <span class="d-flex">Total Site Visitors :<asp:Label ID="Lbl_Total_Visitors" runat="server" Text="Total Visitors" ForeColor="Red" Font-Size="50px" CssClass="d-flex" ></asp:Label></span>
      --%>       <span class="d-flex" style="font-size: 20px; font-weight: 600;">Total Site Visitors :&nbsp;<label id="sitevisitors"></label></span>
        </div>

        </div>
    </div>
    </footer>
  
    <!-- Login Modal -->
  

    <!-- JavaScript -->
   <%-- <script src="js/jquery-3.4.1.min.js"></script>--%>
      <script src="../Rofrnewassets/js/jquery-2.2.0.min.js"></script>
      <script src="../Rofrnewassets/js/bootstrap.min.js"></script>
    <%--<script src="js/bootstrap.min.js"></script>--%>
      <script src="../Rofrnewassets/js/scripts.js"></script>
  <%--  <script src="js/scripts.js"></script>--%>
      <script src="../Rofrnewassets/js/jquery.easy-ticker.js"></script>


       <script src="../Rofrnewassets/js/jquery.easing.1.3.js"></script>
    <script src="../Rofrnewassets/js/jquery.fireworks.js"></script>
    <script src="../Rofrnewassets/js/confetti.js"></script>

   <%-- <script src="js/jquery.easy-ticker.js"></script>--%>
  </body>

   

          <script  nonce="2726c7f26c">
        function disableBackButton() {
            window.history.forward()
        }
        disableBackButton(); dis();
        window.onload = disableBackButton();
        window.onpageshow = function (evt) {
            if (evt.persisted) disableBackButton()
        }
        window.onunload = function () {
            void (0)
        }
        function dis() {
            window.history.pushState(null, "", window.location.href);
            window.onpopstate = function () {
                window.history.pushState(null, "", window.location.href);
            };
        }
    </script>
    
   
	
	   <script>
         var type = "";
         let data = window.performance.getEntriesByType("navigation")[0].type;
         var url = document.referrer;
         if (data == "navigate")
         {
             if (url == "") {
                 type = "8";
                 $.ajax({
                     type: 'POST',
                     contentType: 'application/json; charset=utf-8',
                     url: '../Giribhumi/websitevisitor',
                     data: "{'Type':'" + type + "',}",
                     dataType: "json",
                     success: function (response) {
                         var num = response.Data[0].VISIT_COUNT;
                         $("#sitevisitors").text(num);
                     }

                 });
             }

             else {
                 type = "9";
                 $.ajax({
                     type: 'POST',
                     contentType: 'application/json; charset=utf-8',
                     url: '../Giribhumi/websitevisitor',
                     data: "{'Type':'" + type + "',}",
                     dataType: "json",
                     success: function (response) {
                         var num = response.Data[0].VISIT_COUNT;
                         $("#sitevisitors").text(num);
                     }

                 });
             }
         }
             else {
             type = "9";
             $.ajax({
                 type: 'POST',
                 contentType: 'application/json; charset=utf-8',
                 url: '../Giribhumi/websitevisitor',
                 data: "{'Type':'" + type + "',}",
                 dataType: "json",
                 success: function (response) {
                     var num = response.Data[0].VISIT_COUNT;
                     $("#sitevisitors").text(num);
                 }

             });

             }
             
             
            
         
         
     </script>
    
</html>