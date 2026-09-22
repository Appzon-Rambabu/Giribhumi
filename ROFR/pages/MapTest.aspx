<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapTest.aspx.cs" Inherits="ROFR.pages.MapTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    html, body {
  height: 370px;
  padding: 0;
  margin: 0;
  }
#map {
 height: 360px;
 width: 300px;
 overflow: hidden;
 float: left;
 border: thin solid #333;
 }
#capture {
 height: 360px;
 width: 480px;
 overflow: hidden;
 float: left;
 background-color: #ECECFB;
 border: thin solid #333;
 border-left: none;
 }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="map"></div>
<div id="capture"></div>
<!-- Replace the value of the key parameter with your own API key. -->

    </div>
    </form>
</body>
 <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
<script src="../linksforcdns/Js/1.7.1.jquery.min.js"></script>
  <%--  <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0">
</script>--%>
<script src="../linksforcdns/Js/AIzaSyCx2cY6Odt3ckOO-WtYInywqwEhIVSm9L0.js"></script>
   <script type="text/javascript" src="../MapJsfloder/Maptest.js"></script>
      <script src="js/custom.js"></script>
    <script src="js/jquery-3.3.1.slim.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</html>
