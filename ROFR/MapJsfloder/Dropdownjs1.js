
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
    // Districtgismap();
    InitialAllassets(false);



};


function Dashboardcounts() {
    var hidField1 = "";
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = $("#Village").val();
    var hidField5 = "";
    var hidField6 = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/DeptAssetcount',
       data: "{'HABITATION':'" + hidField4 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           for (var i = 0; i < dist.itdalist.length; i++) {

               if (dist.itdalist[i].DEPT_CODE <= '931') {

                   var idvalue = '#' + dist.itdalist[i].DEPT_CODE + '1';
                   var valueid = '(' + dist.itdalist[i].CNT + ')';

                   $(idvalue).html(valueid);

               }

           }
           var idvalue1 = '#' + "922" + '1';
           var valueid1 = '(' + "1" + ')';
           $(idvalue1).html(valueid1);

       },
       error: function (result) {
           alert("Error");
       }

   });
};



function Districtgismap() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var map = new google.maps.Map(document.getElementById('map'), {
        styles: [
{
    featureType: "all",
    elementType: "labels",
    stylers: [
        { visibility: "off" }
    ]
}
        ],

        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });
    var result = [];
    var hidField1 = "11463005002";
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "11463005002"; //$("#Village").val();
    var hidField6 = "";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Villagefencing',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           // console.log(JSON.stringify(response));
           var dist1 = response;
           if (dist1.Status == "Failure") {
           }
           else {

               var bounds = new google.maps.LatLngBounds();


               result = [];


               for (var i = 0; i < dist1.itdalist.length; i++) {

                   result.push(new google.maps.LatLng(
                           parseFloat(dist1.itdalist[i].LATITUDE),
                         parseFloat(dist1.itdalist[i].LONGITUDE)
                    ));
                   bounds.extend(result[result.length - 1])
                   if (PLATT == "") {
                       PLATT = dist1.itdalist[i].LATITUDE;
                       PLONG = dist1.itdalist[i].LONGITUDE;
                   }
               }

               // Construct the polygon.
               landview = new google.maps.Polygon({
                   paths: result,
                   strokeColor: '#ADFF2F',
                   strokeOpacity: 0.8,
                   strokeWeight: 3,
                   fillColor: '',
                   fillOpacity: 0
               });
               landview.setMap(map);
               map.fitBounds(bounds);
               var pt = new google.maps.LatLng(PLATT, PLONG);
               map.setCenter(pt);
               map.setZoom(15);
           }

       },
       error: function (result) {
           alert("Error");
       }

   });
}


function Roadmap1() {
    var hidField11 = "";
    var hidField21 = "";
    var hidField31 = "";
    var hidField41 = "011463005002";
    var hidField51 = "01";
    var hidField61 = "WC921010339";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Road',
       data: "{'ITDA':'" + hidField11 + "','DISTRICT':'" + hidField21 + "', 'MANDAL':'" + hidField31 + "', 'VILLAGE':'" + hidField51 + "', 'HABITATION':'" + hidField41 + "', 'Type':'" + hidField61 + "'}",
       dataType: "json",
       success: function (response) {
           console.log(JSON.stringify(response));
           var distr = response;
           if (distr.Status == "Failure") {
           }
           else {
               arr = [];
               var startPt = "";
               var endPt = "";
               var P1 = "";
               var P2 = "";
               for (var i = 0; i < distr.itdalist.length; i++) {
                   if (i == 0) {
                       P1 = distr.itdalist[i].REF_ID;
                       break;
                   }
               }
               for (var i = 0; i < distr.itdalist.length; i++) {
                   if (P1 == distr.itdalist[i].REF_ID) {
                       arr.push(new google.maps.LatLng(
                                       parseFloat(distr.itdalist[i].LATITUDE),
                                     parseFloat(distr.itdalist[i].LONGITUDE)
                                ));
                   }
                   else {
                       var flightPath = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'black',
                           strokeOpacity: 1.0,
                           strokeWeight: 6

                       });
                       flightPath.setMap(map);
                       var polyline = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'red',
                           strokeOpacity: 1.0,
                           strokeWeight: 4,
                       });

                       polyline.setMap(map);
                       P1 = distr.itdalist[i].REF_ID;
                       arr = [];
                       arr.push(new google.maps.LatLng(
                                       parseFloat(distr.itdalist[i].LATITUDE),
                                     parseFloat(distr.itdalist[i].LONGITUDE)
                                ));
                   }

                   if (i == 0) {
                       startPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                   }
                   if (i == (distr.itdalist.length - 1)) {
                       endPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                   }
               }
               var flightPath = new google.maps.Polyline({
                   path: arr,
                   geodesic: true,
                   strokeColor: 'black',
                   strokeOpacity: 1.0,
                   strokeWeight: 6

               });
               flightPath.setMap(map);
               var polyline = new google.maps.Polyline({
                   path: arr,
                   geodesic: true,
                   strokeColor: 'red',
                   strokeOpacity: 1.0,
                   strokeWeight: 4,
               });

               polyline.setMap(map);
           }
       },
       error: function (result) {
           alert("Error");
       }

   });


}

function Roadmap() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var assetmap1 = new google.maps.Map(document.getElementById('map'), {
        styles: [
{
    featureType: "all",
    elementType: "labels",
    stylers: [
        { visibility: "off" }
    ]
}
        ],

        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });
    //road
    if ($("#Village").val() != "011463005002") {
        var x = document.getElementById(922).checked;
        if (x != false) {
            var hidField11 = "";
            var hidField21 = "";
            var hidField31 = "";
            var hidField41 = $("#Village").val();
            var hidField51 = "01";
            var hidField61 = "WC921010339";
            $.ajax(
           {
               type: 'POST',
               contentType: 'application/json; charset=utf-8',
               url: '/api/ITDA/Road',
               data: "{'ITDA':'" + hidField11 + "','DISTRICT':'" + hidField21 + "', 'MANDAL':'" + hidField31 + "', 'VILLAGE':'" + hidField51 + "', 'HABITATION':'" + hidField41 + "', 'Type':'" + hidField61 + "'}",
               dataType: "json",
               success: function (response) {
                   console.log(JSON.stringify(response));
                   var distr = response;
                   if (distr.Status == "Failure") {
                   }
                   else {
                       arr = [];
                       var startPt = "";
                       var endPt = "";
                       var P1 = "";
                       var P2 = "";
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (i == 0) {
                               P1 = distr.itdalist[i].REF_ID;
                               break;
                           }
                       }
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (P1 == distr.itdalist[i].REF_ID) {
                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }
                           else {
                               var flightPath = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'black',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 6

                               });
                               flightPath.setMap(assetmap1);
                               var polyline = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'red',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 4,
                               });

                               polyline.setMap(assetmap1);
                               P1 = distr.itdalist[i].REF_ID;
                               arr = [];
                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }

                           if (i == 0) {
                               startPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                           if (i == (distr.itdalist.length - 1)) {
                               endPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                       }
                       var flightPath = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'black',
                           strokeOpacity: 1.0,
                           strokeWeight: 6

                       });
                       flightPath.setMap(assetmap1);
                       var polyline = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'red',
                           strokeOpacity: 1.0,
                           strokeWeight: 4,
                       });

                       polyline.setMap(assetmap1);
                   }
               },
               error: function (result) {
                   alert("Error");
               }

           });
        }
    }
}

function calcRoute(arr) {
    var flightPath = new google.maps.Polyline({
        path: arr,
        geodesic: true,
        strokeColor: 'black',
        strokeOpacity: 1.0,
        strokeWeight: 6

    });
    flightPath.setMap(map);
    var polyline = new google.maps.Polyline({
        path: arr,
        geodesic: true,
        strokeColor: 'red',
        strokeOpacity: 1.0,
        strokeWeight: 4,
    });

    polyline.setMap(map);
}

function check(y) {
    var AssetsArray = ["901", "902", "903", "904", "905", "906", "907", "908", "909", "910", "911", "912", "913", "914", "915", "916", "917", "918", "919", "920", "921", "923", "924", "925", "926", "927", "928", "929", "930", "931", "922"];
    var deptarray = [];
    var x = document.getElementById(y).checked;

    for (var i = 0; i < AssetsArray.length; i++) {

        if (document.getElementById(AssetsArray[i]).checked == true) {

            deptarray.push(AssetsArray[i]);
        }

    }
    if (deptarray.length == 0) {
        alert("Please Select Atleast One Department");
        Refresh();

    }
    else {
        if ($("#Village").val() != " " && deptarray.length >= 0) {


            $.ajax(
             {
                 type: 'POST',
                 contentType: 'application/json; charset=utf-8',
                 url: '/api/ITDA/Allassetslatongs1',
                 data: "{'Data':'" + deptarray + "','Datalength':'" + deptarray.length + "', 'Asset':'" + "" + "', 'SubAsset':'" + "" + "', 'Type':'" + "" + "'}",
                 dataType: "json",
                 success: function (response) {
                     //console.log(JSON.stringify(response));
                     var dist = response;
                     if (dist.Status == "Failure") {
                         var x = document.getElementById(922).checked;
                         if (x != false) {
                             Roadmap();
                         }
                         else {
                             Refresh();
                         }

                     }
                     else {


                         subassetsmap(dist);
                     }

                 },
                 error: function (result) {
                     alert("Error");
                 }

             });
        }

    }
};


function subassetsmap(dist) {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var assetmap1 = new google.maps.Map(document.getElementById('map'), {
        styles: [
{
    featureType: "all",
    elementType: "labels",
    stylers: [
        { visibility: "off" }
    ]
}
        ],

        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });
    $("#lblprofile").html("Village Profile");

    var village = "";
    var villagecode = "";
    var result = [];

    var PLATT = "";
    var PLONG = "";


    //console.log(JSON.stringify(response));
    //  var dist = response;
    if (dist.Status == "Failure") {
        Refresh();

    } else {
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < dist.itdalist.length; i++) {

            var locations = [];
            var features = [];
            for (var i = 0; i < dist.itdalist.length; i++) {



                var haplocations = [];
                haplocations.push(dist.itdalist[i].DEPT, dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE, dist.itdalist[i].DEPARTMENT_NAME,
              dist.itdalist[i].ASSET_NAME, dist.itdalist[i].SUBASSET_NAME, dist.itdalist[i].SUBASSET_CONDITION, dist.itdalist[i].ASSET, dist.itdalist[i].SUB_ASSET, dist.itdalist[i].REF_ID);
                locations.push(haplocations);
                features.push({ position: new google.maps.LatLng(dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE), type: dist.itdalist[i].DEPT });


                if (PLATT == "" || PLATT == null) {
                    PLATT = dist.itdalist[i].LATITUDE;
                    PLONG = dist.itdalist[i].LONGITUDE;
                }


            }
            var marker, i;
            var infowindow = new google.maps.InfoWindow();
            var iconBase =
           'http://giribhumi.ap.gov.in/imagesnew/';
            var icons = {};
            var parameter = 'PHC';

            if (parameter == 'HOSPITALS') {
                icons = {
                    parking: {
                        icon: iconBase + 'maphome.jpg'
                    },
                    library: {
                        icon: iconBase + 'maphome.jpg'
                    },
                    info: {
                        icon: iconBase + 'maphome.jpg'
                    }
                };

            }
            else if (parameter == 'EDUCATION') {
                icons = {
                    parking: {
                        icon: iconBase + 'mapeducation.jpg'
                    },
                    library: {
                        icon: iconBase + 'mapeducation.jpg'
                    },
                    info: {
                        icon: iconBase + 'mapeducation.jpg'
                    }
                };
            }
            else if (parameter == 'PHC') {
                icons = {
                    901: {
                        icon: iconBase + 'A_Agriculture.png'
                    },
                    902: {
                        icon: iconBase + 'A_Bus Stop.png'
                    },
                    903: {
                        icon: iconBase + 'A_Dairy form.png'
                    },
                    904: {
                        icon: iconBase + 'AEducation.png'
                    },
                    905: {
                        icon: iconBase + 'AElectric.png'
                    },
                    906: {
                        icon: iconBase + 'A_Fibernet.png'
                    },
                    907: {
                        icon: iconBase + 'A_ATM Centre.png'
                    },
                    908: {
                        icon: iconBase + 'A_Ration Shop.png'
                    },
                    909: {
                        icon: iconBase + 'A_Plantation.png'
                    },
                    910: {
                        icon: iconBase + 'A_BC Welfare.png'
                    },
                    911: {
                        icon: iconBase + 'A_Ayurveda Centre.png'
                    },
                    912: {
                        icon: iconBase + 'A_AE Irrigation.png'
                    },
                    913: {
                        icon: iconBase + 'A_Children Home.png'
                    },
                    914: {
                        icon: iconBase + 'A_Fire Station.png'
                    },
                    915: {
                        icon: iconBase + 'A_Burial ground.png'
                    },
                    916: {
                        icon: iconBase + 'A_VRO.png'
                    },
                    917: {
                        icon: iconBase + 'A_Bore wells.png'
                    },
                    918: {
                        icon: iconBase + 'A_Serp.png'
                    },
                    919: {
                        icon: iconBase + 'A_Cell Tower.png'
                    },
                    920: {
                        icon: iconBase + 'A_Gopala Mitra Centre.png'
                    },
                    921: {
                        icon: iconBase + 'A_Anganwadi.png'
                    },
                    923: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    924: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    925: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    926: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    927: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    928: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    929: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    930: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    931: {
                        icon: iconBase + 'A_Resourcecentre.png'
                    },
                    922: {
                        icon: iconBase + 'maplocation.jpg'
                    },
                    library: {
                        icon: iconBase + 'maplocation.jpg'
                    },
                    info: {
                        icon: iconBase + 'maplocation.jpg'
                    }
                };
            }
            else if (parameter == 'All') {
                icons = {
                    parking: {
                        icon: iconBase + 'maphome.jpg'
                    },
                    library: {
                        icon: iconBase + 'maplocation.jpg'
                    },
                    info: {
                        icon: iconBase + 'mapeducation.jpg'
                    }
                };
            }
            else {
                icons = {
                    parking: {
                        icon: iconBase + 'maphome.jpg'
                    },
                    library: {
                        icon: iconBase + 'maplocation.jpg'
                    },
                    info: {
                        icon: iconBase + 'mapeducation.jpg'
                    }
                };
            }
            for (i = 0; i < locations.length; i++) {

                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                    icon: icons[features[i].type].icon,
                    map: assetmap1
                });


                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        // var currentvillage = locations[i][0];
                        //  clickparmeter = locations[i][0];
                        //  infowindow.setContent(locations[i][0]);
                        //infowindow.open(map, marker);
                        Assetimageview($("#Village").val(), locations[i][8]);
                        //sessionStorage.setItem("lastname", $("#Village").val());
                        //function1($("#Village").val());


                        var orgurl = ("http://giribhumi.ap.gov.in/Imageprofile.aspx?id=1&type=4");
                        var habcode = $("#Village").val();
                        var assetcode = locations[i][7];
                        var subassetcode = locations[i][8];
                        var refid = locations[i][9];
                        var urlBase = 'http://giribhumi.ap.gov.in/Imageprofile.aspx?id=' + habcode + '&assettype=' + assetcode + '&type=' + subassetcode + '&reftype=' + refid + '&d=' + locations[i][0] + '&la=' + locations[i][1] + '&lo=' + locations[i][2];
                        var win = window.open(urlBase, '_blank');

                        // win.token=$("#Village").val();
                        //  win.focus();


                    }
                })(marker, i));

                google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                    return function () {
                        var asset = "";
                        var subasset = "";
                        if (locations[i][0] == "914") {
                            asset = "SHG Building";
                            subasset = "SHG Building";
                        }
                        else {
                            asset = locations[i][4];
                            subasset = locations[i][5];

                        }
                        if (locations[i][0] == "922") {

                            var contentString = '<h6>Village Profile Asset Details</h6>' +
                        '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                        '<h6>ROAD TYPE: ' + asset + '</h6>' +
                        '<h6>ROAD NAME: ' + subasset + '</h6>' +
                        '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                        }
                        else {
                            var contentString = '<h6>Village Profile Asset Details</h6>' +
                                                               '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                                                               '<h6>ASSET NAME: ' + asset + '</h6>' +
                                                               '<h6>SUBASSET NAME: ' + subasset + '</h6>' +
                                                               '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                        }
                        infowindow.setContent(contentString);
                        infowindow.open(assetmap1, marker);
                    }
                })(marker, i));
                google.maps.event.addListener(marker, 'mouseout', (function (marker, i) {
                    return function () {

                        infowindow.close();
                    }
                })(marker, i));
            }


            var pt = new google.maps.LatLng(PLATT, PLONG);
            assetmap1.setCenter(pt);
            assetmap1.setZoom(18);
            //villagefencingmap
            var result = [];
            var hab = $("#Village").val();
            $.ajax(
                 {
                     type: 'POST',
                     contentType: 'application/json; charset=utf-8',
                     url: '/api/ITDA/Villagefencing',
                     data: "{'ITDA':'" + "" + "','DISTRICT':'" + "" + "', 'MANDAL':'" + "" + "', 'VILLAGE':'" + "" + "', 'HABITATION':'" + hab + "', 'Type':'" + "" + "'}",
                     dataType: "json",
                     success: function (response) {
                         // console.log(JSON.stringify(response));
                         var dist1 = response;
                         if (dist1.Status == "Failure") {

                         }
                         else {
                             var bounds = new google.maps.LatLngBounds();


                             result = [];


                             for (var i = 0; i < dist1.itdalist.length; i++) {

                                 result.push(new google.maps.LatLng(
                                         parseFloat(dist1.itdalist[i].LATITUDE),
                                       parseFloat(dist1.itdalist[i].LONGITUDE)
                                  ));
                                 bounds.extend(result[result.length - 1])
                                 if (PLATT == "") {
                                     PLATT = dist1.itdalist[i].LATITUDE;
                                     PLONG = dist1.itdalist[i].LONGITUDE;
                                 }
                             }

                             // Construct the polygon.
                             landview = new google.maps.Polygon({
                                 paths: result,
                                 strokeColor: '#ADFF2F',
                                 strokeOpacity: 0.8,
                                 strokeWeight: 3,
                                 fillColor: '',
                                 fillOpacity: 0
                             });
                             landview.setMap(assetmap1);
                             assetmap1.fitBounds(bounds);
                             //var pt = new google.maps.LatLng(PLATT, PLONG);
                             //map.setCenter(pt);
                             //map.setZoom(12);
                         }

                     },
                     error: function (result) {
                         alert("Error");
                     }

                 });
        }
    }

    //road
    if ($("#Village").val() != "011463005002") {
        var x = document.getElementById(922).checked;
        if (x != false) {
            var hidField11 = "";
            var hidField21 = "";
            var hidField31 = "";
            var hidField41 = $("#Village").val();
            var hidField51 = "01";
            var hidField61 = "WC921010339";
            $.ajax(
           {
               type: 'POST',
               contentType: 'application/json; charset=utf-8',
               url: '/api/ITDA/Road',
               data: "{'ITDA':'" + hidField11 + "','DISTRICT':'" + hidField21 + "', 'MANDAL':'" + hidField31 + "', 'VILLAGE':'" + hidField51 + "', 'HABITATION':'" + hidField41 + "', 'Type':'" + hidField61 + "'}",
               dataType: "json",
               success: function (response) {
                   console.log(JSON.stringify(response));
                   var distr = response;
                   if (distr.Status == "Failure") {
                   }
                   else {
                       arr = [];
                       var startPt = "";
                       var endPt = "";
                       var P1 = "";
                       var P2 = "";
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (i == 0) {
                               P1 = distr.itdalist[i].REF_ID;
                               break;
                           }
                       }
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (P1 == distr.itdalist[i].REF_ID) {

                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }
                           else {
                               var flightPath = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'black',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 6

                               });
                               flightPath.setMap(assetmap1);

                               var polyline = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'red',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 4,
                               });

                               polyline.setMap(assetmap1);
                               P1 = distr.itdalist[i].REF_ID;

                               arr = [];
                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }

                           if (i == 0) {
                               startPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                           if (i == (distr.itdalist.length - 1)) {
                               endPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                       }
                       var flightPath = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'black',
                           strokeOpacity: 1.0,
                           strokeWeight: 6

                       });
                       flightPath.setMap(assetmap1);

                       var polyline = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'red',
                           strokeOpacity: 1.0,
                           strokeWeight: 4,
                       });

                       polyline.setMap(assetmap1);
                   }
               },
               error: function (result) {
                   alert("Error");
               }

           });
        }
    }


};

function Refresh() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var map1 = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });




};


function Allassets(y) {
    var AssetsArray = ["901", "902", "903", "904", "905", "906", "907", "908", "909", "910", "911", "912", "913", "914", "915", "916", "917", "918", "919", "920", "921", "923", "924", "925", "926", "927", "928", "929", "930", "931", "922"];
    var x = document.getElementById(y).checked;
    if (x == false) {
        alert("Please Select Atleast One Department");
        Refresh();
    }
    else {
        Allassetsmap();
    }
    for (var i = 0; i < AssetsArray.length; i++) {

        if (x == true) {
            document.getElementById(AssetsArray[i]).checked = true;
        }
        else {
            document.getElementById(AssetsArray[i]).checked = false;
        }

    }
}

function InitialAllassets(value) {
    var AssetsArray = ["901", "902", "903", "904", "905", "906", "907", "908", "909", "910", "911", "912", "913", "914", "915", "916", "917", "918", "919", "920", "921", "923", "924", "925", "926", "927", "928", "929", "930", "931", "922"];
    var x = value;

    for (var i = 0; i < AssetsArray.length; i++) {

        if (x == true) {
            document.getElementById(23).checked = true;
            document.getElementById(AssetsArray[i]).checked = true;
        }
        else {
            document.getElementById(23).checked = false;
            document.getElementById(AssetsArray[i]).checked = false;
        }

    }
}

function Allassetsmap() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var assetmap = new google.maps.Map(document.getElementById('map'), {
        styles: [
{
    featureType: "all",
    elementType: "labels",
    stylers: [
        { visibility: "off" }
    ]
}
        ],

        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });
    $("#lblprofile").html("Village Profile");

    var village = "";
    var villagecode = "";
    var result = [];
    var hidField1 = $("#Village").val();
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "SINGLE-ALL ASSETS";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Allassetslatongs',
       data: "{'HABITATION':'" + hidField1 + "','Dept':'" + hidField2 + "', 'Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           if (dist.Status == "Failure") {
               Refresh();

           } else {
               var bounds = new google.maps.LatLngBounds();
               for (var i = 0; i < dist.itdalist.length; i++) {

                   var locations = [];
                   var features = [];
                   for (var i = 0; i < dist.itdalist.length; i++) {



                       var haplocations = [];
                       haplocations.push(dist.itdalist[i].DEPT, dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE, dist.itdalist[i].DEPARTMENT_NAME,
                     dist.itdalist[i].ASSET_NAME, dist.itdalist[i].SUBASSET_NAME, dist.itdalist[i].SUBASSET_CONDITION, dist.itdalist[i].ASSET, dist.itdalist[i].SUB_ASSET, dist.itdalist[i].REF_ID);
                       locations.push(haplocations);
                       features.push({ position: new google.maps.LatLng(dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE), type: dist.itdalist[i].DEPT });


                       if (PLATT == "" || PLATT == null) {
                           PLATT = dist.itdalist[i].LATITUDE;
                           PLONG = dist.itdalist[i].LONGITUDE;
                       }


                   }
                   var marker, i;
                   var infowindow = new google.maps.InfoWindow();
                   var iconBase =
                  'http://giribhumi.ap.gov.in/imagesnew/';
                   var icons = {};
                   var parameter = 'PHC';

                   if (parameter == 'HOSPITALS') {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           info: {
                               icon: iconBase + 'maphome.jpg'
                           }
                       };

                   }
                   else if (parameter == 'EDUCATION') {
                       icons = {
                           parking: {
                               icon: iconBase + 'mapeducation.jpg'
                           },
                           library: {
                               icon: iconBase + 'mapeducation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   else if (parameter == 'PHC') {
                       icons = {
                           901: {
                               icon: iconBase + 'A_Agriculture.png'
                           },
                           902: {
                               icon: iconBase + 'A_Bus Stop.png'
                           },
                           903: {
                               icon: iconBase + 'A_Dairy form.png'
                           },
                           904: {
                               icon: iconBase + 'AEducation.png'
                           },
                           905: {
                               icon: iconBase + 'AElectric.png'
                           },
                           906: {
                               icon: iconBase + 'A_Fibernet.png'
                           },
                           907: {
                               icon: iconBase + 'A_ATM Centre.png'
                           },
                           908: {
                               icon: iconBase + 'A_Ration Shop.png'
                           },
                           909: {
                               icon: iconBase + 'A_Plantation.png'
                           },
                           910: {
                               icon: iconBase + 'A_BC Welfare.png'
                           },
                           911: {
                               icon: iconBase + 'A_Ayurveda Centre.png'
                           },
                           912: {
                               icon: iconBase + 'A_AE Irrigation.png'
                           },
                           913: {
                               icon: iconBase + 'A_Children Home.png'
                           },
                           914: {
                               icon: iconBase + 'A_Fire Station.png'
                           },
                           915: {
                               icon: iconBase + 'A_Burial ground.png'
                           },
                           916: {
                               icon: iconBase + 'A_VRO.png'
                           },
                           917: {
                               icon: iconBase + 'A_Bore wells.png'
                           },
                           918: {
                               icon: iconBase + 'A_Serp.png'
                           },
                           919: {
                               icon: iconBase + 'A_Cell Tower.png'
                           },
                           920: {
                               icon: iconBase + 'A_Gopala Mitra Centre.png'
                           },
                           921: {
                               icon: iconBase + 'A_Anganwadi.png'
                           },
                           923: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           924: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           925: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           926: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           927: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           928: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           929: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           930: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           931: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           922: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'maplocation.jpg'
                           }
                       };
                   }
                   else if (parameter == 'All') {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   else {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   for (i = 0; i < locations.length; i++) {

                       marker = new google.maps.Marker({
                           position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                           icon: icons[features[i].type].icon,
                           map: assetmap
                       });


                       google.maps.event.addListener(marker, 'click', (function (marker, i) {
                           return function () {
                               // var currentvillage = locations[i][0];
                               //  clickparmeter = locations[i][0];
                               //  infowindow.setContent(locations[i][0]);
                               //infowindow.open(map, marker);
                               Assetimageview($("#Village").val(), locations[i][8]);
                               //sessionStorage.setItem("lastname", $("#Village").val());
                               //function1($("#Village").val());


                               var orgurl = ("http://giribhumi.ap.gov.in/Imageprofile.aspx?id=1&type=4");
                               var habcode = $("#Village").val();
                               var assetcode = locations[i][7];
                               var subassetcode = locations[i][8];
                               var refid = locations[i][9];
                               var urlBase = 'http://giribhumi.ap.gov.in/Imageprofile.aspx?id=' + habcode + '&assettype=' + assetcode + '&type=' + subassetcode + '&reftype=' + refid + '&d=' + locations[i][0] + '&la=' + locations[i][1] + '&lo=' + locations[i][2];
                               var win = window.open(urlBase, '_blank');

                               // win.token=$("#Village").val();
                               //  win.focus();


                           }
                       })(marker, i));

                       google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                           return function () {
                               var asset = "";
                               var subasset = "";
                               if (locations[i][0] == "914") {
                                   asset = "SHG Building";
                                   subasset = "SHG Building";
                               }
                               else {
                                   asset = locations[i][4];
                                   subasset = locations[i][5];

                               }
                               if (locations[i][0] == "922") {

                                   var contentString = '<h6>Village Profile Asset Details</h6>' +
                               '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                               '<h6>ROAD TYPE: ' + asset + '</h6>' +
                               '<h6>ROAD NAME: ' + subasset + '</h6>' +
                               '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                               }
                               else {
                                   var contentString = '<h6>Village Profile Asset Details</h6>' +
                                                                      '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                                                                      '<h6>ASSET NAME: ' + asset + '</h6>' +
                                                                      '<h6>SUBASSET NAME: ' + subasset + '</h6>' +
                                                                      '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                               }
                               infowindow.setContent(contentString);
                               infowindow.open(assetmap, marker);
                           }
                       })(marker, i));
                       google.maps.event.addListener(marker, 'mouseout', (function (marker, i) {
                           return function () {

                               infowindow.close();
                           }
                       })(marker, i));
                   }


                   var pt = new google.maps.LatLng(PLATT, PLONG);
                   assetmap.setCenter(pt);
                   assetmap.setZoom(18);
                   //villagefencingmap
                   var result = [];
                   var hab = $("#Village").val();
                   $.ajax(
                        {
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            url: '/api/ITDA/Villagefencing',
                            data: "{'ITDA':'" + "" + "','DISTRICT':'" + "" + "', 'MANDAL':'" + "" + "', 'VILLAGE':'" + "" + "', 'HABITATION':'" + hab + "', 'Type':'" + "" + "'}",
                            dataType: "json",
                            success: function (response) {
                                // console.log(JSON.stringify(response));
                                var dist1 = response;
                                if (dist1.Status == "Failure") {

                                }
                                else {
                                    var bounds = new google.maps.LatLngBounds();


                                    result = [];


                                    for (var i = 0; i < dist1.itdalist.length; i++) {

                                        result.push(new google.maps.LatLng(
                                                parseFloat(dist1.itdalist[i].LATITUDE),
                                              parseFloat(dist1.itdalist[i].LONGITUDE)
                                         ));
                                        bounds.extend(result[result.length - 1])
                                        if (PLATT == "") {
                                            PLATT = dist1.itdalist[i].LATITUDE;
                                            PLONG = dist1.itdalist[i].LONGITUDE;
                                        }
                                    }

                                    // Construct the polygon.
                                    landview = new google.maps.Polygon({
                                        paths: result,
                                        strokeColor: '#ADFF2F',
                                        strokeOpacity: 0.8,
                                        strokeWeight: 3,
                                        fillColor: '',
                                        fillOpacity: 0
                                    });
                                    landview.setMap(assetmap);
                                    assetmap.fitBounds(bounds);
                                    //var pt = new google.maps.LatLng(PLATT, PLONG);
                                    //map.setCenter(pt);
                                    //map.setZoom(12);
                                }

                            },
                            error: function (result) {
                                alert("Error");
                            }

                        });
               }
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
    //road
    if ($("#Village").val() != "011463005002") {
        var x = document.getElementById(922).checked;
        if (x == false) {
            var hidField11 = "";
            var hidField21 = "";
            var hidField31 = "";
            var hidField41 = $("#Village").val();
            var hidField51 = "01";
            var hidField61 = "WC921010339";
            $.ajax(
           {
               type: 'POST',
               contentType: 'application/json; charset=utf-8',
               url: '/api/ITDA/Road',
               data: "{'ITDA':'" + hidField11 + "','DISTRICT':'" + hidField21 + "', 'MANDAL':'" + hidField31 + "', 'VILLAGE':'" + hidField51 + "', 'HABITATION':'" + hidField41 + "', 'Type':'" + hidField61 + "'}",
               dataType: "json",
               success: function (response) {
                   console.log(JSON.stringify(response));
                   var distr = response;
                   if (distr.Status == "Failure") {
                   }
                   else {
                       arr = [];
                       var startPt = "";
                       var endPt = "";
                       var P1 = "";
                       var P2 = "";
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (i == 0) {
                               P1 = distr.itdalist[i].REF_ID;
                               break;
                           }
                       }
                       for (var i = 0; i < distr.itdalist.length; i++) {
                           if (P1 == distr.itdalist[i].REF_ID) {
                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }
                           else {
                               var flightPath = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'black',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 6

                               });
                               flightPath.setMap(assetmap);
                               var polyline = new google.maps.Polyline({
                                   path: arr,
                                   geodesic: true,
                                   strokeColor: 'red',
                                   strokeOpacity: 1.0,
                                   strokeWeight: 4,
                               });

                               polyline.setMap(assetmap);
                               P1 = distr.itdalist[i].REF_ID;
                               arr = [];
                               arr.push(new google.maps.LatLng(
                                               parseFloat(distr.itdalist[i].LATITUDE),
                                             parseFloat(distr.itdalist[i].LONGITUDE)
                                        ));
                           }

                           if (i == 0) {
                               startPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                           if (i == (distr.itdalist.length - 1)) {
                               endPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                           }
                       }
                       var flightPath = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'black',
                           strokeOpacity: 1.0,
                           strokeWeight: 6

                       });
                       flightPath.setMap(assetmap);
                       var polyline = new google.maps.Polyline({
                           path: arr,
                           geodesic: true,
                           strokeColor: 'red',
                           strokeOpacity: 1.0,
                           strokeWeight: 4,
                       });

                       polyline.setMap(assetmap);
                   }
               },
               error: function (result) {
                   alert("Error");
               }

           });
        }
    }
}

function counts() {
    var hidField1 = $("#Itda").val();;
    var hidField2 = $("#District").val();
    var hidField3 = $("#Mandal").val();
    var hidField4 = $("#GP").val();
    var hidField5 = $("#Village").val();
    var hidField6 = "MAP HAB COUNTS";

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/api/ITDA/DistrictDropdown',
        data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));


            var Itda = response;
            for (var i = 0; i < Itda.itdalist.length; i++) {
                var opt1 = new Option(Itda.itdalist[i].VILLAGE_HABITATIONS);

                var opt2 = new Option(Itda.itdalist[i].HABITATION_CODE);
                $("#Village").append($("<option>").val(opt2.text).text(opt1.text));
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}
function Villagegismap() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var map = new google.maps.Map(document.getElementById('map'), {
        styles: [
{
    featureType: "all",
    elementType: "labels",
    stylers: [
        { visibility: "off" }
    ]
}
        ],

        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });
    $("#lblprofile").html("Village Profile");

    var village = "";
    var villagecode = "";
    var result = [];
    var hidField1 = $("#Village").val();// "021505015004"
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "SINGLE-ALL ASSETS";
    var PLATT = "";
    var PLONG = "";
    //markers
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Villagewiseallassetslatongs',
       data: "{'HABITATION':'" + hidField1 + "','Dept':'" + hidField2 + "', 'Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           if (dist.Status == "Failure") {
               Refresh();
               alert("No Data Found");
           } else {
               var bounds = new google.maps.LatLngBounds();
               for (var i = 0; i < dist.itdalist.length; i++) {

                   var locations = [];
                   var features = [];
                   for (var i = 0; i < dist.itdalist.length; i++) {



                       var haplocations = [];
                       haplocations.push(dist.itdalist[i].DEPT, dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE, dist.itdalist[i].DEPARTMENT_NAME,
                     dist.itdalist[i].ASSET_NAME, dist.itdalist[i].SUBASSET_NAME, dist.itdalist[i].SUBASSET_CONDITION, dist.itdalist[i].ASSET, dist.itdalist[i].SUB_ASSET, dist.itdalist[i].REF_ID);
                       locations.push(haplocations);
                       features.push({ position: new google.maps.LatLng(dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE), type: dist.itdalist[i].DEPT });


                       if (PLATT == "" || PLATT == null) {
                           PLATT = dist.itdalist[i].LATITUDE;
                           PLONG = dist.itdalist[i].LONGITUDE;
                       }


                   }
                   var marker, i;
                   var infowindow = new google.maps.InfoWindow();
                   var iconBase =
                  'http://giribhumi.ap.gov.in/imagesnew/';
                   var icons = {};
                   var parameter = 'PHC';

                   if (parameter == 'HOSPITALS') {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           info: {
                               icon: iconBase + 'maphome.jpg'
                           }
                       };

                   }
                   else if (parameter == 'EDUCATION') {
                       icons = {
                           parking: {
                               icon: iconBase + 'mapeducation.jpg'
                           },
                           library: {
                               icon: iconBase + 'mapeducation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   else if (parameter == 'PHC') {
                       icons = {
                           901: {
                               icon: iconBase + 'A_Agriculture.png'
                           },
                           902: {
                               icon: iconBase + 'A_Bus Stop.png'
                           },
                           903: {
                               icon: iconBase + 'A_Dairy form.png'
                           },
                           904: {
                               icon: iconBase + 'AEducation.png'
                           },
                           905: {
                               icon: iconBase + 'AElectric.png'
                           },
                           906: {
                               icon: iconBase + 'A_Fibernet.png'
                           },
                           907: {
                               icon: iconBase + 'A_ATM Centre.png'
                           },
                           908: {
                               icon: iconBase + 'A_Ration Shop.png'
                           },
                           909: {
                               icon: iconBase + 'A_Plantation.png'
                           },
                           910: {
                               icon: iconBase + 'A_BC Welfare.png'
                           },
                           911: {
                               icon: iconBase + 'A_Ayurveda Centre.png'
                           },
                           912: {
                               icon: iconBase + 'A_AE Irrigation.png'
                           },
                           913: {
                               icon: iconBase + 'A_Children Home.png'
                           },
                           914: {
                               icon: iconBase + 'A_Fire Station.png'
                           },
                           915: {
                               icon: iconBase + 'A_Burial ground.png'
                           },
                           916: {
                               icon: iconBase + 'A_VRO.png'
                           },
                           917: {
                               icon: iconBase + 'A_Bore wells.png'
                           },
                           918: {
                               icon: iconBase + 'A_Serp.png'
                           },
                           919: {
                               icon: iconBase + 'A_Cell Tower.png'
                           },
                           920: {
                               icon: iconBase + 'A_Gopala Mitra Centre.png'
                           },
                           921: {
                               icon: iconBase + 'A_Anganwadi.png'
                           },
                           923: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           924: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           925: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           926: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           927: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           928: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           929: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           930: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           931: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           932: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           933: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           934: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           935: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },
                           936: {
                               icon: iconBase + 'A_Resourcecentre.png'
                           },

                           922: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'maplocation.jpg'
                           }
                       };
                   }
                   else if (parameter == 'All') {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   else {
                       icons = {
                           parking: {
                               icon: iconBase + 'maphome.jpg'
                           },
                           library: {
                               icon: iconBase + 'maplocation.jpg'
                           },
                           info: {
                               icon: iconBase + 'mapeducation.jpg'
                           }
                       };
                   }
                   for (i = 0; i < locations.length; i++) {

                       marker = new google.maps.Marker({
                           position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                           icon: icons[features[i].type].icon,
                           map: map
                       });


                       google.maps.event.addListener(marker, 'click', (function (marker, i) {
                           return function () {
                               // var currentvillage = locations[i][0];
                               //  clickparmeter = locations[i][0];
                               //  infowindow.setContent(locations[i][0]);
                               //infowindow.open(map, marker);
                               Assetimageview($("#Village").val(), locations[i][8]);
                               //sessionStorage.setItem("lastname", $("#Village").val());
                               //function1($("#Village").val());


                               var orgurl = ("http://giribhumi.ap.gov.in/Imageprofile.aspx?id=1&type=4");
                               var habcode = $("#Village").val();
                               var assetcode = locations[i][7];
                               var subassetcode = locations[i][8];
                               var refid = locations[i][9];
                               var urlBase = 'http://giribhumi.ap.gov.in/Imageprofile.aspx?id=' + habcode + '&assettype=' + assetcode + '&type=' + subassetcode + '&reftype=' + refid + '&d=' + locations[i][0] + '&la=' + locations[i][1] + '&lo=' + locations[i][2];
                               var win = window.open(urlBase, '_blank');

                               // win.token=$("#Village").val();
                               //  win.focus();


                           }
                       })(marker, i));

                       google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                           return function () {
                               var asset = "";
                               var subasset = "";
                               if (locations[i][0] == "914") {
                                   asset = "SHG Building";
                                   subasset = "SHG Building";
                               }
                               else {
                                   asset = locations[i][4];
                                   subasset = locations[i][5];

                               }
                               if (locations[i][0] == "922") {

                                   var contentString = '<h6>Village Profile Asset Details</h6>' +
                               '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                               '<h6>ROAD TYPE: ' + asset + '</h6>' +
                               '<h6>ROAD NAME: ' + subasset + '</h6>' +
                               '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                               }
                               else {
                                   var contentString = '<h6>Village Profile Asset Details</h6>' +
                                                                      '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                                                                      '<h6>ASSET NAME: ' + asset + '</h6>' +
                                                                      '<h6>SUBASSET NAME: ' + subasset + '</h6>' +
                                                                      '<h6>CONDITION: ' + locations[i][6] + '</h6>';
                               }

                               infowindow.setContent(contentString);
                               infowindow.open(map, marker);
                           }
                       })(marker, i));
                       google.maps.event.addListener(marker, 'mouseout', (function (marker, i) {
                           return function () {

                               infowindow.close();
                           }
                       })(marker, i));
                   }


                   var pt = new google.maps.LatLng(PLATT, PLONG);
                   map.setCenter(pt);
                   map.setZoom(18);
                   //villagefencingmap
                   var result = [];
                   var hab = $("#Village").val();
                   $.ajax(
                        {
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            url: '/api/ITDA/Villagefencing',
                            data: "{'ITDA':'" + "" + "','DISTRICT':'" + "" + "', 'MANDAL':'" + "" + "', 'VILLAGE':'" + "" + "', 'HABITATION':'" + hab + "', 'Type':'" + "" + "'}",
                            dataType: "json",
                            success: function (response) {
                                // console.log(JSON.stringify(response));
                                var dist1 = response;
                                if (dist1.Status == "Failure") {

                                }
                                else {
                                    var bounds = new google.maps.LatLngBounds();


                                    result = [];


                                    for (var i = 0; i < dist1.itdalist.length; i++) {

                                        result.push(new google.maps.LatLng(
                                                parseFloat(dist1.itdalist[i].LATITUDE),
                                              parseFloat(dist1.itdalist[i].LONGITUDE)
                                         ));
                                        bounds.extend(result[result.length - 1])
                                        if (PLATT == "") {
                                            PLATT = dist1.itdalist[i].LATITUDE;
                                            PLONG = dist1.itdalist[i].LONGITUDE;
                                        }
                                    }

                                    // Construct the polygon.
                                    landview = new google.maps.Polygon({
                                        paths: result,
                                        strokeColor: '#ADFF2F',
                                        strokeOpacity: 0.8,
                                        strokeWeight: 3,
                                        fillColor: '',
                                        fillOpacity: 0
                                    });
                                    landview.setMap(map);
                                    map.fitBounds(bounds);
                                    //var pt = new google.maps.LatLng(PLATT, PLONG);
                                    //map.setCenter(pt);
                                    //map.setZoom(12);
                                }

                            },
                            error: function (result) {
                                alert("Error");
                            }

                        });
               }
           }
       },
       error: function (result) {
           alert("Error");
       }

   });


    if ($("#Village").val() != "011463005002") {
        //road
        var hidField11 = "";
        var hidField21 = "";
        var hidField31 = "";
        var hidField41 = $("#Village").val();
        var hidField51 = "01";
        var hidField61 = "WC921010339";
        $.ajax(
       {
           type: 'POST',
           contentType: 'application/json; charset=utf-8',
           url: '/api/ITDA/Road',
           data: "{'ITDA':'" + hidField11 + "','DISTRICT':'" + hidField21 + "', 'MANDAL':'" + hidField31 + "', 'VILLAGE':'" + hidField51 + "', 'HABITATION':'" + hidField41 + "', 'Type':'" + hidField61 + "'}",
           dataType: "json",
           success: function (response) {
               console.log(JSON.stringify(response));
               var distr = response;
               if (distr.Status == "Failure") {
               }
               else {
                   arr = [];
                   var startPt = "";
                   var endPt = "";
                   var P1 = "";
                   var P2 = "";
                   for (var i = 0; i < distr.itdalist.length; i++) {
                       if (i == 0) {
                           P1 = distr.itdalist[i].REF_ID;
                           break;
                       }
                   }
                   for (var i = 0; i < distr.itdalist.length; i++) {
                       if (P1 == distr.itdalist[i].REF_ID) {
                           P2 = distr.itdalist[i].ROAD_TYPE;
                           arr.push(new google.maps.LatLng(
                                           parseFloat(distr.itdalist[i].LATITUDE),
                                         parseFloat(distr.itdalist[i].LONGITUDE)
                                    ));
                       }
                       else {
                           var flightPath = new google.maps.Polyline({
                               path: arr,
                               geodesic: true,
                               strokeColor: 'black',
                               strokeOpacity: 1.0,
                               strokeWeight: 6

                           });
                           flightPath.setMap(map);
                      
                           var polyline = new google.maps.Polyline({
                               path: arr,
                               geodesic: true,
                               strokeColor: 'red',
                               strokeOpacity: 1.0,
                               strokeWeight: 4,
                           });

                           polyline.setMap(map);
                           P1 = distr.itdalist[i].REF_ID;
                           P2 = distr.itdalist[i].ROAD_TYPE;
                           arr = [];
                           arr.push(new google.maps.LatLng(
                                           parseFloat(distr.itdalist[i].LATITUDE),
                                         parseFloat(distr.itdalist[i].LONGITUDE)
                                    ));
                       }

                       if (i == 0) {
                           startPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                       }
                       if (i == (distr.itdalist.length - 1)) {
                           endPt = new google.maps.LatLng(distr.itdalist[i].LATITUDE, distr.itdalist[i].LONGITUDE);
                       }
                   }
                   var flightPath = new google.maps.Polyline({
                       path: arr,
                       geodesic: true,
                       strokeColor: 'black',
                       strokeOpacity: 1.0,
                       strokeWeight: 6

                   });
                   flightPath.setMap(map);
                   
                   var polyline = new google.maps.Polyline({
                       path: arr,
                       geodesic: true,
                       strokeColor: 'red',
                       strokeOpacity: 1.0,
                       strokeWeight: 4,
                   });

                   polyline.setMap(map);
               }
           },
           error: function (result) {
               alert("Error");
           }

       });
    }

}

function Assetimageview(habcode, subassetcode) {
    var hidField1 = habcode;//"021505015004";
    var hidField2 = subassetcode;//"ED90402048";

    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/SubAssetsDetails',
       data: "{'HAB':'" + hidField1 + "','SUBASSET':'" + hidField2 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;


       },
       error: function (result) {
           alert("Error");
       }

   });
}
// For District
$(document).ready(function () {

    var hidField1 = "";
    var hidField2 = "";
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "DISTRICT";

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/api/ITDA/DistrictDropdown',
        data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            var Itda = response;
            for (var i = 0; i < Itda.itdalist.length; i++) {
                var opt1 = new Option(Itda.itdalist[i].DISTRICT);
                var opt2 = new Option(Itda.itdalist[i].SPS_DCODE);
                // $("#District").append(opt1);
                // $("#District").append($("<option></option>").attr("value", opt2).text(opt1));

                $("#District").append($("<option>").val(opt2.text).text(opt1.text));
            }
        },
        error: function (result) {
            alert("Error");
        }
    });


    //For ITDA

    $("#District").change(function (e) {

        $('#Itda').find('option').remove();



        var DISTRICT = $("#District").val();

        var hidField1 = "";
        var hidField2 = $("#District").val();
        var hidField3 = "";
        var hidField4 = "";
        var hidField5 = "";
        var hidField6 = "ITDA";

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/api/ITDA/DistrictDropdown',
            data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                var Itda = response;
                $("#Itda").append('<option value="">Select</option>');

                for (var i = 0; i < Itda.itdalist.length; i++) {
                    var opt1 = new Option(Itda.itdalist[i].ITDA);
                    var opt2 = new Option(Itda.itdalist[i].ITDA_CODE);
                    //$("#Itda").append(opt1);
                    $("#Itda").append($("<option>").val(opt2.text).text(opt1.text));
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });


    //For Mandals

    $("#Itda").change(function (e) {

        $('#Mandal').find('option').remove();



        var hidField1 = $("#Itda").val();;
        var hidField2 = $("#District").val();
        var hidField3 = "";
        var hidField4 = "";
        var hidField5 = "";
        var hidField6 = "MANDAL";

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/api/ITDA/DistrictDropdown',
            data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));

                $("#Mandal").append('<option value="">Select</option>');

                var Itda = response;
                for (var i = 0; i < Itda.itdalist.length; i++) {
                    var opt1 = new Option(Itda.itdalist[i].MANDAL);

                    var opt2 = new Option(Itda.itdalist[i].MANDAL_CODE);
                    $("#Mandal").append($("<option>").val(opt2.text).text(opt1.text));
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });


    //For Gp

    $("#Mandal").change(function (e) {

        $('#GP').find('option').remove();



        var hidField1 = $("#Itda").val();;
        var hidField2 = $("#District").val();
        var hidField3 = $("#Mandal").val();
        var hidField4 = "";
        var hidField5 = "";
        var hidField6 = "GP";

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/api/ITDA/DistrictDropdown',
            data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));

                $("#GP").append('<option value="">Select</option>');

                var Itda = response;
                for (var i = 0; i < Itda.itdalist.length; i++) {
                    var opt1 = new Option(Itda.itdalist[i].GRAM_PANCHAYAT);

                    var opt2 = new Option(Itda.itdalist[i].ITDA_GP_CODE);
                    $("#GP").append($("<option>").val(opt2.text).text(opt1.text));
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });

    //For Villages

    $("#GP").change(function (e) {

        $('#Village').find('option').remove();
        var hidField1 = $("#Itda").val();;
        var hidField2 = $("#District").val();
        var hidField3 = $("#Mandal").val();
        var hidField4 = $("#GP").val();;
        var hidField5 = "";
        var hidField6 = "HAB";

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/api/ITDA/DistrictDropdown',
            data: "{'ITDA':'" + hidField1 + "', 'DISTRICT':'" + hidField2 + "','MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));

                $("#Village").append('<option value="">Select</option>');

                var Itda = response;
                for (var i = 0; i < Itda.itdalist.length; i++) {
                    var opt1 = new Option(Itda.itdalist[i].VILLAGE_HABITATIONS);

                    var opt2 = new Option(Itda.itdalist[i].HABITATION_CODE);
                    $("#Village").append($("<option>").val(opt2.text).text(opt1.text));
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });


    //For Villages

    $("#Village").change(function (e) {
        Dashboardcounts();
        Villagegismap();
        InitialAllassets(true);
        //Roadmap();

    });





});


