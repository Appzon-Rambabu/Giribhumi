
$(document).ready(function () {
    //Back Buttons
    
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();
    Get_Districts();
});

function Get_Districts() {
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();
    $("#dt_man_tbl").hide();
    $("#dt_dist_tbl").show();
    $("#dt_Village_tbl").hide();
    $('.preloader').show();
    var printCounter = 0;
    $("#distbackid").hide(); // no back on first screen
    $("#manbackid").hide();
    $("#villbackid").hide();
    $("#dt_cfridyts_tbl").hide();
    $('#dt_cfridyts_tbl_wrapper').hide();
    $('#dt_cfridyts_tbl_filter').hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();
    $("#dt_cfridytsLot_tbl").hide();
    $('#dt_cfridytsLot_tbl_wrapper').hide();
    $('#dt_cfridytsLot_tbl_filter').hide();
    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: JSON.stringify({ type: 'District', Itdastart: ustart, ITDANAME: ITDANAME }),
        dataType: "json",

        success: function (response) {
            if (response.Status === "1") {
                $('.preloader').fadeIn(5000, function () {
                    var table = $('#dt_dist_tbl').DataTable({
                        data: response.Data,
                        destroy: true,
                        stateSave: true,
                        pageLength: 50,
                        lengthMenu: [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]],
                        "ordering": true,
                       
                        
                        columnDefs: [
                            { targets: [1, 2], className: "text-left" }
                        ],
                        columns: [
                            {
                                data: null,
                                render: (data, type, row, meta) =>
                                    (data.District === 'Total') ? '' : meta.row + meta.settings._iDisplayStart + 1
                            },
                            { data: "ITDA_NAME" },
                            // District column
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {
                                    if (data.District == 'Total') {
                                        return "<a id='dlcview' href='#' style='color:black;'>" + data.District + "<a/>";
                                    }
                                    else if (data.District == null) {

                                        return '';

                                    }
                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.District + "<a/>";
                                    }

                                }
                            },
                            						
				

                            { data: "TOTAL_CFR_Claims" },
                            { data: "Mem_Sub_Claims" },
                            { data: "Yet_to_Submit_Claims" },
                            { data: "Total_Extent" },
                            { data: "Total_Members" },
                            { data: "Submitted_Members" },
                            { data: "Yet_to_Submit_Mem" },
                            { data: "Latlongs_Submitted" },
                            { data: "Yet_to_Sub_Latlongs" }
                        ],
                        footerCallback: function (row, data, start, end, display) {
                            var api = this.api();

                            
                            var totalcfrclaims = api.column(3).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var memsubclaims = api.column(4).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var YetSubmitClaims = api.column(5).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var TotalExtent = api.column(6).data().reduce(function (a, b) {
                                return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                            }, 0);
                            var totalMembers = api.column(7).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var SubmittedMembers = api.column(8).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var YetSubmitMem = api.column(9).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var LatlongsSubmitted = api.column(10).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);
                            var yetSubmitted = api.column(11).data().reduce(function (a, b) {
                                return (parseInt(a) || 0) + (parseInt(b) || 0);
                            }, 0);

                            // Ensure it's a number and format to 2 decimals
                            TotalExtent = parseFloat(TotalExtent).toFixed(2);
                            //update footer
                            $(api.column(0).footer()).html('');
                            $(api.column(1).footer()).html('');
                            $(api.column(2).footer()).html('Total');
                            $(api.column(3).footer()).html(totalcfrclaims);
                            $(api.column(4).footer()).html(memsubclaims);
                            $(api.column(5).footer()).html(YetSubmitClaims);
                            $(api.column(6).footer()).html(TotalExtent);
                            $(api.column(7).footer()).html(totalMembers);
                            $(api.column(8).footer()).html(SubmittedMembers);
                            $(api.column(9).footer()).html(YetSubmitMem);
                            $(api.column(10).footer()).html(LatlongsSubmitted);
                            $(api.column(11).footer()).html(yetSubmitted);
                        }
                    });

                    $('#dt_dist_tbl').show();
                    $('.preloader').fadeOut(2000);
                });
            } else {
                $('#dt_dist_tbl').DataTable().clear().destroy();
                $('#dt_dist_tbl, #dt_dist_tbl_wrapper, #dt_dist_tbl_filter').hide();
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

function Get_Mandals(data) {
    // Store values in session
    sessionStorage.setItem('itdaname', data.ITDA_NAME);
    sessionStorage.setItem('districtname', data.District);
    $("#dt_man_tbl").show();
    $("#dt_dist_tbl").hide();
    $("#dt_Village_tbl").hide();
    // Update labels
    $('#itdaval1').text(data.ITDA_NAME);
    $('#distval1').text(data.District);
   
    // Hide District & Village tables
    $('#dt_dist_tbl, #dt_dist_tbl_wrapper, #dt_dist_tbl_filter').hide();
    $('#dt_Village_tbl, #dt_Village_tbl_wrapper, #dt_Village_tbl_filter').hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();

    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
    // Back Buttons
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();

    $('.preloader').show();

    let printCounter = 0;

    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetCFR_report',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ type: 'Mandal', Itda: data.ITDA_NAME, District: data.District }),
        dataType: 'json',
        success: function (response) {
            if (response.Status === "1") {
                $('#dt_man_tbl').DataTable({
                    data: response.Data,
                    autoWidth: false,
                    destroy: true,
                    stateSave: true,
                    pageLength: 100,
                    lengthMenu: [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]],
                    ordering: true,
                    
                   
                    columnDefs: [
                        { targets: [1], className: "text-left" }
                    ],
                    columns: [
                        { // Serial No
                            data: null,
                            render: (d, t, r, meta) =>
                                (d.MANDAL === 'Total') ? '' : meta.row + meta.settings._iDisplayStart + 1
                        },
                        { // Mandal column (clickable unless Total)
                            data: "MANDAL",
                            render: (d, t, r) => {
                                if (!d) return '';
                                if (d === 'Total') {
                                    return `<span style="color:black;font-weight:bold;">${d}</span>`;
                                }
                                return `<a href="#" style="text-decoration:underline;color:black;"
                                           onclick='return Get_Villages(${JSON.stringify(r)})'>${d}</a>`;
                            }
                        },
                        { data: "TOTAL_CFR_Claims" },
                        { data: "Mem_Sub_Claims" },
                        { data: "Yet_to_Submit_Claims" },
                        { data: "Total_Extent" },
                        { data: "Total_Members" },
                        { data: "Submitted_Members" },
                        { data: "Yet_to_Submit_Mem" },
                        { data: "Latlongs_Submitted" },
                        { data: "Yet_to_Sub_Latlongs" }
                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();


                        var totalcfrclaims = api.column(2).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var memsubclaims = api.column(3).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var YetSubmitClaims = api.column(4).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var TotalExtent = api.column(5).data().reduce(function (a, b) {
                            return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                        }, 0);
                        var totalMembers = api.column(6).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var SubmittedMembers = api.column(7).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var YetSubmitMem = api.column(8).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var LatlongsSubmitted = api.column(9).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var yetSubmitted = api.column(10).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        //update footer
                        // Ensure it's a number and format to 2 decimals
                        TotalExtent = parseFloat(TotalExtent).toFixed(2);

                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalcfrclaims);
                        $(api.column(3).footer()).html(memsubclaims);
                        $(api.column(4).footer()).html(YetSubmitClaims);
                        $(api.column(5).footer()).html(TotalExtent);
                        $(api.column(6).footer()).html(totalMembers);
                        $(api.column(7).footer()).html(SubmittedMembers);
                        $(api.column(8).footer()).html(YetSubmitMem);
                        $(api.column(9).footer()).html(LatlongsSubmitted);
                        $(api.column(10).footer()).html(yetSubmitted);
                    }
                });

                $('#dt_man_tbl').show();
                $('.preloader').fadeOut(2000);
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


function Get_Villages(data) {

    //get stored value
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    //store value
    sessionStorage.setItem('mandalname', data.MANDAL);
    var mandal = sessionStorage.getItem('mandalname');

    sessionStorage.setItem('village', data.VILLAGE);

    $("#dt_man_tbl").hide();
    $("#dt_dist_tbl").hide();
    $("#dt_Village_tbl").show();
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
   
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();
    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
    //Back Buttons
    $('#villbackid').hide();
    $('#manbackid').show();
    $('#distbackid').hide();
    // Here download links show

    $('.preloader').show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: "{ 'type':'Village','Itda':'" + itdaname + "','District':'" + Dist + "','Mandal':'" + mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
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
                    ordering: true,
                    order: [[3, 'desc']],
                   
                    'columnDefs': [
                        {
                            "targets": [1],
                            "className": "text-left"

                        },
                        


                    ],
                    fixedColumns: true,

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

                                return s['TOTAL_CFR_Claims'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Mem_Sub_Claims'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Yet_to_Submit_Claims > 0) {
                                    if (data.VILLAGE == 'Total') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Yet_to_Submit_Claims + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return Get_Cfridyts(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Yet_to_Submit_Claims + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Yet_to_Submit_Claims + "<a/>";
                                }

                            }

                        },
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['Yet_to_Submit_Claims'];
                        //    }
                        //},


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Extent'];
                            }
                        },
                        
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Members'];
                            }
                        },
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //  
                        //        return s['Submitted_Members'];
                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                // ❌ Hide "Total"
                                if (data.VILLAGE === "Total") {
                                    return ""; // hide display
                                }

                                // If variable has submitted members
                                if (data.Submitted_Members > 0) {

                                    // ✔ Create Click Link for Villages
                                    return "<a href='#' onclick='return cfridmemdetails(" + JSON.stringify(data) + ")' " +
                                        "style='text-decoration: underline; color:black;'>" +
                                        data.Submitted_Members + "</a>";
                                }

                                // If 0 members
                                return "<span style='color:black;'>" + data.Submitted_Members + "</span>";
                            }
                        },
    

                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        if (data.Submitted_Members > 0) {

                        //            return "<a href='#' onclick='cfridmemdetails("
                        //                + JSON.stringify(data) +
                        //                "); return false;' style='text-decoration: underline; color:black;'>"
                        //                + data.Submitted_Members + "</a>";
                        //        }

                        //        else {
                        //            return "<a id='dlcview' style='text-decoration:none; color:black;'>"
                        //                + data.Submitted_Members +
                        //                "</a>";
                        //        }
                        //    }
                        //},


                        {

                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Yet_to_Submit_Mem'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Latlongs_Submitted'];
                            }
                        },
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        return s['Yet_to_Sub_Latlongs'];
                        //    }
                        //},
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                if (data.Yet_to_Sub_Latlongs > 0) {
                                    if (data.VILLAGE == 'Total') {
                                        return "<h6 id='dlcview' href='#' style=' text-decoration:color:black;'>" + data.Yet_to_Sub_Latlongs + "</h6>";
                                    }

                                    else {
                                        return "<a id='dlcview' href='#'  onclick='return cfridytsLot(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Yet_to_Sub_Latlongs + "<a/>";
                                    }
                                }
                                else {
                                    return "<a id='dlcview' style=' text-decoration:color:black;'>" + data.Yet_to_Sub_Latlongs + "<a/>";
                                }

                            }

                        },
                       
                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();
                        var totalcfrclaims = api.rows().data().pluck("TOTAL_CFR_Claims").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        var memsubclaims = api.rows().data().pluck("Mem_Sub_Claims").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        
                        var YetSubmitClaims = api.rows().data().pluck("Yet_to_Submit_Claims").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var TotalExtent = api.rows().data().pluck("Total_Extent").reduce(function (a, b) {
                            return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                        }, 0);
                        var totalMembers = api.rows().data().pluck("Total_Members").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var SubmittedMembers = api.rows().data().pluck("Submitted_Members").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var YetSubmitMem = api.rows().data().pluck("Yet_to_Submit_Mem").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var LatlongsSubmitted = api.rows().data().pluck("Latlongs_Submitted").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        var yetSubmitted = api.rows().data().pluck("Yet_to_Sub_Latlongs").reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);
                        //update footer

                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalcfrclaims);
                        $(api.column(3).footer()).html(memsubclaims);
                        $(api.column(4).footer()).html(YetSubmitClaims);
                        $(api.column(5).footer()).html(TotalExtent.toFixed(2));
                        $(api.column(6).footer()).html(totalMembers);
                        $(api.column(7).footer()).html(SubmittedMembers);
                        $(api.column(8).footer()).html(YetSubmitMem);
                        $(api.column(9).footer()).html(LatlongsSubmitted);
                        $(api.column(10).footer()).html(yetSubmitted);
                    }

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

function Get_Cfridyts(data) {
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
    sessionStorage.setItem('village', data.VILLAGE);
    var village = sessionStorage.getItem('village');

    // Hide other tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();

    // Show CFRIDYTS table
    $("#dt_cfridyts_tbl, #dt_cfridyts_tbl_wrapper").show();
    $("#dt_cfridyts_tbl").show();

    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();

    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();

    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();

    // Append labels
    $('#itdaval3').text(itdaname);
    $('#distval3').text(Dist);
    $('#manval3').text(mandal);
    $('#village3').text(village);

    // Back button setup
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: JSON.stringify({
            type: 'CFRIDYTS',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal,
            village: village
        }),
        dataType: "json",
        success: function (response) {
            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                // Destroy old instance if exists
                if ($.fn.DataTable.isDataTable('#dt_cfridyts_tbl')) {
                    $('#dt_cfridyts_tbl').DataTable().clear().destroy();
                }

                // Initialize DataTable with footer totals
                $('#dt_cfridyts_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: (d, t, r, meta) => meta.row + 1
                        },
                        { data: "CFR_ID" },
                        { data: "Total_CFR_Members" },
                        { data: "Total_Extent" }
                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();

                        // CFRID Count
                      /*  var totalCFR = api.column(1).data().count();*/

                        // Members sum
                        var totalMembers = api.column(2).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        // Extent sum
                        var totalExtent = api.column(3).data().reduce(function (a, b) {
                            return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                        }, 0);

                        // Update footer
                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalMembers);
                        $(api.column(3).footer()).html(totalExtent.toFixed(2));
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#dt_cfridyts_tbl')) {
                    $('#dt_cfridyts_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}

function cfridytsLot(data) {
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
    sessionStorage.setItem('village', data.VILLAGE);
    var village = sessionStorage.getItem('village');

    // Hide other tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();

    // Show CFRIDYTS table
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").show();
    $("#dt_cfridytsLot_tbl").show();
    
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();

    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
    // Append labels
    $('#itdaval4').text(itdaname);
    $('#distval4').text(Dist);
    $('#manval4').text(mandal);
    $('#village5').text(village);

    // Back button setup
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: JSON.stringify({
            type: 'CFRIDYTSL',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal,
            village: village
        }),
        dataType: "json",
        success: function (response) {
            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                // Destroy old instance if exists
                if ($.fn.DataTable.isDataTable('#dt_cfridytsLot_tbl')) {
                    $('#dt_cfridytsLot_tbl').DataTable().clear().destroy();
                }

                // Initialize DataTable
                $('#dt_cfridytsLot_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: (d, t, r, meta) => meta.row + 1
                        },
                        { data: "CFR_ID" },
                        { data: "Total_CFR_Members" },
                        { data: "Total_Extent" }
                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();
                       
                        // Members sum
                        var totalMembers = api.column(2).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        // Extent sum
                        var totalExtent = api.column(3).data().reduce(function (a, b) {
                            return (parseFloat(a) || 0) + (parseFloat(b) || 0);
                        }, 0);

                        //update footer
                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalMembers);
                        $(api.column(3).footer()).html(totalExtent.toFixed(2));
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#dt_cfridytsLot_tbl')) {
                    $('#dt_cfridytsLot_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}

function cfridmemsub(data) {
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
    sessionStorage.setItem('village', data.VILLAGE);
    var village = sessionStorage.getItem('village');
    // Hide other tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();
    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").show();
    $("#dt_cfridmemsub_tbl").show();
    // Show CFRIDYTS table
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();

    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
    // Append labels
    $('#itdamem').text(itdaname);
    $('#distmem').text(Dist);
    $('#manmem').text(mandal);
    $('#villmem').text(village);
    sessionStorage.setItem('village', village);
    // Back button setup
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: JSON.stringify({
            type: 'CFRIDMEMSUB',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal,
            village: village
            
        }),
        dataType: "json",
        success: function (response) {
            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                // Destroy old instance if exists
                if ($.fn.DataTable.isDataTable('#dt_cfridmemsub_tbl')) {
                    $('#dt_cfridmemsub_tbl').DataTable().clear().destroy();
                }

                // Initialize DataTable
                $('#dt_cfridmemsub_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: (d, t, r, meta) => meta.row + 1
                        },
                        { data: "CFR_ID" },
                        { data: "Total_CFR_Members" },
                        /*{ data: "Submitted_Members" }*/


                         //{
                         //   data: "Submitted_Members",
                         //   render: function (data, type, row) {
                         //       return `<a href="#;" 
                         //    onclick='cfridmemdetails()'>
                         //   ${data}
                         //    </a>`;
                         //   }
                         //}
                        {
                            data: "Submitted_Members",
                            render: function (data, type, row) {

                                // If greater than 0 → clickable link
                                if (row.Submitted_Members > 0) {
                                    return `<a id="dlcview" href="#;" 
                        onclick='return cfridmemdetails(${JSON.stringify(row)})'
                        style="text-decoration: underline; color:black;">
                        ${row.Submitted_Members}
                    </a>`;
                                }

                                // If 0 → plain text, no link
                                return `<span id="dlcview" style="color:black;">
                    ${row.Submitted_Members}
                </span>`;
                            }
                        }
                    ],
                    footerCallback: function (row, data, start, end, display) {
                        var api = this.api();

                        // Members sum
                        var totalMembers = api.column(2).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        // Extent sum
                        var submembers = api.column(3).data().reduce(function (a, b) {
                            return (parseInt(a) || 0) + (parseInt(b) || 0);
                        }, 0);

                        //update footer
                        $(api.column(0).footer()).html('');
                        $(api.column(1).footer()).html('Total');
                        $(api.column(2).footer()).html(totalMembers);
                        $(api.column(3).footer()).html(submembers);
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#dt_cfridmemsub_tbl')) {
                    $('#dt_cfridmemsub_tbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}

function cfridmemdetails(data)
{
    
    var itdaname = sessionStorage.getItem('itdaname');
    var Dist = sessionStorage.getItem('districtname');
    var mandal = sessionStorage.getItem('mandalname');
   // var village = sessionStorage.getItem('village');
    sessionStorage.setItem('village', data.VILLAGE);
    var village = sessionStorage.getItem('village');
   
    // Hide other tables
    $("#dt_dist_tbl, #dt_dist_tbl_wrapper").hide();
    $("#dt_man_tbl, #dt_man_tbl_wrapper").hide();

    $("#dt_Village_tbl, #dt_Village_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();

    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").show();
    $("#dt_cfridmemdet_tbl").show();
    // Show CFRIDYTS table
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();
    // Append labels
    $('#itdamemdet').text(itdaname);
    $('#distmemdet').text(Dist);
    $('#manmemdet').text(mandal);
    $('#villmemdet').text(village);

    // Back button setup
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();

    $.ajax
    ({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetCFR_report',
        data: JSON.stringify
        ({
            type: 'CFRIDMEMSUBDET',
            Itda: itdaname,
            District: Dist,
            Mandal: mandal,
            village: village,
        }),
        dataType: "json",
        success: function (response) {
            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                // Destroy old instance if exists
                if ($.fn.DataTable.isDataTable('#dt_cfridmemdet_tbl')) {
                    $('#dt_cfridmemdet_tbl').DataTable().clear().destroy();
                }

                // Initialize DataTable
                $('#dt_cfridmemdet_tbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    columns: [
                        {
                            data: null,
                            render: (d, t, r, meta) => meta.row + 1
                        },
                        { data: "CFR_ID" },
                        { data: "Farmer_ID" },
                        { data: "Representative_Name"},
                        { data: "Father_Name" },
                        { data: "Aadhaar_NO" }
                    ],
                    // ✅ ADD THIS
                    initComplete: function () {
                        applyTableAlignment('#dt_cfridmemdet_tbl', {
                            0: 'right',  //serial no
                            1: 'right',    // CFR_ID
                            2: 'right',   // Farmer_ID
                            3: 'left',   // Representative_Name
                            4: 'left',  // Father_Name
                            5: 'right',   // Aadhaar_NO
                            
                        });
                    }

                });

            }
            else {
                if ($.fn.DataTable.isDataTable('#dt_cfridmemdet_tbl')) {
                    $('#dt_cfridmemdet_tbl').DataTable().clear().draw();
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

// Go back to District level
$('#distbackid').click(function () {
    Get_Districts();
    $('#dt_man_tbl, #dt_Village_tbl, #dt_cfridyts_tbl').hide();
    $('#distbackid, #manbackid, #villbackid').hide();
    $('#dt_man_tbl_wrapper').hide();
    $('#dt_cfridyts_tbl_wrapper').hide();
    $('#dt_cfridyts_tbl_filter').hide();
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();
    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
});

// Go back to Mandal level
$('#manbackid').click(function () {
    var data = {
        ITDA_NAME: sessionStorage.getItem('itdaname'),
        District: sessionStorage.getItem('districtname')
    };
    Get_Mandals(data);
    $('#dt_dist_tbl, #dt_Village_tbl, #dt_cfridyts_tbl').hide();
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
    $('#dt_cfridyts_tbl_wrapper').hide();
    $('#dt_cfridyts_tbl_filter').hide();
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();
    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
});

// Go back to Village level
$('#villbackid').click(function () {
    var data = {
        ITDA_NAME: sessionStorage.getItem('itdaname'),
        District: sessionStorage.getItem('districtname'),
        MANDAL: sessionStorage.getItem('mandalname')
    };
    Get_Villages(data);
    $('#dt_dist_tbl, #dt_man_tbl, #dt_cfridyts_tbl').hide();
    $('#distbackid').hide();
    $('#manbackid').show();
    $('#villbackid').hide();
    $('#dt_cfridyts_tbl_wrapper').hide();
    $('#dt_cfridyts_tbl_filter').hide();
    $("#dt_cfridytsLot_tbl, #dt_cfridytsLot_tbl_wrapper").hide();
    $("#dt_cfridytsLot_tbl").hide();
    $("#dt_cfridmemsub_tbl, #dt_cfridmemsub_tbl_wrapper").hide();
    $("#dt_cfridmemsub_tbl").hide();
    $("#dt_cfridmemdet_tbl, #dt_cfridmemdet_tbl_wrapper").hide();
    $("#dt_cfridmemdet_tbl").hide();
});






