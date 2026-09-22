<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleCharts.aspx.cs" Inherits="ROFR.test.GoogleCharts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <%-- Here We need to write some js code for load google chart with database data --%>
            <script src="../chartjs/jquery-1.7.1.js"></script>
            <script type="text/javascript" src="https://www.google.com/jsapi"></script>
 
            <script>
                var chartData; // globar variable for hold chart data
                google.load("visualization", "1", { packages: ["corechart"] });
 
                // Here We will fill chartData
 
                $(document).ready(function () {
                    debugger;
                    $.ajax({
                        url: "GoogleCharts.aspx/GetPopulationData",
                        data: "",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; chartset=utf-8",
                        success: function (data) {
                            chartData = data.d;
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
                        title: "POPULATION VS BENEFICIARES",
                        pointSize: 10
                    };
 
                    var pieChart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    pieChart.draw(data, options);
 
                }
 
            </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
          <div id="chart_div" style="width:500px;height:400px">
                <%-- Here Chart Will Load --%>
            </div>
    </div>
    </form>
</body>
</html>
