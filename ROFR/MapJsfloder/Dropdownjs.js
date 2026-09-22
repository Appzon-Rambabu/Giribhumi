
var map = null;
var infoWindow = null;
var arr = new Array();
var polygons = [];
var subdivision1 = [];
var dist1 = [];
var hidField = null;
var clickparmeter = null;


var globalVariable1;
var local;
function function1(d)
{
  globalVariable1=d;
  function2();
}

function function2()
{
  local = globalVariable1;
}

function initMap() {
    Refresh();

   

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
   var  map = new google.maps.Map(document.getElementById('map'), {
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
           if (dist.Status == "Failure")
           {
               Refresh();
           } else
    {
           var bounds = new google.maps.LatLngBounds();
    for (var i = 0; i < dist.itdalist.length; i++) {

        var locations = [];
        var features = [];
        for (var i = 0; i < dist.itdalist.length; i++) {
            var haplocations = [];
            haplocations.push(dist.itdalist[i].DEPT, dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE, dist.itdalist[i].DEPARTMENT_NAME,
          dist.itdalist[i].ASSET_NAME, dist.itdalist[i].SUBASSET_NAME, dist.itdalist[i].SUBASSET_CONDITION, dist.itdalist[i].ASSET, dist.itdalist[i].SUB_ASSET);
            locations.push(haplocations);
            features.push({ position: new google.maps.LatLng(dist.itdalist[i].LATITUDE, dist.itdalist[i].LONGITUDE), type: dist.itdalist[i].DEPT });
            if (PLATT == "") {
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
                907: {
                    icon: iconBase + 'A_ATM Centre.png'
                },
                908: {
                    icon: iconBase + 'A_Ration Shop.png'
                },
                911: {
                    icon: iconBase + 'A_Ayurveda Centre.png'
                },
                914: {
                    icon: iconBase + 'A_Fire Station.png'
                },
                915: {
                    icon: iconBase + 'A_Burial ground.png'
                },
                917: {
                    icon: iconBase + 'A_Bore wells.png'
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
                    //   var url = ("http://giribhumi.ap.gov.in/Imageprofile.aspx");
       // var win = window.open(url, '_blank');
// win.token=$("#Village").val();
      //  win.focus();
       

                }
            })(marker, i));

            google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                return function () {
                   var contentString = '<h6>Village Profile Asset Details</h6>' +
                        '<h6>DEPT: ' + locations[i][3] + '</h6>' +
                        '<h6>ASSET NAME: ' + locations[i][4] + '</h6>' +
                        '<h6>SUBASSET NAME: ' + locations[i][5] + '</h6>' +
                        '<h6>CONDITION: '  + locations[i][6] + '</h6>';
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
        map.setZoom(10);
    }
}
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function Assetimageview(habcode,subassetcode) {
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

        Villagegismap();

    });





});


