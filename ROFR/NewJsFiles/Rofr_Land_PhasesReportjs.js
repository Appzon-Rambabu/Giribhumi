$(document).ready(function () {

    $("#ddl_benificiary option[value=0]").prop('selected', true);
    $("#ddl_benificiary").change();
    //DISTRICT WISE TABLE HIDE HERE
  
    $('#dt_dit_All_tbl').hide();
   
    //Mandal wise Not Uploaded table Hide Here
    $('#dt_man_All_Notupload_tbl').hide();
    
    
    //VILLAGE WISE NOT ALL
    $('#dt_VILL_ALL_Notupload_tbl').hide();
    
   //VILLAGE WISE TABLE HIDE HERE
    $('#dt_VILL_ALL_upload_tbl').hide();
   
    
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#vilbackid').hide();
   
    //MANDAL WISE TABLE HIDE HERE
    $('#dt_mandal_ByAll_tbl').hide();
   

    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
   
});

$('select[name="dropdown"]').change(function () {
   
        var e = document.getElementById("ddl_benificiary");
        var value = e.value;
        var text = e.options[e.selectedIndex].text;
        Get_DistrictsByType(text);
       
        //MandalAll hide here
        $('#dt_mandal_ben_tbl').hide();
        $('#dt_mandal_ben_tbl_wrapper').hide();
        $('#dt_mandal_ben_tbl_filter').hide();
        
        //All Village level Hide Here
        $('#dt_Vil_All_tbl').hide();
        $('#dt_Vil_All_tbl_wrapper').hide();
        $('#dt_Vil_All_tbl_filter').hide();
        
        //Mandal wise Not Uploaded table Hide Here
        $('#dt_man_All_Notupload_tbl').hide();
        $('#dt_man_All_Notupload_tbl_wrapper').hide();
        $('#dt_man_All_Notupload_tbl_filter').hide();
       
        //VILLAGE WISE NOT ALL
        $('#dt_VILL_ALL_Notupload_tbl').hide();
        $('#dt_VILL_ALL_Notupload_tbl_wrapper').hide();
        $('#dt_VILL_ALL_Notupload_tbl_filter').hide();
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#vilbackid').hide();
    
    
})
function Get_DistrictsByType(type) {
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //Mandal wise table hide
    $('#dt_mandal_ByAll_tbl').hide();
    $('#dt_mandal_ByAll_tbl_wrapper').hide();
    $('#dt_mandal_ByAll_tbl_filter').hide();

    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#vilbackid').hide();

    sessionStorage.setItem('type', type);
    $('.preloader').show();
    
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'" + type + "','Itdastart':'" + ustart + "','ITDANAME':'" + ITDANAME+"'}",
        dataType: "json",
       
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_dit_All_tbl').show();
                $('#dt_dit_All_tbl').dataTable().fnClearTable();
                $('#dt_dit_All_tbl').DataTable({
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

                                    return 'Rofr Stone Plantation District wise Report ';

                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: 'Rofr Stone Plantation District wise Report',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'Rofr Stone Plantation District wise Report',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Rofr Stone Plantation District wise Report';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'Rofr Stone Plantation District wise Report',
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

                                if (data.DISTRICT == 'Total') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";

                                }
                                else if (data.DISTRICT == null) {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";
                                }
                                else {
                                    return "<a id='dlcview' href='#'  onclick='return Get_MandalForAll(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "<a/>";
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

                                return s['Till_yesterday_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Today_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Cumulative_Having_Land_Image'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Not_having_Land_Image'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dit_All_tbl').dataTable().fnClearTable();
                $('#dt_dit_All_tbl').hide();
                $('#dt_dit_All_tbl_wrapper').hide();
                $('#dt_dit_All_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

function Get_MandalForAll(data) {
   
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    //All hide here
    $('#dt_dit_All_tbl').dataTable().fnClearTable();
    $('#dt_dit_All_tbl').hide();
    $('#dt_dit_All_tbl_wrapper').hide();
    $('#dt_dit_All_tbl_filter').hide();
    //All Village level Hide Here
    $('#dt_Vil_All_tbl').hide();
    $('#dt_Vil_All_tbl_wrapper').hide();
    $('#dt_Vil_All_tbl_filter').hide();
   
    
    //Back buttons Hide here
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#vilbackid').hide();
    var phasetype = sessionStorage.getItem('type');
    //append label 
    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.DISTRICT);
    sessionStorage.setItem('itdaname', data.ITDA_NAME);
    sessionStorage.setItem('districtname', data.DISTRICT);
    var printCounter = 0;
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'Mandal','District':'" + data.DISTRICT + "','Itda':'" + data.ITDA_NAME + "','phasetype':'" + phasetype + "','ITDANAME':'" + ITDANAME +"'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_mandal_ByAll_tbl').show();
                $('#dt_mandal_ByAll_tbl').dataTable().fnClearTable();
                $('#dt_mandal_ByAll_tbl').DataTable({
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
                                    return 'Rofr Stone Plantation mandal wise Report';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' Rofr Stone Plantation mandal wise Report',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Rofr Stone Plantation mandal wise Report',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Rofr Stone Plantation mandal wise Report';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Rofr Stone Plantation mandal wise Report',
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
                    columns: [
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

                                if (data.MANDAL == 'Total') {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MANDAL + "</h6>";

                                }
                                else if (data.MANDAL == null) {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MANDAL + "</h6>";
                                }
                                else {
                                    return "<a id='dlcview' href='#'  onclick='return Get_VillageForAll(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.MANDAL + "<a/>";
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

                                return s['Till_yesterday_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Today_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Cumulative_Having_Land_Image'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.MANDAL == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                else if (data.Not_having_Land_Image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Man_NotHavingPhasewise(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                
                            }
                        },
                       
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_ByAll_tbl').dataTable().fnClearTable();
                $('#dt_mandal_ByAll_tbl').hide();
                $('#dt_mandal_ByAll_tbl_wrapper').hide();
                $('#dt_mandal_ByAll_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
       
    });
}

function Get_VillageForAll(data) {
   
    //Mandal wise table hide
    $('#dt_mandal_ByAll_tbl').hide();
    $('#dt_mandal_ByAll_tbl_wrapper').hide();
    $('#dt_mandal_ByAll_tbl_filter').hide();
    
    //Mandal wise Not Uploaded table Hide Here
    $('#dt_man_All_Notupload_tbl').hide();
    $('#dt_man_All_Notupload_tbl_wrapper').hide();
    $('#dt_man_All_Notupload_tbl_filter').hide();
    //Back Buttons
    
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').show();
    $('#vilbackid').hide();
    

    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    sessionStorage.setItem('mandalname', data.MANDAL);
    var phasetype = sessionStorage.getItem('type')
    //append label 
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval1').text(data.MANDAL)
    var count = 0;
    var printCounter = 0;
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'Village','District':'" + Dist + "','Itda':'" + itdaname + "','phasetype':'" + phasetype + "','Mandal':'" + data.MANDAL + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Vil_All_tbl').show();
                $('#dt_Vil_All_tbl').dataTable().fnClearTable();
                $('#dt_Vil_All_tbl').DataTable({
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
                                    return 'Rofr Stone Plantation village wise Report';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' Rofr Stone Plantation village wise Report',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' Rofr Stone Plantation village wise Report',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'Rofr Stone Plantation village wise Report';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' Rofr Stone Plantation village wise Report',
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
                    columns: [
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

                                return s['Total_farmer_Plots'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Till_yesterday_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Today_Having_Land_Image'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.VILLAGE == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Cumulative_Having_Land_Image + "<a/>";
                                }
                                else if (data.Cumulative_Having_Land_Image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_VIL_HavingPhasewise(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Cumulative_Having_Land_Image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Cumulative_Having_Land_Image + "<a/>";
                                }
                                
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.VILLAGE == 'Total') {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                else if (data.Not_having_Land_Image > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_VIL_NotHavingPhasewise(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                else {

                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Not_having_Land_Image + "<a/>";
                                }
                                
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Vil_All_tbl').dataTable().fnClearTable();
                $('#dt_Vil_All_tbl').hide();
                $('#dt_Vil_All_tbl_wrapper').hide();
                $('#dt_Vil_All_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        
    });
}

function Get_Man_NotHavingPhasewise(data) {
    
    //All hide here
    $('#dt_dit_All_tbl').dataTable().fnClearTable();
    $('#dt_dit_All_tbl').hide();
    $('#dt_dit_All_tbl_wrapper').hide();
    $('#dt_dit_All_tbl_filter').hide();
    
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').show();
    $('#vilbackid').hide();

    $('#dt_mandal_ByAll_tbl').hide();
    $('#dt_mandal_ByAll_tbl_wrapper').hide();
    $('#dt_mandal_ByAll_tbl_filter').hide();
    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var phasetype = sessionStorage.getItem('type');
    //append label 
    $('#itdavalANU').text(itdaname);
    $('#distvalANU').text(Dist);
    $('#manvalANU').text(data.MANDAL)
    var count = 0;
    var printCounter = 0;
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'NothavingMandal','District':'" + Dist + "','Itda':'" + itdaname + "','Mandal':'" + data.MANDAL + "','phasetype':'" + phasetype + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_man_All_Notupload_tbl').show();
                $('#dt_man_All_Notupload_tbl').dataTable().fnClearTable();
                $('#dt_man_All_Notupload_tbl').DataTable({
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
                                    return ' ROFR STONE PLANTATION MANDAL WISE ALL NOT UPLOADED';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: 'ROFR STONE PLANTATION MANDAL WISE ALL NOT UPLOADED',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' ROFR STONE PLANTATION MANDAL WISE ALL NOT UPLOADED',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return ' ROFR STONE PLANTATION MANDAL WISE ALL NOT UPLOADED';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' ROFR STONE PLANTATION MANDAL WISE ALL NOT UPLOADED',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [3,4],
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
                       

                    ]
                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_man_All_Notupload_tbl').dataTable().fnClearTable();
                $('#dt_man_All_Notupload_tbl').hide();
                $('#dt_man_All_Notupload_tbl_wrapper').hide();
                $('#dt_man_All_Notupload_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        
    });
}

function Get_VIL_NotHavingPhasewise(data) {
   
    //All hide here
    $('#dt_dit_All_tbl').dataTable().fnClearTable();
    $('#dt_dit_All_tbl').hide();
    $('#dt_dit_All_tbl_wrapper').hide();
    $('#dt_dit_All_tbl_filter').hide();

    
    $('#dt_Vil_All_tbl').hide();
    $('#dt_Vil_All_tbl_wrapper').hide();
    $('#dt_Vil_All_tbl_filter').hide();
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#vilbackid').show();


    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandalname = sessionStorage.getItem('mandalname');
    var phasetype = sessionStorage.getItem('type');
    //append label 
    $('#itdavalVA').text(itdaname);
    $('#distvalVA').text(Dist);
    $('#manvalPVA').text(mandalname);
    $('#VILLvalPVA').text(data.VILLAGE);
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'Nothaving','District':'" + Dist + "','Itda':'" + itdaname + "','Mandal':'" + mandalname + "','phasetype':'" + phasetype + "','Village':'" + data.VILLAGE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_VILL_ALL_Notupload_tbl').show();
                $('#dt_VILL_ALL_Notupload_tbl').dataTable().fnClearTable();
                $('#dt_VILL_ALL_Notupload_tbl').DataTable({
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
                                    return ' ROFR STONE PLANTATION VILLAGE WISE ALL NOT UPLOADED';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' ROFR STONE PLANTATION VILLAGE WISE ALL NOT UPLOADED',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'ROFR STONE PLANTATION VILLAGE WISE ALL NOT UPLOADED',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return ' ROFR STONE PLANTATION VILLAGE WISE ALL NOT UPLOADED';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' ROFR STONE PLANTATION VILLAGE WISE ALL NOT UPLOADED',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [3,4],
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

                                return s['Land_Img_path1'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Land_Img_path2'];
                            }
                        },


                    ]
                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_VILL_ALL_Notupload_tbl').dataTable().fnClearTable();
                $('#dt_VILL_ALL_Notupload_tbl').hide();
                $('#dt_VILL_ALL_Notupload_tbl_wrapper').hide();
                $('#dt_VILL_ALL_Notupload_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_VIL_HavingPhasewise(data) {
    
    //All hide here
    $('#dt_dit_All_tbl').dataTable().fnClearTable();
    $('#dt_dit_All_tbl').hide();
    $('#dt_dit_All_tbl_wrapper').hide();
    $('#dt_dit_All_tbl_filter').hide();

    
    $('#dt_Vil_All_tbl').hide();
    $('#dt_Vil_All_tbl_wrapper').hide();
    $('#dt_Vil_All_tbl_filter').hide();
    //Back buttons Hide here
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#vilbackid').show();


    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandalname = sessionStorage.getItem('mandalname');
    var phasetype = sessionStorage.getItem('type');
    //append label 
    $('#itdavalu').text(itdaname);
    $('#distvalu').text(Dist);
    $('#manvalu').text(mandalname);
    $('#vilvalu').text(data.VILLAGE);
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetRofr_Land_Phases_Report',
        data: "{ 'type':'IHaving','District':'" + Dist + "','Itda':'" + itdaname + "','Mandal':'" + mandalname + "','phasetype':'" + phasetype + "','Village':'" + data.VILLAGE + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_VILL_ALL_upload_tbl').show();
                $('#dt_VILL_ALL_upload_tbl').dataTable().fnClearTable();
                $('#dt_VILL_ALL_upload_tbl').DataTable({
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
                                    return ' ROFR STONE PLANTATION VILLAGE WISE ALL UPLOADED';
                                }

                            },
                            messageBottom: null
                        },

                        {
                            extend: 'excelHtml5',
                            title: ' ROFR STONE PLANTATION VILLAGE WISE ALL UPLOADED',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: ' ROFR STONE PLANTATION VILLAGE WISE ALL UPLOADED',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return ' ROFR STONE PLANTATION VILLAGE WISE ALL UPLOADED';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' ROFR STONE PLANTATION VILLAGE WISE ALL UPLOADED',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [3,4],
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
                            "mRender": function (data, type, row, meta) {

                                if (type === 'display')
                                {
                                    data = '<a href="' + data.Land_Img_path1 +'" alt=""  target="_blank" ><img src="' + data.Land_Img_path1 + '"width="50" height="50"/></a>';
                                }
                                return data;
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (type === 'display') {
                                    data = '<a href="' + data.Land_Img_path2 + '" alt=""  target="_blank" ><img src="' + data.Land_Img_path2 + '"width="50" height="50"/></a>';
                                }
                                return data;
                            }
                        },


                    ]
                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_VILL_ALL_upload_tbl').dataTable().fnClearTable();
                $('#dt_VILL_ALL_upload_tbl').hide();
                $('#dt_VILL_ALL_upload_tbl_wrapper').hide();
                $('#dt_VILL_ALL_upload_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
       
    });
}


$('#distbackid').click(function () {
    var type = sessionStorage.getItem('type');
    Get_DistrictsByType(type);
    $('#dt_mandal_ByAll_tbl').hide();
    $('#dt_mandal_ByAll_tbl_wrapper').hide();
    $('#dt_mandal_ByAll_tbl_filter').hide();
});
$('#manbackid').click(function () {

    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var data = {};
    data.DISTRICT = Dist;
    data.ITDA_NAME = itdaname;
    Get_MandalForAll(data);

    $('#dt_Vil_All_tbl').hide();
    $('#dt_Vil_All_tbl_wrapper').hide();
    $('#dt_Vil_All_tbl_filter').hide();

    $('#dt_man_All_Notupload_tbl').hide();
    $('#dt_man_All_Notupload_tbl_wrapper').hide();
    $('#dt_man_All_Notupload_tbl_filter').hide();
});
$('#vilbackid').click(function () {

    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
    var data = {};
    data.DISTRICT = Dist;
    data.MANDAL = mandal;
    data.ITDA_NAME = itdaname;
    Get_VillageForAll(data);
    $('#dt_VILL_ALL_Notupload_tbl').hide();
    $('#dt_VILL_ALL_Notupload_tbl_wrapper').hide();
    $('#dt_VILL_ALL_Notupload_tbl_filter').hide();

    $('#dt_VILL_ALL_upload_tbl').hide();
    $('#dt_VILL_ALL_upload_tbl_wrapper').hide();
    $('#dt_VILL_ALL_upload_tbl_filter').hide();
});
