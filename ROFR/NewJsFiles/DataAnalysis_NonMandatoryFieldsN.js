
$('.preloader').fadeIn(5000, function () {
$(document).ready(function () {

   
        Get_Districts();
    $('.preloader').hide();
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var district = $("#ContentPlaceHolder1_end").text();

});
   /* $('.preloader').fadeOut(1000)*/
});
function Get_Districts() {
    
    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var district = $("#ContentPlaceHolder1_end").text();
    $('.preloader').fadeIn(3000, function () {
   /* $('.preloader').show();*/
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DataAnalysis_NonMandatoryFields',
        data: "{'Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + district+"'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {
                $('.preloader').fadeIn(3000, function () {
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

                                    return 'District wise Nonmandatory Fields';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'District wise Nonmandatory Fields',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'District wise Nonmandatory Fields',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',

                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise Nonmandatory Fields';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise Nonmandatory Fields',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0',
                            
                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [1,2],
                            "className": "text-left"

                        },
                    ],

                    
                    fixedColumns: true,

                    columns: [
                       

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.itda_name != 'TOTAL' && data.itda_name != 'Total:') {
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

                                return s['District'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_BENEFICIARIES'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['TOTAL_PLOTS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_MANDAL_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_MANDAL_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_VILLAGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_VILLAGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GRAM_PANCHAYAT_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_GRAM_PANCHAYAT_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Habitation_CODE'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_having_Habitation_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_DIVISION_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_DIVISION_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_RANGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_RANGE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_BEAT_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_BEAT_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_Uncultivable_Land'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_Uncultivable_Land'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_Cultivable_Land'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOT_HAVING_Cultivable_Land'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_Water_Tax'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_Water_Tax'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_DRYID_ONECROP_TWO_CROP'];
                            }
                        },
                             {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOT_HAVING_DRYID_ONECROP_TWO_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_WATER_SOURCE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_WATER_SOURCE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENT_IRRIGATED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENT_IRRIGATED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENT_UNDER_CULTIVATOR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENT_UNDER_CULTIVATOR'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_TYPE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_TYPE_CODE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_NET_SOWN_AREA'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_NET_SOWN_AREA'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_KHARIFF_RABI'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_KHARIFF_RABI'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_MONTH_OF_CULTIVATION'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_MONTH_OF_CULTIVATION'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENT_SINGLE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENT_SINGLE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENT_MIXED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENT_MIXED'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENT_TOTAL'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENT_TOTAL'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_FIRST_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_FIRST_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_SECOND_THIRD_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_SECOND_THIRD_CROP'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_CROP_YIELD'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_CROP_YIELD'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_REMARKS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_REMARKS'];
                            }
                        },

                    ]

                });
                    /*$('.preloader').hide();*/
                    $('.preloader').fadeOut(1000)
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
        $('.preloader').fadeOut(1000)
    })

}


