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
var vrefid = null;
var vhabcode = null;
var vassetcode = null;
var vsubassetcode = null;
var kmlLayer;
function Refresh() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var infowindow = new google.maps.InfoWindow({
       
        disableAutoPan: true
    });
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: location,

        mapTypeId: google.maps.MapTypeId.HYBRID

    });
    var src = 'http://giripragati.ap.gov.in/TestMap/KML/ap_district_bnd.kmz';
    var src1 = 'http://giripragati.ap.gov.in/TestMap/KML/itda_total_bnd.kmz';
 
    var msrc = 'http://localhost:60061/MapJsfloder/chintoor.kmz'; 
    kmlLayer = new google.maps.KmlLayer(src, {
        map: map,
        suppressInfoWindows: true
       
    });
    kmlLayer = new google.maps.KmlLayer(src1, {
        map: map,
        suppressInfoWindows: true
    });

    google.maps.event.addListener(kmlLayer, 'click', function (kmlEvent) {
        var text = kmlEvent.featureData.id;
       
     
        if (text == 'ID_00007') {

            kmlLayer = new google.maps.KmlLayer(src, {
                map: map,
                suppressInfoWindows: true
            });
        }
        else
        {
            alert('no data');
        }
      
       
    });
    //kmlLayer.addListener('click', function (event) {
      
    //    var id=event.infoWindow
    //    alert(id);
    //    //kmlLayer = new google.maps.KmlLayer(src, {
    //    //    map: map
    //    //});
    //}
    //)

    //$('#ID_00007').on('click', function (e) {
    //    alert(kmlLayer.id)
    //});
   
    //$('#ID_00007').click({
    //    alert( kmlLayer)
          
    //    });



};

function initMap() {
    // Refresh();
    dlccheck();




};

function dlccheck()
{
    alert('url:https://giribhumi.ap.gov.in//DLC/22-02-2009/06-05-2021_1685%20DLC%20dt%2022.02.2009.pdf')
    var file="https://giribhumi.ap.gov.in//DLC/22-02-2009/06-05-2021_1685%20DLC%20dt%2022.02.2009.pdf";
    getBase64(file).then(
    data => console.log(data)
  );
}

function getBase64(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}
$(document).ready(function () {




    //For ITDA




    //For Mandals







    initMap();
    //For Villages







});