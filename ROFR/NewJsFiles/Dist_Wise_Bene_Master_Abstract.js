

$(function () {
   
    
    Get_Districts();

   //mandal table hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    //village table hide here
    $('#dt_Vil_tbl').hide();
    $('#dt_Vil_tbl_wrapper').hide();
    $('#dt_Vil_tbl_filter').hide();
    //village details hide here
    $('#dt_Vil_Details_tbl').hide();
    $('#dt_Vil_Details_tbl_wrapper').hide();
    $('#dt_Vil_Details_tbl_filter').hide();
    //Back buttons
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();

    //var t = $('#dt_dist_tbl').DataTable();
    //var counter = '';
    //t.row.add([
    //    '<tr>' +
    //    '<td></td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>1</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>2</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>3</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>4</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>5</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>6</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>7</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>8</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>9</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>10</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>11</td>' +
    //    '</tr>',
    //    '<tr>' +
    //    '<td>12</td>' +
    //    '</tr>',
       
    //    //counter + '',
    //    //counter + '1',
    //    //counter + '2',
    //    //counter + '3',
    //    //counter + '4',
    //    //counter + '5',
    //    //counter + '6',
    //    //counter + '7',
    //    //counter + '8',
    //    //counter + '9',
    //    //counter + '10',
    //    //counter + '11',
    //    //counter + '12',

    //]).draw(true),
    //    counter++;
   

})
   
function Get_Districts() {
    var username = $("#ContentPlaceHolder1_username").text();
    var userprivillages = $("#ContentPlaceHolder1_userprevilages").text();
    var ustart = $("#ContentPlaceHolder1_ustart").text();
    var ITDANAME = $("#ContentPlaceHolder1_end").text();

    $('#dt_Vil_tbl').hide();
    $('#dt_Vil_tbl_wrapper').hide();
    $('#dt_Vil_tbl_filter').hide();

    //Back buttons
    $('#distbackid').hide();
    $('#manbackid').hide();
    $('#villbackid').hide();
    /* $('.preloader').show();*/
    var counter = '';
    var printCounter = 0;
    $.ajax({
        
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDistrict_wise_BeneficiaryMaster_Abstract',
        data: "{ 'type':'District','Itdastart':'" + ustart + "','userprevilages':'" + userprivillages + "','ITDANAME':'" + ITDANAME+"'}",
        dataType: "json",

        success: function (response) {
            if (response.Status == "1") {
                $('.preloader').fadeIn(2000, function () {
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

                                    return 'DISTRICT WISE BENE_MASTER ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'DISTRICT WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',


                        },
                        {
                            extend: 'csvHtml5',
                            title: 'DISTRICT WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                            customize: function () {
                                var t = $('#dt_dist_tbl').DataTable();
                                t.row.add([
                                        counter + '',
                                        counter + '1',
                                        counter + '2',
                                        counter + '3',
                                        counter + '4',
                                        counter + '5',
                                        counter + '6',
                                        counter + '7',
                                        counter + '8',
                                        counter + '9',
                                        counter + '10',
                                        counter + '11',
                                        counter + '12',
                                    //'<tr>' +
                                    //'<td></td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>1</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>2</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>3</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>4</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>5</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>6</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>7</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>8</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>9</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>10</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>11</td>' +
                                    //'</tr>',
                                    //'<tr>' +
                                    //'<td>12</td>' +
                                    //'</tr>',
                                ]).draw(false);
                                counter++;
                            }
                        },
                        
                         {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',
                                    
                                printCounter++;

                                if (printCounter === 1) {
                                    return 'DISTRICT WISE BENE_MASTER ABSTRACT  REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            title: 'DISTRICT WISE BENE_MASTER ABSTRACT  REPORT',
                            orientation: 'landscape',
                            pageSize: 'LEGAL'

                        }
                    ],
                    'columnDefs': [
                        {
                            "targets": [1,2],
                            "className": "text-left"

                        },
                        //{
                        //    "targets": [3, 4, 5],
                        //    "className": "text-right"

                        //}

                    ],
                    fixedColumns: true,
                   
                    columns: [
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.Itda_Name != 'Total:') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                                
                            }

                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['Itda_Name'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.District != 'Total') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Mandals(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.District + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.District + "<a/>";
                                }

                            }
                        },

                        // {
                            // "mData": null,
                            // "mRender": function (data, type, s) {

                                // return s['Total_bneficiaries_dept'];
                            // }
                        // },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Beneficiaries'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Received'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnotavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharisvalid'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnoinvalid'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Banknotavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankinvalid'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FullBankDetails'];
                            }
                        },
                    ],
                });
                    $('.preloader').fadeOut(1000)
                })

               
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_dist_tbl').dataTable().fnClearTable();
                $('#dt_dist_tbl').hide();
                $('#dt_dist_tbl_wrapper').hide();
                $('#dt_dist_tbl_filter').hide();
                /*$('.preloader').hide();*/
                alert('No Data Found');
            }
           
           /* $('.preloader').hide();*/
        },
        error: function (result) {
            alert(result);
        }
    });
        
  
}

function Get_Mandals(data) {
    sessionStorage.setItem('Dist', data.District);
    sessionStorage.setItem('Itdaname', data.Itda_Name);
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    $('#dt_Vil_tbl').hide();
    $('#dt_Vil_tbl_wrapper').hide();
    $('#dt_Vil_tbl_filter').hide();
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
    $('#itdaval1').text(data.Itda_Name);
    $('#distval1').text(data.District);
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDistrict_wise_BeneficiaryMaster_Abstract',
        data: "{ 'type':'Mandal','Itda':'" + data.Itda_Name + "','District':'" + data.District + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_mandal_tbl').show();
                $('#dt_mandal_tbl').dataTable().fnClearTable();
                $('#dt_mandal_tbl').DataTable({
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

                                    return 'MANDAL WISE BENE_MASTER ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'MANDAL WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'MANDAL WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',

                                    printCounter++;

                                if (printCounter === 1) {
                                    return 'MANDAL WISE BENE_MASTER ABSTRACT  REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'MANDAL WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL'

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [1],
                            "className": "text-left"

                        },

                    ],
                    fixedColumns: true,

                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, row, meta, s) {
                                if (data.Mandal != 'Total:') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }

                            }

                        },
                        

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.Mandal != 'Total:') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_Villages(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Mandal + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.Mandal + "<a/>";
                                }
                                

                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Beneficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Received'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnotavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharisvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnoinvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Banknotavaliable'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankinvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FullBankDetails'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_mandal_tbl').dataTable().fnClearTable();
                $('#dt_mandal_tbl').hide();
                $('#dt_mandal_tbl_wrapper').hide();
                $('#dt_mandal_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Get_Villages(data) {
   
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    var district = sessionStorage.getItem('Dist');
    var itdaname = sessionStorage.getItem('Itdaname');
    sessionStorage.setItem('mandalname', data.Mandal);
    $('#dt_dist_tbl').hide();
    $('#dt_dist_tbl_wrapper').hide();
    $('#dt_dist_tbl_filter').hide();
    //Back buttons 
    $('#distbackid').hide();
    $('#manbackid').show();
    $('#villbackid').hide();
    //append val to the lable
    $('#itdaval2').text(itdaname);
    $('#distval2').text(district);
    $('#manval2').text(data.Mandal);
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDistrict_wise_BeneficiaryMaster_Abstract',
        data: "{ 'type':'Village','Itda':'" + itdaname + "','District':'" + district + "','Mandal':'" + data.Mandal + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {

                $('#dt_Vil_tbl').show();
                $('#dt_Vil_tbl').dataTable().fnClearTable();
                $('#dt_Vil_tbl').DataTable({
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

                                    return 'VILLAGE WISE BENE_MASTER ABSTRACT REPORT';

                                }

                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',

                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                orientation: 'landscape',

                                    printCounter++;

                                if (printCounter === 1) {
                                    return 'VILLAGE WISE BENE_MASTER ABSTRACT  REPORT';

                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE BENE_MASTER ABSTRACT  REPORT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'LEGAL'

                        }
                    ],

                    'columnDefs': [
                        {
                            "targets": [1],
                            "className": "text-left"

                        },
                        

                    ],
                    fixedColumns: true,

                    columns: [
                        

                        {
                            "mData": null,
                            "mRender": function (data, type, row,meta, s) {
                                if (data.Village != 'Total:') {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                                else {
                                    return null;
                                }
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                if (data.Village != 'Total:') {
                                    return "<a id='dlcview' href='#'  onclick='return Get_vill_Details(" + JSON.stringify(data) + ")' style=' text-decoration: underline;color:black;'>" + data.Village + "<a/>";
                                }
                                else {
                                    return "<a id='dlcview'  style=' text-decoration:color:black;'>" + data.Village + "<a/>";
                                }


                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Beneficiaries'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Total_Received'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnotavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharisvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Adhharnoinvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankavaliable'];
                            }
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Banknotavaliable'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Bankinvalid'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FullBankDetails'];
                            }
                        },
                    ]

                });
                $('.preloader').hide();
            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_Vil_tbl').dataTable().fnClearTable();
                $('#dt_Vil_tbl').hide();
                $('#dt_Vil_tbl_wrapper').hide();
                $('#dt_Vil_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
function Get_vill_Details(data) {
   
   

    
    //Village table hide here
    $('#dt_Vil_tbl').hide();
    $('#dt_Vil_tbl_wrapper').hide();
    $('#dt_Vil_tbl_filter').hide();
    var district = sessionStorage.getItem('Dist');
    var itdaname = sessionStorage.getItem('Itdaname');
    var mandalname = sessionStorage.getItem('mandalname');
    //Append to Label
    $('#itdaval3').text(itdaname);
    $('#distval3').text(district);
    $('#manval3').text(mandalname);
    $('#villval3').text(data.Village);
    //Back Buttons
    $('#villbackid').show();
    $('#manbackid').hide();
    $('#distbackid').hide();
    $('.preloader').show();
    var count = 0;
    var printCounter = 0;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/GetDistrict_wise_BeneficiaryMaster_Abstract',
        data: "{ 'type':'VDetails','Itda':'" + itdaname + "','District':'" + district + "','Mandal':'" + mandalname + "','Village':'" + data.Village + "'}",
        dataType: "json",

        success: function (response) {

            if (response.Status == "1") {
                $('#dt_Vil_Details_tbl').show();
                $('#dt_Vil_Details_tbl').dataTable().fnClearTable();
                $('#dt_Vil_Details_tbl').DataTable({
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
                                    return 'VILLAGE WISE BENEFICIARYMASTER ABSTRACT';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'excelHtml5',
                            title: 'VILLAGE WISE BENEFICIARYMASTER ABSTRACT',
                            text: '<i class="far fa-file-excel fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'csvHtml5',
                            title: 'VILLAGE WISE BENEFICIARYMASTER ABSTRACT',
                            text: '<i class="fas fa-file-csv fa-lg" style="width:30px"></i>',
                        },
                        {
                            extend: 'print',
                            text: '<i class="fas fa-print fa-lg" style="width:30px"></i>',
                            messageTop: function () {
                                printCounter++;
                                if (printCounter === 1) {
                                    return 'VILLAGE BENEFICIARYMASTER ABSTRACT';
                                }
                                else {
                                    return 'You have printed this document ' + printCounter + ' times';
                                }
                            },
                            messageBottom: null
                        },
                        {
                            extend: 'pdfHtml5',
                            title: 'VILLAGE WISE BENEFICIARYMASTER ABSTRACT',
                            text: '<i class="far fa-file-pdf fa-lg" style="width:30px"></i>',
                            orientation: 'landscape',
                            pageSize: 'A4',
                        }
                    ],



                    'columnDefs': [
                        {
                            "targets": [1,2,3,7],
                            "className": "text-left"

                        },
                    ],
                    fixedColumns: true,

                    columns: [
                        {
                            "mData": null,
                            "mRender": function (data, type,row, meta, s) {

                                return meta.row + meta.settings._iDisplayStart + 1;
                            }
                           
                        },

                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['Rofr_Pattadaar'];
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

                                return s['Sub_Caste'];
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
                $('#dt_Vil_Details_tbl').dataTable().fnClearTable();
                $('#dt_Vil_Details_tbl').hide();
                $('#dt_Vil_Details_tbl_wrapper').hide();
                $('#dt_Vil_Details_tbl_filter').hide();

                $('.preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert(result);
        }
    });


}

$('#distbackid').click(function () {
    Get_Districts();
    //Mandal table hide here
    $('#dt_mandal_tbl').hide();
    $('#dt_mandal_tbl_wrapper').hide();
    $('#dt_mandal_tbl_filter').hide();
    $('#distbackid').show();
    $('#manbackid').hide();
    $('#villbackid').hide();
});

$('#manbackid').click(function () {
    var district = sessionStorage.getItem('Dist');
    var itdaname = sessionStorage.getItem('Itdaname');

    var data = {};
    data.District = district;
    data.Itda_Name = itdaname;

    Get_Mandals(data);
    //village table hide here
    $('#dt_Vil_tbl').hide();
    $('#dt_Vil_tbl_wrapper').hide();
    $('#dt_Vil_tbl_filter').hide();

    $('#villbackid').hide();
    $('#distbackid').show();
    $('#manbackid').hide();
});

$('#villbackid').click(function () {
    var district = sessionStorage.getItem('Dist');
    var itdaname = sessionStorage.getItem('Itdaname');
    var mandalname = sessionStorage.getItem('mandalname');

    var data = {};
    data.District = district;
    data.Mandal = mandalname;
    data.Itda_Name = itdaname;

    Get_Villages(data);
    //village details having table hide here
   
    $('#dt_Vil_Details_tbl').hide();
    $('#dt_Vil_Details_tbl_wrapper').hide();
    $('#dt_Vil_Details_tbl_filter').hide();
   

    $('#villbackid').hide();
    $('#distbackid').hide();
    $('#manbackid').show();
});