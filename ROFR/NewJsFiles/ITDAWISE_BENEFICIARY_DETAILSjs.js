$(document).ready(function () {

    
   
    
    document.getElementById("tbl_exporttable_to_xls").style.display = "none";
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#dt_Rvillage_tbl').hide();
    $('#dt_Rvillage_tbl_wrapper').hide();
    $('#dt_Rvillage_tbl_filter').hide();
    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();
    $('#dt_dist_tbl_down').hide();
    $('#dt_dist_tbl_down_wrapper').hide();
    $('#dt_dist_tbl_down_filter').hide();
    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
        data: "{'type':'Itda','start':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
        success: function (response) {
            
            var Itda = response;

            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA_NAME);
                var opt2 = new Option(Itda.Data[i].ITDA_CODE);

                $("#itda").append($('<option>').val(opt2.text).text(opt1.text));

            }
           $('.preloader').hide();
        },
       
    });

    /*For DistrictLoad*/
    $("#itda").change(function () {
        $('#dt_dist_tbl').hide();
        $('#dt_dist_tbl_wrapper').hide();
        $('#dt_dist_tbl_filter').hide();

        $('#dt_Rvillage_tbl').hide();
        $('#dt_Rvillage_tbl_wrapper').hide();
        $('#dt_Rvillage_tbl_filter').hide();

        $('#dt_village_tbl').hide();
        $('#dt_village_tbl_wrapper').hide();
        $('#dt_village_tbl_filter').hide();

        var ITDANAME = $("#ContentPlaceHolder1_end").text();
        $('.preloader').show();
        var screen = 'District';
        var Itda = $("#itda").val();
       
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetItda_wise_Farmer_Details',
            data: "{'type':'" + screen + "','Itdacode':'" + Itda + "','start':'" + ustart + "','ITDANAME':'" + ITDANAME + "'}",
            dataType: "json",
            success: function (response) {
                
               
                $('#Districtid').empty();
                $("#Districtid").append('<option value="">Select</option>');
                $('#MandalId').empty();
                $("#MandalId").append('<option value="">Select</option>');
                $('#VillageId').empty();
                $("#VillageId").append('<option value="">Select</option>');
                $('#RvId').empty();
                $("#RvId").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DISTRICT_NAME);
                    var opt2 = new Option(response.Data[i].LGD_DISTRICT_CODE);

                    $("#Districtid").append($("<option>").val(opt2.text).text(opt1.text));

                }
                $('.preloader').hide();
            },
        });
    });

    /*For SelectRecords*/
    $("#Districtid").change(function () {
       
        
        var itdaname = $('#itda :selected').text();
        var distname = $('#Districtid :selected').text();

        sessionStorage.setItem("ITDA", itdaname);
        sessionStorage.setItem("Dist", distname);
        //new
        var itdacode = $('#itda :selected').val();
        sessionStorage.setItem("itdacode", itdacode);

        var discode = $('#Districtid :selected').val();
        sessionStorage.setItem("Distcode", discode);

        var itdacode = sessionStorage.getItem("itdacode");

        var discode = sessionStorage.getItem("Distcode");
       
        $('#MandalId').empty();
        $("#MandalId").append('<option value="">Select</option>');
        $('#VillageId').empty();
        $("#VillageId").append('<option value="">Select</option>');
        $('#RvId').empty();
        $("#RvId").append('<option value="">Select</option>');
        
        Get_Mandals();
        
        
    });
    


    $("#ALL_DATA_ID").click(function () {
        $('#dt_dist_tbl').hide();
        $('#dt_dist_tbl_wrapper').hide();
        $('#dt_dist_tbl_filter').hide();
        var itdanam = sessionStorage.getItem("ITDA");
        var distnam = sessionStorage.getItem("Dist");
        var count = 0;
        var printCounter = 0;
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetItda_ben_count',
            data: "{ 'type':'Itda_Ben_details_down','Itda':'" + itdanam + "','DistrictName':'" + distnam + "'}",
            dataType: "json",

            success: function (response) {

                if (response.Status == "1") {
                    $('#dt_dist_tbl_down').show();
                    $('#dt_dist_tbl_down').dataTable().fnClearTable();
                    $('#dt_dist_tbl_down').DataTable({
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

                                        return 'ITDA WISE FARMER LAND DETAILS';

                                    }

                                },
                                messageBottom: null
                            },
                            {
                                extend: 'excelHtml5',
                                title: 'ITDA WISE FARMER LAND DETAILS'

                            },
                            {
                                extend: 'csvHtml5',
                                title: 'ITDA WISE FARMER LAND DETAILS',

                            },
                            {
                                extend: 'print',
                                messageTop: function () {
                                    printCounter++;

                                    if (printCounter === 1) {
                                        return 'ITDA WISE FARMER LAND DETAILS';

                                    }
                                    else {
                                        return 'You have printed this document ' + printCounter + ' times';
                                    }
                                },
                                messageBottom: null
                            },
                            {
                                extend: 'pdfHtml5',
                                title: 'ITDA WISE FARMER LAND DETAILS',
                                orientation: 'landscape',
                                pageSize: 'A0',

                            }
                        ],

                        'columnDefs': [
                            {
                                "targets": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 18, 19, 21, 25, 28, 33, 34],
                                "className": "text-left"

                            },
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
                                    return s['benficiary_id'];
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

                                    return s['REV_VILLAGE'];
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

                                    return s['Father_Name'];
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
                    $('#dt_dist_tbl_down').dataTable().fnClearTable();
                    $('#dt_dist_tbl_down').hide();
                    $('#dt_dist_tbl_down_wrapper').hide();
                    $('#dt_dist_tbl_down_filter').hide();

                    $('.preloader').hide();
                    alert('No Data Found');
                }
            },
            error: function (result) {
                alert(result);
            }
        });
    })

    


});

/* SelectRecord changes*/
$("#SelectRecordsid").change(function () {
    Get_Districts();
});

$("#MandalId").change(function () {
    
    $('#dt_Rvillage_tbl').hide();
    $('#dt_Rvillage_tbl_wrapper').hide();
    $('#dt_Rvillage_tbl_filter').hide();
    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();
    var mcode = $('#MandalId :selected').val();
    sessionStorage.setItem("Mcode", mcode);

   
    $('#RvId').empty();
    $("#RvId").append('<option value="">Select</option>');

    $('#VillageId').empty();
    $("#VillageId").append('<option value="">Select</option>');

    Get_Districts();
    Get_Rvillages();
    
    
});



$("#RvId").change(function () {

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $('#dt_village_tbl').hide();
    $('#dt_village_tbl_wrapper').hide();
    $('#dt_village_tbl_filter').hide();

    var Rvname = $('#RvId :selected').text();
    sessionStorage.setItem("Rvcode", Rvname);

    $('#VillageId').empty();
    $("#VillageId").append('<option value="">Select</option>');
   
    Get_RevenuevillageData();
    Get_Villages();
});


$("#VillageId").change(function () {
    $('#dt_Rvillage_tbl').hide();
    $('#dt_Rvillage_tbl_wrapper').hide();
    $('#dt_Rvillage_tbl_filter').hide();

    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    var vname = $('#VillageId :selected').text();
    sessionStorage.setItem("vcode", vname);
    Get_VillageData();
});

function Get_Districts() {



   
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#dt_down_tbl').hide();
    $('#dt_down_tbl_wrapper').hide();
    $('#dt_down_tbl_filter').hide();
    //var itdaname = $('#itda :selected').text();
   

       

    var itdanam = sessionStorage.getItem("ITDA");

    var distnam = sessionStorage.getItem("Dist");

    var itdacode = sessionStorage.getItem("itdacode");

    var discode = sessionStorage.getItem("Distcode");

    var mandal = sessionStorage.getItem("Mcode");

    var Rev = sessionStorage.getItem("Rvcode");

    var villname = sessionStorage.getItem("vcode");

    /*var itdaname = $("#itda").val();*/
    $('#dt_dist_tbl_down').hide();
    $('#dt_dist_tbl_down_wrapper').hide();
    $('#dt_dist_tbl_down_filter').hide();
  
   

    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{ 'type':'BeneficiaryData','itdacode':'" + itdacode + "','Districtcode':'" + discode + "','mancode':'" + mandal + "','Rvillage':'" + Rev + "','village':'" + villname + "','screen':'MandalData'}",
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
                    scrollY: '300px',
                    scrollX: true,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    fixedHeader: true,
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

                                    return 'FARMER LAND DETAILS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',
                                    printCounter++;

                                if (printCounter === 1) {
                                    return 'FARMER LAND DETAILS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 18, 19, 21, 25, 28, 33, 34],
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

                                return s['ID'];
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

                                return s['Father_Name'];
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
                // $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_dist_tbl_wrapper').hide();
                $('#dt_dist_tbl_filter').hide();

                $('.preloader').hide().fadeOut(50000);
                alert('No Data Found');
            }
        },

    });

       
}


function Get_RevenuevillageData() {

    var itdanam = sessionStorage.getItem("ITDA");

    var distnam = sessionStorage.getItem("Dist");

    var itdacode = sessionStorage.getItem("itdacode");

    var discode = sessionStorage.getItem("Distcode");

    var mandal = sessionStorage.getItem("Mcode");

    var Rev = sessionStorage.getItem("Rvcode");

    var villname = sessionStorage.getItem("vcode");

    /*var itdaname = $("#itda").val();*/
    $('#dt_dist_tbl_down').hide();
    $('#dt_dist_tbl_down_wrapper').hide();
    $('#dt_dist_tbl_down_filter').hide();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{ 'type':'BeneficiaryData','itdacode':'" + itdacode + "','Districtcode':'" + discode + "','mancode':'" + mandal + "','Rvillage':'" + Rev + "','village':'" + villname + "','screen':'Rvdata'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Rvillage_tbl').show();
                $('#dt_Rvillage_tbl').dataTable().fnClearTable();
                $('#dt_Rvillage_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    fixedHeader: true,
                    scrollY: '300px',
                    scrollX: true,
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

                                    return 'FARMER LAND DETAILS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: ' FARMER LAND DETAILS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'csvHtml5',
                            title: ' FARMER LAND DETAILS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',
                                    printCounter++;

                                if (printCounter === 1) {
                                    return 'FARMER LAND DETAILS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: ' FARMER LAND DETAILS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 18, 19, 21, 25, 28, 33, 34],
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

                                return s['ID'];
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

                                return s['Father_Name'];
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
                $('#dt_Rvillage_tbl').dataTable().fnClearTable();
                $('#dt_Rvillage_tbl').hide();
                $('#dt_Rvillage_tbl_wrapper').hide();
                $('#dt_Rvillage_tbl_filter').hide();

                 $('.preloader').hide();
                alert('No Data Found');
            }
        },

    });
}

function Get_VillageData() {
    var itdanam = sessionStorage.getItem("ITDA");

    var distnam = sessionStorage.getItem("Dist");

    var itdacode = sessionStorage.getItem("itdacode");

    var discode = sessionStorage.getItem("Distcode");

    var mandal = sessionStorage.getItem("Mcode");

    var Rev = sessionStorage.getItem("Rvcode");

    var villname = sessionStorage.getItem("vcode");

    /*var itdaname = $("#itda").val();*/
    $('#dt_dist_tbl_down').hide();
    $('#dt_dist_tbl_down_wrapper').hide();
    $('#dt_dist_tbl_down_filter').hide();
    $('.preloader').show();
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{ 'type':'BeneficiaryData','itdacode':'" + itdacode + "','Districtcode':'" + discode + "','mancode':'" + mandal + "','Rvillage':'" + Rev + "','village':'" + villname + "','screen':'villdata'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_village_tbl').show();
                $('#dt_village_tbl').dataTable().fnClearTable();
                $('#dt_village_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    fixedHeader: true,
                    scrollY: '300px',
                    scrollX: true,
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

                                    return 'FARMER LAND DETAILS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',
                                    printCounter++;

                                if (printCounter === 1) {
                                    return 'FARMER LAND DETAILS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'FARMER LAND DETAILS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 18, 19, 21, 25, 28, 33, 34],
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

                                return s['ID'];
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

                                return s['Father_Name'];
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
                $('#dt_village_tbl').dataTable().fnClearTable();
                $('#dt_village_tbl').hide();
                $('#dt_village_tbl_wrapper').hide();
                $('#dt_village_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },

    });
}

function Get_Mandals() {

    var itdacode = sessionStorage.getItem("itdacode");
    var discode = sessionStorage.getItem("Distcode");

    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
        data: "{'type':'Mandal','Itda':'" + itdacode + "','District':'" + discode + "'}",
        dataType: "json",

        success: function (response) {
            if (response.Message == "Success") {


                $('#MandalId').empty();
                $("#MandalId").append('<option value="">Select</option>');


                var Itda = response.Data;

                for (var i = 0; i < Itda.length; i++) {
                    var opt1 = new Option(Itda[i].MANDAL_NAME);
                    var opt2 = new Option(Itda[i].LGD_MANDAL_CODE);
                    $("#MandalId").append($('<option>').val(opt2.text).text(opt1.text));


                }
                $('.preloader').hide();
            }
            else {
                alert("No Mandals Found");
                $('.preloader').hide();
            }
           
        },
        error: function () {
            alert("No Data Found");
            $('.preloader').hide();
        }
        
        

    });



}


function Get_Rvillages() {

    var itdacode = sessionStorage.getItem("itdacode");
    var discode = sessionStorage.getItem("Distcode");
    var mandal = sessionStorage.getItem("Mcode");
    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
   $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
        data: "{'type':'Rv','Itda':'" + itdacode + "','District':'" + discode + "','Mandal':'" + mandal + "'}",
        dataType: "json",
        success: function (response) {
            
            $('#RvId').empty();
            $("#RvId").append('<option value="">Select</option>');
            var Itda = response.Data;

            for (var i = 0; i < Itda.length; i++) {
                var opt1 = new Option(Itda[i].REVENUE_VILLAGE);
                var opt2 = new Option(Itda[i].LGD_REVENUE_VILLCODE);
                $("#RvId").append($('<option>').val(opt2.text).text(opt1.text));

            }
            
           $('.preloader').hide();
        },
        error: function (result) {
            alert("No Data Found");
        }

    });
}


function Get_Villages() {

    var itdacode = sessionStorage.getItem("itdacode");

    var discode = sessionStorage.getItem("Distcode");

    var mandal = sessionStorage.getItem("Mcode");
   
    var Rev = sessionStorage.getItem("Rvcode");
   
   

    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Beneficiary_Details',
        data: "{'type':'Village','Itda':'" + itdacode + "','District':'" + discode + "','Mandal':'" + mandal + "','Rvillage':'" + Rev +"'}",
        dataType: "json",
        success: function (response) {
           
            $('#VillageId').empty();
            $("#VillageId").append('<option value="">Select</option>');
            var Itda = response.Data;

            for (var i = 0; i < Itda.length; i++) {
                var opt1 = new Option(Itda[i].VILLAGE_NAME);
                var opt2 = new Option(Itda[i].Village_Code);


                $("#VillageId").append($('<option>').val(opt2.text).text(opt1.text));

            }
           $('.preloader').hide();
        },
        error: function (result) {
            alert("No Data Found");
        }

    });
}



function DownloadAll() {
   
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('.preloader').show();
    var itdanam = sessionStorage.getItem("ITDA");
    var distnam = sessionStorage.getItem("Dist");
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{'type':'Itda_Ben_details_down','Itda':'" + itdanam + "','DistrictName':'" + distnam +"'}",
        dataType: "json",

        success: function (response) {
            
            var rows = "";
            UIDList = response;
            data = response.Data;

            for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td >" + response.Data[i].benficiary_id + "</td><td>" + response.Data[i].ID + "</td><td >" + response.Data[i].ITDA_NAME + "</td><td >" + response.Data[i].District + "</td><td >" + response.Data[i].Mandal + "</td><td >" + response.Data[i].Gram_Panchayat + "</td><td >" + response.Data[i].REV_VILLAGE + "</td><td >" + response.Data[i].Village + "</td><td >" + response.Data[i].Habitation + "</td><td >" + response.Data[i].Forest_Division + "</td><td >" + response.Data[i].Forest_Range + "</td><td >" + response.Data[i].Forest_Beat + "</td><td >" + response.Data[i].Forest_Block + "</td><td >" + response.Data[i].Compartment_No + "</td><td >" + response.Data[i].Plot_No + "</td><td >" + response.Data[i].ExtentPlotArea + "</td><td >" + response.Data[i].ROFR_PATTANO + "</td><td >" + response.Data[i].ROFR_PATTADAAR + "</td><td >" + response.Data[i].Father_Name + "</td><td >" + response.Data[i].SUB_CASTE + "</td><td >" + response.Data[i].CULTIVATOR_NAME + "</td><td >" + response.Data[i].Aadhaar_NO + "</td><td >" + response.Data[i].BankAccountNo + "</td><td >" + response.Data[i].IfscCode + "</td><td >" + response.Data[i].BankName + "</td><td >" + response.Data[i].Uncultivable_Land + "</td><td >" + response.Data[i].Cultivable_Land + "</td><td >" + response.Data[i].PATTA_INAMGOVT + "</td><td >" + response.Data[i].DRYID_ONECROP_TWO_CROP + "</td><td >" + response.Data[i].WATER_SOURCE + "</td><td >" + response.Data[i].EXTENT_IRRIGATED + "</td><td >" + response.Data[i].EXTENT_UNDER_CULTIVATOR + "</td><td >" + response.Data[i].Land_Classification_Name + "</td><td >" + response.Data[i].HOLDING_NATURE + "</td><td >" + response.Data[i].EXTENT + "</td><td >" + response.Data[i].NET_SOWN_AREA + "</td><td >" + response.Data[i].MONTH_OF_CULTIVATION + "</td><td >" + response.Data[i].CROP + "</td><td >" + response.Data[i].SINGLE + "</td><td >" + response.Data[i].MIXED + "</td><td >" + response.Data[i].TOTAL + "</td><td >" + response.Data[i].FIRST_CROP + "</td><td >" + response.Data[i].SECOND_THIRD_CROP + "</td><td >" + response.Data[i].CROP_YIELD + "</td><td >" + response.Data[i].REMARKS + "</td></tr>";
            }
            $('#tbl_exporttable_to_xls tbody').empty();
            $(rows).appendTo("#tbl_exporttable_to_xls tbody");
            
        },
        error: function (result) {
            alert(result);
        }
    });

}