
$(function () {

   
    Get_Districts();
    add_datecum();
    add_dateToDay();
    
    //Mandal Hide Here
    $('#dt_Mandal_tbl').dataTable().fnClearTable();
    $('#dt_Mandal_tbl').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_Mandal_tbl_filter').hide();

    //Back Buttons
    $('#distbackid').hide();

    
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
   
    
});

function Get_Districts(val) {
    add_dateYD();
    //Mandal Hide Here
    $('#dt_Mandal_tbl').dataTable().fnClearTable();
    $('#dt_Mandal_tbl').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_Mandal_tbl_filter').hide();
    
    //Back Buttons
    $('#distbackid').hide();

    $('.preloader').fadeIn(5000, function () {
	var printCounter=0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLandstatusBeneficiary_report',
        data: "{ 'type':'Status'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('.preloader').fadeIn(1000, function () {
                $('#dt_dist_tbl').show();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').DataTable({
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

                                    return 'District wise Beneficiarywise Land Status Report ';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'District Wise Beneficiarywise Land Status Report',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'District Wise Beneficiarywise Land Status Report',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District Wise Beneficiarywise Land Status Report',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise Beneficiarywise Land Status Report';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                       
                    ],



                    'columnDefs': [
                        {
                            "targets": [1,2],
                            "className": "text-left"

                        },
                        {
                            "targets": [0,3, 4, 5,6,7,8],
                            "className": "text-right"

                        }

                    ],
                    fixedColumns: true,

                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'TOTAL' && data.ITDA_NAME != "Total") {
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
                                else if (data.DISTRICT == 'NULL') {
                                    return "<h6  text-decoration: color:blue;'>" + data.DISTRICT + "</h6>";
                                }
                                else {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "<a/>";
                                }
                               
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NO_OF_BENEFICIARIES'];
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

                                return s['UPTOYES_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['UPTOYES_TOTAL_EXTENT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TODAY_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TODAY_TOTAL_EXTENT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CUM_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CUM_TOTAL_EXTENT'];
                            }
                        },

                    ]

                });
                    $('.preloader').fadeOut(1000)
                })
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
        $('.preloader').fadeOut(5000)
    })
}
function Get_Mandals(data) {
    add_dateYDM();
    add_dateToDayM();
    add_datecumMM();
    //Mandal Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').show();

    //append label 
    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.DISTRICT);
    $('.preloader').show();
    var count = 0;
	var printCounter=0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLandstatusBeneficiary_report',
        data: "{ 'type':'Mandal','Itda':'" + data.ITDA_NAME + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",
       
        success: function (response) {

            if (response.Status == "1") {
               

                $('#dt_Mandal_tbl').show();

                $('#dt_Mandal_tbl').dataTable().fnClearTable();
                $('#dt_Mandal_tbl').DataTable({
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

                                    return 'Mandal wise Beneficiarywise Land Status Report';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'Mandal wise Beneficiarywise Land Status Report',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Mandal wise Beneficiarywise Land Status Report',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Mandal wise Beneficiarywise Land Status Report',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Mandal wise Beneficiarywise Land Status Report';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                    ],



                    'columnDefs': [
                        {
                            "targets": [1, 2],
                            "className": "text-left"

                        },
                        {
                            "targets": [3, 4, 5,6,8],
                            "className": "text-right"

                        }

                    ],
                    fixedColumns: true,

                    columns: [
                        
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

                                return s['UPTOYES_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['UPTOYES_TOTAL_EXTENT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TODAY_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TODAY_TOTAL_EXTENT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CUM_NO_OF_FARMERS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CUM_TOTAL_EXTENT'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Mandal_tbl').dataTable().fnClearTable();
                $('#dt_Mandal_tbl').hide();
                $('#dt_Mandal_tbl_wrapper').hide();
                $('#dt_Mandal_tbl_filter').hide();

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

    //MandalAll hide here
    $('#dt_Mandal_tbl').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_Mandal_tbl_filter').hide();
    Get_Districts();
});

function add_dateYD() {
    var currentDate = new Date(), day = currentDate.getDate()-1,
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
    $('#asonYD').append(day1)
}

function add_dateToDay() {
    var currentDate = new Date(), day = currentDate.getDate(),
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
       $('#asontodayId').append(day1)
}

function add_datecum() {
    var currentDate = new Date(), day = currentDate.getDate(),
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
      $('#asontodayId1').append(day1)
}

function add_dateYDM() {
    var currentDate = new Date(), day = currentDate.getDate()-1,
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
    $('#asonYDM').append(day1)
}

function add_dateToDayM() {
    var currentDate = new Date(), day = currentDate.getDate(),
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
    $('#asontodayId2').append(day1)
}

function add_datecumMM() {
    var currentDate = new Date(), day = currentDate.getDate(),
        month = currentDate.getMonth() + 1, year = currentDate.getFullYear(),
        day1 = day + "." + month + "." + year;
    $('#asontodayId3').append(day1)
}
