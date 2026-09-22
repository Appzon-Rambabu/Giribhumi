var type = null;
var username = null;
var itdaname = null;
var uend = null;
var table = null
$(document).ready(function () {
    Itda();
    $('#dt_plot_tbl').dataTable().fnClearTable();
    $('#dt_plot_tbl').hide();
    $('#dt_plot_tbl_wrapper').hide();
    $('#dt_plot_tbl_filter').hide();
    //var table2 = $('#dt_plot_tbl').DataTable();
    //table2.columns().checkboxes.deselect(true);
  
    //$('input[type="checkbox"]', table.cells().nodes()).prop('checked', false);

    $("#checkAll").change(function () {
        $("input:checkbox").prop('checked', $(this).prop("checked"));
    });
});

function Itda() {


    username = $("#ContentPlaceHolder1_user").text();
    itdaname = $("#ContentPlaceHolder1_user").text();
    if ($("#ContentPlaceHolder1_ustart").text() == "DTW") {
        itdaname = "DTW";
        uend = $("#ContentPlaceHolder1_end").text()
    }
    if ($("#ContentPlaceHolder1_user").text() == "ALL") {
        username = "ALL";

    }
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ROFR_MASTERS',
        data: "{'UserName':'ALL', 'Type':'14','Itda':'" + itdaname + "','District':'" + uend + "'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Itda').empty();
                $('#Itda').append('<option value=0>Select Itda</option>');
                $.each(response.Data, function (index, value) {
                    $('#Itda').append('<option value="' + value.ITDA_CODE + '">' + value.ITDA_NAME + '</option>');
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
       
        $('#dt_plot_tbl').dataTable().fnClearTable();
        $('#dt_plot_tbl').hide();
        $('#dt_plot_tbl_wrapper').hide();
        $('#dt_plot_tbl_filter').hide();
        $('#Mandal').empty();
        $('#Mandal').append('<option value=0>Select Mandal </option>');
        $('#Village').empty();
        $('#Village').append('<option value=0>Select Village </option>');


        if ($("#Itda").val() == "0") {
            $('#District').empty();
            $('#District').append('<option value=0>Select District </option>');

            alert("Please select Itda"); $("#Itda").focus(); return;
        }

        else {
            if ($("#Itda").val() != "0") {
                //$('#sandtbldr').empty();

                District();

            }
            else {
                alert('No Data Found');
            }
        }
    });


    $("#District").change(function () {
        $('#dt_plot_tbl').dataTable().fnClearTable();
        $('#dt_plot_tbl').hide();
        $('#dt_plot_tbl_wrapper').hide();
        $('#dt_plot_tbl_filter').hide();
        $('#Village').empty();
        $('#Village').append('<option value=0>Select Village </option>');
        if ($("#Itda").val() == "0" && $("#District").val() == "0") {
            $('#Mandal').empty();
            $('#Mandal').append('<option value=0>Select Mandal</option>');

            alert("Please Select Itda"); $("#Itda").focus(); return;
        }

        else if ($("#Itda").val() != "0" && $("#District").val() != "0") {
            Mandal();

        }
        else {
            alert('No Data Found');
        }
    });

    $("#Mandal").change(function () {
        $('#dt_plot_tbl').dataTable().fnClearTable();
        $('#dt_plot_tbl').hide();
        $('#dt_plot_tbl_wrapper').hide();
        $('#dt_plot_tbl_filter').hide();

        if ($("#Itda").val() == "0" && $("#District").val() == "0" && $("#Mandal").val() == "0") {
            $('#Village').empty();
            $('#Village').append('<option value=0>Select Village</option>');

            alert("Please Select Itda"); $("#Itda").focus(); return;
        }

        else if ($("#Itda").val() != "0" && $("#District").val() != "0" && $("#Mandal").val() != "0") {
            Village();

        }
        else {
            alert('No Data Found');
        }
    });
    $("#Village").change(function () {
        $('#dt_plot_tbl').dataTable().fnClearTable();
        $('#dt_plot_tbl').hide();
        $('#dt_plot_tbl_wrapper').hide();
        $('#dt_plot_tbl_filter').hide();


    });
});

function District() {


    //if ($("#ContentPlaceHolder1_user").text() == "ALL") {
    //    var username = "ALL";
    //    type = "1";
    //}
    if ($("#ContentPlaceHolder1_ustart").text() == "DTW") {
        itdaname = "DTW";
        uend = $("#ContentPlaceHolder1_end").text()
    }
    username = $("#ContentPlaceHolder1_user").text();
    itdaname = "";
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ROFR_MASTERS',
        data: "{ 'Type':'15','Itdacode':'" + $("#Itda").val() + "','District':'" + uend + "','Itda':" + itdaname + "}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#District').empty();
                $('#District').append('<option value=0>Select District</option>');
                $.each(response.Data, function (index, value) {
                    $('#District').append('<option value="' + value.LGD_DISTRICT_CODE + '">' + value.DISTRICT_NAME + '</option>');
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
    username = $("#ContentPlaceHolder1_user").text();
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/ROFR_MASTERS',
        data: "{ 'Type':'16','Itdacode':'" + $("#Itda").val() + "',District_Code:'" + $("#District").val() + "'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Mandal').empty();
                $('#Mandal').append('<option value=0>Select Mandal</option>');
                $.each(response.Data, function (index, value) {
                    $('#Mandal').append('<option value="' + value.LGD_MANDAL_CODE + '">' + value.MANDAL_NAME + '</option>');
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
        url: '../Giribhumi/ROFR_MASTERS',
        data: "{ 'Type':'17','Itdacode':'" + $("#Itda").val() + "',District_Code:'" + $("#District").val() + "',Mandal:'" + $("#Mandal option:selected").text() + "'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#Village').empty();
                $('#Village').append('<option value=0>Select Village</option>');
                $.each(response.Data, function (index, value) {
                    $('#Village').append('<option value="' + value.LGD_VILLAGE_CODE + '">' + value.VILLAGE_NAME + '</option>');
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
    $("#btn_submit").click(function () {


        if ($("#Itda").val() != "0" && $("#District").val() != "0" && $("#Mandal").val() != "0" && $("#Village").val() != "0") {
            if ($("#txtInput").val() == "") {

                alert("Please Enter Captcha");
                return false;
            }
            if ($("#txtInput").val() != "") {
                var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
                var string2 = removeSpaces(document.getElementById('txtInput').value);
                if (string1 == string2) {
                    get_plot_data();
                }


                else {

                    alert("enter valid captcha");
                    $("#txtInput").val("");
                    return false;
                }

            }
        }
        else {
            ValidCaptcha();
        }

    });

});

function get_plot_data() {


    $('#loading-wrapper').show();
    var count = 0;
 
  
 
    //var table1 = $('#dt_plot_tbl').DataTable();
    //table1.columns().checkboxes.deselect(true);
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rofr_Plot_Details',
        data: "{ 'Type':'13','Itda':'" + $("#Itda option:selected").text() + "',District:'" + $("#District option:selected").text() + "',Mandal:'" + $("#Mandal option:selected").text() + "',Village:'" + $("#Village option:selected").text() + "'}",
        dataType: "json",
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {



                $('#dt_plot_tbl').show();

                $('#dt_plot_tbl').dataTable().fnClearTable();
              
                $('#dt_plot_tbl').DataTable({
                    aLengthMenu: [
                        [100, 200, 300, 400, -1],
                        [100, 200, 300, 400, "All"]
                    ],
            //        columnDefs: [
            //       {
                      
            //           targets: 0,
            //           checkboxes: {
            //               selectRow: true,
            //               //className:'check_select',
            //           }
            //}
            //        ],
            //       select: {
            //            style: 'multi'
            //        },
            //       order: [[1, 'asc']],


                    pageLength: 50,
                    destroy: true,
                    stateSave: true,
                    bPagenate: true,
                    footer: true,
                    data: response.Data,
                    dom: 'Bfrtip',
                    //paging: true,
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
                                 //return s['benficiary_id'];
                                 //return ' <input type="checkbox" class="dt-checkboxes" name="checkbox" value=" ' + s['ID'] + '">';
                                return ' <input type="checkbox" class="dt_check"  name="checkbox" value=" ' + s['ID'] + '">';
                             }
                         },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                count++;
                                return count;

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
                                return s['ID'];

                            }
                        },


                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['ITDA_NAME'];

                        //    }
                        //},

                        //{


                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['District'];

                        //    }
                        //},

                        //{


                        //    "mData": null,
                        //    "mRender": function (data, type, s) {
                        //        return s['Mandal'];

                        //    }
                        //},
                        //{
                        //    "mData": null,
                        //    "mRender": function (data, type, s) {

                        //        return s['Village'];
                        //    }
                        //},
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

                                 return s['Aadhaar_NO'];
                             }
                         },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return s['Compartment_No'];
                             }
                         },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ROFR_PATTANO'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {

                                return s['ExtentPlotArea'];
                            }
                        },
                         {
                             "mData": null,
                             "mRender": function (data, type, s) {
                                 if (s['Land_Imagepath'] != null && s['Land_Image'] != null) {
                                     var view = s['Land_Imagepath'] + "/" + s['Land_Image']
                                     return "<a id='Limage' href=' " + view + "'  target='_blank' style=' text-decoration: none;color:red'><img id='pimg' src=' " + view + "' height='50px' width='50px' ></img><a/>";
                                 }
                                 else {
                                     return "No Image"
                                 }
                             }
                         },
                          {
                              "mData": null,
                              "mRender": function (data, type, s) {
                                  if (s['Land_Imagepath1'] != null && s['Land_Image1'] != null) {
                                      var viewnew = s['Land_Imagepath1'] + "/" + s['Land_Image1']
                                      return "<a id='Limagenew' href=' " + viewnew + "'  target='_blank' style=' text-decoration: none;color:red'><img id='pimgnew' src=' " + viewnew + "' height='50px' width='50px' ></img><a/>";
                                  }
                                  else {
                                      return "No Image"
                                  }
                              }
                          },

                         {
                             "mData": null,
                             "mRender": function (data, type, s) {

                                 return "<a id='update' onclick='Updatestatus(this);' style='background-color:green;color:white;' >UpdateImage</a>";
                             }
                         },

                    ]

                });
                $('#loading-wrapper').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_plot_tbl').dataTable().fnClearTable();
                $('#dt_plot_tbl').hide();
                $('#dt_plot_tbl_wrapper').hide();
                $('#dt_plot_tbl_filter').hide();

                $('#loading-wrapper').hide();
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("Error");
        }
    });
}
function Updatestatus() {

  
    $("#txt_image").val("");
    $('#user_img').attr('src', "");
    $("#txt_imagenew").val("");
    $('#user_imgnew').attr('src', "");
    $("#FileUpload").val("");
    $("#FileUpload1").val("");
    table = $('#dt_plot_tbl').DataTable();
    //alert(table.column(0).checkboxes.selected());
    var matches = [];
    var checkedcollection = table.$(".dt-checkboxes:checked", { "page": "all" });
    checkedcollection.each(function (index, elem) {
        matches.push($(elem).val());
    });

    alert(matches);
    $('#dt_plot_tbl tbody').on('click', 'tr', function () {
        console.log(table.row(this).data());
        var tbldata1 = table.row(this).data();

        $("#ben_id").text(tbldata1.benficiary_id2);
        $("#plot_id").text(tbldata1.ID);
        $("#farmer_name").text(tbldata1.ROFR_PATTADAAR);
        $("#p_extent").text(tbldata1.ExtentPlotArea);


    });
    $("#showupdate").modal('show');
}

$(function () {
    $("#Update_Image").click(function () {


        var data = new FormData();
        var file = $("#FileUpload").get(0).files;

        var file1 = $("#FileUpload1").get(0).files;

        data.append('file', file[0]);
        data.append('file1', file1[0]);
        data.append("Type", '14');
        data.append('ClientDocs', "ClientDocs");
        data.append('benid', $("#ben_id").text());
        data.append('id', $("#plot_id").text());
        data.append('username', $("#ContentPlaceHolder1_username").text());
        data.append('ip', $("#ContentPlaceHolder1_ipadress").text());
        if ($("#txt_image").val() != "" && $("#txt_imagenew").val() != "") {
            $('#loading-wrapper').show();
            var data1 = $.ajax({
                type: "POST", url: "../Giribhumi/MultipartImage_Upload", data: data, cache: false, contentType: false, processData: false,
                success: function (res) {
                    console.log(res);
                    if (res.res.Status == "1") {


                        alert("Land Image Uploaded Successfully");
                        get_plot_data();
                    }
                    if (res.res.Status == "101") {


                        alert("Updation Failed...Plot Id does not exists");

                    }
                    else {
                        alert("Land Image Upload Failed.");
                    }
                },
                error: function (error) {
                    alert("Land Image Upload Failed.");

                }
            }, 'json');
            $('#loading-wrapper').hide();
            $('#showupdate').modal('toggle');
        }
        else {
            alert("Please select Land Images");
        }
    });


});

function ValidCaptcha() {

    var itda = document.getElementById("Itda").value;
    var dist = document.getElementById("District").value;
    var mandal = document.getElementById("Mandal").value;
    var village = document.getElementById("Village").value;

    var captcha = document.getElementById('txtInput').value;
    if (itda == "0") {

        alert("Please Select Itda!");
        return false;
    }
    if (dist == "0") {

        alert("Please Select district");
        return false;
    }
    if (mandal == "0") {

        alert("Please Select Mandal");
        return false;
    }
    if (village == "0") {

        alert("Please Select Village");
        return false;
    }

    //if (captcha != "") {


    //    var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
    //    var string2 = removeSpaces(document.getElementById('txtInput').value);
    //    if (string1 == string2) {
    //        return true;
    //    }


    //    else {

    //        alert("enter valid captcha");

    //        return false;
    //    }
    //}
}
function removeSpaces(string) {
    return string.split(' ').join('');
}

