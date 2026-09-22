$(document).ready(function () {
     var hidField1 = "";
    var hidField2 = "";
    var hidField3 ="";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "";


    
    google.load("visualization", "1", { packages: ["corechart"] });

    google.setOnLoadCallback(DrawDonut);

    function DrawDonut() {

        var options = {
            title: 'MONTHLY SALE OF BOOKS',
            pieHole: 0.4,                       // SET NUMBER BETWEEN 0 AND 1.
            colors: ['orange', '#56B21F']      // ADD CUSTOM COLORS.
        };
        var hidField1 = "";
        var hidField2 = "";
        var hidField3 = "";
        var hidField4 = "";
        var hidField5 = "";
        var hidField6 = "";
        $.ajax({

            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/api/ITDA/Piechart',
            data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                var data = response;
                var arrValues = [['Month', 'Sales Figure']];        // DEFINE AN ARRAY.
                var iCnt = 0;

                $.map(data, function () {
                    arrValues.push([data[iCnt].Month, data[iCnt].SalesFigure]);
                    iCnt += 1;
                });

                // CREATE A DataTable AND ADD THE ARRAY (WITH DATA) IN IT.
                var figures = google.visualization.arrayToDataTable(arrValues)

                // THE TYPE OF CHART. IT’S A PIE CHART, HOWEVER THE “pieHole” OPTION 
                // (SEE “var options” ABOVE) WILL ADD A SPACE AT THE CENTER FOR DONUT.
                var chart = new google.visualization.PieChart(document.getElementById('chartContainer'));

                chart.draw(figures, options);      // DRAW GRAPH WITH THE DATA AND OPTIONS.
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert('There was an Error');
            }
        });
    }
  




});
 
 
//function drawChart() {
//    var data = google.visualization.arrayToDataTable(chartData);
 
//    var options = {
//        title: "POPULATION VS BENEFICIARES",                        
//        pointSize: 10

//    };
 
//    var pieChart = new google.visualization.PieChart(document.getElementById('chart_div'));
//    pieChart.draw(data, options);
 
//}


//window.onload = function () {

//    var chart = new CanvasJS.Chart("chartContainer", {
//        animationEnabled: true,
//        title: {
//            text: "Desktop Search Engine Market Share - 2016"
//        },
//        data: [{
//            type: "pie",
//            startAngle: 240,
//            yValueFormatString: "##0.00\"%\"",
//            indexLabel: "{label} {y}",
//            dataPoints: [
//                { y: 79.45, label: "Google" },
//                { y: 7.31, label: "Bing" },
//                { y: 7.06, label: "Baidu" },
//                { y: 4.91, label: "Yahoo" },
//                { y: 1.26, label: "Others" }
//            ]
//        }]
//    });
//    chart.render();

//}
 
