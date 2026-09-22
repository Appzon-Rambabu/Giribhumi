


 $(function () {

        // Here download links show
        $('#dld_NotUploadDataID').show();
        $('#dld_Lessthan4ID').show();

        //Mandal Hide Here
        $('#dt_man_tbl').dataTable().fnClearTable();
        $('#dt_man_tbl').hide();
        $('#dt_man_tbl_wrapper').hide();
        $('#dt_man_tbl_filter').hide();
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
        //Village Hide Here
        $('#dt_Village_tbl').dataTable().fnClearTable();
        $('#dt_Village_tbl').hide();
        $('#dt_Village_tbl_wrapper').hide();
        $('#dt_Village_tbl_filter').hide();
        //Village Rejected Hide Here
        $('#dt_vil_rej_tbl').dataTable().fnClearTable();
        $('#dt_vil_rej_tbl').hide();
        $('#dt_vil_rej_tbl_wrapper').hide();
        $('#dt_vil_rej_tbl_filter').hide();
        //Village Having Hide Here
        $('#dt_vill_hav_tbl').dataTable().fnClearTable();
        $('#dt_vill_hav_tbl').hide();
        $('#dt_vill_hav_tbl_wrapper').hide();
        $('#dt_vill_hav_tbl_filter').hide();

        //Lessthan4 LatLongsTable Hide Here
        $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
        $('#dt_download_latlongs_tbl').hide();
        $('#dt_download_latlongs_tbl_wrapper').hide();
        $('#dt_download_latlongs_tbl_filter').hide();
        //Lessthan4 LatLongsTable Hide Here
        $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
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

        Get_Districts();


    });
    

function Get_Districts() {
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
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
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Village Rejected Hide Here
    $('#dt_vil_rej_tbl').dataTable().fnClearTable();
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();
    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').hide();
    $('#manbackid').hide();
   
    // Here download links show
    $('#dld_NotUploadDataID').show();
    $('#dld_Lessthan4ID').show();
    /*$('.preloader').show();*/
    
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'FDistrict','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Acol = 0; var Bcol = 0; var Ccol = 0; var Dcol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Acol += response.Data[i].total_benficiaries;
                    Bcol += response.Data[i].total_plots;
                    Ccol += response.Data[i].plots_having_latlongs;
                    Dcol += response.Data[i].plots_not_having_latlongs;
                    Ecol += response.Data[i].LATLONGS_LESSTHAN_4;

                }
                res.push({ 'itda_name': '', 'district': 'TOTAL', 'total_benficiaries': Acol, 'total_plots': Bcol, 'plots_having_latlongs': Ccol, 'plots_not_having_latlongs': Dcol, 'LATLONGS_LESSTHAN_4': Ecol });

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

                                        return 'DISTRICT WISE LATLONGS REPORT';

                                    }

                                },
                                messageBottom: null
                            },
                            {
                                extend: 'excelHtml5',
                                title: 'DISTRICT WISE LATLONGS REPORT',
                                text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'

                            },
                            {
                                extend: 'csvHtml5',
                                title: 'DISTRICT WISE LATLONGS REPORT',
                                text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                            },
                            {
                                extend: 'print',
                                text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                                messageTop: function () {
                                    printCounter++;

                                    if (printCounter === 1) {
                                        return 'DISTRICT WISE LATLONGS REPORT';

                                    }
                                    else {
                                        return 'You have printed this document ' + printCounter + ' times';
                                    }
                                },
                                messageBottom: null
                            },
                            {
                                extend: 'pdfHtml5',
                                title: 'DISTRICT WISE LATLONGS REPORT',
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
                                    if (data.district != 'TOTAL') {
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

                                    if (data.district == 'TOTAL') {
                                        return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.district + "</h6>";

                                    }
                                    else if (data.district != 'Total') {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.district + "<a/>";
                                    }
                                    else {
                                        return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.district + "<a/>";
                                    }


                                }

                            },

                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['total_benficiaries'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['total_plots'];
                                }
                            },

                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['plots_having_latlongs'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['plots_not_having_latlongs'];
                                }
                            },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return s['LATLONGS_LESSTHAN_4'];
                                }
                            },

                        ],
                        "initComplete": () => {
                            $("#dt_dist_tbl").show();
                        }
                    });
                   
                    $('.preloader').fadeOut(5000)
                });
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_dist_tbl_wrapper').hide();
                $('#dt_dist_tbl_filter').hide();

               /* $('.preloader').hide();*/
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
    //Mandal Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
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
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Village Rejected Hide Here
    $('#dt_vil_rej_tbl').dataTable().fnClearTable();
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();

    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
    $('#dwnld_latlongs').hide();
    $('#NotUploadID').hide();
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();

    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'FMandal','Itda':'" + data.itda_name + "','District':'" + data.district + "'}",
        dataType: "json",
        
        success: function (response) {
            if (response.Status == "1") {
                //Total adding Here
                var Acol = 0; var Bcol = 0; var Ccol = 0; var Dcol = 0; var Ecol = 0;
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Acol += response.Data[i].total_benficiaries;
                    Bcol += response.Data[i].total_plots;
                    Ccol += response.Data[i].plots_having_latlongs;
                    Dcol += response.Data[i].plots_not_having_latlongs;
                    Ecol += response.Data[i].LATLONGS_LESSTHAN_4;
                }
                res.push({ 'mandal': 'TOTAL', 'total_benficiaries': Acol, 'total_plots': Bcol, 'plots_having_latlongs': Ccol, 'plots_not_having_latlongs': Dcol, 'LATLONGS_LESSTHAN_4': Ecol });

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
                    data:res,
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

                                    return 'MANDAL WISE LATLONGS REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE LATLONGS REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE LATLONGS REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'MANDAL WISE LATLONGS REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE LATLONGS REPORT',
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

                        //        if (data.mandal != 'TOTAL') {
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
                                if (data.mandal != 'TOTAL') {
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

                                if (data.mandal == 'TOTAL') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.mandal + "</h6>";

                                } else if (data.mandal != 'Total') {
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

                                return s['total_benficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['total_plots'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['plots_having_latlongs'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                
                                if (data.plots_not_having_latlongs > 0) {

                                    if (data.plots_not_having_latlongs == Dcol) {
                                        if (data.mandal == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Rejected_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Rejected_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                    }

                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                }

                                

                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                

                                if (data.LATLONGS_LESSTHAN_4 > 0) {

                                    if (data.LATLONGS_LESSTHAN_4 == Ecol) {
                                        if (data.mandal == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LATLONGS_LESSTHAN_4 + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Lessthan4Details_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LATLONGS_LESSTHAN_4 + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Lessthan4Details_man(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.LATLONGS_LESSTHAN_4 + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.LATLONGS_LESSTHAN_4 + "<a/>";
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


function Get_Rejected_man(data) {

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
    //Village Rejected Hide Here
    $('#dt_vil_rej_tbl').dataTable().fnClearTable();
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();

    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    $('#dwnld_latlongs').hide();
    $('#NotUploadID').hide();
    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    //Append to Label
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval4').text(data.mandal);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'Plots not having latlongs','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + data.mandal + "'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_mandal_rej_tbl').show();

                $('#dt_mandal_rej_tbl').dataTable().fnClearTable();
                $('#dt_mandal_rej_tbl').DataTable({
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
                                    return 'MANDAL WISE NOT HAVING LATLONGS';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE NOT HAVING LATLONGS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE NOT HAVING LATLONGS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE NOT HAVING LATLONGS';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE NOT HAVING LATLONGS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [2,3, 4,5,6,7,8,10],
                            "className": "text-left"

                        },
                        // {
                            // "targets": [7, 8, 9, 10, 11],
                            // "className": "text-right"

                        // }

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

                                return s['benficiary_id'];
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

                                return s['ROFR_PATTADAAR'];
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

                                return s['Father_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Compartment_No'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_rej_tbl').dataTable().fnClearTable();
                $('#dt_mandal_rej_tbl').hide();
                $('#dt_mandal_rej_tbl_wrapper').hide();
                $('#dt_mandal_rej_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Get_Lessthan4Details_man(data) {

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
    //Mandal Rejected Hide Here
    $('#dt_mandal_rej_tbl').dataTable().fnClearTable();
    $('#dt_mandal_rej_tbl').hide();
    $('#dt_mandal_rej_tbl_wrapper').hide();
    $('#dt_mandal_rej_tbl_filter').hide();
    //Village Hide Here
    $('#dt_Village_tbl').dataTable().fnClearTable();
    $('#dt_Village_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();
    $('#dt_Village_tbl_filter').hide();
    //Village Rejected Hide Here
    $('#dt_vil_rej_tbl').dataTable().fnClearTable();
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();

    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    $('#dwnld_latlongs').hide();

    $('#NotUploadID').hide();
    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    
    //Append to Label
    $('#itdaval5').text(itdaname);
    $('#distval5').text(Dist);
    $('#manval5').text(data.mandal);
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'LATLONGS LESSTHAN4','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + data.mandal + "'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_mandal_les_tbl').show();

                $('#dt_mandal_les_tbl').dataTable().fnClearTable();
                $('#dt_mandal_les_tbl').DataTable({
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
                                    return 'MANDAL WISE LATLONGS LESSTHAN 4';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE LATLONGS LESSTHAN 4',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE LATLONGS LESSTHAN 4',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'MANDAL WISE LATLONGS LESSTHAN 4';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE LATLONGS LESSTHAN 4',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',
                        }

                    ],



                    'columnDefs': [
                        {
                            "targets": [2,3,4,5,6,7,8,10],
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

                                return s['benficiary_id'];
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

                                return s['ROFR_PATTADAAR'];
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

                                return s['Father_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Compartment_No'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_les_tbl').dataTable().fnClearTable();
                $('#dt_mandal_les_tbl').hide();
                $('#dt_mandal_les_tbl_wrapper').hide();
                $('#dt_mandal_les_tbl_filter').hide();

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
    //Village Rejected Hide Here
    $('#dt_vil_rej_tbl').dataTable().fnClearTable();
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();
    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    

    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    $('#dwnld_latlongs').hide();
    $('#NotUploadID').hide();
    $('.preloader').show();
    // Here download links show
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'FVillage','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
        dataType: "json",
        
        success: function (response) {
           
            if (response.Status == "1") {
                //Total adding Here
                var Acol = 0; var Bcol = 0; var Ccol = 0; var Dcol = 0; 
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Acol += response.Data[i].total_benficiaries;
                    Bcol += response.Data[i].total_plots;
                    Ccol += response.Data[i].plots_having_latlongs;
                    Dcol += response.Data[i].plots_not_having_latlongs;

                }
                res.push({ 'village': 'TOTAL', 'total_benficiaries': Acol, 'total_plots': Bcol, 'plots_having_latlongs': Ccol, 'plots_not_having_latlongs': Dcol });


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
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
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

                        //        if (data.village != 'TOTAL') {
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
                                if (data.village != 'TOTAL') {
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

                                return s['total_benficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['total_plots'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.plots_having_latlongs > 0) {

                                    if (data.plots_having_latlongs == Ccol) {
                                        if (data.village == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_having_latlongs + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Village_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_having_latlongs + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Village_having(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_having_latlongs + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_having_latlongs + "<a/>";
                                }
                               
                                
                            }

                        },
                       

                         {
                            "mData": null,
                            "mRender": function (data, type, s) {



                                if (data.plots_not_having_latlongs > 0) {

                                    if (data.plots_not_having_latlongs == Dcol) {
                                        if (data.village == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_vill_Rejected(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_vill_Rejected(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.plots_not_having_latlongs + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.plots_not_having_latlongs + "<a/>";
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

function Get_vill_Rejected(data) {

    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
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
    //Village Having Hide Here
    $('#dt_vill_hav_tbl').dataTable().fnClearTable();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();
   
    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();
    $('#dwnld_latlongs').hide();
    $('#NotUploadID').hide();
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
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'Nothaving','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.village + "'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_vil_rej_tbl').show();

                $('#dt_vil_rej_tbl').dataTable().fnClearTable();
                $('#dt_vil_rej_tbl').DataTable({
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
                                    return 'VILLAGE WISE NOT HAVING LATLONGS';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE NOT HAVING LATLONGS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE NOT HAVING LATLONGS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE NOT HAVING LATLONGS';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE NOT HAVING LATLONGS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                       {
                           "targets": [2,3,],
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

                                return s['benficiary_id'];
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
                $('#dt_vil_rej_tbl').dataTable().fnClearTable();
                $('#dt_vil_rej_tbl').hide();
                $('#dt_vil_rej_tbl_wrapper').hide();
                $('#dt_vil_rej_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Get_Village_having(data) {

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
    //Lessthan4 LatLongsTable Hide Here
    $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    //NotUploaded table hide Here
    $('#dt_Not_Upload_tbl').dataTable().fnClearTable();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    //Back Buttons
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();
    $('#dwnld_latlongs').hide();
    $('#NotUploadID').hide();

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
    $('#dld_Lessthan4ID').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'Having','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandalname + "','Village':'" + data.village + "'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                var ttry = response.Data;
                $('#dt_vill_hav_tbl').show();

                $('#dt_vill_hav_tbl').dataTable().fnClearTable();
                $('#dt_vill_hav_tbl').DataTable({
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
                                    return 'VILLAGE WISE HAVING LATLONGS';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE HAVING LATLONGS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE HAVING LATLONGS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE WISE HAVING LATLONGS';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE HAVING LATLONGS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                           "targets": [2,3],
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

                                return s['ExtentPlotArea'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LATITUDE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LONGITUDE'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_vill_hav_tbl').dataTable().fnClearTable();
                $('#dt_vill_hav_tbl').hide();
                $('#dt_vill_hav_tbl_wrapper').hide();
                $('#dt_vill_hav_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Download_Lessthan4() {
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
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
    $('#dld_Lessthan4ID').hide();
	$('.preloader').show();
    var count = 0;
   
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'Download','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
       
        success: function (response) {
           
            if (response.Status == "1") {
                $('#dt_download_latlongs_tbl').show();

                $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
                $('#dt_download_latlongs_tbl').DataTable({
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
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DOWNLOAD LESSTHAN4 LATLONGS DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DOWNLOAD LESSTHAN4 LATLONGS DATA'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DOWNLOAD LESSTHAN4 LATLONGS DATA',
                        },
                        {
                            extend: 'print',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'DOWNLOAD LESSTHAN4 LATLONGS DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DOWNLOAD LESSTHAN4 LATLONGS DATA',
                        }
                        
                    ],



                    'columnDefs': [
                        {
                            "targets": [3, 4, 5,6,7,8,9,10],
                            "className": "text-left"

                        },
                        {
                            "targets": [0, 1, 2,11,12,13],
                            "className": "text-right"

                        }

                    ],
                    fixedColumns: true,

                    columns: [

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                count++;
                                return count;
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['id'];
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
                $('#dt_download_latlongs_tbl').dataTable().fnClearTable();
                $('#dt_download_latlongs_tbl').hide();
                $('#dt_download_latlongs_tbl_wrapper').hide();
                $('#dt_download_latlongs_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }


        }
    });

}

function Download_NotUploadData(data) {
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
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
    $('#dld_Lessthan4ID').hide();
    
   
    var count = 0;

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetLatlongsAbstract_report',
        data: "{ 'type':'INDistrict','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
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
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'LATLONGS NOT UPLOADED DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'LATLONGS NOT UPLOADED DATA'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'LATLONGS NOT UPLOADED DATA',
                        },
                        {
                            extend: 'print',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'LATLONGS NOT UPLOADED DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'LATLONGS NOT UPLOADED DATA',
                        }
                    ],



                     'columnDefs': [
                         {
                             "targets": [3,4,5,6,7,8,9,10],
                             "className": "text-left"

                        },
                        // {
                            // "targets": [0, 1, 2,11,12,13],
                            // "className": "text-right"

                        // }

                    ],
                    fixedColumns: true,

                    columns: [
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                count++;
                                return count;
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['id'];
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
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    $('#dt_download_latlongs_tbl').hide();
    $('#dt_download_latlongs_tbl_wrapper').hide();
    $('#dt_download_latlongs_tbl_filter').hide();
    $('#dt_Not_Upload_tbl').hide();
    $('#dt_Not_Upload_tbl_wrapper').hide();
    $('#dt_Not_Upload_tbl_filter').hide();
    // Here download links show
    $('#dld_NotUploadDataID').show();
    $('#dld_Lessthan4ID').show();
});

$('#manbackid').click(function () {
    var itdaname = sessionStorage.getItem('itdaname');
  
    var Dist = sessionStorage.getItem('districtname');

    var data = {};
    data.district = Dist;
    data.itda_name = itdaname;

    Get_Mandals(data);
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('#dt_vill_hav_tbl').hide();
    $('#villbackid').hide();
    $('#distbackid').show();
    
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
    
    //Village All hide
    $('#dt_vil_rej_tbl').hide();
    $('#dt_vil_rej_tbl_wrapper').hide();
    $('#dt_vil_rej_tbl_filter').hide();
    $('#dt_vill_hav_tbl').hide();
    $('#dt_vill_hav_tbl_wrapper').hide();
    $('#dt_vill_hav_tbl_filter').hide();
    // Here download links hide
    $('#dld_NotUploadDataID').hide();
    $('#dld_Lessthan4ID').hide();
    $('#villbackid').hide();
    $('#distbackid').hide();
    $('#manbackid').show();
});

