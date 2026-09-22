$(document).ready(function () {
    //$('#tbl_exporttable_to_xls').show();
      
    document.getElementById("tbl_exporttable_to_xls").style.display = "none";
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
   
    username = $("#ContentPlaceHolder1_username").text();
    userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    itdaname = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
  

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_wise_Farmer_Details',
        data: "{'type':'Itda','start':'" + ustart + "','userprevilages':'" + userprivillages + "'}",
        dataType: "json",
        success: function (response) {
            console.log(JSON.stringify(response));
            var Itda = response;
           
            for (var i = 0; i < Itda.Data.length; i++) {
                var opt1 = new Option(Itda.Data[i].ITDA_NAME);
                var opt2 = new Option(Itda.Data[i].ITDA_CODE);
                $('#itda').append($('<option>').val(opt2.text).text(opt1.text));
            }
            $('.preloader').hide();
        },
       
    });

    /* FOR District LOAD*/

    $("#itda").change(function () {
        var ITDANAME = $("#ContentPlaceHolder1_end").text();
        $('.preloader').show();
        var screen = 'District';
         var Itda = $("#itda").val();
        /*var Itda = $('#itda :selected').val();*/
       /* var Itda = "1";*/
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetItda_wise_Farmer_Details',
            data: "{'type':'" + screen + "','Itdacode':'" + Itda + "','start':'" + ustart + "','ITDANAME':'" + ITDANAME+"'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#Districtid').empty();
                $("#Districtid").append('<option value="">Select</option>');

                for (var i = 0; i < response.Data.length; i++) {
                    var opt1 = new Option(response.Data[i].DISTRICT_NAME);
                    var opt2 = new Option(response.Data[i].LGD_DISTRICT_CODE);

                    $("#Districtid").append($("<option>").val(opt2.text).text(opt1.text));

                }
                $('.preloader').hide();
            },
        });
    });

    /*For SelectRecords*/
    $("#Districtid").change(function () {

        $('.preloader').show();
       
        var itdaname = $('#itda :selected').text();
        var distname = $('#Districtid :selected').text();
       /* alert(itdaname);*/
        sessionStorage.setItem("ITDA", itdaname);
        sessionStorage.setItem("Dist", distname);
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '../Giribhumi/GetItda_ben_count',
            data: "{'type':'Count','Itda':'" + itdaname + "','DistrictName':'" + distname+"'}",
            dataType: "json",
            success: function (response) {
                console.log(JSON.stringify(response));
                $('#SelectRecordsid').empty();
                $('#SelectRecordsid')
                    .append($("<option>--Select--</option>"));
                var rowscount = response;
                let k = '';

                for (var i = 0; i < response.Data.length; i++) {
                   
                    var opt2 = new Option(response.Data[i].COUNT);

                    for (var i = 1; i <= opt2.text; i++) {
                        if (opt2.text <= 100) {
                            j = i + (opt2.text - 1);
                            k = i + "-" + j;
                           
                            $('#SelectRecordsid')
                                .append($("<option></option>")
                                    .attr("value", k)
                                    .text(k));
                           
                            i = j;
                        }
                        else {
                            var remainingrows = opt2.text - i;
                            if (remainingrows > 100) {
                                var j = i + 99;
                                k = i + "-" + j;
                                
                                $('#SelectRecordsid')
                                    .append($("<option></option>")
                                        .attr("value", k)
                                        .text(k));
                                
                                i = j;
                            }
                            else {
                                var j = (i) + remainingrows;
                                k = i + "-" + j;
                                
                                $('#SelectRecordsid')
                                    .append($("<option></option>")
                                        .attr("value", k)
                                        .text(k));
                                
                                i = j;
                                break;
                            }
                        }
                    }
                  
                }

                $('.preloader').hide();
            },

        });

        DownloadAll();
    });

   
   
});




/* SelectRecord changes*/
$("#SelectRecordsid").change(function () {
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
   
    Get_Districts();
    DownloadAll();
});




function Get_Districts() {

    
    $('.preloader').show();
   
    DownloadAll();
    // Here Split records 
    var splitval = $("#SelectRecordsid").val();
    const myArray = splitval.split("-");
    var start = document.getElementById("SelectRecordsid").classList = myArray[0];
    var end = document.getElementById("SelectRecordsid").classList = myArray[1];
    var distname = $('#Districtid :selected').text();
    var itdaname = $('#itda :selected').text();
   /* var itdaname = $("#itda").val();*/
    sessionStorage.setItem('INPUT', itdaname);
   /* alert(itdaname);*/
    var count = 0;
    var printCounter = 0;
    
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{ 'type':'DataDisplay','Itda':'" + itdaname + "','start':'" + start + "','end':'" + end + "','DistrictName':'" + distname+"'}",
        dataType: "json",
       
        success: function (response) {

            if (response.Status == "1") {
                $('#dt_dist_tbl').show();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    ordering: false,
                    order: [[3, 'desc']],
                    buttons: [

                        {
                            extend: 'copy',
                            text: '<i class="far fa-copy fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {

                                    return 'ITDA WISE FARMER DETAILS';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'ITDA WISE FARMER DETAILS',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                            title: 'js-tutorials.com : Export to datatable data to Excel',
                            download: 'open',
                            orientation: 'landscape',
                            exportOptions: {
                                columns: ':visible'
                            },

                           
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'ITDA WISE FARMER DETAILS',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'ITDA WISE FARMER DETAILS';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'ITDA WISE FARMER DETAILS',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A0'

                        }
                    ],
                    
                    'columnDefs': [
                        {
                            "targets": [2,3,4,5,6,7,8,9,13],
                            "className": "text-left"

                        },
                    ],
                    fixedColumns: true,

                    columns: [
                       
                        
                            {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                return meta.row + meta.settings._iDisplayStart + 1;
                            }
                        },
                        

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['benficiary_id'];
                            }
                        },
                        

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['ITDA_NAME'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['District'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Mandal'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Village'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Habitation'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTADAAR'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Father_Name'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['SUB_CASTE'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Aadhaar_NO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BankAccountNo'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['IfscCode'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['BankName'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_dist_tbl_wrapper').hide();
                $('#dt_dist_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
            
        },
        
        error: function (result) {
            alert(result);
        }
    });


}


function DownloadAll() {

    $('.preloader').show();
    
    var itdaname = sessionStorage.getItem("ITDA");
    var distname = sessionStorage.getItem("Dist");
   
    
    $('#dt_dist_tbl').hide(); 
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetItda_ben_count',
        data: "{'type':'ExcelDownload','Itda':'" + itdaname + "','DistrictName':'" + distname + "'}",
        dataType: "json",

        success: function (response) {
            console.log(response);
            var rows = "";
            UIDList = response;
            data = response.Data;
            
            for (var i = 0; response.Data != undefined && i < response.Data.length; i++) {
                rows += "<tr><td class='text-right'>" + (i + 1) + "</td><td >" + response.Data[i].benficiary_id + "</td><td>" + response.Data[i].ITDA_NAME + "</td><td >" + response.Data[i].District + "</td><td >" + response.Data[i].Mandal + "</td><td >" + response.Data[i].Village + "</td><td >" + response.Data[i].Habitation + "</td><td >" + response.Data[i].ROFR_PATTADAAR + "</td><td >" + response.Data[i].Father_Name + "</td><td >" + response.Data[i].SUB_CASTE + "</td><td >" + response.Data[i].Aadhaar_NO + "</td><td >" + response.Data[i].BankAccountNo + "</td><td >" + response.Data[i].IfscCode + "</td><td >" + response.Data[i].BankName + "</td></tr>";
            }
            /*$('#tbl_exporttable_to_xls tbody').empty();*/
            $(rows).appendTo("#tbl_exporttable_to_xls tbody");

        },
        
    });

}



    function ExportToExcel(type, fn, dl) {
    var elt = document.getElementById('tbl_exporttable_to_xls');
    var wb = XLSX.utils.table_to_book(elt, {sheet: "sheet1" });
    return dl ?
    XLSX.write(wb, {bookType: type, bookSST: true, type: 'base64' }) :
    XLSX.writeFile(wb, fn || ('ITDA WISE FARMER DETAILS.' + (type || 'xls')));
               }








