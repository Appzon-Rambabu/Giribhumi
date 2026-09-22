<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Villageinfrastructure1.aspx.cs" Inherits="ROFR.Villageinfrastructure1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Tribal Welfare</title>
    <link rel="stylesheet" href="GISNew/bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="GISNew/bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="GISNew/fonts/stylesheet.css">
    <link rel="stylesheet" href="GISNew/css/main.css">
    <link rel="stylesheet" href="GISNew/css/select2.css">

</head>
<body  onload ="initMap();">

    <div id="preloader">
        <div id="status"></div>
    </div>
    <main>
        <div id="map"></div>

       
      

    </main>
    
    <script type="text/javascript" src="GISNew/js/bundle.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/build/myworld.js?0"></script>
    <script type="text/javascript" src="GISNew/js/myworld/dummy.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/map-init--index.js"></script>
     <script type="text/javascript" src="../MapJsfloder/Kmlmapjs.js"></script>
     
    <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
       <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
    </script>--%>
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

   <%-- <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>--%>
    <script src="linksforcdns/Js/canvasjs.min.js"></script>
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