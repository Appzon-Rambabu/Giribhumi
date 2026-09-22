$(document).ready(function () {
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillage = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var districtname = $("#ContentPlaceHolder1_end").text();
    var requestData = {
        type: "Itda",
        start: ustart,
        userprevilages: userprivillage
    };
    console.log("Sending:", requestData);
    $("#loader").show();
    $.ajax({
        type: 'POST',
        url: '../Giribhumi/viewcfrData',
        data: JSON.stringify(requestData),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (response) {
            console.log("Response:", response);

            if (response.Status === "1" && response.Data) {
                $("#ddlItda").empty().append('<option value="">-- Select Itda --</option>');

                $.each(response.Data, function (i, item) {
                    $("#ddlItda").append(
                        $("<option>").val(item.ITDA_CODE).text(item.ITDA_NAME)
                    );
                });

            } else {
                alert("No ITDA data found");
            }
            $("#loader").hide();
        },

        error: function (xhr, status, error) {
            console.error("Error:", xhr.responseText || error);
            alert("Error calling API");
        }

    });
    // ITDA Change → Show Districts
    $("#ddlItda").change(function () {
        var selectedItda = $(this).val();
        var selectedName = $("#ddlItda option:selected").data("name");

        // Reset all dropdowns properly
        $("#ddlDistrict").empty().append('<option value="">-- Select District --</option>');
        $("#ddlMandal").empty().append('<option value="">-- Select Mandal --</option>');
        

        if (selectedItda === "") return;

        var requestData = {
            start: ustart,
            type: "District",
            Itda: selectedItda,
            ITDANAME: selectedName,
            District: districtname
        };

        $("#loader").show();
        $.ajax({
            type: 'POST',
            url: '../Giribhumi/viewcfrData',
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (response) {
                if (response.Status === "1" && response.Data) {
                    $.each(response.Data, function (i, item) {
                        $("#ddlDistrict").append(
                            $("<option>").val(item.District_Code).text(item.DISTRICT_NAME)
                        );
                    });
                } else {
                    alert("No districts found for selected ITDA.");
                }
                $("#loader").hide();
            },
            error: function () {
                alert("Error loading districts.");
            }
        });
    });

    // District Change → Show Mandals
    $("#ddlDistrict").change(function () {
        var selectedDistrict = $(this).val();
        var selectedItda = $("#ddlItda").val();

        // Reset child dropdowns
        $("#ddlMandal").empty().append('<option value="">-- Select Mandal --</option>');
        

        if (selectedDistrict === "") return;

        var requestData = {
            type: "Mandal",
            Itda: selectedItda,
            District: selectedDistrict
        };

        $("#loader").show();
        $.ajax({
            type: 'POST',
            url: '../Giribhumi/viewcfrData',
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (response) {
                if (response.Status === "1" && response.Data) {
                    $.each(response.Data, function (i, item) {
                        $("#ddlMandal").append(
                            $("<option>").val(item.Mandal_Code).text(item.MANDAL_NAME)
                        );
                    });
                } else {
                    alert("No Mandals found.");
                }
                $("#loader").hide();
            },
            error: function () {
                alert("Error loading mandals.");
            }
        });
    });

    // Mandal Change → Show Panchayats
    $('#ddlMandal').on('change', function () {
        viewcfrData();
    });

})
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

function viewcfrData() {
    var selectedItda = $("#ddlItda").val();
    var selectedDistrict = $("#ddlDistrict").val();
    var selectedMandal = $("#ddlMandal").val();
    printCounter = 0;
    $("#viewcfrdataTbl, #viewcfrdataTbl_wrapper").show();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/viewcfrDatadetails',
        data: JSON.stringify({
            type: 'viewcfrData',
            Itda: selectedItda,
            District: selectedDistrict,
            Mandal: selectedMandal
        }),
        dataType: "json",

        success: function (response) {

            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                if ($.fn.DataTable.isDataTable('#viewcfrdataTbl')) {
                    $('#viewcfrdataTbl').DataTable().clear().destroy();
                }

                $('#viewcfrdataTbl').DataTable({
                    data: response.Data,
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    // SCROLL SETTINGS
                    dom: 'Bfrtip',
                    scrollY: "400px",       // adjust height as needed
                    scrollX: true,
                    scrollCollapse: true,
                    fixedColumns: true,
                    buttons: [

                        {
                            extend: 'copy',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'View CFR Details';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'View CFR Details'

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'View CFR Details',

                        },
                        {
                            extend: 'print',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'View CFR Details';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'View CFR Details',
                            orientation: 'landscape',
                            pageSize: 'A0',

                        }
                    ],
                    columns: [
                        {
                            data: null,
                            render: function (data, type, row, meta) {
                                return meta.row + 1;
                            }
                        },
                        { data: "CFR_ID"},
                        { data: "Rev_Village"},
                        { data: "Village"},
                        { data: "Habitation"},
                        { data: "Compartment_No"},
                        { data: "Khasra_No"},
                        { data: "ROFR_PATTANO"},
                        { data: "Boundaries_Description"},
                        { data: "Total_CFR_Members"},
                        { data: "Total_Extent"},
                        { data: "Nature_Name"},
                        { data: "CFR_Nature"},
                        { data: "Utilization_Status"},
                        { data: "Support_Required"},
                        { data: "Grama_Sabha"},
                        { data: "Remarks"},

                       
                    ],
                    initComplete: function () {
                        applyTableAlignment('#viewcfrdataTbl', {
                            0: 'right',
                            1: 'left',
                            2: 'left',
                            3: 'left',
                            4: 'left',
                            5: 'right',
                            6: 'right',
                            7: 'right',
                            8: 'left',
                            9: 'right',
                            10: 'right',
                            11: 'left',
                            12: 'left',
                            13: 'left',
                            14: 'left',
                            15: 'left',
                            16: 'left'
                        });
                    }
                });

            } else {
                if ($.fn.DataTable.isDataTable('#viewcfrdataTbl')) {
                    $('#viewcfrdataTbl').DataTable().clear().draw();
                }
                alert("No Data Found");
            }
        },
        error: function () {
            alert("Error fetching data");
        }
    });
}

