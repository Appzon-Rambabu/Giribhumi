

$(document).ready(function () {
    Get_Cultivation_Report();
});

function Get_Cultivation_Report() {
    $.ajax({
        type: "POST",
        url: "../Giribhumi/agricultureHorticulture",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            type: "AgricultureHorticulture"
        }),

        success: function (response) {
            if (response.Status == "1") {
                if ($.fn.DataTable.isDataTable('#dt_Cultivation_tbl')) {
                    $('#dt_Cultivation_tbl').DataTable().destroy();
                }

                BindTable(response.Data);

                $('#dt_Cultivation_tbl').DataTable({
                    destroy: true,
                    paging: true,
                    searching: true,
                    ordering: false,
                    info: true,
                    pageLength: 50,
                    scrollX: true,
                    autoWidth: false,
                    scrollCollapse: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { extend: 'copy', text: 'Copy' },
                        { extend: 'excelHtml5', text: 'Excel' },
                        { extend: 'csvHtml5', text: 'CSV' },
                        {
                            extend: 'pdfHtml5',
                            text: 'PDF',
                            orientation: 'landscape',
                            pageSize: 'A3'
                        },
                        { extend: 'print', text: 'Print' }
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
}
function BindTable(data) {

    var tbody = $("#dt_Cultivation_tbl tbody");
    tbody.empty();

    $.each(data, function (i, item) {

        var row = "<tr>";

        // S.No & District
        if (item.District_Name &&
            item.District_Name.toString().trim().toUpperCase() == "TOTAL") {

            row += "<td></td>";
            row += "<td style='text-align:left;font-weight:bold;'>TOTAL</td>";

        } else {

            row += "<td>" + (i + 1) + "</td>";
            row += "<td style='text-align:left !important'>" + item.District_Name + "</td>";
        }

        row += "<td>" + FormatNumber(item.IFR_Extent_UnderCultivation) + "</td>";

        row += "<td>" + FormatNumber(item.Cereals_Paddy) + "</td>";
        row += "<td>" + FormatNumber(item.Cereals_Wheat) + "</td>";
        row += "<td>" + FormatNumber(item.Cereals_Maize) + "</td>";

        row += "<td>" + FormatNumber(item.Millets) + "</td>";
        row += "<td>" + FormatNumber(item.Millets_Korralu) + "</td>";
        row += "<td>" + FormatNumber(item.Millets_Ragi) + "</td>";
        row += "<td>" + FormatNumber(item.Millets_Bajra) + "</td>";
        row += "<td>" + FormatNumber(item.Millets_Jowar) + "</td>";

        row += "<td>" + FormatNumber(item.Pulses_Minumulu) + "</td>";
        row += "<td>" + FormatNumber(item.Pulses_Pesalu) + "</td>";
        row += "<td>" + FormatNumber(item.Pulses_Kandulu) + "</td>";
        row += "<td>" + FormatNumber(item.Pulses_Senagalu) + "</td>";
        row += "<td>" + FormatNumber(item.Pulses_Rajma) + "</td>";

        row += "<td>" + FormatNumber(item.Fruits_Pine_Apple) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Mango) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Banana) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Guva) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Straw_Berry) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Sapota) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Sweet_Orange) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Crusted_Apple) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Citrus) + "</td>";
        row += "<td>" + FormatNumber(item.Fruits_Jafra) + "</td>";

        row += "<td>" + FormatNumber(item.Leafy_Vegetables) + "</td>";
        row += "<td>" + FormatNumber(item.Tomato_Vegetables) + "</td>";
        row += "<td>" + FormatNumber(item.Beans_Vegetables) + "</td>";

        row += "<td>" + FormatNumber(item.Cashew) + "</td>";
        row += "<td>" + FormatNumber(item.Coffee) + "</td>";
        row += "<td>" + FormatNumber(item.Turmeric) + "</td>";
        row += "<td>" + FormatNumber(item.Tobacco) + "</td>";
        row += "<td>" + FormatNumber(item.Sugar_Cane) + "</td>";
        row += "<td>" + FormatNumber(item.Ground_Nut) + "</td>";
        row += "<td>" + FormatNumber(item.Cotton) + "</td>";
        row += "<td>" + FormatNumber(item.Ginger) + "</td>";
        row += "<td>" + FormatNumber(item.Sweet_Corn) + "</td>";
        row += "<td>" + FormatNumber(item.Brooms) + "</td>";
        row += "<td>" + FormatNumber(item.Bamboo) + "</td>";
        row += "<td>" + FormatNumber(item.Coconut) + "</td>";
        row += "<td>" + FormatNumber(item.Rubber) + "</td>";
        row += "<td>" + FormatNumber(item.Palm_Oil) + "</td>";
        row += "<td>" + FormatNumber(item.COCO) + "</td>";
        row += "<td>" + FormatNumber(item.Teak) + "</td>";
        row += "<td>" + FormatNumber(item.Chilli_RedChilli) + "</td>";
        row += "<td>" + FormatNumber(item.Sesame_Seeds) + "</td>";

        row += "<td>" + FormatNumber(item.Others) + "</td>";
        row += "<td>" + FormatNumber(item.Tot_Land_UnderCultivation) + "</td>";
        row += "<td>" + FormatNumber(item.UnCultivable_Land) + "</td>";

        row += "</tr>";

        tbody.append(row);
    });
}

function FormatNumber(value) {
    if (value == null || value === "" || isNaN(value)) {
        return "0.00";
    }

    return Number(value).toFixed(2);
}