$(document).ready(function () {
    $("#NaofCrId").prop("disabled", true);
    ddlnature();
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillage = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var districtname = $("#ContentPlaceHolder1_end").text();
    $("#saveBtn").hide();
    $("#backBtn").hide();
    $("#McId").hide();
    // 👇 Decide request object
    var requestData = {
        type: "Itda",
        start: ustart,
        userprevilages: userprivillage
    };

    console.log("Sending:", requestData);
    $("#loader").show();
    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetDropdownsDataCfr',
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





    $("#ddlNatureofcfr").on("change", function () {

        if ($(this).val() !== "") {
            // Enable textbox
            $("#NaofCrId").prop("disabled", false);
        } else {
            // Disable again if 'Select' is chosen
            $("#NaofCrId").prop("disabled", true);
            $("#NaofCrId").val(""); // clear value
        }
    });
    // ITDA Change → Show Districts
    $("#ddlItda").change(function () {
        var selectedItda = $(this).val();
        var selectedName = $("#ddlItda option:selected").data("name");

        // Reset all dropdowns properly
        $("#ddlDistrict").empty().append('<option value="">-- Select District --</option>');
        $("#ddlMandal").empty().append('<option value="">-- Select Mandal --</option>');
        $("#ddlPanchayat").empty().append('<option value="">-- Select Panchayat --</option>');
        $("#ddlRevVillage").empty().append('<option value="">-- Select Revenue Village --</option>');
        $("#ddlVillage").empty().append('<option value="">-- Select Village --</option>');
        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

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
            url: '../Giribhumi/GetDropdownsDataCfr',
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
        $("#ddlPanchayat").empty().append('<option value="">-- Select Panchayat --</option>');
        $("#ddlRevVillage").empty().append('<option value="">-- Select Revenue Village --</option>');
        $("#ddlVillage").empty().append('<option value="">-- Select Village --</option>');
        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (selectedDistrict === "") return;

        var requestData = {
            type: "Mandal",
            Itda: selectedItda,
            District: selectedDistrict
        };

        $("#loader").show();
        $.ajax({
            type: 'POST',
            url: '../Giribhumi/GetDropdownsDataCfr',
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
        var itda = $('#ddlItda').val();
        var district = $('#ddlDistrict').val();
        var mandal = $('#ddlMandal').val();

        // Reset child dropdowns
        $("#ddlPanchayat").empty().append('<option value="">-- Select Panchayat --</option>');
        $("#ddlRevVillage").empty().append('<option value="">-- Select Revenue Village --</option>');
        $("#ddlVillage").empty().append('<option value="">-- Select Village --</option>');
        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!mandal) return;

        var requestData = {
            type: "Panchayat",
            Itda: itda,
            District: district,
            Mandal: mandal
        };

        $("#loader").show();
        $.ajax({
            url: "../Giribhumi/GetDropdownsDataCfr",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(requestData),
            success: function (response) {
                if (response.Status === "1" && response.Data) {
                    $.each(response.Data, function (i, item) {
                        $("#ddlPanchayat").append(
                            $("<option>").val(item.Grama_Panchayat_Code).text(item.Gram_Panchayat)
                        );
                    });
                } else {
                    alert("No Panchayat data found.");
                }
                $("#loader").hide();
            },
            error: function () {
                alert("Error loading Panchayats.");
            }
        });
    });

    $("#ddlPanchayat").change(function () {
        var panchayatCode = $(this).val();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();
        var mandal = $("#ddlMandal").val();

       
        $("#ddlRevVillage").empty().append('<option value="">-- Select Revenue Village --</option>');
        $("#ddlVillage").empty().append('<option value="">-- Select Village --</option>');
        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!panchayatCode) return;

        if (panchayatCode) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "RevVillage",
                    Itda: itda,
                    District: district,
                    Mandal: mandal,
                    panchayatcode: panchayatCode
                }),
                success: function (response) {
                    if (response.Status === "1" && response.Data.length > 0) {
                        /*$("#ddlRevVillage,#ddlVillage,#ddlHabitation,#ddlDivision,#ddlRange,#ddlBeat").empty().append('<option value="">-- Select Revenue Village --</option>');*/
                        $.each(response.Data, function (i, item) {
                            $("#ddlRevVillage").append(
                                $("<option></option>")
                                    .val(item.REVENUE_VILLAGECODE)
                                    .text(item.REV_VILLAGE_NAME)
                            );
                        });
                    } else {
                        $("#ddlRevVillage").empty().append('<option value="">No Revenue Villages</option>');
                    }
                    $("#loader").hide();
                },
                error: function () {
                    alert("Error loading Revenue Villages.");
                }
                
            });
        } 
    });

    $("#ddlRevVillage").change(function () {
        var revVillage = $(this).val();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();
        var mandal = $("#ddlMandal").val();
        var panchayat = $("#ddlPanchayat").val();

       

        $("#ddlVillage").empty().append('<option value="">-- Select Village --</option>');
        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!revVillage) return;

        if (revVillage) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Village",
                    Itda: itda,
                    District: district,
                    Mandal: mandal,
                    panchayatcode: panchayat,
                    rev_village: revVillage
                }),
                success: function (response) {
                   /* $("#ddlVillage,#ddlHabitation,#ddlDivision,#ddlRange,#ddlBeat").empty().append('<option value="">-- Select Village --</option>');*/
                    if (response.Status === "1" && response.Data.length > 0) {
                        $.each(response.Data, function (i, item) {
                            $("#ddlVillage").append(
                                $("<option></option>")
                                    .val(item.Village_Code)
                                    .text(item.VILLAGE_NAME)
                            );
                        });
                    } else {
                        alert("No villages found.");
                    }
                    $("#loader").hide();
                },
                error: function (xhr) {
                    alert("Error loading Villages: " + xhr.statusText);
                }
            });
        } 
    });

    $("#ddlVillage").change(function () {
        var villageCode = $(this).val();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();
        var mandal = $("#ddlMandal").val();
        var panchayat = $("#ddlPanchayat").val();
        var Revvillagecode = $("#ddlRevVillage").val();
        var villageName = $("#ddlVillage option:selected").text(); // text (name)

        $("#ddlHabitation").empty().append('<option value="">-- Select Habitation --</option>');
        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!villageName) return;

        if (villageName) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Habitation",
                    Itda: itda,
                    District: district,
                    Mandal: mandal,
                    panchayatcode: panchayat,
                    rev_village: Revvillagecode,
                    Village: villageName
                }),
                success: function (response) {
                    if (response.Status === "1") {
                      
                        $.each(response.Data, function (i, item) {
                            $("#ddlHabitation").append('<option value="' + item.HabitationCode + '">' + item.HABITATION + '</option>');
                        });
                    } else {
                        alert("No data found: " + response.Message);
                    }
                    $("#loader").hide();
                },
                error: function (xhr, status, error) {
                    console.error("Error:", error);
                }
            });
        } 
    });

    $("#ddlHabitation").change(function () {
        var habitationCode = $(this).val();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();

        $("#ddlDivision").empty().append('<option value="">-- Select Division --</option>');
        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!habitationCode) return;

        if (habitationCode) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Division",
                    Itda: itda,
                    District: district,
                }),
                success: function (response) {
                    /*$("#ddlDivision").empty();*/

                    if (response.Status === "1" && response.Data.length > 0) {
                       /* $("#ddlDivision,#ddlRange,#ddlBeat").append('<option value="">-- Select Division --</option>');*/
                        $.each(response.Data, function (i, item) {
                            $("#ddlDivision").append(
                                '<option value="' + item.Forest_DivisionCode + '">' + item.FOREST_DIVISION_NAME + '</option>'
                            );
                        });
                    } else {
                        $("#ddlDivision").append('<option value="">No Divisions Found</option>');
                    }

                    $("#loader").hide();
                },
                error: function () {
                    $("#ddlDivision").empty().append('<option value="">Error loading divisions</option>');
                    $("#loader").hide();
                }
            });
        } 
    });


    // Load Ranges on Forest Division Change
    $("#ddlDivision").change(function () {
       
        var divisionName = $("#ddlDivision option:selected").text();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();

        $("#ddlRange").empty().append('<option value="">-- Select Range --</option>');
        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!divisionName) return;

        if (divisionName) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Range",
                    Itda: itda,
                    District: district,
                    Forest_Division: divisionName
                }),
                success: function (response) {
                   /* $("#ddlRange,#ddlBeat").empty().append('<option value="">-- Select Range --</option>');*/
                    if (response.Status === "1") {
                        $.each(response.Data, function (i, item) {
                            $("#ddlRange").append('<option value="' + item.Forest_RangeCode + '">' + item.FOREST_RANGE_NAME + '</option>');
                        });
                    } else {
                        alert("No Ranges found: " + response.Message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error:", error);
                }
            });
            $("#loader").hide();
        } 
    });

    $("#ddlRange").change(function () {
        var rangeCode = $(this).val();
        var RangeName = $("#ddlRange option:selected").text();
        var divisionName = $("#ddlDivision option:selected").text();
        var itda = $("#ddlItda").val();
        var district = $("#ddlDistrict").val();

        $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');

        if (!rangeCode) return;

        if (RangeName) {
            $("#loader").show();
            $.ajax({
                url: "../Giribhumi/GetDropdownsDataCfr",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    type: "Beat",
                    Itda: itda,
                    District: district,
                    Forest_Division: divisionName,
                    Range: RangeName
                }),
                success: function (response) {
                   /* $("#ddlBeat").empty().append('<option value="">-- Select Beat --</option>');*/
                    if (response.Status === "1") {
                        $.each(response.Data, function (i, item) {
                            $("#ddlBeat").append('<option value="' + item.Forest_BeatCode + '">' + item.FOREST_BEAT_NAME + '</option>');
                        });
                    } else {
                        alert("No Beats found: " + response.Message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error:", error);
                }
            });
            $("#loader").hide();
        } 
    });

    $("#submitBtn").on("click", function () {

        if (!validateMandatoryFields()) {
            alert("⚠️ Please fill all mandatory fields.");
            return;
        }

        // ✅ Prevent 0,00,000 type values
        var totalMembers = $("#NoOFBcMeId").val().trim();
        if (/^0+$/.test(totalMembers) || totalMembers === "") {
            alert("⚠️ Total CFR Members cannot be zero or empty.");
            $("#NoOFBcMeId").focus();
            return;
        } 
        // ✅ Prevent 0,00,000 type values
        var kasarano = $("#KhasraId").val().trim();
        if (/^0+$/.test(kasarano) || kasarano === "") {
            alert("⚠️ Khasara Number cannot be zero or empty.");
            $("#KhasraId").focus();
            return;
        }
        // ✅ Prevent 0,00,000 type values
        var CompartmentNo = $("#CompNoID").val().trim();
        if (/^0+$/.test(CompartmentNo) || CompartmentNo === "") {
            alert("⚠️ Compartment Number cannot be zero or empty.");
            $("#CompNoID").focus();
            return;
        }

        alert("✅ All good! Submitting...");

        var formData = new FormData();

        // Collect model data into one object
        var obj = {
            PTYPE: "CFR_MASTER_INSERT",
            ItdaCodecrf: $("#ddlItda").val(),
            ItdaNamecrf: $("#ddlItda option:selected").text(),
            DistrictCodecrf: $("#ddlDistrict").val(),
            Districtcrf: $("#ddlDistrict option:selected").text(),
            Mandal_Code: $("#ddlMandal").val(),
            Mandalcrf: $("#ddlMandal option:selected").text(),
            PanchayatCodecrf: $("#ddlPanchayat").val(),
            Panchayatcrf: $("#ddlPanchayat option:selected").text(),
            RevVillagecodecrf: $("#ddlRevVillage").val(),
            RevVillagecrf: $("#ddlRevVillage option:selected").text(),
            Village_Code: $("#ddlVillage").val(),
            Village: $("#ddlVillage option:selected").text(),
            HabitationCode: $("#ddlHabitation").val(),
            Habitation: $("#ddlHabitation option:selected").text(),
            Forest_DivisionCode: $("#ddlDivision").val(),
            Forest_Division: $("#ddlDivision option:selected").text(),
            Forest_RangeCode: $("#ddlRange").val(),
            Forest_Range: $("#ddlRange option:selected").text(),
            Forest_BeatCode: $("#ddlBeat").val(),
            Forest_Beat: $("#ddlBeat option:selected").text(),
            Forest_Block: $("#ForestBlockId").val(),
            Compartment_No: CompartmentNo,
            KhasraNo: kasarano,
            ROFR_PATTANO: $("#RofrPattaId").val(),
            Boundaries_Description: $("#DesobId").val(),
            Total_CFR_Members: totalMembers,  
            Total_Extent: $("#TotalcfrExtentId").val(),
            Naturecode: $("#ddlNatureofcfr").val(),
            NatureName: $("#ddlNatureofcfr option:selected").text(),
            CFR_Nature: $("#NaofCrId").val(),
            Utilization_Status: $("#preStaId").val(),
            Support_Required: $("#SupportifanyId").val(),
            Gramsabha: $("#GramasabhaId").val(),
            Remarks: $("#RemarksId").val(),
            user_name: username,
            IPADDRESS: "",
        };
        
        // ✅ Append JSON object as one field
        formData.append("model", JSON.stringify(obj));

        // ✅ Append file (only once)
        var fileInput = $("#CFRDocumentUploadId")[0].files[0];
        if (fileInput) {
            formData.append("file", fileInput);
        }

        $.ajax({
            url: "../Giribhumi/CRfInsertion", 
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (res) {
                console.log("Response:", res);
                if (res.Status === "1" || res.Status === "Success") {
                    Swal.fire({
                        toast: true,
                        position: 'top-center',
                        icon: 'success',
                        html: 'Data Submitted Successfully!<br>CFRID: <b>' + res.retId + '</b> Please Save CFRID For Future Reference',
                        showConfirmButton: true,
                        customClass: {
                            popup: 'my-swal-popup'
                        }
                        
                    });
                    ResetAll();
                   /* alert("Inserted Successfully. CFRID: " + res.retId);*/
                } else {
                    alert("Failed: " + res.Message);
                    ResetAll();
                }
            },
            error: function (err) {
                console.log("Error:", err);
            }
        });
    });
    
});

function ddlnature() {
    //Load Nature ddl

    var reqnatureddl = {
        type: "Cfrnatureddl"
    };
    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetDropdownsDataCfr',
        data: JSON.stringify(reqnatureddl),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (response) {
            console.log("Response:", response);

            if (response.Status === "1" && response.Data) {
                $("#ddlNatureofcfr").empty().append('<option value="">-- Select Nature --</option>');

                $.each(response.Data, function (i, item) {
                    $("#ddlNatureofcfr").append(
                        $("<option>").val(item.Nature_Code).text(item.Nature_Name)
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
}

function validateMandatoryFields() {
    var isValid = true;

    var fields = [
        "#ddlItda",
        "#ddlDistrict",
        "#ddlMandal",
        "#ddlPanchayat",
        "#ddlRevVillage",
        "#ddlHabitation",
        "#ddlDivision",
        "#ddlRange",
        "#ddlBeat",
        "#ForestBlockId",
        "#CompNoID",
        "#KhasraId",
        "#NoOFBcMeId",
        "#TotalcfrExtentId",
        "#NaofCrId",
        "#GramasabhaId",
       
    ];

    $(fields).each(function (i, f) {
        var val = $(f).val().trim();
        if (val === "" || val.includes("Select")) {
            $(f).css("border", "1px solid red");
            isValid = false;
        } else {
            $(f).css("border", "");
        }
    });

    return isValid;
}

// ✅ Live remove red border when user selects/enters something
$(document).on("change input","#ddlItda, #ddlDistrict, #ddlMandal, #ddlPanchayat, #ddlRevVillage, #ddlHabitation, #ddlDivision, #ddlRange, #ddlBeat, #ForestBlockId, #CompNoID, #KhasraId, #NoOFBcMeId, #TotalcfrExtentId, #NaofCrId,  #GramasabhaId", function () {
    if ($(this).val().trim() !== "" && !$(this).val().includes("Select")) {
        $(this).css("border", ""); // remove red border
    }
});


function loadDistricts() {
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillage = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var districtName = $("#ContentPlaceHolder1_end").text();
    var requestData = {
        type: "crfdistrict",
        start: ustart,
        District: districtName,
        userprevilages: userprivillage
    };
    console.log("Sending:", requestData);
    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetDropdownsDataCfr',
        data: JSON.stringify(requestData),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (response) {
            console.log("Response:", response);

            if (response.Status === "1" && response.Data) {
                $("#ddlDistrict1").empty().append('<option value="">-- Select DISTRICT --</option>');

                $.each(response.Data, function (i, item) {
                    $("#ddlDistrict1").append(
                        $("<option>")
                            .val(item.District_Code)  // main value
                            .text(item.DISTRICT_NAME)
                            .attr("data-itda", item.ITDA_CODE) // store ITDA in data attribute
                    );
                });
            } else {
                alert("No district data found");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", xhr.responseText || error);
            alert("Error calling API");
        }
    });
}

$("#ddlDistrict1").change(function () {
    var selectedDistrict = $(this).val(); // District_Code (value)
    var selectedItda = $(this).find(":selected").data("itda"); // ITDA_CODE (data attribute)
    sessionStorage.setItem('itdaname', selectedItda);
    if (selectedDistrict === "") {
        $("#ddlMandal1").empty().append('<option value="">-- Select Mandal --</option>');
        return;
    }

    var requestData = {
        type: "Mandal",
        Itda: selectedItda,
        District: selectedDistrict
    };

    console.log("Sending for Mandal:", requestData);

    $.ajax({
        type: 'POST',
        url: '../Giribhumi/GetDropdownsDataCfr',
        data: JSON.stringify(requestData),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (response) {
            $("#ddlMandal1").empty().append('<option value="">-- Select Mandal --</option>');
            $("#ddlMandalbulk").empty().append('<option value="">-- Select Mandal --</option>');
            
            if (response.Status === "1" && response.Data) {
                $.each(response.Data, function (i, item) {
                    $("#ddlMandal1").append(
                        $("<option>").val(item.Mandal_Code).text(item.MANDAL_NAME)
                    );
                    $("#ddlMandalbulk").append(
                        $("<option>").val(item.Mandal_Code).text(item.MANDAL_NAME)
                    );
                });
            } else {
                alert("No Mandals found.");
            }
        },
        error: function (xhr, status, error) {
            console.error("Mandal Error:", xhr.responseText || error);
            alert("Error loading mandals.");
        }
    });
});

function loadcfrdata() {

    var selectedDistrict = $("#ddlDistrict1").val();
    var selectedItda = sessionStorage.getItem('itdaname');
    var mandal = $("#ddlMandalbulk").val();

    var requestData = {
        "PTYPE": "CFR_GET_DATA",
        "itdacode": selectedItda,
        "Districtcode": selectedDistrict,
        "mancode": mandal
    };

    $.ajax({
        url: "../Giribhumi/GetCfrData1",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(requestData),
        success: function (response) {
            // ✅ If DataTable already exists, destroy it FIRST
            if ($.fn.DataTable.isDataTable("#cfrTablemulti")) {
                $("#cfrTablemulti").DataTable().clear().destroy();
            }

            // Clear old rows
            $("#cfrTablemulti tbody").empty();

            if (response.Status === "1" && response.Data && response.Data.length > 0) {
                response.Data.forEach((item, index) => {
                    let row = `
                <tr>
                    <td>${index + 1}</td>
                    <td>${item.CFR_ID}</td>
                    <td>${item.Total_CFR_Members}</td>
                    <td>${item.Total_Extent}</td>
                </tr>`;
                    $("#cfrTablemulti tbody").append(row);
                });

                $("#cfrTablemulti").show();

                // ✅ Re-initialize DataTable after rows are added
                $("#cfrTablemulti").DataTable({
                    paging: true,
                    searching: true,
                    ordering: true,
                    pageLength: 5,
                    lengthMenu: [5, 10, 20, 50]
                });

            } else {
                $("#cfrTablemulti tbody").append(`
            <tr>
                <td colspan="4" class="text-center text-danger">No records found</td>
            </tr>`);
                $("#cfrTablemulti").show();
            }
        },



    });
}

var availableCfrIds = []; // global variable
$('#ddlMandal1').on('change', function () {
   
    var district = $('#ddlDistrict1').val();
    var selectedItda = sessionStorage.getItem('itdaname');
    var mandal = $('#ddlMandal1').val();

  
    // Hide table before making request
    $("#cfrTablemulti").hide();
   
    var requestData = {
        type: "cfr",
        Itda: selectedItda,
        District: district,
        Mandal: mandal
    };
    
    $.ajax({
        url: "../Giribhumi/GetDropdownsDataCfr",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(requestData),
        success: function (response) {
            if (response.Status === "1") {
                var $cfrcode = $('#ddlcfr');
                $cfrcode.empty().append('<option value="">-- Select CFR ID --</option>');
                availableCfrIds = []; // reset before adding new
                $.each(response.Data, function (i, item) {
                    $cfrcode.append('<option value="' + item.CFR_ID + '">' + item.CFR_ID + '</option>');
                    availableCfrIds.push(item.CFR_ID); // ✅ store CFRIDs in global list
                });
                console.log("Available CFRIDs:", availableCfrIds);
            } else {
                alert("No data found.");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error fetching crf:", error);
        }
    });

});

$('#ddlMandalbulk').on('change', function () {

    var district = $('#ddlDistrict1').val();
    var selectedItda = sessionStorage.getItem('itdaname');
    var mandal = $("#ddlMandalbulk").val();
   
   
    $("#cfrTablemulti").show();
    loadcfrdata();
    var requestData = {
        type: "cfr",
        Itda: selectedItda,
        District: district,
        Mandal: mandal
    };

    $.ajax({
        url: "../Giribhumi/GetDropdownsDataCfr",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(requestData),
        success: function (response) {
            if (response.Status === "1") {
                var $cfrcode = $('#ddlcfr');
                $cfrcode.empty().append('<option value="">-- Select CFR ID --</option>');
                availableCfrIds = []; // reset before adding new
                $.each(response.Data, function (i, item) {
                    $cfrcode.append('<option value="' + item.CFR_ID + '">' + item.CFR_ID + '</option>');
                    availableCfrIds.push(item.CFR_ID); // ✅ store CFRIDs in global list
                });
                console.log("Available CFRIDs:", availableCfrIds);
            } else {
                alert("No data found.");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error fetching crf:", error);
        }
    });

});

function normalizeRow(row) {
    let newRow = {};
    Object.keys(row).forEach(k => {
        newRow[k.trim()] = row[k];   // remove spaces
    });
    return newRow;
}
    // Handle Upload & Insert

$("#uploadBtn").on("click", function () {
   
    var username = $("#ContentPlaceHolder1_username").text();
    if (availableCfrIds.length === 0) {
        Swal.fire("Please select District & Mandal first.");
        return;
    }

    var file = $("#excelUpload")[0].files[0];
    if (!file) {
        Swal.fire("Please select an Excel file.");
        return;
    }

    var reader = new FileReader();

    reader.onload = function (e) {
        var data = new Uint8Array(e.target.result);
        var workbook = XLSX.read(data, { type: "array" });

        var firstSheet = workbook.Sheets[workbook.SheetNames[0]];
        var excelRows = XLSX.utils.sheet_to_json(firstSheet);

        // Normalize column names
        excelRows = excelRows.map(r => normalizeRow(r));

        // CFRIDs from Excel
        var excelCfrIds = excelRows.map(r => r.CFRID);

        // ✅ Check if ALL CFRIDs from Excel are in server list
        var allMatched = excelCfrIds.every(cfr => availableCfrIds.includes(cfr));

        if (!allMatched) {
            // Find mismatches
            var invalidFromExcel = excelCfrIds.filter(cfr => !availableCfrIds.includes(cfr));
            // Remove duplicates (make distinct)
            var distinctInvalids = [...new Set(invalidFromExcel)];

            Swal.fire({
                icon: "error",
                html: `
        <p style="color: red; font-weight: bold;">❌ Insert Failed!</p>
        <p>Invalid CFRID(s):</p>
        <ul style="color: darkred;">
            ${distinctInvalids.join(",")}
        </ul>
        <p>Ensure all CFRIDs are valid and try uploading again.</p>
    `,
                showConfirmButton: true
            });
            return; // ❌ Stop, don't insert anything
        }

        // 🔹 Aadhaar validation
        var invalidAadhaars = [];
        var payloadList = excelRows.map(row => {
            let aadhaar = (row.AadhaarNo || "").toString().trim();

            // Allow empty, otherwise must be 12 digits
            if (aadhaar !== "") {
                let isValid = /^[0-9]{12}$/.test(aadhaar);
                if (!isValid) {
                    invalidAadhaars.push(`${row.CFRID} → ${aadhaar}`);
                }
            }

            return {
                PTYPE: "CFR_FARMER_INSERT",
                CFRID: row.CFRID,
                RepreseName: row.RepresentativeName,
                FatherName: row.FatherName,
                Aadhaarno: aadhaar,
                user_name: username,
                IPADDRESS: ""
            };
        });

        // ❌ Stop if invalid Aadhaar numbers exist
        if (invalidAadhaars.length > 0) {
            Swal.fire({
                icon: "error",
                html: `<b>Insert failed!</b><br>Invalid Aadhaar numbers:<br>${invalidAadhaars.join("<br>")}`,
                showConfirmButton: true
            });
            return;
        }

        console.log("Payload JSON:", JSON.stringify(payloadList));

        // ✅ API call
        $.ajax({
            url: "../Giribhumi/FarmerInsertionofcfr",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(payloadList),
            success: function (res) {
                let message = res.Message
                Swal.fire({
                    icon: res.Status === "1" ? "success" : "warning",
                    html: message,
                    showConfirmButton: true
                });

                // Reset
                $("#excelUpload").val("");
                $("#ddlcfr").val("");
                $("#ddlMandal1").val("");
                $("#ddlDistrict1").val("");
            },
            error: function (err) {
                Swal.fire("Something went wrong!");
                console.error("Error:", err);
            }
        });
    };

    reader.readAsArrayBuffer(file);
});


$("#ddlcfr").on("change", function () {
   /* $("#savelatupload").hide();*/
    var selectedCfrid = $(this).val();
    var selectedDistrict = $("#ddlDistrict1").val();
    var selectedItda = sessionStorage.getItem('itdaname');
    var mandal = $('#ddlMandal1').val();

    if (!selectedCfrid) {
        $("#cfrTable tbody").empty();
        return;
    }
    $("#cfrTable").show();
    $("#cfrTablemulti").hide();
    $.ajax({
        url: "../Giribhumi/GetCfrData",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            "PTYPE": "CFR_GET_DATA",
            "itdacode": selectedItda,
            "Districtcode": selectedDistrict,
            "mancode": mandal,
            "CFRID": selectedCfrid
        }),
        success: function (response) {
            var tbody = $("#cfrTable tbody");
            tbody.empty(); // clear previous rows

            
            var submittedCount = updateRowCount();  // get latest number of rows
            console.log("Submitted Row Count = " + submittedCount);

            if (response.Status === "1" && response.Data) {
                $.each(response.Data, function (i, item) {
                    // calculate yet-to-submit
                    var yetToSubmit = item.Total_CFR_Members - submittedCount;

                    // build row
                    var row = "<tr>" +
                        "<td style='border:1px solid #000; text-align:center;'>" + item.Total_CFR_Members + "</td>" +
                        "<td style='border:1px solid #000; text-align:center;'>" + submittedCount + "</td>" +
                        "<td style='border:1px solid #000; text-align:center;'>" + yetToSubmit + "</td>" +
                        "</tr>";

                    tbody.append(row);
                });

                
            } else {
                tbody.append("<tr><td colspan='3' style='border:1px solid #000;'>No data found</td></tr>");
            }
        },
        error: function (xhr, status, error) {
            console.error(error);
            alert("Error loading CFR data");
        }
    });

});

$("#addRowBtn").on("click", function () {
    

    var repName = $("#repName").val().trim();
    var fatherName = $("#fatherName").val().trim();
    var aadhaarNo = $("#aadhaarNo").val().trim();

    if (repName === "" || fatherName === "") {
        alert("Please fill all fields");
        return;
    }
    // normalize aadhaar (remove spaces, dashes, anything non-digit)
    var newAadhaar = aadhaarNo.replace(/\D/g, "");

    //checkAadhaar(function (isValid, message) {
    //    if (!isValid) {
    //        Swal.fire({
    //            toast: true,
    //            position: 'top-center',
    //            icon: 'error',
    //            html: 'This Aadhaar number<br><b>' + newAadhaar + '</b> already exists!<br>',
    //            showConfirmButton: true,
    //            customClass: { popup: 'my-swal-popup' }
    //        });
    //        return; // stop row add
    //    }

    
   

    // optional: basic Aadhaar format check (12 digits)
    //if (!/^\d{12}$/.test(newAadhaar)) {
    //    alert("Please enter a valid 12-digit Aadhaar number (digits only).");
    //    return;
    //}

    // remove any previous highlight
    $("#membersTable tbody tr").removeClass("table-danger");

    // ✅ Check if Aadhaar already exists in table
    var exists = false;
    $("#membersTable tbody tr").each(function () {
        // NOTE: eq(3) = 4th column because your row is: [serial(empty)=0, repName=1, fatherName=2, aadhaar=3, actions=4]
        var existingAadhaar = $(this).find("td").eq(3).text().trim().replace(/\D/g, "");
        if (existingAadhaar === newAadhaar && existingAadhaar !== "") {
            exists = true;
            // highlight the existing row so user can see it
            $(this).addClass("table-danger");
            // scroll to the row (optional)
            $('html, body').animate({ scrollTop: $(this).offset().top - 100 }, 300);
            return false; // break out of .each
        }
    });

    if (exists) {
        /*alert("This Aadhaar number already exists in the table!");*/
        Swal.fire({
            toast: true,
            position: 'top-center',
            icon: 'success',
            html: 'This Aadhaar number<br>:<b>' + newAadhaar + '</b> already exists in the table!',
            showConfirmButton: true,
            customClass: {
                popup: 'my-swal-popup'
            }

        });
        return;
    };

   
    

    // Add row to table
    var newRow = `
        <tr>
            <td></td>
            <td>${repName}</td>
            <td>${fatherName}</td>
            <td>${aadhaarNo}</td>
            <td><button type="button" class="btn btn-danger btn-sm deleteRowBtn">Delete</button></td>
        </tr>
    `;

    $("#membersTable tbody").append(newRow);

    updateSerialNumbers();

    // update row count once
    var totalCount = updateRowCount();
    console.log("Row Count after adding: ", totalCount);

    refreshCfrTable();

    $("#membersTable").show();
    $("#noteid").show();
    $("#cfrTable").show();
   
    // Clear input fields
    $("#repName").val("");
    $("#fatherName").val("");
    $("#aadhaarNo").val("");

});

// Save all rows as JSON
$("#saveBtn").on("click", function () {
    if (availableCfrIds.length === 0) {
        Swal.fire("Please select District & Mandal first.");
        return;
    }
   
    updateSerialNumbers(); // ensure S.No column is up-to-date in UI
    var username = $("#ContentPlaceHolder1_username").text();
    var type ="CFR_FARMER_INSERT"
    var members = [];
    $("#membersTable tbody tr").each(function (index) {
       
        var row = $(this).find("td");
       
        members.push({
            PTYPE: type,
            SNo: index + 1, 
            RepreseName: row.eq(1).text(),
            FatherName: row.eq(2).text(),
            Aadhaarno: row.eq(3).text(),
            CFRID: $("#ddlcfr").val(),
            user_name: username,
            IPADDRESS: ""
        });
        
    });

    console.log("All Members JSON:", members);

    // ✅ Send to API
    $.ajax({
        url: "../Giribhumi/FarmerInsertionofcfr", // replace with your API
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(members),
        success: function (res) {
            /*alert("Data saved successfully!");*/
            Swal.fire({
                toast: true,
                position: 'top-center',
                icon: 'success',
                html: 'Data Submitted successfully',
                showConfirmButton: true,
                customClass: {
                    popup: 'my-swal-popup'
                }
            });
            // clear all input fields
            $("#repName").val("");
            $("#fatherName").val("");
            $("#aadhaarNo").val("");
            $("#ddlDistrict1").val("");
            $("#ddlMandal1").val("");
            $("#ddlcfr").val("");
            $("#membersTable").hide();
            $("#cfrTable").hide();
            $("#noteid").hide();
            $("#addRowBtn").show();
            // ✅ Clear table rows
            $("#LatlongsTable tbody").empty();
            $("#saveBtn").hide();
            console.log(res);
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
});


// hide table if no rows
if ($("#membersTable tbody tr").length === 0) {
    $("#membersTable").hide();
    $("#noteid").hide();
    $("#cfrTable").hide();
}

// delete row handler
$(document).on("click", ".deleteRowBtn", function () {
    $(this).closest("tr").remove();
    updateSerialNumbers();
    updateRowCount();
    refreshCfrTable();
    // hide table if no rows left
    if ($("#membersTable tbody tr").length === 0) {
        $("#membersTable").hide();
        $("#noteid").hide();
        $("#cfrTable").hide();
        $("#addRowBtn").show();
       
        
    }
});
// update S.No column for every row
function updateSerialNumbers() {
    $("#membersTable tbody tr").each(function (index) {
        // set first cell (S.No) text to index+1
        $(this).find("td:eq(0)").text(index + 1);
    });
}

//function checkAadhaar(callback) {
//    var aadhaarNo = $("#aadhaarNo").val().trim();

//    if (aadhaarNo === "") {
//        alert("Please enter Aadhaar number");
//        return;
//    }

//    $.ajax({
//        url: "../Giribhumi/AadharChecking",
//        type: "POST",
//        contentType: "application/json",
//        data: JSON.stringify({ Aadhaarno: aadhaarNo }),
//        success: function (res) {
//            // ✅ Call the callback with the result
//            if (res.Status === "0") {
//                callback(false, res.Message); // Aadhaar already exists
//            } else {
//                callback(true, res.Message);  // Aadhaar is valid
//            }
//        },
//        error: function () {
//            callback(false, "API Error");
//        }
//    });
//}







function refreshCfrTable() {
    var submittedCount = updateRowCount();
    var yetToSubmitTotal = 0; // total yet-to-submit

    // Loop through CFR table rows
    $("#cfrTable tbody tr").each(function () {
        var totalMembers = parseInt($(this).find("td:eq(0)").text()) || 0;
        var yetToSubmit = totalMembers - submittedCount;

        // Ensure yetToSubmit is never negative
        if (yetToSubmit < 0) yetToSubmit = 0;

        $(this).find("td:eq(1)").text(submittedCount);  // update submitted
        $(this).find("td:eq(2)").text(yetToSubmit);     // update yet-to-submit

        yetToSubmitTotal += yetToSubmit;
       // accumulate total
    });

    // Show or hide Save button based on total yet-to-submit
    if (yetToSubmitTotal > 0) {
        $("#saveBtn").hide();
       
    } else {
        $("#saveBtn").show();
       /* $("#addRowBtn").hide();*/
    }
    // ✅ Enable/disable Add Row button
    if (yetToSubmitTotal === 0) {
        $("#addRowBtn").hide();   // disable button
    } else {
        $("#addRowBtn").show(); // enable button
    }
    
}


function updateRowCount() {
    var totalCount = $("#membersTable tbody tr").length;
    console.log("Total rows in membersTable: ", totalCount); // debug
    $("#rowCount").text(totalCount);
    return totalCount;
}

$("#backBtn").on("click", function (e) {
    
    $("#repName1").show();
    $("#fatherName1").show();
    $("#aadhaarNo1").show();
    $("#addRowBtn").show();
    $("#cfrTable").hide();
    $("#savelatupload").show();
    $("#ddlcfr1").show();
    $("#uploadexid").hide();
    $("#backBtn").hide();
    $("#McId").hide();
    $("#membersTable").hide();
    $("#saveBtn").hide();
    $("#cfrTablemulti").hide();
    $('#cfrTablemulti, #cfrTablemulti_wrapper, #cfrTablemulti_filter').hide();
    // ✅ Show nalmandal, hide bulkmandal
    $("#bulkmandal").hide();
    $("#nalmandal").show();     // show normal mandal
    reset();
});

$("#savelatupload").on("click", function (e) {
   
    $("#repName1").hide();
    $("#fatherName1").hide();
    $("#aadhaarNo1").hide();
    $("#addRowBtn").hide();
    $("#savelatupload").hide();
    $("#ddlcfr1").hide();
    $("#cfrTable").hide();
    $("#backBtn").show();
    $("#uploadexid").show();
    $("#McId").show();
   /* $("#cfrTablemulti").hide();*/
    $("#membersTable").hide();
    $("#noteid").hide();
    $("#saveBtn").hide();

    // ✅ Hide nalmandal, show bulkmandal
    $("#nalmandal").hide();
    $("#bulkmandal").show();
  
    reset();
      

});


function ResetAll() {
   
    $("#ddlItda").val(""),
        $("#ddlDistrict").val(""),
        $("#ddlMandal").val(""),
        $("#ddlPanchayat").val(""),
        $("#ddlRevVillage").val(""),
        $("#ddlVillage").val(""),
        $("#ddlHabitation").val(""),
        $("#ddlDivision").val(""),
        $("#ddlRange").val(""),
        $("#ddlBeat").val(""),
        $("#ForestBlockId").val(""),
        $("#CompNoID").val(""),
        $("#KhasraId").val(""),
        $("#RofrPattaId").val(""),
        $("#DesobId").val(""),
        $("#NoOFBcMeId").val(""),
        $("#TotalcfrExtentId").val(""),
        $("#NaofCrId").val(""),
        $("#SupportifanyId").val(""),
        $("#RemarksId").val(""),
        $("#preStaId").val(""),
        $("#CFRDocumentUploadId").val(""),
        $("#CFRDocumentUploadId").replaceWith($("#CFRDocumentUploadId").clone());
}

function reset() {
    $("#ddlDistrict1").val(""),
      $("#ddlMandal1").val("");
    $("#ddlcfr").val("")
}

