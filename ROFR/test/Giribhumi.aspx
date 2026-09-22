<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giribhumi.aspx.cs" Inherits="ROFR.test.Giribhumi" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- CSS -->
    <link rel="stylesheet" href="../gcss/bootstrap.css">
    <link rel="stylesheet" href="../gcss/style.css">
    <link rel="stylesheet" href="../gcss/all.min.css">

    <title>Home - గిరి భూమి</title>
    <script>


        function Captcha() {
            var alpha = new Array('0', '1', '2', '3', '4', '5', '6', '7', '8', '9'

               );
            var i;
            for (i = 0; i < 6; i++) {
                var a = alpha[Math.floor(Math.random() * alpha.length)];
                var b = alpha[Math.floor(Math.random() * alpha.length)];
                var c = alpha[Math.floor(Math.random() * alpha.length)];
                var d = alpha[Math.floor(Math.random() * alpha.length)];
                var e = alpha[Math.floor(Math.random() * alpha.length)];

            }
            var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e;
            document.getElementById("mainCaptcha").innerHTML = code
            document.getElementById("mainCaptcha").value = code
        }
        function ValidCaptcha() {

            var uname = document.getElementById('<%=Txt_username.ClientID %>').value;
         var pwd = document.getElementById('<%=Txt_pwd.ClientID %>').value;
         var captcha = document.getElementById('txtInput').value;
         if (uname == "") {

             alert("Please Enter Username!");
             return false;
         }
         if (pwd == "") {

             alert("Please Enter Password");
             return false;
         }
         if (captcha == "") {

             alert("Please Enter Captcha");
             return false;
         }
         if (captcha != "") {


             var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
             var string2 = removeSpaces(document.getElementById('txtInput').value);
             if (string1 == string2) {
                 return true;
             }


             else {

                 alert("Enter valid captcha");

                 return false;
             }
         }
     }
     function removeSpaces(string) {
         return string.split(' ').join('');
     }



    </script>

</head>
<body>
    <header class="bg-white">
        <div class="container-fluid">
            <%-- <div class="row top-bar">
            <div class="col-md-6 left-side">
                    <div class="demo3">
                        <ul>
                            <li><span class="badge badge-danger">New !</span> Click Here For Rythu Bharosa Dashboard</li>
                            <li><span class="badge badge-info">New !</span> Latest News and Tenders Updates Here.....</li>
                            <li><span class="badge badge-success">New !</span> Click Here For Rythu Bharosa Dashboard</li>
                            <li><span class="badge badge-dark">New !</span> Latest News and Tenders Updates Here.....</li>
                        </ul>
                    </div>
            </div>
            <div class="col-md-6 text-right d-flex justify-content-end right-side">
                <a href="#!" class="btn btn-outline-info">+ A</a>
                <a href="#!" class="btn btn-outline-info">AA</a>
                <a href="#!" class="btn btn-outline-info">- A</a>
                <div class="dropdown">
                    <button class="btn btn btn-outline-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        Language
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item" href="#">English</a>
                        <a class="dropdown-item" href="#">Telugu</a>
                    </div>
                </div>
            </div>
        </div>--%>
            <div class="row d-flex justify-content-between">
                <div class="minister d-flex">
                    <img src="../gimages/Ap-Cm.png">
                    <div class="content">శ్రీ.వై.ఎస్.జగన్ మోహన్ రెడ్డి గారు<br>
                        గౌ.ముఖ్యమంత్రివర్యులు<br>
                        ఆంధ్రప్రదేశ్ ప్రభుత్వం</div>
                </div>
                <div class="logo">
                    <img src="../gimages/logo-wide.png">
                </div>
                <div class="minister d-flex">
                    <div class="content">శ్రీమతి.పి.పుష్ప శ్రీవాణి గారు<br>
                        గౌ.ఉప ముఖ్యమంత్రివర్యులు<br>
                        గిరిజన సంక్షేమ శాఖ</div>
                    <img src="../gimages/Tribal-Minister.png">
                </div>
            </div>
        </div>
        <nav class="navbar navbar-expand-lg navbar-light">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"><a class="nav-link" href="#!">Home</a></li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">Adangal</a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="../test/Adangall.aspx">Mee Adangal</a></li>
                            <li><a class="dropdown-item" href="../test/GramaAdangall.aspx">Grama Adangal</a></li>
                        </ul>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">1-B</a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="../test/Details__1B.aspx">Mee 1-B</a></li>
                            <li><a class="dropdown-item" href="../test/Grama_1B.aspx">Grama 1-B</a></li>
                        </ul>
                    </li>
                    <%--                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                        aria-expanded="false">ఆధార్/ఇతర గుర్తింపుపత్రాలు</a>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item" href="">ఆధార్ లింకింగ్</a></li>
                        <li><a class="dropdown-item" href="">మొబైల్ నెంబర్ లింకింగ్ ,గుర్తింపు పత్రములు ఆధారముగా</a></li>
                        <li><a class="dropdown-item" href="">ఆధార్ రిక్వెస్ట్ స్టేటస్</a></li>
                    </ul>
                </li>--%>
                    <%-- <li class="nav-item"><a class="nav-link" href="">ఎఫ్. ఎం. బి.</a></li>
                <li class="nav-item"><a class="nav-link" href="">గ్రామ పటం</a></li>--%>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">Complaints</a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="">ఫిర్యాదుల నమోదు</a></li>
                            <li><a class="dropdown-item" href="">మీ ఫిర్యాదు స్థితి</a></li>
                        </ul>
                    </li>
                    <%--  <li class="nav-item"><a class="nav-link" href="">సంప్రదించండి</a></li>
                <li class="nav-item"><a class="nav-link" href="">డిపార్టుమెంటు లాగిన్</a></li>--%>
                     <li class="nav-item"><a class="nav-link" href="../test/Epass_book.aspx">Epassbook</a></li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">Reports</a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="../test/ItdawiseLandDetails.aspx">Land Summary Report</a></li>
                            <li><a class="dropdown-item" href="../test/ITDAWISE_POPULATION_REPORT.aspx">Population Report</a></li>
                           
                        </ul>
                    </li>
                <%--    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">Others</a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="LtrData_Analysis.aspx">Ltr Reports</a></li>
                         
                        </ul>
                    </li>--%>
                   
                    <!-- <li class="nav-item"><a class="nav-link" href="">భూమి మార్పిడి వివరములు</a></li> -->
                <%--    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="false">కోర్టువివాదాల వివరములు </a>
                        <ul class="dropdown-menu">
                            <li><a class="dropdown-item" href="">శ్రీకాకుళం </a></li>
                            <li><a class="dropdown-item" href="">విజయనగరం</a></li>
                            <li><a class="dropdown-item" href="">విశాఖపట్నం</a></li>
                            <li class="dropdown">
                                <a class="dropdown-item dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">తూర్పు గోదావరి </a>
                                <ul class="dropdown-menu">
                                    <li><a class="dropdown-item" href="">కోర్టు కేసెస్</a></li>
                                    <li><a class="dropdown-item" href="">హై కోర్టు కేసెస్</a></li>
                                </ul>
                            </li>
                            <li><a class="dropdown-item" href="">పశ్చిమ గోదావరి</a></li>
                            <li><a class="dropdown-item" href="">కృష్ణ</a></li>
                            <li><a class="dropdown-item" href="">ప్రకాశం </a></li>
                            <li><a class="dropdown-item" href="">నెల్లూరు </a></li>
                            <li><a class="dropdown-item" href="">చిత్తూరు  </a></li>
                            <li><a class="dropdown-item" href="">కడప </a></li>
                            <li class="dropdown">
                                <a class="dropdown-item dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">అనంతపురం</a>
                                <ul class="dropdown-menu">
                                    <li><a class="dropdown-item" href="">కోర్టు కేసెస్</a></li>
                                    <li><a class="dropdown-item" href="">హై కోర్టు కేసెస్</a></li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a class="dropdown-item dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true"
                                    aria-expanded="false">కర్నూలు</a>
                                <ul class="dropdown-menu">
                                    <li><a class="dropdown-item" href="">కోర్టు కేసెస్</a></li>
                                    <li><a class="dropdown-item" href="">హై కోర్టు కేసెస్</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>--%>
                </ul>

                <a data-toggle="modal" data-target="#LoginModal" class="float-right btn btn-outline-success login-btn text-white"><i class="fa fa-sign-in-alt   "></i>Login</a>
            </div>
        </nav>
    </header>
    <section class="main-slider">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <!-- <li data-target="#carouselExampleIndicators" data-slide-to="2"></li> -->
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../gimages/slider-1.jpg" class="d-block w-100" alt="Giribhumi">
                </div>
                <div class="carousel-item">
                    <img src="../gimages/slider-2.jpg" class="d-block w-100" alt="...">
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
        </div>
    </section>
    <div class="row top-bar">
        <div class="col-md-6 left-side">
            <div class="demo3">
                <ul>
                    <li><span class="badge badge-danger">New !</span><a href="http://ysrrythubharosa.ap.gov.in/RBApp/index.html" target="_blank"> Click Here For Rythu Bharosa Dashboard</a></li>
                    <%--<li><span class="badge badge-info">New !</span> Latest News and Tenders Updates Here.....</li>
                            <li><span class="badge badge-success">New !</span> Click Here For Rythu Bharosa Dashboard</li>
                            <li><span class="badge badge-dark">New !</span> Latest News and Tenders Updates Here.....</li>--%>
                </ul>
            </div>
        </div>
        <%--  <div class="col-md-6 text-right d-flex justify-content-end right-side">
                <a href="#!" class="btn btn-outline-info">+ A</a>
                <a href="#!" class="btn btn-outline-info">AA</a>
                <a href="#!" class="btn btn-outline-info">- A</a>
                <div class="dropdown">
                    <button class="btn btn btn-outline-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        Language
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item" href="#">English</a>
                        <a class="dropdown-item" href="#">Telugu</a>
                    </div>
                </div>
            </div>--%>
    </div>
    <section class="telugu-section">
        <div class="container">
            <div class="row mt-4 mb-2">
                <div class="col-md-8 mb-4 main">
                    <div class="card">
                        <div class="card-header bg-white border-0">
                            <h3 class="text-success welcome-text">Giribhumi</h3>
                        </div>
                        <div class="card-body py-2 px-3">
                            <p>
                               <%-- ప్రజలు మరియు పట్టాదారులు తమ భూమి వివరాలను నేరుగా తెలుసుకునేందుకు వీలుగా ఈ "మీ భూమి" వెబ్ సైట్ రూపొందించబడినది. ఆంద్ర ప్రదేశ్ రాష్ట ప్రభుత్వ సుపరిపాలనలో ఇదొక ముందడుగు. ప్రజలు మరియు పట్టాదారులు తమ భూమి వివరాలను నేరుగా తెలుసుకునేందుకు వీలుగా ఈ "మీ భూమి" వెబ్ సైట్ రూపొందించబడినది. ఆంద్ర ప్రదేశ్ రాష్ట ప్రభుత్వ సుపరిపాలనలో ఇదొక ముందడుగు. ప్రజలు మరియు పట్టాదారులు తమ భూమి వివరాలను నేరుగా తెలుసుకునేందుకు వీలుగా ఈ "మీ భూమి" వెబ్ సైట్ రూపొందించబడినది. ఆంద్ర ప్రదేశ్ రాష్ట ప్రభుత్వ సుపరిపాలనలో ఇదొక ముందడుగు.--%>
                             Mee Bhoomi is an Andhra Pradesh government initiative to digitize all records and make it easily accessible to the public. Mee Bhoomi makes the procedure for getting encumbrance certificate or land records easy through the portal, while improving speed and transparency. Mee Bhoomi can be used by any person to obtain government land records in all the villages, districts and mandals of Andhra Pradesh state.
                                 </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mb-4 main">
                    <div class="card quick-links">
                        <div class="card-header bg-success">
                            <h6 class="text-white">QUICK LINKS <i class="fas fa-link"></i></h6>
                        </div>
                        <div class="card-body p-1">
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">గిరిభూమి పోర్టల్</li>
                                <li class="list-group-item">గిరి భూమి యాప్</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 1</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 2</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 3</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 4</li>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row mt-2 mb-2">
                <div class="col-md-4 mb-4 main">
                    <div class="card quick-links">
                        <div class="card-header bg-danger">
                            <h6 class="text-white">News &amp; Events <i class="far fa-newspaper"></i></h6>
                        </div>
                        <div class="card-body p-2">
                            <div class=" demo1 demof">
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">గిరిభూమి పోర్టల్</li>
                                    <li class="list-group-item">గిరి భూమి యాప్</li>
                                    <li class="list-group-item">గిరిభూమి పోర్టల్ 1</li>
                                    <li class="list-group-item">గిరిభూమి పోర్టల్ 2</li>
                                    <li class="list-group-item">గిరిభూమి పోర్టల్ 3</li>
                                    <li class="list-group-item">గిరిభూమి పోర్టల్ 4</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mb-4 main">
                    <div class="row offer-section">
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block" >
                                <div class="icon-box" id="districts" runat="server">13</div>
                                <h3><a href="#">Districts</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block" >
                                <div class="icon-box" id="mandals" runat="server">131</div>
                                <h3><a href="#">Mandals</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block">
                                <div class="icon-box"  id="villages" runat="server">3171</div>
                                <h3><a href="#">Villages</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block"  >
                                <div class="icon-box" id="habitations" runat="server">3200</div>
                                <h3><a href="#">Habitations</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block"  >
                                <div class="icon-box" id="divisions" runat="server">18</div>
                                <h3><a href="#">Divisions</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block" >
                                <div class="icon-box" id="ranges" runat="server">50</div>
                                <h3><a href="#">Ranges</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block" >
                                <div class="icon-box" id="beats" runat="server">208</div>
                                <h3><a href="#">Beats</a></h3>
                            </div>
                        </div>
                       <%-- <div class="col-md-4 mb-2">
                            <div class="single-offer-block">
                                <div class="icon-box">50</div>
                                <h3><a href="#">Ranges</a></h3>
                            </div>
                        </div>
                        <div class="col-md-4 mb-2">
                            <div class="single-offer-block">
                                <div class="icon-box">208</div>
                                <h3><a href="#">Beats</a></h3>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="col-md-4 mb-4 main">
                    <div class="card quick-links">
                        <div class="card-header bg-info">
                            <h6 class="text-white">Downloads <i class="far fa-file-pdf"></i></h6>
                        </div>
                        <div class="card-body p-1">
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">గిరిభూమి పోర్టల్</li>
                                <li class="list-group-item">గిరి భూమి యాప్</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 1</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 2</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 3</li>
                                <li class="list-group-item">గిరిభూమి పోర్టల్ 4</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mb-4 total-count">
                <div class="col-md-3 mb-4">
                    <div class="card bg-primary">
                        <div class="card-body">
                            <h3 class="text-center" id="totalbeneficiaries" runat="server">91704</h3>
                            <p class="text-center">Total Farmers</p>
                        </div>
                    </div>
                </div>
              
                <div class="col-md-3 mb-4">
                    <div class="card bg-info">
                        <div class="card-body">
                            <h3 class="text-center" id="Accountsupdated" runat="server">95730</h3>
                            <p class="text-center"> Bank Accounts Updated</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 mb-4">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <h3 class="text-center" id="Acntsnotupdated" runat="server">15066</h3>
                            <p class="text-center"  >Bank Accounts Need to be Updated</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 mb-4">
                    <div class="card bg-purple">
                        <div class="card-body">
                            <h3 class="text-center" id="Tavailaadhar" runat="server">100344</h3>
                            <p class="text-center" >Aadhars Updated</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 mb-4">
                    <div class="card bg-orange">
                        <div class="card-body">
                            <h3 class="text-center" id="Tunavailaadhar" runat="server">95680</h3>
                            <p class="text-center" >Aadhars Need to be Updated</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 mb-4">
                    <div class="card bg-secondary">
                        <div class="card-body">
                            <h3 class="text-center" id="Tvalidaadhar" runat="server">4664</h3>
                            <p class="text-center" >Valid Aadhars</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 mb-4">
                    <div class="card bg-success2">
                        <div class="card-body">
                            <h3 class="text-center" id="Tinvalidaadhar" runat="server">10452</h3>
                            <p class="text-center" >Invalid Aadhars</p>
                        </div>
                    </div>
                </div>

                 <div class="col-md-3 mb-4">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <h3 class="text-center" id="extent" runat="server">62705</h3>
                            <p class="text-center">Extent(Acres)</p>
                        </div>
                    </div>
                </div>
                
               <!-- <div class="col-md-3 mb-4">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <h3 class="text-center">48091</h3>
                            <p class="text-center">Total Geographic Coordinates Need To be Updated</p>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-3 mb-4">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <h3 class="text-center">40870</h3>
                            <p class="text-center">Rythu Bharosa Payment Success</p>
                        </div>
                    </div>
                </div>
                
                <div class="col-md-3 mb-4">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <h3 class="text-white text-center">6219</h3>
                            <p class="text-white text-center">Rythu Bharosa Payment Failed</p>
                        </div>
                    </div>
                </div> -->
            </div>

        </div>
    </section>

    <section class="links-section">
        <div class="col-md-12">
            <div class="container">
                <div id="divmarquee" class="marquee">
                    <div class="row mt-4 mb-4 marquee2">
                        <div class="col-md-2">
                            <div class="item">
                                <a href="http://www.india.gov.in/" title="India.gov.in" target="_blank">
                                    <img src="../gimages/links/ind_gov.jpg" class="img-fluid">
                                    <span>India.gov.in</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="item">
                                <a href="http://ap.meeseva.gov.in/DeptPortal/UserInterface/LoginForm.aspx" title="India.gov.in" target="_blank">
                                    <img src="../gimages/links/meeseva.jpg" class="img-fluid">
                                    <span>AP-Meeseva</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="item">
                                <a href="http://www.ap.gov.in" title="AP Govt. Portal" target="_blank">
                                    <img src="../gimages/links/apportal.jpg" class="img-fluid">
                                    <span>AP Govt. Portal</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="item">
                                <a href="http://www.smart.ap.gov.in/myvillage/" title="AP Smart Gov" target="_blank">
                                    <img src="../gimages/links/smartgov.jpg" class="img-fluid">
                                    <span>AP Smart Gov</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="item">
                                <a href="#!" title="India.gov.in" target="_blank">
                                    <img src="../gimages/links/contactus.jpg" class="img-fluid">
                                    <span>Contact us</span>
                                </a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="pt-3 pb-3 bg-light">
        <div class="col-md-12">
            <div class="container">
                <div class="row text-center">
                    <div class="col-md-4">
                        <span class="text-dark">Revenue Records Viewed :</span>
                        <span class="text-primary">57992019</span>
                    </div>
                    <div class="col-md-4">
                        <span class="text-dark">Electronic Passbooks Downloaded:</span>
                        <span class="text-primary">97818</span>
                    </div>
                    <div class="col-md-4">
                        <span class="text-dark">Site Visits :</span>
                        <span class="text-primary">67337058</span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Footer -->
    <footer class="page-footer font-small">
        <div class="footer-copyright text-center py-3 text-white">Copyright ©2019 Andhra Pradesh Giribhumi. All Rights Reserved Tribal Welfare Department</div>
    </footer>
    <!-- Footer -->
    <!-- Login Modal -->
    <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="LoginModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="LoginModalLabel">Login</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                 <form id="form1" runat="server">
                <div class="modal-body">
                   
                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="exampleInputEmail1">Username</label>
                                <%-- <input type="email" class="form-control" id="Username" aria-describedby="Username">--%>
                                <asp:TextBox ID="Txt_username" runat="server" class="form-control h-auto"  aria-label="Username" aria-describedby="username" autocomplete="off"> </asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <label for="exampleInputPassword1">Password</label>
                                <%-- <input type="password" class="form-control" id="exampleInputPassword1">--%>
                                <asp:TextBox ID="Txt_pwd" runat="server" class="form-control h-auto"  aria-label="Password" aria-describedby="password" autocomplete="off" TextMode="Password" MaxLength="40"> </asp:TextBox>
                            </div>
                            <%--                            <div class="form-group row">
                                <div class="bg-secondary col-md-12">
                                    <h2 class="text-white text-center" id="mainCaptcha" ></h2>
                                </div>
                            </div>--%>
                            <body onload="Captcha();">
                                <%-- <div class="row  pr-3 pl-3 justify-content-center">--%>
                                <div class="form-group row">
                                <div class="col-md-10 border bg-secondary" style="height: 45px;">
                                   
                                        <h2 type="text" id="mainCaptcha" class="text-center text-white"></h2>
                                       

                                   
                                    
                                </div>
                                     <div class="col-md-1 text-left">
                                                <button type="button" class="btn btn-light" value="Refresh" id="refresh" onclick="Captcha();"><i class="fa fa-sync"></i></button>
                                            </div>
                        </div>
                                
                               
                                
                        <div class="form-group row">
                            <label for="exampleInputPassword1" class="col-md-12">Enter Captcha</label>
                            <input type="text" id="txtInput" name="captcha" class="form-control h-auto" autocomplete="off">
                           <%-- <div class="col-md-3">
                                <button type="submit" class="btn btn-primary">Submit</button>
                            </div>--%>
                        </div>

</div>
                    
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                   <%-- <button type="button" class="btn btn-primary">Login</button>--%>
                     <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary"  OnClick="btn_login_Click"  Text="Login" OnClientClick="return ValidCaptcha() "  />
                </div>
                     </form>
</div>
        </div>
    </div>

    <!-- JavaScript -->
<script src="../gjs/jquery-3.4.1.min.js"></script>
<script src="../gjs/bootstrap.min.js"></script>
<script src="../gjs/scripts.js"></script>
<script src="../gjs/jquery.easy-ticker.js"></script>
</body>
</html>
