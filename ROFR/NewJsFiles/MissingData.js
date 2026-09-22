$(document).ready(function () {
    
    var s = $("#ContentPlaceHolder1_tk").text()
    username = $("#ContentPlaceHolder1_username").text();

    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();

    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var itda = $("#ContentPlaceHolder1_end").text();
    document.getElementById("tbl_exporttable_to_xls").style.display = "none";

    //itda load
    var Type = "13";
    $('input[name=ScreenRadio]').prop('checked', false);
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Missing_Data_Load_Itda',
        data: "{'type':'Itda','Type':'" + Type + "','Itdastart':'" + ustart + "','ITDANAME':'" + itda+"'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            var Itda = response;
            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA_NAME);
                var opt2 = new Option(Itda.Data[i].ITDA_NAME);

                $("#itda").append($('<option>').val(opt2.text).text(opt1.text));

            }
            
        },
        error: function (result) {
            alert("Error");
        }
    });

    $("#itda").change(function () {
        $('.preloader').show();
        
        var itdaname = $('#itda').val();
        var Type = "4";
        $('input[name=ScreenRadio]').prop('checked', false);
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/Missing_Data_Load_District',
            data: "{'type':'LoadDistrict','Itdastart':'" + ustart + "','ITDANAME':'" + itda + "','District':'" + itdaname + "','Type':'" + Type +"'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#DistrictId').empty();
                $("#DistrictId").append('<option value="">Select</option>');
                
                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DISTRICT_NAME);
                    var opt2 = new Option(response.Data[i].DISTRICT_CODE);

                    $("#DistrictId").append($("<option>").val(opt2.text).text(opt1.text));
                    $('.preloader').hide();
                }
               
            },
            error: function (result) {
                alert(dist + "Error");
            }
        });
    });

    $("input[type='radio']").click(function () {

        $('.preloader').show();
        document.getElementById("tbl_exporttable_to_xls").style.display = "none";
        var itdanam = $("#itda").val();
        var SetType = "12";
        var dis_code = $('#DistrictId').val();
        var screen = $("input[name='ScreenRadio']:checked").val();
        if (itdanam == "select") {
			
            alert("Please Select ITDA Name and District");
            $('.preloader').hide();
			return;

        }
        else if (dis_code == "select" || dis_code == "") {
			
            alert("Please Select District");
            $('.preloader').hide();
			return;
        }
        else {
            $('.preloader').fadeIn(3000, function () {
            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                url: '../Giribhumi/Missing_Data_DownLoad',
                data: "{'type':'MissingDataDownload','Itda':'" + itdanam + "','Type':'" + SetType + "','screen':'" + screen + "','District_Code':'" + dis_code + "'}",
                dataType: "json",

                success: function (response) {
                    console.log(response);
                    var rows = "";
                    UIDList = response;
                    data = response.Data;
                    if (!data) {
                        alert('No data available');
                    }
                    else {
                        for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                            rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td >" + response.Data[i].benficiary_id + "</td><td>" + response.Data[i].ITDA_NAME + "</td><td >" + response.Data[i].District + "</td><td >" + response.Data[i].Mandal + "</td><td >" + response.Data[i].Gram_Panchayat + "</td><td >" + response.Data[i].Village + "</td><td >" + response.Data[i].Habitation + "</td><td >" + response.Data[i].Compartment_No + "</td><td >" + response.Data[i].ROFR_PATTANO + "</td><td >" + response.Data[i].ROFR_PATTADAAR + "</td><td >" + response.Data[i].Father_Name + "</td><td >" + response.Data[i].Aadhaar_NO + "</td><td >" + response.Data[i].BankAccountNo + "</td><td >" + response.Data[i].IfscCode + "</td><td >" + response.Data[i].BankName + "</td></tr>";
                        }
                        $('#tbl_exporttable_to_xls tbody').empty();
                        $(rows).appendTo("#tbl_exporttable_to_xls tbody");
                        ExportToExcel('xls');

                    }
                    $('.preloader').hide();

                },

                error: function (result) {
                    alert(result);
                }

            });
                $('.preloader').fadeOut(1000)
            })
            /*$('.preloader').hide();*/
        }
        
    });
    
})


function ExportToExcel(type, fn, dl) {
	
    $('.preloader').show();
    var elt = document.getElementById('tbl_exporttable_to_xls');
    var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
    return dl ?
        XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
        XLSX.writeFile(wb, fn || ('MISSING AND INVALID DATA EXPORT TO EXCEL.' + (type || 'xls')));
}


