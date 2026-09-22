$(document).ready(function () {
    $("#saveBtn").hide();
    $("#backBtn").hide();
    $("#McId").hide();
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillage = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ipadress = $("#ContentPlaceHolder1_ipadress").text();
    var userId = $("#ContentPlaceHolder1_userid").text();
    var districtName = $("#ContentPlaceHolder1_end").text();
   
    console.log("UserID from session: " + userId);
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

                if (response.Status === "1" && response.Data) {
                    $.each(response.Data, function (i, item) {
                        $("#ddlMandal1").append(
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
    var availableCfrIds = []; // global variable
    $('#ddlMandal1').on('change', function () {
        var district = $('#ddlDistrict1').val();
        var selectedItda = sessionStorage.getItem('itdaname');
        var mandal = $('#ddlMandal1').val();


        var requestData = {
            type: "cfrLatLongs",
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

    $("#addRowBtn").on("click", function () {
        var LATITUDE = $("#LATITUDEID").val().trim();
        var LONGITUDE = $("#LONGITUDEID").val().trim();

        if (LATITUDE === "" || LONGITUDE === "") {
            alert("Please fill all fields");
            return;
        }

        // Add row to table
        var newRow = `
        <tr>
            <td></td> <!-- S.No will be updated -->
            <td>${LATITUDE}</td>
            <td>${LONGITUDE}</td>
            <td><button type="button" class="btn btn-danger btn-sm deleteRowBtn">Delete</button></td>
        </tr>
    `;
        
         $("#LatlongsTable tbody").append(newRow);

        updateSerialNumbers();
        $("#saveBtn").show();
        $("#LatlongsTable").show();
        // Enable save button only if there are 4 or more rows
        var rowCount = $("#LatlongsTable tbody tr").length;
        if (rowCount >= 4) {
            $("#saveBtn").show();
        } else {
            $("#saveBtn").hide(); // hide if less than 4
        }
        // Clear input fields
        $("#LATITUDEID").val("");
        $("#LONGITUDEID").val("");
    });

    // Function to update S.No column
    function updateSerialNumbers() {
        $("#LatlongsTable tbody tr").each(function (index) {
            $(this).find("td:first").text(index + 1);
        });
    }

    // Delete row
    $("#LatlongsTable").on("click", ".deleteRowBtn", function () {
        $(this).closest("tr").remove();
        updateSerialNumbers();
        $("backBtn").hide();
    });

    if ($("#LatlongsTable tbody tr").length === 0) {
        $("#LatlongsTable").hide();
        $("#saveBtn").hide();
        $("backBtn").hide();
    }

    $(document).on("click", ".deleteRowBtn", function () {
        $(this).closest("tr").remove();
        updateSerialNumbers();
        // Check rows count after deletion
        var rowCount = $("#LatlongsTable tbody tr").length;
        if (rowCount >= 4) {
            $("#saveBtn").show();
        } else {
            $("#saveBtn").hide();
        }
        $("#saveBtn").hide();
        $("#backBtn").hide();
        $("#McId").hide();
        // hide table if no rows left
        if ($("#LatlongsTable tbody tr").length === 0) {
            $("#LatlongsTable").hide();
        }
    });
    function updateSerialNumbers() {
        $("#LatlongsTable tbody tr").each(function (index) {
            // set first cell (S.No) text to index+1
            $(this).find("td:eq(0)").text(index + 1);
        });
    }

    $("#saveBtn").on("click", function () {
        updateSerialNumbers(); // ensure S.No column is up-to-date in UI
        var username = $("#ContentPlaceHolder1_username").text();
        var type = "CFR_LATLONGS_INSERT"
        var members = [];
        $("#LatlongsTable tbody tr").each(function (index) {

            var row = $(this).find("td");

            members.push({
                PTYPE: type,
                SNo: index + 1,
                LATITUDE: row.eq(1).text(),
                LONGITUDE: row.eq(2).text(),
                CFRID: $("#ddlcfr").val(),
                user_name: username,
                IPADDRESS: ipadress
            });

        });

        console.log("All Members JSON:", members);

        // ✅ Send to API
        $.ajax({
            url: "../Giribhumi/Latlonsaveforfarmer", 
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(members),
            success: function (res) {
               
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
                $("#LATITUDEID").val("");
                $("#LONGITUDEID").val("");
                $("#ddlDistrict1").val("");
                $("#ddlMandal1").val("");
                $("#ddlcfr").val("");
                $("#LatlongsTable").hide();
                // ✅ Clear table rows
                $("#LatlongsTable tbody").empty();

                // hide table and save button
                $("#LatlongsTable").hide();
                $("#saveBtn").hide();
                $("#backBtn").hide();
                $("#McId").hide();
                console.log(res);
            },
            error: function (err) {
                console.log("Error:", err);
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
                    html: `<b>Insert failed!</b><br>CFRID:<br>${distinctInvalids.join(",")} is not valid`,
                    showConfirmButton: true
                });
                return; // ❌ Stop, don't insert anything
            }

            // ✅ Prepare payload (since all are valid)
            var payloadList = excelRows.map(row => ({
                PTYPE: "CFR_LATLONGS_INSERT",
                CFRID: row.CFRID,
                LATITUDE: row.LATITUDE,
                LONGITUDE: row.LONGITUDE,
                user_name: username,
                IPADDRESS: ""
            }));

            console.log("Payload JSON:", JSON.stringify(payloadList));

            $.ajax({
                url: "../Giribhumi/Latlonsaveforfarmer",
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
   
    $("#backBtn").on("click", function (e) {

        $("#tbltbtId").show();
        $("#uploadexid").hide();
        $("#dropdownid").show();
        $("#savelatupload").show();
        $("#backBtn").hide();
        $("#McId").hide();
        $("#cfriddll").show();
        reset();
    });

    $("#savelatupload").on("click", function (e) {
        
        $("#tbltbtId").show();
        $("#uploadid").hide();
        $("#dropdownid").show();
        $("#backBtn").show();
        $("#uploadexid").show();
        $("#McId").show();
        $("#cfriddll").hide();
        
        reset();

    });
    function reset() {
        $("#LATITUDEID").val("");
        $("#LONGITUDEID").val("");
        $("#ddlDistrict1").val("");
        $("#ddlMandal1").val("");
        $("#ddlcfr").val("");
    }
});