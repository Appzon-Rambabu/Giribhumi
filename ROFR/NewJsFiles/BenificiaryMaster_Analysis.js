$(document).ready(function () {
    $('.preloader').show();
    
    Get_Districts();

    $('.preloader').hide();
})

function Get_Districts() {
    
    $('#distbackid').hide();
    $('#mandalbackid').hide();
    $('#dt_ben_Details_tbl').hide();
    $('#dt_ben_Details_tbl_wrapper').hide();
    $('#dt_ben_Details_tbl_filter').hide();
    /* var count = 0;*/
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/BenificiaryMaster_Analysis',
        data: "{'District':'','Itda':'','Benificiary':''}",
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
                                    return 'DISTRICT BENIFICIARY WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT BENIFICIARY WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT BENIFICIARY WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'DISTRICT BENIFICIARY WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT BENIFICIARY WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [1,3],
                            "className": "text-left"
                        },
                        {
                            'targets': [0], // column index (start from 0)
                            'orderable': false, // set orderable false for selected columns
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
                                return s['ITDA_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['District_Code'];
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
                                if (data.total_benf > 0) {
                                    return "<a id='dlcview' href='#'  onclick='return Get_BenDetails(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.total_benf + "<a/>";


                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.total_benf + "<a/>";
                                }

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

function Get_BenDetails(data) {

    $('#dt_dist_tbl').hide();
   $('#dt_dist_tbl_wrapper').hide();
   $('#dt_dist_tbl_filter').hide();

   $('#itdaval').text(data.ITDA_NAME);
   $('#distval').text(data.District);

    $('#distbackid').show();
    var Ben = "4";
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/BenificiaryMaster_Analysis',
        data: "{'District':'" + data.District + "','Itda':'" + data.ITDA_NAME + "','Benificiary':'" + Ben+"'}",
        dataType: "json",
        success: function (response) {

            if (response.Status == "1") {

                $('#dt_ben_Details_tbl').show();

                $('#dt_ben_Details_tbl').dataTable().fnClearTable();

                $('#dt_ben_Details_tbl').DataTable({
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
                                    return 'BENIFICIARY WISE MASTER DATA';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'BENIFICIARY WISE MASTER DATA',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>'
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'BENIFICIARY WISE MASTER DATA',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'BENIFICIARY WISE MASTER DATA';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'BENIFICIARY WISE MASTER DATA',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [2],
                            "className": "text-left"
                        },
                    ],
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



                    ]

                });

            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_ben_Details_tbl').dataTable().fnClearTable();
                $('#dt_ben_Details_tbl').hide();
                $('#dt_ben_Details_tbl_wrapper').hide();
                $('#dt_ben_Details_tbl_filter').hide();

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
    
});
