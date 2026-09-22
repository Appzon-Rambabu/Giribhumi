$(document).ready(function () {
    $("#mfpsaveBtn").hide();
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

            if (response.Status === "1" && response.Data && response.Data.length > 0) {

                $("#ddlDistrict1").empty();
                $("#ddlDistrict1").append('<option value="">-- Select DISTRICT --</option>');

                // 🔹 Get unique districts using Set
                var uniqueNames = new Set();

                $.each(response.Data, function (i, item) {

                    //  var name = item.DISTRICT_NAME.trim().toUpperCase();
                    var name = item.DISTRICT_NAME;

                    if (!uniqueNames.has(name)) {

                        uniqueNames.add(name);

                        $("#ddlDistrict1").append(
                            $("<option>")
                                .val(item.District_Code)           // keep district code
                                .text(item.DISTRICT_NAME)          // display name only
                                .attr("data-itda", item.ITDA_CODE) // store ITDA
                        );
                    }
                });

            } else {

                $("#ddlDistrict1").empty()
                    .append('<option value="">-- No District Found --</option>');
            }
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
            url: '../Giribhumi/viewcfrData',
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
            type: "cfrmfp",
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
                    var $cfrcode = $('#ddlcfrmfp');
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


    $('#ddlcfrmfp').change(function () {

        var selectedValue = $(this).val();

        if (selectedValue !== "") {
            $('#tbltbtId').show();
            LoadddlProductName();
        } else {
            $('#tbltbtId').hide();   // ❌ Hide if no selection
        }

    });


    function LoadddlProductName() {
        //Load Nature ddl

        var reqnatureddl = {
            type: "CfrProductNameddl"
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
                    $("#ddlmfpPrdName").empty().append('<option value="">-- Select Product --</option>');

                    $.each(response.Data, function (i, item) {
                        $("#ddlmfpPrdName").append(
                            $("<option>").val(item.ProductCode).text(item.ProductName)
                        );
                    });

                } else {
                    alert("No Product data found");
                }
                $("#loader").hide();
            },

            error: function (xhr, status, error) {
                console.error("Error:", xhr.responseText || error);
                alert("Error calling API");
            }

        });
    }

    $("#addRowBtn").on("click", function () {
        var ProductCode = $("#ddlmfpPrdName").val();  // ✅ gets ProductCode
        var ProductName = $("#ddlmfpPrdName option:selected").text().trim();
        var TotalAcres = $("#TotalAcresID").val().trim();
        var IncomePerAnnum = $("#IncomePerAnnumID").val().trim();
        var PointOfSale = $("#PointOfSaleID").val().trim();
        var ProductQuantity = $("#QuantityID").val().trim();
        

        if (ProductName === "" || TotalAcres === "" || IncomePerAnnum === "" || PointOfSale === "" || ProductQuantity === "" ) {
            alert("Please fill all fields");
            return;
        }

        // Add row to table
        var newRow = `
                <tr>
                    <td class="sno"></td>
                    <td class="productCode" style="display:none;">${ProductCode}</td>
                    <td class="productName">${ProductName}</td>
                    <td class="totalAcres">${TotalAcres}</td>
                    <td class="incomePerAnnum">${IncomePerAnnum}</td>
                    <td class="pointOfSale">${PointOfSale}</td>
                    <td class="productQuantity">${ProductQuantity}</td>
                    <td><button type="button" class="btn btn-danger btn-sm deleteRowBtn">Delete</button></td>
                </tr>
                `;

        $("#mfpProductTable tbody").append(newRow);

        updateSerialNumbers();
        reset();
        $("#mfpsaveBtn").show();
        $("#mfpProductTable").show();
        // Enable save button only if there are 4 or more rows
        var rowCount = $("#mfpProductTable tbody tr").length;
        if (rowCount >= 1) {
            $("#mfpsaveBtn").show();
        } else {
            $("#mfpsaveBtn").hide(); // hide if less than 4
        }
        reset();
    });

    // Function to update S.No column
    function updateSerialNumbers() {
        $("#mfpProductTable tbody tr").each(function (index) {
            $(this).find("td:first").text(index + 1);
        });
    }

    // Delete row
    $("#mfpProductTable").on("click", ".deleteRowBtn", function () {
        $(this).closest("tr").remove();
        updateSerialNumbers();
        $("backBtn").hide();
    });

    if ($("#mfpProductTable tbody tr").length === 0) {
        $("#mfpProductTable").hide();
        $("#mfpsaveBtn").hide();
        $("backBtn").hide();
    }

    $(document).on("click", ".deleteRowBtn", function () {
        $(this).closest("tr").remove();
        updateSerialNumbers();
        // Check rows count after deletion
        var rowCount = $("#mfpProductTable tbody tr").length;
        if (rowCount >= 4) {
            $("#mfpsaveBtn").show();
        } else {
            $("#mfpsaveBtn").hide();
        }
        $("#mfpsaveBtn").hide();
        $("#backBtn").hide();
        $("#McId").hide();
        // hide table if no rows left
        if ($("#mfpProductTable tbody tr").length === 0) {
            $("#mfpProductTable").hide();
        }
    });
    function updateSerialNumbers() {
        $("#mfpProductTable tbody tr").each(function (index) {
            // set first cell (S.No) text to index+1
            $(this).find("td:eq(0)").text(index + 1);
        });
    }

    $("#mfpsaveBtn").on("click", function () {

        updateSerialNumbers();

        var username = $("#ContentPlaceHolder1_username").text();
        var type = "CFR_PRODUCT_INSERT";
        var members = [];

        $("#mfpProductTable tbody tr").each(function (index) {

            var row = $(this).find("td");
            members.push({
                PTYPE: type,
                CFRID: $("#ddlcfrmfp").val(),
                ProductCode: $(this).find(".productCode").text().trim(),
                ProductName: $(this).find(".productName").text().trim(),
                TotalAcres: $(this).find(".totalAcres").text().trim(),
                IncomePerAnnum: $(this).find(".incomePerAnnum").text().trim(),
                PointOfSale: $(this).find(".pointOfSale").text().trim(),
                ProductQuantity: $(this).find(".productQuantity").text().trim(),
                user_name: username,
                IPADDRESS: ipadress
            });

        });

        console.log("All Members JSON:", members);

        $.ajax({
            url: "../Giribhumi/cfrmfrSavedata",
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
                reset1();
                $("#mfpProductTable tbody").empty();
                $("#mfpProductTable").hide();
                $("#mfpsaveBtn").hide();
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
        // Clear all fields
        $("#ddlmfpPrdName").prop("selectedIndex", 0);   // Reset dropdown to first option
        $("#TotalAcresID").val("");
        $("#IncomePerAnnumID").val("");
        $("#PointOfSaleID").val("");  // Reset dropdown
        $("#QuantityID").val("");
        // Optional: focus first field again
        $("#ddlmfpPrdName").focus();
    }
    function reset1() {
        $("#ddlDistrict1").val("");
        $("#ddlMandal1").val("");  // Reset dropdown
        $("#ddlcfrmfp").val("");
    }
});