$(document).ready(function () {
    user = $("#ContentPlaceHolder1_ustart").text();
    /*userprivillages = $("#ContentPlaceHolder1_userprevilages").text();*/
    $("#dt_bplot_tbl").css("display", "none");
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetViewLtr',
        data: "{'type':'Itda','userprevilages':'" + user + "'}",
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
            url: '../Giribhumi/GetViewLtr',
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

        $('#MandalID').empty().append('<option value="">--Select--</option>');
        $('.preloader').show();

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetViewLtr',
            data: JSON.stringify({ type: "Mandal", Itda: Itda, District: Dist }),
            dataType: "json",
            success: function (response) {
                console.log("Mandal Response:", response);

                if (response && response.Data && response.Data.length > 0) {
                    $.each(response.Data, function (i, item) {
                        $("#MandalID").append(
                            $("<option>").val(item.LGD_DISTRICT_CODE).text(item.MANDAL_NAME)
                        );
                    });
                } else {
                    $("#MandalID").append('<option value="">No Mandals Found</option>');
                }

                $('.preloader').hide();
            },
            error: function (xhr, status, error) {
                alert("Error loading Mandals: " + error);
                $('.preloader').hide();
            }
        });
    }

    


    //For Village
    $("#MandalID").change(function () {
        $('.preloader').show();
        $('#VillageID').empty().append('<option value="">--Select--</option>');

        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        var mandal = $("#MandalID option:selected").text();

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetViewLtr',
            data: JSON.stringify({ type: "Village", Itda: Itda, District: Dist, Mandal: mandal }),
            dataType: "json",
            success: function (response) {
                console.log("Village Response:", response);

                if (response && response.Data && response.Data.length > 0) {
                    $.each(response.Data, function (i, item) {
                        $("#VillageID").append(
                            $("<option>").val(item.LGD_VILLAGE_CODE).text(item.VILLAGE_NAME)
                        );
                    });
                } else {
                    $("#VillageID").append('<option value="">No Villages Found</option>');
                }

                $('.preloader').hide();
            },
            error: function (xhr, status, error) {
                alert("Error loading Villages: " + error);
                $('.preloader').hide();
            }
        });
    });


    //$("#MandalID").change(function () {
    //    $('.preloader').show();
    //    $('#VillageID').find('option').remove();
    //    var Itda = $("#ItdaID").val();
    //    var Dist = $("#DistrictID").text();

    //    var select = document.getElementById('MandalID');
    //    var mandal = select.options[select.selectedIndex].text;

    //    $.ajax({
    //        type: 'POST',
    //        contentType: 'application/json; charset=utf-8',
    //        url: '../Giribhumi/GetViewLtr',
    //        data: "{'type':'Village','Itda':'" + Itda + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
    //        dataType: "json",
    //        success: function (response) {
    //            console.log(JSON.stringify(response));
    //            $('#VillageID').empty();
    //            $("#VillageID").append('<option value="">Select</option>');

    //            for (var i = 0; i < response.Data.length; i++) {
    //                var opt1 = new Option(response.Data[i].VILLAGE_NAME);
    //                var opt2 = new Option(response.Data[i].LGD_VILLAGE_CODE);

    //                $("#VillageID").append($("<option>").val(opt2.text).text(opt1.text));

    //            }
    //            $('.preloader').hide();
    //        },
    //        error: function (result) {
    //            alert(dist + "Error");
    //        }
    //    });
    //})

    //For Habitation
    $("#VillageID").change(function () {
        $('.preloader').show();

        var Itda = $("#ItdaID").val();
        var Dist = $("#DistrictID").text();
        var mandal = $("#MandalID option:selected").text();
        var village = $("#VillageID option:selected").text();

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetViewLtr',
            data: JSON.stringify({
                type: "Habitation",
                Itda: Itda,
                District: Dist,
                Mandal: mandal,
                Village: village
            }),
            dataType: "json",
            success: function (response) {
                console.log("Habitation Response:", response);

                $('#HabitationID').empty().append('<option value="">--Select--</option>');

                if (response && response.Data && response.Data.length > 0) {
                    $.each(response.Data, function (i, item) {
                        $("#HabitationID").append(
                            $("<option>").val(item.HABITATION).text(item.HABITATION)
                        );
                    });
                } else {
                    $("#HabitationID").append('<option value="">No Habitations Found</option>');
                }

                $('.preloader').hide();
            },
            error: function (xhr, status, error) {
                alert("Error loading Habitations: " + error);
                $('.preloader').hide();
            }
        });
    });

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
    //        url: '../Giribhumi/GetViewLtr',
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

    $("#HabitationID").change(function (e) {
       /* $("#dt_bplot_tbl").show();*/
        Get_NOTEligible();
    })
    function Get_NOTEligible() {
       
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

        
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetLtrData',
            data: "{'ITDANAME':'" + Itda + "','District':'" + Dist + "','Mandal':'" + Man + "','Village':'" + Vill + "','Habitation':'" + Habi + "'}",
            dataType: "json",

            success: function (response) {
                
                if (response.Status == "1") {
                    $('#dt_bplot_tbl').show();
                    $('#dt_bplot_tbl').dataTable().fnClearTable();
                    $('#dt_bplot_tbl').DataTable({
                        aLengthMenu: [
                            [100, 200, 300, 400, -1],
                            [100, 200, 300, 400, "All"]
                        ],
                        pageLength: 50,
                        destroy: true,
                        stateSave: true,
                        bPagenate: true,
                        footer: true,
                        data: response.Data,
                        columns: response.columns,
                        dom: 'Bfrtip',
                        ordering: false,
                        order: [[3, 'desc']],
                        fixedColumns: true,

                        columns: [

                            {
                                "mData": null,
                                "mRender": function (data, type, row, meta, s) {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }

                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {
                                    if (type === 'display') {
                                        const ltId = s['LTR_ID'];

                                        // Create a hidden form that posts securely
                                        return `
                <form action="../pages/LTR.aspx" method="post" target="_blank">
                    <input type="hidden" name="ltId" value="${ltId}" />
                    <input type="hidden" name="CurrentPage" value="View_LTR.aspx" />
                    <button type="submit" class="btn-link" style="border:none;background:none;color:blue;cursor:pointer;">View</button>
                </form>`;
                                    }
                                    return data;
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['ITDA'];
                                }
                            },

                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DISTRICT'];
                                }
                            },


                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['MANDAL'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['VILLAGE'];
                                }
                            },

                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['STTA'];
                                }
                            },




                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['RS_NO'];
                                }
                            },

                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['EXTENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['LTRP_NO'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DATE_OF_ORDERS'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DISPOSAL_DATE'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['SDC_LEVEL'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['SDC_ORDERS_PASSED'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_IN_FAVOUR_OF_NT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_IN_FAVOUR_OF_T'];
                                }
                            },
                            
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_GOVT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_IN_FAVOUR_OF_NT_EXTENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_IN_FAVOUR_OF_T_EXTENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_IN_FAVOUR_OF_GOVT_EXTENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_T_ORDERS_IMPLEMENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['O_G_ORDERS_IMPLEMENT'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DETAILS_OF_LAND_T_AC_CTS'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DETAILS_OF_T_LAND_HEC_A'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DETAILS_OF_LAND_G_AC_CTS'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['DETAILS_OF_G_LAND_HEC_A'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['LAND_ALREADY_ACQUIRED'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['REMARKS'];
                                }
                            },
                           

                        ]

                    });
                    $('.preloader').hide();
                }
                else {
                    $('dt - button buttons - excel buttons - html5').hide();
                    $('#dt_bplot_tbl').dataTable().fnClearTable();
                    $('#dt_bplot_tbl').hide();
                    $('#dt_bplot_tbl_wrapper').hide();
                    $('#dt_bplot_tbl_filter').hide();

                    $('.preloader').hide();
                    alert('No Data Found');
                }
            },
            error: function (result) {
                alert(result);
            }
        });

    }

});




