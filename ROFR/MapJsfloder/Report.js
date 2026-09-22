// For District
$(document).ready(function () {
    $("#div2").hide();
    $("#div3").hide();
    $("#div4").hide();
    $("#mytable1").hide();
    $("#mytable2").hide();
    $("#mytable3").hide();
    $("#mytable4").hide();
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

        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();
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

        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();
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

        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();
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

        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();
        $('#Village').find('option').remove();
        var hidField1 = $("#Itda").val();
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
        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();
       
        $('#mytable1').find('td').remove();
       
       e.preventDefault();
        if ($("#District").val() === "") {
            alert("Please select District");
        }
        else if ($("#Itda").val() === "") {
            alert("Please select Itda");
        }
        else if ($("#Mandal").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#GP").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#Village").val() === "") {
            alert("Please select Village");
        }
        else {
            $("#div1").show();
            $("#mytable1").show();
            jQuery.support.cors = true;
            var hidField2 = "";
            var hidField3 = "";
            var hidField4 = "";
            var hidField1 = $("#Village").val();
            var hidField5 = "WEB-DEPT";
            var hidField6 = "";
           

            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                url: '/api/ITDA/GisReport',
                data: "{'HABITATION':'" + hidField1 + "', 'Dept':'" + hidField6 + "','Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                dataType: "json",
                success: function (response) {
                    console.log(JSON.stringify(response));
                    var Itda = response;
                    var trHTML = '';
                   
                    if (Itda.Status == "Success") {
                        $.each(Itda.itdalist, function (i, item) {

                            if (Itda.itdalist[i].DEPARTMENT_NAME == null) {
                                //$("a[name='lnkViews']").contents().unwrap();
                                Itda.itdalist[i].DEPARTMENT_NAME = "";
                            }
                            //trHTML += '<tr><td>' + (i + 1) + '</td><td> <a id="at1" href="VillageGisDashboardReport.aspx?Dept=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td>' + Itda.itdalist[i].ASSETS_CNT + '</td><td>' + Itda.itdalist[i].SUBASSET_CNT + '</td><td>' + Itda.itdalist[i].YES_CNT + '</td><td>' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                            trHTML += '<tr><td align="center">' + Itda.itdalist[i].SNO + '</td><td style="color:red"> <a  name="lnkViews" href="VillageGisDashboardReport.aspx?Dep=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td align="center">' + Itda.itdalist[i].ASSETS_CNT + '</td><td align="center">' + Itda.itdalist[i].SUBASSET_CNT + '</td><td align="center">' + Itda.itdalist[i].YES_CNT + '</td><td align="center">' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                        });

                        $('#mytable1').append(trHTML);
                    }
                    else {
                        alert("No Data Available");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }

    });

    $(document).on("click", "a[name='lnkViews']", function (e) {
        //alert("Calling function");
        $("#back1").hide();
        $("#back3").hide();
        $("#back2").show();
        $("#div1").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
       
        $("#mytable3").hide();
        $("#mytable4").hide();
       
            e.preventDefault();
            $('#mytable2').find('td').remove();
            if ($("#District").val() === "") {
                alert("Please select District");
            }
            else if ($("#Itda").val() === "") {
                alert("Please select Itda");
            }
            else if ($("#Mandal").val() === "") {
                alert("Please select GramPanchayat");
            }
            else if ($("#GP").val() === "") {
                alert("Please select GramPanchayat");
            }
            else if ($("#Village").val() === "") {
                alert("Please select Village");
            }
            else {
                $("#div2").show();
                $("#mytable2").show();
                jQuery.support.cors = true;
                var href = $(this).attr('href');
                var hidField2 = "";
                var hidField3 = "";
                var hidField4 = "";
                var hidField1 = $("#Village").val();
                var hidField5 = "WEB-ASSET";
                var hidField6 = getParameterByName("Dep",href);
                sessionStorage.setItem("Deptcode", hidField6);

                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    url: '/api/ITDA/GisReport',
                    data: "{'HABITATION':'" + hidField1 + "', 'Dept':'" + hidField6 + "','Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                    dataType: "json",
                    success: function (response) {
                        console.log(JSON.stringify(response));
                        var Itda = response;
                        var trHTML = '';
                        if (Itda.Status == "Success") {
                            $.each(Itda.itdalist, function (i, item) {
                                if (Itda.itdalist[i].ASSET_NAME == null) {
                                    Itda.itdalist[i].ASSET_NAME = "";

                                }

                                //trHTML += '<tr><td>' + (i + 1) + '</td><td> <a id="at1" href="VillageGisDashboardReport.aspx?Dept=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td>' + Itda.itdalist[i].ASSETS_CNT + '</td><td>' + Itda.itdalist[i].SUBASSET_CNT + '</td><td>' + Itda.itdalist[i].YES_CNT + '</td><td>' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                                trHTML += '<tr><td align="center">' + Itda.itdalist[i].SNO + '</td><td> <a  name="lnkView1" href="VillageGisDashboardReport.aspx?Acode=' + Itda.itdalist[i].ASSET_CODE + '&Dcode=' + hidField6 + '">' + Itda.itdalist[i].ASSET_NAME + '</a></td><td align="center">' + Itda.itdalist[i].SUBASSET_CNT + '</td><td align="center">' + Itda.itdalist[i].YES_CNT + '</td><td align="center">' + Itda.itdalist[i].NO_CNT + '</td></tr>';

                            });

                            $('#mytable2').append(trHTML);
                        }
                        else {
                            alert("No Data Available");
                        }
                    //    //$('#mytable2 tr:last').find("a[name='lnkView1']").contents().unwrap();
                    //    //alert($('#mytable2  tr:last td:eq(0)').html().find(null).remove());
                    //    alert($('#mytable2  tr:last td:eq(1)').html());
                    //   // $('#mytable2  tr:last td:eq(1)').html().find("a[name='lnkView1']").contents().unwrap();
                    },
                    error: function (result) {
                        alert("No Data Available");
                    }
                });
            

            }

      
    });

    $(document).on("click", "a[name='lnkView1']", function (e) {
        //alert("Calling function1");

        $("#back1").hide();
        $("#back2").hide();
        $("#back3").show();
        $("#div1").hide();
        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();
        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();

        e.preventDefault();
        $('#mytable2').find('td').remove();
        if ($("#District").val() === "") {
            alert("Please select District");
        }
        else if ($("#Itda").val() === "") {
            alert("Please select Itda");
        }
        else if ($("#Mandal").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#GP").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#Village").val() === "") {
            alert("Please select Village");
        }
        else {
            $('#mytable3').find('td').remove();
            $('#mytable4').find('td').remove();
            jQuery.support.cors = true;
            var href = $(this).attr('href');
            var hidField2 = "";
            var hidField3 = getParameterByName("Acode", href);
            //var hidField4 = "AP90201032";
            var hidField1 = $("#Village").val();
            //var hidField1 = "021505015004";
            var hidField5 = "WEB-SUBASSET";
            var hidField6 = getParameterByName("Dcode", href);

            if (hidField6 != "922" && hidField3 != "92201")
            {

                $("#div3").show();
               
               
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    url: '/api/ITDA/SubAssets',
                    data: "{'HAB':'" + hidField1 + "', 'DEPARTMENT':'" + hidField6 + "','ASSET':'" + hidField3 + "', 'SUBASSET':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                   
                    dataType: "json",
                    success: function (response) {
                        console.log(JSON.stringify(response));
                        var Itda = response;
                        if (Itda.status == "1") {

                            $("#mytable3").show();
                            var trHTML = '';
                            for (var i = 0; i < Itda.msg_cat.length; i++) {

 if (Itda.msg_cat[i].SUBASSET_NAME != "") {
                                //trHTML += '<tr><td>' + (i + 1) + '</td><td>' + Itda.msg_cat[i].SUBASSET_NAME + '</td><td>' + Itda.msg_cat[i].SUBASSET_CONDITION + '</td><td><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG1 + '" /></a></td><td><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG2 + '" /></a></td><td><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG3 + '" /></a></td></tr>';

                                trHTML += '<tr><td align="center">' + (i + 1) + '</td><td>' + Itda.msg_cat[i].SUBASSET_NAME + '</td><td align="center">' + Itda.msg_cat[i].SUBASSET_CONDITION + '</td><td align="center"><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG1 + '" /></a></td><td align="center"><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG2 + '" /></a></td><td align="center"><a ><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].SUB_ASSET_IMG3 + '" /></a></td></tr>';
                            }
}

                            $('#mytable3').append(trHTML);

                        }
                        else if(Itda.status == "0")
                        {
                            alert("No Data Available");

                        }
                       else {
                            alert("Network Error");
                        }
                    },
                    error: function (result) {
                        alert("No Data Available");
                    }
                });
            }
            else
            {
                $("#div4").show();
               
              
                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    url: '/api/ITDA/RoadSubAssets',
                    data: "{'HAB':'" + hidField1 + "', 'DEPARTMENT':'" + hidField6 + "','ASSET':'" + hidField3 + "', 'SUBASSET':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",

                    dataType: "json",
                    success: function (response) {
                        console.log(JSON.stringify(response));
                        var Itda = response;
                        if (Itda.status == "1") {
                            $("#mytable4").show();
                            var trHTML = '';

                            for (var i = 0; i < Itda.msg_cat.length; i++) {

                                trHTML += '<tr><td align="center">' + (i + 1) + '</td><td>' + Itda.msg_cat[i].DEPARTMENT + '</td><td align="center">' + Itda.msg_cat[i].NO_OF_BENFICIARIES + '</td><td align="center">' + Itda.msg_cat[i].ROAD_NAME + '</td><td align="center">' + Itda.msg_cat[i].ROAD_CATEGORY + '</td><td  align="center"><a><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_START_IMAGE + '" /></a></td><td align="center"><a><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_END_IMAGE + '" /></a></td><td align="center">' + Itda.msg_cat[i].ROAD_START_LAT_LONG + '</td><td align="center">' + Itda.msg_cat[i].ROAD_END_LAT_LONG + '</td><td align="center">' + Itda.msg_cat[i].ROAD_LENGTH_MTS + '</td><td align="center">' + Itda.msg_cat[i].ROAD_WIDTH_MTS + '</td><td align="center"><a href=""><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_WIDTH_IMAGE + '" /></a></td><td align="center">' + Itda.msg_cat[i].ROAD_WIDTH_LATLONGS + '</td><td align="center">' + Itda.msg_cat[i].ROAD_CONNECTING_TO + '</td><td align="center">' + Itda.msg_cat[i].ROAD_CONNECTION_NAME + '</td><td align="center">' + Itda.msg_cat[i].ROAD_CONDITION + '</td><td align="center">' + Itda.msg_cat[i].ROAD_TYPE + '</td><td align="center">' + Itda.msg_cat[i].ROAD_TRANSPORT_TYPE + '</td></tr>';

                            }
                            $('#mytable4').append(trHTML);
                            //$.each(Itda.msg_cat, function (i, item) {

                            //trHTML += '<tr><td>' + (i + 1) + '</td><td>' + Itda.msg_cat[i].DEPARTMENT + '</td><td>' + Itda.msg_cat[i].NO_OF_BENFICIARIES + '</td><td>' + Itda.msg_cat[i].ROAD_NAME + '</td><td>' + Itda.msg_cat[i].ROAD_CATEGORY + '</td><td><a href=""><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_START_IMAGE + '" /></a></td><td><a href=""><img height="50" src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_END_IMAGE + '" /></a></td><td>' + Itda.msg_cat[i].ROAD_START_LAT_LONG + '</td><td>' + Itda.msg_cat[i].ROAD_END_LAT_LONG + '</td><td>' + Itda.msg_cat[i].ROAD_LENGTH_MTS + '</td><td>' + Itda.msg_cat[i].ROAD_WIDTH_MTS + '</td><td><a href=""><img src="data:image/jpeg;base64,' + Itda.msg_cat[i].ROAD_WIDTH_IMAGE + '" /></a></td><td>' + Itda.msg_cat[i].ROAD_WIDTH_LATLONGS + '</td><td>' + Itda.msg_cat[i].ROAD_CONNECTING_TO + '</td><td>' + Itda.msg_cat[i].ROAD_CONNECTION_NAME + '</td><td>' + Itda.msg_cat[i].ROAD_CONDITION + '</td><td>' + Itda.msg_cat[i].ROAD_TYPE + '</td><td>' + Itda.msg_cat[i].ROAD_TRANSPORT_TYPE + '</td></tr>';


                            //});

                            //$('#mytable4').append(trHTML);
                        }
                        else if(Itda.status=="0")
                        {
                            alert("No Data Available");
                        }
                        else
                        {
                            alert("Network Error");
                        }

                    },
                    error: function (result) {
                        alert("No Data Available");
                    }
                });
            }

        }


    });
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
  
    $(document).on("click", "a[name='lback2']", function (e) {
        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#back1").show();
        $("#back2").hide();
        $("#back3").hide();

        $("#mytable2").hide();
        $("#mytable3").hide();
        $("#mytable4").hide();

        $('#mytable1').find('td').remove();

        e.preventDefault();
        if ($("#District").val() === "") {
            alert("Please select District");
        }
        else if ($("#Itda").val() === "") {
            alert("Please select Itda");
        }
        else if ($("#Mandal").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#GP").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#Village").val() === "") {
            alert("Please select Village");
        }
        else {
            $("#div1").show();
            $("#mytable1").show();
            jQuery.support.cors = true;
            var hidField2 = "";
            var hidField3 = "";
            var hidField4 = "";
            var hidField1 = $("#Village").val();
            var hidField5 = "WEB-DEPT";
            var hidField6 = "";


            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                url: '/api/ITDA/GisReport',
                data: "{'HABITATION':'" + hidField1 + "', 'Dept':'" + hidField6 + "','Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                dataType: "json",
                success: function (response) {
                    console.log(JSON.stringify(response));
                    var Itda = response;
                    var trHTML = '';
                    $.each(Itda.itdalist, function (i, item) {
                        if (Itda.itdalist[i].DEPARTMENT_NAME == null)
                        {
                            Itda.itdalist[i].DEPARTMENT_NAME = "";
                        }
                        //trHTML += '<tr><td>' + (i + 1) + '</td><td> <a id="at1" href="VillageGisDashboardReport.aspx?Dept=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td>' + Itda.itdalist[i].ASSETS_CNT + '</td><td>' + Itda.itdalist[i].SUBASSET_CNT + '</td><td>' + Itda.itdalist[i].YES_CNT + '</td><td>' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                        trHTML += '<tr><td align="center">' + Itda.itdalist[i].SNO + '</td><td style="color:red"> <a  name="lnkViews" href="VillageGisDashboardReport.aspx?Dep=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td align="center">' + Itda.itdalist[i].ASSETS_CNT + '</td><td align="center">' + Itda.itdalist[i].SUBASSET_CNT + '</td><td align="center">' + Itda.itdalist[i].YES_CNT + '</td><td align="center">' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                    });

                    $('#mytable1').append(trHTML);

                },
                error: function (result) {
                    alert("Error");
                }
            });
        }


    });

    $(document).on("click", "a[name='lback3']", function (e) {
        //alert("Calling function");
        $("#back1").hide();
        $("#back3").hide();
        $("#back2").show();
        $("#div1").hide();
        $("#div3").hide();
        $("#div4").hide();
        $("#mytable1").hide();

        $("#mytable3").hide();
        $("#mytable4").hide();

        e.preventDefault();
        $('#mytable2').find('td').remove();
        if ($("#District").val() === "") {
            alert("Please select District");
        }
        else if ($("#Itda").val() === "") {
            alert("Please select Itda");
        }
        else if ($("#Mandal").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#GP").val() === "") {
            alert("Please select GramPanchayat");
        }
        else if ($("#Village").val() === "") {
            alert("Please select Village");
        }
        else {
            $("#div2").show();
            $("#mytable2").show();
            jQuery.support.cors = true;
            var href = $(this).attr('href');
            var hidField2 = "";
            var hidField3 = "";
            var hidField4 = "";
            var hidField1 = $("#Village").val();
            var hidField5 = "WEB-ASSET";
            //var hidField6 = getParameterByName("Dep", href);
            var hidField6 =sessionStorage.getItem("Deptcode");

            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                url: '/api/ITDA/GisReport',
                data: "{'HABITATION':'" + hidField1 + "', 'Dept':'" + hidField6 + "','Asset':'" + hidField3 + "', 'SubAsset':'" + hidField4 + "', 'Type':'" + hidField5 + "'}",
                dataType: "json",
                success: function (response) {
                    console.log(JSON.stringify(response));
                    var Itda = response;
                    var trHTML = '';
                    $.each(Itda.itdalist, function (i, item) {
                        if (Itda.itdalist[i].ASSET_NAME == null) {
                            Itda.itdalist[i].ASSET_NAME = "";
                        }
                        //trHTML += '<tr><td>' + (i + 1) + '</td><td> <a id="at1" href="VillageGisDashboardReport.aspx?Dept=' + Itda.itdalist[i].DEPT_CODE + '">' + Itda.itdalist[i].DEPARTMENT_NAME + '</a></td><td>' + Itda.itdalist[i].ASSETS_CNT + '</td><td>' + Itda.itdalist[i].SUBASSET_CNT + '</td><td>' + Itda.itdalist[i].YES_CNT + '</td><td>' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                        trHTML += '<tr><td align="center">' + Itda.itdalist[i].SNO + '</td><td> <a  name="lnkView1" href="VillageGisDashboardReport.aspx?Acode=' + Itda.itdalist[i].ASSET_CODE + '&Dcode=' + hidField6 + '">' + Itda.itdalist[i].ASSET_NAME + '</a></td><td align="center">' + Itda.itdalist[i].SUBASSET_CNT + '</td><td align="center">' + Itda.itdalist[i].YES_CNT + '</td><td align="center">' + Itda.itdalist[i].NO_CNT + '</td></tr>';
                    });

                    $('#mytable2').append(trHTML);

                },
                error: function (result) {
                    alert("Error");
                }
            });


        }


    });
});
