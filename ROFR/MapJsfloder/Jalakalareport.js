$(document).ready(function ()
{

    $('#upload_dlc').hide();
    $('#itdaid').hide();
    $('#dt_bplot_tbl').dataTable().fnClearTable();
    $('#dt_bplot_tbl').hide();
    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();  
    $('#preloader').hide();
    Benificiary_details_multi();
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_Mandal_tbl').hide();
    $('#dt_village_tbl').hide();
    $('#dt_detailed_tbl').hide();
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#itdvillage').hide();
   
    });

function Getdistricts(val) {
    $('#dt_bplot_tbl').hide();
    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();
    $('#distbackid').show();
    $('#dt_Mandal_tbl').hide();
    $('#itdaid').show();
    $('#dt_Mandal_tbl_filter').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#distbackid').hide();
    $('#preloader').show();
    var count = 0;
    setype = 2;
    sessionStorage.setItem('itdaname', val);
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/JalakalReport',
        data: "{ 'Type':'" + setype + "','Itda':'" + val + "'}",
        dataType: "json",
        
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#dt_dist_tbl').show();

                $('#dt_dist_tbl').dataTable().fnClearTable();

                $('#dt_dist_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                   

                    pageLength: 500,
                    destroy: true,
                    ordering: false,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE JALAKALA REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE JALAKALA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' DISTRICT WISE JALAKALA REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        //return s['benficiary_id'];
                        //        //return ' <input type="checkbox" class="dt-checkboxes" name="checkbox" value=" ' + s['ID'] + '">';
                        //        return ' <input type="checkbox" class="dt_check"  name="checkbox" value=" ' + s['id'] + '" >';
                        //    }
                        //},
                       

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.DISTRICT != 'TOTAL') {
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
                                if (data.DISTRICT != 'TOTAL')
                                {
                                    return "<a id='dlcview' href='#'  onclick='return GetMandals(" + JSON.stringify(data.DISTRICT) + ")' style=' text-decoration: underline;color:black;'>" + data.DISTRICT + "<a/>";
                                }
                                else {

                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.DISTRICT + "</h6>";}
                                
                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Total_Benficiaries'];

                            }
                        },

                        {


                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['VRO_APPROVED'];

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_REJECTED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PENDING_APD_PUSH_CONTRACTOR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_COMPLETED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_APPROVED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_REJECTED'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_SUCCESS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_FAILURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TO_BE_BORED'];
                            }
                        },


                    ]

                });
                $('#preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();

                $('#preloader').hide();
               
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function GetMandals(val) {
    var itdaname = sessionStorage.getItem('itdaname');
    sessionStorage.setItem('distname', val);
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_Mandal_tbl').show();
    $('#itdaid').hide();
    $('#distbackid').show();
    
    $('#preloader').show();
   var count = 0;
    setype = 3;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/JalakalReport',
        data: "{ 'Type':'" + setype + "','Itda':'" + itdaname + "','District':'" + val + "'}",
        dataType: "json",
        
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#dt_Mandal_tbl').show();
                $('#dt_Mandal_tbl').dataTable().fnClearTable();
                $('#dt_Mandal_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 500,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    ordering: false,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'MANDAL WISE JALAKALA REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE JALAKALA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' MANDAL WISE JALAKALA REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.MANDAL != 'TOTAL') {
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
                                if (data.MANDAL != 'TOTAL') {
                                    return "<a id='dlcview' href='#'  onclick='return Getvillages(" + JSON.stringify(data.MANDAL) + ")' style=' text-decoration: underline;color:black;'>" + data.MANDAL + "<a/>";
                                }
                                else {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.MANDAL + "</h6>";
                                }
                            }
                            

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Total_Benficiaries'];

                            }
                        },

                        {


                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['VRO_APPROVED'];

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_REJECTED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PENDING_APD_PUSH_CONTRACTOR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_COMPLETED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_APPROVED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_REJECTED'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_SUCCESS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_FAILURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TO_BE_BORED'];
                            }
                        },


                    ]

                });
                $('#preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();

                $('#preloader').hide();

                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("result");
        }
    });
}

function Getvillages(val) {
    var itdaname = sessionStorage.getItem('itdaname');
    var distname = sessionStorage.getItem('distname');
    sessionStorage.setItem('mandal',val);
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_Mandal_tbl').hide();
    $('#mandalbackid').show();
    $('#distbackid').hide();  
    $('#dt_Mandal_tbl_filter').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();
    
    $('#dt_dist_tbl_filter').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_village_tbl').show();


    $('#preloader').show();
    var count = 0;
    setype = 4;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/JalakalReport',
        data: "{ 'Type':'" + setype + "','Itda':'" + itdaname + "','District':'" + distname + "','Mandal':'" + val + "'}",
        dataType: "json",
        
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {



                $('#dt_village_tbl').show();

                $('#dt_village_tbl').dataTable().fnClearTable();

                $('#dt_village_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                   


                    pageLength: 500,
                    destroy: true,
                    ordering: false,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'VILLAGE WISE JALAKALA REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE JALAKALA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' VILLAGE WISE JALAKALA REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    columns: [
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.VILLAGE != 'TOTAL') {
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
                            "mRender": function (data, type, s)
                            {
                                if (data.VILLAGE != 'TOTAL') {

                                    return "<a id='dlcview' href='#'  onclick='return getdetailed(" + JSON.stringify(data.VILLAGE) + ")' style=' text-decoration: underline;color:black;'>" + data.VILLAGE + "<a/>";

                                }
                                else {
                                    return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.VILLAGE + "</h6>";
                                }
                                
                            }


                             
                            

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Total_Benficiaries'];

                            }
                        },

                        {


                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['VRO_APPROVED'];

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_REJECTED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PENDING_APD_PUSH_CONTRACTOR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_COMPLETED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_APPROVED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_REJECTED'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_SUCCESS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_FAILURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TO_BE_BORED'];
                            }
                        },

                    ]

                });
                $('#preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_village_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();

                $('#preloader').hide();

                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("result");
        }
    });
}

$('#itdaid').click(function ()
{
    $('#dt_bplot_tbl').show();
    $('#dt_dist_tbl').hide();
    $('#distbackid').hide();
    Benificiary_details_multi();
    
});
$('#distbackid').click(function () {
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').show();
    $('#itdaid').show();
    
    $('#dt_Mandal_tbl').hide();
    $('#distbackid').hide();

    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();
   var itdaname= sessionStorage.getItem('itdaname');
    Getdistricts(itdaname);

});
$('#mandalbackid').click(function () {
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#itdaid').hide();
    $('#distbackid').show();
    $('#dt_Mandal_tbl').show();
    $('#mandalbackid').hide();
    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();
    $('#dt_village_tbl').hide();
    $('#itdaid').hide();
    $('#dt_village_tbl_filter').hide();
    $('#dt_village_tbl_wrapper').hide();
    
    
    var dist = sessionStorage.getItem('distname');
    var itdaname = sessionStorage.getItem('itdaname');
    GetMandals(dist);

});
$('#itdvillage').click(function () {
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#itdaid').hide();
    $('#distbackid').hide();
    $('#dt_Mandal_tbl').hide();

    $('#mandalbackid').show();
    $('#dt_village_tbl').show();

    $('#dt_detailed_tbl').hide();
    $('#itdvillage').hide();
    $('#dt_detailed_tbl_filter').hide();
    $('#dt_detailed_tbl_wrapper').hide();
    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();
    $('#dt_village_tbl').hide();
    $('#itdaid').hide();
 var mandal=   sessionStorage.getItem('mandal');
    var dist = sessionStorage.getItem('distname');
    var itdaname = sessionStorage.getItem('itdaname');
    Getvillages(mandal);

});
function getdetailed(val)
{

    $('#itdvillage').show();
    $('#mandalbackid').hide();
    var mandal= sessionStorage.getItem('mandal');
    var itdaname = sessionStorage.getItem('itdaname');
    var distname = sessionStorage.getItem('distname');
    $('#dt_bplot_tbl').hide();
    $('#dt_dist_tbl').hide();
    $('#dt_Mandal_tbl').hide();  
    $('#dt_village_tbl').hide();
    $('#dt_Mandal_tbl_filter').hide();
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();
    $('#dt_detailed_tbl').show();
    

    $('#preloader').show();
    var count = 0;
    setype = 5;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/JalakalReport',
        data: "{ 'Type':'" + setype + "','Itda':'" + itdaname + "','District':'" + distname + "','Mandal':'" + mandal + "','Village':'" + val + "'}",
        dataType: "json",
        
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {

                $('#dt_detailed_tbl').show();

                $('#dt_detailed_tbl').dataTable().fnClearTable();

                $('#dt_detailed_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],

                   


                    pageLength: 500,
                    destroy: true,
                    ordering: false,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                   
                    buttons: [
                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DETAILS WISE JALAKALA REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DETAILS WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DETAILS WISE JALAKALA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' DETAILS WISE JALAKALA REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DETAILS WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],
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
                               return s['BENEFICIARY_NAME'];
                              
                              
                                
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
                                return s['CASTE'];

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['SUB_CASTE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['AADHAR_NUMBER'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MOBILE_NUMBER'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['LAND_TYPE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['SURVEY_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['KHATA_NUMBER'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['EXTENT_ACRES'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APPLICATION_NUMBER'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APPLICATION_STATUS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_STATUS_SUCCESS_FAIL'];
                            }
                        },
                       

                    ]

                });
                $(this).find('td:nth-child(2) input').val(); 
                $(this).find('td:eq(1) input').val(); 

                $('td:nth-child(2)').hide();
                $('#preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_detailed_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();
               
                $('#preloader').hide();

                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("result");
        }
    });
}
function Benificiary_details_multi()
{
    $('#dt_Mandal_tbl_wrapper').hide();
    $('#dt_Mandal_tbl_filter').hide();
    $('#itdaid').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#preloader').show();
    var count = 0;
    setype = 1;
   var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/JalakalReport',
        data: "{ 'Type':'" + setype + "'}",
        dataType: "json",
       
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {

                $('#dt_bplot_tbl').show();
               
                $('#dt_bplot_tbl').dataTable().fnClearTable();

                $('#dt_bplot_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 500,
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
                                    return 'ITDA WISE JALAKALA REPORT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'ITDA WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'ITDA WISE JALAKALA REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return ' ITDA WISE JALAKALA REPORT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'ITDA WISE JALAKALA REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',

                        }
                    ],

                    columns: [
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        //return s['benficiary_id'];
                        //        //return ' <input type="checkbox" class="dt-checkboxes" name="checkbox" value=" ' + s['ID'] + '">';
                        //        return ' <input type="checkbox" class="dt_check"  name="checkbox" value=" ' + s['id'] + '" >';
                        //    }
                        //},

                       {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.ITDA_NAME != 'TOTAL') {
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
                                if (data.ITDA_NAME == 'TOTAL') {
                                   return "<h6 id='dlcview' href='#' text-decoration: underline;color:blue;'>" + data.ITDA_NAME + "</h6>";

                                }
                                return "<a id='dlcview' href='#'  onclick='return Getdistricts(" + JSON.stringify(data.ITDA_NAME) +")' style=' text-decoration: underline;color:black;'>" + data.ITDA_NAME+"<a/>";

                            }

                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Total_Benficiaries'];

                            }
                        },

{


                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['VRO_APPROVED'];

                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_REJECTED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['VRO_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PENDING_APD_PUSH_CONTRACTOR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_COMPLETED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CONTRACTOR_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_APPROVED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_REJECTED'];
                            }
                        },

                 
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['APD_PENDING'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_SUCCESS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BORE_FAILURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TO_BE_BORED'];
                            }
                        },

                        
                    ]

                });
                $('#preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_bplot_tbl').dataTable().fnClearTable();
                $('#dt_bplot_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();

                $('#preloader').hide();
                $("#Ben_multi").val('');
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("result");
        }
    });
}



