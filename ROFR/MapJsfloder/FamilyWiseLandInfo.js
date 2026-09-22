var type = "3.2LACS REPORT";
var username = null;
var itdaname = null;
var uend = null;
var table = null

$(document).ready(function () {
    abstarct_tbl_data();
   Itda();
    $('#land_table').dataTable().fnClearTable();
    $('#land_table').hide();
    $('#land_table_wrapper').hide();
    $('#land_table_filter').hide();
    $('#Rythu_tbl').dataTable().fnClearTable();
    $('#Rythu_tbl').hide();
    $('#Rythu_tbl_wrapper').hide();
    $('#Rythu_tbl_filter').hide();
    $('#landexcel').hide();
    $('#Rythuexcel').hide();
    $("#land_table").rowspanizer({
        vertical_align: 'middle',
        columns: [1],

    });
    if ($("input[name='inl']:checked").val() == "3") {
        $('#Status').empty();
        $('#Status').append('<option value=0>Select Status</option>');
        $('#Status').append('<option value=ALL>ALL</option>');
        $('#Status').append('<option value=GRAETERTHAN>>2Acres</option>');
        $('#Status').append('<option value=LESSTHAN><2Acres</option>');
        $('#Status').append('<option value=NOLAND>No Land</option>');
        $('#Status').append('<option value=SUBMERGED>Sub-Merged/Migrated/In-Eligible</option>');
        


    }
    if ($("input[name='inl']:checked").val() == "4") {
        $('#Status').empty();
        $('#Status').append('<option value=0>Select Status</option>');
        $('#Status').append('<option value=ALL>ALL</option>');
        $('#Status').append('<option value=SANCTIONED>Sanctioned</option>');
        $('#Status').append('<option value=REJECTED>Rejected</option>');
        $('#Status').append('<option value=NOT HAVING LAND>Not in Webland</option>');
        $('#Status').append('<option value=HAVING LAND>Not in Webland-having land details</option>');
       
    }
    $('#Status').prop('selectedIndex', 1);
    var s = $("#ContentPlaceHolder1_tk").text()
});

function Itda() {


    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{'Type':'1'}",
        dataType: "json",
        headers:
               {
                   Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
               },
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Itda').empty();
                $('#Itda').append('<option value=0>Select Itda</option>');
                $.each(response.Data, function (index, value) {
                    $('#Itda').append('<option value="' + value.ITDA + '">' + value.ITDA + '</option>');
                });
            }
            else {
                $('#Itda').empty();
                $('#Itda').append('<option value=0>Select Itda</option>');

                return;
            }
        },
        error: function (result) {
            alert("Error");
        }
    });

}

$(function () {



    $("#Itda").change(function () {

        $('#land_table').dataTable().fnClearTable();
        $('#land_table').hide();
        $('#land_table_wrapper').hide();
        $('#land_table_filter').hide();
        $('#Rythu_tbl').dataTable().fnClearTable();
        $('#Rythu_tbl').hide();
        $('#Rythu_tbl_wrapper').hide();
        $('#Rythu_tbl_filter').hide();
        $('#landexcel').hide();
        $('#Rythuexcel').hide();
        $('#Mandal').empty();
        $('#Mandal').append('<option value=0>Select Mandal </option>');
        $('#Village').empty();
        $('#Village').append('<option value=0>Select Village </option>');

        //$('#Status').empty();
        //$('#Status').append('<option value=0>Select Status</option>');
        if ($("#Itda").val() == "0") {
            $('#District').empty();
            $('#District').append('<option value=0>Select District </option>');
            $('#Mandal').empty();
            $('#Mandal').append('<option value=0>Select Mandal </option>');
            $('#Village').empty();
            $('#Village').append('<option value=0>Select Village </option>');

            $('#Status').empty();
            $('#Status').append('<option value=0>Select Status</option>');
            alert("Please select Itda"); $("#Itda").focus(); return;
        }

        else {
            if ($("#Itda").val() != "0") {
                //$('#sandtbldr').empty();
                abstarct_tbl_data();

                District();

            }
            else {
                alert('No Data Found');
            }
        }
    });


    $("#District").change(function () {
        $('#land_table').dataTable().fnClearTable();
        $('#land_table').hide();
        $('#land_table_wrapper').hide();
        $('#land_table_filter').hide();
        $('#Rythu_tbl').dataTable().fnClearTable();
        $('#Rythu_tbl').hide();
        $('#Rythu_tbl_wrapper').hide();
        $('#Rythu_tbl_filter').hide();
        $('#landexcel').hide();
        $('#Rythuexcel').hide();
        $('#Village').empty();
        $('#Village').append('<option value=0>Select Village </option>');
        //$('#Status').empty();
        //$('#Status').append('<option value=0>Select Village</option>');
        if ($("#Itda").val() == "0" && $("#District").val() == "0") {
            $('#Mandal').empty();
            $('#Mandal').append('<option value=0>Select Mandal</option>');
            $('#Village').empty();
            $('#Village').append('<option value=0>Select Village </option>');
            //$('#Status').empty();
            //$('#Status').append('<option value=0>Select Village</option>');
            alert("Please Select Itda"); $("#Itda").focus(); return;
        }

        else if ($("#Itda").val() != "0" && $("#District").val() != "0") {
            abstarct_tbl_data();

            Mandal();

        }
        else {
            alert('No Data Found');
        }
    });

    $("#Mandal").change(function () {
        $('#land_table').dataTable().fnClearTable();
        $('#land_table').hide();
        $('#land_table_wrapper').hide();
        $('#land_table_filter').hide();
        $('#Rythu_tbl').dataTable().fnClearTable();
        $('#Rythu_tbl').hide();
        $('#Rythu_tbl_wrapper').hide();
        $('#Rythu_tbl_filter').hide();
        $('#landexcel').hide();
        $('#Rythuexcel').hide();
        if ($("#Itda").val() == "0" && $("#District").val() == "0" && $("#Mandal").val() == "0") {
            $('#Village').empty();
            $('#Village').append('<option value=0>Select Village</option>');
            //$('#Status').empty();
            //$('#Status').append('<option value=0>Select Village</option>');
            alert("Please Select Itda"); $("#Itda").focus(); return;
        }

        else if ($("#Itda").val() != "0" && $("#District").val() != "0" && $("#Mandal").val() != "0") {
            abstarct_tbl_data();

            Village();

        }
        else {
            alert('No Data Found');
        }
    });
    $("#Village").change(function () {
        //$('#land_table').dataTable().fnClearTable();
        $('#land_table').hide();
        $('#land_table_wrapper').hide();
        $('#land_table_filter').hide();
       // $('#Rythu_tbl').dataTable().fnClearTable();
        $('#Rythu_tbl').hide();
        $('#Rythu_tbl_wrapper').hide();
        $('#Rythu_tbl_filter').hide();
        $('#landexcel').hide();
        $('#Rythuexcel').hide();
        if ($("#Itda").val() == "0" && $("#District").val() == "0" && $("#Mandal").val() == "0" && $("#Village").val() == "0") {
            $('#Village').empty();
            $('#Village').append('<option value=0>Select Village</option>');

            alert("Please Select Itda"); $("#Itda").focus(); return;
        }

        if ($("#Itda").val() != "0" && $("#District").val() != "0" && $("#Mandal").val() != "0" && $("#Village").val() != "0") {
            abstarct_tbl_data();
           
            if ($("input[name='inl']:checked").val() == "3") {
                if ($('#Status').val() == "ALL") {
                    Land_tbl_data(); 

                }

            }
          
            if ($("input[name='inl']:checked").val() == "4") {
              
                if ($('#Status').val() == "ALL") {
                    Rofr_tbl_data();
                    
                }
            }
          
            
        }

    });

    $("#Status").change(function () {
        $('#land_table').dataTable().fnClearTable();
        $('#land_table').hide();
        $('#land_table_wrapper').hide();
        $('#land_table_filter').hide();
        $('#Rythu_tbl').dataTable().fnClearTable();
        $('#Rythu_tbl').hide();
        $('#Rythu_tbl_wrapper').hide();
        $('#Rythu_tbl_filter').hide();
        $('#landexcel').hide();
        $('#Rythuexcel').hide();
        //if ($("#Itda").val() == "0" && $("#District").val() == "0" && $("#Mandal").val() == "0" && $("#Village").val() == "0") {
        //    $('#Village').empty();
        //    $('#Village').append('<option value=0>Select Village</option>');

        //    alert("Please Select Itda"); $("#Itda").focus(); return;
        //}

        if ($("#Itda").val() != "0" && $("#District").val() != "0" && $("#Mandal").val() != "0" && $("#Village").val() != "0") {
            if ($("#Status").val() == "ALL" || $("#Status").val() == "LESSTHAN" || $("#Status").val() == "GRAETERTHAN" || $("#Status").val() == "NOLAND" || $("#Status").val() == "SUBMERGED") {
                Land_tbl_data();
            }

           else if ($("#Status").val() == "SANCTIONED" || $("#Status").val() == "REJECTED" || $("#Status").val() == "HAVING LAND" || $("#Status").val() == "NOT HAVING LAND") {
                Rofr_tbl_data();
           }
           else {
               
           }

        }

    });

});

function District() {


    //if ($("#ContentPlaceHolder1_user").text() == "ALL") {
    //    var username = "ALL";
    //    type = "1";
    //}

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'2','Itda':'" + $("#Itda").val() + "'}",
        dataType: "json",
        //headers:
        //      {
        //          Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //      },

        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#District').empty();
                $('#District').append('<option value=0>Select District</option>');
                $.each(response.Data, function (index, value) {
                    $('#District').append('<option value="' + value.DIST_NAME_EN + '">' + value.DIST_NAME_EN + '</option>');
                });

            }
            else {
                $('#District').empty();
                $('#District').append('<option value=0>Select District</option>');

                return;
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

function Mandal() {

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'3','Itda':'" + $("#Itda").val() + "',District:'" + $("#District").val() + "'}",
        dataType: "json",
        //headers:
        //      {
        //          Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //      },

        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Mandal').empty();
                $('#Mandal').append('<option value=0>Select Mandal</option>');
                $.each(response.Data, function (index, value) {
                    $('#Mandal').append('<option value="' + value.OFFICE_NAME_EN + '">' + value.OFFICE_NAME_EN + '</option>');
                });

            }
            else {
                $('#Mandal').empty();
                $('#Mandal').append('<option value=0>Select Mandal</option>');

                return;
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

function Village() {
    username = $("#ContentPlaceHolder1_user").text();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'4','Itda':'" + $("#Itda").val() + "',District:'" + $("#District").val() + "',Mandal:'" + $("#Mandal").val() + "'}",
        dataType: "json",
        headers:
              {
                  Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
              },
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Village').empty();
                $('#Village').append('<option value=0>Select Village</option>');
                $.each(response.Data, function (index, value) {
                    $('#Village').append('<option value="' + value.SECRETARIAT_NAME + '">' + value.SECRETARIAT_NAME + '</option>');
                });

            }
            else {
                $('#Village').empty();
                $('#Village').append('<option value=0>Select Village</option>');

                return;
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

$(function () {
    $('input[type=radio][name=in]').change(function () {
        if (this.value == '1') {
            $("#Ben_multi").val(''); $('#dt_bplot_tbl').dataTable().fnClearTable();
            document.getElementById("Ben_multi").placeholder = "Benificiary Id's";
            $('#upload_dlc').hide();
            type = "3.2LACS REPORT";
        }
        if (this.value == '2') {
            $("#Ben_multi").val(''); $('#dt_bplot_tbl').dataTable().fnClearTable();
            document.getElementById("Ben_multi").placeholder = "Plot Id's";
            $('#upload_dlc').hide();
            type = "2";
        }

       
    });


});
function abstarct_tbl_data() {


    $('#preloader').show();
    var count = 0;




    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'" + type + "','Itda':'" + $("#Itda").val() + "',District:'" + $("#District").val() + "',Mandal:'" + $("#Mandal").val() + "',Village:'" + $("#Village").val() + "'}",
        dataType: "json",
        //headers:
        //      {
        //          Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //      },
        success: function (response) {
            console.log(response);
            var trHTML = '';
            if (response.Status == "1") {

                

                $('#abstarct_tbl').show();

                $('#abstarct_tbl').dataTable().fnClearTable();
                $('#abstarct_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                   // pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: false,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    searching: false,
                    paging: false,
                    info: false,
                    //bFilter: false,
                    //ordering: false,
                   searching: false,
                    //iDisplayLength: 10,
                  
                    //destroy: true,
                    //data: res.dailyRepDetsli,
                    //dom: 'Bfrtip',
                    buttons: [
                        {

                            //header: true,

                            //title: etittle,
                            //extend: 'excelHtml5',
                            //text: 'Excel',
                            //titleAttr: 'Excel',
                            //filename: etittle + "  " + "Report",



                        },
                    ],

                    columns: [
                       
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['TOTAL_FAMILIES'];
                            }
                        },
                          {


                              "mData": null,
                              "mRender": function (data, type, s) {
                                  return s['SUBMERGED_FAMILIES'];

                              }
                          },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['LESSTHAN_FAMILIES'];

                            }
                        },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['GRAEATERTHAN_FAMILIES'];

                            }
                        },

                        {


                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['NOLAND_FAMILIES'];

                            }
                        },

                      
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['RB_ELIGIBLE'];
                            }
                        },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['RB_REJECTED'];
                             }
                         },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['RB_NOTCOVERED'];
                            }
                        },

                    ]

                });
                $('#preloader').hide();

               
           

            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#abstarct_tbl').dataTable().fnClearTable();
               // $('#abstarct_tbl').hide();
                $('#abstarct_tbl_wrapper').hide();
                $('#abstarct_tbl_filter').hide();

                $('#preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

function Land_tbl_data() {


    $('#preloader').show();
    var count = 0;




    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'5','Itda':'" + $("#Itda").val() + "',District:'" + $("#District").val() + "',Mandal:'" + $("#Mandal").val() + "',Village:'" + $("#Village").val() + "',REMARKS:'" + $("#Status").val() + "'}",
        dataType: "json",
        //headers:
        //      {
        //          Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //      },

        success: function (response) {
            console.log(response);
            if (response.Status == "1") {

                $('#landexcel').show();
              

                $('#land_table').show();
                $('#land_table').empty();
                $('#land_table').dataTable().fnClearTable();
                $('#land_table').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    // pageLength: 50,

                    pageLength: 5000,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                  
                    data: response.Data,

                    dom: 'Bfrtip',
                    //bFilter: false,
                    //ordering: false,
                    //searching: false,
                    //iDisplayLength: 10,
                    //info: false,
                    //destroy: true,
                    //data: res.dailyRepDetsli,
                    //dom: 'Bfrtip',
                    buttons: [
                        {

                            //header: true,

                            //title: etittle,
                            //extend: 'excelHtml5',
                            //text: 'Excel',
                            //titleAttr: 'Excel',
                            //filename: etittle + "  " + "Report",



                        },
                    ],

                    columns: [

                          {
                              "mData": null,
                              "mRender": function (data, type, s) {
                                  count++
                                  
                                 
                                      return count;
                                 
                              }
                          },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                               
                              
                                    return  s['EXISTING_RC_NUMBER'] ;
                               
                            }
                        },
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {


                                
                        //            return  s['UID_NO'] ;
                               
                        //    }
                        //},


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['MEMBER_NAME_EN'];

                            }
                        },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['WEBLAND_SURVEY_NO'];
                             }
                         },

                        //{


                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['WEBLAND_KHATANO'];

                        //    }
                        //},

                         {


                             "mData": null,
                             "mRender": function (data, type, s) {
                                 return s['FINAL_WEBLAND_EXTENT'];

                             }
                         },
                         
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['COMPARTMENT_NO'];
                             }
                         },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FINAL_ROFR_EXTENT'];
                            }
                        },
                         {
                              "mData": null,
                              "mRender": function (data, type, s) {

                                  return s['DKT_EXTENT'];
                              }
                          },
                          //{
                          //    "mData": null,
                          //    "mRender": function (data, type, s) {

                          //        return s['ROFR_PATTA_NO'];
                          //    }
                          //},
                         
                    {
                        "mData": null,
                        "mRender": function (data, type, s) {

                            return "";
                        }

                    }

                    ]
                    ,
                    "displayLength": 25,
                    "drawCallback": function (settings) {
                        var api = this.api();
                        var rows = api.rows({ page: 'current' }).nodes();
                        var last = null;

                        api.column(1, { page: 'current' }).data().each(function (group, i) {
                            if (last != group.EXISTING_RC_NUMBER.trim()) {
                                $(rows).eq(i).before(
                                    '<tr class="group"><td colspan="8"><h5 align="center" style="color:red;">' + group.EXISTING_RC_NUMBER.trim() + '</h5></td></tr>'
                                );

                                last = group.EXISTING_RC_NUMBER.trim();
                            }
                        });
                    }
                   
                });

           
               
                land_rowspan();
               

            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#land_table').dataTable().fnClearTable();
                //$('#abstarct_tbl').hide();
                //$('#abstarct_tbl_wrapper').hide();
                //$('#abstarct_tbl_filter').hide();

                $('#preloader').hide();
                alert('No Data Found');
            }

           
        },
        error: function (result) {
            alert("Error");
        }
    });



  
}


function Rofr_tbl_data() {


    $('#preloader').show();
    var count = 0;




    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/RB_STATUS',
        data: "{ 'Type':'6','Itda':'" + $("#Itda").val() + "',District:'" + $("#District").val() + "',Mandal:'" + $("#Mandal").val() + "',Village:'" + $("#Village").val() + "',REMARKS:'" + $("#Status").val() + "'}",
        dataType: "json",
        //headers:
        //      {
        //          Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //      },

        success: function (response) {
            console.log(response);
            if (response.Status == "1") {


            
                $('#Rythuexcel').show();
                $('#Rythu_tbl').show();

                $('#Rythu_tbl').dataTable().fnClearTable();
                $('#Rythu_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
                    // pageLength: 50,

                    pageLength: 5000,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,

                    dom: 'Bfrtip',
                    //bFilter: false,
                    //ordering: false,
                    //searching: false,
                    //iDisplayLength: 10,
                    //info: false,
                    //destroy: true,
                    //data: res.dailyRepDetsli,
                    //dom: 'Bfrtip',
                    buttons: [
                        {

                            //header: true,

                            //title: etittle,
                            //extend: 'excelHtml5',
                            //text: 'Excel',
                            //titleAttr: 'Excel',
                            //filename: etittle + "  " + "Report",



                        },
                    ],

                    columns: [

                          {
                              "mData": null,
                              "mRender": function (data, type, s) {
                                  count++
                                 
                                  return count  ;
                                 
                              }
                          },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                               
                                return ' <label style=text-align:center;" class="col2">' + s['EXISTING_RC_NUMBER'] + '</label>';
                              
                            }
                        },


                       //{
                       //     "mData": null,
                       //     "mRender": function (data, type, s) {


                               
                       //         return  s['UID_NO'] ;
                             
                       //     }
                       // },


                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['MEMBER_NAME_EN'];

                            }
                        },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['WEBLAND_SURVEY_NO'];
                             }
                         },

                        //{


                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['WEBLAND_KHATANO'];

                        //    }
                        //},

                         {


                             "mData": null,
                             "mRender": function (data, type, s) {
                                 return s['FINAL_WEBLAND_EXTENT'];

                             }
                         },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['COMPARTMENT_NO'];
                             }
                         },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['FINAL_ROFR_EXTENT'];
                            }
                        },

                          {
                              "mData": null,
                              "mRender": function (data, type, s) {

                                  return s['ROFR_PATTA_NO'];
                              }
                          },
                          {
                              "mData": null,
                              "mRender": function (data, type, s) {

                                  return "";
                              }
                          },
                           {
                               "mData": null,
                               "mRender": function (data, type, s) {

                                   return s['AMOUNT'];
                               }
                           },
                           {
                               "mData": null,
                               "mRender": function (data, type, s) {

                                   return s['REMARKS'];
                               }
                           },
                            {
                                "mData": null,
                                "mRender": function (data, type, s) {

                                    return "";
                                }
                            },
                    

                    

                    ]
                     ,
                    "displayLength": 25,
                    "drawCallback": function (settings) {
                        var api = this.api();
                        var rows = api.rows({ page: 'current' }).nodes();
                        var last = null;

                        api.column(1, { page: 'current' }).data().each(function (group, i) {
                            if (last != group.EXISTING_RC_NUMBER.trim()) {
                                $(rows).eq(i).before(
                                    '<tr class="group"><td colspan="8"><h5 align="center" style="color:red;">' + group.EXISTING_RC_NUMBER.trim() + '</h5></td></tr>'
                                );

                                last = group.EXISTING_RC_NUMBER.trim();
                            }
                        });
                    }

                });
                rythu_rowspan();
                $('#preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#Rythu_tbl').dataTable().fnClearTable();
                //$('#abstarct_tbl').hide();
                //$('#abstarct_tbl_wrapper').hide();
                //$('#abstarct_tbl_filter').hide();

                $('#preloader').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}

function land_excel() {



    $("#land_table").table2excel({
        exclude: ".noExl",
        name: "Worksheet Name",
        filename: 'Land Holding Details',
        fileext: ".xls",
      preserveColors: true
    });
}

function Rythu_excel() {



    $("#Rythu_tbl").table2excel({
        exclude: ".noExl",
        name: "Worksheet Name",
        filename: 'Rythu Bharosa Details',
        fileext: ".xls",
        preserveColors: true
    });
}
$(function () {
    $('input[type=radio][name=inl]').change(function () {
        if (this.value == '3') {
            $('#Status').empty();
            $('#Status').append('<option value=0>Select Status</option>');
            $('#Status').append('<option value=ALL>ALL</option>');
            $('#Status').append('<option value=GRAETERTHAN>>2Acres</option>');
            $('#Status').append('<option value=LESSTHAN><2Acres</option>');
            $('#Status').append('<option value=NOLAND>No Land</option>');
            $('#Status').append('<option value=SUBMERGED>Sub-Merged/Migrated/In-Eligible</option>');
            $('#Status').prop('selectedIndex', 1);
        }
        if (this.value == '4') {
            $('#Status').empty();
            $('#Status').append('<option value=0>Select Status</option>');
            $('#Status').append('<option value=ALL>ALL</option>');
            $('#Status').append('<option value=SANCTIONED>Sanctioned</option>');
            $('#Status').append('<option value=REJECTED>Rejected</option>');
            $('#Status').append('<option value=NOT HAVING LAND>Not in Webland</option>');
            $('#Status').append('<option value=HAVING LAND>Not in Webland-having land details</option>');
            $('#Status').prop('selectedIndex', 1);
        }
      

    });


});



function land_rowspan() {

    $("#land_table").rowspanizer({
        vertical_align: 'middle',
        columns: [1],

    });
}
function rythu_rowspan() {

    $("#Rythu_tbl").rowspanizer({
        vertical_align: 'middle',
        columns: [1],

    });
}
