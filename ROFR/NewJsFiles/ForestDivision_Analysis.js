$(document).ready(function () {
    $('.preloader').show();
    Get_Divisions();
    $('.preloader').hide();
   
})

function Get_Divisions() {
    $('.preloader').show();
    $('#distbackid').hide();
    $('#dt_fRange_tbl').hide();
    $('#dt_fRange_tbl_wrapper').hide();
    $('#dt_fRange_tbl_filter').hide();

    $('#dt_FBeats_tbl').hide();
    $('#dt_FBeats_tbl_wrapper').hide();
    $('#dt_FBeats_tbl_filter').hide();
    $('#distbackid').hide();
    $('#F-rangebackid').hide();
    var division = "5"
    /*var count = 0;*/
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ForestDivision_Analysis',
        data: "{'Type':'ALL','Division':'" + division + "','District':'start'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_dist_tbl').show();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 20,
                    destroy: true,
                    footer: true,
                    data: response.Data,
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
                                    return 'FOREST DIVISION MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FOREST DIVISION MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FOREST DIVISION MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'FOREST DIVISION MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FOREST RANGE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 5],
                            "className": "text-left",
                        },
                       
                    ],
                    fixedColumns: true,

                    columns: [

                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        count++;
                        //        return count;
                        //    }
                        //},

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['LGD_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DISTRICT_NAME'];
                            }
                        },

                       

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.NO_OF_RANGES > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_ForestRange(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_RANGES + "<a/>";


                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.NO_OF_RANGES + "<a/>";
                                }

                            }
                        },
                    ]

                });

                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_dist_tbl_wrapper').hide();
                $('#dt_dist_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_ForestRange(data) {
    $('.preloader').show();
    $('#distbackid').show();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_FBeats_tbl').hide();
    $('#dt_FBeats_tbl_wrapper').hide();
    $('#dt_FBeats_tbl_filter').hide();
    sessionStorage.setItem('DisCode', data.LGD_DISTRICT_CODE);
    sessionStorage.setItem('DiviCode', data.FOREST_DIVISION_CODE);
    $('#distbackid').show();
    $('#F-rangebackid').hide();
    var forestrange = "6"
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ForestDivision_Analysis',
        data: "{'Type':'','forestrange':'" + forestrange + "','District':'" + data.LGD_DISTRICT_CODE + "','Division':'" + data.FOREST_DIVISION_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_fRange_tbl').show();
                $('#dt_fRange_tbl').dataTable().fnClearTable();
                $('#dt_fRange_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 20,
                    destroy: true,
                    footer: true,
                    data: response.Data,
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
                                    return 'FOREST RANGE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FOREST RANGE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FOREST RANGE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'FOREST RANGE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FOREST BEAT MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3,6,8,10],
                            "className": "text-left"

                        },
                    ],
                    fixedColumns: true,

                    columns: [

                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        count++;
                        //        return count;
                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['LGD_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DISTRICT_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LGD_MANDAL_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_MANDAL_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MANDAL_NAME'];
                            }
                        },

                        

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_RANGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_RANGE_NAME'];
                            }
                        },
                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.NO_OF_BEATS > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_ForestBeat(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_BEATS + "<a/>";


                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.NO_OF_BEATS + "<a/>";
                                }

                            }
                        },
                        
                    ]

                });

                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_fRange_tbl').dataTable().fnClearTable();
                $('#dt_fRange_tbl').hide();
                $('#dt_fRange_tbl_wrapper').hide();
                $('#dt_fRange_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_ForestBeat(data) {
    $('.preloader').show();
    $('#distbackid').show();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_fRange_tbl').hide();
    $('#dt_fRange_tbl_wrapper').hide();
    $('#dt_fRange_tbl_filter').hide();

    $('#distbackid').hide();
    $('#F-rangebackid').show();
    var Frangebeats = "11"
    /*var count = 0;*/
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ForestDivision_Analysis',
        data: "{'Type':'','Frangebeats':'" + Frangebeats + "','District':'" + data.LGD_DISTRICT_CODE + "','Division':'" + data.FOREST_DIVISION_CODE + "','Mandal':'" + data.LGD_MANDAL_CODE + "','Range':'" + data.FOREST_RANGE_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_FBeats_tbl').show();
                $('#dt_FBeats_tbl').dataTable().fnClearTable();
                $('#dt_FBeats_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 20,
                    destroy: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    ordering: false,
                    order: [[1, 'asc']],
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'FOREST BEAT MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FOREST BEAT MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FOREST BEAT MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'FOREST BEAT MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FOREST BEAT MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3,6,9,11,13,15,16],
                            "className": "text-left"

                        },
                    ],
                    fixedColumns: true,

                    columns: [

                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        count++;
                        //        return count;
                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['LGD_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_DISTRICT_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DISTRICT_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LGD_MANDAL_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_MANDAL_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MANDAL_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LGD_VILLAGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_VILLAGE_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VILLAGE_NAME'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_DIVISION_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_RANGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_RANGE_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_BEAT_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FOREST_BEAT_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAB_NAME'];
                            }
                        },
                        

                        

                    ]

                });

                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_FBeats_tbl').dataTable().fnClearTable();
                $('#dt_FBeats_tbl').hide();
                $('#dt_FBeats_tbl_wrapper').hide();
                $('#dt_FBeats_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

$('#distbackid').click(function () {
    Get_Divisions();
});
$('#F-rangebackid').click(function () {

    var Dist = sessionStorage.getItem('DisCode');
    var Divi = sessionStorage.getItem('DiviCode');

    var data = {};
    data.LGD_DISTRICT_CODE = Dist;
    data.FOREST_DIVISION_CODE = Divi;
    Get_ForestRange(data);
});