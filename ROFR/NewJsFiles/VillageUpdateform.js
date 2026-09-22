$(document).ready(function () {
    // Load Districts on page load
    
    $.ajax({
        url: "../Giribhumi/DropdownsLoad",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ type: "District", PTYPE: "1" }),
        success: function (response) {
            if (response.Status === "1" && Array.isArray(response.Data)) {
                $.each(response.Data, function (index, district) {
                    $('#districtDropdown').append(
                        $('<option></option>')
                            .val(district.District_LGD_Code)
                            .text(district.District_Name)
                    );
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("Failed to load districts:", error);
        },
         
        
        
    });

    // On District Change → Load Mandals
    $('#districtDropdown').change(function () {
        const selectedDistrictCode = $(this).val();
        $('#mandalDropdown').html('<option value="">Select Mandal</option>');
        $('#gpDropdown').html('<option value="">Select Panchayat</option>');
        $('#villageDropdown').html('<option value="">Select Village</option>');

        if (selectedDistrictCode) {
           
            $.ajax({
                url: "../Giribhumi/DropdownsLoad",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Mandal",
                    PTYPE: "1",
                    Districtcode: selectedDistrictCode
                }),
                success: function (response) {
                    if (response.Status === "1" && Array.isArray(response.Data)) {
                        $.each(response.Data, function (i, mandal) {
                            $('#mandalDropdown').append(
                                $('<option></option>')
                                    .val(mandal.Sub_district_LGD_Code)
                                    .text(mandal.Sub_district_Name)
                            );
                        });
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error loading mandals:", error);
                },
               /* hideLoader()*/
            });
        }
    });

    // On Mandal Change → Load GPs
    $('#mandalDropdown').change(function () {
        const selectedMandalCode = $(this).val();
        const selectedDistrictCode = $('#districtDropdown').val();

        $('#gpDropdown').html('<option value="">Select Panchayat</option>');
        $('#villageDropdown').html('<option value="">Select Village</option>');

        if (selectedDistrictCode && selectedMandalCode) {
           /* showLoader();*/
            $.ajax({
                url: "../Giribhumi/DropdownsLoad",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Panchayat",
                    PTYPE: "1",
                    Districtcode: selectedDistrictCode,
                    mancode: selectedMandalCode
                }),
                success: function (response) {
                    if (response.Status === "1" && Array.isArray(response.Data)) {
                        $.each(response.Data, function (index, gp) {
                            $('#gpDropdown').append(
                                $('<option></option>')
                                    .val(gp.Census_GP_Code)
                                    .text(gp.Census_GP_Name)
                            );
                        });
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error loading GPs:", error);
                },
                /* hideLoader();*/
            });
        }
    });

    // On GP Change → Load Villages
    $('#gpDropdown').change(function () {
        const selectedGpCode = $(this).val();
        const selectedMandalCode = $('#mandalDropdown').val();
        const selectedDistrictCode = $('#districtDropdown').val();

        $('#villageDropdown').html('<option value="">Select Village</option>');

        if (selectedDistrictCode && selectedMandalCode && selectedGpCode) {
            /*showLoader();*/
            $.ajax({
                url: "../Giribhumi/DropdownsLoad",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Village",
                    PTYPE: "1",
                    Districtcode: selectedDistrictCode,
                    mancode: selectedMandalCode,
                    GramaPanchayatCode: selectedGpCode
                }),
                success: function (response) {
                    if (response.Status === "1" && Array.isArray(response.Data)) {
                        $.each(response.Data, function (i, village) {
                            $('#villageDropdown').append(
                                $('<option></option>')
                                    .val(village.Village_LGD_Code)
                                    .text(village.Village_Name)
                            );
                        });
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error loading villages:", error);
                },
               /* hideLoader();*/
            });
        }
    });

    // On Village Change → Show confirmation box
    $('#villageDropdown').change(function () {
        const villageCode = $(this).val();
        $('#formSection').hide();
        $('#confirmLoadSection').hide();

        if (villageCode) {
            $('#confirmLoadSection')
                .data('district', $('#districtDropdown').val())
                .data('mandal', $('#mandalDropdown').val())
                .data('gp', $('#gpDropdown').val())
                .data('village', villageCode)
                .show();
        }
    });

    /*showLoader();*/
    $.ajax({
        url: "../Giribhumi/DropdownsLoad",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            "type": "Village_Category",
            "PTYPE": "1"
        }),
        success: function (response) {
            if (response.Status === "1" && response.Data && response.Data.length > 0) {
                var dropdown = $("#Village_Category");
                $.each(response.Data, function (index, item) {
                    dropdown.append($('<option>', {
                        value: item.Village_Category,
                        text: item.Village_Category.replaceAll("_", " ") // Optional: make text more readable
                    }));
                });
            } else {
                alert("No data found or invalid response");
            }
        },
        error: function (xhr, status, error) {
            console.error("AJAX Error:", error);
            alert("Failed to load Village Categories.");
        },
       /* hideLoader();*/
    });


    
    
});
// YES button → Load village data into form
$(document).on('click', '#btnYes', function (e) {
    e.preventDefault(); // ✅ STOP default button/form action
    $('#VillageStatus').val("Yes");
    console.log("Yes button clicked");

    const districtCode = $('#confirmLoadSection').data('district');
    const mandalCode = $('#confirmLoadSection').data('mandal');
    const gpCode = $('#confirmLoadSection').data('gp');
    const villageCode = $('#confirmLoadSection').data('village');

    $.ajax({
        url: "../Giribhumi/GetVillageData",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            PTYPE: "2",
            Districtcode: districtCode,
            mancode: mandalCode,
            GramaPanchayatCode: gpCode,
            VillageCode: villageCode
        }),
        success: function (response) {
            console.log("GetVillageData response:", response);

            if (response.Status === "1" && Array.isArray(response.Data) && response.Data.length > 0) {
                const data = response.Data[0];
                $('#Record_id').val(data.Record_id);
                $('#Geog_Area').val(data.Ggeographical_Area);
                $('#Total_HH').val(data.Total_HH);
                $('#Total_PoP').val(data.Total_Population);
                $('#Total_Male').val(data.Total_Male);
                $('#Total_Fema').val(data.Total_Female);
                $('#Total_SC').val(data.Total_SC);
                $('#SC_Male').val(data.SC_Male);
                $('#SC_Female').val(data.SC_Female);
                $('#Total_ST').val(data.Total_ST);
                $('#ST_Male').val(data.ST_Male);
                $('#ST_Female').val(data.ST_Female);
                $('#Forest_Ha').val(data.Forest_Hectares);
                $('#Village_Category').val(data.Village_Category);
                $('#confirmLoadSection').hide();
                $('#formSection').show();
            } else {
                alert("No data found for the selected village.");
            }
        },
        error: function () {
            alert("Failed to load village data.");
        }
    });
});

// NO button
$(document).on('click', '#btnNo', function (e) {
    e.preventDefault();
    console.log("No button clicked");

    // Set VillageStatus to No
    $('#VillageStatus').val("No");

    // Get selected dropdown values
    const districtCode = $('#districtDropdown').val();
    const mandalCode = $('#mandalDropdown').val();
    const gpCode = $('#gpDropdown').val();
    const villageCode = $('#villageDropdown').val();

    $.ajax({
        url: "../Giribhumi/GetVillageData",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            PTYPE: "2",
            Districtcode: districtCode,
            mancode: mandalCode,
            GramaPanchayatCode: gpCode,
            VillageCode: villageCode
        }),
        success: function (response) {
            console.log("GetVillageData response:", response);

            if (response.Status === "1" && Array.isArray(response.Data) && response.Data.length > 0) {
                const data = response.Data[0];
                const recordId = parseInt(data.Record_id);
                if (!isNaN(recordId)) {
                    $('#Record_id').val(recordId);  // Set only if numeric
                }
                $('#Geog_Area').val(data.Ggeographical_Area);
                $('#Total_HH').val(data.Total_HH);
                $('#Total_PoP').val(data.Total_Population);
                $('#Total_Male').val(data.Total_Male);
                $('#Total_Fema').val(data.Total_Female);
                $('#Total_SC').val(data.Total_SC);
                $('#SC_Male').val(data.SC_Male);
                $('#SC_Female').val(data.SC_Female);
                $('#Total_ST').val(data.Total_ST);
                $('#ST_Male').val(data.ST_Male);
                $('#ST_Female').val(data.ST_Female);
                $('#Forest_Ha').val(data.Forest_Hectares);
                $('#Village_Category').val(data.Village_Category);
                $('#VillageStatus').val("No");
                $('#confirmLoadSection').hide();
                $('#formSection').show();
            } else {
                alert("No data found for the selected village.");
            }
        },
        error: function () {
            alert("Failed to load village data.");
        }
    });

    // Hide confirm section
    $('#confirmLoadSection').hide();

    // Hide all form inputs, labels, selects except submit button
    $('#formSection input, #formSection label, #formSection textarea, #formSection select').not('#submitBtn').hide();

    // Show form and submit button
    $('#formSection').show();
    $('#submitBtn').show();
});


// Submit Validation
$(document).on('click', '#submitBtn', function (e) {
    e.preventDefault();
    const districtCode = $('#confirmLoadSection').data('district');
    const mandalCode = $('#confirmLoadSection').data('mandal');
    const gpCode = $('#confirmLoadSection').data('gp');
    const villageCode = $('#confirmLoadSection').data('village');
    
    const payload = {
        PTYPE: "3",
        Districtcode: districtCode,
        mancode: mandalCode,
        GramaPanchayatCode: gpCode,
        VillageCode: villageCode,
        Recordid: parseInt($('#Record_id').val()),
        GgeographicalArea: toNumberOrNull($('#Geog_Area').val()),
        TotalHH: toNumberOrNull($('#Total_HH').val()),
        TotalPopulation: toNumberOrNull($('#Total_PoP').val()),
        TotalMale: toNumberOrNull($('#Total_Male').val()),
        TotalFemale: toNumberOrNull($('#Total_Fema').val()),
        TotalSC: toNumberOrNull($('#Total_SC').val()),
        SCMale: toNumberOrNull($('#SC_Male').val()),
        SCFemale: toNumberOrNull($('#SC_Female').val()),
        TotalST: toNumberOrNull($('#Total_ST').val()),
        STMale: toNumberOrNull($('#ST_Male').val()),
        STFemale: toNumberOrNull($('#ST_Female').val()),
        ForestHectares:toNumberOrNull($('#Forest_Ha').val()),
        VillageCategory: $('#Village_Category').val(),
        VillageStatus: $('#VillageStatus').val() // ✅ Set from hidden field
    };

    console.log("Sending update payload:", payload);

    $.ajax({
        url: "../Giribhumi/VillageValiUpdate",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(payload),
        success: function (response) {
            console.log("Update response:", response);

            if (response.Status === "1") {
                alert("✅ Data Updated Successfully!");
            } else {
                alert("⚠️ Update failed: " + (response.Reason || "Unknown error"));
            }
        },
        error: function () {
            alert("❌ Failed to update village data.");
        }
    });
});

function showLoader() {
    $('#loader').show();
}
function hideLoader() {
    $('#loader').hide();
}
function toNumberOrNull(value) {
    return value && !isNaN(value) ? parseFloat(value) : null;
}