
var map = null;
var infoWindow = null;
var landview = [];
var clickparmeter = null;
var Isreferesh=null;

function initMap() {
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.ROADMAP  //HYBRID
    });
    Districtgismap();
    Dashboardcounts("", "", "", "", "ALL DISTRICT DATA");
    document.getElementById('nav-home').className += 'show active';
    AssetsDashboardcounts("", "", "", "", "", "ALL DISTRICTS PER","");

 
};

function Referesh() {
Isreferesh="Yes";
    var LAT = '17.998426';
    var LONG = '82.739254';
    var location = new google.maps.LatLng(LAT, LONG);
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: location,
        mapTypeId: google.maps.MapTypeId.ROADMAP  //HYBRID
    });
    Districtgismap();
    Dashboardcounts("", "", "", "", "ALL DISTRICT DATA");
    AssetsDashboardcounts("", "", "", "", "", "ALL DISTRICTS PER","");
 document.getElementById('nav-home1').classList.remove("active");
    document.getElementById('nav-home').className = "active";
};

function Districtgismap() {
    $("#lblprofile").html("District Profile");
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
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;

           var bounds = new google.maps.LatLngBounds();




           for (var i = 0; i < dist.itdalist.length; i++) {

               var x = dist.itdalist[i].SPS_DCODE;
               var hidField1 = "";

               var hidField2 = x;
               var hidField3 = "";
               var hidField4 = "";
               var hidField5 = "";
               var hidField6 = "DISTRICT BOUNDARIES";
               $.ajax(
              {
                  type: 'POST',
                  contentType: 'application/json; charset=utf-8',
                  url: '/api/ITDA/ItdaLatlongslist',
                  data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
                  dataType: "json",
                  success: function (response) {
                      // console.log(JSON.stringify(response));
                      var dist1 = response;

                      var bounds = new google.maps.LatLngBounds();


                      result = [];

                      Districtcode = "";
                      for (var i = 0; i < dist1.itdalist.length; i++) {

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
                          strokeColor: '#007bff',
                          strokeOpacity: 0.8,
                          strokeWeight: 3,
                          fillColor: '',
                          fillOpacity: 0,
                          indexID: Districtcode,
                          indexname: Districtname
                      });
                      landview.setMap(map);


                      google.maps.event.addListener(landview, 'click', function (event) {
                          Itdagismap(this.indexID);
if(Isreferesh=="Yes")
{

 document.getElementById('nav-home').classList.remove("active"); = "in-active";
document.getElementById('nav-home1').className = "active";

}else
{

 //document.getElementById('nav-home').classList.remove('show active');
 //   document.getElementById('nav-home1').className += 'show active';
}

                          AssetsDashboardcounts("", this.indexID, "", "", "", "DISTRICTS PER", "d");
                          Dashboardcounts("", this.indexID, "", "", "DISTRICT DATA");
                         

                   
                      });
                      google.maps.event.addListener(landview, 'mouseover', function (event) {
                          infoWindow.setContent(this.indexname);

                          infoWindow.setPosition(event.latLng);

                          infoWindow.open(map);
                      });
                      landview.addListener('mouseout', function () {
                          infoWindow.close();
                      });

                      map.fitBounds(bounds);
                      var pt = new google.maps.LatLng('17.998426', '82.739254');
                      map.setCenter(pt);
                      map.setZoom(6);
                      infoWindow = new google.maps.InfoWindow;

                  },
                  error: function (result) {
                      alert("Error");
                  }

              });
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function Itdagismap(itdadistrictcode) {
    $("#lblprofile").html("Itda Profile");
    var itda = "";
    var itdacode = "";
    var result = [];
    var hidField1 = "";
    var hidField2 = itdadistrictcode;
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "TOTAL ITDA";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;

           var bounds = new google.maps.LatLngBounds();




           for (var i = 0; i < dist.itdalist.length; i++) {

               var x = dist.itdalist[i].ITDA_CODE;
               var hidField1 = "01";

               var hidField2 = "14";//itdadistrictcode
               var hidField3 = "";
               var hidField4 = "";
               var hidField5 = "";
               var hidField6 = "ITDA BOUNDARIES";
               $.ajax(
              {
                  type: 'POST',
                  contentType: 'application/json; charset=utf-8',
                  url: '/api/ITDA/ItdaLatlongslist',
                  data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
                  dataType: "json",
                  success: function (response) {
                      // console.log(JSON.stringify(response));
                      var dist1 = response;

                      var bounds = new google.maps.LatLngBounds();


                      result = [];

                      itda = "";
                      for (var i = 0; i < dist1.itdalist.length; i++) {

                          result.push(new google.maps.LatLng(
                                  parseFloat(dist1.itdalist[i].LATITUDE),
                                parseFloat(dist1.itdalist[i].LONGITUDE)
                           ));
                          bounds.extend(result[result.length - 1])
                          if (itda == "") {
                              itda = dist1.itdalist[i].ITDA;
                              itdacode = dist1.itdalist[i].ITDA_CODE;
                          }
                          if (PLATT == "") {
                              PLATT = dist1.itdalist[i].LATITUDE;
                              PLONG = dist1.itdalist[i].LONGITUDE;
                          }
                      }

                      // Construct the polygon.
                      landview = new google.maps.Polygon({
                          paths: result,
                          strokeColor: '#28a745',
                          strokeOpacity: 0.8,
                          strokeWeight: 3,
                          fillColor: '#28a745',
                          fillOpacity: 0.2,
                          indexID: itdacode,
                          indexname: itda,
                      });
                      landview.setMap(map);


                      google.maps.event.addListener(landview, 'click', function (event) {
                          var r = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
                          for (var t = 0; t < r.length; t++) {
                              Mandalgismap("14", this.indexID);
                          }
                          Dashboardcounts(this.indexID, "14", "", "", "ITDA DATA");
                          AssetsDashboardcounts(this.indexID, "14", "", "", "", "ITDA PER");
                      });
                      google.maps.event.addListener(landview, 'mouseover', function (event) {
                          infoWindow.setContent(this.indexname);

                          infoWindow.setPosition(event.latLng);

                          infoWindow.open(map);
                      });
                      landview.addListener('mouseout', function () {
                          infoWindow.close();
                      });

                      map.fitBounds(bounds);
                      var pt = new google.maps.LatLng(PLATT, PLONG);
                      map.setCenter(pt);
                      map.setZoom(10);
                      infoWindow = new google.maps.InfoWindow;

                  },
                  error: function (result) {
                      alert("Error");
                  }

              });
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function Mandalgismap(itdadistrictcode, itdaname) {
    $("#lblprofile").html("Mandal Profile");
    var mandal = "";
    var mandalcode = "";
    var result = [];
    var hidField1 = itdaname;
    var hidField2 = itdadistrictcode;
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "TOTAL MANDALS";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;

           var bounds = new google.maps.LatLngBounds();
           for (var i = 0; i < dist.itdalist.length; i++) {
               var x = dist.itdalist[i].MANDAL_CODE;
               var hidField1 = itdaname;
               var hidField2 = itdadistrictcode;
               var hidField3 = x;
               var hidField4 = "";
               var hidField5 = "";
               var hidField6 = "MANDALS BOUNDARIES";
               $.ajax(
              {
                  type: 'POST',
                  contentType: 'application/json; charset=utf-8',
                  url: '/api/ITDA/ItdaLatlongslist',
                  data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
                  dataType: "json",
                  success: function (response) {
                      var dist1 = response;
                      var bounds = new google.maps.LatLngBounds();
                      result = [];
                      mandal = "";
                      for (var i = 0; i < dist1.itdalist.length; i++) {
                          result.push(new google.maps.LatLng(
                                  parseFloat(dist1.itdalist[i].LATITUDE),
                                parseFloat(dist1.itdalist[i].LONGITUDE)
                           ));
                          bounds.extend(result[result.length - 1])
                          if (mandal == "") {
                              mandal = dist1.itdalist[i].MANDAL;
                              mandalcode = dist1.itdalist[i].MANDAL_CODE;
                          }
                          if (PLATT == "") {
                              PLATT = dist1.itdalist[i].LATITUDE;
                              PLONG = dist1.itdalist[i].LONGITUDE;
                          }
                      }
                      landview = new google.maps.Polygon({
                          paths: result,
                          strokeColor: '#FF0000',
                          strokeOpacity: 0.8,
                          strokeWeight: 3,
                          fillColor: '#FF0000',
                          fillOpacity: 0.2,
                          indexitda: itdaname,
                          indexID: mandalcode,
                          indexname: mandal
                      });
                      landview.setMap(map);
                      map.fitBounds(bounds);

                      var pt = new google.maps.LatLng(PLATT, PLONG);
                      map.setCenter(pt);
                      map.setZoom(10);
                      var infowindow = new google.maps.InfoWindow();
                      google.maps.event.addListener(landview, 'click', function (event) {

                          Villagegismap(itdadistrictcode, itdaname, this.indexID);


                          Dashboardcounts(itdaname, itdadistrictcode, this.indexID, "", "MANDAL DATA");
                          AssetsDashboardcounts(itdaname, itdadistrictcode, this.indexID, "", "", "MANDAL PER");
                      });
                      google.maps.event.addListener(landview, 'mouseover', function (event) {
                          var v = (this.indexname);
                          infoWindow.setContent(v);

                          infoWindow.setPosition(event.latLng);

                          infoWindow.open(map);
                      });


                      landview.addListener('mouseout', function () {
                          infoWindow.close();
                      });

                  },
                  error: function (result) {
                      alert("Error");
                  }

              });
           }
       },
       error: function (result) {
           alert("Error");
       }

   });



}

function Villagegismap(itdadistrictcode, itdaname, mandalname) {
    $("#lblprofile").html("Village Profile");

    var village = "";
    var villagecode = "";
    var result = [];
    var hidField1 = itdaname;
    var hidField2 = itdadistrictcode;
    var hidField3 = mandalname;
    var hidField4 = "";
    var hidField5 = "";
    var hidField6 = "TOTAL VILLAGES";
    var PLATT = "";
    var PLONG = "";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;

           var bounds = new google.maps.LatLngBounds();
           for (var i = 0; i < dist.itdalist.length; i++) {

               var locations = [];
               var features = [];
               for (var i = 0; i < dist.itdalist.length; i++) {
                   var haplocations = [];
                   haplocations.push(dist.itdalist[i].VILLAGE, dist.itdalist[i].VILLAGE_LAT, dist.itdalist[i].VILLAGE_LONG, dist.itdalist[i].VILLAGE_CODE);
                   locations.push(haplocations);
                   features.push({ position: new google.maps.LatLng(dist.itdalist[i].VILLAGE_LAT, dist.itdalist[i].VILLAGE_LONG), type: 'parking' });
                   if (PLATT == "") {
                       PLATT = dist.itdalist[i].VILLAGE_LAT;
                       PLONG = dist.itdalist[i].VILLAGE_LONG;
                   }
               }
               var marker, i;
               var infowindow = new google.maps.InfoWindow();
               var iconBase =
              'http://www.giribhumi.ap.gov.in/imagesnew/';
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
                       parking: {
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
                           var currentvillage = locations[i][0]+" " + "Village Profile";
                           $("#lblprofile").html(currentvillage);
                           Dashboardcounts(itdaname, itdadistrictcode, mandalname, locations[i][3], "VILLAGE DATA");
                           AssetsDashboardcounts(itdaname, itdadistrictcode, mandalname, "", locations[i][3], "VILLAGE PER");
                           clickparmeter = locations[i][0];
                           infowindow.setContent(locations[i][0]);
                           infowindow.open(map, marker);
                         

                       }
                   })(marker, i));

                   google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                       return function () {
                          // infowindow.setContent(locations[i][0] + locations[i][3]);
                           //infowindow.open(map, marker);
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
               map.setZoom(12);
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function Villagegismap1(itdaname, mandalname) {
    var map = null;
    var location = null;
    var village = "";
    var result = [];
    var hidField1 = itdaname;
    var hidField2 = mandalname;
    var hidField3 = "";
    var hidField4 = "";
    var hidField5 = "12";
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "', 'MANDAL':'" + hidField2 + "', 'VILLAGE':'" + hidField3 + "', 'Category':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           var LAT = '17.998426';
           var LONG = '82.739254';
           location = new google.maps.LatLng(LAT, LONG);
           map = new google.maps.Map(document.getElementById('map'), {
               zoom: 10,
               center: location,
               mapTypeId: google.maps.MapTypeId.ROADMAP  //HYBRID
           });
           var bounds = new google.maps.LatLngBounds();
           for (var i = 0; i < dist.itdalist.length; i++) {
               var x = dist.itdalist[i].a;
               var hidField1 = itdaname;
               var hidField2 = mandalname;
               var hidField3 = x;
               var hidField4 = "";
               var hidField5 = "5";
               $.ajax(
              {
                  type: 'POST',
                  contentType: 'application/json; charset=utf-8',
                  url: '/api/ITDA/ItdaLatlongslist',
                  data: "{'ITDA':'" + hidField1 + "', 'MANDAL':'" + hidField2 + "', 'VILLAGE':'" + hidField3 + "', 'Category':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                  dataType: "json",
                  success: function (response) {
                      var dist1 = response;
                      var bounds = new google.maps.LatLngBounds();
                      result = [];
                      village = "";
                      for (var i = 0; i < dist1.itdalist.length; i++) {
                          result.push(new google.maps.LatLng(
                                  parseFloat(dist1.itdalist[i].LATTITUDE),
                                parseFloat(dist1.itdalist[i].LONGITUDE)
                           ));
                          bounds.extend(result[result.length - 1])
                          if (village == "") {
                              village = dist1.itdalist[i].VILLAGE;
                          }
                      }
                      landview = new google.maps.Polygon({
                          paths: result,
                          strokeColor: '#FF0000',
                          strokeOpacity: 0.8,
                          strokeWeight: 3,
                          fillColor: '',
                          fillOpacity: 0,
                          indexitda: itdaname,
                          indexmandal: mandalname,
                          indexID: village
                      });
                      landview.setMap(map);
                      map.fitBounds(bounds);
                      var LAT = '17.68118348';
                      var LONG = '82.2389997';
                      var pt = new google.maps.LatLng(LAT, LONG);
                      map.setCenter(pt);
                      map.setZoom(12);
                      var infowindow = new google.maps.InfoWindow();
                      google.maps.event.addListener(landview, 'click', function (event) {
                          var v = (this.indexitda + ' ' + this.indexmandal + ' ' + this.indexID);
                          alert(v);
                      });
                      google.maps.event.addListener(landview, 'mouseover', function (event) {
                          var v = (this.indexID);
                          infoWindow.setContent(v);

                          infoWindow.setPosition(event.latLng);

                          infoWindow.open(map);
                      });


                      landview.addListener('mouseout', function () {
                          infoWindow.close();
                      });

                  },
                  error: function (result) {
                      alert("Error");
                  }

              });
           }
       },
       error: function (result) {
           alert("Error");
       }

   });



}


function Dashboardcounts(Itda, dist, mandal, village, screen) {
    var hidField1 = Itda;
    var hidField2 = dist;
    var hidField3 = mandal;
    if (village == "")
    {
        var hidField4 = village;
        var hidField5 = "";

    }
    else {
        var hidField4 = "";
        var hidField5 = village;
    }
    
    var hidField6 = screen;
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/ItdaLatlongslist',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField4 + "', 'HABITATION':'" + hidField5 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           for (var i = 0; i < dist.itdalist.length; i++) {
               $("#lblTotalGeographicArea").html(dist.itdalist[i].TOTAL_AREA);
               $("#lblTotalwards").html(dist.itdalist[i].NO_OF_WARDS);
               $("#lblTotalMPTCs").html(dist.itdalist[i].NO_OF_MPTC);
               $("#lblTotalVoters").html(dist.itdalist[i].TOTAL_NO_OF_VOTERS);
               $("#lblMaleVoters").html(dist.itdalist[i].TOTAL_MALE_VOTERS);
               $("#lblFemaleVoters").html(dist.itdalist[i].TOTAL_FEMALE_VOTERS);
               $("#lblTotalhouseholds").html(dist.itdalist[i].TOTAL_HOUSEHOLDS);
               $("#lblPopulation").html(dist.itdalist[i].TOTAL_POPULATION);
               $("#lblSTPopulation").html(dist.itdalist[i].TOTAL_ST_POPULATION);
               $("#lblOtherPopulation").html(dist.itdalist[i].OTHER_POPULATION);
               $("#lblVillageOrganisations").html(dist.itdalist[i].NO_OF_VILLAGE_ORGINASATIONS);
               $("#lblSHGGroups").html(dist.itdalist[i].NO_OF_SHG_GROUPS);
               $("#lblPensioners").html(dist.itdalist[i].NO_OF_PENSIONERS);
               $("#lblPanchayatSecretary").html(dist.itdalist[i].GP_SECRETARIAT_NAME);
               $("#lblVillageVoluntreers").html(dist.itdalist[i].NO_OF_VILLAGE_VOLUNTEERS);
               $("#lblAgricultureLandacres").html(dist.itdalist[i].AGRICULTURE_LAND);
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}

function AssetsDashboardcounts(Itda, dist, mandal, dept,village, screen,type) {
    var hidField1 = Itda;
    var hidField2 = dist;
    var hidField3 = mandal;
    var hidField4 = dept;
    var hidField5 = village;
    var hidField6 = screen;
    $.ajax(
   {
       type: 'POST',
       contentType: 'application/json; charset=utf-8',
       url: '/api/ITDA/AsetsDashboardValues',
       data: "{'ITDA':'" + hidField1 + "','DISTRICT':'" + hidField2 + "', 'MANDAL':'" + hidField3 + "', 'VILLAGE':'" + hidField5 + "', 'HABITATION':'" + hidField4 + "', 'Type':'" + hidField6 + "'}",
       dataType: "json",
       success: function (response) {
           //console.log(JSON.stringify(response));
           var dist = response;
           for (var i = 0; i < dist.itdalist.length; i++) {
               var upaset = ""; var downasset = ""; var upassetper = "";
               var downassetper = ""; var upassetvalue = ""; var downassetvalue = "";
               var titileupper = ""; var titiledownper = ""; var upchart = ""; var downchart = "";
               if (type == "")
               {
                   upasset = dist.itdalist[i].DEPTCODE;
                   downasset = dist.itdalist[i].DEPTCODE + "1";
                   upassetper = dist.itdalist[i].UPLOADED + "%";
                   downassetper = dist.itdalist[i].PENDING + "%";
                   upassetvalue = dist.itdalist[i].UPLOADED;
                   downassetvalue = dist.itdalist[i].PENDING;
                   titileupper = "#" + upasset + "l";
                   titiledownper = "#" + downasset + "l";
                   upchart = "." + upasset;
                   downchart = "." + downasset;
               }
               else if (type == "d")
               {
                   upasset = dist.itdalist[i].DEPTCODE;
                   downasset = dist.itdalist[i].DEPTCODE + "1";
                   upassetper = dist.itdalist[i].UPLOADED + "%";
                   downassetper = dist.itdalist[i].PENDING + "%";
                   upassetvalue = dist.itdalist[i].UPLOADED;
                   downassetvalue = dist.itdalist[i].PENDING;
                   titileupper = "#" + upasset +type+ "l";
                   titiledownper = "#" + downasset+type + "l";
                   upchart = "." + upasset+type;
                   downchart = "." + downasset+type;
               }

               $(titileupper).html(upassetper);
               $(titiledownper).html(downassetper);
               var insideuptext = "input." + upasset+type;
               var insidedowntext = "input." + downasset+type;
               $(insideuptext).val(upassetvalue);
               $(insidedowntext).val(downassetvalue);

               $(upchart).knob({
                   readOnly: true,
                   fgColor: "#28a745",
                   bgColor: "#EEEEEE",
                   thickness: 0.2,
                   width: "100",
                   height: "100"
               });
               $(downchart).knob({
                   readOnly: true,
                   fgColor: "#3aa0dc",
                   bgColor: "#EEEEEE",
                   thickness: 0.2,
                   width: "100",
                   height: "100"
               });
           }
       },
       error: function (result) {
           alert("Error");
       }

   });
}










