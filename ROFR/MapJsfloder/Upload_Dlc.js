var setype = "1";

$(document).ready(function () {

    $('#dt_bplot_tbl').dataTable().fnClearTable();
    $('#dt_bplot_tbl').hide();
    $('#dt_bplot_tbl_wrapper').hide();
    $('#dt_bplot_tbl_filter').hide();
    //var table2 = $('#dt_plot_tbl').DataTable();
    //table2.columns().checkboxes.deselect(true);

    //$('input[type="checkbox"]', table.cells().nodes()).prop('checked', false);
    $('#upload_dlc').hide();
    $("#checkAll").change(function () {
        $("input:checkbox").prop('checked', $(this).prop("checked"));
    });
    $('#preloader').hide();
});




$(function () {
    $('input[type=radio][name=in]').change(function () {
        if (this.value == '1') {
            $("#Ben_multi").val(''); $('#dt_bplot_tbl').dataTable().fnClearTable();
            document.getElementById("Ben_multi").placeholder = "Benificiary Id's";
            $('#upload_dlc').hide();
            setype = "1";
        }
        if (this.value == '2') {
            $("#Ben_multi").val(''); $('#dt_bplot_tbl').dataTable().fnClearTable();
            document.getElementById("Ben_multi").placeholder = "Plot Id's";
            $('#upload_dlc').hide();
            setype = "2";
        }


    });

    $("#Ben_data").click(function () {

        if ($('#Ben_multi').val() == '') {
            alert("Please enter Benificiary Id's"); $('#Ben_multi').focus(); return;
        }


        else {
            Benificiary_details_multi($("#Ben_multi").val());

        }

    });
});
function openj()
{
    alert('hii');
}
function openpdf(pdfpath) {

	 window.open(pdfpath, '_blank');
}
function Benificiary_details_multi(b_id) {
    $('#preloader').show();
    var count = 0;


    //alert(type + b_id);
    //var table1 = $('#dt_plot_tbl').DataTable();
    //table1.columns().checkboxes.deselect(true);
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '../Giribhumi/Rofr_ben_Details',
        data: "{ 'Type':'" + setype + "','Benificiary_id':'" + b_id + "'}",
        dataType: "json",
        // headers:
        //{
        //  Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
        //},
        success: function (response) {
            console.log(response);
            if (response.Status == "1") {
                $('#dt_bplot_tbl').show();
                $('#upload_dlc').show();
                $('#dt_bplot_tbl').dataTable().fnClearTable();

                $('#dt_bplot_tbl').DataTable({
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


                    pageLength: 500,
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
                                 return ' <input type="checkbox" class="dt_check"  name="checkbox" value=" ' + s['id'] + '" >';
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
                                return s['benficiary_id2'];
                            }
                        },
                        {
                            "mData": null,
                            "mRender": function (data, type, s) {
                                return s['id'];

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
                                  if (s['Dlcpath'] != null) {
                                      var viewnew = s['Dlcpath']
                                      var urlBase = 'http://giribhumi.ap.gov.in/asd.html?id=' + b_id + '&assettype=' + setype;
                                      //return "<a href='#'  onclick='return openpdf()'>check</a>"
                                     return "<a id='dlcview' href='#'  onclick='return openpdf("+JSON.stringify(data.Dlcpath)+")' style=' text-decoration: underline;color:red;'>View Dlc</img><a/>";
                                  }
                                  else {
                                      return "Dlc not Uploaded";
                                  }
                              }
                          }



                    ]

                });
                $('#preloader').hide();



            }
            else {
                $('dt - button buttons - excel buttons - html5').hide();
                $('#dt_bplot_tbl').dataTable().fnClearTable();
                $('#dt_bplot_tbl').hide();
                $('#dt_bplot_tbl_wrapper').hide();
                $('#dt_bplot_tbl_filter').hide();

                $('#preloader').hide();
                $("#Ben_multi").val('');
                alert('No Data Found');
            }
        },
        error: function (result) {
            alert("result");
        }
    });
}

/* =========================================================
   CUSTOM YEAR SELECTOR
   ========================================================= */
function createCustomYearSelector() {

    var yearSelect = $('.ui-datepicker-year');

    if (!yearSelect.length) {
        return;
    }

    // Remove old custom selector
    $('.custom-year-selector').remove();

    var selectedYear = parseInt(yearSelect.val(), 10);

    if (isNaN(selectedYear)) {
        selectedYear = new Date().getFullYear();
    }

    // Hide original jQuery UI year dropdown
    yearSelect.css({
        'display': 'none'
    });

    // Create custom wrapper
    var wrapper = $('<div class="custom-year-selector"></div>');

    // Create button
    var button = $('<button type="button" class="custom-year-button"></button>');
    button.text(selectedYear);

    // Create scroll list
    var yearList = $('<div class="custom-year-list"></div>');

    var currentYear = new Date().getFullYear();
    var minYear = 2008;

    // 2026 -> 2008
    for (var year = currentYear; year >= minYear; year--) {

        var yearItem = $('<div class="custom-year-item"></div>');

        yearItem.attr('data-year', year);
        yearItem.text(year);

        if (year === selectedYear) {
            yearItem.addClass('selected');
        }

        yearList.append(yearItem);
    }

    wrapper.append(button);
    wrapper.append(yearList);

    // Put custom selector where original year selector was
    yearSelect.after(wrapper);

    // Open year list
    button.on('click', function (e) {

        e.preventDefault();
        e.stopPropagation();

        $('.custom-year-list').not(yearList).hide();

        yearList.toggle();

        // Scroll selected year into view
        var selectedItem = yearList.find(
            '.custom-year-item[data-year="' + selectedYear + '"]'
        );

        if (selectedItem.length) {

            var itemTop = selectedItem[0].offsetTop;

            yearList.scrollTop(itemTop - 80);
        }
    });

    // Select year
    yearList.find('.custom-year-item').on('click', function (e) {

        e.preventDefault();
        e.stopPropagation();

        var newYear = parseInt($(this).attr('data-year'), 10);

        var input = $('#todate');

        var selectedDate = input.datepicker('getDate');

        if (!selectedDate) {
            selectedDate = new Date();
        }

        var month = selectedDate.getMonth();
        var day = selectedDate.getDate();

        // Handle Feb 29
        if (month === 1 && day === 29) {

            var testDate = new Date(newYear, month, day);

            if (testDate.getMonth() !== month) {
                day = 28;
            }
        }

        var newDate = new Date(
            newYear,
            month,
            day
        );

        var today = new Date();
        var minDate = new Date(2008, 0, 1);

        // Do not allow future date
        if (newDate > today) {
            newDate = today;
        }

        // Do not allow before 01/01/2008
        if (newDate < minDate) {
            newDate = minDate;
        }

        // Set date
        input.datepicker('setDate', newDate);

        // Update selected year
        selectedYear = newYear;

        button.text(newYear);

        // Update selected style
        yearList
            .find('.custom-year-item')
            .removeClass('selected');

        $(this).addClass('selected');

        // Close list
        yearList.hide();
    });

    // Close when clicking outside
    $(document).off('click.customYear').on(
        'click.customYear',
        function () {
            yearList.hide();
        }
    );
}
/* =========================================================
   DLC DATEPICKER
   ========================================================= */
$('#todate').datepicker({

    constrainInput: true,

    dateFormat: "dd/mm/yy",

    changeMonth: true,

    changeYear: true,

    yearRange: "2008:" + new Date().getFullYear(),

    minDate: new Date(2008, 0, 1),

    maxDate: 0,

    onUpdateDatepicker: function () {

        setTimeout(function () {
            createCustomYearSelector();
        }, 10);

    }

});
$(function () {
    $("#upload_dlc").click(function () {
        //if (document.getElementById('check_dt').checked == true) {
        if ($('.dt_check:checkbox:checked').length != 0) {
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0');
            var yyyy = today.getFullYear();
            var hhh = today.getHours();

            today = dd + '/' + mm + '/' + yyyy;

            $("#todate").val("");
            $("#txt_image").val("");

            $("#FileUpload").val("");

            table = $('#dt_bplot_tbl').DataTable();
            //alert(table.column(0).checkboxes.selected());
            var matches = [];
            var checkedcollection = table.$(".dt_check:checked", { "page": "all" });
            checkedcollection.each(function (index, elem) {
                matches.push($(elem).val());
            });

            if (matches.length === 0) {
                alert("Please select at least one beneficiary");
                return;
            }

            console.log("Sending IDS:", matches.join(','));

            //alert(matches);
            $("#ben_id_multiple").text(matches);
            //alert($("#todate").val());
            $("#showupdate").modal('show');
        }
        else {
            alert("Please check on Beneficiary records");
        }
    });


});

$(function () {
    $("#Update_Image").click(function () {
        var data = new FormData();
        var file = $("#FileUpload").get(0).files;
        data.append('file', file[0]);
        data.append("Type", '3');
        data.append('Dlcfile', "Dlcfile");
        data.append('dlc_date', $("#todate").val());
        data.append('ID', $("#ben_id_multiple").text());
        //data.append('username', $("#ContentPlaceHolder1_username").text());
        //data.append('ip', $("#ContentPlaceHolder1_ipadress").text());
        if ($("#todate").val() != "") {

            if ($("#txt_image").val() != "") {
                $('#preloader').show();
                var data1 = $.ajax({
                    type: "POST", url: "../Giribhumi/Multipart_Dlc_Upload", data: data, cache: false, contentType: false, processData: false,
                    //headers:
              //{
                //  Authorization: 'Bearer ' + $("#ContentPlaceHolder1_tk").text()
              //},
                    success: function (res) {
                        console.log(res);
                        if (res.res.Status == "200") {


                            alert("Dlc Uploaded Successfully");
                            Benificiary_details_multi($("#Ben_multi").val());
                        }
                        else if (res.res.Status == "102") {


                            alert("Please enter valid file formats");

                        }
                        else if (res.res.Status == "103") {


                            alert("Only jpeg, png , pdf formats are allowed ");

                        }
                        else if (res.res.Status == "104") {


                            alert("Selected files are not Image or PDF. Please check and select Image or PDF to upload");

                        }
                            //if (res.res.Status == "101") {


                            //    alert("Updation Failed...Plot Id does not exists");

                            //}
                        else {
                            alert(res.res.Message);
                        }
                    },
                    error: function (error) {
                        alert("Dlc Upload Failed.");

                    }
                }, 'json');
                $('#preloader').hide();
                $('#showupdate').modal('toggle');


                $('input[type="checkbox"]:checked').prop('checked', false);

            }
            else {
                alert("Please select Dlc File");
            }
        }
        else {
            alert("Please select Dlc Issued Date");
        }
    });

    //$("#Update_Image").click(function () {

    //    // 🔹 Date validation
    //    if ($("#todate").val() === "") {
    //        alert("Please select Dlc Issued Date");
    //        return;
    //    }

    //    // 🔹 File validation
    //    if ($("#FileUpload")[0].files.length === 0) {
    //        alert("Please select Dlc File");
    //        return;
    //    }

    //    // 🔹 Get selected checkbox IDs
    //    var table = $('#dt_bplot_tbl').DataTable();
    //    var matches = [];

    //    var checkedcollection = table.$(".dt_check:checked", { page: "all" });
    //    checkedcollection.each(function () {
    //        matches.push($(this).val());
    //    });

    //    if (matches.length === 0) {
    //        alert("Please select at least one beneficiary");
    //        return;
    //    }

    //    console.log("Sending IDS:", matches.join(',')); // 🔍 debug

    //    // 🔹 Prepare FormData
    //    var data = new FormData();
    //    data.append("file", $("#FileUpload")[0].files[0]);
    //    data.append("IDS", matches.join(','));   // ✅ MULTIPLE IDS
    //    data.append("TYPE", "3");
    //    data.append("dlc_date", $("#todate").val());

    //    // 🔹 Show loader
    //    $('#preloader').show();

    //    $.ajax({
    //        type: "POST",
    //        url: "/Giribhumi/Multipart_Dlc_Upload",
    //        data: data,
    //        cache: false,
    //        contentType: false,
    //        processData: false,
    //        success: function (res) {
    //            console.log(res);

    //            if (res.res.Status === "1") {
    //                alert("DLC Uploaded Successfully");
    //                Benificiary_details_multi($("#Ben_multi").val());
    //                // 🔹 Close modal
    //                $('#showupdate').modal('hide');
    //                // 🔹 Uncheck checkboxes
    //                $('input.dt_check:checked').prop('checked', false);
                   
    //            }
    //            else if (res.res.Status === "102") {
    //                alert("Please enter valid file formats");
    //            }
    //            else if (res.res.Status === "103") {
    //                alert("Only jpeg, png, pdf formats are allowed");
    //            }
    //            else if (res.res.Status === "104") {
    //                alert("Selected file is not Image or PDF");
    //            }
    //            else {
    //                alert(res.res.Message || "DLC Upload Failed");
    //            }
    //        },
    //        error: function () {
    //            alert("DLC Upload Failed");
    //        },
    //        complete: function () {
    //            // 🔹 Hide loader always
    //            $('#preloader').hide();
    //        }
    //    });
    //});


});