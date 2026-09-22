$(document).ready(function () {
    //Back Buttons

    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $('#dt_MandalDetails_tbl,  #dt_MandalDetails_tbl_wrapper').hide();
    $('#dt_DistrictDetails_tbl, #dt_DistrictDetails_tbl_wrapper').hide();
    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();

    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();
    Get_Districts();
});
function renderZero(d) {
    return (d === null || d === "" || d === undefined) ? 0 : d;
}
function Get_Districts() {

    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();

    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").show();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $('#dt_MandalDetails_tbl,  #dt_MandalDetails_tbl_wrapper').hide();
    $('#dt_DistrictDetails_tbl,#dt_DistrictDetails_tbl_wrapper').hide();
    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();

    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();
    $('.preloader').show();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetHousing_report',
        data: JSON.stringify({ type: 'District', Itdastart: ustart, ITDANAME: ITDANAME }),
        dataType: "json",

        success: function (response) {

            console.log("AJAX Response:", response);

            if (response.Status === "1" && Array.isArray(response.Data) && response.Data.length > 0) {

                if ($.fn.DataTable.isDataTable('#dt_dist_tbl')) {
                    $('#dt_dist_tbl').DataTable().clear().destroy();
                }

                $('#dt_dist_tbl').show();

                $('#dt_dist_tbl').DataTable({
                    data: response.Data,
                    stateSave: true,
                    destroy: true,
                    pageLength: 100,
                    lengthMenu: [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]],
                    ordering: true,
                    scrollX: false,  // ✅ ensure DataTables doesn’t force horizontal scroll
                    autoWidth: false, // ✅ prevent extra width calculation
                    columns: [

                        // ✅ Serial Number
                        {
                            data: null,
                            render: (data, type, row, meta) => meta.row + 1
                        },

                        // ✅ ITDA Name
                        { data: "itda_name" },

                        // ✅ District Name (links to Mandal list)
                        {
                            data: "district",
                            render: function (d, t, r) {

                                if (!d) return '';

                                let itda = JSON.stringify(r.itda_name);
                                let dist = JSON.stringify(r.district);

                                return `
                                    <a href="#" style="text-decoration: underline;color:black;"
                                        onclick='Get_Mandals({
                                            ITDA_NAME: ${itda},
                                            District: ${dist}
                                        })'>
                                        ${d}
                                    </a>`;
                            }
                        },

                        // ✅ Total Beneficiaries
                        { data: "Total_benficiaries", render: renderZero },

                        // ✅ Total Housing Plots (links to details)
                        {
                            data: "Total_Housing_plots",
                            render: function (d, t, r) {

                                if (!d) return '';

                                let itda = JSON.stringify(r.itda_name);
                                let dist = JSON.stringify(r.district);

                                return `
                                    <a href="#" style="text-decoration: underline;color:black;"
                                        onclick='Get_DistrictlevDetails({
                                            ITDA_NAME: ${itda},
                                            District: ${dist}
                                        })'>
                                        ${d}
                                    </a>`;
                            }
                        },

                        // ✅ Extent
                       // { data: "Total_extent", render: renderZero },
						// ✅ FIXED HERE
                        {
                            data: "Total_extent",
                            render: function (data, type, row) {
                                if (type === 'display' || type === 'filter') {
                                    return Number(data || 0).toFixed(2);
                                }
                                return data;
                            }
                        }
						

                    ],

                    footerCallback: function (row, data, start, end, display) {

                        var api = this.api();

                        var totalBen = api.column(3).data().reduce((a, b) => Number(a || 0) + Number(b || 0), 0);
                        var totalPlots = api.column(4).data().reduce((a, b) => Number(a || 0) + Number(b || 0), 0);
						 var totalExtent = api.column(5).data().reduce((a, b) => {
                            return Number(a || 0) + Number(b || 0);
                        }, 0);
                       // var totalExtent = api.column(5).data().reduce((a, b) => Number(a || 0) + Number(b || 0), 0).toFixed(2);

                        $(api.column(1).footer()).html('');
                        $(api.column(2).footer()).html('Total');
                        $(api.column(3).footer()).html(totalBen);
                        $(api.column(4).footer()).html(totalPlots);
                        $(api.column(5).footer()).html(totalExtent.toFixed(2));

                        setFooterAlignment('#dt_dist_tbl', {
                            0: "center",
                            1: "left",
                            2: "left",
                            3: "right",
                            4: "right",
                            5: "right"
                        });
                    },

                    initComplete: function () {
                        applyTableAlignment('#dt_dist_tbl', {
                            0: 'center',
                            1: 'left',
                            2: 'left',
                            3: 'right',
                            4: 'right',
                            5: 'right'
                        });
                    }
                });

                $('.preloader').hide();

            } else {
                $('#dt_dist_tbl').hide();
                $('.preloader').hide();
                alert('No Data Found');
            }
        }
    });
}
function Get_DistrictlevDetails(data) {

    // ✅ Use values directly from the clicked row
    var itdaname = data.ITDA_NAME;
    var Dist = data.District;

    // ✅ Store into sessionStorage so other pages/functions can use it
    sessionStorage.setItem('itdaname', itdaname);
    sessionStorage.setItem('districtname', Dist);

    // Hide tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $('#dt_villageDetails_tbl').hide();
    $('#dt_MandalDetails_tbl').hide();

    $("#dt_DistrictDetails_tbl, #dt_DistrictDetails_tbl_wrapper").show();

    // ✅ Display header values
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);

    $('#villbackid').hide();
    $('#manbackid').hide();
    $('#distbackid').show();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetHousing_report',
        data: JSON.stringify({
            type: 'HousingDistrictDetails',
            Itda: itdaname,   // ✅ NOW CORRECT
            District: Dist    // ✅ NOW CORRECT
        }),
        dataType: "json",

        success: function (response) {

            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                if ($.fn.DataTable.isDataTable('#dt_DistrictDetails_tbl')) {
                    $('#dt_DistrictDetails_tbl').DataTable().clear().destroy();
                }

                $('#dt_DistrictDetails_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: function (data, type, row, meta) {
                                return meta.row + 1;
                            }
                        },
                        { data: "Benficiaryid", render: renderZero },
                        { data: "Plot_id", render: renderZero },
                        { data: "ROFR_PATTADAAR", render: renderZero },
                        { data: "Father_Name", render: renderZero },
                        { data: "Aadhaar_NO", render: renderZero },
                        { data: "ROFR_PATTANO", render: renderZero },
                        { data: "Compartment_No", render: renderZero },
                        { data: "ExtentPlotArea", render: renderZero }
                    ],
                    initComplete: function () {
                        applyTableAlignment('#dt_DistrictDetails_tbl', {
                            0: 'right',  //serial no
                            1: 'right',    // Benficiaryid
                            2: 'right',   // Plot_id
                            3: 'left',   // ROFR_PATTADAAR
                            4: 'left',  // Father_Name
                            5: 'right',  // Aadhaar
                            6: 'right',  // Pattadar No
                            7: 'right', // Compartment
                            8: 'right' // Extent
                        });
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#dt_DistrictDetails_tbl')) {
                    $('#dt_DistrictDetails_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}


function Get_Mandals(data) {

    sessionStorage.setItem('itdaname', data.ITDA_NAME);
    sessionStorage.setItem('districtname', data.District);
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").show();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $('#dt_MandalDetails_tbl,  #dt_MandalDetails_tbl_wrapper').hide();
    $('#dt_DistrictDetails_tbl,#dt_DistrictDetails_tbl_wrapper').hide();
    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();

    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.District);

    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();

    $('.preloader').show();

    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetHousing_report',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ type: 'Mandal', Itda: data.ITDA_NAME, District: data.District }),
        dataType: 'json',

        success: function (response) {

            if (response.Status === "1") {

                $('#dt_man_tbl').DataTable({
                    data: response.Data,
                    destroy: true,
                    stateSave: true,
                    pageLength: 100,
                    lengthMenu: [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]],
                    ordering: true,
                    scrollX: false,  // ✅ ensure DataTables doesn’t force horizontal scroll
                    autoWidth: false, // ✅ prevent extra width calculation
                    columns: [
                        {
                            data: null,
                            render: function (data, type, row, meta) {
                                return meta.row + 1;
                            }
                        },
                        {
                            data: "Mandal",
                            render: (d, t, r) => {
                                if (!d) return '';
                                if (d === 'Total') {
                                    return `<span style="font-weight:bold">${d}</span>`;
                                }
                                return `<a href="#" style="text-decoration:underline;color:black;"
                                           onclick='return Get_Villages(${JSON.stringify(r)})'>${d}</a>`;
                            }
                        },
                        { data: "Total_benficiaries", render: renderZero },
                        {
                            data: "Total_Housing_plots",
                            render: (d, t, r) => {
                                if (!d) return '';
                                if (d === 'Total') {
                                    return `<span style="font-weight:bold">${d}</span>`;
                                }
                                return `<a href="#" style="text-decoration:underline;color:black;"
                                           onclick='return Get_MandallevDetails(${JSON.stringify(r)})'>${d}</a>`;
                            }
                        },
                       /* { data: "Total_Housing_plots", render: renderZero  },*/
                        { data: "Total_extent", render: renderZero  }
                    ],

                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();
                        
                        var totalBen = api.column(2).data().reduce((a, b) => (parseInt(a) || 0) + (parseInt(b) || 0), 0);
                        var totalPlots = api.column(3).data().reduce((a, b) => (parseInt(a) || 0) + (parseInt(b) || 0), 0);
                        var totalExtent = api.column(4).data().reduce((a, b) => (parseFloat(a) || 0) + (parseFloat(b) || 0), 0);

                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalBen);
                        $(api.column(3).footer()).html(totalPlots);
                        $(api.column(4).footer()).html(totalExtent);
                    },
                    // ✅ AFTER DATATABLE LOADS, APPLY ALIGNMENT
                    initComplete: function () {
                        applyTableAlignment('#dt_man_tbl', {
                            0: 'center',
                            1: 'left',
                            2: 'right',
                            3: 'right',
                            4: 'right',
                            5: 'right'
                        });
                    }
                });

                $('.preloader').fadeOut(1000);

            } else {

                $('#dt_man_tbl').DataTable().clear().destroy();
                $('#dt_man_tbl, #dt_man_tbl_wrapper, #dt_man_tbl_filter').hide();
                $('.preloader').hide();
                alert('No Data Found');

            }
        },
        error: function (xhr) {
            $('.preloader').hide();
            alert("Error: " + xhr.statusText);
        }
    });
}
function Get_MandallevDetails(data) {

    // ✅ Always use values from the clicked row
    var itdaname = data.ITDA_NAME;
    var Dist = data.District;
    var mandal = data.Mandal;

    // ✅ Update session storage
    var itda = sessionStorage.getItem('itdaname');
    var dist = sessionStorage.getItem('districtname');
    sessionStorage.setItem('mandalname', mandal);

    // Hide tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $("#dt_villageDetails_tbl").hide();
    $('#dt_DistrictDetails_tbl').hide();

    $("#dt_MandalDetails_tbl, #dt_MandalDetails_tbl_wrapper").show();

    // ✅ Show labels correctly
    $('#itdaval5').text(itda);
    $('#distval5').text(dist);
    $('#manval5').text(mandal);

    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetHousing_report',
        data: JSON.stringify({
            type: 'HousingMandalDetails',
            Itda: itda,
            District: dist,
            Mandal: mandal
        }),
        dataType: "json",

        success: function (response) {

            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                if ($.fn.DataTable.isDataTable('#dt_MandalDetails_tbl')) {
                    $('#dt_MandalDetails_tbl').DataTable().clear().destroy();
                }

                $('#dt_MandalDetails_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: function (data, type, row, meta) {
                                return meta.row + 1;
                            }
                        },
                        { data: "Benficiaryid", render: renderZero },
                        { data: "Plot_id", render: renderZero },
                        { data: "ROFR_PATTADAAR", render: renderZero },
                        { data: "Father_Name", render: renderZero },
                        { data: "Aadhaar_NO", render: renderZero },
                        { data: "ROFR_PATTANO", render: renderZero },
                        { data: "Compartment_No", render: renderZero },
                        { data: "ExtentPlotArea", render: renderZero }
                    ],

                    initComplete: function () {
                        applyTableAlignment('#dt_MandalDetails_tbl', {
                            0: 'right',  //serial no
                            1: 'right',    // Benficiaryid
                            2: 'right',   // Plot_id
                            3: 'left',   // ROFR_PATTADAAR
                            4: 'left',  // Father_Name
                            5: 'right',   // Aadhaar
                            6: 'right',   // Pattadar No
                            7: 'right', // Compartment
                            8: 'right' // Extent
                        });
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#dt_MandalDetails_tbl')) {
                    $('#dt_MandalDetails_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}

function Get_Villages(data) {

    // ✅ FIX: correct mandal field name
    sessionStorage.setItem('mandalname', data.Mandal);

    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');

   

    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").show();
    $('#dt_MandalDetails_tbl,  #dt_MandalDetails_tbl_wrapper').hide();
    $('#dt_DistrictDetails_tbl,#dt_DistrictDetails_tbl_wrapper').hide();
    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();

    // ✅ Update labels
    $('#itdavill').text(itdaname);
    $('#distvill').text(Dist);
    $('#mandvill').text(mandal);

    // ✅ Hide previous tables
    $('#dt_dist_tbl').DataTable().clear().destroy();
    $('#dt_man_tbl').DataTable().clear().destroy();

   

    // ✅ Back button setup
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();

    

    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetHousing_report',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            type: 'Village',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal
        }),
        dataType: "json",

        success: function (response) {

            if (response.Status === "1") {

                $('#dt_Village_tbl').DataTable({
                    destroy: true,
                    stateSave: true,
                    pageLength: 100,
                    data: response.Data,
                    scrollX: false,  // ✅ ensure DataTables doesn’t force horizontal scroll
                    autoWidth: false, // ✅ prevent extra width calculation
                    columns: [
                        {
                            data: null,
                            render: (d, t, r, meta) =>
                                r.Village === 'Total' ? '' : meta.row + 1
                        },
                        {
                            data: "Village",
                            render: function (d, t, r) {
                                if (!d) return "";
                                if (d === "Total") {
                                    return `<b>${d}</b>`;
                                }
                                return `<a style="color:black"
                                  '>${d}</a>`;
                            }
                        },
                        { data: "Total_benficiaries", render: renderZero },

                        /*{ data: "Total_Housing_plots", render: renderZero },*/
                        {
                            data: "Total_Housing_plots",
                            render: function (d, t, r) {
                                if (!d) return "";
                                if (d === "Total") {
                                    return `<b>${d}</b>`;
                                }
                                return `<a href="#" style="text-decoration:underline;color:black"
        onclick='Get_VillageDetails(${JSON.stringify(r)})'>${d}</a>`;
                            }
                        },

                        { data: "Total_extent", render: renderZero  }
                    ],

                    footerCallback: function (row, data, start, end, display) {
                        let api = this.api();

                        let totalBen = api.column(2).data().reduce((a, b) => (+a || 0) + (+b || 0), 0);
                        let totalPlots = api.column(3).data().reduce((a, b) => (+a || 0) + (+b || 0), 0);
                        let totalExtent = api.column(4).data().reduce((a, b) => (+a || 0) + (+b || 0), 0);

                        $(api.column(1).footer()).html('<b>Total</b>');
                        $(api.column(2).footer()).html(totalBen);
                        $(api.column(3).footer()).html(totalPlots);
                        $(api.column(4).footer()).html(totalExtent);
                    }
                    ,
                    // ✅ AFTER DATATABLE LOADS, APPLY ALIGNMENT
                    initComplete: function () {
                        applyTableAlignment('#dt_Village_tbl', {
                            0: 'center',
                            1: 'left',
                            2: 'right',
                            3: 'right',
                            4: 'right',
                            5: 'right'
                        });
                    }
                });

            } else {
                $('#dt_Village_tbl').DataTable().clear().destroy();
                $('#dt_Village_tbl, #dt_Village_tbl_wrapper, #dt_Village_tbl_filter').hide();
                alert('No Data Found');
            }

            $('.preloader').fadeOut(500);
        },

        error: function (xhr) {
            
            alert("Error: " + xhr.statusText);
        }
    });
}

function Get_VillageDetails(data) {

    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');

    sessionStorage.setItem("village", data.Village);

    // Hide tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $('#dt_MandalDetails_tbl,  #dt_MandalDetails_tbl_wrapper').hide();
    $('#dt_DistrictDetails_tbl,#dt_DistrictDetails_tbl_wrapper').hide();
    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").show();


    // ✅ FIX — Correct variable
    $('#itdaval3').text(itdaname);
    $('#distval3').text(Dist);
    $('#manval3').text(mandal);
    $('#village3').text(data.Village);  // ✅ FIXED

    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetHousing_report',
        data: JSON.stringify({
            type: 'HousingVillageDetails',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal,
            village: data.Village  // ✅ FIXED
        }),
        dataType: "json",

        success: function (response) {

            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                if ($.fn.DataTable.isDataTable('#dt_villageDetails_tbl')) {
                    $('#dt_villageDetails_tbl').DataTable().clear().destroy();
                }

                $('#dt_villageDetails_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: function (data, type, row, meta) {
                                return meta.row + 1; 
                            }
                        },
                        { data: "Benficiaryid", render: renderZero  },
                        { data: "Plot_id", render: renderZero  },
                        { data: "ROFR_PATTADAAR", render: renderZero  },
                        { data: "Father_Name", render: renderZero  },
                        { data: "Aadhaar_NO", render: renderZero  },
                        { data: "ROFR_PATTANO", render: renderZero  },
                        { data: "Compartment_No", render: renderZero  },
                        { data: "ExtentPlotArea", render: renderZero  }
                    ],
                    // ✅ ADD THIS
                    initComplete: function () {
                        applyTableAlignment('#dt_villageDetails_tbl', {
                            0: 'right',  //serial no
                            1: 'right',    // Benficiaryid
                            2: 'right',   // Plot_id
                            3: 'left',   // ROFR_PATTADAAR
                            4: 'left',  // Father_Name
                            5: 'right',   // Aadhaar
                            6: 'right',   // Pattadar No
                            7: 'right', // Compartment
                            7: 'right' // Extent
                        });
                    }
                });
               

            } else {
                if ($.fn.DataTable.isDataTable('#dt_villageDetails_tbl')) {
                    $('#dt_villageDetails_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}





function applyTableAlignment(tableId, alignmentMap) {

    // Align all table headers to center
    $(tableId + " th")
        .removeClass("text-left text-right text-center")
        .addClass("text-center");

    // Apply column-wise alignment
    $(tableId + " tbody tr").each(function () {
        $(this).find("td").each(function (index) {

            let align = alignmentMap[index];

            if (align === "left")
                $(this).removeClass().addClass("text-left");
            else if (align === "right")
                $(this).removeClass().addClass("text-right");
           
               /* $(this).removeClass().addClass("text-center");*/

        });
    });
}

function setFooterAlignment(tableId, alignments) {
    // alignments = { columnIndex: "left|right|center" }

    let footerCells = $(`${tableId} tfoot th`);

    Object.keys(alignments).forEach(function (index) {
        let cell = footerCells.eq(index);
        let align = alignments[index];

        cell.removeClass("text-left text-right text-center");

        if (align === "left") cell.addClass("text-left");
        else if (align === "right") cell.addClass("text-right");
        else cell.addClass("text-center");
    });
}

// Go back to District level
$('#distbackid').click(function () {

    Get_Districts();

    $('#dt_man_tbl, #dt_Village_tbl, #dt_cfridyts_tbl').hide();
    $('#dt_man_tbl_wrapper, #dt_Village_tbl_wrapper').hide();

    $('#distbackid, #manbackid, #villbackid').hide();

    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();
});


// Go back to Mandal level
$('#manbackid').click(function () {

    var data = {
        ITDA_NAME: sessionStorage.getItem('itdaname'),
        District: sessionStorage.getItem('districtname')
    };

    Get_Mandals(data);

    $('#dt_dist_tbl, #dt_Village_tbl, #dt_cfridyts_tbl').hide();
    $('#dt_Village_tbl_wrapper').hide();

    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();

    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();
});


// ✅ ✅ ✅ Go back to Village level (fixed)
$('#villbackid').click(function () {

    var data = {
        ITDA_NAME: sessionStorage.getItem('itdaname'),
        District: sessionStorage.getItem('districtname'),
        Mandal: sessionStorage.getItem('mandalname')   // ✅ FIXED (M needs lowercase)
    };

    Get_Villages(data);

    // ✅ Show Village table again
    $('#dt_Village_tbl, #dt_Village_tbl_wrapper').show();

    // ✅ Hide other tables
    $('#dt_dist_tbl, #dt_man_tbl').hide();
    $('#dt_man_tbl_wrapper').hide();


    // ✅ Back buttons
    $('#distbackid').hide();
    $('#manbackid').show();
    $('#villbackid').hide();

    $("#dt_villageDetails_tbl, #dt_villageDetails_tbl_wrapper").hide();
});




