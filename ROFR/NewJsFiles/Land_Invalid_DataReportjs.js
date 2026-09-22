$(document).ready(function () {

    
    Get_Districts();
    //HERE DUPLICATE HIDE
    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();
    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();

    //Here Father Hide
    $('#dt_Father_tbl').hide();
    $('#dt_Father_tbl_wrapper').hide();
    $('#dt_Father_tbl_filter').hide();
    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();

    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();


});

function Get_Districts() {
    
   
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Here Duplicate hide
    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();
    //Here Invaild hide
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();

    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'District','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME+"'}",
        dataType: "json",
       
        success: function (response) {

            if (response.Status == "1") {

                /*Total adding Here*/
                var Acol = 0; var Bcol = 0; var Ccol = 0; var Dcol = 0; var Ecol = 0; var Fcol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Acol += response.Data[i].DUPLICATE_AADHAAR;
                    Bcol += response.Data[i].INVALID_AADHAARS;
                    Ccol += response.Data[i].FATHERNAME_NULL;
                    Dcol += response.Data[i].LOCATION_NULL;
                    Ecol += response.Data[i].LANDDETAILS_INVALID;
                    Fcol += response.Data[i].Extent_10_Acrs;

                }
                res.push({ 'ITDA': '', 'DISTRICT': 'TOTAL', 'DUPLICATE_AADHAAR': Acol, 'INVALID_AADHAARS': Bcol, 'FATHERNAME_NULL': Ccol, 'LOCATION_NULL': Dcol, 'LANDDETAILS_INVALID': Ecol, 'Extent_10_Acrs': Fcol });
                $('.preloader').fadeIn(5000, function () {
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

                                    return 'DISTRICT WISE LAND INVALID DATA REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE LAND INVALID DATA REPORT',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE LAND INVALID DATA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE LAND INVALID DATA REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE LAND INVALID DATA REPORT',
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

                        // {
                        // "targets": [3, 4, 5],
                        // "className": "text-right"

                        // }

                    ],
                    fixedColumns: true,

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.DISTRICT != 'TOTAL') {
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
                                if (data.DISTRICT != 'TOTAL') {
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

                                if (data.DUPLICATE_AADHAAR > 0) {

                                    if (data.DUPLICATE_AADHAAR == Acol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.DUPLICATE_AADHAAR + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Duplicates(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DUPLICATE_AADHAAR + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Duplicates(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DUPLICATE_AADHAAR + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.DUPLICATE_AADHAAR + "<a/>";
                                }

                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.INVALID_AADHAARS > 0) {

                                    if (data.INVALID_AADHAARS == Bcol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.INVALID_AADHAARS + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Invailds(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.INVALID_AADHAARS + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Invailds(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.INVALID_AADHAARS + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.INVALID_AADHAARS + "<a/>";
                                }

                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.FATHERNAME_NULL > 0) {

                                    if (data.FATHERNAME_NULL == Ccol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.FATHERNAME_NULL + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Father_Null(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.FATHERNAME_NULL + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Father_Null(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.FATHERNAME_NULL + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.FATHERNAME_NULL + "<a/>";
                                }



                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.LOCATION_NULL > 0) {

                                    if (data.LOCATION_NULL == Dcol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LOCATION_NULL + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Location(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LOCATION_NULL + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Location(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LOCATION_NULL + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LOCATION_NULL + "<a/>";
                                }



                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.LANDDETAILS_INVALID > 0) {

                                    if (data.LANDDETAILS_INVALID == Ecol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LANDDETAILS_INVALID + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Land(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LANDDETAILS_INVALID + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Land(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LANDDETAILS_INVALID + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LANDDETAILS_INVALID + "<a/>";
                                }



                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Extent_10_Acrs > 0) {

                                    if (data.Extent_10_Acrs == Fcol) {
                                        if (data.DISTRICT == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Extent_10_Acrs + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Extent(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Extent_10_Acrs + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Extent(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Extent_10_Acrs + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Extent_10_Acrs + "<a/>";
                                }



                            }

                        },

                    ]

                });
                    $('.preloader').hide();
                    $('.preloader').fadeOut(5000)
                });
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
function Get_Duplicates(data) {

    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
  
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
    $('.preloader').show();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval1').text(data.ITDA);
    $('#distval1').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'Duplicate','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Duplicate_tbl').show();

                $('#dt_Duplicate_tbl').dataTable().fnClearTable();
                $('#dt_Duplicate_tbl').DataTable({
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

                                    return 'DUPLICATE AADHAARS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: ' DUPLICATE AADHAARS',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' DUPLICATE AADHAARS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return ' DUPLICATE AADHAARS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' DUPLICATE AADHAARS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [2, 3, 4, 5],
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
                                return s['benficiary_id'];
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

                                return s['Village'];
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

                                return s['Father_Name'];
                            }
                        },
                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAAR_NO'];
                            }
                        },
                        

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Duplicate_tbl').dataTable().fnClearTable();
                $('#dt_Duplicate_tbl').hide();
                $('#dt_Duplicate_tbl_wrapper').hide();
                $('#dt_Duplicate_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_Invailds(data) {

    //District Hide Here

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();
   
    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();

    $('.preloader').show();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval2').text(data.ITDA);
    $('#distval2').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'Invalid','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Invaild_tbl').show();

                $('#dt_Invaild_tbl').dataTable().fnClearTable();
                $('#dt_Invaild_tbl').DataTable({
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

                                    return 'INVAILD AADHAARS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: ' INVAILD AADHAARS',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' INVAILD AADHAARS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return ' INVAILD AADHAARS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' INVAILD AADHAARS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [2, 3, 4, 5],
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
                                return s['benficiary_id'];
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

                                return s['Village'];
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

                                return s['Father_Name'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAAR_NO'];
                            }
                        },


                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Invaild_tbl').dataTable().fnClearTable();
                $('#dt_Invaild_tbl').hide();
                $('#dt_Invaild_tbl_wrapper').hide();
                $('#dt_Invaild_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_Father_Null(data) {

    //District Hide Here

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();

    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
    $('.preloader').show();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval3').text(data.ITDA);
    $('#distval3').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'Father','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Father_tbl').show();

                $('#dt_Father_tbl').dataTable().fnClearTable();
                $('#dt_Father_tbl').DataTable({
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

                                    return 'FATHER NAME NULL';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FATHER NAME NULL',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FATHER NAME NULL',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'FATHER NAME NULL';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FATHER NAME NULL',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [2, 3, 4, 5],
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
                                return s['benficiary_id'];
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

                                return s['Village'];
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

                                return s['Father_Name'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAAR_NO'];
                            }
                        },


                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Father_tbl').dataTable().fnClearTable();
                $('#dt_Father_tbl').hide();
                $('#dt_Father_tbl_wrapper').hide();
                $('#dt_Father_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_Location(data) {

    //District Hide Here

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();

    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Father Hide
    $('#dt_Father_tbl').hide();
    $('#dt_Father_tbl_wrapper').hide();
    $('#dt_Father_tbl_filter').hide();
    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
    $('.preloader').show();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval4').text(data.ITDA);
    $('#distval4').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'Location','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Location_tbl').show();

                $('#dt_Location_tbl').dataTable().fnClearTable();
                $('#dt_Location_tbl').DataTable({
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

                                    return 'LOCATION DETAILS NULL';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'LOCATION DETAILS NULL',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'LOCATION DETAILS NULL',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'LOCATION DETAILS NULL';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'LOCATION DETAILS NULL',
                             text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 8,9],
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
                                return s['ID'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['benficiary_id2'];
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

                                return s['Gram_Panchayat'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_Village'];
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

                                return s['Habitation'];
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

                                return s['Father_Name'];
                            }
                        },


                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Location_tbl').dataTable().fnClearTable();
                $('#dt_Location_tbl').hide();
                $('#dt_Location_tbl_wrapper').hide();
                $('#dt_Location_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Get_Land(data) {

    //District Hide Here

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    // Here duplicate Hide
    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();
    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Father Hide
    $('#dt_Father_tbl').hide();
    $('#dt_Father_tbl_wrapper').hide();
    $('#dt_Father_tbl_filter').hide();
    // Here Land Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    $('.preloader').show();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval5').text(data.ITDA);
    $('#distval5').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'Land','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Land_tbl').show();

                $('#dt_Land_tbl').dataTable().fnClearTable();
                $('#dt_Land_tbl').DataTable({
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

                                    return 'Land details-Invalid/Null';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'Land details-Invalid/Null',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'Land details-Invalid/Null',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Land details-Invalid/Null';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'Land details-Invalid/Null',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',


                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 7, 8,9],
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
                                return s['ID'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['benficiary_id2'];
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

                                return s['Gram_Panchayat'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REV_Village'];
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

                                return s['Habitation'];
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

                                return s['Father_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Compartment_No'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTANO'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Plot_No'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ExtentPlotArea'];
                            }
                        },


                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Land_tbl').dataTable().fnClearTable();
                $('#dt_Land_tbl').hide();
                $('#dt_Land_tbl_wrapper').hide();
                $('#dt_Land_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_Extent(data) {

    //District Hide Here

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    // Here duplicate Hide
    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();
    //HERE INVAILD HIDE
    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();
    //Here Father Hide
    $('#dt_Father_tbl').hide();
    $('#dt_Father_tbl_wrapper').hide();
    $('#dt_Father_tbl_filter').hide();
    // Here Land Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();
    $('.preloader').show();
    //Back Buttons
    $('#distbackid').show();
    /*append label */
    $('#itdaval6').text(data.ITDA);
    $('#distval6').text(data.DISTRICT);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLand_Invalid_Data_report',
        data: "{ 'type':'>10','Itda':'" + data.ITDA + "','District':'" + data.DISTRICT + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Extent_tbl').show();

                $('#dt_Extent_tbl').dataTable().fnClearTable();
                $('#dt_Extent_tbl').DataTable({
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

                                    return 'Extent >10 Acrs';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'Extent >10 Acrs',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'Extent >10 Acrs',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Extent >10 Acrs';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'Extent >10 Acrs',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',


                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 7, 8,15],
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
                                return s['ID'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['benficiary_id2'];
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

                                return s['Gram_Panchayat'];
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

                                return s['Habitation'];
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

                                return s['Father_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Compartment_No'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ExtentPlotArea'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTANO'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Aadhaar_NO'];
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

                                return s['IfscCode'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BankName'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Extent_tbl').dataTable().fnClearTable();
                $('#dt_Extent_tbl').hide();
                $('#dt_Extent_tbl_wrapper').hide();
                $('#dt_Extent_tbl_filter').hide();

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
    Get_Districts();
    //MandalAll hide here
    $('#dt_Duplicate_tbl').hide();
    $('#dt_Duplicate_tbl_wrapper').hide();
    $('#dt_Duplicate_tbl_filter').hide();

    $('#dt_Invaild_tbl').hide();
    $('#dt_Invaild_tbl_wrapper').hide();
    $('#dt_Invaild_tbl_filter').hide();

    //Here Father Hide
    $('#dt_Father_tbl').hide();
    $('#dt_Father_tbl_wrapper').hide();
    $('#dt_Father_tbl_filter').hide();
    //Here Location Hide
    $('#dt_Location_tbl').hide();
    $('#dt_Location_tbl_wrapper').hide();
    $('#dt_Location_tbl_filter').hide();

    //Here Land Hide
    $('#dt_Land_tbl').hide();
    $('#dt_Land_tbl_wrapper').hide();
    $('#dt_Land_tbl_filter').hide();
    //Here Extent table Hide
    $('#dt_Extent_tbl').hide();
    $('#dt_Extent_tbl_wrapper').hide();
    $('#dt_Extent_tbl_filter').hide();
});