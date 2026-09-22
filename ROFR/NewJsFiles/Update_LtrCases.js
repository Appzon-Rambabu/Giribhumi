$(document).ready(function () {
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    /* document.getElementById("#Update_LtrCasesId").style.display === "none";*/
    document.getElementById('Update_LtrCasesId').style.display = 'none';
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Get_Update_LtrCases',
        data: "{'type':'Itda','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            var Itda = response;
            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA_NAME);
                var opt2 = new Option(Itda.Data[i].ITDA_NAME);

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
        var Itda = $("#ItdaID").val();
        /*$('#DistrictID').find('option').remove();*/
        $('.preloader').show();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Get_Update_LtrCases',
            data: "{'type':'District','Itda':'" + Itda + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#DistrictID').empty();
                /* $("#village").append('<option value="">Select</option>');*/

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DISTRICT);
                    var opt2 = new Option(response.Data[i].DISTRICT_CODE);

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
       
        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        $('#MandalID').find('option').remove();
        $('.preloader').show();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Get_Update_LtrCases',
            data: "{'type':'Mandal','Itda':'" + Itda + "','District':'" + Dist + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#MandalID').empty();
                $("#MandalID").append('<option value="">--Select--</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].MANDAL_NAME);
                    var opt2 = new Option(response.Data[i].LGD_DISTRICT_CODE);

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
        $('.preloader').show();
        $('#VillageID').find('option').remove();
        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        
        var select = document.getElementById('MandalID');
        var mandal = select.options[select.selectedIndex].text;
       
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Get_Update_LtrCases',
            data: "{'type':'Village','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#VillageID').empty();
                $("#VillageID").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].VILLAGE_NAME);
                    var opt2 = new Option(response.Data[i].LGD_VILLAGE_CODE);

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

    $("#VillageID").change(function (e) {
        $('.preloader').show();
        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        var select = document.getElementById('MandalID');
        var mandal = select.options[select.selectedIndex].text;
        var select = document.getElementById('VillageID');
        var village = select.options[select.selectedIndex].text;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Get_Update_LtrCases',
            data: "{'type':'Habitation','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + mandal + "','Village':'" + village + "'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#HabitationID').empty();
                $("#HabitationID").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].HABITATION);
                    var opt2 = new Option(response.Data[i].HABITATION);

                    $("#HabitationID").append($("<option>").val(opt2.text).text(opt1.text));

                }
                $('.preloader').hide();

            },
            error: function (result) {
                alert(dist + "Error");
            }
        });
    });

    $("#HabitationID").change(function (e) {
        $('#Update_LtrCasesId').show();
        UpdateLtrCasesStatus();
    })

   
});

function UpdateLtrCasesStatus() {
    var select = document.getElementById('ItdaID');
    var Itda = select.options[select.selectedIndex].text;
    var select = document.getElementById('DistrictID');
    var Dist = select.options[select.selectedIndex].text;
    var select = document.getElementById('MandalID');
    var Man = select.options[select.selectedIndex].text;
    var select = document.getElementById('VillageID');
    var Vill = select.options[select.selectedIndex].text;
    var select = document.getElementById('HabitationID');
    var Habi = select.options[select.selectedIndex].text;
    
    var screen = 'updateLtrStatus';
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Get_Update_LtrCases_Details',
        data: "{'type':'" + screen + "','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + Man + "','Village':'" + Vill + "','Habitation':'" + Habi + "'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            var rows = "";
            UIDList = response;
            data = response.Data;

            for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td >" + response.Data[i].LTR_ID + "</td><td>" + response.Data[i].RS_NO + "</td><td >" + response.Data[i].EXTENT + "</td><td >" + response.Data[i].LTRP_NO + "</td><td >" + response.Data[i].STATUS + "</td><td >" + response.Data[i].case_status + "</td><td >" + response.Data[i].REFERENCE_NO + "</td></tr>";

            }
            $('#Update_LtrCasesId tbody').empty();
            $(rows).appendTo("#Update_LtrCasesId tbody");

        },
        error: function (result) {
            alert(result);
        }

    });
}