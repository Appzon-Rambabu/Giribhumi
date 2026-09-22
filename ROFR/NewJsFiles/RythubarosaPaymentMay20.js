$(document).ready(function () {
    $('.preloader').show();
    Get_Districts();
    $('.preloader').hide();
})

function Get_Districts() {
    
    //var username = $("#ContentPlaceHolder1_username").text();
    //var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //All hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    //Village hide here
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //RPayment Success hide Here
    $('#dt_RPayment_Success_tbl').hide();
    $('#dt_RPayment_Success_tbl_wrapper').hide();
    $('#dt_RPayment_Success_tbl_filter').hide();
    //RPayment Rejected hide Here
    $('#dt_RPayment_Rejected_tbl').hide();
    $('#dt_RPayment_Rejected_tbl_wrapper').hide();
    $('#dt_RPayment_Rejected_tbl_filter').hide();

    $('#dt_Pending_tbl').hide();
    $('#dt_Pending_tbl_wrapper').hide();
    $('#dt_Pending_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#villagebackid').hide();
    var setType="1"
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'District','Itdastart':'" + ustart + "','Type':'" + setType + "','ITDANAME':'" + ITDANAME+"'}",
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
                                    return 'DISTRICT WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' DISTRICT WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' DISTRICT WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
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
                                if (data.District != 'Total:') {
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
                                return s['Itda_Name'];
                            }
                        },




                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.District == 'Total:') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.District + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_Mandal(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.District + "<a/>";
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Success'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Pending'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Rejected'];
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

    sessionStorage.setItem('itdaname', data.Itda_Name);
    sessionStorage.setItem('districtname', data.District);
    $('#itdaval1').text(data.Itda_Name);
    $('#distval1').text(data.District);
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    ////RPayment Success hide Here
    $('#dt_RPayment_Success_tbl').hide();
    $('#dt_RPayment_Success_tbl_wrapper').hide();
    $('#dt_RPayment_Success_tbl_filter').hide();
    ////RPayment Rejected hide Here
    $('#dt_RPayment_Rejected_tbl').hide();
    $('#dt_RPayment_Rejected_tbl_wrapper').hide();
    $('#dt_RPayment_Rejected_tbl_filter').hide();

    $('#dt_Pending_tbl').hide();
    $('#dt_Pending_tbl_wrapper').hide();
    $('#dt_Pending_tbl_filter').hide();
    ////Back Buttons
    $('#distbackid').show();
    $('#mandalbackid').hide();
    $('#villagebackid').hide();

    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'Mandal','District':'" + data.District + "','Itda':'" + data.Itda_Name + "'}",
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
                                    return 'MANDAL WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' MANDAL WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
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
                                if (data.Mandal != 'Total:') {
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

                                if (data.Mandal == 'Total:') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.Mandal + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Get_Village(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Mandal + "<a/>";
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Success'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Pending'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Payment_Rejected'];
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
function Get_Village(data) {
    
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    sessionStorage.setItem('mandal', data.Mandal);
    sessionStorage.setItem('village', data.Village);
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandal')
    $('#itdaval2').text(itdaname);
    $('#distval2').text(Dist);
    $('#manval2').text(mandal);
    //All hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    /*RPayment Success hide Here*/
    $('#dt_RPayment_Success_tbl').hide();
    $('#dt_RPayment_Success_tbl_wrapper').hide();
    $('#dt_RPayment_Success_tbl_filter').hide();
    ////RPayment Rejected hide Here
    $('#dt_RPayment_Rejected_tbl').hide();
    $('#dt_RPayment_Rejected_tbl_wrapper').hide();
    $('#dt_RPayment_Rejected_tbl_filter').hide();

    $('#dt_Pending_tbl').hide();
    $('#dt_Pending_tbl_wrapper').hide();
    $('#dt_Pending_tbl_filter').hide();
    ////Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').show();
    $('#villagebackid').hide();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'Village','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + data.Mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Village_tbl').show();
                $('#dt_Village_tbl').dataTable().fnClearTable();
                $('#dt_Village_tbl').DataTable({
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
                                    return 'VILLAGE WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' VILLAGE WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
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
                                if (data.Village != 'TOTAL' && data.Village != 'Total:') {
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
                                return s['Village'];
                            }


                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.Payment_Success > 0) {
                                    if (data.Village == 'Total:')
                                    {
                                    return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Payment_Success + "</h6>";
                                     }
                                
                                    else
                                    {
                                    return "<a id='dlcview' href='#'  onclick='return Get_RPaymentSuccess(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Payment_Success + "<a/>";
                                    }
                                }
                               else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Payment_Success + "<a/>";
                                }
                                

                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.Payment_Pending > 0) {
                                    if (data.Village == 'Total:') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Payment_Pending + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_RPaymentPending(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Payment_Pending + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Payment_Pending + "<a/>";
                                }
                                
                            }

                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.Payment_Rejected > 0) {
                                    if (data.Village == 'Total:') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Payment_Rejected + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_RPaymentRejected(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Payment_Rejected + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Payment_Rejected + "<a/>";
                                }
                               
                            }

                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Village_tbl').dataTable().fnClearTable();
                $('#dt_Village_tbl').hide();
                $('#dt_Village_tbl_wrapper').hide();
                $('#dt_Village_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_RPaymentSuccess(data) {
   
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    var mandal = sessionStorage.getItem('mandal');
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    $('#itdaval3').text(itdaname);
    $('#distval3').text(Dist);
    $('#manval3').text(mandal);
    $('#villageval').text(data.Village)
    //All hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    //All hide here
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //RPayment Rejected hide Here
    $('#dt_RPayment_Rejected_tbl').hide();
    $('#dt_RPayment_Rejected_tbl_wrapper').hide();
    $('#dt_RPayment_Rejected_tbl_filter').hide();

    $('#dt_Pending_tbl').hide();
    $('#dt_Pending_tbl_wrapper').hide();
    $('#dt_Pending_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#villagebackid').show();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'Psuccess','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "','Village':'" + data.Village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_RPayment_Success_tbl').show();

                $('#dt_RPayment_Success_tbl').dataTable().fnClearTable();
                $('#dt_RPayment_Success_tbl').DataTable({
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
                                    return 'SUCCESS WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'SUCCESS WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'SUCCESS WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'SUCCESS WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' SUCCESS WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [2,3,7],
                            "className": "text-left"
                        },
                    ],
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
                                return s['Benficiary_id'];
                            }


                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rofr_Pattadaar'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Father_Name'];
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

                                return s['BankAccountNo'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Ifsccode'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankname'];
                            }
                        },


                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_RPayment_Success_tbl').dataTable().fnClearTable();
                $('#dt_RPayment_Success_tbl').hide();
                $('#dt_RPayment_Success_tbl_wrapper').hide();
                $('#dt_RPayment_Success_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_RPaymentRejected(data) {
    
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    var mandal = sessionStorage.getItem('mandal');
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');

    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval4').text(mandal);
    $('#villageval4').text(data.Village)
    //All hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    //All hide here
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //RPayment Success hide Here
    $('#dt_RPayment_Success_tbl').hide();
    $('#dt_RPayment_Success_tbl_wrapper').hide();
    $('#dt_RPayment_Success_tbl_filter').hide();

    $('#dt_Pending_tbl').hide();
    $('#dt_Pending_tbl_wrapper').hide();
    $('#dt_Pending_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#villagebackid').show();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'Prejected','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "','Village':'" + data.Village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_RPayment_Rejected_tbl').show();

                $('#dt_RPayment_Rejected_tbl').dataTable().fnClearTable();
                $('#dt_RPayment_Rejected_tbl').DataTable({
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
                                    return 'REJECTED WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'REJECTED WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'REJECTED WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'REJECTED WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' REJECTED WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [2,3,7,8],
                            "className": "text-left"

                        },
                    ],
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
                                return s['Benficiary_id'];
                            }


                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rofr_Pattadaar'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Father_Name'];
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

                                return s['BankAccountNo'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Ifsccode'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankname'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rejected_Reason'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_RPayment_Rejected_tbl').dataTable().fnClearTable();
                $('#dt_RPayment_Rejected_tbl').hide();
                $('#dt_RPayment_Rejected_tbl_wrapper').hide();
                $('#dt_RPayment_Rejected_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_RPaymentPending(data) {
    
    //All hide here
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    var mandal = sessionStorage.getItem('mandal');
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');

    $('#itdaval5').text(itdaname);
    $('#distval5').text(Dist);
    $('#manval5').text(mandal);
    $('#villageval5').text(data.Village)

    //All hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();

    //All hide here
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //RPayment Success hide Here
    $('#dt_RPayment_Success_tbl').hide();
    $('#dt_RPayment_Success_tbl_wrapper').hide();
    $('#dt_RPayment_Success_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#villagebackid').show();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rythubarosa_May20',
        data: "{ 'type':'Pending','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "','Village':'" + data.Village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Pending_tbl').show();

                $('#dt_Pending_tbl').dataTable().fnClearTable();
                $('#dt_Pending_tbl').DataTable({
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
                                    return 'PENDING WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'PENDING WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'PENDING WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'PENDING WISE RYTHUBAROSA PAYMENT STATU-MAY-2020';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' PENDING WISE RYTHUBAROSA PAYMENT STATU-MAY-2020',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [2, 3, 7, 8],
                            "className": "text-left"

                        },
                    ],
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
                                return s['Benficiary_id'];
                            }


                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rofr_Pattadaar'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Father_Name'];
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

                                return s['BankAccountNo'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Ifsccode'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankname'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rejected_Reason'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Pending_tbl').dataTable().fnClearTable();
                $('#dt_Pending_tbl').hide();
                $('#dt_Pending_tbl_wrapper').hide();
                $('#dt_Pending_tbl_filter').hide();

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

    var Dist = sessionStorage.getItem('districtname');

    var data = {};
    data.District = Dist;
    data.Itda_Name = itdaname;
    Get_Mandal(data);
});
$('#villagebackid').click(function () {

    var mandal = sessionStorage.getItem('mandal');
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');

    var data = {};
    data.District = Dist;
    data.Mandal = mandal;
    data.Itda_Name = itdaname;
    Get_Village(data);
});