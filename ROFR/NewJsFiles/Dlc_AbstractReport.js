$(function () {
   

    Get_Districts();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
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

    //Back Buttons
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();

    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    

});


function Get_Districts() {
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    /*$('.preloader').show();*/
   
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'District','Itdastart':'" + ustart + "','ITDANAME':'" + ITDANAME+"'}",
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

                                    return 'DISTRICT WISE DLC ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE DLC ABSTRACT  REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE DLC ABSTRACT  REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE DLC ABSTRACT  REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE DLC ABSTRACT  REPORT',
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
                    fixedColumns: true,

                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.DISTRICT != 'Total') {
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
                                if (data.DISTRICT != 'Total') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.DISTRICT + "<a/>";
                                }
                                
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_farmer_Plots'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Having_Dlc'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Not_Having_Dlc'];
                            }
                        },
                    ]

                });
                /*$('.preloader').hide();*/
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
    sessionStorage.setItem('itdaname', data.ITDA_NAME);
    sessionStorage.setItem('districtname', data.DISTRICT);
    sessionStorage.setItem('mandalname', data.MANDAL);
  
    /*append label */
    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.DISTRICT);
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
    //Back Buttons
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
    $('.preloader').show();

    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'Mandal','Itda':'" + data.ITDA_NAME + "','District':'" + data.DISTRICT + "'}",
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

                                    return 'MANDAL WISE DLC ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE DLC ABSTRACT REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
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

                        //        if (data.MANDAL != 'Total') {
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
                                if (data.MANDAL != 'Total') {
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
                                if (data.MANDAL != 'Total') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Villages(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MANDAL + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.MANDAL + "<a/>";
                                }

                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Farmer_Plots'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Having_Dlc'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.MANDAL == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_Having_Dlc + "<a/>";
                                }
                                else if (data.Not_Having_Dlc > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Nothavingdlc_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Not_Having_Dlc + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_Having_Dlc + "<a/>";
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
    sessionStorage.setItem('mandalname', data.MANDAL);
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
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
   
    $('.preloader').show();
  
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'Village','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
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
                                    return 'VILLAGE WISE LATLONGS REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE LATLONGS REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE LATLONGS REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE LATLONGS REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE LATLONGS REPORT',
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

                        //        if (data.VILLAGE != 'Total') {
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
                                if (data.VILLAGE != 'Total') {
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

                                return s['VILLAGE'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Farmer_Plots'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.VILLAGE == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Having_Dlc + "<a/>";
                                }
                                else if (data.Having_Dlc > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_vill_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Having_Dlc + "<a/>";
                                }
                                else {
                                   
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Having_Dlc + "<a/>";
                                }
                               
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.VILLAGE == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_Having_Dlc + "<a/>";
                                }
                                else if (data.Not_Having_Dlc > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_vill_not_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Not_Having_Dlc + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_Having_Dlc + "<a/>";
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
function Get_Nothavingdlc_man(data) {

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
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
   
    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    
    //Append to Label
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval4').text(data.MANDAL);
    
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'Not Having Dlc','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + data.MANDAL + "'}",
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
                                    return 'MANDAL WISE NOT HAVING DLC';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE NOT HAVING DLC',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE NOT HAVING DLC',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE NOT HAVING DLC';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE NOT HAVING DLC',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2, 3, 4, 5, 6, 7, 8, 10],
                            "className": "text-left"

                        },
                        // {
                        // "targets": [7, 8, 9, 10, 11],
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

                                return s['Village'];
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

                                return s['Plot_No'];
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

                                return s['Aadhaar_NO'];
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

                                return s['Dlc_date'];
                            }
                        },
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['dlc'];
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
    $('#villval').text(data.VILLAGE);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'IHaving','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.VILLAGE + "'}",
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
                                    return 'VILLAGE WISE  HAVING DLC';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE  HAVING DLC',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE  HAVING DLC',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE  HAVING DLC';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE  HAVING DLC',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2,3,4],
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
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Aadhaar_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Dlc_date'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (type === 'display') {
                                    data = '<a href="' + data.Dlcpath + '" target="_blank">View</a>';
                                }
                                return data;
                            },
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
    $('#villval6').text(data.VILLAGE);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDCL_Abstract_report',
        data: "{ 'type':'Nothaving','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.VILLAGE + "'}",
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
                                    return 'VILLAGE WISE NOT HAVING DLC';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE NOT HAVING DLC',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE NOT HAVING DLC',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE NOT HAVING DLC';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE NOT HAVING DLC',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2,3,4],
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
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Aadhaar_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Dlc_date'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['dlc'];
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

$('#distbackid').click(function () {
    Get_Districts();
    //MandalAll hide here
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
    data.DISTRICT = Dist;
    data.ITDA_NAME = itdaname;

    Get_Mandals(data);
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    $('#villbackid').hide();
    $('#distbackid').show();

});
$('#villbackid').click(function (data) {
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');

    var data = {};
    data.DISTRICT= Dist;
    data.MANDAL = mandal;
    data.ITDA_NAME = itdaname;

    Get_Villages(data);
    //village not having table hide here
    $('#dt_vil_not_having_tbl').hide();
    $('#dt_vil_not_having_tbl_wrapper').hide();
    $('#dt_vil_not_having_tbl_filter').hide();
    $('#villbackid').hide();
    $('#distbackid').hide();
    $('#manbackid').show();
});