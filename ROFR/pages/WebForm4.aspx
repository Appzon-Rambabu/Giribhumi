<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="ROFR.pages.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../chartjs/jquery-1.7.1.js"></script>
          <%--  <script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>
    <script src="../linksforcdns/Js/jsapi.js"></script>
      <script>
                var chartData; // globar variable for hold chart data
                google.load("visualization", "1", { packages: ["corechart"] });
 
                // Here We will fill chartData
 
                $(document).ready(function () {
                    var hidField1 = "";
                    var hidField2 = "";
                    var hidField3 = "";
                    var hidField4 ="";
                    var hidField5 = "";
                    var hidField6 = "";

                    $.ajax({
                        //type: 'POST',
                        //contentType: 'application/json; charset=utf-8',
                        //url: '/api/ITDA/Piechart',
                        //data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
                        //dataType: "json",
                        url: "ITDAWISE_POPULATION_REPORT.aspx/GetPopulationData1",
                        data: "",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; chartset=utf-8",
                        success: function (response) {
                            chartData = response.d;
                        },
                        error: function () {
                            alert("Error loading data! Please try again.");
                        }
                    }).done(function () {
                        // after complete loading data
                        google.setOnLoadCallback(drawChart);
                        drawChart();
                    });
                });
 
 
                function drawChart() {
                    var data = google.visualization.arrayToDataTable(chartData);
 
                    var options = {
                        title: 'MONTHLY SALE OF BOOKS',
                        pieHole: 0.4,                       // SET NUMBER BETWEEN 0 AND 1.
                        colors: ['orange', '#56B21F']
                    };
 
                    var pieChart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    pieChart.draw(data, options);
 
                }
 
            </script>
  <%--  <script>
window.onload = function() {

var chart = new CanvasJS.Chart("chartContainer", {
	animationEnabled: true,
	title: {
		text: "Desktop Search Engine Market Share - 2016"
	},
	data: [{
		type: "pie",
		startAngle: 240,
		yValueFormatString: "##0.00\"%\"",
		indexLabel: "{label} {y}",
		dataPoints: [
			{y: 79.45, label: "Google"},
			{y: 7.31, label: "Bing"},
			{y: 7.06, label: "Baidu"},
			{y: 4.91, label: "Yahoo"},
			{y: 1.26, label: "Others"}
		]
	}]
});
chart.render();

}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="chart_div" style="height: 300px; width: 100%;"></div>

    </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>ahammed
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>bhagya
         <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>siva
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
         <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
       
    </form>
   
<%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
      <script type="text/javascript" src="GISNew/js/bundle.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/build/myworld.js?0"></script>
    <script type="text/javascript" src="GISNew/js/myworld/dummy.js"></script>
    <script type="text/javascript" src="GISNew/js/myworld/map-init--index.js"></script>
    <script src="../MapJsfloder/canvasjs.min.js"></script>--%>

   <%--  <script src="../MapJsfloder/PieChart.js"></script>--%>
        
       
   
   
</body>
</html>
