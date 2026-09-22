
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
    /*$('.preloader').fadeOut(1000)*/
})

function Get_Districts() {


    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var district = $("#ContentPlaceHolder1_end").text();
    $('.preloader').fadeIn(2000, function () {
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/DataAnalysis_MandatoryFields',
        data: "{'Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + district +"'}",
        dataType: "json",
        
        success: function (response) {

            if (response.Status == "1") {

                $('.preloader').fadeIn(2000, function () {
                $('#dt_dist_table').show();
                $('#dt_dist_table').dataTable().fnClearTable();
                $('#dt_dist_table').DataTable({
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

                                    return 'District wise mandatory Fields';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'District wise mandatory Fields',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'District wise mandatory Fields',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'District wise mandatory Fields';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'District wise mandatory Fields',
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
                    columns: [
                        

                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.District != 'TOTAL' && data.District != 'Total') {
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

                                return s['HAVING_MANDAL'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_MANDAL'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_VILLAGE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_VILLAGE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['GRAM_PANCHAYAT'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_GRAM_PANCHAYAT'];
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

                                return s['not_having_Habitation'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_DIVISION'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_DIVISION'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_RANGE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_RANGE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_BEAT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_BEAT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_FOREST_BLOCK'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['not_HAVING_FOREST_BLOCK'];
                            }
                        },
                        
                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_COMPARTMENT_NUMBER'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_COMPARTMENT_NUMBER'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_PLOT_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOT_HAVING_PLOT_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_EXTENTPLOTAREA'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_EXTENTPLOTAREA'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['HAVING_PATTA_INAMGOVT'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['NOT_HAVING_PATTA_INAMGOVT'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_ROFR_PATTANO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_ROFR_PATTANO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_ROFR_PATTADAAR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_ROFR_PATTADAAR'];
                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_CULTIVATOR_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_CULTIVATOR_NAME'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_HOLDING_NATURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_HOLDING_NATURE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_HAVING_Land_Classification_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_Land_Classification_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_WITH_ALL_MANDATORY_FIELDS'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS'];
                            }
                        },



                    ]

                });
                    $('.preloader').fadeOut(1000)
                })
               /* $('.preloader').hide();*/
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_table').dataTable().fnClearTable();
                $('#dt_dist_table').hide();
                $('#dt_dist_table_wrapper').hide();
                $('#dt_dist_table_filter').hide();

                /*$('.preloader').hide();*/
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
