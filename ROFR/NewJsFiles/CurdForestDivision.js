
$(document).ready(function () {
    $('#CurdforestDivsionId_tbl').hide();
    LoadDistrict();
    
    // Here Modal Popup Close Once click on closebutton
    $("#btnClosePopup").click(function () {
        $("#DeleteModal").hide();
    });
    

    $('body').on('click', '.btn-delete', function () {
        alert('ARE YOU SURE WANT DELETE THIS RECORD');
        $(this).parents('tr').remove();
    });

    $('body').on('click', '.btn-edit', function () {
        $("#EditModal").show();
    })

    

})

function LoadDistrict() {
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/CurdForestDivision_Analysis',
        data: "{'type':'Division','start':'','ITDANAME':''}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            $("#ddl_district").append('<option value="">Select</option>');
            var Dis = response;
            for (var i = 0; i < Dis.Data.length; i++) {
                var opt1 = new Option(Dis.Data[i].DISTRICT_NAME);
                var opt2 = new Option(Dis.Data[i].DISTRICT_CODE);

                $("#ddl_district").append($('<option>').val(opt2.text).text(opt1.text));

            }
            $('.preloader').hide();

        },
        error: function (result) {
            alert("Error");
        }
    });
}
// here is district change
$("#ddl_district").change(function () {

    
        District = $("#ddl_district").val();

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetForestDivisionDetails',
            data: "{'type':'FDDetails','District':'" + District + "'}",
            dataType: "json",
            success: function (response) {
                console.log(response);
                var rows = "";
                for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                    rows += "<tr><td>" + response.Data[i].FOREST_DIVISION_CODE + "</td><td style='text-align:left'>" + response.Data[i].FOREST_DIVISION_NAME + "</td><td style='text-align:center' ><button class='btn  btn-md btn-edit'><i class='fas fa-edit'></i></button></td><td style='text-align:center'><button class='btn  btn-md btn-delete'><i class='fas fa-trash'></i></button></td></tr>";
                }
                $('#CurdforestDivsionId_tbl tbody').empty();
                $(rows).appendTo("#CurdforestDivsionId_tbl tbody");
                $('#CurdforestDivsionId_tbl').show();
               
            },
            error: function (result) {
                alert(result);
            }

        });
    
});



