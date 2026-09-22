$(function () {

    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
    Get_Districts();
    //Back Buttons
    $('#distbackid').hide();
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();


});

function Get_Districts() {
    //Mandal Hide Here
    $('#dt_man_tbl').dataTable().fnClearTable();
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
   
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();

    //Back Buttons
    $('#distbackid').hide();

    
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Get_Not_HavingLand_Details',
        data: "{ 'type':'LandDetails'}",
        dataType: "json",
       
        success: function (response) {

            if (response.Status == "1") {

                //Total adding Here
                var Acol = 0; var Bcol = 0; var Ccol = 0; 
                var res = response.Data;

                for (var i = 0; i < res.length; i++) {
                    Acol += response.Data[i].Total_Beneficiaries_not_having_land;
                    Bcol += response.Data[i].Today_Updated;
                    Ccol += response.Data[i].Need_To_Update;
                    
                }
                res.push({ 'ITDA_NAME': '', 'District': 'TOTAL', 'Total_Beneficiaries_not_having_land': Acol, 'Today_Updated': Bcol, 'Need_To_Update': Ccol });
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

                                    return 'DISTRICT WISE NOT HAVING LAND DETAILS REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE NOT HAVING LAND DETAILS REPORT',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE NOT HAVING LAND DETAILS REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE NOT HAVING LAND DETAILS REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE NOT HAVING LAND DETAILS REPORT',
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

                        //        if (data.District!= 'TOTAL') {
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
                                if (data.District != 'TOTAL') {
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

                                return s['District'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Beneficiaries_not_having_land'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Today_Updated'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Need_To_Update > 0) {

                                    if (data.Need_To_Update == Ccol) {
                                        if (data.District == 'TOTAL') {
                                            return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Need_To_Update + "<a/>";
                                        }
                                        else {
                                            return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Need_To_Update + "<a/>";
                                        }
                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Need_To_Update + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Need_To_Update + "<a/>";
                                }

                                

                            }

                        },
                      

                    ]

                });
                    $('.preloader').hide();
                    $('.preloader').fadeOut(3000)
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
function Get_Mandals(data) {

    //District Hide Here
    $('#dt_dist_tbl').dataTable().fnClearTable();
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('.preloader').show();
    //Back Buttons
     $('#distbackid').show();
    /*append label */
    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.District);
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Get_Not_HavingLand_Details',
        data: "{ 'type':'NeedTo','Itda':'" + data.ITDA_NAME + "','District':'" + data.District + "'}",
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

                                    return 'BENEFICIARYWISE NOT HAVING LAND DETAILS REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'BENEFICIARYWISE NOT HAVING LAND DETAILS REPORT',
                             text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            page: 'current',
                            autoFilter: true
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'BENEFICIARYWISE NOT HAVING LAND DETAILS REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'BENEFICIARYWISE NOT HAVING LAND DETAILS REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'BENEFICIARYWISE NOT HAVING LAND DETAILS REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL',

                        }
                    ],

                        'columnDefs': [
                        {
                            "targets": [2,3,4,5,6,7,8,12],
                            "className": "text-left"

                        },
                    ],

                   
                    fixedColumns: true,

                    columns: [
                       

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.ITDA_NAME) {
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

                                return s['DISTRICT'];
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
$('#distbackid').click(function () {
    Get_Districts();
    //MandalAll hide here
    $('#dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_man_tbl_filter').hide();
});

