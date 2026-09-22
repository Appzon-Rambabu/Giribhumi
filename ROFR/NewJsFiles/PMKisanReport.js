$(document).ready(function () {
    LoadPMKisanReport("2026-2027");
   
});
function LoadPMKisanReport(financialYear) {

    $.ajax({
        type: "POST",
        url: "../Giribhumi/getPMKisanReport",
        data: JSON.stringify({
            FinancialYear: financialYear
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if ($.fn.DataTable.isDataTable('#dt_Cultivation_tbl')) {
                $('#dt_Cultivation_tbl').DataTable().clear().destroy();
            }
            $("#dtButtons").empty();
            $("#dtSearch").empty();

            var data = response;

            if (response.Data)
                data = response.Data;

            if (response.Data1)
                data = response.Data1;

            if (financialYear != "2026-2027") {

                data = [];
            }

            BindTable(data);

            $('#dt_Cultivation_tbl').DataTable({

                destroy: true,
                autoWidth: false,
                searching: true,
                ordering: false,
                info: true,
                paging: false,
                scrollY: false,
                paging: true,
                pageLength: 10,
                fixedHeader: true,             

                dom: 'Bfrtip',
                buttons: [
                    { extend: 'copy' },
                    { extend: 'excelHtml5' },
                    { extend: 'csvHtml5' },
                    { extend: 'pdfHtml5', orientation: 'landscape', pageSize: 'A3' },
                    { extend: 'print' }
                ],

                initComplete: function () {

                    var table = this.api();

                    // Move Buttons
                    $("#dtButtons").empty();
                    table.buttons().container().appendTo("#dtButtons");

                    // Move Search
                    $("#dtSearch").empty();
                    $("#dt_Cultivation_tbl_filter").appendTo("#dtSearch");

                    // Fix Header Width
                    setTimeout(function () {

                        table.columns.adjust();

                        (".dataTables_scrollHeadInner").css("width", "100%");
                        (".dataTables_scrollHeadInner table").css("width", "100%");
                        (".dataTables_scrollBody table").css("width", "100%");

                    }, 300);

                    // Financial Year Dropdown
                    if ($("#ddlFinancialYear option").length == 0) {

                        for (var i = 2026; i <= 2035; i++) {

                            var fy = i + "-" + (i + 1);

                            $("#ddlFinancialYear").append(
                                '<option value="' + fy + '">' + fy + '</option>'
                            );
                        }

                        $("#ddlFinancialYear").val(financialYear);

                        $("#ddlFinancialYear").change(function () {

                            LoadPMKisanReport($(this).val());

                        });
                    }

                },

                language: {
                    emptyTable: "No Data Found"
                }

            });

        },
        error: function (xhr) {

            console.log(xhr);

            alert("Error while loading data.");

        }

    });

}

function BindTable(data) {

    $("#dt_Cultivation_tbl thead").html(`
    <tr>
        <th rowspan="2">S.No</th>
        <th rowspan="2">District</th>
        <th colspan="2">First Installment</th>
        <th colspan="2">Second Installment</th>
        <th colspan="2">Third Installment</th>
    </tr>
    <tr>
        <th>Beneficiaries</th>
        <th>Amount</th>
    
        <th>Beneficiaries</th>
        <th>Amount</th>
    
        <th>Beneficiaries</th>
        <th>Amount</th>
    </tr>
`);

    var tbody = $("#dt_Cultivation_tbl tbody");
    tbody.empty();

    if (data.length == 0) {

        return;

    }

    $.each(data, function (i, item) {

        var district = item.DistrictName || "";

        var isTotal = district.trim().toUpperCase() === "TOTAL";

        tbody.append(`
            <tr ${isTotal ? 'style="font-weight:bold;background:#f2f2f2;"' : ''}>
                <td>${isTotal ? '' : (i + 1)}</td>
                <td>${district}</td>
                <td>${FormatNumber(item.Beneficiaries)}</td>
                <td>${FormatNumber(item.Amount)}</td>
                <td>${FormatNumber(0)}</td>
                <td>${FormatNumber(0)}</td>
                <td>${FormatNumber(0)}</td>
                <td>${FormatNumber(0)}</td>
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
        return "0";

    var num = parseFloat(value);

    if (isNaN(num))
        return "0";

    return num.toLocaleString('en-IN', {
        maximumFractionDigits: 0
    });
}


