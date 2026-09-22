$(document).ready(function () {
    $('.preloader').show();
    Get_Districts();
    $('.preloader').hide();
})

function Get_Districts() {
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    /* All hide here*/
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    //HIDE HERE BENEFICIARYFAMILYTABLE
    $('#dt_BENEFICIARY_FAMILY_tbl').hide();
    $('#dt_BENEFICIARY_FAMILY_tbl_wrapper').hide();
    $('#dt_BENEFICIARY_FAMILY_tbl_filter').hide();

    $('#dt_Eligible_tbl').hide();
    $('#dt_Eligible_tbl_wrapper').hide();
    $('#dt_Eligible_tbl_filter').hide();

    $('#dt_INEligible_tbl').hide();
    $('#dt_INEligible_tbl_wrapper').hide();
    $('#dt_INEligible_tbl_filter').hide();
    ////Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    //$('#villagebackid').hide();
    var setType = "1"
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_Oct20',
        data: "{ 'type':'District','Itdastart':'" + ustart + "','ITDANAME':'" + ITDANAME + "'}",
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
                                    return 'DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            title: 'DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS OCT-20'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
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
                      

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME != 'Total') {
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

                                if (data.District == 'Total') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.District + "</h6>";

                                }
                                if (data.District == null) {
                                    return "";

                                }
                                else {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.District + "<a/>";
                                }
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL'];
                            }
                        },
                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Eligible'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Not_Eligible'];
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

function Get_Mandal(data) {
   
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#itdaval').text(data.ITDA_NAME);
    $('#distval').text(data.District);
    //HIDE HERE BENEFICIARYFAMILYTABLE
    $('#dt_BENEFICIARY_FAMILY_tbl').hide();
    $('#dt_BENEFICIARY_FAMILY_tbl_wrapper').hide();
    $('#dt_BENEFICIARY_FAMILY_tbl_filter').hide();

    $('#dt_Eligible_tbl').hide();
    $('#dt_Eligible_tbl_wrapper').hide();
    $('#dt_Eligible_tbl_filter').hide();

    $('#dt_INEligible_tbl').hide();
    $('#dt_INEligible_tbl_wrapper').hide();
    $('#dt_INEligible_tbl_filter').hide();
    // store values
    sessionStorage.setItem('itdaname', data.ITDA_NAME);
    sessionStorage.setItem('dist', data.District);
    //Back Buttons
    $('#distbackid').show();
    $('#mandalbackid').hide();

    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_Oct20',
        data: "{ 'type':'Mandal','Itda':'" + data.ITDA_NAME + "','District':'" + data.District + "'}",
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
                    pageLength: 20,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    ordering: false,
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'MANDAL WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [0],
                            "className": "text-right"

                        },
                        {
                            "targets": [1],
                            "className": "text-left"

                        },
                        {
                            "targets": [2, 3],
                            "className": "text-right"

                        }

                    ],
                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.Mandal != 'Total') {
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
                                return s['Mandal'];
                            }


                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['TOTAL'];
                            }


                        },
                       

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Eligible > 0) {
                                    if (data.Mandal == 'Total') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Eligible + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Eligible(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Eligible + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Eligible + "<a/>";
                                }

                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Not_Eligible > 0) {
                                    if (data.Mandal == 'Total') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Not_Eligible + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_NOTEligible(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Not_Eligible + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_Eligible + "<a/>";
                                }
                               
                            }

                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_tbl').dataTable().fnClearTable();
                $('#dt_mandal_tbl').hide();
                $('#dt_mandal_tbl_wrapper').hide();
                $('#dt_mandal_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_Eligible(data) {



    //Back Buttons
    $('#mandalbackid').show();
    $('#distbackid').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    $('#dt_INEligible_tbl').hide();
    $('#dt_INEligible_tbl_wrapper').hide();
    $('#dt_INEligible_tbl_filter').hide();
    // get values
    var itdaname = sessionStorage.getItem('itdaname');
    var district = sessionStorage.getItem('dist');

    //Append to Label
    $('#itdaval2').text(itdaname);
    $('#distval2').text(district);
    $('#manval2').text(data.Mandal);

    // Here download links show
    $('.preloader').show();
   
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_Oct20',
        data: "{ 'type':'Eligible','Itda':'" + itdaname + "','District':'" + district + "','Mandal':'" + data.Mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Eligible_tbl').show();
                $('#dt_Eligible_tbl').dataTable().fnClearTable();
                $('#dt_Eligible_tbl').DataTable({
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
                                    return 'Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [1, 3, 4, 6,9,10],
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

                                return s['VILLAGE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BENFICIARY_ID'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTADAAR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FATHER_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAAR_NO'];
                            }
                        },



                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BANK_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ACCOUNT_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['IFSC_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['STATUS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REMARKS_NEW'];
                            }
                        },
                       

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Eligible_tbl').dataTable().fnClearTable();
                $('#dt_Eligible_tbl').hide();
                $('#dt_Eligible_tbl_wrapper').hide();
                $('#dt_Eligible_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });

}

function Get_NOTEligible(data) {



    //Back Buttons
    $('#mandalbackid').show();
    $('#distbackid').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    // get values
    var itdaname = sessionStorage.getItem('itdaname');
    var district = sessionStorage.getItem('dist');

    //Append to Label
    $('#itdaval3').text(itdaname);
    $('#distval3').text(district);
    $('#manval3').text(data.Mandal);

    // Here download links show
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_Oct20',
        data: "{ 'type':'NotEligible','Itda':'" + itdaname + "','District':'" + district + "','Mandal':'" + data.Mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_INEligible_tbl').show();
                $('#dt_INEligible_tbl').dataTable().fnClearTable();
                $('#dt_INEligible_tbl').DataTable({
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
                                    return 'NOT_Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'NOT_Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'NOT_Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            text: '<i class="fas fa-file-csv"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'NOT_Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            title: 'NOT_Eligible WISE RYTHU BHAROSA PAYMENT STATUS OCT-20',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [1, 3, 4, 6,9,10],
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

                                return s['VILLAGE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BENFICIARY_ID'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTADAAR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FATHER_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAAR_NO'];
                            }
                        },




                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BANK_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ACCOUNT_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['IFSC_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['STATUS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REMARKS_NEW'];
                            }
                        },
                       

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_INEligible_tbl').dataTable().fnClearTable();
                $('#dt_INEligible_tbl').hide();
                $('#dt_INEligible_tbl_wrapper').hide();
                $('#dt_INEligible_tbl_filter').hide();

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
    //Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#villagebackid').hide();
    Get_Districts();
});
$('#mandalbackid').click(function () {
    var itdaname = sessionStorage.getItem('itdaname');
    var district = sessionStorage.getItem('dist');

    var data = {};
    data.District = district;
    data.ITDA_NAME = itdaname;
    Get_Mandal(data);
});
