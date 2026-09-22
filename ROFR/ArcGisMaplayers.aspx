<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArcGisMaplayers.aspx.cs" Inherits="ROFR.ArcGisMaplayers" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Tribal Welfare</title>
   
   
    <link rel="stylesheet" href="../kmlcss1/main.css"/>
    <link rel="stylesheet" href="../kmlcss1/select2.css"/>
<%--   <script type="text/javascript" src="https://maps.google.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0"></script>--%>
    <script src="linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>

<%--  <script src="../kmlJS_Content/canvasjs.min.js"></script>--%>

    <script src="../kmlTribalJs1/trigissupport.js"></script>

    <script src="../kmlTribalJs1/MisReport.js"></script>
    
    <style type="text/css">
        html, body, #map {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #loaddiv {
        }

        .infowindow * {
            font-size: 90%;
            margin: 0;
        }
    </style>
</head>
<body onload="initialize()">
     
    

    <form id="form1" runat="server">

      

  
          
           
            <div id="map">
                
            </div>

    


      
      

    

        <script type="text/javascript" src="../kmljs1/bundle.js"></script>
        <script type="text/javascript" src="../kmljs1/myworld/build/myworld.js?0"></script>
        <script type="text/javascript" src="../kmljs1/myworld/dummy.js"></script>



    </form>
</body>
</html>