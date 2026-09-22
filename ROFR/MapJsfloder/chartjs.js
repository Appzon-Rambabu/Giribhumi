var map3 = null;
var infoWindow = null;
var arr = new Array();
var polygons = [];
var subdivision1 = [];
var dist1 = [];
var hidField = null;
var clickparmeter = null;
var id = "";
var reftype = "";

function Refresh() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var map2 = new google.maps.Map(document.getElementById('map1'), {
        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.HYBRID
    });




};
function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    console.log("URL", url);
    console.log("NAME", name);
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function initMap2() {
    document.getElementById("carousel-thumb").style.display = "none";
    document.getElementById("carousel-thumb1").style.display = "none";
    Refresh();
    id = getParameterByName("id")

    var type = getParameterByName("type");
    reftype = getParameterByName("reftype");
    var assettype = getParameterByName("assettype");
    var dept = getParameterByName("d");
    var lat = getParameterByName("la");
    var long = getParameterByName("lo");
    Assetimageview(id, type, reftype);

    Villagegismap(id, assettype, reftype,type);
    Villagegismap1(dept, lat, long, reftype);
    assetextradetails(id, reftype, type, "", "SUBASSET EXTRA DETAILS");
    if (dept == "922") {
        document.getElementById("RoadDetails").style.display = "block";
        document.getElementById("AssetDetails").style.display = "none";
        RoadDetails(id, reftype);
    }
    else {
        document.getElementById("AssetDetails").style.display = "block";
        document.getElementById("RoadDetails").style.display = "none";
    }

};

function Assetimageview(habcode, subassetcode, reftype) {
    var hidField1 = habcode;//"021505015004";
    var hidField2 = subassetcode;//"ED90402048";
    var hidField3 = reftype;//"ED90402048";

    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/SubAssetsDetails',
       data: "{'HAB':'" + hidField1 + "','DEPARTMENT':'" + hidField3 + "','SUBASSET':'" + hidField2 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           if (dist.message != "getSubassetDetails not available") {
               var aimg2 = dist.msg_cat.SUB_ASSET_IMG1;
               var aimg3 = dist.msg_cat.SUB_ASSET_IMG2;
               var aimg4 = dist.msg_cat.SUB_ASSET_IMG3;
               if (aimg2 != "NA" && aimg3 != "NA" && aimg4 != "NA") {
                   var aimg2 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG1;
                   var aimg3 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG2;
                   var aimg4 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG3;
                   document.getElementById("carousel-thumb").style.display = "block";
                   document.getElementById("carousel-thumb1").style.display = "none";
                   // alert(dist.msg_cat.ASSET_NAME);
                   $("#img1").attr('src', aimg2);
                   $("#img4").attr('src', aimg2);
                   document.getElementById("abc1").href = aimg2;

                   // alert(dist.msg_cat.ASSET_NAME);
                   $("#img2").attr('src', aimg3);
                   $("#img5").attr('src', aimg3);
                   document.getElementById("abc2").href = aimg3;

                   // alert(dist.msg_cat.ASSET_NAME);
                   $("#img3").attr('src', aimg4);
                   $("#img6").attr('src', aimg4);
                   document.getElementById("abc3").href = aimg4;
               }
               else if (aimg2 != "NA" && aimg3 == "NA" && aimg4 == "NA") {

                   document.getElementById("carousel-thumb").style.display = "none";
                   document.getElementById("carousel-thumb1").style.display = "block";
                   var aimg2 = 'data:image/png;base64,' + dist.msg_cat.SUB_ASSET_IMG1;
                   $("#img11").attr('src', aimg2);
                   $("#img41").attr('src', aimg2);
                   document.getElementById("abc11").href = aimg2;
               }

               var asset = "";
               var subasset = "";
               if (subassetcode == "MI91403242") {
                   asset = "SHG Building";
                   subasset = "SHG Building";
               }
               else {
                   asset = dist.msg_cat.ASSET_NAME;
                   subasset = dist.msg_cat.SUBASSET_NAME;

               }
               $("#DEP").html(dist.msg_cat.DEPARTMENT);
               $("#ASSET").html(asset);
               $("#SUBASSET").html(subasset);
               $("#Con").html(dist.msg_cat.SUBASSET_CONDITION);
           }
           else {
               alert("Images are not available");
           }

       },
       error: function (result) {
           alert("Error");
       }

   });
}


function Villagegismap(id, assettype, reftype,type) {
    var hidField1 = id;// "021505015004"
    var hidField2 = reftype;
    var hidField3 = assettype;
    var hidField4 = "";
    var hidField5 = "REFID CHECKING";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/AssetFacility',
       data: "{'HABITATION':'" + hidField1 + "','Dept':'" + hidField2 + "', 'Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           // var dist = response;


           var Itda = response;
           if (Itda.Status == "Failure") {

           }
           else {
               if (Itda.itdalist.length > 1) {
                   for (var i = 0; i < Itda.itdalist.length; i++) {
                       var opt1 = new Option(Itda.itdalist[i].SUBASSET_NAME);

                       var opt2 = new Option(Itda.itdalist[i].SUBASSET_CODE);
                       $("#facility").append($("<option>").val(opt2.text).text(opt1.text));
                   }
                   $('#facility').val(type);
               }
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function Villagegismap1(dept, lat, long, reftype) {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    var map = new google.maps.Map(document.getElementById('map1'), {
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

    var PLATT = "";
    var PLONG = "";


    var bounds = new google.maps.LatLngBounds();


    var locations = [];
    var features = [];




    var haplocations = [];
    haplocations.push(dept, lat, long);
    locations.push(haplocations);
    features.push({ position: new google.maps.LatLng(lat, long), type: dept });


    if (PLATT == "" || PLATT == null) {
        PLATT = lat;
        PLONG = long;
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
    }


    var pt = new google.maps.LatLng(PLATT, PLONG);
    map.setCenter(pt);
    if (dept == "922") {
        map.setZoom(12);
    }
    else {
        map.setZoom(18);
    }
    //road
    if (dept == "922") {
        var hidField11 = "";
        var hidField21 = "";
        var hidField31 = "";
        var hidField41 = "";
        var hidField51 = "";
        var hidField61 = reftype;
        $.ajax(
       {
           type: 'POST',
           contentType: 'application/json; charset=utf-8',
           url: '/api/ITDA/imageRoad',
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

}

function RoadDetails(hab, id) {
    var hidField1 = hab;
    var hidField2 = id;
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "ROAD DETAILS";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Roadservice',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField5 + "', 'HABITATION':'" + hidField4 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           console.log(JSON.stringify(response));
           var dist = response;
           if (dist.Status == "Failure") {
           }
           else {
               for (var i = 0; i < dist.itdalist.length; i++) {
                   $("#RN").html(dist.itdalist[i].ROAD_NAME);
                   $("#RC").html(dist.itdalist[i].ROAD_CATEGORY);
                   $("#RL").html(dist.itdalist[i].ROAD_LENGTH_MTS);
                   $("#RT").html(dist.itdalist[i].ROAD_TYPE);

                   $("#RCF").html(dist.itdalist[i].ROAD_CONNECTING_FROM);
                   $("#RCT").html(dist.itdalist[i].ROAD_CONNECTING_TO);
                   $("#RCN").html(dist.itdalist[i].ROAD_CONNECTION_NAME);
                   $("#RCC").html(dist.itdalist[i].ROAD_CONDITION);

                   $("#DEPA").html(dist.itdalist[i].DEPARTMENT);
                   $("#RTT").html(dist.itdalist[i].ROAD_TRANSPORT_TYPE);
               }
           }
       },
       error: function (result) {
           alert("Error");
       }

   });


}


function assetextradetails(Itda, dist, mandal, village, screen) {
    var hidField1 = Itda;
    var hidField2 = dist;
    var hidField3 = mandal;
    var hidField4 = village;
    var hidField5 = "";

    var hidField6 = screen;
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/Subassetextradetails',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           if (dist.Status == "Failure") {
               $('#mytable1').find('td').remove();
               $("#mytable1").hide();
           }
           else {
               $('#mytable1').find('td').remove();
               $("#mytable1").show();
               jQuery.support.cors = true;
               var trHTML = '';

               $.each(dist.itdalist, function (i, item) {

                   trHTML += ' <tbody><tr  WIDTH="100%"><td>' + dist.itdalist[i].NAME + '</td><td   align="right">' + dist.itdalist[i].VALUESS + '</td></tr></tbody>';
               });

               $('#mytable1').append(trHTML);
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

$(document).ready(function () {


    $("#facility").change(function (e) {
        if ($("#facility").val() != "") {
            $('#mytable1').find('td').remove();
            $("#mytable1").hide();
            Assetimageview(id, $("#facility").val(), reftype);
            assetextradetails(id, reftype, $("#facility").val(), "", "SUBASSET EXTRA DETAILS");

        }


    });

});

