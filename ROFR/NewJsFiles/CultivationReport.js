$(document).ready(function () {
    $.ajax({

        type: "POST",
        url: "../Giribhumi/getCultivationReport",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.Status == "1") {
                console.log($.fn.dataTable.version);

                BindTable(response.Data);

                if ($.fn.DataTable.isDataTable('#dt_Cultivation_tbl')) {
                    $('#dt_Cultivation_tbl').DataTable().destroy();
                }

                $('#dt_Cultivation_tbl').DataTable({
                    destroy: true,
                    autoWidth: false,
                    searching: true,
                    ordering: false,
                    info: true,
                    paging: false,
                    scrollY: 500,
                    scrollX: true,
                    scrollCollapse: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { extend: 'copy' },
                        { extend: 'excelHtml5' },
                        { extend: 'csvHtml5' },
                        { extend: 'pdfHtml5', orientation: 'landscape', pageSize: 'A3' },
                        { extend: 'print' }
                    ]
                });


            }
            else {

                $("#dt_Cultivation_tbl tbody").empty();
                alert("No Data Found");

            }

        },
        error: function (xhr) {

            console.log(xhr);

            alert("Error while loading data.");

        }

    });

});

function BindTable(data) {

    // Create Header Dynamically
    $("#dt_Cultivation_tbl thead").html(`
        <tr>
            <th>S.No<br><span>(1)</span></th>
            <th>District<br>(Recontinued District)<br><span>(2)</span></th>
            <th>Extent of IFR Land<br>Under Cultivation<br><span>(3)</span></th>
            <th>Cereals<br><span>(4)</span></th>
            <th>Millets<br><span>(5)</span></th>
            <th>Pulses<br><span>(6)</span></th>
            <th>Fruits<br><span>(7)</span></th>
            <th>Commercial Crop<br><span>(8)</span></th>
            <th>Vegetables<br><span>(9)</span></th>
            <th>Others<br><span>(10)</span></th>
            <th>Total Land <br>Under Cultivation<br>in Acres<br><span>(11)</span></th>
            <th>Un Cultivable Land<br>in Acres<br><span>(12)</span></th>
        </tr>
    `);

    var tbody = $("#dt_Cultivation_tbl tbody");
    tbody.empty();

    $.each(data, function (i, item) {
        var district = item.District_Name || item.District || "";

        var isTotal = district.trim().toUpperCase() === "TOTAL";

        var sno = isTotal ? "" : (i + 1);

        tbody.append(`
           <tr ${isTotal ? 'style="font-weight:bold;background:#f2f2f2;"' : ""}>
            <td>${sno}</td>
            <td>${isTotal ? "TOTAL" : district}</td>
                
                <td>${FormatNumber(item.IFR_Extent_UnderCultivation)}</td>
                <td>${FormatNumber(item.Cereals)}</td>
                <td>${FormatNumber(item.Millets)}</td>
                <td>${FormatNumber(item.Pulses)}</td>
                <td>${FormatNumber(item.Fruits)}</td>
                <td>${FormatNumber(item.Commercial_Crop)}</td>
                <td>${FormatNumber(item.Vegetables)}</td>
                <td>${FormatNumber(item.Others)}</td>
                <td>${FormatNumber(item.Tot_Land_UnderCultivation)}</td>
                <td>${FormatNumber(item.UnCultivable_Land)}</td>
            </tr>
        `);
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


function FormatNumber(value) {

    if (value == null || value == "" || value == undefined)
        return "0.00";

    var num = parseFloat(value);

    if (isNaN(num))
        return "0.00";

    return num.toLocaleString('en-IN', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}


