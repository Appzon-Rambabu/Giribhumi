$(document).ready(function () {
    //new
    $('#dt_dist_benificiary_tbl').hide();
    $('#dt_dist_benificiary_tbl_wrapper').hide();
    $('#dt_dist_benificiary_tbl_filter').hide();
    
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
        data: "{'type':'Itda','start':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));

            var Itda = response;

            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA_CODE);
                var opt2 = new Option(Itda.Data[i].ITDA_NAME);

                $("#itda").append($('<option>').val(opt1.text).text(opt2.text));
                sessionStorage.setItem('itdaval', opt1.text);
                sessionStorage.setItem('itdaname', opt2.text);
            }
            $('.preloader').hide();
        },
        error: function (result) {
            alert("Error");
        }
    });

    /*For SelectRecords*/
    $("#itda").change(function () {
        $('.preloader').show();
        var districtName = $("#ContentPlaceHolder1_end").text();
        var itdaname = $("#itda").val();
        
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
            data: "{'type':'District','Itda':'" + itdaname + "','start':'" + ustart + "','ITDANAME':'" + districtName +"'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#districtId').empty();
                $('#districtId')
                    .append($("<option>--Select--</option>"));
                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DISTRICT_NAME);
                    var opt2 = new Option(response.Data[i].DISTRICT_NAME);

                    $("#districtId").append($("<option>").val(opt2.text).text(opt1.text));

                }
                $('.preloader').hide();
            },
            error: function (result) {
                
            }

        });
    });


});

/* SelectRecord changes*/
$("#districtId").change(function () {

    Get_Districts();
});

function Get_Districts() {
    var district = $("#districtId").val();
    var itdaname = sessionStorage.getItem('itdaname');
    var itdaname = $("#itda option:selected").text();
   
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    var arrayReturn = [];
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{ 'type':'MissingData','Itda':'" + itdaname + "','District':'" + district + "'}",
        dataType: "json",

        success: function (response) {
           

            if (response.Status == "1") {
                $('#dt_dist_benificiary_tbl').show();
                $('#dt_dist_benificiary_tbl').dataTable().fnClearTable();
                $('#dt_dist_benificiary_tbl').DataTable({
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

                                    return 'DISTRICT WISE MISSING MANDATORY FIELDS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE MISSING MANDATORY FIELDS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                           
                            download: 'open',
                            orientation: 'landscape',
                            exportOptions: {
                                columns: ':visible'
                            }
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE MISSING MANDATORY FIELDS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'DISTRICT WISE MISSING MANDATORY FIELDS';
                                    
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'DISTRICT WISE MISSING MANDATORY FIELDS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',

                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [2,3,4,5,6,7,8,9,10,11,12,17,18,19,20,24,27,33,44],
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

                                return s['Id'];
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

                                return s['Forest_Division'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Forest_Range'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Forest_Beat'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Forest_Block'];
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

                                return s['ROFR_PATTANO'];
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

                                return s['SUB_CASTE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CULTIVATOR_NAME'];
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
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Uncultivable_Land'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Cultivable_Land'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PATTA_INAMGOVT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['DRYID_ONECROP_TWO_CROP'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['WATER_SOURCE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['EXTENT_IRRIGATED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['EXTENT_UNDER_CULTIVATOR'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Land_Classification_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HOLDING_NATURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['EXTENT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NET_SOWN_AREA'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MONTH_OF_CULTIVATION'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['SINGLE'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['MIXED'];
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

                                return s['FIRST_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['SECOND_THIRD_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['CROP_YIELD'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['REMARKS'];
                            }
                        },

                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_benificiary_tbl').dataTable().fnClearTable();
                $('#dt_dist_benificiary_tbl').hide();
                $('#dt_dist_benificiary_tbl_wrapper').hide();
                $('#dt_dist_benificiary_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}