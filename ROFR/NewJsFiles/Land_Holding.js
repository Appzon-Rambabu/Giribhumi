$(document).ready(function () {
    /*userprivillages = $("#ContentPlaceHolder1_userprevilages").text();*/
    /* document.getElementById("#Update_LtrCasesId").style.display === "none";*/
    /* document.getElementById('Update_LtrCasesId').style.display = 'none';*/
    var screen="1"
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/LandHolding',
        data: "{'Type':'" + screen+"'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            var Itda = response;
            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA);
                var opt2 = new Option(Itda.Data[i].ITDA);

                $("#ItdaID").append($('<option>').val(opt2.text).text(opt1.text));

            }
            $('.preloader').hide();
        },
        error: function (result) {
            alert("Error");
        }
    });


    //For district
    $("#ItdaID").change(function () {
        var screen="2"
        var Itda = $("#ItdaID").val();
        /*$('#DistrictID').find('option').remove();*/
        $('.preloader').show();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/LandHolding',
            data: "{'Type':'" + screen +"','Itda':'" + Itda + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#DistrictID').empty();
                /* $("#village").append('<option value="">Select</option>');*/

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DIST_NAME_EN);
                    var opt2 = new Option(response.Data[i].DIST_NAME_EN);

                    $("#DistrictID").append($("<option>").val(opt2.text).text(opt1.text));
                    LoadMandal();

                }

                $('.preloader').hide();
            },
            error: function (result) {
                alert(dist + "Error");
            }
        });


    });

    //For Mandal
    function LoadMandal() {
        var screen="3"
        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        $('#MandalID').find('option').remove();
        $('.preloader').show();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/LandHolding',
            data: "{'Type':'" + screen +"','Itda':'" + Itda + "','District':'" + Dist + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#MandalID').empty();
                $("#MandalID").append('<option value="">--Select--</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].OFFICE_NAME_EN);
                    var opt2 = new Option(response.Data[i].OFFICE_NAME_EN);

                    $("#MandalID").append($("<option>").val(opt2.text).text(opt1.text));

                }

                $('.preloader').hide();
            },
            error: function (result) {
                alert(dist + "Error");
            }
        });
    }


    //For Village

    $("#MandalID").change(function () {
        var screen="4"
        $('.preloader').show();
        $('#VillageID').find('option').remove();
        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        
        var mandal = $('#MandalID :selected').text();
        

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/LandHolding',
            data: "{'Type':'" + screen+"','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#VillageID').empty();
                $("#VillageID").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].SECRETARIAT_NAME);
                    var opt2 = new Option(response.Data[i].SECRETARIAT_NAME);

                    $("#VillageID").append($("<option>").val(opt2.text).text(opt1.text));

                }
                $('.preloader').hide();
            },
            error: function (result) {
                alert(dist + "Error");
            }
        });
    })

    //For Habitation

    //$("#VillageID").change(function (e) {
    //    $('.preloader').show();
    //    var Itda = $("#ItdaID").val();
    //    var Dist = $("#DistrictID").text();
    //    var select = document.getElementById('MandalID');
    //    var mandal = select.options[select.selectedIndex].text;
    //    var select = document.getElementById('VillageID');
    //    var village = select.options[select.selectedIndex].text;
    //    $.ajax({
    //        type: 'POST',
    //        contentType: 'application/json; charset=utf-8',
    //        url: '../Giribhumi/Get_Update_LtrCases',
    //        data: "{'type':'Habitation','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + mandal + "','Village':'" + village + "'}",
    //        dataType: "json",
    //        success: function (response) {
    //            console.log(JSON.stringify(response));
    //            $('#HabitationID').empty();
    //            $("#HabitationID").append('<option value="">Select</option>');

    //            for (var i = 0; i < response.Data.length; i++) {
    //                var opt1 = new Option(response.Data[i].HABITATION);
    //                var opt2 = new Option(response.Data[i].HABITATION);

    //                $("#HabitationID").append($("<option>").val(opt2.text).text(opt1.text));

    //            }
    //            $('.preloader').hide();

    //        },
    //        error: function (result) {
    //            alert(dist + "Error");
    //        }
    //    });
    //});

    //$("#HabitationID").change(function (e) {
    //    $('#Update_LtrCasesId').show();
    //    UpdateLtrCasesStatus();
    //})


});