

$(document).ready(function () {
    $('.sec-loading').show();
    Get_Mandals();
    $('.sec-loading').hide();
});

function Get_Mandals() {
   

    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();

    $('#dt_beat_tbl').hide();
    $('#dt_beat_tbl_wrapper').hide();
    $('#dt_beat_tbl_filter').hide();

    $('#dt_range_tbl').hide();
    $('#dt_range_tbl_wrapper').hide();
    $('#dt_range_tbl_filter').hide();

    $('#dt_Rbeat_tbl').hide();
    $('#dt_Rbeat_tbl_wrapper').hide();
    $('#dt_Rbeat_tbl_filter').hide();
   
    
    $('#mandalbackid').hide();
    $('#villbackid').hide();
    $('#Frangebackid').hide();
    
    var mandal = "4";
    
    var printCounter = 0;
    $('.sec-loading').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DistictData_Analysis',
        data: "{'Mandal':'" + mandal + "','Type':'ALL'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_mandal_tbl').show();
                $('#dt_mandal_tbl').dataTable().fnClearTable();
                $('#dt_mandal_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
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
                                    return 'MANDAL WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 6],
                            "className": "text-left"
                        },
                    ],
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
                                if (data.NO_OF_VILLAGES > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_NoOFVillages(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_VILLAGES + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.NO_OF_VILLAGES + "<a/>";
                                }

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NO_OF_RANGES > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_NoOFRanges(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_RANGES + "<a/>";


                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.NO_OF_RANGES + "<a/>";
                                }

                            }
                        },


                    ]

                });

                $('.sec-loading').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_tbl').dataTable().fnClearTable();
                $('#dt_mandal_tbl').hide();
                $('#dt_mandal_tbl_wrapper').hide();
                $('#dt_mandal_tbl_filter').hide();

                $('.sec-loading').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_NoOFVillages(data) {
    
    
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    $('#dt_beat_tbl').hide();
    $('#dt_beat_tbl_wrapper').hide();
    $('#dt_beat_tbl_filter').hide();

    $('#dt_range_tbl').hide();
    $('#dt_range_tbl_wrapper').hide();
    $('#dt_range_tbl_filter').hide();

    $('#dt_Rbeat_tbl').hide();
    $('#dt_Rbeat_tbl_wrapper').hide();
    $('#dt_Rbeat_tbl_filter').hide();
    sessionStorage.setItem('DisCode', data.LGD_DISTRICT_CODE);
    sessionStorage.setItem('ManCode', data.LGD_MANDAL_CODE);
    $('#mandalbackid').show();
    $('#villbackid').hide();
    $('#Frangebackid').hide();
    
    var Village = "7";
   
    var printCounter = 0;
    $('.loader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DistictData_Analysis',
        data: "{'District':'" + data.LGD_DISTRICT_CODE + "','Village':'" + Village + "','Type':'','Mandal':'" + data.LGD_MANDAL_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_village_tbl').show();
                $('#dt_village_tbl').dataTable().fnClearTable();
                $('#dt_village_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
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
                                    return 'VILLAGE WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 6, 9],
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
                                if (data.NO_OF_BEATS > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_VillBeats(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_BEATS + "<a/>";


                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.NO_OF_BEATS + "<a/>";
                                }

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_HABITATIONS'];
                            }
                        },

                    ]

                });

                $('.loader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_village_tbl').dataTable().fnClearTable();
                $('#dt_village_tbl').hide();
                $('#dt_village_tbl_wrapper').hide();
                $('#dt_village_tbl_filter').hide();

                $('.loader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_VillBeats(data) {
    
   
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();

    $('#dt_range_tbl').hide();
    $('#dt_range_tbl_wrapper').hide();
    $('#dt_range_tbl_filter').hide();

    $('#dt_Rbeat_tbl').hide();
    $('#dt_Rbeat_tbl_wrapper').hide();
    $('#dt_Rbeat_tbl_filter').hide();

    sessionStorage.setItem('ManCode', data.LGD_MANDAL_CODE);
    sessionStorage.setItem('VillCode', data.LGD_VILLAGE_CODE);
    $('#mandalbackid').hide();
    $('#villbackid').show();
    $('#Frangebackid').hide();
    var Beats = "10";
    
    var printCounter = 0;
    $('.loader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DistictData_Analysis',
        data: "{'District':'" + data.LGD_DISTRICT_CODE + "','NoofBeats':'" + Beats + "','Type':'','Mandal':'" + data.LGD_MANDAL_CODE + "','Village':'" + data.LGD_VILLAGE_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_beat_tbl').show();
                $('#dt_beat_tbl').dataTable().fnClearTable();
                $('#dt_beat_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
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
                                    return 'BEAT WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'BEAT WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'BEAT WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'BEAT WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'RANGE WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 6],
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

                $('.loader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_beat_tbl').dataTable().fnClearTable();
                $('#dt_beat_tbl').hide();
                $('#dt_beat_tbl_wrapper').hide();
                $('#dt_beat_tbl_filter').hide();

                $('.loader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_NoOFRanges(data) {
   
    

    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

   
    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();

    $('#dt_beat_tbl').hide();
    $('#dt_beat_tbl_wrapper').hide();
    $('#dt_beat_tbl_filter').hide();

    $('#dt_Rbeat_tbl').hide();
    $('#dt_Rbeat_tbl_wrapper').hide();
    $('#dt_Rbeat_tbl_filter').hide();

    
    $('#mandalbackid').show();
    $('#villbackid').hide();
    $('#Frangebackid').hide();
   
    var Range = "8";
    /*var count = 0;*/
    var printCounter = 0;
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DistictData_Analysis',
        data: "{'District':'" + data.LGD_DISTRICT_CODE + "','Range':'" + Range + "','Type':'','Mandal':'" + data.LGD_MANDAL_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_range_tbl').show();
                $('#dt_range_tbl').dataTable().fnClearTable();
                $('#dt_range_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
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
                                    return 'RANGE WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'RANGE WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'RANGE WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'RANGE WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'RANGE WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 6],
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
                                    return "<a id='dlcview' href='#'  onclick='return Get_RangeBeats(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NO_OF_BEATS + "<a/>";


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
                $('#dt_range_tbl').dataTable().fnClearTable();
                $('#dt_range_tbl').hide();
                $('#dt_range_tbl_wrapper').hide();
                $('#dt_range_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_RangeBeats(data) {
    
    

    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();

    $('#dt_range_tbl').hide();
    $('#dt_range_tbl_wrapper').hide();
    $('#dt_range_tbl_filter').hide();

    $('#dt_beat_tbl').hide();
    $('#dt_beat_tbl_wrapper').hide();
    $('#dt_beat_tbl_filter').hide();

    
    $('#mandalbackid').hide();
    $('#villbackid').hide();
    $('#Frangebackid').show();
    var rangebeats = "11";
    /*var count = 0;*/
    var printCounter = 0;
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DistictData_Analysis',
        data: "{'District':'" + data.LGD_DISTRICT_CODE + "','rangebeats':'" + rangebeats + "','Type':'','Mandal':'" + data.LGD_MANDAL_CODE + "','Division':'" + data.FOREST_DIVISION_CODE + "','Range':'" + data.FOREST_RANGE_CODE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Rbeat_tbl').show();
                $('#dt_Rbeat_tbl').dataTable().fnClearTable();
                $('#dt_Rbeat_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
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
                                    return 'RANGE BEAT WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'RANGE BEAT WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'RANGE BEAT WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'RANGE BEAT WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'RANGE BEAT WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 6],
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
                $('#dt_Rbeat_tbl').dataTable().fnClearTable();
                $('#dt_Rbeat_tbl').hide();
                $('#dt_Rbeat_tbl_wrapper').hide();
                $('#dt_Rbeat_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

$('#mandalbackid').click(function () {

    var Dist = sessionStorage.getItem('DisCode');

    var data = {};
    data.LGD_DISTRICT_CODE = Dist;
    Get_Mandals(data);
});

$('#villbackid').click(function () {

    var Dist = sessionStorage.getItem('DisCode');
    var Man = sessionStorage.getItem('ManCode');
   
    var data = {};
    data.LGD_DISTRICT_CODE = Dist;
    data.LGD_MANDAL_CODE = Man;
   
    Get_NoOFVillages(data);
});

$('#Frangebackid').click(function () {

    var Dist = sessionStorage.getItem('DisCode');
    var Man = sessionStorage.getItem('ManCode');

    var data = {};
    data.LGD_DISTRICT_CODE = Dist;
    data.LGD_MANDAL_CODE = Man;

    Get_NoOFRanges(data);
});