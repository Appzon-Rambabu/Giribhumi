
var map = null;
var infoWindow = null;
var arr = new Array();
var polygons = [];
var subdivision1 = [];
var dist1 = [];
var hidField = null;
var clickparmeter = null;
var landview = [];

var globalVariable1;
var local;


function initMap() {
    Refresh();

    Dashboardcounts()

};


function Dashboardcounts() {
    var Districtcode = "";
    var Districtname = "";
    var result = [];
    var hidField1 = "";
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "TOTAL DISTRICTS";
    var PLATT = "";
    var PLONG = "";
    var hidField1 = "Finaldistrict.xlsx";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/EXCELVALUESFENCING',
       data: "{'ITDA':'" + hidField1 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist1 = response;
           var bounds = new google.maps.LatLngBounds();


           result = [];

           Districtcode = "";
           for (var i = 0; i < 11129; i++) {

               result.push(new google.maps.LatLng(
                       parseFloat(dist1.itdalist[i].DISTRICT_LATITUDE),
                     parseFloat(dist1.itdalist[i].DISTRICTLONGITUDE)
                ));
               bounds.extend(result[result.length - 1])
               if (Districtcode == "") {
                   Districtcode = dist1.itdalist[i].DISTRICT_CODE;
                   Districtname = dist1.itdalist[i].DISTRICT_NAME;
               }
               if (PLATT == "") {
                   PLATT = dist1.itdalist[i].DISTRICT_LATITUDE;
                   PLONG = dist1.itdalist[i].DISTRICTLONGITUDE;
               }
           }

           // Construct the polygon.
           landview = new google.maps.Polygon({
               paths: result,
               strokeColor: '#000000',
               strokeOpacity: 0.8,
               strokeWeight: 3,
               fillColor: '#FFFFB2',
               fillOpacity: 13,
               indexID: Districtcode,
               indexname: Districtname
           });
           landview.setMap(map);




           map.fitBounds(bounds);
           var pt = new google.maps.LatLng('17.998426', '82.739254');
           map.setCenter(pt);
           map.setZoom(6);
           if (map.getZoom() <= 8) {
               map.setZoom(6);
           }
           infoWindow = new google.maps.InfoWindow;

       },
       error: function (result) {
           alert("Error");
       }

   });
};




function Refresh() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });




};

// For District
$(document).ready(function () {
    initMap();
});


