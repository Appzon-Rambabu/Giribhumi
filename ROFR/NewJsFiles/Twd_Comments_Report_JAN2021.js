$(document).ready(function () {
    $('.preloader').show();
    Get_Districts();
    $('.preloader').hide();
})

function Get_Districts() {
    $('.preloader').show();

    $('#dt_Man_tbl').hide();
    $('#dt_Man_tbl_wrapper').hide();
    $('#dt_Man_tbl_filter').hide();
    var screen = "1";
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/TwdCommentsReport',
        data: "{ 'Type':'" + screen +"'}",
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
                                    return 'TWD COMMENTS REPORT JAN-2021';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="fas fa-file-csv"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'TWD COMMENTS REPORT JAN-2021';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
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
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.ITDA_NAME != 'Total') {
                                    count++;
                                    return count;
                                }
                                else {
                                    return null;

                                }

                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.ITDA_NAME == 'Total') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.ITDA_NAME + "</h6>";
                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.ITDA_NAME + "<a/>";
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.TOATL_L1ACRE > 0)
                                {
                                    if (data.ITDA_NAME == "Total") {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.TOATL_L1ACRE + "</h6>";
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.TOATL_L1ACRE + "<a/>";
                                    }

                                }
                                else {
                                    return "<a id='dlcview'   style=' text-decoration: underline;color:black;'>" + data.TOATL_L1ACRE + "<a/>";
                                }
                                
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.TOTAL_NOLAND > 0) {
                                    if (data.ITDA_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.TOTAL_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.TOTAL_NOLAND + "<a/>";
                                    }
                                }
                               
                                
                                else {
                                    return "<a id='dlcview'   style=' text-decoration: underline;color:black;'>" + data.TOTAL_NOLAND + "<a/>";
                                }
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.PENDING_L1ACRE > 0) {

                                    if (data.ITDA_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.PENDING_L1ACRE + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.PENDING_L1ACRE + "<a/>";
                                    }
                                }
                               
                                
                                else {
                                    return "<a id='dlcview'   style=' text-decoration: underline;color:black;'>" + data.PENDING_L1ACRE + "<a/>";
                                }
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.PENDING_NOLAND > 0) {

                                    if (data.ITDA_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.PENDING_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.PENDING_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview'   style=' text-decoration: underline;color:black;'>" + data.PENDING_NOLAND + "<a/>";
                                }
                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOLAND_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LANDIDENTIFIED_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['POLAVARAMSUBMERGED_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DEATHCASES_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NONTRIBES_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GOVT_EMP_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['WEBLAND_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GIRIBHUMI_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MUTATION_NOLAND'];
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOTDEPENDED_NOLAND'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MIGRATED_NOLAND'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOLAND_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LANDIDENTIFIED_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['POLAVARAMSUBMERGED_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DEATHCASES_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NONTRIBES_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GOVT_EMP_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['WEBLAND_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GIRIBHUMI_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MUTATION_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOTDEPENDED_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MIGRATED_L1'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOLAND_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LANDIDENTIFIED_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['POLAVARAMSUBMERGED_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DEATHCASES_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NONTRIBES_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GOVT_EMP_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['WEBLAND_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GIRIBHUMI_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MUTATION_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOTDEPENDED_REM'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MIGRATED_REM'];
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

function Get_Mandals(data) {
    $('.preloader').show();

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    var screen = "2";
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/TwdCommentsReport',
        data: "{ 'Type':'" + screen + "','Itda':'" + data.ITDA_NAME + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Man_tbl').show();
                $('#dt_Man_tbl').dataTable().fnClearTable();
                $('#dt_Man_tbl').DataTable({
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
                                    return 'TWD COMMENTS REPORT JAN-2021';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="fas fa-file-csv"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'TWD COMMENTS REPORT JAN-2021';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'TWD COMMENTS REPORT JAN-2021',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
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
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.MANDAL_NAME != 'Total') {
                                    count++;
                                    return count;
                                }
                                else {
                                    return null;

                                }

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

                               
                                return s['TOATL_L1ACRE'];
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_NOLAND'];
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                
                                return s['PENDING_L1ACRE'];
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                               
                                return s['PENDING_NOLAND'];
                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.NOLAND_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOLAND_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOLAND_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration: underline;color:black;'>" + data.NOLAND_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.LANDIDENTIFIED_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.LANDIDENTIFIED_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.POLAVARAMSUBMERGED_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.POLAVARAMSUBMERGED_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_NOLAND + "<a/>";
                                }

                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.DEATHCASES_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DEATHCASES_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_NOLAND + "<a/>";
                                }
                               
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.NONTRIBES_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NONTRIBES_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.GOVT_EMP_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GOVT_EMP_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_NOLAND + "<a/>";
                                }
                               
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.WEBLAND_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.WEBLAND_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.WEBLAND_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.WEBLAND_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.GIRIBHUMI_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GIRIBHUMI_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MUTATION_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MUTATION_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MUTATION_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MUTATION_NOLAND + "<a/>";
                                }
                                
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NOTDEPENDED_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOTDEPENDED_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_NOLAND + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.MIGRATED_NOLAND > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MIGRATED_NOLAND + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MIGRATED_NOLAND + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MIGRATED_NOLAND + "<a/>";
                                }
                                
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NOLAND_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOLAND_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOLAND_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NOLAND_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.LANDIDENTIFIED_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.LANDIDENTIFIED_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_L1 + "<a/>";
                                }
                                return s['LANDIDENTIFIED_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.POLAVARAMSUBMERGED_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.POLAVARAMSUBMERGED_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.DEATHCASES_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DEATHCASES_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_L1 + "<a/>";
                                }
                               
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NONTRIBES_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NONTRIBES_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_L1 + "<a/>";
                                }
                                return s['NONTRIBES_L1'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.GOVT_EMP_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GOVT_EMP_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.WEBLAND_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.WEBLAND_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.WEBLAND_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.WEBLAND_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.GIRIBHUMI_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GIRIBHUMI_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MUTATION_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MUTATION_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MUTATION_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MUTATION_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NOTDEPENDED_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOTDEPENDED_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_L1 + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MIGRATED_L1 > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MIGRATED_L1 + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MIGRATED_L1 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MIGRATED_L1 + "<a/>";
                                }
                                
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NOLAND_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOLAND_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOLAND_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NOLAND_REM + "<a/>";
                                }
                               
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.LANDIDENTIFIED_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.LANDIDENTIFIED_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.LANDIDENTIFIED_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.POLAVARAMSUBMERGED_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.POLAVARAMSUBMERGED_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.POLAVARAMSUBMERGED_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.DEATHCASES_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DEATHCASES_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.DEATHCASES_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NONTRIBES_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NONTRIBES_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NONTRIBES_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.GOVT_EMP_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GOVT_EMP_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GOVT_EMP_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.WEBLAND_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.WEBLAND_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.WEBLAND_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.WEBLAND_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.GIRIBHUMI_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.GIRIBHUMI_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.GIRIBHUMI_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MUTATION_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MUTATION_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MUTATION_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MUTATION_REM + "<a/>";
                                }
                               
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.NOTDEPENDED_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.NOTDEPENDED_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.NOTDEPENDED_REM + "<a/>";
                                }
                                
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MIGRATED_REM > 0) {

                                    if (data.MANDAL_NAME == 'Total') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MIGRATED_REM + "</h6>";

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MIGRATED_REM + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' href='#'   style=' text-decoration: underline;color:black;'>" + data.MIGRATED_REM + "<a/>";
                                }
                                
                            }
                        },

                    ]

                });

                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Man_tbl').dataTable().fnClearTable();
                $('#dt_Man_tbl').hide();
                $('#dt_Man_tbl_wrapper').hide();
                $('#dt_Man_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}