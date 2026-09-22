var selectitdadistrictid = "";
var godwansgistdata = "";
var geoXml = null;
var geoXmlDoc = null;
var geoXml1 = null;
var geoXml2 = null;
var geoXml4 = null;
var geoXml5 = null;
var geoXmlDoc1 = null;
var geoXmlDoc2 = null;
var geoXmlDoc4 = null;
var geoXmlDoc5 = null;
var map = null;
var markers = [];
var HouseholdDatamarker = [];
var litilltmarker = [];
var marker = [];
var maptypeclear = google.maps.MapTypeId.ROADMAP;
var mapset = {
    mapTypeId: maptypeclear
};
var myLatLng = null;
var myGeoXml3Zoom = true;
var sidebarHtml = "";
var infowindow = null;
var kmlLayer = null;
var filename = "";
var geocoder = new google.maps.Geocoder();

function initialize() {

    $("#loadingtext").show();
    $("#lbllegend").html("STATE");
    // MainLegend();
    sessionStorage.setItem("load", "dist");
    //callservermandal();
    myLatLng = new google.maps.LatLng(15.573731, 79.9345364);
    var zoom = 6;
    var maptype = google.maps.MapTypeId.ROADMAP;

    var myOptions = {
        zoom: zoom,
        center: myLatLng,

        mapTypeId: maptype
    };

    //kml load dist
    map = new google.maps.Map(document.getElementById("map"),
          myOptions);
    var src1 = '';



    alldistitdabound();

    infowindow = new google.maps.InfoWindow({});

    var zoomlev = map.getZoom();


    $("#loadingtext").hide();

};


function alldistitdabound() {

    var godwanskml = "../KML/95.kml";

    delete geoXml;
    delete geoXml1;
    delete geoXml2;


    geoXml = new geoXML3.parser({
      
        singleInfoWindow: true,
        afterParse: useTheDatanewload
    });
    geoXml.parse(godwanskml);




}

function useTheDatanewload(doc) {


    var currentBounds = map.getBounds();
    geoXmlDoc = doc[0];
    $("drpitda").empty();
    for (var i = 0; i < geoXmlDoc.placemarks.length; i++) {
        var placemark = geoXmlDoc.placemarks[i];

        if (placemark.polygon) {
            if (currentBounds.intersects(placemark.polygon.bounds)) {
                //makeSidebarPolygonEntry(i);
            }
            var normalStyle = {
                strokeColor: placemark.polygon.get('strokeColor'),
                strokeWeight: placemark.polygon.get('strokeWeight'),
                strokeOpacity: placemark.polygon.get('strokeOpacity'),
                fillColor: placemark.polygon.get('fillColor'),
                fillOpacity: placemark.polygon.get('fillOpacity')
            };
            placemark.polygon.normalStyle = normalStyle;


        }
     
            if (selectitdadistrictid != "") {
                if (placemark.name != null) {
                    if (placemark.name.split(',')[2] == selectitdadistrictid) {
                        geoXmlDoc.placemarks[i].polygon.setMap(map);
                        highlightPoly_load(placemark.polygon, i);
                        map.setZoom(8);
                        if ($("#Alltypes").val() == "all") {
                            Godwanslatlongsdata(placemark.name.split(',')[2]);
                        }
                    }
                }

            }
       
        else {
                geoXmlDoc.placemarks[i].polygon.setMap(map);
                highlightPoly_load(placemark.polygon, i);
                map.setZoom(6);
               
        }

    
    }


    $("#preloader").hide();

};

function highlightPoly_load(poly, polynum) {

    var colourcode = ""; var strokeColor = "";
    colourcode = "#ec4842"; strokeColor = "#060606";
    poly.setOptions({ fillColor: colourcode, strokeColor: strokeColor, fillOpacity: 0.11, strokeWidth: 5 });
    google.maps.event.addListener(poly, "mouseover", function (e) {
   
    });
    google.maps.event.addListener(poly, "click", function (e) {
     
      //  Godwanslatlongsdata(geoXmlDoc.placemarks[polynum].polygon.title.split(',')[2]);


    });

    google.maps.event.addListener(poly, "mouseout", function () {
        poly.infoWindow.close();
    });
    google.maps.event.addListener(poly, "rightclick", function (e) {
        if (geoXmlDoc.placemarks[polynum].polygon) {
            // map.fitBounds(geoXmlDoc.placemarks[polynum].polygon.bounds);
            if (e && e.latLng) {
                infowindow.setPosition(e.latLng);
            } else {
                infowindow.setPosition(placemark.polygon.bounds.getCenter());
            }
            infowindow.setContent('<div class="geoxml3_infowindow"><h4>Name :' + geoXmlDoc.placemarks[polynum].polygon.title.split(',')[0] +
                       '</h4><div></div></div>');
            infowindow.open(map);
        }

    });
}


function Godwanslatlongsdata(districtid) {
    var map = null;
    var location = null;
    var village = "";
    var result = [];

    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/Godwans/Latlongslist',
       data: "{'DistrictId':'" + districtid + "'}",
       dataType: "json",
       success: function (response) {
           console.log(JSON.stringify(response));
           var dist = response.itdalist;
           godwansgistdata = dist;
           if ($("#AllDistrict").val() != "all") {
               Godwansdatalist(dist, "all")
           }
       },
       error: function (result) {
           alert("Error");
       }

   });



}


function Godwansdatalist(godwanslist, typeofselection) {

    var Rbklist = [];
    var locations = [];

    Rbklist = godwanslist;
    console.log(Rbklist);

    var arr = [];
    var startPt = "";
    var endPt = "";
    var P1 = "";
    var P2 = "";
    var CP1 = "";
    var CP2 = "";

    // add code start
    var features = [];
    var marker, i;
    var infowindow = new google.maps.InfoWindow();
    var iconBase = 'https://giribhumi.ap.gov.in/imagesnew/';
    //var iconBase = 'EduStyles/images/';
    var icons = {};
    icons = {
        APSWC: {
            icon: iconBase + 'A_Agriculture.png'
        },
        Other: {
            icon: iconBase + 'A_Resourcecentre.png'
        },
    Private_Godowns: {
        icon: iconBase + 'A_Bus Stop.png'
    }
    };
    // alert("Rbklist.length --->" + Rbklist.length);
    for (var i = 0; i < Rbklist.length; i++) {
        var haplocations = [];
        //  var obj = JSON.parse(Rbklist[i]);
        //alert(obj.Lattitude);
      
      
        if (Rbklist[i].Type == typeofselection) {
            haplocations.push(Rbklist[i].Latitude, Rbklist[i].Longitude, Rbklist[i].NameoftheFacility, Rbklist[i].YrofEstablishment, Rbklist[i].OwnershipDetails, Rbklist[i].ManagedBy, Rbklist[i].ServicesProvided, Rbklist[i].StorageCapacity, Rbklist[i].Commoditiesstored, Rbklist[i].NearestHighway, Rbklist[i].NearestAirport, Rbklist[i].NearestSeaport);

           locations.push(haplocations);
           var othertype = "";
           if (Rbklist[i].Type == "Other Government Facilities") {
               othertype = "Other";
           }
           else {
               othertype = Rbklist[i].Type;
           }
           features.push({ position: new google.maps.LatLng(Rbklist[i].Latitude, Rbklist[i].Longitude), type: othertype });
        }
        else if (typeofselection =="all" )
        {
            haplocations.push(Rbklist[i].Latitude, Rbklist[i].Longitude, Rbklist[i].NameoftheFacility, Rbklist[i].YrofEstablishment, Rbklist[i].OwnershipDetails, Rbklist[i].ManagedBy, Rbklist[i].ServicesProvided, Rbklist[i].StorageCapacity, Rbklist[i].Commoditiesstored, Rbklist[i].NearestHighway, Rbklist[i].NearestAirport, Rbklist[i].NearestSeaport);

            locations.push(haplocations);
            var othertype = "";
            if (Rbklist[i].Type == "Other Government Facilities") {
                othertype = "Other";
            }
            else {
                othertype = Rbklist[i].Type;
            }
            features.push({ position: new google.maps.LatLng(Rbklist[i].Latitude, Rbklist[i].Longitude), type: othertype });
        }
      
     
      
        if (typeofselection == "Single") {
            if (CP1 == "") {
                CP1 = obj.Latitude;
                CP2 = obj.Longitude;
            }
        }
    }
    if (typeofselection == "Single") {
        var pt = new google.maps.LatLng(CP1, CP2);
        map.setCenter(pt);
        map.setZoom(15);
    }
    else if (typeofselection == "Multiple") {
        map.setZoom(6);
    }
   
    for (i = 0; i < locations.length; i++) {

        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][0], locations[i][1]),
            // please remove comment
            icon: icons[features[i].type].icon,
            map: map
        });
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var contentString = '<h6>Details</h6>' + '           <h6>Name of the Facility: ' + locations[i][2] + '</h6>' +
                                                                     '<h6>Latitude: ' + locations[i][0] + '</h6>' +
                                                                     '<h6>Longitude: ' + locations[i][1] + '</h6>' +
                                                                     '<h6>Yr of Establishment: ' + locations[i][3] + '</h6>' +

                                                                      ' <h6>Ownership Details: ' + locations[i][4] + '</h6>' +
                                                                        '<h6>ManagedBy: ' + locations[i][5] + '</h6>' +
                                                                          '<h6>Services Provided: ' + locations[i][6] + '</h6>' +
                                                                        '<h6>Storage Capacity: ' + locations[i][7] + '</h6>' +

                                                                        ' <h6>Commodities stored": ' + locations[i][8] + '</h6>' +
                                                                        '<h6>Nearest Highway: ' + locations[i][9] + '</h6>' +
                                                                        '<h6>Nearest Railway Station: ' + "" + '</h6>' +
                                                                        '<h6>Nearest Airport: ' + locations[i][10] + '</h6>' +
                                                                        '<h6>Nearest Seaport: ' + locations[i][11] + '</h6>'
                infowindow.setContent(contentString);
                infowindow.open(map, marker);
            }
        })(marker, i));

        google.maps.event.addListener(marker, 'rightclick', (function (marker, i) {
            return function () {
                var contentString = '<h6>Details</h6>' + '           <h6>Name of the Facility: ' + locations[i][2] + '</h6>' +
                                                                      '<h6>Latitude: ' + locations[i][0] + '</h6>' +
                                                                      '<h6>Longitude: ' + locations[i][1] + '</h6>' +
                                                                      '<h6>Yr of Establishment: ' + locations[i][3] + '</h6>' +

                                                                       ' <h6>Ownership Details: ' + locations[i][4] + '</h6>' +
                                                                         '<h6>ManagedBy: ' + locations[i][5] + '</h6>' +
                                                                           '<h6>Services Provided: ' + locations[i][6] + '</h6>' +
                                                                         '<h6>Storage Capacity: ' + locations[i][7] + '</h6>' +

                                                                         ' <h6>Commodities stored": ' + locations[i][8] + '</h6>' +
                                                                         '<h6>Nearest Highway: ' + locations[i][9] + '</h6>' +
                                                                         '<h6>Nearest Railway Station: ' + "" + '</h6>' +
                                                                         '<h6>Nearest Airport: ' + locations[i][10] + '</h6>' +
                                                                         '<h6>Nearest Seaport: ' + locations[i][11] + '</h6>'
                infowindow.setContent(contentString);
                infowindow.open(map, marker);

            }
        })(marker, i));
    }
}



$(document).ready(function () {



    $("#AllDistrict").change(function (e) {

        var DISTRICT = $("#AllDistrict").val();

        if(DISTRICT =="all")
        {
            selectitdadistrictid = "";
            initialize();
        }
        else {
            selectitdadistrictid = DISTRICT;
            initialize();
        }
    });

    $("#Alltypes").change(function (e) {

        var selecttype = $("#Alltypes").val();

        if (selecttype == "all") {
            Godwansdatalist(godwansgistdata, "all");
        }
        else {
            initialize();
            selecttype = $("#Alltypes").val();
            if (selecttype == "APSWC")
            {
                selecttype = "APSWC";
            }
            else if (selecttype == "OGF")
            {
                selecttype = "Other Government Facilities";
            }
            else if (selecttype == "PG") {
                selecttype = "Private_Godowns";
            }
            Godwansdatalist(godwansgistdata, selecttype);
        }
    });
});


