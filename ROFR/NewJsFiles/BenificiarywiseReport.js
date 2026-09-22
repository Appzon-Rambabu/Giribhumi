//====================================================
// BENEFICIARYWISE ALL REPORT - BACK NAVIGATION
//====================================================

var currentAllReportLevel = "DISTRICT";

var currentAllReportData = null;
var previousHabitationData = null;



$(document).ready(function () {
    //Div3
    $('.preloader').show();
    $("#ddl_benificiary option[value=0]").prop('selected', true);
   
    $('#dt_dist_benificiary_tbl').dataTable().fnClearTable();
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();

    $('#dt_dist_Phase1_tbl').hide();
    $('#dt_dist_Phase2_tbl').hide();
    $('#dt_dist_PHASESBOTH_tbl').hide();
    $('#dt_mandal_ben_tbl').hide();
    $('#dt_mandal_Ph1_tbl').hide();
    $('#dt_mandal_Ph2_tbl').hide();
    $('#dt_mandal_both_tbl').hide();
    //Phase1 hide here
    $('#dt_dist_Phase1_tbl').hide();
    $('#dt_dist_Phase1_tbl_wrapper').hide();
    $('#dt_dist_Phase1_tbl_filter').hide();
    //Phase2 hide here
    $('#dt_dist_Phase2_tbl').hide();
    $('#dt_dist_Phase2_tbl_wrapper').hide();
    $('#dt_dist_Phase2_tbl_filter').hide();
    //PHASESBOTH hide here
    $('#dt_dist_PHASESBOTH_tbl').hide();
    $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
    $('#dt_dist_PHASESBOTH_tbl_filter').hide();
    //MandalAll hide here
    $('#dt_mandal_ben_tbl').hide();
    $('#dt_mandal_ben_tbl_wrapper').hide();
    $('#dt_mandal_ben_tbl_filter').hide();

    $('#dt_panchayt_ben_tbl').hide();
    $('#dt_panchayt_ben_tbl_wrapper').hide();
    $('#dt_panchayt_ben_tbl_filter').hide();

    //====================================================
    // SHOW REVENUE VILLAGE TABLE
    //====================================================
    $('#dt_revenuevillage_ben_tbl').hide();
    $('#dt_revenuevillage_ben_tbl_wrapper').hide();
    $('#dt_revenuevillage_ben_tbl_filter').hide();

    $('#dt_village_ben_tbl').hide();
    $('#dt_village_ben_tbl_wrapper').hide();
    $('#dt_village_ben_tbl_filter').hide();

    $('#dt_habitation_ben_tbl').hide();
    $('#dt_habitation_ben_tbl_wrapper').hide();
    $('#dt_habitation_ben_tbl_filter').hide();

    //mandal phase2 hide here
    $('#dt_mandal_Ph2_tbl').hide();
    $('#dt_mandal_Ph2_tbl_wrapper').hide();
    $('#dt_mandal_Ph2_tbl_filter').hide();
    //Mandal Phase1 hide here
    $('#dt_mandal_Ph1_tbl').hide();
    $('#dt_mandal_Ph1_tbl_wrapper').hide();
    $('#dt_mandal_Ph1_tbl_filter').hide();
    //mandal both hide here
    $('#dt_mandal_both_tbl').hide();
    $('#dt_mandal_both_tbl_wrapper').hide();
    $('#dt_mandal_both_tbl_filter').hide();
    //Back buttons Hide here
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();


    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();

    //====================================================
// INITIAL LOAD - DISTRICT ALL
//====================================================
$('.preloader').show();

setTimeout(function () {
    Get_DistrictsforALL();
}, 100
);
    

});


$('select[name="dropdown"]').change(function () {

    if ($(this).val() == "0") {
        /* alert("You select Benficiarywise ALL Data");*/
        $('.preloader').show();
        //Get_DistrictsforALL();

        //Phase1 hide here
        $('#dt_dist_Phase1_tbl').hide();
        $('#dt_dist_Phase1_tbl_wrapper').hide();
        $('#dt_dist_Phase1_tbl_filter').hide();
        //Phase2 hide here
        $('#dt_dist_Phase2_tbl').hide();
        $('#dt_dist_Phase2_tbl_wrapper').hide();
        $('#dt_dist_Phase2_tbl_filter').hide();
        //PHASESBOTH hide here
        $('#dt_dist_PHASESBOTH_tbl').hide();
        $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
        $('#dt_dist_PHASESBOTH_tbl_filter').hide();
        //MandalAll hide here
        $('#dt_mandal_ben_tbl').hide();
        $('#dt_mandal_ben_tbl_wrapper').hide();
        $('#dt_mandal_ben_tbl_filter').hide();

        $('#dt_panchayt_ben_tbl').hide();
        $('#dt_panchayt_ben_tbl_wrapper').hide();
        $('#dt_panchayt_ben_tbl_filter').hide();
        //====================================================
        // SHOW REVENUE VILLAGE TABLE
        //====================================================
        $('#dt_revenuevillage_ben_tbl').hide();
        $('#dt_revenuevillage_ben_tbl_wrapper').hide();
        $('#dt_revenuevillage_ben_tbl_filter').hide();

        $('#dt_village_ben_tbl').hide();
        $('#dt_village_ben_tbl_wrapper').hide();
        $('#dt_village_ben_tbl_filter').hide();

        $('#dt_habitation_ben_tbl').hide();
        $('#dt_habitation_ben_tbl_wrapper').hide();
        $('#dt_habitation_ben_tbl_filter').hide();
        //mandal phase2 hide here
        $('#dt_mandal_Ph2_tbl').hide();
        $('#dt_mandal_Ph2_tbl_wrapper').hide();
        $('#dt_mandal_Ph2_tbl_filter').hide();
        //Mandal Phase1 hide here
        $('#dt_mandal_Ph1_tbl').hide();
        $('#dt_mandal_Ph1_tbl_wrapper').hide();
        $('#dt_mandal_Ph1_tbl_filter').hide();
        //mandal both hide here
        $('#dt_mandal_both_tbl').hide();
        $('#dt_mandal_both_tbl_wrapper').hide();
        $('#dt_mandal_both_tbl_filter').hide();

    }
    else if ($(this).val() == "1") {
        /* alert("You select Benficiarywise Phase1 Data");*/
        $('.preloader').show();
        Get_DistrictsforPhase1();
        //All hide here
        $('#dt_dist_benificiary_tbl').hide();
        $('#dt_dist_benificiary_tbl_wrapper').hide();
        $('#dt_dist_benificiary_tbl_filter').hide();
        //Phase2 hide here
        $('#dt_dist_Phase2_tbl').hide();
        $('#dt_dist_Phase2_tbl_wrapper').hide();
        $('#dt_dist_Phase2_tbl_filter').hide();
        //PHASESBOTH hide here
        $('#dt_dist_PHASESBOTH_tbl').hide();
        $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
        $('#dt_dist_PHASESBOTH_tbl_filter').hide();
        //MandalAll hide here
        $('#dt_mandal_ben_tbl').hide();
        $('#dt_mandal_ben_tbl_wrapper').hide();
        $('#dt_mandal_ben_tbl_filter').hide();

        $('#dt_panchayt_ben_tbl').hide();
        $('#dt_panchayt_ben_tbl_wrapper').hide();
        $('#dt_panchayt_ben_tbl_filter').hide();
        //====================================================
        // SHOW REVENUE VILLAGE TABLE
        //====================================================
        $('#dt_revenuevillage_ben_tbl').hide();
        $('#dt_revenuevillage_ben_tbl_wrapper').hide();
        $('#dt_revenuevillage_ben_tbl_filter').hide();

        $('#dt_village_ben_tbl').hide();
        $('#dt_village_ben_tbl_wrapper').hide();
        $('#dt_village_ben_tbl_filter').hide();
        $('#dt_habitation_ben_tbl').hide();
        $('#dt_habitation_ben_tbl_wrapper').hide();
        $('#dt_habitation_ben_tbl_filter').hide();

        //mandal phase2 hide here
        $('#dt_mandal_Ph2_tbl').hide();
        $('#dt_mandal_Ph2_tbl_wrapper').hide();
        $('#dt_mandal_Ph2_tbl_filter').hide();
        //mandal both hide here
        $('#dt_mandal_both_tbl').hide();
        $('#dt_mandal_both_tbl_wrapper').hide();
        $('#dt_mandal_both_tbl_filter').hide();

    }
    else if ($(this).val() == "2") {
        /* alert("You select Benficiarywise Phase2 Data");*/
        $('.preloader').show();
        Get_DistrictsforPhase2();

        //All hide here
        $('#dt_dist_benificiary_tbl').hide();
        $('#dt_dist_benificiary_tbl_wrapper').hide();
        $('#dt_dist_benificiary_tbl_filter').hide();
        //Phase1 Hide here
        $('#dt_dist_Phase1_tbl').hide();
        $('#dt_dist_Phase1_tbl_wrapper').hide();
        $('#dt_dist_Phase1_tbl_filter').hide();
        //PHASESBOTH hide here
        $('#dt_dist_PHASESBOTH_tbl').hide();
        $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
        $('#dt_dist_PHASESBOTH_tbl_filter').hide();
        //MandalAll hide here
        $('#dt_mandal_ben_tbl').hide();
        $('#dt_mandal_ben_tbl_wrapper').hide();
        $('#dt_mandal_ben_tbl_filter').hide();

        $('#dt_panchayt_ben_tbl').hide();
        $('#dt_panchayt_ben_tbl_wrapper').hide();
        $('#dt_panchayt_ben_tbl_filter').hide();
        //====================================================
        // SHOW REVENUE VILLAGE TABLE
        //====================================================
        $('#dt_revenuevillage_ben_tbl').hide();
        $('#dt_revenuevillage_ben_tbl_wrapper').hide();
        $('#dt_revenuevillage_ben_tbl_filter').hide();

        $('#dt_village_ben_tbl').hide();
        $('#dt_village_ben_tbl_wrapper').hide();
        $('#dt_village_ben_tbl_filter').hide();

        $('#dt_habitation_ben_tbl').hide();
        $('#dt_habitation_ben_tbl_wrapper').hide();
        $('#dt_habitation_ben_tbl_filter').hide();
        //mandal phase2 hide here
        $('#dt_mandal_Ph2_tbl').hide();
        $('#dt_mandal_Ph2_tbl_wrapper').hide();
        $('#dt_mandal_Ph2_tbl_filter').hide();
        //mandal both hide here
        $('#dt_mandal_both_tbl').hide();
        $('#dt_mandal_both_tbl_wrapper').hide();
        $('#dt_mandal_both_tbl_filter').hide();
        $('.preloader').hide();
    }
    else if ($(this).val() == "3") {
        /* alert("You select Benficiarywise Phase2 Data");*/
        $('.preloader').show();
        Get_DistrictsforPhasesboth();

        //All hide here
        $('#dt_dist_benificiary_tbl').hide();
        $('#dt_dist_benificiary_tbl_wrapper').hide();
        $('#dt_dist_benificiary_tbl_filter').hide();

        //Phase1 Hide here
        $('#dt_dist_Phase1_tbl').hide();
        $('#dt_dist_Phase1_tbl_wrapper').hide();
        $('#dt_dist_Phase1_tbl_filter').hide();
        //PHASESBOTH hide here
        $('#dt_dist_PHASESBOTH_tbl').hide();
        $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
        $('#dt_dist_PHASESBOTH_tbl_filter').hide();
        //Phase2 hide here
        $('#dt_dist_Phase2_tbl').hide();
        $('#dt_dist_Phase2_tbl_wrapper').hide();
        $('#dt_dist_Phase2_tbl_filter').hide();
        //MandalAll hide here
        $('#dt_mandal_ben_tbl').hide();
        $('#dt_mandal_ben_tbl_wrapper').hide();
        $('#dt_mandal_ben_tbl_filter').hide();

        $('#dt_panchayt_ben_tbl').hide();
        $('#dt_panchayt_ben_tbl_wrapper').hide();
        $('#dt_panchayt_ben_tbl_filter').hide();
        //====================================================
        // SHOW REVENUE VILLAGE TABLE
        //====================================================
        $('#dt_revenuevillage_ben_tbl').hide();
        $('#dt_revenuevillage_ben_tbl_wrapper').hide();
        $('#dt_revenuevillage_ben_tbl_filter').hide();

        $('#dt_village_ben_tbl').hide();
        $('#dt_village_ben_tbl_wrapper').hide();
        $('#dt_village_ben_tbl_filter').hide();
        $('#dt_habitation_ben_tbl').hide();
        $('#dt_habitation_ben_tbl_wrapper').hide();
        $('#dt_habitation_ben_tbl_filter').hide();
        //mandal phase2 hide here
        $('#dt_mandal_Ph2_tbl').hide();
        $('#dt_mandal_Ph2_tbl_wrapper').hide();
        $('#dt_mandal_Ph2_tbl_filter').hide();
        //mandal both hide here
        $('#dt_mandal_both_tbl').hide();
        $('#dt_mandal_both_tbl_wrapper').hide();
        $('#dt_mandal_both_tbl_filter').hide();
        $('.preloader').hide();
    }
})


function Get_DistrictsforALL(val) {
    //====================================================
    // CURRENT LEVEL = DISTRICT
    //====================================================

    currentAllReportLevel = "DISTRICT";

    currentAllReportData = null;
    $('.preloader').show();
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Back Buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'Benificiary','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].NO_OF_FARMERS;
                    Pocol += response.Data[i].NO_OF_PLOTS;
                    Ecol += response.Data[i].TOTAL_EXTENT;
                    var x = Ecol;
                    x = Math.floor(x * 100) / 100;
                }
                res.push({ 'ITDA_NAME': 'TOTAL', 'DISTRICT': ' ', 'NO_OF_FARMERS': Facol, 'NO_OF_PLOTS': Pocol, 'TOTAL_EXTENT': x });

                $('#dt_dist_benificiary_tbl').show();

                $('#dt_dist_benificiary_tbl').dataTable().fnClearTable();
                $('#dt_dist_benificiary_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    order: [[3, 'desc']],
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'District wise Total Beneficiaries & Total Extent ';

                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: 'District wise Total Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'District wise Total Beneficiaries & Total Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise Total Beneficiaries & Total Extent';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise Total Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }

                    ],



                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },

                    ],
                    fixedColumns: true,

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['ITDA_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.DISTRICT == 'TOTAL') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_MandalForAll(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "</a>";
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_PLOTS'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_EXTENT'];
                            }
                        },
                    ],

                    //================================================
                    // CREATED ROW
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {

                        if (
                            String(
                                data.ITDA_NAME || ''
                            ).trim().toUpperCase() === 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css('font-weight', 'bold');

                        }

                    }

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_benificiary_tbl').dataTable().fnClearTable();
                $('#dt_dist_benificiary_tbl').hide();
                $('#dt_dist_benificiary_tbl_wrapper').hide();
                $('#dt_dist_benificiary_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {

            $('.preloader').hide();

            console.log("District ALL AJAX Error:", result);

            alert("Error while loading District data.");
        }
    });


}
function Get_DistrictsforPhase1(val) {
    $('.preloader').show();
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Back Buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'PHASE1','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].NO_OF_FARMERS;
                    Pocol += response.Data[i].NO_OF_PLOTS;
                    Ecol += response.Data[i].TOTAL_EXTENT;
                    var y = Ecol;
                    y = Math.floor(y * 100) / 100;

                }
                res.push({ 'ITDA_NAME': 'TOTAL', 'DISTRICT': ' ', 'NO_OF_FARMERS': Facol, 'NO_OF_PLOTS': Pocol, 'TOTAL_EXTENT': y });
                $('#dt_dist_Phase1_tbl').show();

                $('#dt_dist_Phase1_tbl').dataTable().fnClearTable();
                $('#dt_dist_Phase1_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'District wise PhaseI Beneficiaries & Total Extent ';

                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' District wise PhaseI Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' District wise PhaseI Beneficiaries & Total Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise PhaseI Beneficiaries & Total Extent';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise PhaseI Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }

                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }


                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['ITDA_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.DISTRICT == 'TOTAL') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_MandalForPhase1(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "</a>";
                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_PLOTS'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_Phase1_tbl').dataTable().fnClearTable();
                $('#dt_dist_Phase1_tbl').hide();
                $('#dt_dist_Phase1_tbl_wrapper').hide();
                $('#dt_dist_Phase1_tbl_filter').hide();

                $('.preloader').hide();

                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_DistrictsforPhase2(val) {
    $('.preloader').show();
    $('#dt_mandal_Ph1_tbl').hide();
    $('#dt_mandal_Ph1_tbl_wrapper').hide();
    $('#dt_mandal_Ph1_tbl_filter').hide();

    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Back Buttons
    $('#distbackidForPH2').hide();
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForBoth').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'PHASE2','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME + "'}",
        dataType: "json",
        //headers:
        //{
        //    Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //},
        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].NO_OF_FARMERS;
                    Pocol += response.Data[i].NO_OF_PLOTS;
                    Ecol += response.Data[i].TOTAL_EXTENT;
                    var x = Ecol;
                    x = Math.floor(x * 100) / 100;
                }
                res.push({ 'ITDA_NAME': 'TOTAL', 'DISTRICT': ' ', 'NO_OF_FARMERS': Facol, 'NO_OF_PLOTS': Pocol, 'TOTAL_EXTENT': x });
                $('#dt_dist_Phase2_tbl').show();
                $('#dt_dist_Phase2_tbl').dataTable().fnClearTable();
                $('#dt_dist_Phase2_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'District wise PhaseII Beneficiaries & Total Extent ';

                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' District wise PhaseII Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' District wise PhaseII Beneficiaries & Total Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise PhaseII Beneficiaries & Total Extent';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise PhaseII Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }


                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['ITDA_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.DISTRICT == 'TOTAL') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_MandalForPhase2(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "</a>";
                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_PLOTS'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_Phase2_tbl').dataTable().fnClearTable();
                $('#dt_dist_Phase2_tbl').hide();
                $('#dt_dist_Phase2_tbl_wrapper').hide();
                $('#dt_dist_Phase2_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}
function Get_DistrictsforPhasesboth(val) {
    $('.preloader').show();
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Mandal Phase1 hide here
    $('#dt_mandal_Ph1_tbl').hide();
    $('#dt_mandal_Ph1_tbl_wrapper').hide();
    $('#dt_mandal_Ph1_tbl_filter').hide();
    //Back Buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'PHASESBOTH','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].PHASE_I_BEN_IN_PHASE_II;
                    Pocol += response.Data[i].PHASE_I_EXTENT;
                    Ecol += response.Data[i].PHASE_II_EXTENT;
                    var x = Ecol;
                    x = Math.floor(x * 100) / 100;
                    var y = Pocol;
                    y = Math.floor(y * 100) / 100;
                }
                res.push({ 'ITDA_NAME': 'TOTAL', 'DISTRICT': ' ', 'PHASE_I_BEN_IN_PHASE_II': Facol, 'PHASE_I_EXTENT': y, 'PHASE_II_EXTENT': x });
                $('#dt_dist_PHASESBOTH_tbl').show();
                $('#dt_dist_PHASESBOTH_tbl').dataTable().fnClearTable();
                $('#dt_dist_PHASESBOTH_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'District wise Phase - I Beneficiaries in Phase - II ';

                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' District wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' District wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise Phase - I Beneficiaries in Phase - II';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }


                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['ITDA_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.DISTRICT == 'TOTAL') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_MandalForBoth(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "</a>";
                            }

                        },



                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PHASE_I_BEN_IN_PHASE_II'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PHASE_I_EXTENT'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PHASE_II_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_PHASESBOTH_tbl').dataTable().fnClearTable();
                $('#dt_dist_PHASESBOTH_tbl').hide();
                $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
                $('#dt_dist_PHASESBOTH_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

function Get_MandalForPhase1(data) {
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    $('.preloader').show();
    //All hide here
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();
    //Phase1 hide here
    $('#dt_dist_Phase1_tbl').hide();
    $('#dt_dist_Phase1_tbl_wrapper').hide();
    $('#dt_dist_Phase1_tbl_filter').hide();
    $('#distbackid').hide();
    //Back Buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').show();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();
    //append label 
    $('#itdaval2').text(data.ITDA_NAME);
    $('#distval2').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'Mandalphase1','District':'" + data.DISTRICT + "','Itda':'" + data.ITDA_NAME + "'}",
        dataType: "json",
        //headers:
        //{
        //    Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //},
        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].NO_OF_FARMERS;
                    Pocol += response.Data[i].NO_OF_PLOTS;
                    Ecol += response.Data[i].TOTAL_EXTENT;

                }
                res.push({ 'DISTRICT': ' ', 'MANDAL': 'TOTAL', 'NO_OF_FARMERS': Facol, 'NO_OF_PLOTS': Pocol, 'TOTAL_EXTENT': Ecol });
                $('#dt_mandal_Ph1_tbl').show();

                $('#dt_mandal_Ph1_tbl').dataTable().fnClearTable();
                $('#dt_mandal_Ph1_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase-I Beneficiaries & Extent';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' Mandal wise Phase-I Beneficiaries & Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Mandal wise Phase-I Beneficiaries & Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase-I Beneficiaries & Extent';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Mandal wise Phase-I Beneficiaries & Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }



                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        if (data.MANDAL != 'TOTAL' && data.MANDAL != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.MANDAL != 'TOTAL' && data.MANDAL != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
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

                                return s['NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_PLOTS'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_Ph1_tbl').dataTable().fnClearTable();
                $('#dt_mandal_Ph1_tbl').hide();
                $('#dt_mandal_Ph1_tbl_wrapper').hide();
                $('#dt_mandal_Ph1_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_MandalForPhase2(data) {
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    $('.preloader').show();
    //All hide here
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();
    //Phase1 hide here
    $('#dt_dist_Phase1_tbl').hide();
    $('#dt_dist_Phase1_tbl_wrapper').hide();
    $('#dt_dist_Phase1_tbl_filter').hide();
    //Phase2 hide here
    $('#dt_dist_Phase2_tbl').hide();
    $('#dt_dist_Phase2_tbl_wrapper').hide();
    $('#dt_dist_Phase2_tbl_filter').hide();
    $('#distbackid').hide();
    //Back buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').show();
    $('#distbackidForBoth').hide();
    //append label 
    $('#itdaval3').text(data.ITDA_NAME);
    $('#distval3').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'Mandalphase2','District':'" + data.DISTRICT + "','Itda':'" + data.ITDA_NAME + "'}",
        dataType: "json",
        //headers:
        //{
        //    Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //},
        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].NO_OF_FARMERS;
                    Pocol += response.Data[i].NO_OF_PLOTS;
                    Ecol += response.Data[i].TOTAL_EXTENT;
                    var x = Ecol;
                    x = Math.floor(x * 100) / 100;
                }
                res.push({ 'DISTRICT': ' ', 'MANDAL': 'TOTAL', 'NO_OF_FARMERS': Facol, 'NO_OF_PLOTS': Pocol, 'TOTAL_EXTENT': x });

                $('#dt_mandal_Ph2_tbl').show();

                $('#dt_mandal_Ph2_tbl').dataTable().fnClearTable();
                $('#dt_mandal_Ph2_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase-II Beneficiaries & Extent';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' Mandal wise Phase-II Beneficiaries & Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Mandal wise Phase-II Beneficiaries & Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase-II Beneficiaries & Extent';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Mandal wise Phase-II Beneficiaries & Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        if (data.MANDAL != 'TOTAL' && data.MANDAL != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.MANDAL != 'TOTAL' && data.MANDAL != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
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

                                return s['NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_PLOTS'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_Ph2_tbl').dataTable().fnClearTable();
                $('#dt_mandal_Ph2_tbl').hide();
                $('#dt_mandal_Ph2_tbl_wrapper').hide();
                $('#dt_mandal_Ph2_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_MandalForBoth(data) {

    $('.preloader').show();
    //All hide here
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();
    //Phase1 hide here
    $('#dt_dist_Phase1_tbl').hide();
    $('#dt_dist_Phase1_tbl_wrapper').hide();
    $('#dt_dist_Phase1_tbl_filter').hide();
    //Phase2 hide here
    $('#dt_dist_Phase2_tbl').hide();
    $('#dt_dist_Phase2_tbl_wrapper').hide();
    $('#dt_dist_Phase2_tbl_filter').hide();
    //mandal phase2 hide here
    $('#dt_mandal_Ph2_tbl').hide();
    $('#dt_mandal_Ph2_tbl_wrapper').hide();
    $('#dt_mandal_Ph2_tbl_filter').hide();
    //PHASESBOTH hide here
    $('#dt_dist_PHASESBOTH_tbl').hide();
    $('#dt_dist_PHASESBOTH_tbl_wrapper').hide();
    $('#dt_dist_PHASESBOTH_tbl_filter').hide();
    //Back Buttons
    $('#distbackidForAll').hide();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').show();
    //append label 
    $('#itdaval4').text(data.ITDA_NAME);
    $('#distval4').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetBenficiarywise_report',
        data: "{ 'type':'Mandalbothphase','District':'" + data.DISTRICT + "','Itda':'" + data.ITDA_NAME + "'}",
        dataType: "json",
        //headers:
        //{
        //    Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //},
        success: function (response) {

            if (response.Status == "1") {
                //Total adding Here
                var Facol = 0; var Pocol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Facol += response.Data[i].PHASE_I_BEN_IN_PHASE_II;
                    Pocol += response.Data[i].PHASE_I_EXTENT;
                    Ecol += response.Data[i].PHASE_II_EXTENT;
                    var x = Ecol;
                    x = Math.floor(x * 100) / 100;
                    var y = Pocol;
                    y = Math.floor(y * 100) / 100;
                }
                res.push({ 'DISTRICT': 'TOTAL', 'MANDAL': '', 'PHASE_I_BEN_IN_PHASE_II': Facol, 'PHASE_I_EXTENT': y, 'PHASE_II_EXTENT': x });


                $('#dt_mandal_both_tbl').show();
                $('#dt_mandal_both_tbl').dataTable().fnClearTable();
                $('#dt_mandal_both_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: res,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase - I Beneficiaries in Phase - II';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' Mandal wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Mandal wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Phase - I Beneficiaries in Phase - II';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Mandal wise Phase - I Beneficiaries in Phase - II',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }

                    ],
                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        if (data.DISTRICT != 'TOTAL' && data.DISTRICT != 'Total') {
                        //            count++;
                        //            return count;
                        //        }
                        //        else {
                        //            return null;

                        //        }

                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.DISTRICT != 'TOTAL' && data.DISTRICT != 'Total') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
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

                                return s['PHASE_I_BEN_IN_PHASE_II'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PHASE_I_EXTENT'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PHASE_II_EXTENT'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_both_tbl').dataTable().fnClearTable();
                $('#dt_mandal_both_tbl').hide();
                $('#dt_mandal_both_tbl_wrapper').hide();
                $('#dt_mandal_both_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}


function Get_MandalForAll(data) {

    //====================================================
    // CURRENT LEVEL = MANDAL
    //====================================================

    currentAllReportLevel = "MANDAL";

    currentAllReportData = data;

    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("District clicked:", data);

    $('.preloader').show();

    //====================================================
    // Selected ITDA and District
    //====================================================
    var ITDA = data.ITDA_NAME || '';
    var District = data.DISTRICT || '';

    console.log("ITDA:", ITDA);
    console.log("District:", District);

    //====================================================
    // Hide District Table
    //====================================================
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();

    //====================================================
    // Hide Panchayat Table
    //====================================================
    $('#dt_panchayt_ben_tbl').hide();
    $('#dt_panchayt_ben_tbl_wrapper').hide();
    $('#dt_panchayt_ben_tbl_filter').hide();

    //====================================================
    // Back Buttons
    //====================================================
    $('#distbackidForAll').show();
    $('#distbackidForPH1').hide();
    $('#distbackidForPH2').hide();
    $('#distbackidForBoth').hide();

    //====================================================
    // Heading
    //====================================================
    $('#itdaval1').text(ITDA);
    $('#distval1').text(District);

    var printCounter = 0;

    //====================================================
    // AJAX - Get Mandal Data
    //====================================================
    $.ajax({

        type: 'POST',

        contentType: 'application/json; charset=utf-8',

        url: '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({
            type: 'Mandalben',
            District: District,
            Itda: ITDA
        }),

        dataType: 'json',

        success: function (response) {

            console.log("Mandal Response:", response);

            if (response.Status == "1") {

                var Facol = 0;
                var Pocol = 0;
                var Ecol = 0;

                var res = response.Data || [];

                console.log("Mandal Data:", res);

                //================================================
                // Add ITDA and DISTRICT to every row
                //================================================
                for (var i = 0; i < res.length; i++) {

                    res[i].ITDA_NAME = ITDA;
                    res[i].DISTRICT = District;

                }

                //================================================
                // Calculate Total
                //================================================
                for (var i = 0; i < res.length; i++) {

                    Facol += Number(res[i].NO_OF_FARMERS || 0);
                    Pocol += Number(res[i].NO_OF_PLOTS || 0);
                    Ecol += Number(res[i].TOTAL_EXTENT || 0);

                }

                Ecol = Math.floor(Ecol * 100) / 100;

                //================================================
                // Add Total Row
                //================================================
                res.push({
                    ITDA_NAME: ITDA,
                    DISTRICT: District,
                    MANDAL: 'TOTAL',
                    NO_OF_FARMERS: Facol,
                    NO_OF_PLOTS: Pocol,
                    TOTAL_EXTENT: Ecol
                });

                //================================================
                // Show Mandal Table
                //================================================
                $('#dt_mandal_ben_tbl').show();

                //================================================
                // Destroy Existing DataTable
                //================================================
                if ($.fn.DataTable.isDataTable('#dt_mandal_ben_tbl')) {

                    $('#dt_mandal_ben_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }

                //================================================
                // Create Mandal DataTable
                //================================================
                $('#dt_mandal_ben_tbl').DataTable({

                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    footer: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,

                    //================================================
                    // BUTTONS
                    //================================================
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: 'Mandal wise Total Beneficiaries & Total Extent',
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: 'Mandal wise Total Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },

                        {
                            extend: 'csvHtml5',
                            title: 'Mandal wise Total Beneficiaries & Total Extent',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },

                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: 'Mandal wise Total Beneficiaries & Total Extent',
                            messageBottom: null
                        },

                        {
                            extend: 'pdfHtml5',
                            title: 'Mandal wise Total Beneficiaries & Total Extent',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4'
                        }

                    ],


                    'columnDefs': [
                        {
                            "targets": [1, 1],
                            "className": "text-left"

                        },

                    ],
                    fixedColumns: true,

                    //================================================
                    // COLUMNS
                    //================================================
                    columns: [

                        //================================================
                        // 1. S.NO
                        //================================================
                        {
                            mData: null,

                            mRender: function (data, type, row, meta) {

                                if (
                                    row.MANDAL != 'TOTAL' &&
                                    row.MANDAL != 'Total'
                                ) {

                                    return meta.row +
                                        meta.settings._iDisplayStart +
                                        1;

                                }

                                return null;
                            }
                        },

                        ////================================================
                        //// 2. DISTRICT
                        ////================================================
                        //{
                        //    mData: null,

                        //    mRender: function (data, type, row) {

                        //        return row.DISTRICT || District;

                        //    }
                        //},

                        //================================================
                        // 3. MANDAL - CLICKABLE
                        //================================================
                        {
                            mData: null,

                            mRender: function (data, type, row) {

                                // TOTAL ROW - NOT CLICKABLE
                                if (
                                    row.MANDAL == 'TOTAL' ||
                                    row.MANDAL == 'Total' ||
                                    !row.MANDAL
                                ) {

                                    return row.MANDAL || '';

                                }

                                // NORMAL MANDAL - CLICK TO PANCHAYAT
                                return "<a href='#' " +
                                    "onclick='return Get_PanchayatForAll(" +
                                    JSON.stringify(row) +
                                    ");' " +
                                    "style='text-decoration:underline;" +
                                    "color:black;" +
                                    "cursor:pointer;'>" +
                                    row.MANDAL +
                                    "</a>";
                            }
                        },

                        //================================================
                        // 4. TOTAL FARMERS
                        //================================================
                        {
                            mData: null,

                            mRender: function (data, type, row) {

                                return row.NO_OF_FARMERS || 0;

                            }
                        },

                        //================================================
                        // 5. TOTAL PLOTS
                        //================================================
                        {
                            mData: null,

                            mRender: function (data, type, row) {

                                return row.NO_OF_PLOTS || 0;

                            }
                        },

                        //================================================
                        // 6. TOTAL EXTENT
                        //================================================
                        {
                            mData: null,

                            mRender: function (data, type, row) {

                                return row.TOTAL_EXTENT || 0;

                            }
                        }

                    ],


                    //================================================
                    // CREATED ROW
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {

                        if (
                            String(
                                data.MANDAL || ''
                            ).trim().toUpperCase() === 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css('font-weight', 'bold');

                        }

                    }

                });

                //================================================
                // Hide Loader
                //================================================
                $('.preloader').hide();

            }
            else {

                $('#dt_mandal_ben_tbl').hide();
                $('#dt_mandal_ben_tbl_wrapper').hide();
                $('#dt_mandal_ben_tbl_filter').hide();

                $('.preloader').hide();

                alert('No Data Found');
            }
        },

        //================================================
        // AJAX ERROR
        //================================================
        error: function (xhr, status, error) {

            $('.preloader').hide();

            console.log("Mandal AJAX Error:", xhr);
            console.log("Mandal AJAX Status:", status);
            console.log("Mandal AJAX Error:", error);

            alert('Error while loading Mandal data');
        }

    });

    return false;
}


function Get_PanchayatForAll(data) {

    //====================================================
    // CURRENT LEVEL = PANCHAYAT
    //====================================================

    currentAllReportLevel = "PANCHAYAT";

    currentAllReportData = data;

    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Mandal clicked - Panchayat data:", data);

    $('.preloader').show();

    // Hide Mandal
    $('#dt_mandal_ben_tbl').hide();
    $('#dt_mandal_ben_tbl_wrapper').hide();
    $('#dt_mandal_ben_tbl_filter').hide();

    // Hide lower tables
    $('#dt_revenuevillage_ben_tbl').hide();
    $('#dt_revenuevillage_ben_tbl_wrapper').hide();
    $('#dt_revenuevillage_ben_tbl_filter').hide();



    // Keep Back button
    $('#distbackidForAll').show();
    //====================================================
    // Get Selected Values
    //====================================================
    var ITDA = data.ITDA_NAME || '';
    var District = data.DISTRICT || '';
    var Mandal = data.MANDAL || '';

    console.log("Panchayat Request Values:", {
        ITDA: ITDA,
        District: District,
        Mandal: Mandal
    });

    //====================================================
    // Validate Required Values
    //====================================================
    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Mandal == 'TOTAL' ||
        Mandal == 'Total'
    ) {

        $('.preloader').hide();

        console.log("Invalid Panchayat Request:", {
            ITDA: ITDA,
            District: District,
            Mandal: Mandal
        });

        return false;
    }

    //====================================================
    // Set Parent Heading
    //====================================================
    $('#itdaval5').text(ITDA);
    $('#distval5').text(District);
    $('#mandalval5').text(Mandal);

    var printCounter = 0;

    //====================================================
    // AJAX - Get Panchayat Data
    //====================================================
    $.ajax({

        type: 'POST',

        contentType: 'application/json; charset=utf-8',

        url: '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({
            type: 'Panchayatben',
            Itda: ITDA,
            District: District,
            Mandal: Mandal
        }),

        dataType: 'json',

        //================================================
        // SUCCESS
        //================================================
        success: function (response) {

            console.log("Panchayat Response:", response);

            //================================================
            // Check Status
            //================================================
            if (response.Status == "1") {

                var Facol = 0;
                var Pocol = 0;
                var Ecol = 0;

                var res = response.Data || [];

                console.log("Panchayat Data Before Total:", res);

                //================================================
                // Check Data
                //================================================
                if (res.length == 0) {

                    $('.preloader').hide();

                    console.log("No Panchayat data found");

                    alert("No Panchayat Data Found");

                    return false;
                }

                //================================================
                // Add Parent Values
                //================================================
                for (var i = 0; i < res.length; i++) {

                    res[i].ITDA_NAME = ITDA;
                    res[i].DISTRICT = District;
                    res[i].MANDAL = Mandal;

                }

                //================================================
                // Calculate Total
                //================================================
                for (var i = 0; i < res.length; i++) {

                    Facol += Number(
                        res[i].NO_OF_FARMERS || 0
                    );

                    Pocol += Number(
                        res[i].NO_OF_PLOTS || 0
                    );

                    Ecol += Number(
                        res[i].TOTAL_EXTENT || 0
                    );

                }

                //================================================
                // Round Total Extent
                //================================================
                Ecol = Math.floor(Ecol * 100) / 100;

                //================================================
                // Add Total Row
                //================================================
                res.push({
                    ITDA_NAME: '',
                    DISTRICT: '',
                    MANDAL: '',
                    Gram_Panchayat: 'TOTAL',
                    NO_OF_FARMERS: Facol,
                    NO_OF_PLOTS: Pocol,
                    TOTAL_EXTENT: Ecol
                });

                console.log("Final Panchayat Data:", res);

                //================================================
                // Destroy Existing DataTable
                //================================================
                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_panchayt_ben_tbl'
                    )
                ) {

                    $('#dt_panchayt_ben_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }

                //================================================
                // SHOW TABLE BEFORE DATATABLE INITIALIZATION
                //================================================
                $('#dt_panchayt_ben_tbl').show();

                //================================================
                // CREATE PANCHAYAT DATATABLE
                //================================================
                $('#dt_panchayt_ben_tbl').DataTable({

                    //================================================
                    // DataTable Settings
                    //================================================
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],

                    pageLength: 50,

                    destroy: true,

                    // IMPORTANT
                    // Disable old saved column state
                    stateSave: false,

                    bPaginate: true,

                    footer: true,

                    //================================================
                    // DATA BINDING
                    //================================================
                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,

                    //================================================
                    // BUTTONS
                    //================================================
                    buttons: [

                        // COPY
                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            messageTop: function () {

                                printCounter++;

                                return 'Panchayat wise Total Beneficiaries & Total Extent';

                            },

                            messageBottom: null
                        },

                        // EXCEL
                        {
                            extend: 'excelHtml5',

                            title:
                                'Panchayat wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            page: 'current',

                            autoFilter: true
                        },

                        // CSV
                        {
                            extend: 'csvHtml5',

                            title:
                                'Panchayat wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },

                        // PRINT
                        {
                            extend: 'print',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>',

                            messageTop: function () {

                                return 'Panchayat wise Total Beneficiaries & Total Extent';

                            },

                            messageBottom: null
                        },

                        // PDF
                        {
                            extend: 'pdfHtml5',

                            title:
                                'Panchayat wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],

                    'columnDefs': [
                        {
                            "targets": [1, 1],
                            "className": "text-left"

                        },

                    ],
                    fixedColumns: true,


                    //================================================
                    // COLUMNS - TOTAL 7 COLUMNS
                    //================================================
                    columns: [

                        // 1. S.NO
                        {
                            mData: null,
                            mRender: function (data, type, row, meta) {

                                if (
                                    row.Gram_Panchayat == 'TOTAL' ||
                                    row.Gram_Panchayat == 'Total' ||
                                    !row.Gram_Panchayat
                                ) {
                                    return '';
                                }

                                return meta.row +
                                    meta.settings._iDisplayStart +
                                    1;
                            }
                        },

                        //// 2. DISTRICT
                        //{
                        //    mData: null,
                        //    mRender: function (data, type, row) {
                        //        return row.DISTRICT || District;
                        //    }
                        //},

                        //// 3. MANDAL
                        //{
                        //    mData: null,
                        //    mRender: function (data, type, row) {
                        //        return row.MANDAL || Mandal;
                        //    }
                        //},

                        // 4. PANCHAYAT - CLICKABLE
                        {
                            mData: null,
                            mRender: function (data, type, row) {

                                if (
                                    row.Gram_Panchayat == 'TOTAL' ||
                                    row.Gram_Panchayat == 'Total' ||
                                    !row.Gram_Panchayat
                                ) {
                                    return row.Gram_Panchayat || '';
                                }

                                return "<a href='#' " +
                                    "onclick='return Get_RevenueVillageForAll(" +
                                    JSON.stringify(row) +
                                    ")' " +
                                    "style='text-decoration:underline;color:black;cursor:pointer;'>" +
                                    row.Gram_Panchayat +
                                    "</a>";
                            }
                        },

                        // 5. TOTAL FARMERS
                        {
                            mData: null,
                            mRender: function (data, type, row) {
                                return row.NO_OF_FARMERS || 0;
                            }
                        },

                        // 6. TOTAL PLOTS
                        {
                            mData: null,
                            mRender: function (data, type, row) {
                                return row.NO_OF_PLOTS || 0;
                            }
                        },

                        // 7. TOTAL EXTENT
                        {
                            mData: null,
                            mRender: function (data, type, row) {
                                return row.TOTAL_EXTENT || 0;
                            }
                        }


                    ],

                    //================================================
                    // CREATED ROW
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {

                        if (
                            String(
                                data.Gram_Panchayat || ''
                            ).trim().toUpperCase() === 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css('font-weight', 'bold');

                        }

                    }

                });

                //================================================
                // SHOW DATATABLE WRAPPER
                //================================================
                $('#dt_panchayt_ben_tbl_wrapper').show();

                $('#dt_panchayt_ben_tbl_filter').show();

                //================================================
                // Hide Loader
                //================================================
                $('.preloader').hide();

                console.log(
                    "PANCHAYAT TABLE DATA BOUND SUCCESSFULLY"
                );

            }

            //================================================
            // STATUS NOT 1
            //================================================
            else {

                $('#dt_panchayt_ben_tbl').hide();

                $('#dt_panchayt_ben_tbl_wrapper').hide();

                $('#dt_panchayt_ben_tbl_filter').hide();

                $('.preloader').hide();

                console.log(
                    "Panchayat Status is not 1:",
                    response
                );

                alert("No Data Found");

            }

        },

        //================================================
        // AJAX ERROR
        //================================================
        error: function (
            xhr,
            status,
            error
        ) {

            $('#dt_panchayt_ben_tbl').hide();

            $('#dt_panchayt_ben_tbl_wrapper').hide();

            $('#dt_panchayt_ben_tbl_filter').hide();

            $('.preloader').hide();

            console.log(
                "Panchayat AJAX Error:",
                xhr
            );

            console.log(
                "Panchayat AJAX Status:",
                status
            );

            console.log(
                "Panchayat AJAX Error:",
                error
            );

            alert(
                "Error while loading Panchayat data"
            );

        }

    });

    return false;
}

function Get_RevenueVillageForAll(data) {

    console.log("====================================");
    console.log("PANCHAYAT CLICKED - REVENUE VILLAGE");
    console.log("====================================");


    //====================================================
    // IF JSON STRING COMES, CONVERT TO OBJECT
    //====================================================

    if (typeof data === "string") {
        data = JSON.parse(data);
    }
    //====================================================
    // CURRENT LEVEL = REVENUE VILLAGE
    //====================================================

    currentAllReportLevel = "REVENUE_VILLAGE";

    currentAllReportData = data;

    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Panchayat clicked - Revenue Village data:", data);

    $('.preloader').show();


    //====================================================
    // HIDE PANCHAYAT TABLE
    //====================================================

    $('#dt_panchayt_ben_tbl').hide();
    $('#dt_panchayt_ben_tbl_wrapper').hide();
    $('#dt_panchayt_ben_tbl_filter').hide();


    //====================================================
    // HIDE VILLAGE TABLE
    //====================================================

    $('#dt_village_ben_tbl').hide();
    $('#dt_village_ben_tbl_wrapper').hide();
    $('#dt_village_ben_tbl_filter').hide();


    //====================================================
    // GET SELECTED VALUES
    //====================================================

    var ITDA = data.ITDA_NAME || '';
    var District = data.DISTRICT || '';
    var Mandal = data.MANDAL || '';
    var Panchayat = data.Gram_Panchayat || '';


    console.log("Revenue Village Request Values:", {
        ITDA: ITDA,
        District: District,
        Mandal: Mandal,
        Panchayat: Panchayat
    });


    //====================================================
    // VALIDATE VALUES
    //====================================================

    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Panchayat == '' ||
        Panchayat == 'TOTAL' ||
        Panchayat == 'Total'
    ) {

        $('.preloader').hide();

        console.log("Invalid Revenue Village Request:", {
            ITDA: ITDA,
            District: District,
            Mandal: Mandal,
            Panchayat: Panchayat
        });

        alert("Revenue Village Request Values Missing");

        return false;
    }


    //====================================================
    // SET HEADING
    //====================================================

    $('#itdaval6').text(ITDA);
    $('#distval6').text(District);
    $('#mandalval6').text(Mandal);
    $('#panchayatval6').text(Panchayat);


    //====================================================
    // AJAX REQUEST
    //====================================================

    $.ajax({

        type: 'POST',

        contentType: 'application/json; charset=utf-8',

        url: '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({

            type: 'RevenueVillageben',

            Itda: ITDA,

            District: District,

            Mandal: Mandal,

            Gram_Panchayat: Panchayat

        }),

        dataType: 'json',


        //================================================
        // SUCCESS
        //================================================

        success: function (response) {

            console.log("====================================");
            console.log("REVENUE VILLAGE FULL RESPONSE");
            console.log("====================================");

            console.log("Response:", response);
            console.log("Status:", response.Status);
            console.log("Data:", response.Data);


            if (response.Status == "1") {

                var res = response.Data || [];


                //================================================
                // CHECK DATA
                //================================================

                if (res.length == 0) {

                    $('.preloader').hide();

                    $('#dt_revenuevillage_ben_tbl').hide();
                    $('#dt_revenuevillage_ben_tbl_wrapper').hide();
                    $('#dt_revenuevillage_ben_tbl_filter').hide();

                    alert("No Revenue Village Data Found");

                    return false;
                }


                //================================================
                // ADD PARENT VALUES TO EVERY ROW
                //================================================

                for (var i = 0; i < res.length; i++) {

                    res[i].ITDA_NAME = ITDA;

                    res[i].DISTRICT = District;

                    res[i].MANDAL = Mandal;

                    res[i].Gram_Panchayat = Panchayat;

                }


                //================================================
                // REMOVE EXISTING TOTAL ROW
                //================================================

                res = res.filter(function (row) {

                    return String(
                        row.REVENUE_VILLAGE || ''
                    ).trim().toUpperCase() !== 'TOTAL';

                });


                //================================================
                // CALCULATE TOTAL
                //================================================

                var Facol = 0;
                var Pocol = 0;
                var Ecol = 0;


                for (var i = 0; i < res.length; i++) {

                    Facol += Number(
                        res[i].NO_OF_FARMERS
                    ) || 0;


                    Pocol += Number(
                        res[i].NO_OF_PLOTS
                    ) || 0;


                    Ecol += Number(
                        res[i].TOTAL_EXTENT
                    ) || 0;

                }


                //================================================
                // ROUND TOTAL EXTENT TO 2 DECIMAL PLACES
                //================================================

                Ecol = Math.round(Ecol * 100) / 100;


                //================================================
                // ADD ONE TOTAL ROW AT BOTTOM
                //================================================

                res.push({

                    ITDA_NAME: ITDA,

                    DISTRICT: District,

                    MANDAL: Mandal,

                    Gram_Panchayat: Panchayat,

                    REVENUE_VILLAGE: 'TOTAL',

                    NO_OF_FARMERS: Facol,

                    NO_OF_PLOTS: Pocol,

                    TOTAL_EXTENT: Ecol

                });


                //================================================
                // FINAL DATA CHECK
                //================================================

                console.log("====================================");
                console.log("FINAL REVENUE VILLAGE DATA");
                console.log("====================================");

                console.log("Total Farmers :", Facol);
                console.log("Total Plots   :", Pocol);
                console.log("Total Extent  :", Ecol);
                console.log("Total Rows    :", res.length);
                console.log("Final Data    :", res);


                //================================================
                // DESTROY OLD DATATABLE
                //================================================

                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_revenuevillage_ben_tbl'
                    )
                ) {

                    $('#dt_revenuevillage_ben_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }


                //================================================
                // SHOW REVENUE VILLAGE TABLE
                //================================================

                $('#dt_revenuevillage_ben_tbl').show();


                //================================================
                // DATATABLE
                //================================================

                $('#dt_revenuevillage_ben_tbl').DataTable({

                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    footer: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,


                    //================================================
                    // BUTTONS
                    //================================================

                    buttons: [

                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            title:
                                'Revenue Village wise Total Beneficiaries & Total Extent'
                        },


                        {
                            extend: 'excelHtml5',

                            title:
                                'Revenue Village wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            autoFilter: true
                        },


                        {
                            extend: 'csvHtml5',

                            title:
                                'Revenue Village wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'print',

                            title:
                                'Revenue Village wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'pdfHtml5',

                            title:
                                'Revenue Village wise Total Beneficiaries & Total Extent',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],


                    //================================================
                    // COLUMN DEFINITIONS
                    //================================================

                    columnDefs: [

                        {
                            targets: [1],

                            className: "text-left"
                        }

                    ],


                    fixedColumns: true,


                    //================================================
                    // COLUMNS
                    //================================================

                    columns: [


                        //================================================
                        // 1. S.NO
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row,
                                meta
                            ) {


                                // TOTAL ROW - BLANK S.NO

                                if (
                                    String(
                                        row.REVENUE_VILLAGE || ''
                                    ).trim().toUpperCase() === 'TOTAL'
                                ) {

                                    return '';

                                }


                                return (
                                    meta.row +
                                    meta.settings._iDisplayStart +
                                    1
                                );

                            }
                        },


                        //================================================
                        // 2. REVENUE VILLAGE
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {


                                //================================================
                                // TOTAL ROW
                                //================================================

                                if (
                                    String(
                                        row.REVENUE_VILLAGE || ''
                                    ).trim().toUpperCase() === 'TOTAL'
                                ) {

                                    return 'TOTAL';

                                }


                                //================================================
                                // CLICK REVENUE VILLAGE
                                //================================================

                                return "<a href='#' " +

                                    "onclick='return Get_VillageForAll(" +
                                    JSON.stringify(row) +
                                    ");' " +

                                    "style='text-decoration:underline;color:black;cursor:pointer;'>" +

                                    row.REVENUE_VILLAGE +

                                    "</a>";

                            }

                        },


                        //================================================
                        // 3. TOTAL FARMERS
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.NO_OF_FARMERS || 0;

                            }
                        },


                        //================================================
                        // 4. TOTAL PLOTS
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.NO_OF_PLOTS || 0;

                            }
                        },


                        //================================================
                        // 5. TOTAL EXTENT
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.TOTAL_EXTENT || 0;

                            }
                        }

                    ],


                    //================================================
                    // CREATED ROW
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {


                        //================================================
                        // TOTAL ROW BOLD
                        //================================================

                        if (
                            String(
                                data.REVENUE_VILLAGE || ''
                            ).trim().toUpperCase() === 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css('font-weight', 'bold');

                        }

                    }

                });


                //================================================
                // SHOW DATATABLE WRAPPER
                //================================================

                $('#dt_revenuevillage_ben_tbl_wrapper').show();

                $('#dt_revenuevillage_ben_tbl_filter').show();


                //================================================
                // HIDE LOADER
                //================================================

                $('.preloader').hide();


                console.log(
                    "REVENUE VILLAGE TABLE DATA BOUND SUCCESSFULLY"
                );

            }


            else {

                $('#dt_revenuevillage_ben_tbl').hide();

                $('#dt_revenuevillage_ben_tbl_wrapper').hide();

                $('#dt_revenuevillage_ben_tbl_filter').hide();

                $('.preloader').hide();


                console.log(
                    "Revenue Village Status is not 1:",
                    response
                );


                alert("No Revenue Village Data Found");

            }

        },


        //================================================
        // AJAX ERROR
        //================================================

        error: function (
            xhr,
            status,
            error
        ) {

            $('#dt_revenuevillage_ben_tbl').hide();

            $('#dt_revenuevillage_ben_tbl_wrapper').hide();

            $('#dt_revenuevillage_ben_tbl_filter').hide();

            $('.preloader').hide();


            console.log(
                "Revenue Village AJAX Error:",
                xhr
            );


            console.log(
                "Status:",
                status
            );


            console.log(
                "Error:",
                error
            );


            console.log(
                "Response Text:",
                xhr.responseText
            );


            alert(
                "Error while loading Revenue Village data"
            );

        }

    });


    return false;
}

function Get_VillageForAll(data) {

    console.log("====================================");
    console.log("REVENUE VILLAGE CLICKED - VILLAGE");
    console.log("====================================");


    //====================================================
    // CONVERT STRING TO OBJECT
    //====================================================

    if (typeof data === "string") {

        try {

            data = JSON.parse(data);

        }
        catch (e) {

            console.log("JSON Parse Error:", e);

            alert("Invalid Village Row Data");

            return false;
        }
    }


    //====================================================
    // CHECK ROW DATA
    //====================================================

    console.log("========== CLICK ROW CHECK ==========");

    console.log("FULL DATA:", data);
    console.log("ITDA_NAME:", data.ITDA_NAME);
    console.log("DISTRICT:", data.DISTRICT);
    console.log("MANDAL:", data.MANDAL);
    console.log("Gram_Panchayat:", data.Gram_Panchayat);
    console.log("REVENUE_VILLAGE:", data.REVENUE_VILLAGE);


    //====================================================
    // CURRENT LEVEL = VILLAGE
    //====================================================

    currentAllReportLevel = "VILLAGE";

    currentAllReportData = data;

    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Revenue Village clicked - Village data:", data);

    $('.preloader').show();


    //====================================================
    // HIDE REVENUE VILLAGE TABLE
    //====================================================

    $('#dt_revenuevillage_ben_tbl').hide();
    $('#dt_revenuevillage_ben_tbl_wrapper').hide();
    $('#dt_revenuevillage_ben_tbl_filter').hide();


    //====================================================
    // HIDE VILLAGE TABLE
    //====================================================

    $('#dt_village_ben_tbl').hide();
    $('#dt_village_ben_tbl_wrapper').hide();
    $('#dt_village_ben_tbl_filter').hide();


    //====================================================
    // GET VALUES
    //====================================================

    var ITDA = data.ITDA_NAME || '';

    var District = data.DISTRICT || '';

    var Mandal = data.MANDAL || '';

    var Panchayat = data.Gram_Panchayat || '';

    var RevenueVillage = data.REVENUE_VILLAGE || '';


    //====================================================
    // LOG REQUEST VALUES
    //====================================================

    console.log("====================================");

    console.log(
        "Village Request Values:",
        {
            ITDA: ITDA,
            District: District,
            Mandal: Mandal,
            Panchayat: Panchayat,
            RevenueVillage: RevenueVillage
        }
    );

    console.log("====================================");


    //====================================================
    // VALIDATE
    //====================================================

    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Panchayat == '' ||
        RevenueVillage == '' ||
        RevenueVillage == 'TOTAL' ||
        RevenueVillage == 'Total'
    ) {

        $('.preloader').hide();

        console.log(
            "Invalid Village Request Values:",
            {
                ITDA: ITDA,
                District: District,
                Mandal: Mandal,
                Panchayat: Panchayat,
                RevenueVillage: RevenueVillage
            }
        );

        alert("Village Request Values Missing");

        return false;
    }


    //====================================================
    // SET HEADING
    //====================================================

    $('#itdaval7').text(ITDA);

    $('#distval7').text(District);

    $('#mandalval7').text(Mandal);

    $('#panchayatval7').text(Panchayat);

    $('#revenuevillageval7').text(RevenueVillage);


    //====================================================
    // AJAX REQUEST
    //====================================================

    $.ajax({

        type: 'POST',

        contentType: 'application/json; charset=utf-8',

        url: '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({

            type: 'Villageben',

            Itda: ITDA,

            District: District,

            Mandal: Mandal,

            Gram_Panchayat: Panchayat,

            REVENUE_VILLAGE: RevenueVillage

        }),

        dataType: 'json',


        //================================================
        // SUCCESS
        //================================================

        success: function (response) {

            console.log("====================================");

            console.log("VILLAGE FULL RESPONSE");

            console.log("====================================");

            console.log("FULL RESPONSE:", response);

            console.log("STATUS:", response.Status);

            console.log("DATA:", response.Data);

            console.log(
                "DATA LENGTH:",
                response.Data
                    ? response.Data.length
                    : "NULL"
            );

            console.log("REASON:", response.Reason);


            //================================================
            // CHECK STATUS
            //================================================

            if (response.Status == "1") {

                var res = response.Data || [];


                //================================================
                // CHECK DATA
                //================================================

                if (res.length == 0) {

                    $('.preloader').hide();

                    $('#dt_village_ben_tbl').hide();

                    $('#dt_village_ben_tbl_wrapper').hide();

                    $('#dt_village_ben_tbl_filter').hide();

                    alert("No Village Data Found");

                    return false;
                }


                //================================================
                // ADD PARENT VALUES
                //================================================

                for (var i = 0; i < res.length; i++) {

                    res[i].ITDA_NAME = ITDA;

                    res[i].DISTRICT = District;

                    res[i].MANDAL = Mandal;

                    res[i].Gram_Panchayat = Panchayat;

                    res[i].REVENUE_VILLAGE =
                        RevenueVillage;

                }


                //================================================
                // REMOVE EXISTING TOTAL ROW
                //================================================

                res = res.filter(function (row) {

                    return String(
                        row.Village || ''
                    ).trim().toUpperCase() !== 'TOTAL';

                });


                //================================================
                // CALCULATE TOTAL
                //================================================

                var Facol = 0;

                var Pocol = 0;

                var Ecol = 0;


                for (var i = 0; i < res.length; i++) {

                    Facol += Number(
                        res[i].NO_OF_FARMERS
                    ) || 0;


                    Pocol += Number(
                        res[i].NO_OF_PLOTS
                    ) || 0;


                    Ecol += Number(
                        res[i].TOTAL_EXTENT
                    ) || 0;

                }


                //================================================
                // ROUND EXTENT
                //================================================

                Ecol = Math.round(
                    Ecol * 100
                ) / 100;


                //================================================
                // ADD TOTAL ROW
                //================================================

                res.push({

                    ITDA_NAME: ITDA,

                    DISTRICT: District,

                    MANDAL: Mandal,

                    Gram_Panchayat: Panchayat,

                    REVENUE_VILLAGE: RevenueVillage,

                    Village: 'TOTAL',

                    NO_OF_FARMERS: Facol,

                    NO_OF_PLOTS: Pocol,

                    TOTAL_EXTENT: Ecol

                });


                //================================================
                // FINAL DATA CHECK
                //================================================

                console.log("====================================");

                console.log("FINAL VILLAGE DATA");

                console.log("====================================");

                console.log(
                    "Total Farmers:",
                    Facol
                );

                console.log(
                    "Total Plots:",
                    Pocol
                );

                console.log(
                    "Total Extent:",
                    Ecol
                );

                console.log(
                    "Total Rows:",
                    res.length
                );

                console.log(
                    "Final Data:",
                    res
                );


                //================================================
                // DESTROY OLD DATATABLE
                //================================================

                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_village_ben_tbl'
                    )
                ) {

                    $('#dt_village_ben_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }


                //================================================
                // SHOW VILLAGE TABLE
                //================================================

                $('#dt_village_ben_tbl').show();


                //================================================
                // CREATE VILLAGE DATATABLE
                //================================================

                $('#dt_village_ben_tbl').DataTable({

                    aLengthMenu: [

                        [100, 200, 300, 400, -1],

                        [100, 200, 300, 400, "All"]

                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    footer: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,


                    //================================================
                    // BUTTONS
                    //================================================

                    buttons: [

                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            title:
                                'Village wise Beneficiaries & Extent'
                        },


                        {
                            extend: 'excelHtml5',

                            title:
                                'Village wise Beneficiaries & Extent',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            autoFilter: true
                        },


                        {
                            extend: 'csvHtml5',

                            title:
                                'Village wise Beneficiaries & Extent',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'print',

                            title:
                                'Village wise Beneficiaries & Extent',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'pdfHtml5',

                            title:
                                'Village wise Beneficiaries & Extent',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],


                    //================================================
                    // COLUMN DEFINITIONS
                    //================================================

                    columnDefs: [

                        {
                            targets: [1],

                            className: "text-left"
                        }

                    ],


                    fixedColumns: true,


                    //================================================
                    // COLUMNS
                    //================================================

                    columns: [


                        //================================================
                        // 1. S.NO
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row,
                                meta
                            ) {


                                // TOTAL ROW - BLANK S.NO

                                if (
                                    String(
                                        row.Village || ''
                                    ).trim().toUpperCase()
                                    === 'TOTAL'
                                ) {

                                    return '';

                                }


                                return (
                                    meta.row +
                                    meta.settings._iDisplayStart +
                                    1
                                );

                            }

                        },


                        //================================================
                        // 2. VILLAGE
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {


                                //================================================
                                // TOTAL ROW - NOT CLICKABLE
                                //================================================

                                if (
                                    String(
                                        row.Village || ''
                                    ).trim().toUpperCase()
                                    === 'TOTAL'
                                ) {

                                    return 'TOTAL';

                                }


                                //================================================
                                // VILLAGE CLICK
                                // NEXT LEVEL -> HABITATION
                                //================================================

                                return "<a href='#' " +

                                    "onclick='return Get_HabitationForAll(" +
                                    JSON.stringify(row) +
                                    ");' " +

                                    "style='text-decoration:underline;color:black;cursor:pointer;'>" +

                                    row.Village +

                                    "</a>";

                            }

                        },


                        //================================================
                        // 3. TOTAL FARMERS
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.NO_OF_FARMERS || 0;

                            }

                        },


                        //================================================
                        // 4. TOTAL PLOTS
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.NO_OF_PLOTS || 0;

                            }

                        },


                        //================================================
                        // 5. TOTAL EXTENT
                        //================================================

                        {
                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.TOTAL_EXTENT || 0;

                            }

                        }

                    ],


                    //================================================
                    // CREATED ROW
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {


                        //================================================
                        // TOTAL ROW BOLD
                        //================================================

                        if (
                            String(
                                data.Village || ''
                            ).trim().toUpperCase()
                            === 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css(
                                    'font-weight',
                                    'bold'
                                );

                        }

                    }

                });


                //================================================
                // SHOW WRAPPER
                //================================================

                $('#dt_village_ben_tbl_wrapper').show();

                $('#dt_village_ben_tbl_filter').show();


                //================================================
                // HIDE LOADER
                //================================================

                $('.preloader').hide();


                console.log(
                    "===================================="
                );

                console.log(
                    "VILLAGE TABLE DATA BOUND SUCCESSFULLY"
                );

                console.log(
                    "===================================="
                );

            }


            else {

                $('#dt_village_ben_tbl').hide();

                $('#dt_village_ben_tbl_wrapper').hide();

                $('#dt_village_ben_tbl_filter').hide();

                $('.preloader').hide();


                console.log(
                    "Village Status is not 1:",
                    response
                );


                alert(
                    "No Village Data Found"
                );

            }

        },


        //================================================
        // AJAX ERROR
        //================================================

        error: function (
            xhr,
            status,
            error
        ) {

            $('.preloader').hide();

            $('#dt_village_ben_tbl').hide();

            $('#dt_village_ben_tbl_wrapper').hide();

            $('#dt_village_ben_tbl_filter').hide();


            console.log(
                "===================================="
            );

            console.log(
                "VILLAGE AJAX ERROR"
            );

            console.log(
                "===================================="
            );


            console.log(
                "Status Code:",
                xhr.status
            );

            console.log(
                "Status:",
                status
            );

            console.log(
                "Error:",
                error
            );

            console.log(
                "Response Text:",
                xhr.responseText
            );


            alert(
                "Error while loading Village data"
            );

        }

    });


    return false;
}

function Get_HabitationForAll(data) {

    console.log("====================================");
    console.log("VILLAGE CLICKED - HABITATION");
    console.log("====================================");


    //================================================
    // Convert JSON string to object
    //================================================

    if (typeof data === "string") {

        try {
            data = JSON.parse(data);
        }
        catch (e) {

            console.log("JSON Parse Error:", e);

            alert("Invalid Habitation Row Data");

            return false;
        }
    }

    //====================================================
    // CURRENT LEVEL = HABITATION
    //====================================================

    currentAllReportLevel = "HABITATION";

    currentAllReportData = data;
    previousHabitationData = data;
    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Village clicked - Habitation data:", data);


    $('.preloader').show();


    //================================================
    // Hide Village table
    //================================================

    $('#dt_village_ben_tbl').hide();
    $('#dt_village_ben_tbl_wrapper').hide();
    $('#dt_village_ben_tbl_filter').hide();


    //================================================
    // Hide Habitation table while loading
    //================================================

    $('#dt_habitation_ben_tbl').hide();
    $('#dt_habitation_ben_tbl_wrapper').hide();
    $('#dt_habitation_ben_tbl_filter').hide();


    //================================================
    // Hide Beneficiary table
    //================================================

    $('#dt_beneficiary_details_tbl').hide();
    $('#dt_beneficiary_details_tbl_wrapper').hide();
    $('#dt_beneficiary_details_tbl_filter').hide();


    //================================================
    // Back button
    //================================================

    $('#distbackidForAll').show();


    //================================================
    // Get selected values
    //================================================

    var ITDA =
        data.ITDA_NAME || '';

    var District =
        data.DISTRICT || '';

    var Mandal =
        data.MANDAL || '';

    var Panchayat =
        data.Gram_Panchayat || '';

    var RevenueVillage =
        data.REVENUE_VILLAGE || '';

    var Village =
        data.Village || '';


    console.log(
        "Habitation Request Values:",
        {
            ITDA: ITDA,
            District: District,
            Mandal: Mandal,
            Panchayat: Panchayat,
            RevenueVillage: RevenueVillage,
            Village: Village
        }
    );


    //================================================
    // Validate
    //================================================

    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Panchayat == '' ||
        RevenueVillage == '' ||
        Village == '' ||
        String(Village).trim().toUpperCase() == 'TOTAL'
    ) {

        $('.preloader').hide();

        console.log(
            "Invalid Habitation Request:",
            {
                ITDA: ITDA,
                District: District,
                Mandal: Mandal,
                Panchayat: Panchayat,
                RevenueVillage: RevenueVillage,
                Village: Village
            }
        );

        alert("Habitation Request Values Missing");

        return false;
    }


    //================================================
    // Set heading
    //================================================

    $('#itdaval8').text(ITDA);

    $('#distval8').text(District);

    $('#mandalval8').text(Mandal);

    $('#panchayatval8').text(Panchayat);

    $('#revenuevillageval8').text(RevenueVillage);

    $('#villageval8').text(Village);


    //================================================
    // AJAX - Habitation
    //================================================

    $.ajax({

        type: 'POST',

        contentType:
            'application/json; charset=utf-8',

        url:
            '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({

            type: 'Habitationben',

            Itda: ITDA,

            District: District,

            Mandal: Mandal,

            Gram_Panchayat: Panchayat,

            REVENUE_VILLAGE: RevenueVillage,

            Village: Village

        }),

        dataType: 'json',


        //================================================
        // SUCCESS
        //================================================

        success: function (response) {

            console.log(
                "Habitation Response:",
                response
            );


            if (response.Status == "1") {

                var res =
                    response.Data || [];


                //================================================
                // No Data
                //================================================

                if (res.length == 0) {

                    $('.preloader').hide();

                    alert(
                        "No Habitation Data Found"
                    );

                    return false;
                }


                //================================================
                // Calculate Total
                //================================================

                var Facol = 0;

                var Pocol = 0;

                var Ecol = 0;


                for (
                    var i = 0;
                    i < res.length;
                    i++
                ) {

                    // Skip existing TOTAL row
                    if (
                        String(
                            res[i].Habitation || ''
                        ).trim().toUpperCase() == 'TOTAL'
                    ) {
                        continue;
                    }


                    Facol += Number(
                        res[i].NO_OF_FARMERS || 0
                    );


                    Pocol += Number(
                        res[i].NO_OF_PLOTS || 0
                    );


                    Ecol += Number(
                        res[i].TOTAL_EXTENT || 0
                    );

                }


                //================================================
                // Remove existing TOTAL row
                //================================================

                res = res.filter(function (row) {

                    return !(
                        String(
                            row.Habitation || ''
                        ).trim().toUpperCase() == 'TOTAL'
                    );

                });


                //================================================
                // Round Extent
                //================================================

                Ecol =
                    Math.floor(
                        Ecol * 100
                    ) / 100;


                //================================================
                // Add TOTAL row
                //================================================

                res.push({

                    ITDA_NAME: '',

                    DISTRICT: '',

                    MANDAL: '',

                    Gram_Panchayat: '',

                    REVENUE_VILLAGE: '',

                    Village: '',

                    Habitation: 'TOTAL',

                    NO_OF_FARMERS: Facol,

                    NO_OF_PLOTS: Pocol,

                    TOTAL_EXTENT: Ecol

                });


                console.log(
                    "Final Habitation Data:",
                    res
                );


                //================================================
                // Destroy old DataTable
                //================================================

                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_habitation_ben_tbl'
                    )
                ) {

                    $('#dt_habitation_ben_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }


                //================================================
                // Show Habitation table
                //================================================

                $('#dt_habitation_ben_tbl').show();


                //================================================
                // Create DataTable
                //================================================

                $('#dt_habitation_ben_tbl').DataTable({

                    aLengthMenu: [

                        [100, 200, 300, 400, -1],

                        [100, 200, 300, 400, "All"]

                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    footer: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,


                    //================================================
                    // BUTTONS
                    //================================================

                    buttons: [

                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            title:
                                'Habitation wise Beneficiaries & Extent'
                        },


                        {
                            extend: 'excelHtml5',

                            title:
                                'Habitation wise Beneficiaries & Extent',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            autoFilter: true
                        },


                        {
                            extend: 'csvHtml5',

                            title:
                                'Habitation wise Beneficiaries & Extent',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'print',

                            title:
                                'Habitation wise Beneficiaries & Extent',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'pdfHtml5',

                            title:
                                'Habitation wise Beneficiaries & Extent',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],


                    //================================================
                    // COLUMN DEFINITIONS
                    //================================================

                    columnDefs: [

                        {
                            targets: [1],

                            className: "text-left"
                        }

                    ],


                    fixedColumns: true,


                    //================================================
                    // COLUMNS
                    //================================================

                    columns: [


                        //================================================
                        // 1. S.NO
                        //================================================

                        {

                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row,
                                meta
                            ) {

                                // TOTAL ROW
                                if (
                                    String(
                                        row.Habitation || ''
                                    ).trim().toUpperCase() == 'TOTAL'
                                ) {

                                    return '';

                                }


                                return (
                                    meta.row +
                                    meta.settings._iDisplayStart +
                                    1
                                );

                            }

                        },


                        //================================================
                        // 2. DISTRICT
                        //================================================

                        // Not displayed in current table


                        //================================================
                        // 3. MANDAL
                        //================================================

                        // Not displayed in current table


                        //================================================
                        // 4. PANCHAYAT
                        //================================================

                        // Not displayed in current table


                        //================================================
                        // 5. REVENUE VILLAGE
                        //================================================

                        // Not displayed in current table


                        //================================================
                        // 6. VILLAGE
                        //================================================

                        // Not displayed in current table


                        //================================================
                        // 7. HABITATION
                        //================================================

                        {

                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                //================================================
                                // TOTAL ROW - NOT CLICKABLE
                                //================================================

                                if (
                                    String(
                                        row.Habitation || ''
                                    ).trim().toUpperCase() == 'TOTAL'
                                ) {

                                    return 'TOTAL';

                                }


                                return row.Habitation || '';

                            }

                        },


                        //================================================
                        // 8. TOTAL FARMERS
                        //================================================

                        {

                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                //================================================
                                // TOTAL ROW - NOT CLICKABLE
                                // IMPORTANT FIX
                                //================================================

                                if (
                                    String(
                                        row.Habitation || ''
                                    ).trim().toUpperCase() == 'TOTAL'
                                ) {

                                    return row.NO_OF_FARMERS || 0;

                                }


                                //================================================
                                // HABITATION ROW - CLICKABLE
                                // Next Level -> BENEFICIARIES
                                //================================================

                                return "<a href='#' " +

                                    "onclick='return Get_NoOfFarmer(" +
                                    JSON.stringify(row) +
                                    ");' " +

                                    "style='text-decoration:underline;color:black;cursor:pointer;'>" +

                                    row.NO_OF_FARMERS +

                                    "</a>";

                            }

                        },


                        //================================================
                        // 9. TOTAL PLOTS
                        //================================================

                        {

                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                //================================================
                                // TOTAL ROW - NOT CLICKABLE
                                // IMPORTANT FIX
                                //================================================

                                if (
                                    String(
                                        row.Habitation || ''
                                    ).trim().toUpperCase() == 'TOTAL'
                                ) {

                                    return row.NO_OF_PLOTS || 0;

                                }


                                //================================================
                                // HABITATION ROW - CLICKABLE
                                // Next Level -> PLOTS
                                //================================================

                                return "<a href='#' " +

                                    "onclick='return Get_NoOfFarmerPlots(" +
                                    JSON.stringify(row) +
                                    ");' " +

                                    "style='text-decoration:underline;color:black;cursor:pointer;'>" +

                                    row.NO_OF_PLOTS +

                                    "</a>";

                            }

                        },


                        //================================================
                        // 10. TOTAL EXTENT
                        //================================================

                        {

                            mData: null,

                            mRender: function (
                                data,
                                type,
                                row
                            ) {

                                return row.TOTAL_EXTENT || 0;

                            }

                        }

                    ],


                    //================================================
                    // CREATED ROW
                    // TOTAL ROW BOLD
                    //================================================

                    createdRow: function (
                        row,
                        data,
                        dataIndex
                    ) {

                        if (
                            String(
                                data.Habitation || ''
                            ).trim().toUpperCase() == 'TOTAL'
                        ) {

                            $(row)
                                .find('td')
                                .css(
                                    'font-weight',
                                    'bold'
                                );

                        }

                    }

                });


                //================================================
                // SHOW WRAPPER / FILTER
                //================================================

                $('#dt_habitation_ben_tbl_wrapper').show();

                $('#dt_habitation_ben_tbl_filter').show();


                //================================================
                // HIDE LOADER
                //================================================

                $('.preloader').hide();


                console.log(
                    "===================================="
                );

                console.log(
                    "HABITATION TABLE DATA BOUND SUCCESSFULLY"
                );

                console.log(
                    "====================================");

            }


            else {

                $('#dt_habitation_ben_tbl').hide();

                $('#dt_habitation_ben_tbl_wrapper').hide();

                $('#dt_habitation_ben_tbl_filter').hide();

                $('.preloader').hide();

                alert(
                    "No Habitation Data Found"
                );

            }

        },


        //================================================
        // AJAX ERROR
        //================================================

        error: function (
            xhr,
            status,
            error
        ) {

            $('#dt_habitation_ben_tbl').hide();

            $('#dt_habitation_ben_tbl_wrapper').hide();

            $('#dt_habitation_ben_tbl_filter').hide();

            $('.preloader').hide();


            console.log(
                "===================================="
            );

            console.log(
                "Habitation AJAX Error"
            );

            console.log(
                "===================================="
            );


            console.log(
                "Status Code:",
                xhr.status
            );


            console.log(
                "Status:",
                status
            );


            console.log(
                "Error:",
                error
            );


            console.log(
                "Response:",
                xhr.responseText
            );


            alert(
                "Error while loading Habitation data"
            );

        }

    });


    return false;

}

function Get_NoOfFarmer(data) {

    console.log("====================================");
    console.log("HABITATION CLICKED - TOTAL FARMERS");
    console.log("====================================");

    //================================================
    // Convert JSON string to object
    //================================================

    if (typeof data === "string") {

        try {
            data = JSON.parse(data);
        }
        catch (e) {

            console.log("JSON Parse Error:", e);

            alert("Invalid Farmer Row Data");

            return false;
        }
    }

    currentAllReportLevel = "FARMERS";



    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Habitation clicked - Total Farmers:", data);


    $('.preloader').show();


    //================================================
    // IMPORTANT
    // Take parent values from Habitation heading
    //================================================

    var ITDA =
        $('#itdaval8').text().trim();

    var District =
        $('#distval8').text().trim();

    var Mandal =
        $('#mandalval8').text().trim();

    var Panchayat =
        $('#panchayatval8').text().trim();

    var RevenueVillage =
        $('#revenuevillageval8').text().trim();

    var Village =
        $('#villageval8').text().trim();


    //================================================
    // Habitation from clicked row
    //================================================

    var Habitation =
        data.Habitation ||
        data.HABITATION ||
        data.Habitation_Name ||
        '';


    Habitation = String(Habitation).trim();


    console.log("====================================");
    console.log("GET_NO_OF_FARMER REQUEST VALUES");
    console.log("====================================");

    console.log("ITDA           :", ITDA);
    console.log("District       :", District);
    console.log("Mandal         :", Mandal);
    console.log("Panchayat      :", Panchayat);
    console.log("RevenueVillage :", RevenueVillage);
    console.log("Village        :", Village);
    console.log("Habitation     :", Habitation);

    console.log("====================================");


    //================================================
    // Validation
    //================================================

    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Panchayat == '' ||
        RevenueVillage == '' ||
        Village == '' ||
        Habitation == '' ||
        Habitation.toUpperCase() == 'TOTAL'
    ) {

        $('.preloader').hide();

        console.log("❌ FARMER REQUEST VALIDATION FAILED");

        console.log({
            ITDA: ITDA,
            District: District,
            Mandal: Mandal,
            Panchayat: Panchayat,
            RevenueVillage: RevenueVillage,
            Village: Village,
            Habitation: Habitation
        });

        alert("Farmer Request Values Missing");

        return false;
    }


    //================================================
    // Set Farmer page heading
    //================================================

    $('#itdaval9').text(ITDA);

    $('#distval9').text(District);

    $('#mandalval9').text(Mandal);

    $('#panchayatval9').text(Panchayat);

    $('#revenuevillageval9').text(RevenueVillage);

    $('#villageval9').text(Village);

    $('#habitationval9').text(Habitation);


    //================================================
    // Hide Habitation table
    //================================================

    $('#dt_habitation_ben_tbl').hide();

    $('#dt_habitation_ben_tbl_wrapper').hide();

    $('#dt_habitation_ben_tbl_filter').hide();


    //================================================
    // Hide Plot table
    //================================================

    $('#dt_beneficiary_plots_tbl').hide();

    $('#dt_beneficiary_plots_tbl_wrapper').hide();

    $('#dt_beneficiary_plots_tbl_filter').hide();


    //================================================
    // Hide old Beneficiary table
    //================================================

    $('#dt_beneficiary_details_tbl').hide();

    $('#dt_beneficiary_details_tbl_wrapper').hide();

    $('#dt_beneficiary_details_tbl_filter').hide();


    //================================================
    // AJAX
    // PTYPE = 37
    // TOTAL FARMERS
    //================================================

    $.ajax({

        type: 'POST',

        contentType:
            'application/json; charset=utf-8',

        url:
            '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({

            type: 'BeneficiaryForAll',

            Itda: ITDA,

            District: District,

            Mandal: Mandal,

            Gram_Panchayat: Panchayat,

            REVENUE_VILLAGE: RevenueVillage,

            Village: Village,

            Habitation: Habitation

        }),

        dataType: 'json',


        //================================================
        // SUCCESS
        //================================================

        success: function (response) {

            console.log("====================================");
            console.log("TOTAL FARMERS RESPONSE");
            console.log("====================================");

            console.log(response);


            if (response.Status == "1") {

                var res =
                    response.Data || [];


                console.log("TOTAL FARMERS DATA:");
                console.log(res);


                //================================================
                // No Data
                //================================================

                if (res.length == 0) {

                    $('.preloader').hide();

                    alert("No Farmer Data Found");

                    return false;
                }


                //================================================
                // Destroy old DataTable
                //================================================

                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_beneficiary_details_tbl'
                    )
                ) {

                    $('#dt_beneficiary_details_tbl')
                        .DataTable()
                        .clear()
                        .destroy();

                }


                //================================================
                // Show Beneficiary table
                //================================================

                $('#dt_beneficiary_details_tbl').show();


                //================================================
                // Create DataTable
                //================================================

                $('#dt_beneficiary_details_tbl').DataTable({

                    aLengthMenu: [

                        [100, 200, 300, 400, -1],

                        [100, 200, 300, 400, "All"]

                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,


                    //================================================
                    // Buttons
                    //================================================

                    buttons: [

                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            title:
                                'Habitation wise Total Farmers'
                        },

                        {
                            extend: 'excelHtml5',

                            title:
                                'Habitation wise Total Farmers',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            autoFilter: true
                        },

                        {
                            extend: 'csvHtml5',

                            title:
                                'Habitation wise Total Farmers',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },

                        {
                            extend: 'print',

                            title:
                                'Habitation wise Total Farmers',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>'
                        },

                        {
                            extend: 'pdfHtml5',

                            title:
                                'Habitation wise Total Farmers',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],


                    //================================================
                    // Column Alignment
                    //================================================

                    columnDefs: [
                        {
                            targets: [2, 3],
                            className: "text-left"
                        }
                    ],


                    //================================================
                    // Columns
                    //================================================

                    columns: [

                        //================================================
                        // 1. S.NO
                        //================================================
                        {
                            data: null,

                            render: function (
                                data,
                                type,
                                row,
                                meta
                            ) {

                                return (
                                    meta.row +
                                    meta.settings._iDisplayStart +
                                    1
                                );
                            }
                        },


                        //================================================
                        // 2. BENEFICIARY ID
                        //================================================
                        {
                            data: 'benficiary_id',

                            defaultContent: ''
                        },





                        //================================================
                        // 3. FARMER NAME
                        //================================================
                        {
                            data: 'ROFR_PATTADAAR',

                            defaultContent: ''
                        },


                        //================================================
                        // 4. FATHER NAME
                        //================================================
                        {
                            data: 'Father_Name',

                            defaultContent: ''
                        },


                        //================================================
                        // 5. AADHAAR NO
                        //================================================
                        {
                            data: 'Aadhaar_NO',

                            defaultContent: ''
                        }

                    ]

                });


                //================================================
                // Show wrapper/filter
                //================================================

                $('#dt_beneficiary_details_tbl_wrapper').show();

                $('#dt_beneficiary_details_tbl_filter').show();


                $('.preloader').hide();

            }

            else {

                $('.preloader').hide();

                console.log("====================================");
                console.log("TOTAL FARMERS FAILED");
                console.log("====================================");

                console.log("Status :", response.Status);
                console.log("Message:", response.Message);
                console.log("Reason :", response.Reason);
                console.log("Full Response:", response);

                alert(
                    "No Farmer Data Found\n\n" +
                    "Reason: " +
                    (response.Reason || response.Message || "Unknown")
                );
            }

        },


        //================================================
        // AJAX ERROR
        //================================================

        error: function (
            xhr,
            status,
            error
        ) {

            $('.preloader').hide();

            console.log("====================================");
            console.log("FARMER AJAX ERROR");
            console.log("====================================");

            console.log("XHR:", xhr);

            console.log("STATUS:", status);

            console.log("ERROR:", error);

            console.log(
                "RESPONSE:",
                xhr.responseText
            );


            alert("Error while loading Farmer data");

        }

    });


    return false;
}

function Get_NoOfFarmerPlots(data) {

    console.log("====================================");
    console.log("HABITATION CLICKED - TOTAL PLOTS");
    console.log("====================================");


    //================================================
    // Convert JSON string to object
    //================================================

    if (typeof data === "string") {

        try {
            data = JSON.parse(data);
        }
        catch (e) {

            console.log("JSON Parse Error:", e);

            alert("Invalid Plot Row Data");

            return false;
        }
    }

    currentAllReportLevel = "PLOTS";



    console.log("Current Level:", currentAllReportLevel);
    console.log("Current Data:", currentAllReportData);

    console.log("Habitation clicked - Total Plots:", data);;


    $('.preloader').show();


    //================================================
    // Hide Habitation table
    //================================================

    $('#dt_habitation_ben_tbl').hide();
    $('#dt_habitation_ben_tbl_wrapper').hide();
    $('#dt_habitation_ben_tbl_filter').hide();


    //================================================
    // Hide Beneficiary table
    //================================================

    $('#dt_beneficiary_details_tbl').hide();
    $('#dt_beneficiary_details_tbl_wrapper').hide();
    $('#dt_beneficiary_details_tbl_filter').hide();


    //================================================
    // Hide Plot table
    //================================================

    $('#dt_beneficiary_plots_tbl').hide();
    $('#dt_beneficiary_plots_tbl_wrapper').hide();
    $('#dt_beneficiary_plots_tbl_filter').hide();


    //================================================
    // Show Back button
    //================================================

    $('#distbackidForAll').show();


    //================================================
    // IMPORTANT
    // Get Parent Values From Habitation Heading
    //================================================

    var ITDA =
        $('#itdaval8').text().trim();

    var District =
        $('#distval8').text().trim();

    var Mandal =
        $('#mandalval8').text().trim();

    var Panchayat =
        $('#panchayatval8').text().trim();

    var RevenueVillage =
        $('#revenuevillageval8').text().trim();

    var Village =
        $('#villageval8').text().trim();


    //================================================
    // Get Habitation From Clicked Row
    //================================================

    var Habitation =
        data.Habitation ||
        data.HABITATION ||
        data.Habitation_Name ||
        '';

    Habitation = String(Habitation).trim();


    //================================================
    // Console Request Values
    //================================================

    console.log("====================================");
    console.log("GET_NO_OF_FARMER_PLOTS REQUEST VALUES");
    console.log("====================================");

    console.log("ITDA           :", ITDA);
    console.log("District       :", District);
    console.log("Mandal         :", Mandal);
    console.log("Panchayat      :", Panchayat);
    console.log("RevenueVillage :", RevenueVillage);
    console.log("Village        :", Village);
    console.log("Habitation     :", Habitation);

    console.log("====================================");


    //================================================
    // Validation
    //================================================

    if (
        ITDA == '' ||
        District == '' ||
        Mandal == '' ||
        Panchayat == '' ||
        RevenueVillage == '' ||
        Village == '' ||
        Habitation == '' ||
        Habitation.toUpperCase() == 'TOTAL'
    ) {

        $('.preloader').hide();

        console.log("❌ PLOT REQUEST VALIDATION FAILED");

        console.log({
            ITDA: ITDA,
            District: District,
            Mandal: Mandal,
            Panchayat: Panchayat,
            RevenueVillage: RevenueVillage,
            Village: Village,
            Habitation: Habitation
        });

        alert("Plot Request Values Missing");

        return false;
    }


    //================================================
    // Set Plot Heading
    //================================================

    $('#itdaval10').text(ITDA);

    $('#distval10').text(District);

    $('#mandalval10').text(Mandal);

    $('#panchayatval10').text(Panchayat);

    $('#revenuevillageval10').text(RevenueVillage);

    $('#villageval10').text(Village);

    $('#habitationval10').text(Habitation);


    //================================================
    // AJAX
    // PTYPE = 38
    //================================================

    $.ajax({

        type: 'POST',

        contentType:
            'application/json; charset=utf-8',

        url:
            '../Giribhumi/GetBenficiarywise_report',

        data: JSON.stringify({

            type: 'NoofFarmerPlots',

            Itda: ITDA,

            District: District,

            Mandal: Mandal,

            Gram_Panchayat: Panchayat,

            REVENUE_VILLAGE: RevenueVillage,

            Village: Village,

            Habitation: Habitation

        }),

        dataType: 'json',


        //================================================
        // SUCCESS
        //================================================

        success: function (response) {

            console.log("====================================");
            console.log("TOTAL PLOTS RESPONSE");
            console.log("====================================");

            console.log("STATUS :", response.Status);

            console.log("MESSAGE:", response.Message);

            console.log("REASON  :", response.Reason);

            console.log("DATA   :", response.Data);


            //================================================
            // Success
            //================================================

            if (response.Status == "1") {

                var res =
                    response.Data || [];


                console.log("====================================");
                console.log("TOTAL PLOTS DATA");
                console.log("====================================");

                console.log(res);

                console.log(
                    "TOTAL PLOTS COUNT:",
                    res.length
                );


                //================================================
                // No Data
                //================================================

                if (res.length == 0) {

                    $('.preloader').hide();

                    alert("No Plot Data Found");

                    return false;
                }


                //================================================
                // Destroy Existing DataTable
                //================================================

                if (
                    $.fn.DataTable.isDataTable(
                        '#dt_beneficiary_plots_tbl'
                    )
                ) {

                    $('#dt_beneficiary_plots_tbl')
                        .DataTable()
                        .clear()
                        .destroy();
                }


                //================================================
                // Show Plot Table
                //================================================

                $('#dt_beneficiary_plots_tbl').show();


                //================================================
                // Create DataTable
                //================================================

                $('#dt_beneficiary_plots_tbl').DataTable({

                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],

                    pageLength: 50,

                    destroy: true,

                    stateSave: false,

                    bPaginate: true,

                    data: res,

                    dom: 'Bfrtip',

                    ordering: false,


                    //================================================
                    // Buttons
                    //================================================

                    buttons: [

                        {
                            extend: 'copy',

                            text:
                                '<i class="far fa-copy fa-lg" style="width:30px"></i>',

                            title:
                                'Habitation wise Total Plots'
                        },


                        {
                            extend: 'excelHtml5',

                            title:
                                'Habitation wise Total Plots',

                            text:
                                '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                            autoFilter: true
                        },


                        {
                            extend: 'csvHtml5',

                            title:
                                'Habitation wise Total Plots',

                            text:
                                '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'print',

                            title:
                                'Habitation wise Total Plots',

                            text:
                                '<i class="fas fa-print fa-lg" style="width:30px"></i>'
                        },


                        {
                            extend: 'pdfHtml5',

                            title:
                                'Habitation wise Total Plots',

                            text:
                                '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',

                            orientation: 'landscape',

                            pageSize: 'A4'
                        }

                    ],


                    //================================================
                    // Column Alignment
                    //================================================

                    columnDefs: [

                        {
                            targets: [

                                3,
                                4

                            ],

                            className: "text-left"
                        }

                    ],

                    fixedColumns: true,

                    columns: [

                        // 1. S.NO
                        {
                            data: null,

                            render: function (
                                data,
                                type,
                                row,
                                meta
                            ) {

                                return (
                                    meta.row +
                                    meta.settings._iDisplayStart +
                                    1
                                );
                            }
                        },


                        // 2. BENEFICIARY ID
                        {
                            data: 'benficiary_id',

                            defaultContent: ''
                        },


                        // 3. PLOT ID
                        {
                            data: 'PLOT_ID',

                            defaultContent: ''
                        },


                        // 4. FARMER NAME
                        {
                            data: 'ROFR_PATTADAAR',

                            defaultContent: ''
                        },


                        // 5. FATHER NAME
                        {
                            data: 'Father_Name',

                            defaultContent: ''
                        },


                        // 6. AADHAAR NO
                        {
                            data: 'Aadhaar_NO',

                            defaultContent: ''
                        },


                        // 7. COMPARTMENT NO
                        {
                            data: 'Compartment_No',

                            defaultContent: ''
                        },


                        // 8. ROFR PATTA NO
                        {
                            data: 'ROFR_PATTANO',

                            defaultContent: ''
                        },


                        // 9. EXTENT
                        {
                            data: 'ExtentPlotArea',

                            defaultContent: ''
                        }

                    ]

                });


                //================================================
                // Show DataTable Wrapper
                //================================================

                $('#dt_beneficiary_plots_tbl_wrapper').show();

                $('#dt_beneficiary_plots_tbl_filter').show();


                $('.preloader').hide();

            }


            //================================================
            // Failure
            //================================================

            else {

                $('.preloader').hide();

                alert("No Plot Data Found");
            }

        },


        //================================================
        // AJAX ERROR
        //================================================

        error: function (
            xhr,
            status,
            error
        ) {

            $('.preloader').hide();

            console.log("====================================");
            console.log("PLOT AJAX ERROR");
            console.log("====================================");

            console.log("XHR    :", xhr);

            console.log("STATUS :", status);

            console.log("ERROR  :", error);

            console.log(
                "RESPONSE:",
                xhr.responseText
            );

            alert("Error while loading Plot data");

        }

    });


    return false;
}

//====================================================
// STEP-BY-STEP BACK BUTTON
//====================================================

$('#distbackidForAll').click(function () {

    console.log("====================================");
    console.log("BACK BUTTON CLICKED");
    console.log("CURRENT LEVEL:", currentAllReportLevel);
    console.log("CURRENT DATA:", currentAllReportData);
    console.log("====================================");
    //MandalAll hide here
    $('#dt_mandal_ben_tbl').hide();
    $('#dt_mandal_ben_tbl_wrapper').hide();
    $('#dt_mandal_ben_tbl_filter').hide();
    //PanchaytAll hide here
    $('#dt_panchayt_ben_tbl').hide();
    $('#dt_panchayt_ben_tbl_wrapper').hide();
    $('#dt_panchayt_ben_tbl_filter').hide();

    $('#dt_revenuevillage_ben_tbl').hide();
    $('#dt_revenuevillage_ben_tbl_wrapper').hide();
    $('#dt_revenuevillage_ben_tbl_filter').hide();

    $('#dt_village_ben_tbl').hide();
    $('#dt_village_ben_tbl_wrapper').hide();
    $('#dt_village_ben_tbl_filter').hide();
    $('#dt_habitation_ben_tbl').hide();
    $('#dt_habitation_ben_tbl_wrapper').hide();
    $('#dt_habitation_ben_tbl_filter').hide();

    $('#dt_beneficiary_details_tbl').hide();
    $('#dt_beneficiary_details_tbl_wrapper').hide();
    $('#dt_beneficiary_details_tbl_filter').hide();

    $('#dt_beneficiary_plots_tbl').hide();
    $('#dt_beneficiary_plots_tbl_wrapper').hide();
    $('#dt_beneficiary_plots_tbl_filter').hide();


    //====================================================
    // 1. MANDAL -> DISTRICT
    //====================================================

    if (currentAllReportLevel === "MANDAL") {

        console.log("BACK: MANDAL -> DISTRICT");

        Get_DistrictsforALL();

        return false;
    }


    //====================================================
    // 2. PANCHAYAT -> MANDAL
    //====================================================

    if (currentAllReportLevel === "PANCHAYAT") {

        console.log("BACK: PANCHAYAT -> MANDAL");

        Get_MandalForAll(currentAllReportData);

        return false;
    }


    //====================================================
    // 3. REVENUE VILLAGE -> PANCHAYAT
    //====================================================

    if (currentAllReportLevel === "REVENUE_VILLAGE") {

        console.log(
            "BACK: REVENUE VILLAGE -> PANCHAYAT"
        );

        Get_PanchayatForAll(currentAllReportData);

        return false;
    }


    //====================================================
    // 4. VILLAGE -> REVENUE VILLAGE
    //====================================================

    if (currentAllReportLevel === "VILLAGE") {

        console.log(
            "BACK: VILLAGE -> REVENUE VILLAGE"
        );

        Get_RevenueVillageForAll(
            currentAllReportData
        );

        return false;
    }


    //====================================================
    // 5. HABITATION -> VILLAGE
    //====================================================

    if (currentAllReportLevel === "HABITATION") {

        console.log(
            "BACK: HABITATION -> VILLAGE"
        );

        Get_VillageForAll(
            currentAllReportData
        );

        return false;
    }


    //====================================================
    // 6. FARMERS -> HABITATION
    //====================================================

    if (currentAllReportLevel === "FARMERS") {

        console.log("BACK: FARMERS -> HABITATION");
        console.log("Restoring Habitation Data:", previousHabitationData);

        Get_HabitationForAll(previousHabitationData);

        return false;
    }

    //====================================================
    // 7. PLOTS -> HABITATION
    //====================================================

    if (currentAllReportLevel === "PLOTS") {

        console.log("BACK: PLOTS -> HABITATION");
        console.log("Restoring Habitation Data:", previousHabitationData);

        Get_HabitationForAll(previousHabitationData);

        return false;
    }


    //====================================================
    // DEFAULT
    //====================================================

    console.log(
        "No previous level found."
    );

    return false;

});




$('#distbackidForPH1').click(function () {
    //mandal phase1 hide here
    $('#dt_mandal_Ph1_tbl').hide();
    $('#dt_mandal_Ph1_tbl_wrapper').hide();
    $('#dt_mandal_Ph1_tbl_filter').hide();
    Get_DistrictsforPhase1();
});
$('#distbackidForPH2').click(function () {
    //mandal phase2 hide here
    $('#dt_mandal_Ph2_tbl').hide();
    $('#dt_mandal_Ph2_tbl_wrapper').hide();
    $('#dt_mandal_Ph2_tbl_filter').hide();
    Get_DistrictsforPhase2();
});
$('#distbackidForBoth').click(function () {
    //mandal both hide here
    $('#dt_mandal_both_tbl').hide();
    $('#dt_mandal_both_tbl_wrapper').hide();
    $('#dt_mandal_both_tbl_filter').hide();

    Get_DistrictsforPhasesboth();
});

$('#distval2').click(function () {
    Get_DistrictsforALL();
});
