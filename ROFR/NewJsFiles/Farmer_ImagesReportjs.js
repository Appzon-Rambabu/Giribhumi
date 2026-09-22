$(function () {
    

    Get_Districts();
    // Here download links show
    $('#dld_NotUploadDataID').show();

   //Mandal table Hide Here
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Village table Hide Here
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    // Mandal Not having table hide here
    $('#dt_man_NotHaving_tbl').hide();
    $('#dt_man_NotHaving_tbl_wrapper').hide();
    $('#dt_man_NotHaving_tbl_filter').hide();
    //Village Having Table hide here
    $('#dt_vil_having_tbl').hide();
    $('#dt_vil_having_tbl_wrapper').hide();
    $('#dt_vil_having_tbl_filter').hide();
     //Village Not Having Table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();

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

    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();

    // Here download links show
    $('#dld_NotUploadDataID').show();
    $('.preloader').show();
    
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'FDistrict','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME+"'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
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

                                    return 'DISTRICT WISE FARMER IMAGES REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE FARMER IMAGES REPORT',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE FARMER IMAGES REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE FARMER IMAGES REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE FARMER IMAGES REPORT',
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
                                if (data.district != 'Total') {
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
                                return s['itda_name'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.district == 'Total') 
								{
                                    return "<a id='dlcview' href='#' style='color:black;'>" + data.district + "<a/>";
                                }
								else if (data.district == null) {
                                   
                                    return '';

                                }
                                else 
								{
                                     return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.district + "<a/>";
                                }

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['total_beneficiaries'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['having_image'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_having_image'];
                            }
                        },
                    ]

                });
                    /*$('.preloader').hide();*/
                    $('.preloader').fadeOut(2000)
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


}
function Get_Mandals(data) {

    /*store value*/
    sessionStorage.setItem('itdaname', data.itda_name);
    sessionStorage.setItem('districtname', data.district);

    /*append label */
    $('#itdaval1').text(data.itda_name);
    $('#distval1').text(data.district);
    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();

    //Mandal wise not having
    $('#dt_man_NotHaving_tbl').dataTable().fnClearTable();
    $('#dt_man_NotHaving_tbl').hide();
    $('#dt_man_NotHaving_tbl_wrapper').hide();
    $('#dt_man_NotHaving_tbl_filter').hide();
    //Village wise  having
    $('#dt_vil_having_tbl').dataTable().fnClearTable();
    $('#dt_vil_having_tbl').hide();
    $('#dt_vil_having_tbl_wrapper').hide();
    $('#dt_vil_having_tbl_filter').hide();
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('.preloader').show();

    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'FMandal','Itda':'" + data.itda_name + "','District':'" + data.district + "'}",
        dataType: "json",

        success: function (response) {
            if (response.Status == "1") {

                $('#dt_man_tbl').show();

                $('#dt_man_tbl').dataTable().fnClearTable();
                $('#dt_man_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                   /* pageLength: 50,*/
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

                                    return 'MANDAL WISE DLC ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE DLC ABSTRACT REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE DLC ABSTRACT REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'MANDAL WISE DLC ABSTRACT REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE DLC ABSTRACT REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [1],
                            "className": "text-left"

                        },


                    ],
                    fixedColumns: true,

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.mandal != 'Total') {
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
                                if (data.mandal != 'Total') {
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
                                if (data.mandal != 'Total') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Villages(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.mandal + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.mandal + "<a/>";
                                }

                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['total_beneficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['having_image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.mandal == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.not_having_image + "<a/>";
                                }
                                else if (data.not_having_image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Nothaving_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.not_having_image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.not_having_image + "<a/>";
                                }

                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_man_tbl').dataTable().fnClearTable();
                $('#dt_man_tbl').hide();
                $('#dt_man_tbl_wrapper').hide();
                $('#dt_man_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Get_Villages(data) {

    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    //store value
    sessionStorage.setItem('mandalname', data.mandal);
    var mandal = sessionStorage.getItem('mandalname');
    //Append to Label
    $('#itdaval2').text(itdaname);
    $('#distval2').text(Dist);
    $('#manval').text(mandal);
    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Mandal wise not having
    $('#dt_man_NotHaving_tbl').dataTable().fnClearTable();
    $('#dt_man_NotHaving_tbl').hide();
    $('#dt_man_NotHaving_tbl_wrapper').hide();
    $('#dt_man_NotHaving_tbl_filter').hide();
    //Village wise  having
    $('#dt_vil_having_tbl').dataTable().fnClearTable();
    $('#dt_vil_having_tbl').hide();
    $('#dt_vil_having_tbl_wrapper').hide();
    $('#dt_vil_having_tbl_filter').hide();
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('.preloader').show();

    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'FVillage','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
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
                                    return 'VILLAGE WISE FARMER IMAGES REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE FARMER IMAGES REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE FARMER IMAGES REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE FARMER IMAGES REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE FARMER IMAGES REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [1],
                            "className": "text-left"

                        },


                    ],
                    fixedColumns: true,

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.village != 'Total') {
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
                                if (data.village != 'Total') {
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

                                return s['village'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['total_beneficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.village == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.having_image + "<a/>";
                                }
                                else if (data.having_image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_vill_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.having_image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.having_image + "<a/>";
                                }

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.village == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.not_having_image + "<a/>";
                                }
                                else if (data.not_having_image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_vill_not_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.not_having_image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.not_having_image + "<a/>";
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
function Get_Nothaving_man(data) {
    sessionStorage.setItem('mandalname', data.mandal);
    var mandal = sessionStorage.getItem('mandalname');
    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Mandal_Lessthan4 hide here
    $('#dt_mandal_les_tbl').dataTable().fnClearTable();
    $('#dt_mandal_les_tbl').hide();
    $('#dt_mandal_les_tbl_wrapper').hide();
    $('#dt_mandal_les_tbl_filter').hide();

    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Village wise  having
    $('#dt_vil_having_tbl').dataTable().fnClearTable();
    $('#dt_vil_having_tbl').hide();
    $('#dt_vil_having_tbl_wrapper').hide();
    $('#dt_vil_having_tbl_filter').hide();
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    
    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
    //Append to Label
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval4').text(mandal);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'IMAGES NOT UPLOADED','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_man_NotHaving_tbl').show();

                $('#dt_man_NotHaving_tbl').dataTable().fnClearTable();
                $('#dt_man_NotHaving_tbl').DataTable({
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
                                    return 'MANDAL WISE NOT HAVING FARMER IMAGES';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE NOT HAVING FARMER IMAGES',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE NOT HAVING FARMER IMAGES',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE NOT HAVING FARMER IMAGES';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE NOT HAVING FARMER IMAGES',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2, 3, 4, 5, 6, 7, 8, 9],
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

                                return s['Benficiary_Id'];
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

                                return s['District'];
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
                       
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_man_NotHaving_tbl').dataTable().fnClearTable();
                $('#dt_man_NotHaving_tbl').hide();
                $('#dt_man_NotHaving_tbl_wrapper').hide();
                $('#dt_man_NotHaving_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_vill_having(data) {

    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandalname = sessionStorage.getItem('mandalname');
    //Append to Label
    $('#itdaval3').text(itdaname);
    $('#distval3').text(Dist);
    $('#manval3').text(mandalname);
    $('#villval').text(data.village);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'Having','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_vil_having_tbl').show();
                $('#dt_vil_having_tbl').dataTable().fnClearTable();
                $('#dt_vil_having_tbl').DataTable({
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
                                    return 'VILLAGE WISE IMAGES UPLOADED';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE IMAGES UPLOADED',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE IMAGES UPLOADED',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE IMAGES UPLOADED';
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
                            title: 'VILLAGE WISE IMAGES UPLOADED',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2, 3],
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

                                return s['Benficiary_Id'];
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

                                return s['AADHAAR_NO'];
                            }
                        },
                        
                        

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_vil_having_tbl').dataTable().fnClearTable();
                $('#dt_vil_having_tbl').hide();
                $('#dt_vil_having_tbl_wrapper').hide();
                $('#dt_vil_having_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}
function Get_vill_not_having(data) {

    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();

    //Not Upload Table Hide Here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandalname = sessionStorage.getItem('mandalname');
    //Append to Label
    $('#itdaval6').text(itdaname);
    $('#distval6').text(Dist);
    $('#manval6').text(mandalname);
    $('#villval6').text(data.village);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
   
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'Nothaving','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_vil_not_having_tbl').show();
                $('#dt_vil_not_having_tbl').dataTable().fnClearTable();
                $('#dt_vil_not_having_tbl').DataTable({
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
                                    return 'VILLAGE WISE IMAGES NOT UPLOADED';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE IMAGES NOT UPLOADED',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE IMAGES NOT UPLOADED',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE IMAGES NOT UPLOADED';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE IMAGES NOT UPLOADED',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2, 3],
                            "className": "text-left"

                        },
                    //     {
                    //     "targets": [3, 4, 5],
                    //     "className": "text-right"

                    //     }

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

                                return s['Benficiary_Id'];
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

                                return s['AADHAAR_NO'];
                            }
                        },



                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_vil_not_having_tbl').dataTable().fnClearTable();
                $('#dt_vil_not_having_tbl').hide();
                $('#dt_vil_not_having_tbl_wrapper').hide();
                $('#dt_vil_not_having_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Download_NotUploadData(data) {
    $('.preloader').show();
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Mandal Rejected Hide Here
    $('#dt_mandal_rej_tbl').dataTable().fnClearTable();
    $('#dt_mandal_rej_tbl').hide();
    $('#dt_mandal_rej_tbl_wrapper').hide();
    $('#dt_mandal_rej_tbl_filter').hide();
    //Mandal_Lessthan4 hide here
    $('#dt_mandal_les_tbl').dataTable().fnClearTable();
    $('#dt_mandal_les_tbl').hide();
    $('#dt_mandal_les_tbl_wrapper').hide();
    $('#dt_mandal_les_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').hide();
    $('#distbackid').show();
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetFarmer_Images_report',
        data: "{ 'type':'INDistrict','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME +"'}",
        dataType: "json",
        success: function (response) {
            if (response.Status == "1") {
                $('#dt_Not_Upload_tbl').show();

                $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
                $('#dt_Not_Upload_tbl').DataTable({
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
                                    return 'FARMER IMAGES NOT UPLOADED DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FARMER IMAGES NOT UPLOADED DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FARMER IMAGES NOT UPLOADED DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'FARMER IMAGES NOT UPLOADED DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FARMER IMAGES NOT UPLOADED DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2,3, 4, 5, 6, 7, 8, 9, 10],
                            "className": "text-left"

                        },
                        // {
                        // "targets": [0, 1, 2,11,12,13],
                        // "className": "text-right"

                        // }

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

                                return s['Benficiary_Id'];
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

                                return s['District'];
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

                                return s['AADHAAR_NO'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
                $('#dt_Not_Upload_tbl').hide();
                $('#dt_Not_Upload_tbl_wrapper').hide();
                $('#dt_Not_Upload_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }


        }
    });

}
$('#distbackid').click(function () {
    Get_Districts();
    //MandalAll hide here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();

    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    $('#villbackid').hide();
    $('#distbackid').hide();
    $('#manbackid').hide();
});
$('#manbackid').click(function () {
    var itdaname = sessionStorage.getItem('itdaname');

    var Dist = sessionStorage.getItem('districtname');

    var data = {};
    data.district = Dist;
    data.itda_name = itdaname;

    Get_Mandals(data);
    //village not having table hide here
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();

    $('#villbackid').hide();
    $('#distbackid').show();
    $('#manbackid').hide();
});
$('#villbackid').click(function (data) {
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');

    var data = {};
    data.district = Dist;
    data.mandal = mandal;
    data.itda_name = itdaname;

    Get_Villages(data);
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();

    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();

    $('#villbackid').hide();
    $('#distbackid').hide();
    $('#manbackid').show();
});